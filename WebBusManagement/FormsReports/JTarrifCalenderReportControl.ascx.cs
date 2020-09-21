using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsReports
{
    public partial class JTarrifCalenderReportControl : System.Web.UI.UserControl
    {
        public string StrCalender = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                // btnSave_Click(null, null);
                return;
            else
            {
                LoadYears();
                LoadMonth();
                LoadBus();
                LoadZones();
                LoadLines();
                LoadBusOwner();
                LoadFleets();
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
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BusNumber"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, BUSNumber = "0 - همه" });
            cmbBus.DataSource = p;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
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

        public void GetReport(int BusNumebr = 0, int Year = 0, int Mount = 0, int Zone = 0, int Line = 0, int Fleet = 0, int Owner = 0)
        {

            StrCalender = "";

            int NumOfDay = 0;
            if (Mount <= 6)
                NumOfDay = 31;
            else if (Mount > 6)
                NumOfDay = 30;

            string WhereStr = "";
            if (BusNumebr > 0)
                WhereStr += " and ab.Code = " + BusNumebr;
            if (Zone > 0)
                WhereStr += " and az.code = " + Zone;
            if (Line > 0)
                WhereStr += " and al.code = " + Line;
            if (Fleet > 0)
                WhereStr += " and ab.FleetCode = " + Fleet;
            if (Owner > 0)
                WhereStr += " and abo.CodePerson = " + BusNumebr;


            DataTable DtBusNumber = WebClassLibrary.JWebDataBase.GetDataTable(@"
            select a.Date,dbo.DateEnToFa(a.Date)FDate,SUBSTRING(dbo.DateEnToFa(a.Date), 9, 2)MDay,ab.BUSNumber,max(al.LineNumber)LineNumber,
            sum(a.NumOfService)NumOfService,sum(isnull(a.CountNimService, 0))CountNimService from (
                 select Date, BusCode, LineCode, ZoneCode, isnull(b.MinNumOfService, 0) NumOfService,
            	isnull(cast((

                        (select sum(isnull(AB.NumOfService, 0)) from AutBusServices AB where AB.BusNumber
                         = (select BUSNumber from autbus where code = b.BusCode) AND AB.date = b.Date AND CAST(AB.FirstStationDate AS TIME) BETWEEN b.StartTime AND b.EndTime and deleted <> 1)
            		) as int),0) CountNimService
                from AUTTariff b
                   where(cast(substring(dbo.DateEnToFa(Date), 0, 5) as int) = " + Year + @"
                   and cast(substring(dbo.DateEnToFa(Date), 6, 2) as int) = " + Mount + @")
               )a
               left join AUTBus ab on a.BusCode = ab.Code
               left join AUTLine al on al.Code = a.LineCode
               left join AUTZone az on az.Code = a.ZoneCode
               left join (select * from AUTBusOwner where IsActive = 1) abo on abo.BusCode = a.BusCode
               where 1 = 1" + WhereStr + @"
               group by a.Date, ab.BUSNumber
               order by ab.BUSNumber, a.Date");
            //DataTable DtBusNumber = WebClassLibrary.JWebDataBase.GetDataTable(@"
            //   select a.Date,dbo.DateEnToFa(a.Date)FDate,SUBSTRING(dbo.DateEnToFa(a.Date),9,2)MDay,ab.BUSNumber,max(al.LineNumber)LineNumber,
            //sum(a.NumOfService)NumOfService,sum(isnull(a.CountNimService,0))CountNimService from (
            //	select Date,BusCode,LineCode,ZoneCode,isnull(b.MinNumOfService,0) NumOfService,
            //	isnull(cast((
            //			(select isnull(count(*),0) from AutTarrifEzamBe where TarrifCode = b.Code and CAST(StartTime AS TIME) BETWEEN b.StartTime AND b.EndTime and CAST(StartTime AS DATE) = b.Date)
            //			+
            //			(select sum(isnull(AB.NumOfService,0)) from AutBusServices AB where AB.BusNumber
            //			=(select BUSNumber from autbus where code=b.BusCode) AND AB.date = b.Date AND CAST(AB.FirstStationDate AS TIME) BETWEEN b.StartTime AND b.EndTime)
            //		) as int),0) CountNimService 
            //	from AUTTariff b
            //       where (cast(substring(dbo.DateEnToFa(Date),0,5) as int)=" + Year + @"
            //       and cast(substring(dbo.DateEnToFa(Date),6,2) as int)=" + Mount + @")
            //   )a
            //   left join AUTBus ab on a.BusCode = ab.Code
            //   left join AUTLine al on al.Code = a.LineCode
            //   left join AUTZone az on az.Code = a.ZoneCode
            //   left join (select * from AUTBusOwner where IsActive = 1) abo on abo.BusCode = a.BusCode
            //   where 1 = 1 " + WhereStr + @"
            //   group by a.Date,ab.BUSNumber
            //   order by ab.BUSNumber,a.Date ");

            //if (DtBusNumber != null)
            //{
            //    if (DtBusNumber.Rows.Count > 0)
            //    {
            //        StrCalender += "<div style='float:right;background-color:Yellow;color:Black;width:42px;height:20px;text-align:center;border : 1px solid black ; border-left:none'>ردیف</div>";
            //        StrCalender += "<div style='float:right;background-color:Yellow;color:Black;width:42px;height:20px;text-align:center;border : 1px solid black ; border-left:none'>خط</div>";
            //        StrCalender += "<div style='float:right;background-color:Yellow;color:Black;width:42px;height:20px;text-align:center;border : 1px solid black ; border-left:none'>اتوبوس</div>";
            //        for (int j = 1; j <= NumOfDay; j++)
            //        {
            //            StrCalender += "<div style='float:right;background-color:Yellow;color:Black;width:42px;height:20px;text-align:center;border : 1px solid black; border-left:none'>" + j + "</div>";
            //        }
            //        StrCalender += "<div style='clear:both'></div>";

            //    int k = 0;

            //    int oldBusNumber = Convert.ToInt32(DtBusNumber.Rows[0]["BusNumber"].ToString());
            //    for (int i = 0; i < DtBusNumber.Rows.Count; i += NumOfDay)
            //    {

            //        StrCalender += "<div style='float:right;background-color:Yellow;color:Black;width:42px;height:20px;text-align:center;border : 1px solid black ; border-left:none'>" + Rafid + "</div>";
            //        StrCalender += "<div style='float:right;background-color:Yellow;color:Black;width:42px;height:20px;text-align:center;border : 1px solid black ; border-left:none'>" + DtBusNumber.Rows[i]["LineNumber"].ToString() + "</div>";
            //        StrCalender += "<div style='float:right;background-color:Yellow;color:Black;width:42px;height:20px;text-align:center;border : 1px solid black ; border-left:none'>" + DtBusNumber.Rows[i]["BUSNumber"].ToString() + "</div>";
            //        Rafid++;
            //        CurrentBusNumber = Convert.ToInt32(DtBusNumber.Rows[i]["BusNumber"].ToString());
            //        for(int Dcount = 1; Dcount <= NumOfDay; Dcount++)
            //        { 
            //        if (k < DtBusNumber.Rows.Count - 1)
            //        {
            //            if (Convert.ToInt32(DtBusNumber.Rows[i]["MDay"].ToString()) != 1)
            //            {
            //                int l = Convert.ToInt32(DtBusNumber.Rows[i]["MDay"].ToString());

            //                for (int j = 1; j < l; j++)
            //                {

            //                    StrCalender += "<div style='clear:both'></div>";
            //                }
            //            }

            //                for (int j = i; CurrentBusNumber == oldBusNumber;)
            //                {
            //                    if (j < DtBusNumber.Rows.Count - 1)
            //                    {

            //                        if (Convert.ToInt32(DtBusNumber.Rows[j]["NumOfService"].ToString()) <= 0 & Convert.ToInt32(DtBusNumber.Rows[j]["CountNimService"].ToString()) <= 0)//بدون تعرفه
            //                        {
            //                            BgColor = "#8EE5EE";
            //                            Color = "Black";

            //                        }

            //                        else if ((Convert.ToInt32(DtBusNumber.Rows[j]["NumOfService"].ToString()) > Convert.ToInt32(DtBusNumber.Rows[j]["CountNimService"].ToString())) & Convert.ToInt32(DtBusNumber.Rows[j]["CountNimService"].ToString()) > 0)//کمتر از تعرفه
            //                        {
            //                            BgColor = "#ffd800";
            //                            Color = "Black";
            //                        }
            //                        else if (Convert.ToInt32(DtBusNumber.Rows[j]["CountNimService"].ToString()) == 0 & Convert.ToInt32(DtBusNumber.Rows[j]["NumOfService"].ToString()) > 0)//غیبت
            //                        {
            //                            BgColor = "#ff0000";
            //                            Color = "Black";
            //                        }
            //                        else if (Convert.ToInt32(DtBusNumber.Rows[j]["NumOfService"].ToString()) < Convert.ToInt32(DtBusNumber.Rows[j]["CountNimService"].ToString()) & Convert.ToInt32(DtBusNumber.Rows[j]["NumOfService"].ToString()) > 0)//بیشتر از تعرفه
            //                        {
            //                            BgColor = "#3aa807";
            //                            Color = "Black";

            //                        }
            //                        else if (Convert.ToInt32(DtBusNumber.Rows[j]["NumOfService"].ToString()) < Convert.ToInt32(DtBusNumber.Rows[j]["CountNimService"].ToString()) & Convert.ToInt32(DtBusNumber.Rows[j]["NumOfService"].ToString()) <= 0)//خارج از تعرفه
            //                        {
            //                            BgColor = "#0094ff";
            //                            Color = "Black";
            //                        }
            //                        else if (Convert.ToInt32(DtBusNumber.Rows[j]["NumOfService"].ToString()) == Convert.ToInt32(DtBusNumber.Rows[j]["CountNimService"].ToString()) & Convert.ToInt32(DtBusNumber.Rows[j]["NumOfService"].ToString()) != 0)//کامل
            //                        {
            //                            BgColor = "#BADA55";
            //                            Color = "Black";
            //                        }

            //                    }
            //                    StrCalender += "<div style='float:right;background-color:" + BgColor + ";color:" + Color + ";width:42px;height:20px;text-align:center;border : 1px solid black ; border-left:none'>" + DtBusNumber.Rows[j]["NumOfService"].ToString() + "-" + DtBusNumber.Rows[j]["CountNimService"].ToString() + "</div>";
            //                    CurrentBusNumber = Convert.ToInt32(DtBusNumber.Rows[++j]["BusNumber"].ToString());
            //                    k = j;
            //            }
            //            
            //            CurrentBusNumber = Convert.ToInt32(DtBusNumber.Rows[++k]["BusNumber"].ToString());
            //            oldBusNumber = CurrentBusNumber;
            //        }
            //    }

            //}

            int CurrentBusNumber = 0;
            int Radif= 1;
            string BgColor = "#3aa807", Color = "White";
            int MyIndex = 0;
            int CheckIndex = 0;
            if (DtBusNumber != null)
            {
                if (DtBusNumber.Rows.Count > 0)
                {
                    StrCalender += "<div style='float:right;background-color:Yellow;color:Black;width:42px;height:20px;text-align:center;border : 1px solid black ; border-left:none'>ردیف</div>";
                    StrCalender += "<div style='float:right;background-color:Yellow;color:Black;width:42px;height:20px;text-align:center;border : 1px solid black ; border-left:none'>خط</div>";
                    StrCalender += "<div style='float:right;background-color:Yellow;color:Black;width:42px;height:20px;text-align:center;border : 1px solid black ; border-left:none'>اتوبوس</div>";
                    for (int j = 1; j <= NumOfDay; j++)
                    {
                        StrCalender += "<div style='float:right;background-color:Yellow;color:Black;width:42px;height:20px;text-align:center;border : 1px solid black; border-left:none'>" + j + "</div>";
                    }
                    StrCalender += "<div style='clear:both'></div>";


                    for (int i = 0; i < DtBusNumber.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(DtBusNumber.Rows[i]["BUSNumber"].ToString()) != CurrentBusNumber)
                        {
                            StrCalender += "<div style='clear:both'></div>";
                            CurrentBusNumber =  Convert.ToInt32(DtBusNumber.Rows[i]["BUSNumber"].ToString());
                            StrCalender += "<div style='float:right;background-color:Yellow;color:Black;width:42px;height:20px;text-align:center;border : 1px solid black ; border-left:none'>" + Radif + "</div>";
                            StrCalender += "<div style='float:right;background-color:Yellow;color:Black;width:42px;height:20px;text-align:center;border : 1px solid black ; border-left:none'>" + DtBusNumber.Rows[i]["LineNumber"].ToString() + "</div>";
                            StrCalender += "<div style='float:right;background-color:Yellow;color:Black;width:42px;height:20px;text-align:center;border : 1px solid black ; border-left:none'>" + DtBusNumber.Rows[i]["BUSNumber"].ToString() + "</div>";
                            Radif++;
                            CheckIndex = i;
                            for (int Dcount = 1; Dcount <= NumOfDay; Dcount++)
                            {
                                MyIndex = (Dcount - 1) + i;
                                if (MyIndex > DtBusNumber.Rows.Count - 1)
                                    MyIndex = DtBusNumber.Rows.Count - 1;
                                if (Convert.ToInt32(DtBusNumber.Rows[CheckIndex]["BUSNumber"].ToString()) == CurrentBusNumber)
                                {
                                    if (Dcount == Convert.ToInt32(DtBusNumber.Rows[CheckIndex]["MDay"].ToString()))
                                    {
                                        
                                        if (Convert.ToInt32(DtBusNumber.Rows[CheckIndex]["NumOfService"].ToString()) <= 0 & Convert.ToInt32(DtBusNumber.Rows[CheckIndex]["CountNimService"].ToString()) <= 0)//بدون تعرفه
                                        {
                                            BgColor = "#8EE5EE";
                                            Color = "Black";
                                        }

                                        else if ((Convert.ToInt32(DtBusNumber.Rows[CheckIndex]["NumOfService"].ToString()) > Convert.ToInt32(DtBusNumber.Rows[CheckIndex]["CountNimService"].ToString())) & Convert.ToInt32(DtBusNumber.Rows[CheckIndex]["CountNimService"].ToString()) > 0)//کمتر از تعرفه
                                        {
                                            BgColor = "#ffd800";
                                            Color = "Black";
                                        }
                                        else if (Convert.ToInt32(DtBusNumber.Rows[CheckIndex]["CountNimService"].ToString()) == 0 & Convert.ToInt32(DtBusNumber.Rows[CheckIndex]["NumOfService"].ToString()) > 0)//غیبت
                                        {
                                            BgColor = "#ff0000";
                                            Color = "Black";
                                        }
                                        else if (Convert.ToInt32(DtBusNumber.Rows[CheckIndex]["NumOfService"].ToString()) < Convert.ToInt32(DtBusNumber.Rows[CheckIndex]["CountNimService"].ToString()) & Convert.ToInt32(DtBusNumber.Rows[CheckIndex]["NumOfService"].ToString()) > 0)//بیشتر از تعرفه
                                        {
                                            BgColor = "#BADA55";
                                            Color = "Black";

                                        }
                                        else if (Convert.ToInt32(DtBusNumber.Rows[CheckIndex]["NumOfService"].ToString()) < Convert.ToInt32(DtBusNumber.Rows[CheckIndex]["CountNimService"].ToString()) & Convert.ToInt32(DtBusNumber.Rows[CheckIndex]["NumOfService"].ToString()) <= 0)//خارج از تعرفه
                                        {
                                            BgColor = "#0094ff";
                                            Color = "Black";
                                        }
                                        else if (Convert.ToInt32(DtBusNumber.Rows[CheckIndex]["NumOfService"].ToString()) == Convert.ToInt32(DtBusNumber.Rows[CheckIndex]["CountNimService"].ToString()) & Convert.ToInt32(DtBusNumber.Rows[CheckIndex]["NumOfService"].ToString()) != 0)//کامل
                                        {
                                            BgColor = "#3aa807" ;
                                            Color = "Black";
                                        }
                                        StrCalender += "<div style='float:right;background-color:" + BgColor + ";color:" + Color + ";width:42px;height:20px;text-align:center;border : 1px solid black ; border-left:none'>" + DtBusNumber.Rows[CheckIndex]["NumOfService"].ToString() + "-" + DtBusNumber.Rows[CheckIndex]["CountNimService"].ToString() + "</div>";

                                        CheckIndex++;
                                        if (CheckIndex > DtBusNumber.Rows.Count - 1)
                                            CheckIndex = DtBusNumber.Rows.Count - 1;
                                    }

                                    else
                                    {
                                        StrCalender += "<div style='float:right;background-color:White;color:Black;width:42px;height:20px;text-align:center;border : 1px solid black ; border-left:none'> </div>";
                                    }
                                }
                                else
                                {

                                    if (Dcount <= NumOfDay)
                                        StrCalender += "<div style='float:right;background-color:White;color:Black;width:42px;height:20px;text-align:center;border : 1px solid black ; border-left:none'> </div>";

                                    else
                                        break;
                                }
                            }
                        }

                    }
                    StrCalender += "<div style='clear:both'></div>";
                    StrCalender += "<div style='clear:both'></div>";
                }

            }
        }
    }
}