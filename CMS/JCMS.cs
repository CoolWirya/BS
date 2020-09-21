using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebClassLibrary;

namespace CMS
{
    public class JCMS
    {
        public const string _ConstClassName = "CMS.JCMS";
        public string URL;
        public JCMS()
        {
            URL = HttpContext.Current.Request.Url.AbsoluteUri;
            
           // URL = "www.moblart.ir";
             string tmp = URL.Split(new string[]{"//"},StringSplitOptions.None)[1];
            DataTable sites = CMSClassLibrary.Site.JSites.GetDataTable("Domain like '%" + tmp.Split('/')[0] + "%'");
            if (sites != null)
                if (sites.Rows.Count > 0)
                {
                    WebClassLibrary.SessionManager.Current.Session.Add("SiteCode", sites.Rows[0]["Code"]);
                }
        }
        public List<JNode> GetNodes()
        {
            string _WebBaseDefineConstClassName = "CMS.JCMS";
            List<JNode> Nodes = new List<JNode>();
            Nodes.Add(new JNode(null, ClassLibrary.JLanguages._Text("Module Management"), _ConstClassName, JDomains.Images.MenuImages.Folder, new List<JNode>(){
                new JNode(new List<JActionsInfo>(){new JActionsInfo("Click",JDomains.JActionEvents.MouseClick,_ConstClassName+"._JNewModule",null,new List<object>(){})},ClassLibrary.JLanguages._Text("Modules"),_ConstClassName,JDomains.Images.MenuImages.BusManagmentTarrif,null),
            }));
            Nodes.Add(new JNode(null, ClassLibrary.JLanguages._Text("Template Management"), _ConstClassName, JDomains.Images.MenuImages.Folder, new List<JNode>() { 
                new JNode(new List<JActionsInfo>(){new JActionsInfo("Click",JDomains.JActionEvents.MouseClick,_ConstClassName+"._JNewTemplate",null,new List<object>(){})},ClassLibrary.JLanguages._Text("Templates"),_ConstClassName,JDomains.Images.MenuImages.BusManagmentTarrif,null),
                new JNode(new List<JActionsInfo>(){new JActionsInfo("Click",JDomains.JActionEvents.MouseClick,_ConstClassName+"._JNewSelectTemplate",null,new List<object>(){})},ClassLibrary.JLanguages._Text("Select Default Template"),_ConstClassName,JDomains.Images.MenuImages.BusManagmentTarrif,null)
            }));
            Nodes.Add(new JNode(null, ClassLibrary.JLanguages._Text("Website Managemant"), _ConstClassName, JDomains.Images.MenuImages.Folder, new List<JNode>(){
                new JNode(new List<JActionsInfo>(){new JActionsInfo("Click",JDomains.JActionEvents.MouseClick,_ConstClassName + "._JNewSite",null,new List<object>(){})},ClassLibrary.JLanguages._Text("Websites"),_ConstClassName,JDomains.Images.MenuImages.BusManagmentTarrif,null)
            }));
            Nodes.Add(new JNode(null, ClassLibrary.JLanguages._Text("Content Managemant"), _ConstClassName, JDomains.Images.MenuImages.Folder, new List<JNode>(){
                new JNode(new List<JActionsInfo>(){new JActionsInfo("Click",JDomains.JActionEvents.MouseClick,_ConstClassName + "._JNewContent",null,new List<object>(){})},ClassLibrary.JLanguages._Text("Contents"),_ConstClassName,JDomains.Images.MenuImages.BusManagmentTarrif,null),
                new JNode(new List<JActionsInfo>(){new JActionsInfo("Click",JDomains.JActionEvents.MouseClick,_ConstClassName + "._JNewCategory",null,new List<object>(){})},ClassLibrary.JLanguages._Text("Categories"),_ConstClassName,JDomains.Images.MenuImages.BusManagmentTarrif,null)
            }));

            Nodes.Add(new JNode(null, ClassLibrary.JLanguages._Text("Extension Managemant"), _ConstClassName, JDomains.Images.MenuImages.Folder, new List<JNode>(){
                new JNode(new List<JActionsInfo>(){new JActionsInfo("Click",JDomains.JActionEvents.MouseClick,_ConstClassName + "._JNewExtension",null,new List<object>(){})},ClassLibrary.JLanguages._Text("Extensions"),_ConstClassName,JDomains.Images.MenuImages.BusManagmentTarrif,null),
            }));
            Nodes.Add(new JNode(null, ClassLibrary.JLanguages._Text("File Management"), _ConstClassName, JDomains.Images.MenuImages.Folder, new List<JNode>(){
                new JNode(new List<JActionsInfo>(){new JActionsInfo("Click",JDomains.JActionEvents.MouseClick,_ConstClassName + "._JNewFile",null,new List<object>(){})},ClassLibrary.JLanguages._Text("File Management"),_ConstClassName,JDomains.Images.MenuImages.BusManagmentTarrif,null),
            }));
            //Nodes.Add(new JNode(null, ClassLibrary.JLanguages._Text("test"), _ConstClassName, JDomains.Images.MenuImages.Folder, new List<JNode>(){
            //    new JNode(new List<JActionsInfo>(){new JActionsInfo("Click",JDomains.JActionEvents.MouseClick,_ConstClassName + "._Jtest",null,new List<object>(){})},ClassLibrary.JLanguages._Text("File Management"),_ConstClassName,JDomains.Images.MenuImages.BusManagmentTarrif,null),
            //}));
           // Nodes.Add(new JNode(new List<JActionsInfo>() { new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JIndex", null, null) }, "صفحه اصلی", _ConstClassName, JDomains.Images.MenuImages.Item, null));
            return Nodes;
        }
        public string _JIndex()
        {
            // WebClassLibrary.JWebManager.Redirect( "~/CMS/Index.aspx");

            return WebClassLibrary.JWebManager.LoadClientControl("Index", "~/CMS/Index.ascx",
               ClassLibrary.JLanguages._Text("Index"), null,
               WindowTarget.NewWindow, true, false, true, 600, 400);
        }

