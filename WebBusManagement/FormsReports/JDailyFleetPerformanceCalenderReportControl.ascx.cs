using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsReports
{
    public partial class JDailyFleetPerformanceCalenderReportControl : System.Web.UI.UserControl
    {
        public string StrCalender = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //btnSave_Click(null, null);
                //LoadFromBus();
                //LoadToBus();
                LoadYears();
                LoadMonth();
                LoadZones();
                LoadLines();
                LoadBusOwner();
                LoadFleets();

                ////// Default date for date and time controlers dteControlFrom set to today, dteControlTo set to tomorrow
                ((WebControllers.MainControls.Date.JDateControl)dteControlFrom).SetDate(ClassLibrary.JDateTime.Now().AddDays(-1));
                ((WebControllers.MainControls.Date.JDateControl)dteControlTo).SetDate(ClassLibrary.JDateTime.Now());
            }
            AllBusPerformanceCalender.Value = WebClassLibrary.JDataManager.EncryptString("WebBusManagement.FormsReports.JDailyFleetPerformanceCalenderReportControl.SaveTrnsactionPrintRequest");
            AllBusPerformanceCalenderGetReport.Value = WebClassLibrary.JDataManager.EncryptString("WebBusManagement.FormsReports.JDailyFleetPerformanceCalenderReportControl.GetReportJquery");
        }


        //////
        /// <summary>
        /// Raise when a radiobutton checkec change.
        /// </summary>
        /// <param name="sender">radiobutton that raised event.</param>
        /// <param name="e">Some info about Raised event</param>
        protected void rdbYearMonth_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;
            if (rdb.Checked == false)
                return;
            if (rdb == rdbCustomDate)
            {
                rdbYearMonth.Checked = false;
                pnlCustomDateTime.Visible = !(pnlYearMonth.Visible = false);
            }
            else if (rdb == rdbYearMonth)
            {
                rdbCustomDate.Checked = false;
                pnlCustomDateTime.Visible = !(pnlYearMonth.Visible = true);
            }
        }

        public void LoadFleets()
        {
            DataTable dt = BusManagment.Fleet.JFleets.GetDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), NameWithCode = v["NameWithCode"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, NameWithCode = "0 - همه" });
            cmbFleets.DataSource = p;
            cmbFleets.DataTextField = "NameWithCode";
            cmbFleets.DataValueField = "Code";
            cmbFleets.DataBind();
            if (cmbFleets.Items.Count > 1)
            {
                cmbFleets.SelectedIndex = 1;
            }
        }

        public void LoadZones()
        {
            DataTable dt = BusManagment.Zone.JZones.GetDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), NameWithCode = v["NameWithCode"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, NameWithCode = "0 - همه" });
            cmbZone.DataSource = p;
            cmbZone.DataTextField = "NameWithCode";
            cmbZone.DataValueField = "Code";
            cmbZone.DataBind();
        }

        public void LoadLines()
        {
            DataTable dt = BusManagment.Line.JLines.GetWebDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), LineNumberWithCode = v["LineNumberWithCode"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, LineNumberWithCode = "0 - همه" });
            cmbLine.DataSource = p;
            cmbLine.DataTextField = "LineNumberWithCode";
            cmbLine.DataValueField = "Code";
            cmbLine.DataBind();
        }

        public void LoadBusOwner()
        {
            DataTable dt = BusManagment.Bus.JBusOwners.GetBusOwners();
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), OwnerWithCode = v["OwnerWithCode"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, OwnerWithCode = "0 - همه" });
            cmbBusOwner.DataSource = p;
            cmbBusOwner.DataTextField = "OwnerWithCode";
            cmbBusOwner.DataValueField = "Code";
            cmbBusOwner.DataBind();
        }

        //public void LoadFromBus()
        //{
        //    DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
        //    cmbFromBus.DataSource = dt;
        //    cmbFromBus.DataTextField = "BUSNumber";
        //    cmbFromBus.DataValueField = "Code";
        //    cmbFromBus.DataBind();
        //}

        //public void LoadToBus()
        //{
        //    DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
        //    cmbToBus.DataSource = dt;
        //    cmbToBus.DataTextField = "BUSNumber";
        //    cmbToBus.DataValueField = "Code";
        //    cmbToBus.DataBind();
        //}

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

        // int Year = 0, int Mount = 0, int Zone = 0, int Line = 0, int OwnerCode = 0 , DateTime From , DateTime To , int rdTransactionType , bool rdbYearMonth
        public string[] GetReportJquery(string[] param)
        {
            string StrCalender = "";
            StrCalender = GetReportJQ(Convert.ToInt32(param[0]), Convert.ToInt32(param[1]), Convert.ToInt32(param[2])
                , Convert.ToInt32(param[3]), Convert.ToInt32(param[4]), Convert.ToDateTime(DateTime.Now)
                , Convert.ToDateTime(DateTime.Now), Convert.ToInt32(param[7]), Convert.ToBoolean(param[8]), Convert.ToInt32(param[9]));
            return new string[] { StrCalender };
        }

        public string GetReportJQ(int Year = 0, int Mount = 0, int Zone = 0, int Line = 0, int OwnerCode = 0, DateTime? dteControlFromDate = null, DateTime? dteControlToDate = null, int rdTransactionType = 0, bool rdbYearMonth = false, int Fleets = 0)
        {
            string StrCalender = "";

            DateTime StartDate = DateTime.Now, EndDate = DateTime.Now;
            if (rdbYearMonth)
            {
                StartDate = ClassLibrary.JDateTime.GregorianDate(Year.ToString() + "/" + Mount.ToString() + "/" + "1", "00:00:00");
                if (Mount <= 6)
                    EndDate = ClassLibrary.JDateTime.GregorianDate(Year.ToString() + "/" + Mount.ToString() + "/" + "31", "23:59:59");
                else if (Mount > 6 & Mount < 12)
                    EndDate = ClassLibrary.JDateTime.GregorianDate(Year.ToString() + "/" + Mount.ToString() + "/" + "30", "23:59:59");
                else if (Mount == 12)
                    EndDate = ClassLibrary.JDateTime.GregorianDate(Year.ToString() + "/" + Mount.ToString() + "/" + "29", "23:59:59");
            }
            else
            {
                StartDate = Convert.ToDateTime(dteControlFromDate.Value.ToShortDateString() + " 00:00:00");
                EndDate = Convert.ToDateTime(dteControlToDate.Value.ToShortDateString() + " 23:59:59");
            }

            int NumOfDay = 0;
            if (Mount <= 6)
                NumOfDay = 31;
            else if (Mount > 6)
                NumOfDay = 30;

            ClassLibrary.JDataBase Dbs = new ClassLibrary.JDataBase();

            string FWhereStr = "", OwnerWhereStr = "";
            if (Fleets > 0)
                FWhereStr += " and FleetCode = " + Fleets + " ";
            if (Line > 0)
                FWhereStr += " and LastLineNumber = " + Line;
            if (Zone > 0)
                FWhereStr += " and LastLineNumber in (select LineNumber from AutLine where ZoneCode = " + Zone + ")";
            if (OwnerCode > 0)
                OwnerWhereStr += @" and BusNumber in (select a.BUSNumber from AUTBus a left join (select * from AUTBusOwner where IsActive = 1) b on a.Code = b.BusCode 
                                    where b.CodePerson is not null and b.CodePerson = " + OwnerCode + @") ";


            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"
                                                ;WITH
                                                n AS (SELECT num = ROW_NUMBER() OVER (ORDER BY (SELECT 1)) FROM sys.all_columns a1 CROSS JOIN sys.all_columns a2),
                                                dt AS (SELECT [date] = DATEADD(day, n.num - 1, '2014/08/01') FROM n WHERE n.num BETWEEN 1 AND DATEDIFF(day, '2014/08/01', '2014/08/" + NumOfDay + @"') + 1)
                                                SELECT cast(dt.date as date)EnDate,dbo.DateFaToEn(" + Year + @"," + Mount + @",DATEPART(day,dt.date))LastEnDate,nt.Date,dbo.DateEnToFa(nt.Date)FDate
                                                ,isnull(nt.DayF,0)DayF,
                                                isnull(nt.TicketCount,0)TicketCount,
												isnull(nt.TaeedTicketCount,0)TaeedTicketCount,isnull(nt.ApplyTicketCount,0)ApplyTicketCount,isnull(nt.PaymentTicketCount,0)PaymentTicketCount FROM dt
                                                left join

                                                (
                                                select abp.Date,SUBSTRING(dbo.DateEnToFa(abp.Date),9,2)DayF,sum(abp.TicketCount)TicketCount,sum(abp.TaeedTicketCount)TaeedTicketCount,
                                                sum(abp.ApplyTicketCount)ApplyTicketCount,sum(abp.PaymentTicketCount)PaymentTicketCount from AUTBusPerformanceCalenderReport abp
                                                where   (cast(substring(dbo.DateEnToFa(abp.Date),0,5) as int)=" + Year + @"
                                                and cast(substring(dbo.DateEnToFa(abp.Date),6,2) as int)=" + Mount + @")
                                                and BusNumber in (select BusNumber from AUTBus where 1 = 1 " + FWhereStr + @")
                                                " + OwnerWhereStr + @"
                                                group by abp.Date
                                                )nt on cast(datepart(day,dt.date) as int) = cast(nt.DayF as int)
                                                order by LastEnDate", false);

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
                        //BNumber = c Dt.Rows[i]["DayF"].ToString();
                        if (int.TryParse(Dt.Rows[i]["DayF"].ToString(), out BNumber) && BNumber > 0)
                        {


                            TransactionDetaile = @"<div style='clear:both;height:5px'></div>
                                    تایید شده : " + Dt.Rows[i]["TaeedTicketCount"].ToString() + @"
                                    <div style='clear:both;height:5px'></div>
                                    پرداخت شده : " + Dt.Rows[i]["PaymentTicketCount"].ToString() + @"
                                    <div style='clear:both;height:5px'></div>
                                    پرینت : " + Dt.Rows[i]["ApplyTicketCount"].ToString() + @"
                                    <div style='clear:both;height:5px'></div>";

                            int TCount, TaeedTCount, ApplyTCount, PaymnetTCount, FrontDoor, BackDoor;
                            TCount = Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString());
                            TaeedTCount = Convert.ToInt32(Dt.Rows[i]["TaeedTicketCount"].ToString());
                            ApplyTCount = Convert.ToInt32(Dt.Rows[i]["ApplyTicketCount"].ToString());
                            PaymnetTCount = Convert.ToInt32(Dt.Rows[i]["PaymentTicketCount"].ToString());


                            //int AllTicketDoor;
                            //AllTicketDoor = (FrontDoor) + (BackDoor);
                            if ((ApplyTCount > 0) & (TCount > 0) & (TCount - ApplyTCount) >= -5 & (TCount - ApplyTCount) <= 5)
                            {
                                BgColor = "#3aa807";
                                TextColor = "white";
                            }
                            else if ((TCount > 0) & (ApplyTCount > 0) & (TCount > ApplyTCount))
                            {
                                BgColor = "#3aa807";
                                TextColor = "white";
                            }
                            else if (TCount == 0)
                            {
                                BgColor = "#9b9797";
                                TextColor = "white";
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

                            // if (int.TryParse(Dt.Rows[i]["BusNumber"].ToString(), out BNumber))
                            //  {
                            CellZeroNumber++;
                            StrCalender += @"<div style='float:right;background-color:" + BgColor + @";color:" + TextColor + @";width:120px;height:160px;text-align:center;border : 1px solid black'>
                                    <div style='clear:both;height:5px'></div>
                                    " + Dt.Rows[i]["FDate"].ToString() + @"
                                    <div style='clear:both;height:5px'></div>
                                    کل : " + Dt.Rows[i]["TicketCount"].ToString() + @"
                                    " + TransactionDetaile + @"
                                </div>";
                        }
                        // }
                    }
                }

                StrCalender += "<div style='clear:both'></div>";


            }
            return StrCalender;

        }



        public string GetReport(int Year = 0, int Mount = 0, int Zone = 0, int Line = 0, int OwnerCode = 0, DateTime? dteControlFromDate = null, DateTime? dteControlToDate = null, int rdTransactionType = 0, bool rdbYearMonth = false)
        {
            string StrCalender = "";
            int NumOfDay = 0;
            if (Mount <= 6)
                NumOfDay = 31;
            else if (Mount > 6)
                NumOfDay = 30;

            StrCalender = "";

            StrCalender += "<div style='float:right;background-color:Yellow;color:Black;width:40px;height:20px;text-align:center;border : 1px solid black ; border-left:none'>ردیف</div>";
            StrCalender += "<div style='float:right;background-color:Yellow;color:Black;width:40px;height:20px;text-align:center;border : 1px solid black ; border-left:none'>خط</div>";
            StrCalender += "<div style='float:right;background-color:Yellow;color:Black;width:40px;height:20px;text-align:center;border : 1px solid black ; border-left:none'>اتوبوس</div>";
            for (int DayN = 1; DayN <= NumOfDay; DayN++)
            {
                StrCalender += "<div style='float:right;background-color:Yellow;color:Black;width:40px;height:20px;text-align:center;border : 1px solid black; border-left:none'>" + DayN + @"</div>";
            }
            StrCalender += "<div style='float:right;background-color:Yellow;color:Black;width:40px;height:20px;text-align:center;border : 1px solid black ; border-left:none'>مجموع</div>";
            StrCalender += "<div style='clear:both'></div>";

            string DateWhere = "";
            if (rdbYearMonth)
            {
                DateWhere = @" substring(dbo.DateEnToFa(abp.Date),0,5)=" + Year + @" 
                              and substring(dbo.DateEnToFa(abp.Date),6,2)=" + Mount + @" ";
            }
            else
            {
                DateWhere = @" abp.Date Between '" + dteControlFromDate.Value.ToShortDateString() + @" 00:00:00' and '" + dteControlToDate.Value.ToShortDateString() + @" 23:59:59' ";
            }
            string BusWhere = "";
            if (Zone > 0)
                BusWhere += " and Al.ZoneCode = " + Zone;
            if (Line > 0)
                BusWhere += " and Al.Code = " + Line;
            if (OwnerCode > 0)
                BusWhere += " and ab.Code in (select BusCode from AutBusOwner where CodePerson = " + OwnerCode + ") ";
            DataTable DtBus = WebClassLibrary.JWebDataBase.GetDataTable(@"select AUTBusPerformanceCalenderReport.Busnumber from AUTBusPerformanceCalenderReport  
                                                                            left join AutBus ab on ab.BUSNumber = AUTBusPerformanceCalenderReport.Busnumber
                                                                            left join AutLine al on al.LineNumber = ab.LastLineNumber
                                                                            where " + DateWhere.Replace("abp.", " ") + @"
                                                                            and len(ab.busnumber)=4 and ab.busnumber > 1000 and ab.busnumber < 6999
																			and ab.FleetCode = 1000001
                                                                            " + BusWhere + @"
                                                                            group by AUTBusPerformanceCalenderReport.BusNumber 
                                                                            order by AUTBusPerformanceCalenderReport.Busnumber");

            string TransactionWhereStr = "";
            if (Convert.ToInt32(rdTransactionType) > 0)
            {
                switch (Convert.ToInt32(rdTransactionType))
                {
                    case 1: TransactionWhereStr = " and abp.TicketCount = 0 ";
                        break;
                    case 2: TransactionWhereStr = " and (abp.TaeedTicketCount = 0 or abp.TaeedTicketCount < abp.TicketCount) ";
                        break;
                    case 3: TransactionWhereStr = " and (abp.PaymentTicketCount = 0 or abp.PaymentTicketCount < abp.TicketCount) ";
                        break;
                    case 4: TransactionWhereStr = " and abp.ApplyTicketCount = 0 ";
                        break;
                    case 5: TransactionWhereStr = " and (abp.TicketCount = abp.TaeedTicketCount and abp.TicketCount = abp.ApplyTicketCount and abp.TicketCount = abp.PaymentTicketCount) ";
                        break;
                    case 6: TransactionWhereStr = " and (abp.TicketCount = abp.TaeedTicketCount and abp.TicketCount = abp.ApplyTicketCount) ";
                        break;
                    case 7: TransactionWhereStr = " and (abp.TicketCount = abp.ApplyTicketCount) ";
                        break;
                    case 8: TransactionWhereStr = " and (abp.TicketCount > abp.ApplyTicketCount and abp.ApplyTicketCount > 0) ";
                        break;
                    case 9: TransactionWhereStr = " and (abp.TicketCount < abp.ApplyTicketCount) ";
                        break;
                    case 10: TransactionWhereStr = " and (abp.FrontDoor = 0 or abp.BackDoor = 0) ";
                        break;
                    default: TransactionWhereStr = " ";
                        break;
                }
            }

            //            DataTable FilterDt = WebClassLibrary.JWebDataBase.GetDataTable(@"select abp.BusNumber,cast(dbo.DateEnToFa(Date) as nvarchar)Date
            //                                                                ,SUBSTRING(dbo.DateEnToFa(Date),9,2)DayF,ab.LastLineNumber LineNumber,abp.TicketCount,TaeedTicketCount,
            //                                                                ApplyTicketCount,PaymentTicketCount,FrontDoor,BackDoor
            //                                                                ,(select sum(TicketCount) from AUTBusPerformanceCalenderReport 
            //                                                                where BUSNumber = abp.BUSNumber and " + DateWhere + " " + TransactionWhereStr.Replace("abp.", " ") + @") MontSum
            //                                                                from AUTBusPerformanceCalenderReport abp
            //                                                                left join AutBus ab on ab.BUSNumber = abp.BusNumber
            //                                                                where abp.BusNumber in (" + string.Join(",", ClassLibrary.JDataBase.DataTableToStringtArray(DtBus, "Busnumber")) + @")
            //                                                                and " + DateWhere + " " + TransactionWhereStr + @"
            //                                                                order by abp.BusNumber,Date");
            DataTable FilterDt = WebClassLibrary.JWebDataBase.GetDataTable(@"select abp.BusNumber,cast(dbo.DateEnToFa(abp.Date) as nvarchar)Date
                                                                ,SUBSTRING(dbo.DateEnToFa(abp.Date),9,2)DayF,ab.LastLineNumber LineNumber,abp.TicketCount,TaeedTicketCount,
                                                                ApplyTicketCount,PaymentTicketCount,FrontDoor,BackDoor
                                                                ,(select sum(TicketCount) from AUTBusPerformanceCalenderReport 
                                                                where BUSNumber = abp.BUSNumber and  " + DateWhere.Replace("abp.", " ") + " " + TransactionWhereStr.Replace("abp.", " ") + @") MontSum,
                                                                ISNULL(abf.BusFailureCode,0)BusFailureCode
                                                                from AUTBusPerformanceCalenderReport abp
                                                                left join AutBus ab on ab.BUSNumber = abp.BusNumber
																left join AUTBusFailure abf on abf.BusCode = ab.Code and cast(abf.Date as date) = cast(abp.Date as date)
                                                                where abp.BusNumber in (" + string.Join(",", ClassLibrary.JDataBase.DataTableToStringtArray(DtBus, "Busnumber")) + @")
                                                                and  " + DateWhere + " " + TransactionWhereStr + @"  
                                                                order by abp.BusNumber,abp.Date");

            DataTable Dt = null;
            int Radif = 0, I2Plus = 0;
            string BgColor = "red", TextColor = "black";
            int BusNumber = 0, Counter = 1, DayFNumber = 0, CellZeroNumber = 0;
            int OnClickFlag = 1;
            string OnClickStr = "", OnClickStrPointer = "";
            int MonthSum = 0;
            for (int AllBus = 0; AllBus < DtBus.Rows.Count; AllBus++)
            {
                try
                {
                    Dt = FilterDt.Select("BusNumber = " + DtBus.Rows[AllBus]["BusNumber"].ToString()).CopyToDataTable();
                }
                catch { Dt = null; continue; }
                //                Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select abp.BusNumber,cast(dbo.DateEnToFa(Date) as nvarchar)Date
                //                                                                    ,SUBSTRING(dbo.DateEnToFa(Date),9,2)DayF,ab.LastLineNumber LineNumber,abp.TicketCount,TaeedTicketCount,
                //                                                                    ApplyTicketCount,PaymentTicketCount,FrontDoor,BackDoor from AUTBusPerformanceCalenderReport abp
                //																	left join AutBus ab on ab.BUSNumber = abp.BusNumber
                //                                                                    where abp.BusNumber = " + DtBus.Rows[AllBus]["BusNumber"].ToString() + @"
                //                                                                    and " + DateWhere + @"
                //                                                                    order by abp.BusNumber,Date");

                if (Dt != null & Dt.Rows.Count > 0)
                {
                    Radif++;
                    // DataTable NewDtAfterAddDays = AddNoTransactionDateinToDataTdable(Dt, NumOfDay);
                    // Dt = null;
                    // Dt = NewDtAfterAddDays;

                    BusNumber = Convert.ToInt32(Dt.Rows[0]["BusNumber"].ToString());
                    StrCalender += @"<div style='float:right;background-color:Yellow;color:Black;width:40px;height:20px;
                                         text-align:center;border : 1px solid black ; border-left:none'>" + Radif.ToString() + @"</div>
                                     <div style='float:right;background-color:Yellow;color:Black;width:40px;height:20px;
                                         text-align:center;border : 1px solid black ; border-left:none'>" + Dt.Rows[0]["LineNumber"].ToString() + @"</div>
                                     <div style='float:right;background-color:Yellow;color:Black;width:40px;height:20px;
                                         text-align:center;border : 1px solid black ; border-left:none'>" + BusNumber + @"</div>";
                    for (int i = 0; i < NumOfDay; i++)
                    {
                        if (i < Dt.Rows.Count)
                        {
                            if (Convert.ToInt32(Dt.Rows[i]["FrontDoor"].ToString()) == 0 || Convert.ToInt32(Dt.Rows[i]["BackDoor"].ToString()) == 0)
                            {
                                BgColor = "#75cf7a";
                                TextColor = "white";
                            }
                            else if (Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString()) == 0)
                            {
                                BgColor = "#9b9797";
                                TextColor = "white";
                            }
                            else if (Convert.ToInt32(Dt.Rows[i]["TaeedTicketCount"].ToString()) == 0 ||
                                Convert.ToInt32(Dt.Rows[i]["TaeedTicketCount"].ToString()) < Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString()))
                            {
                                BgColor = "#ca8383";
                                TextColor = "white";
                                OnClickFlag = 0;
                            }
                            else if (Convert.ToInt32(Dt.Rows[i]["PaymentTicketCount"].ToString()) == 0 ||
                                Convert.ToInt32(Dt.Rows[i]["PaymentTicketCount"].ToString()) < Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString()))
                            {
                                BgColor = "#0094ff";
                                TextColor = "white";
                                OnClickFlag = 0;
                            }
                            else if (Convert.ToInt32(Dt.Rows[i]["ApplyTicketCount"].ToString()) == 0)
                            {
                                BgColor = "#ffd800";
                                TextColor = "black";
                            }
                            else if (Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString()) == Convert.ToInt32(Dt.Rows[i]["TaeedTicketCount"].ToString()) &
                                Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString()) == Convert.ToInt32(Dt.Rows[i]["PaymentTicketCount"].ToString()) &
                                Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString()) == Convert.ToInt32(Dt.Rows[i]["ApplyTicketCount"].ToString()))
                            {
                                BgColor = "#3aa807";
                                TextColor = "white";
                                OnClickFlag = 0;
                            }
                            else if (Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString()) == Convert.ToInt32(Dt.Rows[i]["TaeedTicketCount"].ToString()) &
                                Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString()) == Convert.ToInt32(Dt.Rows[i]["ApplyTicketCount"].ToString()))
                            {
                                BgColor = "#15d42b";
                                TextColor = "black";
                                OnClickFlag = 0;
                            }
                            else if (Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString()) == Convert.ToInt32(Dt.Rows[i]["ApplyTicketCount"].ToString()))
                            {
                                BgColor = "#00ff21";
                                TextColor = "black";
                                OnClickFlag = 0;
                            }
                            else if (Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString()) > Convert.ToInt32(Dt.Rows[i]["ApplyTicketCount"].ToString()))
                            {
                                BgColor = "#ff0000";
                                TextColor = "white";
                            }
                            else if (Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString()) < Convert.ToInt32(Dt.Rows[i]["ApplyTicketCount"].ToString()))
                            {
                                BgColor = "#60f6c3";
                                TextColor = "black";
                            }

                            if (OnClickFlag == 1)
                            {
                                OnClickStr = @" onclick=""SetParam('" + Dt.Rows[i]["Date"].ToString() + @"','" + Dt.Rows[i]["BusNumber"].ToString() + @"','0');"" ";
                                OnClickStrPointer = " ;cursor:pointer ";
                            }
                            else
                            {
                                OnClickStr = @"";
                                OnClickStrPointer = "";
                                OnClickFlag = 1;
                            }

                            MonthSum = Convert.ToInt32(Dt.Rows[i]["MontSum"].ToString());

                            DayFNumber = Convert.ToInt32(Dt.Rows[i]["DayF"].ToString());
                            if (DayFNumber == (i + Counter))
                            {
                                I2Plus++;
                                CellZeroNumber++;
                                //Counter = 1;
                                //MonthSum += Convert.ToInt32(Dt.Rows[i]["TicketCount"].ToString());
                                StrCalender += @"<div " + OnClickStr + @" style='float:right;background-color:" + BgColor + @";color:" + TextColor + @";width:40px;height:20px;
                                         text-align:center;border : 1px solid black ; border-left:none" + OnClickStrPointer + @"'>" + Dt.Rows[i]["TicketCount"].ToString() + @"</div>";
                            }
                            else
                            {
                                CellZeroNumber++;
                                Counter += 1;
                                i = i - 1;
                                if (i > 0)
                                    StrCalender += @"<div " + OnClickStr + @" style='float:right;background-color:#9b9797;color:white;width:40px;height:20px;
                                         text-align:center;border : 1px solid black ; border-left:none" + OnClickStrPointer + @"'>" + GetBusFailure(Convert.ToInt32(Dt.Rows[i]["BusFailureCode"].ToString())) + @"</div>";
                                else
                                    StrCalender += @"<div " + OnClickStr + @" style='float:right;background-color:#9b9797;color:white;width:40px;height:20px;
                                         text-align:center;border : 1px solid black ; border-left:none" + OnClickStrPointer + @"'>0</div>";
                            }
                        }
                        //                        else
                        //                        {
                        //                            StrCalender += @"<div style='float:right;background-color:#9b9797;color:white;width:40px;height:20px;
                        //                                         text-align:center;border : 1px solid black ; border-left:none'>0</div>";
                        //                        }
                    }

                    for (int ZC = 0; ZC < (NumOfDay - CellZeroNumber); ZC++)
                    {
                        StrCalender += @"<div style='float:right;background-color:#9b9797;color:white;width:40px;height:20px;
                                         text-align:center;border : 1px solid black ; border-left:none'>0</div>";
                    }
                    StrCalender += @"<div style='float:right;background-color:Yellow;color:black;width:40px;height:20px;
                                         text-align:center;border : 1px solid black ; border-left:none'>" + MonthSum + "</div>";
                    StrCalender += "<div style='clear:both'></div>";
                    Counter = 1;
                    CellZeroNumber = 0;
                    // MonthSum = 0;
                }
                else
                {
                    continue;
                }
            }
            return StrCalender;
        }

        public string GetBusFailure(int BusNumber)
        {
            string FCode = "0";
            //            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select top 1 sf.Code FailName from AUTBusFailure abf
            //                                                                        left join subdefine sf on sf.Code = abf.BusFailureCode
            //                                                                        where abf.BusCode = (select Code from AutBus where BusNumber = " + BusNumber + @") 
            //                                                                        and cast(abf.[Date] as date) = '" + ClassLibrary.JDateTime.GregorianDate(Date).ToShortDateString() + @"' 
            //                                                                        order by abf.InsertDate desc");
            if (BusNumber > 0)
            {
                FCode = BusNumber.ToString();
                if (FCode == "81180194")
                    return "1";
                else if (FCode == "81180195")
                    return "2";
                else if (FCode == "81180196")
                    return "3";
                else if (FCode == "81180197")
                    return "4";
                else if (FCode == "81180198")
                    return "5";
                else if (FCode == "81180199")
                    return "6";
                else if (FCode == "81180200")
                    return "7";
                else
                    return "0";
            }
            else
            {
                return "0";
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
            //try
            //{

            StrCalender = GetReport(Convert.ToInt32(cmbYears.SelectedValue), Convert.ToInt32(cmbMount.SelectedValue), Convert.ToInt32(cmbZone.SelectedValue)
                    , Convert.ToInt32(cmbLine.SelectedValue), Convert.ToInt32(cmbBusOwner.SelectedValue),
                    ((WebControllers.MainControls.Date.JDateControl)dteControlFrom).GetDate(),
                    ((WebControllers.MainControls.Date.JDateControl)dteControlTo).GetDate(),
                    0,
                    rdbYearMonth.Checked);

            // }
            //catch
            //{ }
        }

        public string[] SaveTrnsactionPrintRequest(string[] param)
        {
            int LastInsertCode = 0;
            try
            {
                LastInsertCode = SaveInSqlPrintTable(Convert.ToDateTime(ClassLibrary.JDateTime.GregorianDate(param[0])), Convert.ToInt32(param[1]));
                bool MySqlRes = SaveInMySql(LastInsertCode, Convert.ToDateTime(ClassLibrary.JDateTime.GregorianDate(param[0])), Convert.ToInt32(param[1]), Convert.ToInt32(param[2]));
                if (MySqlRes == false)
                    throw new Exception();
                return new string[] { "1" };
            }
            catch (Exception er)
            {
                return new string[] { er.Message.ToString() };
            }
        }

        public int SaveInSqlPrintTable(DateTime StartDate, int BusNumber)
        {
            //BusManagment.JBusPrintReport TransactionPrint = new BusManagment.JBusPrintReport();
            //TransactionPrint.Code = 0;
            //TransactionPrint.BusNumber = BusNumber;
            //TransactionPrint.StartDate = Convert.ToDateTime(StartDate.ToShortDateString() + " 00:00:00");
            //TransactionPrint.EndDate = Convert.ToDateTime(StartDate.ToShortDateString() + " 23:59:59");
            //TransactionPrint.TicketCount = 0;
            //TransactionPrint.TicketSent = 0;
            //TransactionPrint.State = 0;
            //return TransactionPrint.Insert();
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            Db.setQuery(@"INSERT INTO [dbo].[AUTPrinterRporte]
                               ([Code]
                               ,[BusNumber]
                               ,[StartDate]
                               ,[EndDate]
                               ,[TicketCount]
                               ,[TicketSent]
                               ,[State]
                               ,[GetTicket]
                               ,[DailyCode]
                               ,[RequestCount]
                               ,[Date])
                         VALUES
                               ((select ISNULL(Max(Code),0)+1 From [AUTPrinterRporte])
                               ," + BusNumber + @"
                               ,'" + StartDate.ToShortDateString().Replace("/", "-") + " 00:00:00" + @"'
                               ,'" + StartDate.ToShortDateString().Replace("/", "-") + " 23:59:59" + @"'
                               ,0
                               ,0
                               ,0
                               ,0
                               ,0
                               ,0
                               ,'" + StartDate.ToShortDateString().Replace("/", "-") + @"')");
            Db.Query_ExecutSacler();
            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select top 1 Code from AUTPrinterRporte where BusNumber = " + BusNumber + @"
            and StartDate = '" + StartDate.ToShortDateString().Replace("/", "-") + " 00:00:00" + @"' 
            and EndDate = '" + StartDate.ToShortDateString().Replace("/", "-") + " 23:59:59" + @"' and DailyCode = 0 and State = 0 
            order by Code desc");
            return int.Parse(Dt.Rows[0][0].ToString());
        }
        public bool SaveInMySql(int Code, DateTime StartDate, int BusNumber, int IsSent)
        {
            ClassLibrary.JMySQLDataBase mysqlDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            mysqlDB.setQuery(@"INSERT INTO `getdataticket`(`Code`, `busserial`, `state`, `startdate`, `enddate`, `isSent`, `RowCount`, `RowSent`) 
                               VALUES (" + Code + @"," + BusNumber + @",0,'" + StartDate.Year + "-" + StartDate.Month + @"-" + StartDate.Day + @" 00:00:00',
                               '" + StartDate.Year + "-" + StartDate.Month + "-" + StartDate.Day + @" 23:59:59'," + IsSent + @",0,0)");
            return mysqlDB.Query_Execute() >= 0 ? true : false;
        }


        protected void cmbZone_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (Convert.ToInt32(cmbZone.SelectedValue) > 0)
            {
                DataTable dtLines = WebClassLibrary.JWebDataBase.GetDataTable("SELECT [Code],convert(nvarchar,[LineNumber])+' - - > '+[LineName] as [lineName],LineNumber FROM AUTLine Where ZoneCode = " + cmbZone.SelectedValue + " Order By LineNumber ASC");
                var p = (from v in dtLines.AsEnumerable()
                         select new { Code = Convert.ToInt32(v["Code"]), lineName = v["lineName"].ToString() }).ToList();
                p.Insert(0, new { Code = 0, lineName = "همه" });
                cmbLine.DataSource = p;
                cmbLine.DataTextField = "lineName";
                cmbLine.DataValueField = "Code";
                cmbLine.DataBind();
            }
            else
            {
                LoadLines();
            }
        }

        protected void cmbLine_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (Convert.ToInt32(cmbLine.SelectedValue) > 0)
            {
                DataTable dtZones = WebClassLibrary.JWebDataBase.GetDataTable(@"select * from AUTZone Where Code =
                    (Select ZoneCode From AutLine Where Code = " + cmbLine.SelectedValue + ")");
                var p = (from v in dtZones.AsEnumerable()
                         select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
                p.Insert(0, new { Code = 0, Name = "همه" });
                cmbZone.DataSource = p;
                cmbZone.DataTextField = "Name";
                cmbZone.DataValueField = "Code";
                cmbZone.DataBind();
            }
            else
            {
                LoadZones();
            }
        }

    }
}