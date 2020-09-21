using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace StoreComplex
{
    public class JOtherService : JStoreComplex
    {
        #region Properties
        public int Code { get; set; }
        /// <summary>
        /// رسید/حواله/مجوز
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// کد  رسید/حواله/مجوز
        /// </summary>
        public int ObjectCode { get; set; }
       /// <summary>
       /// نوع سرویس
       /// </summary>
        public int ServiceType { get; set; }
        /// <summary>
        /// سریال  رسید/حواله/مجوز
        /// </summary>
        public string Serial { get; set; }
        /// <summary>
        /// تاریخ و ساعت
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// محل
        /// </summary>
        public int Location { get; set; }
        /// <summary>
        /// تعدا نیرو
        /// </summary>
        public int WorkerCount{ get; set; }
        /// <summary>
        /// دقیقه
        /// </summary>
        public int WorkerDuration{ get; set; }
        /// <summary>
        /// هزینه سرویس
        /// </summary>
        public decimal ServiceCost { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// کد قرارداد
        /// </summary>
        public int ContractCode { get; set; }
        #endregion Properties

        public JOtherService()
        {
        }
        public JOtherService(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }
        public int Insert()
        {
            JOtherServiceTable table = new JOtherServiceTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JOtherService.Insert"))
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
            JOtherServiceTable table = new JOtherServiceTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JOtherService.Delete"))
                {
                    table.SetValueProperty(this);
                    if (table.Delete())
                    {
                        Histroy.Save(this, table, table.Code, "Delete");
                      //  Nodes.Delete(Nodes.CurrentNode);
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

            JOtherServiceTable table = new JOtherServiceTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JOtherService.Update"))
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
                DB.setQuery("SELECT * FROM SCService WHERE Code=" + pCode.ToString());
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

    public class JOtherServices : JSystem
    {
        public static DataTable GetDatatable(int pCode)
        {
            string SelectQouery = @" SELECT * FROM SCService Where 1=1 ";
            string where = " ";
            if (pCode > 0)
                where = where + " And Code=" + pCode;
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
        public static DataTable GetDatatable(int pCode, string ClassName, int ObjectCode)
        {
            string SelectQouery = @" Select Code
                ,(Select Fa_Date From StaticDates WHERE En_Date = Date ) Date
                ,(Select name From subdefine Where Code = ServiceType ) ServiceType
                , Description , ServiceCost   from SCService   WHERE 1 = 1  ";
            string where = "";
            if (!string.IsNullOrEmpty(ClassName))
                where += where + " AND ClassName = " + JDataBase.Quote(ClassName);
            //if (ObjectCode>0)
                where += where + " AND ObjectCode = " + ObjectCode;
            if (pCode > 0)
                where = where + " And Code=" + pCode;
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
