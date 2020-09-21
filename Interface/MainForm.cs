using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Automation;
using System.Xml;
using ClassLibrary;
using OfficeWord;
using System.IO;
using Employment;
using Entertainment;


namespace ERP
{
    public partial class MainForm : ClassLibrary.JBaseForm
    {
        JTreeView TV;
        JListView LV;
        string TodayInfo;
        Janus.Windows.ButtonBar.ButtonBar RightButtonBar;
        ClassLibrary.Controllers.JAutoTypeLabel AutoTypeLabelShow;

        public MainForm(string pGUID)
        {
            try
            {
                if (DesignMode)
                    return;
				WindowState = FormWindowState.Maximized;
                JMainFrame.Key = pGUID;

                /// تغییر زبان
                if (JGlobal.MainFrame.GetConfig().CurrentLang == JLanguageNames.Farsi)
                {
                    System.Globalization.CultureInfo x = new System.Globalization.CultureInfo("fa-IR");
                    InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(x);
                }

                /// نمایش فرم ورود
                if (JMainFrame.Terminated == 0 && JMainFrame.CurrentUserCode == 0)
                {
                    Employment.JLogin Login = new Employment.JLogin();
                    Login.Show();
                    if (JMainFrame.CurrentUserCode != 0)
                        InitializeComponent();
                }
                else
                {
                    InitializeComponent();
                }

                try
                {
                    RightButtonBar = new Janus.Windows.ButtonBar.ButtonBar();
                    RightButtonBar.Parent = panel2;
                    panel2.Controls.Add(RightButtonBar);
                    RightButtonBar.Dock = DockStyle.Fill;
                    RightButtonBar.BringToFront();
                }
                catch
                {
                }

                try
                {
                    AutoTypeLabelShow = new ClassLibrary.Controllers.JAutoTypeLabel();
                    AutoTypeLabelShow.Parent = this;
                    this.Controls.Add(AutoTypeLabelShow);
                    AutoTypeLabelShow.Dock = DockStyle.Bottom;
                    AutoTypeLabelShow.Height = 20;
                    AutoTypeLabelShow.SendToBack();
                    AutoTypeLabelShow.BackColor = Color.LightBlue;
                }
                catch
                {
                }
            }
            catch
            {
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowMessages();

            LV = new JListView(null, ListViewtoolStrip, null, null, RightButtonBar, tabControl1 , statusStripBottom,panelAddressBar,null);

            Globals.JUser user = new Globals.JUser(JMainFrame.CurrentUserCode);
            string UserName = user.username;
            this.Text = "نرم افزار جامع "+"کاربر: " + JMainFrame.CurrentPostTitle;

            SuccessorRefresh();

            DiscardEsc = true;
        }

        private void SuccessorRefresh()
        {
            System.Data.DataTable _DT = JSuccessor.GetDataTable(0);
            if (_DT!= null && _DT.Rows.Count > 0)
            {
                cmbSuccessor.Visible = true;
                _DT.DefaultView.Sort = "Person_Full_Title";

                System.Data.DataRow _DR = _DT.NewRow();
                _DR["Person_Full_Title"] = "-------------";
                _DR["Person_post_code"] = 0;
                _DT.Rows.Add(_DR);

                _DR = _DT.NewRow();
                _DR["Person_Full_Title"] = JMainFrame.BaseCurrentPostTitle;
                _DR["Person_post_code"] = JMainFrame.BaseCurrentPostCode;
                _DT.Rows.Add(_DR);

                cmbSuccessor.DataSource = _DT;
                cmbSuccessor.DisplayMember = "Person_Full_Title";
                cmbSuccessor.ValueMember = "Person_post_code";
            }
            else
            {
                cmbSuccessor.Visible = false;
            }

        }
        private void ShowMessages()
        {
            #region MessageLabel
            AutoTypeLabelShow.label1.BackColor = AutoTypeLabelShow.BackColor;
            AutoTypeLabelShow.WaitTick = 60;
            List<String> messages = new List<string>();
            // Date info
            string date = "امروز، ";
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            switch (pc.GetDayOfWeek(DateTime.Now))
            {
                case DayOfWeek.Saturday:
                    date += "شنبه";
                    break;
                case DayOfWeek.Sunday:
                    date += "یکشنبه";
                    break;
                case DayOfWeek.Monday:
                    date += "دوشنبه";
                    break;
                case DayOfWeek.Tuesday:
                    date += "سه شنبه";
                    break;
                case DayOfWeek.Wednesday:
                    date += "چهارشنبه";
                    break;
                case DayOfWeek.Thursday:
                    date += "پنجشنبه";
                    break;
                case DayOfWeek.Friday:
                    date += "جمعه";
                    break;
            }
            date += " " + pc.GetDayOfMonth(DateTime.Now).ToString() + " ";

            switch (pc.GetMonth(DateTime.Now))
            {
                case 1:
                    date += "فروردین";
                    break;
                case 2:
                    date += "اردیبهشت";
                    break;
                case 3:
                    date += "خرداد";
                    break;
                case 4:
                    date += "تیر";
                    break;
                case 5:
                    date += "مرداد";
                    break;
                case 6:
                    date += "شهریور";
                    break;
                case 7:
                    date += "مهر";
                    break;
                case 8:
                    date += "آبان";
                    break;
                case 9:
                    date += "آذر";
                    break;
                case 10:
                    date += "دی";
                    break;
                case 11:
                    date += "بهمن";
                    break;
                case 12:
                    date += "اسفند";
                    break;
            }

            date += " ماه سال " + pc.GetYear(DateTime.Now).ToString() + " شمسی مصادف با " + DateTime.Now.Day.ToString() + " ";

            switch (DateTime.Now.Month)
            {
                case 1:
                    date += "ژانویه";
                    break;
                case 2:
                    date += "فوریه";
                    break;
                case 3:
                    date += "مارس";
                    break;
                case 4:
                    date += "آپریل";
                    break;
                case 5:
                    date += "می";
                    break;
                case 6:
                    date += "ژوئن";
                    break;
                case 7:
                    date += "جولای";
                    break;
                case 8:
                    date += "آگوست";
                    break;
                case 9:
                    date += "سپتامبر";
                    break;
                case 10:
                    date += "اکتبر";
                    break;
                case 11:
                    date += "نوامبر";
                    break;
                case 12:
                    date += "دسامبر";
                    break;
            }

            date += " سال " + DateTime.Now.Year.ToString() + " میلادی";

            System.Globalization.HijriCalendar hc = new System.Globalization.HijriCalendar();

            date += " و همچنین " + hc.GetDayOfMonth(DateTime.Now).ToString() + " ";
            switch (hc.GetMonth(DateTime.Now))
            {
                case 1:
                    date += "محرم";
                    break;
                case 2:
                    date += "صفر";
                    break;
                case 3:
                    date += "ربیع الاول";
                    break;
                case 4:
                    date += "ربیع الثانی";
                    break;
                case 5:
                    date += "جمادی الاول";
                    break;
                case 6:
                    date += "جمادی الثانی";
                    break;
                case 7:
                    date += "رجب";
                    break;
                case 8:
                    date += "شعبان";
                    break;
                case 9:
                    date += "رمضان";
                    break;
                case 10:
                    date += "شوال";
                    break;
                case 11:
                    date += "ذیقعده";
                    break;
                case 12:
                    date += "ذیحجه";
                    break;
            }

            date += " سال " + hc.GetYear(DateTime.Now).ToString() + " قمری";

            messages.Add(date);
            try
            {
                // Get Daily Messages
                JDailyMessage jDM = new JDailyMessage();
                DataTable jdt = jDM.GetMonasebat(DateTime.Now);
                foreach (DataRow item in jdt.Rows)
                {
                    messages.Add(item["Text"].ToString().Replace("[MONASEBAT]", "::: "));
                }
                jdt = jDM.GetRandomMessages(DateTime.Now.AddDays(-10));
                foreach (DataRow item in jdt.Rows)
                {
                    messages.Add(item["Text"].ToString());
                }
            }
            catch
            {
            }
            AutoTypeLabelShow.label1.Click += new EventHandler(label1_Click);
            TodayInfo = messages[0];
            AutoTypeLabelShow.TextList = messages.ToArray();
            #endregion

        }

        void label1_Click(object sender, EventArgs e)
        {
            JMessages.Information(TodayInfo, "اطلاعات");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
 
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (View.Details.ToString() == toolStripComboBox1.SelectedItem.ToString())
            //    listView1.View = View.Details;
            //if (View.LargeIcon.ToString() == toolStripComboBox1.SelectedItem.ToString())
            //    listView1.View = View.LargeIcon;
            //if (View.List.ToString() == toolStripComboBox1.SelectedItem.ToString())
            //    listView1.View = View.List;
            //if (View.SmallIcon.ToString() == toolStripComboBox1.SelectedItem.ToString())
            //    listView1.View = View.SmallIcon;
            //if (View.Tile.ToString() == toolStripComboBox1.SelectedItem.ToString())
            //    listView1.View = View.Tile;

        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //JSystem.Nodes.DataTable.DefaultView.Sort = listView1.Columns[e.Column].Name;
        }

      
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            JPermission.PermissionDataTable = null;
            JPermission.PermissionDataTableGroup = null;

            JSystem.Free();
            RightButtonBar.Groups.Clear();
            JSystem.Nodes.TreeNodes.ButtonBar = RightButtonBar;
            SuccessorRefresh();
        }

