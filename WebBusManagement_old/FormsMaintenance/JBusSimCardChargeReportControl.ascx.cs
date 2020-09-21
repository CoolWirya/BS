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
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("WebBusMaintenance_JBusMaintenance");
            jGridView.SQL = @"SELECT distinct a.Code,a.BusNumber,a.LastSimCardCharge,ade.Tel,at.LineNumber,a3.Name FROM AUTBus a 
                                LEFT JOIN AUTTicketTransaction at ON a.Code = at.BusCode AND a.TicketLastDate = at.EventDate
                                LEFT JOIN AUTLine a2 ON at.LineNumber = a2.LineNumber
                                LEFT JOIN AUTZone a3 ON a2.ZoneCode = a3.Code
                                LEFT JOIN AUTBusDevise ao ON a.Code = ao.BusCode
                                LEFT JOIN AUTDevice ade ON ao.DeviceCode = ade.Code
                                WHERE a.[Active]=1 and a.LastSimCardCharge" + StrMode + @"" + SimCardCharge.ToString();
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JSimCardChargeReportControl";
            jGridView.Buttons = "excel";
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).GridView = jGridView;
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).LoadGrid(true);
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