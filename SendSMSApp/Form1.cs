using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using AxMmCtlLib;

namespace SendSMSApp
{
    public partial class Form1 : Form
    {
        private Gsm objGsm;
        private SmsConstants objSmsConstants;
        SmsMessage objSmsMessage = new SmsMessageClass();

        public Form1()
        {
            InitializeComponent();
            objGsm = new GsmClass();
            objSmsConstants = new SmsConstantsClass();
            
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int DeviceSpeed;
            string StrDeviceSpeed = "115200";
            if (!int.TryParse(StrDeviceSpeed, out DeviceSpeed))
            {
                DeviceSpeed = 0;
            }

            // Opens the COM-Port of the GSM modem.
            objGsm.Open(txtPort.Text, "", objSmsConstants.GSM_FLOWCONTROL_AUTO, DeviceSpeed);
            //UpdateResult(objGsm.LastError);

            if (objGsm.LastError != 0)
            {
                // Checks if PIN is valid, or required.
                if (objGsm.LastError == 36101)
                {   // 36101 means: Invalid Pin entered. See also www.activexperts.com/support/errorcodes
                    JMessages.Error("Invalid Pin entered: SIM card can be blocked after a number of false attempts in a row.", "");
                }
                objGsm.Close();
                MessageBox.Show("Error");
                return ;
            }

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
        private void UpdateResult(int nResult)
        {
            string StrError = string.Format("{0}: {1}", nResult, objGsm.GetErrorDescription(objGsm.LastError));
        }
        private bool Send(string Recipient, string Message)
        {
            object obj;
            //Message Settings
            objSmsMessage.Clear();
            objSmsMessage.ToAddress = Recipient;
            objSmsMessage.Body = Message;
            objSmsMessage.DataCoding |= objSmsConstants.DATACODING_UNICODE;
            obj = objSmsMessage;
            //int iMultipart = objFrmSendOptions.MultiPart;
            // Sends the SMS Message
            objGsm.SendSms(ref obj, 0, 10000);
            UpdateResult(objGsm.LastError);
            objSmsMessage = (SmsMessage)obj;
            string strMessageReference = objSmsMessage.Reference;
            if (objGsm.LastError == 0)
                return true;
            else
                return false;
        }

        private void SendSMS()
        {
            ClassLibrary.JSMSSend tmpSendSMS = new ClassLibrary.JSMSSend();
            ClassLibrary.JClsSMS tmpSMS = new ClassLibrary.JClsSMS();

            //tmpSendSMS.GetData(1000003);
            //while (true)
            //{
            //    tmpSendSMS.ObjectCode++;
            //    tmpSendSMS.Update();
            //    Thread.Sleep(1000);
            //}

            try
            {
                tmpSMS.PortName = txtPort.Text;// "COM7";
                tmpSMS.Pincode = "";
                tmpSMS.DeviceSpeed = Convert.ToInt32(txtDeviceSpeed.Text);// "115200");
                //while (true)
                //{
                foreach (DataRow dr in ClassLibrary.JSMSSend.GetSMSNotSend().Rows)
                {
                    if (Send(dr["Mobile"].ToString(), dr["Text"].ToString()))
                    //if (tmpSMS.SendSMS(dr["Mobile"].ToString(), dr["Text"].ToString(), "Unicode"))
                    {
                        tmpSendSMS.GetData(Convert.ToInt32(dr["Code"]));
                        tmpSendSMS.Send = true;
                        tmpSendSMS.Update();
                    }
                }
                //}
            }
            finally
            {
                tmpSendSMS.Dispose();
                tmpSMS.Dispose();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SendSMS();
        }
    }
}
