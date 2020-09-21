using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Globals
{
    public partial class JChangePass : JBaseForm
    {
        private JUser _user;
        public JChangePass()
        {
            InitializeComponent();
            _user = new JUser(JMainFrame.CurrentUserCode);
            txtUserName.Text = _user.username;
            txtPersonCode.Text = _user.PCode.ToString();
            txtUserName.Enabled = false;
        }

        private void SaveBtn_update_Click(object sender, EventArgs e)
        {
            if (_user.Login(txtUserName.Text, txtOldPassword.Text, JMainFrame.CurrentPostCode) > 0)
            {
                if (txtPassword.Text != txtRePasswor.Text)
                {
                    JMessages.Error("کلمه عبور اول و دوم یکی نیست.", "Error");
                    return;
                }
                if (txtPassword.Text.Length < 4)
                {
                    JMessages.Error("کلمه عبور باید بیشتر از 3 حرف باشد.", "Error");
                    return;
                }
                _user.PCode = Convert.ToInt32(txtPersonCode.Text);
                if (txtPassword.Text.Length > 0)
                {
                    _user.password = txtPassword.Text;
                    _user.LastPassChangeDate = DateTime.Now;
                    if (_user.Update())
                    {
                        JMessages.Information("کلمه عبور تغییر یافت", "");
                        Close();
                    }
                }
            }
            else
                JMessages.Error("PasswordIsIncorrect", "Error");
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
