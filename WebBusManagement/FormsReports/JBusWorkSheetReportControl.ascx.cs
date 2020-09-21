using BusManagment.Line;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsReports
{
    public partial class JBusWorkSheetReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
            }
            else
            {
                LoadZones();
                LoadLines();
                LoadYears();
                LoadMonth();
                btnSave_Click(null, null);
            }
        }
        public void LoadLines()
        {
            DataTable dt = JLines.GetWebDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), lineName = v["lineName"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, lineName = "همه" });
            cmbLine.DataSource = p;
            cmbLine.DataTextField = "lineName";
            cmbLine.DataValueField = "Code";
            cmbLine.DataBind();
        }

        public void LoadZones()
        {
            DataTable dt = BusManagment.Zone.JZones.GetDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, Name = "همه" });
            cmbZone.DataSource = p;
            cmbZone.DataTextField = "Name";
            cmbZone.DataValueField = "Code";
            cmbZone.DataBind();
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

        void GetReport(int LineCode = 0, int Year = 0, int Mount = 0)
        {
            string strServiceWhere = @" AT.Date between dbo.DateFaToEn(" + Year + @", " + Mount + @", 1) and DATEADD(DAY, -1,dbo.DateFaToEn((case "
                + Mount + @" when 12 then " + Year + @" + 1 else " + Year + @" end), (case " + Mount + @" when 12 then 1 else " + Mount + @" + 1 end), 1))";
            string strTariffWhere = strServiceWhere, strEzamWhere = strServiceWhere;
            if (LineCode > 0)
            {
                strServiceWhere += " and LineNumber = (select top 1 LineNumber from AUtLine WHERE Code=" + LineCode + ")";
                strTariffWhere += " and AT.LineCode = " + LineCode;
                strEzamWhere += " and T.LineCode = " + LineCode;
            }
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;//new WebControllers.MainControls.Grid.JGridView("WebBusManagement_FormsReports_JBusWorkSheetReportControl");
            jGridView.ClassName = "WebBusManagement_FormsReports_JBusWorkSheetReportControl_NEW_" + LineCode + "_" + Year + "_" + Mount;
            jGridView.SQL = @"
IF OBJECT_ID('tempdb..#TempSensaname') IS NOT NULL DROP Table #TempSensaname
IF OBJECT_ID('tempdb..#TempSensaname2') IS NOT NULL DROP Table #TempSensaname2
select * into #TempSensaname from
(
select AT.Date,LineNumber,zone.Name ZoneName,AT.BusNumber,(select code from AUTBus where BusNumber=AT.BusNumber) BusCode,min(FirstStationDate) FirstStationDate ,Max(LastStationDate) LastStationDate
,Sum(isnull(AT.NumOfService,0)) NumOfService,ISNULL(EzamBeCode, 0) EzamBeCode,Ast.Code ShiftCode,AST.Title ShiftTitle,N'کارکرد' WorkTitle,
AT.DriverPersonCode
from AutBusServices AT
INNER JOIN AUTBus bus ON bus.BUSNumber = AT.BUSNumber
inner join AUTTariff Trf on Trf.Date = AT.Date AND Trf.BusCode = bus.Code and AT.FirstStationDate BETWEEN Trf.Date + Trf.StartTime AND Trf.Date + Trf.EndTime
inner join AUTShift ASt ON AT.date between ASt.StartDate and Ast.EndDate and cast(AT.FirstStationDate as time) between Ast.StartTime and ASt.EndTime
left join AUTZone zone on zone.Code = AT.ZoneCode
where Deleted=0 and " + strServiceWhere + @"
and not exists(select * from AutTarrifEzamBe where TarrifCode = Trf.Code and AT.FirstStationDate < FinishTime and AT.LastStationDate > StartTime)
group by AT.Date,LineNumber,zone.Name,AT.BusNumber,ISNULL(EzamBeCode, 0),Ast.Code,Ast.Title,DriverPersonCode
) as a

select BusEventDetailesCode,AT.Code,(select BusNumber from AUTBus where Code= T.BusCode) BusNumber,0 Beja,AT.Date,AT.MinNumOfService,0 NumOfSevice
,N'واقعه '+(select top 1  a.Name from AUTBusEventDetailes a where code = T.BusEventDetailesCode) Comment
,T.DriverPCode,(select name from clsAllPerson where code=DriverPCode) Name 
,(select LineNumber from AUTLine where Code = AT.LineCode) LineNumber,zone.Name ZoneName,T.StartDate+T.StartTime StartDate,T.EndDate +T.EndTime Enddate
into #TempSensaname2
from AUTTariff AT
left join AUTBusEventRegisterTarrifCode ABRT on ABRT.TarrifCode=AT.Code
left join AUTBusEventRegister T ON T.Code=ABRT.BusEventRegisterCode
inner join AUTZone zone on zone.Code = AT.ZoneCode
where " + strTariffWhere + @"
<#PreviusSQL#>
";
            string _TempSQL = @"
select AT.Code,T.BusNumber,0 Beja,AT.Date,AT.MinNumOfService,T.NumOfService,ShiftTitle,WorkTitle
,T.DriverPersonCode,(select name from clsAllPerson where code=DriverPersonCode) Name 
, ZoneName,T.LineNumber,T.FirstStationDate,T.LastStationDate,0 TimeLen
from AUTTariff AT
inner join #TempSensaname T ON AT.BusCode=T.BusCode and T.Date=AT.Date and cast(T.FirstStationDate as time) between AT.StartTime and AT.EndTime
where " + strTariffWhere + @"
Union ALL
select AT.Code,(select top 1 BusNumber from AUTBus where Code=(select BusCode from AUTTariff where code=t.TarrifCode)) BusNumber,(select BusNumber from AUTBus where Code= T.BusCodeBeJa) Beja,AT.Date,AT.MinNumOfService,T.NumOfSevice,N'اعزام به '+(select Name from subdefine where code = T.EzamBe),N'کارکرد'
,T.DriverPCode,(select name from clsAllPerson where code=DriverPCode) Name , zone.Name
,(select LineNumber from AUTLine where Code=T.LineCode) LineNumber,T.StartTime,T.FinishTime ,0 TimeLen
from AutTarrifEzamBe T
inner join AUTTariff AT ON AT.Code=T.TarrifCode
inner join AUTZone zone on zone.Code = AT.ZoneCode
where " + strEzamWhere + @"
Union ALL
select Code,BusNumber,beja,Date,MinNumOfService,NumOfSevice,comment ShiftTitle,null WorkTitle,DriverPCode,Name,ZoneName,LineNumber,startdate,enddate,TimeLen from
	(
		select Code,BusNumber,NULL beja, Date,NULL MinNumOfService,NULL NumOfSevice,comment collate Persian_100_CI_AI comment, DriverPCode, Name, ZoneName,LineNumber,startdate,isnull(enddate,startdate) enddate,DATEDIFF(minute,startdate,enddate) TimeLen 
		from #TempSensaname2 
		where BusEventDetailesCode<1000000 group by BusNumber,Date,comment, DriverPCode, Name, ZoneName,LineNumber,Code,startdate,enddate
	) b";
            jGridView.PageOrderByField = "Date";
            jGridView.HiddenColumns = "Code";
            if (cmbReportType.SelectedValue == "1")
                jGridView.SQL += "select BusNumber,beja,Date,MinNumOfService,sum(NumOfService) NumOfService,ShiftTitle,DriverPersonCode,name, ZoneName,LineNumber,min(FirstStationDate) FirstStationDate,max(LastStationDate) LastStationDate from ("
                    + _TempSQL
                    + ") as a group by BusNumber,beja,Date,ShiftTitle,MinNumOfService,DriverPersonCode,Name, ZoneName,LineNumber";
            else
                if (cmbReportType.SelectedValue == "2")
                jGridView.SQL += "select BusNumber,sum(NumOfService) NumOfService,Date,ShiftTitle,min(FirstStationDate) FirstStationDate,max(LastStationDate) LastStationDate from ("
                + _TempSQL
                + ") as a group by BusNumber,Date,ShiftTitle";
            else
            {
                if (cmbReportType.SelectedValue == "3")
                    jGridView.SQL += "select LineNumber,BusNumber,sum(NumOfService) NumOfService,WorkTitle,cast(sum(TimeLen)/60 as nvarchar(10))+N':'+cast(sum(TimeLen)%60 as nvarchar(10)) TimeLen from ("
                    + _TempSQL
                    + ") as a group by LineNumber,BusNumber,WorkTitle";
                jGridView.HiddenColumns = "Code,Date";
                jGridView.PageOrderByField = "BusNumber";
            }

            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.Title = "JBusWorkSheetReportControl";
            jGridView.Buttons = "excel,print,record_print";
            jGridView.SumFields = new Dictionary<string, double>();
            jGridView.SumFields.Add("NumOfService", 0);
            jGridView.Bind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            // try
            //   {
            GetReport(Convert.ToInt32(cmbLine.SelectedValue), Convert.ToInt32(cmbYears.SelectedValue), Convert.ToInt32(cmbMount.SelectedValue));
            // }
            // catch
            // { }
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
    }
}