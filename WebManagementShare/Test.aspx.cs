using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebManagementShare
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ShareWebService.AndroidWebService service = new ShareWebService.AndroidWebService();
           Response.Write(service.Login(txtUserName.Text+"%%" + txtPassword.Text));
        }

        protected void btnShowInfo_Click(object sender, EventArgs e)
        {
            ShareWebService.AndroidWebService service = new ShareWebService.AndroidWebService();
           Response.Write(service.GetPersonInfo ());
        }

        protected void btnGetAgents_Click(object sender, EventArgs e)
        {
            ShareWebService.AndroidWebService service = new ShareWebService.AndroidWebService();
            Response.Write(service.GetLawyers());
        }

        protected void btnInsertBuyRequest_Click(object sender, EventArgs e)
        {
            ShareWebService.AndroidWebService service = new ShareWebService.AndroidWebService();
            Response.Write(service.BuyRequest(Convert.ToInt32(txtShareCount.Text)));

        }

        protected void btnInsertSelRequest_Click(object sender, EventArgs e)
        {
            ShareWebService.AndroidWebService service = new ShareWebService.AndroidWebService();
            Response.Write(service.SellRequest(Convert.ToInt32(txtShareCountToSell.Text)));
        }

        protected void btnShowShareCount_Click(object sender, EventArgs e)
        {
            ShareWebService.AndroidWebService service = new ShareWebService.AndroidWebService();
            Response.Write(service.GetShareCount());
        }

        protected void btnShowByRequests_Click(object sender, EventArgs e)
        {
            ShareWebService.AndroidWebService service = new ShareWebService.AndroidWebService();
            Response.Write(service.GetBuyRequests());
        }

        protected void btnShowSellRequests_Click(object sender, EventArgs e)
        {
            ShareWebService.AndroidWebService service = new ShareWebService.AndroidWebService();
            Response.Write(service.GetSellRequests());
        }
    }
}