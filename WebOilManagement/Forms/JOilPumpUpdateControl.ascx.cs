using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebOilManagement.Forms
{
    public partial class JOilPumpUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            _SetForm();
        }

        public void _SetForm()
        {
            cmbGasStation.DataSource = OilProductsDistributionCompany.GasStation.JGasStationes.GetTitles();
            cmbGasStation.DataTextField = "Title";
            cmbGasStation.DataValueField = "Code";
            cmbGasStation.DataBind();

            cmbPump.DataSource = OilProductsDistributionCompany.Define.JTypesOfPumps.GetDataTable(OilProductsDistributionCompany.JDefine.TypeOfPumps);
            cmbPump.DataTextField = "Name";
            cmbPump.DataValueField = "Code";
            cmbPump.DataBind();




            if (Code > 0)
            {
                OilProductsDistributionCompany.Pump.JPump jPump = new OilProductsDistributionCompany.Pump.JPump();
                jPump.GetData(Code);
                txtNumber.Text = jPump.Number.ToString();
                cmbGasStation.SelectedValue = jPump.GasStationCode.ToString();
                cmbPump.SelectedValue = jPump.TypeOfPumpCode.ToString();
                rgNozzel.DataSource = OilProductsDistributionCompany.Nozzle.JNozzleses.GetDataTableByPumpCode(Code);
                rgNozzel.DataBind();
            }
        }

        public bool Save()
        {
            OilProductsDistributionCompany.Pump.JPump jPump = new OilProductsDistributionCompany.Pump.JPump();
            jPump.Code = Code;
            jPump.Number = Convert.ToInt32(txtNumber.Text);
            jPump.TypeOfPumpCode = Convert.ToInt32(cmbPump.SelectedValue);
            jPump.GasStationCode = Convert.ToInt32(cmbGasStation.SelectedValue);

            if (Code > 0)
                return jPump.Update();
            else
                return jPump.Insert() > 0 ? true : false;
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
            OilProductsDistributionCompany.Pump.JPump jPump = new OilProductsDistributionCompany.Pump.JPump();
            jPump.Code = Code;
            if (jPump.Delete())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }

        protected void cmbPump_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {

            }
            catch
            {

            }
        }

        protected void btnJOilNozzle_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (Code > 0)
                    WebClassLibrary.JWebManager.LoadControl("Goods"
                  , "~/WebOilManagement/Forms/JOilNozzleUpdateControl.ascx"
                  , " درج نازل "
                   , new List<Tuple<string, string>>() { new Tuple<string, string>("PumpCode", Code.ToString()) }
                  , WebClassLibrary.WindowTarget.NewWindow
                  , true, false, true, 650, 450);
                else
                    WebClassLibrary.JWebManager.ShowMessage("ابتدا پمپ را تعریف کنید.");
            }
            catch { }

        }
    }
}