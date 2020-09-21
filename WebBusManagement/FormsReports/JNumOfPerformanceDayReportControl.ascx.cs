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
    public partial class JNumOfPerformanceDayReportControl : System.Web.UI.UserControl
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
               // LoadFleets();
                LoadZones();
                LoadLines();
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
        //#region Original code

        //public void GetReport(int BusNumebr = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        //{
        //    string WhereStr = "", WhereStr2 = "";
        //    //

        //    //
        //    if (BusNumebr > 0)
        //        WhereStr += " and a.BusNumber = " + BusNumebr;
        //    if (StartEventDate.HasValue && EndEventDate.HasValue)
        //        WhereStr2 += " and Startdate between '" + StartEventDate.Value.ToShortDateString() + " 00:00:00' and '" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + " 23:59:59'";
        //   WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusManagement_FormsReports_JNumOfPerformanceDayReportControl");
        //    jGridView.ClassName = "WebBusManagement_FormsReports_JNumOfPerformanceDayReportControl_"+BusNumebr.ToString()+ "_" +(StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "")+ "_" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "");
        //    jGridView.SQL = @"select max(a.Code)Code,a.BusNumber,Count(*)NumOfDay from (
        //                        select max(Code)Code,BusNumber,cast(startdate as date)Date from AUTShiftDriver where 1 = 1 " + WhereStr2 + @"
        //                        group by BusNumber,cast(startdate as date)
        //                        )a
        //                        where 1 = 1 " + WhereStr + @"
        //                        group by a.BusNumber";
        //    jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
        //    jGridView.PageSize = 50;
        //    jGridView.HiddenColumns = "Code";
        //    jGridView.Title = "JNumOfPerformanceDayReportControl";
        //    jGridView.PageOrderByField = " BusNumber asc";
        //    jGridView.Buttons = "excel,print,record_print";

        //    jGridView.Bind();
        //}
        //#endregion

        //        public void GetReport(int BusNumebr = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int Zone = 0,
        //             int Line = 0)
        //        {
        //            string WhereStr = " 1 = 1 ";
        //            if (BusNumebr > 0)
        //                WhereStr += " and ab.BusNumber = " + BusNumebr;
        //            if (StartEventDate.HasValue && EndEventDate.HasValue)
        //                WhereStr += " and abst.date between '" + StartEventDate.Value.ToShortDateString() + "' and '" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + "'";
        //            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusManagement_FormsReports_JBusPassingStationTicketReportControl");
        //            jGridView.ClassName = "WebBusManagement_FormsReports_JNumOfPerformanceDayReportControl_" + BusNumebr.ToString() + "_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + Zone.ToString() + "_" +  Line.ToString();
        //            jGridView.SQL = @"SELECT 1 Code

        //	                            ,az.Name ZoneName
        //	                            ,ab.LastLineNumber
        //                                ,ab.[BusNumber]
        //                                ,abst.[StationCode]
        //	                            ,ast.Name StationName
        //	                            ,abst.[COUNT] TicketCount
        //                                ,cast(dbo.DateEnToFa(abst.date) as varchar) EventDate
        //                            from AUTBusStationTicketCount abst
        //                            left join AUTStation ast on ast.Code = abst.StationCode
        //                            left join AUTBus ab on ab.BUSNumber = abst.BusNumber
        //                            left join AUTLine al on al.LineNumber = ab.LastLineNumber
        //                            left join AUTZone az on al.ZoneCode = az.Code

        //where " + WhereStr;
        //            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
        //            jGridView.PageSize = 50;
        //            jGridView.HiddenColumns = "Code";
        //            jGridView.Title = "JNumOfPerformanceDayReportControl";
        //            jGridView.PageOrderByField = " EventDate asc";
        //            jGridView.Buttons = "excel,print,record_print";

        //            jGridView.Bind();
        //        }


        public void GetReport(DateTime? StartEventDate = null, DateTime? EndEventDate = null, int DriverCode = 0, int BusNumebr = 0, int LineCode = 0, int ZoneCode = 0, int CountTransaction = 0, int total = 0)
        {
            string WhereStr = "";
            //string WhereStr2 = ""; string WhereStr3 = "";

            if (BusNumebr > 0)
                WhereStr += " and shift.BusNumber = " + BusNumebr;
            if (total > 0)
                WhereStr += " and SUM(isnull(busservice.NumOfService,0)) as total = " + total;
            if (DriverCode > 0)
                WhereStr += " and PCode = " + DriverCode;
            if (LineCode > 0)
                WhereStr += " and line.Code = " + LineCode;
            if (ZoneCode > 0)
                WhereStr += " and zone.Code = " + ZoneCode;
            if (StartEventDate.HasValue && EndEventDate.HasValue)
            {
                WhereStr += " and shift.date between '" + StartEventDate.Value.ToShortDateString() + "' and '" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + "'";
            }
            //WhereStr2 += " and busservice.date between '" + StartEventDate.Value.ToShortDateString() + " 00:00:00' and '" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + " 23:59:59'";


            //WhereStr3 += " and ticket.eventdate between '" + StartEventDate.Value.ToShortDateString() + " 00:00:00' and '" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + " 23:59:59'";


            //DateTime startdate;
            //DateTime enddate;
            //DateTime remaindate;

            //startdate = DateTime.Parse(txtFromDate.ToString()).Date;
            //enddate = DateTime.Parse(txtToDate.ToString()).Date;

            //remaindate = Convert.ToDateTime(startdate - enddate);




            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusManagement_FormsReports_JNumOfPerformanceDayReportControl");
            jGridView.ClassName = "WebBusManagement_FormsReports_JNumOfPerformanceDayReportControl_" + BusNumebr.ToString() + "_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") +  "_" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "")
                + ZoneCode.ToString() + "_" + LineCode.ToString()+"_"+DriverCode.ToString()+"_"+CountTransaction.ToString()+"_"+total.ToString();

            jGridView.SQL = @"
                    select a.BusNumber Code,DriverName Name,Count(*)NumOfDay
					,(select Count(*) from (select Date from AutBusServices shift where Deleted=0 and BusNumber=a.BusNumber " + WhereStr + @" group by Date  having count(*) >= 1) as a)NumOfDayService
                    ,BusNumber,sum(NumOfTransaction)/count(*)AvgTransactions ,sum(NumOfService)NumOfService
									from (
                    select max(shift.Code)Code,shift.BusNumber,cast(shift.startdate as date)Date,person.Name as	DriverName,sum(shift.TCount) as NumOfTransaction
					,SUM(isnull(busservice.NumOfService,1)) as NumOfService
                               
                    from AUTShiftDriver shift
					left join AUTBus bus on bus.BUSNumber = shift.BusNumber
					left join AUTBusOwner owners on owners.BusCode = bus.Code
					left join clsAllPerson person on  person.Code = owners.CodePerson
					left join AUTLine line on line.LineNumber =  shift.LineNumber 
					left join AUTZone zone on zone.Code = ZoneCode 
					left join AutBusServices  busservice on busservice.BusNumber = bus.BUSNumber 
					and busservice.FirstStationDate between shift.StartDate and shift.EndDate
                        where isnull(busservice.deleted, 0) = 0  " + WhereStr + @"
                    group by shift.BusNumber,cast(shift.startdate as date),person.Name
					)a
                    group by a.BusNumber,DriverName
				   ";

            WebClassLibrary.SessionManager.Current.Session["JNumOfPerformanceDayReportControl"] = WhereStr;

            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JNumOfPerformanceDayReportControl";
            jGridView.PageOrderByField = " BusNumber asc";
            jGridView.Buttons = "excel,print,record_print";

            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("Report", "Report", new JActionsInfo("Click", JDomains.JActionEvents.GridItemClick, "WebBusManagement.FormsReports.JNumOfPerformanceDayReportControl._NumOfPerformanceDayReportControl", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, "WebBusManagement.FormsReports.JNumOfPerformanceDayReportControl._NumOfPerformanceDayReportControl", null, null));

            jGridView.Bind();
        }


        public string _NumOfPerformanceDayReportControl(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("HokmeKar"
                  , "~/WebBusManagement/FormsReports/JNumOfPerformanceDayDetailsReportControl.ascx"
                  , "گزارش ریز کارکرد اتوبوس"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 570);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            InitialReport = false;
            try
            {
                if (cmbBus.SelectedValue == "0")
                {
                    GetReport(((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                     ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(),
                         ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode, 0,  Convert.ToInt32(cmbLine.SelectedValue)
                        , Convert.ToInt32(cmbZone.SelectedValue)
                   );
                }
                else
                {
                    GetReport(((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                    ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(),
                       ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode,
                       Convert.ToInt32(cmbBus.SelectedItem.Text),  Convert.ToInt32(cmbLine.SelectedValue)
                        , Convert.ToInt32(cmbZone.SelectedValue)
                    );
                }
                //if (cmbBus.SelectedValue == "0")
                //{
                //    GetReport(0, ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                //    ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
                //}
                //else
                //{
                //    GetReport(Convert.ToInt32(cmbBus.SelectedItem.Text), ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                //    ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
                //}

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