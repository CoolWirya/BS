using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Legal
{
    /// <summary>
    /// کلاس شعبه قضائی 
    /// </summary>
    public class JJudicialBranch : JSystem 
    {
        #region Constructor
        public JJudicialBranch()
        {
        }
        public JJudicialBranch(int pCode)
        {
            getData(pCode);
        }
        #endregion

        #region property
        public int Code { get; set; }
        public string Name { get; set; }
        public int JudicialComplex { get; set; }
        public int City { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Address { get; set; }
        #endregion

        #region SearchMethod
        private int find(string pName)
        {
            JDataBase db = new JDataBase();
            try
            {
                string Query = "select Code from " + JTableNamesLegal.JudicialBranch + " where Name=" +JDataBase.Quote(pName) + " ";
                db.setQuery(Query);
                db.Query_DataReader();
                if (db.DataReader.Read())
                {
                    return (int)db.DataReader["Code"];
                }
                return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }
        private bool getData(int pCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                string Query = "select * from "+JTableNamesLegal.JudicialBranch+" where Code="+pCode+"";
                db.setQuery(Query);
                db.Query_DataReader();
                if (db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                return false;

            }
            catch(Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        #endregion

        #region Method
        /// <summary>
        /// اطلاعات شعبه قضایی را درج می کند
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            if (JPermission.CheckPermission("Legal.JJudicialBranch.Insert"))
            {
                if (find(this.Name) > 0)
                {
                    JMessages.Error("عنوان شعیه قضایی تکراری می باشد.", "خطا در ثبت اطلاعات");
                    return 0;
                }
                else
                {
                    JDataBase Db = new JDataBase();
                    try
                    {
                        JJudicialBranchTable BranchTable = new JJudicialBranchTable();
                        BranchTable.SetValueProperty(this);
                        int result = BranchTable.Insert();
                        if (result > 0)
                        {
                            this.Code = result;
                            //Nodes.DataTable.Rows.Add(BranchTable.GetRow(Nodes.DataTable));
                            Histroy.Save(this, BranchTable, Code, "Insert");
                            Nodes.DataTable.Merge(JJudicialBranches.GetDataTable(Code));
                        }
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
            }
            else
                return -1;
        }
        /// <summary>
        /// اطلاعات شعبه قضایی را به روز رسانی می کند
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            if (JPermission.CheckPermission("Legal.JJudicialBranch.Update"))
            {
                int TCode = find(this.Name);
                if (TCode != 0 && Code != TCode)
                {
                    JMessages.Error("مجتمع قضایی با این عنوان قبلا ایجاد شده است", "خطا در ثبت اطلاعات");
                    return false;
                }
                else
                {
                    JJudicialBranchTable jbt = new JJudicialBranchTable();
                    jbt.SetValueProperty(this);
                    if (jbt.Update())
                    {
                        Histroy.Save(this, jbt, Code, "Update");
                        Nodes.Refreshdata(Nodes.CurrentNode, JJudicialBranches.GetDataTable(Code).Rows[0]);
                        return true;
                    }
                    return false;
                }
            }
            else
                return false;
        }
        public void Delete()
        {
            if (JPermission.CheckPermission("Legal.JJudicialBranch.Delete"))
            {
                string[] parameters = { "@Item" };
                string[] values = { "JudicialBranch" };
                string msg = JLanguages._Text("YouWantToDelete?", parameters, values);
                if (JMessages.Question(msg, "Confirm?") != System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                JJudicialBranchTable jbt = new JJudicialBranchTable();
                jbt.SetValueProperty(this);
                if (jbt.Delete())
                {
                    Histroy.Save(this, jbt, Code, "Delete");
                    Nodes.Delete(Nodes.CurrentNode);
                }
            }                            
        }
     
        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow[JJudicialBranchEnum.Code.ToString()], "Legal.JJudicialBranch");
            Node.Name = pRow["Title"].ToString();
            Node.Icone = JImageIndex.Default.GetHashCode();
            //اکشن جدید
            JAction NewAction = new JAction("new...", "Legal.JJudicialBranch.ShowDialog", null, null);
            //اکشن حذف
            JAction DeleteAction = new JAction("Delete...", "Legal.JJudicialBranch.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = DeleteAction;
            //اکشن ویرایش
            JAction EditAction=new JAction("Edit...","Legal.JJudicialBranch.ShowDialog",null,new object[] {Node.Code});
            Node.MouseDBClickAction=EditAction;
            Node.EnterClickAction=EditAction;
            Node.Hint = JLanguages._Text("JudicialComplexName") + ":" + pRow[JJudicialBranchEnum.JudicialComplex.ToString()];
            JPopupMenu pMenu = new JPopupMenu("Legal.JJudicialBranch", Node.Code);
            pMenu.Insert(NewAction);
            pMenu.Insert(EditAction);
            pMenu.Insert(DeleteAction);
            Node.Popup=pMenu;
            return Node;
        }
        public void ShowDialog()
        {
            ShowDialog(0);
        }
        public void ShowDialog(int pComCode)
        {
            if (this.Code == 0)
            {
                JJudicialBranchForm JudicialBranchForm = new JJudicialBranchForm();
                if (pComCode != 0)
                {
                    JudicialBranchForm.cmbJudicalComplex.SelectedValue = pComCode;
                    JudicialBranchForm.cmbJudicalComplex.Enabled = false;
                }
                JudicialBranchForm.State = JFormState.Insert;
                JudicialBranchForm.ShowDialog();
            }
            else
            {
                JJudicialBranchForm JudicialBranchForm = new JJudicialBranchForm(this.Code);
                JudicialBranchForm.State = JFormState.Update;
                JudicialBranchForm.ShowDialog();
            }
        }

        public static string _Query = @"select " + JTableNamesLegal.JudicialBranch + ".Code," + JTableNamesLegal.JudicialBranch + ".Name Title," + JTableNamesLegal.JudicialComplex + ".Name JudicialComplex, legJudicialBranch.Name +' - '+legJudicialComplex.Name FullName,"
            + JTableNamesLegal.JudicialBranch + ".Address," + JTableNamesClassLibrary.SubBaseDefine + ".name City," + JTableNamesLegal.JudicialBranch + ".Tel," + JTableNamesLegal.JudicialBranch + ".Fax from " +
                  JTableNamesLegal.JudicialBranch + " inner join  " + JTableNamesLegal.JudicialComplex + " on " + JTableNamesLegal.JudicialBranch + ".JudicialComplex=" + JTableNamesLegal.JudicialComplex + ".Code" +
                  " LEFT OUTER JOIN " + JTableNamesClassLibrary.SubBaseDefine + " ON " + JTableNamesLegal.JudicialBranch + ".City = " + JTableNamesClassLibrary.SubBaseDefine + ".Code ";
        public override string ToString()
        {
            return Name;
        }
            
        #endregion


    }

    /// <summary>
    /// 
    /// </summary>
    public class JJudicialBranches : JSystem
    {
        public JJudicialBranches()
        {
            GetDataJudicialBranch();
        }
       public JJudicialBranch[] JBs = new JJudicialBranch[0];
        public void GetDataJudicialBranch()
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            string Qouery="select * from "+JTableNamesLegal.JudicialBranch;
            try
            {

                Db.setQuery(Qouery);
                Db.Query_DataReader();
                if (Db.DataReader.HasRows)
                {
                    Array.Resize(ref JBs, Db.RecordCount);
                    int count = 0;
                    while (Db.DataReader.Read())
                    {
                        JBs[count] = new JJudicialBranch();
                        JBs[count].Code = Convert.ToInt32(Db.DataReader["Code"]);
                        JBs[count].JudicialComplex = Convert.ToInt32(Db.DataReader["JudicialComplex"]);
                        JBs[count].Name=Db.DataReader["Name"].ToString();
                        JBs[count].Address = Db.DataReader["Address"].ToString();
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
                Db.Dispose();
            }

        }

        //private void GetData()
        //{
        //    JDataBase DB = JGlobal.MainFrame.GetDBO();
        //    DB.setQuery("SELECT * FROM " + JTableNamesEstate.LandTable);
        //    try
        //    {
        //        DB.Query_DataReader();
        //        if (DB.DataReader.HasRows)
        //        {
        //            Array.Resize(ref Items, DB.RecordCount);
        //            int count = 0;
        //            while (DB.DataReader.Read())
        //            {
        //                Items[count] = new JLand();
        //                Items[count].Area = Convert.ToInt32(DB.DataReader["Area"]);
        //                Items[count].Code = Convert.ToInt32(DB.DataReader["Code"]);
        //                Items[count].Name = DB.DataReader["Name"].ToString();
        //                count++;
        //            }
        //        }
        //    }
        //    finally
        //    {
        //        DB.Dispose();
        //    }
        //}

        public static DataTable GetDataTable(int pCode)
        {
            JDataBase Database = new JDataBase();
            try
            {
                string Query = JJudicialBranch._Query;
                Query = Query + " Where 1=1 ";
                    //JPermission.getObjectSql("Legal.JJudicialBranches.GetDataTable");
                if (pCode != 0)
                    Query = Query + " And " + JTableNamesLegal.JudicialBranch + "." + JJudicialBranchEnum.Code.ToString() + " = " + pCode.ToString();
                Database.setQuery(Query);
                return Database.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Database.Dispose();
            }
        }
        public void ListView()
        {
            JAction newAction = new JAction("new...", "Legal.JJudicialBranch.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Icon = JImageIndex.Add;
            JTN.Click = newAction;
            Nodes.AddToolbar(JTN);
            Nodes.ObjectBase = new JAction("GetJudicialBranch", "Legal.JJudicialBranch.GetNode");
            Nodes.DataTable = GetDataTable(0);
            
        }
    }
}
