using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JBusOwnerReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBus();
                LoadBusOwner();
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now.AddMonths(-1));
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
            }
            else
            {
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

        public void LoadBusOwner()
        {
            DataTable dt = BusManagment.Bus.JBusOwners.GetBusOwners();
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, Name = "همه" });
            cmbBusOwner.DataSource = p;
            cmbBusOwner.DataTextField = "Name";
            cmbBusOwner.DataValueField = "Code";
            cmbBusOwner.DataBind();
        }

        public void GetReport(int OwnerCode = 0, int BusNumebr = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null)
        {
            string whereStr = " where 1 = 1 ";
            if (OwnerCode > 0)
                whereStr += " and abo.CodePerson = " + OwnerCode;
            if (BusNumebr > 0)
                whereStr += " and abo.BusCode = " + BusNumebr;
            if (StartEventDate.HasValue & EndEventDate.HasValue)
                whereStr += " and abo.StartDate <= '" + StartEventDate.Value.ToShortDateString() + " 00:00:00' and abo.EndDate >= '" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "") + " 23:59:59'";
           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusReports_JBusOwnerReportControl");
           jGridView.ClassName = "WebBusManagement_FormsMaintenance_JBusOwnerReportControl" + OwnerCode.ToString() + "_" + BusNumebr.ToString() + "_" + (StartEventDate != null ? StartEventDate.Value.ToShortDateString() : "") + "_" + (EndEventDate != null ? EndEventDate.Value.ToShortDateString() : "");
            //jGridView.ClassName = "WebBusReports_JBusReports_GetReport";
            jGridView.SQL = @"select abo.Code , ab.BUSNumber , cap.Name OwnerName , StartDate , EndDate , case IsActive when 1 then N'فعال' else N'غیر فعال' end as Status from AUTBusOwner abo
                                left join AUTBus ab on abo.BusCode = ab.Code
                                left join clsAllPerson cap on cap.Code = abo.CodePerson " + whereStr;
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.PageOrderByField = "StartDate desc";
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusOwnerReportControl";
            jGridView.Buttons = "excel,print,record_print";
            jGridView.Bind();
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            GetReport(Convert.ToInt32(cmbBusOwner.SelectedValue), Convert.ToInt32(cmbBus.SelectedValue),
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
        }


    }
}