using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace StoreComplex
{
    public enum JStoreType
    {
        Counting = 1,
        Box = 2,
        Meter = 3,
        Ton = 4
    }
    public class JSCReceipt : JStoreComplex
    {
        #region Properties
        public int Code { get; set; }
        /// <summary>
        /// کد قرارداد
        /// </summary>
        public int ContractCode { get; set; }
        /// <summary>
        ///ش  سریال رسید
        /// </summary>
        public string Serial { get; set; }
        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// نام راننده
        /// </summary>
        public string DriverName { get; set; }
        /// <summary>
        /// نوع خودرو
        /// </summary>
        public int DriveType { get; set; }
        /// <summary>
        /// ش پلاک
        /// </summary>
        public string PelakNo { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// نوع انبارداری
        /// </summary>
        public int StoreType { get; set; }
        /// <summary>
        /// تائید نهایی شده
        /// </summary>
        public bool Closed { get; set; }
        /// <summary>
        /// برای سهولت ارتباط بین اشخاص و خدمات ارائه شده، کد شخص در این قسمت ثبت میشود
        /// </summary>
        public int PCode{ get; set; }

        #endregion

        public JSCReceipt(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }

        public int Insert()
        {
            JSCReceiptTable table = new JSCReceiptTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JSCReceipt.Insert"))
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
            JSCReceiptTable table = new JSCReceiptTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JSCReceipt.Delete"))
                {
                    table.SetValueProperty(this);
                    if (table.Delete())
                    {
                        Histroy.Save(this, table, table.Code, "Delete");
                        Nodes.Delete(Nodes.CurrentNode);
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

            JSCReceiptTable table = new JSCReceiptTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JSCReceipt.Update"))
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
                DB.setQuery("SELECT * FROM SCReceipt WHERE Code=" + pCode.ToString());
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

        public void ShowDialog(int pPCode, int ContractCode, int ReceiptCode)
        {
            JSCReceiptForm form = new JSCReceiptForm(pPCode, ContractCode, ReceiptCode);
            form.ShowDialog();
        }

        public void ShowList(int ContractCode)
        {
            JReceiptListForm form = new JReceiptListForm(ContractCode);
            form.ShowDialog();
        }
    }

    public class JSCReceipts : JSystem
    {
        public static DataTable GetDatatable(int pCode, int pContractCode)
        {
            string SelectQouery = @" SELECT Code
 ,(Select Fa_Date From StaticDates Where En_Date = CONVERT (Date, [Date]) ) Date
  , Serial ,LEFT( CONVERT (Time, [Date]), 5) Time,  DriverName , Description, PCode   FROM SCReceipt ";
            string where = " Where 1=1 ";
            if (pCode > 0)
                where = where + " And Code=" + pCode;
            if (pContractCode > 0)
                where = where + " And ContractCode=" + pContractCode;

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

        public static string GetMaxSerial()
        {
            string SelectQouery = @" Begin try  
                    Select Max(CONVERT (bigint , Serial ))+1 From SCReceipt  
                    End try 
                    begin catch 
                    select '0'
                    end catch ";
                     
            
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(SelectQouery);
                if (Db.Query_DataTable().Rows.Count > 0 && Db.Query_DataTable().Rows[0][0] != null)
                    return Db.Query_DataTable().Rows[0][0].ToString();
                else
                    return "";

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
