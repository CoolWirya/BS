using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebOilManagement.Forms
{
    public partial class JOilZoneUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            LoadOilDistrict();
            _SetForm();
        }

        public void LoadOilDistrict()
        {
            DataTable DtOilZone = new DataTable();
            DtOilZone = OilProductsDistributionCompany.Zone.JOilDistrictes.GetDataTable();
            cmbOilDistrict.DataSource = DtOilZone;
            cmbOilDistrict.DataTextField = "Name";
            cmbOilDistrict.DataValueField = "Code";
            cmbOilDistrict.DataBind();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                OilProductsDistributionCompany.Zone.JOilZone OilZone = new OilProductsDistributionCompany.Zone.JOilZone();
                OilZone.GetData(Code);
                txtZoneName.Text = OilZone.Name;
                cmbOilDistrict.SelectedValue = OilZone.OilDistrictCode.ToString();
            }
        }

        public bool Save()
        {
            OilProductsDistributionCompany.Zone.JOilZone OilZone = new OilProductsDistributionCompany.Zone.JOilZone();
            OilZone.Code = Code;
            OilZone.Name = txtZoneName.Text;
            OilZone.OilDistrictCode = Convert.ToInt32(cmbOilDistrict.SelectedValue);
            if (Code > 0)
                return OilZone.update();
            else
                return OilZone.Insert() > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            OilProductsDistributionCompany.Zone.JOilZone jOilZone = new OilProductsDistributionCompany.Zone.JOilZone();
            jOilZone.Code = Code;
            if (jOilZone.Delete())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }
    }
}