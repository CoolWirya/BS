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

            nodes.Add(new JNode(null, "Map", _ConstClassName, JDomains.Images.MenuImages.Folder, new List<JNode> 
            {
                //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ShowOnlineMap", null, new List<object>() { }) }, "ShowOnlineMap", _ConstClassName + "._ShowOnlineMap", JDomains.Images.MenuImages.BusManagmentMap, null));
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ShowOnlineMapNew", null, new List<object>() { }) }, "ShowOnlineMapNew", _ConstClassName + "._ShowOnlineMapNew", JDomains.Images.MenuImages.BusManagmentMap, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ShowViewMap", null, new List<object>() { }) }, "ShowViewMap", _ConstClassName + "._ShowViewMap", JDomains.Images.MenuImages.BusManagmentMap, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ShowLinePathMap", null, new List<object>() { }) }, "ShowLinePathMap", _ConstClassName + "._ShowLinePathMap", JDomains.Images.MenuImages.BusManagmentMap, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OnlinePath", null, new List<object>() { }) }, "OnlinePath", _ConstClassName + "._OnlinePath", JDomains.Images.MenuImages.BusManagmentMap, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LastAVLTransactions", null, new List<object>() { }) }, "LastAVLTransactions", _ConstClassName + "._LastAVLTransactions", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._MapSetting", null, new List<object>() { }) }, "MapSetting", "WebBusManagement.JBusManagement._MapSetting", JDomains.Images.MenuImages.BusManagmentReport, null),
            }));
            nodes.Add(new JNode(null, "Message", _ConstClassName, JDomains.Images.MenuImages.Folder, new List<JNode> 
            {
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SendMessageToConsole", null, new List<object>() { }) }, "SendMessageToConsole", _ConstClassName + "._SendMessageToConsole", JDomains.Images.MenuImages.BusManagmentBus, null),
            }));

            nodes.Add(new JNode(null, "Reports", _ConstClassName, JDomains.Images.MenuImages.Folder, new List<JNode> 
            {
                //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusRetardationReport", null, new List<object>() { }) }, "BusRetardationReport", _ConstClassName + "._BusRetardationReport", JDomains.Images.MenuImages.BusManagmentReport, null));
                //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusSendAvlTransenctionReport", null, new List<object>() { }) }, "BusSendAvlTransenctionReport", _ConstClassName + "._BusSendAvlTransenctionReport", JDomains.Images.MenuImages.BusManagmentReport, null));
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusAvlTransenctionReport", null, new List<object>() { }) }, "BusAvlTransenctionReport", _ConstClassName + "._BusAvlTransenctionReport", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusSpeedAverageReport", null, new List<object>() { }) }, "BusSpeedAverageReport", _ConstClassName + "._BusSpeedAverageReport", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LineSpeedAverageReport", null, new List<object>() { }) }, "LineSpeedAverageReport", _ConstClassName + "._LineSpeedAverageReport", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DistanceMesureReport", null, new List<object>() { }) }, "DistanceMesureReport", _ConstClassName + "._DistanceMesureReport", JDomains.Images.MenuImages.BusManagmentReport, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._NoAVLBusesReport", null, new List<object>() { }) }, "NoAVLBusesReport", _ConstClassName + "._NoAVLBusesReport", JDomains.Images.MenuImages.BusManagmentReport, null),
                //new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusAVLCutReport", null, new List<object>() { }) }, "BusAVLCutReport", _ConstClassName + "._BusAVLCutReport", JDomains.Images.MenuImages.BusManagmentReport, null),
                //new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusInputOutputLine", null, new List<object>() { }) }, "BusInputOutputLine", _ConstClassName + "._BusInputOutputLine", JDomains.Images.MenuImages.BusManagmentReport, null),
            }));
            return nodes;
        }
        public string _BusAVLCutReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusAVLCutReport"
                 , "~/WebBusManagement/FormsReports/JBusAVLCutReportControl.ascx"
                 , "گزارش قطعی AVL اتوبوس ها"
                 , null
                 , WindowTarget.NewWindow
                 , false, true, true, 0, 0, true);

        }
        public string _NoAVLBusesReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("NoAVLBusesReport"
                 , "~/WebBusManagement/FormsReports/JNoAVLBusesReportControl.ascx"
                 , "گزارش اتوبوس های بدون تراکنش AVL"
                 , null
                 , WindowTarget.NewWindow
                 , false, true, true, 0, 0, true);

        }
        public string _MapSetting()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("MapSetting"
                 , "~/WebBusManagement/FormsManagement/JMapSetting.ascx"
                 , "تنظیمات نقشه"
                 , null
                 , WindowTarget.NewWindow
                 , false, true, true, 0, 0, true);

        }
        //_SendMessageToConsole

        public string _SendMessageToConsole()
        {
           WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_SendMessageToConsole";
            jGridView.SQL = @"SELECT ACM.[Code]
                                  ,[BusNumber]
                                  ,[MessageText]
                                  ,[UserCode]
	                              ,Cap.Name UserName
                                  ,[InsertDate]
                              FROM [dbo].[AutConsoleMessage] ACM
                              left join clsAllPerson cap on cap.Code = ACM.UserCode";
            jGridView.Title = "SendMessageToConsole";
            jGridView.PageOrderByField = "Code Desc";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SendMessageToConsoleNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            //jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SendMessageToConsoleUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            //jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            // jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._SendMessageToConsoleUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _SendMessageToConsoleNew()
        {
            return _SendMessageToConsoleNew(null);
        }
        public string _SendMessageToConsoleNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("SendMessageToConsole"
                 , "~/WebBusManagement/FormsManagement/JSendMessageToConsoleUpdateControl.ascx"
                 , "ارسال پیام برای اتوبوس"
                 , null
                 , WindowTarget.NewWindow
                 , true, false, true, 700, 500);
        }
        //public string _SendMessageToConsoleUpdate(string code)
        //{
        //    return WebClassLibrary.JWebManager.LoadClientControl("SendMessageToConsole"
        //          , "~/WebBusManagement/FormsManagement/JSendMessageToConsoleUpdateControl.ascx"
        //          , "ارسال پیام برای اتوبوس"
        //          , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
        //          , WindowTarget.NewWindow
        //          , true, false, true, 700, 500);
        //}

        public string _ShowOnlineMapNew()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OnlineMap", "~/WebBusManagement/FormsManagement/JOnlineMapNew.ascx", "نقشه آنلاین نسخه جدید", null, WindowTarget.NewWindow, true, true, true);
        }

        public string _ShowOnlineMap()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OnlineMap", "~/WebBusManagement/FormsManagement/JOnlineMap.ascx", "نقشه آنلاین", null, WindowTarget.NewWindow, true, true, true);
        }

        public string _ShowViewMap()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("ViewMap", "~/WebBusManagement/FormsManagement/JViewMap.ascx", "نقشه مشاهده مسیر", null, WindowTarget.NewWindow, true, true, true);
        }

        public string _OnlinePath()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OnlinePath", "~/WebBusManagement/FormsManagement/JOnlinePath.ascx", "مسیر خطوط", null, WindowTarget.NewWindow, true, true, true);
        }

        public string _ShowLinePathMap()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("LineMap", "~/WebBusManagement/FormsManagement/JLinePathMap.ascx", "نقشه مشاهده مسیر خطوط", null, WindowTarget.NewWindow, true, true, true);
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

        public string _BusRetardationReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusRetardation"
                  , "~/WebBusManagement/FormsReports/JBusRetardationReportControl.ascx"
                  , "گزارش تخلفات اتوبوس"
                  , null
                  , WindowTarget.NewWindow
                  , false, true, true, 0, 0, true);
        }



        public string _LineSpeedAverageReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("LineSpeedAverage"
                  , "~/WebBusManagement/FormsReports/JLineSpeedAverageReportControl.ascx"
                  , "گزارش متوسط سرعت خطوط"
                  , null
                  , WindowTarget.NewWindow
                  , false, true, true, 0, 0, true);
        }


        public string _BusInputOutputLine()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusInputOutputLine"
                  , "~/WebBusManagement/FormsReports/JBusInputOutputLine.ascx"
                  , "گزارش ورود و خروج اتوبوس از خط"
                  , null
                  , WindowTarget.NewWindow
                  , false, true, true, 0, 0, true);
        }

        
        public string _DistanceMesureReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("DistanceMesure"
                  , "~/WebBusManagement/FormsReports/JDistanceMesureReportControl.ascx"
                  , "گزارش مسافت های طی شده"
                  , null
                  , WindowTarget.NewWindow
                  , false, true, true, 0, 0, true);
        }


        public string _BusSpeedAverageReport()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusSpeedAverage"
                  , "~/WebBusManagement/FormsReports/JBusSpeedAverageReportControl.ascx"
                  , "گزارش متوسط سرعت اتوبوس ها"
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