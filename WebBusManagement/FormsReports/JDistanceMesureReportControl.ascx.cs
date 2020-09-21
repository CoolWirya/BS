using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusManagment.Line;
using BusManagment.Zone;

namespace WebBusManagement.FormsReports
{
    public partial class JDistanceMesureReportControl : System.Web.UI.UserControl
    {
        static bool InitialReport = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {


                btnSave_Click(null, null);
            }
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now.AddDays(-1));
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now.AddDays(-1));
                LoadLines();
                LoadBus();
                LoadZones();
            }
        }

        public void LoadZones()
        {
            DataTable dt = JZones.GetDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, Name = "همه" });
            cmbZone.DataSource = p;
            cmbZone.DataTextField = "Name";
            cmbZone.DataValueField = "Code";
            cmbZone.DataBind();
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


        public void GetReport(int LineNumber = 0, int BusNumebr = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int DriverCode = 0, int ZoneCode = 0)
        {
            DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day);
            DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day);
            string WhereStr = " ";
            if (BusNumebr > 0)
                WhereStr += " and a.BusCode = " + BusNumebr;
            if (LineNumber > 0)
                WhereStr += " and a.LineNumber = (select linenumber from autline where code = " + LineNumber + " )";
            if (DriverCode > 0)
                WhereStr += " and a.OwnerCode = " + DriverCode;
            if (ZoneCode > 0)
                WhereStr += " and az.Code = " + ZoneCode;
            if (StartEventDate.HasValue)
            {
                WhereStr += @" and a.Date between '" + StartDTime.ToShortDateString() + " 00:00:00' and '" + EndDTime.ToShortDateString() + " 23:59:59'";
            }
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusManagement_FormsReports_JDistanceMesureReportControl");
            jGridView.ClassName = "WebBusManagement_FormsReports_JDistanceMesureReportControl_" + LineNumber.ToString() + "_" + BusNumebr.ToString() + "_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + EndEventDate.ToString() + "_" + DriverCode.ToString() + "_" + ZoneCode.ToString();
            jGridView.SQL = @"select a.Code,az.Name ZoneName,a.LineNumber,b.BUSNumber,cap.Name OwnerName,a.Date,cast(a.Distance as int)Distance,a.date InsertDate
                                from AUTBusDictance a
                                left join AUTBus b on a.BusCode = b.Code
                                left join clsAllPerson cap on a.OwnerCode = cap.Code
                                left join AUTLine al on al.LineNumber = a.LineNumber
                                left join AUTZone az on az.Code = al.ZoneCode
                                where 1=1 " + WhereStr;
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.PageOrderByField = " Date desc";
            jGridView.Title = "JDistanceMesureReportControl";
            jGridView.Buttons = "excel,print,record_print";
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("Distance", 0);

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
                    ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode,
                    Convert.ToInt32(cmbZone.SelectedValue));
            }
            catch { }
        }


    }
}