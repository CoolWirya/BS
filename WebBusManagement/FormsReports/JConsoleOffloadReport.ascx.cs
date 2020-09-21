using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsReports
{
    public partial class JConsoleOffloadReport : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {


                //btnSave_Click(null, null);
            }
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                LoadBus();
                //GetReport();
                btnSave_Click(null, null);
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

        public void GetReport(int BusNumber = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null)//
        {
            string WhereStr = "";
            if (BusNumber > 0)
                WhereStr += " and att.BUSNumber = " + BusNumber;
            if (StartEventDate.HasValue && EndEventDate.HasValue)
            {
                DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day);
                DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day);
                WhereStr += @" and cast(at.RecievedDate as Date) between  '" + StartDTime.ToString("yyyy-MM-dd") + "' and '" + EndDTime.ToString("yyyy-MM-dd") + "'";
            }

            //if (StartEventDate.HasValue && EndEventDate.HasValue)
            //WhereStr += " and Cast(at.RecievedDate as Date) between '{0}' and '{1}'";
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;//new WebControllers.MainControls.Grid.JGridView("WebBusManagement_FormsReports_JTariffReportControl");
            jGridView.ClassName = "WebBusManagement_FormsReports_JConsoleOffloadReport_" + BusNumber.ToString() ;
            jGridView.SQL = @"select at.code,att.BusNumber, att.EventDate,at.RecievedDate from server02.erp_tabrizbus.dbo.auttickettransactioncitybank at
                              right join  AUTTicketTransaction att on at.Code=att.Code
                              where 1=1  " + WhereStr;
            //jGridView.Parameters = new object[] { StartEventDate.Value.ToShortDateString() + " 00:00:00", EndEventDate.Value.ToShortDateString() + " 23:59:59" };
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            //jGridView.HiddenColumns = "Code";
            jGridView.Title = "JConsoleOffload";
            jGridView.PageOrderByField = " recieveddate Desc";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Buttons = "excel,print,record_print,refresh";

            //
            jGridView.Bind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbBus.SelectedValue == "0")
                {
                    GetReport(0, ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                        ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate()
                        );
                }
                else
                {
                    GetReport(Convert.ToInt32(cmbBus.SelectedItem.Text), ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                            ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
                }
            }
            catch { }
        }
    }
}