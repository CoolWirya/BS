using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JBusSimCardChargeReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int SimCharge;
                if (txtCharge.Text != "")
                {
                    if (int.TryParse(txtCharge.Text, out SimCharge) == true)
                    {
                        GetReport(Convert.ToInt32(cmbMode.SelectedValue), Convert.ToInt32(txtCharge.Text));
                    }
                }
            }
        }

        public void GetReport(int Mode = 0, int SimCardCharge = 0)
        {
            string StrMode = "";
            if (Mode == 0)
            {
                StrMode = "<";
            }
            else if (Mode == 1)
            {
                StrMode = ">";
            }
            else if (Mode == 2)
            {
                StrMode = "=";
            }
           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusMaintenance_JBusMaintenance_GetReportSimCardCharge");
           jGridView.ClassName = "WebBusManagement_FormsMaintenance_GetReportSimCardCharge" + Mode.ToString() + "_" + SimCardCharge.ToString();
            jGridView.SQL = @"SELECT distinct a.Code,a.BusNumber,a.LastSimCardCharge,a.LastDate,a.TicketLastDate,a.LastLineNumber,a3.Name,
                                ISNULL(ah.IMEI,0)IMEI,ISNULL(ad.TEL,0)TEL
                                FROM AUTBus a 
                                LEFT JOIN AUTLine a2 ON a.LastLineNumber = a2.LineNumber
                                LEFT JOIN AUTZone a3 ON a2.ZoneCode = a3.Code
								left join AUTHeaderTransaction ah on ah.Code = a.LastHeaderTransactionCode
								left join AUTDevice ad on ad.IMEI = ah.IMEI
                                WHERE a.[Active]=1 and a.LastDate is not null and a.LastSimCardCharge " + StrMode + @"" + SimCardCharge.ToString();
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.PageOrderByField = "LastDate desc";
            jGridView.Title = "JSimCardChargeReportControl";
            jGridView.Buttons = "excel";

            jGridView.Bind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int SimCharge;
            if (txtCharge.Text != "")
            {
                if (int.TryParse(txtCharge.Text, out SimCharge) == true)
                {
                    GetReport(Convert.ToInt32(cmbMode.SelectedValue), Convert.ToInt32(txtCharge.Text));
                }
                else
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('لطفا عدد وارد کنید');", "UpdateSettings");
                }
            }
            else
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفا میزان شارژ را وارد کنید');", "UpdateSettings");
            }
        }

    }
}