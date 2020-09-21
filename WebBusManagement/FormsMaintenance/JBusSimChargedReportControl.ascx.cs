using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JBusSimChargedReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                btnSave_Click(null, null);
            }
            else
            {
                LoadBus();
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
            }
        }

        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, BUSNumber = "همه" });
            cmbBus.DataSource = p;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }

        public void GetReport(int BusCode = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            string WhereStr = " where 1=1 ";

            if (BusCode > 0)
                WhereStr += " and absi.BusCode = " + BusCode;
            if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
            {
                DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day);
                DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day);
                WhereStr += @" and absi.EventDate between '" + StartDTime.ToShortDateString() + " 00:00:00' and '" + EndDTime.ToShortDateString() + " 23:59:59'";
            }

           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusMaintenance_JBusSimChargedReportControl");
           jGridView.ClassName = "WebBusManagement_FormsMaintenance_JBusSimChargedReportControl" + BusCode.ToString() + "_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "");
            jGridView.SQL = @"select top 100 percent absi.Code,ab.BUSNumber,ab.LastLineNumber,absi.EventDate,
                                absi.ChargeDate,absi.ChargeAmount,absi.OldCharge,absi.NewCharge from AUTBusSimCardCharge absi
                                left join AUTBus ab on absi.BusCode = ab.Code" + WhereStr;
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusSimChargedReportControl";
            jGridView.Buttons = "excel";
            jGridView.Bind();
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            GetReport(Convert.ToInt32(cmbBus.SelectedValue),
                        ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                        ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
        }
    }
}