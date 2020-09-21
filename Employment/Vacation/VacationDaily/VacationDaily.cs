using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using Automation;

namespace Employment
{
    public class JVacationDaily : JEmployment
    {

        public int _Refer_Code;

        #region constructor
        public JVacationDaily()
        {

        }
        public JVacationDaily(int pCode)
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
        public int User_Post_Code { get; set; }
        /// <summary>
        /// کد درخواست کننده 
        /// </summary>
        public int User_Code { get; set; }
        /// <summary>
        /// عنوان درخواست کننده 
        /// </summary>
        public string User_Full_Title { get; set; }
        /// <summary>
        /// کد  شخص درخواست کننده 
        /// </summary>
        public int pCode { get; set; }
        /// <summary>
        /// کد پست ثبت کننده 
        /// </summary>
        public int Register_Post_Code { get; set; }
        /// <summary>
        /// عنوان ثبت کننده 
        /// </summary>
        public string Register_Full_Title { get; set; }
        /// <summary>
        /// کد ثبت کننده 
        /// </summary>
        public int Register_User_Code { get; set; }
        /// <summary>
        /// کد پست تایید کننده 
        /// </summary>
        public int Confirm_Post_Code { get; set; }
        /// <summary>
        /// عنوان تایید کننده 
        /// </summary>
        public string Confirm_Full_Title { get; set; }
        /// <summary>
        /// کد  تایید کننده 
        /// </summary>
        public int Confirm_User_Code { get; set; }
        /// <summary>
        /// کد پست تایید کارگزینی کننده 
        /// </summary>
        public int ConfirmVacation_Post_Code { get; set; }
        /// <summary>
        /// عنوان تایید کارگزینی کننده 
        /// </summary>
        public string ConfirmVacation_Full_Title { get; set; }
        /// <summary>
        /// کد   تایید کارگزینی کننده 
        /// </summary>
        public int ConfirmVacation_User_Code { get; set; }
        /// <summary>
        /// وضعیت 
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// تاریخ شروع
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// تاریخ پایان 
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// نوع مرخصی 
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }

        #endregion

        #region search method

        public bool GetData(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from EmpVacationDaily where Code=" + pCode + "";
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

        private bool Find()
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from EmpVacationDaily where pCode = " + pCode + " And ((StartDate <= '" + StartDate + "' And EndDate >= '" + StartDate + "') or (StartDate <= '" + EndDate + "' ) And (EndDate >= '" + EndDate + "'))";
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

        public DataTable Search(DateTime pStartDate, DateTime pEndDate)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Where = " Where 1=1 ";
                if (StartDate.Date != DateTime.MinValue)
                    Where = Where + " And Cast(StartDate as date) >= '" + StartDate + "'";
                if (pStartDate.Date != DateTime.MinValue)
                    Where = Where + " And Cast(StartDate as date) <= '" + pStartDate + "'";
                if (EndDate.Date != DateTime.MinValue)
                    Where = Where + " And Cast(EndDate as date) >= '" + EndDate + "'";
                if (pEndDate.Date != DateTime.MinValue)
                    Where = Where + " And Cast(EndDate as date) <= '" + pEndDate + "'";
                if (pCode != 0)
                    Where = Where + " And pCode = " + pCode;
                string Query = @"select code,
User_Full_Title,
Register_Full_Title,
(select Fa_Date from StaticDates where En_Date=StartDate) 'StartDate',
(select Fa_Date from StaticDates where En_Date=EndDate) 'EndDate',
case status
when 1 then N'درخواست'
when 2 then N'تایید'
when 3 then N'تایید کارگزینی'
when 4 then N'عدم تایید'
end 'status',
case status
when 1 then N'استحقاقی'
when 2 then N'استعلاجی'
when 3 then N'بدون حقوق'
when 4 then N'تشویقی'
end N'نوع مرخصی' ,DATEDIFF(day,startDate,endDate)+1 'CountDay' 
from EmpVacationDaily " + Where;
                //" And ((StartDate >= '" + StartDate + "' And StartDate <= '" + pStartDate
                //+ "') And (EndDate >= '" + EndDate + "' ) And (EndDate <= '" + pEndDate +"'))";
                //" And ((StartDate <= '" + pStartDate + "' And EndDate >= '" + pStartDate
                //+ "') or (StartDate <= '" + pEndDate + "' ) And (EndDate >= '" + pEndDate + 
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
        #endregion

        #region method

        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            //if (JPermission.CheckPermission("Employment.JVacationDaily.Insert"))
            //{
            if (!(Find()))
            {
                JDataBase tempDb = new JDataBase();
                JVacationDailyTable JLT = new JVacationDailyTable();
                try
                {
                    tempDb.beginTransaction("VacationDaily");
                    JLT.SetValueProperty(this);
                    Code = JLT.Insert(tempDb);
                    if (Code > 0)
                    {
                        if (!(SendConfirm(tempDb)))
                            JMessages.Error("Send Not Successfuly ", "");
                        else
                        {
                            if (tempDb.Commit())
                            {
                                Nodes.DataTable = JVacationDailys.GetDataTable(0);
                                //Nodes.DataTable.Merge(JVacationDailys.GetDataTable(Code));
                                return Code;
                            }
                        }
                    }
                    tempDb.Rollback("VacationDaily");
                    return 0;
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                    tempDb.Rollback("VacationDaily");
                    return 0;
                }
                finally
                {
                    tempDb.Dispose();
                    JLT.Dispose();
                }
            }
            else
                JMessages.Message(" برای این تاریخ درخواست مرخصی ثبت شده است ", "", JMessageType.Error);
            //}
            return 0;
        }

