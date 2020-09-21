using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace StoreComplex
{
    /// <summary>
    /// اجاره انبار اختصاصی
    /// </summary>
    public class JRenewPrivate : JStoreComplex
    {
        #region Properties
        public int Code { get; set; }
        /// <summary>
        /// کد اجاره انبار در رسید 
        /// </summary>
        public int PrivateCode { get; set; }
        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// مبلغ
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// تعداد باکس قابل تمدید
        /// </summary>
        public decimal BoxCount{ get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description{ get; set; }
        /// <summary>
        /// تاریخ رسید یا تمدید
        /// </summary>
        public DateTime Receipt_Renew_Date { get; set; }
        /// <summary>
        /// نوبت تمدید
        /// </summary>
        public int RenewPeriod { get; set; }
#endregion

           public JRenewPrivate()
        {
        }
        public JRenewPrivate(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }

        public int Insert()
        {
            JRenewPrivateTable table = new JRenewPrivateTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JRenewPrivate.Insert"))
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
            JRenewPrivateTable table = new JRenewPrivateTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JRenewPrivate.Delete"))
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

            JRenewPrivateTable table = new JRenewPrivateTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JRenewPrivate.Update"))
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

        public void ShowDialog()
        {
            JRenewPrivateReportForm form = new JRenewPrivateReportForm();
            form.ShowDialog();
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM SCRenewPrivate WHERE Code=" + pCode.ToString());
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

    public class JRenewPrivates : JSystem
    {

        /// <summary>
        /// انبارهای قابل تمدید
        /// </summary>
        /// <param name="pDate"></param>
        /// <returns></returns>
        public static DataTable StoragesToRenew(string fromDate, string toDate)
        {
            string SelectQouery = @" Select * from(Select S.Title StorageTitle, PS.Description ,PS.BoxCount 
                    ,PS.BoxCount -  (SELECT ISNULL (SUM(BoxCount), 0) FROM SCPrivateTransfer WHERE SCPrivateTransfer .PrivateStorageCode = PS.Code ) AS ExistBoxCount  
                    ,(Select Fa_Date FROM StaticDates Where En_Date =  Convert(Date ,(Select ISNULL(Max(Date), R.Date) FROM SCRenewPrivate  WHERE Re.PrivateCode = SCRenewPrivate.PrivateCode) ) )IN_Renew_Date
                    , (Select COUNT (*) FROM SCRenewPrivate WHERE SCRenewPrivate .PrivateCode = PS .Code) + 1 RenewPeriod
                    , R.Serial , PS.Cost, C.SCCode 
                    ,(Select Name FROM clsAllPerson Where Code = R.PCode) PersonName, PS.Code 

                     from SCPrivateStorage PS
	                    INNER JOIN SCStorage S ON PS.StorageCode = S.Code 
	                    INNER JOIN SCReceipt R ON R.Code = PS.ReceiptCode
	                    Left Join SCRenewPrivate Re ON Re . PrivateCode = PS.Code 
	                    INNER Join legSubjectContract C ON R.ContractCode = C.Code
                    WHERE R.Closed = 1 ) A
	                    WHERE  A.ExistBoxCount >0
	                    AND  A.IN_Renew_Date <=" + JDataBase.Quote(toDate);// " AND " + JDataBase.Quote(toDate);
            SelectQouery += " ORDER BY A.IN_Renew_Date ";
            string where = " ";
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
        /// تمدیدهای انجام شده
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string fromDate, string toDate)
        {
            string SelectQouery = @" Select * FROM (Select Re.Code 
            , (Select Title FROM SCStorage WHERE Code = PS.StorageCode) StorageTitle
            , PS.Description PrivateDesc
            , (Select Fa_date from StaticDates Where En_Date =CONVERT(Date, R.Date)) RecieptDate 
            , (Select Fa_date from StaticDates Where En_Date = CONVERT(Date, Re.Date)) RenewDate 
            , Re.BoxCount  Exist , Re.Cost RenewCost , Re.Description 
            ,(Select Name FROM clsAllPerson Where Code = R.PCode) PersonName
             FROM SCRenewPrivate Re 
				INNER JOIN SCPrivateStorage PS ON Re.PrivateCode = PS.Code 
				INNER JOIN SCReceipt R ON PS.ReceiptCode = R.Code ) A Where A.RecieptDate Between "
                 + JDataBase.Quote(fromDate) + " AND " + JDataBase.Quote(toDate);
            SelectQouery += " ORDER BY A.RecieptDate ";
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

        public static bool ReceiptHasRenew(int pReceiptCode, DateTime pReceiptDate)
        {
            DateTime nextMonth = JDateTime.GregorianDate(JDateTime.AddMonthFarsi(JDateTime.FarsiDate(pReceiptDate), 1));
            if (nextMonth >= (new JDataBase()).GetCurrentDateTime())
                return true;
            string SelectQouery = @" Select Code from SCRenewPrivate  Where PrivateCode = " + pReceiptCode
                + " AND Date> " + JDataBase.Quote(pReceiptDate.ToShortDateString());
            string where = " ";
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(SelectQouery + where);
                return Db.Query_DataTable().Rows.Count > 0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                Db.Dispose();
            }
        }
    }

}
