using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace WebBusMaintenance
{
    public class JBusMaintenance
    {

        public const string _ConstClassName = "WebBusMaintenance.JBusMaintenance";
        // Main Method
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusSimCardChargeReport", null, new List<object>() { }) }, "BusSimCardChargeReport", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusBatteryChargeReport", null, new List<object>() { }) }, "BusBatteryChargeReport", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TotalPerformanceReport", null, new List<object>() { }) }, "TotalPerformanceReport", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusSummaryPerformanceReport", null, new List<object>() { }) }, "BusSummaryPerformanceReport", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusTicketFailureTransactionSendReport", null, new List<object>() { }) }, "BusTicketFailureSendReport", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusAvlFailureTransactionSendReport", null, new List<object>() { }) }, "BusAvlFailureSendReport", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusFailureDoorsReport", null, new List<object>() { }) }, "BusFailureDoorsReport", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ConsulHistoryReport", null, new List<object>() { }) }, "ConsulHistoryReport", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusTicketFailureBusNumberReport", null, new List<object>() { }) }, "BusTicketFailureBusNumberReport", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusFailureDeviceIMEIReport", null, new List<object>() { }) }, "BusFailureDeviceIMEIReport", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusUsedSimCardChargeReport", null, new List<object>() { }) }, "BusUsedSimCardChargeReport", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusNotActiveReport", null, new List<object>() { }) }, "BusNotActiveReport", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusSummaryTransactionReport", null, new List<object>() { }) }, "BusSummaryTransactionReport", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusSendTicketTransenctionReport", null, new List<object>() { }) }, "BusSendTicketTransenctionReport", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusSendAvlTransenctionReport", null, new List<object>() { }) }, "BusSendAvlTransenctionReport", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusErrorDateTransactionReport", null, new List<object>() { }) }, "BusErrorDateTransactionReport", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusErrorSendTransactionReport", null, new List<object>() { }) }, "BusErrorSendTransactionReport", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PortalLastDataReport", null, new List<object>() { }) }, "PortalLastDataReport", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusLastDataReport", null, new List<object>() { }) }, "BusLastDataReport", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            return nodes;
        }

        public string _BusSimCardChargeReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusSimCardCharge"
                , "~/WebBusMaintenance/Forms/JBusSimCardChargeReportControl.ascx"
                , "گزارش شارژ سیم کارت ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusBatteryChargeReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusBatteryCharge"
                , "~/WebBusMaintenance/Forms/JBusBatteryChargeReportControl.ascx"
                , "گزارش وضعیت شارژ باتری دستگاه ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _TotalPerformanceReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("TotalPerformance"
                , "~/WebBusMaintenance/Forms/JTotalPerformanceReportControl.ascx"
                , "گزارش خلاصه وضعیت کارکرد"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusSummaryPerformanceReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusSummaryPerformance"
                , "~/WebBusMaintenance/Forms/JBusSummaryPerformanceReportControl.ascx"
                , "گزارش خلاصه کارکرد اتوبوس"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusTicketFailureTransactionSendReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusTicketFailureTransactionSend"
                , "~/WebBusMaintenance/Forms/JBusTicketFailureTransactionSendReportControl.ascx"
                , "گزارش عدم ارسال تراکنش بلیط"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusAvlFailureTransactionSendReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusAvlFailureTransactionSend"
                , "~/WebBusMaintenance/Forms/JBusAvlFailureTransactionSendReportControl.ascx"
                , "گزارش عدم ارسال تراکنش AVL"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusFailureDoorsReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusFailureDoors"
                , "~/WebBusMaintenance/Forms/JBusFailureDoorsReportControl.ascx"
                , "گزارش عدم ارسال تراکنش دو درب"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _ConsulHistoryReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("ConsulHistory"
                , "~/WebBusMaintenance/Forms/JConsulHistoryReportControl.ascx"
                , "گزارش تاریخچه ی کنسول ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusTicketFailureBusNumberReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusTicketFailureBusNumber"
                , "~/WebBusMaintenance/Forms/JBusTicketFailureBusNumberReportControl.ascx"
                , "گزارش شماره اتوبوس های نامعتبر در تراکنش های بلیط"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusFailureDeviceIMEIReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusFailureDeviceIMEI"
                , "~/WebBusMaintenance/Forms/JBusFailureDeviceIMEIReportControl.ascx"
                , "گزارش اختلاف بین IMEI ثبت شده برای اتوبوس و اطلاعات رسیده از کنسول"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusUsedSimCardChargeReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusUsedSimCardCharge"
                , "~/WebBusMaintenance/Forms/JBusUsedSimCardChargeReportControl.ascx"
                , "گزارش مصرف شارژ سیم کارت اتوبوس ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusNotActiveReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusNotActiveReport"
                , "~/WebBusMaintenance/Forms/JBusNotActiveReportControl.ascx"
                , "گزارش عدم فعالسازی اتوبوس ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusSummaryTransactionReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusSummaryTransactionReport"
                , "~/WebBusMaintenance/Forms/JBusSummaryTransactionReportControl.ascx"
                , "گزارش خلاصه تراکنش های انجام شده اتوبوس"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusSendTicketTransenctionReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusSendTicketTransenctionReport"
                , "~/WebBusMaintenance/Forms/JBusSendTicketTransenctionReportControl.ascx"
                , "گزارش ارسال تراکنش بلیط اتوبوس ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }
        
        public string _BusSendAvlTransenctionReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusSendAvlTransenctionReport"
                , "~/WebBusMaintenance/Forms/JBusSendAvlTransenctionReportControl.ascx"
                , "گزارش ارسال تراکنش AVL اتوبوس ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusErrorDateTransactionReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusErrorDateTransactionReport"
                , "~/WebBusMaintenance/Forms/JBusErrorDateTransactionReportControl.ascx"
                , "گزارش خطای تاریخ"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusErrorSendTransactionReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusErrorSendTransactionReport"
                , "~/WebBusMaintenance/Forms/JBusErrorSendTransactionReportControl.ascx"
                , "گزارش خطای ارسال"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _PortalLastDataReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("PortalLastDataReport"
                , "~/WebBusMaintenance/Forms/JPortalLastDataReportControl.ascx"
                , "گزارش آخرین اطلاعات دریافتی پرتال"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusLastDataReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusLastDataReport"
                , "~/WebBusMaintenance/Forms/JBusLastDataReportControl.ascx"
                , "گزارش آخرین اطلاعات دریافتی اتوبوس ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

    }
}