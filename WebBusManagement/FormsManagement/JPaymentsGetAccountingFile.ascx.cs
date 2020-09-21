using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace WebBusManagement.FormsManagement
{
    public partial class JPaymentsGetAccountingFile : System.Web.UI.UserControl
    {
        int Code;


        public string FarsiNumber(string pNum)
        {
            string Temp = pNum;
            char[] En = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] Fa = { '۰', '۱', '۲', '۳', '۴', '۵', '۶', '۷', '۸', '۹' };
            for(int i=0;i<10;i++)
            {
                Temp = Temp.Replace(En[i], Fa[i]);
            }
            return Temp;
        }

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
            //string line = "1   1   " + SumPrice;
            //sb.AppendLine(line);
            //line = BusManagment.Settings.JBusSettings.Get("BusCompanyAccountNumber").ToString() + " " + SumPrice + " D";
            //sb.AppendLine(line);
            
            System.Data.DataTable table = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT row_number() over(order by fcc.value ) radif,
 ad.OwnerPCode,fba.AccountNo as AccountNo,Sum(ad.PaymentPrice)PaymentPrice,
                                                                            ISNULL(fcc.Value,0) as TafsiliCode,ap.[Description] as Description,cap.Name OwnerName 
                                                                            FROM AUTPaymentDetail ad 
                                                                            left join finBankAccount fba on fba.PCode = ad.OwnerPCode
                                                                            LEFT JOIN clsAllPerson cap ON cap.code = ad.OwnerPCode
                                                                            left join AutPayment ap on ap.Code = ad.PaymentCode
                                                                            left join (select * from finComparativeCode where ClassName = 'ClassLibrary.Person.AllPerson') fcc on fcc.ObjectCode = cap.Code
                                                                            WHERE ad.PaymentCode=" + code + @"
                                                                            Group by ad.code,ad.OwnerPCode,fba.AccountNo,fcc.Value,ap.[Description],cap.Name
                                                                           order by fcc.value");

            //            System.Data.DataTable table = WebClassLibrary.JWebDataBase.GetDataTable(@"select fdd.TafziliCode1 OwnerPCode,fba.AccountNo as AccountNo,
            //                                                                            (sum(fdd.BesPrice) - sum(fdd.BedPrice))PaymentPrice,ISNULL(fcc.Value,0) as TafsiliCode,
            //                                                                            Max(N'پرداخت '+cast(dbo.DateEnToFa(getdate()) as nvarchar))Description,cap.Name OwnerName
            //                                                                            from FinDocumentDetails fdd
            //                                                                            left join finBankAccount fba on fba.PCode = fdd.TafziliCode1
            //                                                                            left join (select * from finComparativeCode where ClassName = 'ClassLibrary.Person.AllPerson') fcc on fcc.ObjectCode = fdd.TafziliCode1
            //                                                                            LEFT JOIN clsAllPerson cap ON cap.code = fdd.TafziliCode1
            //                                                                            where MoeinCode=3
            //                                                                            group by  fdd.TafziliCode1,fba.AccountNo,fcc.Value,cap.Name
            //                                                                            having sum(fdd.BesPrice) - sum(fdd.BedPrice)>0");
            
          
            sb.AppendLine("<meta http-equiv=Content-Type content=text/html; charset=utf-8>");
            sb.AppendLine("<table border=1 width=100% >");
            sb.AppendLine("<thead> ");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th > Owner Name </th>");
            sb.AppendLine("<th> Discription </th>");
            sb.AppendLine("<th> Price (Rial) </th>");
            sb.AppendLine("<th> Account Number </th>");
            sb.AppendLine("<th> Tafsili Code </th>");
            sb.AppendLine("<th> radif </th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</thead>");



            string Radif="", AccountNumber = "", PaymentPrice = "", TafsiliCode = "";
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
                Radif = FarsiNumber(Radif);
                AccountNumber = FarsiNumber (AccountNumber);
                PaymentPrice = FarsiNumber(PaymentPrice);
                TafsiliCode = FarsiNumber(TafsiliCode);

                //sb.AppendLine(AccountNumber +
                // " " + PaymentPrice);

                sb.AppendLine("<tr>");
                sb.AppendLine("<th> " + table.Rows[i]["OwnerName"].ToString() + " </th>");
                sb.AppendLine("<th style= font-size:10px> " + FarsiNumber( table.Rows[0]["Description"].ToString()) + " </th>");
                sb.AppendLine("<th> " + PaymentPrice + " </th>");
                sb.AppendLine("<th> " + AccountNumber + " </th>");
                sb.AppendLine("<th> " + TafsiliCode + " </th>");
                sb.AppendLine("<th> " + Radif + " </th>");
                sb.AppendLine("</tr>");
                
            }

            //using this code for repeat header in each printing page

            sb.AppendLine(@" <style>
                  div.fauxRow {
                  display: inline-block;
                  vertical-align: top;
                  width: 100%;
                  page-break-inside: avoid;
                }
                table.fauxRow {border-spacing: 0;}
                table.fauxRow > tbody > tr > td {
                  padding: 0;
                  overflow: hidden;
                }
                table.fauxRow > tbody > tr > td > table.print {
                  display: inline-table;
                  vertical-align: top;
                }
                table.fauxRow > tbody > tr > td > table.print > caption {caption-side: top;}
                .noBreak {
                  float: right;
                  width: 100%;
                  visibility: hidden;
                }
                .noBreak:before, .noBreak:after {
                  display: block;
                  content: "";
                }
                .noBreak:after {margin-top: -594mm;}
                .noBreak > div {
                  display: inline-block;
                  vertical-align: top;
                  width:100%;
                  page-break-inside: avoid;
                }
                table.print > tbody > tr {page-break-inside: avoid;}
                table.print > tbody > .metricsRow > td {border-top: none !important;}

                table.fauxRow, table.print {
                  font-size: 16px;
                  line-height: 20px;
                }

                body {counter-reset: t1;} 
                .noBreak .t1 > tbody > tr > :first-child:before {counter-increment: none;} 
                .t1 > tbody > tr > :first-child:before {
                  display: block;
                  text-align: right;
                  counter-increment: t1 1;
                  content: counter(t1);
                }
                table.fauxRow, table.print {
                  font-family: Tahoma, Verdana, Georgia;
                  margin: 0 auto 0 auto;
                }
                table.print {border-spacing: 0;}
                table.print > * > tr > * {
                  border-right: 2px solid black;
                  border-bottom: 2px solid black;
                  padding: 0 5px 0 5px;
                }
                table.print > * > :first-child > * {border-top: 2px solid black;}
                table.print > thead ~ * > :first-child > *, table.print > tbody ~ * > :first-child > * {border-top: none;}
                table.print > * > tr > :first-child {border-left: 2px solid black;}
                table.print > thead {vertical-align: bottom;}
                table.print > thead > .borderRow > th {border-bottom: none;}
                table.print > tbody {vertical-align: top;}
                table.print > caption {font-weight: bold;}
            </style>

            <script>
              (function() { 
                var rowCount = 100
                  , tbod = document.querySelector(table.print > tbody)
                  , row = tbod.rows[0];
                        for (; --rowCount; tbod.appendChild(row.cloneNode(true))) ;
                    })();

              (function()
                    { 
                        if (/ Firefox | MSIE | Trident / i.test(navigator.userAgent))
                            var formatForPrint = function(table) {
                            var noBreak = document.createElement(div)
                              , noBreakTable = noBreak.appendChild(document.createElement(div)).appendChild(table.cloneNode())
                              , tableParent = table.parentNode
                              , tableParts = table.children
                              , partCount = tableParts.length
                              , partNum = 0
                              , cell = table.querySelector(tbody > tr > td);
                            noBreak.className = noBreak;
                            for (; partNum < partCount; partNum++)
                            {
                                if (!/ tbody / i.test(tableParts[partNum].tagName))
                                    noBreakTable.appendChild(tableParts[partNum].cloneNode(true));
                            }
                            if (cell)
                            {
                                noBreakTable.appendChild(cell.parentNode.parentNode.cloneNode()).appendChild(cell.parentNode.cloneNode(true));
                                if (!table.tHead)
                                {
                                    var borderRow = document.createElement(tr);
                                    borderRow.appendChild(document.createElement(th)).colSpan = 1000;
                                    borderRow.className = borderRow;
                                    table.insertBefore(document.createElement(thead), table.tBodies[0]).appendChild(borderRow);
                                }
                            }
                            tableParent.insertBefore(document.createElement(div), table).style.paddingTop = .009px;
                            tableParent.insertBefore(noBreak, table);
                        };
                else
                  var formatForPrint = function(table) {
                            var tableParent = table.parentNode
                              , cell = table.querySelector(tbody > tr > td);
                            if (cell)
                            {
                                var topFauxRow = document.createElement(table)
                                  , fauxRowTable = topFauxRow.insertRow(0).insertCell(0).appendChild(table.cloneNode())
                                  , colgroup = fauxRowTable.appendChild(document.createElement(colgroup))
                                  , headerHider = document.createElement(div)
                                  , metricsRow = document.createElement(tr)
                                  , cells = cell.parentNode.cells
                                  , cellNum = cells.length
                                  , colCount = 0
                                  , tbods = table.tBodies
                                  , tbodCount = tbods.length
                                  , tbodNum = 0
                                  , tbod = tbods[0];
                                for (; cellNum--; colCount += cells[cellNum].colSpan) ;
                                for (cellNum = colCount; cellNum--; metricsRow.appendChild(document.createElement(td)).style.padding = 0) ;
                                cells = metricsRow.cells;
                                tbod.insertBefore(metricsRow, tbod.firstChild);
                                for (; ++cellNum < colCount; colgroup.appendChild(document.createElement(col)).style.width = cells[cellNum].offsetWidth + px) ;
                                var borderWidth = metricsRow.offsetHeight;
                                metricsRow.className = metricsRow;
                                borderWidth -= metricsRow.offsetHeight;
                                tbod.removeChild(metricsRow);
                                tableParent.insertBefore(topFauxRow, table).className = fauxRow;
                                if (table.tHead)
                                    fauxRowTable.appendChild(table.tHead);
                                var fauxRow = topFauxRow.cloneNode(true)
                                  , fauxRowCell = fauxRow.rows[0].cells[0];
                                fauxRowCell.insertBefore(headerHider, fauxRowCell.firstChild).style.marginBottom = -fauxRowTable.offsetHeight - borderWidth + px;
                                if (table.caption)
                                    fauxRowTable.insertBefore(table.caption, fauxRowTable.firstChild);
                                if (tbod.rows[0])
                                    fauxRowTable.appendChild(tbod.cloneNode()).appendChild(tbod.rows[0]);
                                for (; tbodNum < tbodCount; tbodNum++)
                                {
                                    tbod = tbods[tbodNum];
                                    rows = tbod.rows;
                                    for (; rows[0]; tableParent.insertBefore(fauxRow.cloneNode(true), table).rows[0].cells[0].children[1].appendChild(tbod.cloneNode()).appendChild(rows[0])) ;
                                }
                                tableParent.removeChild(table);
                            }
                            else
                                tableParent.insertBefore(document.createElement(div), table).appendChild(table).parentNode.className = fauxRow;
                        };
                        var tables = document.body.querySelectorAll(table.print)
                          , tableNum = tables.length;
                        for (; tableNum--; formatForPrint(tables[tableNum])) ;
                    })();
            </script> ");
            //end of repeating script

     


    // byte[] BytesDescription = Encoding.Default.GetBytes(table.Rows[0]["Description"].ToString());
    // byte[] BytesDescription = Encoding.Default.GetBytes("سلام فارسی");

    string ExcelFileName = table.Rows[0]["Description"].ToString() + " - PaymentCode" + code;

            sb.AppendLine("<tr>");
            sb.AppendLine("<th>  Sum Price  </th>");
            sb.AppendLine("<th> " + FarsiNumber(table.Rows[0]["Description"].ToString()) + "</th>");
            sb.AppendLine("<th> " + SumPrice + "</th>");
            sb.AppendLine("</tr>");
            sb.AppendLine("</table>");
            //sb.AppendLine("<table border=1>");
            //sb.AppendLine("<tr>");
            //sb.AppendLine("<th> </th>");
            //sb.AppendLine("<th> </th>");
            //sb.AppendLine("<th> Sum Price </th>");
            //sb.AppendLine("</tr>");
            //sb.AppendLine("<tr>");
            //sb.AppendLine("<th> </th>");
            //sb.AppendLine("<th> " + FarsiNumber(table.Rows[0]["Description"].ToString()) + " </th>");
            //sb.AppendLine("<th> " + SumPrice + " </th>");
            //sb.AppendLine("</tr>");
            //sb.AppendLine("</table>");



            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment; filename=PaymentCode" + code + ".html");
            
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
            return FarsiNumber(Res);
        }

    }
}