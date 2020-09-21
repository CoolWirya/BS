using System;
using System.Data;
using System.ServiceProcess;
using ClassLibrary;
using System.Threading;

namespace SMSServise
{
 
    public partial class SMSService : ServiceBase
    {
        private bool _Stop = false;
        ClassLibrary.JSMSCorelib objGSMsms;
        
        public SMSService()
        {
            InitializeComponent();            
        }

        protected override void OnStart(string[] args)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(CheckClientReceiveData));
            thread.IsBackground = true;
            thread.Start(null);
        }

        protected override void OnStop()
        {
            JFile File = new JFile();
            File.FileName = "smsLog.txt";
            File.Read();
            File.FileText += this.EventLog.Log;
            File.Write();
            File.Dispose();
        }

       
        
        private void SendWEBSMS(DataTable _dt)
        {
            ClassLibrary.JSMSSend tmpSendSMS = new ClassLibrary.JSMSSend();
            try
            {
                ClassLibrary.JConfig Config = new JConfig();
                JWebServiceSMS SendSMS_Batch = new JWebServiceSMS();

                foreach (DataRow dr in _dt.Rows)
                {

                    tmpSendSMS.GetData(Convert.ToInt32(dr["Code"]));
                    string[] Mobiles = dr["Mobile"].ToString().Split(new char[] { ',' });
                    string[] ret1 = new string[0];
                    ret1 = SendSMS_Batch.SendSMS_Batch(dr["Text"].ToString(), 
                        Mobiles, 
                        Config.WebSmsNumber, 
                        Config.WebSmsUserName, 
                        Config.WebSmsPassword, 
                        Config.WebSmsIPAddress, 
                        Config.WebSmsCompany, false);

                    if (ret1[0].ToUpper() == "CHECK_OK")
                    {
                        tmpSendSMS.Send = 1; // Send
                        tmpSendSMS.BatchId = ret1[1];
                    }
                    else //Error
                    {
                        if (tmpSendSMS.Send == 0)
                            tmpSendSMS.Send = 2;
                        else
                            tmpSendSMS.Send++;

                    }
                    tmpSendSMS.Update();
                }
            }
            catch
            {
                _Stop = true;
            }
            finally
            {
                _dt.Clear();
                _dt.Dispose();
                tmpSendSMS.Dispose();
            }
        }

        public void SendSMS(JSMSSendType SendType)
        {
            DataTable _dt = ClassLibrary.JSMSSend.GetSMSNotSend();
            if (_dt.Rows.Count > 0)
            {
                if (SendType == JSMSSendType.GSM)
                {
                }
                if (SendType == JSMSSendType.WebService)
                {
                    SendWEBSMS(_dt);
                }
            }
            _dt.Clear();
            _dt.Dispose();
        }
        
        public void CheckClientReceiveData(object Obj)
        {
            while (!_Stop)
            {
                System.Threading.Thread.Sleep(100);
                try
                {
                    (new ClassLibrary.SMS.JSMSPatternCheck()).CheckSMSes();
                }
                catch { }
                SendSMS((new ClassLibrary.JConfig()).SMSSendType);
            }
        }
    }
}
