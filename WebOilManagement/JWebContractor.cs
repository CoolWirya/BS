using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace WebOilManagement
{
    public class JWebContractor
    {
        public const string _ConstClassName = "WebOilManagement.JWebContractor";
        // Main Method
        public List<JNode> GetNodes()
        {
            List<JNode> nodes = new List<JNode>();
            nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilSupplier", null, new List<object>() { }) }, "OilSupplier", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            //nodes.Add(new JNode(null, "ثبت و نگهداری مناطق تحت پوشش پیمانکاران", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            //nodes.Add(new JNode(null, "ثبت و نگهداری اطلاعات تیم های پشتیبانی پیمانکار", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            nodes.Add(new JNode(null, "رتبه بندی پیمانکاران", _ConstClassName, JDomains.Images.MenuImages.Item, null));

            return nodes;
        }

        public string _OilSupplier()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName;
            jGridView.SQL = OilProductsDistributionCompany.JSupplierses.GetWebQuery();
            jGridView.Title = "OilSupplier";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilSupplierNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilSupplierUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("SupplierZones", "SupplierZones", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilSupplierZones", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("SupplierZones", "SupplierTeam", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._OilSupplierTeam", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._OilSupplierUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);

        }

        public string _OilSupplierNew()
        {
            return _OilSupplierNew(null);
        }
        public string _OilSupplierNew(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OilSupplier"
                  , "~/WebOilManagement/Forms/JOilSupplierUpdateControl.ascx"
                  , ClassLibrary.JLanguages._Text("JWebContractor")
                  , null
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 400);
        }
        public string _OilSupplierUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OilSupplier"
                  , "~/WebOilManagement/Forms/JOilSupplierUpdateControl.ascx"
                  , ClassLibrary.JLanguages._Text("JWebContractor")
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 400);
        }
        public string _OilSupplierZones(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("OilSupplierZones"
                  , "~/WebOilManagement/Forms/JOilSupplierZonesUpdateControl.ascx"
                  , ClassLibrary.JLanguages._Text("JWebContractor")
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WindowTarget.NewWindow
                  , true, false, true, 600, 400);
        }
        public string _OilSupplierTeam(string code)
        {
            int postCode = 0;
            OilProductsDistributionCompany.JSupplier jSupplier = new OilProductsDistributionCompany.JSupplier();
            jSupplier.GetData(Convert.ToInt32(code));
            var posts = Employment.JEOrganizationCharts.GetPostCodeByPersonCode(jSupplier.PCode);
            if (posts != null && posts.Count > 0)
                postCode = posts.First();

            if (postCode > 0)
                return WebClassLibrary.JWebManager.LoadClientControl("OilSupplierTeam"
                      , "~/WebBaseDefine/Forms/JOrganizationChartControl.ascx"
                      , ClassLibrary.JLanguages._Text("JWebContractor")
                      , new List<Tuple<string, string>>() { new Tuple<string, string>("PostCode", postCode.ToString()) }
                      , WindowTarget.NewWindow
                      , true, false, true, 600, 400);
            return "";
        }

    }
}