        /// <summary>
        /// حذف  
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            if (JPermission.CheckPermission("Employment.JVacationDaily.Delete"))
            {
                JDataBase DB = JGlobal.MainFrame.GetDBO();
                JVacationDailyTable PDT = new JVacationDailyTable();
                try
                {
                    PDT.SetValueProperty(this);
                    if (PDT.Delete())
                        return true;
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
                    DB.Dispose();
                    PDT.Dispose();
                }
            }
            return false;
        }

        /// <summary>
        /// ویرایش 
        /// </summary>
        /// <returns></returns>
        public bool Update(bool Send)
        {
            JDataBase Db = new JDataBase();
            try
            {
                Db.beginTransaction("VacationDaily");
                if (Update(Db, Send))
                {
                    if (Db.Commit())
                        return true;
                    else
                    {
                        Db.Rollback("VacationDaily");
                        return false;
                    }
                }
                else
                {
                    Db.Rollback("VacationDaily");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Db.Rollback("VacationDaily");
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
        public bool Update(JDataBase Db, bool Send)
        {
            //if (JPermission.CheckPermission("Employment.JVacationHour.Update"))
            //{                
            JVacationDailyTable PDT = new JVacationDailyTable();
            try
            {
                //Db.beginTransaction("VacationDaily");
                PDT.SetValueProperty(this);
                if (PDT.Update(Db))
                    if (Send)
                    {
                        if (!(SendConfirm(Db)))
                        {
                            //Db.Rollback("VacationDaily");
                            JMessages.Error("Send Not Successfuly ", "");
                        }
                        else
                        {
                            //if (Db.Commit())
                            //{
                            //Nodes.DataTable.Merge(JVacationHours.GetDataTable(Code));
                            return true;
                            //}
                        }
                    }
                    else
                    {
                        //if (Db.Commit())
                        return true;
                        //else
                        //{
                        //    //Db.Rollback("VacationDaily");
                        //    return false;
                        //}
                    }
                //Db.Rollback("VacationDaily");
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                //Db.Rollback("VacationDaily");
                return false;
            }
            finally
            {
                if ((Send))
                    Db.Dispose();
                PDT.Dispose();
            }
            //}
            //return false;
        }

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
                                    where pu.User_Post_Code = " + JMainFrame.CurrentPostCode + "  pu.ObjectCode =  " + pCode + " and pc.Class_Name=N'Employment.JVacationHour.SendConfirm') ";
                //+ JPermission.getObjectSql("Employment.JVacationHour.SendConfirm", "Code");
                db.setQuery(Query);
                DataTable dt = db.Query_DataTable();
                if (dt.Rows.Count <= 0)
                {
                    Query = "select * from VOrganizationChart where Code = " + JMainFrame.CurrentPostCode + " AND (Select COUNT(*) From VOrganizationChart where Code = " + pCode + " and parentcode = " + JMainFrame.CurrentPostCode + ") >= 1";
                    db.setQuery(Query);
                    dt = db.Query_DataTable();
                }

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
        /// ارسال به تایید کننده کارگزینی 
        /// </summary>
        /// <returns></returns>
        public static bool CheckConfirmFinal(int pRefer_Code)
        {
            JDataBase db = new JDataBase();
            try
            {
                Automation.JARefer tmprefer = new Automation.JARefer(pRefer_Code);
                string Query = @"select * from VOrganizationChart Where Code IN (select pu.User_Post_Code from PermissionUser pu
                                    inner join PermissionDecision pd on pu.DecisionCode=pd.Code
                                    inner join PermissionControl pc on pc.Decision_Code = pd.Code
                                    where (pu.ObjectCode = 0 OR pu.ObjectCode=" + tmprefer.sender_post_code + ") and pc.Class_Name=N'Employment.JVacationDaily.SendConfirmFinal')";
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
        public bool SendConfirm(JDataBase db)
        {
            try
            {
                // Current User Permission for Inserting Vacation
                JDataBase db2 = new JDataBase();
                string Query = @"select * from VOrganizationChart Where  Code IN (select pu.User_Post_Code from PermissionUser pu
                                    inner join PermissionDecision pd on pu.DecisionCode=pd.Code
                                    inner join PermissionControl pc on pc.Decision_Code = pd.Code
                                    where  pu.User_Post_Code =  " + JMainFrame.CurrentPostCode + " and ObjectCode = (select EmpEmployee.Code from EmpEmployee inner join VOrganizationChart on VOrganizationChart.pCode = EmpEmployee.pCode where VOrganizationChart.Code = " + this.User_Post_Code + ") and pc.Class_Name=N'Employment.JVacationHour.GetUser') ";
                db2.setQuery(Query);
                DataTable dt2 = db2.Query_DataTable();
                if (dt2.Rows.Count > 0 || JMainFrame.CurrentPostCode == this.User_Post_Code)
                {
                    // Finding Confirmer and Refering Vacation
                    Query = @"select * from VOrganizationChart Where  Code IN (select pu.User_Post_Code from PermissionUser pu
                                    inner join PermissionDecision pd on pu.DecisionCode=pd.Code
                                    inner join PermissionControl pc on pc.Decision_Code = pd.Code
                                    where  pu.ObjectCode =  " + this.User_Post_Code + " and pc.Class_Name=N'Employment.JVacationHour.SendConfirm') ";
                    db.setQuery(Query);
                    DataTable dt = db.Query_DataTable();
                    if (dt.Rows.Count <= 0)
                    {
                        Query = "select * from VOrganizationChart where Code = (select parentcode from VOrganizationChart where Code = " + this.User_Post_Code + ")";
                        db.setQuery(Query);
                        dt = db.Query_DataTable();
                    }
                    if (dt.Rows.Count > 0)
                    {
                        Automation.JARefer tmprefer = new Automation.JARefer();
                        Automation.JARefer prefer = new JARefer(_Refer_Code);
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
                        tmprefer.ReferLevel = prefer.ReferLevel + 1;
                        tmprefer.status = 1;
                        tmprefer.is_active = true;
                        tmprefer.ReferGroup = 1;
                        if (_Refer_Code != 0)
                            tmprefer.parent_code = _Refer_Code;

                        tmprefer.object_code = tmprefer.SendToAutomation(Code, ClassLibrary.Domains.JAutomation.JObjectType.VacationDaily
                            , "مرخصی روزانه", "مرخصی روزانه", "Employment.JVacationDaily",
                            db, User_Full_Title, User_Post_Code, pCode, false);
                        int referCode = tmprefer.Send(db, true);
                        if (referCode > 0)
                        {
                                return true;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
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

        /// <summary>
        /// ارسال به کارگزینی
        /// </summary>
        /// <returns></returns>
        public bool SendConfirmFinal(int pRefer_Code)
        {
            return SendConfirmFinal(pRefer_Code, null);
        }
        public bool SendConfirmFinal(int pRefer_Code, JDataBase pDB)
        {
            JDataBase db;
            if (pDB == null)
                db = new JDataBase();
            else
                db = pDB;

            try
            {
                if (pDB == null)
                    db.beginTransaction("ConfirmFinal");
                if (Update(db, false))
                {
                    string Query = @"select * from VOrganizationChart Where  Code IN (select pu.User_Post_Code from PermissionUser pu
                                        inner join PermissionDecision pd on pu.DecisionCode=pd.Code
                                        inner join PermissionControl pc on pc.Decision_Code = pd.Code
                                        where (pu.ObjectCode = " + User_Post_Code + ") and pc.Class_Name=N'Employment.JVacationDaily.SendConfirmFinal') ";
                    db.setQuery(Query);
                    DataTable dt = db.Query_DataTable();
                    if (dt.Rows.Count > 0)
                    {
                        Automation.JARefer tmprefer = new Automation.JARefer();

                        Automation.JARefer temprefer = new Automation.JARefer();
                        temprefer.GetData(pRefer_Code);

                        tmprefer.object_code = temprefer.object_code;
                        tmprefer.ReferLevel = temprefer.ReferLevel + 1;
                        tmprefer.send_date_time = DateTime.Now;
                        tmprefer.sender_code = JMainFrame.CurrentUserCode;//User_Post_Code;
                        tmprefer.sender_full_title = JMainFrame.CurrentPostTitle;//tmpdt.Rows[0]["Full_Title"].ToString();
                        tmprefer.sender_post_code = JMainFrame.CurrentPostCode;//Convert.ToInt32(tmpdt.Rows[0]["Code"]);
                        tmprefer.receiver_code = Convert.ToInt32(dt.Rows[0]["User_Code"]);
                        tmprefer.receiver_full_title = dt.Rows[0]["Full_Title"].ToString();
                        tmprefer.receiver_post_code = Convert.ToInt32(dt.Rows[0]["Code"]);
                        tmprefer.register_user_code = JMainFrame.CurrentUserCode;
                        tmprefer.register_Date_Time = DateTime.Now;
                        tmprefer.status = 1;
                        tmprefer.parent_code = pRefer_Code;
                        tmprefer.is_active = true;
                        tmprefer.ReferGroup = 1;
                        if (tmprefer.Send(db, true) > 0)
                        {
                            if (db.Commit())
                                return true;
                        }
                        else
                        {
                            db.Rollback("ConfirmFinal");
                            return false;
                        }
                    }
                    else
                    {
                        db.Rollback("ConfirmFinal");
                        return false;
                    }
                }
                db.Rollback("ConfirmFinal");
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                db.Rollback("ConfirmFinal");
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public void ReferShow()
        {
            ReferShow(0, 0);
        }
        public void ReferShow(int pCode, int pRefer_Code)
        {
            if (pCode == 0)
            {
                JVacationDailyForm LandForm = new JVacationDailyForm();
                LandForm.State = JFormState.Insert;
                if (LandForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    ReferShow(0, 0);
            }
            else
            {
                JVacationDailyForm LandForm = new JVacationDailyForm(pCode, pRefer_Code);
                LandForm.State = JFormState.Update;
                LandForm.ShowDialog();
            }
        }

        #endregion

        #region GetData

        public static DataTable GetDataTable(int pCode)
        {
            string Where = " where 1=1 ";
            if (pCode != 0)
                Where = Where + " And Code=" + pCode;
            string Query = @"select * from  EmpVacationDaily " + Where;
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

        public static DataTable GetUser()
        {
            string Query = "  select P.Code,(Fam+'-'+Name+'_'+cast(E.PersonNumber as nvarchar)) as 'Name' from clsPerson P inner join empemployee E on P.Code = E.pCode where p.code=" + JMainFrame.CurrentPersonCode;
            string tmpQuery = @" union select E.Code,(Fam+'-'+Name+'_'+cast(E.PersonNumber as nvarchar)) as 'Name' from clsPerson P inner join empemployee E on P.Code = E.pCode And E.Active=1 Where ";
            //string Query = @"select * from VOrganizationChart Where " +
            string tmpWhere = JPermission.getObjectSql("Employment.JVacationHour.GetUser", "E.Code");
            if (!string.IsNullOrEmpty(tmpWhere.Replace("1 = 1", "").Replace(" ", ""))) Query += tmpQuery + tmpWhere;
            //Query = Query + " union select * from VOrganizationChart where code=" + JMainFrame.CurrentPostCode;
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
            JNode Node = new JNode((int)pRow["Code"], "Employment.JVacationDaily");
            Node.Name = pRow["User_Full_Title"].ToString();
            Node.Icone = JImageIndex.land.GetHashCode();
            Node.Hint = pRow["StartDate"].ToString();
            //اکشن ویرایش
            JAction editAction = new JAction("Edit...", "Employment.JVacationDaily.ReferShow", new object[] { Node.Code, 0 }, null);
            Node.MouseDBClickAction = editAction;
            //اکشن حذف
            //JAction DeleteAction = new JAction("Delete", "Employment.JVacationHour.Delete", null, new object[] { Node.Code });
            //Node.DeleteClickAction = DeleteAction;
            //اکشن جدید
            JAction newAction = new JAction("New...", "Employment.JVacationDaily.ReferShow", null, null);

            //Node.Popup.Insert(DeleteAction);
            Node.Popup.Insert(editAction);
            Node.Popup.Insert(newAction);
            //Node.Popup.Insert(PersonAction);
            return Node;
        }

        #endregion
    }

    public class JVacationDailys : JSystem
    {

        public JVacationDailys[] Items = new JVacationDailys[0];
        public JVacationDailys()
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
                Where = Where + " And EmpVacationDaily.Code=" + pCode;
            string Query = @"select code,
                                REPLACE(SUBSTRING(User_Full_Title, 1, CHARINDEX('_', User_Full_Title, 1)-1), '-', '،') as 'User_Full_Title',
                                REPLACE(SUBSTRING(Register_Full_Title, 1, CHARINDEX('_', Register_Full_Title, 1)-1), '-', '،') as 'ثبت کننده',
                                (select Fa_Date from StaticDates where En_Date=CAST(StartDate as Date)) 'StartDate',
                                (select Fa_Date from StaticDates where En_Date=CAST(EndDate as Date)) 'EndDate',
                                case status
                                when 0 then N'برگشت'
                                when 1 then N'درخواست'
                                when 2 then N'تایید'
                                when 3 then N'تایید کارگزینی'
                                when 4 then N'عدم تایید'
                                end 'status',
                                case Type
                                when 1 then N'استحقاقی'
                                when 2 then N'استعلاجی'
                                when 3 then N'بدون حقوق'
                                when 4 then N'تشویقی'
                                end N'نوع مرخصی'
                                ,DATEDIFF(day,startDate,endDate)+1 'CountDay' 
                                 from EmpVacationDaily Where Register_Post_Code = " + JMainFrame.CurrentPostCode + " OR User_Post_Code= " + JMainFrame.CurrentPostCode + Where + " Order by Code desc";
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
            Nodes.ObjectBase = new JAction("VacationDaily", "Employment.JVacationDaily.GetNode");
            Nodes.DataTable = GetDataTable();
            JAction newAction = new JAction("New...", "Employment.JVacationDaily.ReferShow", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode JTN = new JToolbarNode();
            JTN.Click = newAction;
            JTN.Icon = JImageIndex.Add;
            Nodes.AddToolbar(JTN);
        }

        #endregion Node

    }
}
