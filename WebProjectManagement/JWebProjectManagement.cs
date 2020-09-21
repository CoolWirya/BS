using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebProjectManagement
{
    public class JWebProjectManagement
    {

        public const string _ConstClassName = "WebProjectManagement.JWebProjectManagement";
        public const string FORMS_PLACE = "~/WebProjectManagement/Forms/";
        // Main Method
        public List<WebClassLibrary.JNode> GetNodes()
        {
            List<WebClassLibrary.JNode> nodes = new List<WebClassLibrary.JNode>();

            nodes.Add(new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._MainPage", null, new List<object>() { }) }, "MainPage", _ConstClassName + "._MainPage", WebClassLibrary.JDomains.Images.AvlManagementImages.Home_icon, null));
            nodes.Add(new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._templates", null, new List<object>() { }) }, "الگو ها", _ConstClassName + "._templates", WebClassLibrary.JDomains.Images.AvlManagementImages.Maps_icon, null));
            nodes.Add(new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._Projects", null, new List<object>() { }) }, "پروژه ها", _ConstClassName + "._Projects", WebClassLibrary.JDomains.Images.AvlManagementImages.Maps_icon, null));
            //   nodes.Add(new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._Items", null, new List<object>() { }) }, "آیتم ها", _ConstClassName + "._Items", WebClassLibrary.JDomains.Images.AvlManagementImages.app_map_icon, null));
            nodes.Add(new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._ReportDataProject", null, new List<object>() { }) }, "ورود اطلاعات", _ConstClassName + "._ReportDataProject2", WebClassLibrary.JDomains.Images.AvlManagementImages.app_map_icon, null));


            //development grid
       //    nodes.Add(new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._customGrid", null, new List<object>() { }) }, "گرید دلخواه", _ConstClassName + "._customGrid", WebClassLibrary.JDomains.Images.AvlManagementImages.app_map_icon, null));

            return nodes;
        }
        public string _customGrid()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("CustomGrid"
                           , FORMS_PLACE + "CustomGrid.ascx"
                           , "گرید دلخواه"
                           , null
                           , WebClassLibrary.WindowTarget.NewWindow
                           , true, true, true, 600, 350, true);
        }
        public string _templates()
        {
            WebControllers.MainControls.Grid.JGridView jGridView =
                new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_Templates");
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "._Templates";
            string query = @"SELECT t.Code,t.Name,cast(t.[TotalWeight] as numeric(36,2)) as TotalWeight,
(SELECT cast( SUM(WeightPercentage) as numeric(36,2)) FROM pmTemplateItem WHERE TemplateCode=t.Code AND ParentItemCode=-1) as filledWeight FROM pmTemplate  t ";
            jGridView.SQL = query;

            jGridView.Buttons = "Refresh,Print,record_print,PDF,Excel,Word,CSV";

            jGridView.Title = "Templates";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._NewTemplate", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._EditTemplate", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("ShowItems", "ShowItemsTreeView", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._ShowTemplateItems", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Report));
            jGridView.Toolbar.AddButton("ItemEditor", "ItemEditor", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._TemplateItemEditor", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Report));
            jGridView.Actions = new List<WebClassLibrary.JActionsInfo>();

            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), false);
        }
        public string _NewTemplate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("NewTemplate"
                           , FORMS_PLACE + "TemplateUpdate.ascx"
                           , "الگو جدید"
                           , null
                           , WebClassLibrary.WindowTarget.NewWindow
                           , true, true, true, 600, 350, true);
        }
        public string _EditTemplate(string code)
        {
            if (code == "0")
            {
                return "";
            }
            return WebClassLibrary.JWebManager.LoadClientControl("NewTemplate"
                           , FORMS_PLACE + "TemplateUpdate.ascx"
                           , "الگو جدید"
                           , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                           , WebClassLibrary.WindowTarget.NewWindow
                           , true, true, true, 600, 350, true);
        }
        public string _ShowTemplateItems(string code)
        {
            if (code == "0")
            {
                return "";
            }
            return ProjectManagement.Controls.ExtendedJWindow.ExtendedJWindow.LoadClientControl("TemplateItemsList"
                           , FORMS_PLACE + "TemplateItemList.ascx"
                           , "لیست آیتم ها"
                           , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                           , WebClassLibrary.WindowTarget.NewWindow
                           ,"", true, true, true, 600, 350, true);
        }
        public string _MainPage()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("MainPage"
                           , FORMS_PLACE + "MainPage.ascx"
                                    , "صفحه اصلی"
                           ,null
                           , WebClassLibrary.WindowTarget.NewWindow
                           , true, true, true, 600, 350, true);
        }

        public string _Projects()
        {
            WebControllers.MainControls.Grid.JGridView jGridView =
                new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_Projects");
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "._Projects";
            string query = @"SELECT t.*,
(SELECT cast( SUM(WeightPercentage) as numeric(36,2)) as WeightPercentage FROM pmItems WHERE ProjectCode=t.Code AND ParentItemCode=-1) as filledWeight FROM pmProjects t ";
            jGridView.SQL = query;

            jGridView.Buttons = "Refresh,Print,record_print,Excel,Word,CSV";
            jGridView.Title = "Projects";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._NewProject", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._EditProject", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("ShowItems", "ShowItemsTreeView", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._ShowItems", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Report));
            jGridView.Toolbar.AddButton("ItemEditor", "ItemEditor", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._ProjectItemEditor", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Report));
            
        //    jGridView.Toolbar.AddButton("PDF", "", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + ".pdf", null, new List<object> { jGridView.ClassName, "0",new object[0] }), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.GridViewImages.GridView_PDF));

            jGridView.Actions = new List<WebClassLibrary.JActionsInfo>();

            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), false);
        }
       
        public string pdf(string className, string objectCode, string parameters, string code)
        {
            return "Services/ProjectManagementStuffs/PdfGenerator.ashx?className=" + className + "&objectCode=" + objectCode + "&parameters=" + parameters+ "';return false;";
        }
        public string _NewProject(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("NewProject"
                           , FORMS_PLACE + "ProjectUpdate.ascx"
                           , "پروژه جدید"
                           , null
                           , WebClassLibrary.WindowTarget.NewWindow
                           , true, true, true, 600, 350, true);
        }
        public string _EditProject(string code)
        {
            if (code == "0")
            {
                return "";
            }
            return WebClassLibrary.JWebManager.LoadClientControl("EditProject"
                           , FORMS_PLACE + "ProjectUpdate.ascx"
                           , "ویرایش پروژه"
                           , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                           , WebClassLibrary.WindowTarget.NewWindow
                           , true, true, true, 900, 500, true);
        }

        public string _Items()
        {
            WebControllers.MainControls.Grid.JGridView jGridView =
                new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_ProjectsToShowItems");
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "._ProjectsToShowItems";
            string query = @"SELECT * FROM pmProjects";
            jGridView.SQL = query;

            jGridView.Title = "Projects";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("_ShowItemsTreeMap", "ShowItemsMetroStyle", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._ShowItemsTreeMap", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Actions = new List<WebClassLibrary.JActionsInfo>();

            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public string _ShowItems(string code)
        {
            if (code == "0")
            {
                return "";
            }
            return ProjectManagement.Controls.ExtendedJWindow.ExtendedJWindow.LoadClientControl("ProjectItemsList"
                           , FORMS_PLACE + "ProjectItemList.ascx"
                           , "لیست آیتم ها"
                           , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                           , WebClassLibrary.WindowTarget.NewWindow
                           ,"", true, true, true, 600, 350, true);
        }
        public string _ShowItemsTreeMap(string code)
        {
            if (code == "0")
            {
                return "";
            }
            return ProjectManagement.Controls.ExtendedJWindow.ExtendedJWindow.LoadClientControl("ProjectItemsList"
                           , FORMS_PLACE + "ProjectItemListTreeMap.ascx"
                           , "لیست آیتم ها"
                           , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                           , WebClassLibrary.WindowTarget.NewWindow
                           ,"", true, true, true, 600, 350, true);
        }

        public string _ReportDataProject()
        {

            WebControllers.MainControls.Grid.JGridView jGridView =
                new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_ProjectsToReport");
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "._ProjectsToShowItems";

            string query = @"SELECT p.*,
            (SELECT  
	cast(	SUM(CASE WHEN (ir.WeightPercentage IS NULL OR i.WeightPercentage IS NULL) THEN 0  ELSE ir.WeightPercentage*i.WeightPercentage/100 end )  as numeric(36,2))
FROM	pmItemReport ir 
		INNER join 
		(SELECT  ItemCode,
				 Max(RegisterDate) maxDate
		 FROM	pmItemReport 
		 group by ItemCode) a 
		 ON a.ItemCode=ir.ItemCode
		 INNER join pmItems i on i.Code=ir.ItemCode  
WHERE	 ProjectCode=p.Code AND ir.RegisterDate=a.maxDate) as improvement  
            FROM pmProjects p";
            jGridView.SQL = query;

            jGridView.Buttons = "Refresh,Print,record_print,PDF,Excel,Word,CSV";
            jGridView.Title = "Projects";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("ReportItemImprovement", "ReportItemImprovement", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._ReportData", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Report));
            if (ClassLibrary.JPermission.CheckPermission(_ConstClassName + "._history"))
                jGridView.Toolbar.AddButton("history", "history", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._history", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Report));

            jGridView.Actions = new List<WebClassLibrary.JActionsInfo>();

            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), false);
        }

        public string _history(string projectCode)
        {
            if (projectCode=="0")
            {
                return "";
            }
            return ProjectManagement.Controls.ExtendedJWindow.ExtendedJWindow.LoadClientControl("_ReportDataItemsHistory"
                           , FORMS_PLACE + "EnterDataHistory.ascx"
                           , "تاریخچه ورود اطلاعات"
                           , new List<Tuple<string, string>>() { new Tuple<string, string>("ProjectCode", projectCode) }
                           , WebClassLibrary.WindowTarget.NewWindow
                           , "OnClientCloseHandler", "onRadWindowShow", false, true, true, 1200,800, false);
        }

        public string _ReportData(string projectCode)
        {
            if (projectCode == "0")
            {
                return "";
            }
            return ProjectManagement.Controls.ExtendedJWindow.ExtendedJWindow.LoadClientControl("_ReportDataItems"
                           , FORMS_PLACE + "EnterDataTreeView.ascx"
                           , "ورود اطلاعات"
                           , new List<Tuple<string, string>>() { new Tuple<string, string>("ProjectCode", projectCode)}
                           , WebClassLibrary.WindowTarget.NewWindow
                           ,"","", true, true, true, 900, 500, true);
            //            WebControllers.MainControls.Grid.JGridView jGridView =
            //                new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_ReportDataItems");
            //            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "._ReportDataItems";
            //            //            string query = @"
            //            //declare  @TEMPitems table (code int)
            //            // insert into @TEMPitems select Code from pmItems 
            //            //  select 1 as code into #Temp 
            //            // declare  @temp int,@tempcode int
            //            //while(1=1)
            //            //begin 
            //            //	set @tempcode =(select top 1 code from @TEMPitems)
            //            //	set @temp= (select top 1 code from pmItems where ParentItemCode=@tempcode)
            //            //	if(@temp IS NULL)
            //            //		insert into #Temp values (@tempcode)
            //            //	DELETE FROM @TEMPitems WHERE code=@tempcode
            //            //	if((select count(code) from @TEMPitems) <1)
            //            //		break;
            //            //end
            //            //<#PreviusSQL#> 
            //            //select * from pmItems where Code in (select code from #Temp) AND ProjectCode="+ projectCode;
            //            string query = @"select i.[Code]
            //      ,(SELECT CASE Name WHEN NULL THEN '' ELSE Name END from pmItems where Code=i.ParentItemCode) as parentName
            //      ,i.[Name]
            //      ,i.[ParentItemCode]
            //      ,i.[WeightPercentage]
            //      ,i.[ProjectCode]
            //      ,i.[ItemDescription],(i.WeightPercentage*100/p.TotalWeight) AS itemPercentage,
            //(SELECT SUM(WeightPercentage) from pmItemReport WHERE ItemCode=i.Code) as improvementPercent,
            //(SELECT MAX(RegisterDate) from pmItemReport WHERE ItemCode=i.Code) as latestEnterDate
            // from pmItems i 
            //inner join pmProjects p on p.Code=i.ProjectCode
            //where i.Code not in (select ParentItemCode from pmItems)
            //AND i.ProjectCode=" + projectCode;// +" ORDER BY i.Code asc";
            //            jGridView.SQL = query;


            //            jGridView.Title = "Items";
            //            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            //            jGridView.Toolbar.AddButton("ItemsToEnterReport", "Report Data", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._EnterReport", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Add));
            //            jGridView.Actions = new List<WebClassLibrary.JActionsInfo>();

            //            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), false);
        }

        public string _EnterReport(string code)
        {
            if (code == "0")
            {
                return "";
            }
            return WebClassLibrary.JWebManager.LoadClientControl("EnterReport"
                           , FORMS_PLACE + "ItemReportUpdate.ascx"
                                    , "وارد کردن اطلاعات"
                           , new List<Tuple<string, string>>() {
                              new Tuple<string, string>("Code",code ),
                               new Tuple<string, string>("ItemCode", "-1")
                           }
                           , WebClassLibrary.WindowTarget.NewWindow
                           , true, true, true, 600, 350, true);
        }

        public string _EditReport(string code)
        {
            if (code == "0")
            {
                return "";
            }
            return WebClassLibrary.JWebManager.LoadClientControl("EnterReport"
                           , FORMS_PLACE + "ItemReportUpdate.ascx"
                                    , "ویرایش اطلاعات"
                           , new List<Tuple<string, string>>() {
                              new Tuple<string, string>("Code",code ),
                               new Tuple<string, string>("ItemCode", "-1")
                           }
                           , WebClassLibrary.WindowTarget.NewWindow
                           , true, true, true, 600, 350, true);
        }

        public string _DeleteReport(string code)
        {

            if (code == "0")
            {
                return "";
            }
            return WebClassLibrary.JWebManager.LoadClientControl("EnterReport"
                           , FORMS_PLACE + "DeleteForm.ascx"
                                    , "حذف گزارش"
                           , new List<Tuple<string, string>>() {
                              new Tuple<string, string>("Type","0" ),
                              new Tuple<string, string>("Code",code )
                           }
                           , WebClassLibrary.WindowTarget.NewWindow
                           , true, true, true, 600, 350, true);
        }

        public string _ProjectItemEditor(string code)
        {

            if (code == "0")
            {
                return "";
            }
            return ProjectManagement.Controls.ExtendedJWindow.ExtendedJWindow.LoadClientControl("_ProjectItemEditor"
                           , FORMS_PLACE + "ItemWeightEditor.ascx"
                                    , "ویرایشگر وزن آیتم"
                           , new List<Tuple<string, string>>() {
                              new Tuple<string, string>("Type","1" ),
                              new Tuple<string, string>("Code",code )
                           }
                           , WebClassLibrary.WindowTarget.NewWindow
                           ,"", true, true, true, 800,600);
        }
        public string _TemplateItemEditor(string code)
        {

            if (code == "0")
            {
                return "";
            }
            return ProjectManagement.Controls.ExtendedJWindow.ExtendedJWindow.LoadClientControl("_TemplateItemEditor"
                           , FORMS_PLACE + "ItemWeightEditor.ascx"
                                    , "ویرایشگر وزن آیتم"
                           , new List<Tuple<string, string>>() {
                              new Tuple<string, string>("Type","0" ),
                              new Tuple<string, string>("Code",code )
                           }
                           , WebClassLibrary.WindowTarget.NewWindow
                           , "",true, true, true, 800, 600);
        }
        public string _TemplateItemEditor2(string code)
        {

            if (code == "0")
            {
                return "";
            }
            return ProjectManagement.Controls.ExtendedJWindow.ExtendedJWindow.LoadClientControl("_TemplateItemEditor2"
                           , FORMS_PLACE + "ItemWeightEditor2.ascx"
                                    , "ویرایشگر وزن آیتم"
                           , new List<Tuple<string, string>>() {
                              new Tuple<string, string>("Type","0" ),
                              new Tuple<string, string>("Code",code )
                           }
                           , WebClassLibrary.WindowTarget.NewWindow
                           , "",true, true, true, 800, 600);
        }
    }
}