using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JPaymentGetDetailReportControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            GetReport(Code);
            //GetReportTotal(Code);
        }

        public void GetReport(int PaymentCode)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("JPaymentGetDetailReportControl");
            jGridView.ClassName = "WebBusManagement_FormsManagement_JPaymentGetDetailReportControl_" + PaymentCode;
            jGridView.SQL = @"select top 100 percent 
row_number() over(order by apd.code) radif,cap.name ownername, ap.[Description],apd.TotalPrice * 10 as TotalPrice, fba.accountno, fcc.Value TafsiliCode
						  from AUTPaymentDetail apd
                                left join clsAllPerson cap on cap.Code = apd.OwnerPCode
                                left join AutPayment ap on ap.Code = apd.PaymentCode
                                left join (select * from finComparativeCode		where ClassName = 'ClassLibrary.Person.AllPerson') fcc on fcc.ObjectCode = cap.Code
								left join finBankAccount fba on fba.pcode=cap.code

                                where PaymentCode=" + PaymentCode.ToString();
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JPaymentGetDetailReportControl";
            jGridView.PageOrderByField = "OwnerName";
            jGridView.Buttons = "excel";
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("TotalPrice", 0);
            jGridView.SumFields.Add("PaymentPrice", 0);
            jGridView.Bind();

        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Code > 0)
            {
                if (!ClassLibrary.JPermission.CheckPermission("BusManagment.Documents.JAUTPayments.CascadeDelete"))
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('شما دسترسی مورد نیاز برای انجام این عملیات را ندارید');", "err");
                    return;
                }
                JDataBase db = new JDataBase();
                db.beginTransaction("PaymentCascadeDelete");
                BusManagment.Documents.JAUTPayment payment = new BusManagment.Documents.JAUTPayment();
                if (!payment.GetData(db, Code))
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('دوباره تلاش کنید');", "err");
                    db.Rollback("PaymentCascadeDelete");
                    return;
                }

                if (payment.PaymentDate != new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('فقط سند پرداخت روز جاری قابل حذف می باشد');", "err");
                    db.Rollback("PaymentCascadeDelete");
                    return;
                }

                if (payment.CascadeDelete(db))
                {
                    db.Commit();
                    WebClassLibrary.JWebManager.RunClientScript("alert('عملیات با موفقیت انجام شد');", "err");
                }
                else 
                {
                    db.Rollback("PaymentCascadeDelete");
                    WebClassLibrary.JWebManager.RunClientScript("alert('دوباره تلاش کنید');", "err");
                }
            }
        }

        //        public void GetReportTotal(int PaymentCode)
        //        {
        //           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("JPaymentGetDetailReportControlTotal");
        //            jGridView.SQL = @"select top 100 percent max(apd.Code)Code,apd.PaymentCode,sum(apd.TotalPrice) * 10 as TotalPrice,sum(apd.PaymentPrice * 10) as PaymentPrice from AUTPaymentDetail apd
        //                                where PaymentCode=" + PaymentCode.ToString()
        //                                + @"Group By apd.PaymentCode";
        //            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
        //            jGridView.PageSize = 50;
        //            jGridView.HiddenColumns = "Code";
        //            jGridView.Title = "JPaymentGetDetailReportControlTotal";
        //            jGridView.Buttons = "excel";
        //            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReportTotal).GridView = jGridView;
        //            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReportTotal).LoadGrid(true);
        //        }

    }
}