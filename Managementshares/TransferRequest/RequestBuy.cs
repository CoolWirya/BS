using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ManagementShares.TransferRequest
{
    /// <summary>
    /// وضعیت درخواست
    /// </summary>
    public enum RequestStatus
    {
        /// <summary>
        /// در انتظار پاسخ
        /// </summary>
        Waiting = 0,
        /// <summary>
        /// پذیرفته شده
        /// </summary>
        Accepted = 1,
        /// <summary>
        /// رد شده
        /// </summary>
        Rejected = 2,
        /// <summary>
        /// لغو شده
        /// </summary>
        Canceled = -1
    }
    /// <summary>
    /// درخواست خرید
    /// </summary>
    public class JRequestBuy
    {
        #region Properties
        public int Code { get; set; }
        /// <summary>
        /// کد شخص
        /// </summary>
        public int PCode { get; set; }
        /// <summary>
        /// تاریخ درخواست
        /// </summary>
        public DateTime RequestDate { get; set; }
        /// <summary>
        /// تعداد سهم درخواستی جهت خرید
        /// </summary>
        public int ShareCount { get; set; }
        /// <summary>
        /// وضعیت
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// شرح
        /// </summary>
        public int Description { get; set; }
        #endregion

         public JRequestBuy()
        {
        }

         public JRequestBuy(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }

        public void GetData(int pCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(" SELECT * From ShareRequestBuy WHERE Code = " + pCode);
                DataTable requestTable = db.Query_DataTable();
                if (requestTable.Rows.Count > 0)
                    JTable.SetToClassProperty(this, requestTable.Rows[0]);
            }
            finally
            {
                db.DisConnect();
            }
        }

        public int Insert()
        {
            JRequestBuyTable request = new JRequestBuyTable();
            try
            {
                // if (JPermission.CheckPermission("ManagementShares.RequestTransfer.JRequestBuy.Insert"))
                {
                    request.SetValueProperty(this);
                    Code = request.Insert();
                    if (Code > 0)
                    {
                        return Code;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
        }

        public bool Update(JDataBase pDB)
        {
            JRequestBuyTable JUBT = new JRequestBuyTable();
            //if (JPermission.CheckPermission("ManagementShares.RequestTransfer.JRequestBuy.Update"))
            {
                JUBT.SetValueProperty(this);
                return JUBT.Update(pDB);
            }
        }

        public bool Delete(JDataBase pDB)
        {
            JRequestBuyTable JUBT = new JRequestBuyTable();
            //if (JPermission.CheckPermission("ManagementShares.RequestTransfer.JRequestBuy.Update"))
            {
                JUBT.SetValueProperty(this);
                return JUBT.Delete(pDB);
            }
        }

        public bool SetRequestStatus(RequestStatus status)
        {
            this.Status = status.GetHashCode();
            return this.Update(null);
        }

    }

    public class JRequestBuys
    {
        public static DataTable GetDataTable( int personCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                string sql = string.Format(@"
	            Select Code
                , ((Select Fa_Date FROM StaticDates WHERE EN_Date = Convert(Date, RequestDate)) + ' - '+ RIGHT(Convert(varchar, RequestDate, 120), 8 )) RequestDate 
                , ShareCount
	            ,Case Status 
		            When 0 then 'در انتظار پاسخ' 
		            When 1 then 'پذیرفته شده' 
		            When 2 then 'رد شده' 
		            When -1 then 'کنسل شده'  end AS RequestStatus
	            from ShareRequestBuy Where PCode = {0}
	            Order By RequestDate DESC", personCode);
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
