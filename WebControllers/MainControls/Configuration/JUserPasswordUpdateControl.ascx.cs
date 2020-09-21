using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControllers.MainControls.Configuration
{
    public partial class jUserPasswordUpdateControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (WebClassLibrary.Authentication.Authentication.VerifyUser(WebClassLibrary.SessionManager.Current.MainFrame.CurrentUser.username, txtCurrentPassword.Text))
            {
                if (WebClassLibrary.Authentication.Authentication.ChangeUserPassword(txtNewPassword.Text))
                {
                    WebClassLibrary.SessionManager.Current.Dispose();
                    WebClassLibrary.JWebManager.RedirectClient(ClassLibrary.JConfig.LoginPage);
                }
                else
                    WebClassLibrary.JWebManager.ShowMessage("خطا در هنگام تغییر کلمه عبور. مجددا سعی نمایید.");
            }
            else
                WebClassLibrary.JWebManager.ShowMessage("کلمه عبور فعلی معتبر نمی باشد.");

        }
    }
}