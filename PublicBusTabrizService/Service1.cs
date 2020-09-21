using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Linq;
using System.Threading;
using ClassLibrary;

namespace PublicBusTabrizService
{
    public partial class PublicBusTabrizService : ServiceBase
    {
        Thread AVLThread;
        Thread TicketThread;
        Thread TicketThreadOffilne;
        Thread BusUpdateLocationThread;
        Thread ShowExceptionThread;
        Thread KillSleetConnThread;
        Thread DistanceMeasurement;
        Thread SocketAvl;
        Thread TransactionPrintCheck;
        Thread TransactionPrintInsert;
        Thread TransactionPrintInsertDailyMontly;
        Thread CalenderRepair;
        Thread SendSMS;
        Thread EventLog;
        Thread TicketHandHeldThread;
        BSPTCPServer BspTcpServer;
        bool _NoClose = true;
        bool _AVLThread = true;
        bool _TicketThread = true;
        bool _TicketThreadOffilne = true;
        bool _BusUpdateLocationThread = true;
        bool _ShowExceptionThread = true;
        bool _KillSleetConnThread = true;
        bool _DistanceMeasurement = true;
        bool _SocketAvl = true;
        bool _TransactionPrintCheck = true;
        bool _TransactionPrintInsert = true;
        bool _TransactionPrintInsertDailyMontly = true;
        bool _CalenderRepair = true;
        bool _SendSMS = true;
        bool _EventLog = true;
        bool _TicketHandHeldThread = true;
        int SocketConnect = 0;

        bool Public;
        public PublicBusTabrizService()
        {
            InitializeComponent();

            string OutStr = "";
            ClassLibrary.JMainFrame.FConfig.TryGetValue("Public", out OutStr);
            Public = OutStr == "1";
        }

        protected override void OnStart(string[] args)
        {
            AVLServiceForm();
        }

        protected override void OnStop()
        {
            AVLServiceForm_FormClosed(null);
        }

        public void AVLServiceForm()
        {
            BspTcpServer = new BSPTCPServer();
            BspTcpServer.OnClientConnect += new BSPTCPServer.OnClientConnectHandler(this.BspTcpServer_OnClientConnect);
            BspTcpServer.OnClientDisconnect += new BSPTCPServer.OnClientDisconnectHandler(this.BspTcpServer_OnClientDisconnect);
            BspTcpServer.OnError += new BSPTCPServer.OnErrorHandler(this.BspTcpServer_OnError);
            BspTcpServer.OnReceiveData += new BSPTCPServer.OnReceiveDataHandler(this.BspTcpServer_OnReceiveData);


            AVLThread = new Thread(AVLProcess);
            TicketThread = new Thread(TicketProcess);
            TicketHandHeldThread = new Thread(TicketHandHeldProcess);
            TicketThreadOffilne = new Thread(TicketProcessOffline);
            BusUpdateLocationThread = new Thread(BusUpdateLocation);
            ShowExceptionThread = new Thread(ShowException);
            KillSleetConnThread = new Thread(KillConnection);
            DistanceMeasurement = new Thread(DistanceMeasur);
            SocketAvl = new Thread(SocketAvlProcess);
            TransactionPrintCheck = new Thread(TransactionPrintCheckProcess);
            TransactionPrintInsert = new Thread(TransactionPrintInsertProcess);
            TransactionPrintInsertDailyMontly = new Thread(TransactionPrintInsertDailyMontlyProcess);
            CalenderRepair = new Thread(CalenderRepairProcess);
            SendSMS = new Thread(SendSMSProcess);
            EventLog = new Thread(EventLogProcess);

            StartSocketLisner();
            AVLThread.Start();
            TicketThread.Start();
            TicketHandHeldThread.Start();
            TicketThreadOffilne.Start();
            //BusUpdateLocationThread.Start();
            //ShowExceptionThread.Start();
            //KillSleetConnThread = new Thread(KillConnection);
            //DistanceMeasurement = new Thread(DistanceMeasur);
            SocketAvl.Start();
            TransactionPrintCheck.Start();
            //TransactionPrintInsert.Start();
            //TransactionPrintInsertDailyMontly.Start();
            CalenderRepair.Start();
            //SendSMS.Start();
            EventLog.Start();

        }


