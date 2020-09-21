using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClassLibrary;

namespace WebERP
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionManager.Current.MainFrame.isAuthenticated == false)
                Response.Redirect("~/"+ClassLibrary.JConfig.LoginPage);
        }
    }
}