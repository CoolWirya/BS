using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ManagementShares.TransferRequest
{
    public class JRequests
    {
        /// <summary>
        /// لیست همه درخواستهای خرید و فروش
        /// استفاده شده در وب سرویس موبایل سهام
        /// قبل از هر تغییری هماهنگ شود
        /// </summary>
        /// <param name="personCode"></param>
        /// <returns></returns>
        public static DataTable GetAllRequests(int personCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                string sql = string.Format(@"
	          Select Code, 'درخواست خرید' AS 'Type'
                , ((Select Fa_Date FROM StaticDates WHERE EN_Date = Convert(Date, RequestDate)) + ' - '+ RIGHT(Convert(varchar, RequestDate, 120), 8 )) RequestDate 
                , ShareCount
	            ,Case Status 
		            When 0 then 'در انتظار پاسخ' 
		            When 1 then 'پذیرفته شده' 
		            When 2 then 'رد شده' 
		            When -1 then 'کنسل شده'  end AS RequestStatus
	            from ShareRequestBuy Where PCode = {0}
            union all
    
            Select Code ,'درخواست فروش' as 'Type'
                , ((Select Fa_Date FROM StaticDates WHERE EN_Date = Convert(Date, RequestDate)) + ' - '+ RIGHT(Convert(varchar, RequestDate, 120), 8 )) RequestDate 
                , ShareCount
	            ,Case Status 
		            When 0 then 'در انتظار پاسخ' 
		            When 1 then 'پذیرفته شده' 
		            When 2 then 'رد شده' 
		            When -1 then 'کنسل شده'  end AS RequestStatus
	            from ShareRequestSell Where PCode = {0}
	            Order By RequestDate DESC", personCode);
                db.setQuery(sql);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public static string GetBuyRequestSqlQuery()
        {
            return @"select top 100 PERCENT * from(Select top 100 percent ShareRequestBuy.Code, 'درخواست خرید' AS 'Type',cap.Name
                , ((Select Fa_Date FROM StaticDates WHERE EN_Date = Convert(Date, RequestDate)) + ' - '+ RIGHT(Convert(varchar, RequestDate, 120), 8 )) RequestDate 
                , ShareCount
	            ,Case Status 
		            When 0 then 'در انتظار پاسخ' 
		            When 1 then 'پذیرفته شده' 
		            When 2 then 'رد شده' 
		            When -1 then 'کنسل شده'  end AS RequestStatus
	            from ShareRequestBuy
	            LEFT JOIN clsAllPerson cap
	            ON ShareRequestBuy.PCode = cap.Code
                Order By RequestDate DESC)tb1";
        }

        public static string GetSellRequestSqlQuery()
        {
            return @"select top 100 PERCENT * from(Select top 100 percent ShareRequestSell.Code ,'درخواست فروش' as 'Type',cap.Name
                , ((Select Fa_Date FROM StaticDates WHERE EN_Date = Convert(Date, RequestDate)) + ' - '+ RIGHT(Convert(varchar, RequestDate, 120), 8 )) RequestDate 
                , ShareCount
	            ,Case Status 
		            When 0 then 'در انتظار پاسخ' 
		            When 1 then 'پذیرفته شده' 
		            When 2 then 'رد شده' 
		            When -1 then 'کنسل شده'  end AS RequestStatus
	            from ShareRequestSell
	            LEFT JOIN clsAllPerson cap
	            ON ShareRequestSell.PCode = cap.Code
	            Order By RequestDate DESC)tb1";
        }

    }
}
