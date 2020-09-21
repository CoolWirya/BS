using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebERP.Services.Dashboard
{
    /// <summary>
    /// Summary description for ChartsWebServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ChartsWebServices : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public string GetChart(int chartId)
        {

            string result = "";
            string query = @"select * from Dashboardsettings where ChartId="+chartId;
            DataSet ds = new DataSet();
            JDataBase db = JGlobal.MainFrame.GetDBO();
            
            try
            {
                db.setQuery(query);
                DataTable dt = db.Query_DataTable();
                if (dt == null)
                    return "";
                query = dt.Rows[0]["Query"].ToString();
                db.setQuery(query);
                ds.Tables.Add(db.Query_DataTable());
                DataTable chartSettings = new DataTable("ChartSettings");
                DataColumn chartTypeColumn = new DataColumn();
                DataColumn refreshIntervalColumn = new DataColumn();
                DataColumn xMemberFieldColumn = new DataColumn();
                DataColumn yMemberFieldsColumn = new DataColumn();
                DataColumn legendLabelsColumn = new DataColumn();
                DataColumn titleColumn = new DataColumn();
                chartTypeColumn.DataType = System.Type.GetType("System.String");
                refreshIntervalColumn.DataType = System.Type.GetType("System.Int32");
                chartTypeColumn.ColumnName = "ChartType";
                refreshIntervalColumn.ColumnName = "RefreshInterval";
                xMemberFieldColumn.ColumnName = "XMemberField";
                yMemberFieldsColumn.ColumnName = "YMemberFields";
                legendLabelsColumn.ColumnName = "LegendLabels";
                titleColumn.ColumnName = "Title";
                chartSettings.Columns.Add(chartTypeColumn);
                chartSettings.Columns.Add(refreshIntervalColumn);
                chartSettings.Columns.Add(xMemberFieldColumn);
                chartSettings.Columns.Add(yMemberFieldsColumn);
                chartSettings.Columns.Add(legendLabelsColumn);
                chartSettings.Columns.Add(titleColumn);
                DataRow row;
                row = chartSettings.NewRow();
                row["ChartType"] = dt.Rows[0]["ChartType"].ToString();
                row["RefreshInterval"] = (Int32)(dt.Rows[0]["RefreshInterval"]);
                row["XMemberField"] = dt.Rows[0]["XMemberField"].ToString();
                row["YMemberFields"] = dt.Rows[0]["YMemberFields"].ToString();
                row["LegendLabels"] = dt.Rows[0]["LegendLabels"].ToString();
                row["Title"] = dt.Rows[0]["Title"].ToString();
                chartSettings.Rows.Add(row);
                ds.Tables.Add(chartSettings);
                result = ds.GetXml();
            }
            finally
            {
                db.Dispose();
            }
            return result;
        }
    }
}
