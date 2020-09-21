using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;

namespace ManagementShares
{
    public enum JCompanyActions
    {
        IncreaseShare = 1,
        JoinAllSheets = 2,
        CancelPrints = 3,
        BreakSheets = 4,
    }
    public class JIncreaseShare :JManagementshares
    {
        #region Propetties

        public int Code { get; set; }
        /// <summary>
        /// تاریخ افزایش سرمایه
        /// </summary>
        public DateTime IncDate { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// کد شرکت
        /// </summary>
        public int CompanyCode { get; set; }
        /// <summary>
        /// مبلغ هر سهم
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// تعداد کل سهام
        /// </summary>
        public decimal ShareCount { get; set; }
        /// <summary>
        /// عملیات افزایش / تجمیع / ...ـ
        /// </summary>
        public int Action{ get; set; }
        /// <summary>
        /// کد کاربر 
        /// </summary>
        public int UserCode { get; set; }
        /// <summary>
        /// تعداد بخش شکستن هر سهم
        /// </summary>
        public int BreakCount { get; set; }
        /// <summary>
        /// پست کاربر
        /// </summary>
        public int PostCode { get; set; }

        #endregion Propetties

        public JIncreaseShare()
        {
        }

        public JIncreaseShare(int pCode)
        {
            GetData(pCode);
        }
        public void GetData(int pCode)
        {
            GetData(pCode, null);
        }
        public void GetData(int pCode, JDataBase pDB)
        {
            string sql = "Select * From ShareIncreaseCourse Where Code = " + pCode + " ORDER BY IncDate Desc ";
            JDataBase db;
            if (pDB == null)
                db = new JDataBase();
            else db = pDB;
                try
                {
                    db.setQuery(sql);
                    DataTable tableInc = db.Query_DataTable();
                    if (tableInc.Rows.Count > 0)
                    {
                        JTable.SetToClassProperty(this, tableInc.Rows[0]);
                    }

                }
                finally
                {
                    if (pDB == null)
                        db.Dispose();
                }
        }

        public int Insert(JDataBase pDB)
        {
            JIncreaseShareTable tranTable = new JIncreaseShareTable();
            try
            {
                if (JPermission.CheckPermission("ManagementShares.JIncreaseShare.Insert"))
                {
                    this.UserCode = JMainFrame.CurrentUserCode;
                    this.PostCode = JMainFrame.CurrentPostCode;
                    tranTable.SetValueProperty(this);
                    tranTable.Set_ComplexInsert(false);
                    
                    Code = tranTable.Insert(pDB);
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
            finally
            {
                //       Db.Dispose();
            }
        }


    }
    public class JIncreaseShares
    {
        public static DataTable GetIncreaseHistory(int CompanyCode)
        {
            string sql = @"SELECT Code,(Select Fa_Date From StaticDates Where En_Date =  IncDate) Date , Comment, CompanyCode, Cost NameShareCost, ShareCount 
            ,(Select UserName From Users Where Code = UserCode) UserName  FROM [ShareIncreaseCourse] Where CompanyCode=" + CompanyCode + " AND Action = " + JCompanyActions.IncreaseShare.GetHashCode() + "  ORDER BY IncDate Desc ";
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
        public static DataTable GetJoinHistory(int CompanyCode)
        {
            string sql = @" SELECT Code, (Select Fa_Date From StaticDates Where En_Date =  IncDate) Date, Comment
            ,(Select UserName From Users Where Code = UserCode) UserName  FROM [ShareIncreaseCourse] Where CompanyCode=" + CompanyCode + " AND Action = " + JCompanyActions.JoinAllSheets.GetHashCode() + " ORDER BY IncDate Desc ";
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
        public static DataTable GetBreakHistory(int CompanyCode)
        {
            string sql = @" SELECT Code, (Select Fa_Date From StaticDates Where En_Date =  IncDate) Date , BreakCount , Comment
            ,(Select UserName From Users Where Code = UserCode) UserName  FROM [ShareIncreaseCourse] Where CompanyCode=" + CompanyCode + " AND Action = " + JCompanyActions.BreakSheets.GetHashCode() + " ORDER BY IncDate Desc ";
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
