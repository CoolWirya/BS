using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClassLibrary;
using WebClassLibrary.Authentication;

namespace WebERP
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebClassLibrary.JWebManager.Configure();
            QsfSkinManager.Skin = WebClassLibrary.JWebSettings.GetKey("WebSiteSkin");
            imgLogo.ImageUrl = WebClassLibrary.JWebSettings.GetKey("WebSiteLogoImage");
			//if (Environment.MachineName.ToUpper() == "ALIMOHSENI-PC")
			//	if (Authentication.Authenticate("مدیر", "1"))
			//		Response.Redirect("~/Default.aspx");//ccc
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (!RadCaptcha1.IsValid) return;
            if (Authentication.Authenticate(txtUsername.Text, txtPassword.Text))
            {
                Response.Redirect("~/Default.aspx");
            }
            else
                lblError.Visible = true;
        }
        
        protected void lnkRegister_Click(object sender, EventArgs e)
        {
            string SUID = "Signup";
            JWebManager.SetControlType(JDomains.JControls.JUserControl, SUID, "~/WebControllers/MainControls/Signup/SignupControl.ascx", false);
            Response.Redirect(JWebManager.GenerateControlURL(SUID));
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string SUID = "Register";
            JWebManager.SetControlType(JDomains.JControls.JUserControl, SUID, "~/WebAVL/Forms/RegisterUser.ascx", false);
            Response.Redirect(JWebManager.GenerateControlURL(SUID));
        }
        protected void RadCaptcha1_CaptchaValidate(object sender, Telerik.Web.UI.CaptchaValidateEventArgs e)
        {
        }
    }
}