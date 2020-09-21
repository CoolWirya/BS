using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebERP
{
    public partial class send : System.Web.UI.Page
    {

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("OK");
            try
            {
                string req = Request.QueryString["Dat"].ToString();
                byte[] TempCard = StringToByteArray(req.Substring(0, 8));
                Int32 CardRFID = BitConverter.ToInt32(TempCard, 0);
                string time = req.Substring(8, 6);
                string date = req.Substring(14, 6);
                DateTime CardTime = ClassLibrary.JDateTime.GregorianDate("13"+date.Substring(0, 2) + "/" + date.Substring(2, 2) + "/" + date.Substring(4, 2) ,
                   time.Substring(0, 2) + ":" + time.Substring(2, 2) + ":" + time.Substring(4, 2));
                SmartCard.JCards Card = new SmartCard.JCards();
                if(!Card.Find((Int64)CardRFID))
                {
                    Card.RfidNumber = (Int64)CardRFID;
                    Card.Status = true;
                    Card.pCode = 0;
                    Card.Description = "ثبت شده بصورت اتومات ارسالی از کارت خوان";
                    Card.CardType = SmartCard.JCardTypeEnum.UdDefine.GetHashCode();
                    Card.Insert(true,true);
                }
            }catch(Exception ex)
            {
                System.IO.File.AppendAllText("C:\\123\\khanelog.txt", ex.Message.ToString() + Environment.NewLine);
            }
        }
    }
}