using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAVL.Forms
{
    public partial class registerInvoice : System.Web.UI.UserControl
    {
        int Code = 0;
        // مبلغ کنونی را نگاه می دارد 
        // ابتدا از جدول صندوق به این اندازه کم می شود
        // سپس به اندازه
        //txtPrice
        //به صندوق اضافه می شود
        decimal PrevPrice = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "قبت فیش بانکی";
                int.TryParse(Request["Code"], out Code);
            if (!Page.IsPostBack)
            {
                lblRegisterDate.Text = DateTime.Now.ToString(System.Globalization.CultureInfo.GetCultureInfo("fa-IR"));
                if (Code > 0)
                {
                    Accounting.Paid.JAVLPaid p = new Accounting.Paid.JAVLPaid(Code, WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode);
                    btnRegister.Enabled = false;
                    btnUpdate.Enabled = true;
                    if (((Accounting.InvoiceStateEnum)p.State) != 0)
                    {
                        txtBankName.Enabled = txtBranch.Enabled = txtInvoiceNumber.Enabled = txtPrice.Enabled = btnUpdate.Enabled = false;
                        WebClassLibrary.JWebManager.RunClientScript("alert('شما قادر به تغییر در این فیش نیستید. تنها فیش هایی که اقدام نشده اند قابل تغییر اند.');", "ConfirmDialog");
                    }
                    else
                    {

                    }
                    txtBankName.Text = p.bankName;
                    txtBranch.Text = p.branch;
                    txtInvoiceNumber.Text = p.invoiceNumber;
                   txtPrice.Text = p.Price.ToString();
                   PrevPrice = p.Price;
                    ((WebControllers.MainControls.Date.JDateControl)clrDocumentDate).Date = p.documentDateTime;
                    lblRegisterDate.Text = p.registerDateTime.ToString(System.Globalization.CultureInfo.GetCultureInfo("fa-IR"));
                }
                else
                {
                    btnRegister.Enabled = true;
                    btnUpdate.Enabled = false;
                }
                
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Accounting.Paid.JAVLPaid p = new Accounting.Paid.JAVLPaid();
            p.bankName = txtBankName.Text;
            p.branch = txtBranch.Text;
            p.documentDateTime = ((WebControllers.MainControls.Date.JDateControl)clrDocumentDate).Date;
            p.invoiceNumber =txtInvoiceNumber.Text;
            p.Price = decimal.Parse(txtPrice.Text);
            p.registerDateTime = DateTime.Now;
            p.type = "M";
            p.userCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
            Accounting.Paid.JAVLPaidTable ptable = new Accounting.Paid.JAVLPaidTable();
            ptable.SetValueProperty(p);
            p.code= ptable.Insert();
            if (p.code > 0)
            {
            }
            else
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('عملیات نا موفق لطفا دوباره سعی کنید. اگر مشکل برقرار بود با پشتیبانی تماس بگیرید.');", "ConfirmDialog");
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Accounting.Paid.JAVLPaid p = new Accounting.Paid.JAVLPaid(Code, WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode);
            p.bankName = txtBankName.Text;
            p.branch = txtBranch.Text;
            p.documentDateTime = ((WebControllers.MainControls.Date.JDateControl)clrDocumentDate).Date;
            p.invoiceNumber = txtInvoiceNumber.Text;
            p.Price = decimal.Parse(txtPrice.Text);
            p.registerDateTime =DateTime.Now;
            p.type = "M";
            p.userCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
            Accounting.Paid.JAVLPaidTable ptable = new Accounting.Paid.JAVLPaidTable();
            ptable.SetValueProperty(p);

            if (ptable.Update())
            {
               
            }
            else
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('عملیات نا موفق لطفا دوباره سعی کنید. اگر مشکل برقرار بود با پشتیبانی تماس بگیرید.');", "ConfirmDialog");
            }
        }
    }
}