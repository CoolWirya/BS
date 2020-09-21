using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsReports
{
    public partial class JBusAVLCutReportControl : System.Web.UI.UserControl
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
                LoadBus();
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
        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, BUSNumber = "همه" });
            cmbBus.DataSource = p;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }

        public void GetReport(int BusNumebr = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int Zone = 0, int Line = 0)
        {
            string strWhere = " ";
            if (BusNumebr > 0)
                strWhere += " and bus.BUSNumber = " + BusNumebr;
            if (Zone > 0)
                strWhere += " and zone.Code = " + Zone;
            if (Line > 0)
                strWhere += " and line.Code = " + Line;
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;
            jGridView.ClassName = "WebBusManagement_FormsReports_JBusAVLCutReportControl_" + BusNumebr.ToString() + "_"
                + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_"
                + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + "_" + Zone.ToString() + "_" + Line.ToString();
            jGridView.SQL = @"
select BusCode, lag(EventDate, 1, null) over (partition by BusCode order by EventDate) CutStart, EventDate  CutEnd
into #tmpAVL
from dbo.AUTAvlTransaction where EventDate between '{0}' and '{1}'

select aber.BusCode, abed.Code EventDetailCode, aber.StartDate + aber.StartTime EventDate into #tmpEvent
from AUTBusEventRegisterTarrifCode abrtc
inner join AUTBusEventRegister aber on aber.Code = abrtc.BusEventRegisterCode
left join AUTBusEventDetailes abed on abed.Code = aber.BusEventDetailesCode
left join AUTBusEvent abe on abe.Code = abed.BusEventCode
where aber.StartDate between '{0}' and '{1}' and abed.Code in (1000005, 1000011)

select a.BusCode, a.EventDate OnDate
, (select min(b.EventDate) from #tmpEvent b where b.BusCode = a.BusCode and b.EventDetailCode = 1000011 and b.EventDate > a.EventDate) OffDate 
into #tmpBusOnOffDate
from #tmpEvent a where EventDetailCode = 1000005

<#PreviusSQL#>

select bus.BUSNumber Code, bus.BUSNumber, zone.Name ZoneName, bus.LastLineNumber LineNumber, avl.CutStart, avl.CutEnd 
from #tmpAVL avl
inner join AUTBus bus on bus.Code = avl.BusCode
inner join AUTLine line on line.LineNumber = bus.LastLineNumber
inner join AUTZone zone on zone.Code = line.ZoneCode
where DATEDIFF(minute, CutStart, CutEnd) > 10
and not exists(select*from #tmpBusOnOffDate b where b.BusCode = avl.BusCode and b.OffDate > avl.CutStart and b.OnDate < avl.CutEnd)
                          " + strWhere;
            jGridView.Parameters = new object[] { StartEventDate.Value.ToShortDateString() + " 00:00:00", EndEventDate.Value.ToShortDateString() + " 23:59:59" };
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            //jGridView.HiddenColumns = "Code";
            jGridView.Title = "BusAVLCutReport";
            jGridView.PageOrderByField = "ZoneName, LineNumber, BUSNumber, CutStart";
            jGridView.Buttons = "excel,print,record_print";
            jGridView.Bind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //InitialReport = false;
            try
            {
                if (cmbBus.SelectedValue == "0")
                {
                    GetReport(0, ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                    ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(), Convert.ToInt32(cmbZone.SelectedItem.Value)
                    , Convert.ToInt32(cmbLine.SelectedItem.Value)
                    );
                }
                else
                {
                    GetReport(Convert.ToInt32(cmbBus.SelectedItem.Text), ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                    ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(), Convert.ToInt32(cmbZone.SelectedItem.Value)
                    , Convert.ToInt32(cmbLine.SelectedItem.Value)
                    );
                }

            }
            catch { }
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

                DataTable dtBus = WebClassLibrary.JWebDataBase.GetDataTable(@"Select Code,BusNumber from AUTBus Where Active = 1 
                                                                              and LastLineNumber in (SELECT LineNumber FROM AUTLine 
                                                                              Where ZoneCode = " + cmbZone.SelectedValue + ") Order By BusNumber ASC");
                var p2 = (from v in dtBus.AsEnumerable()
                          select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
                p2.Insert(0, new { Code = 0, BUSNumber = "همه" });
                cmbBus.DataSource = p2;
                cmbBus.DataTextField = "BUSNumber";
                cmbBus.DataValueField = "Code";
                cmbBus.DataBind();
            }
            else
            {
                LoadLines();
                LoadBus();
            }
        }

        protected void cmbLine_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (Convert.ToInt32(cmbLine.SelectedValue) > 0)
            {
                DataTable dtBus = WebClassLibrary.JWebDataBase.GetDataTable(@"Select Code,BusNumber from AUTBus Where Active = 1 
                                                                              and LastLineNumber in (SELECT LineNumber FROM AUTLine 
                                                                              Where Code = " + cmbLine.SelectedValue + ") Order By BusNumber ASC");
                var p2 = (from v in dtBus.AsEnumerable()
                          select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
                p2.Insert(0, new { Code = 0, BUSNumber = "همه" });
                cmbBus.DataSource = p2;
                cmbBus.DataTextField = "BUSNumber";
                cmbBus.DataValueField = "Code";
                cmbBus.DataBind();
            }
            else
            {
                LoadZones();
                LoadBus();
            }
        }
    }
}