using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JAccountingBaseDefineReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadSettings();
        }

        public void LoadSettings()
        {
            txtBusCompanyAccountNumber.Text = BusManagment.Settings.JBusSettings.Get("BusCompanyAccountNumber").ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int BusCompanyAccountNumber;
            if (int.TryParse(txtBusCompanyAccountNumber.Text, out BusCompanyAccountNumber) == true)
            {
                BusManagment.Settings.JBusSettings.Set("BusCompanyAccountNumber", txtBusCompanyAccountNumber.Text);
                WebClassLibrary.JWebManager.RunClientScript("alert('تعارف پایه حسابداری با موفقیت بروز رسانی شد');", "UpdateSettings");
            }
            else
            {
                txtBusCompanyAccountNumber.Text = "";
                txtBusCompanyAccountNumber.Focus();
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفا برای شماره حساب اتوبوسرانی عدد وارد کنید');", "UpdateSettings");
            }
        }
    }
}