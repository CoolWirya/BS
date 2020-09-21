using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAccounting.Forms
{
    public partial class ViewFactor : System.Web.UI.UserControl
    {
        protected string PgwSite = "https://bpm.shaparak.ir/pgwchannel/startpay.mellat";
        decimal amount = 0;
        public int factorCode;
        public Accounting.Factor.JFactor factor;
        public Accounting.Paid.JAVLPaid paid;
        protected void Page_Load(object sender, EventArgs e)
        {
            int i = 0;
            if(Request["Code"]!=null && int.TryParse(Request["Code"].ToString(),out i))
                factorCode = int.Parse(Request["Code"]);
            factor = new Accounting.Factor.JFactor();
            paid = new Accounting.Paid.JAVLPaid();
            if (factorCode > 0)
            {
                factor.GetData(factorCode);
                this.amount = factor.Total + factor.Tax;

                paid.GetDataByFactorCode(factorCode);

                if (factor.payState)
                    btnOnlinePay.Visible = false;
            }
            if (!IsPostBack)
            {
                //ReportViewer2.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                //System.Data.DataTable dt = Accounting.Factor.FactorItem.JFactorItems.GetDataTable(factorCode);
                //ReportViewer2.LocalReport.ReportPath = @"C:\WebAvl\HPublish\WebERP\WebAccounting\Reports\rptFactorView.rdlc";// Request.PhysicalApplicationPath+(@"WebAccounting\Reports\rptFactorView.rdlc");
                //Microsoft.Reporting.WebForms.ReportParameter[] rp = new Microsoft.Reporting.WebForms.ReportParameter[5];
                //rp[0] = new Microsoft.Reporting.WebForms.ReportParameter("Code", factor.Code.ToString());
                //rp[1] = new Microsoft.Reporting.WebForms.ReportParameter("Date", ClassLibrary.JDateTime.FarsiDate(factor.RegisterDate));
                //rp[2] = new Microsoft.Reporting.WebForms.ReportParameter("Discount", factor.Discount.ToString());
                //rp[3] = new Microsoft.Reporting.WebForms.ReportParameter("Total", factor.Total.ToString());
                //rp[4] = new Microsoft.Reporting.WebForms.ReportParameter("Tax", factor.Tax.ToString());
                //ReportViewer2.LocalReport.SetParameters(rp);
                //ReportViewer2.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", dt));
                //ReportViewer2.LocalReport.Refresh();
            }
        }

        public string PayState()
        {
            if (!factor.payState)
                return "پرداخت نشده";
            else
                return "پرداخت شده";
        }

        public string FactorFor()
        {
            Globals.JUser User = new Globals.JUser(factor.userCode);
            ClassLibrary.JAllPerson AP = new ClassLibrary.JAllPerson(User.PCode);
            return AP.Name;
        }

        public string FactorItem()
        {
            int sum = 0;
            string str = "";
            System.Data.DataTable dt = Accounting.Factor.FactorItem.JFactorItems.GetDataTable(factorCode);
            if(dt!=null && dt.Rows.Count>0)
            {
                foreach(System.Data.DataRow dr in dt.Rows)
                {
                    str += "<tr>";
                    str += "<td>" + dr["describe"].ToString() + "</td>";
                    str += "<td>" + Convert.ToInt64(dr["TotalUnitPrice"]).ToString("N0") + "</td>";
                    str += "</tr>";
                    sum += int.Parse(dr["TotalUnitPrice"].ToString());
                }
                str += "<tr>";
                str += "<td>جمع کل</td>";
                str += "<td>" + sum.ToString("N0") + "</td>";
                str += "</tr>";
                str += "<tr>";
                str += "<td>مالیات بر ارزش افزوده</td>";
                str += "<td>" + Convert.ToInt64(factor.Tax).ToString("N0") + "</td>";
                str += "</tr>";
                str += "<tr>";
                str += "<td>قابل پرداخت</td>";
                str += "<td>" + Convert.ToInt64(paid.Price).ToString("N0") + "</td>";
                str += "</tr>";
            }
            return str;

        }
        protected void btnOnlinePay_Click(object sender, EventArgs e)
        {
            string date = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0');
            string time = DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0');
            try
            {
                paid.GetDataByFactorCode(factorCode);
                paid.factorCode = factorCode;
                paid.bankName = "ملت";
                paid.branch = "درگاه اینترنتی به پرداخت";
                paid.documentDateTime = DateTime.Now;
                paid.Price = amount;
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
                //Random r = new Random();
                if (paid.code > 0)
                {
                    //این بیست به این خاطر اضافه می شود که چون در سرور به پرداخت شماره درخواست چندتا بیشتر از
                    //شماره فیش در دیتابیس ما است و اگر این جمع انجام نشود خطای شماره تراکنش تکراری می دهد.
                    string TMaxOrderId = WebClassLibrary.JWebSettings.GetKey("MaxOrderCode", false);
                    if (TMaxOrderId == null || TMaxOrderId.Length == 0)
                    {
                        TMaxOrderId = (100 + paid.code).ToString();
                    }
                    int MD = int.Parse(TMaxOrderId);
                    WebClassLibrary.JWebSettings.SetKey("MaxOrderCode", (MD + 1).ToString());
                    paid.OrderId = (MD + 1);

                    WebAVL. BpService.PaymentGatewayImplService pay = new WebAVL. BpService.PaymentGatewayImplService();
                    string res = pay.bpPayRequest(
                        1586805,
                        "sms47",
                        "62965982",
                        paid.OrderId,
                        (long)amount,
                        date,
                        time,
                        "Transaction Number " + paid.code,
                        "http://tstracker.ir/WebAVL/Callback.aspx",
                        0);
                    String[] resultArray = res.Split(',');
                    WebClassLibrary.JWebManager.RunClientScript("alert('"+res+"');","ConfirmDialog");
                    if (resultArray[0] == "0")
                    {
                        paid.RefId = resultArray[1];
                        paid.Update();
                        WebClassLibrary.JWebManager.RunClientScript(" postRefId('" + resultArray[1] + "');", "ConfirmDialog");
                    }
                    else
                    {
                        paid.Delete(true);
                    }

                }
                else
                {
                    //lblError.Text = "فیش ثبت نشد. لطفا از درستی اطلاعات اطمینان حاصل کنید.";
                }
            }
            catch (Exception er)
            {
                //lblError.Text = er.Message;
                //lblError.Visible = true;
            }
            finally
            {
                //lblError.Visible = true;
            }
        }
    }
}
