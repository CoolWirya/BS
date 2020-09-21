using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace StoreManagement
{
    public class JPrepayment : JSystem
    {
        #region constructor
        public JPrepayment()
        {

        }
        public JPrepayment(int pCode)
        {
            GetData(pCode);
        }
        #endregion

        #region Property
        /// <summary>
        /// کد کالا  
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        ///   کد فاکتور
        /// </summary>
        public int BillGoodsCode { get; set; }
        /// <summary>
        ///   قیمت
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        ///   تاریخ
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        ///   توضیحات
        /// </summary>
        public string Description { get; set; }
        #endregion

        public bool GetData(int pCode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select * from StorePrepayment where Code=" + pCode + "";
                Db.setQuery(Query);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                Db.Dispose();
            }
        }

        #region Method
        public int insert(JDataBase pDb)
        {
            JPrepaymentTable JPOT = new JPrepaymentTable();
            try
            {
                int Code;
                JPOT.SetValueProperty(this);
                Code = JPOT.Insert(pDb);
                if (Code > 0)
                    return Code;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                JPOT.Dispose();
            }
        }

        public bool Delete(JDataBase PDb)
        {
            try
            {
                JPrepaymentTable JPOT = new JPrepaymentTable();
                JPOT.SetValueProperty(this);
                if (JPOT.Delete(PDb) || JPOT.GetDeleteCount() == 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        public bool Delete(int pBillGoodsCode, JDataBase PDb)
        {
            try
            {
                JPrepaymentTable JPOT = new JPrepaymentTable();
                if (JPOT.DeleteManual(" BillGoodsCode= " + pBillGoodsCode, PDb))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        public bool Update(JDataBase pDb)
        {
            JPrepaymentTable JPOT = new JPrepaymentTable();
            try
            {
                JPOT.SetValueProperty(this);
                return JPOT.Update(pDb);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                JPOT.Dispose();
            }
        }

        public bool Save(int pBillGoodsCode, DataTable pPrepaymentList, JDataBase pDb)
        {
            JPrepayment JPOB = new JPrepayment(0);
            try
            {
                foreach (DataRow Row in pPrepaymentList.Rows)
                {
                    /// در صورتی که سطر اضافه شده باشد
                    if (Row.RowState == DataRowState.Added)
                    {
                        BillGoodsCode = pBillGoodsCode;
                        Date = Convert.ToDateTime(JDateTime.GregorianDate(Row["Date"].ToString()));
                        Price = Convert.ToDecimal(Row["Price"]);
                        Description = Row["Description"].ToString();
                        if (insert(pDb) <= 0)
                            return false;
                    }
                    /// در صورتی که سطر حذف شده باشد
                    if (Row.RowState == DataRowState.Deleted)
                    {
                        Row.RejectChanges();
                        if (Row["Code"] != DBNull.Value)
                        {
                            Code = (int)Row["Code"];
                            if (!(Delete(pDb)))
                                return false;
                            Row.Delete();
                        }
                        else
                            Row.Delete();
                    }
                    /// در صورتی که سطر ویرایش شده باشد
                    if (Row.RowState == DataRowState.Modified)
                    {
                        Code = (int)Row["Code"];
                        BillGoodsCode = pBillGoodsCode;
                        Date = Convert.ToDateTime(JDateTime.GregorianDate(Row["Date"].ToString()));
                        Price = Convert.ToDecimal(Row["Price"]);
                        Description = Row["Description"].ToString();
                        if (!Update(pDb))
                            return false;
                    }
                }
                pPrepaymentList.AcceptChanges();
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }
        #endregion

        public static DataTable GetDataTable(int pBillGoodsCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                string Where = "";
                if (pBillGoodsCode != 0)
                    Where = " Where BillGoodsCode=" + pBillGoodsCode;
                Db.setQuery(@" Select Code,
(select Fa_Date from StaticDates where En_Date=Cast([date] as date)) 'Date',
Price,Description  From StorePrepayment " + Where);
                return Db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }

    }
}
