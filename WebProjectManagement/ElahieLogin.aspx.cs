using System;
using WebClassLibrary;
using WebClassLibrary.Authentication;

namespace WebProjectManagement
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Authentication.Authenticate(txtUsername.Text, txtPassword.Text))
            {
                Response.Redirect("~/Default.aspx");
               // Response.Redirect("../Default.aspx");
            }
        }
    }
}