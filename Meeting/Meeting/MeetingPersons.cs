using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Meeting
{
    class JMeetingPersons : JMeeting
    {
            #region constructor
            public JMeetingPersons()
            {

            }
            public JMeetingPersons(int pCode)
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
            /// کد جلسه
            /// </summary>
            public int MeetingCode
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
            /// <summary>
            /// امضا
            /// </summary>
            public bool Signature
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
                    string Query = "select * from " + JTableNamesMeeting.MetMeetingPersons + " where Code=" + pCode + "";
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
        public bool Update(DataTable tmpdt, int pMeeting_Code,JDataBase db)
        {
            JMeetingPersonsTable PDT = new JMeetingPersonsTable();
            try
            {
                if (tmpdt != null)
                    foreach (DataRow dr in tmpdt.Rows)
                    {
                        if ((dr.RowState == DataRowState.Added) || ((dr.RowState == DataRowState.Unchanged) && (dr["Code"].ToString() == "")))
                        {
                            MeetingCode = pMeeting_Code;
                            PersonCode = Convert.ToInt32(dr["PersonCode"]);
                            Insert(db);
                            dr["Code"] = Code;
                            if (Code < 1)
                                return false;                                                        
                        }
                        if ((dr.RowState == DataRowState.Modified) && (dr["Code"].ToString() != ""))
                        {
                            Code = (int)dr["Code"];
                            Signature = (bool)dr["Signature"];
                            MeetingCode = pMeeting_Code;
                            PersonCode = Convert.ToInt32(dr["PersonCode"]);
                            //GetData(Code);
                            if (!Update(db))
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
                //if (JPermission.CheckPermission("Meeting.JMeetingPersons.Insert"))
                //{
                    JMeetingPersonsTable JLT = new JMeetingPersonsTable();
                    JLT.SetValueProperty(this);
                    Code = JLT.Insert(tempDb);
                    if (Code > 0)
                    {
                        //Nodes.DataTable.Merge(JMeetingPersonss.GetDataTable(Code));
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
                tempDb.Dispose();
            }
        }
            /// <summary>
            /// حذف  
            /// </summary>
            /// <returns></returns>
        public bool delete(JDataBase DB)
        {
            JMeetingPersonsTable PDT = new JMeetingPersonsTable();
            try
            {
                //if (JPermission.CheckPermission("Meeting.JMeetingPersons.Delete"))
                //{
                    PDT.SetValueProperty(this);
                    if (PDT.Delete(DB))
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
            }
        }
            /// <summary>
            /// حذف  
            /// </summary>
            /// <returns></returns>
            public bool DeleteManual(JDataBase DB ,int pCode)
            {
                JMeetingPersonsTable PDT = new JMeetingPersonsTable();
                try
                {
                    //if (JPermission.CheckPermission("Meeting.JMeetingPersons.DeleteManual"))
                    //{
                        PDT.SetValueProperty(this);
                        if (PDT.DeleteManual(" MeetingCode = " + pCode.ToString()))
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
                }
            }

            /// <summary>
            /// ویرایش  
            /// </summary>
            /// <returns></returns>
            public bool Update(JDataBase DB)
            {
                try
                {
                    JMeetingPersonsTable PDT = new JMeetingPersonsTable();
                    //if (JPermission.CheckPermission("Meeting.JMeetingPersons.Update"))
                    //{
                        PDT.SetValueProperty(this);
                        PDT.Update(DB);
                        //Nodes.Refreshdata(Nodes.CurrentNode, JMeetingPersonss.GetDataTable(Code).Rows[0]);
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
                }

            }
            public JNode GetNode(DataRow pRow)
            {
                JNode Node = new JNode((int)pRow["Code"], "Meeting.JCommissionPersons");
                Node.Name = pRow["Name"].ToString();
                Node.Icone = JImageIndex.land.GetHashCode();
                Node.Hint = JLanguages._Text("Lands:") + " " + pRow["Name"].ToString() + "\n" +
                    JLanguages._Text("Section:") + " " + pRow["Section"].ToString();
                //اکشن ویرایش
                JAction editAction = new JAction("Edit...", "Meeting.JCommissionPersons.ShowDialog", null, new object[] { Node.Code });
                Node.MouseDBClickAction = editAction;
                //اکشن حذف
                JAction DeleteAction = new JAction("Delete", "Meeting.JCommissionPersons.Delete", null, new object[] { Node.Code });
                Node.DeleteClickAction = DeleteAction;
                //اکشن جدید
                JAction newAction = new JAction("New...", "Meeting.JCommissionPersons.ShowDialog", null, null);

                Node.Popup.Insert(DeleteAction);
                Node.Popup.Insert(editAction);
                Node.Popup.Insert(newAction);

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

        public class JMeetingPersonss : JSystem
        {
            public JMeetingPersonss[] Items = new JMeetingPersonss[0];
            public JMeetingPersonss()
            {
                //GetData();
            }

            #region GetData
            public DataTable GetDataTable()
            {
                return GetDataTable(0);
            }
            public static DataTable GetDataTable(int pMeetingCode)
            {
                JDataBase DB = new JDataBase();
                try
                {
                    DB.setQuery(@"SELECT A.Code,P.Code PersonCode,Name,Signature FROM " + JTableNamesMeeting.MetMeetingPersons + @" A inner join clsAllPerson P on A.PersonCode=P.Code 
            WHERE MeetingCode=" + pMeetingCode.ToString());
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
                Nodes.ObjectBase = new JAction("MeetingPersons", "Meeting.JMeetingPersons.GetNode");
                Nodes.DataTable = GetDataTable();
                JAction newAction = new JAction("New...", "Meeting.JMeetingPersons.ShowDialog", null, null);
                Nodes.GlobalMenuActions.Insert(newAction);
                JToolbarNode JTN = new JToolbarNode();
                JTN.Click = newAction;
                JTN.Icon = JImageIndex.Add;
                Nodes.AddToolbar(JTN);
            }

            #endregion Node
        }
}
