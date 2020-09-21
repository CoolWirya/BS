using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ClassLibrary;
using BusManagment.Zone;
using BusManagment.Line;
using WebClassLibrary;
using Telerik.Web.UI;


namespace WebBusManagement.FormsReports
{
    public partial class JBusGetEqualizationFile : System.Web.UI.UserControl
    {
        static bool InitialReport = true;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {


            }
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                LoadBus();
                btnSave_Click(null, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            InitialReport = false;
            try
            {
                GetReport(Convert.ToInt32(cmbBus.SelectedValue), ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
            }
            catch { }
        }

        private void GetReport(int v, DateTime dateTime1, DateTime dateTime2, DateTime? EndEventDate = null, DateTime? StartEventDate = null)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusManagement_FormsReports_JBusPerformanceReportControl");
            jGridView.ClassName = "WebBusManagement_FormsReports_JBusGetEqualizationFile_" + "_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "");
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("GettheEqualizationFile", "GettheEqualizationFile", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JBusAccounting_GetEqualizationFile.GettheEqualizationFile", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Bind();
        }



        public string _GetEqualizationFile(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("GettheEqualizationFile"
                  , "~/WebBusManagement/FormsReports/GettheEqualizationFile.ascx"
                  , "فایل تسویه"
                  ,null
                  , WindowTarget.NewWindow
                  , true, false, true, 800, 650);
        }
        private void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, BUSNumber = "همه" });
            cmbBus.DataSource = p;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }

        protected void cmbBus_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (Convert.ToInt32(cmbBus.SelectedValue) > 0)
            {
                DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
                var p = (from v in dt.AsEnumerable()
                         select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
                p.Insert(0, new { Code = 0, BUSNumber = "همه" });
                cmbBus.DataSource = p;
                cmbBus.DataTextField = "BUSNumber";
                cmbBus.DataValueField = "Code";
                cmbBus.DataBind();
            }
           
        }
    }
}

    



  






