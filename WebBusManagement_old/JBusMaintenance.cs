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
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusDeviceSettings", null, new List<object>() { }) }, "BusDeviceSettings", _ConstClassName + "._BusDeviceSettings", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusInstallAndUinstallDevice", null, new List<object>() { }) }, "BusInstallAndUinstallDevice", _ConstClassName + "._BusInstallAndUinstallDevice", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusInstallAndUinstallDeviceReport", null, new List<object>() { }) }, "BusInstallAndUinstallDeviceReport", _ConstClassName + "._BusInstallAndUinstallDeviceReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusSimCardChargeReport", null, new List<object>() { }) }, "BusSimCardChargeReport", _ConstClassName + "._BusSimCardChargeReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusBatteryChargeReport", null, new List<object>() { }) }, "BusBatteryChargeReport", _ConstClassName + "._BusBatteryChargeReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TotalPerformanceReport", null, new List<object>() { }) }, "TotalPerformanceReport", _ConstClassName + "._TotalPerformanceReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusSummaryPerformanceReport", null, new List<object>() { }) }, "BusSummaryPerformanceReport", _ConstClassName + "._BusSummaryPerformanceReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusTicketFailureTransactionSendReport", null, new List<object>() { }) }, "BusTicketFailureSendReport", _ConstClassName + "._BusTicketFailureTransactionSendReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusAvlFailureTransactionSendReport", null, new List<object>() { }) }, "BusAvlFailureSendReport", _ConstClassName + "._BusAvlFailureTransactionSendReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusFailureDoorsReport", null, new List<object>() { }) }, "BusFailureDoorsReport", _ConstClassName + "._BusFailureDoorsReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ConsulHistoryReport", null, new List<object>() { }) }, "ConsulHistoryReport", _ConstClassName + "._ConsulHistoryReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusTicketFailureBusNumberReport", null, new List<object>() { }) }, "BusTicketFailureBusNumberReport", _ConstClassName + "._BusTicketFailureBusNumberReport", JDomains.Images.MenuImages.BusManagmentReport, null));
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
            return nodes;
        }

        //_BusInstallAndUinstallDevice
        public string _BusInstallAndUinstallDevice()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
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

        public string _BusDeviceSettings()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusDeviceSettings"
                , "~/WebBusManagement/FormsManagement/JBusDeviceSettingsUpdateControl.ascx"
                , "تنظیمات اتوبوس"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
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

        public string _BusLastDataReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusLastDataReport"
                , "~/WebBusManagement/FormsMaintenance/JBusLastDataReportControl.ascx"
                , "گزارش آخرین اطلاعات دریافتی اتوبوس ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

    }
}