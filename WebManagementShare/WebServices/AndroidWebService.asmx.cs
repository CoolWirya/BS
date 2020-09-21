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
using ArchivedDocuments;
using System.Globalization;

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
        string ConstClassName = "AndroidElahiye";
        int ConstObjectCode = 123456;

        #region Person

        [WebMethod(EnableSession = true)]
        public string ChangePass(string username, string oldPassword, string newPassword)//, string mobile)
        {
            Globals.JUser user = new Globals.JUser();
            try
            {
                if (!WebClassLibrary.Authentication.Authentication.Authenticate(username, oldPassword))
                    return "Error Authenticate";
                if (WebClassLibrary.Authentication.Authentication.VerifyUser(username, oldPassword))
                    if (WebClassLibrary.Authentication.Authentication.ChangeUserPassword(newPassword))
                        return WebClassLibrary.SessionManager.Current.MainFrame.GuidCode.ToString();
                return "0";
            }
            catch (Exception e)
            {
                return "0";
            }
            finally
            {
                WebClassLibrary.SessionManager.Current.Dispose();
                user.Dispose();
            }
        }

        /// <summary>
        /// ورود به سیستم
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string Login(string UserName, string Password)//, string mobile)
        {
            Globals.JUser user = new Globals.JUser();
            try
            {
                WebClassLibrary.Authentication.Authentication.Authenticate(UserName, Password);
                //PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;
                if (WebClassLibrary.SessionManager.Current.MainFrame.GuidCode == Guid.Empty)
                    return "Failed";
                user = new Globals.JUser(user.findPerson(WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode));
                user.LoginedFromAndroid = true;
                user.Update();
                return WebClassLibrary.SessionManager.Current.MainFrame.GuidCode.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                WebClassLibrary.SessionManager.Current.Dispose();
                user.Dispose();
            }
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
                if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                    return "Error Authenticate";
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
                        Result += ManagementShares.ShareCompany.JSharepCode.GetData(1, person.Code) + splitter;
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
                    JCitiy city = new JCitiy();
                    city.GetData(address.City);
                    //Result += city.Name + splitter;
                    if (address != null)
                    {
                        Result += address.PostalCode + splitter;//کد پستی
                        Result += address.Email + splitter;
                        Result += address.Tel + splitter;
                        Result += workAddress.Tel + splitter;
                        Result += address.Mobile + splitter;
                        Result += address.City + splitter;
                        Result += address.Address + splitter;
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
                    {
                        city.GetData(workAddress.City);
                        Result += workAddress.Address + splitter;
                    }
                    else
                        Result += " " + splitter;
                    int shareCount = JShareSheets.GetSumPersonSheet(PersonCode);
                    Result += shareCount + splitter;
                }
                catch (Exception ex)
                {
                    return ex.Message + ' ' + pGuid;
                }
                finally
                {
                    // foreach (Exception E in JException.Exceptions)
                    //{
                    //if (E != null)
                    //    Result += E.Message+E.Source;
                    //}
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
            if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                return null;
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
            try
            {
                if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                    return null;
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
            catch(Exception ex)
            {
                return ex.Message+ex.Source+ex.StackTrace;
            }
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
                if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                    return -1;

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
                    workAddress.City = Convert.ToInt32(City);

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

        #region Gallery

        [WebMethod(EnableSession = true)]
        public bool UploadImageToGallery(string pGuid, string strImage)
        {
            if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                return false;
            try
            {
                byte[] bytes = Convert.FromBase64String(strImage);
                JFile imageFile = new JFile(JFileTypes.Image);
                imageFile.Extension = ".jpg";
                imageFile.FileSource = JFile.JFileSource.FromMemory;
                imageFile.Content = bytes;
                ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), JConstantArchivePalces.GeneralArchive.GetHashCode());
                int ArchiveCode = 0;
                if (bytes != null && bytes.GetUpperBound(0) > 0)
                    ArchiveCode = archive.ArchiveDocument(imageFile, ConstClassName, ConstObjectCode, JLanguages._Text("GalleryPicture"), true);
                return ArchiveCode > 0;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod(EnableSession = true)]
        public string DownloadGalleryImage(string pGuid, int imageId)
        {
            if (pGuid != "0000-0000-0000-0000")
            {
                if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                    return "Error Authenticate";
            }
            try
            {
                byte[] file = new JArchiveDocument().RetiriveByteContents(imageId);
                return Convert.ToBase64String(file);
            }
            catch
            {
                return "Error Downloading Images";
            }
        }

        [WebMethod(EnableSession = true)]
        public string GetGalleryImagesId(string pGuid)
        {
            if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                return "Error Authenticate";
            try
            {
                string res = "";
                List<int> files = new JArchiveDocument().GetArchivesCodes(ConstClassName, ConstObjectCode);
                for (int i = 0; i < files.Count; i++)
                    res += files[i] + splitter;
                return res != "" ? res : "No Data";
            }
            catch
            {
                return "Error Downloading Images";
            }
        }

        [WebMethod(EnableSession = true)]
        public string GetPictureGalleryLvl1(string pGuid)
        {
            string result = "";
            if (pGuid != "0000-0000-0000-0000")
            {
                if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                    return "Error Authenticate";
            }
            ClassLibrary.JDataBase Db = new JDataBase();
            try
            {
                Db.setQuery(@"SELECT [dbo].[EntPicGalleryLvl1].[Code] TCode
                          ,[Name]
                          ,isnull(ERP_Elahye_Archive.dbo.ArchiveInterface.ArchiveCode,0)ArchiveCode
                          ,[InsertDate]
                      FROM [dbo].[EntPicGalleryLvl1]
                      left join ERP_Elahye_Archive.dbo.ArchiveInterface on 
                      [EntPicGalleryLvl1].ArchiveCode = ERP_Elahye_Archive.dbo.ArchiveInterface.Code
                      order by [dbo].[EntPicGalleryLvl1].[Code]");
                DataTable table = Db.Query_DataTable();
                if (table == null || table.Rows.Count == 0)
                {
                    return "Nothing";
                }
                //int rowIndex = 0;
                foreach (DataRow row in table.Rows)
                {
                    result += row["TCode"].ToString() + splitter;
                    result += row["Name"].ToString() + splitter;
                    result += row["ArchiveCode"].ToString() + splitter;
                    result += recordSplitter;
                }
                return result;
            }
            finally
            {
                Db.Dispose();
            }

        }

        [WebMethod(EnableSession = true)]
        public string GetPictureGalleryLvl2(string pGuid)
        {
            string result = "";
            if (pGuid != "0000-0000-0000-0000")
            {
                if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                    return "Error Authenticate";
            }
            ClassLibrary.JDataBase Db = new JDataBase();
            try
            {
                Db.setQuery(@"SELECT  [dbo].[EntPicGalleryLvl2].[Code] TCode
                              ,[Lvl1Code]
                              ,[Name]
                              ,isnull(ERP_Elahye_Archive.dbo.ArchiveInterface.ArchiveCode,0)ArchiveCode
                              ,[InsertDate]
                          FROM [dbo].[EntPicGalleryLvl2]
                          left join ERP_Elahye_Archive.dbo.ArchiveInterface on 
	                        [EntPicGalleryLvl2].ArchiveCode = ERP_Elahye_Archive.dbo.ArchiveInterface.Code
	                        order by [dbo].[EntPicGalleryLvl2].[Code]");
                DataTable table = Db.Query_DataTable();
                if (table == null || table.Rows.Count == 0)
                {
                    return "Nothing";
                }
                //int rowIndex = 0;
                foreach (DataRow row in table.Rows)
                {
                    result += row["TCode"].ToString() + splitter;
                    result += row["Name"].ToString() + splitter;
                    result += row["ArchiveCode"].ToString() + splitter;
                    result += row["Lvl1Code"].ToString() + splitter;
                    result += recordSplitter;
                }
                return result;
            }
            finally
            {
                Db.Dispose();
            }
        }

        #endregion

        #region Agent
        /// <summary>
        /// اطلاعات وکیل
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetLawyers(string pGuid)
        {
            if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                return "Error Authenticate";
            int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;

            //getLawyers: id integer,name text,mobile text
            string result = "";
            DataTable table = JShareAgents.GetPersonAgents(PersonCode);
            ManagementShares.JShareCompany Company = new JShareCompany(1);
            JAllPerson Pers = new JAllPerson(Company.PCode);

            result += Company.PCode.ToString() + splitter + Pers.Name + splitter + "0" + splitter + "1" + splitter;
            if (table == null || table.Rows.Count == 0)
                return result;
            int rowIndex = 0;
            result += recordSplitter;
            foreach (DataRow row in table.Rows)
            {
                result += row["Code"].ToString() + splitter;
                result += row["AgentName"].ToString() + splitter;
                result += (row["Mobile"] != null && row["Mobile"].ToString() != "" ? row["Mobile"].ToString() : "0") + splitter + "0" + splitter;
                rowIndex++;
                if (table.Rows.Count > rowIndex)
                    result += recordSplitter;
            }
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
            if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                return "Error Authenticate";

            string result = "";
            JDataBase db = new JDataBase();
            try
            {
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
            finally
            {
                db.Dispose();
            }

        }

        /// <summary>
        /// تعداد سهام سهامدار
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetShareCount(string pGuid)
        {
            if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                return "Error Authenticate";

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
            if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                return "Error Authenticate";

            JConnection jc = new JConnection();
            JDataBase db = new JDataBase(jc.GetSQlServerConnection(ConstClassName, ConstObjectCode));
            try
            {
                JAllPerson person = new JAllPerson(WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode);
                string CurentYear = ClassLibrary.JDateTime.FarsiDate(DateTime.Now);
                db.setQuery("declare @PP numeric ( 15)  set @PP =0  exec  EL1_ATTOT" + CurentYear.Substring(2, 2) + "..usp_Mandeh  " + ManagementShares.ShareCompany.JSharepCode.GetData(1, person.Code) + ", @PP output select @PP");
                string res = db.Query_DataTable().Rows[0][0].ToString();
                if (string.IsNullOrEmpty(res))
                    return "No Price";
                if (res.Substring(0, 1) == "-")
                    res = "بدهکار" + splitter + res;
                else
                    res = "بستانکار" + splitter + res;
                return res;
                //for (int i = 0; i < DT.Rows.Count; i++)
                //{
                //	res += i == 0 ? "" : recordSplitter;
                //	for (int j = 0; j < DT.Rows[i].ItemArray.Length; j++)
                //		res += (j == 0 ? "" : splitter) + DT.Rows[i].ItemArray[j];
                //}

                //int Counter = 1;
                //int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;
                //DataTable DT = ShareProfit.JReport.FinancialAdvice(PersonCode, 1);

                //if (DT != null && DT.Rows.Count > 0)
                //{
                //	List<string> L = new List<string>();
                //	foreach (DataRow DR in DT.Rows)
                //	{
                //		L.Add(
                //			Counter.ToString() + splitter +
                //			DR["PayDate"].ToString() + splitter +
                //			DR["Title"].ToString() + splitter +
                //			DR["Bed"].ToString() + splitter +
                //			DR["Bes"].ToString() + splitter +
                //			DR["man"].ToString() + splitter);
                //		Counter++;
                //	}
                //	return string.Join(recordSplitter, L);
                //}
                //else
                //{
                //	return "No Price";
                //}
            }
            finally
            {
                db.Dispose();
            }

        }

        [WebMethod(EnableSession = true)]
        public string GetShareSheet(string pGuid)
        {
            if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                return "Error Authenticate";

            int Counter = 1;

            int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;

            DataTable DT = ManagementShares.JShareSheets.GetSimpleSheet(PersonCode, 1);

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
        /// Return buy and sell request text
        /// </summary>
        /// <param name="pGuid"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetShareText(string pGuid)
        {
            if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                return "Error Authentication";
            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable("SELECT Type,Text FROM entSharePriceText WHERE ClassName='" + ConstClassName + "'");
            if (dt == null || dt.Rows.Count < 1)
                return "Nothing";
            string result = "";
            for (int i = 0; i < dt.Rows.Count; i++)
                result += dt.Rows[i]["Type"] + splitter + dt.Rows[i]["Text"] + recordSplitter;
            return result;
        }
        /// <summary>
        /// درج درخواست فروش
        /// </summary>
        /// <param name="PersonCode"></param>
        /// <param name="ShareCount"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public int SellRequest(string pGuid, int ShareCount)
        {
            if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
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
            if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                return -1;
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
            if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
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
            if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                return false;

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
            if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                return "Error Authenticate";
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
            if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                return "Error Authenticate";
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
            if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                return "Error Authenticate";
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
            string result = "";
            if (pGuid != "0000-0000-0000-0000")
            {
                if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                    return "Error Authenticate";
            }

            //getNews: id integer,title text,description text,sDate text

            DataTable table = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT [EntNews].[Code],[Title], [Body], isnull(ERP_Elahye_Archive.dbo.ArchiveInterface.ArchiveCode,0)ArchiveCode
                      ,(Select Fa_Date FROM StaticDates WHERE En_Date = Convert(date, [Date])) 'Date'
                       FROM [EntNews] 
                       left join ERP_Elahye_Archive.dbo.ArchiveInterface on [EntNews].ArchiveCode = ERP_Elahye_Archive.dbo.ArchiveInterface.Code
                       Order By Date Desc");//JNewss.GetData(10);
            if (table == null || table.Rows.Count == 0)
            {
                return "Nothing";
            }
            //int rowIndex = 0;
            foreach (DataRow row in table.Rows)
            {
                result += row["Code"].ToString() + splitter;
                result += row["Title"].ToString() + splitter;
                result += row["Body"].ToString() + splitter;
                result += row["Date"].ToString() + splitter;
                if (row["ArchiveCode"] != null && row["ArchiveCode"].ToString() != "")
                    result += row["ArchiveCode"] + splitter; //Convert.ToBase64String(new JArchiveDocument().RetiriveByteContents((int)row["ArchiveCode"])) + "#fieldsplitter#";
                else
                    result += "-1" + splitter;
                //rowIndex++;
                //if (table.Rows.Count > rowIndex)
                result += recordSplitter;
            }

            return result;

        }


        [WebMethod(EnableSession = true)]
        public string GetCountNewsUnread(string LastNewsId)
        {
            string Result = "";
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(@"select ISNULL(count(*),0)C,(select COUNT(*) from EntNews)Koll,Max(Code)MCODE from EntNews Where Code > " + LastNewsId);
                if (Convert.ToInt32(db.Query_DataTable().Rows[0]["C"].ToString()) == Convert.ToInt32(db.Query_DataTable().Rows[0]["Koll"].ToString()))
                    Result = "0";
                else
                    Result = db.Query_DataTable().Rows[0]["C"].ToString() + splitter + db.Query_DataTable().Rows[0]["MCODE"].ToString();
                return Result;
            }
            finally
            {
                db.Dispose();
            }
        }

        #endregion News

        #region About Us

        /// <summary>
        /// اطلاعات درباره ما
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="NewsId"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetInformation(string pGuid)
        {
            if (pGuid != "0000-0000-0000-0000")
            {
                if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                    return "Error Authenticate";
            }
            //getNews: id integer,title text,description text,sDate text
            string result = "";
            DataTable table = WebClassLibrary.JWebDataBase.GetDataTable(@"select entAboutUs.Code,entAboutUs.Text,
																			ERP_Elahye_Archive.dbo.ArchiveInterface.ArchiveCode,entAboutUs.ClassName from entAboutUs 
																			left join ERP_Elahye_Archive.dbo.ArchiveInterface on entAboutUs.ArchiveCode = ERP_Elahye_Archive.dbo.ArchiveInterface.Code 
																			where entAboutUs.classname='" + ConstClassName + "'");
            if (table == null || table.Rows.Count == 0)
            {
                return "Nothing";
            }
            //int rowIndex = 0;
            foreach (DataRow row in table.Rows)
            {
                result += row["Code"].ToString() + "#fieldsplitter#";
                result += row["Text"].ToString() + "#fieldsplitter#";
                if (row["ArchiveCode"] != null && row["ArchiveCode"].ToString() != "")
                {
                    //JArchiveDocument ad = new JArchiveDocument();
                    //JFile file = ad.RetrieveContent((int)row["ArchiveCode"]);
                    //if (file != null && file.Content != null && file.Content.Length >= 0)
                    //	result += Convert.ToBase64String(file.Content) + "#fieldsplitter#";
                    //else
                    //	result += "No Pic" + "#fieldsplitter#";
                    result += row["ArchiveCode"].ToString() + "#fieldsplitter#";
                }
                else
                    result += "NoPic" + "#fieldsplitter#";
                //rowIndex++;
                //if (table.Rows.Count > rowIndex)
                result += "#recordsplitter#";
            }
            return result;

        }
        #endregion

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
            if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                return "Error Authenticate";
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
            if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                return "Error Authenticate";
            int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;

            //id integer,senderId integer,receiverId integer,type text,sDate text,title text, body text,openned text
            string Result = "";
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(" Select  ShareMessage.Code, SenderCode, ReceiverCode, Type , clsAllPerson .Name SenderName , sDate,Title, Body,IsRead from ShareMessage INNER JOIN clsAllPerson ON ShareMessage .SenderCode = clsAllPerson .Code  Where ReceiverCode = " + PersonCode);
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
                    Result += row["IsRead"].ToString() + splitter;
                    rowIndex++;
                    if (table.Rows.Count > rowIndex)
                        Result += recordSplitter;
                }
                return Result;
            }
            finally
            {
                db.Dispose();
            }
        }


        /// <summary>
        /// پیام های ورودی
        /// </summary>
        /// <param name="PersonCode"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetMessagesInboxWithUserName(string UserName)
        {
            string Result = "";
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(" Select  ShareMessage.Code, SenderCode, ReceiverCode, Type , clsAllPerson .Name SenderName , sDate,Title, Body,IsRead from ShareMessage INNER JOIN clsAllPerson ON ShareMessage .SenderCode = clsAllPerson .Code  Where ReceiverCode = (select pcode from users where username = '" + UserName + @"')");
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
                    Result += row["IsRead"].ToString() + splitter;
                    rowIndex++;
                    if (table.Rows.Count > rowIndex)
                        Result += recordSplitter;
                }
                return Result;
            }
            finally
            {
                db.Dispose();
            }
        }


        /// <summary>
        /// انتخاب یک پیام با کد
        /// </summary>
        /// <param name="NewsCode"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetMessageByCode(string pGuid, int MessageCode)
        {
            if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                return "Error Authenticate";

            string Result = "";
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(@" 
	                Select  ShareMessage.Code , SenderPerson .Name SenderName , ReceiverPerson .Name ReceiverName , sDate,ShareMessage.Title, ShareMessage.Body,ShareMessage.IsRead  from ShareMessage 
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
                    Result += row["IsRead"].ToString() + splitter;
                }
                return Result;
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// پیام های خروجی
        /// </summary>
        /// <param name="PersonCode"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetMessagesOutbox(string pGuid)
        {
            if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                return "Error Authenticate";
            int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;

            string Result = "";
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(" Select  ShareMessage.Code, SenderCode, ReceiverCode, Type , clsAllPerson .Name SenderName , sDate,Title, Body,IsRead from ShareMessage INNER JOIN clsAllPerson ON ShareMessage .ReceiverCode = clsAllPerson .Code  Where SenderCode = " + PersonCode);
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
                    Result += row["IsRead"].ToString() + splitter;
                    rowIndex++;
                    if (table.Rows.Count > rowIndex)
                        Result += recordSplitter;
                }
                return Result;
            }
            finally
            {
                db.Dispose();
            }
        }


        [WebMethod(EnableSession = true)]
        public string UpdateMessageIsRead(string pGuid, string MessageId)
        {
            // حذف پیام دریافتی
            if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                return "Error Authenticate";
            int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;

            string Result = "";

            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("update [ShareMessage] set [IsRead] = 1 Where code = " + MessageId + " and ReceiverCode = " + PersonCode);
                if (db.Query_Execute() >= 0)
                    //If Update Ok Result=1
                    Result = "1";
                else
                    Result = "0";
                return Result;
            }
            finally
            {
                db.Dispose();
            }
        }

        [WebMethod(EnableSession = true)]
        public string DeleteMessageInbox(string pGuid, string MessageId)
        {
            // حذف پیام دریافتی
            if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                return "Error Authenticate";
            int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;

            string Result = "";

            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("delete from ShareMessage Where code = " + MessageId + " and ReceiverCode = " + PersonCode);
                if (db.Query_Execute() >= 0)
                    //If Delete Ok Result=1
                    Result = "1";
                else
                    Result = "0";
                return Result;
            }
            finally
            {
                db.Dispose();
            }
        }

        [WebMethod(EnableSession = true)]
        public string GetCountMessageUnread(string UserName)
        {
            string Result = "";
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(@"select ISNULL(count(*),0)C from ShareMessage Where ReceiverCode = (select pcode from users where username = '" + UserName + @"') 
                          and [IsRead] = 0 and InsertDate > DATEADD(MINUTE,-1,GETDATE())");
                Result = db.Query_DataTable().Rows[0][0].ToString();
                return Result;
            }
            finally
            {
                db.Dispose();
            }

        }

        [WebMethod(EnableSession = true)]
        public string DeleteMessageOutbox(string pGuid, string MessageId)
        {
            // حذف پیام ارسالی
            if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                return "Error Authenticate";
            int PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;

            string Result = "";

            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("delete from ShareMessage Where code = " + MessageId + " and SenderCode = " + PersonCode);
                if (db.Query_Execute() >= 0)
                    //If Delete Ok Result=1
                    Result = "1";
                else
                    Result = "0";
                return Result;
            }
            finally
            {
                db.Dispose();
            }
        }

        #endregion Messages

        #region Defines
        [WebMethod(EnableSession = true)]
        public string GetCity(string pGuid, string Code)
        {
            if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                return "Error Authenticate";
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
            if (pGuid != "0000-0000-0000-0000")
            {
                if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                    return "Error Authenticate";
            }
            DataTable DT = ManagementShares.JSharePrices.LastSharePrice(100000);
            if (DT != null && DT.Rows.Count > 0)
            {
                List<string> L = new List<string>();
                CultureInfo c = CultureInfo.GetCultureInfo("fa-Ir");
                foreach (DataRow DR in DT.Rows)
                {
                    L.Add(DR["Price"].ToString().Replace(".0000", "") + splitter + ClassLibrary.JDateTime.FarsiDate((DateTime)DR["ChangeDate"]));
                }
                return string.Join(recordSplitter, L);
            }
            else
            {
                return "No Price";
            }
        }

        [WebMethod(EnableSession = true)]
        public string GetCountSharePriceUnread(string CountSharePriceId)
        {
            string Result = "";
            if (CountSharePriceId == "0")
                return "0";
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(@"select COUNT(*)PCount from SharePrice where CompanyCode = 0");
                Result = db.Query_DataTable().Rows[0][0].ToString();
                int NewRecord = Convert.ToInt32(Result) - Convert.ToInt32(CountSharePriceId);
                if (NewRecord > 0)
                    Result = NewRecord.ToString();
                else
                    Result = "0";
                return Result;
            }
            finally
            {
                db.Dispose();
            }
        }

        [WebMethod(EnableSession = true)]
        public string GetBenefits(string pGuid)
        {
            if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                return "Error Authenticate";
            DataTable DT = WebClassLibrary.JWebDataBase.GetDataTable("SELECT Code,Title,Cost FROM SahamCourse ORDER BY Code Desc");
            if (DT != null && DT.Rows.Count > 0)
            {
                List<string> L = new List<string>();
                foreach (DataRow DR in DT.Rows)
                    L.Add(DR["Code"] + splitter + DR["Title"] + splitter + DR["Cost"]);
                return string.Join(recordSplitter, L);
            }
            else
                return "No Benefits";
        }


        [WebMethod(EnableSession = true)]
        public string GetAndroidVesion(string pGuid, int pCount)
        {
            return "1.0.0.0";
        }
        #endregion


        #region Projects
        /// <summary>
        /// پروژه ها
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="NewsId"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetProjects(string pGuid)
        {
            string result = "";
            if (pGuid != "0000-0000-0000-0000")
            {
                if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                    return "Error Authenticate";
            }

            //getNews: id integer,title text,description text,sDate text

            ClassLibrary.JDataBase Db = new JDataBase();
            try
            {
                Db.setQuery(@"select EntProjects.Code,ProjectName,Decription,dbo.dateentofa(insertDate)insertDate, isnull(ERP_Elahye_Archive.dbo.ArchiveInterface.ArchiveCode,0)ArchiveCode from EntProjects
                          left join ERP_Elahye_Archive.dbo.ArchiveInterface on [EntProjects].ArchiveCode = ERP_Elahye_Archive.dbo.ArchiveInterface.Code
                          order by EntProjects.Code desc");

                DataTable table = Db.Query_DataTable();
                if (table == null || table.Rows.Count == 0)
                {
                    return "Nothing";
                }
                //int rowIndex = 0;
                foreach (DataRow row in table.Rows)
                {
                    result += row["Code"].ToString() + splitter;
                    result += row["ProjectName"].ToString() + splitter;
                    result += row["Decription"].ToString() + splitter;
                    result += row["insertDate"].ToString() + splitter;
                    result += row["ArchiveCode"].ToString() + splitter;
                    result += "-1" + splitter;
                    //rowIndex++;
                    //if (table.Rows.Count > rowIndex)
                    result += recordSplitter;
                }

                return result;
            }
            finally
            {
                Db.Dispose();
            }

        }
        #endregion Projects



        #region Aparteman
        /// <summary>
        /// آپارتمان
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="NewsId"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetAparteman(string pGuid)
        {
            string result = "";
            if (pGuid != "0000-0000-0000-0000")
            {
                if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                    return "Error Authenticate";
            }

            //getNews: id integer,title text,description text,sDate text

            ClassLibrary.JDataBase Db = new JDataBase();
            try
            {
                Db.setQuery(@"SELECT [Android_Apartments].[Code]
                                ,[ProjectName]
                                ,[Metraj]
                                ,[TedadeVahed]
                                ,[TedadKhab]
                                ,[ShomareVahed]
                                ,[Tabaghe]
                                ,[Emkanat]
                                ,[Gheymat],isnull(ERP_Elahye_Archive.dbo.ArchiveInterface.ArchiveCode,0)ArchiveCode
                            FROM [dbo].[Android_Apartments]
                                left join ERP_Elahye_Archive.dbo.ArchiveInterface on [Android_Apartments].ArchiveCode = ERP_Elahye_Archive.dbo.ArchiveInterface.Code
                            order by [Android_Apartments].Code desc");




                DataTable table = Db.Query_DataTable();
                if (table == null || table.Rows.Count == 0)
                {
                    return "Nothing";
                }
                //int rowIndex = 0;
                foreach (DataRow row in table.Rows)
                {
                    result += row["Code"].ToString() + splitter;
                    result += row["ProjectName"].ToString() + splitter;
                    result += row["Metraj"].ToString() + splitter;
                    result += row["TedadeVahed"].ToString() + splitter;
                    result += row["ShomareVahed"].ToString() + splitter;
                    result += row["Tabaghe"].ToString() + splitter;
                    result += row["Emkanat"].ToString() + splitter;
                    result += row["Gheymat"].ToString() + splitter;
                    result += row["ArchiveCode"].ToString() + splitter;
                    result += recordSplitter;
                }

                return result;
            }
            finally
            {
                Db.Dispose();
            }

        }


        [WebMethod(EnableSession = true)]
        public string GetApartemanRequest(string pGuid)
        {
            string result = "";
            int PersonCode = 0;
            if (pGuid != "0000-0000-0000-0000")
            {
                if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                    return "Error Authenticate";
                PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;
            }

            //getNews: id integer,title text,description text,sDate text

            ClassLibrary.JDataBase Db = new JDataBase();
            try
            {
                Db.setQuery(@"SELECT AR.[Code] Code
                                  ,AR.[UserCode]
	                              ,cap.Name UserName
                                  ,AR.[ObjectCode]
	                              ,N' پروژه ' + AP.ProjectName + N' طبقه ' + AP.Tabaghe + N' واحد ' + AP.ShomareVahed Apartments
                                  ,case AR.[Status] when 0 then N'در انتظار پاسخ' when 1 then N'پذیرفته شده' else N'رد شده' end as Status
                                  ,dbo.dateEnToFa(AR.[InsertDate])InsertDate
                              FROM [dbo].[Andorid_Request] AR
                              left join clsAllPerson cap on cap.Code = AR.[UserCode]
                              left join Android_Apartments ap on ap.Code = AR.[ObjectCode]
                              where [RequestType] = 1 and UserCode = " + PersonCode.ToString() + @" order by Code desc");

                DataTable table = Db.Query_DataTable();
                if (table == null || table.Rows.Count == 0)
                {
                    return "Nothing";
                }
                //int rowIndex = 0;
                foreach (DataRow row in table.Rows)
                {
                    result += row["Code"].ToString() + splitter;
                    result += row["ObjectCode"].ToString() + splitter;
                    result += row["Apartments"].ToString() + splitter;
                    result += row["Status"].ToString() + splitter;
                    result += row["InsertDate"].ToString() + splitter;
                    result += recordSplitter;
                }

                return result;
            }
            finally
            {
                Db.Dispose();
            }

        }


        [WebMethod(EnableSession = true)]
        public string InsertApartemanAndGroundRequest(string pGuid, string RequestType, string ObjectCode)
        {
            string result = "";
            int PersonCode = 0;
            if (pGuid != "0000-0000-0000-0000")
            {
                if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                    return "Error Authenticate";
                PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;
            }

            //getNews: id integer,title text,description text,sDate text

            ClassLibrary.JDataBase Db = new JDataBase();
            try
            {
                Db.setQuery(@"select ISNULL(count(*),0)C from [dbo].[Andorid_Request] where RequestType = " + RequestType + " and UserCode = " + PersonCode + " and ObjectCode = " + ObjectCode);
                if (Convert.ToInt32(Db.Query_DataTable().Rows[0]["C"].ToString()) == 0)
                {
                    Db.setQuery(@"INSERT INTO [dbo].[Andorid_Request]
                                   ([RequestType]
                                   ,[UserCode]
                                   ,[ObjectCode]
                                   ,[Status]
                                   ,[InsertDate])
                             VALUES
                                   (" + RequestType + @"
                                   ," + PersonCode + @"
                                   ," + ObjectCode + @"
                                   ,0
                                   ,getdate())");

                    if (Db.Query_Execute() >= 0)
                    {
                        result = "1";
                    }
                    else
                    {
                        result = "0";
                    }
                }
                else
                {
                    result = "2";
                }


                return result;
            }
            finally
            {
                Db.Dispose();
            }

        }


        [WebMethod(EnableSession = true)]
        public string DeleteApartemanAndGroundRequest(string pGuid, string ObjectCode)
        {
            string result = "";
            int PersonCode = 0;
            if (pGuid != "0000-0000-0000-0000")
            {
                if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                    return "Error Authenticate";
                PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;
            }

            //getNews: id integer,title text,description text,sDate text

            ClassLibrary.JDataBase Db = new JDataBase();
            try
            {
                Db.setQuery(@"Delete from [dbo].[Andorid_Request]
                          where Code = " + ObjectCode);

                if (Db.Query_Execute() >= 0)
                {
                    result = "1";
                }
                else
                {
                    result = "0";
                }


                return result;
            }
            finally
            {
                Db.Dispose();
            }

        }


        #endregion Aparteman


        #region Ground
        /// <summary>
        /// زمین
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="NewsId"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetGround(string pGuid)
        {
            string result = "";
            if (pGuid != "0000-0000-0000-0000")
            {
                if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                    return "Error Authenticate";
            }

            //getNews: id integer,title text,description text,sDate text

            ClassLibrary.JDataBase Db = new JDataBase();

            try
            {
                Db.setQuery(@"SELECT [Code]
                                ,[Metraj]
                                ,[Abad]
                                ,[MogheeyatJoghrafi]
                                ,[MogheeyatMakani]
                                ,[Address]
                                ,[Sanad]
                                ,[TedadShoraka]
                                ,[Tozihat]
                                ,[Gheymat]
                            FROM [dbo].[Android_Ground] order by Code desc");

                DataTable table = Db.Query_DataTable();
                if (table == null || table.Rows.Count == 0)
                {
                    return "Nothing";
                }
                //int rowIndex = 0;
                foreach (DataRow row in table.Rows)
                {
                    result += row["Code"].ToString() + splitter;
                    result += row["Metraj"].ToString() + splitter;
                    result += row["Abad"].ToString() + splitter;
                    result += row["MogheeyatJoghrafi"].ToString() + splitter;
                    result += row["MogheeyatMakani"].ToString() + splitter;
                    result += row["Address"].ToString() + splitter;
                    result += row["Sanad"].ToString() + splitter;
                    result += row["TedadShoraka"].ToString() + splitter;
                    result += row["Tozihat"].ToString() + splitter;
                    result += row["Gheymat"].ToString() + splitter;
                    result += recordSplitter;
                }

                return result;

            }
            finally
            {
                Db.Dispose();
            }
        }


        [WebMethod(EnableSession = true)]
        public string GetGroundRequest(string pGuid)
        {
            string result = "";
            int PersonCode = 0;
            if (pGuid != "0000-0000-0000-0000")
            {
                if (!WebClassLibrary.Authentication.Authentication.Authenticate(Guid.Parse(pGuid)))
                    return "Error Authenticate";
                PersonCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;
            }

            //getNews: id integer,title text,description text,sDate text

            ClassLibrary.JDataBase Db = new JDataBase();
            try
            {
                Db.setQuery(@"SELECT AR.[Code]
                                  ,AR.[UserCode]
	                              ,cap.Name UserName
                                  ,AR.[ObjectCode]
	                              ,N' متراژ ' + AP.Metraj + N' موقعیت مکانی ' +AP.MogheeyatMakani+N' آدرس '+AP.Address Ground
                                  ,case AR.[Status] when 0 then N'در انتظار پاسخ' when 1 then N'پذیرفته شده' else N'رد شده' end as Status
                                  ,dbo.dateEnToFa(AR.[InsertDate])InsertDate
                              FROM [dbo].[Andorid_Request] AR
                              left join clsAllPerson cap on cap.Code = AR.[UserCode]
                              left join Android_Ground ap on ap.Code = AR.[ObjectCode]
                              where [RequestType] = 2 and UserCode = " + PersonCode.ToString() + @" order by AR.Code desc");

                DataTable table = Db.Query_DataTable();
                if (table == null || table.Rows.Count == 0)
                {
                    return "Nothing";
                }
                //int rowIndex = 0;
                foreach (DataRow row in table.Rows)
                {
                    result += row["Code"].ToString() + splitter;
                    result += row["ObjectCode"].ToString() + splitter;
                    result += row["Ground"].ToString() + splitter;
                    result += row["Status"].ToString() + splitter;
                    result += row["InsertDate"].ToString() + splitter;
                    result += recordSplitter;
                }

                return result;
            }
            finally
            {
                Db.Dispose();
            }

        }

        #endregion Ground


    }
}
