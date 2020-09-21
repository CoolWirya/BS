using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace WebBusManagement
{
    public class JBusStatisticalReports
    {
        public const string _ConstClassName = "WebBusManagement.JBusStatisticalReports";
        // Main Method
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ZonesStatisticalReport", null, new List<object>() { }) }, "ZonesStatisticalReport", _ConstClassName + "._ZonesStatisticalReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LinesStatisticalReport", null, new List<object>() { }) }, "LinesStatisticalReport", _ConstClassName + "._LinesStatisticalReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusStatisticalReport", null, new List<object>() { }) }, "BusStatisticalReport", _ConstClassName + "._BusStatisticalReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DriverStatisticalReport", null, new List<object>() { }) }, "DriverStatisticalReport", _ConstClassName + "._DriverStatisticalReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._HourStatisticalReport", null, new List<object>() { }) }, "HourStatisticalReport", _ConstClassName + "._HourStatisticalReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DailyStatisticalReport", null, new List<object>() { }) }, "DailyStatisticalReport", _ConstClassName + "._DailyStatisticalReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._AvlTransactionStatisticalReport", null, new List<object>() { }) }, "AvlTransactionStatisticalReport", _ConstClassName + "._AvlTransactionStatisticalReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TicketTransactionStatisticalReport", null, new List<object>() { }) }, "TicketTransactionStatisticalReport", _ConstClassName + "._TicketTransactionStatisticalReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._YearMonthsStatisticalReport", null, new List<object>() { }) }, "YearMonthsStatisticalReport", _ConstClassName + "._YearMonthsStatisticalReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JWeekDaysStatisticalReport", null, new List<object>() { }) }, "WeekDaysStatisticalReport", _ConstClassName + "._JWeekDaysStatisticalReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._YearStatisticalReport", null, new List<object>() { }) }, "YearStatisticalReport", _ConstClassName + "._YearStatisticalReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._MultiYearMonthsStatisticalReport", null, new List<object>() { }) }, "MultiYearMonthsStatisticalReport", _ConstClassName + "._MultiYearMonthsStatisticalReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusServicesStatisticalReport", null, new List<object>() { }) }, "BusServicesStatisticalReport", _ConstClassName + "._BusServicesStatisticalReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusServicesZoneStatisticalReport", null, new List<object>() { }) }, "BusServicesZoneStatisticalReport", _ConstClassName + "._BusServicesZoneStatisticalReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusServicesLineStatisticalReport", null, new List<object>() { }) }, "BusServicesLineStatisticalReport", _ConstClassName + "._BusServicesLineStatisticalReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusServicesBusStatisticalReport", null, new List<object>() { }) }, "BusServicesBusStatisticalReport", _ConstClassName + "._BusServicesBusStatisticalReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusMinMaxServiceStatisticalReport", null, new List<object>() { }) }, "BusMinMaxServiceStatisticalReport", _ConstClassName + "._BusMinMaxServiceStatisticalReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            return nodes;
        }

        public string _BusServicesBusStatisticalReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusServicesBusStatisticalReport"
                , "~/WebBusManagement/FormsStatisticalReports/JBusServicesBusStatisticalReportControl.ascx"
                , "گزارش آماری سرویس های اتوبوس ها بر اساس اتوبوس در بازه زمانی"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        //_BusMinMaxServiceStatisticalReport
        public string _BusMinMaxServiceStatisticalReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusMinMaxServiceStatisticalReport"
                , "~/WebBusManagement/FormsStatisticalReports/JBusMinMaxServiceStatisticalReportControl.ascx"
                , "گزارش کمترین و بیشترین سرویس اتوبوس ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        //_BusServicesLineStatisticalReport
        public string _BusServicesLineStatisticalReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusServicesLineStatisticalReport"
                , "~/WebBusManagement/FormsStatisticalReports/JBusServicesLineStatisticalReportControl.ascx"
                , "گزارش آماری سرویس های اتوبوس ها بر اساس خط در بازه زمانی"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        //BusServicesLineZoneStatisticalReport
        public string _BusServicesZoneStatisticalReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusServicesZoneStatisticalReport"
                , "~/WebBusManagement/FormsStatisticalReports/JBusServicesZoneStatisticalReportControl.ascx"
                , "گزارش آماری سرویس های اتوبوس ها بر اساس منطقه در بازه زمانی"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        //_BusServicesStatisticalReport
        public string _BusServicesStatisticalReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusServicesStatisticalReport"
                , "~/WebBusManagement/FormsStatisticalReports/JBusServicesStatisticalReportControl.ascx"
                , "گزارش آماری سرویس های اتوبوس ها در بازه زمانی"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _MultiYearMonthsStatisticalReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("MultiYearMonthsStatisticalReport"
                , "~/WebBusManagement/FormsStatisticalReports/JMultiYearMonthsStatisticalReportControl.ascx"
                , "گزارش آماری مقایسه تراکنش و درآمد در ماه های سال های مختلف"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        //_YearStatisticalReport
        public string _YearStatisticalReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("YearStatisticalReport"
                , "~/WebBusManagement/FormsStatisticalReports/JYearStatisticalReportControl.ascx"
                , "گزارش آماری مقایسه تراکنش و درآمد در سال های مختلف"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        //_YearMonthsStatisticalReport
        public string _YearMonthsStatisticalReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("YearMonthsStatisticalReport"
                , "~/WebBusManagement/FormsStatisticalReports/JYearMonthsStatisticalReportControl.ascx"
                , "گزارش آماری مقایسه تراکنش و درآمد در ماه های مختلف سال"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _JWeekDaysStatisticalReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("WeekDaysStatisticalReport"
                , "~/WebBusManagement/FormsStatisticalReports/JWeekDaysStatisticalReportControl.ascx"
                , "گزارش آماری مقایسه تراکنش و درآمد در روزهای مختلف هفته"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _ZonesStatisticalReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("ZonesStatisticalReport"
                , "~/WebBusManagement/FormsStatisticalReports/JZonesStatisticalReportControl.ascx"
                , "گزارش آماری مناطق"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _LinesStatisticalReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("LinesStatisticalReport"
                , "~/WebBusManagement/FormsStatisticalReports/JLinesStatisticalReportControl.ascx"
                , "گزارش آماری خطوط"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }


        public string _BusStatisticalReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusStatisticalReport"
                , "~/WebBusManagement/FormsStatisticalReports/JBusStatisticalReportControl.ascx"
                , "گزارش آماری اتوبوس ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _DriverStatisticalReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("DriverStatisticalReport"
                , "~/WebBusManagement/FormsStatisticalReports/JDriverStatisticalReportControl.ascx"
                , "گزارش آماری رانندگان"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _HourStatisticalReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("HourStatisticalReport"
               , "~/WebBusManagement/FormsStatisticalReports/JHourStatisticalReportControl.ascx"
               , "گزارش آماری ساعتی"
               , null
               , WindowTarget.NewWindow
               , false, true, true, 0, 0, true);
        }

        public string _DailyStatisticalReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("DailyStatisticalReport"
               , "~/WebBusManagement/FormsStatisticalReports/JDailyStatisticalReportControl.ascx"
               , "گزارش آماری روزانه"
               , null
               , WindowTarget.NewWindow
               , false, true, true, 0, 0, true);
        }

        public string _AvlTransactionStatisticalReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("AvlTransactionStatisticalReport"
               , "~/WebBusManagement/FormsStatisticalReports/JAvlTransactionStatisticalReportControl.ascx"
               , "گزارش آماری تعداد تراکنش های AVL"
               , null
               , WindowTarget.NewWindow
               , false, true, true, 0, 0, true);
        }

        public string _TicketTransactionStatisticalReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("TicketTransactionStatisticalReport"
               , "~/WebBusManagement/FormsStatisticalReports/JTicketTransactionStatisticalReportControl.ascx"
               , "گزارش آماری تعداد تراکنش های بلیط"
               , null
               , WindowTarget.NewWindow
               , false, true, true, 0, 0, true);
        }

    }
}