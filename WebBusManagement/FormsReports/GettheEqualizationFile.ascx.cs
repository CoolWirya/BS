using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebClassLibrary;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsReports
{
    public partial class GettheEqualizationFile : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            CreatePaymentFile(Code.ToString());
            WebClassLibrary.JWebManager.CloseWindow();
        }

        public void CreatePaymentFile(string code)
        {

            //try
            //{
            //    ClassLibrary.JDataBase dbAccProc = new ClassLibrary.JDataBase();
            //    dbAccProc.setQuery("EXEC SP_FinDocumentDetailToFinDocument");
            //    dbAccProc.Query_Execute();
            //}
            //catch { }

            //try
            //{
            //    ClassLibrary.JDataBase dbAccProc = new ClassLibrary.JDataBase();
            //    dbAccProc.setQuery("EXEC SP_FinPaymentCDToFinDocument " + Code);
            //    dbAccProc.Query_Execute();
            //}
            //catch { }

            var sb = new System.Text.StringBuilder();
            string SumPrice = GetPaymentPriceSum(code);
            string line = "1   1   " + SumPrice;
            sb.AppendLine(line);
            line = BusManagment.Settings.JBusSettings.Get("BusCompanyAccountNumber").ToString() + " " + SumPrice + " D";
            sb.AppendLine(line);

            System.Data.DataTable table = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT ad.OwnerPCode,fba.AccountNo as AccountNo,Sum(ad.PaymentPrice)PaymentPrice
                                                                                    ,max(ap.Description)PDiscription 
                                                                            FROM AUTPaymentDetail ad 
                                                                            left join finBankAccount fba on fba.PCode = ad.OwnerPCode
                                                                            left join AUTPayment ap on ap.Code = ad.PaymentCode
                                                                            WHERE ad.PaymentCode=" + code + @" 
                                                                            Group by ad.OwnerPCode,fba.AccountNo
                                                                            order by PaymentPrice");
            //            System.Data.DataTable table = WebClassLibrary.JWebDataBase.GetDataTable(@"select fdd.TafziliCode1 OwnerPCode,fba.AccountNo as AccountNo,
            //                                                                            (sum(fdd.BesPrice) - sum(fdd.BedPrice))PaymentPrice,
            //                                                                            Max(N'پرداخت '+cast(dbo.DateEnToFa(getdate()) as nvarchar))PDiscription
            //                                                                            from FinDocumentDetails fdd
            //                                                                            left join finBankAccount fba on fba.PCode = fdd.TafziliCode1 where MoeinCode=3
            //                                                                            group by  fdd.TafziliCode1,fba.AccountNo
            //                                                                            having sum(fdd.BesPrice) - sum(fdd.BedPrice)>0");

            string AccountNumber = "", PaymentPrice = "";
            for (int i = 0; i < table.Rows.Count; i++)
            {
                AccountNumber = table.Rows[i]["AccountNo"].ToString();
                PaymentPrice = (Convert.ToInt32(table.Rows[i]["PaymentPrice"].ToString()) * 10).ToString();
                long Price, AcNumber;
                if (long.TryParse(AccountNumber, out AcNumber) == false)
                    AccountNumber = "0";
                if (long.TryParse(PaymentPrice, out Price) == false)
                    PaymentPrice = "0";
                sb.AppendLine(AccountNumber +
                    " " + PaymentPrice + " C");
            }

            //sb.AppendLine("     ");

            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-disposition", "attathment;filename=document.txt");
            Response.AddHeader("Content-Length", sb.Length.ToString());
            Response.Write(sb.ToString());
            Response.Flush();
            Response.End();

            WebClassLibrary.JWebManager.CloseWindow();

            //Encoding outputEnc = new UTF8Encoding(false); // create encoding with no BOM
            //TextWriter file = new StreamWriter(HttpContext.Current.Server.MapPath("~/document.txt"), false, outputEnc); // open file with encoding
            //file.WriteLine(sb);
            //file.Close();
            //System.Diagnostics.Process.Start(HttpContext.Current.Server.MapPath("~/document.txt"));
        }

        public string GetPaymentPriceSum(string PaymentCode)
        {
            string Res = "";
            System.Data.DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT ad.OwnerPCode,Sum(ad.PaymentPrice) * 10 as PaymentPrice FROM AUTPaymentDetail ad 
                                                                                    WHERE ad.PaymentCode=" + PaymentCode + @" 
                                                                                    Group by ad.OwnerPCode
                                                                                    order by PaymentPrice");
            Int64 SumPrice = 0;
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                SumPrice += Convert.ToInt64(Dt.Rows[i]["PaymentPrice"].ToString());
            }
            Res = SumPrice.ToString();
            return Res;
        }

    }
}