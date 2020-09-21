using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
namespace Legal
{
    public class JContractdefine : JLegal
    {
        #region Properties
        /// <summary>
        /// کد
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// نوع قرارداد
        /// </summary>
        public int ContractType { get; set; }
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title { get; set; }

        #endregion

        #region سازنده

        public JContractdefine()
        {
        }
        public JContractdefine(int pCode)
        {
            Code=pCode;
            GetData(Code);
        }

        #endregion

        #region Methods Insert,Update,delete,GetData

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert(JDataBase DB)
        {
            JContractdefineTable PDT = new JContractdefineTable();
            try
            {
                PDT.SetValueProperty(this);
                Code = PDT.Insert(DB);
                if (Code > 0)
                {
                    Histroy.Save(this, PDT, PDT.Code, "Insert");
                    //Nodes.DataTable.Merge(JContractdefines.GetDataTable(Code,0, DB));
                }
                return Code;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return -1;
            }
            finally
            {
                PDT.Dispose();
            }
        }
        /// <summary>
        ///بروزرسانی   
        /// </summary>
        /// <returns></returns>
        public bool Update(JDataBase pDB)
        {
            JContractdefineTable PDT = new JContractdefineTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Update(pDB))
                {
                    Histroy.Save(this, PDT, PDT.Code, "Update");
//                    Nodes.CurrentNode.Name = Title;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }
         /// <summary>
        /// حذف 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool delete()
        {
            JDataBase DB = new JDataBase();
            DB.setQuery("Select Code From legSubjectContract WHERE Type = " + Code.ToString());
            if (DB.Query_DataReader())
                if (DB.DataReader.Read())
                {
                    JMessages.Error("برای این متن قرارداد ثبت شده است. امکان حذف متن وجود ندارد.", "حذف");
                    return false;
                }

            if (JMessages.Question("آیا میخواهید متن انتخاب شده حذف شود؟", "حذف متن؟") != System.Windows.Forms.DialogResult.Yes)
            {
                return false;
            }
            JContractdefineTable PDT = new JContractdefineTable();
            try
            {
                OfficeWord.JOfficeWord Office = new OfficeWord.JOfficeWord();
                Office.GetData("Legal.JContractdefine", this.Code);

                DB.beginTransaction("DELETE WORD");

                ArchivedDocuments.JArchiveDataBase adb = new ArchivedDocuments.JArchiveDataBase();
                adb.beginTransaction("");
                DB.ADDRelation(adb);
                
                if (Office.Delete(adb))
                {
                    PDT.SetValueProperty(this);
                    if (PDT.Delete(DB))
                    {
                        if (DB.Commit())
                        {
                            Histroy.Save(this, PDT, PDT.Code, "Delete");
                            //Nodes.Delete(Nodes.CurrentNode);
                            return true;
                        }
                        else
                        {
                            DB.Rollback("DELETE WORD");
                            return false;
                        }
                    }
                    else
                    {
                        DB.Rollback("DELETE WORD");
                        return false;
                    }
                }
                else
                {
                    DB.Rollback("DELETE WORD");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                DB.Rollback("DELETE WORD");
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }
      

        //private bool delete(JDataBase pDB, int pCode)
        //{

        //    JDataBase DB;
        //    if (pDB == null)
        //        DB = new JDataBase();
        //    else
        //        DB = pDB;
        //    if (JMessages.Question("آیا میخواهید متن انتخاب شده حذف شود؟", "حذف متن؟") != System.Windows.Forms.DialogResult.Yes)
        //    {
        //        return false;
        //    }
        //    JContractdefineTable PDT = new JContractdefineTable();
        //    try
        //    {
        //        OfficeWord.JOfficeWord Office = new OfficeWord.JOfficeWord();
        //        Office.GetData("Legal.JContractdefine", pCode);

        //        DB.beginTransaction("DELETE WORD");

        //        if (Office.Delete(pDB))
        //        {
        //            PDT.SetValueProperty(this);
        //            if (PDT.Delete(pDB))
        //            {
        //                Histroy.Save(this, PDT, PDT.Code, "Delete");
        //                Nodes.Delete(Nodes.CurrentNode);
        //                return true;
        //            }
        //            else
        //            {
        //                DB.Rollback("DELETE WORD");
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            DB.Rollback("DELETE WORD");
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Except.AddException(ex);
        //        DB.Rollback("DELETE WORD");
        //        return false;
        //    }
        //    finally
        //    {
        //        DB.Dispose();
        //    }
        //}
        /// <summary>
        /// حذف 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool DeleteManual(string exp, JDataBase pDB)
        {
            JContractdefineTable PDT = new JContractdefineTable();
            try
            {
                return PDT.DeleteManual(exp, pDB);
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }
        /// <summary>
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesLegal.ContractType + " WHERE Code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }
         #endregion

        #region ShowData

        public void ShowDialog()
        {
            if (this.Code == 0)
            {
                JdocumentdefineForm JNF = new JdocumentdefineForm(this.ContractType);
                JNF.State = JBaseContractForm.JStateContractForm.Insert;
                JNF.ShowDialog();
            }
            else
            {
                JdocumentdefineForm JNF = new JdocumentdefineForm(this.ContractType, this.Code);
                JNF.State = JBaseContractForm.JStateContractForm.Update;
                JNF.ShowDialog();
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "Legal.JContractdefine");
            Node.Icone = JImageIndex.testimonial.GetHashCode();
            Node.Name = pRow["Title"].ToString();
            Node.Hint = pRow["Title"].ToString();

            //اکشن جدید
            JAction NewAction = new JAction("new...", "Legal.JContractdefine.ShowDialog", null, null);
            //اکشن ویرایش
            JAction editAction = new JAction("edit...", "Legal.JContractdefine.ShowDialog", null, new object[] { Node.Code });
            Node.MouseDBClickAction = editAction;
            Node.EnterClickAction = editAction;
            //اکشن حذف
            JAction delete = new JAction("delete...", "Legal.JContractdefine.delete", new object[] { Node.Code }, null);
            Node.DeleteClickAction = delete;

            Node.Popup.Insert(NewAction);
            Node.Popup.Insert(editAction);
            Node.Popup.Insert(delete);

            return Node;
        }

        #endregion
    }

    public class JContractdefines : JSystem
    {
        public JContractdefines[] Items = new JContractdefines[0];
        public static DataTable GetDataTable()
        {
            return GetDataTable(0, 0, null);
        }

        public static DataTable GetDataTable(int pCode, int pTypeCode, JDataBase pDB)
        {
            string Where = "select * from legContractType WHERE 1=1 ";
            if (pCode > 0)
            {
                Where += " AND Code=" + pCode;
            }
            if (pTypeCode > 0)
            {
                Where += " AND " + JContractdefineEnum.ContractType.ToString() + "=" + pTypeCode.ToString();
            }
            //Where = Where + " And " + JPermission.getObjectSql("Legal.JContractdefines.GetDataTable", "legContractType.Code");
            JDataBase Db;
            if (pDB == null)
                Db = JGlobal.MainFrame.GetDBO();
            else
                Db = pDB;
            try
            {
                Db.setQuery(Where);
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
            Nodes.ObjectBase = new JAction("NewNode", "Legal.JContractdefine.GetNode");
            Nodes.DataTable = GetDataTable();
            //اکشن جدید
            JAction newaction = new JAction("new...", "Legal.JContractdefine.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newaction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Icon = JImageIndex.Add;
            JTN.Click = newaction;
            Nodes.AddToolbar(JTN);
        }
    }
}
