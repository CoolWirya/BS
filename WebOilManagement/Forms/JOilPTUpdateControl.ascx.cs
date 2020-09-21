using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebOilManagement.Forms
{
    public partial class JPTUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            _SetForm();
        }

        public void _SetForm()
        {
            if (!IsPostBack)
            {
                DataTable dt = OilProductsDistributionCompany.GasStation.JGasStationes.GetTitles();
                cmbGasStation.DataSource = dt;
                cmbGasStation.DataTextField = "Title";
                cmbGasStation.DataValueField = "Code";
                cmbGasStation.DataBind();
            }

            if (Code > 0)
            {
                OilProductsDistributionCompany.PT.JPT jPT = new OilProductsDistributionCompany.PT.JPT();
                jPT.GetData(Code);
                txtNumber.Text = jPT.PTNumber.ToString();
                cmbNozzle.SelectedValue = jPT.NozzleCode.ToString();
                OilProductsDistributionCompany.Nozzle.JNozzle jNozzle = jPT.GetNozzle();
                int pumpCode = jNozzle.PumpCode;
                int gasStationCode = jNozzle.GetPump().GasStationCode;

                cmbGasStation.SelectedValue = gasStationCode.ToString();

                cmbPump.DataSource = OilProductsDistributionCompany.Pump.JPumpes.GetDataTableByGasStationCode(gasStationCode);
                cmbPump.DataTextField = "Title";
                cmbPump.DataValueField = "Code";
                cmbPump.DataBind();
                cmbPump.SelectedValue = pumpCode.ToString();

                cmbNozzle.DataSource = OilProductsDistributionCompany.Nozzle.JNozzleses.GetDataTableByPumpCode(pumpCode);
                cmbNozzle.DataTextField = "Title";
                cmbNozzle.DataValueField = "Code";
                cmbNozzle.DataBind();

                cmbNozzle.SelectedValue = jPT.NozzleCode.ToString();
            }
            //else
            //{
            //    if (cmbGasStation.Items.Count > 0)
            //    {
            //        cmbGasStation.SelectedIndex = 0;
            //        cmbGasStation_SelectedIndexChanged(null, new Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs("", "", cmbGasStation.SelectedValue, ""));
            //    }
            //}
        }

        public bool Save()
        {
            OilProductsDistributionCompany.PT.JPT jPT = new OilProductsDistributionCompany.PT.JPT();

            jPT.Code = Code;
            if (!string.IsNullOrEmpty(cmbNozzle.SelectedValue) && txtNumber.Text != string.Empty)
            {
                jPT.NozzleCode = Convert.ToInt32(cmbNozzle.SelectedValue);
                jPT.PTNumber = Convert.ToInt32(txtNumber.Text);
            }
            else
                return false;
            if (Code > 0)
                return jPT.Update();
            else
                return jPT.Insert() > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }

        protected void cmbGasStation_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            cmbPump.Text = "";
            cmbNozzle.Items.Clear();
            cmbNozzle.Text = "";
            int x = 0;
            int.TryParse(e.Value, out x);
            DataTable dt = OilProductsDistributionCompany.Pump.JPumpes.GetDataTableByGasStationCode(x);
            cmbPump.DataSource = dt;
            cmbPump.DataTextField = "Title";
            cmbPump.DataValueField = "Code";
            cmbPump.DataBind();
        }

        protected void cmbPump_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            cmbNozzle.Text = "";
            int x = 0;
            int.TryParse(e.Value, out x);
            cmbNozzle.DataSource = OilProductsDistributionCompany.Nozzle.JNozzleses.GetDataTableByPumpCode(x);
            cmbNozzle.DataTextField = "Title";
            cmbNozzle.DataValueField = "Code";
            cmbNozzle.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            OilProductsDistributionCompany.PT.JPT jPT = new OilProductsDistributionCompany.PT.JPT();
            jPT.Code = Code;
            if (jPT.Delete())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }
    }
}