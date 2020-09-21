using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Meeting
{
    public class JLegislation: JMeeting
    {

        #region constructor
        public JLegislation()
        {

        }
        public JLegislation(int pCode)
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
        /// گروه مصوبه
        /// </summary>
        public int LegislationGroup
        {
            get;
            set;
        }
        /// <summary>
        /// مصوبه
        /// </summary>
        public string Legislation
        {
            get;
            set;
        }
        /// <summary>
        /// کد 
        /// </summary>
        public int MeetingCode
        {
            get;
            set;
        }
        /// <summary>
        /// پیگیری
        /// </summary>
        public int Flow
        {
            get;
            set;
        }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description
        {
            get;
            set;
        }
        /// <summary>
        /// تاریخ پیگیری
        /// </summary>
        public DateTime FlowDate
        {
            get;
            set;
        }
        /// <summary>
        /// پیگیری کننده
        /// </summary>
        public string PersonFlow
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
                string Query = "select * from " + JTableNamesMeeting.MetLegislation + " where Code=" + pCode + "";
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
            JLegislationTable PDT = new JLegislationTable();
            try
            {
                if (tmpdt != null)
                    foreach (DataRow dr in tmpdt.Rows)
                    {
                        if (dr.RowState == DataRowState.Added)
                        {
                            MeetingCode = pMeeting_Code;
                            LegislationGroup = Convert.ToInt32(dr["LegislationGroup"]);
                            Legislation = dr["Legislation"].ToString();
                            Flow = Convert.ToInt32(dr["Flow"]);
                            Description = dr["Description"].ToString();
                            FlowDate = Convert.ToDateTime(dr["FlowDate"]);
                            PersonFlow = dr["PersonFlow"].ToString();
                            Insert(db);
                            dr["Code"] = Code;
                            if (Code < 1)
                                return false;
                        }
                        if (dr.RowState == DataRowState.Modified)
                        {
                            MeetingCode = pMeeting_Code;
                            LegislationGroup = Convert.ToInt32(dr["LegislationGroup"]);
                            Legislation = dr["Legislation"].ToString();
                            Flow = Convert.ToInt32(dr["Flow"]);
                            Description = dr["Description"].ToString();
                            FlowDate = Convert.ToDateTime(dr["FlowDate"]);
                            PersonFlow = dr["PersonFlow"].ToString();
                            Code = Convert.ToInt32(dr["Code"]);
                            if(!Update(db))
                                return false;
                        }
                        if (dr.RowState == DataRowState.Deleted)
                        {
                            dr.RejectChanges();
                            Code = (int)dr["Code"];
                            GetData(Code);
                            if (!Delete(db))
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
                //if (JPermission.CheckPermission("Meeting.JLegislation.Insert"))
                //{
                    JLegislationTable JLT = new JLegislationTable();
                    JLT.SetValueProperty(this);
                    Code = JLT.Insert(tempDb);
                    if (Code > 0)
                    {
                        //Nodes.DataTable.Merge(JCommissions.GetDataTable(Code));
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
        public bool Delete(JDataBase Db)
        {
            JLegislationTable PDT = new JLegislationTable();
            try
            {
                //if (JPermission.CheckPermission("Meeting.JLegislation.Delete"))
                //{
                    PDT.SetValueProperty(this);
                    if (PDT.Delete(Db))
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
                //Db.Dispose();
            }
        }
        /// <summary>
        /// حذف  
        /// </summary>
        /// <returns></returns>
        public bool DeleteManual(int pCode,JDataBase Db)
        {
            JLegislationTable PDT = new JLegislationTable();
            try
            {
                //if (JPermission.CheckPermission("Meeting.JLegislation.Delete"))
                //{
                    if (PDT.DeleteManual(" MeetingCode=" + pCode.ToString(), Db))
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
                Db.Dispose();
            }
        }
        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update(JDataBase Db)
        {
            try
            {
                JLegislationTable PDT = new JLegislationTable();
                //if (JPermission.CheckPermission("Meeting.JLegislation.Update"))
                //{
                    PDT.SetValueProperty(this);
                    if (PDT.Update(Db))
                    {
                        //Nodes.Refreshdata(Nodes.CurrentNode, JLegislations.GetDataTable(Code).Rows[0]);
                        return true;
                    }
                    return false;
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
                Db.Dispose();
            }

        }
        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "Meeting.JLegislation");
            Node.Name = pRow["Legislation"].ToString() + "-" + pRow["FlowDate"].ToString();
            Node.Icone = JImageIndex.land.GetHashCode();
            Node.Hint = pRow["Legislation"].ToString();
            //اکشن ویرایش
            JAction editAction = new JAction("Edit...", "Meeting.JLegislation.ShowDialog", null, new object[] { Node.Code });
            Node.MouseDBClickAction = editAction;
            //اکشن حذف
            JAction DeleteAction = new JAction("Delete", "Meeting.JLegislation.Delete", null, new object[] { Node.Code });
            Node.DeleteClickAction = DeleteAction;
            //اکشن جدید
            JAction newAction = new JAction("New...", "Meeting.JLegislation.ShowDialog", null, null);

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

    public class JLegislations : JSystem
    {
        public JLegislations[] Items = new JLegislations[0];
        public JLegislations()
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
            string Where = " where 1=1 ";
            if (pMeetingCode != 0)
                Where = Where + " And " + JTableNamesMeeting.MetLegislation + ".MeetingCode=" + pMeetingCode;
            string Query = @"select Code,LegislationGroup,(select Name from subdefine where Code=LegislationGroup ) 'GroupName',MeetingCode,Legislation,Flow,
Description,FlowDate,PersonFlow 
            from " + JTableNamesMeeting.MetLegislation + Where;
                // + " And " + JPermission.getObjectSql("Meeting.JLegislation.GetDataTable", JTableNamesMeeting.MetLegislation + ".Code");
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
            Nodes.ObjectBase = new JAction("JLegislation", "Meeting.JMeetings.GetNode");
            Nodes.DataTable = JMeetingss.GetDataTable(0);
            JAction newAction = new JAction("New...", "Meeting.JLegislation.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Click = newAction;
            JTN.Icon = JImageIndex.Add;
            Nodes.AddToolbar(JTN);
        }

        #endregion Node
    }
}
