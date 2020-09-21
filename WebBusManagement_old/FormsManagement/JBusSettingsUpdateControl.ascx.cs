using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusManagment;

namespace WebBusManagement.FormsManagement
{
    public partial class JBusSettingsUpdateControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadSettings();
        }

        public void LoadSettings()
        {
            txtStartTime.Text = BusManagment.Settings.JBusSettings.Get("BusStartTime").ToString();
            txtSpeedLimit.Text = BusManagment.Settings.JBusSettings.Get("SpeedLimit").ToString();
            txtTrepassOfLineMeter.Text = BusManagment.Settings.JBusSettings.Get("TrepassOfLineMeter").ToString();
            //txtBusCompanyAccountNumber.Text = BusManagment.Settings.JBusSettings.Get("BusCompanyAccountNumber").ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int speedLimit, TrepassOfLineMeter, BusCompanyAccountNumber;
            if (int.TryParse(txtSpeedLimit.Text, out speedLimit) == true)
            {
                if (int.TryParse(txtTrepassOfLineMeter.Text, out TrepassOfLineMeter) == true)
                {
                    if (TimeValidation(txtStartTime.Text) == true)
                    {
                        //if (int.TryParse(txtBusCompanyAccountNumber.Text, out BusCompanyAccountNumber) == true)
                        //{
                        BusManagment.Settings.JBusSettings.Set("BusStartTime", txtStartTime.Text);
                        BusManagment.Settings.JBusSettings.Set("SpeedLimit", txtSpeedLimit.Text);
                        BusManagment.Settings.JBusSettings.Set("TrepassOfLineMeter", txtTrepassOfLineMeter.Text);
                        //BusManagment.Settings.JBusSettings.Set("BusCompanyAccountNumber", txtBusCompanyAccountNumber.Text);
                        WebClassLibrary.JWebManager.RunClientScript("alert('تنظیمات اتوبوس با موفقیت بروز رسانی شد');", "UpdateSettings");
                        //}
                        //else
                        //{
                        //    txtBusCompanyAccountNumber.Text = "";
                        //    txtBusCompanyAccountNumber.Focus();
                        //    WebClassLibrary.JWebManager.RunClientScript("alert('لطفا برای شماره حساب اتوبوسرانی عدد وارد کنید');", "UpdateSettings");
                        //}

                    }
                    else
                    {
                        txtStartTime.Text = "";
                        txtStartTime.Focus();
                        WebClassLibrary.JWebManager.RunClientScript("alert('لطفا تاریخ شروع را با قالب صحیح وارد کنید');", "UpdateSettings");
                    }
                }
                else
                {
                    txtTrepassOfLineMeter.Text = "";
                    txtTrepassOfLineMeter.Focus();
                    WebClassLibrary.JWebManager.RunClientScript("alert('لطفا برای میزان مجاز تجاوز از خط عدد وارد کنید');", "UpdateSettings");
                }
            }
            else
            {
                txtSpeedLimit.Text = "";
                txtSpeedLimit.Focus();
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفا برای سرعت مجاز عدد وارد کنید');", "UpdateSettings");
            }
        }

        public bool TimeValidation(string Time)
        {
            try
            {
                TimeSpan ti = new TimeSpan(Convert.ToInt32(Time.Split(':')[0].ToString()), Convert.ToInt32(Time.Split(':')[1].ToString()), 0);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}