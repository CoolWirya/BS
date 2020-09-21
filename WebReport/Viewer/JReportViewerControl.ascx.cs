using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebReport.Viewer
{
    public partial class JReportViewer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (DataSources == null) DataSources = new List<JReportDataSource>();
            //// Add QueryDataSource to DataSource
            //if (QueryDataSources != null)
            //    foreach (JReportQuery query in QueryDataSources)
            //    {
            //        DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(query.Query);
            //        if (dt != null)
            //            DataSources.Add(new JReportDataSource(query.Name, dt));
            //    }
            //// Add QueryCode to DataSource
            //// Not implemented yet.


        }
    }
}