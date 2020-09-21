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
    public partial class JDriversLoginLogoutReportControl : System.Web.UI.UserControl
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
                LoadLines();
                LoadZones();
                //GetReport();
                btnSave_Click(null, null);
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


        public void GetReport(int BusNumebr = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int DriverCode = 0, int LineCode = 0,
            int ZoneCode = 0)
        {
            string WhereStr = " 1 = 1 ", Datestr = " 1 = 1 ";
            if (BusNumebr > 0)
                WhereStr += " and login.BusNumber = " + BusNumebr;
            if (LineCode > 0)
                WhereStr += " and line.Code = " + LineCode;
            if (ZoneCode > 0)
                WhereStr += " and zone.Code = " + ZoneCode;
            if (DriverCode > 0)
                WhereStr += " and DriverPersonCode = " + DriverCode;
            if (StartEventDate.HasValue && EndEventDate.HasValue)
            {
                WhereStr += " and cast(login.Date as date) between '" + StartEventDate.Value.ToShortDateString() + "' and '" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + "'";
                Datestr = " Date between '" + StartEventDate.Value.ToShortDateString() + "' and '" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + "'";
            }
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusManagement_FormsReports_JDriversLoginLogoutReportControl");
            jGridView.ClassName = "WebBusManagement_FormsReports_JDriversLoginLogoutReportControl_" + BusNumebr.ToString() + "_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + "_" + DriverCode.ToString() + "_" + LineCode.ToString();
            jGridView.SQL = @"
                            IF OBJECT_ID('tempdb..#tempShiftDrv') IS NOT NULL DROP Table #tempShiftDrv
								select BusNumber, DriverCardSerial, LineNumber, Date
                                into #tempShiftDrv
                                from AUTShiftDriver
								where " + Datestr + @"
								group by BusNumber, DriverCardSerial, LineNumber, Date
                                <#PreviusSQL#>
                                SELECT login.Code
                                    ,dbo.DateEnToFa(login.Date)Date
                                    ,login.BusNumber
                                    ,ShiftDriver.LineNumber LineNumber
									,zone.Name ZoneName
                                    ,login.DriverCardSerial
									,(select top 1 code from Cards where Cards.RfidNumber = login.DriverCardSerial and Cards.Status=1) CardCode
                                    ,login.DriverPersonCode
	                                ,ISNULL((select top 1 Name from clsallPerson where code =login.DriverPersonCode) ,N'نامشخص')DriverName
									,convert(varchar(32),[LoginTime],8)[LoginTime]
									,convert(varchar(32),[LogoutTime],8)[LogoutTime]
                                    ,dbo.DateEnToFa(login.InsertDate)InsertDate
                                FROM AUTDriversLoginLogout login
                                left join #tempShiftDrv ShiftDriver on ShiftDriver.BusNumber = login.BUSNumber 
                                    and ShiftDriver.DriverCardSerial = login.DriverCardSerial and ShiftDriver.Date = login.Date 
								left join AUTLine line on line.LineNumber = ShiftDriver.LineNumber
								left join AUTZone zone on zone.Code = line.ZoneCode
                                where " + WhereStr;

            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "DriversLoginLogoutReport";
            jGridView.PageOrderByField = " Date Desc";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JDriversLoginLogoutReportControl._DriversLoginLogoutNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JDriversLoginLogoutReportControl._DriversLoginLogoutUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, "WebBusManagement.FormsReports.JDriversLoginLogoutReportControl._DriversLoginLogoutUpdate", null, null));
            jGridView.Buttons = "excel,print,record_print,refresh";
            jGridView.Bind();

        }

        public string _DriversLoginLogoutNew()
        {
            return _DriversLoginLogoutNew(null);
        }
        public string _DriversLoginLogoutNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("DriversLoginLogout"
                 , "~/WebBusManagement/FormsManagement/JDriversLoginLogoutUpdateControl.ascx"
                 , "ورود و خروج راننده"
                 , null
                 , WindowTarget.NewWindow
                 , true, false, true, 700, 500);
        }
        public string _DriversLoginLogoutUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("DriversLoginLogout"
                  , "~/WebBusManagement/FormsManagement/JDriversLoginLogoutUpdateControl.ascx"
                  , "ورود و خروج راننده"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 700, 500);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InitialReport = false;
            try
            {
                if (cmbBus.SelectedValue == "0")
                {
                    GetReport(0, ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                        ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(),
                        ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode, Convert.ToInt32(cmbLine.SelectedValue),
                        Convert.ToInt32(cmbZone.SelectedItem.Value));
                }
                else
                {
                    GetReport(Convert.ToInt32(cmbBus.SelectedItem.Text), ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                            ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(),
                            ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode, Convert.ToInt32(cmbLine.SelectedValue), Convert.ToInt32(cmbZone.SelectedItem.Value));
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
    }
}