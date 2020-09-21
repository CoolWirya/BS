using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AndroidWebManagement.Forms
{
    public partial class JSharePriceUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                ((WebControllers.MainControls.Date.JDateControl)txtChangeDate).SetDate(DateTime.Now);
            int.TryParse(Request["Code"], out Code);
            _SetForm();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                ManagementShares.JSharePrice SharePrice = new ManagementShares.JSharePrice();
                SharePrice.GetData(Code);
                txtPrice.Text = SharePrice.Price.ToString();
                ((WebControllers.MainControls.Date.JDateControl)txtChangeDate).SetDate(SharePrice.ChangeDate);
            }
        }

        public bool Save()
        {
            ManagementShares.JSharePrice SharePrice = new ManagementShares.JSharePrice();
            SharePrice.Code = Code;
            SharePrice.Price = Convert.ToDecimal(txtPrice.Text);
            SharePrice.ChangeDate = ((WebControllers.MainControls.Date.JDateControl)txtChangeDate).GetDate();
            SharePrice.CompanyCode = 0;
            if(Code>0)
              return  SharePrice.Update(0);
            else
              return  SharePrice.insert() > 0 ? true : false;;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }
    }
}