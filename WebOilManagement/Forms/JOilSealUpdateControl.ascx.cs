using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebOilManagement.Forms
{
    public partial class JSealUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            _SetForm();
        }

        public void _SetForm()
        {
            rdStatus.DataSource = WebClassLibrary.JWebDataBase.TranslateColumns(WebClassLibrary.JDataManager.EnumToDataTable(typeof(OilProductsDistributionCompany.Seal.JStatusSeal)), "Key");
            rdStatus.DataTextField = "Key";
            rdStatus.DataValueField = "Value";
            DataBind();

            if (Code > 0)
            {
                OilProductsDistributionCompany.Seal.JSeal Seal = new OilProductsDistributionCompany.Seal.JSeal();
                Seal.GetData(Code);
                txtSerialNumber.Text = Seal.Serial;
                rdStatus.SelectedValue = Seal.Status.GetHashCode().ToString();
            }
        }

        public bool Save()
        {
            OilProductsDistributionCompany.Seal.JSeal Seal = new OilProductsDistributionCompany.Seal.JSeal();
            Seal.Code = Code;
            Seal.Serial = txtSerialNumber.Text;
            Seal.Status = (OilProductsDistributionCompany.Seal.JStatusSeal)Convert.ToInt32(rdStatus.SelectedValue);
            if (Code > 0)
                return Seal.Update();
            else
                return Seal.Insert() > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
            else
                WebClassLibrary.JWebManager.ShowMessage("ذخیره سازی با خطا مواجه شد. پس از بررسی مجددا سعی نمایید.");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            OilProductsDistributionCompany.Seal.JSeal jSeal = new OilProductsDistributionCompany.Seal.JSeal();
            jSeal.Code = Code;
            if (jSeal.Delete())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }
    }
}