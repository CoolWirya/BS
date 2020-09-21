using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace WebBusManagement
{
    public class JBusManagement
    {
        public const string _ConstClassName = "WebBusManagement.JBusManagement";
        // Main Method
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();
            nodes.Add(new JNode(null, "BaseDefine", _ConstClassName, JDomains.Images.MenuImages.Folder, new List<JNode> 
            {
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DefineFleetsTypes", null, new List<object>() { }) }, "DefineFleetsTypes", _ConstClassName + "._DefineFleetsTypes", JDomains.Images.MenuImages.BusManagmentDefine, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DefineLinesTypes", null, new List<object>() { }) }, "DefineLinesTypes", _ConstClassName + "._DefineLinesTypes", JDomains.Images.MenuImages.BusManagmentDefine, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DefineStationsTypes", null, new List<object>() { }) }, "DefineStationsTypes", _ConstClassName + "._DefineStationsTypes", JDomains.Images.MenuImages.BusManagmentDefine, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DefineTypeCards", null, new List<object>() { }) }, "DefineTypeCards", _ConstClassName + "._DefineTypeCards", JDomains.Images.MenuImages.BusManagmentDefine, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DefineSpecializationTypes", null, new List<object>() { }) }, "DefineSpecializationTypes", _ConstClassName + "._DefineSpecializationTypes", JDomains.Images.MenuImages.BusManagmentDefine, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DefineTypeSallerTickets", null, new List<object>() { }) }, "DefineTypeSallerTickets", _ConstClassName + "._DefineTypeSallerTickets", JDomains.Images.MenuImages.BusManagmentDefine, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DefineEmploymentTypes", null, new List<object>() { }) }, "DefineEmploymentTypes",  _ConstClassName + "._DefineEmploymentTypes", JDomains.Images.MenuImages.BusManagmentDefine, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._AutomobileType", null, new List<object>() { }) }, "AutomobileType", _ConstClassName + "._AutomobileType", JDomains.Images.MenuImages.BusManagmentDefine, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._MakerCompany", null, new List<object>() { }) }, "MakerCompany", _ConstClassName + "._MakerCompany", JDomains.Images.MenuImages.BusManagmentDefine, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._AutomobileDefine", null, new List<object>() { }) }, "AutomobileDefine", _ConstClassName + "._AutomobileDefine", JDomains.Images.MenuImages.BusManagmentDefine, null),
                new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusSettings", null, new List<object>() { }) }, "BusSettings", _ConstClassName + "._BusSettings", JDomains.Images.MenuImages.BusManagmentDefine, null)
            }));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Fleets", null, new List<object>() { }) }, "Fleets", _ConstClassName + "._Fleets", JDomains.Images.MenuImages.BusManagmentFleet, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Zones", null, new List<object>() { }) }, "Zones", _ConstClassName + "._Zones", JDomains.Images.MenuImages.BusManagmentZone, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Buses", null, new List<object>() { }) }, "Buses", _ConstClassName + "._Buses", JDomains.Images.MenuImages.BusManagmentBus, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Stations", null, new List<object>() { }) }, "Stations", _ConstClassName + "._Stations", JDomains.Images.MenuImages.BusManagmentBusStation, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Lines", null, new List<object>() { }) }, "Lines", _ConstClassName + "._Lines", JDomains.Images.MenuImages.BusManagmentBusLine, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Counters", null, new List<object>() { }) }, "Counters", _ConstClassName + "._Counters", JDomains.Images.MenuImages.BusManagmentTicket, null));

            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._RealPerson", null, new List<object>() { }) }, "RealPersons", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LegalPerson", null, new List<object>() { }) }, "LegalPersons", _ConstClassName, JDomains.Images.MenuImages.Item, null));

            //nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusDeviceSettings", null, new List<object>() { }) }, "BusDeviceSettings", _ConstClassName, JDomains.Images.MenuImages.Item, null));





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

        //_BusDeviceSettings
        //public string _BusDeviceSettings()
        //{
        //    return WebClassLibrary.JWebManager.LoadClientControl("BusDeviceSettings"
        //        , "~/WebBusManagement/FormsManagement/JBusDeviceSettingsUpdateControl.ascx"
        //        , "تنظیمات اتوبوس"
        //        , null
        //        , WindowTarget.NewWindow
        //        , false, true, true, 0, 0, true);
        //}

        public string _RealPerson()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = ClassLibrary.JPersons.GetWebQuery();
            jGridView.Title = "RealPersons";
            jGridView.PageOrderByField = "Fam,Name";
            jGridView.PageSize = 15;
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._RealPersonNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._RealPersonUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._RealPersonUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _LegalPerson()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = ClassLibrary.JOrganizations.GetWebQuery();
            jGridView.Title = "LegalPersons";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LegalPersonNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LegalPersonUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._LegalPersonUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        // Real Person New/Edit
        public string _RealPersonNew()
        {
            return _RealPersonNew(null);
        }
        public string _RealPersonNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("RealPersons"
                  , "~/WebBaseDefine/Forms/JRealPersonUpdateControl.ascx"
                  , "شخص حقیقی"
                  , null
                  , WindowTarget.NewWindow
                  , true, true, true, 600, 350);
        }

        public string _RealPersonUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("RealPersons"
                  , "~/WebBaseDefine/Forms/JRealPersonUpdateControl.ascx"
                  , "شخص حقیقی"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, true, true, 630, 350);
        }

        // Legal Person New/Edit
        public string _LegalPersonNew()
        {
            return _LegalPersonNew(null);
        }
        public string _LegalPersonNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("LegalPersons"
                  , "~/WebBaseDefine/Forms/JLegalPersonUpdateControl.ascx"
                  , "شخص حقوقی"
                  , null
                  , WindowTarget.NewWindow
                  , true, true, true, 600, 350);
        }

        public string _LegalPersonUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("LegalPersons"
                  , "~/WebBaseDefine/Forms/JLegalPersonUpdateControl.ascx"
                  , "شخص حقوقی"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, true, true, 630, 350);
        }

        public string _DefineFleetsTypes()
        {
            return JWebManager.GenerateClientWindow(WebControllers.MainControls.Grid.JSubDefine.GetSubDefineGrid(9101031, "TypeFleet").GenerateWindow(false, false, false), true);
        }

        public string _DefineLinesTypes()
        {
            return JWebManager.GenerateClientWindow(WebControllers.MainControls.Grid.JSubDefine.GetSubDefineGrid(9101021, "TypeLine").GenerateWindow(false, false, false), true);
        }

        public string _DefineStationsTypes()
        {
            return JWebManager.GenerateClientWindow(WebControllers.MainControls.Grid.JSubDefine.GetSubDefineGrid(9001010, "TypeStation").GenerateWindow(false, false, false), true);
        }

        public string _DefineSpecializationTypes()
        {
            return JWebManager.GenerateClientWindow(WebControllers.MainControls.Grid.JSubDefine.GetSubDefineGrid(9101024, "SpecificationType").GenerateWindow(false, false, false), true);
        }

        public string _DefineEmploymentTypes()
        {
            return JWebManager.GenerateClientWindow(WebControllers.MainControls.Grid.JSubDefine.GetSubDefineGrid(9101025, "EmploymentType").GenerateWindow(false, false, false), true);
        }

        public string _DefineTypeCards()
        {
            return JWebManager.GenerateClientWindow(WebControllers.MainControls.Grid.JSubDefine.GetSubDefineGrid(9101023, "TypeCard").GenerateWindow(false, false, false), true);
        }

        public string _DefineTypeSallerTickets()
        {
            return JWebManager.GenerateClientWindow(WebControllers.MainControls.Grid.JSubDefine.GetSubDefineGrid(9101011, "TypeSallerTicket").GenerateWindow(false, false, false), true);
        }


        public string _BusSettings()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusSettings"
                   , "~/WebBusManagement/FormsManagement/JBusSettingsUpdateControl.ascx"
                   , "تنظیمات اتوبوس"
                   , null
                   , WindowTarget.NewWindow
                   , false, true, true, 0, 0, true);
        }



        public string _Fleets()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = BusManagment.Fleet.JFleets.GetWebQuery();
            jGridView.Title = "Fleets";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._FleetNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._FleetUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._FleetUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _FleetNew()
        {
            return _FleetNew(null);
        }
        public string _FleetNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Fleets"
                  , "~/WebBusManagement/FormsManagement/JFleetUpdateControl.ascx"
                  , "ناوگان"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 350);
        }
        public string _FleetUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Fleets"
                  , "~/WebBusManagement/FormsManagement/JFleetUpdateControl.ascx"
                  , "ناوگان"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 350);
        }

        public string _Zones()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = BusManagment.Zone.JZones.GetWebQuery();
            jGridView.Title = "Zones";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ZoneNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._ZoneUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._ZoneUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _ZoneNew()
        {
            return _ZoneNew(null);
        }
        public string _ZoneNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Zones"
                   , "~/WebBusManagement/FormsManagement/JZoneUpdateControl.ascx"
                   , "منطقه"
                   , null
                   , WindowTarget.NewWindow
                   , true, false, true, 600, 400);
        }
        public string _ZoneUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Zones"
                  , "~/WebBusManagement/FormsManagement/JZoneUpdateControl.ascx"
                  , "منطقه"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 400);
        }


        public string _Lines()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = BusManagment.Line.JLines.GetWebQuery();
            jGridView.Title = "Lines";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LinesNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LinesUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("LinePath", "LinePath", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._LinePath", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._LinesUpdate", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _LinesNew()
        {
            return _LinesNew(null);
        }
        public string _LinesNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Lines"
                  , "~/WebBusManagement/FormsManagement/JLineUpdateControl.ascx"
                  , "خطوط"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 800, 450);
        }
        public string _LinesUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Lines"
                  , "~/WebBusManagement/FormsManagement/JLineUpdateControl.ascx"
                  , "خطوط"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 800, 450);
        }

        public string _LinePath(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Lines"
                  , "~/WebBusManagement/FormsManagement/JLinePathUpdateControl.ascx"
                  , "مسیر خط"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 800, 450);
        }


        public string _Buses()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = BusManagment.Bus.JBuses.GetWebQuery();
            jGridView.Title = "Buses";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusesNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._BusesUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._BusesUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _BusesNew()
        {
            return _BusesNew(null);
        }
        public string _BusesNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Buses"
                 , "~/WebBusManagement/FormsManagement/JBusesUpdateControl.ascx"
                 , "اتوبوس"
                 , null
                 , WindowTarget.NewWindow
                 , true, false, true, 800, 450);
        }
        public string _BusesUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Buses"
                  , "~/WebBusManagement/FormsManagement/JBusesUpdateControl.ascx"
                  , "اتوبوس"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 800, 450);
        }



        public string _Counters()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = BusManagment.SellerTicket.JSellerTickets.GetWebQuery();
            jGridView.Title = "Counters";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._CountersNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._CountersUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._CountersUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _CountersNew()
        {
            return _CountersNew(null);
        }
        public string _CountersNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Counters"
                  , "~/WebBusManagement/FormsManagement/JCountersUpdateControl.ascx"
                  , "باجه های فروش بلیط"
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 800, 450);
        }
        public string _CountersUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Counters"
                   , "~/WebBusManagement/FormsManagement/JCountersUpdateControl.ascx"
                   , "باجه های فروش بلیط"
                   , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                   , WindowTarget.NewWindow
                   , true, false, true, 800, 450);
        }



        public string _Stations()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = BusManagment.Station.JStations.GetWebQuery();
            jGridView.Title = "Stations";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._StationsNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._StationsUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._CountersUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _StationsNew()
        {
            return _StationsNew(null);
        }
        public string _StationsNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Stations"
                   , "~/WebBusManagement/FormsManagement/JStationsUpdateControl.ascx"
                   , "ایستگاه"
                   , null
                   , WindowTarget.NewWindow
                   , true, false, true, 800, 450);
        }
        public string _StationsUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Stations"
                   , "~/WebBusManagement/FormsManagement/JStationsUpdateControl.ascx"
                   , "ایستگاه"
                   , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                   , WindowTarget.NewWindow
                   , true, false, true, 800, 450);
        }



        public string _Person()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = BusManagment.Personel.JPersonels.GetWebQuery();
            jGridView.Title = "Person";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PersonNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PersonUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._PersonUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _PersonNew()
        {
            return _PersonNew(null);
        }
        public string _PersonNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Person"
                   , "~/WebBusManagement/FormsManagement/JPersonUpdateControl.ascx"
                   , "شخص"
                   , null
                   , WindowTarget.NewWindow
                   , true, false, true, 600, 350);
        }
        public string _PersonUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Person"
                  , "~/WebBusManagement/FormsManagement/JPersonUpdateControl.ascx"
                  , "شخص"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 350);
        }


        //_Documents
        public string _Documents()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = BusManagment.Documents.JAUTDocuments.GetWebQuery();
            jGridView.Title = "Documents";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DocumentsNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._DocumentsUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._DocumentsUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _DocumentsNew()
        {
            return _DocumentsNew(null);
        }
        public string _DocumentsNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Documents"
                  , "~/WebBusManagement/FormsManagement/JDocumentsUpdateControl.ascx"
                  , "اسناد"
                  , null
                  , WindowTarget.NewWindow
                  , true, true, true, 600, 350);
        }
        public string _DocumentsUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Documents"
                  , "~/WebBusManagement/FormsManagement/JDocumentsUpdateControl.ascx"
                  , "اسناد"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, true, true, 600, 350);
        }


        //_Payments
        public string _Payments()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.SQL = BusManagment.Documents.JAUTPayments.GetWebQuery();
            jGridView.Title = "Payments";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PaymentsNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PaymentsUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._PaymentsUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _PaymentsNew()
        {
            return _PaymentsNew(null);
        }
        public string _PaymentsNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Payments"
                  , "~/WebBusManagement/FormsManagement/JPaymentsUpdateControl.ascx"
                  , "پرداختها"
                  , null
                  , WindowTarget.NewWindow
                  , true, true, true, 600, 350);
        }
        public string _PaymentsUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Payments"
                 , "~/WebBusManagement/FormsManagement/JPaymentsUpdateControl.ascx"
                 , "پرداختها"
                 , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                 , WindowTarget.NewWindow
                 , true, true, true, 600, 350);
        }
    }
}