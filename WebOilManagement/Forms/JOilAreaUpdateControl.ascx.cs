using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebOilManagement.Forms
{
    public partial class JOilAreaUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            LoadOilZone();
            _SetForm();
        }

        public void LoadOilZone()
        {
            DataTable DtOilZone = new DataTable();
            DtOilZone = OilProductsDistributionCompany.Zone.JOliZonees.GetDataTable();
            cmbOilZone.DataSource = DtOilZone;
            cmbOilZone.DataTextField = "Name";
            cmbOilZone.DataValueField = "Code";
            cmbOilZone.DataBind();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                OilProductsDistributionCompany.Zone.OilArea OilArea = new OilProductsDistributionCompany.Zone.OilArea();
                OilArea.GetData(Code);
                txtAreaName.Text = OilArea.Name;
                cmbOilZone.SelectedValue = OilArea.OilZoneCode.ToString();
            }
        }

        public bool Save()
        {
            OilProductsDistributionCompany.Zone.OilArea OilArea = new OilProductsDistributionCompany.Zone.OilArea();
            OilArea.Code = Code;
            OilArea.Name = txtAreaName.Text;
            OilArea.OilZoneCode = Convert.ToInt32(cmbOilZone.SelectedValue);
            if (Code > 0)
                return OilArea.update();
            else
                return OilArea.Insert() > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }
    }
}