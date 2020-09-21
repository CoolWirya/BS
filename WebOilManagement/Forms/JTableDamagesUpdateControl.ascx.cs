using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebOilManagement.Forms
{
    public partial class JTableDamagesUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            if (!IsPostBack)
            {
                LoadFailureType();
                LoadUrgencies();
                _SetForm();
            }
        }

        public void LoadFailureType()
        {
            DataTable Dt = new DataTable();
            Dt = WebClassLibrary.JDataManager.EnumToDataTable(typeof(OilProductsDistributionCompany.Failure.JFailureType));
            cmbFailureType.DataSource = Dt;
            cmbFailureType.DataTextField = "Key";
            cmbFailureType.DataValueField = "Value";
            cmbFailureType.DataBind();
        }

        public void LoadUrgencies()
        {
            DataTable Dt = new DataTable();
            Dt = WebClassLibrary.JDataManager.EnumToDataTable(typeof(OilProductsDistributionCompany.Failure.JUrgencies));
            cmbUrgencies.DataSource = Dt;
            cmbUrgencies.DataTextField = "Key";
            cmbUrgencies.DataValueField = "Value";
            cmbUrgencies.DataBind();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                OilProductsDistributionCompany.Failure.JTableDamages TableDamage = new OilProductsDistributionCompany.Failure.JTableDamages();
                TableDamage.GetData(Code);
                txtDamageName.Text = TableDamage.Name;
                cmbFailureType.SelectedValue = TableDamage.FailureTypeCode.GetHashCode().ToString();
                txtTimeRequiredToRepair.Text = TableDamage.TimeRequiredToRepair.ToString();
                txtExpertiseRequired.Text = TableDamage.ExpertiseRequired.ToString();
                cmbUrgencies.SelectedValue = TableDamage.Urgency.GetHashCode().ToString();
                txtFailureNumber.Text = TableDamage.FailureNumber.ToString();
            }
        }

        public bool Save()
        {
            OilProductsDistributionCompany.Failure.JTableDamages TableDamage = new OilProductsDistributionCompany.Failure.JTableDamages();
            TableDamage.Code = Code;
            TableDamage.Name = txtDamageName.Text;
            TableDamage.FailureTypeCode = (OilProductsDistributionCompany.Failure.JFailureType)Convert.ToInt32(cmbFailureType.SelectedValue);
            TableDamage.TimeRequiredToRepair = Convert.ToInt32(txtTimeRequiredToRepair.Text);
            TableDamage.ExpertiseRequired = txtExpertiseRequired.Text;
            TableDamage.Urgency = (OilProductsDistributionCompany.Failure.JUrgencies)Convert.ToInt32(cmbUrgencies.SelectedValue);
            TableDamage.FailureNumber = int.Parse(txtFailureNumber.Text);
            if (Code > 0)
                return TableDamage.update();
            else
                return TableDamage.Insert() > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
            else
                WebClassLibrary.JWebManager.ShowMessage("عملیات با خطا مواجه شد. پس از بررسی اطلاعات وارد شده مجددا سعی نمایید.");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            OilProductsDistributionCompany.Failure.JTableDamages jTableDamages = new OilProductsDistributionCompany.Failure.JTableDamages();
            jTableDamages.Code = Code;
            if (jTableDamages.Delete())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }
    }
}