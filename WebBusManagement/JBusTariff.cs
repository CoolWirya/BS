using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace WebBusManagement
{
    public class JBusTariff
    {
        public const string _ConstClassName = "WebBusManagement.JBusTariff";
        // Main Method
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();

            nodes.Add(new JNode(null, "BaseDefine", _ConstClassName, JDomains.Images.MenuImages.Folder, new List<JNode> 
            {
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Lines", null, new List<object>() { }) }, "Lines", _ConstClassName + "._Lines", JDomains.Images.MenuImages.BusManagmentBusLine, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Drivers", null, new List<object>() { }) }, "Drivers", _ConstClassName + "._Drivers", JDomains.Images.MenuImages.BusManagmentTarrif, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._HokmeKarReport", null, new List<object>() { }) }, "HokmeKar", _ConstClassName + "._HokmeKarReport", JDomains.Images.MenuImages.BusManagmentTarrif, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TariffHokmeKarBaseDefine", null, new List<object>() { }) }, "TariffHokmeKarBaseDefine", _ConstClassName + "._TariffHokmeKarBaseDefine", JDomains.Images.MenuImages.BusManagmentTarrif, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusEvent", null, new List<object>() { }) }, "BusEvent", _ConstClassName + "._BusEvent", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ActivityandEventPairing", null, new List<object>() { }) }, "ActivityandEventPairing", _ConstClassName + "._ActivityandEventPairing", JDomains.Images.MenuImages.BusManagmentBusLine, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusEventDetailes", null, new List<object>() { }) }, "BusEventDetailes", _ConstClassName + "._BusEventDetailes", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusEventPlace", null, new List<object>() { }) }, "BusEventPlace", _ConstClassName + "._BusEventPlace", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusEventRegister", null, new List<object>() { }) }, "BusEventRegister", _ConstClassName + "._BusEventRegister", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Shifts", null, new List<object>() { }) }, "Shifts", _ConstClassName + "._Shifts", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._EzamBeType", null, new List<object>() { }) }, "EzamBeType", _ConstClassName + "._EzamBeType", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._FaliyatType", null, new List<object>() { }) }, "FaliyatType", _ConstClassName + "._FaliyatType", JDomains.Images.MenuImages.BusManagmentReport, null),
                
            }));

            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TariffReport", null, new List<object>() { }) }, "Tariff", _ConstClassName + "._TariffReport", JDomains.Images.MenuImages.BusManagmentTarrif, null));

            nodes.Add(new JNode(null, "Reports", _ConstClassName, JDomains.Images.MenuImages.Folder, new List<JNode> 
            {
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TarrifCalenderReport", null, new List<object>() { }) }, "TarrifCalenderReport", _ConstClassName + "._TarrifCalenderReport", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DriversLoginLogoutReport", null, new List<object>() { }) }, "DriversLoginLogoutReport", _ConstClassName + "._DriversLoginLogoutReport", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusServiceReport", null, new List<object>() { }) }, "BusServiceReport", _ConstClassName + "._BusServiceReport", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusServiceWithoutTransactionReport", null, new List<object>() { }) }, "BusServiceWithoutTransactionReport", _ConstClassName + "._BusServiceWithoutTransactionReport", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusPerformanceYearlyReport", null, new List<object>() { }) }, "BusPerformanceYearlyReport", _ConstClassName + "._BusPerformanceYearlyReport", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ComparativeServiceReport", null, new List<object>() { }) }, "ComparativeServiceReport", _ConstClassName + "._ComparativeServiceReport", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusLineStationPosition", null, new List<object>() { }) }, "BusLineStationPosition", _ConstClassName + "._BusLineStationPosition", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusWorkSheetReport", null, new List<object>() { }) }, "BusWorkSheetReport", _ConstClassName + "._BusWorkSheetReport", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DriverKarkardTariffSheetReport", null, new List<object>() { }) }, "DriverKarkardTariffSheetReport", _ConstClassName + "._DriverKarkardTariffSheetReport", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ServicingStatusReport", null, new List<object>() { }) }, "ServicingStatusReport", _ConstClassName + "._ServicingStatusReport", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._HolidaysReport", null, new List<object>() { }) }, "HolidaysReport", _ConstClassName + "._HolidaysReport", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._EzamBeReport", null, new List<object>() { }) }, "EzamBeReport", _ConstClassName + "._EzamBeReport", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BazrasServiceReportControl", null, new List<object>() { }) }, "BazrasServiceReport", _ConstClassName + "._BazrasServiceReportControl", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ServiceTurnReport", null, new List<object>() { }) }, "ServiceTurnReport", _ConstClassName + "._ServiceTurnReport", JDomains.Images.MenuImages.BusManagmentReport, null),
                
                //new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._UndefinedDriversBusReport", null, new List<object>() { }) }, "UndefinedDriversBusReport", _ConstClassName + "._UndefinedDriversBusReport", JDomains.Images.MenuImages.BusManagmentReport, null),
                //new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusTransactionLower", null, new List<object>() { }) }, "BusTransactionLower", _ConstClassName + "._BusTransactionLower", JDomains.Images.MenuImages.BusManagmentReport, null),
                //new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DriverMonthlyKarkardReport", null, new List<object>() { }) }, "DriverMonthlyKarkardReport", _ConstClassName + "._DriverMonthlyKarkardReport", JDomains.Images.MenuImages.BusManagmentReport, null),
                //new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OvertimeTariffReport", null, new List<object>() { }) }, "OvertimeTariffReport", _ConstClassName + "._OvertimeTariffReport", JDomains.Images.MenuImages.BusManagmentReport, null),
                //new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusDontLoginReport", null, new List<object>() { }) }, "BusDontLoginReport", _ConstClassName + "._BusDontLoginReport", JDomains.Images.MenuImages.BusManagmentTarrif, null),
            }));

            nodes.Add(new JNode(null, "ReportStation", _ConstClassName, JDomains.Images.MenuImages.Folder, new List<JNode> 
            {
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusPassingStationReport", null, new List<object>() { }) }, "BusPassingStationReport", _ConstClassName + "._BusPassingStationReport", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusPassingStationTicketReport", null, new List<object>() { }) }, "BusPassingStationTicketReport", _ConstClassName + "._BusPassingStationTicketReport", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._StationPassCalender", null, new List<object>() { }) }, "StationPassCalender", _ConstClassName + "._StationPassCalender", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._StationTicketCount", null, new List<object>() { }) }, "StationTicketCount", _ConstClassName + "._StationTicketCount", JDomains.Images.MenuImages.BusManagmentReport, null),
            }));

            nodes.Add(new JNode(null, "FailReports", _ConstClassName, JDomains.Images.MenuImages.Folder, new List<JNode> 
            {
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusNotWorkInHokmeKarReport", null, new List<object>() { }) }, "BusNotWorkInHokmeKarReport", _ConstClassName + "._BusNotWorkInHokmeKarReport", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusHokmeKarTarrifDif", null, new List<object>() { }) }, "BusHokmeKarTarrifDif", _ConstClassName + "._BusHokmeKarTarrifDif", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JTariffServiceConflictReport", null, new List<object>() { }) }, "TariffServiceConflictReport", _ConstClassName + "._TariffServiceConflictReport", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusTimeStopsAtTheStations", null, new List<object>() { }) }, "BusTimeStopsAtTheStations", _ConstClassName + "._BusTimeStopsAtTheStations", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DriverInfraction", null, new List<object>() { }) }, "DriverInfraction", _ConstClassName + "._DriverInfraction", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._StationAndPathConflictReport", null, new List<object>() { }) }, "StationAndPathConflictReport", _ConstClassName + "._StationAndPathConflictReport", JDomains.Images.MenuImages.BusManagmentReport, null),
            }));

            return nodes;
        }

        public string _ServiceTurnReport()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_ServiceTurnReport";
            jGridView.SQL = @"select Code, BusNumber, FromDate, ToDate
                , case FirstDay when 0 then null else FirstDay end FirstDay, case SecondDay when 0 then null else SecondDay end SecondDay from dbo.AUTBusServiceTurn";
            jGridView.Title = "ServiceTurnReport";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ServiceTurnNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ServiceTurnUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._ServiceTurnUpdate", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }
        public string _ServiceTurnNew(string code)
        {
            return _ServiceTurnNew();
        }
        public string _ServiceTurnNew()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("ServiceTurnUpdate"
                 , "~/WebBusManagement/FormsManagement/JServiceTurnUpdateControl.ascx"
                 , "نوبت سرویس"
                 , null
                 , WindowTarget.NewWindow
                 , true, false, true, 450, 350);
        }
        public string _ServiceTurnUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("ServiceTurnUpdate"
                 , "~/WebBusManagement/FormsManagement/JServiceTurnUpdateControl.ascx"
                 , "نوبت سرویس"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                 , WindowTarget.NewWindow
                 , true, false, true, 450, 350);
        }

        public string _ComparativeServiceReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("ComparativeServiceReport"
                  , "~/WebBusManagement/FormsReports/JComparativeServiceReportControl.ascx"
                  , "گزارش مقایسه ای سرویس ها"
                  , null
                  , WindowTarget.NewWindow
                  , false, true, true, 0, 0, true);
        }

        public string _StationAndPathConflictReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("StationAndPathConflictReport"
                  , "~/WebBusManagement/FormsReports/JStationAndPathConflictReportControl.ascx"
                  , "گزارش مغایرت اطلاعات ایستگاه و مسیر"
                  , null
                  , WindowTarget.NewWindow
                  , false, true, true, 0, 0, true);
        }

        public string _DriverInfraction()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("DriverInfraction"
                  , "~/WebBusManagement/FormsReports/JDriverInfractionReportControl.ascx"
                  , "گزارش تخلفات راننده"
                  , null
                  , WindowTarget.NewWindow
                  , false, true, true, 0, 0, true);
        }

        public string _FaliyatType()
        {
            return JWebManager.GenerateClientWindow(WebControllers.MainControls.Grid.JSubDefine.GetSubDefineGrid(9101054, "FaliyatType").GenerateWindow(false, false, false), true);
        }

        public string _EzamBeType()
        {
            return JWebManager.GenerateClientWindow(WebControllers.MainControls.Grid.JSubDefine.GetSubDefineGrid(9101058, "EzamBeType").GenerateWindow(false, false, false), true);
        }

        //_EzamBeReport
        public string _EzamBeReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("TariffReport"
                                , "~/WebBusManagement/FormsReports/JEzamBeReportControl.ascx"
                                , "گزارش اعزام به"
                                , null
                                , WindowTarget.NewWindow
                                , false, true, true, 0, 0, true);
        }

        public string _BazrasServiceReportControl()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BazrasServiceReport"
                                , "~/WebBusManagement/FormsReports/JBazrasServiceReportControl.ascx"
                                , "گزارش سرویس بازرس"
                                , null
                                , WindowTarget.NewWindow
                                , false, true, true, 0, 0, true);
        }

        //_Holidays
        public string _HolidaysReport()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_Holidays";
            jGridView.SQL = @"SELECT [Code]
                              ,dbo.DateEnToFa([Date]) Date
                              ,[Description]
                              ,case [HoliDaysType] when 1 then N'جمعه' else N'تعطیل رسمی' end Type
                              ,case [DateType] when 1 then N'شمسی' else N'قمری' end 'شمسی/قمری'
                          FROM [dbo].[AUTHolidays]";
            jGridView.Title = "HolidaysReport";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._HolidaysNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._HolidaysUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("CopyHolidaysToNextYear", "انتقال به سال جدید", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._CopyHolidaysToNextYear", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._HolidaysUpdate", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
        }
        public string _CopyHolidaysToNextYear()
        {
            return _CopyHolidaysToNextYear(null);
        }
        public string _CopyHolidaysToNextYear(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Holidays"
                  , "~/WebBusManagement/FormsManagement/JCopyHolidaysToNextYearUpdateControl.ascx"
                  , "انتقال روزهای تعطیل به سال جدید"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 650, 300);
        }

        public string _HolidaysNew()
        {
            return _HolidaysNew(null);
        }
        public string _HolidaysNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Holidays"
                  , "~/WebBusManagement/FormsManagement/JHolidaysUpdateControl.ascx"
                  , "تعریف روزهای تعطیل"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 700, 400);
        }
        public string _HolidaysUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Holidays"
                  , "~/WebBusManagement/FormsManagement/JHolidaysUpdateControl.ascx"
                  , "تعریف روزهای تعطیل"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 700, 400);
        }

        public string _JTariffServiceConflictReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("TariffServiceConflictReport"
                , "~/WebBusManagement/FormsReports/JTariffServiceConflictReportControl.ascx"
                , "گزارش مغایرت سرویس و تعرفه"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }
        public string _OvertimeTariffReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OvertimeTariffReport"
                , "~/WebBusManagement/FormsReports/JOvertimeTariffReportControl.ascx"
                , "گزارش تعرفه اضافه کاری"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }
        public string _DriverMonthlyKarkardReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("DriverMonthlyKarkardReport"
                , "~/WebBusManagement/FormsReports/JDriverMonthlyKarkardReportControl.ascx"
                , "کارکرد ماهانه رانندگان به حقوق و دستمزد"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }
        public string _ServicingStatusReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("ServicingStatusReport"
                , "~/WebBusManagement/FormsReports/JServicingStatusReportControl.ascx"
                , "گزارش وضعیت سرویس دهی"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }
        public string _DriverKarkardTariffSheetReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("DriverKarkardTariffSheet"
                , "~/WebBusManagement/FormsReports/JDriverKarkardTariffSheetReportControl.ascx"
                , "گزارش شناسنامه تعرفه کارکرد رانندگان"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }
        public string _BusWorkSheetReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusWorkSheet"
                , "~/WebBusManagement/FormsReports/JBusWorkSheetReportControl.ascx"
                , "گزارش شناسنامه کاری اتوبوس"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }
        //_BusEventRegister
        public string _BusEventRegister()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_BusEventRegister";
            jGridView.SQL = @"SELECT a.[Code]
	                              ,ab.BUSNumber
                                  ,cap.Name DriverName
                                  ,[BusEventDetailesCode]
	                              ,b.Name BusEventDetailesName
                                  ,[StartDate]
                                  ,[EndDate]
                                  ,SUBSTRING(CONVERT(VARCHAR,[StartTime],20),0,9)[StartTime]
								  ,SUBSTRING(CONVERT(VARCHAR,[EndTime],20),0,9)[EndTime]
                                  ,case [Status] when 1 then N'تایید شده' else N'عدم تایید' end as Status
                                  ,a.[InsertDate]
                              FROM [dbo].[AUTBusEventRegister] a
                              left join [dbo].[AUTBusEventDetailes] b
                              on a.[BusEventDetailesCode] = b.[Code]
                              left join AUTBus ab on a.BusCode = ab.Code
                              left join clsAllPerson cap on cap.Code = a.[DriverPCode]
                              where a.BusEventDetailesCode < 10000";
            jGridView.PageOrderByField = " Code desc";
            jGridView.Title = "BusEventRegister";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusEventRegisterNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusEventRegisterUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("ApplyBusEventRegister", "ApplyBusEventRegister", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusEventRegisterDocumentsApply", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._BusEventRegisterUpdate", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _BusEventRegisterDocumentsApply(string code)
        {
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            string UpdateQuery = "";
            UpdateQuery = @"update AUTBusEventRegister set Status = 1 where Code = " + code;
            Db.setQuery(UpdateQuery);
            if (Db.Query_Execute() >= 0)
            {
                //return WebClassLibrary.JWebManager.LoadClientControl("AccDocumentsGetDetail"
                //  , "~/WebBusManagement/FormsManagement/JDeleteApplyControl.ascx"
                //  , "تایید سند"
                //  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                //  , WindowTarget.NewWindow
                //  , true, true, true, 500, 200);
                // WebClassLibrary.JWebManager.RunClientScript("alert('تایید واقعه با موفقیت انجام شد');", "ConfirmDialog");
                //return "";
                return WebClassLibrary.JWebManager.LoadClientControl("AccDocumentsGetDetail"
                  , "~/WebBusManagement/FormsManagement/JDeleteApplyControl.ascx"
                  , "تایید واقعه"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, true, true, 500, 200);
            }
            else
                return "";
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
        public string _BusEventRegisterUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusEventRegister"
                  , "~/WebBusManagement/FormsManagement/JBusEventRegisterUpdateControl.ascx"
                  , "ثبت وقایع"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 800, 650);
        }


        //_TariffHokmeKarBaseDefine
        public string _TariffHokmeKarBaseDefine()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_TariffHokmeKarBaseDefine";
            jGridView.SQL = BusManagment.WorkOrder.JTarrfiHokmeKarBaseDefines.GetWebQuery();
            jGridView.Title = "TariffHokmeKarBaseDefine";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TariffHokmeKarBaseDefineNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TariffHokmeKarBaseDefineUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._TariffHokmeKarBaseDefineUpdate", null, null));
            jGridView.PageOrderByField = " [Code] desc";
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _TariffHokmeKarBaseDefineNew()
        {
            return _TariffHokmeKarBaseDefineNew(null);
        }
        public string _TariffHokmeKarBaseDefineNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("TariffHokmeKarBaseDefine"
                  , "~/WebBusManagement/FormsManagement/JTariffHokmeKarBaseDefineUpdateControl.ascx"
                  , "تعاریف پایه تعرفه بر اساس حکم کار"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 700, 450);
        }
        public string _TariffHokmeKarBaseDefineUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("TariffHokmeKarBaseDefine"
                  , "~/WebBusManagement/FormsManagement/JTariffHokmeKarBaseDefineUpdateControl.ascx"
                  , "تعاریف پایه تعرفه بر اساس حکم کار"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 700, 450);
        }


        //_BusEventPlace
        public string _BusEventPlace()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_BusEventPlace";
            jGridView.SQL = @"SELECT a.[Code]
                                      ,a.[Name]
                                      ,[BusEventDetailesCode]
	                                  ,b.Name BusEventDetailesName
                                      ,[Longitude]
                                      ,[Latitude]
                                      ,a.[InsertDate]
                                      ,Radius
                                  FROM [dbo].[AUTBusEventPlace] a
                                  left join [dbo].[AUTBusEventDetailes] b
                                  on a.[BusEventDetailesCode] = b.[Code]";
            jGridView.Title = "BusEventPlace";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusEventPlaceNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusEventPlaceUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._BusEventPlaceUpdate", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _BusEventPlaceNew()
        {
            return _BusEventPlaceNew(null);
        }
        public string _BusEventPlaceNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusEventPlace"
                  , "~/WebBusManagement/FormsManagement/JBusEventPlaceUpdateControl.ascx"
                  , "مکان های وقایع"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 900, 450);
        }
        public string _BusEventPlaceUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusEventPlace"
                  , "~/WebBusManagement/FormsManagement/JBusEventPlaceUpdateControl.ascx"
                  , "مکان های وقایع"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 900, 450);
        }

        //_BusEventDetailes
        public string _BusEventDetailes()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_BusEventDetailes";
            jGridView.SQL = @"SELECT a.[Code]
                                  ,a.[Name]
                                  ,[BusEventCode]
	                              ,b.Name ParentEventName
                                  ,a.[InsertDate]
                              FROM [dbo].[AUTBusEventDetailes] a
                              left join [dbo].[AUTBusEvent] b
                              on a.[BusEventCode] = b.Code";
            jGridView.Title = "BusEventDetailes";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusEventDetailesNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusEventDetailesUpdate2", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            //jGridView.Toolbar.AddButton("InsertEventDetailes", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusEventDetailesUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._BusEventDetailesUpdate2", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _BusEventDetailesNew()
        {
            return _BusEventDetailesNew(null);
        }
        public string _BusEventDetailesNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusEventDetailes"
                  , "~/WebBusManagement/FormsManagement/JBusEventDetailesUpdateControl.ascx"
                  , "جزئیات وقایع"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 700, 450);
        }
        public string _BusEventDetailesUpdate2(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusEventDetailes"
                  , "~/WebBusManagement/FormsManagement/JBusEventDetailesUpdateControl.ascx"
                  , "جزئیات وقایع"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 700, 450);
        }

        //_BusEvent
        public string _BusEvent()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_BusEvent";
            jGridView.SQL = @"SELECT [Code],[Name],case [BusActive] when 1 then N'فعال' else N'غیر فعال' end as BusActive,case [DriverActive] when 1 then N'فعال' else N'غیر فعال' end as DriverActive,
                              [InsertDate] FROM [dbo].[AUTBusEvent]";
            jGridView.Title = "BusEvent";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusEventNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusEventUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("BusSendEvent", "BusSendEvent", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusSendEvent", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._BusEventUpdate", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _BusEventNew()
        {
            return _BusEventNew(null);
        }
        public string _BusEventNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusEvent"
                  , "~/WebBusManagement/FormsManagement/JBusEventUpdateControl.ascx"
                  , "وقایع"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 700, 450);
        }
        public string _BusEventUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusEvent"
                  , "~/WebBusManagement/FormsManagement/JBusEventUpdateControl.ascx"
                  , "وقایع"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 700, 450);
        }

        public string _BusEventDetailesUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusEventDetailes"
                  , "~/WebBusManagement/FormsManagement/JBusEventDetailesUpdateControl.ascx"
                  , "جزئیات وقایع"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 700, 450);
        }
        public string _BusSendEvent()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusSendEvent"
                  , "~/WebBusManagement/FormsManagement/JBusSendEventUpdateControl.ascx"
                  , "ارسال واقعه"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 700, 450);
        }
        public string _BusSendEvent(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusSendEvent"
                  , "~/WebBusManagement/FormsManagement/JBusSendEventUpdateControl.ascx"
                  , "ارسال واقعه"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 700, 450);
        }

        public string _Shifts()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_Shifts";
            jGridView.SQL = BusManagment.Shift.JShifts.GetWebQuery();
            jGridView.Title = "Shifts";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ShiftsNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ShiftsUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._ShiftsUpdate", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
        }
        public string _ActivityandEventPairing()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_ActivityandEventPairing";
            jGridView.SQL = @"  SELECT  a.[Code]
                                       ,b.[name] buseventname
							          ,s.[name] activityname
                                    
                              FROM [dbo].[AUTBusEventActivity] a
                              left join [dbo].[AUTBusEvent] b
                              on a.[Event] = b.[Code]
							  left join [dbo].[subdefine] s
							  on a.[activity]=s.[code]
							  where s.[bcode]='9101054' ";

            jGridView.Title = "ActivityandEventPairing";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ActivityandEventPairingNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ActivityandEventPairingUpdate2", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._ActivityandEventPairingUpdate2", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);

        }
        public string _ActivityandEventPairingNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusEventDetailes"
                  , "~/WebBusManagement/FormsManagement/JActivityandEventPairingControl.ascx"
                  , " مرتبط سازی فعالیت و وقایع"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 700, 450);
        }
        public string _ActivityandEventPairingUpdate2(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusEventDetailes"
                  , "~/WebBusManagement/FormsManagement/JActivityandEventPairingControl.ascx"
                  , "مرتبط سازی فعالیت و وقایع"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 700, 450);
        }
        public string _ShiftsNew()
        {
            return _ShiftsNew(null);
        }
        public string _ShiftsNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Shifts"
                  , "~/WebBusManagement/FormsManagement/JShiftsUpdateControl.ascx"
                  , "شیفت ها"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 700, 450);
        }
        public string _ShiftsUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Shifts"
                  , "~/WebBusManagement/FormsManagement/JShiftsUpdateControl.ascx"
                  , "شیفت ها"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 700, 450);
        }

        //_BusLineStationPosition
        public string _BusLineStationPosition()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusLineStationPosition",
                "~/WebBusManagement/FormsReports/JBusLineStationPositionReportControl.ascx", "گزارش موقعیت اتوبوس ها در خطوط"
                , null, WindowTarget.NewWindow, true, true, true);
        }

        //_TarrifCalenderReport
        public string _TarrifCalenderReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("TarrifCalenderReport",
                "~/WebBusManagement/FormsReports/JTarrifCalenderReportControl.ascx", "تقویم تعرفه"
                , null, WindowTarget.NewWindow, true, true, true);
        }

        //_StationPassCalender
        public string _StationPassCalender()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("StationPassCalender",
                "~/WebBusManagement/FormsReports/JStationPassCalenderReportControl.ascx", "تقویم عبور از ایستگاه اتوبوس ها"
                , null, WindowTarget.NewWindow, true, true, true);
        }

        //_StationPassCalender
        public string _StationTicketCount()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("StationTicketReportControl",
                "~/WebBusManagement/FormsReports/JStationTicketReportControl.ascx", "گزارش تراکم مسافر در ایستگاه"
                , null, WindowTarget.NewWindow, true, false, true, 700, 450);
        }

        //_Drivers
        public string _Drivers()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_Drivers";
            jGridView.SQL = @"SELECT ee.[Code]
                                  ,ee.[pCode]
	                              ,cap.Name DriverName
                                  ,[PersonNumber]
                                  ,[PersonCart]
	                              ,c.RfidNumber
                              FROM [dbo].[EmpEmployee] ee
                              left join clsAllPerson cap
                              on ee.pCode = cap.Code
                              left join Cards c on c.Code = ee.PersonCart";
            jGridView.Title = "Drivers";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DriversNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DriversUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._DriversUpdate", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
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
        public string _DriversUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Drivers"
                  , "~/WebBusManagement/FormsManagement/JDriversUpdateControl.ascx"
                  , "رانندگان"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 700, 450);
        }

        public string _Lines()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_Lines";

            jGridView.SQL = BusManagment.Line.JLines.GetWebQuery();
            jGridView.Title = "Lines";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LinesNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LinesUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("InsertTransactionCount", "InsertTransactionCount", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._InsertTransactionCount", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("LinePath", "LinePath", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LinePath", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("LinePath", "LinePathBack", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LinePathBack", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("LinePath", "LinePathCircular", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LinePathCircular", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._LinesUpdate", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _LinesNew()
        {
            return _LinesNew(null);
        }
        public string _LinesNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Lines"
                  , "~/WebBusManagement/FormsManagement/JLineUpdateControl.ascx"
                  , "خطوط"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 720, 500);
        }
        public string _LinesUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Lines"
                  , "~/WebBusManagement/FormsManagement/JLineUpdateControl.ascx"
                  , "خطوط"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 720, 500);
        }

        public string _InsertTransactionCount(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("InsertTransactionCount"
                , "~/WebBusManagement/FormsManagement/JLineInsertTransactionCountUpdateControl.ascx"
                , "ثبت متوسط تراکنش خط به ازای هر اتوبوس در روز"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 700, 450);
        }

        public string _LinePath(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Lines"
                  , "~/WebBusManagement/FormsManagement/JLinePathUpdateControl.ascx"
                  , "مسیر رفت خط"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code)}
                  , WindowTarget.NewWindow
                  , true, false, true, 700, 450);
        }


        public string _LinePathBack(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("LinePathBack"
                  , "~/WebBusManagement/FormsManagement/JLinePathBackUpdateControl.ascx"
                  , "مسیر برگشت خط"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code)}
                  , WindowTarget.NewWindow
                  , true, false, true, 700, 450);
        }

        //_LinePathCircular
        public string _LinePathCircular(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("LinePathCircular"
                  , "~/WebBusManagement/FormsManagement/JLinePathCircularUpdateControl.ascx"
                  , "مسیر گردشی خط"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code)}
                  , WindowTarget.NewWindow
                  , true, false, true, 700, 450);
        }

        //_BusPassingStationTicketReport
        public string _BusPassingStationTicketReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusPassingStationTicket"
                , "~/WebBusManagement/FormsReports/JBusPassingStationTicketReportControl.ascx"
                , "گزارش تعداد بلیط اتوبوس در هر ایستگاه"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _InsertBusFailure()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_InsertBusFailure";
            jGridView.SQL = BusManagment.JBusFailures.GetWebQuery();
            jGridView.Title = "InsertBusFailure";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._InsertBusFailureNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._InsertBusFailureUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._InsertBusFailureUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);

        }

        public string _InsertBusFailureNew()
        {
            return _InsertBusFailureNew(null);
        }
        public string _InsertBusFailureNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("InsertBusFailure"
                  , "~/WebBusManagement/FormsMaintenance/JInsertBusFailureUpdateControl.ascx"
                  , "ثبت دلیل عدم فعالیت اتوبوس ها"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 450);
        }
        public string _InsertBusFailureUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("InsertBusFailure"
                  , "~/WebBusManagement/FormsMaintenance/JInsertBusFailureUpdateControl.ascx"
                  , "ویرایش دلیل عدم فعالیت اتوبوس ها"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 450);
        }

        public string _TariffReport()

        {
            return WebClassLibrary.JWebManager.LoadClientControl("TariffReport"
                                , "~/WebBusManagement/FormsReports/JTariffReportControl.ascx"
                                , "گزارش تعرفه ها"
                                , null, WindowTarget.NewWindow, true, true, true);
        }

        //public string _BusDontLoginReport()
        //{
        //    return WebClassLibrary.JWebManager.LoadClientControl("BusDontLoginReport"
        //                        , "~/WebBusManagement/FormsReports/JBusDontLoginReportControl.ascx"
        //                        , "گزارش اتوبوس هایی که لاگین نکرده اند"
        //                        , null
        //                        , WindowTarget.NewWindow
        //                        , false, true, true, 0, 0, true);
        //}

        public string _HokmeKarReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("HokmeKarReport"
                                , "~/WebBusManagement/FormsReports/JHokmeKarReportControl.ascx"
                                , "گزارش حکم رانندگان"
                                , null
                                , WindowTarget.NewWindow
                                , false, true, true, 0, 0, true);
        }



        public string _BusTimeStopsAtTheStations()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusTimeStopsAtTheStations"
                            , "~/WebBusManagement/FormsReports/JBusTimeStopsAtTheStation.ascx"
                            , "گزارش میزان توقف اتوبوس در ایستگاه های مبدا و مقصد "
                            , null
                            , WindowTarget.NewWindow
                            , false, true, true, 0, 0, true);
        }
    
    
    public string _BusNotWorkInHokmeKarReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusNotWorkInHokmeKarReport"
                            , "~/WebBusManagement/FormsReports/JBusNotWorkInHokmeKarReportControl.ascx"
                            , "گزارش اتوبوس هایی که طبق حکم کار ، کار نکرده اند"
                            , null
                            , WindowTarget.NewWindow
                            , false, true, true, 0, 0, true);
        }

        public string _DriversLoginLogoutReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("DriversLoginLogoutReport"
                            , "~/WebBusManagement/FormsReports/JDriversLoginLogoutReportControl.ascx"
                            , ""
                            , null
                            , WindowTarget.NewWindow
                            , false, true, true, 0, 0, true);
        }
        public string _UndefinedDriversBusReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("UndefinedDriversBusReport"
                            , "~/WebBusManagement/FormsReports/JUndefinedDriversBusReportControl.ascx"
                            , "گزارش اتوبوس های با راننده تعریف نشده"
                            , null
                            , WindowTarget.NewWindow
                            , false, true, true, 0, 0, true);
        }


        public string _BusServiceReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusServiceReport"
                            , "~/WebBusManagement/FormsReports/JBusServiceReportControl.ascx"
                            , "گزارش سرویس های اتوبوس ها"
                            , null
                            , WindowTarget.NewWindow
                            , false, true, true, 0, 0, true);
        }
        public string _BusServiceWithoutTransactionReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusServiceWithoutTransactionReport"
                            , "~/WebBusManagement/FormsReports/JBusServiceWithoutTransactionReportControl.ascx"
                            , "گزارش اتوبوس های با سرویس بدون تراکنش"
                            , null
                            , WindowTarget.NewWindow
                            , false, true, true, 0, 0, true);
        }
        public string _BusPerformanceYearlyReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusPerformanceYearlyReport"
                        , "~/WebBusManagement/FormsReports/JBusPerformanceYearlyReportControl.ascx"
                        , "گزارش سالیانه کارکرد اتوبوس ها"
                        , null
                        , WindowTarget.NewWindow
                        , false, true, true, 0, 0, true);

        }

        //_BusTransactionLower
        public string _BusTransactionLower()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusTransactionLower"
                            , "~/WebBusManagement/FormsReports/JBusTransactionLowerReportControl.ascx"
                            , "گزارش کسر تراکنش اتوبوس ها"
                            , null
                            , WindowTarget.NewWindow
                            , false, true, true, 0, 0, true);
        }

        //_BusHokmeKarTarrifDif
        public string _BusHokmeKarTarrifDif()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusHokmeKarTarrifDif"
                            , "~/WebBusManagement/FormsReports/JBusHokmeKarTarrifDifReportControl.ascx"
                            , "گزارش اختلاف تعرفه و حکم کار"
                            , null
                            , WindowTarget.NewWindow
                            , false, true, true, 0, 0, true);
        }


        //public string _BusFirstLastStationReport()
        //{
        //    return WebClassLibrary.JWebManager.LoadClientControl("BusFirstLastStation"
        //        , "~/WebBusManagement/FormsReports/JBusFirstLastStationReportControl.ascx"
        //        , "گزارش ایستگاه های ابتدا و انتهای خط اتوبوس ها"
        //        , null
        //        , WindowTarget.NewWindow
        //        , false, true, true, 0, 0, true);
        //}

        public string _BusPassingStationReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusPassingStation"
                , "~/WebBusManagement/FormsReports/JBusPassingStationReportControl.ascx"
                , "گزارش عبور از ایستگاه اتوبوس ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        //        public string _DriversLoginLogout()
        //        {
        //           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //(_ConstClassName.Replace(".", "_"));
        //            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_DriversLoginLogout";
        //            jGridView.SQL = @"SELECT [AUTDriversLoginLogout].[Code] Code
        //                                    ,dbo.DateEnToFa([Date])Date
        //                                    ,[BusNumber]
        //                                    ,[DriverCardSerial]
        //                                    ,[DriverPersonCode]
        //	                                ,ISNULL(cap.Name,N'نامشخص')DriverName
        //                                    ,convert(varchar(32),[LoginTime],8)[LoginTime]
        //									,convert(varchar(32),[LogoutTime],8)[LogoutTime]
        //                                    ,dbo.DateEnToFa([InsertDate])InsertDate
        //                                FROM [dbo].[AUTDriversLoginLogout]
        //                                Left Join clsAllPerson cap on cap.Code = [AUTDriversLoginLogout].DriverPersonCode";
        //            jGridView.Title = "DriversLoginLogout";
        //            jGridView.PageOrderByField = "Code Desc";
        //            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
        //            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DriversLoginLogoutNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
        //            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DriversLoginLogoutUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
        //            jGridView.Actions = new List<JActionsInfo>();
        //            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
        //            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._DriversLoginLogoutUpdate", null, null));
        //            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
        //            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        //        }

        //        public string _DriversLoginLogoutNew()
        //        {
        //            return _DriversLoginLogoutNew(null);
        //        }
        //        public string _DriversLoginLogoutNew(string code)
        //        {
        //            return WebClassLibrary.JWebManager.LoadClientControl("DriversLoginLogout"
        //                 , "~/WebBusManagement/FormsManagement/JDriversLoginLogoutUpdateControl.ascx"
        //                 , "ورود و خروج راننده"
        //                 , null
        //                 , WindowTarget.NewWindow
        //                 , true, false, true, 700, 500);
        //        }
        //        public string _DriversLoginLogoutUpdate(string code)
        //        {
        //            return WebClassLibrary.JWebManager.LoadClientControl("DriversLoginLogout"
        //                  , "~/WebBusManagement/FormsManagement/JDriversLoginLogoutUpdateControl.ascx"
        //                  , "ورود و خروج راننده"
        //                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
        //                  , WindowTarget.NewWindow
        //                  , true, false, true, 700, 500);
        //        }

        //_EzamBe
        public string _EzamBe()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_EzamBe";
            jGridView.SQL = BusManagment.WorkOrder.JHokmeKars.GetWebQuery();
            //jGridView.HiddenColumns = "Code";
            jGridView.Title = "EzamBe";
            jGridView.PageOrderByField = " Code desc ";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._EzamBeNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._EzamBeUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._EzamBeUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _EzamBeNew()
        {
            return _EzamBeNew(null);
        }
        public string _EzamBeNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("EzamBe"
                 , "~/WebBusManagement/FormsManagement/JEzamBeUpdateControl.ascx"
                 , "اعزام به"
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


        ////_HokmeKar
        //public string _HokmeKar()
        //{
        //   WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //(_ConstClassName.Replace(".", "_"));
        //    jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_HokmeKar";
        //    jGridView.SQL = BusManagment.WorkOrder.JHokmeKars.GetWebQuery();
        //    //jGridView.HiddenColumns = "Code";
        //    jGridView.Title = "HokmeKar";
        //    jGridView.PageOrderByField = " Code desc ";
        //    jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
        //    jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._HokmeKarNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
        //    jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._HokmeKarUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));

        //    jGridView.Actions = new List<JActionsInfo>();
        //    //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
        //    jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._HokmeKarUpdate", null, null));
        //    //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
        //    return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        //}

        //public string _HokmeKarNew()
        //{
        //    return _HokmeKarNew(null);
        //}
        //public string _HokmeKarNew(string code)
        //{
        //    return WebClassLibrary.JWebManager.LoadClientControl("HokmeKar"
        //         , "~/WebBusManagement/FormsManagement/JHokmeKarUpdateControl.ascx"
        //         , "حکم کار رانندگان"
        //         , null
        //         , WindowTarget.NewWindow
        //         , true, false, true, 1150, 600);
        //}
        //public string _HokmeKarUpdate(string code)
        //{
        //    return WebClassLibrary.JWebManager.LoadClientControl("HokmeKar"
        //          , "~/WebBusManagement/FormsManagement/JHokmeKarUpdateControl.ascx"
        //          , "حکم کار رانندگان"
        //          , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
        //          , WindowTarget.NewWindow
        //          , true, false, true, 1150, 600);
        //}

        //public string _EzamBeUpdate(string code)
        //{
        //    return WebClassLibrary.JWebManager.LoadClientControl("EzamBe"
        //          , "~/WebBusManagement/FormsManagement/JEzamBeUpdateControl.ascx"
        //          , "اعزام به"
        //          , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
        //          , WindowTarget.NewWindow
        //          , true, false, true, 1150, 600);
        //}

        ////_Tariff
        //public string _Tariff()
        //{
        //   WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //(_ConstClassName.Replace(".", "_"));
        //    jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_Tariff";
        //    jGridView.SQL = BusManagment.WorkOrder.JTariffs.GetWebQuery();
        //    //jGridView.HiddenColumns = "Code";
        //    jGridView.Title = "Tariff";
        //    jGridView.PageOrderByField = " Code desc ";
        //    jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
        //    jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TariffNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
        //    jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TariffUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
        //    jGridView.Toolbar.AddButton("EzamBe", "EzamBe", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._EzamBeUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
        //    jGridView.Toolbar.AddButton("DriversNew", "DriversNew", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DriversNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
        //    jGridView.Toolbar.AddButton("TarrifHokmeKar", "TarrifHokmeKar", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TarrifHokmeKar", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
        //    jGridView.Toolbar.AddButton("TarrifEmptyPrint", "TarrifEmptyPrint", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TarrifEmptyPrint", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
        //    jGridView.Actions = new List<JActionsInfo>();
        //    //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
        //    jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._TariffUpdate", null, null));
        //    //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
        //    return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        //}

        ////_TarrifEmptyPrint
        //public string _TarrifEmptyPrint()
        //{
        //    return _TarrifEmptyPrint(null);
        //}
        //public string _TarrifEmptyPrint(string code)
        //{
        //    return WebClassLibrary.JWebManager.LoadClientControl("TarrifEmptyPrint"
        //         , "~/WebBusManagement/FormsManagement/JTarrifEmptyPrintUpdateControl.ascx"
        //         , "ثبت تعرفه خام"
        //         , null
        //         , WindowTarget.NewWindow
        //         , true, false, true, 600, 300);
        //}

        //public string _TarrifHokmeKar()
        //{
        //    return _TarrifHokmeKar(null);
        //}
        //public string _TarrifHokmeKar(string code)
        //{
        //    return WebClassLibrary.JWebManager.LoadClientControl("TarrifHokmeKar"
        //         , "~/WebBusManagement/FormsManagement/JTarrifHokmeKarUpdateControl.ascx"
        //         , "ثبت تعرفه بر اساس حکم کار"
        //         , null
        //         , WindowTarget.NewWindow
        //         , true, false, true, 500, 300);
        //}


        //public string _EzamBeUpdate(string code)
        //{
        //    return WebClassLibrary.JWebManager.LoadClientControl("EzamBe"
        //          , "~/WebBusManagement/FormsManagement/JEzamBeUpdateControl.ascx"
        //          , "اعزام به"
        //          , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
        //          , WindowTarget.NewWindow
        //         , false, true, true, 1150, 600);
        //}

        //public string _TariffNew()
        //{
        //    return _TariffNew(null);
        //}
        //public string _TariffNew(string code)
        //{
        //    return WebClassLibrary.JWebManager.LoadClientControl("Tariff"
        //         , "~/WebBusManagement/FormsManagement/JTariffUpdateControl.ascx"
        //         , "تعرفه"
        //         , null
        //         , WindowTarget.NewWindow
        //         , true, true, true);
        //}
        //public string _TariffUpdate(string code)
        //{
        //    return WebClassLibrary.JWebManager.LoadClientControl("Tariff"
        //          , "~/WebBusManagement/FormsManagement/JTariffUpdateControl.ascx"
        //          , "تعرفه"
        //          , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
        //          , WindowTarget.NewWindow
        //          , true, true, true);
        //}

    }
}