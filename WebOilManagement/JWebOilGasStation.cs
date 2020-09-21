using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace WebOilManagement
{
    public class JWebOilGasStation
    {
        public const string _ConstClassName = "WebOilManagement.JWebOilGasStation";
        // Main Method
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._GasStation", null, new List<object>() { }) }, "تعریف جایگاه", _ConstClassName + "._GasStation", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._FuelTank", null, new List<object>() { }) }, "تعریف مخزن سوخت", _ConstClassName + "._FuelTank", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Pump", null, new List<object>() { }) }, "تعریف پمپ", _ConstClassName + "._Pump", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Nozzle", null, new List<object>() { }) }, "تعریف نازل", _ConstClassName + "._Nozzle", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._PT", null, new List<object>() { }) }, "تعریف PT", _ConstClassName + "._PT", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Seal", null, new List<object>() { }) }, "تعریف پلمپ", _ConstClassName + "._Seal", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SealForm", null, new List<object>() { }) }, "فرم ثبت پلمپ", _ConstClassName + "._SealForm", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._RPMCenter", null, new List<object>() { }) }, "تعریف RPM مرکز", _ConstClassName + "._RPMCenter", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._RPMStation", null, new List<object>() { }) }, "تعریف RMP جایگاه", _ConstClassName + "._RPMStation", JDomains.Images.MenuImages.Item, null));

            return nodes;
        }

        public string _GasStation()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName;
            jGridView.SQL = OilProductsDistributionCompany.GasStation.JGasStationes.GetWebQuery();
            jGridView.Title = "OilGasStation";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilGasStationNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilGasStationUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._OilGasStationUpdate", null, null));
            //jGridView.SumFields = new Dictionary<string, double>();
            //jGridView.SumFields.Add("GSID", 0);
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _OilGasStationNew()
        {
            return _OilGasStationNew(null);
        }
        public string _OilGasStationNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OilGasStation"
                , "~/WebOilManagement/Forms/JOilGasStationUpdateControl.ascx"
                , ClassLibrary.JLanguages._Text("JWebOilGasStation")
                , null
                , WindowTarget.NewWindow
                , true, false, true, 600, 400);
        }
        public string _OilGasStationUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OilGasStation"
                , "~/WebOilManagement/Forms/JOilGasStationUpdateControl.ascx"
                , ClassLibrary.JLanguages._Text("JWebOilGasStation")
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 600, 400);
        }

        public string _FuelTank()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName;
            jGridView.SQL = OilProductsDistributionCompany.FuelTank.JFuelTankes.GetWebQuery();
            jGridView.Title = "OilFuelTank";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilFuelTankNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilFuelTankUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._OilFuelTankUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _OilFuelTankNew()
        {
            return _OilFuelTankNew(null);
        }
        public string _OilFuelTankNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OilFuelTank"
                , "~/WebOilManagement/Forms/JOilFuelTankUpdateControl.ascx"
                , ClassLibrary.JLanguages._Text("JWebOilGasStation")
                , null
                , WindowTarget.NewWindow
                , true, false, true, 600, 400);
        }
        public string _OilFuelTankUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OilFuelTank"
                , "~/WebOilManagement/Forms/JOilFuelTankUpdateControl.ascx"
                , ClassLibrary.JLanguages._Text("JWebOilGasStation")
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 600, 400);
        }

        // Pump
        public string _Pump()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName;
            jGridView.SQL = OilProductsDistributionCompany.Pump.JPumpes.GetWebQuery();
            jGridView.Title = "OilPump";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilPumpNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilPumpUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._OilPumpUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _OilPumpNew()
        {
            return _OilPumpNew(null);
        }
        public string _OilPumpNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OilPump"
                , "~/WebOilManagement/Forms/JOilPumpUpdateControl.ascx"
                , ClassLibrary.JLanguages._Text("JWebOilGasStation")
                , null
                , WindowTarget.NewWindow
                , true, false, true, 600, 400);
        }
        public string _OilPumpUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OilPump"
                , "~/WebOilManagement/Forms/JOilPumpUpdateControl.ascx"
                , ClassLibrary.JLanguages._Text("JWebOilGasStation")
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 600, 400);
        }

        // Nozzle
        public string _Nozzle()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName;
            jGridView.SQL = OilProductsDistributionCompany.Nozzle.JNozzleses.GetWebQuery();
            jGridView.Title = "OilNozzle";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilNozzleNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilNozzleUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._OilNozzleUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _OilNozzleNew()
        {
            return _OilNozzleNew(null);
        }
        public string _OilNozzleNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OilNozzle"
                , "~/WebOilManagement/Forms/JOilNozzleUpdateControl.ascx"
                , ClassLibrary.JLanguages._Text("JWebOilGasStation")
                , null
                , WindowTarget.NewWindow
                , true, false, true, 600, 400);
        }
        public string _OilNozzleUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OilNozzle"
                , "~/WebOilManagement/Forms/JOilNozzleUpdateControl.ascx"
                , ClassLibrary.JLanguages._Text("JWebOilGasStation")
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 600, 400);
        }

        // PT
        public string _PT()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName;
            jGridView.SQL = OilProductsDistributionCompany.PT.JPTs.GetWebQuery();
            jGridView.Title = "OilPT";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilPTNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilPTUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("PTGoods", "PTGoods", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilPTGoods", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Button));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._OilPTUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _OilPTNew()
        {
            return _OilPTNew(null);
        }
        public string _OilPTNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OilPT"
                , "~/WebOilManagement/Forms/JOilPTUpdateControl.ascx"
                , ClassLibrary.JLanguages._Text("JWebOilGasStation")
                , null
                , WindowTarget.NewWindow
                , true, false, true, 600, 400);
        }
        public string _OilPTUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OilPT"
                , "~/WebOilManagement/Forms/JOilPTUpdateControl.ascx"
                , ClassLibrary.JLanguages._Text("JWebOilGasStation")
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 600, 400);
        }
        public string _OilPTGoods(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OilPT"
                , "~/WebOilManagement/Forms/JOilPTGoodsUpdateControl.ascx"
                , ClassLibrary.JLanguages._Text("JWebOilGasStation")
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 600, 400);
        }

        // Seal
        public string _Seal()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName;
            jGridView.SQL = OilProductsDistributionCompany.Seal.JSeales.GetWebQuery();
            jGridView.Title = "OilSeal";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilSealNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilSealUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._OilSealUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _OilSealNew()
        {
            return _OilSealNew(null);
        }
        public string _OilSealNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OilSeal"
                , "~/WebOilManagement/Forms/JOilSealUpdateControl.ascx"
                , ClassLibrary.JLanguages._Text("JWebOilGasStation")
                , null
                , WindowTarget.NewWindow
                , true, false, true, 600, 400);
        }
        public string _OilSealUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OilSeal"
                , "~/WebOilManagement/Forms/JOilSealUpdateControl.ascx"
                , ClassLibrary.JLanguages._Text("JWebOilGasStation")
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 600, 400);
        }

        // SealForm
        public string _SealForm()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName;
            jGridView.SQL = OilProductsDistributionCompany.Seal.JFormSealses.GetWebQuery();
            jGridView.Title = "OilSealForm";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilSealFormNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilSealFormUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._OilSealFormUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _OilSealFormNew()
        {
            return _OilSealFormNew(null);
        }
        public string _OilSealFormNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OilSealForm"
                , "~/WebOilManagement/Forms/JOilSealFormUpdateControl.ascx"
                , ClassLibrary.JLanguages._Text("JWebOilGasStation")
                , null
                , WindowTarget.NewWindow
                , true, false, true, 600, 400);
        }
        public string _OilSealFormUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OilSealForm"
                , "~/WebOilManagement/Forms/JOilSealFormUpdateControl.ascx"
                , ClassLibrary.JLanguages._Text("JWebOilGasStation")
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WindowTarget.NewWindow
                , true, false, true, 600, 400);
        }

    }
}