using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Transaction
{
    public class JTicketTransactions
    {
        public static bool AddTicketTransaction(Transaction.JTransactionTicketHeader TH, Transaction.JTransactionTicket TT, Int64 recordNumber, string Header_IMEI, float Header_BusSerial, byte[] Header_Version, ClassLibrary.JDataBase db, int ArchiveContentCode = 0)
        {
            //AddTicketTransactionExtract(TH, TT, recordNumber, Header_IMEI, Header_BusSerial, Header_Version, db, ArchiveContentCode);

            db.Params.Clear();
            if (db.Params.Count > 0)
            {
                db.Params.Remove("recordNumber");
                db.Params.Remove("TransactionID");
                db.Params.Remove("LineNumber");
                db.Params.Remove("BusSerial");
                db.Params.Remove("DriverSerialCard");
                db.Params.Remove("PassengerCardSerial");
                db.Params.Remove("CardType");
                db.Params.Remove("EventDate");
                db.Params.Remove("TicketPrice");
                db.Params.Remove("ReaderID");
                db.Params.Remove("RemainPrice");
                db.Params.Remove("IMEI");
                db.Params.Remove("VERSION");
            }

            string date = (new DateTime(TH.DATE.Year, TH.DATE.Month, TH.DATE.Day, TT.Time[0], TT.Time[1], TT.Time[2])).ToString("yyyy-MM-dd HH:mm:ss");
            db.setQuery(@"EXEC SP_InsertAUTTicketTransaction
	                    @recordNumber,
	                    @TransactionID,
	                    @LineNumber,
	                    @BusSerial,
	                    @DriverSerialCard,
	                    @PassengerCardSerial,
	                    @CardType,
	                    @EventDate,
	                    @TicketPrice,
	                    @ReaderID,
	                    @RemainPrice,
	                    @IMEI,
	                    @VERSION");

            db.AddParams("recordNumber", recordNumber);
            db.AddParams("TransactionID", Convert.ToInt64(TT.transactionid));
            db.AddParams("LineNumber", Convert.ToInt64(TH.LineNumber));
            db.AddParams("BusSerial", Convert.ToDouble(TH.busSerial.ToString().Replace('-', '.')));
            db.AddParams("DriverSerialCard", Convert.ToInt64(TH.DriverSerialCard));
            db.AddParams("PassengerCardSerial", Convert.ToInt64(TT.PassengerCardSerial));
            db.AddParams("CardType", Convert.ToInt32(TT.CardType));
            db.AddParams("EventDate", date);
            db.AddParams("TicketPrice", Convert.ToInt32(TT.TicketPrice));
            db.AddParams("ReaderID", Convert.ToInt32(TT.ReaderID));
            db.AddParams("RemainPrice", Convert.ToInt64(TT.RemainPrice));
            db.AddParams("IMEI", Convert.ToInt64(Header_IMEI));
            db.AddParams("VERSION", Header_Version);

            if (db.Query_Execute() > 0)
            {
                return true;
            }
            return true;
        }



        public static bool AddTicketTransactionPublic(TransactionPublic.JTransactionTicketHeader TH, TransactionPublic.JTransactionTicket TT, Int64 recordNumber, string Header_IMEI, float Header_BusSerial, byte[] Header_Version, ClassLibrary.JDataBase db, int ArchiveContentCode = 0)
        {
            //AddTicketTransactionExtract(TH, TT, recordNumber, Header_IMEI, Header_BusSerial, Header_Version, db, ArchiveContentCode);

            db.Params.Clear();
            if (db.Params.Count > 0)
            {
                db.Params.Remove("recordNumber");
                db.Params.Remove("TransactionID");
                db.Params.Remove("LineNumber");
                db.Params.Remove("BusSerial");
                db.Params.Remove("DriverSerialCard");
                db.Params.Remove("PassengerCardSerial");
                db.Params.Remove("CardType");
                db.Params.Remove("EventDate");
                db.Params.Remove("TicketPrice");
                db.Params.Remove("ReaderID");
                db.Params.Remove("RemainPrice");
                db.Params.Remove("IMEI");
                db.Params.Remove("VERSION");
            }

            string date = (new DateTime(TH.DATE.Year, TH.DATE.Month, TH.DATE.Day, TT.Time[0], TT.Time[1], TT.Time[2])).ToString("yyyy-MM-dd HH:mm:ss");
            db.setQuery(@"EXEC SP_InsertAUTTicketTransaction
	                    @recordNumber,
	                    @TransactionID,
	                    @LineNumber,
	                    @BusSerial,
	                    @DriverSerialCard,
	                    @PassengerCardSerial,
	                    @CardType,
	                    @EventDate,
	                    @TicketPrice,
	                    @ReaderID,
	                    @RemainPrice,
	                    @IMEI,
	                    @VERSION");

            int NewTicketPrice = GetLinePrice(TH.LineNumber.ToString(), Convert.ToDateTime(date));
            int NewCardType = Convert.ToInt32(TT.CardType);
            if (NewTicketPrice == 0)
            {
                NewCardType = 10;
            }

            db.AddParams("recordNumber", recordNumber);
            db.AddParams("TransactionID", Convert.ToInt64(recordNumber));
            db.AddParams("LineNumber", Convert.ToInt64(TH.LineNumber));
            db.AddParams("BusSerial", Convert.ToDouble(TH.busSerial.ToString().Replace('-', '.')));
            db.AddParams("DriverSerialCard", Convert.ToInt64(TH.DriverSerialCard));
            db.AddParams("PassengerCardSerial", Convert.ToInt64(TT.PassengerCardSerial));
            db.AddParams("CardType", Convert.ToInt32(NewCardType));
            db.AddParams("EventDate", date);
            db.AddParams("TicketPrice", Convert.ToInt32(NewTicketPrice));
            db.AddParams("ReaderID", Convert.ToInt32(TH.ReaderID));
            db.AddParams("RemainPrice", Convert.ToInt64(TT.RemainPrice));
            db.AddParams("IMEI", Convert.ToInt64(Header_IMEI));
            db.AddParams("VERSION", Header_Version);

            if (db.Query_Execute() > 0)
            {
                return true;
            }
            return true;
        }

        public static int GetLinePrice(string LineNumber, DateTime EventDate)
        {
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            int Res = 0;
            //  ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            Db.setQuery(@"select Price from AUTPrice where LineCode = (select Code from AUTLine where LineNumber = " + LineNumber + @")
                            and '" + EventDate.ToShortDateString() + "' >= StartDate and '" + EventDate.ToShortDateString() + "' <= EndDate Order By StartDate Desc");
            System.Data.DataTable Dt = Db.Query_DataTable();
            if (Dt != null)
            {
                if (Dt.Rows.Count > 0)
                {
                    Res = Convert.ToInt32(Dt.Rows[0]["Price"].ToString());
                }
            }
            Db.Dispose();
            return Res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TH"></param>
        /// <param name="TT"></param>
        /// <param name="recordNumber"></param>
        /// <param name="Header_IMEI"></param>
        /// <param name="Header_BusSerial"></param>
        /// <param name="Header_Version"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static bool AddTicketTransactionExtract(Transaction.JTransactionTicketHeader TH, Transaction.JTransactionTicket TT, Int64 recordNumber, string Header_IMEI, float Header_BusSerial, byte[] Header_Version, ClassLibrary.JDataBase db, int ArchiveContentCode = 0)
        {

            db.Params.Clear();
            if (db.Params.Count > 0)
            {
                db.Params.Remove("recordNumber");
                db.Params.Remove("TransactionID");
                db.Params.Remove("LineNumber");
                db.Params.Remove("BusSerial");
                db.Params.Remove("DriverSerialCard");
                db.Params.Remove("PassengerCardSerial");
                db.Params.Remove("CardType");
                db.Params.Remove("EventDate");
                db.Params.Remove("TicketPrice");
                db.Params.Remove("ReaderID");
                db.Params.Remove("RemainPrice");
                db.Params.Remove("IMEI");
                db.Params.Remove("VERSION");
            }
            try
            {
                string date = (new DateTime(TH.DATE.Year, TH.DATE.Month, TH.DATE.Day, TT.Time[0], TT.Time[1], TT.Time[2])).ToString("yyyy-MM-dd HH:mm:ss");
                db.setQuery(@"INSERT INTO ExtractedTickets
                            (
	                            recordNumber,
	                            TransactionID,
	                            LineNumber,
	                            BusSerial,
	                            DriverSerialCard,
	                            PassengerCardSerial,
	                            CardType,
	                            EventDate,
	                            TicketPrice,
	                            ReaderID,
	                            RemainPrice,
	                            IMEI,
	                            VERSION
                            )
                            VALUES
                            (
	                    @recordNumber,
	                    @TransactionID,
	                    @LineNumber,
	                    @BusSerial,
	                    @DriverSerialCard,
	                    @PassengerCardSerial,
	                    @CardType,
	                    @EventDate,
	                    @TicketPrice,
	                    @ReaderID,
	                    @RemainPrice,
	                    @IMEI,
	                    @VERSION)");

                db.AddParams("recordNumber", recordNumber.ToString());
                db.AddParams("TransactionID", TT.transactionid.ToString());
                db.AddParams("LineNumber", TH.LineNumber.ToString());
                db.AddParams("BusSerial", TH.busSerial.ToString());
                db.AddParams("DriverSerialCard", TH.DriverSerialCard.ToString());
                db.AddParams("PassengerCardSerial", TT.PassengerCardSerial.ToString());
                db.AddParams("CardType", TT.CardType.ToString());
                db.AddParams("EventDate", date.ToString());
                db.AddParams("TicketPrice", TT.TicketPrice.ToString());
                db.AddParams("ReaderID", TT.ReaderID.ToString());
                db.AddParams("RemainPrice", TT.RemainPrice.ToString());
                db.AddParams("IMEI", Header_IMEI.ToString());
                db.AddParams("VERSION", Header_Version.ToString());

                if (ArchiveContentCode > 0)
                {
                    try
                    {
                        InsertBusOfflineFilesRecordInDb(ArchiveContentCode, recordNumber.ToString(), TT.transactionid.ToString(),
                            TH.LineNumber.ToString(), TH.busSerial.ToString(), TH.DriverSerialCard.ToString()
                            , TT.PassengerCardSerial.ToString(), TT.CardType.ToString(), date.ToString()
                            , TT.TicketPrice.ToString(), TT.ReaderID.ToString(), TT.RemainPrice.ToString()
                            , Header_IMEI.ToString(), Header_Version.ToString());
                    }
                    catch { }
                }

                if (db.Query_Execute() > 0) return true;
                return true;
            }
            catch (Exception ex)
            {
                ex.Source += "BusManagment.Transaction.JTicketTransaction.AddTicketTransactionExtract";
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            return true;
        }

        public static void InsertBusOfflineFilesRecordInDb(int ArchiveContentCode, string recordNumber,
            string TransactionID, string LineNumber, string BusSerial, string DriverSerialCard,
            string PassengerCardSerial, string CardType, string EventDate, string TicketPrice,
            string ReaderID, string RemainPrice, string IMEI, string VERSION)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            db.setQuery(@"INSERT INTO ArchiveContentExtracted
                            (
                                ArchiveContentCode,
	                            recordNumber,
	                            TransactionID,
	                            LineNumber,
	                            BusSerial,
	                            DriverSerialCard,
	                            PassengerCardSerial,
	                            CardType,
	                            EventDate,
	                            TicketPrice,
	                            ReaderID,
	                            RemainPrice,
	                            IMEI,
	                            VERSION
                            )
                            VALUES
                            (
                        @ArchiveContentCode,
	                    @recordNumber,
	                    @TransactionID,
	                    @LineNumber,
	                    @BusSerial,
	                    @DriverSerialCard,
	                    @PassengerCardSerial,
	                    @CardType,
	                    @EventDate,
	                    @TicketPrice,
	                    @ReaderID,
	                    @RemainPrice,
	                    @IMEI,
	                    @VERSION)");
            db.AddParams("ArchiveContentCode", ArchiveContentCode);
            db.AddParams("recordNumber", recordNumber.ToString());
            db.AddParams("TransactionID", TransactionID.ToString());
            db.AddParams("LineNumber", LineNumber.ToString());
            db.AddParams("BusSerial", BusSerial.ToString());
            db.AddParams("DriverSerialCard", DriverSerialCard.ToString());
            db.AddParams("PassengerCardSerial", PassengerCardSerial.ToString());
            db.AddParams("CardType", CardType.ToString());
            db.AddParams("EventDate", EventDate.ToString());
            db.AddParams("TicketPrice", TicketPrice.ToString());
            db.AddParams("ReaderID", ReaderID.ToString());
            db.AddParams("RemainPrice", RemainPrice.ToString());
            db.AddParams("IMEI", IMEI.ToString());
            db.AddParams("VERSION", VERSION.ToString());
            db.Query_Execute();
        }




        public static void TransactionPrintCheckDataTicketForAllPrinterReport(ClassLibrary.JDataBase db, ClassLibrary.JMySQLDataBase MySqlDb)
        {
            ClassLibrary.JSystem.Except.AddException(new Exception("*** Start Update Shifti Daily From MySql " + DateTime.Now.ToLongTimeString()));


            db.setQuery(@"select top 1000 Code,BusNumber,cast(StartDate as date)FDate,DailyCode,StartDate,EndDate from [AUTPrinterRporte] 
                                        where [ShiftDriverCode] > 0 and [State] = 0
                                        order by Code desc");
            System.Data.DataTable DtPrinterReport = db.Query_DataTable();
            if (DtPrinterReport != null)
            {
                if (DtPrinterReport.Rows.Count > 0)
                {
                    for (int i = 0; i < DtPrinterReport.Rows.Count; i++)
                    {
                        try
                        {
                            MySqlDb.setQuery(@"SELECT `RowCount`,`RowSent` FROM `getdataticket` Where `Code` = " + DtPrinterReport.Rows[i]["Code"].ToString() + @" and `state` = 1");
                            System.Data.DataTable DtMyDqlGetDataTicket = MySqlDb.Query_DataTable();
                            if (DtMyDqlGetDataTicket != null)
                            {
                                if (DtMyDqlGetDataTicket.Rows.Count > 0)
                                {
                                    db.setQuery(@"Update [AUTPrinterRporte] set [TicketCount] = " + DtMyDqlGetDataTicket.Rows[0]["RowCount"].ToString() + @"
                                            ,[TicketSent] = " + DtMyDqlGetDataTicket.Rows[0]["RowSent"].ToString() + @" ,[State] = 1 where 
                                            Code = " + DtPrinterReport.Rows[i]["Code"].ToString());

                                    //                                    db.setQuery(@"select ISNULL(sum(TCount),-1)TCount from [dbo].[AUTDailyPerformanceRportOnBus]
                                    //                                                where BusCode = (select Code from AutBus Where BusNumber = " + DtPrinterReport.Rows[i]["BusNumber"].ToString() + @")
                                    //                                                      And [Date] = cast('" + DtPrinterReport.Rows[i]["FDate"].ToString() + @"' as date)
                                    //                                                      And FirstTicketDate >= '" + DtPrinterReport.Rows[i]["StartDate"].ToString() + @"'
                                    //                                                      And LastTicketDate <= '" + DtPrinterReport.Rows[i]["EndDate"].ToString() + @"'");
                                    db.setQuery(@"SELECT sum(Tcount)TCount
                                                                  FROM [dbo].[AUTShiftDriver]
                                                                  where BusNumber = " + DtPrinterReport.Rows[i]["BusNumber"].ToString() + @" and Error = 0 and CardType = 0
                                                                  and 
                                                                  ([Startdate] >= '" + DtPrinterReport.Rows[i]["StartDate"].ToString() + @"'
                                                                  and [Enddate] <= '" + DtPrinterReport.Rows[i]["EndDate"].ToString() + @"')");
                                    System.Data.DataTable DtSumTransaction = db.Query_DataTable();
                                    if (DtSumTransaction != null && Convert.ToInt32(DtSumTransaction.Rows[0]["TCount"].ToString()) > -1)
                                    {
                                        if (DtSumTransaction.Rows.Count > 0)
                                        {
                                            if (Convert.ToInt32(DtSumTransaction.Rows[0]["TCount"].ToString()) == Convert.ToInt32(DtMyDqlGetDataTicket.Rows[0]["RowCount"].ToString()))
                                            {
                                                db.setQuery(@"Update [AUTShiftDriver] set [SetPrinter] = 1  where 
                                                                  BusNumber = " + DtPrinterReport.Rows[i]["BusNumber"].ToString() + @" and Error = 0 and CardType = 0
                                                                  and 
                                                                  ([Startdate] >= '" + DtPrinterReport.Rows[i]["StartDate"].ToString() + @"'
                                                                  and [Enddate] <= '" + DtPrinterReport.Rows[i]["EndDate"].ToString() + @"')");
                                                db.Query_Execute();
                                            }

                                            //                                            db.setQuery(@"Update [AUTPrinterRporte] set [GetTicket] = 1,[State] = 1,[RequestCount]= IsNull(RequestCount,0) + 1 where 
                                            //                                            Code = " + DtPrinterReport.Rows[i]["Code"].ToString());
                                            //                                            db.Query_Execute();

                                            //                                            db.setQuery(@"Update [AUTDailyPerformanceRportOnBus] set [SetPrinter] = 1 , 
                                            //                                                            [TCount]  = " + DtMyDqlGetDataTicket.Rows[0]["RowCount"].ToString() + @" - 
                                            //															(select ISNULL(sum(tcount),0) from AUTDailyPerformanceRportOnBus where BusCode = b.BusCode and
                                            //															Date = b.Date and CardType=b.CardType and DriverCardSerial=b.DriverCardSerial
                                            //															and LineNumber=b.LineNumber and TicketPrice=b.TicketPrice and (DocumentCode > 0))
                                            //                                                          , Price = ((" + DtMyDqlGetDataTicket.Rows[0]["RowCount"].ToString() + @" - 
                                            //															(select ISNULL(sum(tcount),0) from AUTDailyPerformanceRportOnBus where BusCode = b.BusCode and
                                            //															Date = b.Date and CardType=b.CardType and DriverCardSerial=b.DriverCardSerial
                                            //															and LineNumber=b.LineNumber and TicketPrice=b.TicketPrice and (DocumentCode > 0))) * TicketPrice) 
                                            //															from AUTDailyPerformanceRportOnBus b
                                            //                                                           where DocumentCode = 0 and Code = " + DtPrinterReport.Rows[i]["DailyCode"].ToString() + @"
                                            //                                                            and (" + DtMyDqlGetDataTicket.Rows[0]["RowCount"].ToString() + @" - 
                                            //                                                            (select ISNULL(sum(tcount),0) from AUTDailyPerformanceRportOnBus where BusCode = b.BusCode and
                                            //															Date = b.Date and CardType=b.CardType and DriverCardSerial=b.DriverCardSerial
                                            //															and LineNumber=b.LineNumber and TicketPrice=b.TicketPrice and (DocumentCode > 0))) >= 0");
                                            //                                            db.Query_Execute();
                                            //                                            db.setQuery(@"Update [AUTDailyPerformanceRportOnBus] set [SetPrinter] = 1 , 
                                            //                                                            [TCount]  = 0  , Price = 0
                                            //                                                            where DocumentCode = 0 and BusCode = (select Code from AutBus Where BusNumber = " + DtPrinterReport.Rows[i]["BusNumber"].ToString() + @")
                                            //                                                            and FirstTicketDate > '" + DtPrinterReport.Rows[i]["StartDate"].ToString() +
                                            //                                                            "' AND LastTicketDate < '" + DtPrinterReport.Rows[i]["EndDate"].ToString() + @"'");
                                            //                                            db.Query_Execute();

                                            db.setQuery(@"Update [AUTWorkedDay] set [Active] = 1 where Date = '"
                                               + DtPrinterReport.Rows[i]["FDate"].ToString() + "'");
                                            db.Query_Execute();
                                        }
                                    }
                                }
                            }
                        }
                        catch
                        {

                        }
                    }
                }
            }
            ClassLibrary.JSystem.Except.AddException(new Exception("*** End Update Shifti Daily From MySql " + DateTime.Now.ToLongTimeString()));
        }


        public static void TransactionPrintCheckDataTicket(ClassLibrary.JDataBase db, ClassLibrary.JMySQLDataBase MySqlDb, DateTime InsertDate)
        {
            ClassLibrary.JSystem.Except.AddException(new Exception("*** Start TransactionPrintCheckDataTicket " + DateTime.Now.ToLongTimeString()));

            db.setQuery(@"select Date from AutWorkedDay where Active = 1 and Date > = '" + InsertDate.ToString("yyyy-MM-dd") + "' order by Date Desc");
            System.Data.DataTable DtWorkedDay = db.Query_DataTable();
            DateTime ProcDate = DateTime.Now;
            if (DtWorkedDay != null)
            {
                if (DtWorkedDay.Rows.Count > 0)
                {
                    for (int WD = 0; WD < DtWorkedDay.Rows.Count; WD++)
                    {

                        ProcDate = Convert.ToDateTime(DtWorkedDay.Rows[WD]["Date"].ToString());


                        ClassLibrary.JSystem.Except.AddException(new Exception("Start UpdateAUTDailyPerformanceRportOnBus For " +
                            ProcDate.ToShortDateString() + " " + DateTime.Now.ToLongTimeString()));

                        db.setQuery("EXEC UpdateAUTDailyPerformanceRportOnBus @ProcessDate");
                        db.Params.Clear();
                        if (db.Params.Count > 0)
                        {
                            db.Params.Remove("ProcessDate");
                        }
                        db.AddParams("ProcessDate", ProcDate);
                        db.Query_Execute();

                        ClassLibrary.JSystem.Except.AddException(new Exception("END UpdateAUTDailyPerformanceRportOnBus For " +
                            ProcDate.ToShortDateString() + " " + DateTime.Now.ToLongTimeString()));

                        ClassLibrary.JSystem.Except.AddException(new Exception("Start TransactionPrintCheckDataTicket For " +
                            ProcDate.ToShortDateString() + " " + DateTime.Now.ToLongTimeString()));

                        db.setQuery(@"select Code,BusNumber,cast(StartDate as date)FDate,DailyCode,StartDate,EndDate from [AUTPrinterRporte] 
                                        where [ShiftDriverCode] > 0 and [State] = 0 and cast(StartDate as date) = cast('" + ProcDate.ToShortDateString() + @"' as date)
                                        order by Code desc");
                        System.Data.DataTable DtPrinterReport = db.Query_DataTable();
                        if (DtPrinterReport != null)
                        {
                            if (DtPrinterReport.Rows.Count > 0)
                            {
                                for (int i = 0; i < DtPrinterReport.Rows.Count; i++)
                                {
                                    try
                                    {
                                        MySqlDb.setQuery(@"SELECT `RowCount`,`RowSent` FROM `getdataticket` Where `Code` = " + DtPrinterReport.Rows[i]["Code"].ToString() + @" and `state` = 1");
                                        System.Data.DataTable DtMyDqlGetDataTicket = MySqlDb.Query_DataTable();
                                        if (DtMyDqlGetDataTicket != null)
                                        {
                                            if (DtMyDqlGetDataTicket.Rows.Count > 0)
                                            {
                                                db.setQuery(@"Update [AUTPrinterRporte] set [TicketCount] = " + DtMyDqlGetDataTicket.Rows[0]["RowCount"].ToString() + @"
                                                            ,[TicketSent] = " + DtMyDqlGetDataTicket.Rows[0]["RowSent"].ToString() + @" ,[State] = 1 where 
                                                             Code = " + DtPrinterReport.Rows[i]["Code"].ToString());
                                                db.Query_Execute();
                                                db.setQuery(@"SELECT sum(Tcount)TCount
                                                                  FROM [dbo].[AUTShiftDriver]
                                                                  where BusNumber = " + DtPrinterReport.Rows[i]["BusNumber"].ToString() + @" and Error = 0 and CardType = 0
                                                                  and 
                                                                  ([Startdate] >= '" + DtPrinterReport.Rows[i]["StartDate"].ToString() + @"'
                                                                  and [Enddate] <= '" + DtPrinterReport.Rows[i]["EndDate"].ToString() + @"')");
                                                System.Data.DataTable DtSumTransaction = db.Query_DataTable();
                                                if (DtSumTransaction != null && Convert.ToInt32(DtSumTransaction.Rows[0]["TCount"].ToString()) > -1)
                                                {
                                                    if (DtSumTransaction.Rows.Count > 0)
                                                    {
                                                        if (Convert.ToInt32(DtSumTransaction.Rows[0]["TCount"].ToString()) == Convert.ToInt32(DtMyDqlGetDataTicket.Rows[0]["RowCount"].ToString()))
                                                        {
                                                            db.setQuery(@"Update [AUTShiftDriver] set [SetPrinter] = 1 
                                                                            where BusNumber = " + DtPrinterReport.Rows[i]["BusNumber"].ToString() + @" 
                                                                            and Error = 0 and CardType = 0
                                                                            and 
                                                                            ([Startdate] >= '" + DtPrinterReport.Rows[i]["StartDate"].ToString() + @"'
                                                                            and [Enddate] <= '" + DtPrinterReport.Rows[i]["EndDate"].ToString() + @"')");
                                                            db.Query_Execute();
                                                        }
                                                        db.setQuery(@"Update [AUTWorkedDay] set [Active] = 1 where Date = '"
                                                           + DtPrinterReport.Rows[i]["FDate"].ToString() + "'");
                                                        db.Query_Execute();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    catch
                                    {

                                    }
                                }
                            }
                        }

                        //if (DateTime.Now.Hour >= 22 & DateTime.Now.Hour < 2)
                        //{
                        //    ClassLibrary.JSystem.Except.AddException(new Exception("Start TransactionPrintInsert " + DateTime.Now.ToLongTimeString()));
                        //    TransactionPrintInsert(db, MySqlDb, InsertDate);
                        //    ClassLibrary.JSystem.Except.AddException(new Exception("END TransactionPrintInsert " + DateTime.Now.ToLongTimeString()));
                        //}



                        ClassLibrary.JSystem.Except.AddException(new Exception("Start UpdateAUTDailyPerformanceRportOnBus For " +
                            DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString()));

                        db.setQuery("EXEC UpdateAUTDailyPerformanceRportOnBus @ProcessDate");
                        db.Params.Clear();
                        if (db.Params.Count > 0)
                        {
                            db.Params.Remove("ProcessDate");
                        }
                        db.AddParams("ProcessDate", DateTime.Now);
                        db.Query_Execute();

                        ClassLibrary.JSystem.Except.AddException(new Exception("End UpdateAUTDailyPerformanceRportOnBus For " +
                            DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString()));



                    }
                }
            }

            ClassLibrary.JSystem.Except.AddException(new Exception("*** END TransactionPrintCheckDataTicket" + DateTime.Now.ToLongTimeString()));
        }

        public static void TransactionDailyPrintUpdateFromMySql(ClassLibrary.JDataBase db, ClassLibrary.JMySQLDataBase MySqlDb)
        {
            ClassLibrary.JSystem.Except.AddException(new Exception("Start TransactionDailyPrintUpdateFromMySql For " + DateTime.Now.ToLongTimeString()));

            db.setQuery(@"select Code,BusNumber,cast(StartDate as date)FDate,DailyCode,StartDate,EndDate from [AUTPrinterRporte] 
                                        where [DailyCode] = 0 and [State] = 0 and [ShiftDriverCode] = 0
                                        and StartDate > DATEADD(month,-1,getdate())
                                        order by Code desc");
            System.Data.DataTable DtPrinterReport = db.Query_DataTable();
            if (DtPrinterReport != null)
            {
                if (DtPrinterReport.Rows.Count > 0)
                {
                    for (int i = 0; i < DtPrinterReport.Rows.Count; i++)
                    {
                        try
                        {
                            MySqlDb.setQuery(@"SELECT `RowCount`,`RowSent` FROM `getdataticket` Where `Code` = " + DtPrinterReport.Rows[i]["Code"].ToString() + @" and `state` = 1");
                            System.Data.DataTable DtMyDqlGetDataTicket = MySqlDb.Query_DataTable();
                            if (DtMyDqlGetDataTicket != null)
                            {
                                if (DtMyDqlGetDataTicket.Rows.Count > 0)
                                {
                                    db.setQuery(@"Update [AUTPrinterRporte] set [TicketCount] = " + DtMyDqlGetDataTicket.Rows[0]["RowCount"].ToString() + @"
                                            ,[TicketSent] = " + DtMyDqlGetDataTicket.Rows[0]["RowSent"].ToString() + @" ,[State] = 1 where 
                                            Code = " + DtPrinterReport.Rows[i]["Code"].ToString());
                                    db.Query_Execute();

                                }
                            }
                        }
                        catch { }
                    }
                }
            }

            ClassLibrary.JSystem.Except.AddException(new Exception("End TransactionDailyPrintUpdateFromMySql For " + DateTime.Now.ToLongTimeString()));
        }

        public static void TransactionPrintInsertForBeforeMonth(ClassLibrary.JDataBase db, ClassLibrary.JMySQLDataBase MySqlDb)
        {
            db.setQuery(@"select BusNumber,count(*)c from AUTTicketTransaction where eventdate between '2014-03-21 00:00:00' and '2014-05-21 23:59:59'
                            and Len(BusNumber)=4 and BusNumber < 5999
                            group by BusNumber
                            having count(*) > 20
                            order by c");
        }

        public static void TransactionPrintInsert(ClassLibrary.JDataBase db, ClassLibrary.JMySQLDataBase MySqlDb, DateTime InsertDate)
        {
            ClassLibrary.JSystem.Except.AddException(new Exception("Start TransactionPrintInsert" + DateTime.Now.ToLongTimeString()));
            int SqlLastInsertCode;
            //            db.setQuery(@"select adprob.[Code],adprob.[Date],adprob.[BusCode],ab.BusNumber as BusNumber,adprob.[CardType],adprob.[DriverPersonCode],
            //                           adprob.[DriverCardSerial],
            //                           adprob.[LineNumber],adprob.[TicketPrice],adprob.[Price],adprob.[TCount],adprob.[DocumentCode],adprob.[OwnerCode],adprob.[IsHoliDay],
            //                           adprob.[FirstTicketDate],adprob.[LastTicketDate],adprob.[FirstAvlDate],
            //                           adprob.[LastAvlDate],adprob.[FrontDoor],adprob.[BackDoor],adprob.[SetPrinter],adprob.[InsertPrintRequest] 
            //                           from AUTDailyPerformanceRportOnBus adprob
            //                           Left Join AutBus ab on adprob.BusCode = ab.Code
            //                           where adprob.SetPrinter = 0 and adprob.InsertPrintRequest = 0 and adprob.CardType = 0 
            //                           and (adprob.[Date] >= '" + InsertDate.ToShortDateString() + @"' and adprob.[Date] < cast(getdate() as date))
            //                           and adprob.FirstTicketDate is not null and adprob.LastTicketDate is not null
            //                           Order By adprob.[Date] Desc");
            db.setQuery(@"SELECT max([Code])Code,[BusNumber],[Startdate],[Enddate]
                              FROM [dbo].[AUTShiftDriver]
                              where [InsertPrintRequest] = 0 and SetPrinter = 0 and Error = 0 and CardType = 0
                              and cast(Startdate as date) < cast(getdate() as date)
                              group by [BusNumber],[Startdate],[Enddate]
                              order by Code Desc");
            System.Data.DataTable DtDailyTicket = db.Query_DataTable();
            if (DtDailyTicket != null)
            {
                if (DtDailyTicket.Rows.Count > 0)
                {
                    for (int i = 0; i < DtDailyTicket.Rows.Count; i++)
                    {
                        BusManagment.JBusPrintReport TransactionPrint = new BusManagment.JBusPrintReport();

                        if (!TransactionPrint.GetShiftDriverData(Convert.ToInt32(DtDailyTicket.Rows[i]["BusNumber"].ToString()),
                            Convert.ToDateTime(DtDailyTicket.Rows[i]["Startdate"].ToString()),
                            Convert.ToDateTime(DtDailyTicket.Rows[i]["Enddate"].ToString())))
                        {
                            TransactionPrint.BusNumber = Convert.ToInt32(DtDailyTicket.Rows[i]["BusNumber"].ToString());
                            TransactionPrint.StartDate = Convert.ToDateTime(DtDailyTicket.Rows[i]["Startdate"].ToString());
                            TransactionPrint.EndDate = Convert.ToDateTime(DtDailyTicket.Rows[i]["Enddate"].ToString());
                            TransactionPrint.TicketCount = 0;
                            TransactionPrint.TicketSent = 0;
                            TransactionPrint.State = 0;
                            TransactionPrint.DailyCode = 0;
                            TransactionPrint.ShiftDriverCode = Convert.ToInt32(DtDailyTicket.Rows[i]["Code"].ToString());

                            SqlLastInsertCode = TransactionPrint.Insert();

                            SavePrintInMySql(MySqlDb, SqlLastInsertCode,
                                Convert.ToInt32(DtDailyTicket.Rows[i]["BusNumber"].ToString()),
                                Convert.ToDateTime(DtDailyTicket.Rows[i]["Startdate"].ToString()),
                                Convert.ToDateTime(DtDailyTicket.Rows[i]["Enddate"].ToString()));
                            UpdateInserPrintInShift(db, Convert.ToInt32(DtDailyTicket.Rows[i]["Code"].ToString()));

                        }
                        else
                        {
                            TransactionPrint.StartDate = Convert.ToDateTime(DtDailyTicket.Rows[i]["Startdate"].ToString());
                            TransactionPrint.EndDate = Convert.ToDateTime(DtDailyTicket.Rows[i]["Enddate"].ToString());
                            TransactionPrint.State = 0;

                            TransactionPrint.Update();
                            SqlLastInsertCode = TransactionPrint.Code;
                            if (GetMySqlData(MySqlDb, SqlLastInsertCode))
                            {
                                UpdatePrintInMySql(MySqlDb, SqlLastInsertCode,
                                    Convert.ToInt32(DtDailyTicket.Rows[i]["BusNumber"].ToString()),
                                    Convert.ToDateTime(DtDailyTicket.Rows[i]["Startdate"].ToString()),
                                    Convert.ToDateTime(DtDailyTicket.Rows[i]["Enddate"].ToString()));
                            }
                            else
                            {
                                SavePrintInMySql(MySqlDb, SqlLastInsertCode,
                                Convert.ToInt32(DtDailyTicket.Rows[i]["BusNumber"].ToString()),
                                Convert.ToDateTime(DtDailyTicket.Rows[i]["Startdate"].ToString()),
                                Convert.ToDateTime(DtDailyTicket.Rows[i]["Enddate"].ToString()));
                            }
                            UpdateInserPrintInShift(db, Convert.ToInt32(DtDailyTicket.Rows[i]["Code"].ToString()));
                        }
                    }
                }
            }
            ClassLibrary.JSystem.Except.AddException(new Exception("END TransactionPrintInsert" + DateTime.Now.ToLongTimeString()));
        }

        public static void TransactionPrintInsertMonthly(ClassLibrary.JDataBase db, ClassLibrary.JMySQLDataBase MySqlDb)
        {
            ClassLibrary.JSystem.Except.AddException(new Exception("Start TransactionPrintInsertMonthly " + DateTime.Now.ToLongTimeString()));

            System.Globalization.PersianCalendar PersCal = new System.Globalization.PersianCalendar();
            if (PersCal.GetDayOfMonth(DateTime.Now) == 1)
            {
                int SqlLastInsertCode;
                db.setQuery(@"select ab.BUSNumber,convert(varchar(7),adp.[Date],120)YearMonth,cast((convert(varchar(7),adp.[Date],120)+'-01') as date)SMonth,
                                dateadd(day,-1,dateadd(month,1,cast((convert(varchar(7),adp.[Date],120)+'-01') as date)))EMonth
                                from AUTDailyPerformanceRportOnBus adp
                                left join AutBus ab on adp.BusCode = ab.Code
                                where adp.MonthlyPrint = 0
                                and ab.BUSNumber IS NOT NULL
                                group by ab.BUSNumber,convert(varchar(7),adp.[Date],120),cast((convert(varchar(7),adp.[Date],120)+'-01') as date)
                                order by SMonth desc");
                System.Data.DataTable DtDailyTicket = db.Query_DataTable();
                if (DtDailyTicket != null)
                {
                    if (DtDailyTicket.Rows.Count > 0)
                    {
                        BusManagment.JBusPrintReport TransactionPrint = new BusManagment.JBusPrintReport();
                        for (int i = 0; i < DtDailyTicket.Rows.Count; i++)
                        {

                            TransactionPrint.BusNumber = Convert.ToInt32(DtDailyTicket.Rows[i]["BusNumber"].ToString());
                            TransactionPrint.StartDate = Convert.ToDateTime(Convert.ToDateTime(DtDailyTicket.Rows[i]["SMonth"].ToString()).ToShortDateString() + " 00:00:00");
                            TransactionPrint.EndDate = Convert.ToDateTime(Convert.ToDateTime(DtDailyTicket.Rows[i]["EMonth"].ToString()).ToShortDateString() + " 23:59:59");
                            TransactionPrint.TicketCount = 0;
                            TransactionPrint.TicketSent = 0;
                            TransactionPrint.State = 0;
                            TransactionPrint.DailyCode = 0;
                            SqlLastInsertCode = TransactionPrint.Insert();

                            SavePrintInMySql(MySqlDb, SqlLastInsertCode,
                                Convert.ToInt32(DtDailyTicket.Rows[i]["BusNumber"].ToString()),
                                Convert.ToDateTime(Convert.ToDateTime(DtDailyTicket.Rows[i]["SMonth"].ToString()).ToShortDateString() + " 00:00:00"),
                                Convert.ToDateTime(Convert.ToDateTime(DtDailyTicket.Rows[i]["EMonth"].ToString()).ToShortDateString() + " 23:59:59"));

                            db.setQuery(@"update AUTDailyPerformanceRportOnBus set MonthlyPrint = 1 where BusCode = (select code from AutBus where BusNumber = " + DtDailyTicket.Rows[i]["BusNumber"].ToString() + @") and convert(varchar(7),[Date],120) = '" + DtDailyTicket.Rows[i]["YearMonth"].ToString() + @"'");
                            db.Query_Execute();
                        }
                    }
                }
            }

            ClassLibrary.JSystem.Except.AddException(new Exception("End TransactionPrintInsertMonthly " + DateTime.Now.ToLongTimeString()));
        }

        public static void TransactionPrintInsertDaily(ClassLibrary.JDataBase db, ClassLibrary.JMySQLDataBase MySqlDb)
        {
            ClassLibrary.JSystem.Except.AddException(new Exception("Start TransactionPrintInsertDailyMontly " + DateTime.Now.ToLongTimeString()));
            int SqlLastInsertCode;
            db.setQuery(@"select BusNumber,cast(startdate as date)FDate from AUTShiftDriver
							where DailyPrint = 0
							and cast(startdate as date) < cast(getdate() as date)
                            and BusNumber IS NOT NULL and LEN(BusNumber)=4 and BusNumber < 6999
							group by BusNumber,cast(startdate as date)
                            order by FDate desc");
            System.Data.DataTable DtDailyTicket = db.Query_DataTable();
            if (DtDailyTicket != null)
            {
                if (DtDailyTicket.Rows.Count > 0)
                {
                    BusManagment.JBusPrintReport TransactionPrint = new BusManagment.JBusPrintReport();
                    for (int i = 0; i < DtDailyTicket.Rows.Count; i++)
                    {

                        TransactionPrint.BusNumber = Convert.ToInt32(DtDailyTicket.Rows[i]["BusNumber"].ToString());
                        TransactionPrint.StartDate = Convert.ToDateTime(Convert.ToDateTime(DtDailyTicket.Rows[i]["FDate"].ToString()).ToShortDateString() + " 00:00:00");
                        TransactionPrint.EndDate = Convert.ToDateTime(Convert.ToDateTime(DtDailyTicket.Rows[i]["FDate"].ToString()).ToShortDateString() + " 23:59:59");
                        TransactionPrint.TicketCount = 0;
                        TransactionPrint.TicketSent = 0;
                        TransactionPrint.State = 0;
                        TransactionPrint.DailyCode = 0;
                        SqlLastInsertCode = TransactionPrint.Insert();

                        SavePrintInMySql(MySqlDb, SqlLastInsertCode,
                            Convert.ToInt32(DtDailyTicket.Rows[i]["BusNumber"].ToString()),
                            Convert.ToDateTime(Convert.ToDateTime(DtDailyTicket.Rows[i]["FDate"].ToString()).ToShortDateString() + " 00:00:00"),
                            Convert.ToDateTime(Convert.ToDateTime(DtDailyTicket.Rows[i]["FDate"].ToString()).ToShortDateString() + " 23:59:59"));

                        db.setQuery(@"update AUTShiftDriver set DailyPrint = 1 where BusNumber = " + DtDailyTicket.Rows[i]["BusNumber"].ToString() + @" and cast(startdate as date) = cast('" + DtDailyTicket.Rows[i]["FDate"].ToString() + @"' as date)");
                        db.Query_Execute();

                    }
                }
            }
            ClassLibrary.JSystem.Except.AddException(new Exception("End TransactionPrintInsertDailyMontly " + DateTime.Now.ToLongTimeString()));
        }

        public static void TransactionDailyPrintCheck(ClassLibrary.JDataBase db, ClassLibrary.JMySQLDataBase MySqlDb)
        {
            ClassLibrary.JSystem.Except.AddException(new Exception("Start TransactionDailyPrintCheck" + DateTime.Now.ToLongTimeString()));

            db.setQuery(@"select [Code],[BusNumber],[StartDate],[EndDate]
                            ,[TicketCount],[TicketSent],[State],
                            [GetTicket],[DailyCode],ISNULL([RequestCount] ,0)RequestCount
                            from AUTPrinterRporte 
                            where cast(StartDate as time) = '00:00:00' and cast(EndDate as time) = '23:59:59' and cast(StartDate as date) = cast(EndDate as date)
                            and State = 1 and DailyCode = 0 and GetTicket = 0 and StartDate < Dateadd(day,-2,GetDate())
                            and (BusNumber > 1000 and BusNumber < 7000)
                            Order By StartDate desc");
            System.Data.DataTable DtDailyPrint = db.Query_DataTable();
            if (DtDailyPrint != null)
            {
                if (DtDailyPrint.Rows.Count > 0)
                {
                    for (int i = 0; i < DtDailyPrint.Rows.Count; i++)
                    {
                        db.setQuery(@"select adp.Date,ab.BusNumber,Sum(Tcount)Tcount from AUTDailyPerformanceRportOnBus adp
                                        left join AutBus ab on ab.Code = adp.BusCode
                                        where adp.CardType = 0 and ab.BusNumber = " + DtDailyPrint.Rows[i]["BusNumber"].ToString() + @" and adp.Date = 
                                        cast('" + DtDailyPrint.Rows[i]["StartDate"].ToString() + @"' as date)
                                        group by adp.Date,ab.BusNumber");
                        System.Data.DataTable DtSumDailyTable = db.Query_DataTable();
                        if (DtSumDailyTable != null)
                        {
                            if (DtSumDailyTable.Rows.Count > 0)
                            {
                                if (Convert.ToInt32(DtSumDailyTable.Rows[0]["Tcount"].ToString()) == Convert.ToInt32(DtDailyPrint.Rows[i]["TicketCount"].ToString()))
                                {
                                    db.setQuery(@"Update AUTPrinterRporte set DailyCode = -3,RequestCount = 0 where Code = " + DtDailyPrint.Rows[i]["Code"].ToString());
                                    db.Query_Execute();
                                }
                                else if (Convert.ToInt32(DtSumDailyTable.Rows[0]["Tcount"].ToString()) > Convert.ToInt32(DtDailyPrint.Rows[i]["TicketCount"].ToString()))
                                {
                                    db.setQuery(@"Update AUTPrinterRporte set DailyCode = -2,RequestCount = IsNull(RequestCount,0) + 1 where Code = " + DtDailyPrint.Rows[i]["Code"].ToString());
                                    db.Query_Execute();
                                }
                                else if (Convert.ToInt32(DtSumDailyTable.Rows[0]["Tcount"].ToString()) < Convert.ToInt32(DtDailyPrint.Rows[i]["TicketCount"].ToString()))
                                {
                                    if (Convert.ToInt32(DtDailyPrint.Rows[i]["RequestCount"].ToString()) <= 2)
                                    {
                                        MySqlDb.setQuery(@"UPDATE `getdataticket` SET 
                                                                                            `state`=0,
                                                                                            `isSent`=1,
                                                                                            `GetTicket`=1
                                                                                            WHERE `Code` = " + DtDailyPrint.Rows[i]["Code"].ToString());
                                        MySqlDb.Query_Execute();

                                        db.setQuery(@"Update AUTPrinterRporte set DailyCode = -1,RequestCount = IsNull(RequestCount,0) + 1,GetTicket=1  where Code = " + DtDailyPrint.Rows[i]["Code"].ToString());
                                        db.Query_Execute();
                                    }
                                }
                            }
                        }
                    }
                }
            }

            ClassLibrary.JSystem.Except.AddException(new Exception("END TransactionDailyPrintCheck" + DateTime.Now.ToLongTimeString()));
        }

        public static bool DeleteDuplicatePrintInMySql(ClassLibrary.JMySQLDataBase mysqlDB)
        {
            mysqlDB.setQuery(@"delete from `getdataticket` where code in
                                (
                                select Code from(
                                SELECT a2.Code FROM `getdataticket` a1 inner join
                                `getdataticket` a2
                                on
                                a1.`busserial` = a2.`busserial`
                                and a1.Code<>a2.Code
                                and a1.StartDate<=a2.StartDate and a1.EndDate>=a2.EndDate
                                and time(a1.StartDate)<>'00:00:00'
                                and time(a1.Enddate)<>'23:59:59'
                                and a2.State=0
                                group by a2.Code
                                ) as a
                                )");
            return mysqlDB.Query_Execute() > 0 ? true : false;
        }

        public static bool DeleteDuplicatePrintInSqlServer(ClassLibrary.JDataBase DB)
        {
            DB.setQuery(@"delete from AUTPrinterRporte where code in
                            (
                            select Code from(
                            SELECT a2.Code FROM AUTPrinterRporte a1 inner join
                            AUTPrinterRporte a2
                            on
                            a1.BusNumber = a2.BusNumber
                            and a1.Code<>a2.Code
                            and a1.StartDate<=a2.StartDate and a1.EndDate>=a2.EndDate
                            and cast(a1.StartDate as time)<>'00:00:00'
                            and cast (a1.Enddate as time)<>'23:59:59'
                            and a2.State=0
                            group by a2.Code
                            ) as a
                            )");
            return DB.Query_Execute() > 0 ? true : false;
        }

        public static bool SavePrintInMySql(ClassLibrary.JMySQLDataBase mysqlDB, int Code, int BusNumber, DateTime StartDate, DateTime EndDate)
        {
            mysqlDB.setQuery(@"INSERT INTO `getdataticket`(`Code`, `busserial`, `state`, `startdate`, `enddate`, `isSent`, `RowCount`, `RowSent`) 
                               VALUES (" + Code + @"," + BusNumber + @",0,'" + StartDate.Year + "/" + StartDate.Month + @"/" + StartDate.Day + @" " + StartDate.Hour + @":" + StartDate.Minute + @":" + StartDate.Second + @"',
                               '" + EndDate.Year + "/" + EndDate.Month + "/" + EndDate.Day + @" " + EndDate.Hour + @":" + EndDate.Minute + @":" + EndDate.Second + @"',0,0,0)");
            return mysqlDB.Query_Execute() > 0 ? true : false;
        }

        public static bool GetMySqlData(ClassLibrary.JMySQLDataBase MySqlDB, int Code)
        {
            try
            {
                MySqlDB.setQuery("select * from `getdataticket` where `Code` = " + Code.ToString());
                MySqlDB.Query_DataTable();
                if (MySqlDB.datatable.Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            finally
            {
                MySqlDB.Dispose();
            }
        }

        public static bool GetMySqlData(ClassLibrary.JMySQLDataBase MySqlDB, int BusSerial, DateTime startdate, DateTime enddate)
        {
            try
            {
                MySqlDB.setQuery("select * from `getdataticket` where `busserial` = " + BusSerial + " and `startdate` = '" + startdate + "' and `enddate` = '" + enddate + "'");
                MySqlDB.Query_DataTable();
                if (MySqlDB.datatable.Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            finally
            {
                MySqlDB.Dispose();
            }
        }

        public static bool UpdatePrintInMySql(ClassLibrary.JMySQLDataBase mysqlDB, int Code, int BusNumber, DateTime StartDate, DateTime EndDate)
        {
            mysqlDB.setQuery(@"UPDATE `getdataticket` SET 
                                `busserial`=" + BusNumber + @",
                                `state`=0,
                                `startdate`='" + StartDate.Year + "/" + StartDate.Month + @"/" + StartDate.Day + @" " + StartDate.Hour + @":" + StartDate.Minute + @":" + StartDate.Second + @"',
                                `enddate`='" + EndDate.Year + "/" + EndDate.Month + "/" + EndDate.Day + @" " + EndDate.Hour + @":" + EndDate.Minute + @":" + EndDate.Second + @"',
                                `isSent`=0,
                                `RowCount`=0,
                                `RowSent`=0
                                WHERE `Code` = " + Code.ToString());
            return mysqlDB.Query_Execute() > 0 ? true : false;
        }

        public static bool UpdateInserPrintInDaily(ClassLibrary.JDataBase sqlDB, int Code)
        {
            sqlDB.setQuery(@"Update AUTDailyPerformanceRportOnBus set InsertPrintRequest = 1 where Code = " + Code);
            return sqlDB.Query_Execute() > 0 ? true : false;
        }

        public static bool UpdateInserPrintInShift(ClassLibrary.JDataBase sqlDB, int Code)
        {
            sqlDB.setQuery(@"Update AUTShiftDriver set InsertPrintRequest = 1 where Code = " + Code);
            return sqlDB.Query_Execute() > 0 ? true : false;
        }

        public static string GetWebQuery()
        {
            string PermitionSql = " and " + ClassLibrary.JPermission.getObjectSql("BusManagment.Transaction.JTicketTransactions.GetWebQuery", "ticket.BusCode");
            if (PermitionSql.Length < 5)
            {
                PermitionSql = "";
            }

            string CardTypePermitionSql = ClassLibrary.JPermission.getObjectSql("BusManagment.Card.JCards.GetDataTable", "Code");
            string FinalCardType = "";
            if (CardTypePermitionSql.Length < 5)
            {
                CardTypePermitionSql = "";
            }
            else
            {
                ClassLibrary.JDataBase mydb = new ClassLibrary.JDataBase();
                mydb.setQuery("Select Type From AutCardType Where " + CardTypePermitionSql);
                System.Data.DataTable DtCardType = mydb.Query_DataTable();
                FinalCardType = "and ticket.CardType in (" + String.Join(",", ClassLibrary.JDataBase.DataTableToStringtArray(DtCardType, "Type")) + ")";
            }

            return @"SELECT top 100   ticket.Code
                              ,bus.BUSNumber
                              ,ticket.LineNumber
                              ,ticket.TicketPrice
                              ,ticket.RemainPrice
                              ,ticket.EventDate
                              ,ticket.RecievedDate
                              ,ticket.DriverCardSerial
                              ,ticket.DriverPersonName
                              ,ticket.PassengerCardSerial
                              ,N'نامشخص' AS PassengerName
                        FROM   AUTTicketTransaction ticket
                               INNER JOIN AUTBus bus
                                    ON  bus.Code = ticket.BusCode
                                where 1 = 1 " + PermitionSql + @"
                                Order by ticket.Code desc";
        }


    }
}