        #region Module Management

        public string _JNewModule()
        {
            WebControllers.MainControls.Grid.JGridView gridview = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace('.', '_'));
            gridview.Title = ClassLibrary.JLanguages._Text("Modules");
            int SiteCode = 0;
            if (WebClassLibrary.SessionManager.Current.Session["SiteCode"] != null)
                SiteCode = Int32.Parse(WebClassLibrary.SessionManager.Current.Session["SiteCode"].ToString());
            gridview.SQL = "select * from CMSModules where Site=" + SiteCode;
            gridview.ClassName = "AddModule";
            gridview.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            gridview.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JAddNewModule", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            gridview.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JUpdateModule", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            gridview.Actions = new List<JActionsInfo>();
            gridview.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._JUpdateModule", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(gridview.GenerateWindow(true, false, false), true);
        }

        public string _JAddNewModule()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("AddModule", "~/administrator/CMS/ModuleManagement/JAddModuleControl.ascx",
                ClassLibrary.JLanguages._Text("AddModule"), null,
                WindowTarget.NewWindow, true, false, true, 600, 400);
        }


        public string _JUpdateModule(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("UpdateModule", "~/administrator/CMS/ModuleManagement/JAddModuleControl.ascx",
        ClassLibrary.JLanguages._Text("UpdateModule"),
        new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) },
        WindowTarget.NewWindow, true, false, true, 600, 400);
        }


        #endregion

        #region template

        public string _JNewTemplate()
        {
            WebControllers.MainControls.Grid.JGridView gridview = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace('.', '_'));
            gridview.SQL = "select * from CMSTemplateStyles";
            gridview.Title = "AddTemplate";
            gridview.ClassName = "AddTemplate";
            gridview.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            gridview.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JAddNewTemplate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            gridview.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JUpdateTemplate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            gridview.Actions = new List<JActionsInfo>();
            gridview.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._JUpdateTemplate", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(gridview.GenerateWindow(true, false, false), true);
        }

        public string _JAddNewTemplate()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("AddTemplate", "~/administrator/CMS/TemplateManagement/JAddTemplateControl.ascx",
                ClassLibrary.JLanguages._Text("AddTemplate"), null,
                WindowTarget.NewWindow, true, false, true, 600, 400);
        }


        public string _JUpdateTemplate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("AddTemplate", "~/administrator/CMS/TemplateManagement/JAddTemplateControl.ascx",
        ClassLibrary.JLanguages._Text("UpdateTemplate"),
        new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) },
        WindowTarget.NewWindow, true, false, true, 600, 400);
        }


        public string _JNewSelectTemplate()
        {
            WebControllers.MainControls.Grid.JGridView gridview = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace('.', '_'));
             int SiteCode = 0;
            if (WebClassLibrary.SessionManager.Current.Session["SiteCode"] != null)
                SiteCode = Int32.Parse(WebClassLibrary.SessionManager.Current.Session["SiteCode"].ToString());
            gridview.SQL = "select * from CMSSiteTemplates where SiteCode=" +SiteCode;
            gridview.Title = "SelectTemplate";
            gridview.ClassName = "SelectTemplate";
            gridview.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            //gridview.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JAddNewTemplate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            gridview.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JUpdateSelectTemplate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            gridview.Actions = new List<JActionsInfo>();
            gridview.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._JUpdateSelectTemplate", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(gridview.GenerateWindow(true, false, false), true);
        }

        public string _JAddNewSelectTemplate()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("AddSelectTemplate", "~/administrator/CMS/TemplateManagement/JSetTemplateControl.ascx",
                ClassLibrary.JLanguages._Text("AddSelectTemplate"), null,
                WindowTarget.NewWindow, true, false, true, 600, 400);
        }


        public string _JUpdateSelectTemplate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("AddSelectTemplate", "~/administrator/CMS/TemplateManagement/JSetTemplateControl.ascx",
        ClassLibrary.JLanguages._Text("UpdateSelectTemplate"),
        new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) },
        WindowTarget.NewWindow, true, false, true, 600, 400);
        }

        #endregion template

        #region Content

        public string _JNewContent()
        {
            int SiteCode = 0;
            WebControllers.MainControls.Grid.JGridView gridview = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            if (WebClassLibrary.SessionManager.Current.Session["SiteCode"] != null)
                SiteCode = Int32.Parse(WebClassLibrary.SessionManager.Current.Session["SiteCode"].ToString());
            gridview.SQL = "select * from CMSContents where Site=" + SiteCode;
            gridview.Title = ClassLibrary.JLanguages._Text("Contents");
            gridview.ClassName = "AddContent";
            gridview.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            gridview.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JAddNewContent", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            gridview.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JUpdateContent", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            gridview.Actions = new List<JActionsInfo>();
            gridview.HiddenColumns = "Text";
            gridview.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._JUpdateContent", null, null));
            
            return WebClassLibrary.JWebManager.GenerateClientWindow(gridview.GenerateWindow(true, false, false), true);
        }

        public string _JAddNewContent()
        {

            return WebClassLibrary.JWebManager.LoadClientControl("AddContent", "~/administrator/CMS/ContentManagement/JAddContentControl.ascx",
                ClassLibrary.JLanguages._Text("AddContent"), null,
                WindowTarget.NewWindow, true, false, true, 600, 400);
        }


        public string _JUpdateContent(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("UpdateContent", "~/administrator/CMS/ContentManagement/JAddContentControl.ascx",
        ClassLibrary.JLanguages._Text("UpdateContent"),
        new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) },
        WindowTarget.NewWindow, true, false, true, 600, 400);
        }

       

        public string _JNewCategory()
        {
            int SiteCode = 0;
            WebControllers.MainControls.Grid.JGridView gridview = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace('.', '_'));
            if (WebClassLibrary.SessionManager.Current.Session["SiteCode"] != null)
                SiteCode = Int32.Parse(WebClassLibrary.SessionManager.Current.Session["SiteCode"].ToString());
            gridview.SQL = "select * from CMSCategories ";
            gridview.Title = ClassLibrary.JLanguages._Text("Categories");
            gridview.ClassName = "AddCategory";
            gridview.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            gridview.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JAddNewCategory", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            gridview.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JUpdateCategory", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            gridview.Actions = new List<JActionsInfo>();
            gridview.HiddenColumns = "Text";
            gridview.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._JUpdateCategory", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(gridview.GenerateWindow(true, false, false), true);
        }

        public string _JAddNewCategory()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("AddCategory", "~/administrator/CMS/ContentManagement/JAddCategoryControl.ascx",
                ClassLibrary.JLanguages._Text("AddCategory"), null,
                WindowTarget.NewWindow, true, false, true, 600, 400);
        }

        public string _JUpdateCategory(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("UpdateCategory", "~/administrator/CMS/ContentManagement/JAddCategoryControl.ascx",
       ClassLibrary.JLanguages._Text("UpdateCategory"),
       new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) },
       WindowTarget.NewWindow, true, false, true, 600, 400);
        }
        #endregion Content

        #region Extension


        public string _JNewExtension()
        {
            WebControllers.MainControls.Grid.JGridView gridview = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace('.', '_'));
            gridview.Title = ClassLibrary.JLanguages._Text("Extensions");
            int SiteCode = 0;
            if (WebClassLibrary.SessionManager.Current.Session["SiteCode"] != null)
                SiteCode = Int32.Parse(WebClassLibrary.SessionManager.Current.Session["SiteCode"].ToString());
            gridview.SQL = "select * from CMSExtensions";
            gridview.ClassName = "AddExtension";
            gridview.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            gridview.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JAddNewExtension", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            gridview.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JUpdateExtension", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            gridview.Actions = new List<JActionsInfo>();
            gridview.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._JUpdateExtension", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(gridview.GenerateWindow(true, false, false), true);
        }

        public string _JAddNewExtension()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("AddExtension", "~/administrator/CMS/ExtensionManagement/JAddExtensionControl.ascx",
                ClassLibrary.JLanguages._Text("AddExtension"), null,
                WindowTarget.NewWindow, true, false, true, 600, 400);
        }


        public string _JUpdateExtension(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("UpdateExtension", "~/administrator/CMS/ExtensionManagement/JAddExtensionControl.ascx",
        ClassLibrary.JLanguages._Text("UpdateExtension"),
        new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) },
        WindowTarget.NewWindow, true, false, true, 600, 400);
        }
        #endregion Extension

        #region Site Management

        public string _JNewSite()
        {
            WebControllers.MainControls.Grid.JGridView gridview = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace('.', '_'));
            gridview.Title = ClassLibrary.JLanguages._Text("WebSites");
            int SiteCode = 0;
            if (WebClassLibrary.SessionManager.Current.Session["SiteCode"] != null)
                SiteCode = Int32.Parse(WebClassLibrary.SessionManager.Current.Session["SiteCode"].ToString());
            gridview.SQL = "select * from CMSSites ";
            gridview.ClassName = "AddSite";
            gridview.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            gridview.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JAddNewSite", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            gridview.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._JUpdateSite", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            gridview.Actions = new List<JActionsInfo>();
            gridview.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._JUpdateSite", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(gridview.GenerateWindow(true, false, false), true);
        }

        public string _JAddNewSite()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("AddSite", "~/administrator/CMS/SiteManagement/JAddSiteControl.ascx",
                ClassLibrary.JLanguages._Text("AddSite"), null,
                WindowTarget.NewWindow, true, false, true, 600, 400);
        }


        public string _JUpdateSite(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("UpdateSite", "~/administrator/CMS/SiteManagement/JAddSiteControl.ascx",
        ClassLibrary.JLanguages._Text("UpdateSite"),
        new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) },
        WindowTarget.NewWindow, true, false, true, 600, 400);
        }
        #endregion


        #region File Management

        public string _JNewFile()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("AddSite", "~/administrator/CMS/FileManagement/JFileManager.ascx",
                 ClassLibrary.JLanguages._Text("File Management"), null,
                 WindowTarget.NewWindow, false, true, true, 0, 0, true);
        }
        #endregion File Management

        public string _Jtest()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("AddSite", "~/CMS/ContentManagement/test.ascx",
                ClassLibrary.JLanguages._Text("File Management"), null,
                WindowTarget.NewWindow, false, true, true,0,0,true);
        }
    }
}