using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using Globals;

namespace Employment
{
    public class JLogin: JSystem
    {
        public Boolean HasLogin = false;

        public JLogin()
        {
        }

        public Boolean Login(string pUserName, string pPassword, int pPostCode)
        {
            JUser User = new JUser();
            if (User.Login(pUserName, pPassword, pPostCode) > 0)
            {
                if (!User.CheckPassDate())
                {
                    JMessages.Information("لطفا جهت افزایش هر چه بیشتر امنیت، کلمه عبور خود را تغییر دهید", "");
                    JChangePass changePass = new JChangePass();
                    changePass.ShowDialog();
                }
                return true;
            }

            return false;
        }

        public int Check(string pUserName, string pPassword)
        {
            JUser User = new JUser();
            return User.CheckUserPass(pUserName, pPassword);
        }

        private Boolean _ActiveUser(Globals.JUser pUser)
        {
            try
            {
                pUser.Active = true;
                pUser.Guide = GuidCode.ToString();
                pUser.Update();
                JMainFrame.CurrentUserCode = pUser.code;
                return true;
            }
            catch(Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
        }


        public void Show()
        {
            JLoginForm LForm = new JLoginForm();
            LForm.ShowDialog();
        }
    }
}
