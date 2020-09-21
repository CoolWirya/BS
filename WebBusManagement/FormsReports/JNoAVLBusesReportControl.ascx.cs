using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsReports
{
    public partial class JNoAVLBusesReportControl : System.Web.UI.UserControl
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
            string strWhere = " ", strTransactionWhere = "";
            if (BusNumebr > 0)
                strWhere += " and bus.BUSNumber = " + BusNumebr;
            if (Zone > 0)
                strWhere += " and zone.Code = " + Zone;
            if (Line > 0)
                strWhere += " and line.Code = " + Line;
            if (StartEventDate.HasValue && EndEventDate.HasValue)
                strTransactionWhere += " and EventDate between '" + StartEventDate.Value.ToShortDateString() + " 00:00:00' and '" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + " 23:59:59'";
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;
            jGridView.ClassName = "WebBusManagement_FormsReports_JNoAVLBusesReportControl_" + BusNumebr.ToString() + "_"
                + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_"
                + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + "_" + Zone.ToString() + "_" + Line.ToString();
            jGridView.SQL = @"
                select BusCode, COUNT(*) AVLCount into #tmpAVL from AUTAvlTransaction where 1=1 " + strTransactionWhere + @"
                group by BusCode 

                select BusCode, COUNT(*) TicketCount into #tmpTicket from AUTTicketTransaction where 1=1 " + strTransactionWhere + @"
                group by BusCode 

                <#PreviusSQL#>

                select bus.Code, bus.BUSNumber, zone.Name ZoneName, bus.LastLineNumber LineNumber,aht.ConsulVersion, ticket.TicketCount
                ,isnull((select AVLCount from #tmpAVL where BusCode = ticket.BusCode), 0) AVLCount, bus.LastDate AvlLastDate
                from #tmpTicket ticket
                inner join AUTBus bus on bus.Code = ticket.BusCode
                left join AUTLine line on line.LineNumber = bus.LastLineNumber
                left join AUTZone zone on zone.Code = line.ZoneCode
                left join
                        (
                            select BusSerial,IMEI, ConsulVersion from
                            (
                            select BusSerial,IMEI, cast(cast(substring([Version],1,1) AS INT)AS NVARCHAR)+
                                                                cast(cast(substring([Version],2,1) AS INT)AS NVARCHAR)+
                                                                cast(cast(substring([Version],3,1) AS INT)AS NVARCHAR) ConsulVersion, ROW_NUMBER() over (partition by BusSerial order by date desc) row_numb from AUTHeaderTransaction
                            ) aht where row_numb = 1
                        ) aht on aht.BusSerial = bus.BUSNumber
                where not exists(select 1 from #tmpAVL where BusCode = ticket.BusCode and AVLCount > 4)
                and bus.IsValid=1
                          " + strWhere;
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            //jGridView.HiddenColumns = "Code";
            jGridView.Title = "NoAVLBusesReport";
            jGridView.PageOrderByField = "ZoneName, LineNumber";
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