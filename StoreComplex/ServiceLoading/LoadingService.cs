using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace StoreComplex
{
    public enum JLoadingServiceType
    {
        All = 0,
        Loading = 1,
        Unloading = 2
    }
    public class JLoadingService : JStoreComplex
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
        /// تخلیه/بارگیری
        /// </summary>
        public int Type { get; set; }
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
        public decimal Cost { get; set; }
        /// <summary>
        /// کد قرارداد
        /// </summary>
        public int ContractCode{ get; set; }

        #endregion Properties

        public JLoadingService()
        {
        }
        public JLoadingService(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }
        public int Insert()
        {
            JLoadingServiceTable table = new JLoadingServiceTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JLoadingService.Insert"))
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
            JLoadingServiceTable table = new JLoadingServiceTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JLoadingService.Delete"))
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

            JLoadingServiceTable table = new JLoadingServiceTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JLoadingService.Update"))
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
                DB.setQuery("SELECT * FROM SCLoadingService WHERE Code=" + pCode.ToString());
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

    public class JLoadingServices : JSystem
    {
        public static DataTable GetDatatable(int pCode)
        {
            string SelectQouery = @" SELECT * FROM SCLoadingService Where 1=1 ";
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
        public static DataTable GetDatatable(int pCode, string ClassName, int ObjectCode, JLoadingServiceType Type)
        {
            string SelectQouery = @" SELECT Code, 
                 (Select Fa_Date From StaticDates Where En_Date =CONVERT ( Date ,[Date])) Date
                 ,Left(Convert(Time , [Date]) ,5) Time, WorkerCount , WorkerDuration ,  Cost  FROM SCLoadingService Where 1=1 ";
            string where = " ";
            if (!string.IsNullOrEmpty(ClassName))
                where += where + " AND ClassName = " + JDataBase.Quote(ClassName);
            //if (ObjectCode>0)
                where += where + " AND ObjectCode = " + ObjectCode;
            if (Type != JLoadingServiceType.All)
                where += where + " AND Type = " + Type.GetHashCode();
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
