using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebOilManagement.Forms
{
    public partial class JOilDistrictUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            _SetForm();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                OilProductsDistributionCompany.Zone.JOilDistrict OilDistrictes = new OilProductsDistributionCompany.Zone.JOilDistrict();
                OilDistrictes.GetData(Code);
                txtDistrictName.Text = OilDistrictes.Name;
            }
        }

        public bool Save()
        {
            OilProductsDistributionCompany.Zone.JOilDistrict OilDistrictes = new OilProductsDistributionCompany.Zone.JOilDistrict();
            OilDistrictes.Code = Code;
            OilDistrictes.Name = txtDistrictName.Text;
            if (Code > 0)
                return OilDistrictes.update();
            else
                return OilDistrictes.Insert() > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            OilProductsDistributionCompany.Zone.JOilDistrict jOilDistrict = new OilProductsDistributionCompany.Zone.JOilDistrict();
            jOilDistrict.Code = Code;
            if (jOilDistrict.Delete())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }
    }
}