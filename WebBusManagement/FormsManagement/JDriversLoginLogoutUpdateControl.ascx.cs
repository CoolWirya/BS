using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsManagement
{
    public partial class JDriversLoginLogoutUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            ((WebControllers.MainControls.Date.JDateControl)txtDate).SetDate(DateTime.Now);
            _SetForm();
            if (!IsPostBack)
                LoadBus();
        }

        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            cmbBus.DataSource = dt;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT [AUTDriversLoginLogout].[Code]
                                                                              ,dbo.DateEnToFa([Date])DateF
                                                                              ,[Date]
                                                                              ,[AUTDriversLoginLogout].[BusNumber]
	                                                                          ,ab.Code BusCode
                                                                              ,[DriverCardSerial]
                                                                              ,ISNULL([DriverPersonCode], 0) DriverPersonCode
                                                                              ,datepart(HOUR,[LoginTime])LoginTimeHour
	                                                                          ,datepart(MINUTE,[LoginTime])LoginTimeMINUTE
                                                                              ,datepart(HOUR,[LogoutTime])LogoutTimeHour
	                                                                          ,datepart(MINUTE,[LogoutTime])LogoutTimeMINUTE
                                                                              ,dbo.DateEnToFa([InsertDate])InsertDate
                                                                          FROM [dbo].[AUTDriversLoginLogout]
                                                                          left join AUTBus ab on ab.BUSNumber = [AUTDriversLoginLogout].BusNumber where [AUTDriversLoginLogout].[Code] = " + Code, false);
                if (Dt != null)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        ((WebControllers.MainControls.Date.JDateControl)txtDate).SetDate(Convert.ToDateTime(Dt.Rows[0]["Date"].ToString()));
                        ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode = Convert.ToInt32(Dt.Rows[0]["DriverPersonCode"].ToString());
                        cmbBus.SelectedValue = Dt.Rows[0]["BusCode"].ToString();
                        txtStartTimeHour.Text = Dt.Rows[0]["LoginTimeHour"].ToString();
                        txtStartTimeMinute.Text = Dt.Rows[0]["LoginTimeMINUTE"].ToString();
                        txtFinishTimeHour.Text = Dt.Rows[0]["LogoutTimeHour"].ToString();
                        txtFinishTimeMinute.Text = Dt.Rows[0]["LogoutTimeMINUTE"].ToString();
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            if (Code > 0)
            {
                Db.setQuery(@"UPDATE [dbo].[AUTDriversLoginLogout]
                                   SET [Date] = cast('" + ((WebControllers.MainControls.Date.JDateControl)txtDate).GetDate() + @"' as date)
                                      ,[BusNumber] = " + cmbBus.SelectedItem.Text.ToString() + @"
                                      ,[DriverCardSerial] = 0
                                      ,[DriverPersonCode] = " + ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode + @"
                                      ,[LoginTime] = '" + txtStartTimeHour.Text + ":" + txtStartTimeMinute.Text + ":00" + @"'
                                      ,[LogoutTime] = '" + txtFinishTimeHour.Text + ":" + txtFinishTimeMinute.Text + ":00" + @"'
                                      ,[IsInsertedByDriver] = 0
                                 WHERE Code = " + Code + @"
                            UPDATE [dbo].[AutBusServices] 
                            SET [DriverCardSerial] = 0, 
                                [DriverPersonCode] = " + ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode + @"
                            where Date = cast('" + ((WebControllers.MainControls.Date.JDateControl)txtDate).GetDate() + @"' as date) 
                                and BusNumber = " + cmbBus.SelectedItem.Text.ToString() + @" 
                                and cast(FirstStationDate as time) between '" + txtStartTimeHour.Text + ":" + txtStartTimeMinute.Text + ":00" + @"'
                                       and '" + txtFinishTimeHour.Text + ":" + txtFinishTimeMinute.Text + ":00" + @"'");
            }
            else
            {
                DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT Code
                                                                          FROM [dbo].[AUTDriversLoginLogout]
                                                                          WHERE [Date] = cast('" + ((WebControllers.MainControls.Date.JDateControl)txtDate).GetDate() + @"' as date)
                                                                            and [BusNumber] = " + cmbBus.SelectedItem.Text.ToString() + @"
                                                                            and [LoginTime] < '" + txtFinishTimeHour.Text + ":" + txtFinishTimeMinute.Text + ":00" + @"'
                                                                            and [LogoutTime] > '" + txtStartTimeHour.Text + ":" + txtStartTimeMinute.Text + ":00" + "'", false);
                if (Dt != null && Dt.Rows.Count > 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "Set StartDate", "alert('خطا! قبلاً ورود و خروج برای این اتوبوس ثبت شده است');", true);
                    return;
                }
                Db.setQuery(@"INSERT INTO [dbo].[AUTDriversLoginLogout]
                                       ([Date]
                                       ,[BusNumber]
                                       ,[DriverCardSerial]
                                       ,[DriverPersonCode]
                                       ,[LoginTime]
                                       ,[LogoutTime]
                                       ,[InsertDate]
                                       ,[IsInsertedByDriver])
                                 VALUES
                                       (cast('" + ((WebControllers.MainControls.Date.JDateControl)txtDate).GetDate() + @"' as date)
                                       ," + cmbBus.SelectedItem.Text.ToString() + @"
                                       ,0
                                       ," + ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode + @"
                                       ,'" + txtStartTimeHour.Text + ":" + txtStartTimeMinute.Text + ":00" + @"'
                                       ,'" + txtFinishTimeHour.Text + ":" + txtFinishTimeMinute.Text + ":00" + @"'
                                       ,getdate()
                                       ,0)
                            UPDATE [dbo].[AutBusServices] 
                            SET [DriverCardSerial] = 0, 
                                [DriverPersonCode] = " + ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode + @"
                            where Date = cast('" + ((WebControllers.MainControls.Date.JDateControl)txtDate).GetDate() + @"' as date) 
                                and BusNumber = " + cmbBus.SelectedItem.Text.ToString() + @" 
                                and cast(FirstStationDate as time) between '" + txtStartTimeHour.Text + ":" + txtStartTimeMinute.Text + ":00" + @"'
                                       and '" + txtFinishTimeHour.Text + ":" + txtFinishTimeMinute.Text + ":00" + @"'");
            }
            Db.beginTransaction("DriversLoginLogout");
            try
            {
                if (Db.Query_Execute() >= 0)
                {
                    Db.Commit();
                    Page.ClientScript.RegisterStartupScript(GetType(), "Set StartDate", "alert('ثبت اطلاعات با موفقیت انجام شد');", true);
                    return;
                }
                else
                {
                    Db.Rollback("DriversLoginLogout");
                    Page.ClientScript.RegisterStartupScript(GetType(), "Set StartDate", "alert('ثبت اطلاعات با خطا مواجه شد');", true);
                    return; 
                }
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                Db.Rollback("DriversLoginLogout");
            }
            finally { Db.Dispose(); }
            Page.ClientScript.RegisterStartupScript(GetType(), "Set StartDate", "alert('ثبت اطلاعات با خطا مواجه شد');", true);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            if (Code > 0)
            {
                Db.setQuery(@"delete from [dbo].[AUTDriversLoginLogout] where code = " + Code);
                if (Db.Query_Execute() >= 0)
                {
                    WebClassLibrary.JWebManager.CloseAndRefresh();
                }
            }
        }

    }
}