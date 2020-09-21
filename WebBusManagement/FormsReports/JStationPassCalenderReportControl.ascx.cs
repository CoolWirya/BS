using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsReports
{
    public partial class JStationPassCalenderReportControl : System.Web.UI.UserControl
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
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                LoadLines();
            }
        }

        public void LoadLines()
        {
            DataTable dt = BusManagment.Line.JLines.GetWebDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), lineName = v["lineName"].ToString() }).ToList();
            cmbLine.DataSource = p;
            cmbLine.DataTextField = "lineName";
            cmbLine.DataValueField = "Code";
            cmbLine.DataBind();
        }

        public string CreateTempTable(int LineCode,int IsBack)
        {
            String QRet=@"
create table #MyTempTable
(
a0 varchar(100)";
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery("select ',a'+cast(Priority as varchar)+' int' c from autLineStation where LineCode=" + LineCode + " and IsBack=" + IsBack + " order by Priority");
                DataTable DT = db.Query_DataTable();
                foreach (DataRow dr in DT.Rows)
                {
                    QRet += Environment.NewLine + dr[0].ToString();
                }
                QRet += Environment.NewLine + ")";

                return QRet;
            }
            finally
            {
                db.Dispose();
            }
        }

        public void GetReport(
            DateTime? StartEventDate = null
            , DateTime? EndEventDate = null
            , int Line = 0
            , int HourOf = 0
            , int MinuteOf = 0
            , int HourTo = 0
            , int MinuteTo = 0
            , int Path = 0)
        {

            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;
            jGridView.ClassName = "WebBusManagement_FormsReports_JBusPassingStationTicketReportControl_" + "_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + Line.ToString() + "_" + Path.ToString();
            jGridView.SQL = "";
            jGridView.SQL += Environment.NewLine + "IF OBJECT_ID('tempdb..#MyTempTable') IS NOT NULL DROP Table #MyTempTable";
            jGridView.SQL += Environment.NewLine + CreateTempTable(Line, Path);
            jGridView.SQL += @"
insert into #MyTempTable
EXEC	[dbo].[SP_CalenderStationCreator]
        @StartTime = '"+HourOf+':'+MinuteOf+@"',
        @EndTime = '"+HourTo+':'+MinuteTo+@"',
        @StartDate = '"+((DateTime)StartEventDate).ToShortDateString()+@"',
        @EndDate = '"+((DateTime)EndEventDate).ToShortDateString()+@"',
        @InterVal = "+txtTimeInterval.Text+@",
        @LineCode = " + Line + @",
        @IsBack =" + Path + @"
<#PreviusSQL#>
SELECT ROW_NUMBER()over(order by a0) Code, * FROM #MyTempTable
";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.Title = "JStationPassCalenderReportControl";
            jGridView.Buttons = "excel,print,record_print";

            jGridView.Bind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InitialReport = false;
            try
            {
                GetReport(
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate()
                ,((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate()
                , Convert.ToInt32(cmbLine.SelectedItem.Value)
                , Convert.ToInt32(txtHourOf.Text)
                , Convert.ToInt32(txtMinuteOf.Text)
                , Convert.ToInt32(txtHourTo.Text)
                , Convert.ToInt32(txtMinuteTo.Text)
                , Convert.ToInt32(cmbPathType.SelectedItem.Value));

            }
            catch { }
        }

    }
}