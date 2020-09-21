using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsReports
{
    public partial class JBusAvlTransenctionReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Avl Transaction Map
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapAvlT).Provider = WebControllers.MainControls.OpenLayersMap.MapProvider.GoogleStreets;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapAvlT).CenterPosition = "46.294956,38.068636";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapAvlT).Zoom = "12";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapAvlT).Action = "";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapAvlT).TimerEnabled = false;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapAvlT).TimerInterval = 0;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapAvlT).MouseClickAddUserMarker = false;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapAvlT).CanAddMultipleMarkers = false;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapAvlT).DrawMarkers = true;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapAvlT).DrawLines = false;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapAvlT).MarkerClick = false;

            if (IsPostBack)
                btnSave_Click(null, null);
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                LoadBus();
                txtStartTimeHour.Text = "07";
                txtStartTimeMinute.Text = "00";
                txtFinishTimeHour.Text = "07";
                txtFinishTimeMinute.Text = "00";
            }
        }

        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), BusNumber = v["BUSNumber"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, BusNumber = "همه" });
            cmbBus.DataSource = p;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }

        public int GmtMintePlus = 210;
        public void GetReport(int BUSNumber = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null, TimeSpan? StartTime = null, TimeSpan? EndTime = null)
        {
            string WhereStr = "", Query = "";

            string PersianDateNow = ClassLibrary.JDateTime.FarsiDate(DateTime.Now);
            if (Convert.ToInt32(PersianDateNow.Split('/')[2].ToString()) <= 6)
            {
                GmtMintePlus = 270;
            }

            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            if (StartEventDate.HasValue == true || BUSNumber > 0)
            {
                WhereStr = " where 1=1 ";

                if ((StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime) && !StartTime.HasValue)
                    WhereStr += @" and dateadd(minute," + GmtMintePlus.ToString() + @",at.EventDate) between '" +
                        StartEventDate.Value.Date.ToShortDateString() + " 00:00:00' and '" + EndEventDate.Value.Date.ToShortDateString() + " 23:59:59'";

                if ((StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime) && StartTime.HasValue)
                {
                    DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day, StartTime.Value.Hours, StartTime.Value.Minutes, StartTime.Value.Seconds);
                    DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day, EndTime.Value.Hours, EndTime.Value.Minutes, EndTime.Value.Seconds);
                    WhereStr += @" and dateadd(minute," + GmtMintePlus.ToString() + @",at.EventDate) between '" + StartDTime.ToString() + "' and '" + EndDTime.ToString() + "'";
                }

                if (BUSNumber > 0)
                    WhereStr += @" and at.BusCode=" + BUSNumber;
            }

            Query = @"SELECT top 100 percent at.Code,ab.BUSNumber,at.Latitude as Latitude,at.Longitude as Longitude,dateadd(minute," + GmtMintePlus.ToString() + @",at.EventDate)EventDate
                            ,at.Speed,at.SimCardCharge,at.GpsAntenna,at.GsmAntenna
                            FROM AUTAvlTransaction at
                            LEFT JOIN AUTBus ab ON at.BusCode = ab.Code"
                            + WhereStr + " order by dateadd(minute," + GmtMintePlus.ToString() + @",at.EventDate)";

            RadGridReport1.DataSource = WebClassLibrary.JWebDataBase.GetDataTable(Query);
            RadGridReport1.DataBind();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TimeSpan TsStartTime;
            TimeSpan TsEndTime;
            int TimeFlag = 0;
            try
            {
                TsStartTime = new TimeSpan(
                        Convert.ToInt32(txtStartTimeHour.Text)
                        , Convert.ToInt32(txtStartTimeMinute.Text), 0);
            }
            catch
            {
                TsStartTime = new TimeSpan(0, 0, 0);
                TimeFlag = 1;
            }

            try
            {
                TsEndTime = new TimeSpan(
                        Convert.ToInt32(txtFinishTimeHour.Text)
                        , Convert.ToInt32(txtFinishTimeMinute.Text), 0);
            }
            catch
            {
                TsEndTime = new TimeSpan(0, 0, 0);
                TimeFlag = 1;
            }

            if (TimeFlag == 0)
            {
                GetReport(Convert.ToInt32(cmbBus.SelectedValue), ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(), ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(), TsStartTime, TsEndTime);
            }
            else if (TimeFlag == 1)
            {
                GetReport(Convert.ToInt32(cmbBus.SelectedValue), ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(), ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(), null, null);
            }
        }

        protected void RadGridReport1_PreRender(object sender, EventArgs e)
        {
            if (RadGridReport1.DataSource == null) return;
            foreach (DataColumn col in (RadGridReport1.DataSource as DataTable).Columns)
            {
                RadGridReport1.MasterTableView.GetColumn(col.ColumnName).HeaderText = ClassLibrary.JLanguages._Text(col.ColumnName);
                if (col.ColumnName == "Code")
                {
                    RadGridReport1.MasterTableView.GetColumn(col.ColumnName).Visible = false;
                }
            }
            RadGridReport1.MasterTableView.Rebind();
        }
    }
}