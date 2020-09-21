using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebOilManagement.Forms
{
    public partial class JNozzleUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        int PumpCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            int.TryParse(Request["PumpCode"], out PumpCode);
            _SetForm();
        }

        public void _SetForm()
        {
            cmbFuelTank.DataSource = OilProductsDistributionCompany.FuelTank.JFuelTankes.GetTitles();
            cmbFuelTank.DataTextField = "Title";
            cmbFuelTank.DataValueField = "Code";
            cmbFuelTank.DataBind();

            cmbPump.DataSource = OilProductsDistributionCompany.Pump.JPumpes.GetTitles();
            cmbPump.DataTextField = "Title";
            cmbPump.DataValueField = "Code";
            cmbPump.DataBind();

            cmbPump.SelectedValue = PumpCode.ToString();

            if (Code > 0)
            {
                OilProductsDistributionCompany.Nozzle.JNozzle jNozzle = new OilProductsDistributionCompany.Nozzle.JNozzle();
                jNozzle.GetData(Code);
                cmbFuelTank.SelectedValue = jNozzle.FuelTankCode.ToString();
                cmbPump.SelectedValue = jNozzle.PumpCode.ToString();
                txtNumber.Text = jNozzle.Number.ToString();
            }
        }

        public bool Save()
        {
            OilProductsDistributionCompany.Nozzle.JNozzle jNozzle = new OilProductsDistributionCompany.Nozzle.JNozzle();
            jNozzle.Code = Code;
            jNozzle.FuelTankCode = Convert.ToInt32(cmbFuelTank.SelectedValue);
            jNozzle.Number = Convert.ToInt32(txtNumber.Text);
            jNozzle.PumpCode = Convert.ToInt32(cmbPump.SelectedValue);

            if (Code > 0)
                return jNozzle.Update();
            else
                return jNozzle.Insert() > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
            else
                WebClassLibrary.JWebManager.ShowMessage("امکان ذخیره اطلاعات وجود ندارد. پس بررسی اطلاعات وارد شده مجددا سعی نمایید.");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            OilProductsDistributionCompany.Nozzle.JNozzle jNozzle = new OilProductsDistributionCompany.Nozzle.JNozzle();
            jNozzle.Code = Code;
            if (jNozzle.Delete())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }
    }
}