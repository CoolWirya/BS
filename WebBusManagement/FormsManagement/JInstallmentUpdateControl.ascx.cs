using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JInstallmentUpdateControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTafsili1();
            }
        }

        public void LoadTafsili1()
        {
            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select ObjectCode Code,Value TafsiliCode,b.Name from finComparativeCode a
                                                                        left join clsAllPerson b on a.ObjectCode = b.Code
                                                                        where ClassName = N'ClassLibrary.Person.AllPerson'");
            cmbTafzili1.DataSource = dt;
            cmbTafzili1.DataTextField = "Name";
            cmbTafzili1.DataValueField = "Code";
            cmbTafzili1.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select cast((select sum(BesPrice)KarKard from FinDocumentDetails 
                                        where TafziliCode1 = " + cmbTafzili1.SelectedValue.ToString() + @" and DocCode between 120140000 and 121000000) as decimal)  Karkard,
                                        cast((
                                        select sum(BedPrice)Pardakhti from FinDocumentDetails where TafziliCode1 = " + cmbTafzili1.SelectedValue.ToString() + @" and DocCode between 400000000 and 499999999
                                        ) as decimal) Pardakhti,
                                        cast((select sum(BesPrice)KarKard from FinDocumentDetails where TafziliCode1 = " + cmbTafzili1.SelectedValue.ToString() + @" and DocCode between 120140000 and 121000000)-
                                        (
                                        select sum(BedPrice)Pardakhti from FinDocumentDetails where TafziliCode1 = " + cmbTafzili1.SelectedValue.ToString() + @" and DocCode between 400000000 and 499999999
                                        ) as decimal) MablaghManehBeToman,(select Max(Code)+1 from AUTPayment)MaPaymentCode");
            if (Dt != null)
            {
                if (Dt.Rows.Count > 0)
                {
                    txtTafziliName.Text = cmbTafzili1.SelectedValue.ToString() + "-" + cmbTafzili1.SelectedItem.Text;
                    txtKarkard.Text = Dt.Rows[0]["Karkard"].ToString();
                    txtPardakhti.Text = Dt.Rows[0]["Pardakhti"].ToString();
                    txtMandeh.Text = Dt.Rows[0]["MablaghManehBeToman"].ToString();
                    //txtDocumentDescription.Text = "سند مانده های " + cmbTafzili1.SelectedItem.Text + " " + "به شماره " + Dt.Rows[0]["MaPaymentCode"].ToString() + " - " + "سند " + ClassLibrary.JDateTime.FarsiDate(DateTime.Now).ToString();
                    long Mandeh = 0;
                    long.TryParse(txtMandeh.Text, out Mandeh);
                    if (Mandeh < 0)
                        btnInsertDocument.Enabled = true;
                    else
                        btnInsertDocument.Enabled = false;

                }
                else
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('اطلاعاتی موجود نمی باشد');", "ConfirmDialog");
                }
            }
            else
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('اطلاعاتی موجود نمی باشد');", "ConfirmDialog");
            }
        }

        protected void btnInsertDocument_Click(object sender, EventArgs e)
        {
            int Mandeh = 0;
            int Amount = 0;
            int Period = 0;
            try 
            {
                Mandeh = Convert.ToInt32(txtMandeh.Text);
                Amount = Convert.ToInt32(txtInstallmentAmount.Text);
                Period = Convert.ToInt32(txtInstallmentPeriod.Text);
            }
            catch { return; }
            if (Mandeh < Amount || Amount <= 0 || Period <= 0)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('مقادیر وارد شده قابل قبول نیستند');", "ConfirmDialog");
                return;
            }
            int MaxCode;
            int InstallmentCount = Mandeh / Amount;
            string Due;
            string MySqlQuery = "";
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            DB.setQuery(@"select isnull(max(Code),0) max_value from AUTInstallments");
            DataTable dtMaxCode = DB.Query_DataTable();
            Int32.TryParse(dtMaxCode.Rows[0]["max_value"].ToString(), out MaxCode);
            MySqlQuery += @"insert AUTInstallments values";
            for (int i = 0; i < InstallmentCount; i++)
            {
                Due = DateTime.Now.AddDays((i + 1) * Period).ToString("yyyy-MM-dd") + " 00:00:00.000";
                MySqlQuery += @" (" + (MaxCode + 1) + @" , " + cmbTafzili1.SelectedValue + ", '" + Due + "', " + Amount + @" , 0) , ";
                MaxCode++;
            }
            Amount = Mandeh - InstallmentCount * Amount;
            if (Amount > 0)
            {
                Due = DateTime.Now.AddDays((InstallmentCount + 1) * Period).ToString("yyyy-MM-dd") + " 00:00:00.000";
                MySqlQuery += @" (" + (MaxCode + 1) + @" , " + cmbTafzili1.SelectedValue + ", '" + Due + "', " + Amount + @" , 0) , ";
            }
            MySqlQuery = MySqlQuery.Substring(0, MySqlQuery.Length - 3);
            DB.setQuery(MySqlQuery);

            if (DB.Query_Execute() >= 0)
                WebClassLibrary.JWebManager.RunClientScript("alert('ثبت با موفقیت انجام شد');", "ConfirmDialog");
            else
                WebClassLibrary.JWebManager.RunClientScript("alert('خطا در انجام عملیات!');", "ConfirmDialog");
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
        }
    }
}