using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ERP
{
    public partial class AVLServiceForm : Form
    {

        private bool Public = true;
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
        Thread SendQuery;
        Thread TicketHandHeldThread;
        Thread ServiceProcess;

        bool _NoClose = true;
        bool _AVLThread = false;
        bool _TicketThread = false;
        bool _TicketThreadOffilne = false;
        bool _BusUpdateLocationThread = false;
        bool _ShowExceptionThread = false;
        bool _KillSleetConnThread = false;
        bool _DistanceMeasurement = false;
        bool _SocketAvl = false;
        bool _TransactionPrintCheck = false;
        bool _TransactionPrintInsert = false;
        bool _TransactionPrintInsertDailyMontly = false;
        bool _CalenderRepair = false;
        bool _SendSMS = false;
        bool _EventLog = false;
        bool _SendQuery = false;
        bool _TicketHandHeldThread = false;
        int SocketConnect = 0;
        bool _ServiceProcess = false;

        public AVLServiceForm()
        {
            InitializeComponent();

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
            SendQuery = new Thread(SendQueryProcess);
            ServiceProcess = new Thread(ServiceProcessFunction);

            ShowExceptionThread.Start();

        }


        delegate void SetTextCallback(string text, int pType);

        private void SetText(string text, int pType)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            switch (pType)
            {
                case 1:
                    if (this.listBox1.InvokeRequired)
                    {
                        SetTextCallback d = new SetTextCallback(SetText);
                        this.Invoke(d, new object[] { text, pType });
                    }
                    else
                    {
                        return;
                        this.listBox1.Items.Add(text);
                    }

                    break;
                case 2:
                    this.toolStripStatusLabelConnectn.Text = text;
                    //int dbcount = 0;
                    //if (int.TryParse(text, out dbcount) && int.Parse(text) > 10)
                    //{
                    //	SetText(String.Join(",", ClassLibrary.JDataBase.dbsOpen.GetSql(120)), 1);
                    //}
                    break;
                case 3:
                    if (this.lbSocketConnect.InvokeRequired)
                    {
                        SetTextCallback d = new SetTextCallback(SetText);
                        this.Invoke(d, new object[] { text, pType });
                    }
                    else
                        this.lbSocketConnect.Text = text;
                    break;

            }
        }

        #region
        private void ShowException()
        {
            while (_NoClose)
            {
                Thread.Sleep(20000);
                try
                {
                    SetText(ClassLibrary.JDataBase.dbsOpen.Count.ToString(), 2);

                    if (ClassLibrary.JSystem.Except.Count > 0)
                    {
                        for (int i = 0; i < ClassLibrary.JSystem.Except.Count; i++)
                        {
                            if (ClassLibrary.JSystem.Except.GetByIndex(i) != null)
                                SetText(ClassLibrary.JSystem.Except.GetByIndex(i).Message + '-' + ClassLibrary.JSystem.Except.GetByIndex(i).Source, 1);
                        }
                        ClassLibrary.JSystem.Except.EmptyExceptions();
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void SocketAvlProcess()
        {
            try
            {
                while (_SocketAvl)
                {
                    Thread.Sleep(1);
                    (new BusManagment.Transaction.JTransactions()).SocketCheckDataAVL();
                }
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
            }
            SocketAvl.Abort();
        }

        private void ServiceProcessFunction()
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                while (_ServiceProcess)
                {
                    Thread.Sleep(1);
                    BusManagment.WorkOrder.JTariff.ServiceProcessFunction(db);
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
            ServiceProcess.Abort();
        }

        private void TransactionPrintInsertDailyMontlyProcess()
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            ClassLibrary.JMySQLDataBase mysqlDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            try
            {
                while (_TransactionPrintInsertDailyMontly)
                {
                    // if (DateTime.Now.Hour >= 7 & DateTime.Now.Hour <= 24)
                    //   BusManagment.Transaction.JTicketTransactions.TransactionPrintInsert(db, mysqlDB, DateTime.Now);

                    //Thread.Sleep(3600000);

                    // if (DateTime.Now.Hour >= 2 & DateTime.Now.Hour <= 6)
                    BusManagment.Transaction.JTicketTransactions.TransactionPrintInsertDaily(db, mysqlDB);
                    //if (DateTime.Now.Hour > 5 & DateTime.Now.Hour <= 6)
                    //  BusManagment.Transaction.JTicketTransactions.TransactionPrintInsertMonthly(db, mysqlDB);
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
            TransactionPrintInsertDailyMontly.Abort();
        }

        private void TransactionPrintInsertProcess()
        {
            int TimerCount = 1;
            DateTime InsertDate;
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            ClassLibrary.JMySQLDataBase mysqlDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            try
            {
                while (_TransactionPrintInsert)
                {
                    if (txt_InsertPrintTimer.Text.Length > 0)
                    {
                        if (int.TryParse(txt_InsertPrintTimer.Text, out TimerCount))
                        {
                            Thread.Sleep(TimerCount);
                            if (txt_InsertPrintDate.Text.Length > 0)
                            {
                                if (DateTime.TryParse(txt_InsertPrintDate.Text, out InsertDate))
                                {
                                    //BusManagment.Transaction.JTicketTransactions.TransactionPrintInsert(db, mysqlDB, InsertDate);
                                }
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
            TransactionPrintInsert.Abort();
        }

        private void TransactionPrintCheckProcess()
        {
            DateTime InsertDate;
            int TimerCount = 1;
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            ClassLibrary.JMySQLDataBase mysqlDB = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            try
            {
                while (_TransactionPrintCheck)
                {
                    if (txt_CheckPrintTimer.Text.Length > 0)
                    {
                        if (int.TryParse(txt_CheckPrintTimer.Text, out TimerCount))
                        {
                            Thread.Sleep(TimerCount);

                            if (txt_InsertPrintDate.Text.Length > 0)
                            {
                                if (DateTime.TryParse(txt_InsertPrintDate.Text, out InsertDate))
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
                                BusManagment.Transaction.JTicketTransactions.TransactionPrintCheckDataTicketForAllPrinterReport(db, mysqlDB);
                                BusManagment.Transaction.JTicketTransactions.TransactionDailyPrintUpdateFromMySql(db, mysqlDB);
                                BusManagment.Transaction.JTicketTransactions.TransactionDailyPrintCheck(db, mysqlDB);
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
                        (new BusManagment.Transaction.JTransactions()).SocketCheckDataAVL();
                }

            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            }
            db.Dispose();
            AVLThread.Abort();
        }

        private void TicketProcess()
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
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
            finally
            {
                }
            }
            TicketThread.Abort();
                db.Dispose();
            mysqlDB.Dispose();
        }

        private void TicketHandHeldProcess()
        {
            try
            {
                while (_TicketHandHeldThread)
                {
                    Thread.Sleep(5000);
                    (new BusManagment.Transaction.JTransactions()).CheckDataTicketHandHeld();
                }
                TicketHandHeldThread.Abort();
            }
            finally
            {
            }
        }

        public void EventLogProcess()
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                while (_EventLog)
                {
                    if (!Public)
                    {
                        (new BusManagment.EventLog.JEventLog()).EventLogProcess(db);
                    }
                    Thread.Sleep(30000);//600000

                }
                EventLog.Abort();
            }
            finally
            {
                db.Dispose();
            }
        }
        public void SendQueryProcess()
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            ClassLibrary.JMySQLDataBase MySqlDb = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            try
            {
                while (_SendQuery)
                {
                    if (!Public)
                    {
                        (new BusManagment.EventLog.JEventLog()).InsertIntoAUTConsoleQuerySendStatus(db);
                        (new BusManagment.EventLog.JEventLog()).InsertIntoGetQuery(db, MySqlDb);
                        (new BusManagment.EventLog.JEventLog()).UpdateAUTConsoleQuerySendStatus(db, MySqlDb);
                        (new BusManagment.EventLog.JEventLog()).SendMessage(db, MySqlDb);
                    }
                    Thread.Sleep(150000);//600000

                }
                SendQuery.Abort();
            }
            finally
            {
                db.Dispose();
                MySqlDb.Dispose();
            }
        }

        public void SendSMSProcess()
        {
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
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            ClassLibrary.JMySQLDataBase MySqlDb = new ClassLibrary.JMySQLDataBase(ClassLibrary.JConfig.AUTServerName, ClassLibrary.JConfig.AUTUserName, ClassLibrary.JConfig.AUTPassword, ClassLibrary.JConfig.AUTDataBase);
            while (_CalenderRepair)
            {
                Thread.Sleep(180000);
                try
                {
                    if (!Public)
                    {
                        (new BusManagment.Transaction.JTransactions()).CalenderRepairMethod(Db, MySqlDb);
                        (new BusManagment.Transaction.JTransactions()).CalenderRepairMethodGetPrintFromConsole(Db, MySqlDb);
                        // (new BusManagment.Transaction.JTransactions()).SetZeroBusNumberInConsole(Db, MySqlDb);
                        //  (new BusManagment.Transaction.JTransactions()).CalenderRepairFrontAndBackDoorMethod(Db);
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
                //Thread.Sleep(1000*60*15);
                Thread.Sleep(1);
                try
                {
                    if (Public)
                    {
                        (new BusManagment.TransactionPublic.JTransactions()).CheckDataSQLiteTicket();
                        (new BusManagment.TransactionPublic.JTransactions()).CheckDataOfflineTicketPublic();
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
                //if (int.TryParse(txtBackTime.Text, out backtime) == true & int.TryParse(txtPeriod.Text, out Period) == true)
                // {
                //  BusManagment.AVL.JOnlineMap.UpdateBusLocation(Convert.ToInt32(txtBackTime.Text), Convert.ToInt32(txtPeriod.Text));
                // }
                // else
                // {
                BusManagment.AVL.JOnlineMap.UpdateBusLocation(30, 5);
                //}
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
            _AVLThread = chkAVL.Checked;
            if (chkAVL.Checked)
            {
                AVLThread.Start();
            }
        }

        private void chkTicket_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string S = "";
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                S += listBox1.Items[i].ToString() + Environment.NewLine;
            }
            System.IO.File.WriteAllText("c:\\serviceAVL.txt", S);
            listBox1.Items.Clear();

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
            _TicketThread = chkTicket.Checked;
            if (chkTicket.Checked)
            {
                TicketThread.Start();
            }
        }

        private void ChkSocket_CheckedChanged(object sender, EventArgs e)
        {
            BspTcpServer.Port = ushort.Parse(TxtPort.Text);
            BspTcpServer.LiveTime = 5000 * 24;
            BspTcpServer.IsListen = ChkSocket.Checked;

            _SocketAvl = ChkSocket.Checked;
            if (ChkSocket.Checked)
            {
                SocketAvl.Start();
            }
        }

        private void BspTcpServer_OnReceiveData(object sender, System.Net.Sockets.TcpClient client, byte[] bytes, string data)
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
                    DB.setQuery("insert into AUTGroundDeviceTicket(ip,Data,GetDate,IsProceced) values(@ip,@Data,@GetDate,@IsProceced)");
                    DB.Params.Add("ip", ClassLibrary.BSPTCPServer.GetClientInfo(client).IP);
                    DB.Params.Add("Data", NewByte);
                    DB.Params.Add("GetDate", DateTime.Now);
                    DB.Params.Add("IsProceced", 0);
                    DB.Query_Execute();
                    return;
                    //  return;
                }
            }
            else if (bytes[0] == (byte)201)
            {
                if (bytes[1] == (byte)1)
                {
                    //byte[] uni = Encoding.Unicode.GetBytes(BusManagment.Settings.JBusSettings.Get("RTPISText").ToString());
                    //string Ascii = Encoding.ASCII.GetString(uni);
                    //BspTcpServer.SendData(client, uni);

                    ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                    try
                    {
                    byte[] NewByte = new byte[bytes.Length - 2];
                    Array.Copy(bytes, 2, NewByte, 0, NewByte.Length);
                    DB.setQuery("select dbo.fngetrtpistextforboard(" + int.Parse(Encoding.Unicode.GetString(NewByte)) + ")");
                    string res = DB.Query_ExecutSacler().ToString();
                    byte[] uni = Encoding.Unicode.GetBytes(res);
                    BspTcpServer.SendData(client, uni);
                    }
                    finally
                    {
                        DB.Dispose();
                    }
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
                    DB.setQuery("insert into AUTHandHeldDeviceTicket(ip,Data,GetDate,IsProceced) values(@ip,@Data,@GetDate,@IsProceced)");
                    DB.Params.Add("ip", ClassLibrary.BSPTCPServer.GetClientInfo(client).IP);
                    DB.Params.Add("Data", NewByte);
                    DB.Params.Add("GetDate", DateTime.Now);
                    DB.Params.Add("IsProceced", 0);
                    DB.Query_Execute();

                    string RecoedNumber = DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                    (new BusManagment.Transaction.JTransactions()).CheckDataTicketSocket(NewByte, Convert.ToInt64(RecoedNumber));

                    BspTcpServer.SendData(client, "SAVE OK");

                    return;
                }
            }
            else if (bytes[0] == (byte)203)
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
                    DB.setQuery("insert into AUTHandHeldDeviceTicketCityBank(ip,Data,GetDate,IsProceced) values(@ip,@Data,@GetDate,@IsProceced)");
                    DB.Params.Add("ip", ClassLibrary.BSPTCPServer.GetClientInfo(client).IP);
                    DB.Params.Add("Data", NewByte);
                    DB.Params.Add("GetDate", DateTime.Now);
                    DB.Params.Add("IsProceced", 0);
                    DB.Query_Execute();

                    //string RecoedNumber = DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                    //(new BusManagment.Transaction.JTransactions()).CheckDataTicketSocket(NewByte, Convert.ToInt64(RecoedNumber));

                    BspTcpServer.SendData(client, "SAVE OK");

                    return;
                }
            }
            else
            {
                ClassLibrary.Socket.JSocketManager.GetData(client, bytes, "BusManagment.Transaction.JTransactionAVL.GetClassNameBusNumber");
                BspTcpServer.SendData(client, "OK");
            }
            //BspTcpServer.SendData(client, data);
        }

        private readonly object listLock = new object();

        private void BspTcpServer_OnClientConnect(object sender, System.Net.Sockets.TcpClient client)
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
                catch { }
            }
        }

        private void BspTcpServer_OnClientDisconnect(object sender, System.Net.Sockets.TcpClient client)
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
                catch { }
            }
        }

        private void BspTcpServer_OnError(object sender, System.Net.Sockets.TcpClient client, Exception exception)
        {
            ClassLibrary.JSystem.Except.AddException(exception);
        }

        private void chkOffline_CheckedChanged(object sender, EventArgs e)
        {
            _TicketThreadOffilne = chkOffline.Checked;
            if (chkOffline.Checked)
            {
                TicketThreadOffilne.Start();
            }
        }

        private void chkKillSleepCon_CheckedChanged(object sender, EventArgs e)
        {
            _KillSleetConnThread = chkKillSleepCon.Checked;
            if (chkKillSleepCon.Checked)
            {
                KillSleetConnThread.Start();
            }
        }


        private void CLoseThread(Thread pT, bool _Check)
        {
            _Check = false;
            try
            {
                if (pT.ThreadState == ThreadState.Running)
                {
                    pT.Abort();
                    pT.Join();
                }
            }
            catch { }
        }

        private void AVLServiceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _NoClose = false;

            chkAVL.Checked = false;
            //chkBusLocation.Checked = false;
            chkOffline.Checked = false;
            ChkSocket.Checked = false;
            chkTicket.Checked = false;
            chkTransactionPrintInsertDailyMontly.Checked = false;
            chkCalenderRapir.Checked = false;

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
            CLoseThread(SendQuery, _SendQuery);

            Application.ExitThread();
            Application.Exit();


        }

        private void chkDistanceMeasurement_CheckedChanged(object sender, EventArgs e)
        {
            _DistanceMeasurement = chkDistanceMeasurement.Checked;
            if (chkDistanceMeasurement.Checked)
            {
                DistanceMeasurement.Start();
            }
        }

        private void chkTransactionPrintCheck_CheckedChanged(object sender, EventArgs e)
        {
            _TransactionPrintCheck = chkTransactionPrintCheck.Checked;
            if (chkTransactionPrintCheck.Checked)
            {
                TransactionPrintCheck.Start();
            }
        }

        private void chkTransactionPrintInsert_CheckedChanged(object sender, EventArgs e)
        {
            _TransactionPrintInsert = chkTransactionPrintInsert.Checked;
            if (chkTransactionPrintInsert.Checked)
            {
                TransactionPrintInsert.Start();
            }
        }

        private void chkTransactionPrintInsertDailyMontly_CheckedChanged(object sender, EventArgs e)
        {
            _TransactionPrintInsertDailyMontly = chkTransactionPrintInsertDailyMontly.Checked;
            if (chkTransactionPrintInsertDailyMontly.Checked)
            {
                TransactionPrintInsertDailyMontly.Start();
            }
        }

        private void chkCalenderRapir_CheckedChanged(object sender, EventArgs e)
        {
            _CalenderRepair = chkCalenderRapir.Checked;
            if (chkCalenderRapir.Checked)
            {
                CalenderRepair.Start();
            }
        }

        private void chkSendSMS_CheckedChanged(object sender, EventArgs e)
        {
            _SendSMS = chkSendSMS.Checked;
            if (chkSendSMS.Checked)
            {
                SendSMS.Start();
            }
        }

        private void chkEventLog_CheckedChanged(object sender, EventArgs e)
        {
            _EventLog = chkEventLog.Checked;
            if (chkEventLog.Checked)
            {
                EventLog.Start();
            }
        }
        private void chkSendQuery_CheckedChanged(object sender, EventArgs e)
        {
            //_SendQuery = chkSendQuery.Checked;
            //if (chkSendQuery.Checked)
            //{
            //    SendQuery.Start();
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                DateTime FDate = Convert.ToDateTime(("2015-01-21 00:00:00").ToString());
                DateTime EDate = Convert.ToDateTime(("2015-03-20 00:00:00").ToString());
                for (DateTime date = FDate; date <= EDate; date = date.AddDays(1))
                {
                    DB.setQuery("INSERT INTO [dbo].[StaticDates]  ([En_Date],[Fa_Date]) " +
                                   "VALUES " +
                                  "('" + date + "', dbo.DateEnToFa('" + date + "') )");
                    DB.Query_Execute();
                }
                MessageBox.Show("عملیات با موفقیت انجام شد", "توجه");
            }
            catch (Exception ex) { MessageBox.Show("درج با خطا مواجه شد", "هشدار"); }
        }

        private void chkTicketHandHeldTransaction_CheckedChanged(object sender, EventArgs e)
        {
            _TicketHandHeldThread = chkTicketHandHeldTransaction.Checked;
            if (chkTicketHandHeldTransaction.Checked)
            {
                TicketHandHeldThread.Start();
            }

        }

        private void chkServiceProcess_CheckedChanged(object sender, EventArgs e)
        {
            _ServiceProcess = chkServiceProcess.Checked;
            if (chkServiceProcess.Checked)
            {
                ServiceProcess.Start();
            }
        }

        private void TxtPort_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
