using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JCityBankPaymentsGetFile : System.Web.UI.UserControl
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
            string TransactionCount = GetTransactionCount(code);
            string FileName = GetName(code);

            string line = TransactionCount + ";" + SumPrice + ";" + DateTime.Now.ToString() + ";" + BusManagment.Settings.JBusSettings.Get("InstituteCode").ToString();
            sb.AppendLine(line);


            System.Data.DataTable table = WebClassLibrary.JWebDataBase.GetDataTable(@"select [Code]
                              ,[EventDate]
                              ,[RecievedDate]
                              ,[DriverCardSerial]
                              ,[DriverPersonCode]
                              ,[DriverPersonName]
                              ,[LineNumber]
                              ,[ZoneName]
                              ,[FleetName]
                              ,[BusNumber]
                              ,[PassengerCardSerial]
                              ,[CardType]
                              ,[TicketPrice] * 10 TicketPrice
                              ,[RemainPrice]
                              ,[ReaderId]
                              ,[Bin] CBin
                              ,[TerminalID]
                              ,[WaletID]
                              ,[CType]
                              ,[LTD]
                              ,[ServerMac]
                              ,[MacOut]
                              ,[LTB]
                              ,[Counter]
                              ,[ServerID]
                              ,[BankType]
	                          from AUTTicketTransactionCityBank where FileGenerate = " + code + " Order by [EventDate]");

            string BankType = "", TerminalID = "", TerminalIdTEMP = "", TicketPrice = "", TicketPriceTEMP = "", CCODE = "", CCODETEMP = "", LTID = "",
                LTIDTemp = "", Balance = "", BalanceTemp = "", Mac = "", MacTemp = "", LTB = "", LTBTemp = "",
                Counter = "", CounterTemp = "", ServerId = "", ServerIdTemp = "";
            string TransactionType = "", TransactionId = "", PaymentInfo = "", MedialInfo = "", MediaID = "";
            for (int i = 0; i < table.Rows.Count; i++)
            {
                BankType = table.Rows[i]["BankType"].ToString();

                TerminalID = table.Rows[i]["TerminalID"].ToString();
                if (TerminalID.Length < 8)
                {
                    for (int j = 0; j < (8 - TerminalID.Length); j++)
                    {
                        TerminalIdTEMP += "0";
                    }
                    TerminalIdTEMP += TerminalID;
                    TerminalID = TerminalIdTEMP;
                }

                TicketPrice = table.Rows[i]["TicketPrice"].ToString();
                if (TicketPrice.Length < 8)
                {
                    for (int j = 0; j < (8 - TicketPrice.Length); j++)
                    {
                        TicketPriceTEMP += "0";
                    }
                    TicketPriceTEMP += TicketPrice;
                    TicketPrice = TicketPriceTEMP;
                }

                CCODE = table.Rows[i]["Code"].ToString();
                if (CCODE.Length < 6)
                {
                    for (int j = 0; j < (6 - CCODE.Length); j++)
                    {
                        CCODETEMP += "0";
                    }
                    CCODETEMP += CCODE;
                    CCODE = CCODETEMP;
                }

                LTID = table.Rows[i]["LTD"].ToString();
                if (LTID.Length < 8)
                {
                    for (int j = 0; j < (8 - LTID.Length); j++)
                    {
                        LTIDTemp += "0";
                    }
                    LTIDTemp += LTID;
                    LTID = LTIDTemp;
                }

                Balance = table.Rows[i]["RemainPrice"].ToString();
                if (Balance.Length < 8)
                {
                    for (int j = 0; j < (8 - Balance.Length); j++)
                    {
                        BalanceTemp += "0";
                    }
                    BalanceTemp += Balance;
                    Balance = BalanceTemp;
                }

                Mac = table.Rows[i]["ServerMac"].ToString();
                if (Mac.Length < 16)
                {
                    for (int j = 0; j < (16 - Mac.Length); j++)
                    {
                        MacTemp += "0";
                    }
                    MacTemp += Mac;
                    Mac = MacTemp;
                }

                LTB = table.Rows[i]["LTB"].ToString();
                if (LTB.Length < 2)
                {
                    for (int j = 0; j < (2 - LTB.Length); j++)
                    {
                        LTBTemp += "0";
                    }
                    LTBTemp += LTB;
                    LTB = LTBTemp;
                }

                Counter = table.Rows[i]["Counter"].ToString();
                if (Counter.Length < 4)
                {
                    for (int j = 0; j < (4 - Counter.Length); j++)
                    {
                        CounterTemp += "0";
                    }
                    CounterTemp += Counter;
                    Counter = CounterTemp;
                }

                ServerId = table.Rows[i]["ServerID"].ToString();
                if (ServerId.Length < 8)
                {
                    for (int j = 0; j < (8 - ServerId.Length); j++)
                    {
                        ServerIdTemp += "0";
                    }
                    ServerIdTemp += ServerId;
                    ServerId = ServerIdTemp;
                }

                if (BankType == "2")
                {
                    TransactionType = "W";
                    PaymentInfo = System.Text.Encoding.Default.GetString(ToBcd(Convert.ToInt32(table.Rows[i]["TicketPrice"].ToString())));
                    MedialInfo = TerminalID + LTB + Counter + TicketPrice + Balance + ServerId +
                        table.Rows[i]["EventDate"].ToString().Replace("-", "").Replace(":", "").Replace(" ", "").Substring(2, table.Rows[i]["EventDate"].ToString().Length) + Mac;
                }
                else if (BankType == "3")
                {
                    TransactionType = "P";
                    PaymentInfo = System.Text.Encoding.Default.GetString(ToBcd(Convert.ToInt32(table.Rows[i]["TicketPrice"].ToString()))) + "; "
                        + BusManagment.Settings.JBusSettings.Get("merchantCode").ToString() + " ; " + BusManagment.Settings.JBusSettings.Get("TerminalCode").ToString();
                    MedialInfo = "00" + TerminalID + table.Rows[i]["EventDate"].ToString().Replace("-", "").Replace(":", "").Replace(" ", "") + TicketPrice
                        + CCODE + "01" + "00" + LTID + Balance + Mac;
                }

                MediaID = table.Rows[i]["PassengerCardSerial"].ToString();
                TransactionId = table.Rows[i]["Code"].ToString();

                sb.AppendLine(TransactionType + ";" + TransactionId + ";" + PaymentInfo + ";" + MedialInfo + ";" + MediaID);
            }

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
        }

        public static byte[] ToBcd(int value)
        {
            if (value < 0 || value > 99999999)
                throw new ArgumentOutOfRangeException("value");
            byte[] ret = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                ret[i] = (byte)(value % 10);
                value /= 10;
                ret[i] |= (byte)((value % 10) << 4);
                value /= 10;
            }
            return ret;
        }

        public string GetPaymentPriceSum(string PaymentCode)
        {
            string Res = "";
            System.Data.DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Name,TransactionCount,TransactionSum * 10 TransactionSum,Date from [AutCityBankSettlementFile] where Code = " + PaymentCode);
            Res = Dt.Rows[0]["TransactionSum"].ToString();
            return Res;
        }

        public string GetTransactionCount(string PaymentCode)
        {
            string Res = "";
            System.Data.DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Name,TransactionCount,TransactionSum * 10 TransactionSum,Date from [AutCityBankSettlementFile] where Code = " + PaymentCode);
            Res = Dt.Rows[0]["TransactionCount"].ToString();
            return Res;
        }

        public string GetName(string PaymentCode)
        {
            string Res = "";
            System.Data.DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Name,TransactionCount,TransactionSum * 10 TransactionSum,Date from [AutCityBankSettlementFile] where Code = " + PaymentCode);
            Res = Dt.Rows[0]["Name"].ToString();
            return Res;
        }

    }
}