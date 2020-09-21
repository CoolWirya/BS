using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace StoreComplex
{
    /// <summary>
    /// تخلیه انبار اختصاصی
    /// </summary>
    public class JPrivateTransfer :JStoreComplex
    {
        #region Properties
        public int Code { get; set; }
        /// <summary>
        /// کد اجاره انبار اختصاصی که در رسید ثبت شده است
        /// </summary>
        public int PrivateStorageCode { get; set; }
        /// <summary>
        /// کد حواله
        /// </summary>
        public int TransferCode { get; set; }
        /// <summary>
        /// تعداد باکس تخلیه شده
        /// </summary>
        public decimal BoxCount { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
        
        #endregion 

        public JPrivateTransfer(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM SCPrivateTransfer WHERE Code=" + pCode.ToString());
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

        public int Insert()
        {
            JPrivateTransferTable table = new JPrivateTransferTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JPrivateTransfer.Insert"))
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
            JPrivateTransferTable table = new JPrivateTransferTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JPrivateTransfer.Delete"))
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

            JPrivateTransferTable table = new JPrivateTransferTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JPrivateTransfer.Update"))
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

    }

    public class JPrivateTransfers : JSystem
    {
        public static DataTable GetDatatable(int pTransferCode)
        {
            string SelectQouery = @" 
                    Select PT.Code , S.Title StorageTitle,  PT.BoxCount  , Pt.Description  
                     from SCPrivateTransfer PT 	            
                     INNER JOIN SCPrivateStorage PS ON PT.PrivateStorageCode = PS.Code  
                     INNER JOIN SCStorage S ON PS.StorageCode = S.Code   ";
            string where = " Where 1=1 ";
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
    }

}
