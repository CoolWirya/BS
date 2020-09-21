using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JConsulHistoryReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Int64 CuIMEI;
                if (txtIMEI.Text != "" && txtIMEI.Text.Length == 15)
                {
                    if (Int64.TryParse(txtIMEI.Text, out CuIMEI) == true)
                    {
                        GetReport(Convert.ToInt64(txtIMEI.Text));
                    }
                }
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

        public void GetReport(Int64 IMEI = 0, double BusNumebr = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            string WhereStr = " where 1=1 ";
            if (IMEI > 0)
                WhereStr += " and at.IMEI = " + IMEI;
            if (BusNumebr > 0)
                WhereStr += " and at.BusSerial = " + BusNumebr;
            if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
            {
                DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day);
                DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day);
                WhereStr += @" and at.[Date] between '" + StartDTime.ToShortDateString() + "' and '" + EndDTime.ToShortDateString() + "'";
            }

            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("WebBusMaintenance_JConsulHistory");
            jGridView.SQL = @"SELECT top 100 percent at.Code,at.IMEI,at.[Date],at.BusSerial,
                                cast(cast(substring(at.[Version],0,2) AS INT)AS NVARCHAR)+
                                cast(cast(substring(at.[Version],2,2) AS INT)AS NVARCHAR)+
                                cast(cast(substring(at.[Version],4,2) AS INT)AS NVARCHAR)ConsulVersion
                                FROM AUTHeaderTransaction at
                                " + WhereStr + @"
                                ORDER BY at.[Date]";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JConsulHistoryReportControl";
            jGridView.Buttons = "excel";
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).GridView = jGridView;
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).LoadGrid(true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Int64 CuIMEI;
            if (txtIMEI.Text != "" && txtIMEI.Text.Length == 15)
            {
                if (Int64.TryParse(txtIMEI.Text, out CuIMEI) == true)
                {
                    GetReport(Convert.ToInt64(txtIMEI.Text), Convert.ToDouble(cmbBus.SelectedItem.Text),
                    ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                    ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
                }
            }
            else
            {
                if (cmbBus.SelectedItem.Value != "0")
                {
                    GetReport(0, Convert.ToDouble(cmbBus.SelectedItem.Text),
                        ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                        ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
                }
                else
                {
                    GetReport(0, Convert.ToDouble(0),
                        ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                        ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
                }
            }
        }
    }
}