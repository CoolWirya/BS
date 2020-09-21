using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebClassLibrary;
using ClassLibrary;
//'WebBusManagement.FormsReports.JRTPISUpdateBoardReportControl._NewUplodFile
namespace WebBusManagement.FormsReports
{
    public partial class JRTPISUpdateBoardReportControl : System.Web.UI.UserControl
    {
        int Code = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            if (IsPostBack)
            {
                btnSave_Click(null, null);
            }
            else
            {
                GetReport();
            }
        }


        public void GetReport()
        {

            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;
            jGridView.ClassName = "WebBusManagement_FormsReports_JRTPISUpdateBoardReportControl";
            jGridView.SQL = @"SELECT * FROM AUTRTPISUpdate" ;

            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.Title = "JAUTRTPISUpdate";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JRTPISUpdateBoardReportControl._NewUplodFile", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Delete", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JRTPISUpdateBoardReportControl._DeleteHistory", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Buttons = "excel,print,record_print,refresh";            
            
            jGridView.Bind();


        }

        public string _NewUplodFile()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("RTPISFileDownloadUpdateControl"
                 , "~/WebBusManagement/FormsManagement/JRTPISFileDownloadUpdateControl.ascx"
                 , "آپلود"
                 , null
                 , WindowTarget.NewWindow
                 , true, false, true, 700, 500);
        }

        public string _NewUplodFile(string pCode)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("RTPISFileDownloadUpdateControl"
                 , "~/WebBusManagement/FormsManagement/JRTPISFileDownloadUpdateControl.ascx"
                 , "آپلود"
                 , null
                 , WindowTarget.NewWindow
                 , true, false, true, 700, 500);
        }

        public void _DeleteHistory(string pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                if (int.Parse(pCode) > 0)
                {
                    DB.setQuery("delete from AUTRTPISUpdate where code=" + pCode.ToString());
                    DB.Query_Execute();
                    WebClassLibrary.JWebManager.CloseAndRefresh();
                }
            }
            finally
            {
                DB.Dispose();
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                GetReport();

            }
            catch { }
        }

        protected void btnNewUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void btnDeleteUpdateHistory_Click(object sender, EventArgs e)
        {
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {

        }

    }
}