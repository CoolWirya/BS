using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsManagement
{
    public partial class JAccDocumentsEditUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            _SetForm();
        }

        public void _SetForm()
        {
            if (!IsPostBack)
            {
                LoadDocumentDetailes();
            }
        }

        public void LoadDocumentDetailes()
        {
            DataTable report = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT TOP 100 PERCENT FDD.[Code]
                                  ,FDD.[DocCode]
                                  ,FDD.[DateSave]
                                  ,FDD.[DateModifie]
                                  ,FM.Name MoeinName
                                  ,FT.Name Tafzili1
                                  ,FT2.Name Tafzili2
                                  ,fba.AccountNo
                                  ,FDD.[BedPrice]
                                  ,FDD.[BesPrice]
                                  ,FDD.[Description]
                              FROM [dbo].[FinDocumentDetails] FDD
                              left join FinDocument FD on FD.Code = FDD.DocCode  
                              left join finMoein FM on FM.Code = FDD.MoeinCode
                              left join finTafzili FT on FT.Code = FDD.TafziliCode1
                              left join finTafzili FT2 on FT2.Code = FDD.TafziliCode2
                              left join finBankAccount fba on fba.PCode = FDD.TafziliCode1
	                            where FDD.doccode = " + Code);
            RadGridPaymentDetail.DataSource = report;
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

        protected void RadGridPaymentDetail_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (IsPostBack)
            {
                LoadDocumentDetailes();
            }
        }

        protected void RadGridPaymentDetail_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                LoadDocumentDetailes();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<string> DocDetailsCode = new List<string>();
            for (int i = 0; i < RadGridPaymentDetail.MasterTableView.Items.Count; i++)
            {
                if (((CheckBox)(RadGridPaymentDetail.MasterTableView.Items[i]["DeleteStatus"].FindControl("chbSelect"))).Checked == true)
                {
                    DocDetailsCode.Add(RadGridPaymentDetail.MasterTableView.Items[i]["Code"].Text.ToString());
                }
            }
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            Db.setQuery(@"delete from FinDocumentDetails where Code in (" + String.Join(",", DocDetailsCode.ToArray()) + @")");
            if (Db.Query_Execute() >= 0)
                WebClassLibrary.JWebManager.CloseAndRefresh();
            else
                WebClassLibrary.JWebManager.RunClientScript("alert('خطا در حذف اطلاعات');", "ConfirmDialog");
        }
    }
}