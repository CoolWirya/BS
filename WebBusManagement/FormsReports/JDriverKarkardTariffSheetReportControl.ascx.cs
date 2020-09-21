using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClassLibrary;

namespace WebBusManagement.FormsReports
{
    public partial class JDriverKarkardTariffSheetReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
            }
            else
            {
                LoadYears();
                LoadMonth();
                //btnSave_Click(null, null);
            }
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
        public void LoadMonth()
        {
            cmbMount.SelectedValue = ClassLibrary.JDateTime.FarsiMonth(DateTime.Now);
        }
        public void GetReport(int PersonCode = 0, int Year = 0, int Mount = 0)
        {

            int Year1 = Year;
            int Mount1 = Mount;

            if (Mount == 12)
            {
                Year1++;
                Mount1 = 1;
            }
            else
            {
                Mount1++;
            }

            string strWhere = "AT.Date between dbo.DateFaToEn(" + Year + @"," + Mount + ",01) and dateadd(day,-1,dbo.DateFaToEn(" + Year1 + @"," + Mount1 + ",01))";
            string strPersonWhere = strWhere;
            if (PersonCode > 0)
            {
                strWhere += " and DriverPersonCode = " + PersonCode;
                strPersonWhere += " and DriverPCode = " + PersonCode;
            }
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;//new WebControllers.MainControls.Grid.JGridView("WebBusManagement_FormsReports_JDriverKarkardTariffSheetReportControl");
            jGridView.ClassName = "WebBusManagement_FormsReports_JDriverKarkardTariffSheetReportControl_NEW_" + PersonCode + "_" + Year + "_" + Mount;
            jGridView.SQL = @"
IF OBJECT_ID('tempdb..#TempSensaname') IS NOT NULL DROP Table #TempSensaname
IF OBJECT_ID('tempdb..#TempSensaname1') IS NOT NULL DROP Table #TempSensaname1
select * into #TempSensaname from
(
select AT.Date,case when AT.LineNumber=0 OR AT.LineNumber is null then (select max(LineNumber) from AUTShiftDriver ASD where ASD.BusNumber=AT.BusNumber and ASD.Date = cast(min(AT.FirstStationDate) as date)) else AT.LineNumber end LineNumber,AT.ZoneCode,BusNumber,(select code from AUTBus where BusNumber=AT.BusNumber) BusCode,min(FirstStationDate) FirstStationDate ,Max(LastStationDate) LastStationDate
,Sum(isnull(AT.NumOfService,0)) NumOfService,EzamBeCode,Ast.Code ShiftCode,Ast.Title ShiftTitle,
AT.DriverPersonCode
from AutBusServices AT
INNER JOIN AUTTariff t ON t.date = AT.Date AND CAST(AT.FirstStationDate AS TIME) BETWEEN t.StartTime AND t.EndTime and t.BusCode=(select code from autbus where busnumber=AT.BusNumber)
inner join AUTShift ASt ON ast.Code=t.ShiftCode
where  isnull(AT.Deleted, 0) = 0 
and (((isnull(AT.EzamBeCode, 0) > 0 AND ISOK <> 11) or not exists(select * from AutTarrifEzamBe where TarrifCode = t.Code and AT.FirstStationDate < FinishTime and AT.LastStationDate > StartTime)))
and " + strWhere + @"
group by AT.Date,LineNumber,AT.ZoneCode,BusNumber,EzamBeCode,Ast.Code,Ast.Title,DriverPersonCode
) as a

    select BusEventDetailesCode,AT.Code,(select BusNumber from AUTBus where Code= T.BusCode) BusNumber,0 Beja,AT.Date,AT.MinNumOfService,0 NumOfSevice
,N'واقعه '+(select top 1  a.Name from AUTBusEventDetailes a where code = T.BusEventDetailesCode) Comment
    ,T.DriverPCode,(select name from clsAllPerson where code=DriverPCode) Name 
    ,0 LineNumber,T.StartDate+T.StartTime StartDate,T.EndDate +T.EndTime EndDate
    into #TempSensaname1
    from AUTTariff AT
    left join AUTBusEventRegisterTarrifCode ABRT on ABRT.TarrifCode=AT.Code
    left join AUTBusEventRegister T ON T.Code=ABRT.BusEventRegisterCode
    where " + strPersonWhere + @"

<#PreviusSQL#>
select  code,BusNumber,Beja,date,max(MinNumOfService) MinNumOfService,sum(NumOfService) NumOfService,ShiftTitle,DriverPersonCode,Name,LineNumber ,min(FirstStationDate)FirstStationDate,max(LastStationDate)LastStationDate
from
(
    select AT.Code,T.BusNumber,0 Beja,AT.Date,AT.MinNumOfService,T.NumOfService,ShiftTitle
    ,T.DriverPersonCode,(select name from clsAllPerson where code=DriverPersonCode) Name 
    ,T.LineNumber,T.FirstStationDate,T.LastStationDate
    from AUTTariff AT
    inner join #TempSensaname T ON AT.BusCode=T.BusCode and T.Date=AT.Date and cast(T.FirstStationDate as time) between AT.StartTime and AT.EndTime
    where " + strWhere + @"
    Union ALL
    select Code,BusNumber,beja,Date,0 MinNumOfService,0 NumOfSevice,comment collate Persian_100_CI_AI ,DriverPCode,Name,LineNumber,startdate,enddate from #TempSensaname1 where BusEventDetailesCode<1000000
) as a
group by code,BusNumber,Beja,date,ShiftTitle,DriverPersonCode,Name,LineNumber";

            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JDriverKarkardTariffSheetReportControl";
            jGridView.PageOrderByField = "DriverPersonCode,FirstStationDate,Date,BusNumber,ShiftTitle,LineNumber";
            jGridView.Buttons = "excel,print,record_print";
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("NumOfService", 0);
            jGridView.SumFields.Add("MinNumOfService", 0);
            jGridView.Bind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            // try
            //   {
            GetReport(((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode, Convert.ToInt32(cmbYears.SelectedValue), Convert.ToInt32(cmbMount.SelectedValue));
            // }
            // catch
            // { }
        }
    }
}