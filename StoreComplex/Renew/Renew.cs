using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace StoreComplex
{
    /// <summary>
    /// تمدید کالاها
    /// </summary>
    public class JRenew:JStoreComplex 
    {
        #region Prperties
        public int Code { get; set; }
        /// <summary>
        /// کد رسید کالا
        /// </summary>
        public int ReceiptGoodCode { get; set; }
        /// <summary>
        /// تاریخ تمدید
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// هزینه تمدید
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// موجودی جهت تمدید
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// نوضیحات
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// تائید نهایی شده
        /// </summary>
        public bool Closed { get; set; }
        /// <summary>
        /// تاریخ رسید یا تمدید
        /// </summary>
        public DateTime Receipt_Renew_Date { get; set; }
        /// <summary>
        /// نوبت تمدید
        /// </summary>
        public int RenewPeriod { get; set; }
        #endregion

         public JRenew()
        {
        }
        public JRenew(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }

        public int Insert()
        {
            JRenewTable table = new JRenewTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JRenew.Insert"))
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
            JRenewTable table = new JRenewTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JRenew.Delete"))
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

            JRenewTable table = new JRenewTable();
            try
            {
                if (JPermission.CheckPermission("StoreComplex.JRenew.Update"))
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
            JRenewReportForm form = new JRenewReportForm();
            form.ShowDialog();
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM SCRenew WHERE Code=" + pCode.ToString());
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
    public class JRenews : JSystem
    {
        /// <summary>
        /// کالاهای قابل تمدید
        /// </summary>
        /// <param name="pDate"></param>
        /// <returns></returns>
        public static DataTable GoodsToRenew(string fromDate, string toDate)
        {
            string SelectQouery = @" Select * from
                    (Select  Distinct StoreGoods .Name GoodName, RG.Description 
                    ,RG.Amount 
                    ------- محاسبه موجودی انبار
                    ,RG.Amount - (Select ISNULL ( SUM(Amount), 0) FROM SCTransferGoods WHERE SCTransferGoods.RecieptGoodCode   = RG.Code ) as Exist  
                    ------ واحد کالا
                    ,(Select Name FROM subdefine WHERE Code = StoreGoods.Measure ) Measure 
                     ---------  تاریخ آخرین تمدید ، در صورتی که نال باشد تاریخ ورود کالا انتخاب میشود
                    ,(Select Fa_Date FROM StaticDates Where En_Date =  Convert(Date ,(Select ISNULL(Max(Date), R.Date) FROM SCRenew Re WHERE Re.ReceiptGoodCode  = SCRenew .ReceiptGoodCode ) ) )Date
                     -------  نوبت تمدید این کالا
                    ,(Select COUNT (*) FROM SCRenew WHERE SCRenew.ReceiptGoodCode = RG.Code) + 1 RenewPeriod
                    ,R.Serial ReceiptSerial, C.SCCode
                    ,RG.Cost , R.ContractCode , RG.GoodCode , RG.Code
                    ,(Select Name FROM clsAllPerson Where Code = R.PCode) PersonName
                    from SCReceiptGoods RG
	                    INNER Join SCReceipt R ON R.Code = RG.ReceiptCode 
	                    INNER Join legSubjectContract C ON R.ContractCode = C.Code
	                    LEFT Join SCTransferGoods TG ON RG.Code = TG .RecieptGoodCode 
	                    INNER Join StoreGoods ON RG.GoodCode = StoreGoods.Code 
	                    Left Join SCRenew ON SCRenew . ReceiptGoodCode = RG.Code 
	                    WHERE R.Closed = 1 ) A
	                    WHERE  A.Exist >0
	                    AND  A.Date <=" + JDataBase.Quote(toDate);// " AND " + JDataBase.Quote(toDate);
            SelectQouery += " ORDER BY A.Date ";
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
            string SelectQouery = @" Select * FROM
                (Select Re.Code , G.Name, RG.Description GoodsDesc
                , (Select Fa_date from StaticDates Where En_Date =CONVERT(Date, R.Date)) RecieptDate 
                , (Select Fa_date from StaticDates Where En_Date = CONVERT(Date, Re.Date)) RenewDate 
                , Re.Amount Exist , (Select Name FROM subdefine WHERE Code = G .Measure ) Measure 
                , Re.Cost RenewCost , Re.Description 
                ,(Select Name FROM clsAllPerson Where Code = R.PCode) PersonName
                 from SCRenew Re  
                 INNER JOIN SCReceiptGoods RG ON Re.ReceiptGoodCode = RG.Code 
                 INNER JOIN SCReceipt R ON RG.ReceiptCode = R.Code 
                 INNER JOIN StoreGoods G ON RG.GoodCode = G.Code ) A
            Where A.RecieptDate Between " + JDataBase.Quote(fromDate) + " AND " + JDataBase.Quote(toDate);
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
        /// <summary>
        /// چک میکند آیا رسید کالایی که قبل از یک ماه پیش ثبت شده است، تمدید شده است یا خیر
        /// </summary>
        /// <param name="pReceiptCode"></param>
        /// <param name="pReceiptDate"></param>
        /// <returns></returns>
        public static bool ReceiptHasRenew(int pReceiptCode, DateTime pReceiptDate)
        {
            DateTime nextMonth = JDateTime.GregorianDate(JDateTime.AddMonthFarsi(JDateTime.FarsiDate(pReceiptDate), 1));
            if (nextMonth >= (new JDataBase()).GetCurrentDateTime())
                return true;
            string SelectQouery = @" Select 
                Code from SCRenew Where ReceiptGoodCode = " + pReceiptCode 
                + " AND Date> " + JDataBase.Quote(pReceiptDate.ToShortDateString());
            string where = " ";
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery(SelectQouery + where);
                return Db.Query_DataTable().Rows.Count>0;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false ;
            }
            finally
            {
                Db.Dispose();
            }
        }
    }
}
