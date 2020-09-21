using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;

namespace ManagementShares
{
    public class JShareReport
    {
        public static string SQLSheet = string.Format(@"
 Select distinct  S1.Code SCode,S1.Code Code,S1.PCode, S1.ShareCount , S1.Az , S1 .Ela
                    ,Case  S1.NumPrint When null  then N'چاپ نشده' When 0  then N'چاپ نشده' else N'چاپ شده' end PrintStatus 
                    --,Delivery DeliverStatus
                    ,Case S1.[Status]  When 1 then N'فعال' when 0 then N'غیر فعال' end StatusTitle
                    , (select top 1 SharePCode from SharePCodeSheet where PersonCode = AgentAllPerson.Code AND CompanyCode = S1.CompanyCode) AgentPCode, PersonAgent.Name + ' ' +PersonAgent .Fam as AgentName
                    , Person .Code PersonCode, (select top 1 SharePCode from SharePCodeSheet where PersonCode = Person .Code AND CompanyCode = S1.CompanyCode) SharePCode, Person.PersonName , Person.Fam_CompanyName Family , Person.Name FamName , Person.BirthDate
                    , Person . IDNo , Person .IssueCityName, Person .NationalCode_CommercialCode, Person .FatherName
                    ,Person.HomeTel, Person.WorkTel, Person.Mobile, Person.HomeAddress, Person.HomePostCode, Person.WorkAddress, Person.WorkPostCode
                    ,Person.HomeCity
                    ,Person.WorkCity
                    ,ISNULL((select TOP 1 CAST(Price AS BIGINT) from sharePrice where CompanyCode=S1.CompanyCode order by ChangeDate DESC ),0) * S1.ShareCount ShareCost
                    ,(Select cast(CurrentShareCost as bigint) From ShareCompany Where ShareCompany.Code = S1 .CompanyCode ) * S1.ShareCount as NameCost
					,ISNULL(legDistraint .Code, 0) DistraintCode ,Convert (bit,  Case  legDistraint .Active When 1 then 1 else 0 END ) AS Distrainted 
					,(Select top 1  Fa_Date From StaticDates Where En_Date = CONVERT (Date, GETDATE())) Currentdate,
                    case when Person.Died = 0 then N'خیر' else N'بلی' end Died ,legDistraint.OrderComment   
					,LSC.ContractTitle,lsc.Number LSCNumber,LSC.Code LSCCode, LSC.Type LSCType,
					(	
						select isnull(sum(ss.ShareCount),0) from ShareSheet ss
						Where ss.Status=1 and S1.CompanyCode=ss.CompanyCode and SS.ACode=S1.ACode
					) ShareACount
                    ,case when EXISTS(SELECT * FROM sys.columns WHERE Name      = N'عکس' AND Object_ID = Object_ID(N'PersonAddressViewSharePCode')) then person.عکس else 0 end N'عکس'
                    ,case when EXISTS(SELECT * FROM sys.columns WHERE Name      = N'فرم__مشخصات' AND Object_ID = Object_ID(N'PersonAddressViewSharePCode')) then person.فرم__مشخصات else 0 end N'فرم__مشخصات'
                    ,case when EXISTS(SELECT * FROM sys.columns WHERE Name      = N'کپی__شناسنامه' AND Object_ID = Object_ID(N'PersonAddressViewSharePCode')) then person.کپی__شناسنامه else 0 end N'کپی__شناسنامه'
                    ,case when EXISTS(SELECT * FROM sys.columns WHERE Name      = N'کپی__کارت__ملی' AND Object_ID = Object_ID(N'PersonAddressViewSharePCode')) then person.کپی__کارت__ملی else 0 end N'کپی__کارت__ملی'
            from ShareSheet S1
                    Inner Join PersonAddressViewSharePCode Person On S1.PCode = Person .Code
                    inner join vSharePerson  on S1.PCode  = vSharePerson.PCode 
                    Left Join ShareAgent on ShareAgent.Code = S1 .ACode 
                    Left join vShareAgent on vShareAgent.Code = ShareAgent.Code 
                    Left Join clsPerson PersonAgent On ShareAgent.PCode = PersonAgent.Code
                    Left Join clsAllPerson AgentAllPerson on AgentAllPerson.Code= PersonAgent.Code
                    Left Join ShareTransfer on ShareTransfer .SCode = S1.Code
                  INNER JOIN finAsset ON finAsset .ClassName = 'ManagementShares.JShareSheet' AND  finAsset .ObjectCode = S1 .Code 
                left Join [legDistraint]  ON legDistraint.Asset = finAsset .Code and legDistraint .Active = 1
                left  JOIN finAsset  finAssetContract ON finAssetContract .ClassName = 'ManagementShares.JShareSheet' AND  finAssetContract .ObjectCode = S1 .ParentCode 
				left join LegSubjectContract LSC on lsc.FinanceCode=finAssetContract.Code
				Where 1 = 1 
				and Person.CompanyCode=S1.CompanyCode ");

		private static Globals.Property.JProperties P = new Globals.Property.JProperties("ManagementShares.JTransferSheetForm", 0);
		private static string transferSql = string.Format(@" 
 Select 
Case Mosalehe When 0 then N'خیر' when 1 then N'بله' else '' end Mosalehe, 
sum(S1 . ShareCount) ShareCount, dbo.[Num_ToWords](sum(S1 . ShareCount) ) as ShareCountAlphabet, min(S1 .Az) Az, max(S1 .Ela) Ela,
(Select  top 1 Fa_Date from StaticDates where En_Date = cast(TDate as date)) TransferDate, sum(TranSum) TranSum, 
ShNote, ShIndex , Tax , Price AllCost , voucher , 
  (select sharepcode from SharePCodeSheet WHere PersonCode=FPCode and CompanyCode=S1.CompanyCode)FPCode,
Person .Name SellerName ,  Person.FatherName SellerFatherName, Person .IDNo SellerIDNo, Person .IssueCityName SellerIssueCityName , Person .NationalCode_CommercialCode SellerNationalCode_CommercialCode , Person .homeTel SellerHomeTel,  Person .WorkTel SellerWorkTel, 

((select sharepcode from SharePCodeSheet WHere PersonCode=SPCode and CompanyCode=S1.CompanyCode))SPCode, 
 PersonBuyer .Name BuyerName ,  PersonBuyer.FatherName BuyerFatherName, PersonBuyer .IDNo BuyerIDNo, PersonBuyer .IssueCityName BuyerIssueCityName , PersonBuyer .NationalCode_CommercialCode BuyerNationalCode_CommercialCode , PersonBuyer .homeTel BuyerHomeTel,  PersonBuyer .WorkTel BuyerWorkTel
    , (Select  top 1 Fa_Date From StaticDates Where En_Date  = Person_Seller.BthDate ) SellerBirthDate
    , (Select  top 1 Fa_Date From StaticDates Where En_Date = Person_Buyer.BthDate ) BuyerBirthDate,(select Died from clsPerson where FPCode=Code)Died  
	,Person.Address  SellerAddress,PersonBuyer.Address BuyerAddress,Person.SharePCode SellerSharePCode,PersonBuyer.SharePCode BuyerSharePcode
	,Person.BirthDate SellerBrithDate,PersonBuyer.BirthDate BuyerBrithDate,Person.Mobile SellerMobile,PersonBuyer.Mobile BuyerMobile
	,(select sum(ShareCount) from ShareSheet ss where ss.CompanyCode=S1.CompanyCode AND ss.PCode=PersonBuyer.Code and Status=1) BuyerShareCount
	,(select sum(ShareCount) from ShareSheet ss where ss.CompanyCode=S1.CompanyCode AND ss.PCode=Person.Code and Status=1) SellerShareCount
,dbo.[Num_ToWords]((select sum(ShareCount) from ShareSheet ss where ss.CompanyCode=S1.CompanyCode AND ss.PCode=PersonBuyer.Code and Status=1)) BuyerShareCountAlphabet
,dbo.[Num_ToWords]((select sum(ShareCount) from ShareSheet ss where ss.CompanyCode=S1.CompanyCode AND ss.PCode=Person.Code and Status=1)) SellerShareCountAlphabet
,(select top 1 Fa_Date from StaticDates where EN_date=cast(getdate() as date)) Nowdate
,sellerPropperty.*,buyerPropperty.*,prop.*
from ShareTransfer 
 Inner Join ShareSheet S1 on S1 .Code = ShareTransfer .SCode
  Inner Join PersonAddressViewSharePCode Person On ShareTransfer.FPCode = Person .Code
  Inner Join PersonAddressViewSharePCode PersonBuyer On ShareTransfer.SPCode = PersonBuyer .Code
                    Left Join ShareAgent on ShareAgent.Code = S1 .ACode 
                    Left join vShareAgent on vShareAgent.Code = ShareAgent.Code 
                    Left Join clsPerson PersonAgent On ShareAgent.PCode = PersonAgent.Code
                    Left Join clsPerson Person_Seller On Person.Code = Person_Seller .Code 
                    Left Join clsPerson Person_Buyer On PersonBuyer.Code = Person_Buyer.Code
					left join [Propperty_ClassName_ClassLibrary.JRealPerson_1] sellerPropperty on sellerPropperty.ObjectCode = Person.Code
					left join [Propperty_ClassName_ClassLibrary.JRealPerson_1] buyerPropperty on buyerPropperty.ObjectCode = PersonBuyer.Code
					left join " + P.TableName + @" Prop on ShareTransfer.Code = Prop.ObjectCode 
					WHERE 1=1   and Person.CompanyCode=S1.CompanyCode  and PersonBuyer.CompanyCode=S1.CompanyCode
					@AND@
					group by
sellerPropperty.ObjectCode,buyerPropperty.ObjectCode,
ShNote, ShIndex , Tax , Price  , voucher , FPCode,
Person .Name,  Person.FatherName, Person .IDNo,
 Person .IssueCityName, Person .NationalCode_CommercialCode,
  Person .homeTel,  Person .WorkTel, 

SPCode, 
 PersonBuyer .Name  ,  PersonBuyer.FatherName , PersonBuyer .IDNo , PersonBuyer .IssueCityName  ,
  PersonBuyer .NationalCode_CommercialCode  , PersonBuyer .homeTel ,  PersonBuyer .WorkTel 
    , Person_Seller.BthDate
    , Person_Buyer.BthDate
	,Person.Address  ,PersonBuyer.Address ,Person.SharePCode ,PersonBuyer.SharePCode 
	,Person.BirthDate ,PersonBuyer.BirthDate ,Person.Mobile ,PersonBuyer.Mobile 
	,S1.CompanyCode
	,Mosalehe,TDate,Person.Code,PersonBuyer.Code,Person_Seller.Code");
         
        public static DataTable SelectSheetsReport(string Filter, string PersonFilter, string AgentFilter, string TransferFilter, ref string ShareCount)
        {

            string sql = SQLSheet + Filter + PersonFilter + AgentFilter + TransferFilter;
            //if (!string.IsNullOrEmpty(PersonFilter))
            //    sql += " AND ShareSheet.PCode IN ( Select Code From clsAllPerson Where 1 =1 " + PersonFilter + ")";
            //if (!string.IsNullOrEmpty(AgentFilter))
            //    sql += " AND ShareSheet.ACode IN ( Select Code From ShareAgent Where 1 =1 " + AgentFilter + ")";
            //if (!string.IsNullOrEmpty(TransferFilter))
            //    sql += " AND ShareSheet.Code IN ( Select SCode From ShareTransfer Where 1 =1 " + TransferFilter + ")";

            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(sql);
                DataTable result = db.Query_DataTable();
                sql = "SELECT SUM(ShareCount) From (" + sql + ") A";
                db.setQuery(sql);
                ShareCount = db.Query_DataTable().Rows[0][0].ToString();
                return result;
            }
            finally
            {
                db.Dispose();
            }
        }


        public static DataTable SelectPerson(string SheetFilter, string PersonFilter, string AgentFilter, string TransferFilter)
        {
            string sql = string.Format(@"  Select distinct Person.SharePCode ,PErson.Name, Person.FatherName, IDNo , Person .NationalCode_CommercialCode, Person .Gender, 
            Person.GenderTitle, Person .ISBlockedTitle , Person .IsDiedTitle , Tel, Address, vSharePerson.ShareCount,PersonAgent.Died  From ShareSheet S1
            inner join vSharePerson  on S1.PCode  = vSharePerson.PCode 
            inner join [PersonAddressViewSharePCode] Person on Person.Code = S1.PCode
            Left Join ShareAgent  on ShareAgent.Code = S1 .ACode 
            Left join vShareAgent on vShareAgent.Code = ShareAgent.Code 
			Left Join clsPerson PersonAgent On ShareAgent.PCode = PersonAgent.Code
			Left Join ShareTransfer on ShareTransfer .SCode = S1.Code
            Where 1=1 and Person.CompanyCode=S1.CompanyCode  " + AgentFilter + SheetFilter + PersonFilter + TransferFilter);
            //if (!string.IsNullOrEmpty(SheetFilter))
            //    sql += " AND ShareSheet.Code IN ( Select Code From ShareSheet Where 1 =1 " + SheetFilter + ")";
            //if (!string.IsNullOrEmpty(PersonFilter))
            //    sql += " AND ShareSheet.PCode IN ( Select Code From clsAllPerson Where 1 =1 " + PersonFilter + ")";
            //if (!string.IsNullOrEmpty(TransferFilter))
            //    sql += " AND ShareSheet.Code IN ( Select SCode From ShareTransfer Where 1 =1 " + TransferFilter + ")";
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(sql);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public static DataTable SelectAgent(string SheetFilter, string PersonFilter, string AgentFilter, string TransferFilter)
        {
            string sql = string.Format(@" 
              SELECT distinct ShareAgent.Code , AgentAllPerson.SharePCode AgentPCode , PersonAgent.Name  AgentName, 
                    (Select  top 1 Fa_Date  From StaticDates Where En_Date = ShareAgent.StartDate  ) StartDate
                    ,(Select  top 1 Fa_Date From StaticDates Where En_Date = ShareAgent.EndDate ) EndDate
                    ,Case ShareAgent.Status 
	                    When 1 then N'فعال'
	                    When 0 then N'غیر فعال' end StatusTitle, ShareAgent.Status 
                        , vShareAgent.SheetsCount
	                    , vShareAgent.SharesCount 
					 , PersonAgent.IDNo  , PersonAgent.FatherName , PersonAgent.NationalCode_CommercialCode NationalCode
					, PersonAgent.HomeAddress ,  PersonAgent.HomeTel , PersonAgent.HomePostCode ,PersonAgent.Mobile ,PersonAgent.WorkAddress , PersonAgent.WorkPostCode , PersonAgent.WorkTel 
                                From ShareAgent
                     inner join vShareAgent on vShareAgent.Code = ShareAgent.Code 
                     inner join ShareSheet S1 on S1.ACode = ShareAgent.Code
                     inner join vSharePerson  on S1.PCode  = vSharePerson.PCode 
                        inner join [PersonAddressViewSharePCode] Person on Person.Code = S1.PCode
			            Left Join [PersonAddressViewSharePCode] PersonAgent On ShareAgent.PCode = PersonAgent.Code
                        Left Join clsAllPerson AgentAllPerson on PersonAgent.Code = AgentAllPerson .Code 
			            Left Join ShareTransfer on ShareTransfer .SCode = S1.Code
              Where 1=1   and Person.CompanyCode=S1.CompanyCode  and PersonAgent.CompanyCode=S1.CompanyCode " + AgentFilter + SheetFilter + TransferFilter + PersonFilter);
            //if (!string.IsNullOrEmpty(SheetFilter))
            //    sql += " AND ShareSheet.Code IN ( Select Code From ShareSheet Where 1 =1 " + SheetFilter + ")";
            //if (!string.IsNullOrEmpty(PersonFilter))
            //    sql += " AND Person.Code IN ( Select Code From PersonAddressViewSharePCode Where 1 =1 " + PersonFilter + ")";
            //if (!string.IsNullOrEmpty(TransferFilter))
            //    sql += " AND ShareSheet.Code IN ( Select SCode From ShareTransfer Where 1 =1 " + TransferFilter + ")";

            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(sql);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public static DataTable SelectTransfer(string SheetFilter, string PersonFilter, string AgentFilter, string TransferFilter,ref string ShareCount)
        {
             string sql = transferSql.Replace("@AND@",  TransferFilter + SheetFilter + AgentFilter + TransferFilter);
             //if (!string.IsNullOrEmpty(SheetFilter))
            //    sql += " AND ShareSheet.Code IN ( Select Code From ShareSheet Where 1 =1 " + SheetFilter + ")";
            //if (!string.IsNullOrEmpty(PersonFilter))
            //    sql += " AND ShareSheet.ACode IN ( Select Code From ShareAgent Where 1 =1 " + AgentFilter + ")";
            //if (!string.IsNullOrEmpty(TransferFilter))
            //    sql += " AND ShareSheet.Code IN ( Select SCode From ShareTransfer Where 1 =1 " + TransferFilter + ")";

			 Globals.Property.JPropertyTables Prop1 = new Globals.Property.JPropertyTables("ClassLibrary.JRealPerson", 1);
			 sql = sql.Replace("sellerPropperty.*", Prop1.getFieldsNameTable("sellerPropperty"));
			 sql = sql.Replace("buyerPropperty.*", Prop1.getFieldsNameTable("buyerPropperty"));
			 Globals.Property.JPropertyTables Prop2 = new Globals.Property.JPropertyTables("ManagementShares.JTransferSheetForm", 0);
			 sql = sql.Replace("prop.*", Prop2.getFieldsNameTable("prop"));
			 sql = sql + ',' + Prop1.getFieldsNameTable("sellerPropperty") + ',' + Prop1.getFieldsNameTable("buyerPropperty") + ',' + Prop2.getFieldsNameTable("prop");

            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(sql);
                DataTable result = db.Query_DataTable();

                sql = "SELECT SUM(ShareCount) From (" + sql + ") A";
				db.setQuery(sql.Replace(',' + Prop1.getFieldsNameTable("sellerPropperty") + ',' + Prop1.getFieldsNameTable("buyerPropperty") + ',' + Prop2.getFieldsNameTable("prop"), ""));
                ShareCount = db.Query_DataTable().Rows[0][0].ToString();
                return result;
            }
            finally
            {
                db.Dispose();
            }
        }

        public void ShowReportForm(int pCompanyCode)
        {
            ManagementShares.JReportSheetForm form = new JReportSheetForm(pCompanyCode);
            form.ShowDialog();
        }
    }
}
