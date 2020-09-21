using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NotificationProjects
{
    public partial class Form1 : ClassLibrary.JBaseForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.ShowInTaskbar = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClassLibrary.JSystem.SMSSend = false;
            WindowState = FormWindowState.Minimized;
            deActiveToolStripMenuItem.Tag = 0;

            /// تغییر زبان
            if (ClassLibrary.JGlobal.MainFrame.GetConfig().CurrentLang == ClassLibrary.JLanguageNames.Farsi)
            {
                System.Globalization.CultureInfo x = new System.Globalization.CultureInfo("fa-IR");
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(x);
            }

            Login();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Login()
        {
            Employment.JLoginForm user = new Employment.JLoginForm(true, "not.lxt");
            user.ShowDialog();

            if (ClassLibrary.JMainFrame.CurrentUser != null)
                ClassLibrary.JNotifyCation.Start();
        }


        private void deActiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (deActiveToolStripMenuItem.Tag.ToString() == "0")
            {
                ClassLibrary.JNotifyCation.Stop();
                deActiveToolStripMenuItem.Tag = 1;
                deActiveToolStripMenuItem.Text = "Active";
            }
            else
            {
                ClassLibrary.JNotifyCation.Start();
                deActiveToolStripMenuItem.Tag = 0;
                deActiveToolStripMenuItem.Text = "DeActive";
            }
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employment.JLoginForm user = new Employment.JLoginForm(false, "not.lxt");
            user.Show();
        }
    }
}