        private void button1_Click_6(object sender, EventArgs e)
        {

        }

        private void btlLogin_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            JExceptionForm tmp = new JExceptionForm();
            tmp.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            JLoginForm LF = new JLoginForm();
            LF.ShowDialog();
            JSystem.Nodes.TreeNodes.ButtonBarRefresh();
            Globals.JUser user = new Globals.JUser(JMainFrame.CurrentUserCode);
            string UserName = user.username;
            this.Text = "نرم افزار جامع " + "کاربر: " + JMainFrame.CurrentPostTitle;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Globals.JLoginUserForm LF = new Globals.JLoginUserForm();
            LF.ShowDialog();
        }

        private void cmbSuccessor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSuccessor.SelectedIndex == 0 || cmbSuccessor.SelectedValue == null || ((int)cmbSuccessor.SelectedValue == 0))
                return;
            JMainFrame.Successor = (int)cmbSuccessor.SelectedValue != JMainFrame.BaseCurrentPostCode;
            JMainFrame.CurrentPostCode = (int)cmbSuccessor.SelectedValue;
            JMainFrame.CurrentPostTitle = cmbSuccessor.Text;

            RightButtonBar.Groups.Clear();
            JSystem.Nodes.TreeNodes.ButtonBarRefresh();
            this.Text = "نرم افزار جامع " + "کاربر: " + JMainFrame.CurrentPostTitle;
            ClassLibrary.JPermission.PermissionDataTable = null;
            ClassLibrary.JPermission.PermissionDataTableGroup = null;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            ClassLibrary.BarCode.JTestBarcodeForm TBF = new ClassLibrary.BarCode.JTestBarcodeForm();
            TBF.ShowDialog();
        }

        private void button1_Click_4(object sender, EventArgs e)
        {
           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (JMessages.Question("آیا میخواهید از برنامه خارج شوید؟", "خروج از برنامه") == DialogResult.Yes)
                {
                    JMainFrame.CurrentUser.LogOut();
                    this.Close();
                    this.Dispose();
                }
            }
        }

        private void button1_Click_5(object sender, EventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_7(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

       

   }

}
