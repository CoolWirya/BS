using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;

namespace StoreComplex
{
    public class JSCReport
    {
        public void ShowDialog()
        {
            JReportForm form = new JReportForm();
            form.ShowDialog();
        }
        /// <summary>
        /// کلی Join
        /// </summary>
        static string AllJoin = @"       FROM legSubjectContract Contract
--- اشخاص قراردادها
	INNER JOIN LegPersonContract PersonContract ON Contract .Code = PersonContract  .ContractSubjectCode  AND PersonContract.Type  = " 
            + ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer +
@"    
--- اشخاص
	INNER JOIN clsAllPerson Person ON Person .Code = PersonContract .PersonCode                                
--- رسیدها
	LEFT JOIN SCReceipt Receipt ON Receipt .ContractCode = Contract .Code 
--- کالاهای رسید
	LEFT JOIN SCReceiptGoods ReceiptGood ON Receipt .Code = ReceiptGood .ReceiptCode
--- کالاهای انبار برای رسید
	LEFT JOIN StoreGoods RGood ON RGood .Code = ReceiptGood .GoodCode
--- حواله ها
	LEFT JOIN SCTransfer  Transfer ON Transfer.ContractCode = Contract .Code 
--- کالاهای حواله
	LEFT JOIN SCTransferGoods TranGood ON Transfer .Code = TranGood .TransferCode 
--- کالاهای خارج شده 
	LEFT JOIN SCReceiptGoods TranReceiptGood ON TranReceiptGood .GoodCode = ReceiptGood .Code 
--- کالاهای انبار برای حواله
	LEFT JOIN StoreGoods TGood ON TGood .Code = TranReceiptGood .GoodCode 
--- خدمات حمل و نقل	
	LEFT JOIN SCConveyService ConveyService ON ConveyService .ContractCode = Contract .Code 
--- خدمات تخلیه و بارگیری
	LEFT JOIN SCLoadingService  LoadingService ON LoadingService.ContractCode = Contract .Code 
--- سایر خدمات
	LEFT JOIN SCService   Service ON Service.ContractCode = Contract .Code 
--- اجاره انبار اختصاصی
	LEFT JOIN SCPrivateStorage PrivateStorage ON PrivateStorage.ReceiptCode  = Receipt .Code 
 --- انبارها
	LEFT JOIN SCStorage Storage ON PrivateStorage.StorageCode = Storage .Code 
--- تمدید اجاره
	LEFT JOIN SCRenew Renew ON Renew .ReceiptGoodCode = ReceiptGood .Code 
--- تمدید اجاره انبار اختصاصی
	LEFT JOIN SCRenewPrivate RenewPrivate ON RenewPrivate  .PrivateCode = PrivateStorage  .Code 
where SCContractType is not null AND SCContractType > 0 ";
        /// <summary>
        /// قراردادها
        /// </summary>
        /// <param name="contractFilter"></param>
        /// <returns></returns>
        public static DataTable SelectContract(string contractFilter, string receiptFilter, string transferFilter, string serviceFilter, string privateStorageFilter)
        {
            string sql = @" Select Distinct  
                 SCCode , Person.Code, Person.Name PersonName
                 ,(Select Fa_DAte From StaticDates Where En_Date = Contract.Date ) ContractDate
                 ,Contract.SCContractType ,   Case SCContractType 
	            When 1 then 'قرارداد انبارداری'
	            When 2 then 'قرارداد اجاره انبار اختصاصی'
                 else '' end  TypeTitle " + AllJoin + contractFilter + receiptFilter + transferFilter + serviceFilter +privateStorageFilter;
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
        /// <summary>
        /// رسید
        /// </summary>
        /// <param name="contractFilter"></param>
        /// <param name="receiptFilter"></param>
        /// <returns></returns>
        public static DataTable SelectReceipt(string contractFilter, string receiptFilter, string transferFilter, string serviceFilter, string privateStorageFilter)
        {
            string sql = @"  Select Distinct Receipt.Serial  
             ,(Select Fa_Date From StaticDates Where En_Date = CONVERT (Date, Receipt.[Date] ) ) Date
              ,LEFT( CONVERT (Time, Receipt.[Date] ), 5) Time, Receipt . DriverName ,Receipt . Description, Contract .SCCode ,  Person .Name PersonName "
                + AllJoin + receiptFilter + contractFilter + transferFilter + serviceFilter + privateStorageFilter;
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
        /// <summary>
        /// حواله
        /// </summary>
        /// <param name="contractFilter"></param>
        /// <param name="receiptFilter"></param>
        /// <returns></returns>
        public static DataTable SelectTransfer(string contractFilter, string receiptFilter, string transferFilter, string serviceFilter, string privateStorageFilter)
        {
            string sql = @" Select Distinct  (Select Fa_Date From StaticDates Where En_Date = CONVERT (Date, Transfer.[Date] ) ) Date
              ,LEFT( CONVERT (Time, Transfer.[Date] ), 5) Time, Transfer . DriverName ,Transfer . Description, Contract .SCCode , Person .Name   PersonName "
                + AllJoin + receiptFilter + contractFilter + transferFilter + serviceFilter + privateStorageFilter;
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
        
        /// <summary>
        /// سرویس حمل و نقل
        /// </summary>
        /// <param name="contractFilter"></param>
        /// <param name="receiptFilter"></param>
        /// <param name="transferFilter"></param>
        /// <param name="serviceFilter"></param>
        /// <param name="privateStorageFilter"></param>
        /// <returns></returns>
        public static DataTable SelectConveyService(string contractFilter, string receiptFilter, string transferFilter, string serviceFilter, string privateStorageFilter)
        {
            string sql = @" Select Distinct
                Case ConveyService.ClassName WHEN 'StoreComplex.JSCReceipt' THEN N'رسید'  WHEN 'StoreComplex.JSCTransfer' THEN N'حواله' END AS Receipt_Transfer
                , (SELECT Fa_Date FROM StaticDates WHERE En_Date = CONVERT(Date, ConveyService.[Date])) ServiceDate
                , (SELECT Name FROM subdefine WHERE Code = ConveyService.DriveType ) DriveType, ConveyService.PelakNo ,ConveyService.DriverName , ConveyService.Cost , Contract.SCCode " + AllJoin + receiptFilter + contractFilter + transferFilter + serviceFilter + privateStorageFilter;
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
        /// <summary>
        /// سرویس تخلیه و بارگیری
        /// </summary>
        /// <param name="contractFilter"></param>
        /// <param name="receiptFilter"></param>
        /// <param name="transferFilter"></param>
        /// <param name="serviceFilter"></param>
        /// <param name="privateStorageFilter"></param>
        /// <returns></returns>
        public static DataTable SelectLoadingService(string contractFilter, string receiptFilter, string transferFilter, string serviceFilter, string privateStorageFilter)
        {
            string sql = @" Select Distinct
                Case LoadingService.ClassName WHEN 'StoreComplex.JSCReceipt' THEN N'رسید'  WHEN 'StoreComplex.JSCTransfer' THEN N'حواله' END AS Receipt_Transfer
                , (SELECT Fa_Date FROM StaticDates WHERE En_Date = CONVERT(Date, LoadingService.[Date])) ServiceDate
                , (SELECT Title FROM SCStorage WHERE Code = LoadingService.Location  ) Location, LoadingService.WorkerCount  ,LoadingService.WorkerDuration , LoadingService.Cost , Contract.SCCode  " + AllJoin + receiptFilter + contractFilter + transferFilter + serviceFilter + privateStorageFilter;
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

        /// <summary>
        /// سایر خدمات
        /// </summary>
        /// <param name="contractFilter"></param>
        /// <param name="receiptFilter"></param>
        /// <param name="transferFilter"></param>
        /// <param name="serviceFilter"></param>
        /// <param name="privateStorageFilter"></param>
        /// <returns></returns>
        public static DataTable SelectService(string contractFilter, string receiptFilter, string transferFilter, string serviceFilter, string privateStorageFilter)
        {
            string sql = @" Select Distinct
                Case Service.ClassName WHEN 'StoreComplex.JSCReceipt' THEN N'رسید'  WHEN 'StoreComplex.JSCTransfer' THEN N'حواله' ELSE '' END AS Receipt_Transfer
                , (SELECT Fa_Date FROM StaticDates WHERE En_Date = CONVERT(Date, Service.[Date])) ServiceDate
                , (SELECT Name  FROM subdefine  WHERE Code =Service.ServiceType) ServiceType , Service.Description  , Service.ServiceCost   , Contract.SCCode  " + AllJoin + receiptFilter + contractFilter + transferFilter + serviceFilter + privateStorageFilter;
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

        /// <summary>
        /// اجاره انبار اختصاصی
        /// </summary>
        /// <param name="contractFilter"></param>
        /// <param name="receiptFilter"></param>
        /// <param name="transferFilter"></param>
        /// <param name="serviceFilter"></param>
        /// <param name="privateStorageFilter"></param>
        /// <returns></returns>
        public static DataTable SelectPrivateStorage(string contractFilter, string receiptFilter, string transferFilter, string serviceFilter, string privateStorageFilter)
        {
            string sql = @" Select DISTINCT   PrivateStorage.BoxCount , PrivateStorage.Cost ,PrivateStorage.Description, Storage.Title Storage   "
                    + AllJoin + receiptFilter + contractFilter + transferFilter + serviceFilter + privateStorageFilter;
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
        /// <summary>
        /// کالاها
        /// </summary>
        /// <param name="contractFilter"></param>
        /// <param name="receiptFilter"></param>
        /// <param name="transferFilter"></param>
        /// <param name="serviceFilter"></param>
        /// <param name="privateStorageFilter"></param>
        /// <returns></returns>
        public static DataTable SelectReceiptGoods(string contractFilter, string receiptFilter, string transferFilter, string serviceFilter, string privateStorageFilter)
        {
            string sql = @"Select Distinct 
                (SELECT Name FROM subdefine WHERE Code = RGood .GroupCode ) GoodGroup,RGood .Name GoodName
                ,Contract.SCCode ,ReceiptGood .Amount ,ReceiptGood .Description , ReceiptGood .Cost   
                ,(Select Name FROM subdefine WHERE Code = ReceiptGood .StoreType ) "
                    + AllJoin + receiptFilter + contractFilter + transferFilter + serviceFilter + privateStorageFilter;
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
        /// <summary>
        /// تمدید اجاره
        /// </summary>
        /// <param name="contractFilter"></param>
        /// <param name="receiptFilter"></param>
        /// <param name="transferFilter"></param>
        /// <param name="serviceFilter"></param>
        /// <param name="privateStorageFilter"></param>
        /// <returns></returns>
        public static DataTable SelectRenew(string contractFilter, string receiptFilter, string transferFilter, string serviceFilter, string privateStorageFilter)
        {
            string sql = @"Select Distinct 
                 (Select Fa_date FROM StaticDates WHERE En_Date = Convert(Date, Renew.Date )) Date 
                 , Renew .Cost , Renew . Amount , Renew .Description  "
                    + AllJoin + receiptFilter + contractFilter + transferFilter + serviceFilter + privateStorageFilter;
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
        /// <summary>
        /// تمدید اجاره انبار اختصاصی
        /// </summary>
        /// <param name="contractFilter"></param>
        /// <param name="receiptFilter"></param>
        /// <param name="transferFilter"></param>
        /// <param name="serviceFilter"></param>
        /// <param name="privateStorageFilter"></param>
        /// <returns></returns>
        public static DataTable SelectRenewPrivate(string contractFilter, string receiptFilter, string transferFilter, string serviceFilter, string privateStorageFilter)
        {
            string sql = @"  Select Distinct   
                 (Select Fa_date FROM StaticDates WHERE En_Date = Convert(Date, RenewPrivate .Date )) Date 
                 , RenewPrivate .Cost , RenewPrivate . BoxCount  , RenewPrivate.Description  "
                    + AllJoin + receiptFilter + contractFilter + transferFilter + serviceFilter + privateStorageFilter;
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
    }
}
