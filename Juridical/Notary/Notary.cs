using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Legal
{
    /// <summary>
    /// دفتر اسناد رسمی: محضر
    /// </summary>
    class JNotary : JLegal
    {
        #region Constructor
        public JNotary()
        {
        }
        public JNotary(int pCode)
        {
            this.GetData(pCode);
        }
        #endregion
        #region property
         


        public int Code { get; set; }
        /// <summary>
        /// شماره دفتر اسناد رسمی
        /// </summary>
        public int NumNotary { get; set; }

        /// <summary>
        /// نام سر دفتر اسناد رسمی
        /// </summary>
        public string HeadOffice { get; set; }

        /// <summary>
        /// نام دفتر یار اسناد رسمی
        /// </summary>
        public string Assistant { get; set; }
        /// <summary>
        /// کدشهر اقامت گاه دفتر اسناد رسمی
        /// </summary>
        public int City { get; set; }
        /// <summary>
        /// کد استان اقامتگاه دفتر اسنادرسمی
        /// </summary>
        
        public string Address { get; set; }
        /// <summary>
        /// تلفن دفتر اسناد رسمی
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// تلفن همراه دفتر اسناد رسمی
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// نمابر دفتر اسناد رسمی
        /// </summary>
        public string Fax { get; set; }
        #endregion
        #region SearchMethod
        public bool GetData(int pCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                string Query = "select * from " + JTableNamesLegal.NotaryTable + " where Code=" + pCode.ToString();
                Db.setQuery(Query);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                Db.Dispose();
            }
        }
        /// <summary>
        /// دفتر اسناد رسمی را براساس شماره دفتر پیدا می کند
        /// </summary>
        /// <param name="pNumNotary"></param>
        /// <returns></returns> 
        public bool Find(int pNumNotary, int pCityCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from " + JTableNamesLegal.NotaryTable +
                        " where NumNotary=" + pNumNotary.ToString() +
                        " AND " + JNotaryTableEnum.City.ToString() + "=" + pCityCode.ToString();
                Db.setQuery(Query);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                Db.Dispose();
            }
        }
        #endregion
        #region Method
       
        /// <summary>
        /// اطلاعات یک دفتر اسناد رسمی را درج می کند
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
         return Insert(true);
        }
        public int Insert(bool pRefreshNode)
        {
            if (JPermission.CheckPermission("Legal.JNotary.Insert"))
            {
                if (Find(this.NumNotary, this.City))
                {
                    JMessages.Error("اطلاعات دفتر اسناد رسمی  تکراری می باشد", "خطا در ورود اطلاعات");
                    return 0;
                }
                else
                {
                    int RejectCode;
                    int defaultCode = 99;
                    JNotaryTable JNT = new JNotaryTable();
                    try
                    {
                        JNT.SetValueProperty(this);
                        RejectCode = JNT.Insert(defaultCode);
                        Code = RejectCode;
                        if (Code > 0)
                        {
                                Histroy.Save(this, JNT, Code, "Insert");
                            try
                            {
                                if (pRefreshNode)
                                    Nodes.DataTable.Merge(JNotarys.GetDataTable(Code));
                            }
                            catch
                            {
                            }
                            return RejectCode;
                        }
                        else
                            return -1;

                    }
                    catch (Exception ex)
                    {
                        JSystem.Except.AddException(ex);
                        return 0;
                    }
                    finally
                    {
                        JNT.Dispose();
                    }
                }
            }
            else
                return -1;
        }

        /// <summary>
        /// دفتر اسناد رسمی را ویرایش می کند
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JNotaryTable JNT = new JNotaryTable();
            try
            {
                if (JPermission.CheckPermission("Legal.JNotary.Update"))
                {
                    JNT.SetValueProperty(this);
                    if (JNT.Update())
                    {
                        Histroy.Save(this, JNT, Code, "Update");
                        Nodes.Refreshdata(Nodes.CurrentNode, JNotarys.GetDataTable(this.Code).Rows[0]);
                        return true;
                    }
                    return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                JNT.Dispose();
            }

        }

        /// <summary>
        /// دفتر اسناد رسمی را حذف می کند
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            JNotaryTable JTN = new JNotaryTable();
            try
            {
                if (JPermission.CheckPermission("Legal.JNotary.Delete"))
                {
                    JTN.SetValueProperty(this);
                    if (JMessages.Question("Are You Sure?", "Delete") == System.Windows.Forms.DialogResult.Yes && JTN.Delete())
                    {
                        Nodes.Delete(Nodes.CurrentNode);
                        Histroy.Save(this, JTN, Code, "Delete");
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                JTN.Dispose();
            }
        }
        

        #endregion
        #region ShowData


        public void ShowDialog()
        {
            ShowDialog(true);
        }
        public void ShowDialog(bool pRefreshNode)
        {
            if (this.Code == 0)
            {
                JNotaryForm JNF = new JNotaryForm();
                JNF.RefreshNode = pRefreshNode;
                JNF.State = JFormState.Insert;
                JNF.ShowDialog();
            }
            else
            {
                JNotaryForm JNF = new JNotaryForm(this.Code);
                JNF.State = JFormState.Update;
                JNF.ShowDialog();
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow[JNotaryTableEnum.Code.ToString()], " Legal.JNotary");
            Node.Name =  pRow[JNotaryTableEnum.NumNotary.ToString()] + "-" + pRow[JNotaryTableEnum.City.ToString()];
            Node.Hint = JLanguages._Text("headOffice") + "\n" + pRow[JNotaryTableEnum.HeadOffice.ToString()];
            Node.Icone = JImageIndex.Default.GetHashCode();
            //اکشن جدید
            JAction NewAction = new JAction("new...", "Legal.JNotary.ShowDialog", null, null);
            //اکشن ویرایش
            JAction editAction = new JAction("edit...", "Legal.JNotary.ShowDialog", null, new object[] { Node.Code });
            Node.MouseDBClickAction = editAction;
            Node.EnterClickAction = editAction;
            //اکشن حذف
            JAction delete = new JAction("delete...", "Legal.JNotary.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = delete;

            Node.Popup.Insert(NewAction);
            Node.Popup.Insert(editAction);
            Node.Popup.Insert(delete);

            return Node;
        }

            
        #endregion

    }

    class JNotarys : JSystem
    {
        static string  QoueryDataTable = "select "+JTableNamesLegal.NotaryTable+".Code,NumNotary,"
            + " CAST( NumNotary as nvarchar(10)) + ' (سردفتر: ' + HeadOffice+ ')' FullName,HeadOffice, Assistant ,"
            +JTableNamesClassLibrary.SubBaseDefine+".name City,Address,Tel,Mobile,Fax from "
            +JTableNamesLegal.NotaryTable+" inner join  "
            +JTableNamesClassLibrary.SubBaseDefine+" on "+JTableNamesLegal.NotaryTable+".City="
            +JTableNamesClassLibrary.SubBaseDefine+".Code";
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        /// <summary>
        /// دفتر اسناد رسمی را براساس شماره دفتر پیدا می کند
        /// </summary>
        /// <param name="pNumNotary"></param>
        /// <returns></returns> 
        public static DataTable Find(int pNumNotary)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select Code,City from " + JTableNamesLegal.NotaryTable + " where NumNotary='" + pNumNotary + "'";
                Db.setQuery(Query);
                return Db.Query_DataTable();            
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }

        /// <summary>
        /// نام شهر دفنر 
        /// </summary>
        /// <param name="pNumNotary"></param>
        /// <returns></returns> 
        public static DataTable FindCity(int pNumNotary)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select N.Code as Code,SD.Name as city from " + JTableNamesLegal.NotaryTable + " N inner join subdefine SD on N.City=SD.Code  where NumNotary='" + pNumNotary + "'";
                Db.setQuery(Query);
                return Db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }

        public static DataTable GetDataTable(int pCode)
        {
            //string Where = " Where " +                JPermission.getObjectSql("Legal.JNotarys.GetDataTable", JTableNamesLegal.NotaryTable + ".Code");
            string Where = " ";
            if (pCode > 0)
                Where = Where + " Where " + JTableNamesLegal.NotaryTable + ".Code=" + pCode;            
            JDataBase Db = new JDataBase();
            try
            {
                Db.setQuery(QoueryDataTable + Where);
                return Db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }

        public void ListView()
        {
            Nodes.ObjectBase = new JAction("NewNode", "Legal.JNotary.GetNode");
            Nodes.DataTable = GetDataTable(0);
            //اکشن جدید
            JAction newaction = new JAction("new...","Legal.JNotary.ShowDialog",null,null);
            Nodes.GlobalMenuActions.Insert(newaction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Icon = JImageIndex.Add;
            JTN.Click = newaction;
            Nodes.AddToolbar(JTN);
        }
        

    }
}
