using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsReports
{
    public partial class JServicingStatusReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
            }
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                LoadZones();
                LoadLines();
                btnSave_Click(null, null);
            }
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

        public void LoadLines()
        {
            DataTable dt = BusManagment.Line.JLines.GetWebDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), lineName = v["lineName"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, lineName = "همه" });
            cmbLine.DataSource = p;
            cmbLine.DataTextField = "lineName";
            cmbLine.DataValueField = "Code";
            cmbLine.DataBind();
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

        void GetReport(DateTime? StartEventDate = null, DateTime? EndEventDate = null, int TotalDays = 0, int Zone = 0, int Line = 0)
        {
            string WhereStr = " ";
            string WhereStrSub = " ";
            if (Zone > 0)
            {
                WhereStr += " and line.ZoneCode = " + Zone;
                WhereStrSub += " and ZoneCode = " + Zone;
            }
            if (Line > 0)
            {
                WhereStr += " and line.Code = " + Line;
                WhereStrSub += " and LineCode = " + Line;
            }
            WhereStr += " and service.Date between '" + StartEventDate.Value.ToShortDateString() + "' and '" + EndEventDate.Value.ToShortDateString() + "'";
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;//new WebControllers.MainControls.Grid.JGridView("WebBusManagement_FormsReports_JServicingStatusReportControl");
            jGridView.ClassName = "WebBusManagement_FormsReports_JServicingStatusReportControl_NEW_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + "_" + TotalDays + "_" + Zone + "_" + Line;
            jGridView.SQL = @"
                select ROW_NUMBER()OVER(order by LineNumber)Code ,(select Name from AUTZone where code =  ZoneCode) Zone,LineNumber,OrganizationalBus,OrganizationalService,DoneServiceCount,OrganizationalService-DoneServiceCount KasrService,case when OrganizationalService=0 then 0 else (OrganizationalService-DoneServiceCount)*100/OrganizationalService end DarsdKasrService,DayKind
                , case when OrganizationalService=0 then 0 else cast(cast(DoneServiceCount as float)*OrganizationalBus/OrganizationalService as decimal(6,2)) end BusReal from (
							select service.LineNumber,line.ZoneCode,
	                            (select FLOOR(sum(c)*1.0/count(*)) from (select Date,count(*)c from(select Distinct buscode,Date from AUTTariff where 1=1 " + WhereStrSub + " and AUTTariff.LineCode=line.Code and AUTTariff.Date  between '" + StartEventDate.Value.ToShortDateString() + "' and '" + EndEventDate.Value.ToShortDateString() + @"' and AUTTariff.Date not in (select Date from AUTHolidays where AUTHolidays.date between '" + StartEventDate.Value.ToShortDateString() + "' and '" + EndEventDate.Value.ToShortDateString() + @"' ))a group by Date)a) OrganizationalBus,
	                            (select sum(AUTTariff.MinNumOfService) from AUTTariff where 1=1 " + WhereStrSub + " and AUTTariff.LineCode=line.Code and AUTTariff.Date  between '" + StartEventDate.Value.ToShortDateString() + "' and '" + EndEventDate.Value.ToShortDateString() + @"' and AUTTariff.Date not in (select Date from AUTHolidays where AUTHolidays.date between '" + StartEventDate.Value.ToShortDateString() + "' and '" + EndEventDate.Value.ToShortDateString() + @"' ) ) OrganizationalService,
	                            sum(DoneServiceCount) DoneServiceCount,
								N'روز عادی' DayKind
                            from (select LineNumber,Date,sum(DoneServiceCount) DoneServiceCount from AUTServicingStatus group by LineNumber,Date) service
                            left join AUTLine line on line.LineNumber = service.LineNumber
                            where 1=1 " + WhereStr + @" and not exists(select code from AUTHolidays where AUTHolidays.date = service.Date)
                            group by service.LineNumber,line.ZoneCode,line.Code
                            union all
                            select service.LineNumber,line.ZoneCode,
	                            (select FLOOR(sum(c)*1.0/count(*)) from (select Date,count(*)c from(select Distinct buscode,Date from AUTTariff where 1=1 " + WhereStrSub + " and AUTTariff.LineCode=line.Code and AUTTariff.Date  between '" + StartEventDate.Value.ToShortDateString() + "' and '" + EndEventDate.Value.ToShortDateString() + @"' and AUTTariff.Date in (select Date from AUTHolidays where AUTHolidays.date between '" + StartEventDate.Value.ToShortDateString() + "' and '" + EndEventDate.Value.ToShortDateString() + @"' ))a group by Date)a) OrganizationalBus,
	                            (select sum(AUTTariff.MinNumOfService) from AUTTariff where 1=1 " + WhereStrSub + " and AUTTariff.LineCode=line.Code and AUTTariff.Date between '" + StartEventDate.Value.ToShortDateString() + "' and '" + EndEventDate.Value.ToShortDateString() + @"' and AUTTariff.Date in (select Date from AUTHolidays where AUTHolidays.date between '" + StartEventDate.Value.ToShortDateString() + "' and '" + EndEventDate.Value.ToShortDateString() + @"' ) ) Organizational,
	                            sum(DoneServiceCount) DoneServiceCount,
	                            N'روز تعطیل' DayKind
							from (select LineNumber,Date,sum(DoneServiceCount) DoneServiceCount from AUTServicingStatus group by LineNumber,Date) service
                            left join AUTLine line on line.LineNumber = service.LineNumber
                            where 1=1 " + WhereStr + @" and exists(select code from AUTHolidays where AUTHolidays.date = service.Date)
                            group by service.LineNumber,line.ZoneCode,line.Code
		    )a
";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code, DayKind desc";
            jGridView.Title = "JBusServiceReportControl";
            jGridView.PageOrderByField = " Code";
            jGridView.Buttons = "excel,print,record_print";
            jGridView.Bind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int TotalDays = 1;
            try
            {
                TotalDays = Convert.ToInt32((((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate()
                    - ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate()).TotalDays) + 1;
            }
            catch
            {
            }
            GetReport(
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(),
                TotalDays,
                Convert.ToInt32(cmbZone.SelectedValue),
                Convert.ToInt32(cmbLine.SelectedItem.Value));
        }
    }
}