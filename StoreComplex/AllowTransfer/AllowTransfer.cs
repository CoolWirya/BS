using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreComplex
{
    public class JSCAllowTransfer: JStoreComplex
    {
        #region Properties
        public int Code { get; set; }
        /// <summary>
        /// کد قرارداد
        /// </summary>
        public int ContractCode { get; set; }
        /// <summary>
        ///ش  سریال 
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
        #endregion

        public JSCAllowTransfer(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }
        public int Insert()
        {
            JSCAllowTransferTable table = new JSCAllowTransferTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JSCAllowTransfer.Insert"))
                {

                    table.SetValueProperty(this);
                    int Code = table.Insert();
                    if (Code > 0)
                    {
                        this.Code = Code;
                        //  Nodes.DataTable.Merge(JSCAllowTransfers.GetDatatable(Code));
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
            JSCAllowTransferTable table = new JSCAllowTransferTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JSCAllowTransfer.Delete"))
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

            JSCAllowTransferTable table = new JSCAllowTransferTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JSCAllowTransfer.Update"))
                {
                    table.SetValueProperty(this);
                    if (table.Update())
                    {
                        Histroy.Save(this, table, table.Code, "Update");
                        // Nodes.Refreshdata(Nodes.CurrentNode, JSCAllowTransfers.GetDatatable(Code).Rows[0]);
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
                DB.setQuery("SELECT * FROM SCAllowTransfer WHERE Code=" + pCode.ToString());
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

        public void ShowDialog(int ContractCode, int AllowTransferCode)
        {
            JSCAllowTransferForm form = new JSCAllowTransferForm(ContractCode, AllowTransferCode);
            form.ShowDialog();
        }

        public void ShowList(int ContractCode)
        {
            //JAllowTransferListForm form = new JAllowTransferListForm(ContractCode);
            //form.ShowDialog();
        }
    }
}
