using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace WebBusManagement
{
    public class JBusTariff
    {
        public const string _ConstClassName = "WebBusManagement.JBusTariff";
        // Main Method
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Tariff", null, new List<object>() { }) }, "Tariff", _ConstClassName + "._Tariff", JDomains.Images.MenuImages.BusManagmentTarrif, null));
            return nodes;
        }

        //_Tariff
        public string _Tariff()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = BusManagment.WorkOrder.JTariffs.GetWebQuery();
            jGridView.Title = "Tariff";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TariffNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TariffUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._TariffUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _TariffNew()
        {
            return _TariffNew(null);
        }
        public string _TariffNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Tariff"
                 , "~/WebBusManagement/FormsManagement/JTariffUpdateControl.ascx"
                 , "تعرفه"
                 , null
                 , WindowTarget.NewWindow
                 , true, false, true, 600, 350);
        }
        public string _TariffUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Tariff"
                  , "~/WebBusManagement/FormsManagement/JTariffUpdateControl.ascx"
                  , "تعرفه"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 350);
        }

    }
}