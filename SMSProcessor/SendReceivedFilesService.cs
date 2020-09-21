using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using ClassLibrary;

namespace SMSProcessor
{
    partial class SendReceivedFilesService : ServiceBase
    {
        public SendReceivedFilesService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            SendReceivedFiles();
        }

        public void SendReceivedFiles()
        {
            string strPath = @"C:\inetpub\wwwroot\getsms\SMS\Received";
            JDataBase db = new JDataBase();
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                try
                {
                    string[] files = System.IO.Directory.GetFiles(strPath);
                    for (int i = 0; i < files.Length; i++)
                    {
                        string[] data = System.IO.File.ReadAllLines(files[i]);
                        //First Line: DateTime.Tick
                        DateTime Send_Date = DateTime.MinValue;
                        try
                        {
                            Send_Date = new DateTime(Convert.ToInt64(data[0]));
                        }
                        catch
                        {
                            Send_Date = DateTime.MinValue;
                        }
                        finally { }

                        //Second Line: Sender Number
                        string Sender_Number = data[1];

                        //Third Line: Receiver Number
                        // Always 10000144

                        //Forth and Other Lines: Message Text
                        string Message = "";
                        for (int j = 3; j < data.Length; j++)
                            Message += data[j];

                        //Insert to Database
                        try
                        {
                            db.beginTransaction("VPS_SMS_RECEIVED");
                            db.setQuery(@"INSERT INTO [ERP_Sepad].[dbo].[SMSesReceived]
                                       ([Code]
                                       ,[SMS_Text]
                                       ,[Sender_Number]
                                       ,[Sender_PersonCode]
                                       ,[Sender_Full_Title]
                                       ,[Send_Date]
                                       ,[Service_Read_Date]
                                       ,[Status])
                                 VALUES
                                       ((select isnull(MAX(s.Code),0)+1 from [SMSesReceived] s)
                                       ,N'" + Message + @"'
                                       ,N'" + Sender_Number + @"'
                                       ,(select isnull((select TOP 1 clsAllPerson.Code from clsAllPerson inner join clsPersonAddress on clsAllPerson.Code = clsPersonAddress.PCode where clsPersonAddress.Mobile = N'" + Sender_Number + @"'), 0))
                                       ,(select isnull((select TOP 1 Name from clsAllPerson inner join clsPersonAddress on clsAllPerson.Code = clsPersonAddress.PCode where clsPersonAddress.Mobile = N'" + Sender_Number + @"'), ''))
                                       ,CAST('" + Send_Date.ToString("yyyy/MM/dd HH:mm:ss") + @"' as datetime)
                                       ,CAST('" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + @"' as datetime)
                                       , 0)");
                            if (db.Query_Execute() > 0)
                            {
                                System.IO.File.Delete(files[i]);
                                if (System.IO.File.Exists(files[i]) == false)
                                    db.Commit();
                                else
                                    db.Rollback("VPS_SMS_RECEIVED");
                            }
                        }
                        catch
                        {
                            db.Rollback("VPS_SMS_RECEIVED");
                        }
                        finally
                        {
                            //db.Dispose();
                        }
                    }
                }
                catch { }
                finally
                { }
            }
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
