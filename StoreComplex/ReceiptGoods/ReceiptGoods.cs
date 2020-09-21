using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace StoreComplex
{
    public class JSCReceiptGood : JStoreComplex
    {
        #region Properties
        public int Code { get; set; }
        /// <summary>
        /// کد رسید
        /// </summary>
        public int ReceiptCode { get; set; }
        /// <summary>
        /// کد کالا
        /// </summary>
        public int GoodCode { get; set; }
        /// <summary>
        /// مقدار
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// شرح
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// هزینه
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// نوع انبارداری
        /// </summary>
        public int StoreType { get; set; }
        #endregion

        public JSCReceiptGood(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }

        public int Insert()
        {
            JSCReceiptGoodsTable table = new JSCReceiptGoodsTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JSCReceiptGood.Insert"))
                {

                    table.SetValueProperty(this);
                    int Code = table.Insert();
                    if (Code > 0)
                    {
                        this.Code = Code;
                        //  Nodes.DataTable.Merge(JSCReceipts.GetDatatable(Code));
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
            JSCReceiptGoodsTable table = new JSCReceiptGoodsTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JSCReceiptGood.Delete"))
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

            JSCReceiptGoodsTable table = new JSCReceiptGoodsTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JSCReceiptGood.Update"))
                {
                    table.SetValueProperty(this);
                    if (table.Update())
                    {
                        Histroy.Save(this, table, table.Code, "Update");
                        // Nodes.Refreshdata(Nodes.CurrentNode, JSCReceipts.GetDatatable(Code).Rows[0]);
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
                DB.setQuery("SELECT * FROM SCReceiptGoods WHERE Code=" + pCode.ToString());
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

    public class JSCReceiptGoods : JSystem
    {
        public static DataTable GetDataTable(int pReceiptCode)
        {
            string SelectQouery = @" SELECT R.Code, G.Name , Amount, (Select name FROM subdefine Where Code = G.Measure) Measure
                    , R.DEscription, R.Cost  FROM SCReceiptGoods R
                    Inner Join StoreGoods G On R.GoodCode  = G.Code  ";
            string where = " Where 1=1 ";
            //if (pReceiptCode > 0)
                where = where + " And ReceiptCode =" + pReceiptCode;
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
     
    }
}
