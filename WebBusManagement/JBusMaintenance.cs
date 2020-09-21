using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace WebBusManagement
{
    public class JBusMaintenance
    {

        public const string _ConstClassName = "WebBusManagement.JBusMaintenance";
        // Main Method
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();

            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SendSms", null, new List<object>() { }) }, "SendSms", _ConstClassName + "._SendSms", JDomains.Images.MenuImages.Item, null));
            
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._RTPISText", null, new List<object>() { }) }, "RTPISText", _ConstClassName + "._RTPISText", JDomains.Images.MenuImages.Item, null));

            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusValidAndInvalid", null, new List<object>() { }) }, "BusValidAndInvalid", _ConstClassName + "._BusValidAndInvalid", JDomains.Images.MenuImages.Item, null));

            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusOwnerReport", null, new List<object>() { }) }, "BusOwnerReport", _ConstClassName + "._BusOwnerReport", JDomains.Images.MenuImages.BusManagmentReport, null));

            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusDeviceSettings", null, new List<object>() { }) }, "BusDeviceSettings", _ConstClassName + "._BusDeviceSettings", JDomains.Images.MenuImages.Item, null));

            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GetQuery", null, new List<object>() { }) }, "GetQuery", _ConstClassName + "._GetQuery", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DefineQuery", null, new List<object>() { }) }, "DefineQuery", _ConstClassName + "._DefineQuery", JDomains.Images.MenuImages.Item, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DailyAndPrintComparisonReport", null, new List<object>() { }) }, "DailyAndPrintComparisonReport", _ConstClassName + "._DailyAndPrintComparisonReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DuplicateRecordInDailyReport", null, new List<object>() { }) }, "DuplicateRecordInDailyReport", _ConstClassName + "._DuplicateRecordInDailyReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusDontSendPrintReport", null, new List<object>() { }) }, "BusDontSendPrintReport", _ConstClassName + "._BusDontSendPrintReport", JDomains.Images.MenuImages.BusManagmentReport, null));

            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusSendDataReport", null, new List<object>() { }) }, "BusSendDataReport", _ConstClassName + "._BusSendDataReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusDontSendTicketInTimeframeReport", null, new List<object>() { }) }, "BusDontSendTicketInTimeframeReport", _ConstClassName + "._BusDontSendTicketInTimeframeReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusSendTicketCountRateReport", null, new List<object>() { }) }, "BusSendTicketCountRateReport", _ConstClassName + "._BusSendTicketCountRateReport", JDomains.Images.MenuImages.BusManagmentReport, null));

            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._InsertBusFailure", null, new List<object>() { }) }, "InsertBusFailure", _ConstClassName + "._InsertBusFailure", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusStatusMonthlyReport", null, new List<object>() { }) }, "BusStatusMonthlyReport", _ConstClassName + "._BusStatusMonthlyReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusStatusCurrentlyReport", null, new List<object>() { }) }, "BusStatusCurrentlyReport", _ConstClassName + "._BusStatusCurrentlyReport", JDomains.Images.MenuImages.BusManagmentReport, null));

            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._InvalidLinePriceReport", null, new List<object>() { }) }, "InvalidLinePriceReport", _ConstClassName + "._InvalidLinePriceReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Dictionary", null, new List<object>() { }) }, "Dictionary", _ConstClassName + "._Dictionary", JDomains.Images.MenuImages.BusManagmentReport, null));

            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusInstallAndUinstallDevice", null, new List<object>() { }) }, "BusInstallAndUinstallDevice", _ConstClassName + "._BusInstallAndUinstallDevice", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusInstallAndUinstallDeviceReport", null, new List<object>() { }) }, "BusInstallAndUinstallDeviceReport", _ConstClassName + "._BusInstallAndUinstallDeviceReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._InsertBusTicketTransaction", null, new List<object>() { }) }, "InsertBusTicketTransaction", _ConstClassName + "._InsertBusTicketTransaction", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._InsertBusOfflineFile", null, new List<object>() { }) }, "InsertBusOfflineFile", _ConstClassName + "._InsertBusOfflineFile", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusSimCardChargeReport", null, new List<object>() { }) }, "BusSimCardChargeReport", _ConstClassName + "._BusSimCardChargeReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusSimChargedReport", null, new List<object>() { }) }, "BusSimChargedReport", _ConstClassName + "._BusSimChargedReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusBatteryChargeReport", null, new List<object>() { }) }, "BusBatteryChargeReport", _ConstClassName + "._BusBatteryChargeReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ComparisonTicketTableAndExtractTableReport", null, new List<object>() { }) }, "ComparisonTicketTableAndExtractTableReport", _ConstClassName + "._ComparisonTicketTableAndExtractTableReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ComparisonTicketTExtractTAndDailyTReport", null, new List<object>() { }) }, "ComparisonTicketTExtractTAndDailyTReport", _ConstClassName + "._ComparisonTicketTExtractTAndDailyTReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TotalPerformanceReport", null, new List<object>() { }) }, "TotalPerformanceReport", _ConstClassName + "._TotalPerformanceReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusSummaryPerformanceReport", null, new List<object>() { }) }, "BusSummaryPerformanceReport", _ConstClassName + "._BusSummaryPerformanceReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusTicketFailureTransactionSendReport", null, new List<object>() { }) }, "BusTicketFailureSendReport", _ConstClassName + "._BusTicketFailureTransactionSendReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusAvlFailureTransactionSendReport", null, new List<object>() { }) }, "BusAvlFailureSendReport", _ConstClassName + "._BusAvlFailureTransactionSendReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusFailureDoorsReport", null, new List<object>() { }) }, "BusFailureDoorsReport", _ConstClassName + "._BusFailureDoorsReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ConsulHistoryReport", null, new List<object>() { }) }, "ConsulHistoryReport", _ConstClassName + "._ConsulHistoryReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusTicketFailureBusNumberReport", null, new List<object>() { }) }, "BusTicketFailureBusNumberReport", _ConstClassName + "._BusTicketFailureBusNumberReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusFailureIMEIReport", null, new List<object>() { }) }, "BusFailureIMEIReport", _ConstClassName + "._BusFailureIMEIReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusFailureDeviceIMEIReport", null, new List<object>() { }) }, "BusFailureDeviceIMEIReport", _ConstClassName + "._BusFailureDeviceIMEIReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusUsedSimCardChargeReport", null, new List<object>() { }) }, "BusUsedSimCardChargeReport", _ConstClassName + "._BusUsedSimCardChargeReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusNotActiveReport", null, new List<object>() { }) }, "BusNotActiveReport", _ConstClassName + "._BusNotActiveReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusSummaryTransactionReport", null, new List<object>() { }) }, "BusSummaryTransactionReport", _ConstClassName + "._BusSummaryTransactionReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusSendTicketTransenctionReport", null, new List<object>() { }) }, "BusSendTicketTransenctionReport", _ConstClassName + "._BusSendTicketTransenctionReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusSendAvlTransenctionReport", null, new List<object>() { }) }, "BusSendAvlTransenctionReport", _ConstClassName + "._BusSendAvlTransenctionReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusErrorDateTransactionReport", null, new List<object>() { }) }, "BusErrorDateTransactionReport", _ConstClassName + "._BusErrorDateTransactionReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusErrorSendTransactionReport", null, new List<object>() { }) }, "BusErrorSendTransactionReport", _ConstClassName + "._BusErrorSendTransactionReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PortalLastDataReport", null, new List<object>() { }) }, "PortalLastDataReport", _ConstClassName + "._PortalLastDataReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusLastDataReport", null, new List<object>() { }) }, "BusLastDataReport", _ConstClassName + "._BusLastDataReport", JDomains.Images.MenuImages.BusManagmentReport, null));

            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusGetReportFromConsole", null, new List<object>() { }) }, "BusGetReportFromConsole", _ConstClassName + "._BusGetReportFromConsole", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusReportFromPrintConsole", null, new List<object>() { }) }, "BusReportFromPrintConsole", _ConstClassName + "._BusReportFromPrintConsole", JDomains.Images.MenuImages.BusManagmentReport, null));




            //ReportSendQueryToConsoleStatus


            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusQuerySendReport", null, new List<object>() { }) }, "BusQuerySendReport", _ConstClassName + ".__BusQuerySendReport", JDomains.Images.MenuImages.Item, null));

            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JInsertBusTicketFailure", null, new List<object>() { }) }, "InsertBusTicketFailure", _ConstClassName + "._JInsertBusTicketFailure", JDomains.Images.MenuImages.Item, null));

            return nodes;
        }


        //_BusOwnerReport


        public string _BusQuerySendReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusQuerySendReport"
                , "~/WebBusManagement/FormsMaintenance/JBusQuerySendUpdateControl.ascx"
                , "گزارش وضعیت ارسال کوئری به کنسول"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _JInsertBusTicketFailure()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("InsertBusTicketFailure"
                , "~/WebBusManagement/FormsMaintenance/JInsertBusTicketFailure.ascx"
                , "گزارش اتوبوس های فعال"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusOwnerReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusOwnerReport"
                , "~/WebBusManagement/FormsMaintenance/JBusOwnerReportControl.ascx"
                , "گزارش مالکین اتوبوس ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }


        public string _SendSms()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("SendSms"
                , "~/WebBusManagement/FormsManagement/JSendSmsUpdateControl.ascx"
                , "ارسال پیام کوتاه"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _RTPISText()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("RTPISText"
                , "~/WebBusManagement/FormsManagement/JRTPISTextUpdateControl.ascx"
                , "ثبت متن RTPIS"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        //_InsertBusTicketTransaction
        public string _InsertBusTicketTransaction()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_InsertBusTicketTransaction";
            jGridView.SQL = BusManagment.JBusTransactionPrints.GetWebQuery();
            jGridView.Title = "InsertBusTicketTransaction";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._InsertBusTicketTransactionNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._InsertBusTicketTransactionUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._InsertBusTicketTransactionUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);

        }

        public string _InsertBusTicketTransactionNew()
        {
            return _InsertBusTicketTransactionNew(null);
        }
        public string _InsertBusTicketTransactionNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("InsertBusTicketTransaction"
                  , "~/WebBusManagement/FormsMaintenance/JInsertBusTicketTransactionUpdateControl.ascx"
                  , "ثبت پرینت تراکنش اتوبوس"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 450);
        }
        public string _InsertBusTicketTransactionUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("InsertBusTicketTransaction"
                  , "~/WebBusManagement/FormsMaintenance/JInsertBusTicketTransactionUpdateControl.ascx"
                  , "ویرایش پرینت تراکنش اتوبوس"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 450);
        }

        //_BusInstallAndUinstallDevice
        public string _BusInstallAndUinstallDevice()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_BusInstallAndUinstallDevice";
            jGridView.SQL = BusManagment.JBusInstallAndUnistallDevises.GetWebQuery();
            jGridView.Title = "BusInstallAndUinstallDevice";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusInstallAndUinstallDeviceNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusInstallAndUinstallDeviceUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._BusInstallAndUinstallDeviceUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);

        }

        public string _BusInstallAndUinstallDeviceNew()
        {
            return _BusInstallAndUinstallDeviceNew(null);
        }
        public string _BusInstallAndUinstallDeviceNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusInstallAndUinstallDevice"
                  , "~/WebBusManagement/FormsMaintenance/JBusInstallAndUinstallDeviceUpdateControl.ascx"
                  , "ثبت نصب و فک دستگاه"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 450);
        }
        public string _BusInstallAndUinstallDeviceUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusInstallAndUinstallDevice"
                  , "~/WebBusManagement/FormsMaintenance/JBusInstallAndUinstallDeviceUpdateControl.ascx"
                  , "ثبت نصب و فک دستگاه"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 450);
        }

        //_InsertBusFailure
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

        //_BusValidAndInvalid

        public string _BusValidAndInvalid()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_BusValidAndInvalid";
            jGridView.SQL = @"select top 100 percent ab.Code,BUSNumber,af.Name FleetName,LastLineNumber LineNumber,case Active when 1 then N'فعال' else N'غیر فعال' end Status,LastDate LastAvlDate,TicketLastDate
                                ,case Isvalid when 1 then N'معتبر' else N'نامعتبر' end IsValid
                                from AUTBus ab left join AUTFleet af on af.Code = ab.FleetCode";
            jGridView.Title = "BusValidAndInvalid";
            jGridView.PageOrderByField = " BUSNumber ";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            //jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._InsertBusOfflineFileNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("ApplyBus", "ApplyBus", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ApplyBus", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            //jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._InsertBusOfflineFileGetDetaile", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);

        }

        //ApplyBus

        public string _ApplyBus(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("ApplyBus"
                  , "~/WebBusManagement/FormsMaintenance/JApplyInvalidBusUpdateControl.ascx"
                  , "تایید اتوبوس نامعتبر"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 450);
        }

        //_InsertBusOfflineFile
        public string _InsertBusOfflineFile()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_InsertBusOfflineFile";
            jGridView.SQL = BusManagment.JBusOfflineFileses.GetWebQuery();
            jGridView.Title = "InsertBusOfflineFile";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._InsertBusOfflineFileNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            //jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._InsertBusOfflineFileUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._InsertBusOfflineFileGetDetaile", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);

        }

        public string _InsertBusOfflineFileNew()
        {
            return _InsertBusOfflineFileNew(null);
        }
        public string _InsertBusOfflineFileNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("InsertBusOfflineFile"
                  , "~/WebBusManagement/FormsMaintenance/JInsertBusOfflineFileUpdateControl.ascx"
                  , "درج فایل های آفلاین اتوبوس ها"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 450);
        }
        public string _InsertBusOfflineFileUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("InsertBusOfflineFile"
                  , "~/WebBusManagement/FormsMaintenance/JInsertBusOfflineFileUpdateControl.ascx"
                  , "درج فایل های آفلاین اتوبوس ها"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 450);
        }
        public string _InsertBusOfflineFileGetDetaile(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("InsertBusOfflineFileGetDetaile"
                  , "~/WebBusManagement/FormsMaintenance/JInsertBusOfflineFileGetDetaileReportControl.ascx"
                  , "ریز جزئیات فایل های آفلاین اتوبوس ها"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 450);
        }

        public string _BusDeviceSettings()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusDeviceSettings"
                , "~/WebBusManagement/FormsManagement/JBusDeviceSettingsUpdateControl.ascx"
                , "تنظیمات اتوبوس"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _GetQuery()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("GetQuery"
                , "~/WebBusManagement/FormsMaintenance/JGetQueryUpdateControl.ascx"
                , "ورود کوئری"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }
        public string _DefineQuery()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_DefineQuery";
            jGridView.SQL = BusManagment.Query.JQueries.GetWebQuery();
            jGridView.Title = "DefineQuery";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DefineQueryNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DefineQueryUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._DefineQueryUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }
        public string _DefineQueryNew()
        {
            return _DefineQueryNew(null);
        }
        public string _DefineQueryNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("DefineQuery"
                  , "~/WebBusManagement/FormsMaintenance/JDefineQueryUpdateControl.ascx"
                  , "تعریف کوئری"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 350);
        }
        public string _DefineQueryUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("DefineQuery"
                  , "~/WebBusManagement/FormsMaintenance/JDefineQueryUpdateControl.ascx"
                  , "تعریف کوئری"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 350);
        }
        public string _BusInstallAndUinstallDeviceReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusInstallAndUinstallDeviceReport"
                , "~/WebBusManagement/FormsMaintenance/JBusInstallAndUinstallDeviceReportControl.ascx"
                , "گزارش نصب و فک دستگاه ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        //_BusSendDataReport
        public string _BusSendDataReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusSendDataReport"
                , "~/WebBusManagement/FormsMaintenance/JBusSendDataReportControl.ascx"
                , "گزارش ارسال اطلاعات اتوبوس ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        //_BusDontSendTicketInTimeframeReport
        public string _BusDontSendTicketInTimeframeReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusDontSendTicketInTimeframeReport"
                , "~/WebBusManagement/FormsMaintenance/JBusDontSendTicketInTimeframeReportControl.ascx"
                , "گزارش عدم ارسال بلیط اتوبوس در بازه زمانی"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        //_BusSendTicketCountRateReport
        public string _BusSendTicketCountRateReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusSendTicketCountRateReport"
                , "~/WebBusManagement/FormsMaintenance/JBusSendTicketCountRateReportControl.ascx"
                , "گزارش تعداد بلیط ارسالی اتوبوس ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        //_BusStatusMonthlyReport
        public string _BusStatusMonthlyReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusStatusMonthlyReport"
                , "~/WebBusManagement/FormsMaintenance/JBusStatusMonthlyReportControl.ascx"
                , "گزارش وضعیت ماهانه اتوبوس"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        //_BusStatusCurrentlyReport
        public string _BusStatusCurrentlyReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusStatusCurrentlyReport"
                , "~/WebBusManagement/FormsMaintenance/JBusStatusCurrentlyReportControl.ascx"
                , "گزارش وضعیت جاری اتوبوس"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        //_InvalidLinePriceReport
        public string _InvalidLinePriceReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("InvalidLinePriceReport"
                , "~/WebBusManagement/FormsMaintenance/JInvalidLinePriceReportControl.ascx"
                , "گزارش مبالغ نادرست"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }
        public string _Dictionary()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_Dictionary";
            jGridView.SQL = BusManagment.Dictionary.JDictionaries.GetWebQuery();
            jGridView.Title = "Dictionary";
            //jGridView.HiddenColumns = "Code";
            //jGridView.PageOrderByField = " Name asc ";
            jGridView.Buttons = "excel,print,record_print,refresh";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DictionaryNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DictionaryUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._DictionaryUpdate", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _DictionaryNew()
        {
            return _DictionaryNew(null);
        }
        public string _DictionaryNew(string Code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Dictionary"
                  , "~/WebBusManagement/FormsMaintenance/JDictionaryUpdateControl.ascx"
                  , "لغت نامه"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 350);
        }
        public string _DictionaryUpdate(string Code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Dictionary"
                  , "~/WebBusManagement/FormsMaintenance/JDictionaryUpdateControl.ascx"
                  , "لغت نامه"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", Code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 350);
        }

        public string _BusSimCardChargeReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusSimCardCharge"
                , "~/WebBusManagement/FormsMaintenance/JBusSimCardChargeReportControl.ascx"
                , "گزارش شارژ سیم کارت ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusBatteryChargeReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusBatteryCharge"
                , "~/WebBusManagement/FormsMaintenance/JBusBatteryChargeReportControl.ascx"
                , "گزارش وضعیت شارژ باتری دستگاه ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _TotalPerformanceReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("TotalPerformance"
                , "~/WebBusManagement/FormsMaintenance/JTotalPerformanceReportControl.ascx"
                , "گزارش خلاصه وضعیت کارکرد"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusSummaryPerformanceReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusSummaryPerformance"
                , "~/WebBusManagement/FormsMaintenance/JBusSummaryPerformanceReportControl.ascx"
                , "گزارش خلاصه کارکرد اتوبوس"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusTicketFailureTransactionSendReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusTicketFailureTransactionSend"
                , "~/WebBusManagement/FormsMaintenance/JBusTicketFailureTransactionSendReportControl.ascx"
                , "گزارش عدم ارسال تراکنش بلیط"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusAvlFailureTransactionSendReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusAvlFailureTransactionSend"
                , "~/WebBusManagement/FormsMaintenance/JBusAvlFailureTransactionSendReportControl.ascx"
                , "گزارش عدم ارسال تراکنش AVL"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusFailureDoorsReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusFailureDoors"
                , "~/WebBusManagement/FormsMaintenance/JBusFailureDoorsReportControl.ascx"
                , "گزارش عدم ارسال تراکنش دو درب"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _ConsulHistoryReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("ConsulHistory"
                , "~/WebBusManagement/FormsMaintenance/JConsulHistoryReportControl.ascx"
                , "گزارش تاریخچه ی کنسول ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusTicketFailureBusNumberReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusTicketFailureBusNumber"
                , "~/WebBusManagement/FormsMaintenance/JBusTicketFailureBusNumberReportControl.ascx"
                , "گزارش شماره اتوبوس های نامعتبر در تراکنش های بلیط"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusFailureDeviceIMEIReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusFailureDeviceIMEI"
                , "~/WebBusManagement/FormsMaintenance/JBusFailureDeviceIMEIReportControl.ascx"
                , "گزارش اختلاف بین IMEI ثبت شده برای اتوبوس و اطلاعات رسیده از کنسول"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusUsedSimCardChargeReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusUsedSimCardCharge"
                , "~/WebBusManagement/FormsMaintenance/JBusUsedSimCardChargeReportControl.ascx"
                , "گزارش مصرف شارژ سیم کارت اتوبوس ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusNotActiveReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusNotActiveReport"
                , "~/WebBusManagement/FormsMaintenance/JBusNotActiveReportControl.ascx"
                , "گزارش عدم فعالسازی اتوبوس ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusSummaryTransactionReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusSummaryTransactionReport"
                , "~/WebBusManagement/FormsMaintenance/JBusSummaryTransactionReportControl.ascx"
                , "گزارش خلاصه تراکنش های انجام شده اتوبوس"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusSendTicketTransenctionReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusSendTicketTransenctionReport"
                , "~/WebBusManagement/FormsMaintenance/JBusSendTicketTransenctionReportControl.ascx"
                , "گزارش ارسال تراکنش بلیط اتوبوس ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusSendAvlTransenctionReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusSendAvlTransenctionReport"
                , "~/WebBusManagement/FormsMaintenance/JBusSendAvlTransenctionReportControl.ascx"
                , "گزارش ارسال تراکنش AVL اتوبوس ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusErrorDateTransactionReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusErrorDateTransactionReport"
                , "~/WebBusManagement/FormsMaintenance/JBusErrorDateTransactionReportControl.ascx"
                , "گزارش خطای تاریخ"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusErrorSendTransactionReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusErrorSendTransactionReport"
                , "~/WebBusManagement/FormsMaintenance/JBusErrorSendTransactionReportControl.ascx"
                , "گزارش خطای ارسال"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _PortalLastDataReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("PortalLastDataReport"
                , "~/WebBusManagement/FormsMaintenance/JPortalLastDataReportControl.ascx"
                , "گزارش آخرین اطلاعات دریافتی پرتال"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        //JBusQuerySendUpdateControl Node

        public string _BusLastDataReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusLastDataReport"
                , "~/WebBusManagement/FormsMaintenance/JBusLastDataReportControl.ascx"
                , "گزارش آخرین اطلاعات دریافتی اتوبوس ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusGetReportFromConsole()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "BusGetReportFromConsole");
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_BusGetReportFromConsole";
            jGridView.SQL = @"select Code,BusNumber,StartDate,EndDate,TicketCount,TicketSent,case State when 0 then N'منتظر پاسخ' else N'پاسخ دریافت شده' end as State,
                                case GetTicket when 0 then N'بلیط ارسال نشده' else N'بلیط ارسال شده' end as GetTicket,RequestDate from [dbo].[AUTPrinterRporte]
                                where ShiftDriverCode = 0 and DailyCode < 1 and cast(StartDate as date) = cast(EndDate as date)";
            jGridView.Title = "BusGetReportFromConsole";
            jGridView.PageOrderByField = "RequestDate desc";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusGetReportFromConsoleNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            //jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._InsertBusOfflineFileUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            //jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            //jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._InsertBusOfflineFileGetDetaile", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);

        }

        public string _BusGetReportFromConsoleNew()
        {
            return _BusGetReportFromConsoleNew(null);
        }
        public string _BusGetReportFromConsoleNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusGetReportFromConsole"
                  , "~/WebBusManagement/FormsMaintenance/JBusGetReportFromConsoleUpdateControl.ascx"
                  , "دریافت پرینت از کنسول"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 450);
        }

        public string _ComparisonTicketTableAndExtractTableReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("ComparisonTicketTableAndExtractTableReport"
                , "~/WebBusManagement/FormsMaintenance/JComparisonTicketTableAndExtractTableReportControl.ascx"
                , "گزارش مقایسه جدول بلیط با جدول اکسترکت"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusSimChargedReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusSimChargedReport"
                , "~/WebBusManagement/FormsMaintenance/JBusSimChargedReportControl.ascx"
                , "گزارش سیم کارت های شارژ شده"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _ComparisonTicketTExtractTAndDailyTReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("ComparisonTicketTExtractTAndDailyT"
                , "~/WebBusManagement/FormsMaintenance/JComparisonTicketTExtractTAndDailyTReportControl.ascx"
                , "گزارش مقایسه سه جدول بلیط ، اکسترکت و تجمیع"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        //_DailyAndPrintComparisonReport
        public string _DailyAndPrintComparisonReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("DailyAndPrintComparisonReport"
                , "~/WebBusManagement/FormsMaintenance/JDailyAndPrintComparisonReportControl.ascx"
                , "گزارش اختلاف های جدول پرینت و جدول تجمیع بلیط"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        //_DuplicateRecordInDailyReport
        public string _DuplicateRecordInDailyReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("DuplicateRecordInDailyReport"
                , "~/WebBusManagement/FormsMaintenance/JDuplicateRecordInDailyReportControl.ascx"
                , "گزارش رکورد تکراری در جدول تجمیع بلیط"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        //_BusDontSendPrintReport
        public string _BusDontSendPrintReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusDontSendPrintReport"
                , "~/WebBusManagement/FormsMaintenance/JBusDontSendPrintReportControl.ascx"
                , "گزارش اتوبوس هایی که پرینت خود را اعلام نکرده اند"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusFailureIMEIReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusFailureIMEIReport"
                , "~/WebBusManagement/FormsMaintenance/JBusFailureIMEIReportControl.ascx"
                , "گزارش IMEI های نامعتبر"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        //_BusReportFromPrintConsole
        public string _BusReportFromPrintConsole()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusReportFromPrintConsole"
                , "~/WebBusManagement/FormsReports/JDailyReport.ascx"
                , "گزارش پرینت روزانه"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

    }
}