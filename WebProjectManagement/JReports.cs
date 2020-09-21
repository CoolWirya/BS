using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjectManagement
{
    public class JReports
    {
        public const string FORMS_PLACE = "~/WebProjectManagement/Forms/";
        public const string _ConstClassName = "WebProjectManagement.JReports";
        // Main Method
        public List<WebClassLibrary.JNode> GetNodes()
        {
            List<WebClassLibrary.JNode> nodes = new List<WebClassLibrary.JNode>();


            //   nodes.Add(new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._ItemReports", null, new List<object>() { }) }, "گزارش آیتم ها", _ConstClassName + "._ItemReports", WebClassLibrary.JDomains.Images.AvlManagementImages.gps_icon, null));
            nodes.Add(new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._TotalReportsProject", null, new List<object>() { }) }, "گزارش پیشرفت کلی پروژه ها", _ConstClassName + "._TotalReportsProject", WebClassLibrary.JDomains.Images.AvlManagementImages.gps_icon, null));
            nodes.Add(new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._TotalReportsProjectChart", null, new List<object>() { }) }, "گزارش پیشرفت کلی پروژه ها(نمودار)", _ConstClassName + "._TotalReportsProjectChart", WebClassLibrary.JDomains.Images.AvlManagementImages.gps_icon, null));
            nodes.Add(new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._DetailedProjectReport", null, new List<object>() { }) }, "گزارش جزئیات پروژه", _ConstClassName + "._ItemReports", WebClassLibrary.JDomains.Images.AvlManagementImages.gps_icon, null));


            return nodes;
        }


        public string _ItemReports()
        {

            return WebClassLibrary.JWebManager.LoadClientControl("VisualReportData"
                           , FORMS_PLACE + "ItemReports.ascx"
                                    , "گزارش آیتم ها"
                           , null
                           , WebClassLibrary.WindowTarget.NewWindow
                           , true, true, true, 900, 450, true);
        }
        public string _TotalReportsProject()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("_TotalReportsProject"
                           , FORMS_PLACE + "TotalReportsProjects.ascx"
                                    , "گزارش کلی پیشرفت پروژه ها"
                           , null
                           , WebClassLibrary.WindowTarget.NewWindow
                           , true, true, true, 900, 450, true);

        }
        public string _TotalReportsProjectChart()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("_TotalReportsProjectChart"
                           , FORMS_PLACE + "TotalReportProjectsChart.ascx"
                                    , "گزارش نموداری پیشرفت پروژه ها"
                           , null
                           , WebClassLibrary.WindowTarget.NewWindow
                           , true, true, true, 900, 450, true);

        }
        public string _DetailedProjectReport()
        {
            WebControllers.MainControls.Grid.JGridView jGridView =
                new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_DetailedProjectReport");
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "._DetailedProjectReport";
            string query = @"SELECT * FROM pmProjects";
            jGridView.SQL = query;

            jGridView.Buttons = "Refresh,Print,record_print,Excel,Word,CSV";
            jGridView.Title = "Projects";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("DetailedProjectReport", "DetailedProjectReport",
                new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._ReportProjectDetails", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Report));


            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, true), true);
        }

        public string _ReportProjectDetails(string code)
        {
            if (code == "0")
            {
                return "";
            }
            if (string.IsNullOrEmpty(code) || code.Equals("0")) return "";
            WebClassLibrary.JWebManager.RunClientScript("parent.location='Services/ProjectManagementService.asmx/DetailedProjectImprovementReport?code="+code+"';", "excelHandler");
          return "Services/ProjectManagementStuffs/DetailedProjectReport.ashx?code="+code;// "Services /ProjectManagementService.asmx/DetailedProjectImprovementReport?code="+code;
         return WebClassLibrary.JWebManager.LoadClientControl("_ReportProjectDetails"
                           , FORMS_PLACE + "DetailedProjectImprovementReport.ascx"
                                    , "گزارش جزئیات پیشرفت پروژه"
                            , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                           , WebClassLibrary.WindowTarget.NewWindow
                           , true, true, true, 600, 350, true);
        }
    }
}