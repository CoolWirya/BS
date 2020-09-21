using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Globals;

namespace Employment
{
    public partial class JLoginForm : ClassLibrary.JBaseForm
    {
        private JLogin _Login = new JLogin();
        private Boolean _AutoLogin;
        private string _FilePass;

        public JLoginForm()
            : this(false, "")
        {
        }

        public JLoginForm(Boolean pAutoLogin, string pFilePass)
        {
            InitializeComponent();
            _AutoLogin = pAutoLogin;
            if (pFilePass.Length <= 0)
                pFilePass = "sec.lxt";
            _FilePass = pFilePass;
        }

        private void SavePass()
        {
            if (cbSave.Checked || _AutoLogin)
            {
                try
                {
                    JFile File = new JFile();
                    File.FileName = JConfig.appPath + "\\" + _FilePass;
                    File.FileText =
                        JEnryption.EncryptStr(txtUserName.Text) +
                        Environment.NewLine +
                        JEnryption.EncryptStr(txtPassword.Text) +
                        Environment.NewLine +
                        JEnryption.EncryptStr(Convert.ToInt32(((DataRowView)(comboBoxPost.SelectedItem))["code"]).ToString());
                    File.Write();
                }
                catch
                {
                }
            }
            else
            {
                System.IO.File.Delete(JConfig.appPath + "\\" + _FilePass);
            }
        }

        private void LoadPass()
        {
            if (System.IO.File.Exists(JConfig.appPath + "\\" + _FilePass))
            {
                try
                {
                    JFile File = new JFile();
                    File.FileName = JConfig.appPath + "\\" + _FilePass;
                    File.Read();

                    string[] Data = File.FileText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

                    Data[0] = JEnryption.DecryptStr(Data[0]);
                    Data[1] = JEnryption.DecryptStr(Data[1]);
                    Data[2] = JEnryption.DecryptStr(Data[2]);

                    if (txtUserName.Text == Data[0])
                    {
                        txtUserName.Text = Data[0];
                        txtPassword.Text = Data[1];
                        PostRefresh();
                        cbSave.Checked = true;
                        comboBoxPost.SelectedValue = int.Parse(Data[2]);
                        if (_AutoLogin)
                            loginBtn_Click(loginBtn, null);
                    }
                }
                catch
                {
                }
            }
        }


        private void loginBtn_Click(object sender, EventArgs e)
        {


            if (comboBoxPost.SelectedItem != null && _Login.Login(txtUserName.Text, txtPassword.Text, Convert.ToInt32(((DataRowView)(comboBoxPost.SelectedItem))["code"])))
            {
                SavePass();
                ClassLibrary.JApplicationsManager tmp = new JApplicationsManager();
                string DllError = tmp.CheckVersion();
                if (DllError.Length > 0)
                {
                    JMessages.Error(" ورژن برنامه " + DllError + "با برنامه اصلی یکی نیست لطفا ابتدا ورژن جدید را نصب  کنید ", "");
                    //return;
                }
                JEOrganizationChart Chart = new JEOrganizationChart(JMainFrame.CurrentPostCode);
                JMainFrame.CurrentPostTitle = Chart.full_Name;
                JMainFrame.BaseCurrentPostTitle = Chart.full_Name;

                JConfig tmpJConfig = new JConfig();
                JMainFrame.TimeLogin = tmpJConfig.TimeLogin;
                if (JMainFrame.TimeLogin == 0)
                    JMainFrame.TimeLogin = 1800;
                Globals.JRegistry.Write("Employment.DefaultUser", txtUserName.Text);
                Close();
            }
            else
            {
                JMessages.Error("InvalidUserNameOrPass", "Error");
                txtPassword.Focus();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            JMainFrame.Terminated = 1;
            Application.Exit();
        }

        private void JLoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (JMainFrame.CurrentUserCode == 0 && JMainFrame.Terminated == 0)
                e.Cancel = true;
        }

        private void PostRefresh()
        {
            btnChangePassword.Visible = false;
            comboBoxPost.DataSource = null;
            comboBoxPost.Items.Clear();
            int code = _Login.Check(txtUserName.Text, txtPassword.Text);
            if (code > 0)
            {
                Employment.JEOrganizationChart chart = new Employment.JEOrganizationChart();
                comboBoxPost.DisplayMember = "Job";
                comboBoxPost.ValueMember = "Code";
                comboBoxPost.DataSource = chart.GetUserPostsByUser_code(code);
                btnChangePassword.Visible = true;
            }
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            PostRefresh();
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            PostRefresh();
        }

        private void JLoginForm_Shown(object sender, EventArgs e)
        {
            object DefaultUser = Globals.JRegistry.Read("Employment.DefaultUser");
            if (DefaultUser != null)
            {
                txtUserName.Text = DefaultUser.ToString();
                txtPassword.Focus();
            }
            LoadPass();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (comboBoxPost.SelectedItem != null && _Login.Login(txtUserName.Text, txtPassword.Text, Convert.ToInt32(((DataRowView)(comboBoxPost.SelectedItem))["code"])))
            {
                Globals.JChangePass C = new Globals.JChangePass();
                C.ShowDialog();
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length > 0)
            {
                JUser u = new JUser();
                u.GetData(txtUserName.Text);
                if (u.code > 0 && u.PCode > 0)
                {
                    JMainFrame.CurrentUser = u;
                    JPerson p = new JPerson(u.PCode);
                    JMainFrame.CurrentPerson = p;
                    if (p.Code > 0 && p.PersonImage != null)
                    {
                        pictureBox1.Image = p.PersonImage;
                    }
                }
            }
        }

        private void JLoginForm_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        int AltControlShift = 0;
        private void JLoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.Control && e.Shift)
                AltControlShift++;
            if (AltControlShift > 5)
            {
                JConfigForm f = new JConfigForm();
                f.ShowDialog();
                AltControlShift = 0;
            }
        }
    }
}
