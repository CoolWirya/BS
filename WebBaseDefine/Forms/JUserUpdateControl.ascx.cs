using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBaseDefine.Forms
{
    public partial class JUserUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);

            _SetForm();

        }

        private void _SetForm()
        {
            if (Code > 0)
            {
                Globals.JUser user = new Globals.JUser(Code);
                txtUsername.Text = user.username;
                if (user.Active)
                    cmbUserStatus.SelectedValue = "1";
                else
                    cmbUserStatus.SelectedValue = "0";
                ((WebControllers.MainControls.JSearchPersonControl)jSearchPersonControl).PersonCode = user.PCode;
            }
        }
        private bool Save()
        {
            Globals.JUser user;
            if (Code > 0) user = new Globals.JUser(Code);
            else user = new Globals.JUser();

            user.username = txtUsername.Text;
            user.Active = cmbUserStatus.SelectedValue == "1" ? true : false;
            user.PCode = ((WebControllers.MainControls.JSearchPersonControl)jSearchPersonControl).PersonCode;
            if (Code == 0 && txtPassword1.Text.Length == 0) return false; // Password is required for new user
            if (txtPassword1.Text.Length > 0)
            {
                user.password = txtPassword1.Text;
                user.LastPassChangeDate = DateTime.Now;
            }

            if (Code > 0)
                return user.Update();
            else
            {
                Code = user.insert();
                return Code > 0 ? true : false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
			if (txtPassword1.Text.Length > 0 && txtPassword1.Text != txtPassword2.Text)
				WebClassLibrary.JWebManager.ShowMessage("کلمه عبورهای وارد شده یکسان نمی باشد.");
            //else
            //    if (Save())
            //        //WebClassLibrary.JWebManager.CloseAndRefresh();
            //        WebClassLibrary.JWebManager.CloseAndRefresh();
            //    else
            //        WebClassLibrary.JWebManager.ShowMessage("خطا در ذخیره اطلاعات. پس از بررسی اطلاعات مجددا سعی نمایید.");
        }

		protected void btnClose_Click(object sender, EventArgs e)
		{
			WebClassLibrary.JWebManager.CloseWindow();
		}
    }
}