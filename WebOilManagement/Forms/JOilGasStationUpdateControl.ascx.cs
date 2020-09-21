using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebOilManagement.Forms
{
    public partial class JOilGasStationUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            hfCode.Value = Request["Code"];
            _SetForm();
        }

        public void _SetForm()
        {
            cmbZone.DataSource = OilProductsDistributionCompany.Zone.JOliZonees.GetDataTable();
            cmbZone.DataTextField = "Name";
            cmbZone.DataValueField = "Code";
            cmbZone.DataBind();


            cmbPlaceOfSupply.DataSource = OilProductsDistributionCompany.Define.JPlaceOfSupplies.GetDataTable(OilProductsDistributionCompany.JDefine.PlaceOfSupply);
            cmbPlaceOfSupply.DataTextField = "Name";
            cmbPlaceOfSupply.DataValueField = "Code";
            cmbPlaceOfSupply.DataBind();

            cmbTypeOfSupply.DataSource = OilProductsDistributionCompany.Define.JTypeOfSupplies.GetDataTable(OilProductsDistributionCompany.JDefine.TypeOfSupply);
            cmbTypeOfSupply.DataTextField = "Name";
            cmbTypeOfSupply.DataValueField = "Code";
            cmbTypeOfSupply.DataBind();

            if (Code > 0)
            {
                OilProductsDistributionCompany.GasStation.JGasStation jGasStation = new OilProductsDistributionCompany.GasStation.JGasStation();
                jGasStation.GetData(Code);
                txtName.Text = jGasStation.Name;
                txtStationNumber.Text = jGasStation.Number.ToString();
                txtAlt.Text = jGasStation.Alt.ToString();
                txtLat.Text = jGasStation.Lat.ToString();
                txtLon.Text = jGasStation.Lon.ToString();
                txtArea.Text = jGasStation.Area.ToString();
                //txtAddress.Text =

                #region Zone/Area Combo Filling
                OilProductsDistributionCompany.Zone.OilArea Oa=new OilProductsDistributionCompany.Zone.OilArea();
                Oa.GetData(jGasStation.OilAreaCode);
                cmbZone.SelectedValue = Oa.OilZoneCode.ToString();
                System.Data.DataTable dt = OilProductsDistributionCompany.Zone.JOilAreaes.GetDataTable();
                dt.DefaultView.RowFilter = " OilZoneCode =" + cmbZone.SelectedValue;
                cmbArea.DataSource = dt.DefaultView;
                cmbArea.DataTextField = "Name";
                cmbArea.DataValueField = "Code";
                cmbArea.DataBind();
                #endregion Zone/Area Combo Filling

                cmbArea.SelectedValue = jGasStation.OilAreaCode.ToString();
                cmbPlaceOfSupply.SelectedValue = jGasStation.PlaceOfSupply.ToString();
                cmbTypeOfSupply.SelectedValue = jGasStation.TypeOfSupply.ToString();
                ((WebControllers.MainControls.JSearchPersonControl)personOwner).PersonCode = jGasStation.OwnerCode;
                ((WebControllers.MainControls.JSearchPersonControl)personOperator).PersonCode = jGasStation.OperatorCode;
            }
        }

        public bool Save()
        {
            string ErrorResult = string.Empty;

            if (string.IsNullOrEmpty(txtName.Text))
                ErrorResult += " نام جایگاه   \n";
            if (string.IsNullOrEmpty(cmbPlaceOfSupply.SelectedValue))
                ErrorResult += " مکان محل عرضه   \n";
            if (string.IsNullOrEmpty(txtStationNumber.Text))
                ErrorResult += "  شماره جایگاه    \n";
            if (string.IsNullOrEmpty(cmbTypeOfSupply.SelectedValue))
                ErrorResult += " نوع محل عرضه   \n";
            if (string.IsNullOrEmpty(cmbArea.SelectedValue))
                ErrorResult += " ناحیه   \n";
            if (string.IsNullOrEmpty(txtArea.Text))
                ErrorResult += " مساحت   \n";
            //if (string.IsNullOrEmpty(personOwner.Text))
            //    ErrorResult += " مالک   \n";
            //if (string.IsNullOrEmpty(txtName.Text))
            //    ErrorResult += " اپراتور   \n";
            //if (string.IsNullOrEmpty(txtAddress.Text))
            //    ErrorResult += " آدرس   \n";
            if (string.IsNullOrEmpty(txtLat.Text))
                ErrorResult += " طول جغرافیایی   \n";
            if (string.IsNullOrEmpty(txtLon.Text))
                ErrorResult += " عرض جغرافیایی   \n";
            if (string.IsNullOrEmpty(txtAlt.Text))
                ErrorResult += "ارتفاع جغرافیایی \n ";

            if (ErrorResult != string.Empty)
            {
                WebClassLibrary.JWebManager.ShowMessage("\nلطفا ابتدا موارد زیر را تکمیل کنید" + ErrorResult, WebClassLibrary.MessageType.Error);
                return false;
            }

            OilProductsDistributionCompany.GasStation.JGasStation jGasStation = new OilProductsDistributionCompany.GasStation.JGasStation();
            jGasStation.Code = Code;
            jGasStation.Name = txtName.Text;
            jGasStation.Number = Convert.ToInt32(txtStationNumber.Text);
            jGasStation.Area = Convert.ToInt32(txtArea.Text);
            jGasStation.Alt = Convert.ToInt32(txtAlt.Text);
            jGasStation.Lat = Convert.ToInt32(txtLat.Text);
            jGasStation.Lon = Convert.ToInt32(txtLon.Text);
            //jGasStation.AddressCode = txtAddress.Text;
            //jGasStation.AddressCode =
            jGasStation.OilAreaCode = Convert.ToInt32(cmbArea.SelectedValue);
            jGasStation.PlaceOfSupply = Convert.ToInt32(cmbPlaceOfSupply.SelectedValue);
            jGasStation.TypeOfSupply = Convert.ToInt32(cmbTypeOfSupply.SelectedValue);
            jGasStation.OwnerCode = ((WebControllers.MainControls.JSearchPersonControl)personOwner).PersonCode;
            jGasStation.OperatorCode = ((WebControllers.MainControls.JSearchPersonControl)personOperator).PersonCode;

            if (Code > 0)
            {
                hfCode.Value = Code.ToString();
                return jGasStation.update();
            }
            else
            {

                Code = jGasStation.Insert();
                hfCode.Value = Code.ToString();
                return Code > 0 ? true : false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            // WebClassLibrary.JWebManager.CloseAndRefresh();
            //else
            //    WebClassLibrary.JWebManager.ShowMessage("امکان ذخیره اطلاعات وجود ندارد. پس بررسی اطلاعات وارد شده مجددا سعی نمایید.");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            OilProductsDistributionCompany.GasStation.JGasStation jGasStation = new OilProductsDistributionCompany.GasStation.JGasStation();
            jGasStation.Code = Code;
            if (jGasStation.Delete())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }

        protected void rtabJOilGasStation_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
        {
            if (hfCode.Value == string.Empty || int.Parse(hfCode.Value) <= 0 || e.Tab.Value == "rpvOilGasStation")
            {

                rtabJOilGasStation.Tabs.FindTabByValue("rpvOilGasStation").Selected = true;
                rpageJOilGasStation.FindPageViewByID("rpvOilGasStation").Selected = true;

            }
            else
            {
                rtabJOilGasStation.Tabs.FindTabByValue("rpvJClsPerssonAddress").Selected = true;
                rpageJOilGasStation.FindPageViewByID("rpvJClsPerssonAddress").Selected = true;
                ((WebControllers.MainControls.Persons.JclsPersonAddress)JclsPersonAddress).ObjectCode = hfCode.Value;
                ((WebControllers.MainControls.Persons.JclsPersonAddress)JclsPersonAddress).ClassName = JWebOilManagement._ConstClassName;
                ((WebControllers.MainControls.Persons.JclsPersonAddress)JclsPersonAddress).AddressType = ClassLibrary.JAddressTypes.GasStation;
                ((WebControllers.MainControls.Persons.JclsPersonAddress)JclsPersonAddress).Binding();
            }
        }

        /// <summary>
        /// انتخاب منطقه جهت فیلتر
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cmbZone_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                System.Data.DataTable dt = OilProductsDistributionCompany.Zone.JOilAreaes.GetDataTable();
                dt.DefaultView.RowFilter = " OilZoneCode =" + cmbZone.SelectedValue;
                cmbArea.DataSource = dt.DefaultView;
                cmbArea.DataTextField = "Name";
                cmbArea.DataValueField = "Code";
                cmbArea.DataBind();
            }
            catch
            {
                WebClassLibrary.JWebManager.ShowMessage("عملیات مورد نظر با مشکل مواجه شد. لطفا پس از بررسی، مجددا سعی نمایید.");
            }
        }
    }
}