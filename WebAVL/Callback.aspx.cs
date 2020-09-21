using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAVL
{
    public partial class Callback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BpService.PaymentGatewayImplService pay = new BpService.PaymentGatewayImplService();

            Accounting.Paid.JAVLPaid Paid = Accounting.Paid.JAVLPaid.GetLatestGateawayInvoice(WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode, Request.Params["RefId"]);
            if (Paid.code == 0 || Paid.OrderId != long.Parse( Request.Params["SaleOrderId"]))
            {
                RefIdLabel.Text = Request.Params["RefId"];
                ResCodeLabel.Text = Request.Params["ResCode"];
                SaleOrderIdLabel.Text = Request.Params["SaleOrderId"];
                SaleReferenceIdLabel.Text = Request.Params["SaleReferenceId"];

                lblPrice.Text = "فیش پیدا نشد." + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
                pay.bpReversalRequest(1586805, "sms47", "62965982", long.Parse(Request.Params["SaleOrderId"]), long.Parse(Request.Params["SaleOrderId"]), long.Parse(Request.Params["SaleReferenceId"]));
                return;
            }

            Accounting.Cash.JCash cash = new Accounting.Cash.JCash(0, WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode);
            Paid.RefId = Request.Params["RefId"];
            Paid.ResCode = Request.Params["ResCode"];
            Paid.SaleOrderId = Request.Params["SaleOrderId"];
            Paid.SaleReferenceId = Request.Params["SaleReferenceId"];
            
            if (Paid.ResCode == ("0"))//عملیات     موفق در درگاه بانک
            {
                //اطمینان از عملیات موفق
                string result = pay.bpVerifyRequest(1586805, "sms47", "62965982", long.Parse(Paid.SaleOrderId), long.Parse(Paid.SaleOrderId), long.Parse(Paid.SaleReferenceId));
                String inqResult = "";
             
                if (string.IsNullOrEmpty(result))   //تاییدیه عملیات به دلیل نامعلومی تتیجه ندارد
                {
                    //از متد زیر تاییدیه را جویامیشویم
                    inqResult = pay.bpInquiryRequest(1586805, "sms47", "62965982", long.Parse(Paid.SaleOrderId), long.Parse(Paid.SaleOrderId), long.Parse(Paid.SaleReferenceId));
                }
                if (result == "0" || inqResult == "0")//یکی از متدهای تایدیه موفقیت عملیات را تایید کردند
                {
                    //به بانک می گوییم پول را به حسا واریزکن
                    result = pay.bpSettleRequest(1586805, "sms47", "62965982", long.Parse(Paid.SaleOrderId), long.Parse(Paid.SaleOrderId), long.Parse(Paid.SaleReferenceId));
                    if (result == "0" || result == "45")//پوووووول واریز شد
                    {
                        //در دیتابییس ذخیره شود
                        Accounting.Factor.JFactor f = new Accounting.Factor.JFactor();
                        f.GetData(Paid.factorCode);
                        f.payState = true;
                        f.Number = long.Parse(Paid.SaleOrderId);
                        f.Update();

                        cash.paid += f.Total;
                        Paid.State = (byte)Accounting.InvoiceStateEnum.Varified;

                        bool res = false;
                        if (cash.code == 0)
                        {
                            if (cash.Insert() > 0 && Paid.Update())
                                res = true;
                        }
                        else
                        {
                            if (cash.Update() && Paid.Update())
                                res = true;
                        }
                        if (res)
                        {
                            foreach (System.Data.DataRow dr in Accounting.Factor.FactorItem.JFactorItems.GetDataTable(f.Code).Rows)
                            {
                                try
                                {
                                    WebClassLibrary.JActionsInfo action = new WebClassLibrary.JActionsInfo();
                                    action.Method = dr["ClassName"].ToString() + ".DoOperation";
                                    action.ParameterValue = new List<object>() { dr["parameter"].ToString() };
                                    action.runAction();
                                }
                                catch (Exception err)
                                {

                                }
                            }
                            //اتمام  عملیات
                            RefIdLabel.Text = Paid.RefId;
                            ResCodeLabel.Text = Paid.ResCode;
                            SaleOrderIdLabel.Text = Paid.SaleOrderId;
                            SaleReferenceIdLabel.Text = Paid.SaleReferenceId;

                            lblPrice.Text = Paid.Price.ToString();
                            lblTotal.Text = cash.paid.ToString();

                            try
                            {
                                WebClassLibrary.JWebManager.LoadClientControl("ViewFactor"
                                        , "~/WebAccounting/Forms/ViewFactor.ascx"
                                        , "نمایش فاکتور"
                                        , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", f.Code.ToString()) }
                                        , WebClassLibrary.WindowTarget.NewWindow
                                        , true, false, true, 630, 350);

                                Response.Redirect("/Controls.aspx?SUID=ViewFactor&Code=" + f.Code.ToString());

                            }
                            catch
                            {
                            }
                            return;// 
                        }
                    }
                }
                //اگربه این  جا برسد عملیات ناموف و پول برگشت میخورد
                pay.bpReversalRequest(1586805, "sms47", "62965982", long.Parse(Paid.SaleOrderId), long.Parse(Paid.SaleOrderId), long.Parse(Paid.SaleReferenceId));
                
            }
            
        }
    }
}