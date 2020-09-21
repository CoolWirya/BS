using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAVL.Forms
{
    public partial class Purchase : System.Web.UI.UserControl
    { 
    protected AVL.RegisterDevice.JRegisterDevice device = new AVL.RegisterDevice.JRegisterDevice();

        protected string PgwSite = "https://bpm.shaparak.ir/pgwchannel/startpay.mellat";

        public Purchase()
        {

            device.GetData(WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "شاژ با درگاه";
            if (!Page.IsPostBack)
            {
                int Code = 0;
                if (Request["Code"] != null)
                    Code = int.Parse(Request["Code"]);
                else
                    txtCode.Text = "0";
                if (Code > 0)
                {
                    Accounting.Paid.JAVLPaid paid = new Accounting.Paid.JAVLPaid(Code);
                    Accounting.Factor.JFactor f = new Accounting.Factor.JFactor(paid.factorCode);
                    txtAmount.Text = Convert.ToInt64(f.Total).ToString();
                    txtCode.Text = ClassLibrary.JEnryption.EncryptStr(Code.ToString());
                } 
            }
            else
            {
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int EditCode = 0;
            if (txtCode.Text.Length > 3)
                EditCode = int.Parse(ClassLibrary.JEnryption.DecryptStr(txtCode.Text));
            Accounting.Paid.JAVLPaid paid = paid = new Accounting.Paid.JAVLPaid(EditCode);
            if (paid.State == 1)
                return;
            txtAmount.Text = txtAmount.Text.Replace(",","");
            string date = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');
            string time = DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0');
            try
            {
                Accounting.Factor.JFactor f = new Accounting.Factor.JFactor(paid.factorCode);
                f.Discount = 0;
                f.userCode= WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode; 
                f.payState = false;
                f.RegisterDate = DateTime.Now;
                f.Tax = decimal.Parse(txtAmount.Text) * Accounting.Config.getTaxPercentage() / 100;
                f.Total =  decimal.Parse(txtAmount.Text);
                if (f.Code > 0)
                    f.Update();
                else
                    f.Insert();

                Accounting.Factor.FactorItem.JFactorItem item = new Accounting.Factor.FactorItem.JFactorItem(f.Code);
                item.count = 1;
                item.describe = "شارژ حساب کاربری برای " +
                    AVL.RegisterDevice.JRegisterDevices.GetDataTable(WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode).Rows.Count.ToString()+
                    " دستگاه در تاریخ فاکتور برای مدت "+
                    Convert.ToInt64(f.Total) / AVL.RegisterDevice.JRegisterDevices.GetOneDayPrice(WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode)+
                    " روز";
                item.product = 1;
                item.FactorCode = f.Code;
                item.TotalUnitPrice = f.Total;
                item.Row = 1;
                item.product = 0;
                if (item.Code == 0)
                    item.Insert();
                else
                    item.Update();

                paid.factorCode = f.Code;
                paid.bankName = "ملت";
                paid.branch = "درگاه اینترنتی به پرداخت";
                paid.documentDateTime = DateTime.Now;
                paid.Price = (f.Total + f.Tax);
                paid.registerDateTime = DateTime.Now;
                paid.invoiceNumber = "g";
                paid.State = (byte)(Accounting.InvoiceStateEnum.NoAction);
                paid.type = "G";
                paid.RefId = "0";
                paid.ResCode = "0";
                paid.SaleOrderId = "0";
                paid.SaleReferenceId = "0";
                paid.userCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
                if (paid.code == 0)
                    paid.code = paid.Insert();
                else
                    paid.Update();
                WebClassLibrary.JWebManager.LoadClientControl("ViewFactor"
                , "~/WebAccounting/Forms/ViewFactor.ascx"
                , "نمایش فاکتور"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", f.Code.ToString()) }
                , WebClassLibrary.WindowTarget.NewWindow
                , true, false, true, 630, 350);

                Response.Redirect("/Controls.aspx?SUID=ViewFactor&Code=" + f.Code.ToString());
                //این بیست به این خاطر اضافه می شود که چون در سرور به پرداخت شماره درخواست چندتا بیشتر از
                //شماره فیش در دیتابیس ما است و اگر این جمع انجام نشود خطای شماره تراکنش تکراری می دهد.
                //string TMaxOrderId = WebClassLibrary.JWebSettings.GetKey("MaxOrderCode", false);
                //if(TMaxOrderId == null || TMaxOrderId.Length==0)
                //{
                //    TMaxOrderId = (100 + paid.code).ToString();
                //}
                //int MD = int.Parse(TMaxOrderId);
                //WebClassLibrary.JWebSettings.SetKey("MaxOrderCode", (MD + 1).ToString());
                //paid.OrderId = (MD + 1);
                //BpService.PaymentGatewayImplService pay = new BpService.PaymentGatewayImplService();
                //string res = pay.bpPayRequest(1586805,
                //    "sms47",
                //    "62965982",
                //    paid.OrderId,
                //    (long)paid.Price,
                //    date,
                //    time,
                //    "Transaction Number " + paid.code,
                //    "http://tstracker.ir/WebAVL/Callback.aspx",
                //    0);
                //paid.Update();
                //String[] resultArray = res.Split(',');
                //BankResult(resultArray[0]);
                //if (resultArray[0] == "0")
                //    //ClientScript.RegisterStartupScript(typeof(Page), "ClientScript", "<script language='javascript' type='text/javascript'> postRefId('" + resultArray[1] + "');</script> ", false);
                //    WebClassLibrary.JWebManager.RunClientScript(" postRefId('" + resultArray[1] + "');", "ConfirmDialog");
                //else
                //{
                //    paid.Delete();
                //    item.Delete();
                //    f.Delete();
                //}

            }
            catch (Exception er)
            {
                lblError.Text = er.Message;
                lblError.Visible = true;
            }
            finally
            {
                lblError.Visible = true;
            }
        }


        private void BankResult(string res)
        {
            switch (res)
            {
                case "0":
                    lblError.Text = "تراكنش با موفقيت انجام شد";
                    break;
                case "11":
                    lblError.Text = "شماره كارت نامعتبر است";
                    break;
                case "12":
                    lblError.Text = "موجودي كافي نيست";
                    break;
                case "13":
                    lblError.Text = "رمز نادرست است";
                    break;
                case "14":
                    lblError.Text = "تعداد دفعات وارد كردن رمز بيش از حد مجاز است";
                    break;
                case "15":
                    lblError.Text = "كارت نامعتبر است";
                    break;
                case "16":
                    lblError.Text = "دفعات برداشت وجه بيش از حد مجاز است";
                    break;
                case "17":
                    lblError.Text = "كاربر از انجام تراكنش منصرف شده است";
                    break;
                case "18":
                    lblError.Text = "تاريخ انقضاي كارت گذشته است";
                    break;
                case "19":
                    lblError.Text = "مبلغ برداشت وجه بيش از حد مجاز است";
                    break;
                case "111":
                    lblError.Text = "صادر كننده كارت نامعتبر است";
                    break;
                case "112":
                    lblError.Text = "خطاي سوييچ صادر كننده كارت";
                    break;
                case "113":
                    lblError.Text = "پاسخي از صادر كننده كارت دريافت نشد";
                    break;
                case "114":
                    lblError.Text = "دارنده كارت مجاز به انجام اين تراكنش نيست";
                    break;
                case "21":
                    lblError.Text = "پذيرنده نامعتبر است";
                    break;
                case "23":
                    lblError.Text = "خطاي امنيتي رخ داده است";
                    break;
                case "24":
                    lblError.Text = "اطلاعات كاربري پذيرنده نامعتبر است";
                    break;
                case "25":
                    lblError.Text = "مبلغ نامعتبر است";
                    break;
                case "31":
                    lblError.Text = "پاسخ نامعتبر است";
                    break;
                case "32":
                    lblError.Text = "فرمت اطلاعات وارد شده صحيح نمي باشد";
                    break;
                case "33":
                    lblError.Text = "حساب نامعتبر است";
                    break;
                case "34":
                    lblError.Text = "خطاي سيستمي";
                    break;
                case "35":
                    lblError.Text = "تاريخ نامعتبر است";
                    break;
                case "41":
                    lblError.Text = "شماره درخواست تكراري است";
                    break;
                case "42":
                    lblError.Text = "يافت نشد Sale تراكنش";
                    break;
                case "43":
                    lblError.Text = "داده شده است Verify قبلا درخواست";
                    break;
                case "44":
                    lblError.Text = "يافت نشد Verfiy درخواست";
                    break;
                case "45":
                    lblError.Text = "شده است Settle تراكنش";
                    break;
                case "46":
                    lblError.Text = "نشده است Settle تراكنش";
                    break;
                case "47":
                    lblError.Text = "يافت نشد Settle تراكنش";
                    break;
                case "48":
                    lblError.Text = "شده است Reverse تراكنش";
                    break;
                case "49":
                    lblError.Text = "يافت نشد Refund تراكنش";
                    break;
                case "412":
                    lblError.Text = "شناسه قبض نادرست است";
                    break;
                case "413":
                    lblError.Text = "شناسه پرداخت نادرست است";
                    break;
                case "414":
                    lblError.Text = "سازمان صادر كننده قبض نامعتبر است";
                    break;
                case "415":
                    lblError.Text = "زمان جلسه كاري به پايان رسيده است";
                    break;
                case "416":
                    lblError.Text = "خطا در ثبت اطلاعات";
                    break;
                case "417":
                    lblError.Text = "شناسه پرداخت كننده نامعتبر است";
                    break;
                case "418":
                    lblError.Text = "اشكال در تعريف اطلاعات مشتري";
                    break;
                case "419":
                    lblError.Text = "تعداد دفعات ورود اطلاعات از حد مجاز گذشته است";
                    break;
                case "421":
                    lblError.Text = "نامعتبر است IP";
                    break;
                case "51":
                    lblError.Text = "تراكنش تكراري است";
                    break;
                case "54":
                    lblError.Text = "تراكنش مرجع موجود نيست";
                    break;
                case "55":
                    lblError.Text = "تراكنش نامعتبر است";
                    break;
                case "61":
                    lblError.Text = "خطا در واريز";
                    break;
                default:
                    lblError.Text = "خطای نامشخص";
                    break;
            }
        }

        protected void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}