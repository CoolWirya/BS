using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Meeting
{
    public class JCommission:JSystem
    {        
            #region constructor
            public JCommission()
            {

            }
            public JCommission(int pCode)
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
            /// نام
            /// </summary>
            public string Name
            {
                get;
                set;
            }            
            #endregion

            #region search method

            public override string ToString()
            {
                return this.Name;
            }
            
            public bool GetData(int pCode)
            {
                JDataBase Db = new JDataBase();
                try
                {
                    string Query = "select * from " + JTableNamesMeeting.MetCommission + " where Code=" + pCode + "";
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
            /// درج 
            /// </summary>
            /// <returns></returns>
            public int Insert(DataTable dtLegCom)
            {
                JDataBase Db = new JDataBase();
                JLegCommission LegCom = new JLegCommission();
                try
                {
                    if (JPermission.CheckPermission("Meeting.JCommission.Insert"))
                    {
                        JCommissionTable JLT = new JCommissionTable();
                        JLT.SetValueProperty(this);
                        Db.beginTransaction("InsertCom");
                        Code = JLT.Insert(Db);
                        if (Code > 0)                        
                        {
                            if (LegCom.Update(dtLegCom, Code, Db))
                            {
                                if (Db.Commit())
                                {
                                    Nodes.DataTable.Merge(JCommissions.GetDataTable(Code));
                                    return Code;
                                }
                                else
                                {
                                    Db.Rollback("InsertCom");
                                    return 0;
                                }
                            }
                            else
                            {
                                Db.Rollback("InsertCom");
                                return 0;
                            }
                        }
                        else
                        {
                            Db.Rollback("InsertCom");
                            return 0;
                        }
                    }
                    else                   
                        return 0;
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                    Db.Rollback("InsertCom");
                    return 0;
                }
                finally
                {
                    Db.Dispose();
                }
            }

            /// <summary>
            /// حذف  
            /// </summary>
            /// <returns></returns>
            public bool Delete()
            {
                JDataBase Db = new JDataBase();
                JCommissionTable PDT = new JCommissionTable();
                JCommissionPersonsTable CPDT = new JCommissionPersonsTable();
                try
                {
                    if (JPermission.CheckPermission("Meeting.JCommission.Delete"))
                    {
                        JDataBase DB = JGlobal.MainFrame.GetDBO();                        
                        PDT.SetValueProperty(this);
                        DB.beginTransaction("DeleteMeet");

                        if (CPDT.DeleteManual(" CommissionCode=" + Code, DB))
                        {
                            if (PDT.Delete(DB))
                            {
                                if (DB.Commit())
                                {
                                    Nodes.Delete(Nodes.CurrentNode);
                                    return true;
                                }
                                else
                                {
                                    DB.Rollback("DeleteMeet");
                                    return false;
                                }                               
                            }
                            else
                            {
                                DB.Rollback("DeleteMeet");
                                return false;
                            }
                        }
                        else
                        {
                            DB.Rollback("DeleteMeet");
                            return false;
                        }
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
                    Db.Dispose();
                }
            }

            /// <summary>
            /// ویرایش 
            /// </summary>
            /// <returns></returns>
            public bool Update(DataTable dtLegCom)
            {
                JDataBase Db = new JDataBase();
                JCommissionTable PDT = new JCommissionTable();
                JLegCommission LegCom = new JLegCommission();
                try
                {
                    if (JPermission.CheckPermission("Meeting.JCommission.Update"))
                    {
                        PDT.SetValueProperty(this);
                        Db.beginTransaction("UpdateCom");
                        if (PDT.Update(Db))
                        {
                            if (LegCom.Update(dtLegCom, Code, Db))
                            {
                                if (Db.Commit())
                                {
                                    Nodes.Refreshdata(Nodes.CurrentNode, JCommissions.GetDataTable(Code).Rows[0]);
                                    return true;
                                }
                                else
                                {
                                    Db.Rollback("UpdateCom");
                                    return false;
                                }
                            }
                            else
                            {
                                Db.Rollback("UpdateCom");
                                return false;
                            }
                        }
                        else
                        {
                            Db.Rollback("UpdateCom");
                            return false;
                        }
                    }
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                    Db.Rollback("UpdateCom");
                    return false;
                }
                finally
                {
                    Db.Dispose();
                    PDT.Dispose();
                    LegCom.Dispose();
                }

            }
            public JNode GetNode(DataRow pRow)
            {
                JNode Node = new JNode((int)pRow["Code"], "Meeting.JCommission");
                Node.Name = pRow["Name"].ToString();
                Node.Icone = JImageIndex.land.GetHashCode();
                Node.Hint = pRow["Name"].ToString();
                //اکشن ویرایش
                JAction editAction = new JAction("Edit...", "Meeting.JCommission.ShowDialog", null, new object[] { Node.Code });
                Node.MouseDBClickAction = editAction;
                //اکشن حذف
                JAction DeleteAction = new JAction("Delete", "Meeting.JCommission.Delete", null, new object[] { Node.Code });
                Node.DeleteClickAction = DeleteAction;
                //اکشن جدید
                JAction newAction = new JAction("New...", "Meeting.JCommission.ShowDialog", null, null);
                //اکشن ویرایش
                //JAction PersonAction = new JAction("Persons Commission...", "Meeting.JCommissionPersons.ShowDialog", new object[] { Node.Code }, new object[] { Node.Code });
                //Node.MouseDBClickAction = editAction;

                Node.Popup.Insert(DeleteAction);
                Node.Popup.Insert(editAction);
                Node.Popup.Insert(newAction);
                //Node.Popup.Insert(PersonAction);
                return Node;

            }
            public void ShowDialog()
            {
                if (this.Code == 0)
                {
                    JCommissionForm LandForm = new JCommissionForm();
                    LandForm.State = JFormState.Insert;
                    LandForm.ShowDialog();
                }
                else
                {
                    JCommissionForm LandForm = new JCommissionForm(Code);
                    LandForm.State = JFormState.Update;
                    LandForm.ShowDialog();
                }
            }

            #endregion
        }

        public class JCommissions : JSystem
        {
            public JCommissions[] Items = new JCommissions[0];
            public JCommissions()
            {
                //GetData();
            }

            #region GetData
            public DataTable GetDataTable()
            {
                return GetDataTable(0);
            }
            public static DataTable GetDataTable(int pCode)
            {
                string Where = " where 1=1 ";
                if (pCode != 0)
                    Where = Where + " And " + JTableNamesMeeting.MetCommission + ".Code=" + pCode;
                string Query = "select Name,code from " + JTableNamesMeeting.MetCommission + Where +
                    " And " + JPermission.getObjectSql("Meeting.JCommissions.GetDataTable", JTableNamesMeeting.MetCommission + ".Code");
                JDataBase db = new JDataBase();
                try
                {
                    db.setQuery(Query);
                    return db.Query_DataTable();
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                    return null;
                }
                finally
                {
                    db.Dispose();
                }
            }

            #endregion GetData

            #region Node
            public void ListView()
            {
                Nodes.ObjectBase = new JAction("Commission", "Meeting.JCommission.GetNode");
                Nodes.DataTable = GetDataTable();
                JAction newAction = new JAction("New...", "Meeting.JCommission.ShowDialog", null, null);
                Nodes.GlobalMenuActions.Insert(newAction);
                JToolbarNode JTN = new JToolbarNode();
                JTN.Click = newAction;
                JTN.Icon = JImageIndex.Add;
                Nodes.AddToolbar(JTN);
            }

            #endregion Node
        }
    }

