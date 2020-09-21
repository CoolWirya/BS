using ClassLibrary;
using Entertainment;
using ManagementShares.TransferRequest;
using ManagementShares;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Tcontrolco.WebServiceTest
{
    /// <summary>
    /// Summary description for AndroidWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AndroidWebService : System.Web.Services.WebService
    {
        const string splitter = "##";
        const string recordSplitter = "@@";
        const int CompanyCode = 1;
        #region Person
        /// <summary>
        /// ورود به سیستم
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        //public int Login(string UserName, string Password)
        public string Login(string UserName, string Password)
        {
			try
			{
				WebClassLibrary.Authentication.Authentication.Authenticate(UserName, Password);
				//PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;
				if (WebClassLibrary.SessionManager.Current.MainFrame.GuidCode ==
					Guid.Empty)
					return "Failed";
				else
					return WebClassLibrary.SessionManager.Current.MainFrame.GuidCode.ToString();
			}
			catch (Exception e)
			{
				return e.Message;
			}
			finally
			{
				WebClassLibrary.SessionManager.Current.Dispose();
			}
            //return "";
        }
        /// <summary>
        /// اطلاعات شخص
        /// </summary>
        /// <param name="PeronCode"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetPersonInfo(string pGuid)
        {
            try
            {
                //if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                //    return "Error Authenticate";
                //int PersonCode = 1;
                int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;
                string Result = "";
                try
                {
                    JAllPerson person = new JAllPerson(PersonCode);
                    /// شخص حقیقی
                    if (person.PersonType == JPersonTypes.RealPerson)
                    {
                        JPerson realPerson = new JPerson(person.Code);
                        Result += person.Code + splitter;
                        Result += person.SharePCode + splitter;
                        Result += realPerson.Name + " " + realPerson.Fam + splitter;
                        Result += realPerson.FatherName + splitter;
                        Result += JDateTime.FarsiDate(realPerson.BthDate) + splitter;
                        Result += realPerson.ShSh + splitter;// شماره شناسنامه
                        Result += realPerson.ShMeli + splitter;
                        Result += realPerson.BirthplaceCode.ToString() + splitter; // شهر
                    }
                    ///////////////////////////////////
                    ///شخص حقوقی
                    else if (person.PersonType == JPersonTypes.LegalPerson)
                    {

                    }
                    /// آدرس
                    JPersonAddress address = new JPersonAddress(PersonCode, JAddressTypes.Home);
                    JPersonAddress workAddress = new JPersonAddress(PersonCode, JAddressTypes.Work);
                    JCitiy city = new JCitiy(); city.GetData(address.City);
                    //Result += city.Name + splitter;
                    if (address != null)
                    {
                        Result += address.PostalCode + splitter;//کد پستی
                        Result += address.Email + splitter;
                        Result += address.Tel + splitter;
                        Result += workAddress.Tel + splitter;
                        Result += address.Mobile + splitter;
                        Result += address.City + " " + address.Address + splitter;
                    }
                    else
                    {
                        Result += ' ' + splitter;//کد پستی
                        Result += ' ' + splitter;
                        Result += ' ' + splitter;
                        Result += ' ' + splitter;
                        Result += ' ' + splitter;
                        Result += ' ' + splitter;
                    }
                    if (workAddress != null)
                        Result += workAddress.City + " " + workAddress.Address;
                    else
                        Result += " " + splitter;
                }
                catch (Exception ex)
                {
                    return ex.Message + ' ' + pGuid;
                }
                finally
                {
                    foreach (Exception E in JException.Exceptions)
                    {
                        //if (E != null)
                        //    Result += E.Message+E.Source;
                    }
                }
                return Result;
            }
            catch (Exception ex)
            {
                return ex.Message + ' ' + pGuid;
            }
            finally
            {
                WebClassLibrary.SessionManager.Current.Dispose();
            }

        }
        /// <summary>
        /// تصویر شخص
        /// </summary>
        /// <param name="pGuid"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetPersonImage(string pGuid)
        {
            //if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
            //    return null;
            int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;
            JPerson person = new JPerson(PersonCode);
            Image personImage = person.PersonImage;
            if (personImage == null)
                return "Nothing";
            using (MemoryStream ms = new MemoryStream())
            {
                personImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return Convert.ToBase64String(ms.ToArray());
            }
        }
        /// <summary>
        /// ست کردن تصویر شخص
        /// </summary>
        /// <param name="pGuid"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string SetPersonImage(string pGuid, string strImage)
        {
            //if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
            //    return null;
            int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;

            byte[] bytes = Convert.FromBase64String(strImage);
            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }
            JPerson person = new JPerson(PersonCode);
            if (person.SetImage(image))
                return "1";
            else
                return "0";
        }
        /// <summary>
        /// بروزرسانی اطلاعات شخص
        /// </summary>
        /// <param name="PersonCode"></param>
        /// <param name="City"></param>
        /// <param name="PostalCode"></param>
        /// <param name="Email"></param>
        /// <param name="HomeTel"></param>
        /// <param name="Mobile"></param>
        /// <param name="Address"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public int UpdatePersonInfo(string pGuid, string City, string PostalCode, string Email, string HomeTel, string WorkTel, string Mobile, string HomeAddress, string WorkAddress)
        {
            try
            {
                //if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                //    return -1;

                int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;

                JAllPerson person = new JAllPerson(PersonCode);
                int Result = 0;
                if (person.PersonType == JPersonTypes.RealPerson)
                {
                    JPersonAddress address = new JPersonAddress(person.Code, JAddressTypes.Home);
                    JPersonAddress workAddress = new JPersonAddress(person.Code, JAddressTypes.Work);
                    address.PCode = person.Code;
                    address.City = Convert.ToInt32(City);
                    address.PostalCode = PostalCode;
                    address.Email = Email;
                    address.Tel = HomeTel;
                    address.Mobile = Mobile;
                    address.Address = HomeAddress;

                    workAddress.PCode = person.Code;
                    workAddress.Address = WorkAddress;
                    workAddress.Tel = WorkTel;

                    if (address.Save() && workAddress.Save())
                        Result = 1;
                }
                return Result;
            }
            catch
            {
                return -1;
            }
        }

        #endregion Person

        #region Agent
        /// <summary>
        /// اطلاعات وکیل
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetLawyers(string pGuid)
        {
         
            int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;

            //getLawyers: id integer,name text,mobile text
            string result = "";
            DataTable table = JShareAgents.GetPersonAgents(PersonCode);
            if (table == null || table.Rows.Count == 0)
            {
                return "Nothing";
            }
            int rowIndex = 0;
            foreach (DataRow row in table.Rows)
            {
                result += row["Code"].ToString() + splitter;
                result += row["AgentName"].ToString() + splitter;
                rowIndex++;
                if (table.Rows.Count > rowIndex)
                    result += recordSplitter;
            }

            ManagementShares.JShareCompany Company = new JShareCompany(1);
            JAllPerson Pers = new JAllPerson(Company.PCode);

            result += recordSplitter + 
                Company.Code.ToString()+splitter+ 
                Pers.Name;

            return result;
        }
        #endregion Agent

        #region Finance
        /// <summary>
        /// قیمت روز سهام
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetSharePrice(string pGuid)
        {
            //if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
            //    return "Error Authenticate";

            string result = "";
            JDataBase db = new JDataBase();
            db.setQuery(string.Format(@"SELECT Top 1
	            (Select Fa_Date FROM StaticDates WHERE En_Date = ChangeDate ) 'ChangeDate'
	            , Price
              FROM [ERP_Sepad].[dbo].[SharePrice] WHERE CompanyCode = {0} Order BY Date Desc ", CompanyCode));
            DataTable table = db.Query_DataTable();
            if (table == null || table.Rows.Count == 0)
            {
                return "Nothing";
            }
            if (table.Rows.Count > 0)
            {
                result += table.Rows[0]["ChangeDate"].ToString() + splitter;
                result += table.Rows[0]["Price"].ToString();
            }
            return result;
        }

        /// <summary>
        /// تعداد سهام سهامدار
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetShareCount(string pGuid)
        {
           

            string Result = "";
            int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;
            int allShareCount = JShareSheets.GetSumPersonSheet(PersonCode);
            Result += allShareCount;
            return Result;
        }
        /// <summary>
        /// اطلاعات مالی
        /// سودهای مصوب و سودهای دریافت شده
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetFinancials(string pGuid)
        {
            //if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
            //    return "Error Authenticate";

            int Counter = 1;

            int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;
            DataTable DT = null;

            if (DT != null && DT.Rows.Count > 0)
            {
                List<string> L = new List<string>();
                foreach (DataRow DR in DT.Rows)
                {
                    L.Add(
                        Counter.ToString() + splitter +
                        DR["PayDate"].ToString() + splitter +
                        DR["Title"].ToString() + splitter +
                        DR["Bed"].ToString() + splitter +
                        DR["Bes"].ToString() + splitter +
                        DR["man"].ToString() + splitter);
                    Counter++;
                }
                return string.Join(recordSplitter, L);
            }
            else
            {
                return "No Price";
            }
        }

        [WebMethod(EnableSession = true)]
        public string GetShareSheet(string pGuid)
        {
            //if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
            //    return "Error Authenticate";

            int Counter = 1;

            int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;

            DataTable DT = null;
                //ManagementShares.JShareSheets.GetSimpleSheet(PersonCode, 1);

            if (DT != null && DT.Rows.Count > 0)
            {
                List<string> L = new List<string>();
                string[] RowString = new string[DT.Columns.Count];
                foreach (DataRow DR in DT.Rows)
                {
                    for (int i = 0; i < DT.Columns.Count; i++)
                    {
                        RowString[i] = DR[i].ToString();
                    }
                    L.Add(string.Join(splitter, RowString));
                    Counter++;
                }
                return string.Join(recordSplitter, L);
            }
            else
            {
                return "No Price";
            }
        }

        #endregion Finance

        #region Sell & Buy Request
        /// <summary>
        /// درج درخواست فروش
        /// </summary>
        /// <param name="PersonCode"></param>
        /// <param name="ShareCount"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public int SellRequest(string pGuid, int ShareCount)
        {
            
                return -1;
            int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;

            //int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;
            ManagementShares.TransferRequest.JRequestSell sell = new JRequestSell();
            sell.PCode = PersonCode;
            sell.RequestDate = DateTime.Now;
            sell.ShareCount = ShareCount;
            return sell.Insert();
        }
        /// <summary>
        /// درج درخواست خرید
        /// </summary>
        /// <param name="PersonCode"></param>
        /// <param name="ShareCount"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public int BuyRequest(string pGuid, int ShareCount)
        {
           
            int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;

            //int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;
            JRequestBuy buy = new JRequestBuy();
            buy.PCode = PersonCode;
            buy.RequestDate = DateTime.Now;
            buy.ShareCount = ShareCount;
            return buy.Insert();
        }

        /// <summary>
        /// لغو درخواست فروش
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="RequestId"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public bool CancelSellRequest(string pGuid, int RequestCode)
        {
            
                return false;

            //int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;
            JRequestSell request = new JRequestSell(RequestCode);
            return request.SetRequestStatus(RequestStatus.Canceled);
        }

        /// <summary>
        /// لغو درخواست خرید
        /// </summary>
        /// <param name="PersonCode"></param>
        /// <param name="RequestCode"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public bool CancelBuyRequest(string pGuid, int RequestCode)
        {

            //int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;
            JRequestBuy request = new JRequestBuy(RequestCode);
            return request.SetRequestStatus(RequestStatus.Canceled);
        }
        /// <summary>
        /// لیست درخواستهای خرید
        /// </summary>
        /// <param name="PersonCode"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetBuyRequests(string pGuid)
        {
           
            int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;

            string result = "";
            DataTable table = JRequestBuys.GetDataTable(PersonCode);
            if (table == null || table.Rows.Count == 0)
            {
                return "Nothing";
            }
            int rowIndex = 0;
            foreach (DataRow row in table.Rows)
            {
                result += row["Code"].ToString() + splitter;
                result += row["RequestDate"].ToString() + splitter;
                result += row["RequestStatus"].ToString() + splitter;
                result += row["ShareCount"].ToString() + splitter;
                rowIndex++;
                if (table.Rows.Count > rowIndex)
                    result += recordSplitter;
            }
            return result;
        }

        /// <summary>
        ///  لیست درخواستهای خرید و فروش
        /// </summary>
        /// <param name="PersonCode"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetAllRequests(string pGuid)
        {
          
            int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;

            string result = "";
            DataTable table = ManagementShares.TransferRequest.JRequests.GetAllRequests(PersonCode);
            if (table == null || table.Rows.Count == 0)
            {
                return "Nothing";
            }
            int rowIndex = 0;
            foreach (DataRow row in table.Rows)
            {
                result += row["Code"].ToString() + splitter;
                result += row["Type"].ToString() + splitter;
                result += row["RequestDate"].ToString() + splitter;
                result += row["RequestStatus"].ToString() + splitter;
                result += row["ShareCount"].ToString() + splitter;
                rowIndex++;
                if (table.Rows.Count > rowIndex)
                    result += recordSplitter;
            }
            return result;
        }
        /// <summary>
        /// لیست درخواستهای فروش
        /// </summary>
        /// <param name="PersonCode"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetSellRequests(string pGuid)
        {
           
            int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;

            string result = "";
            DataTable table = JRequestSells.GetDataTable(PersonCode);
            if (table == null || table.Rows.Count == 0)
            {
                return "Nothing";
            }
            int rowIndex = 0;
            foreach (DataRow row in table.Rows)
            {
                result += row["Code"].ToString() + splitter;
                result += row["RequestDate"].ToString() + splitter;
                result += row["RequestStatus"].ToString() + splitter;
                result += row["ShareCount"].ToString() + splitter;
                rowIndex++;
                if (table.Rows.Count > rowIndex)
                    result += recordSplitter;
            }
            return result;
        }
        #endregion Sell & Buy Request

        #region News
        /// <summary>
        /// اخبار و اطلاعیه ها
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="NewsId"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetNews(string pGuid)
        {
           

            //getNews: id integer,title text,description text,sDate text
            string result = "";
            DataTable table = JNewss.GetData(10);
            if (table == null || table.Rows.Count == 0)
            {
                return "Nothing";
            }
            int rowIndex = 0;
            foreach (DataRow row in table.Rows)
            {
                result += row["Code"].ToString() + splitter;
                result += row["Title"].ToString() + splitter;
                result += row["Body"].ToString() + splitter;
                result += row["Date"].ToString() + splitter;
                rowIndex++;
                if (table.Rows.Count > rowIndex)
                    result += recordSplitter;
            }
            return result;

        }
        #endregion News

        #region Messages
        /// <summary>
        /// ارسال پیام
        /// </summary>
        /// <param name="pGuid"></param>
        /// <param name="receiverCode"></param>
        /// <param name="Title"></param>
        /// <param name="Body"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string SendMessage(string pGuid, int receiverCode, string Title, string Body, int Type)
        {
            //if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
            //    return "Error Authenticate";
            int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;
            ManagementShares.ShareMessage.JShareMessage message = new ManagementShares.ShareMessage.JShareMessage();
            message.Body = Body;
            message.mDate = DateTime.Now;
            message.sDate = ClassLibrary.JDateTime.FarsiDate(DateTime.Now);
            message.SenderCode = PersonCode;
            message.ReceiverCode = receiverCode;
            message.Title = Title;
            message.Type = Type;
            if (message.Insert())
                return "1";
            else
                return "0";
        }
        /// <summary>
        /// پیام های ورودی
        /// </summary>
        /// <param name="PersonCode"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetMessagesInbox(string pGuid)
        {
            //if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
            //    return "Error Authenticate";
            int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;

            //id integer,senderId integer,receiverId integer,type text,sDate text,title text, body text,openned text
            string Result = "";
            JDataBase db = new JDataBase();
            db.setQuery(" Select  ShareMessage.Code, SenderCode, ReceiverCode, Type , clsAllPerson .Name SenderName , sDate,Title, Body from ShareMessage INNER JOIN clsAllPerson ON ShareMessage .SenderCode = clsAllPerson .Code  Where ReceiverCode = " + PersonCode);
            DataTable table = db.Query_DataTable();
            if (table == null || table.Rows.Count == 0)
            {
                return "Nothing";
            }
            int rowIndex = 0;
            foreach (DataRow row in table.Rows)
            {
                Result += row["Code"].ToString() + splitter;
                Result += row["SenderCode"].ToString() + splitter;
                Result += row["ReceiverCode"].ToString() + splitter;
                Result += row["SenderName"].ToString() + splitter;
                Result += row["sDate"].ToString() + splitter;
                Result += row["Type"].ToString() + splitter;
                Result += row["Title"].ToString() + splitter;
                Result += row["Body"].ToString() + splitter;
                rowIndex++;
                if (table.Rows.Count > rowIndex)
                    Result += recordSplitter;
            }
            return Result;
        }
        /// <summary>
        /// انتخاب یک پیام با کد
        /// </summary>
        /// <param name="NewsCode"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetMessageByCode(string pGuid, int MessageCode)
        {
            //if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
            //    return "Error Authenticate";

            string Result = "";
            JDataBase db = new JDataBase();
            db.setQuery(@" 
	                Select  ShareMessage.Code , SenderPerson .Name SenderName , ReceiverPerson .Name ReceiverName , sDate,ShareMessage.Title, ShareMessage.Body  from ShareMessage 
	                INNER JOIN clsAllPerson SenderPerson ON ShareMessage .SenderCode = SenderPerson .Code 
	                INNER JOIN clsAllPerson ReceiverPerson ON ShareMessage .ReceiverCode = ReceiverPerson .Code 
	                 Where ShareMessage.Code  = " + MessageCode);
            DataTable table = db.Query_DataTable();
            if (table == null || table.Rows.Count == 0)
            {
                return "Nothing";
            }
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                Result += row["Code"].ToString() + splitter;
                Result += row["SenderName"].ToString() + splitter;
                Result += row["ReceiverName"].ToString() + splitter;
                Result += row["sDate"].ToString() + splitter;
                Result += row["Title"].ToString() + splitter;
                Result += row["Body"].ToString() + splitter;
            }
            return Result;
        }

        /// <summary>
        /// پیام های خروجی
        /// </summary>
        /// <param name="PersonCode"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetMessagesOutbox(string pGuid)
        {
            //if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
            //    return "Error Authenticate";
            int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;

            string Result = "";
            JDataBase db = new JDataBase();
            db.setQuery(" Select  ShareMessage.Code, SenderCode, ReceiverCode, Type , clsAllPerson .Name SenderName , sDate,Title, Body from ShareMessage INNER JOIN clsAllPerson ON ShareMessage .SenderCode = clsAllPerson .Code  Where SenderCode = " + PersonCode);
            DataTable table = db.Query_DataTable();
            if (table == null || table.Rows.Count == 0)
            {
                return "Nothing";
            }
            int rowIndex = 0;
            foreach (DataRow row in table.Rows)
            {
                Result += row["Code"].ToString() + splitter;
                Result += row["SenderCode"].ToString() + splitter;
                Result += row["ReceiverCode"].ToString() + splitter;
                Result += row["SenderName"].ToString() + splitter;
                Result += row["sDate"].ToString() + splitter;
                Result += row["Type"].ToString() + splitter;
                Result += row["Title"].ToString() + splitter;
                Result += row["Body"].ToString() + splitter;
                rowIndex++;
                if (table.Rows.Count > rowIndex)
                    Result += recordSplitter;
            }
            return Result;
        }

        [WebMethod(EnableSession = true)]
        public string DeleteMessageInbox(string pGuid, string MessageId)
        {
            // حذف پیام دریافتی
            string Result = "";
            //If Delete Ok Result=1
            Result = "1";
            return Result;
        }

        [WebMethod(EnableSession = true)]
        public string DeleteMessageOutbox(string pGuid, string MessageId)
        {
            // حذف پیام ارسالی
            string Result = "";
            //If Delete Ok Result=1
            Result = "1";
            return Result;
        }

        #endregion Messages

        #region Defines
        [WebMethod(EnableSession = true)]
        public string GetCity(string pGuid, string Code)
        {
            
            List<string> L = new List<string>();
            try
            {
                ClassLibrary.JCities Cities = new JCities();
                DataTable DT = Cities.GetNewCity(int.Parse(Code));
                foreach (DataRow DR in DT.Rows)
                {
                    L.Add(DR["Code"].ToString() + splitter + DR["Name"].ToString());
                }
                return string.Join(recordSplitter, L);
            }
            finally
            {
                L.Clear();
            }
        }
        #endregion

        #region Price
        [WebMethod(EnableSession = true)]
        public string GetTodaySharePrice(string pGuid)
        {
            return GetLastSharePrices(pGuid, 1);
        }

        [WebMethod(EnableSession = true)]
        public string GetLastSharePrices(string pGuid, int pCount)
        {

            DataTable DT = null;
            if (DT!=null && DT.Rows.Count > 0)
            {
                List<string> L = new List<string>();
                foreach (DataRow DR in DT.Rows)
                {
                    L.Add(DR["Price"] + splitter + ClassLibrary.JDateTime.FarsiDate((DateTime)DR["ChangeDate"]));
                }
                return string.Join(recordSplitter, L);
            }
            else
            {
                return "No Price";
            }
        }
        #endregion
    }
}
