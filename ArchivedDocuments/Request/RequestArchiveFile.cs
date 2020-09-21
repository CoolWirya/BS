using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace ArchivedDocuments
{
    public class JRequestArchiveFile : JSystem
    {
        public int _Refer_Code;

        #region constructor
        public JRequestArchiveFile()
        {

        }
        public JRequestArchiveFile(int pCode)
        {
            GetData(pCode);
        }
        #endregion

        #region Property
        /// <summary>
        /// کد 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// کد پست درخواست کننده 
        /// </summary>
        public int Requester_Post_Code { get; set; }
        /// <summary>
        /// عنوان درخواست کننده 
        /// </summary>
        public string Requester_Full_Title { get; set; }
        /// <summary>
        /// کد درخواست کننده 
        /// </summary>
        public int Requester_User_Code { get; set; }
        /// <summary>
        ///  تاریخ درخواست
        /// </summary>
        public DateTime RequestDate { get; set; }
        /// <summary>
        /// وضعیت 
        /// </summary>
        //public int Status { get; set; }
        #endregion

        #region method
        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert(DataTable pArchiveList)
        {
            if (JPermission.CheckPermission("ArchivedDocuments.JRequestArchiveFile.Insert"))
            {
                JDataBase tempDb = new JDataBase();
                JRequestArchiveFileTable JLT = new JRequestArchiveFileTable();
                JRequestArchiveList tmpRequestArchiveList = new JRequestArchiveList();
                JArchiveDocument tmpArchiveDocument = new JArchiveDocument();
                try
                {
                    tempDb.beginTransaction("JRequestArchiveFile");
                    JLT.SetValueProperty(this);
                    Code = JLT.Insert(tempDb);
                    if (Code > 0)
                    {
                        foreach (DataRow dr in pArchiveList.Rows)
                        {
                            tmpRequestArchiveList.RequestCode = Code;
                            tmpRequestArchiveList.ArchiveCode = Convert.ToInt32(dr["ArchiveCode"]);
                            if(dr["Confirm_Post_Code"].ToString() != "")
                                tmpRequestArchiveList.Confirm_Post_Code = Convert.ToInt32(dr["Confirm_Post_Code"].ToString());
                            tmpRequestArchiveList.Confirm_Full_Title = dr["Confirm_Full_Title"].ToString();
                            if (dr["Confirm_User_Code"].ToString() != "")
                                tmpRequestArchiveList.Confirm_User_Code = Convert.ToInt32(dr["Confirm_User_Code"].ToString());
                            tmpRequestArchiveList.Status = ClassLibrary.Domains.Employment.JVacationStatus.Request;// Convert.ToInt32(dr["Status"].ToString());
                            //if (dr["StartDate"].ToString() != "")
                            //    tmpRequestArchiveList.StartDate = Convert.ToDateTime(dr["StartDate"]);
                            //if (dr["EndDate"].ToString() != "")
                            //    tmpRequestArchiveList.EndDate = Convert.ToDateTime(dr["EndDate"]);
                            //tmpRequestArchiveList.Description = dr["Description"].ToString();
                            if (tmpRequestArchiveList.Insert(tempDb) < 1)
                            {
                                tempDb.Rollback("JRequestArchiveFile");
                                return 0;
                            }
                            tmpArchiveDocument.GetData(tmpRequestArchiveList.ArchiveCode);
                            if (tmpArchiveDocument.PlaceCode == 0)
                            {
                                tempDb.Rollback("JRequestArchiveFile");
                                JMessages.Error("مکان آرشیو این فایل تعیین نشده است ", "");
                                return 0;
                            }
                            if (!(SendConfirm(tempDb, tmpArchiveDocument.PlaceCode)))
                            {
                                tempDb.Rollback("JRequestArchiveFile");
                                JMessages.Error("Send Not Successfuly ", "");
                                return 0;
                            }
                        }
                        if (tempDb.Commit())
                            return Code;
                        else
                        {
                            tempDb.Rollback("JRequestArchiveFile");
                            return 0;
                        }
                    }
                    else
                        return 0;
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                    tempDb.Rollback("JRequestArchiveFile");
                    return 0;
                }
                finally
                {
                    tempDb.Dispose();
                    JLT.Dispose();
                    tmpRequestArchiveList.Dispose();
                    tmpArchiveDocument.Dispose();
                }
            }
            return 0;
        }
        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update(JDataBase Db, bool Send)
        {
            if (JPermission.CheckPermission("ArchivedDocuments.JRequestArchiveFile.Update"))
            {
                JRequestArchiveFileTable PDT = new JRequestArchiveFileTable();
                try
                {
                    Db.beginTransaction("RequestArchiveFile");
                    PDT.SetValueProperty(this);
                    if (PDT.Update(Db))
                        if (Send)
                        {
                            if (!(SendConfirm(Db, 999)))
                            {
                                Db.Rollback("RequestArchiveFile");
                                JMessages.Error("Send Not Successfuly ", "");
                            }
                            else
                            {
                                if (Db.Commit())
                                {
                                    //Nodes.DataTable.Merge(JVacationHours.GetDataTable(Code));
                                    return true;
                                }
                            }
                        }
                        else
                        {
                            if (Db.Commit())
                                return true;
                            else
                            {
                                Db.Rollback("RequestArchiveFile");
                                return false;
                            }
                        }
                    Db.Rollback("RequestArchiveFile");
                    return false;
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                    Db.Rollback("RequestArchiveFile");
                    return false;
                }
                finally
                {
                    if ((Send))
                        Db.Dispose();
                    PDT.Dispose();
                }
            }
            return false;
        }
        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update(DataTable pArchiveList)
        {
            if (JPermission.CheckPermission("ArchivedDocuments.JRequestArchiveFile.Update"))
            {
                JDataBase Db = new JDataBase();
                JRequestArchiveFileTable PDT = new JRequestArchiveFileTable();
                try
                {
                    PDT.SetValueProperty(this);
                    if (PDT.Update(Db))
                        return true;
                    return false;
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                    return false;
                }
                finally
                {
                    PDT.Dispose();
                    Db.Dispose();
                }
            }
            return false;
        }

        /// <summary>
        /// حذف 
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            if (JPermission.CheckPermission("ArchivedDocuments.JRequestArchiveFile.Delete"))
            {
                JDataBase Db = new JDataBase();
                JRequestArchiveFileTable PDT = new JRequestArchiveFileTable();
                try
                {
                    PDT.SetValueProperty(this);
                    if (PDT.Delete(Db))
                        return true;
                    return false;
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                    return false;
                }
                finally
                {
                    PDT.Dispose();
                    Db.Dispose();
                }
            }
            return false;
        }
        #endregion

        public bool GetData(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from ArchiveRequest where Code=" + pCode + "";
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


        public void ReferShow()
        {
            ReferShow(0, 0, 0);
        }
        public void ReferShow(int pCode, int pRefer_Code)
        {
            ReferShow(pCode, 0, pRefer_Code);
        }
        public void ReferShow(int pCode, int pArchiveCode, int pRefer_Code)
        {
            if (pCode == 0)
            {
                JRequestArchiveFileForm LandForm = new JRequestArchiveFileForm(0, pArchiveCode, 0);
                LandForm.State = JFormState.Insert;
                LandForm.ShowDialog();
            }
            else
            {
                JRequestArchiveFileForm LandForm = new JRequestArchiveFileForm(pCode, 0, pRefer_Code);
                LandForm.State = JFormState.Update;
                LandForm.ShowDialog();
            }
        }

        #region GetData
        public DataTable GetDataTable()
        {
            return GetDataTable(0);
        }
        public static DataTable GetDataTable(int pCode)
        {
            string Where = "";
            if (pCode != 0)
                Where = Where + " And Code=" + pCode;
            string Query = @"select * 
From ArchiveRequest";// Where Code = " + JMainFrame.CurrentPostCode + Where;
            //" And " + JPermission.getObjectSql("Meeting.JCommissions.GetDataTable", JTableNamesMeeting.MetCommission + ".Code");
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

        /// <summary>
        /// ارسال به تایید کننده
        /// </summary>
        /// <returns></returns>
        public static bool CheckConfirm(int pCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                string Query = @"select * from VOrganizationChart Where  Code IN (select pu.User_Post_Code from PermissionUser pu
inner join PermissionDecision pd on pu.DecisionCode=pd.Code
inner join PermissionControl pc on pc.Decision_Code = pd.Code
where  pu.ObjectCode =  " + pCode + " and pc.Class_Name=N'ArchivedDocuments.JRequestArchiveFile.SendConfirm') ";
                //+ JPermission.getObjectSql("Employment.JVacationHour.SendConfirm", "Code");
                db.setQuery(Query);
                DataTable dt = db.Query_DataTable();
                if (dt.Rows.Count > 0)
                    if (Convert.ToInt32(dt.Rows[0]["Code"]) == JMainFrame.CurrentPostCode)
                        return true;
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

        /// <summary>
        /// ارسال به تایید کننده
        /// </summary>
        /// <returns></returns>
        public bool SendConfirm(JDataBase db, int pArchivePlaceCode)
        {
            try
            {
                string Query = @"select * from VOrganizationChart Where  Code IN (select pu.User_Post_Code from PermissionUser pu
inner join PermissionDecision pd on pu.DecisionCode=pd.Code
inner join PermissionControl pc on pc.Decision_Code = pd.Code
where  pu.ObjectCode =  " + pArchivePlaceCode + " and pc.Class_Name=N'ArchivedDocuments.JRequestArchiveFile.SendConfirm') ";
                db.setQuery(Query);
                DataTable dt = db.Query_DataTable();
                if (dt.Rows.Count > 0)
                {
                    Automation.JARefer tmprefer = new Automation.JARefer();
                    tmprefer.send_date_time = DateTime.Now;

                    //db.setQuery("select * from VOrganizationChart Where Code = " + dt.Rows[0][0].ToString());
                    //DataTable tmpdt = db.Query_DataTable();
                    tmprefer.sender_code = JMainFrame.CurrentUserCode;
                    tmprefer.sender_full_title = JMainFrame.CurrentPostTitle;
                    tmprefer.sender_post_code = JMainFrame.CurrentPostCode;
                    tmprefer.receiver_code = Convert.ToInt32(dt.Rows[0]["User_Code"]);
                    tmprefer.receiver_full_title = dt.Rows[0]["Full_Title"].ToString();
                    tmprefer.receiver_post_code = Convert.ToInt32(dt.Rows[0]["Code"]);
                    tmprefer.register_user_code = JMainFrame.CurrentUserCode;
                    tmprefer.register_Date_Time = DateTime.Now;
                    tmprefer.status = 1;
                    tmprefer.is_active = true;
                    tmprefer.ReferGroup = 1;
                    if (_Refer_Code != 0)
                        tmprefer.parent_code = _Refer_Code;

                    //tmprefer.object_code = tmprefer.SendToAutomation(Code, ClassLibrary.Domains.JAutomation.JObjectType.ArchiveRequest
                        //, "درخواست آرشیو فایل", "درخواست آرشیو فایل", "ArchivedDocuments.JRequestArchiveFile",
                        //db, JMainFrame.CurrentPostTitle, JMainFrame.CurrentUserCode, JMainFrame.CurrentUserCode, false);
                    //if (tmprefer.Send(db, true) > 0)
                        //return true;
                    //else
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
                db.Dispose();
            }
        }

        public static DataTable GetDataTableArchiveFile(int pCode,int pRequestCode)
        {
            string Where = " Where 1=1 ";
            if (pCode != 0)
                Where = Where + " And AI.Code=" + pCode;
            if (pRequestCode != 0)
                Where = Where + " And Al.RequestCode=" + pRequestCode;
            string Query = @"select

case Al.status
when 1 then 'درخواست'
when 2 then 'تایید'
when 3 then 'عدم تایید'
else 'درخواست'
end 'statusTitle',
Al.Status as 'status',
(select Fa_Date from StaticDates where En_Date=Cast(AI.ArchiveDate as Date)) 'RegisterDate',
(select Name from ArchivedSubject Where Code=AI.subjectcode) 'Subject',
AI.ArchiveDesc 'ArchiveFileDesc' ,

Al.Code,
Al.RequestCode,
AI.Code as 'ArchiveCode',
Al.Confirm_Post_Code,
Al.Confirm_Full_Title,
Al.Confirm_User_Code,
(select Fa_Date from StaticDates where En_Date=Cast(Al.StartDate as Date)) StartDate,
(select Fa_Date from StaticDates where En_Date=Cast(Al.EndDate as Date)) EndDate,
Al.Description
 from ArchiveRequestList Al Right join ArchiveInterface AI on Al.archivecode=AI.Code " + Where;
            //" And " + JPermission.getObjectSql("Meeting.JCommissions.GetDataTable", JTableNamesMeeting.MetCommission + ".Code");
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

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "ArchivedDocuments.JRequestArchiveFile");
            Node.Name = pRow["Requester_Full_Title"].ToString();
            Node.Icone = JImageIndex.land.GetHashCode();
            Node.Hint = pRow["RequestDate"].ToString();
            //اکشن ویرایش
            JAction editAction = new JAction("Edit...", "ArchivedDocuments.JRequestArchiveFile.ReferShow", new object[] { Node.Code, 0, 0 }, null);
            Node.MouseDBClickAction = editAction;
            //اکشن حذف
            //JAction DeleteAction = new JAction("Delete", "ArchivedDocuments.JRequestArchiveFile.Delete", null, new object[] { Node.Code });
            //Node.DeleteClickAction = DeleteAction;
            //اکشن جدید
            JAction newAction = new JAction("New...", "ArchivedDocuments.JRequestArchiveFile.ReferShow", null, null);

            //Node.Popup.Insert(DeleteAction);
            Node.Popup.Insert(editAction);
            Node.Popup.Insert(newAction);
            //Node.Popup.Insert(PersonAction);
            return Node;
        }
    }

    public class JRequestArchiveFiles : JSystem
    {

        public JRequestArchiveFiles[] Items = new JRequestArchiveFiles[0];
        public JRequestArchiveFiles()
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
            string Where = "";
            if (pCode != 0)
                Where = Where + " And AR.Code=" + pCode;
            string Query = @"select
AR.Code,
AR.Requester_Full_Title,
(select Fa_Date from StaticDates where En_Date=Cast(AR.RequestDate as Date)) RequestDate,
Al.Confirm_Full_Title,
(select Fa_Date from StaticDates where En_Date=Cast(Al.StartDate as Date)) StartDate,
(select Fa_Date from StaticDates where En_Date=Cast(Al.EndDate as Date)) EndDate,
Al.Description,
case Al.status
when 1 then 'درخواست'
when 2 then 'تایید'
when 3 then 'عدم تایید'
else 'درخواست'
end 'status',
(select Fa_Date from StaticDates where En_Date=Cast(AI.ArchiveDate as Date)) 'RegisterDate',
(select Name from ArchivedSubject Where Code=AI.subjectcode) 'Subject',
AI.ArchiveDesc
 from 
 ArchiveRequest AR inner join ArchiveRequestList Al on AR.Code=Al.RequestCode
 inner join ArchiveInterface AI on Al.archivecode=AI.Code  
  Where Requester_User_Code = " + JMainFrame.CurrentUserCode + Where;
            //" And " + JPermission.getObjectSql("Meeting.JCommissions.GetDataTable", JTableNamesMeeting.MetCommission + ".Code");
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
            Nodes.ObjectBase = new JAction("RequestArchive", "ArchivedDocuments.JRequestArchiveFile.GetNode");
            Nodes.DataTable = GetDataTable();
            //JAction newAction = new JAction("New...", "ArchivedDocuments.JRequestArchiveFile.ReferShow", null, null);
            //Nodes.GlobalMenuActions.Insert(newAction);
            //JToolbarNode JTN = new JToolbarNode();
            //JTN.Click = newAction;
            //JTN.Icon = JImageIndex.Add;
            //Nodes.AddToolbar(JTN);
        }

        #endregion Node

    }

}
