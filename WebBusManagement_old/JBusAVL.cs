using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace WebBusManagement
{
    public class JBusAVL
    {
        public const string _ConstClassName = "WebBusManagement.JBusAVL";
        // Main Method
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ShowOnlineMap", null, new List<object>() { }) }, "ShowOnlineMap", _ConstClassName + "._ShowOnlineMap", JDomains.Images.MenuImages.BusManagmentMap, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ShowViewMap", null, new List<object>() { }) }, "ShowViewMap", _ConstClassName + "._ShowViewMap", JDomains.Images.MenuImages.BusManagmentMap, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ShowLinePathMap", null, new List<object>() { }) }, "ShowLinePathMap", _ConstClassName + "._ShowLinePathMap", JDomains.Images.MenuImages.BusManagmentMap, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LastAVLTransactions", null, new List<object>() { }) }, "LastAVLTransactions", _ConstClassName + "._LastAVLTransactions", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusRetardationReport", null, new List<object>() { }) }, "BusRetardationReport", _ConstClassName + "._BusRetardationReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusSendAvlTransenctionReport", null, new List<object>() { }) }, "BusSendAvlTransenctionReport", _ConstClassName + "._BusSendAvlTransenctionReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusAvlTransenctionReport", null, new List<object>() { }) }, "BusAvlTransenctionReport", _ConstClassName + "._BusAvlTransenctionReport", JDomains.Images.MenuImages.BusManagmentReport, null));
            return nodes;
        }
        public string _ShowOnlineMap()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OnlineMap", "~/WebBusManagement/FormsManagement/JOnlineMap.ascx", "نقشه آنلاین", null, WindowTarget.NewWindow, true, true, true);
        }

        public string _ShowViewMap()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("ViewMap", "~/WebBusManagement/FormsManagement/JViewMap.ascx", "نقشه مشاهده مسیر", null, WindowTarget.NewWindow, true, true, true);
        }

        public string _ShowLinePathMap()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("LineMap", "~/WebBusManagement/FormsManagement/JLinePathMap.ascx", "نقشه مشاهده مسیر خطوط", null, WindowTarget.NewWindow, true, true, true);
        }

        public string _LastAVLTransactions()
        {
            string SUID = "BusManagement_LastAVLTransactions";
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(SUID);
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

        public string _BusRetardationReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusRetardation"
                  , "~/WebBusManagement/FormsReports/JBusRetardationReportControl.ascx"
                  , "گزارش تخلفات اتوبوس"
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

        public string _BusAvlTransenctionReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusAvlTransenctionReport"
                , "~/WebBusManagement/FormsReports/JBusAvlTransenctionReportControl.ascx"
                , "گزارش تراکنش های AVL"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }

        

    }
}