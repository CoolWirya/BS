using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClassLibrary;
using WebReport;

namespace WebErp
{
    public partial class JReportViewer : System.Web.UI.Page
    {
        string rSUID;
        protected void Page_Load(object sender, EventArgs e)
        {
            rSUID = Request.QueryString["rSUID"];
            //  //  WebClassLibrary.JSUIDManager suid = new WebClassLibrary.JSUIDManager(rSUID);
            int reportCode = Convert.ToInt32(Request.QueryString["reportCode"]);
            //List<string> REP_SQL = (List<string>)Session["REP_SQL"];
            //string CurrentQuery = (string)Session["FilterQuery"];
            DataSet REP_DS = new DataSet();
            WebReport.JReport jReport = new WebReport.JReport();


            jReport.GetData(reportCode);
            int index = 0;
            //foreach (string query in REP_SQL)
            //{
            //    DataTable DT = JWebDataBase.GetDataTable(query, true);
            //    REP_DS.Tables.Add(DT);
            //    index++;
            //}

            string SessionName = "WebClassLibrary.JWebDataBase.GetPagerData." + jReport.ClassName + "." + jReport.ObjectCode.ToString();
            JDataBase DB = (JDataBase)SessionManager.Current.Session[SessionName + ".DB"];
            if (DB != null)
            {
                string TempTableName = SessionManager.Current.Session[SessionName + ".TempTableName"].ToString();
                DataTable DT = JWebDataBase.GetDataTable("select * from " + TempTableName, true, DB);
                REP_DS.Tables.Add(DT);
                if (stiWebViewer.IsImageRequest)
                    return;
            }
            else
            {
                String QueryCode = WebClassLibrary.JWebManager.GetQueryString("QueryCode").ToString();
                ClassLibrary.DataBase.JQuery query = new ClassLibrary.DataBase.JQuery();
                foreach (string q in QueryCode.Split(new string[] { "," }, StringSplitOptions.None))
                {
                    query.GetData(int.Parse(q));
                    DB = new JDataBase();
                    DB.setQuery(query.QueryText);
                    REP_DS.Tables.Add(DB.Query_DataTable());
                }
                DB.Dispose();
            }


            if (jReport.Template != null && jReport.Template.Length != 0)
            {
                //Stimulsoft.Report.StiReport StListReport = new Stimulsoft.Report.StiReport();
                //StListReport.ResetRenderedState();
                //StListReport.RegData("REP_DS", REP_DS);
                //StListReport.Dictionary.Synchronize();
                //StListReport.LoadEncryptedReport(jReport.Template, "TARAHAN");
                //stiWebViewer.Report = StListReport;

            }


        }
    }
}