        delegate void SetTextCallback(string text, int pType);

        private void SetText(string text, int pType)
        {
        }

        #region
        private void ShowException()
        {
            while (_NoClose)
            {
                Thread.Sleep(20000);
                try
                {
                }
                catch (Exception ex)
                {
                    ClassLibrary.JSystem.Except.AddException(ex);
                }
            }
        }

        private void SocketAvlProcess()
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                while (_SocketAvl)
                {
                    Thread.Sleep(1000);
                    (new BusManagment.Transaction.JTransactions()).SocketCheckDataAVL(db);
                }
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
            try
            {
                SocketAvl.Abort();
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);

            }
            SocketAvl = null;
            SocketAvl = new Thread(SocketAvlProcess);
            SocketAvl.Start();
        }

        private void TransactionPrintInsertDailyMontlyProcess()
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            ClassLibrary.JMySQLDataBase mysqlDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            try
            {
                while (_TransactionPrintInsertDailyMontly)
                {

                    Thread.Sleep(3600000);

                    //BusManagment.Transaction.JTicketTransactions.TransactionPrintInsertDaily(db, mysqlDB);
                }
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
                mysqlDB.Dispose();
            }
            try
            {
                TransactionPrintInsertDailyMontly.Abort();
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);

            }
            TransactionPrintInsertDailyMontly = null;
            TransactionPrintInsertDailyMontly = new Thread(TransactionPrintInsertDailyMontlyProcess);
            TransactionPrintInsertDailyMontly.Start();

        }

        private void TransactionPrintInsertProcess()
        {
            //int TimerCount = 1;
            //DateTime InsertDate;
            //ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            //ClassLibrary.JMySQLDataBase mysqlDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            //try
            //{
            //    while (_TransactionPrintInsert)
            //    {
            //        if (txt_InsertPrintTimer.Text.Length > 0)
            //        {
            //            if (int.TryParse(txt_InsertPrintTimer.Text, out TimerCount))
            //            {
            //                Thread.Sleep(TimerCount);
            //                if (txt_InsertPrintDate.Text.Length > 0)
            //                {
            //                    if (DateTime.TryParse(txt_InsertPrintDate.Text, out InsertDate))
            //                    {
            //                        //BusManagment.Transaction.JTicketTransactions.TransactionPrintInsert(db, mysqlDB, InsertDate);
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ClassLibrary.JSystem.Except.AddException(ex);
            //}
            //finally
            //{
            //    db.Dispose();
            //    mysqlDB.Dispose();
            //}
            //TransactionPrintInsert.Abort();
        }

        private void TransactionPrintCheckProcess()
        {
            if (Public)
                return;
            DateTime InsertDate;
            DateTime.TryParse("2014//03//21", out InsertDate);
            int TimerCount = 600;
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            ClassLibrary.JMySQLDataBase mysqlDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            try
            {
                while (_TransactionPrintCheck)
                {
                    //if (txt_CheckPrintTimer.Text.Length > 0)
                    {
                        //if (int.TryParse(txt_CheckPrintTimer.Text, out TimerCount))
                        {
                            Thread.Sleep(TimerCount);

                            //if (txt_InsertPrintDate.Text.Length > 0)
                            {
                                //if (DateTime.TryParse(txt_InsertPrintDate.Text, out InsertDate))
                                {
                                    if (Public)
                                    {
                                        BusManagment.TransactionPublic.JTransactions.TransactionPrintCheckDataTicketPublic(db, mysqlDB, InsertDate);
                                    }
                                    else
                                    {
                                        BusManagment.Transaction.JTicketTransactions.TransactionPrintCheckDataTicket(db, mysqlDB, InsertDate);
                                    }
                                    //BusManagment.Transaction.JTicketTransactions.TransactionPrintInsert(db, mysqlDB, InsertDate);
                                }
                            }
                            if (!Public)
                            {
                                // BusManagment.Transaction.JTicketTransactions.TransactionPrintInsert(db, mysqlDB, DateTime.Now);
                                //BusManagment.Transaction.JTicketTransactions.TransactionPrintCheckDataTicketForAllPrinterReport(db, mysqlDB);
                                //BusManagment.Transaction.JTicketTransactions.TransactionDailyPrintUpdateFromMySql(db, mysqlDB);
                                //BusManagment.Transaction.JTicketTransactions.TransactionDailyPrintCheck(db, mysqlDB);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
                mysqlDB.Dispose();
            }
            TransactionPrintCheck.Abort();
        }

        private void AVLProcess()
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            while (_AVLThread)
            {
                try
                {
                    Thread.Sleep(1000);
                    if (Public)
                        (new BusManagment.TransactionPublic.JTransactions()).CheckDataAVLPublic();
                    else
                        (new BusManagment.Transaction.JTransactions()).SocketCheckDataAVL(db);
                }

                catch (Exception ex)
                {
                    ClassLibrary.JSystem.Except.AddException(ex);
                }
            }
            AVLThread.Abort();
            db.Dispose();
        }

        private void TicketProcess()
        {
            ClassLibrary.JMySQLDataBase mysqlDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            while (_TicketThread)
            {
                try
                {
                    Thread.Sleep(5000);
                    if (Public)
                    {
                        (new BusManagment.TransactionPublic.JTransactions()).CheckDataTicket();
                        (new BusManagment.TransactionPublic.JTransactions()).CheckDataTicketMySql();
                    }
                    else
                        (new BusManagment.Transaction.JTransactions()).CheckDataTicket();
                }
                catch (Exception ex)
                {
                    ClassLibrary.JSystem.Except.AddException(ex);
                }
                finally
                {
                }
            }
            TicketThread.Abort();
            mysqlDB.Dispose();
        }

        private void TicketHandHeldProcess()
        {
            try
            {
                while (_TicketHandHeldThread)
                {
                    Thread.Sleep(500);
                    (new BusManagment.Transaction.JTransactions()).CheckDataTicketHandHeld();
                }
                TicketHandHeldThread.Abort();
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);

            }
            finally
            {
            }
        }

        public void EventLogProcess()
        {
            if (Public)
                return;

            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            ClassLibrary.JMySQLDataBase mydb = new ClassLibrary.JMySQLDataBase("127.0.0.1", "root", "MyPaSsTaB1392", "bus");
            try
            {
                while (_EventLog)
                {
                    Thread.Sleep(5000);
                    if (!Public)
                        (new BusManagment.EventLog.JEventLog()).EventLogProcess(db, mydb);
                }
                EventLog.Abort();
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }

            finally
            {
                db.Dispose();
            }
        }

        public void SendSMSProcess()
        {
            if (Public)
                return;
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            while (_SendSMS)
            {
                Thread.Sleep(60000);
                try
                {
                    (new ClassLibrary.SMS.ClsMainSmsClass()).SendSMSService(Db);
                }
                catch (Exception ex)
                {
                    Db.Dispose();
                    ClassLibrary.JSystem.Except.AddException(ex);
                }
            }
            Db.Dispose();
            SendSMS.Abort();
        }

        private void CalenderRepairProcess()
        {
            if (Public)
                return;
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            ClassLibrary.JMySQLDataBase MySqlDb = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            while (_CalenderRepair)
            {
                Thread.Sleep(180000);
                try
                {
                    if (!Public)
                    {
                    }
                }
                catch (Exception ex)
                {
                    Db.Dispose();
                    MySqlDb.Dispose();
                    ClassLibrary.JSystem.Except.AddException(ex);
                }
                finally
                {
                    Db.Dispose();
                    MySqlDb.Dispose();
                }
                Thread.Sleep(1800000);
            }
            CalenderRepair.Abort();
        }

        private void TicketProcessOffline()
        {
            while (_TicketThreadOffilne)
            {
                Thread.Sleep(1000);//1000*60*15
                try
                {
                    if (Public)
                    {
                        (new BusManagment.TransactionPublic.JTransactions()).CheckDataOfflineTicketPublic();
                        (new BusManagment.TransactionPublic.JTransactions()).CheckDataSQLiteTicket();
                        (new BusManagment.TransactionPublic.JTransactions()).CheckDataOfflineTicketPublicForStatus3();
                        (new BusManagment.TransactionPublic.JTransactions()).CheckDataOfflineTicketPublicForStatus4();
                    }
                    else
                    {
                        (new BusManagment.Transaction.JTransactions()).CheckDataSQLiteTicket();
                        (new BusManagment.Transaction.JTransactions()).CheckDataOfflineTicket();
                    }
                }
                catch (Exception ex)
                {
                    ClassLibrary.JSystem.Except.AddException(ex);
                }
            }
            TicketThreadOffilne.Abort();
        }

        private void BusUpdateLocation()
        {
            int backtime, Period;
            while (_BusUpdateLocationThread)
            {
                Thread.Sleep(100);
                BusManagment.AVL.JOnlineMap.UpdateBusLocation(30, 5);
            }
            BusUpdateLocationThread.Abort();
        }

        private void KillConnection(object obj)
        {
            ClassLibrary.JMySQLDataBase MyDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            try
            {
                while (_KillSleetConnThread)
                {
                    Thread.Sleep(1000);
                    MyDB.KillSleepProcess(300);
                }
                KillSleetConnThread.Abort();
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);

            }
            finally
            {
                MyDB.Dispose();
            }
        }


        private void DistanceMeasur(object obj)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                while (_DistanceMeasurement)
                {
                    Thread.Sleep(1000 * 60);
                    BusManagment.AVL.JAVLTransactions.DistanceMeasurement(db);
                }
                DistanceMeasurement.Abort();
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
        }

        #endregion

        private void chkAVL_CheckedChanged(object sender, EventArgs e)
        {
            AVLThread.Start();
        }

        private void chkTicket_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void chkTicket_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        //private void chkBusLocation_CheckedChanged(object sender, EventArgs e)
        //{
        //    _BusUpdateLocationThread = chkBusLocation.Checked;
        //    if (chkBusLocation.Checked)
        //    {
        //        BusUpdateLocationThread.Start();
        //    }
        //}

        private void chkTicket_CheckedChanged_2(object sender, EventArgs e)
        {
            //_TicketThread = chkTicket.Checked;
            //if (chkTicket.Checked)
            //{
            TicketThread.Start();
            //}
        }

        private void StartSocketLisner()
        {
            BspTcpServer.Port = ushort.Parse("8572");
            BspTcpServer.IsListen = true;

            //_SocketAvl = true;
            //if (ChkSocket.Checked)
            //{
            //SocketAvl.Start();
            //}
        }

        private void BspTcpServer_OnReceiveData(object sender, System.Net.Sockets.Socket client, byte[] bytes)
        {
            if (bytes[0] == (byte)200)
            {
                if (bytes[1] == (byte)3)
                {
                    //string str = "Recieved data from your device is: " + data;
                    //SetText(str, 1);
                    //byte[] res = System.Text.Encoding.UTF8.GetBytes(str);
                    //client.Client.Send(res);
                    BspTcpServer.SendData(client, "OK - " + ClassLibrary.BSPTCPServer.GetClientInfo(client).IP);
                    byte[] NewByte = new byte[32];
                    int counter = 0;
                    for (int i = 2; i < 34; i++)
                    {
                        NewByte[counter] = bytes[i];
                        counter++;
                    }
                    ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                    try
                    {
                        DB.setQuery("insert into AUTGroundDeviceTicket(ip,Data,GetDate,IsProceced) values(@ip,@Data,@GetDate,@IsProceced)");
                        DB.Params.Add("ip", ClassLibrary.BSPTCPServer.GetClientInfo(client).IP);
                        DB.Params.Add("Data", NewByte);
                        DB.Params.Add("GetDate", DateTime.Now);
                        DB.Params.Add("IsProceced", 0);
                        DB.Query_Execute();
                    }
                    catch (Exception ex)
                    {
                        ClassLibrary.JSystem.Except.AddException(ex);

                    }
                    finally
                    {
                        DB.Dispose();
                    }
                    return;
                    //  return;
                }
            }
            else if (bytes[0] == (byte)201)
            {
                if (bytes[1] == (byte)1)
                {
                    byte[] uni = Encoding.Unicode.GetBytes(BusManagment.Settings.JBusSettings.Get("RTPISText").ToString());
                    string Ascii = Encoding.ASCII.GetString(uni);
                    BspTcpServer.SendData(client, uni);
                    return;
                }
            }
            else if (bytes[0] == (byte)202)
            {
                if (bytes[1] == (byte)4)
                {
                    byte[] NewByte = new byte[bytes.Length - 2];
                    int counter = 0;
                    for (int i = 2; i < bytes.Length; i++)
                    {
                        NewByte[counter] = bytes[i];
                        counter++;
                    }

                    //AUTHandHeldDeviceTicket

                    ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                    try
                    {
                        DB.setQuery("insert into AUTHandHeldDeviceTicket(ip,Data,GetDate,IsProceced) values(@ip,@Data,@GetDate,@IsProceced)");
                        DB.Params.Add("ip", ClassLibrary.BSPTCPServer.GetClientInfo(client).IP);
                        DB.Params.Add("Data", NewByte);
                        DB.Params.Add("GetDate", DateTime.Now);
                        DB.Params.Add("IsProceced", 0);
                        DB.Query_Execute();
                    }
                    catch (Exception ex)
                    {
                        ClassLibrary.JSystem.Except.AddException(ex);

                    }
                    finally
                    {
                        DB.Dispose();
                    }

                    string RecoedNumber = DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                    //(new BusManagment.Transaction.JTransactions()).CheckDataTicketSocket(NewByte, Convert.ToInt64(RecoedNumber));

                    BspTcpServer.SendData(client, "SAVE OK");

                    return;
                }
            }
            else
            {
                ClassLibrary.Socket.JSocketManager.GetData(client, bytes, "BusManagment.Transaction.JTransactionAVL.GetClassNameBusNumber");
            }
            //BspTcpServer.SendData(client, data);
        }

        private readonly object listLock = new object();

        private void BspTcpServer_OnClientConnect(object sender, System.Net.Sockets.Socket client)
        {
            ClassLibrary.Socket.JSocketManager.Connect(client);
            lock (listLock)
            {
                try
                {
                    //lbSocketConnect.Text =  (int.Parse(lbSocketConnect.Text) + 1).ToString();
                    SocketConnect++;
                    SetText(SocketConnect.ToString(), 3);
                }
                catch (Exception ex)
                {
                    ClassLibrary.JSystem.Except.AddException(ex);
                }
            }
        }

        private void BspTcpServer_OnClientDisconnect(object sender, System.Net.Sockets.Socket client)
        {
            ClassLibrary.Socket.JSocketManager.DisConnect(client);
            lock (listLock)
            {
                try
                {
                    //lbSocketConnect.Text = (int.Parse(lbSocketConnect.Text) - 1).ToString();
                    SocketConnect--;
                    SetText(SocketConnect.ToString(), 3);
                }
                catch (Exception ex)
                {
                    ClassLibrary.JSystem.Except.AddException(ex);
                }
            }
        }

        private void BspTcpServer_OnError(object sender, System.Net.Sockets.Socket client, Exception exception)
        {
            ClassLibrary.JSystem.Except.AddException(exception);
        }

        private void chkOffline_CheckedChanged(object sender, EventArgs e)
        {
            //_TicketThreadOffilne = chkOffline.Checked;
            //if (chkOffline.Checked)
            {
                TicketThreadOffilne.Start();
            }
        }

        private void chkKillSleepCon_CheckedChanged(object sender, EventArgs e)
        {
            //_KillSleetConnThread = chkKillSleepCon.Checked;
            //if (chkKillSleepCon.Checked)
            {
                KillSleetConnThread.Start();
            }
        }


        private void CLoseThread(Thread pT, bool _Check)
        {
            _Check = false;
            try
            {
                //if (pT.ThreadState == ThreadState.Running)
                {
                    pT.Abort();
                    pT.Join();
                }
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            pT = null;
        }

        public void AVLServiceForm_FormClosed(object sender)
        {
            _NoClose = false;

            CLoseThread(AVLThread, _AVLThread);
            CLoseThread(TicketThread, _TicketThread);
            CLoseThread(TicketThreadOffilne, _TicketThreadOffilne);
            CLoseThread(BusUpdateLocationThread, _BusUpdateLocationThread);
            CLoseThread(ShowExceptionThread, _ShowExceptionThread);
            CLoseThread(TransactionPrintCheck, _TransactionPrintCheck);
            CLoseThread(TransactionPrintInsert, _TransactionPrintInsert);
            CLoseThread(TransactionPrintInsertDailyMontly, _TransactionPrintInsertDailyMontly);
            CLoseThread(CalenderRepair, _CalenderRepair);
            CLoseThread(EventLog, _EventLog);
            CLoseThread(TicketHandHeldThread, _TicketHandHeldThread);
            CLoseThread(SocketAvl, _SocketAvl);
            CLoseThread(SendSMS, _SendSMS);
            CLoseThread(EventLog, _EventLog);


        }

        private void chkDistanceMeasurement_CheckedChanged(object sender, EventArgs e)
        {
            //_DistanceMeasurement = chkDistanceMeasurement.Checked;
            //if (chkDistanceMeasurement.Checked)
            {
                DistanceMeasurement.Start();
            }
        }

        private void chkTransactionPrintCheck_CheckedChanged(object sender, EventArgs e)
        {
            //_TransactionPrintCheck = chkTransactionPrintCheck.Checked;
            //if (chkTransactionPrintCheck.Checked)
            {
                TransactionPrintCheck.Start();
            }
        }

        private void chkTransactionPrintInsert_CheckedChanged(object sender, EventArgs e)
        {
            //_TransactionPrintInsert = chkTransactionPrintInsert.Checked;
            //if (chkTransactionPrintInsert.Checked)
            {
                TransactionPrintInsert.Start();
            }
        }

        private void chkTransactionPrintInsertDailyMontly_CheckedChanged(object sender, EventArgs e)
        {
            //_TransactionPrintInsertDailyMontly = chkTransactionPrintInsertDailyMontly.Checked;
            //if (chkTransactionPrintInsertDailyMontly.Checked)
            {
                TransactionPrintInsertDailyMontly.Start();
            }
        }

        private void chkCalenderRapir_CheckedChanged(object sender, EventArgs e)
        {
            //_CalenderRepair = chkCalenderRapir.Checked;
            //if (chkCalenderRapir.Checked)
            {
                CalenderRepair.Start();
            }
        }

        private void chkSendSMS_CheckedChanged(object sender, EventArgs e)
        {
            //_SendSMS = chkSendSMS.Checked;
            //if (chkSendSMS.Checked)
            {
                SendSMS.Start();
            }
        }

        private void chkEventLog_CheckedChanged(object sender, EventArgs e)
        {
            //_EventLog = chkEventLog.Checked;
            //if (chkEventLog.Checked)
            {
                EventLog.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            //    DateTime FDate = Convert.ToDateTime(("2015-01-21 00:00:00").ToString());
            //    DateTime EDate = Convert.ToDateTime(("2015-03-20 00:00:00").ToString());
            //    for (DateTime date = FDate; date <= EDate; date = date.AddDays(1))
            //    {
            //        DB.setQuery("INSERT INTO [dbo].[StaticDates]  ([En_Date],[Fa_Date]) " +
            //                       "VALUES " +
            //                      "('" + date + "', dbo.DateEnToFa('" + date + "') )");
            //        DB.Query_Execute();
            //    }
            //    MessageBox.Show("عملیات با موفقیت انجام شد", "توجه");
            //}
            //catch (Exception ex) { MessageBox.Show("درج با خطا مواجه شد", "هشدار"); }
        }

        private void chkTicketHandHeldTransaction_CheckedChanged(object sender, EventArgs e)
        {
            //_TicketHandHeldThread = chkTicketHandHeldTransaction.Checked;
            //if (chkTicketHandHeldTransaction.Checked)
            {
                TicketHandHeldThread.Start();
            }

        }

    }
}
