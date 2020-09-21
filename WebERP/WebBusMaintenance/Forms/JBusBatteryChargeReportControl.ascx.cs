using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusMaintenance.Forms
{
    public partial class JBusBatteryChargeReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int BatteryCharge;
                if (txtCharge.Text != "")
                {
                    if (int.TryParse(txtCharge.Text, out BatteryCharge) == true)
                    {
                        GetReport(Convert.ToInt32(cmbMode.SelectedValue), Convert.ToInt32(txtCharge.Text));
                    }
                }
            }
        }

        public void GetReport(int Mode = 0, int BatteryCharge = 0)
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

            BatteryCharge = BatteryCharge * 5;

            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("WebBusMaintenance_JBusBatteryCharge");
            jGridView.SQL = @"select top 100 percent 1 as Code,BusNumber,
                                CASE WHEN BatteryChargeF < 0 THEN 0 else BatteryChargeF/5 END AS BatteryChargeF
                                ,LastDate from 
                                (SELECT a.BusNumber,(a.LastBatteryCharge-3500) as BatteryChargeF,a.LastDate
                                   FROM AUTBus a
                                WHERE a.[Active]=1)BusBatteryCharge
                                WHERE BatteryChargeF " + StrMode + " " + BatteryCharge.ToString();
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "JBusBatteryChargeReportControl";
            jGridView.Buttons = "excel";
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).GridView = jGridView;
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).LoadGrid(true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int BatteryCharge;
            if (txtCharge.Text != "")
            {
                if (int.TryParse(txtCharge.Text, out BatteryCharge) == true)
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