using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebOilManagement.Forms
{
    public partial class JOilSupplierUpdateControl : System.Web.UI.UserControl
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
                OilProductsDistributionCompany.JSupplier Suppplier = new OilProductsDistributionCompany.JSupplier();
                Suppplier.GetData(Code);
                ((WebControllers.MainControls.JSearchPersonControl)personSupplier).PersonCode = Suppplier.PCode;
                ((WebControllers.MainControls.Date.JDateControl)dteStartDate).SetDate(Suppplier.StartContract);
                ((WebControllers.MainControls.Date.JDateControl)dteEndDate).SetDate(Suppplier.EndContract);
            }
        }

        public bool Save()
        {
            OilProductsDistributionCompany.JSupplier Suppplier = new OilProductsDistributionCompany.JSupplier();
            Suppplier.Code = Code;
            Suppplier.PCode = ((WebControllers.MainControls.JSearchPersonControl)personSupplier).PersonCode;
            Suppplier.StartContract = ((WebControllers.MainControls.Date.JDateControl)dteStartDate).GetDate();
            Suppplier.EndContract = ((WebControllers.MainControls.Date.JDateControl)dteEndDate).GetDate();
            if (Code > 0)
                return Suppplier.update();
            else
                return Suppplier.Insert() > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                btnSave.Enabled = false;
                WebClassLibrary.JWebManager.CloseAndRefresh();
            }
            else
                WebClassLibrary.JWebManager.ShowMessage("عملیات با خطا مواجه شد. پس از بررسی اطلاعات وارد شده مجددا سعی نمایید.");

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            OilProductsDistributionCompany.JSupplier jSupplier = new OilProductsDistributionCompany.JSupplier();
            jSupplier.Code = Code;
            if (jSupplier.Delete())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }

    }
}