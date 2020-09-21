using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace WebBusManagement.FormsManagement
{
    public partial class JPaymentsGetAccountingFileexcel : System.Web.UI.UserControl
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

            
            var sb = new System.Text.StringBuilder();
            string SumPrice = GetPaymentPriceSum(code);
            
            System.Data.DataTable table = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT row_number() over(order by ad.code desc) radif,
 ad.OwnerPCode,fba.AccountNo as AccountNo,Sum(ad.PaymentPrice)PaymentPrice,
                                                                            ISNULL(fcc.Value,0) as TafsiliCode,ap.[Description] as Description,cap.Name OwnerName 
                                                                            FROM AUTPaymentDetail ad 
                                                                            left join finBankAccount fba on fba.PCode = ad.OwnerPCode
                                                                            LEFT JOIN clsAllPerson cap ON cap.code = ad.OwnerPCode
                                                                            left join AutPayment ap on ap.Code = ad.PaymentCode
                                                                            left join (select * from finComparativeCode where ClassName = 'ClassLibrary.Person.AllPerson') fcc on fcc.ObjectCode = cap.Code
                                                                            WHERE ad.PaymentCode=" + code + @"
                                                                            Group by ad.code,ad.OwnerPCode,fba.AccountNo,fcc.Value,ap.[Description],cap.Name
                                                                           order by ad.code desc");

            sb.AppendLine("<table border=2 width=100% ");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th>  radif </th>");
            sb.AppendLine("<th>Tafsili Code  </th>");
            sb.AppendLine("<th>Account Number </th>");
            sb.AppendLine("<th> Price (Rial)  </th>");
            sb.AppendLine("<th>Discription  </th>");
            sb.AppendLine("<th >Owner Name </th>");
            sb.AppendLine("</tr>");

            string Radif = "", AccountNumber = "", PaymentPrice = "", TafsiliCode = "";
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Radif = table.Rows[i]["radif"].ToString();
                AccountNumber = table.Rows[i]["AccountNo"].ToString();
                PaymentPrice = (Convert.ToInt32(table.Rows[i]["PaymentPrice"].ToString()) * 10).ToString();
                TafsiliCode = table.Rows[i]["TafsiliCode"].ToString();

                long Price, AcNumber, TafsiliCodeLong;

                if (long.TryParse(AccountNumber, out AcNumber) == false)
                    AccountNumber = "0";
                if (long.TryParse(PaymentPrice, out Price) == false)
                    PaymentPrice = "0";
                if (long.TryParse(TafsiliCode, out TafsiliCodeLong) == false)
                    TafsiliCode = "0";
                
                sb.AppendLine("<tr>");
                sb.AppendLine("<th> " + Radif + " </th>");
                sb.AppendLine("<th> " + TafsiliCode + " </th>");
                sb.AppendLine("<th> " + AccountNumber + " </th>");
                sb.AppendLine("<th> " + PaymentPrice + " </th>");
                sb.AppendLine("<th style= font-size:10px> " + table.Rows[0]["Description"].ToString() + " </th>");
                sb.AppendLine("<th> " + table.Rows[i]["OwnerName"].ToString() + " </th>");
                sb.AppendLine("</tr>");

            }


            
            string ExcelFileName = table.Rows[0]["Description"].ToString() + " - PaymentCode" + code;

            sb.AppendLine("<tr>");
            sb.AppendLine("<th> </th>");
            sb.AppendLine("<th> </th>");
            sb.AppendLine("<th> </th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</table>");
            sb.AppendLine("<table border=2>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th> </th>");
            sb.AppendLine("<th> </th>");
            sb.AppendLine("<th> Sum Price </th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th> </th>");
            sb.AppendLine("<th> " + table.Rows[0]["Description"].ToString() + " </th>");
            sb.AppendLine("<th> " + SumPrice + " </th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</table>");

            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "application/vnd.ms-excel";
            //EO.Pdf.HtmlToPdf.ConvertHtml(htmlText, pdfFileName);
            Response.AddHeader("Content-Disposition", "attachment; filename=PaymentCode" + code + ".xls");

            Response.Write(sb.ToString());
            Response.Flush();
            Response.End();
            //string Content = Encoding.UTF8.GetString(table);
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