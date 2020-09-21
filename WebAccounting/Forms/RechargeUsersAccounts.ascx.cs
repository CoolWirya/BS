using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAccounting.Forms
{
    public partial class RechargeUsersAccounts : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((WebControllers.MainControls.Date.JDateControl)clrFromDate).Date = DateTime.Now;
            txtAmount.Text = "0";
            txtPortalPrice.Text = "0";
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AVL.RegisterDevice.JRegisterDevice devie = new AVL.RegisterDevice.JRegisterDevice();
            devie.GetData(((WebAVL.Controls.Search.JSearchDevice) searchDevice).IMEI);
            if (devie.Code <= 0)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('دستگاه یافت نشد.');", "ConfirmDialog");
                return;
            }
            decimal price=0, portalPrice=0;
            try
            {
                price = decimal.Parse(txtAmount.Text);
                portalPrice = decimal.Parse(txtPortalPrice.Text);
            }
            catch
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('خطا در فرمت مبلغ رخ داده است.');", "ConfirmDialog");
                return;
            }
            Accounting.Factor.JFactor jfactor = new Accounting.Factor.JFactor();
            jfactor.Discount = 0;
            jfactor.Number = 0;
            jfactor.payState = true;
            jfactor.RegisterDate = ((WebControllers.MainControls.Date.JDateControl)clrFromDate).Date;
            jfactor.Tax = 0;     
            jfactor.Total = price+portalPrice;
            jfactor.userCode = devie.personCode;
          int factorCode=  jfactor.Insert();
            // charghe
            Accounting.Factor.FactorItem.JFactorItem fi = new Accounting.Factor.FactorItem.JFactorItem();
            fi.count = 1;
            fi.describe = "هزینه شارژ";
            fi.FactorCode = factorCode;
            fi.product = 0;
            fi.Row = 0;
            fi.TotalUnitPrice = fi.unitPrice = price;
            fi.Insert();
            //portal price
            if (portalPrice > 0)
            {
                Accounting.Factor.FactorItem.JFactorItem fi1 = new Accounting.Factor.FactorItem.JFactorItem();
                fi1.count = 1;
                fi1.describe = "هزینه پرتال";
                fi1.FactorCode = factorCode;
                fi1.product = 0;
                fi1.Row = 0;
                fi1.TotalUnitPrice = fi.unitPrice = portalPrice;
                fi1.Insert();
            }
            //اطلاعات فیش پرداختی
            Accounting.Paid.JAVLPaid paid = new Accounting.Paid.JAVLPaid();
            paid.bankName =txtBankName.Text;
            paid.branch =txtBranchName.Text;
            paid.documentDateTime = ((WebControllers.MainControls.Date.JDateControl)documentDate).Date;
            paid.factorCode = factorCode;
            paid.Price = price + portalPrice;
            paid.registerDateTime = jfactor.RegisterDate;
            paid.State = 1;
            paid.userCode = jfactor.userCode;
            paid.type = "M";
            paid.Insert();
            //update cash and device
            Accounting.Cash.JCash cash = new Accounting.Cash.JCash(0, devie.personCode);
            cash.paid += price;
            cash.Update(true, false);
            //  devie.PurchasePlanCode = plan.code;
            devie.Update(true, false);

            WebClassLibrary.JWebManager.RunClientScript("alert('فاکتور ثبت شد.');", "ConfirmDialog");
        }
    }
}