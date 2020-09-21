using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebReport.Viewer
{
    public partial class JReportSelector : System.Web.UI.UserControl
    {
        string reportSUID;
        string ClassName;
        int ObjectCode;

        protected void Page_Load(object sender, EventArgs e)
        {
            hfreportSUID.Value = WebClassLibrary.JWebManager.GetQueryString("rSUID").ToString();
            reportSUID = hfreportSUID.Value;

            hfClassName.Value = WebClassLibrary.JWebManager.GetQueryString("ClassName").ToString();
            ClassName = hfClassName.Value;

            hfObjectCode.Value = WebClassLibrary.JWebManager.GetQueryString("ObjectCode").ToString();
            ObjectCode = int.Parse(hfObjectCode.Value);

            hfQueryCode.Value = WebClassLibrary.JWebManager.GetQueryString("QueryCode").ToString();

            LoadReports();
        }

        public void LoadReports()
        {
            ClassName = hfClassName.Value;
            ObjectCode = int.Parse(hfObjectCode.Value);
            dgrReports.DataSource = JReports.GetReportsByClassNameObjectCode(ClassName, ObjectCode);
            dgrReports.DataBind();
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            if (dgrReports.SelectedItems.Count == 0) 
                return;
            int reportCode = Convert.ToInt32((dgrReports.DataSource as DataTable).Rows[dgrReports.SelectedItems[0].DataSetIndex]["Code"]);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "a", "window.open('JReportViewer.aspx?rSUID=" + reportSUID + "&QueryCode=" + hfQueryCode.Value + "&reportCode=" + reportCode + "', 'پیش نمایش');", true);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgrReports.SelectedItems.Count == 0) 
                return;

            List<int> QueryCodes = new List<int>();
            foreach(string S in hfQueryCode.Value.Split(new string[] {","},StringSplitOptions.None))
                QueryCodes.Add(Int32.Parse(S));
            int reportCode = Convert.ToInt32((dgrReports.DataSource as DataTable).Rows[dgrReports.SelectedItems[0].DataSetIndex]["Code"]);
            JReportManager.DesignReport(false, hfreportSUID.Value, hfClassName.Value, int.Parse(hfObjectCode.Value), 
                reportCode, WebClassLibrary.WindowTarget.NewWindow, null, null, QueryCodes);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgrReports.SelectedItems.Count == 0)
                return;
            int reportCode = Convert.ToInt32((dgrReports.DataSource as DataTable).Rows[dgrReports.SelectedItems[0].DataSetIndex]["Code"]);

            JReport jReport = new JReport();
            jReport.Code = reportCode;
            jReport.Delete();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            List<int> QueryCodes = new List<int>();
            QueryCodes.Add(Int32.Parse(hfQueryCode.Value));
            JReport jReport = new JReport();
            jReport.ClassName = hfClassName.Value;

            jReport.Name = txtName.Text + '_' + ClassLibrary.JDateTime.FarsiDate(DateTime.Now);
            jReport.ObjectCode = int.Parse(hfObjectCode.Value);
            int rptCode = jReport.Insert();
            if (rptCode > 0)
            {
                JReportManager.DesignReport(false, hfreportSUID.Value, hfClassName.Value, int.Parse(hfObjectCode.Value), 
                    rptCode, WebClassLibrary.WindowTarget.NewWindow, null, null, QueryCodes);
            }
        }
    }
}