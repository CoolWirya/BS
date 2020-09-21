using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebManagementShare.Forms
{
    public partial class JShareFinanceInfoControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GatDate();
        }

        public System.Data.DataTable GetPaymentSqlQuery()
        {
            ClassLibrary.JPerson person = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPerson;
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            db.setQuery(@"EXEC SP_ShareHoldersFinance
	                    @ShareHoldersPerosnCode,
	                    @ReportType");

            db.AddParams("ShareHoldersPerosnCode", person.Code);
            db.AddParams("ReportType", 0);
            return db.Query_DataTable();
        }

        private void GatDate()
        {
            RadGridPaymentDetail.DataSource = GetPaymentSqlQuery();
            RadGridPaymentDetail.MasterTableView.EditMode = Telerik.Web.UI.GridEditMode.InPlace;
            if (RadGridPaymentDetail.MasterTableView.DataSource == null)
            {
                RadGridPaymentDetail.DataBind();
            }
        }

        protected void RadGridPaymentDetail_PreRender(object sender, EventArgs e)
        {
            if (RadGridPaymentDetail.DataSource == null) return;
            foreach (DataColumn col in (RadGridPaymentDetail.DataSource as DataTable).Columns)
            {
                RadGridPaymentDetail.MasterTableView.GetColumn(col.ColumnName).HeaderText = ClassLibrary.JLanguages._Text(col.ColumnName);
            }
            RadGridPaymentDetail.MasterTableView.Rebind();
        }

    }
}