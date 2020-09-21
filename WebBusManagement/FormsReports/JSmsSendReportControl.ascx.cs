using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsReports
{
    public partial class JSmsSendReportControl : System.Web.UI.UserControl
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
                btnSave_Click(null, null);
            }
        }

        public void GetReport(DateTime? StartEventDate = null, DateTime? EndEventDate = null)//
        {
            string WhereStr = "";
            //if (StartEventDate.HasValue && EndEventDate.HasValue)
            WhereStr += " and SendDate between '{0}' and '{1}'";
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;
            jGridView.ClassName = "WebBusManagement_FormsReports_JSmsSendReportControl";
            jGridView.SQL = @"select Code, Mobile, Text MessageText, SendDate Send_Date, DeliveryDate from SMSSend where 1 = 1 " + WhereStr;
            jGridView.Parameters = new object[] { StartEventDate.Value.ToShortDateString() + " 00:00:00", EndEventDate.Value.ToShortDateString() + " 23:59:59" };
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 10;
            //jGridView.HiddenColumns = "Code";
            jGridView.Title = "SmsSendReport";
            jGridView.PageOrderByField = " Code Desc";
            jGridView.Buttons = "excel,print,record_print,refresh";
            jGridView.Bind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            GetReport(((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
        }
    }
}