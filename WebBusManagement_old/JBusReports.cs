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
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DriverPerformance", null, new List<object>() { }) }, "DriverPerformance", _ConstClassName + "._DriverPerformance", JDomains.Images.MenuImages.BusManagmentReport, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusTransaction", null, new List<object>() { }) }, "BusTransaction", _ConstClassName + "._BusTransaction", JDomains.Images.MenuImages.BusManagmentReport, null));

            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DriverServices", null, new List<object>() { }) }, "DriverServices", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DriverCrossingFromStop", null, new List<object>() { }) }, "DriverCrossingFromStop", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DriverTrepassFromLine", null, new List<object>() { }) }, "DriverTrepassFromLine", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DocumentAndPayment", null, new List<object>() { }) }, "DocumentAndPayment", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ZonesStatisticalReport", null, new List<object>() { }) }, "ZonesStatisticalReport", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LinesStatisticalReport", null, new List<object>() { }) }, "LinesStatisticalReport", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusStatisticalReport", null, new List<object>() { }) }, "BusStatisticalReport", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DriverStatisticalReport", null, new List<object>() { }) }, "DriverStatisticalReport", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DailyStatisticalReport", null, new List<object>() { }) }, "DailyStatisticalReport", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            return nodes;
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

        public string _LastTicketTransactions()
        {
            string SUID = "BusManagement_LastTicketTransactions";
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(SUID);
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
            return WebClassLibrary.JWebManager.LoadClientControl("BusPerformance"
                  , "~/WebBusManagement/FormsReports/JBusPerformanceReportControl.ascx"
                  , "گزارش کارکرد اتوبوس"
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