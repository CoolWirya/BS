using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsReports
{
    public partial class JRTPISReportControl : System.Web.UI.UserControl
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
                LoadFleets();
                LoadZones();
                LoadLines();
                LoadStation();
            }
        }

        public void LoadFleets()
        {
            DataTable dt = BusManagment.Fleet.JFleets.GetDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, Name = "همه" });
            cmbFleets.DataSource = p;
            cmbFleets.DataTextField = "Name";
            cmbFleets.DataValueField = "Code";
            cmbFleets.DataBind();
            //if (cmbFleets.Items.Count > 1)
            //{
            //    cmbFleets.SelectedIndex = 1;
            //}
        }

        public void LoadZones()
        {
            DataTable dt = BusManagment.Zone.JZones.GetDataTable(0);
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
            DataTable dt = BusManagment.Line.JLines.GetWebDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), lineName = v["lineName"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, lineName = "همه" });
            cmbLine.DataSource = p;
            cmbLine.DataTextField = "lineName";
            cmbLine.DataValueField = "Code";
            cmbLine.DataBind();
        }

        public void LoadStation()
        {
            DataTable dt = BusManagment.Station.JStations.GetDataTableForComboBox();
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), StationName = v["Name"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, StationName = "همه" });
            cmbStation.DataSource = p;
            cmbStation.DataTextField = "StationName";
            cmbStation.DataValueField = "Code";
            cmbStation.DataBind();
        }

        public void GetReport(
              int Zone = 0
            , int Fleet = 0
            , int Line = 0
            , int Station = 0
            , int Path = 0)
        {
            string WhereStr = " where 1 = 1 ";
            if (Zone > 0)
                WhereStr += " and Code in (select StationCode from AUTLineStation where LineCode in (select Code from AUTLine where ZoneCode=" + Zone + @")) ";
            if (Fleet > 0)
                WhereStr += " and Code in (select StationCode from AUTLineStation where LineCode=(select code from autline where LineNumber=(select LastLineNumber from AUTBus where FleetCode=" + Fleet + ")))";
            if (Line > 0)
                WhereStr += " and Code in (select StationCode from AUTLineStation where LineCode=" + Line + ") ";
            if (Station > 0)
                WhereStr += " and Code=" + Station;
            WhereStr += " and Code in (select StationCode from AUTLineStation where IsBack = "+Path+") ";
            
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;
            jGridView.ClassName = "WebBusManagement_FormsReports_JBusPassingStationTicketReportControl_" + Zone.ToString() + "_" + Fleet.ToString() + "_" + Line.ToString() +
                "_" + Station.ToString() + "_" + Path.ToString();
            jGridView.SQL = @"
select Code,Name, dbo.FnGetRTPISTextForBoardWithCode_WebTest(Code) Answer from AUTStation "+WhereStr;
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JRTPISReportControl";
            jGridView.PageOrderByField = "Name";
            jGridView.Buttons = "excel,print,record_print";

            jGridView.Bind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InitialReport = false;
            try
            {
                GetReport(
                  Convert.ToInt32(cmbZone.SelectedItem.Value)
                , Convert.ToInt32(cmbFleets.SelectedItem.Value)
                , Convert.ToInt32(cmbLine.SelectedItem.Value)
                , Convert.ToInt32(cmbStation.SelectedItem.Value)
                , Convert.ToInt32(cmbPathType.SelectedItem.Value));

            }
            catch { }
        }

        protected void cmbZone_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (Convert.ToInt32(cmbZone.SelectedValue) > 0)
            {
                DataTable dtLines = WebClassLibrary.JWebDataBase.GetDataTable("SELECT [Code],convert(nvarchar,[LineNumber])+' - - > '+[LineName] as [lineName],LineNumber FROM AUTLine Where ZoneCode = " + cmbZone.SelectedValue + " Order By LineNumber ASC");
                var p = (from v in dtLines.AsEnumerable()
                         select new { Code = Convert.ToInt32(v["Code"]), lineName = v["lineName"].ToString() }).ToList();
                p.Insert(0, new { Code = 0, lineName = "همه" });
                cmbLine.DataSource = p;
                cmbLine.DataTextField = "lineName";
                cmbLine.DataValueField = "Code";
                cmbLine.DataBind();

                DataTable dtStations = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code, case when IMEI > 0 then concat(Name, ' ', N'(تابلو)') else Name end Name from AUTStation Where ZoneCode = " + cmbZone.SelectedValue);
                var p2 = (from v in dtStations.AsEnumerable()
                          select new { Code = Convert.ToInt32(v["Code"]), StationName = v["Name"].ToString() }).ToList();
                p2.Insert(0, new { Code = 0, StationName = "همه" });
                cmbStation.DataSource = p2;
                cmbStation.DataTextField = "StationName";
                cmbStation.DataValueField = "Code";
                cmbStation.DataBind();
            }
            else
            {
                LoadLines();
                LoadStation();
            }
        }

        protected void cmbLine_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (Convert.ToInt32(cmbLine.SelectedValue) > 0)
            {
//                DataTable dtZones = WebClassLibrary.JWebDataBase.GetDataTable(@"select * from AUTZone Where Code =
//                    (Select ZoneCode From AutLine Where Code = " + cmbLine.SelectedValue + ")");
//                var p1 = (from v in dtZones.AsEnumerable()
//                         select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
//                p1.Insert(0, new { Code = 0, Name = "همه" });
//                cmbZone.DataSource = p1;
//                cmbZone.DataTextField = "Name";
//                cmbZone.DataValueField = "Code";
//                cmbZone.DataBind();

                DataTable dtStations = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code, case when IMEI > 0 then concat(Name, ' ', N'(تابلو)') else Name end Name from AUTStation Where Code in (Select StationCode From AutLineStation Where LineCode = " + cmbLine.SelectedValue + ")");
                var p2 = (from v in dtStations.AsEnumerable()
                         select new { Code = Convert.ToInt32(v["Code"]), StationName = v["Name"].ToString() }).ToList();
                p2.Insert(0, new { Code = 0, StationName = "همه" });
                cmbStation.DataSource = p2;
                cmbStation.DataTextField = "StationName";
                cmbStation.DataValueField = "Code";
                cmbStation.DataBind();
            }
            else
            {
                //LoadZones();
                LoadStation();
            }
        }

    }
}