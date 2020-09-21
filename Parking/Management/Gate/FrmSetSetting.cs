using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using TCCOParking;
using System.Threading;
using System.Globalization;
using ClassLibrary;


namespace Parking
{
    public partial class FrmSettingForm :JBaseForm
    {
        public BSPTCPClient tcpClient;
        public FrmSettingForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }


        public FrmSettingForm(string _IpDevice,string _IpCenter,int _Port)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            deviceIP = _IpDevice;
            IpCenter = _IpCenter;
                Port=_Port;

        }

        private DateTime dtStart;

        private string deviceIP="";
        private String IpCenter = "";
        private int Port;

        private string Add0(string str, int length)
        {
            while (str.Length < length) str = "0" + str;
            return str;
        }

        private string BytesToHexString(byte[] bytes)
        {
            string str = "";
            for (int i = 0; i < bytes.Length; i++)
                str += Add0(Convert.ToString(bytes[i], 16), 2) + " ";
            return str.ToUpper();
        }

        private byte[] HexStringToBytes(string strHexBytes)
        {
            strHexBytes = strHexBytes.Replace("  ", " ").Trim().ToUpper();
            string[] strings = strHexBytes.Split(' ');
            byte[] bytes = new byte[strings.Length];
            for (int i = 0; i < strings.Length; i++)
                bytes[i] = Convert.ToByte(strings[i], 16);
            return bytes;
        }

        private string TrimDate(DateTime dt)
        {
            PersianCalendar pc = new PersianCalendar();
            int year = pc.GetYear(dt);
            int month = pc.GetMonth(dt);
            int day = pc.GetDayOfMonth(dt);
            string str = year.ToString() + "/";
            if (month < 10)
                str += "0";
            str += month.ToString() + "/";
            if (day < 10)
                str += "0";
            str += day.ToString();
            return str;
        }

        private string TrimTime(DateTime dt)
        {

            int hour = dt.Hour;
            int minute = dt.Minute;
            int second = dt.Second;
            string str = "";
            if (hour < 10)
                str += "0";
            str += hour.ToString() + ":";
            if (minute < 10)
                str += "0";
            str += minute.ToString() + ":";
            if (second < 10)
                str += "0";
            str += second.ToString();
            return str;
        }

        private DateTime PersianDateToDateTime(string pdate)
        {
            PersianCalendar pc = new PersianCalendar();
            int year = Convert.ToInt32(pdate.Substring(0, 4));
            int month = Convert.ToInt32(pdate.Substring(5, 2));
            int day = Convert.ToInt32(pdate.Substring(8, 2));
            int hour, minute, second;
            hour = minute = second = 0;
            if (pdate.Length > 10)
            {
                hour = Convert.ToInt32(pdate.Substring(11, 2));
                minute = Convert.ToInt32(pdate.Substring(14, 2));
                if (pdate.Length > 16)
                    second = Convert.ToInt32(pdate.Substring(17, 2));
            }

            return pc.ToDateTime(year, month, day, hour, minute, second, 0);
        }

        private string TrimForIP(string ip)
        {
            string[] bytes = ip.Split('.');
            string ipOut = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                bool canConvert = false;
                for (int j = 0; j < bytes[i].Length; j++)
                {
                    if (bytes[i][j] != '0' || j == bytes[i].Length - 1)
                        canConvert = true;
                    if (canConvert && Char.IsDigit(bytes[i][j]))
                        ipOut += bytes[i][j];
                }
                if (i < bytes.Length - 1)
                    ipOut += ".";
            }
            return ipOut;
        }

        private void ClearAllControls(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox)
                    (control as TextBox).Clear();
                else if (control is MaskedTextBox)
                    (control as MaskedTextBox).Clear();
                else if (control is MaskedTextBox)
                    (control as MaskedTextBox).Clear();
                else if (control.HasChildren)
                    ClearAllControls(control);

            }
        }
        
        private void FrmMain_Load(object sender, EventArgs e)
        {
            PersianCalendar pc = new PersianCalendar();
            int year = pc.GetYear(DateTime.Now);
            int month = pc.GetMonth(DateTime.Now);
            int day = pc.GetDayOfMonth(DateTime.Now);
            int hour = pc.GetHour(DateTime.Now);
            int minute = pc.GetMinute(DateTime.Now);
            string str = year.ToString();
            if (month < 10)
                str += "0";
            str += month.ToString();
            if (day < 10)
                str += "0";
            str += day.ToString();
            txtDate.Text = str;

            str = "";
            
            if (hour < 10)
                str += "0";
            str += hour.ToString();
            if (minute < 10)
                str += "0";
            str += minute.ToString();
            txtTime.Text = str;
            
            str = "";
            tcpClient = new BSPTCPClient();
            tcpClient.Connect(IpCenter,Convert.ToUInt16(Port));
        }

       



        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllControls(this);
        }


        private void btnSetIP_Click(object sender, EventArgs e)
        {
            byte[] p = { 192, 168, 0, 1 };

            System.Net.IPAddress ip = new System.Net.IPAddress(p);//(long)(192 << 24) + (long)(168 << 16) + (long)(2));
            Text = ip.ToString();
            IPAddress newIP, subnet, serverIP;
            bool isIpTrue = true;

            isIpTrue = IPAddress.TryParse(TrimForIP(txtIP.Text), out newIP);
            isIpTrue = isIpTrue & IPAddress.TryParse(TrimForIP(txtSubnet.Text), out subnet);
            isIpTrue = isIpTrue & IPAddress.TryParse(TrimForIP(txtServerIP.Text), out serverIP);
            if (isIpTrue)
            {
                if (deviceIP.Length > 0)
                   tcpClient.SendData("SetIpDevice" +","+ deviceIP +","+ txtIP.Text +","+ txtSubnet.Text +","+ txtServerIP.Text);
                //tccoParking.SetIP(deviceIP, newIP, subnet, serverIP);
            }
        }

        private void btnOffline_Click(object sender, EventArgs e)
        {
            if (deviceIP.Length > 0)
                tcpClient.SendData("GetDataOfflineData" + "," + deviceIP);
            //tccoParking.GetOfflineData(deviceIP);
        }

        private void btnSetDateTime_Click(object sender, EventArgs e)
        {
            if (deviceIP.Length > 0)
            {
                try
                {
                    //DateTime dt = PersianDateToDateTime(Commands[2] + ' ' + Commands[3]);
                    tcpClient.SendData("SetDateTimeDevice" + "," + deviceIP + "," + txtDate.Text + "," + txtTime.Text);
                    //tccoParking.SetِDateTime(deviceIP, dt);
                }
                catch (Exception exp)
                {
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (deviceIP.Length > 0)
                tcpClient.SendData("ResetDevice" + "," + deviceIP);
            //tccoParking.ResetDevice(deviceIP);
        }

        private void btnVolume_Click(object sender, EventArgs e)
        {
            if (deviceIP.Length > 0)
                tcpClient.SendData("SetVolumeDevice" + "," + deviceIP + "," + txtVolume.Value.ToString());
            //tccoParking.SetVolume(deviceIP, Convert.ToByte(txtVolume.Value));
        }

        private void btnFormat_Click(object sender, EventArgs e)
        {
            if (deviceIP.Length > 0)
               tcpClient.SendData("FormatMemoryDevice" + "," + deviceIP);
            //tccoParking.FormatMemory(deviceIP);
        }

    }
}

