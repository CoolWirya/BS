using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JInvalidLinePriceReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBus();
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
            }
            else
            {
                if (cmbBus.SelectedValue == "0")
                {
                    GetReport(Convert.ToDouble(0),
                                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                                ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
                }
                else
                {
                    GetReport(Convert.ToDouble(cmbBus.SelectedItem.Text),
                                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                                ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
                }
            }
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

        public void GetReport(double BusNumebr = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            string BusNumberWhere = "";
            if (BusNumebr > 0)
            {
                BusNumberWhere = "and autt.BusNumber = " + BusNumebr;
            }
            DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day);
            DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day);
           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusMaintenance_JInvalidLinePriceReportControl");
           jGridView.ClassName = "WebBusManagement_FormsMaintenance_JInvalidLinePriceReportControl" + BusNumebr.ToString()+"_"+(StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "")+"_"+ (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "");
            jGridView.SQL = @"select autt.Code,autt.BusNumber,autt.EventDate,autt.LineNumber,
                                autt.TicketPrice,autt.CardType
                                from AUTTicketTransaction autt
                                where autt.TicketPrice not in 
                                (select Price from AutPrice where LineCode = (select Code From AutLine where LineNumber = autt.LineNumber))
                                and 
                                autt.EventDate Between '" + StartDTime.ToShortDateString() + @" 00:00:00' and '" + EndDTime.ToShortDateString() + @" 23:59:59'"
                                + BusNumberWhere;
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.PageOrderByField = "EventDate desc";
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JInvalidLinePriceReportControl";
            jGridView.Buttons = "excel";
            jGridView.Bind();
            
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbBus.SelectedValue == "0")
            {
                GetReport(Convert.ToDouble(0),
                            ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                            ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
            }
            else
            {
                GetReport(Convert.ToDouble(cmbBus.SelectedItem.Text),
                            ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                            ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
            }
        }

    }
}