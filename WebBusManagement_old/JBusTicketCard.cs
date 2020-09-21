using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace WebBusManagement
{
    public class JBusTicketCard
    {
        public const string _ConstClassName = "WebBusManagement.JBusTicketCard";
        // Main Method
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DeviceDefine", null, new List<object>() { }) }, "DeviceDefine", _ConstClassName + "._DeviceDefine", JDomains.Images.MenuImages.BusManagmentBus, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TicketCards", null, new List<object>() { }) }, "TicketCards", _ConstClassName + "._TicketCards", JDomains.Images.MenuImages.BusManagmentBus, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LastTicketTransactions", null, new List<object>() { }) }, "LastTicketTransactions", _ConstClassName + "._LastTicketTransactions", JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusPerformance", null, new List<object>() { }) }, "BusPerformance", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusTransaction", null, new List<object>() { }) }, "BusTransaction", _ConstClassName, JDomains.Images.MenuImages.BusManagmentReport, null));
            return nodes;
        }

        public string _DeviceDefine()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = "SELECT Code , ID , Tel , MacAddress , IMEI , CASE [Type] WHEN  1 THEN  N'کنسول' WHEN  2 THEN N'کارتخوان' END AS 'Type' FROM AUTDevice";
                //AUTOMOBILE.Device.JDevices.GetWebQuery();
            jGridView.Title = "DeviceDefine";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DeviceDefineNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DeviceDefineUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._DeviceDefineUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);

        }

        public string _DeviceDefineNew()
        {
            return _DeviceDefineNew(null);
        }
        public string _DeviceDefineNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Fleets"
                  , "~/WebAutomobile/Forms/JDeviceDefineUpdateControl.ascx"
                  , "ثبت دستگاه"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 350);
        }
        public string _DeviceDefineUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Fleets"
                   , "~/WebAutomobile/Forms/JDeviceDefineUpdateControl.ascx"
                   , "ویرایش دستگاه"
                   , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                   , WindowTarget.NewWindow
                   , true, false, true, 600, 350);
        }

        //_TicketCards Not Complate
        public string _TicketCards()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = @"SELECT TOP 100 PERCENT 
                                c.Code,c.RfidNumber,cap.Name,case c.[STATUS] WHEN 1 THEN N'فعال' ELSE N'غير فعال' END AS [STATUS],
                                c.[DESCRIPTION],c.[PassengerCardType] 
                                FROM Cards c 
                                LEFT JOIN clsAllPerson cap ON cap.Code = c.PCode";
            jGridView.Title = "TicketCard";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TicketCardsNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TicketCardsUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._TicketCardsUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);

        }

        public string _TicketCardsNew()
        {
            return _TicketCardsNew(null);
        }
        public string _TicketCardsNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("TicketCard"
                   , "~/WebBusManagement/FormsManagement/JTicketCardUpdateControl.ascx"
                   , "ثبت کارت بلیط"
                   , null
                   , WindowTarget.NewWindow
                   , true, false, true, 600, 350);
        }
        public string _TicketCardsUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("TicketCard"
                  , "~/WebBusManagement/FormsManagement/JTicketCardUpdateControl.ascx"
                  , "ویرایش کارت بلیط"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 350);
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

        public string _BusTransaction()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusTransaction"
                , "~/WebBusManagement/FormsReports/JBusTransactionReportControl.ascx"
                , "گزارش تراکنش اتوبوس ها"
                , null
                , WindowTarget.NewWindow
                , false, true, true, 0, 0, true);
        }



    }
}