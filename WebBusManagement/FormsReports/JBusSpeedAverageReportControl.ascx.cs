using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusManagment.Line;

namespace WebBusManagement.FormsReports
{

    public partial class JBusSpeedAverageReportControl : System.Web.UI.UserControl
    {
        static bool InitialReport = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                //  
                //    GetReport();
                //else
                btnSave_Click(null, null);
            }
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now.AddDays(-1));
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now.AddDays(-1));
                LoadLines();
                LoadBus();
            }
        }


        public void LoadLines()
        {
            DataTable dt = JLines.GetWebDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), lineName = v["lineName"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, lineName = "همه" });
            cmbLine.DataSource = p;
            cmbLine.DataTextField = "lineName";
            cmbLine.DataValueField = "Code";
            cmbLine.DataBind();
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


        public void GetReport(int LineNumber = 0, int BusNumebr = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int DriverCode = 0)
        {
            DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day);
            DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day);
            string WhereStr = " where 1 = 1 ";
            if (BusNumebr > 0)
                WhereStr += " and BusNumber = (select busnumber from autbus where code = " + BusNumebr + " )";
            if (LineNumber > 0)
                WhereStr += " and LineNumber = (select linenumber from autline where code = " + LineNumber + " )";
            if (DriverCode > 0)
                WhereStr += " and DriverPersonCode = " + DriverCode;
            if (StartEventDate.HasValue)
            {
                WhereStr += @" and Date between '" + StartDTime.ToShortDateString() + " 00:00:00' and '" + EndDTime.ToShortDateString() + " 23:59:59'";
            }
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusManagement_FormsReports_JBusSpeedAverageReportControl");
            jGridView.ClassName = "WebBusManagement_FormsReports_JBusSpeedAverageReportControl_" + LineNumber.ToString() + "_" + BusNumebr.ToString() + "_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + "_" + DriverCode.ToString();
            jGridView.SQL = @"select AUTBusSpeedAverage.Code,BusCode,BusNumber,Date,LineNumber,DriverCardSerial,DriverPersonCode,cap.Name DriverName,SpeedAverage,MaxSpeed,InsertDate from AUTBusSpeedAverage
                              left join clsAllPerson cap on cap.Code = AUTBusSpeedAverage.DriverPersonCode " + WhereStr;
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            //jGridView.HiddenColumns = "Code";
            jGridView.PageOrderByField = " Code desc ";
            jGridView.Title = "JBusSpeedAverageReportControl";
            jGridView.Buttons = "excel,print,record_print";
            jGridView.Bind();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InitialReport = false;
            try
            {
                GetReport(Convert.ToInt32(cmbLine.SelectedValue), Convert.ToInt32(cmbBus.SelectedValue),
                    ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                    ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(),
                    ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode);
            }
            catch { }
        }

    }
}