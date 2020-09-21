using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JInsertBusOfflineFileGetDetaileReportControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            GetReport(Code);
        }

        public void GetReport(int OfflineFileCode)
        {
            try
            {
                BusManagment.Transaction.JTransactions BusTransaction = new BusManagment.Transaction.JTransactions();
                BusManagment.JBusOfflineFiles BusOFFlineFiles = new BusManagment.JBusOfflineFiles();
                BusOFFlineFiles.GetData(Code);
                //DataTable Dt = BusManagment.Transaction.JTransactions.OpenSQLiteTicketDataBaseSt(BusOFFlineFiles.ArchiveCode);
                RadGridReport1.DataSource = WebClassLibrary.JWebDataBase.GetDataTable(@"select * from ArchiveContentExtracted where ArchiveContentCode = " + BusOFFlineFiles.ArchiveCode);
                //RadGridReport1.DataSource = Dt;
                RadGridReport1.DataBind();
            }
            catch (Exception ex)
            {
                WebClassLibrary.JWebManager.ShowMessage(ex.ToString());
            }
        }

        protected void RadGridReport1_PreRender(object sender, EventArgs e)
        {
            if (RadGridReport1.DataSource == null) return;
            foreach (DataColumn col in (RadGridReport1.DataSource as DataTable).Columns)
            {
                RadGridReport1.MasterTableView.GetColumn(col.ColumnName).HeaderText = ClassLibrary.JLanguages._Text(col.ColumnName);
            }
            RadGridReport1.MasterTableView.Rebind();
        }

    }
}