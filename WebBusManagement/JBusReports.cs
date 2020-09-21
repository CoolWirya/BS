using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace WebBusManagement
{
    public class JBusReports
    {
        public const string _ConstClassName = "WebBusManagement.JBusReports";
        // Main Method
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LastAVLTransactions", null, new List<object>() { }) }, "LastAVLTransactions", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LastTicketTransactions", null, new List<object>() { }) }, "LastTicketTransactions", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ZonesTransactionAndIncome", null, new List<object>() { }) }, "ZonesTransactionAndIncome", _ConstClassName + "._ZonesTransactionAndIncome", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LinesTransactionAndIncome", null, new List<object>() { }) }, "LinesTransactionAndIncome", _ConstClassName + "._LinesTransactionAndIncome", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusPerformance", null, new List<object>() { }) }, "BusPerformance", _ConstClassName + "._BusPerformance", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JConsoleOffloadReport", null, new List<object>() { }) }, "JConsoleOffloadReport", _ConstClassName + "._JConsoleOffloadReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._CompareBusPerformance", null, new List<object>() { }) }, "CompareBusPerformance", _ConstClassName + "._CompareBusPerformance", JDomains.Images.MenuImages.BusManagmentReport, null));

            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusPerformanceAccounting", null, new List<object>() { }) }, "BusPerformanceAccounting", _ConstClassName + "._BusPerformanceAccounting", JDomains.Images.MenuImages.BusManagmentReport, null));

            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DailyFleetPerformanceCalender", null, new List<object>() { }) }, "DailyFleetPerformanceCalender", _ConstClassName + "._DailyFleetPerformanceCalender", JDomains.Images.MenuImages.BusManagmentReport, null));

            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._AllBusPerformanceCalender", null, new List<object>() { }) }, "AllBusPerformanceCalender", _ConstClassName + "._AllBusPerformanceCalender", JDomains.Images.MenuImages.BusManagmentReport, null));

            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusPerformanceCalender", null, new List<object>() { }) }, "BusPerformanceCalender", _ConstClassName + "._BusPerformanceCalender", JDomains.Images.MenuImages.BusManagmentReport, null));

            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OwnerBusReport", null, new List<object>() { }) }, "OwnerBusReport", _ConstClassName + "._OwnerBusReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DriverPerformance", null, new List<object>() { }) }, "DriverPerformance", _ConstClassName + "._DriverPerformance", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusTransaction", null, new List<object>() { }) }, "BusTransaction", _ConstClassName + "._BusTransaction", JDomains.Images.MenuImages.BusManagmentReport, null));

            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusDailyPrintPaymentReport", null, new List<object>() { }) }, "BusDailyPrintPaymentReport", _ConstClassName + "._BusDailyPrintPaymentReport", JDomains.Images.MenuImages.BusManagmentReport, null));

            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusStatusMonthlyReport", null, new List<object>() { }) }, "BusStatusMonthlyReport", _ConstClassName + "._BusStatusMonthlyReport", JDomains.Images.MenuImages.BusManagmentReport, null));

            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusDontSendTicketDataReport", null, new List<object>() { }) }, "BusDontSendTicketDataReport", _ConstClassName + "._BusDontSendTicketDataReport", JDomains.Images.MenuImages.BusManagmentReport, null));

            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GroundDeviceTicketReport", null, new List<object>() { }) }, "GroundDeviceTicketReport", _ConstClassName + "._GroundDeviceTicketReport", JDomains.Images.MenuImages.BusManagmentReport, null));

           // nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusConsoleAndPortalTransaction", null, new List<object>() { }) }, "BusConsoleAndPortalTransaction", _ConstClassName + "._BusConsoleAndPortalTransaction", JDomains.Images.MenuImages.BusManagmentReport, null));

            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusMulFunctionForms", null, new List<object>() { }) }, "BusMulFunctionForms", _ConstClassName + "._BusMulFunctionForms", JDomains.Images.MenuImages.BusManagmentReport, null));

			////// DailyReport
			nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + ".DailyReport", null, new List<object>() { }) }, "گزارش پرینت روزانه", _ConstClassName + ".DailyReport", JDomains.Images.MenuImages.BusManagmentReport, null));

            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._NumOfPerformanceDayReport", null, new List<object>() { }) }, "NumOfPerformanceDayReport", _ConstClassName + "._NumOfPerformanceDayReport", JDomains.Images.MenuImages.BusManagmentReport, null));

            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LinePerformanceAverageReport", null, new List<object>() { }) }, "LinePerformanceAverageReport", _ConstClassName + "._LinePerformanceAverageReport", JDomains.Images.MenuImages.BusManagmentReport, null));

            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusTransactionLower", null, new List<object>() { }) }, "BusTransactionLower", _ConstClassName + "._BusTransactionLower", JDomains.Images.MenuImages.BusManagmentReport, null));

            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SmsSendReport", null, new List<object>() { }) }, "SmsSendReport", _ConstClassName + "._SmsSendReport", JDomains.Images.MenuImages.BusManagmentReport, null));

            return nodes;
        }

        public string _SmsSendReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("SmsSendReport"
                            , "~/WebBusManagement/FormsReports/JSmsSendReportControl.ascx"
                            , "گزارش ارسال پیام کوتاه"
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


        //_LinePerformanceAverageReport
        public string _LinePerformanceAverageReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("LinePerformanceAverageReport"
                , "~/WebBusManagement/FormsReports/JLinePerformanceAverageReportControl.ascx"
                , "گزارش مقایسه ای متوسط تراکنش خطوط"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _NumOfPerformanceDayReport()
        {
            //return WebClassLibrary.JWebManager.LoadClientControl("DailyReport",
            //        "~/WebBusManagement/FormsReports/JNumOfPerformanceDayReportControl.ascx", "گزارش تعداد روزهای کارکرد اتوبوس ها"
            //        , null, WindowTarget.NewWindow, true, true, true);

            return WebClassLibrary.JWebManager.LoadClientControl("NumOfPerformanceDayReport"
                , "~/WebBusManagement/FormsReports/JNumOfPerformanceDayReportControl.ascx"
                , "گزارش تعداد روزهای کارکرد اتوبوس ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }


		public string DailyReport()
		{
			return WebClassLibrary.JWebManager.LoadClientControl("DailyReport",
				"~/WebBusManagement/FormsReports/JDailyReport.ascx", "پرینت روزانه"
				, null, WindowTarget.NewWindow, true, true, true);
		}

        public string _GroundDeviceTicketReport()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_GroundDeviceTicketReport";
            jGridView.SQL = @"SELECT top 100 percent [Code]
                                      ,[Ip]
                                      ,convert (varchar(max),[Data],2) PackData
                                      ,cast(dbo.DateEnToFa([GetDate]) as varchar) +' '+ cast(cast([GetDate] as time)as varchar) RecivedDate
                                      ,[IsProceced]
                                  FROM [dbo].[AUTGroundDeviceTicket]";
            jGridView.Title = "GroundDeviceTicketReport";
            jGridView.PageOrderByField = "RecivedDate desc";
            jGridView.ClassName = _ConstClassName;
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("GroundDeviceTicketReportShowData", "GroundDeviceTicketReportShowData", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GroundDeviceTicketReportShowData", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            //jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._FleetUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._GroundDeviceTicketReportShowData", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _GroundDeviceTicketReportShowData(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("GroundDeviceTicket"
                  , "~/WebBusManagement/FormsReports/JGroundDeviceTicketReportShowDataReportControl.ascx"
                  , "نمایش اطلاعات"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 350);
        }

        public string _BusPerformanceCalender()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusPerformanceCalender",
                "~/WebBusManagement/FormsReports/JBusPerformanceCalenderReportControl.ascx", "تقویم کارکرد تفصیلی اتوبوس"
                , null, WindowTarget.NewWindow, true, true, true);
        }

        public string _AllBusPerformanceCalender()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("AllBusPerformanceCalender",
                "~/WebBusManagement/FormsReports/JAllBusPerformanceCalenderReportControl.ascx", "تقویم کارکرد معین"
                , null, WindowTarget.NewWindow, true, true, true);
        }

        public string _DailyFleetPerformanceCalender()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("AllBusPerformanceCalender",
                "~/WebBusManagement/FormsReports/JDailyFleetPerformanceCalenderReportControl.ascx", "تقویم کارکرد روزانه"
                , null, WindowTarget.NewWindow, true, true, true);
        }

        //_BusDontSendTicketDataReport
        public string _BusDontSendTicketDataReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusDontSendTicketDataReport"
                , "~/WebBusManagement/FormsMaintenance/JBusDontSendTicketDataReportControl.ascx"
                , "گزارش عدم ارسال اطلاعات اتوبوس ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusStatusMonthlyReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusStatusMonthlyReport"
                , "~/WebBusManagement/FormsMaintenance/JBusStatusMonthlyReportControl.ascx"
                , "گزارش وضعیت ماهانه اتوبوس"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        //_BusMulFunctionForms
        public string _BusMulFunctionForms()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_BusMulFunctionForms";
            jGridView.SQL = BusManagment.Bus.JBuses.GetMulFunctionOfBusQuery();
            jGridView.Title = "BusMulFunctionInsert";
            jGridView.PageOrderByField = "BusNumber asc";
            jGridView.ClassName = _ConstClassName;
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("MulFunctionInsert", "MulFunctionInsert", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusMulFunctionInsertForm", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            //jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._FleetUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            //jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            //jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._FleetUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _BusMulFunctionInsertForm(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusMulFunctionInsertForm"
                  , "~/WebBusManagement/FormsReports/JFleetUpdateControl.ascx"
                  , "اعلام خرابی"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 350);
        }



        public string _LastAVLTransactions()
        {
            string SUID = "BusManagement_LastAVLTransactions";
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(SUID);
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_LastAVLTransactions";
            jGridView.SQL = BusManagment.AVL.JAVLTransactions.GetWebQuery();
            jGridView.PageOrderByField = "EventDate DESC";
            jGridView.PageSize = 30;
            jGridView.Title = "LastAVLTransactions";
            jGridView.RefreshTimerEnabled = true;
            jGridView.RefreshTimerInterval = 5000; // 5 Seconds
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            //jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._ZoneUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true,false,true), false);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), false);
        }

        public string _LastTicketTransactions()
        {
            string SUID = "BusManagement_LastTicketTransactions";
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(SUID);
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_LastTicketTransactions";
            jGridView.SQL = BusManagment.Transaction.JTicketTransactions.GetWebQuery();
            jGridView.PageOrderByField = "EventDate DESC";
            jGridView.PageSize = 30;
            jGridView.Title = "LastTicketTransactions";
            jGridView.RefreshTimerEnabled = true;
            jGridView.RefreshTimerInterval = 5000; // 5 Seconds
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            //jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._ZoneUpdate", null, null));
            // JWebManager.AddWindow(jGridView.GenerateWindow(true, false, true), false);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), false);
        }

        public string _BusPerformance()
        {
            //WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            //jGridView.Toolbar.AddButton("GetFile", "GetFile", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GetFile", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            return WebClassLibrary.JWebManager.LoadClientControl("BusPerformance"
             , "~/WebBusManagement/FormsReports/JBusPerformanceReportControl.ascx"
             , "گزارش کارکرد اتوبوس"
             , null
             , WindowTarget.NewWindow
             , false, true, true, 0, 0, true);
            //return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);  
         }
        public string _JConsoleOffloadReport()
        {            
            return WebClassLibrary.JWebManager.LoadClientControl("JConsoleOffloadReport"
             , "~/WebBusManagement/FormsReports/JConsoleOffloadReport.ascx"
             , "گزارش تخلیه کنسول اتوبوس"
             , null
             , WindowTarget.NewWindow
             , false, true, true, 0, 0, true);
            
        }
        public string _CompareBusPerformance()
        {
            //WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            //jGridView.Toolbar.AddButton("GetFile", "GetFile", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GetFile", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Report));
            return WebClassLibrary.JWebManager.LoadClientControl("CompareBusPerformance"
             , "~/WebBusManagement/FormsReports/JCompareBusPerformance.ascx"
             , "گزارش مقایسه کارکرد اتوبوس"
             , null
             , WindowTarget.NewWindow
             , false, true, true, 0, 0, true);
            //return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);  
        }



        public string _BusPerformanceAccounting()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusPerformanceAccounting"
                  , "~/WebBusManagement/FormsReports/JBusPerformanceAccountingReportControl.ascx"
                  , "گزارش کارکرد مالی اتوبوس"
                  , null
                  , WindowTarget.NewWindow
                  , false, true, true, 0, 0, true);
        }

        public string _BusDailyPrintPaymentReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusDailyPrintPaymentReport"
                  , "~/WebBusManagement/FormsReports/JBusDailyPrintPaymentReportControl.ascx"
                  , "گزارش وضعیت تراکنش های اتوبوس ها"
                  , null
                  , WindowTarget.NewWindow
                  , false, true, true, 0, 0, true);
        }

        public string _OwnerBusReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OwnerBusReport"
                , "~/WebBusManagement/FormsReports/JOwnerBusReportControl.ascx"
                , "مشخصات اتوبوس مالک"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _DriverPerformance()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("DriverPerformance"
                , "~/WebBusManagement/FormsReports/JDriverPerformanceReportControl.ascx"
                , "گزارش کارکرد رانندگان"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusTransaction()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusTransaction"
                , "~/WebBusManagement/FormsReports/JBusTransactionReportControl.ascx"
                , "گزارش تراکنش اتوبوس ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _InsertAutLineStation()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("InsertAutLineStation"
                , "~/WebBusManagement/FormsReports/JInsertAutLineStationUpdateControl.ascx"
                , "درج ایستگاه های خطوط"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _ZonesTransactionAndIncome()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("ZonesTransactionAndIncome"
                , "~/WebBusManagement/FormsReports/JZonesTransactionAndIncomeReportControl.ascx"
                , "گزارش تراکنش و درآمد مناطق"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _LinesTransactionAndIncome()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("LinesTransactionAndIncome"
                , "~/WebBusManagement/FormsReports/JLinesTransactionAndIncomeReportControl.ascx"
                , "گزارش تراکنش و درآمد خطوط"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }


        public string _DriverServices()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("DriverServices"
                , "~/WebBusManagement/FormsReports/JDriverServicesReportControl.ascx"
                , "گزارش سرویس های رانندگان"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _DriverCrossingFromStop()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("DriverCrossingFromStop"
                , "~/WebBusManagement/FormsReports/JDriverCrossingFromStopReportControl.ascx"
                , "گزارش عبور رانندگان از ایستگاه"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _DriverTrepassFromLine()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("DriverTrepassFromLine"
                , "~/WebBusManagement/FormsReports/JDriverTrepassFromLineReportControl.ascx"
                , "گزارش تخلف راننده از مسیر"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusConsoleAndPortalTransaction()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusConsoleAndPortalTransaction"
                , "~/WebBusManagement/FormsReports/JBusConsoleAndPortalTransactionReportControl.ascx"
                , "گزارش مقایسه پرینت کنسول و پرتال"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        //public string _DocumentAndPayment()
        //{
        //    return WebClassLibrary.JWebManager.LoadClientControl("DocumentAndPayment"
        //        , "~/WebBusManagement/FormsReports/JDocumentAndPaymentReportControl.ascx"
        //        , "گزارش اسناد و پرداختی ها"
        //        , null
        //        , WindowTarget.NewWindow
        //        , false, true, true, 0, 0, true);
        //}

        //public void _ZonesStatisticalReport()
        //{
        //    WebClassLibrary.JWebManager.LoadClientControl("ZonesStatisticalReport"
        //        , "~/WebBusManagement/FormsReports/JZonesStatisticalReportControl.ascx"
        //        , "گزارش آماری مناطق"
        //        , null
        //        , WindowTarget.NewWindow
        //        , false, true, true, 0, 0, true);
        //}

        //public void _LinesStatisticalReport()
        //{
        //    WebClassLibrary.JWebManager.LoadClientControl("LinesStatisticalReport"
        //        , "~/WebBusManagement/FormsReports/JLinesStatisticalReportControl.ascx"
        //        , "گزارش آماری خطوط"
        //        , null
        //        , WindowTarget.NewWindow
        //        , false, true, true, 0, 0, true);
        //}


        //public void _BusStatisticalReport()
        //{
        //    WebClassLibrary.JWebManager.LoadClientControl("BusStatisticalReport"
        //        , "~/WebBusManagement/FormsReports/JBusStatisticalReportControl.ascx"
        //        , "گزارش آماری اتوبوس ها"
        //        , null
        //        , WindowTarget.NewWindow
        //        , false, true, true, 0, 0, true);
        //}

        //public void _DriverStatisticalReport()
        //{
        //    WebClassLibrary.JWebManager.LoadClientControl("DriverStatisticalReport"
        //        , "~/WebBusManagement/FormsReports/JDriverStatisticalReportControl.ascx"
        //        , "گزارش آماری رانندگان"
        //        , null
        //        , WindowTarget.NewWindow
        //        , false, true, true, 0, 0, true);
        //}

        //public void _DailyStatisticalReport()
        //{
        //    WebClassLibrary.JWebManager.LoadClientControl("DailyStatisticalReport"
        //       , "~/WebBusManagement/FormsReports/JDailyStatisticalReportControl.ascx"
        //       , "گزارش آماری روزانه"
        //       , null
        //       , WindowTarget.NewWindow
        //       , false, true, true, 0, 0, true);
        //}

    }
}