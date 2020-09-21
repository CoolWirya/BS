using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebOilManagement.Forms
{
    public partial class JFuelTankUpdateControl : System.Web.UI.UserControl
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

            cmbTypeOfFuelTank.DataSource = OilProductsDistributionCompany.Define.JTypeOfFuelTanks.GetDataTable(OilProductsDistributionCompany.JDefine.TypeOfFuelTank);
            cmbTypeOfFuelTank.DataTextField = "Name";
            cmbTypeOfFuelTank.DataValueField = "Code";
            cmbTypeOfFuelTank.DataBind();

            cmbTypeOfProduct.DataSource = OilProductsDistributionCompany.Define.JTypeOfProducts.GetDataTable(OilProductsDistributionCompany.JDefine.TypeOfProduct);
            cmbTypeOfProduct.DataTextField = "Name";
            cmbTypeOfProduct.DataValueField = "Code";
            cmbTypeOfProduct.DataBind();

            cmbManufacturer.DataSource = WarehouseManagement.JManufacturers.GetDataTable(WarehouseManagement.Define.JDefine.Manufacturers);
            cmbManufacturer.DataTextField = "name";
            cmbManufacturer.DataValueField = "Code";
            cmbManufacturer.DataBind();

            if (Code > 0)
            {
                OilProductsDistributionCompany.FuelTank.JFuelTank jFuelTank = new OilProductsDistributionCompany.FuelTank.JFuelTank();
                jFuelTank.GetData(Code);
                cmbGasStation.SelectedValue = jFuelTank.GasStationCode.ToString();
                cmbTypeOfFuelTank.SelectedValue = jFuelTank.TypeOfFuelTankCode.ToString();
                cmbTypeOfProduct.SelectedValue = jFuelTank.TypeOfProductCode.ToString();
                txtNumber.Text = jFuelTank.Number.ToString();
                cmbManufacturer.SelectedValue = jFuelTank.Manufacturer.ToString();
                txtYearBuilt.Text = jFuelTank.YearBuilt.ToString();
                txtNumberOfPumps.Text = jFuelTank.NumberOfPumps.ToString();
            }
        }

        public bool Save()
        {
            OilProductsDistributionCompany.FuelTank.JFuelTank jFuelTank = new OilProductsDistributionCompany.FuelTank.JFuelTank();
            jFuelTank.Code = Code;
            jFuelTank.GasStationCode = Convert.ToInt32(cmbGasStation.SelectedValue);
            jFuelTank.Manufacturer = Convert.ToInt32(cmbManufacturer.SelectedValue);
            jFuelTank.Number = Convert.ToInt32(txtNumber.Text);
            jFuelTank.NumberOfPumps = Convert.ToInt32(txtNumberOfPumps.Text);
            jFuelTank.TypeOfFuelTankCode = Convert.ToInt32(cmbTypeOfFuelTank.SelectedValue);
            jFuelTank.TypeOfProductCode = Convert.ToInt32(cmbTypeOfProduct.SelectedValue);
            jFuelTank.YearBuilt = int.Parse(txtYearBuilt.Text);
            if (Code > 0)
                return jFuelTank.Update();
            else
                return jFuelTank.Insert() > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            OilProductsDistributionCompany.FuelTank.JFuelTank jFuekTank = new OilProductsDistributionCompany.FuelTank.JFuelTank();
            jFuekTank.Code = Code;
            if (jFuekTank.Delete())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }
    }
}