using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace WebOilManagement
{
    public class JWebOilManagement
    {

        public const string _ConstClassName = "WebOilManagement.JWebOilManagement";
        // Main Method
        public List<JNode> GetNodes()
        {
            string _WebBaseDefineConstClassName = "WebBaseDefine.JWebBaseDefine";

            List<JNode> nodes = new List<JNode>();
            nodes.Add(new JNode(null, "مدیریت اشخاص و کاربران", _ConstClassName, JDomains.Images.MenuImages.Folder, new List<JNode> 
            {
            new JNode(null, "DefinePersons", _ConstClassName, JDomains.Images.MenuImages.Folder, new List<JNode> 
            {
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _WebBaseDefineConstClassName + "._RealPerson", null, new List<object>() { }) }, "RealPersons", _ConstClassName, JDomains.Images.MenuImages.Item, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _WebBaseDefineConstClassName + "._LegalPerson", null, new List<object>() { }) }, "LegalPersons", _ConstClassName, JDomains.Images.MenuImages.Item, null),
            }),
            new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _WebBaseDefineConstClassName + "._User", null, new List<object>() { }) }, "Users", _ConstClassName, JDomains.Images.MenuImages.Item, null),
            new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _WebBaseDefineConstClassName + "._OrganizationChart", null, new List<object>() { }) }, "OrganizationChart", _ConstClassName, JDomains.Images.MenuImages.Item, null)
            }));
            nodes.Add(new JNode(null, "مدیریت حوزه ها، مناطق و نواحی، ", _ConstClassName, JDomains.Images.MenuImages.Folder, new List<JNode> 
            {
            new JNode(null, "BaseDefine", _ConstClassName, JDomains.Images.MenuImages.Folder, new List<JNode> 
            {
            new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PlaceOfSupply", null, new List<object>() { }) }, "PlaceOfSupply", _ConstClassName, JDomains.Images.MenuImages.BusManagmentTarrif, null),
            new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TypeOfFuelTank", null, new List<object>() { }) }, "TypeOfFuelTank", _ConstClassName, JDomains.Images.MenuImages.BusManagmentTarrif, null),
            new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TypeOfProduct", null, new List<object>() { }) }, "TypeOfProduct", _ConstClassName, JDomains.Images.MenuImages.BusManagmentTarrif, null),
            new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TypeOfSupply", null, new List<object>() { }) }, "TypeOfSupply", _ConstClassName, JDomains.Images.MenuImages.BusManagmentTarrif, null),
            new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TypeOfMalfunction", null, new List<object>() { }) }, "TypeOfMalfunction", _ConstClassName, JDomains.Images.MenuImages.BusManagmentTarrif, null),
            new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TypesOfPump", null, new List<object>() { }) }, "TypesOfPump", _ConstClassName, JDomains.Images.MenuImages.BusManagmentTarrif, null)
            }),
            new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilDistrict", null, new List<object>() { }) }, "OilDistrict", _ConstClassName, JDomains.Images.MenuImages.BusManagmentTarrif, null),
            new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilZone", null, new List<object>() { }) }, "OilZone", _ConstClassName, JDomains.Images.MenuImages.BusManagmentTarrif, null),
            new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilArea", null, new List<object>() { }) }, "OilArea", _ConstClassName, JDomains.Images.MenuImages.BusManagmentTarrif, null),
            new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Seal", null, new List<object>() { }) }, "Seal", _ConstClassName, JDomains.Images.MenuImages.BusManagmentTarrif, null),
            new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._RPM", null, new List<object>() { }) }, "RPM", _ConstClassName, JDomains.Images.MenuImages.BusManagmentTarrif, null)
            }));
            return nodes;
        }

        public string _PlaceOfSupply()
        {
            return JWebManager.GenerateClientWindow(WebControllers.MainControls.Grid.JSubDefine.GetSubDefineGrid(OilProductsDistributionCompany.JDefine.PlaceOfSupply, "PlaceOfSupply").GenerateWindow(false, false, false), true);
        }
        public string _TypeOfFuelTank()
        {
            return JWebManager.GenerateClientWindow(WebControllers.MainControls.Grid.JSubDefine.GetSubDefineGrid(OilProductsDistributionCompany.JDefine.TypeOfFuelTank, "TypeOfFuelTank").GenerateWindow(false, false, false), true);
        }
        public string _TypeOfProduct()
        {
            return JWebManager.GenerateClientWindow(WebControllers.MainControls.Grid.JSubDefine.GetSubDefineGrid(OilProductsDistributionCompany.JDefine.TypeOfProduct, "TypeOfProduct").GenerateWindow(false, false, false), true);
        }
        public string _TypeOfSupply()
        {
            return JWebManager.GenerateClientWindow(WebControllers.MainControls.Grid.JSubDefine.GetSubDefineGrid(OilProductsDistributionCompany.JDefine.TypeOfSupply, "TypeOfSupply").GenerateWindow(false, false, false), true);
        }
        public string _TypeOfMalfunction()
        {
            return JWebManager.GenerateClientWindow(WebControllers.MainControls.Grid.JSubDefine.GetSubDefineGrid(OilProductsDistributionCompany.JDefine.TypeOfMalfunction, "TypeOfMalfunction").GenerateWindow(false, false, false), true);
        }
        public string _TypesOfPump()
        {
            return JWebManager.GenerateClientWindow(WebControllers.MainControls.Grid.JSubDefine.GetSubDefineGrid(OilProductsDistributionCompany.JDefine.TypeOfPumps, "TypeOfPumps").GenerateWindow(false, false, false), true);
        }

        public string _OilDistrict()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = OilProductsDistributionCompany.Zone.JOilDistrictes.GetWebQuery();
            jGridView.Title = "OilDistrict";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilDistrictNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilDistrictUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._OilDistrictUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _OilDistrictNew()
        {
            return _OilDistrictNew(null);
        }
        public string _OilDistrictNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OilDistrict"
                , "~/WebOilManagement/Forms/JOilDistrictUpdateControl.ascx"
                , ClassLibrary.JLanguages._Text("JWebOilManagement")
                , null
                , WindowTarget.NewWindow
                , true, false, true, 600, 200);
        }
        public string _OilDistrictUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OilDistrict"
                , "~/WebOilManagement/Forms/JOilDistrictUpdateControl.ascx"
                , ClassLibrary.JLanguages._Text("JWebOilManagement")
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 600, 200);
        }

        public string _OilZone()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = OilProductsDistributionCompany.Zone.JOliZonees.GetWebQuery();
            jGridView.Title = "OilZone";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilZoneNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilZoneUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._OilZoneUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _OilZoneNew()
        {
            return _OilZoneNew(null);
        }
        public string _OilZoneNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OilZone"
                , "~/WebOilManagement/Forms/JOilZoneUpdateControl.ascx"
                , ClassLibrary.JLanguages._Text("JWebOilManagement")
                , null
                , WindowTarget.NewWindow
                , true, false, true, 600, 200);
        }
        public string _OilZoneUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OilZone"
                , "~/WebOilManagement/Forms/JOilZoneUpdateControl.ascx"
                , ClassLibrary.JLanguages._Text("JWebOilManagement")
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 600, 200);
        }

        //_OilArea
        public string _OilArea()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = OilProductsDistributionCompany.Zone.JOilAreaes.GetWebQuery();
            jGridView.Title = "OilArea";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilAreaNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilAreaUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._OilAreaUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _OilAreaNew()
        {
            return _OilAreaNew(null);
        }
        public string _OilAreaNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OilArea"
                , "~/WebOilManagement/Forms/JOilAreaUpdateControl.ascx"
                , ClassLibrary.JLanguages._Text("JWebOilManagement")
                , null
                , WindowTarget.NewWindow
                , true, false, true, 600, 200);
        }
        public string _OilAreaUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OilArea"
                , "~/WebOilManagement/Forms/JOilAreaUpdateControl.ascx"
                , ClassLibrary.JLanguages._Text("JWebOilManagement")
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 600, 200);
        }

        //_Seal
        public string _Seal()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = OilProductsDistributionCompany.Seal.JSeales.GetWebQuery();
            jGridView.Title = "Seal";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SealNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SealUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._SealUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _SealNew()
        {
            return _SealNew(null);
        }
        public string _SealNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Seal"
                , "~/WebOilManagement/Forms/JOilSealUpdateControl.ascx"
                , ClassLibrary.JLanguages._Text("JWebOilManagement")
                , null
                , WindowTarget.NewWindow
                , true, false, true, 600, 250);
        }
        public string _SealUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Seal"
                , "~/WebOilManagement/Forms/JOilSealUpdateControl.ascx"
                , ClassLibrary.JLanguages._Text("JWebOilManagement")
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 600, 250);
        }

        //_RPM
        public string _RPM()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = OilProductsDistributionCompany.RPM.JRPMes.GetWebQuery();
            jGridView.Title = "RPM";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._RPMNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._RPMUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._RPMUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _RPMNew()
        {
            return _RPMNew(null);
        }
        public string _RPMNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("RPM"
                , "~/WebOilManagement/Forms/JOilRPMUpdateControl.ascx"
                , ClassLibrary.JLanguages._Text("JWebOilManagement")
                , null
                , WindowTarget.NewWindow
                , true, false, true, 600, 350);
        }
        public string _RPMUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("RPM"
                , "~/WebOilManagement/Forms/JOilRPMUpdateControl.ascx"
                , ClassLibrary.JLanguages._Text("JWebOilManagement")
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 600, 350);
        }

        //public string _BusSimCardChargeReport()
        //{
        //    return WebClassLibrary.JWebManager.LoadClientControl("BusSimCardCharge"
        //        , "~/WebBusMaintenance/Forms/JBusSimCardChargeReportControl.ascx"
        //        , "گزارش شارژ سیم کارت ها"
        //        , null
        //        , WindowTarget.NewWindow
        //        , false, true, true, 0, 0, true);
        //}

    }
}