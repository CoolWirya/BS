using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsReports
{
    public partial class JBusPerformanceCalenderReportControl : System.Web.UI.UserControl
    {
        public string StrCalender = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                btnSave_Click(null, null);
            else
            {
                LoadYears();
                LoadMonth();
                LoadBus();
            }
        }

        public void LoadMonth()
        {
            cmbMount.SelectedValue = ClassLibrary.JDateTime.FarsiMonth(DateTime.Now);
        }

        public void LoadYears()
        {
            int CYear = Convert.ToInt32(ClassLibrary.JDateTime.FarsiYear(DateTime.Now));
            for (int i = CYear; i >= 1392; i--)
            {
                Telerik.Web.UI.RadComboBoxItem RCBI = new Telerik.Web.UI.RadComboBoxItem();
                RCBI.Value = i.ToString();
                RCBI.Text = i.ToString();
                cmbYears.Items.Add(RCBI);
            }
        }

        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            cmbBus.DataSource = dt;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }

        public void GetReport(int BusNumebr = 0, int Year = 0, int Mount = 0)
        {
            int NumOfDay = 0;
            if (Mount <= 6)
                NumOfDay = 31;
            else if (Mount > 6)
                NumOfDay = 30;

            DataTable DtBusNumber = WebClassLibrary.JWebDataBase.GetDataTable(@"select BusNumber From AutBus Where Code = " + BusNumebr);

            StrCalender = "";

            //            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@";WITH
            //                                                                            n AS (SELECT num = ROW_NUMBER() OVER (ORDER BY (SELECT 1)) FROM sys.all_columns a1 CROSS JOIN sys.all_columns a2),
            //                                                                            dt AS (SELECT [date] = DATEADD(day, n.num - 1, '2014/08/01') FROM n WHERE n.num BETWEEN 1 AND DATEDIFF(day, '2014/08/01', '2014/08/" + NumOfDay + @"') + 1)
            //                                                                        SELECT cast(dt.date as date)EnDate,dbo.DateFaToEn("+Year+@","+Mount+@",DATEPART(day,dt.date))LastEnDate,nt.* FROM dt
            //                                                                        left join
            //                                                                        (select ab.BusNumber BusNumber,cast(dbo.DateEnToFa(allt.Date) as nvarchar)Date,SUBSTRING(dbo.DateEnToFa(allt.Date),9,2)DayF,ISNULL(allt.TCount,0) as TicketCount,
            //                                                                        ISNULL(taeedt.TCount,0) TaeedTicketCount,
            //                                                                        ISNULL(Printt.TicketCount,0) ApplyTicketCount,ISNULL(paymentt.TCount,0) PaymentTicketCount,
            //                                                                        allt.FrontDoor,allt.BackDoor 
            //                                                                        from 
            //                                                                        (
            //                                                                        select max(adp.Code)Code,adp.BusCode,adp.Date,sum(adp.TCount)TCount,
            //																		max(cast(adp.FrontDoor as int))FrontDoor,max(cast(adp.BackDoor as int))BackDoor from AUTDailyPerformanceRportOnBus adp
            //                                                                        where adp.CardType = 0 and adp.Error = 0 and adp.Tcount > 0 and adp.TicketPrice > 0 and adp.Price > 0
            //                                                                        group by adp.BusCode,adp.Date
            //                                                                        ) allt
            //                                                                        left join
            //                                                                        (
            //                                                                        select max(adp.Code)Code,adp.BusCode,adp.Date,sum(adp.TCount)TCount from AUTDailyPerformanceRportOnBus adp
            //                                                                        where adp.CardType = 0 and adp.Error = 0 and adp.SetPrinter = 1 and adp.Tcount > 0
            //                                                                        and adp.TicketPrice > 0 and adp.Price > 0
            //                                                                        group by adp.BusCode,adp.Date
            //                                                                        ) taeedt on allt.BusCode = taeedt.BusCode and allt.Date = taeedt.Date
            //                                                                        left join
            //                                                                        (
            //                                                                        select BusNumber,Date,TicketCount from (select BusNumber,cast(startdate as date)Date,max(TicketCount)TicketCount from AUTPrinterRporte
            //                                                                        where DailyCode < 1 and TicketCount > 0 and cast(startdate as date) = cast(enddate as date) and ShiftDrivercode = 0
            //                                                                        group by BusNumber,cast(startdate as date))b
            //                                                                        )Printt on allt.BusCode = (select code from AUTBus where BusNumber = Printt.BusNumber) and allt.Date = Printt.Date
            //                                                                        left join 
            //                                                                        (
            //                                                                        select max(adp.Code)Code,adp.BusCode,adp.Date,sum(adp.TCount)TCount from AUTDailyPerformanceRportOnBus adp
            //                                                                        where adp.CardType = 0 and adp.Error = 0 and adp.SetPrinter = 1 and adp.DocumentCode > 0 and adp.Tcount > 0
            //                                                                        and adp.TicketPrice > 0 and adp.Price > 0
            //                                                                        group by adp.BusCode,adp.Date
            //                                                                        ) paymentt on allt.BusCode = paymentt.BusCode and allt.Date = paymentt.Date
            //                                                                        left join AUTBus ab on ab.Code = allt.BusCode
            //                                                                        left join AUTFleet af on af.Code = ab.FleetCode
            //                                                                        where allt.BusCode = " + BusNumebr + @"
            //                                                                        and (cast(substring(dbo.DateEnToFa(allt.Date),0,5) as int)=" + Year + @"
            //                                                                        and cast(substring(dbo.DateEnToFa(allt.Date),6,2) as int)=" + Mount + @"))nt
            //                                                                        on cast(datepart(day,dt.date) as int) = cast(nt.DayF as int)", false);

            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"
                                                ;WITH
                                                n AS (SELECT num = ROW_NUMBER() OVER (ORDER BY (SELECT 1)) FROM sys.all_columns a1 CROSS JOIN sys.all_columns a2),
                                                dt AS (SELECT [date] = DATEADD(day, n.num - 1, '2014/08/01') FROM n WHERE n.num BETWEEN 1 AND DATEDIFF(day, '2014/08/01', '2014/08/" + NumOfDay + @"') + 1)
                                                SELECT cast(dt.date as date)EnDate,dbo.DateFaToEn(" + Year + @"," + Mount + @",DATEPART(day,dt.date))LastEnDate,nt.* FROM dt
                                                left join

                                                (select ISNULL(tbl1.BusNumber,0)BusNumber,tbl1.Date,tbl1.DayF,ISNULL(tbl1.TicketCount,0)TicketCount,tbl1.TaeedTicketCount,tbl1.ApplyTicketCount,tbl1.PaymentTicketCount
                                                ,tbl1.FrontDoor,tbl1.BackDoor,tbl1.BusFailureCode
                                                from 
                                                (select ISNULL(abp.BusNumber,0) BusNumber,cast(dbo.DateEnToFa(abp.Date) as nvarchar)Date
	                                                ,SUBSTRING(dbo.DateEnToFa(abp.Date),9,2)DayF,max(abp.TicketCount)TicketCount,max(TaeedTicketCount)TaeedTicketCount,
	                                                max(ApplyTicketCount)ApplyTicketCount,max(PaymentTicketCount)PaymentTicketCount,max(FrontDoor)FrontDoor,max(BackDoor)BackDoor,
	                                                MAX(ISNULL(abf.BusFailureCode,0))BusFailureCode
	                                                from AUTBusPerformanceCalenderReport abp
	                                                left join AutBus ab on ab.BUSNumber = abp.BusNumber
	                                                left join AUTBusFailure abf on abf.BusCode = ab.Code and cast(abf.Date as date) = cast(abp.Date as date)
	                                                where   (cast(substring(dbo.DateEnToFa(abp.Date),0,5) as int)=" + Year + @"
                                                    and cast(substring(dbo.DateEnToFa(abp.Date),6,2) as int)=" + Mount + @")
	                                                and abp.busNumber = " + DtBusNumber.Rows[0]["BusNumber"].ToString() + @"
	                                                group by abp.BusNumber,cast(dbo.DateEnToFa(abp.Date) as nvarchar),SUBSTRING(dbo.DateEnToFa(abp.Date),9,2),ab.LastLineNumber,abp.Date
                                                )tbl1)nt on cast(datepart(day,dt.date) as int) = cast(nt.DayF as int)", false);

            if (Dt != null & Dt.Rows.Count > 0)
            {
                DateTime FirstDayDate = Convert.ToDateTime(Dt.Rows[0]["LastEnDate"].ToString());
                int DayOfW = (int)FirstDayDate.DayOfWeek;
                if (DayOfW != 6)
                {
                    for (int i = 0; i < (DayOfW + 1); i++)
                    {
                        StrCalender += "<div style='float:right;background-color:white;color:white;width:122px;height:160px;text-align:center'></div>";
                    }
                }
            }


            // DataTable NewDtAfterAddDays = AddNoTransactionDateinToDataTdable(Dt, NumOfDay);
            // Dt = null;
            // Dt = NewDtAfterAddDays;

            string BgColor = "red", TextColor = "black", TransactionDetaile = "", FrontDoorStr = "", BackDoorStr = "";
            int Counter = 1, DayFNumber = 0, CellZeroNumber = 0, MaxDateCounter = 1;
            int BNumber = 0;
            DateTime MaxDate = DateTime.Now;
            if (Dt != null & Dt.Rows.Count > 0)
            {
                for (int i = 0; i < NumOfDay; i++)
                {
                    if (i < Dt.Rows.Count)
                    {
                        //  BNumber = Dt.Rows[i]["BusNumber"].ToString();
                        if (int.TryParse(Dt.Rows[i]["BusNumber"].ToString(), out BNumber))
                        {
                            FrontDoorStr = Dt.Rows[i]["FrontDoor"].ToString();
                            BackDoorStr = Dt.Rows[i]["BackDoor"].ToString();

                            TransactionDetaile = @"<div style='clear:both;height:5px'></div>
                                    تایید شده : " + Dt.Rows[i]["TaeedTicketCount"].ToString() + @"
                                    <div style='clear:both;height:5px'></div>
                                    پرداخت شده : " + Dt.Rows[i]["PaymentTicketCount"].ToString() + @"
                                    <div style='clear:both;height:5px'></div>
                                    پرینت : " + Dt.Rows[i]["ApplyTicketCount"].ToString() + @"
                                    <div style='clear:both;height:5px'></div>
                                    تعداد درب جلو : " + FrontDoorStr + @"
                                    <div style='clear:both;height:5px'></div>
                                    تعداد درب عقب : " + BackDoorStr + @"
                                    <div style='clear:both;height:5px'></div>";

                            int TCount, TaeedTCount, ApplyTCount, PaymnetTCount, FrontDoor, BackDoor;
                            TCount = Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString());
                            TaeedTCount = Convert.ToInt32(Dt.Rows[i]["TaeedTicketCount"].ToString());
                            ApplyTCount = Convert.ToInt32(Dt.Rows[i]["ApplyTicketCount"].ToString());
                            PaymnetTCount = Convert.ToInt32(Dt.Rows[i]["PaymentTicketCount"].ToString());
                            FrontDoor = Convert.ToInt32(Dt.Rows[i]["FrontDoor"].ToString());
                            BackDoor = Convert.ToInt32(Dt.Rows[i]["BackDoor"].ToString());


                            int AllTicketDoor;
                            AllTicketDoor = (FrontDoor) + (BackDoor);
                            if ((ApplyTCount > 0) & (TCount > 0) & (TCount - ApplyTCount) >= -5 & (TCount - ApplyTCount) <= 5)
                            {
                                BgColor = "#3aa807";
                                TextColor = "white";
                            }
                            else if ((TCount > 0) & (ApplyTCount > 0) & (AllTicketDoor == TCount) & (TCount > ApplyTCount))
                            {
                                BgColor = "#3aa807";
                                TextColor = "white";
                            }
                            else if (TCount == 0)
                            {
                                BgColor = "#9b9797";
                                TextColor = "white";
                                TransactionDetaile = @"<div style='clear:both;height:5px'></div>
                                           دلیل عدم کارکرد : 
                                           <div style='clear:both;height:5px'></div>
                                           " + GetBusFailure(Convert.ToInt32(Dt.Rows[i]["BusNumber"].ToString()), Dt.Rows[i]["Date"].ToString()) + @"
                                           <div style='clear:both;height:5px'></div>
                                           تعداد درب جلو : 0
                                           <div style='clear:both;height:5px'></div>
                                           تعداد درب عقب : 0
                                           <div style='clear:both;height:5px'></div>";
                            }
                            else if (ApplyTCount == 0)
                            {
                                BgColor = "#ffd800";
                                TextColor = "black";
                            }
                            else if ((TCount == TaeedTCount) & (TCount == ApplyTCount) & (TCount < PaymnetTCount))
                            {
                                BgColor = "#0094ff";
                                TextColor = "white";
                            }
                            else if ((TCount == TaeedTCount) & (TCount == ApplyTCount) & (TCount == PaymnetTCount))
                            {
                                BgColor = "#3aa807";
                                TextColor = "white";
                            }
                            else if ((TCount == TaeedTCount) & (TCount == ApplyTCount))
                            {
                                BgColor = "#15d42b";
                                TextColor = "black";
                            }
                            else if (TCount == ApplyTCount)
                            {
                                BgColor = "#00ff21";
                                TextColor = "black";
                            }
                            else if (TCount > ApplyTCount)
                            {
                                BgColor = "#ff0000";
                                TextColor = "black";
                            }
                            else if (TCount < ApplyTCount)
                            {
                                BgColor = "#60f6c3";
                                TextColor = "black";
                            }
                            else if ((TaeedTCount == 0) | (TaeedTCount < TCount))
                            {
                                BgColor = "#ca8383";
                                TextColor = "white";
                            }


//                            if (Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString()) > 0 & 
//                                (Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString()) - Convert.ToInt32(Dt.Rows[i]["ApplyTicketCount"].ToString())) >= -5 &
//                                (Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString()) - Convert.ToInt32(Dt.Rows[i]["ApplyTicketCount"].ToString())) <= 5)
//                            {
//                                BgColor = "#3aa807";
//                                TextColor = "white";
//                            }
//                            else if (Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString()) > 0 & 
//                                (Convert.ToInt32(Dt.Rows[i]["FrontDoor"].ToString()) + Convert.ToInt32(Dt.Rows[i]["BackDoor"].ToString())) == Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString())
//                                & Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString()) > Convert.ToInt32(Dt.Rows[i]["ApplyTicketCount"].ToString()))
//                            {
//                                BgColor = "#3aa807";
//                                TextColor = "white";
//                            }
//                            else if (Convert.ToInt32(Dt.Rows[i]["FrontDoor"].ToString()) == 0 || Convert.ToInt32(Dt.Rows[i]["BackDoor"].ToString()) == 0)
//                            {
//                                BgColor = "#75cf7a";
//                                TextColor = "white";
//                            }
//                            else if (Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString()) == 0)
//                            {
//                                BgColor = "#9b9797";
//                                TextColor = "white";
//                                TransactionDetaile = @"<div style='clear:both;height:5px'></div>
//                                           دلیل عدم کارکرد : 
//                                           <div style='clear:both;height:5px'></div>
//                                           " + GetBusFailure(Convert.ToInt32(Dt.Rows[i]["BusNumber"].ToString()), Dt.Rows[i]["Date"].ToString()) + @"
//                                           <div style='clear:both;height:5px'></div>
//                                           تعداد درب جلو : 0
//                                           <div style='clear:both;height:5px'></div>
//                                           تعداد درب عقب : 0
//                                           <div style='clear:both;height:5px'></div>";
//                            }
//                            else if (Convert.ToInt32(Dt.Rows[i]["TaeedTicketCount"].ToString()) == 0 ||
//                                Convert.ToInt32(Dt.Rows[i]["TaeedTicketCount"].ToString()) < Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString()))
//                            {
//                                BgColor = "#ca8383";
//                                TextColor = "white";
//                            }
//                            else if (Convert.ToInt32(Dt.Rows[i]["PaymentTicketCount"].ToString()) == 0 ||
//                                Convert.ToInt32(Dt.Rows[i]["PaymentTicketCount"].ToString()) < Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString()))
//                            {
//                                BgColor = "#0094ff";
//                                TextColor = "white";
//                            }
//                            else if (Convert.ToInt32(Dt.Rows[i]["ApplyTicketCount"].ToString()) == 0)
//                            {
//                                BgColor = "#ffd800";
//                                TextColor = "black";
//                            }
//                            else if (Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString()) == Convert.ToInt32(Dt.Rows[i]["TaeedTicketCount"].ToString()) &
//                                Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString()) == Convert.ToInt32(Dt.Rows[i]["PaymentTicketCount"].ToString()) &
//                                Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString()) == Convert.ToInt32(Dt.Rows[i]["ApplyTicketCount"].ToString()))
//                            {
//                                BgColor = "#3aa807";
//                                TextColor = "white";
//                            }
//                            else if (Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString()) == Convert.ToInt32(Dt.Rows[i]["TaeedTicketCount"].ToString()) &
//                                Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString()) == Convert.ToInt32(Dt.Rows[i]["ApplyTicketCount"].ToString()))
//                            {
//                                BgColor = "#15d42b";
//                                TextColor = "black";
//                            }
//                            else if (Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString()) == Convert.ToInt32(Dt.Rows[i]["ApplyTicketCount"].ToString()))
//                            {
//                                BgColor = "#00ff21";
//                                TextColor = "black";
//                            }
//                            else if (Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString()) > Convert.ToInt32(Dt.Rows[i]["ApplyTicketCount"].ToString()))
//                            {
//                                BgColor = "#ff0000";
//                                TextColor = "white";
//                            }
//                            else if (Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString()) < Convert.ToInt32(Dt.Rows[i]["ApplyTicketCount"].ToString()))
//                            {
//                                BgColor = "#60f6c3";
//                                TextColor = "black";
//                            }
                        }

                        //DayFNumber = Convert.ToInt32(Dt.Rows[i]["DayF"].ToString());
                        if (int.TryParse(Dt.Rows[i]["BusNumber"].ToString(), out BNumber))
                        {
                            CellZeroNumber++;
                            StrCalender += @"<div style='float:right;background-color:" + BgColor + @";color:" + TextColor + @";width:120px;height:160px;text-align:center;border : 1px solid black'>
                                    <div style='clear:both;height:5px'></div>
                                    " + Dt.Rows[i]["BusNumber"].ToString() + @"
                                    <div style='clear:both;height:5px'></div>
                                    " + Dt.Rows[i]["Date"].ToString() + @"
                                    <div style='clear:both;height:5px'></div>
                                    کل : " + Dt.Rows[i]["TicketCount"].ToString() + @"
                                    " + TransactionDetaile + @"
                                </div>";
                            // MaxDate = ClassLibrary.JDateTime.GregorianDate(Dt.Rows[i]["Date"].ToString());
                        }
                        else
                        {

                            //if (MaxDate == ClassLibrary.JDateTime.GregorianDate(Dt.Rows[i]["Date"].ToString()).AddDays(-1))
                            //{
                            //    MaxDateCounter++;
                            //    MaxDate = ClassLibrary.JDateTime.GregorianDate(Dt.Rows[i]["Date"].ToString()).AddDays(-MaxDateCounter);
                            //}
                            //else
                            //{
                            //    MaxDate = ClassLibrary.JDateTime.GregorianDate(Dt.Rows[i]["Date"].ToString()).AddDays(-1);
                            //}

                            //CellZeroNumber++;
                            //Counter += 1;
                            //i = i - 1;
                            //if (i < 0)
                            //    i = 0;
                            try
                            {
                                StrCalender += @"<div style='float:right;background-color:#9b9797;color:white;width:120px;height:160px;text-align:center;border : 1px solid black'>
                                    <div style='clear:both;height:5px'></div>
                                    " + DtBusNumber.Rows[0]["BusNumber"].ToString() + @"
                                    <div style='clear:both;height:5px'></div>
                                    " + ClassLibrary.JDateTime.FarsiDate(Convert.ToDateTime(Dt.Rows[i]["LastEnDate"].ToString())).ToString() + @"
                                    <div style='clear:both;height:5px'></div>
                                    کل : 0
                                    <div style='clear:both;height:5px'></div>
                                           دلیل عدم کارکرد : 
                                    <div style='clear:both;height:5px'></div>
                                    " + GetBusFailure(Convert.ToInt32(DtBusNumber.Rows[0]["BusNumber"].ToString()), ClassLibrary.JDateTime.FarsiDate(Convert.ToDateTime(Dt.Rows[i]["LastEnDate"].ToString())).ToString()) + @"
                                    <div style='clear:both;height:5px'></div>
                                </div>";
                            }
                            catch
                            {
                                StrCalender += @"<div style='float:right;background-color:#9b9797;color:white;width:120px;height:160px;text-align:center;border : 1px solid black'>
                                    <div style='clear:both;height:5px'></div>
                                    " + Dt.Rows[0]["BusNumber"].ToString() + @"
                                    <div style='clear:both;height:5px'></div>
                                    " + ClassLibrary.JDateTime.FarsiDate(DateTime.Now).ToString() + @"
                                    <div style='clear:both;height:5px'></div>
                                    کل : 0
                                    <div style='clear:both;height:5px'></div>
                                           دلیل عدم کارکرد : 
                                    <div style='clear:both;height:5px'></div>
                                    " + GetBusFailure(0, ClassLibrary.JDateTime.FarsiDate(DateTime.Now).ToString()) + @"
                                    <div style='clear:both;height:5px'></div>
                                </div>";
                            }
                        }
                    }
                }

                //                for (int ZC = 0; ZC < (NumOfDay - CellZeroNumber); ZC++)
                //                {
                //                    StrCalender += @"<div style='float:right;background-color:#9b9797;color:white;width:120px;height:120px;text-align:center;border : 1px solid black'>
                //                                    <div style='clear:both;height:5px'></div>
                //                                    " + Dt.Rows[0]["BusNumber"].ToString() + @"
                //                                    <div style='clear:both;height:5px'></div>
                //                                    " + ClassLibrary.JDateTime.FarsiDate(MaxDate.AddDays(ZC)) + @"
                //                                    <div style='clear:both;height:5px'></div>
                //                                    کل : 0
                //                                    <div style='clear:both;height:5px'></div>
                //                                           دلیل عدم کارکرد : 
                //                                    <div style='clear:both;height:5px'></div>
                //                                    " + GetBusFailure(Convert.ToInt32(Dt.Rows[0]["BusNumber"].ToString()), ClassLibrary.JDateTime.FarsiDate(MaxDate.AddDays(ZC))) + @"</div>";
                //                }
                StrCalender += "<div style='clear:both'></div>";
                //                Counter = 1;
                //                CellZeroNumber = 0;

            }
        }

        public string GetBusFailure(int BusNumber, string Date)
        {
            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select top 1 sf.name FailName from AUTBusFailure abf
                                                                        left join subdefine sf on sf.Code = abf.BusFailureCode
                                                                        where abf.BusCode = (select Code from AutBus where BusNumber = " + BusNumber + @") 
                                                                        and cast(abf.[Date] as date) = '" + ClassLibrary.JDateTime.GregorianDate(Date).ToShortDateString() + @"' 
                                                                        order by abf.InsertDate desc");
            if (Dt != null & Dt.Rows.Count > 0)
            {
                return Dt.Rows[0]["FailName"].ToString();
            }
            else
            {
                return "ثبت نشده است";
            }
        }

        public DataTable AddNoTransactionDateinToDataTdable(DataTable Dt, int NumOfDay)
        {
            int DateCounter = 0;
            for (int i = 0; i < NumOfDay; i++)
            {
                if ((i + 1) != Convert.ToInt32(Dt.Rows[i]["DayF"].ToString()))
                {
                    for (int j = 0; j < (Convert.ToInt32(Dt.Rows[i]["DayF"].ToString()) - (i + 1)); j++)
                    {
                        DateCounter++;
                        DataRow dr = Dt.NewRow();
                        dr[0] = Dt.Rows[0]["BusNumber"].ToString();
                        dr[1] = ClassLibrary.JDateTime.FarsiDate(ClassLibrary.JDateTime.GregorianDate(Dt.Rows[i - 1]["Date"].ToString()).AddDays(DateCounter)).ToString();
                        dr[2] = ClassLibrary.JDateTime.FarsiDayInMonth(ClassLibrary.JDateTime.GregorianDate(ClassLibrary.JDateTime.FarsiDate(ClassLibrary.JDateTime.GregorianDate(Dt.Rows[i - 1]["Date"].ToString()).AddDays(DateCounter)).ToString()));
                        dr[3] = 0;
                        dr[4] = 0;
                        dr[5] = 0;
                        dr[6] = 0;
                        Dt.Rows.InsertAt(dr, i);
                    }
                    DateCounter = 0;
                }
            }
            return Dt;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // try
            //   {
            GetReport(Convert.ToInt32(cmbBus.SelectedValue), Convert.ToInt32(cmbYears.SelectedValue), Convert.ToInt32(cmbMount.SelectedValue));
            // }
            // catch
            // { }
        }
    }
}