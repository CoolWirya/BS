using BusManagment.Bus;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JOwnerChangeUpdateControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                LoadBus();
                LoadOwners();
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
            }
        }

        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, BUSNumber = "-" });
            cmbBus.DataSource = p;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }
        public void LoadOwners()
        {
            DataTable BusOwners = JBusOwners.GetBusOwners();
            var p = (from v in BusOwners.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, Name = "-" });
            this.cmbReceiverOwner.DataSource = p;
            this.cmbReceiverOwner.DataTextField = "Name";
            this.cmbReceiverOwner.DataValueField = "Code";
            this.cmbReceiverOwner.DataBind();
            this.cmbSenderOwner.DataSource = p;
            this.cmbSenderOwner.DataTextField = "Name";
            this.cmbSenderOwner.DataValueField = "Code";
            this.cmbSenderOwner.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DateTime FromDate = ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate();
            DateTime ToDate = ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate();
            if (FromDate <= DateTime.MinValue || ToDate <= DateTime.MinValue)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "err", "alert('لطفاً تاریخ شروع و پایان را انتخاب کنید.');", true);
                return;
            }
            if (Convert.ToInt32(cmbSenderOwner.SelectedValue) == 0 || Convert.ToInt32(cmbReceiverOwner.SelectedValue) == 0)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "err", "alert('لطفاً مالکین را انتخاب کنید.');", true);
                return;
            }
            if (Convert.ToInt32(cmbBus.SelectedValue) == 0)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "err", "alert('لطفاً اتوبوس را انتخاب کنید.');", true);
                return;
            }
            JDataBase db = new JDataBase();
            db.beginTransaction("UpdateTicket");
            db.setQuery(@"
                INSERT INTO [dbo].[AUTBusOwnerChange]
                           ([Code]
                           ,[BusNumber]
                           ,[FromOwnerCode]
                           ,[ToOwnerCode]
                           ,[FromDate]
                           ,[ToDate]
                           ,[UserPostCode])
                     VALUES
                           (isnull((select max(Code) + 1 from [dbo].[AUTBusOwnerChange]), 1)
                           ,@BusNumber
                           ,@FromOwnerCode
                           ,@ToOwnerCode
                           ,cast(@FromDate as date)
                           ,cast(@ToDate as date)
                           ,@UserPostCode)");
            db.AddParams("BusNumber", cmbBus.SelectedItem.Text);
            db.AddParams("BusCode", cmbBus.SelectedValue);
            db.AddParams("FromOwnerCode", cmbSenderOwner.SelectedValue);
            db.AddParams("ToOwnerCode", cmbReceiverOwner.SelectedValue);
            db.AddParams("FromDate", FromDate.ToString("yyyy-MM-dd 00:00:00"));
            db.AddParams("ToDate", ToDate.ToString("yyyy-MM-dd 23:59:59"));
            db.AddParams("UserPostCode", ClassLibrary.JMainFrame.CurrentPostCode.ToString());

            if (db.Query_Execute() < 0)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "err", "alert('دوباره تلاش کنید.');", true);
                return;
            }
            JDataBase db2 = new JDataBase();
            db2.AddParams("BusNumber", cmbBus.SelectedItem.Text);
            db2.AddParams("BusCode", cmbBus.SelectedValue);
            db2.AddParams("FromOwnerCode", cmbSenderOwner.SelectedValue);
            db2.AddParams("ToOwnerCode", cmbReceiverOwner.SelectedValue);
            db2.AddParams("FromDate", FromDate.ToString("yyyy-MM-dd 00:00:00"));
            db2.AddParams("ToDate", ToDate.ToString("yyyy-MM-dd 23:59:59"));
            db2.AddParams("UserPostCode", ClassLibrary.JMainFrame.CurrentPostCode.ToString());
            db2.setQuery(@"
                    declare @dates table (TranDate Date)

                    update AUTTicketTransaction set OwnerCode = @ToOwnerCode output Cast(inserted.EventDate as date) into @dates 
                    where BusCode = @BusCode and BusNumber=@BusNumber and OwnerCode = @FromOwnerCode and EventDate between @FromDate and @ToDate

	                declare @DateTimeN DateTime

	                declare Date_Cursor_Temp_ProcessTicket1 CURSOR FOR 
	                select TranDate from @dates

	                OPEN Date_Cursor_Temp_ProcessTicket1
	                FETCH NEXT FROM Date_Cursor_Temp_ProcessTicket1 INTO @DateTimeN
	                WHILE @@FETCH_STATUS = 0
	                BEGIN
                        declare @WorkDate int
                        select @WorkDate = isnull(Code,0) from AUTWorkedDay where Date=cast(@DateTimeN as date)

                        if(@WorkDate = 0 OR @WorkDate is NULL)
                        BEGIN
	                        Insert into AUTWorkedDay Values
	                        (
		                        (select isnull(Max(Code),0) +1 from AUTWorkedDay),
		                        cast(@DateTimeN as Date),
		                        1
	                        )
                        END
                        ELSE
                        BEGIN
	                        Update AUTWorkedDay set Active=1 WHERE Code =@WorkDate
                        END

	                    FETCH NEXT FROM Date_Cursor_Temp_ProcessTicket1 INTO @DateTimeN
	                END
	                CLOSE Date_Cursor_Temp_ProcessTicket1;
	                DEALLOCATE Date_Cursor_Temp_ProcessTicket1;");
            if (db2.Query_Execute(true) >= 0)
            {
                db.Commit();
                Page.ClientScript.RegisterStartupScript(GetType(), "success", "alert('پردازش مورد نظر آغاز شد.');", true); 
            }
            else
            {
                db.Rollback("UpdateTicket");
                Page.ClientScript.RegisterStartupScript(GetType(), "success", "alert('دوباره تلاش کنید.');", true);
            }
        }
    }
}