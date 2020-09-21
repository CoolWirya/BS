using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using mCore;

namespace SendSMSApp
{
    public partial class SMSmcore : Form
    {
        public SMSmcore()
        {
            InitializeComponent();
        }

        ClassLibrary.JSMSCorelib objSMS;

        private void Start_Click()
        {
            timer1.Start();
            this.btnStart.BackColor = System.Drawing.Color.Red;
        }

        private void Stop_Click()
        {
            timer1.Stop();
            objSMS.disConnect();
            this.btnStart.BackColor = System.Drawing.SystemColors.Control;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            SendSMS();
            timer1.Start();
        }
        public void SendSMS()
        {
            ClassLibrary.JSMSSend tmpSendSMS = new ClassLibrary.JSMSSend();
            try
            {
                DataTable _dt = ClassLibrary.JSMSSend.GetSMSNotSend();
                foreach (DataRow dr in _dt.Rows)
                {
                    objSMS.SendSMS(dr["Mobile"].ToString(), dr["Text"].ToString());
                    if (objSMS.objSMS.ErrorCode == 0)
                    {
                        tmpSendSMS.GetData(Convert.ToInt32(dr["Code"]));
                        tmpSendSMS.Send = 1;
                        tmpSendSMS.Update();
                        txtLog.Text += Environment.NewLine +
                            "Send SMS :" + dr["Mobile"].ToString() + " Text :" + dr["Text"].ToString();
                    }
                    else
                    {
                        txtLog.Text += Environment.NewLine + "خطا:"+objSMS.objSMS.ErrorDescription + " " + dr["Mobile"].ToString();
                    }

                }
            }
            finally
            {
                tmpSendSMS.Dispose();
            }
        }

        private bool Connect()
        {
            if (objSMS == null)
            {
                objSMS = new ClassLibrary.JSMSCorelib(txtPort.Text, BaudRate.BaudRate_115200, mCore.Encoding.Unicode_16Bit);
            }
            else
            {
                objSMS.disConnect();
                objSMS.objSMS.Port = txtPort.Text;
                objSMS.objSMS.BaudRate = BaudRate.BaudRate_115200;
                objSMS.objSMS.Encoding = mCore.Encoding.Unicode_16Bit;
            }
            if (objSMS.Connect())
            {
                return
                    true;
            }
            return false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "Connect")
            {
                if (Connect())
                {
                    txtLog.Text += Environment.NewLine + "Connect";
                    btnConnect.Text = "DisConnect";
                    btnStart.Enabled = true;
                    btnConnect.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    txtLog.Text = Environment.NewLine + objSMS.objSMS.ErrorDescription;
                }
            }
            else
            {
                objSMS.disConnect();
                txtLog.Text += Environment.NewLine + "DisConnect";
                btnConnect.Text = "Connect";
                btnStart.Enabled = false;
                btnConnect.BackColor = System.Drawing.SystemColors.Control;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                if (objSMS.objSMS.IsConnected)
                {
                    btnStart.BackColor = System.Drawing.Color.Green;
                    btnStart.Text = "Stop";
                    Start_Click();
                    txtLog.Text += Environment.NewLine + "Start Send";
                }
            }
            else
            {
                btnStart.Text = "Start";
                btnStart.BackColor = System.Drawing.SystemColors.Control;
                Stop_Click();
                txtLog.Text += Environment.NewLine + "Stop Send";
            }
        }
    }
}
