using ClassLibrary;
using ClassLibrary.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClassLibrary;

namespace WebReport.Viewer
{
    public partial class JReportDesigner : System.Web.UI.UserControl
    {
        string rSUID;
        protected void Page_Load(object sender, EventArgs e)
        {
            //rSUID = Request.QueryString["rSUID"] ?? "";
            //WebClassLibrary.JSUIDManager suid = new WebClassLibrary.JSUIDManager(rSUID);
            //int reportCode = Convert.ToInt32(suid.GetObject("ReportCode"));
            //List<int> QueryCodes = (List<int>)suid.GetObject("QueryCodes");
            //List<int> QueryCodes = (List<int>)Session["QueryCodes"];
            int reportCode = int.Parse(WebClassLibrary.JWebManager.GetQueryString("reportCode").ToString());
            DataSet REP_DS = new DataSet();
            JReport jReport = new JReport();
            jReport.GetData(reportCode);

            string SessionName = "WebClassLibrary.JWebDataBase.GetPagerData." + jReport.ClassName + "." + jReport.ObjectCode.ToString();
            JDataBase DB = (JDataBase)SessionManager.Current.Session[SessionName + ".DB"];
            if (DB != null)
            {
                string TempTableName = SessionManager.Current.Session[SessionName + ".TempTableName"].ToString();


                DataTable DT = JWebDataBase.GetDataTable("select * from " + TempTableName, true, DB);
                foreach (DataColumn DC in DT.Columns)
                {
                    DC.Caption = ClassLibrary.JLanguages._Text(DC.ColumnName).Replace('ی', 'ي');
                }

                REP_DS.Tables.Add(DT);
            }
            else
            {
                String QueryCode = WebClassLibrary.JWebManager.GetQueryString("QueryCodes").ToString();
                JQuery query = new JQuery();
                int _Index = 0;
                foreach (string q in QueryCode.Split(new string[] { "," }, StringSplitOptions.None))
                {
                    query.GetData(int.Parse(q));
                    DB = new JDataBase();
                    DB.setQuery(query.QueryText);
                    DataTable DT = DB.Query_DataTable();
                    DT.TableName = "DataTable" + _Index.ToString();
                    _Index++;
                    REP_DS.Tables.Add(DT);
                }
                DB.Dispose();
            }
            //int index = 0;
            //foreach (int QueryCode in QueryCodes)
            //{
            //    JQuery jQuery = new JQuery();
            //    if (!jQuery.GetData(QueryCode)) continue;
            //    DataTable DT = JWebDataBase.GetDataTable(TempTableName, true);
            //    DT.TableName = DT.TableName + index;
            //    foreach (DataColumn DC in DT.Columns)
            //    {
            //        DC.Caption = ClassLibrary.JLanguages._Text(DC.ColumnName).Replace('ی', 'ي');
            //    }
 
            //    REP_DS.Tables.Add(DT);
            //    index++;

            //}

            if (jReport.Template != null && jReport.Template.Length != 0)
            {
                Stimulsoft.Report.StiReport StListReport = new Stimulsoft.Report.StiReport();
                StListReport.LoadEncryptedReport(jReport.Template, "TARAHAN");
                StListReport.ResetRenderedState();
                StListReport.RegData("REP_DS", REP_DS);
                StListReport.Dictionary.Synchronize();
                StiWebDesigner1.Report = StListReport;

            }
            else
            {
                Stimulsoft.Report.StiReport StListReport = new Stimulsoft.Report.StiReport();
                StListReport.ResetRenderedState();
                StListReport.RegData("REP_DS", REP_DS);
                StListReport.Dictionary.Synchronize();
                StiWebDesigner1.Report = StListReport;
            }
            StiWebDesigner1.Design();

        }

        protected void StiWebDesigner1_SaveReport(object sender, global::Stimulsoft.Report.Web.StiWebDesigner.StiSaveReportEventArgs e)
        {
            //rSUID = Request.QueryString["rSUID"] ?? "";
            //WebClassLibrary.JSUIDManager suid = new WebClassLibrary.JSUIDManager(rSUID);
            //int reportCode = Convert.ToInt32(suid.GetObject("ReportCode"));
            int reportCode = int.Parse(WebClassLibrary.JWebManager.GetQueryString("reportCode").ToString());


            JReport jReport = new JReport();
            jReport.GetData(reportCode);

            jReport.Template = e.Report.SaveEncryptedReportToByteArray("TARAHAN");

            jReport.Update();



        }
    }
}