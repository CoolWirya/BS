using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JBusSendDataReportControl : System.Web.UI.UserControl
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
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            string WhereStr = " where 1=1 ";
            if (BusNumebr > 0)
                WhereStr += " and BusNumber = " + BusNumebr;
            if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
            {
                DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day);
                DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day);
                WhereStr += @" and (LastDate Between '" + StartDTime.ToShortDateString() + " 00:00:00' and '" + EndDTime.ToShortDateString() +
                    " 23:59:59' or TicketLastDate Between '" + StartDTime.ToShortDateString() + " 00:00:00' and '" + EndDTime.ToShortDateString() + " 23:59:59')";
            }

           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusManagement_FormsMaintenance");
           jGridView.ClassName = "WebBusManagement_FormsMaintenance_JBusSendAvlTransenctionReport" + BusNumebr.ToString() + "_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "");
            jGridView.SQL = @"select Code,BusNumber,LastDate as AvlLastDate,TicketLastDate from AutBus"
                            + WhereStr;
            //jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.PageOrderByField = "BusNumber asc";
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusSendDataReportControl";
            jGridView.Buttons = "excel";
            //jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            //jGridView.Toolbar.AddButton("BusDetailsReport", "BusDetailsReport", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, "WebBusManagement.JBusManagement" + "._FleetUpdate", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Report));
            jGridView.Actions = new List<WebClassLibrary.JActionsInfo>();
            //jGridView.Actions.Add(new WebClassLibrary.JActionsInfo("Menu", WebClassLibrary.JDomains.JActionEvents.GridItemRightClick, "WebBusManagement.FormsMaintenance.JBusSendDataReportControl" + "._BusDetails", null, null));
            jGridView.Actions.Add(new WebClassLibrary.JActionsInfo("GridItemDblClick", WebClassLibrary.JDomains.JActionEvents.GridItemDblClick, "WebBusManagement.FormsMaintenance.JBusSendDataReportControl" + "._BusDetails", null, null));
            jGridView.Bind();
            
        }

        public string _BusDetails(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("BusDetails"
                  , "~/WebBusManagement/FormsMaintenance/JBusDetailsReportControl.ascx"
                  , "جزئیات اتوبوس ها"
                  , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                  , WebClassLibrary.WindowTarget.NewWindow
                  , true, true, true, 600, 350);
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