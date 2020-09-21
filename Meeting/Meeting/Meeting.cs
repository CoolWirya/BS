using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Meeting
{
    public class JMeetings : JMeeting
    {
        #region constructor
        public JMeetings()
        {

        }
        public JMeetings(int pCode)
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
        /// تاریخ جلسه
        /// </summary>
        public DateTime Date
        {
            get;
            set;
        }
        /// <summary>
        /// موضوع جلسه
        /// </summary>
        public string Subject
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
        /// ساعت
        /// </summary>
        public string Time
        {
            get;
            set;
        }
        /// <summary>
        /// مکان
        /// </summary>
        public string Location
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
                string Query = "select * from " + JTableNamesMeeting.MetMeeting + " where Code=" + pCode + "";
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
        public int Insert(DataTable dtPerson, DataTable dtLegistlation,DataTable dtProgram)
        {
            JDataBase tempDb = new JDataBase();
            try
            {
                if (JPermission.CheckPermission("Meeting.JMeetings.Insert"))
                {
                    JMeetingsTable JLT = new JMeetingsTable();
                    JMeetingPersons JMetp = new JMeetingPersons();
                    JLegislation leg = new JLegislation();
                    JProgram Prog = new JProgram();
                    JLT.SetValueProperty(this);

                    tempDb.beginTransaction("InsertMeet");
                    Code = JLT.Insert(tempDb);
                    if (Code > 0)
                    {
                        if (!JMetp.Update(dtPerson, Code, tempDb))
                        {
                            tempDb.Rollback("InsertMeet");
                            return -1;
                        }
                        if (!leg.Update(dtLegistlation, Code, tempDb))
                        {
                            tempDb.Rollback("InsertMeet");
                            return -1;
                        }
                        if (!Prog.Update(dtProgram, Code, tempDb))
                        {
                            tempDb.Rollback("InsertMeet");
                            return -1;
                        }
                        if (tempDb.Commit())
                        {
                            Nodes.DataTable.Merge(JMeetingss.GetDataTable(Code));
                            return Code;
                        }
                        else
                        {
                            tempDb.Rollback("InsertMeet");
                            return -1;
                        }
                    }
                    else
                    {
                        tempDb.Rollback("InsertMeet");
                        return -1;
                    }
                    return 0;
                }
                else
                    return 0;
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
        public bool Delete()
        {
            JMeetingsTable PDT = new JMeetingsTable();
            JLegislation tmpLeg=new JLegislation();
            JMeetingPersons tmpP = new JMeetingPersons();
            JProgram tmpPro = new JProgram();
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                if (JPermission.CheckPermission("Meeting.JMeetings.Delete"))
                {
                    if (JMessages.Question("Are You Sure?", "Delete") == System.Windows.Forms.DialogResult.Yes)
                    {
                        PDT.SetValueProperty(this);
                        DB.beginTransaction("DeleteMeet");
                        if (tmpPro.DeleteManual(Code, DB))
                        {
                            if (tmpP.DeleteManual(DB, Code))
                            {
                                if (tmpLeg.DeleteManual(Code, DB))
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
                DB.Dispose();
            }
        }

        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update(DataTable dtPerson, DataTable dtLegistlation,DataTable dtProgram)
        {
            JDataBase tempDb = new JDataBase();
            try
            {
                JMeetingsTable PDT = new JMeetingsTable();
                JMeetingPersons JMetp = new JMeetingPersons();
                JLegislation leg = new JLegislation();
                JProgram Prog = new JProgram();
                if (JPermission.CheckPermission("Meeting.JMeetings.Update"))
                {
                    PDT.SetValueProperty(this);
                    tempDb.beginTransaction("UpdateMeet");
                    if (PDT.Update(tempDb))
                    {
                        if (!JMetp.Update(dtPerson, Code, tempDb))
                        {
                            tempDb.Rollback("UpdateMeet");
                            return false;
                        }
                        if (!leg.Update(dtLegistlation, Code, tempDb))
                        {
                            tempDb.Rollback("UpdateMeet");
                            return false;
                        }
                        if (!Prog.Update(dtProgram, Code, tempDb))
                        {
                            tempDb.Rollback("UpdateMeet");
                            return false;
                        }
                        if (tempDb.Commit())
                        {
                            Nodes.Refreshdata(Nodes.CurrentNode, JMeetingss.GetDataTable(Code).Rows[0]);
                            //Nodes.DataTable.Merge(JMeetingss.GetDataTable(Code));
                            return true;
                        }
                        else
                            return false;
                        return true;
                    }
                    else
                    {
                        tempDb.Rollback("UpdateMeet");
                        return false;
                    }
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
                tempDb.Dispose();
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "Meeting.JMeetings");
            Node.Name = pRow["Subject"].ToString() + "\n" + pRow["Date"].ToString();
            Node.Icone = JImageIndex.land.GetHashCode();
            Node.Hint = pRow["Subject"].ToString();
            //اکشن ویرایش
            JAction editAction = new JAction("Edit...", "Meeting.JMeetings.ShowDialog", null, new object[] { Node.Code });
            Node.MouseDBClickAction = editAction;
            //اکشن حذف
            JAction DeleteAction = new JAction("Delete", "Meeting.JMeetings.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = DeleteAction;
            //اکشن جدید
            JAction newAction = new JAction("New...", "Meeting.JMeetings.ShowDialog", null, null);
            Node.Popup.Insert(DeleteAction);
            Node.Popup.Insert(editAction);
            Node.Popup.Insert(newAction);
            return Node;
        }

        public void ShowDialog()
        {
            if (this.Code == 0)
            {
                JLegMeetingForm LandForm = new JLegMeetingForm();
                LandForm.State = JFormState.Insert;
                LandForm.ShowDialog();
            }
            else
            {
                JLegMeetingForm LandForm = new JLegMeetingForm(Code);
                LandForm.State = JFormState.Update;
                LandForm.ShowDialog();
            }
        }

        #endregion
    }

    public class JMeetingss : JSystem
    {
        public JMeetingss[] Items = new JMeetingss[0];
        public JMeetingss()
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
                Where = Where + " And " + JTableNamesMeeting.MetMeeting + ".Code=" + pCode;
            string Query = "select Code,[Subject],[Time],Location,dbo.MiladiTOShamsi(Date) 'Date',(select name from MetCommission where Code = MetMeeting.CommissionCode) 'CommissionName' from " 
                + JTableNamesMeeting.MetMeeting + Where +
                " And " + JPermission.getObjectSql("Meeting.JCommissions.GetDataTable", JTableNamesMeeting.MetMeeting + ".CommissionCode");
            //Meeting.JMeetingss.GetDataTable   JTableNamesMeeting.MetMeeting
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
            Nodes.ObjectBase = new JAction("Meetings", "Meeting.JMeetings.GetNode");
            Nodes.DataTable = GetDataTable();
            JAction newAction = new JAction("New...", "Meeting.JMeetings.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Click = newAction;
            JTN.Icon = JImageIndex.Add;
            Nodes.AddToolbar(JTN);
        }

        #endregion Node
    }
}
