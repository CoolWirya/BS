using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Finance;
using System.Data;

namespace WebBusManagement.FormsManagement
{
    public partial class JOnAccountFormUpdateControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadBus();
        }

        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, BUSNumber = "نامشخص" });
            cmbBus.DataSource = p;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }

        public bool Save()
        {
            int BusNumber = Convert.ToInt32(cmbBus.SelectedValue);
            int PersonCode = ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode;

            decimal Bed1 = 0, Bes1 = 0, Bed2 = 0, Bes2 = 0;
            if (cmbActionType.SelectedValue == "1")
            {
                Bes1 = Convert.ToDecimal(txtPrice.Text) / 10;
                Bed1 = 0;
                Bes2 = 0;
                Bed2 = Convert.ToDecimal(txtPrice.Text) / 10;
            }
            else
            {
                Bes1 = 0;
                Bed1 = Convert.ToDecimal(txtPrice.Text) / 10;
                Bes2 = Convert.ToDecimal(txtPrice.Text) / 10;
                Bed2 = 0;
            }

            if (PersonCode > 0)
            {
                DataTable DtMaxFinDocCode = WebClassLibrary.JWebDataBase.GetDataTable(@"select ISNULL(max(Code),0)+1 MaxCode from FinDocument where code between 400000000 and 500000000");
                return Finance.JDocumentDetailes.InsertFullDocument
                    (WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode, WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostCode,
                    txtDescription.Text, 1, 1, 2, 20000001, BusNumber, Bed1, Bes1, 1, 1, 3, PersonCode, BusNumber, Bed2, Bes2, Convert.ToInt32(DtMaxFinDocCode.Rows[0]["MaxCode"].ToString())) > 0 ? true : false;
            }
            else
            {
                return false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                txtPrice.Text = "";
                txtDescription.Text = "";
                WebClassLibrary.JWebManager.RunClientScript("alert('ثبت با موفقیت انجام شد');", "ConfirmDialog");
            }
            else
                WebClassLibrary.JWebManager.RunClientScript("alert('خطا در ثبت اطلاعات');", "ConfirmDialog");
            //WebClassLibrary.JWebManager.CloseAndRefresh();
        }
    }
}