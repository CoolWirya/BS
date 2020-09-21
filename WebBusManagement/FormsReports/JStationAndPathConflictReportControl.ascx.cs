using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClassLibrary;


namespace WebBusManagement.FormsReports
{
    public partial class JStationAndPathConflictReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
            }
            else
            {
                LoadLines();
                LoadZones();
            }
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

        public void GetReport(int LineCode = 0,int ZoneCode = 0)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;
            jGridView.ClassName = "WebBusManagement_FormsReports_JStationAndPathConflictReportControl_" + LineCode.ToString() + ZoneCode.ToString();

            string WhereStr = "";
            if (LineCode > 0)
                WhereStr += " and ls.LineCode = " + LineCode;
            if (ZoneCode > 0)
                WhereStr += " and l.ZoneCode = " + ZoneCode;

            jGridView.SQL = @"
            select
		                    s.Code 
				            ,l.LineNumber
		                    ,s.Code StationCode
		                    ,s.Name StationName
		                    ,(case ls.IsBack when 0 then N'رفت' else N'برگشت' end) path
		                    ,ls.Priority
		                    ,calibr.dis DistanceToPath
		                    ,s.Angle StationAngle
		                    ,calibr.CoursePath PathAngle
                            ,case when cos(3.14*(calibr.c)/90) < SQRT(3)/2  then N'جهت اشتباه است' else N'جهت درست است' end CourseState
                            ,case when isnull(calibr.dis,100000000000000000) > s.Radius / 2  then N'موقعیت اشتباه است' else N'موقعیت درست است' end positionState
                            ,case when NOT EXISTS(select 1 from AUTFleetLinePoints where LineCode=l.code and PathType=1)  then N'مسیر رفت رسم نشده است' else N'مسیر رفت رسم شده است' end gorouteState
                            ,case when NOT EXISTS(select 1 from AUTFleetLinePoints where LineCode=l.code and PathType=2)  then N' مسیر برگشت رسم نشده است' else N' مسیر برگشت رسم شده است' end BackrouteState
		                     from AUTLineStation ls
		                     inner join AUTLine l on l.Code = ls.LineCode
		                     inner join AUTStation s on s.Code = ls.StationCode
		                     outer apply dbo.CalibratedGPSWithPath(s.Lat,s.Lng,s.Angle,l.LineNumber, (case ls.IsBack when 0 then 1 else 2 end)) calibr
		                     where (
                                        cos(3.14*(calibr.c)/90) < SQRT(3)/2 
                                        or 
                                        isnull(calibr.dis,100000000000000000) > s.Radius / 2
                                        or
                                        (NOT EXISTS(select 1 from AUTFleetLinePoints where LineCode=l.code and PathType=1) and ls.IsBack = 0)
                                        or
                                        (NOT EXISTS(select 1 from AUTFleetLinePoints where LineCode=l.code and PathType=2) and ls.IsBack = 1)
                                    )" + WhereStr;
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 10;
            jGridView.Title = "JStationAndPathConflictReportControl";
            jGridView.PageOrderByField = " path desc, Priority";
            jGridView.Buttons = "excel,print,record_print,refresh";
            jGridView.Bind();
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, "WebBusManagement.FormsReports.JStationAndPathConflictReportControl._StationsUpdate", null, null));
        }
        public string _StationsUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Stations"
                   , "~/WebBusManagement/FormsManagement/JStationsUpdateControl.ascx"
                   , "ایستگاه"
                   , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                   , WindowTarget.NewWindow
                   , true, false, true, 770, 450);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            GetReport(Convert.ToInt32(cmbLine.SelectedValue), Convert.ToInt32(cmbZone.SelectedValue));
        }
    }
}