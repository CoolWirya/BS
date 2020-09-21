using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace WebOilManagement
{
    public class JWebFailure
    {
        public const string _ConstClassName = "WebOilManagement.JWebFailure";
        // Main Method
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TableDamages", null, new List<object>() { }) }, "TableDamages", _ConstClassName + "._TableDamages", JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._Malfunction", null, new List<object>() { }) }, "Malfunction", _ConstClassName + "._Malfunction", JDomains.Images.MenuImages.Item, null));
            //nodes.Add(new JNode(null, "تعریف انواع خرابی", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            //nodes.Add(new JNode(null, "ثبت اعلام خرابی", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "پیگیری و گزارشات", _ConstClassName + "._Reports", JDomains.Images.MenuImages.Item, null));

            return nodes;
        }

        public string _TableDamages()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName;
            jGridView.SQL = OilProductsDistributionCompany.Failure.JTableDamageses.GetWebQuery();
            jGridView.Title = "TableDamages";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TableDamagesNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._TableDamagesUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._TableDamagesUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);

        }

        public string _TableDamagesNew()
        {
            return _TableDamagesNew(null);
        }
        public string _TableDamagesNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("TableDamages"
                  , "~/WebOilManagement/Forms/JTableDamagesUpdateControl.ascx"
                  , ClassLibrary.JLanguages._Text("JWebFailure")
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 400);
        }
        public string _TableDamagesUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("TableDamages"
                  , "~/WebOilManagement/Forms/JTableDamagesUpdateControl.ascx"
                  , ClassLibrary.JLanguages._Text("JWebFailure")
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 400);
        }


        public string _Malfunction()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName;
            jGridView.SQL = OilProductsDistributionCompany.Failure.JMalfunctiones.GetWebQuery();
            jGridView.Title = "Malfunction";
            jGridView.PageSize = 100;
            jGridView.PageOrderByField = "Code Desc";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._MalfunctionNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._MalfunctionUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._MalfunctionUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);

        }

        public string _MalfunctionNew()
        {
            return _MalfunctionNew(null);
        }
        public string _MalfunctionNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Malfunction"
                  , "~/WebOilManagement/Forms/JMalfunctionUpdateControl.ascx"
                  , ClassLibrary.JLanguages._Text("JWebFailure")
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 750, 450);
        }
        public string _MalfunctionUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Malfunction"
                  , "~/WebOilManagement/Forms/JMalfunctionUpdateControl.ascx"
                  , ClassLibrary.JLanguages._Text("JWebFailure")
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 750, 450);
        }


        public string _HardwareRepair()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName;
            jGridView.SQL = OilProductsDistributionCompany.Failure.JHardwareRepairs.GetWebQuery();
            jGridView.Title = "HardwareRepair";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._HardwareRepairNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._HardwareRepairUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._HardwareRepairUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);

        }

        public string _HardwareRepairNew()
        {
            return _HardwareRepairNew(null);
        }
        public string _HardwareRepairNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("HardwareRepair"
                  , "~/WebOilManagement/Forms/JHardwareRepairUpdateControl.ascx"
                  , ClassLibrary.JLanguages._Text("JWebFailure")
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 750, 500);
        }
        public string _HardwareRepairUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("HardwareRepair"
                  , "~/WebOilManagement/Forms/JHardwareRepairUpdateControl.ascx"
                  , ClassLibrary.JLanguages._Text("JWebFailure")
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 750, 500);
        }

        //_SoftwareRepair
        public string _SoftwareRepair()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName;
            jGridView.SQL = OilProductsDistributionCompany.Failure.JSoftwareRepairs.GetWebQuery();
            jGridView.Title = "SoftwareRepair";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SoftwareRepairNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._SoftwareRepairUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._SoftwareRepairUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);

        }

        public string _SoftwareRepairNew()
        {
            return _SoftwareRepairNew(null);
        }
        public string _SoftwareRepairNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("SoftwareRepair"
                  , "~/WebOilManagement/Forms/JSoftwareRepairUpdateControl.ascx"
                  , ClassLibrary.JLanguages._Text("JWebFailure")
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 500);
        }
        public string _SoftwareRepairUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("SoftwareRepair"
                  , "~/WebOilManagement/Forms/JSoftwareRepairUpdateControl.ascx"
                  , ClassLibrary.JLanguages._Text("JWebFailure")
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 500);
        }


        //_AfterReviewing
        public string _AfterReviewing()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName;
            jGridView.SQL = OilProductsDistributionCompany.Failure.JAfterReviewings.GetWebQuery();
            jGridView.Title = "AfterReviewing";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._AfterReviewingNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._AfterReviewingUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._AfterReviewingUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);

        }

        public string _AfterReviewingNew()
        {
            return _AfterReviewingNew(null);
        }
        public string _AfterReviewingNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("AfterReviewing"
                  , "~/WebOilManagement/Forms/JAfterReviewingUpdateControl.ascx"
                  , ClassLibrary.JLanguages._Text("JWebFailure")
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 500);
        }
        public string _AfterReviewingUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("AfterReviewing"
                  , "~/WebOilManagement/Forms/JAfterReviewingUpdateControl.ascx"
                  , ClassLibrary.JLanguages._Text("JWebFailure")
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 500);
        }

        public string ShowRefer(object ReferCode)
        {
            int referCode = 0;
            int.TryParse(ReferCode.ToString(), out referCode);

            return WebClassLibrary.JWebManager.LoadClientControl("Malfunction"
                  , "~/WebOilManagement/Forms/JMalfunctionUpdateControl.ascx"
                  , ClassLibrary.JLanguages._Text("JWebFailure")
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("ReferCode", ReferCode.ToString()) }
                  , WebClassLibrary.WindowTarget.NewWindow
                  , true, false, true, 650, 450);
        }

        public string GetInbox()
        {
            return @"SELECT om.Code as Master_Code,ogs.Number GSID, ogs.name GasStation, on1.Number NozzleNumber
                                    FROM OilMalfunction om
                                      LEFT JOIN OilGasStation ogs ON ogs.Code = om.GasStationCode
                                      LEFT JOIN OilNozzle on1 ON on1.Code = om.NozzleCode
                                      LEFT JOIN OilTableDamages otd ON otd.Code = om.DamageCode
                                      LEFT JOIN users  ON users.code = om.RegistrarCode
									  left join clsPerson ON users.pcode = clsPerson.Code
                                      LEFT JOIN subdefine sTypeOfMalfunction ON sTypeOfMalfunction.Code = om.TypeOfMalfunction";
        }

    }
}