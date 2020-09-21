using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace StoreManagement
{
    public class JBillListGoods : JSystem
    {
        #region constructor
        public JBillListGoods()
        {
        }
        public JBillListGoods(int pCode)
        {
            //GetData(pCode);
        }
        #endregion

        #region property
        /// <summary>
        ///  
        /// </summary>
        public int Code { set; get; }
        /// <summary>
        ///  کد صورتحساب کالا
        /// </summary>
        public int BillGoodsCode { set; get; }
        /// <summary>
        ///  
        /// </summary>
        public string ClassName { set; get; }
        /// <summary>
        ///  کد کالا
        /// </summary>
        public int ObjectCode { set; get; }
        /// <summary>
        ///  تعداد
        /// </summary>
        public decimal Count { set; get; }
        /// <summary>
        ///  قیمت
        /// </summary>
        public decimal Price { set; get; }
        /// <summary>
        ///  مالیات  
        /// </summary>
        public decimal Tax { set; get; }
        /// <summary>
        ///  عوارض
        /// </summary>
        public decimal Duty { set; get; }

        #endregion

        #region Method
        public int insert(JDataBase pDb)
        {
            JBillListGoodsTable JPOT = new JBillListGoodsTable();
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
                JBillListGoodsTable JPOT = new JBillListGoodsTable();
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
                JBillListGoodsTable JPOT = new JBillListGoodsTable();
                if (JPOT.DeleteManual(" BillGoodsCode= "+pBillGoodsCode , PDb))
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
            JBillListGoodsTable JPOT = new JBillListGoodsTable();
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

        public bool _Insert = false;

        public bool Save(int pBillGoodsCode, DataTable pGoodsList, JDataBase pDb)
        {
            JBillListGoods JPOB = new JBillListGoods(0);
            try
            {
                foreach (DataRow Row in pGoodsList.Rows)
                {
                    /// در صورتی که سطر اضافه شده باشد
                    if ((Row.RowState == DataRowState.Added) || ((Row.RowState == DataRowState.Modified) && (_Insert)))
                    {
                        BillGoodsCode = pBillGoodsCode;
                        ClassName = Row["ClassName"].ToString();
                        ObjectCode = Convert.ToInt32(Row["ObjectCode"]);
                        Count = Convert.ToDecimal(Row["Count"]);
                        Price = Convert.ToDecimal(Row["Price"]);
                        Tax = Convert.ToDecimal(Row["Tax"]);
                        Duty = Convert.ToDecimal(Row["Duty"]);
                        Code = insert(pDb);
                        if (Code <= 0)
                            return false;

                        //Add Relation
                        JRelation tmpJRelation = new JRelation();
                        tmpJRelation.PrimaryClassName = ClassName;
                        tmpJRelation.PrimaryObjectCode = ObjectCode;
                        tmpJRelation.ForeignClassName = "StoreManagement.JBillListGoods";
                        tmpJRelation.ForeignObjectCode = Code;
                        tmpJRelation.Comment = "برای این کالا فاکتور ثبت شده است";
                        if (!tmpJRelation.Insert(pDb))
                            return false;
                    }
                    /// در صورتی که سطر حذف شده باشد
                    else if ((Row.RowState == DataRowState.Deleted) && (_Insert == false))
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

                        //Delete Relation
                        JRelation tmpJRelation = new JRelation();
                        if (!tmpJRelation.CheckRelation("StoreManagement.JBillListGoods", Code, pDb))
                            if (!tmpJRelation.Delete("StoreManagement.JBillListGoods", Code, pDb))
                                return false;

                    }
                    /// در صورتی که سطر ویرایش شده باشد
                    else if ((Row.RowState == DataRowState.Modified) && (_Insert == false))
                    {
                        Code = (int)Row["Code"];
                        BillGoodsCode = pBillGoodsCode;
                        ClassName = Row["ClassName"].ToString();
                        ObjectCode = Convert.ToInt32(Row["ObjectCode"]);
                        Count = Convert.ToDecimal(Row["Count"]);
                        Price = Convert.ToDecimal(Row["Price"]);
                        Tax = Convert.ToDecimal(Row["Tax"]);
                        Duty = Convert.ToDecimal(Row["Duty"]);
                        if (!Update(pDb))
                            return false;
                    }
                }
                pGoodsList.AcceptChanges();
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
case classname when 'StoreManagement.JGoods' then 
(Select Name From StoreGoods Where Code=ObjectCode)  
when 'StoreManagement.JServices' then (Select Name From StoreServices Where Code=ObjectCode)  
end 'Name',
BillGoodsCode,
ClassName,
ObjectCode,
Count,
(Select (Select Name From Subdefine Where code=Measure) from StoreGoods Where Code=ObjectCode) Measure,
Price,(Count * Price) 'TotalPrice',Tax,Duty, (Tax+Duty) SumTaxDutyList ,
case (select discount From StoreBillGoods Where Code=StoreBillGoodsList.BillGoodsCode)
When 0 then 0
else
cast((select discount From StoreBillGoods Where Code=StoreBillGoodsList.BillGoodsCode)/(select Count(L.Code) From StoreBillGoods B inner join StoreBillGoodsList L on B.Code=L.BillGoodsCode where B.Code=StoreBillGoodsList.BillGoodsCode) as decimal(18,2))
end DiscountList,

case (select discount From StoreBillGoods Where Code=StoreBillGoodsList.BillGoodsCode)
When 0 then (Count * Price)
else
(Count * Price) - cast((select discount From StoreBillGoods Where Code=StoreBillGoodsList.BillGoodsCode)/(select Count(L.Code) From StoreBillGoods B inner join StoreBillGoodsList L on B.Code=L.BillGoodsCode where B.Code=StoreBillGoodsList.BillGoodsCode) as decimal(18,2))
end TotalPriceDiscount,

case (select discount From StoreBillGoods Where Code=StoreBillGoodsList.BillGoodsCode)
When 0 then (Count * Price+Tax+Duty)
else
(Count * Price+Tax+Duty) - cast((select discount From StoreBillGoods Where Code=StoreBillGoodsList.BillGoodsCode)/(select Count(L.Code) From StoreBillGoods B inner join StoreBillGoodsList L on B.Code=L.BillGoodsCode where B.Code=StoreBillGoodsList.BillGoodsCode) as decimal(18,2))
end TotalPriceTaxDuty 

  From StoreBillGoodsList " + Where);
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

    public class JBillListGoodsTable : JTable
    {
        public JBillListGoodsTable()
            : base("StoreBillGoodsList")
        {
        }
        /// <summary>
        ///  کد صورتحساب کالا
        /// </summary>
        public int BillGoodsCode;
        public string ClassName;
        /// <summary>
        ///  کد کالا
        /// </summary>
        public int ObjectCode;
        /// <summary>
        ///  تعداد
        /// </summary>
        public decimal Count;
        /// <summary>
        ///  قیمت
        /// </summary>
        public decimal Price;
        /// <summary>
        ///  مالیات  
        /// </summary>
        public decimal Tax ;
        /// <summary>
        ///  عوارض
        /// </summary>
        public decimal Duty;
    }
}
