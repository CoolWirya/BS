using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebReport.Viewer
{
    public partial class JReportViewer1 : System.Web.UI.Page
    {
        string rSUID;
        protected void Page_Load(object sender, EventArgs e)
        {
            rSUID = Request.QueryString["rSUID"];
        //  //  WebClassLibrary.JSUIDManager suid = new WebClassLibrary.JSUIDManager(rSUID);
            int reportCode = Convert.ToInt32(Request.QueryString["reportCode"]);
            List<string> REP_SQL = (List<string>)Session["REP_SQL"];
            DataSet REP_DS = new DataSet();
            JReport jReport = new JReport();

            if (!IsPostBack)
            {

                jReport.GetData(reportCode);


                int index = 0;
                foreach (string query in REP_SQL)
                {
                    ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();

                    try
                    {
                        db.setQuery(query);
                        DataTable DT = db.Query_DataTable();
                        DT.TableName = index.ToString();
                        REP_DS.Tables.Add(DT);
                        index++;
                    }
                    finally
                    {
                        db.Dispose();
                    }

                }
            }
            if (stiWebViewer.IsImageRequest)
                return;
            stiWebViewer.Report = new global::Stimulsoft.Report.StiReport();
            stiWebViewer.Report.RegData(REP_DS);

            if (jReport.Template != null && jReport.Template.Length != 0)
            {
                stiWebViewer.Report = new global::Stimulsoft.Report.StiReport();
                stiWebViewer.Report.LoadEncryptedReport(jReport.Template, "TARAHAN");
                stiWebViewer.Report.Render(false);

            }
            //  stiWebViewer.DataBind();
            stiWebViewer.Report.Render(false);

        }
    }
}