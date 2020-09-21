using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsManagement
{
    public partial class JPaymentMadehUpdateControl : System.Web.UI.UserControl
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
                    txtDocumentDescription.Text = "سند مانده های " + cmbTafzili1.SelectedItem.Text + " " + "به شماره " + Dt.Rows[0]["MaPaymentCode"].ToString() + " - " + "سند " + ClassLibrary.JDateTime.FarsiDate(DateTime.Now).ToString();
                    long Mandeh = 0;
                    long.TryParse(txtMandeh.Text, out Mandeh);
                    if (Mandeh > 0)
                    {
                        btnInsertDocument.Enabled = true;
                    }
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
            long Mandeh = 0;
            long.TryParse(txtMandeh.Text, out Mandeh);
            if (Mandeh > 0)
            {
                ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
                Db.setQuery(@"insert into AUTPayment
                          select top 1 isnull((select Max(Code)+1 from AUTPayment),1)Code,cast(GETDATE() as date),N'" + txtDocumentDescription.Text + @"',
                          N'" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostTitle + @"'," + WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostCode + @",
                          " + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode + @" from AUTPayment");
                if (Db.Query_Execute() >= 0)
                {
                    Db.setQuery(@"Insert Into AUTPaymentDetail
                                    select top 1 ROW_NUMBER() over (order by code)+(select isnull(MAX(Code),0)+1 from AUTPaymentDetail)Code
                                    ,(select Max(Code)Code from AUTPayment)," + cmbTafzili1.SelectedValue.ToString() + @"," + txtMandeh.Text + @"," + txtMandeh.Text + @" from AUTPaymentDetail");
                    if (Db.Query_Execute() >= 0)
                    {
                        try
                        {
                            ClassLibrary.JDataBase dbAccProc = new ClassLibrary.JDataBase();
                            dbAccProc.setQuery("EXEC SP_FinPaymentToFinDocument " + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode + "," + WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostCode);
                            dbAccProc.Query_Execute();

                            dbAccProc.setQuery("EXEC SP_FinPaymentCdToFinDocument " + WebClassLibrary.JWebDataBase.GetDataTable(@"select Max(Code)Code from AUTPayment").Rows[0]["Code"].ToString());
                            dbAccProc.Query_Execute(true);
                        }
                        catch { }

                        txtMandeh.Text = "0";
                        txtPardakhti.Text = txtKarkard.Text;
                        WebClassLibrary.JWebManager.RunClientScript("alert('ثبت با موفقیت انجام شد');", "ConfirmDialog");

                    }
                }
            }
            else
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('مانده ای جهت پرداخت وجود ندارد');", "ConfirmDialog");
            }
        }

    }
}