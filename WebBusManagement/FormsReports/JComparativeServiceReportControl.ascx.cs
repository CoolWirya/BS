using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsReports
{
    public partial class JComparativeServiceReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {


                //   btnSave_Click(null, null);
            }
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                LoadBus();
                LoadFleets();
                LoadZones();
                LoadLines();

            }
        }

        public void LoadFleets()
        {
            DataTable dt = BusManagment.Fleet.JFleets.GetDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, Name = "همه" });
            cmbFleets.DataSource = p;
            cmbFleets.DataTextField = "Name";
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

        public void GetReport(int BusNumebr = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int Zone = 0,
            int Fleet = 0, int Line = 0)
        {
            string WhereStr = " ";
            if (BusNumebr > 0)
                WhereStr += " and ISNULL(ISNULL(ISNULL(Srv.BusNumber,GPS.BusNumber),Bazras.BusNumber),Manuel.BusNumber) = " + BusNumebr;
            if (Zone > 0)
                WhereStr += " and zone.Code = " + Zone;
            if (Fleet > 0)
                WhereStr += " and line.Fleet = " + Fleet;
            if (Line > 0)
                WhereStr += " and line.Code = " + Line;
            //if (StartEventDate.HasValue && EndEventDate.HasValue)
            //WhereStr += " and a.Date between '" + StartEventDate.Value.ToShortDateString() + " 00:00:00' and '" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + " 23:59:59'";
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;
            jGridView.ClassName = "WebBusManagement_FormsReports_JComparativeServiceReportControl_" + BusNumebr.ToString() + "_"
                + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_"
                + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + "_" + Zone.ToString()
                + "_" + Fleet.ToString() + "_" + Line.ToString();
            jGridView.SQL = @"
select *
into #tblServices
from AutBusServices 
where Date between '{0}' and '{1}'
<#PreviusSQL#>
select ISNULL(ISNULL(ISNULL(Srv.BusNumber,GPS.BusNumber),Bazras.BusNumber),Manuel.BusNumber) Code
,ISNULL(ISNULL(ISNULL(Srv.BusNumber,GPS.BusNumber),Bazras.BusNumber),Manuel.BusNumber) BusNumber, line.LineNumber,zone.Name ZoneName, Srv.Date
,isnull(GPS.count, 0) GPSService, isnull(Bazras.count, 0) BazrasService, isnull(Manuel.count, 0) ManuelService, isnull(Srv.count, 0) NumOfService
from
(
select LineNumber, BusNumber, Date, count(*) count
from #tblServices 
where IsOk in (0, 1, 2, 5, 10, 11) and Deleted = 0
group by LineNumber, BusNumber, Date
) Srv
full join 
(
select LineNumber, BusNumber, Date, count(*) count
from #tblServices 
where IsOk in (1,10)
group by LineNumber, BusNumber, Date
) Manuel on Manuel.LineNumber = Srv.LineNumber and Manuel.BusNumber = Srv.BusNumber and Manuel.Date = Srv.Date
full join
(
select LineNumber, BusNumber, Date, count(*) count
from #tblServices 
where IsOk in (0, 2, 5)
group by LineNumber, BusNumber, Date
) GPS on GPS.LineNumber = Srv.LineNumber and GPS.BusNumber = Srv.BusNumber and GPS.Date = Srv.Date
full join
(
select LineNumber, BusNumber, cast(MoveDate as Date) Date, 2*count(*) count
from AUTBazRasService
where MoveDate between '{0}' and '{1}'
group by LineNumber, BusNumber, cast(MoveDate as Date)
) Bazras on Bazras.LineNumber = Srv.LineNumber and Bazras.BusNumber = Srv.BusNumber and Bazras.Date = Srv.Date
inner join AUTLine line on line.LineNumber = Srv.LineNumber or line.LineNumber = GPS.LineNumber 
	or line.LineNumber = Manuel.LineNumber or line.LineNumber = Bazras.LineNumber
inner join AUTZone zone on zone.Code = line.ZoneCode
where 1=1 " + WhereStr;
            jGridView.Parameters = new object[] { StartEventDate.Value.ToShortDateString() + " 00:00:00", EndEventDate.Value.ToShortDateString() + " 23:59:59" };
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            //jGridView.HiddenColumns = "Code";
            jGridView.Title = "ComparativeServiceReport";
            jGridView.PageOrderByField = " ZoneName, LineNumber, BusNumber, Date desc";
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
                    , Convert.ToInt32(cmbFleets.SelectedItem.Value), Convert.ToInt32(cmbLine.SelectedItem.Value)
                    );
                }
                else
                {
                    GetReport(Convert.ToInt32(cmbBus.SelectedItem.Text), ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                    ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(), Convert.ToInt32(cmbZone.SelectedItem.Value)
                    , Convert.ToInt32(cmbFleets.SelectedItem.Value), Convert.ToInt32(cmbLine.SelectedItem.Value)
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
                //                DataTable dtZones = WebClassLibrary.JWebDataBase.GetDataTable(@"select * from AUTZone Where Code =
                //                    (Select ZoneCode From AutLine Where Code = " + cmbLine.SelectedValue + ")");
                //                var p = (from v in dtZones.AsEnumerable()
                //                         select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
                //                p.Insert(0, new { Code = 0, Name = "همه" });
                //                cmbZone.DataSource = p;
                //                cmbZone.DataTextField = "Name";
                //                cmbZone.DataValueField = "Code";
                //                cmbZone.DataBind();

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