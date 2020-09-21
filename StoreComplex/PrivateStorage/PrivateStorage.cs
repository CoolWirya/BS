using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace StoreComplex
{
    public class JPrivateStorage :JStoreComplex
    {
        #region Properties
        public int Code { get; set; }
        /// <summary>
        /// محل اجاره
        /// </summary>
        public int StorageCode { get; set; }
        /// <summary>
        /// کد رسید
        /// </summary>
        public int ReceiptCode { get; set; }
        /// <summary>
        /// تعداد باکس مورد اجاره
        /// </summary>
        public decimal BoxCount { get; set; }
        /// <summary>
        /// مبلغ اجاره
        /// </summary>
        public decimal Cost{ get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
        #endregion Properties

        public JPrivateStorage(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }

        public int Insert()
        {
            JPrivateStorageTable table = new JPrivateStorageTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JPrivateStorage.Insert"))
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
            JPrivateStorageTable table = new JPrivateStorageTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JPrivateStorage.Delete"))
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

            JPrivateStorageTable table = new JPrivateStorageTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JPrivateStorage.Update"))
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
                DB.setQuery("SELECT * FROM SCPrivateStorage WHERE Code=" + pCode.ToString());
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

    public class JPrivateStorages : JSystem
    {
        public static DataTable GetDataTable(int pReceiptCode)
        {
            string SelectQouery = @"  SELECT SCPrivateStorage.Code, SCStorage.Title , SCPrivateStorage.BoxCount 
 , Cost, SCPrivateStorage.Description  FROM SCPrivateStorage 
 Inner Join SCStorage On SCStorage.Code = SCPrivateStorage.StorageCode ";
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

        /// <summary>
        /// لیست انبارهای مورد اجاره جهت استفاده در حواله انبار
        /// </summary>
        /// <param name="pContractCode"></param>
        /// <returns></returns>
        public static DataTable GetExistStorages(int pContractCode)
        {
            string SelectQouery = @" Select * from 
                    (Select PS.Code , Sg.Title StorageTitle
                    , PS.BoxCount - (Select ISNULL(SUM(BoxCount), 0) FROM SCPrivateTransfer WHERE SCPrivateTransfer.PrivateStorageCode = PS.Code ) AS ExistBoxCount
                    , R.Date ,(Select Fa_Date FROM StaticDates WHERE En_Date = Convert(Date, R.Date )) AS ReceiptDate
                    , R.Serial, R.ContractCode   from SCPrivateStorage PS
	                    INNER JOIN SCStorage Sg ON PS.StorageCode = Sg.Code 
	                    INNER JOIN SCReceipt R ON PS.ReceiptCode = R.Code ) A 
	                    WHERE A.ExistBoxCount >0
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
