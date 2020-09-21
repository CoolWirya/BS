using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebClassLibrary;
using BusManagment.Zone;
using BusManagment.Line;

namespace WebBusManagement.FormsReports
{
    public partial class JBusPassingStationReportControl : System.Web.UI.UserControl
    {
        static bool InitialReport = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                
                 
                    //btnSave_Click(null, null);
            }
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                LoadBus();
                LoadFleets();
                LoadZones();
                LoadLines();
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
            if (cmbFleets.Items.Count > 1)
            {
                cmbFleets.SelectedIndex = 1;
            }
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

        public void GetReport(int BusNumebr = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int Zone = 0, int Fleet = 0, int Line = 0, int StationType = 0)
        {
            string WhereStr = " 1 = 1 ";
            if (BusNumebr > 0)
                WhereStr += " and abps.BusNumber = " + BusNumebr;
            if (Zone > 0)
                WhereStr += " and abps.BusNumber in (select BusNumber from AUTBus where LastLineNumber in (select LineNumber from AUTLine where ZoneCode = " + Zone + @"))";
            if (Fleet > 0)
                WhereStr += " and abps.BusNumber in (select BusNumber from AUTBus where FleetCode = " + Fleet + @") ";
            if (Line > 0)
                WhereStr += " and abps.BusNumber in (select BusNumber from AUTBus where LastLineNumber in (select LineNumber from AUTLine where Code = " + Line + @"))";
            if (StationType > 0)
                WhereStr += " and (abps.firstStation = 1 or abps.LastStation = 1)";
            if (StartEventDate.HasValue && EndEventDate.HasValue)
                WhereStr += " and abps.EventDate between '" + StartEventDate.Value.ToShortDateString() + " 00:00:00' and '" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + " 23:59:59'";
           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusManagement_FormsReports_JBusPassingStationReportControl");
            jGridView.ClassName = "WebBusManagement_FormsReports_JBusPassingStationReportControl_"+BusNumebr.ToString()+ "_" +(StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "")+ "_" +Zone.ToString()+ "_" +Fleet.ToString()+ "_" +Line.ToString()+ "_" +StationType.ToString();
            string SQL = @"SELECT Max(abps.[Code])Code
                                      , case when als.Priority = (select max(Priority) from AUTLineStation where LineCode = als.LineCode and IsBack = als.IsBack)
									  then cast(dbo.DateEnToFa([ArrivalDate]) as varchar)+' '+LEFT(CAST(CONVERT(time,[ArrivalDate]) AS CHAR(16)),8)
									  else cast(dbo.DateEnToFa([EventDate]) as varchar)+' '+LEFT(CAST(CONVERT(time,[EventDate]) AS CHAR(16)),8)
									  end [EventDate]
									  ,af.Name FleetName
									  ,az.Name ZoneName
									  ,al.LineNumber
                                      ,abps.[BusNumber]
                                      ,abps.[StationCode]
	                                  ,ast.Name StationName
									  ,case when als.IsBack = 0 then N'رفت' when als.IsBack = 1 then N'برگشت' else N'' end IsBack
									  ,als.Priority
                                      ,case  when abps.firstStation = 1 then N'ایستگاه ابتدای خط' when abps.LastStation = 1 then N'ایستگاه انتهای خط' else N'سایر ایستگاه ها' end as StationType
                                      ,[DriverCardSerial]
                                      ,[DriverPersonCode]
									  ,ISNULL(cap.Name,N'نامشخص')DriverName
                                      ,max(cast(dbo.DateEnToFa(InsertDate) as varchar)+' '+cast(cast(InsertDate as time(0)) as varchar))InsertDate
                                  FROM [dbo].[AutBusPassingStations] abps
                                  left join AUTStation ast on abps.[StationCode] = ast.Code
								  left join clsAllPerson cap on cap.Code = abps.DriverPersonCode
								  left join AUTLine al on al.Code = abps.LineCode
								  left join AUTZone az on al.ZoneCode = az.Code
								  left join AUTFleet af on af.Code = al.Fleet
								  left join AUTLineStation als on als.LineCode = al.Code and als.StationCode = ast.Code
								  where  " + WhereStr + @"
								  group by af.Name,az.Name,al.LineNumber,als.LineCode,[EventDate],[ArrivalDate]
								  ,abps.[BusNumber],abps.[StationCode],ast.Name,als.IsBack,als.Priority,[DriverCardSerial],[DriverPersonCode],cap.Name,abps.firstStation, abps.LastStation";
            jGridView.SQL = SQL;
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            //jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusPassingStationReportControl";
            jGridView.PageOrderByField = " BusNumber,EventDate desc ";
            jGridView.Buttons = "excel,print,record_print";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("Show", "Show", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JBusPassingStationReportControl._ShowPoint", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            //jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, "WebBusManagement.FormsReports.JBusPassingStationReportControl._ShowPoint", null, null));

            jGridView.Bind();
        }

        public string _ShowPoint(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("ShowPoint"
                  , "~/WebBusManagement/FormsReports/JBusPassingStationShowPointUpdateControl.ascx"
                  , "نمایش نقاط عبور از ایستگاه"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 900, 450);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InitialReport = false;
            try
            {
                if (cmbBus.SelectedValue == "0")
                {
                    GetReport(0, ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                    ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(), Convert.ToInt32(cmbZone.SelectedItem.Value)
                    , Convert.ToInt32(cmbFleets.SelectedItem.Value), Convert.ToInt32(cmbLine.SelectedItem.Value), Convert.ToInt32(cmbStationType.SelectedItem.Value));
                }
                else
                {
                    GetReport(Convert.ToInt32(cmbBus.SelectedItem.Text), ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                    ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(), Convert.ToInt32(cmbZone.SelectedItem.Value)
                    , Convert.ToInt32(cmbFleets.SelectedItem.Value), Convert.ToInt32(cmbLine.SelectedItem.Value), Convert.ToInt32(cmbStationType.SelectedItem.Value));
                }

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

                DataTable dtBus = WebClassLibrary.JWebDataBase.GetDataTable(@"Select Code,BusNumber from AUTBus Where Active = 1 
                                                                              and LastLineNumber in (SELECT LineNumber FROM AUTLine 
                                                                              Where ZoneCode = " + cmbZone.SelectedValue + ") Order By BusNumber ASC");
                var p2 = (from v in dtBus.AsEnumerable()
                          select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
                p2.Insert(0, new { Code = 0, BUSNumber = "همه" });
                cmbBus.DataSource = p2;
                cmbBus.DataTextField = "BUSNumber";
                cmbBus.DataValueField = "Code";
                cmbBus.DataBind();
            }
            else
            {
                LoadLines();
                LoadBus();
            }
        }

        protected void cmbLine_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (Convert.ToInt32(cmbLine.SelectedValue) > 0)
            {
                DataTable dtZones = WebClassLibrary.JWebDataBase.GetDataTable(@"select * from AUTZone Where Code =
                    (Select ZoneCode From AutLine Where Code = " + cmbLine.SelectedValue + ")");
                var p = (from v in dtZones.AsEnumerable()
                         select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
                p.Insert(0, new { Code = 0, Name = "همه" });
                cmbZone.DataSource = p;
                cmbZone.DataTextField = "Name";
                cmbZone.DataValueField = "Code";
                cmbZone.DataBind();

                DataTable dtBus = WebClassLibrary.JWebDataBase.GetDataTable(@"Select Code,BusNumber from AUTBus Where Active = 1 
                                                                              and LastLineNumber in (SELECT LineNumber FROM AUTLine 
                                                                              Where Code = " + cmbLine.SelectedValue + ") Order By BusNumber ASC");
                var p2 = (from v in dtBus.AsEnumerable()
                          select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
                p2.Insert(0, new { Code = 0, BUSNumber = "همه" });
                cmbBus.DataSource = p2;
                cmbBus.DataTextField = "BUSNumber";
                cmbBus.DataValueField = "Code";
                cmbBus.DataBind();
            }
            else
            {
                LoadZones();
                LoadBus();
            }
        }

        protected void cmbBus_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (Convert.ToInt32(cmbBus.SelectedValue) > 0)
            {
                DataTable dtLines = WebClassLibrary.JWebDataBase.GetDataTable("SELECT [Code],convert(nvarchar,[LineNumber])+' - - > '+[LineName] as [lineName],LineNumber FROM AUTLine Where LineNumber = (Select LastLineNumber From AutBus Where Code = " + cmbBus.SelectedValue + ") Order By LineNumber ASC");
                var p = (from v in dtLines.AsEnumerable()
                         select new { Code = Convert.ToInt32(v["Code"]), lineName = v["lineName"].ToString() }).ToList();
                p.Insert(0, new { Code = 0, lineName = "همه" });
                cmbLine.DataSource = p;
                cmbLine.DataTextField = "lineName";
                cmbLine.DataValueField = "Code";
                cmbLine.DataBind();

                DataTable dtZones = WebClassLibrary.JWebDataBase.GetDataTable(@"select * from AUTZone Where Code =
                    (Select top 1 ZoneCode From AutLine Where LineNumber = (Select LastLineNumber From AutBus Where Code = " + cmbBus.SelectedValue + "))");
                var p2 = (from v in dtZones.AsEnumerable()
                          select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
                p2.Insert(0, new { Code = 0, Name = "همه" });
                cmbZone.DataSource = p2;
                cmbZone.DataTextField = "Name";
                cmbZone.DataValueField = "Code";
                cmbZone.DataBind();
            }
            else
            {
                LoadZones();
                LoadLines();
            }
        }

    }
}