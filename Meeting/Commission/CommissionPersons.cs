using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Meeting
{
    public class JCommissionPersons : JSystem
    {
        #region constructor
        public JCommissionPersons()
        {

        }
        public JCommissionPersons(int pCode)
        {
            GetData(pCode);
        }
        #endregion

        #region Property
        /// <summary>
        /// کد 
        /// </summary>
        public int Code
        {
            get;
            set;
        }
        /// <summary>
        /// کد کمیسیون
        /// </summary>
        public int CommissionCode
        {
            get;
            set;
        }
        /// <summary>
        /// کدشخص
        /// </summary>
        public int PersonCode
        {
            get;
            set;
        }
        #endregion

        #region search method

        public bool GetData(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from " + JTableNamesMeeting.MetCommissionPersons + " where Code=" + pCode + "";
                Db.setQuery(Query);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
                    return true;
                }
                else
                {
                    return false;
                }
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

        #region method
        /// <summary>
        ///بروزرسانی فقط   
        /// </summary>
        /// <returns></returns>
        public bool Update(DataTable tmpdt, int pCommission_Code)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            JCommissionPersonsTable PDT = new JCommissionPersonsTable();
            try
            {
                if (tmpdt != null)
                    foreach (DataRow dr in tmpdt.Rows)
                    {
                        if (dr.RowState == DataRowState.Added)
                        {
                            CommissionCode = pCommission_Code;
                            PersonCode = Convert.ToInt32(dr["PersonCode"]);
                            Insert(db);
                            dr["Code"] = Code;
                            if (Code < 1)
                                return false;
                        }
                        if (dr.RowState == DataRowState.Deleted)
                        {
                            dr.RejectChanges();
                            Code = (int)dr["Code"];
                            GetData(Code);
                            if (!delete(db))
                                return false;
                            dr.Delete();
                        }
                    }
                tmpdt.AcceptChanges();
                return true;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
                db.Dispose();
            }
        }

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert(JDataBase tempDb)
        {
            try
            {
                //if (JPermission.CheckPermission("Meeting.JCommissionPersons.Insert"))
                //{
                    JCommissionPersonsTable JLT = new JCommissionPersonsTable();
                    JLT.SetValueProperty(this);
                    Code = JLT.Insert();
                    if (Code > 0)
                    {
                        //Nodes.DataTable.Merge(JCommissionPersonss.GetDataTable(Code));
                        return Code;
                    }
                    return 0;
                //}
                //else
                //    return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                //tempDb.Dispose();
            }
        }
        /// <summary>
        /// حذف  
        /// </summary>
        /// <returns></returns>
        public bool delete(JDataBase DB)
        {
            JCommissionPersonsTable PDT = new JCommissionPersonsTable();
            try
            {
                //if (JPermission.CheckPermission("Meeting.JCommissionPersons.Delete"))
                //{
                    PDT.SetValueProperty(this);
                    if (PDT.Delete(DB))
                        return true;
                    //Nodes.Delete(Nodes.CurrentNode);
                    return true;
                //}
                //else
                //    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
            }
        }
        /// <summary>
        /// حذف  
        /// </summary>
        /// <returns></returns>
        public bool DeleteManual(int pCode)
        {
            JCommissionPersonsTable PDT = new JCommissionPersonsTable();
            try
            {
                //if (JPermission.CheckPermission("Meeting.JCommissionPersons.DeleteManual"))
                //{                    
                    PDT.SetValueProperty(this);
                    if (PDT.DeleteManual(" CommissionCode = " + pCode.ToString()))
                        return true;
                    Nodes.Delete(Nodes.CurrentNode);
                    return true;
                //}
                //else
                //    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
            }
        }

        /// <summary>
        /// ویرایش یک اراضی
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JCommissionPersonsTable PDT = new JCommissionPersonsTable();
            try
            {                
                //if (JPermission.CheckPermission("Meeting.JCommissionPersons.Update"))
                //{
                    PDT.SetValueProperty(this);
                    PDT.Update();
                    Nodes.Refreshdata(Nodes.CurrentNode, JCommissionPersonss.GetDataTable(Code).Rows[0]);
                    return true;
                //}
                //else
                //    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
            }

        }
        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "Meeting.JCommission");
            Node.Name = pRow["Name"].ToString();
            Node.Icone = JImageIndex.land.GetHashCode();
            Node.Hint = pRow["Name"].ToString();               
            //اکشن ویرایش
            JAction editAction = new JAction("Edit...", "Meeting.JCommissionPersons.ShowDialog", null, new object[] { Node.Code });
            Node.MouseDBClickAction = editAction;
            //اکشن حذف
            //JAction DeleteAction = new JAction("Delete", "Meeting.JCommissionPersons.Delete", null, new object[] { Node.Code });
            //Node.DeleteClickAction = DeleteAction;
            //اکشن جدید
            //JAction newAction = new JAction("New...", "Meeting.JCommissionPersons.ShowDialog", null, null);
            //Node.Popup.Insert(DeleteAction);
            Node.Popup.Insert(editAction);
            //Node.Popup.Insert(newAction);

            return Node;

        }
        public void ShowDialog(int pCode)
        {
            if (pCode == 0)
            {
                JCommissionPersonsForm LandForm = new JCommissionPersonsForm();
                LandForm.State = JFormState.Insert;
                LandForm.ShowDialog();
            }
            else
            {
                JCommissionPersonsForm LandForm = new JCommissionPersonsForm(pCode);
                LandForm.State = JFormState.Update;
                LandForm.ShowDialog();
            }
        }

        #endregion
    }
 
    public class JCommissionPersonss : JSystem
    {
        public JCommissionPersonss[] Items = new JCommissionPersonss[0];
        public JCommissionPersonss()
        {
            //GetData();
        }

        #region GetData
        public DataTable GetDataTable()
        {
            return GetDataTable(0);
        }
        public static DataTable GetDataTableWithCode(int pCommissionCode)
        {
            JDataBase DB = new JDataBase();
            try
            {                
                string Where = "";
                if (pCommissionCode != 0)
                    Where = " WHERE CommissionCode=" + pCommissionCode.ToString();
                DB.setQuery(@"SELECT A.Code,P.Code PersonCode,Name FROM " + JTableNamesMeeting.MetCommissionPersons
                    + " A inner join clsAllPerson P on A.PersonCode=P.Code " + Where);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static DataTable GetDataTable(int pCommissionCode)
        {
            JDataBase DB = new JDataBase();
            try
            {                
                string Where = "";
                if (pCommissionCode != 0)
                    Where = " WHERE CommissionCode=" + pCommissionCode.ToString();
                DB.setQuery(@"SELECT '' 'Code',P.Code PersonCode,Name,PersonType FROM " + JTableNamesMeeting.MetCommissionPersons 
                    + " A inner join clsAllPerson P on A.PersonCode=P.Code "+Where);           
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        #endregion GetData

        #region Node
        public void ListView()
        {
            Nodes.ObjectBase = new JAction("Commission", "Meeting.JCommissionPersons.GetNode");
            Nodes.DataTable = JCommissions.GetDataTable(0);
            //JAction newAction = new JAction("New...", "Meeting.JCommissionPersons.ShowDialog", null, null);
            //Nodes.GlobalMenuActions.Insert(newAction);
            //JToolbarNode JTN = new JToolbarNode();
            //JTN.Click = newAction;
            //JTN.Icon = JImageIndex.Add;
            //Nodes.AddToolbar(JTN);
        }

        #endregion Node
    }
}

