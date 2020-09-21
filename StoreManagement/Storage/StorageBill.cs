using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace StoreManagement
{
    public class JStorageBill : JSystem
    {
        #region constructor
        public JStorageBill()
        {

        }
        public JStorageBill(int pCode)
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
        ///   شماره رسید
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        ///    
        /// </summary>
        public decimal Discount { get; set; }
        /// <summary>
        ///   تاریخ
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        ///  کد انبار
        /// </summary>
        public int StorageCode { get; set; }
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
                string Query = "select * from StoreStorageBill where Code=" + pCode + "";
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
            JStorageBillTable JPOT = new JStorageBillTable();
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
                JStorageBillTable JPOT = new JStorageBillTable();
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
                JStorageBillTable JPOT = new JStorageBillTable();
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
            JStorageBillTable JPOT = new JStorageBillTable();
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

        public bool Save(int pBillGoodsCode, DataTable pStorageList, JDataBase pDb)
        {
            JStorageBill JPOB = new JStorageBill(0);
            try
            {
                foreach (DataRow Row in pStorageList.Rows)
                {
                    /// در صورتی که سطر اضافه شده باشد
                    if (Row.RowState == DataRowState.Added)
                    {
                        if (Convert.ToInt32(Row["Number"]) < 0)
                            if (Find(Row["Number"].ToString(), ""))
                            {
                                JMessages.Error(" شماره رسید انبار تکراری است ", "");
                                return false;
                            }
                        BillGoodsCode = pBillGoodsCode;
                        Number = Convert.ToInt32(Row["Number"]);
                        Date = Convert.ToDateTime(JDateTime.GregorianDate(Row["Date"].ToString()));
                        Discount = Convert.ToDecimal(Row["Discount"]);
                        StorageCode = Convert.ToInt32(Row["StorageCode"].ToString());
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
                        if (Convert.ToInt32(Row["Number"]) < 0)
                            if (Find(Row["Number"].ToString(), ""))
                            {
                                JMessages.Error(" شماره رسید انبار تکراری است ", "");
                                return false;
                            }
                        Code = (int)Row["Code"];
                        BillGoodsCode = pBillGoodsCode;
                        Number = Convert.ToInt32(Row["Number"]);
                        Date = Convert.ToDateTime(JDateTime.GregorianDate(Row["Date"].ToString()));
                        Discount = Convert.ToDecimal(Row["Discount"]);
                        StorageCode = Convert.ToInt32(Row["StorageCode"].ToString());
                        Description = Row["Description"].ToString();
                        if (!Update(pDb))
                            return false;
                    }
                }
                pStorageList.AcceptChanges();
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
                string Where = " Where BillGoodsCode=" + pBillGoodsCode;
                Db.setQuery(@" Select 
Code,Number,
(select Fa_Date from StaticDates where En_Date=Cast([date] as date)) 'Date',Discount,StorageCode,Description 
 From StoreStorageBill " + Where);
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

        public static bool Find(string pNumber, string pTankhah)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(@" Select * From StoreBillGoods B inner join StoreStorageBill S on B.Code=S.BillGoodsCode 
 Where S.Number=" + pNumber + " And Year(Regdate)=Year(GETDATE()) ");// B.TankhahCode=" + pTankhah);
                return Db.Query_DataTable().Rows.Count > 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false; ;
            }
            finally
            {
                Db.Dispose();
            }
        }
    }

    class JStorageBillTable : JTable
    {
        public JStorageBillTable()
            : base("StoreStorageBill")
        {
        }
        /// <summary>
        ///   کد فاکتور
        /// </summary>
        public int BillGoodsCode;
        /// <summary>
        ///   شماره رسید
        /// </summary>
        public int Number;
        /// <summary>
        ///   تاریخ
        /// </summary>
        public DateTime Date;
        /// <summary>
        ///    
        /// </summary>
        public decimal Discount;
        /// <summary>
        ///  کد انبار
        /// </summary>
        public int StorageCode;
        /// <summary>
        ///   توضیحات
        /// </summary>
        public string Description;
    }
}
