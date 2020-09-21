using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebReport
{
    public class JReportManager
    {
        public static string SelectReport(bool isAjax, string reportSUID, string reportClassName, int reportObjectCode, WebClassLibrary.WindowTarget target = WebClassLibrary.WindowTarget.NewWindow, List<JReportDataSource> DataSources = null, List<JReportQuery> QueryDataSources = null, List<int> QueryCodes = null)
        {
            if (isAjax)
                return WebClassLibrary.JWebManager.LoadClientControl(reportSUID + "_Selector"
                    , "~/WebReport/Viewer/JReportSelectorControl.ascx"
                    , "ReportViewer"
                    , new List<Tuple<string, string>>() { new Tuple<string, string>("rSUID", reportSUID)
                    ,new Tuple<string, string>("ClassName", reportClassName)
                    ,new Tuple<string, string>("QueryCodes", QueryCodes.ToString())
                    ,new Tuple<string, string>("ObjectCode", reportObjectCode.ToString())}
                    , target
                    , true, true, true, 750, 500);
            else
            {
                WebClassLibrary.JWebManager.LoadControl(reportSUID + "_Selector"
                    , "~/WebReport/Viewer/JReportSelectorControl.ascx"
                    , "ReportViewer"
                    , new List<Tuple<string, string>>() { new Tuple<string, string>("rSUID", reportSUID)
                    ,new Tuple<string, string>("ClassName", reportClassName)
                    ,new Tuple<string, string>("QueryCodes", QueryCodes.ToString())
                    ,new Tuple<string, string>("ObjectCode", reportObjectCode.ToString())}
                    , target
                    , true, true, true, 750, 500);
                return "";
            }
        }

        public static string ViewReport(bool isAjax, string reportSUID, string reportClassName, int reportObjectCode, int reportCode, WebClassLibrary.WindowTarget target = WebClassLibrary.WindowTarget.NewWindow, List<JReportDataSource> DataSources = null, List<JReportQuery> QueryDataSources = null, List<int> QueryCodes = null)
        {
            return ViewReport(isAjax, reportSUID, reportCode, target, reportClassName, reportObjectCode, QueryCodes);
        }
        public static string ViewReport(bool isAjax, string reportSUID, int reportCode, WebClassLibrary.WindowTarget target, string reportClassName, int reportObjectCode, List<int> QueryCodes = null)
        {
            if (isAjax)
                return WebClassLibrary.JWebManager.LoadClientControl(reportSUID + "_Viewer"
                    , "~/WebReport/Viewer/JReportViewerControl.ascx"
                    , "ReportViewer"
                    , new List<Tuple<string, string>>() { new Tuple<string, string>("rSUID", reportSUID)
                    ,new Tuple<string, string>("ClassName", reportClassName)
                    ,new Tuple<string, string>("QueryCodes", QueryCodes.ToString())
                    ,new Tuple<string, string>("ObjectCode", reportObjectCode.ToString())}
                    , target
                    , true, true, true, 750, 500);
            else
            {
                WebClassLibrary.JWebManager.LoadControl(reportSUID + "_Viewer"
                    , "~/WebReport/Viewer/JReportViewerControl.ascx"
                    , "ReportViewer"
                    , new List<Tuple<string, string>>() { new Tuple<string, string>("rSUID", reportSUID)
                    ,new Tuple<string, string>("ClassName", reportClassName)
                    ,new Tuple<string, string>("QueryCodes", QueryCodes.ToString())
                    ,new Tuple<string, string>("ObjectCode", reportObjectCode.ToString())}
                    , target
                    , true, true, true, 750, 500);
                return "";
            }

        }

        public static void ViewReportPage(bool isAjax, string reportSUID, string reportClassName, int reportObjectCode, int reportCode, System.Web.UI.Page page = null, WebClassLibrary.WindowTarget target = WebClassLibrary.WindowTarget.NewWindow, List<JReportDataSource> DataSources = null, List<JReportQuery> QueryDataSources = null, List<int> QueryCodes = null
            )
        {
            if (page != null)
                ViewReportPage(isAjax, reportSUID, reportCode, target, page);
        }
        public static void ViewReportPage(bool isAjax, string reportSUID, int reportCode, WebClassLibrary.WindowTarget target, System.Web.UI.Page page)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "a", "window.open('WebReport/Viewer/JReportViewer.aspx?rSUID=" + reportSUID + "', 'پیش نمایش');", true);

        }

        public static string DesignReport(bool isAjax, string reportSUID, string reportClassName, int reportObjectCode, int reportCode = 0, WebClassLibrary.WindowTarget target = WebClassLibrary.WindowTarget.NewWindow, List<JReportDataSource> DataSources = null, List<JReportQuery> QueryDataSources = null, List<int> QueryCodes = null)
        {
            return DesignReport(isAjax, reportSUID, reportClassName, reportObjectCode, reportCode, target, QueryCodes);
        }

        public static string DesignReport(bool isAjax, string reportSUID,
            string reportClassName,
            int reportObjectCode,
            int reportCode = 0,
            WebClassLibrary.WindowTarget target = WebClassLibrary.WindowTarget.NewWindow,
            List<int> QueryCodes = null)
        {
            if (isAjax)
                return WebClassLibrary.JWebManager.LoadClientControl(reportSUID + "_Designer"
                    , "~/WebReport/Viewer/JReportDesignerControl.ascx"
                    , "ReportViewer"
                    , new List<Tuple<string, string>>() { new Tuple<string, string>("rSUID", reportSUID), new Tuple<string, string>("reportCode", reportCode.ToString()) }
                    , target
                    , true, true, true, 750, 500);
            else
            {
                WebClassLibrary.JWebManager.LoadControl(reportSUID + "_Designer"
                    , "~/WebReport/Viewer/JReportDesignerControl.ascx"
                    , "ReportViewer"
                    , new List<Tuple<string, string>>() { new Tuple<string, string>("rSUID", reportSUID)
                    ,new Tuple<string, string>("ClassName", reportClassName)
                    ,new Tuple<string, string>("QueryCodes", string.Join(",",QueryCodes))
                    ,new Tuple<string, string>("reportCode", reportCode.ToString())
                    ,new Tuple<string, string>("ObjectCode", reportObjectCode.ToString())}
                   , target
                    , true, true, true, 750, 500);
                return "";
            }
        }
    }

    [Serializable()]
    public class JReportDataSource
    {
        public JReportDataSource(string name, object dataSource)
        {
            Name = name;
            DataSource = dataSource;
        }

        public string Name;
        public object DataSource;
    }
    [Serializable()]
    public class JReportQuery
    {
        public JReportQuery(string name, string query)
        {
            Name = name;
            Query = query;
        }

        public string Name;
        public string Query;
    }
}