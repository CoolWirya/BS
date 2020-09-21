using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace WebAutomobile
{
    public class JWebAutomobile
    {

        public const string _ConstClassName = "WebAutomobile.JWebAutomobile";
        // Main Method
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._AutomobileType", null, new List<object>() { }) }, "AutomobileType", _ConstClassName, JDomains.Images.MenuImages.BusManagmentBus, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._MakerCompany", null, new List<object>() { }) }, "MakerCompany", _ConstClassName, JDomains.Images.MenuImages.BusManagmentBus, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._AutomobileDefine", null, new List<object>() { }) }, "AutomobileDefine", _ConstClassName, JDomains.Images.MenuImages.BusManagmentBus, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DeviceDefine", null, new List<object>() { }) }, "DeviceDefine", _ConstClassName, JDomains.Images.MenuImages.BusManagmentBus, null));
            return nodes;
        }

        public string _AutomobileType()
        {
            return JWebManager.GenerateClientWindow(WebControllers.MainControls.Grid.JSubDefine.GetSubDefineGrid(ClassLibrary.JBaseDefine.AutomobileType, "AutomobileType").GenerateWindow(false, false, false), true);
        }

        public string _MakerCompany()
        {
            return JWebManager.GenerateClientWindow(WebControllers.MainControls.Grid.JSubDefine.GetSubDefineGrid(ClassLibrary.JBaseDefine.MakerCompany, "MakerCompany").GenerateWindow(false, false, false), true);
        }

        public string _AutomobileDefine()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = AUTOMOBILE.AutomobileDefine.JAutomobileDefines.GetWebQuery();
            jGridView.Title = "AutomobileDefine";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._AutomobileDefineNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._AutomobileDefineUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._AutomobileDefineUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);

        }

        public string _AutomobileDefineNew()
        {
            return _AutomobileDefineNew(null);
        }
        public string _AutomobileDefineNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Fleets"
                , "~/WebAutomobile/Forms/JAutomobileDefineUpdateControl.ascx"
                , "ثبت اتومبیل"
                , null
                , WindowTarget.NewWindow
                , true, false, true, 600, 350);
        }
        public string _AutomobileDefineUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Fleets"
                , "~/WebAutomobile/Forms/JAutomobileDefineUpdateControl.ascx"
                , "ویرایش اتومبیل"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 600, 350);
        }


        public string _DeviceDefine()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = @"SELECT Code , ID , Tel , MacAddress , IMEI , CASE [Type] WHEN  1 THEN  N'کنسول' WHEN  2 THEN N'کارتخوان' END AS 'Type' FROM AUTDevice";
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

    }
}