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
    public partial class JLineSpeedAverageReportControl : System.Web.UI.UserControl
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


        public void GetReport(int LineNumber = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day);
            DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day);
            string WhereStr = " where 1 = 1 ";
            if (LineNumber > 0)
                WhereStr += " and LineNumber = (select linenumber from autline where code = " + LineNumber + " )";
            if (StartEventDate.HasValue)
            {
                WhereStr += @" and Date between '" + StartDTime.ToShortDateString() + " 00:00:00' and '" + EndDTime.ToShortDateString() + " 23:59:59'";
            }
           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusManagement_FormsReports_JLineSpeedAverageReportControl");
            jGridView.ClassName = "WebBusManagement_FormsReports_JBusSpeedAverageReportControl_"+LineNumber.ToString()+ "_" +(StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "")+ "_" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "");
            jGridView.SQL = @"select Max(AUTBusSpeedAverage.Code)Code,Date,LineNumber,cast(avg(SpeedAverage) as int)SpeedAverage,max(MaxSpeed)MaxSpeed from AUTBusSpeedAverage
                               " + WhereStr + " group by Date,LineNumber";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            //jGridView.HiddenColumns = "Code";
            jGridView.PageOrderByField = " Code desc";
            jGridView.Title = "JLineSpeedAverageReportControl";
            jGridView.Buttons = "excel,print,record_print";
            jGridView.Bind();
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InitialReport = false;
            try
            {
                GetReport(Convert.ToInt32(cmbLine.SelectedValue),
                    ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                    ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
            }
            catch { }
        }

    }
}