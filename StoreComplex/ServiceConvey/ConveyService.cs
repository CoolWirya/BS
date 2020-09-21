using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace StoreComplex
{
    public class JConveyService : JStoreComplex
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
        /// سریال رسید/حواله
        /// </summary>
        public string Serial { get; set; }
        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// نوع وسیله
        /// </summary>
        public int DriveType { get; set; }
        /// <summary>
        /// نام راننده
        /// </summary>
        public string DriverName { get; set; }
        /// <summary>
        /// ش پلاک
        /// </summary>
        public string PelakNo { get; set; }
        /// <summary>
        /// هزینه سرویس
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// کد قرارداد
        /// </summary>
        public int ContractCode{ get; set; }

        #endregion Properties

        public JConveyService()
        {
        }
        public JConveyService(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }
        public int Insert()
        {
            JConveyServiceTable table = new JConveyServiceTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JConveyService.Insert"))
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
            JConveyServiceTable table = new JConveyServiceTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JConveyService.Delete"))
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

            JConveyServiceTable table = new JConveyServiceTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JConveyService.Update"))
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
                DB.setQuery("SELECT * FROM SCConveyService WHERE Code=" + pCode.ToString());
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

    public class JConveyServices : JSystem
    {
        public static DataTable GetDatatable(int pCode)
        {
            string SelectQouery = @" SELECT * FROM SCConveyService Where 1=1 ";
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
            string SelectQouery = @" SELECT Code, 
                 (Select Fa_Date From StaticDates Where En_Date =CONVERT ( Date ,[Date])) Date
                 ,Left(Convert(Time , [Date]) ,5) Time, 
                 (Select name from subdefine Where Code = DriveType) DriveType, DriverName ,  Cost  FROM SCConveyService Where 1=1 ";
            string where = " ";
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
