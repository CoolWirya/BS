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
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DailyStatisticalReport", null, new List<object>() { }) }, "DailyStatisticalReport", _ConstClassName + "._DailyStatisticalReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            return nodes;
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

    }
}