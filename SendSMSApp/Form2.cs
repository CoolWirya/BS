using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SendSMSApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
            this.btnStart.BackColor = System.Drawing.Color.Red;
            this.btnStop.BackColor = System.Drawing.SystemColors.Control;            

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStart.BackColor = System.Drawing.SystemColors.Control;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            SendSMS();
        }
        private void SendSMS()
        {
            ClassLibrary.JSMSSend tmpSendSMS = new ClassLibrary.JSMSSend();
            ClassLibrary.JClsSMS tmpSMS = new ClassLibrary.JClsSMS();

            try
            {
                tmpSMS.PortName = txtPort.Text;// "COM7";
                tmpSMS.Pincode = "";
                tmpSMS.DeviceSpeed = Convert.ToInt32(txtDeviceSpeed.Text);// "115200");
                foreach (DataRow dr in ClassLibrary.JSMSSend.GetSMSNotSend().Rows)
                {
                    if (tmpSMS.SendSMS(dr["Mobile"].ToString(), dr["Text"].ToString(), "Unicode"))
                    {
                        tmpSendSMS.GetData(Convert.ToInt32(dr["Code"]));
                        tmpSendSMS.Send = true;
                        tmpSendSMS.Update();
                    }
                }
            }
            finally
            {
                tmpSendSMS.Dispose();
                tmpSMS.Dispose();
            }
        }
    }
}
