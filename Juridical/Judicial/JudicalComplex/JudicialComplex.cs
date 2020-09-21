using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Legal
{
    public class JJudicialComplex:JLegal
    {
        #region Constructor
        public JJudicialComplex()
        {
        }

        public JJudicialComplex(int pCode)
        {
            GetData(pCode);
        }

        #endregion

        #region Property
        /// <summary>
        /// کد مجتمع قضایی
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// نام مجتمع قضایی
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// کد شهر محل اقامت مجتمع قضایی 
        /// </summary>
        public int City { get; set; }
        /// <summary>
        /// آدرس اقامت گاه مجتمع قضایی
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// تلفن مجتمع قضایی
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// نمابر مجتمع قضایی
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// نام سرپرست مجتمع قضایی
        /// </summary>
        public string SupervisorNameComplex { get; set; }


        #endregion

        #region  SearchMethod
        /// <summary>
        /// مشخص می کند که شعبه قضایی با این عنوان در سیستم ثبت شده است یا نه
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public bool Find(string Name)
        {
            JDataBase db = new JDataBase();
            try
            {
                string Query = "select * from " + JTableNamesLegal.JudicialComplex + " where Name=N'" + Name + "'";
                db.setQuery(Query);
                db.Query_DataReader();
                if (db.DataReader.Read())
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
                db.Dispose();
            }
        }

        public bool GetData(int Pcode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from " + JTableNamesLegal.JudicialComplex + " where Code='" + Pcode + "'";
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
        /// تعداد شعبه های این مجتمع
        /// </summary>
        /// <returns></returns>
        public int GetBranchesCount()
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select Count(*) from " + JTableNamesLegal.JudicialBranch + " where " + JJudicialBranchEnum.JudicialComplex.ToString() + " = " + this.Code.ToString();
                Db.setQuery(Query);
                int result = (int)Db.Query_ExecutSacler();
                return result;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                Db.Dispose();
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// اطلاعات مجتمع قضایی را درج می کند
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            if (JPermission.CheckPermission("Legal.JJudicialComplex.Insert"))
            {
                if (Find(this.Name))
                {
                    JMessages.Error("مجتمع قضایی با این عنوان قبلا ایجاد شده است", "خطا در ثبت اطلاعات");
                    return 0;
                }
                else
                {
                    JDataBase Db = JGlobal.MainFrame.GetDBO();
                    int returnCode;
                    try
                    {
                        JJudicalComplexTable JudicalTable = new JJudicalComplexTable();
                        JudicalTable.SetValueProperty(this);
                        returnCode = JudicalTable.Insert(99);
                        if (returnCode > 0)
                        {
                            this.Code = returnCode;
                            Histroy.Save(this, JudicalTable, Code, "Insert");
                            Nodes.DataTable.Merge(JJudicialComplexs.GetDataTable(returnCode));
                        }
                        return returnCode;

                    }
                    catch (Exception ex)
                    {
                        JSystem.Except.AddException(ex);
                        return 0;
                    }
                }
            }
            else
                return -1;
        }
        public bool Update()
        {
            if (JPermission.CheckPermission("Legal.JJudicialComplex.Update"))
            {

                //if (Find(this.Name))
                //{
                //    JMessages.Error("مجتمع قضایی با این عنوان قبلا ایجاد شده است", "خطا در ثبت اطلاعات");
                //    return false;
                //}
                //else
                {
                    JJudicalComplexTable jct = new JJudicalComplexTable();
                    jct.SetValueProperty(this);
                    jct.Update();
                    Histroy.Save(this, jct, Code, "Update");
                    Nodes.Refreshdata(Nodes.CurrentNode, JJudicialComplexs.GetDataTable(Code).Rows[0]);
                    return true;
                }
            }
            else
                return false;
        }
        public bool Delete()
        {
            if (JPermission.CheckPermission("Legal.JJudicialComplex.Delete"))
            {
                if (GetBranchesCount() > 0)
                {
                    JMessages.Error("ComplexHasBranches", "Error");
                    return false;
                }

                string[] parameters = { "@Item", };
                string[] values = { "JudicalComplex" };
                string msg = JLanguages._Text("YouWantToDelete?", parameters, values);
                if (JMessages.Question(msg, "Confirm?") != System.Windows.Forms.DialogResult.Yes)
                {
                    return false;
                }

                JJudicalComplexTable JudicalComplexTable = new JJudicalComplexTable();
                try
                {
                    JudicalComplexTable.SetValueProperty(this);
                    JudicalComplexTable.Delete();
                    Nodes.Delete(Nodes.CurrentNode);
                    return true;
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                    return false;
                }
                finally
                {
                    JudicalComplexTable.Dispose();
                }
            }
            else
                return false;
        }
        public override string ToString()
        {
            return this.Name;
        }
        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow[JJudicalComplexTableEnum.Code.ToString()], "Legal.JJudicialComplex");
            Node.Name = pRow["Title"].ToString();
            Node.Icone = JImageIndex.Default.GetHashCode();
            Node.Hint = JLanguages._Text("City:") + pRow[JJudicalComplexTableEnum.City.ToString()];
            //اکشن جدید
            JAction NewAction = new JAction("New...", "Legal.JJudicialComplex.ShowDialog", null, null);
            //اکشن حذف
            JAction DeleteAction = new JAction("Delete...", "Legal.JJudicialComplex.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = DeleteAction;
            //اکشن ویرایش
            JAction EditAction = new JAction("Edit...", "Legal.JJudicialComplex.ShowDialog", null, new object[] { Node.Code });
            Node.MouseDBClickAction = EditAction;
            Node.EnterClickAction = EditAction;
            JPopupMenu pMenu = new JPopupMenu("Legal.JJudicialComplex", Node.Code);
            pMenu.Insert(NewAction);
            pMenu.Insert(DeleteAction);
            pMenu.Insert(EditAction);
            Node.Popup = pMenu;
            return Node;
        }
        public void ShowDialog()
        {
            if (this.Code == 0)
            {
                JJudicialComplexForm JudicialComplexForm = new JJudicialComplexForm();
                JudicialComplexForm.State = JFormState.Insert;
                JudicialComplexForm.ShowDialog();
            }
            else
            {
                JJudicialComplexForm JudicialComplexForm = new JJudicialComplexForm(this.Code);
                JudicialComplexForm.State = JFormState.Update;
                JudicialComplexForm.ShowDialog();
            }
        }

        public static DataTable ListBranch(int pnewJudicalComplex)
        {
            JDataBase DB = new JDataBase();
            DB.setQuery(@"SELECT " +
                JJudicialBranchEnum.Code + ',' +
                JJudicialBranchEnum.Name + ',' +
                JJudicialBranchEnum.Tel + ',' +
                JJudicialBranchEnum.Fax + " FROM " + JTableNamesLegal.JudicialBranch +
                " WHERE " + JJudicialBranchEnum.JudicialComplex + "=" + pnewJudicalComplex);
            return DB.Query_DataTable();
        }

        #endregion

        public static string _Query = @"select " + JTableNamesLegal.JudicialComplex + ".Name Title," + JTableNamesLegal.JudicialComplex + ".Code," + JTableNamesClassLibrary.SubBaseDefine + ".name City,Address,Tel,Fax from " + JTableNamesLegal.JudicialComplex +
                       " left outer join " + JTableNamesClassLibrary.SubBaseDefine + " on " + JTableNamesClassLibrary.SubBaseDefine + ".Code=" + JTableNamesLegal.JudicialComplex + ".City";
    }

    public class JJudicialComplexs:JSystem
    {
        public JJudicialComplex [] items=new JJudicialComplex[0];
        public JJudicialComplexs()
        {
          //  getData();
        }
        public void getData()
        {
            JDataBase db = new JDataBase();
            try
            {
                string Qouery = "select * from " + JTableNamesLegal.JudicialComplex;
                db.setQuery(Qouery);
                db.Query_DataReader();
                if (db.DataReader.HasRows)
                {
                    Array.Resize(ref items, db.RecordCount);
                    int count = 0;
                    while (db.DataReader.Read())
                    {
                        items[count] = new JJudicialComplex();
                        items[count].Code = Convert.ToInt32(db.DataReader["Code"]);
                        items[count].Name = db.DataReader["Name"].ToString();
                        items[count].City = Convert.ToInt32(db.DataReader["City"]);
                        count++;
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
        }
        public  DataTable GetDataTable()
        {
            return GetDataTable(0);
        }
        public static DataTable GetDataTable(int pCode)
        {
            JDataBase Db = new JDataBase();
            string Query = Legal.JJudicialComplex._Query + " Where 1= 1 ";
                    //JPermission.getObjectSql("Legal.JJudicialComplexs.GetDataTable");
            if (pCode != 0)
                Query = Query + " And " + JTableNamesLegal.JudicialComplex + ".Code = " + pCode.ToString();
            try
            {
                Db.setQuery(Query);
                return  Db.Query_DataTable();
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

            Nodes.ObjectBase = new JAction("GetJudicialComplex", "Legal.JJudicialComplex.GetNode");
            Nodes.DataTable = GetDataTable();
            JAction newAction = new JAction("New...", "Legal.JJudicialComplex.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Icon = JImageIndex.Add;
            JTN.Click = newAction;
            Nodes.AddToolbar(JTN);
        }
    }
}
