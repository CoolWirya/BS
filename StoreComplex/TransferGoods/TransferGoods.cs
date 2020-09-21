using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace StoreComplex
{
    public class JSCTransferGood :JStoreComplex
    {
    #region Properties
        public int Code { get; set; }
        /// <summary>
        /// کد حواله
        /// </summary>
        public int TransferCode { get; set; }
        /// <summary>
        /// کد کالا
        /// </summary>
        public int RecieptGoodCode { get; set; }
        /// <summary>
        /// مقدار
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// شرح
        /// </summary>
        public string Description { get; set; }
        
        #endregion

        public JSCTransferGood(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }
        public int Insert()
        {
            JSCTransferGoodsTable table = new JSCTransferGoodsTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JSCTransferGood.Insert"))
                {

                    table.SetValueProperty(this);
                    int Code = table.Insert();
                    if (Code > 0)
                    {
                        this.Code = Code;
                        //  Nodes.DataTable.Merge(JSCTransfers.GetDatatable(Code));
                        Histroy.Save(this, table, table.Code, "Insert");
                        return Code;
                    }
                    else
                        return 0;
                }
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
                table.Dispose();
            }
        }

        public bool Delete()
        {
            JSCTransferGoodsTable table = new JSCTransferGoodsTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JSCTransferGood.Delete"))
                {
                    table.SetValueProperty(this);
                    if (table.Delete())
                    {
                        Histroy.Save(this, table, table.Code, "Delete");
                        //Nodes.Delete(Nodes.CurrentNode);
                        return true;
                    }
                    else
                        return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                table.Dispose();
            }
        }

        public bool Update()
        {

            JSCTransferGoodsTable table = new JSCTransferGoodsTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JSCTransferGood.Update"))
                {
                    table.SetValueProperty(this);
                    if (table.Update())
                    {
                        Histroy.Save(this, table, table.Code, "Update");
                        // Nodes.Refreshdata(Nodes.CurrentNode, JSCTransfers.GetDatatable(Code).Rows[0]);
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                table.Dispose();
            }
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM SCTransferGoods WHERE Code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }

    }

    public class JSCTransferGoods : JSystem
    {
        public static DataTable GetDatatable(int pTransferCode)
        {
            string SelectQouery = @" Select TG.Code, G.Name , TG.Description , TG.Amount 
            ,(SELECT Name From subdefine WHERE Code = G.Measure ) Measure 
	            from SCTransferGoods TG
	            INNER Join SCReceiptGoods RG ON TG.RecieptGoodCode = RG.Code 
	            INNER JOIN StoreGoods G ON RG.GoodCode = G.Code  ";
            string where = " Where 1=1 ";
            //if (pTransferCode > 0)
                where = where + " And TransferCode =" + pTransferCode;
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(SelectQouery + where);
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

        /// <summary>
        /// لیست کالاها جهت استفاده در حواله انبار
        /// </summary>
        /// <param name="pContractCode"></param>
        /// <returns></returns>
        public static DataTable GetExistGoods(int pContractCode)
        {
            string SelectQouery = @" Select * from
                    (Select  Distinct StoreGoods .Name GoodName, RG.Description 
                    ,RG.Amount ,RG.Amount - (Select ISNULL ( SUM(Amount), 0) FROM SCTransferGoods WHERE SCTransferGoods.RecieptGoodCode   = RG.Code ) as Exist  
                    ,(Select Name FROM subdefine WHERE Code = StoreGoods .Measure ) Measure 
                    ,(Select Fa_Date FROM StaticDates WHERE En_Date =CONVERT(Date, R.Date))  + ' - ' +  Left(CONVERT (Time , R.Date), 5) ReceiptRegisterDate 
                    ,R.Date
                    ,R.Serial ReceiptSerial
                    ,RG.Cost , R.ContractCode , RG.GoodCode , RG.Code from SCReceiptGoods RG
	                    INNER Join SCReceipt R ON R.Code = RG.ReceiptCode 
	                    LEFT Join SCTransferGoods TG ON RG.Code = TG .RecieptGoodCode 
	                    INNER Join StoreGoods ON RG.GoodCode = StoreGoods.Code) A
	                    WHERE  A.Exist >0
	                and ContractCode =  " + pContractCode;
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(SelectQouery);
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
