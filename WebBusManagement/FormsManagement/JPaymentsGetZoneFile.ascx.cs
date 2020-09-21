using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace WebBusManagement.FormsManagement
{
    public partial class JPaymentsGetZoneFile : System.Web.UI.UserControl
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
            //    dbAccProc.setQuery("EXEC SP_FinPaymentCDToFinDocument " + Code);
            //    dbAccProc.Query_Execute();
            //}
            //catch { }

            var sb = new System.Text.StringBuilder();
            string SumPrice = GetPaymentPriceSum(code);
            //string line = "1   1   " + SumPrice;
            //sb.AppendLine(line);
            //line = BusManagment.Settings.JBusSettings.Get("BusCompanyAccountNumber").ToString() + " " + SumPrice + " D";
            //sb.AppendLine(line);

            System.Data.DataTable table = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT az.Code,az.Name ZoneName,Sum(ad.PaymentPrice)*10 PaymentPrice 
                                                                                        FROM AUTPaymentDetail ad                                                                
                                                                                            left join AUTBus ab on ab.Code = ad.TotalPrice
                                                                                            left join AUTLine al on al.LineNumber = ab.LastLineNumber
                                                                                            left join AUTZone az on az.Code = al.ZoneCode
                                                                                            WHERE ad.PaymentCode=" + Code+@"
                                                                                            Group by az.Code,az.Name
                                                                                            order by az.Code");
            sb.AppendLine("<table>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th> Zone Code </th>");
            sb.AppendLine("<th> Zone Name </th>");
            sb.AppendLine("<th> Price (Rial) </th>");
            sb.AppendLine("</tr>");

            string PaymentPrice = "";
            for (int i = 0; i < table.Rows.Count; i++)
            {

                PaymentPrice = table.Rows[i]["PaymentPrice"].ToString();

                sb.AppendLine("<tr>");
                sb.AppendLine("<th> " + table.Rows[i]["Code"].ToString() + " </th>");
                sb.AppendLine("<th> " + table.Rows[i]["ZoneName"].ToString() + " </th>");
                sb.AppendLine("<th> " + PaymentPrice + " </th>");
                sb.AppendLine("</tr>");

            }

            string ExcelFileName = "Zone-Payment-Code" + code;

            sb.AppendLine("<tr>");
            sb.AppendLine("<th> </th>");
            sb.AppendLine("<th> </th>");
            sb.AppendLine("<th> </th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</table>");
            sb.AppendLine("<table>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th> </th>");
            sb.AppendLine("<th> </th>");
            sb.AppendLine("<th> Sum Price </th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th> </th>");
            sb.AppendLine("<th> PaymentCode " + Code + " </th>");
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
            Response.AddHeader("Content-Disposition", "attachment; filename=" + ExcelFileName + ".xls");
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
            System.Data.DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT Sum(ad.PaymentPrice) * 10 as PaymentPrice FROM AUTPaymentDetail ad WHERE ad.PaymentCode=" + PaymentCode);
            Res = Dt.Rows[0]["PaymentPrice"].ToString();
            return Res;
        }

    }
}