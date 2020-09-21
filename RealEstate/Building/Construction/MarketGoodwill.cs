using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;

namespace RealEstate
{
    public class JMarketGoodwill : JSystem
    {
        
        public JMarketGoodwill()
        {
        }

        public int Code { get; set; }
        public int MarketCode { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public float IncreasePercent { get; set; }

      

        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>
        public bool Save (DataTable GoodwillTable, int MarketCode, JDataBase db)
        {
            JMarketGoodwillTable PDT = new JMarketGoodwillTable();
            try
            {
                if (GoodwillTable != null)
                    foreach (DataRow dr in GoodwillTable.Rows)
                    {
                        if (dr.RowState == DataRowState.Added)
                        {
                            PDT.MarketCode = MarketCode;
                            PDT.FromDate = Convert.ToDateTime(dr[JMarketGoodwillEnum.FromDate.ToString()]);
                            PDT.ToDate = Convert.ToDateTime(dr[JMarketGoodwillEnum.ToDate.ToString()]);
                            PDT.IncreasePercent = Convert.ToSingle(dr[JMarketGoodwillEnum.IncreasePercent.ToString()]);
                            if (PDT.Insert(db) < 1)
                                return false;

                        }
                        else if (dr.RowState == DataRowState.Deleted)
                        {
                            dr.RejectChanges();
                            PDT.Delete(true, " Code = " + (dr[JMarketGoodwillEnum.Code.ToString()]).ToString(), db);
                            dr.Delete();
                        }
                    }
                GoodwillTable.AcceptChanges();
                return true;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
            }
        }

        public static  DataTable GetDataByMarketCode(int pMarketCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                /// تاریخ شمسی و میلادی را با هم انتخاب میکنیم تا بتوانیم در فیلد میلادی درج کنیم
                JFreeClass.RUN(new JAction("GetDocumant", "ClassLibrary.JMainFrame.Check"));
                DB.setQuery(@"SELECT [Code], " + JMarketGoodwillEnum.FromDate.ToString() +
                    ", " + JDataBase.SQLMiladiToShamsi(JMarketGoodwillEnum.FromDate.ToString(), "FromDateF") + ", " +
                     JMarketGoodwillEnum.ToDate.ToString() + ", " +
                     JDataBase.SQLMiladiToShamsi(JMarketGoodwillEnum.ToDate.ToString(), "ToDateF") + ", " +
                     JMarketGoodwillEnum.IncreasePercent + "  FROM " + JRETableNames.MarketGoodwill +
                    " WHERE " + JMarketGoodwillEnum.MarketCode + "=" + pMarketCode.ToString());
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        /// <summary>
        /// محاسبه اجاره صلح سرقفلی بر اساس اجاره اولیه و درصدهای افزایش وارد شده در قسمت بازارها و مجتمع ها
        /// </summary>
        /// <param name="pInitialRent"></param>
        /// <param name="pDate"></param>
        /// <returns></returns>
        public static decimal CalcRent(int pMarketCode, decimal pInitialRent, DateTime pDate)
        {
            DateTime tmpDate = pDate; //JGlobal.MainFrame.GetDBO().GetDateTime();
            DataTable goodwillInc = GetDataByMarketCode(pMarketCode);
            decimal rent = pInitialRent;
            foreach (DataRow row in goodwillInc.Rows)
            {
                /// در صورتی که تاریخ بعد از تاریخ این ردیف است
                if (tmpDate >= (DateTime)row[JMarketGoodwillEnum.ToDate.ToString()])
                    rent = rent + rent * (Convert.ToDecimal(row[JMarketGoodwillEnum.IncreasePercent.ToString()]) / 100);
                if (tmpDate >= (DateTime)row[JMarketGoodwillEnum.FromDate.ToString()] && tmpDate <= (DateTime)row[JMarketGoodwillEnum.ToDate.ToString()])
                    rent = rent + rent * (Convert.ToDecimal(row[JMarketGoodwillEnum.IncreasePercent.ToString()]) / 100);
            }
            return Math.Round(RoundRent(rent),0);
        }

        public static DateTime CalcRentDate(int pMarketCode, DateTime pDate)
        {
            DateTime tmpDate = pDate;
            DataTable goodwillInc = GetDataByMarketCode(pMarketCode);
            foreach (DataRow row in goodwillInc.Rows)
            {
                /// در صورتی که تاریخ بعد از تاریخ این ردیف است
                if (pDate >= (DateTime)row[JMarketGoodwillEnum.ToDate.ToString()])
                    tmpDate = (DateTime)row[JMarketGoodwillEnum.FromDate.ToString()];
                if (pDate >= (DateTime)row[JMarketGoodwillEnum.FromDate.ToString()] && pDate <= (DateTime)row[JMarketGoodwillEnum.ToDate.ToString()])
                    tmpDate = (DateTime)row[JMarketGoodwillEnum.FromDate.ToString()];
            }
            return tmpDate;
        }
        private static decimal RoundRent(decimal rent)
        {
            decimal rem = rent % 1000;
            if (rem >= 500)
                rent = rent + (1000 - rem);
            else
                rent = rent - rem;
            return rent;
        }
    }
}
