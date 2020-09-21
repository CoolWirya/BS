using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebClassLibrary;


namespace WebBusManagement.FormsReports
{
    public partial class JBusServiceReportControl : System.Web.UI.UserControl
    {
        //static bool InitialReport = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {


                //   btnSave_Click(null, null);
            }
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                LoadBus();
                LoadFleets();
                LoadZones();
                LoadLines();
                LoadShift();

            }
        }

        public void LoadShift()
        {
            DataTable DtShift = new DataTable();
            DtShift = BusManagment.WorkOrder.JShifts.GetDataTable(0);
            var p = (from v in DtShift.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Title = v["Title"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, Title = "همه" });
            cmbShift.DataSource = p;
            cmbShift.DataTextField = "Title";
            cmbShift.DataValueField = "Code";
            cmbShift.DataBind();
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

        public void GetReport(int BusNumebr = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int Zone = 0,
            int Fleet = 0, int Line = 0, int ShiftCode = 0, int FromConsole = 2)
        {
            string WhereStr = " ";
            if (FromConsole < 2)
                WhereStr += " and a.FromConsole = " + FromConsole;
            if (BusNumebr > 0)
                WhereStr += " and a.BusNumber = " + BusNumebr;
            if (Zone > 0)
                WhereStr += " and a.BusNumber in (select BusNumber from AUTBus where LastLineNumber in (select LineNumber from AUTLine where ZoneCode = " + Zone + @"))";
            if (Fleet > 0)
                WhereStr += " and a.BusNumber in (select BusNumber from AUTBus where FleetCode = " + Fleet + @") ";
            if (Line > 0)
                WhereStr += " and a.BusNumber in (select BusNumber from AUTBus where LastLineNumber in (select LineNumber from AUTLine where Code = " + Line + @"))";
            if (ShiftCode > 0)
                WhereStr += " and TarrifTbl.ShiftCode = " + ShiftCode;
            //if (StartEventDate.HasValue && EndEventDate.HasValue)
                WhereStr += " and a.Date between '" + StartEventDate.Value.ToShortDateString() + " 00:00:00' and '" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + " 23:59:59'";
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusManagement_FormsReports_JBusServiceReportControl");
            jGridView.ClassName = "WebBusManagement_FormsReports_JBusServiceReportControl_" + BusNumebr.ToString() + "_"
                + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_"
                + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + "_" + Zone.ToString()
                + "_" + Fleet.ToString() + "_" + Line.ToString() + "_" + ShiftCode.ToString() + "_" + FromConsole.ToString();
            jGridView.SQL = @"select a.Code,af.Name FleetName
							,az.Name ZoneName,TarrifTbl.title ShiftName
						    ,ab.LastLineNumber,a.BusNumber,dbo.DateEnToFa(a.Date)Date,a.FirstStationCode
						 ,cast(dbo.DateEnToFa(a.FirstStationDate) as varchar) + ' ' + LEFT(CAST(CONVERT	(time,a.FirstStationDate) AS CHAR(16)),8)FirstStationDate,
                                a.LastStationCode,cast(dbo.DateEnToFa(a.LastStationDate) as varchar) + ' ' + LEFT(CAST(CONVERT(time,a.LastStationDate) AS CHAR(16)),8)LastStationDate,
								case when a.FromConsole = 0 then N'اتوماتیک' else N'دستی' end as Type,
								a.DriverCardSerial,a.DriverPersonCode,cap.Name DriverName,
								cast(dbo.DateEnToFa(a.InsertDate) as varchar) + ' ' + LEFT(CAST(CONVERT (time,a.InsertDate) AS	CHAR(16)),8)InsertDate
                                from AutBusServices a
                                left join clsAllPerson cap on cap.Code = a.DriverPersonCode
								left join AUTBus ab on ab.BUSNumber = a.BusNumber
								left join AUTLine al on al.LineNumber = ab.LastLineNumber
								left join AUTZone az on al.ZoneCode = az.Code
								left join AUTFleet af on af.Code = ab.FleetCode 
								left join (select a.buscode,Date,ass.StartTime,ass.EndTime,ass.title,ass.Code ShiftCode from AUTTariff a
											left join AutShift ass on ass.Code = a.ShiftCode) TarrifTbl
											on ab.Code = TarrifTbl.buscode
											and a.Date = cast(TarrifTbl.Date as date) and cast(a.FirstStationDate as time) between TarrifTbl.StartTime and TarrifTbl.EndTime
                                where 1 = 1 and  
                                (ISNULL(A.EzamBeCode,0) = 0 OR (ISNULL(A.EzamBeCode,0) > 0 AND ISOK = 11))
                          " + WhereStr + @"";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusServiceReportControl";
            jGridView.PageOrderByField = "Date asc";
            jGridView.Buttons = "excel,print,record_print";

            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, "WebBusManagement.FormsReports.JBusServiceReportControl._BusServiceShowMap", null, null));

            jGridView.Bind();
        }

        public string _BusServiceShowMap(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusServiceShowMap"
                  , "~/WebBusManagement/FormsReports/JBusServiceShowMapUpdateControl.ascx"
                  , "نمایش مسیر سرویس روی نقشه"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WebClassLibrary.WindowTarget.NewWindow
                  , true, false, true, 700, 450);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //InitialReport = false;
            try
            {
                if (cmbBus.SelectedValue == "0")
                {
                    GetReport(0, ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                    ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(), Convert.ToInt32(cmbZone.SelectedItem.Value)
                    , Convert.ToInt32(cmbFleets.SelectedItem.Value), Convert.ToInt32(cmbLine.SelectedItem.Value), Convert.ToInt32(cmbShift.SelectedValue),
                    Convert.ToInt32(CmbFromConsole.SelectedValue)
                    );
                }
                else
                {
                    GetReport(Convert.ToInt32(cmbBus.SelectedItem.Text), ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                    ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(), Convert.ToInt32(cmbZone.SelectedItem.Value)
                    , Convert.ToInt32(cmbFleets.SelectedItem.Value), Convert.ToInt32(cmbLine.SelectedItem.Value), Convert.ToInt32(cmbShift.SelectedValue),
                    Convert.ToInt32(CmbFromConsole.SelectedValue)
                    );
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
//                DataTable dtZones = WebClassLibrary.JWebDataBase.GetDataTable(@"select * from AUTZone Where Code =
//                    (Select ZoneCode From AutLine Where Code = " + cmbLine.SelectedValue + ")");
//                var p = (from v in dtZones.AsEnumerable()
//                         select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
//                p.Insert(0, new { Code = 0, Name = "همه" });
//                cmbZone.DataSource = p;
//                cmbZone.DataTextField = "Name";
//                cmbZone.DataValueField = "Code";
//                cmbZone.DataBind();

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