using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace WebBusManagement
{
    public class JBusRTPIS
    {
        public const string _ConstClassName = "WebBusManagement.JBusRTPIS";
        // Main Method
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._RTPISText", null, new List<object>() { }) }, "RTPISText", _ConstClassName + "._RTPISText", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusPassingStationReport", null, new List<object>() { }) }, "BusPassingStationReport", _ConstClassName + "._BusPassingStationReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._RTPISReport", null, new List<object>() { }) }, "RTPISReport", _ConstClassName + "._RTPISReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._RTPISUpdateBoardReportControl", null, new List<object>() { }) }, "RTPISUpdateBoardReportControl", _ConstClassName + "._RTPISUpdateBoardReportControl", JDomains.Images.MenuImages.BusManagmentReport, null));
            return nodes;
        }

        public string _RTPISUpdateBoardReportControl()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("RTPISUpdateBoardReportControl"
                , "~/WebBusManagement/FormsReports/JRTPISUpdateBoardReportControl.ascx"
                , "بروز رسانی برد RTPIS"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _RTPISReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("RTPISReport"
                , "~/WebBusManagement/FormsReports/JRTPISReportControl.ascx"
                , "گزارش آر تی پی آی اس"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        public string _BusPassingStationReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusPassingStation"
                , "~/WebBusManagement/FormsReports/JBusPassingStationReportControl.ascx"
                , "گزارش عبور از ایستگاه اتوبوس ها"
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

    }
}