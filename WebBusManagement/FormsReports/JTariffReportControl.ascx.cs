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
    public partial class JTariffReportControl : System.Web.UI.UserControl
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
                LoadZones();
                LoadLines();
                //GetReport();
                btnSave_Click(null, null);
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

        public void GetReport(int BusNumebr = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int DriverCode = 0, int LineCode = 0, int ZoneCode = 0, int Status = 2, int FaultCode = 2)//
        {
            string WhereStr = "";
            if (BusNumebr > 0)
                WhereStr += " and AUTBus.BUSNumber = " + BusNumebr;
            if (DriverCode > 0)
                WhereStr += " and AUTTariff.DriverCode = " + DriverCode;
            if (LineCode > 0)
                WhereStr += " and AUTLine.Code = " + LineCode;
            if (ZoneCode > 0)
                WhereStr += " and AUTZone.Code = " + ZoneCode;
            if (Status < 2)
                WhereStr += " and AUTTariff.Status = " + Status;
            if (FaultCode == 0)
                WhereStr += " and isnull(srvs.NumOfFaultyServices, 0) > 0";
            else if (FaultCode == 1)
                WhereStr += " and isnull(srvs.NumOfFaultyServices, 0) = 0";
            //if (StartEventDate.HasValue && EndEventDate.HasValue)
            WhereStr += " and AUTTariff.Date between '{0}' and '{1}'";
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;//new WebControllers.MainControls.Grid.JGridView("WebBusManagement_FormsReports_JTariffReportControl");
            jGridView.ClassName = "WebBusManagement_FormsReports_JTariffReportControl_" + BusNumebr.ToString() + "_" + DriverCode.ToString() + "_" + LineCode.ToString() + "_" + ZoneCode.ToString() + "_" + Status.ToString() + "_" + FaultCode.ToString();
            jGridView.SQL = @"
                IF OBJECT_ID('tempdb..#TempServiceLast') IS NOT NULL DROP Table #TempServiceLast
                IF OBJECT_ID('tempdb..#TempService') IS NOT NULL DROP Table #TempService
                Declare @Period int = 5
                Declare @Date DateTime = '{0}'
                WHILE(@Date <= '{1}')
                BEGIN
	                IF OBJECT_ID('tempdb..#Temp') IS NOT NULL DROP Table #Temp

                    select code, min(StartWork) StartWork, max(EndWork) EndWork
	                ,sum(NumOfServices) NumOfServices
	                ,sum(NumOfFaultyServices) NumOfFaultyServices
	                ,sum(WrongDriver) WrongDriver
	                ,BusNumber,Date
                    into #Temp
	                from
	                (
		                SELECT t.Code,
			                CAST(MIN(bs.FirstStationDate) AS TIME)StartWork
			                ,CAST(MAX(bs.LastStationDate) AS TIME)EndWork
			                ,sum(bs.NumOfService) NumOfServices 
			                ,case when (isnull(bs.IsOk, 1) = 0 and isnull(bs.EzamBeCode, 0) = 0) then sum(bs.NumOfService) else 0 end NumOfFaultyServices 
			                ,case when isnull(bs.DriverPersonCode, 0) != t.DriverCode then sum(bs.NumOfService) else 0 end WrongDriver
			                ,bs.BusNumber
			                ,bs.Date
			                ,bs.DriverPersonCode
		                FROM AutBusServices bs 
		                INNER JOIN AUTTariff t ON t.date = bs.Date AND CAST(bs.FirstStationDate AS TIME) BETWEEN t.StartTime AND t.EndTime
		                INNER JOIN AUTBus b ON b.Code = t.BusCode AND b.BUSNumber = bs.BusNumber
                        where isnull(bs.Deleted, 0) = 0
			                and (((isnull(bs.EzamBeCode, 0) > 0 and bs.ISOK <> 11) or not exists(select * from AutTarrifEzamBe where TarrifCode = t.Code and bs.FirstStationDate < FinishTime and bs.LastStationDate > StartTime)))
		                GROUP BY t.Code,bs.BusNumber,bs.Date,bs.DriverPersonCode,t.DriverCode, bs.IsOk, bs.EzamBeCode
	                )tbl
                    WHERE Date between @Date and DATEADD(DAY,@Period,@Date) and Date <= '{1}'
	                GROUP BY Code,BusNumber,Date

	                IF OBJECT_ID('tempdb..#TempService') IS NOT NULL insert into #TempService select * from #Temp
	                else select * into #TempService  from #Temp

                    SET @Date = DATEADD(DAY,@Period + 1,@Date)
                END

	                IF OBJECT_ID('tempdb..#Temp') IS NOT NULL DROP Table #Temp

                select code, min(StartWork) StartWork, max(EndWork) EndWork
	            ,sum(NumOfServices) NumOfServices
	            ,sum(NumOfFaultyServices) NumOfFaultyServices
	            ,sum(WrongDriver) WrongDriver
	            ,BusNumber,Date
                into #TempServiceLast
	            from #TempService
				GROUP BY Code,BusNumber,Date

                IF OBJECT_ID('tempdb..#TempService') IS NOT NULL DROP Table #TempService

                <#PreviusSQL#>
                Select
                AUTTariff.Code,AUTTariff.Code TarrifCode, clsAllPerson.Name DriverName,e.PersonNumber, AUTLine.LineNumber
                , isnull(srvs.NumOfServices, 0) NumOfService, isnull(srvs.NumOfFaultyServices, 0) FaultyService
                ,(select Name from subdefine where Code=FaliyatCode) Faliyat
				, ISNULL(WrongDriver, 0) WrongDriver
                ,AUTBus .BUSNumber , AUTShift .Title Shift
                ,(select Name from subdefine where bcode = 9101053 and Code=DriverWorkStatus) DriverWorkStatus
                ,AUTTariff.DriverCode DriverPersonCode
                , dbo.DateEnToFa(AUTTariff.Date) Date
                ,AUTTariff.StartTime
                ,AUTTariff.EndTime
                ,srvs.StartWork
                ,srvs.EndWork
                from AUTTariff 
	                left join clsAllPerson on  AUTTariff.DriverCode = clsAllPerson.Code 
	                left join AUTLine  on  AUTLine.Code  = AUTTariff.LineCode 
	                left join AUTBus   on  AUTBus.Code  = AUTTariff.BusCode 
	                left join AUTShift    on  AUTShift.Code  = AUTTariff.ShiftCode
	                left join AUTZone    on  AUTZone.Code  = AUTLine.ZoneCode 
	                left join EmpEmployee e on e.pCode = AUTTariff.DriverCode
	                left JOIN #TempServiceLast srvs ON srvs.Code = AUTTariff.Code
                    where 1 = 1 " + WhereStr;
            jGridView.Parameters = new object[] { StartEventDate.Value.ToString("yyyy-MM-dd") + " 00:00:00", EndEventDate.Value.ToString("yyyy-MM-dd") + " 23:59:59" };
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 10;
            jGridView.Title = "JTariffReportControl";
            jGridView.PageOrderByField = " TarrifCode Desc";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JTariffReportControl._TariffNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JTariffReportControl._TariffUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("EzamBe", "EzamBe", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JTariffReportControl._EzamBeUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("DriversNew", "DriversNew", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JTariffReportControl._DriversNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("TarrifHokmeKar", "TarrifHokmeKar", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JTariffReportControl._TarrifHokmeKar", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("TarrifEmptyPrint", "TarrifEmptyPrint", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JTariffReportControl._TarrifEmptyPrint", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
           // jGridView.Toolbar.AddButton("BusEventRegister", "BusEventRegister", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JTariffReportControl._TarrifEmptyPrint" + "._BusEventRegisterNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));

            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("NumOfService", 0);
            jGridView.SumFields.Add("FaultyService", 0);
            jGridView.SumFields.Add("WrongDriver", 0);
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, "WebBusManagement.FormsReports.JTariffReportControl._TariffUpdate", null, null));
            jGridView.Buttons = "excel,print,record_print,refresh";

            //
            jGridView.Bind();
        }
        public string _BusEventRegisterNew()
        {
            return _BusEventRegisterNew(null);
        }
        public string _BusEventRegisterNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusEventRegister"
                  , "~/WebBusManagement/FormsManagement/JBusEventRegisterUpdateControl.ascx"
                  , "ثبت وقایع"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 800, 650);
        }

        //_TarrifEmptyPrint
        public string _TarrifEmptyPrint()
        {
            return _TarrifEmptyPrint(null);
        }
        public string _TarrifEmptyPrint(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("TarrifEmptyPrint"
                 , "~/WebBusManagement/FormsManagement/JTarrifEmptyPrintUpdateControl.ascx"
                 , "ثبت تعرفه خام"
                 , null
                 , WindowTarget.NewWindow
                 , true, false, true, 600, 300);
        }

        public string _TarrifHokmeKar()
        {
            return _TarrifHokmeKar(null);
        }
        public string _TarrifHokmeKar(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("TarrifHokmeKar"
                 , "~/WebBusManagement/FormsManagement/JTarrifHokmeKarUpdateControl.ascx"
                 , "ثبت تعرفه بر اساس حکم کار"
                 , null
                 , WindowTarget.NewWindow
                 , true, false, true, 500, 400);
        }

        public string _DriversNew()
        {
            return _DriversNew(null);
        }
        public string _DriversNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Drivers"
                  , "~/WebBusManagement/FormsManagement/JDriversUpdateControl.ascx"
                  , "رانندگان"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 700, 450);
        }
        public string _EzamBeUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("EzamBe"
                  , "~/WebBusManagement/FormsManagement/JEzamBeUpdateControl.ascx"
                  , "اعزام به"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 700, 450);
        }

        public string _TariffNew()
        {
            return _TariffNew(null);
        }
        public string _TariffNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Tariff"
                 , "~/WebBusManagement/FormsManagement/JTariffUpdateControl.ascx"
                 , "تعرفه"
                 , null
                 , WindowTarget.NewWindow
                  , true, false, true, 700, 450);
        }
        public string _TariffUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Tariff"
                  , "~/WebBusManagement/FormsManagement/JTariffUpdateControl.ascx"
                  , "تعرفه"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 700, 450);
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
                        ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode, Convert.ToInt32(cmbLine.SelectedValue)
                        , Convert.ToInt32(cmbZone.SelectedValue), Convert.ToInt32(rblStatus.SelectedValue)
                        , Convert.ToInt32(rblShowFaulty.SelectedValue));
                }
                else
                {
                    GetReport(Convert.ToInt32(cmbBus.SelectedItem.Text), ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                            ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(),
                            ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode, Convert.ToInt32(cmbLine.SelectedValue)
                        , Convert.ToInt32(cmbZone.SelectedValue), Convert.ToInt32(rblStatus.SelectedValue)
                        , Convert.ToInt32(rblShowFaulty.SelectedValue));
                }
            }
            catch { }
        }

    }

}