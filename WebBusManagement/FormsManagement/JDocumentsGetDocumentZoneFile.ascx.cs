using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace WebBusManagement.FormsManagement
{
    public partial class JDocumentsGetDocumentZoneFile : System.Web.UI.UserControl
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
            //string line = "1   1   " + SumPrice;
            //sb.AppendLine(line);
            //line = BusManagment.Settings.JBusSettings.Get("BusCompanyAccountNumber").ToString() + " " + SumPrice + " D";
            //sb.AppendLine(line);

            System.Data.DataTable table = WebClassLibrary.JWebDataBase.GetDataTable(@"select az.Code,az.Name ZoneName,ad.TicketPrice * 10 as TicketPrice,cast(Sum(ad.Price) as float)*10.0 Amount,sum(ad.TCount)TCount from AUTDailyPerformanceRportOnBus ad
                                                                                        left join AUTLine al on al.LineNumber = ad.LineNumber
                                                                                        left join AUTZone az on az.Code = al.ZoneCode
                                                                                        where DocumentCode = " + code + @"
                                                                                        Group by az.Code,az.Name,ad.TicketPrice
                                                                                        order by az.Code");
            sb.AppendLine("<table>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th> Zone Code </th>");
            sb.AppendLine("<th> Zone Name </th>");
            sb.AppendLine("<th> Ticket Price </th>");
            sb.AppendLine("<th> Ticket Count </th>");
            sb.AppendLine("<th> Price (Rial) </th>");
            sb.AppendLine("<th> Karmozd (" + BusManagment.Settings.JBusSettings.Get("BusPeymankarPercent").ToString() + @"%) (Rial) </th>");
            sb.AppendLine("<th> Hosne Anhame Kar (" + BusManagment.Settings.JBusSettings.Get("BusHosneAnjameKarPercent").ToString() + @"%) (Rial) </th>");
            sb.AppendLine("<th> Bimeh (" + BusManagment.Settings.JBusSettings.Get("BusInsurancePercent").ToString() + @"%) (Rial) </th>");
            sb.AppendLine("<th> Maliyat (" + BusManagment.Settings.JBusSettings.Get("BusMaliyatPercent").ToString() + @"%) (Rial) </th>");
            sb.AppendLine("</tr>");

            long SumTcount = 0;
            Double SumKarmoz = 0, SumHosneAnjameKar = 0, SumBime = 0, SumMaliyat = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {

                sb.AppendLine("<tr>");
                sb.AppendLine("<th> " + table.Rows[i]["Code"].ToString() + " </th>");
                sb.AppendLine("<th> " + table.Rows[i]["ZoneName"].ToString() + " </th>");
                sb.AppendLine("<th> " + table.Rows[i]["TicketPrice"].ToString() + " </th>");
                sb.AppendLine("<th> " + table.Rows[i]["TCount"].ToString() + " </th>");
                sb.AppendLine("<th> " + table.Rows[i]["Amount"].ToString() + " </th>");
                sb.AppendLine("<th> " + ((Convert.ToDouble(table.Rows[i]["Amount"].ToString()) / 100) * Convert.ToDouble(BusManagment.Settings.JBusSettings.Get("BusPeymankarPercent").ToString())).ToString() + " </th>");
                sb.AppendLine("<th> " + (Convert.ToDouble(((Convert.ToDouble(table.Rows[i]["Amount"].ToString()) / 100) * Convert.ToDouble(BusManagment.Settings.JBusSettings.Get("BusPeymankarPercent").ToString())) / 100) * Convert.ToDouble(BusManagment.Settings.JBusSettings.Get("BusHosneAnjameKarPercent").ToString())).ToString() + " </th>");
                sb.AppendLine("<th> " + (Convert.ToDouble(((Convert.ToDouble(table.Rows[i]["Amount"].ToString()) / 100) * Convert.ToDouble(BusManagment.Settings.JBusSettings.Get("BusPeymankarPercent").ToString())) / 100) * Convert.ToDouble(BusManagment.Settings.JBusSettings.Get("BusInsurancePercent").ToString())).ToString() + " </th>");
                sb.AppendLine("<th> " + (Convert.ToDouble(((Convert.ToDouble(table.Rows[i]["Amount"].ToString()) / 100) * Convert.ToDouble(BusManagment.Settings.JBusSettings.Get("BusPeymankarPercent").ToString())) / 100) * Convert.ToDouble(BusManagment.Settings.JBusSettings.Get("BusMaliyatPercent").ToString())).ToString() + " </th>");
                sb.AppendLine("</tr>");
                SumTcount += Convert.ToInt64(table.Rows[i]["TCount"].ToString());
                SumKarmoz += Convert.ToDouble(((Convert.ToDouble(table.Rows[i]["Amount"].ToString()) / 100) * Convert.ToDouble(BusManagment.Settings.JBusSettings.Get("BusPeymankarPercent").ToString())));
                SumHosneAnjameKar += Convert.ToDouble((Convert.ToDouble(((Convert.ToDouble(table.Rows[i]["Amount"].ToString()) / 100) * Convert.ToDouble(BusManagment.Settings.JBusSettings.Get("BusPeymankarPercent").ToString())) / 100) * Convert.ToDouble(BusManagment.Settings.JBusSettings.Get("BusHosneAnjameKarPercent").ToString())));
                SumBime += Convert.ToDouble((Convert.ToDouble(((Convert.ToDouble(table.Rows[i]["Amount"].ToString()) / 100) * Convert.ToDouble(BusManagment.Settings.JBusSettings.Get("BusPeymankarPercent").ToString())) / 100) * Convert.ToDouble(BusManagment.Settings.JBusSettings.Get("BusInsurancePercent").ToString())));
                SumMaliyat += Convert.ToDouble((Convert.ToDouble(((Convert.ToDouble(table.Rows[i]["Amount"].ToString()) / 100) * Convert.ToDouble(BusManagment.Settings.JBusSettings.Get("BusPeymankarPercent").ToString())) / 100) * Convert.ToDouble(BusManagment.Settings.JBusSettings.Get("BusMaliyatPercent").ToString())));
            }

            string ExcelFileName = "Zone-Document-Code" + code;

            sb.AppendLine("<tr>");
            sb.AppendLine("<th> </th>");
            sb.AppendLine("<th> </th>");
            sb.AppendLine("<th> </th>");
            sb.AppendLine("<th> </th>");
            sb.AppendLine("<th> </th>");
            sb.AppendLine("<th> </th>");
            sb.AppendLine("<th> </th>");
            sb.AppendLine("<th> </th>");
            sb.AppendLine("<th> </th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</table>");
            sb.AppendLine("<table>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th> </th>");
            sb.AppendLine("<th> </th>");
            sb.AppendLine("<th> Sum </th>");
            sb.AppendLine("<th> " + SumTcount + " </th>");
            sb.AppendLine("<th> " + SumPrice + " </th>");
            sb.AppendLine("<th> " + SumKarmoz + " </th>");
            sb.AppendLine("<th> " + SumHosneAnjameKar + " </th>");
            sb.AppendLine("<th> " + SumBime + " </th>");
            sb.AppendLine("<th> " + SumMaliyat + " </th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th> </th>");
            sb.AppendLine("<th> </th>");
            sb.AppendLine("<th> DocumentCode " + Code + " </th>");
            sb.AppendLine("<th> Date " + GetDatePeroid(code) + " </th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th> </th>");
            sb.AppendLine("<th> </th>");
            sb.AppendLine("<th> Sum Price Of Document " + SumPrice + " </th>");
            sb.AppendLine("<th> Karmozd (" + BusManagment.Settings.JBusSettings.Get("BusPeymankarPercent").ToString() + @"%) " + SumKarmoz + " </th>");
            sb.AppendLine("<th> Kosoorat " + (SumHosneAnjameKar + SumBime + SumMaliyat).ToString() + " </th>");
            sb.AppendLine("<th> Ghablele Pardakht Be Peymankar " + (SumKarmoz - (SumHosneAnjameKar + SumBime + SumMaliyat)).ToString() + " </th>");
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

        public string GetDatePeroid(string DocumentCode)
        {
            string Query = "select dbo.DateEnToFa(min(Date))FromDate,dbo.DateEnToFa(max(Date))ToDate from AUTDocumentDate where DocumentCode = " + DocumentCode;
            string Res = "";
            System.Data.DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(Query);
            Res = Dt.Rows[0]["FromDate"].ToString() + " - " + Dt.Rows[0]["ToDate"].ToString();
            return Res;
        }

        public string GetPaymentPriceSum(string PaymentCode)
        {
            string Res = "";
            System.Data.DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT cast(Sum(ad.price) as float) * 10.0 as PaymentPrice FROM AUTDailyPerformanceRportOnBus ad WHERE ad.DocumentCode=" + PaymentCode);
            Res = Dt.Rows[0]["PaymentPrice"].ToString();
            return Res;
        }
    }
}