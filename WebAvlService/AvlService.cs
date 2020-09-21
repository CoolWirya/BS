using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using ClassLibrary;
using System.Threading;

namespace WebAvlService
{
    public partial class AvlService : ServiceBase
    {
        BSPTCPServer BspTcpServer;
        int SocketConnect = 0;//Iterator of connected sockets
        private readonly object listLock = new object();
        Thread MobileSocketListener;
        Thread DataExtractor;
        Thread SMSSender;
        Thread EMailSender;
        Thread GeofenceChecker;
        Thread SpeedControl;
        Thread UpdateObjectList;
        bool _MobileSocketListener = true;
        bool _DataExtractor = true;
        bool _SMSSender = true;
        bool _EMailSender = true;
        bool _GeofenceChecker = true;
        bool _SpeedControl = true;
        bool _UpdateObjectList = true;
        List<Thread> threads = new List<Thread>();

        public AvlService()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {

            RunServices();

            threads.Clear();
            threads.Add(MobileSocketListener);
            threads.Add(DataExtractor);
            threads.Add(SMSSender);
            threads.Add(EMailSender);
            threads.Add(GeofenceChecker);
            threads.Add(SpeedControl);
            threads.Add(UpdateObjectList);

        }
        protected override void OnStop()
        {
            foreach (Thread t in threads)
                StopThread(t);
        }
        private void StopThread(Thread t)
        {
            try
            {
                t.Abort();
            }
            catch
            {

            }
        }
        private void GeofenceCheck()
        {
            // 
            DataTable dt;
            AVL.Coordinate.JCoordinate coordinate;
            AVL.Area.JArea area;
            AVL.Geofence.GeoData.JGeofenceData geoData;
            AVL.ObjectList.JObjectList ol;
            while (true)
            {
                try
                {
                    dt = AVL.ObjectList.JObjectLists.GetDataTable(false);
                    foreach (DataRow dr in dt.Rows)
                    {
                        coordinate = new AVL.Coordinate.JCoordinate();
                        try
                        {
                            coordinate.Altitude = float.Parse(dr["lastAltitude"].ToString());
                            coordinate.Angle = int.Parse(dr["lastAngle"].ToString());
                            coordinate.DeviceSendDateTime = DateTime.Parse(dr["lastSendDate"].ToString());
                            coordinate.lat = float.Parse(dr["lastLat"].ToString());
                            coordinate.lng = float.Parse(dr["lastLng"].ToString());
                            coordinate.Speed = float.Parse(dr["lastSpeed"].ToString());
                        }
                        catch
                        {
                            continue;
                        }

                        area = AVL.Geofence.GeoData.JGeofenceData.CheckGeofence(coordinate);
                        if (area.code > 0)
                        {
                            geoData = new AVL.Geofence.GeoData.JGeofenceData();
                            geoData.entered = true;
                            geoData.GeoCode = area.code;
                            geoData.IsGeofence = area.IsGeofence;
                            geoData.LastDate = DateTime.Now;
                            geoData.Insert(true, false);
                            ol = new AVL.ObjectList.JObjectList(int.Parse(dr["Code"].ToString()));
                            //ol.geofenceFault = true;
                            ol.Update();
                        }

                    }
                }
                catch (Exception er)
                {
                    System.IO.File.AppendAllText(@"C:\123\GeofenceLog.txt", er.Message + " [" + DateTime.Now + "](StackTrace" + er.StackTrace + ")" + Environment.NewLine + Environment.NewLine);
                }
                finally
                {
                }
                Thread.Sleep(5000);
            }
        }
        private void SpeedController()
        {
            ClassLibrary.JDataBase DB;
            float speed = 0;
            string query = "";
            AVL.ObjectList.JObjectList ol;
            AVL.RegisterDevice.JRegisterDevice device;
            AVL.SpeedFault.JSpeedFaultData speedfault;
            while (true)
            {
                DB = new ClassLibrary.JDataBase();
                try
                {
                    query = @"SELECT * FROM [AVLObjectList]";
                    DB.setQuery(query);
                    DB.Query_DataReader();
                    if (DB.DataReader != null)
                        while (DB.DataReader.Read())
                        {
                            ol = new AVL.ObjectList.JObjectList(DB.DataReader);
                            if (ol.Type != "شخص")
                            {
                                device = new AVL.RegisterDevice.JRegisterDevice(ol.Code, true);
                                //if (ol.lastSpeed > (speed = device.speed))
                                //{
                                //    speedfault = new AVL.SpeedFault.JSpeedFaultData() { Datetime = ol.lastSendDate, LimitedSpeed = speed, speed = ol.lastSpeed };
                                //    speedfault.Insert(false);
                                //}
                            }
                        }
                }
                catch (Exception er)
                {
                    System.IO.File.AppendAllText(@"C:\123\SpeedCheckLog.txt", er.Message + " [" + DateTime.Now + "](Line" + er.StackTrace + ")" + Environment.NewLine);
                }
                finally
                {
                    DB.Dispose();
                }
                Thread.Sleep(4000);
            }
        }
        private void UpdateObjectListRows()
        {
            System.Data.DataRowCollection drs;
            System.Data.DataTable dt = null;
            while (true)
            {

                try
                {

                    dt = AVL.Coordinate.JCoordinates.GetDataTable(false);
                    if (dt != null)
                    {
                        drs = dt.Rows;
                        if (drs != null && drs.Count > 0)
                            foreach (System.Data.DataRow dr in drs)
                            {
                                ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                                try
                                {
                                    //DB.setQuery(string.Format(@" UPDATE [AVLObjectList] SET lastLat={0},lastLng={1},lastSendDate='{2}',lastSpeed={3},lastAngle={4}, lastAltitude={5}  WHERE Code={6}",
                                    //    dr["lat"].ToString(),
                                    //    dr["lng"].ToString(),
                                    //    dr["DeviceSendDateTime"].ToString(),
                                    //    dr["Speed"].ToString(),
                                    //    dr["Angle"].ToString(),
                                    //    dr["Altitude"].ToString(),
                                    //    dr["ObjectCode"].ToString()));
                                    //DB.Query_Execute(true);
                                }
                                catch (Exception er)
                                {
                                    System.IO.File.AppendAllText(@"C:\123\ObjectListUpdateLog.txt", er.Message + " [" + DateTime.Now + "](Line" + er.StackTrace + ")" + Environment.NewLine);
                                }
                                finally
                                {
                                    DB.Dispose();
                                }
                            }
                    }
                }
                catch (Exception er)
                {
                    System.IO.File.AppendAllText(@"C:\123\ObjectListUpdateLog.txt", er.Message + " [" + DateTime.Now + "](Line" + er.StackTrace + ")" + Environment.NewLine);
                }
                Thread.Sleep(1000);
            }
        }
        public void RunServices()
        {
            BspTcpServer = new BSPTCPServer();
            BspTcpServer.OnClientConnect += new BSPTCPServer.OnClientConnectHandler(this.BspTcpServer_OnClientConnect);
            BspTcpServer.OnClientDisconnect += new BSPTCPServer.OnClientDisconnectHandler(this.BspTcpServer_OnClientDisconnect);
            BspTcpServer.OnError += new BSPTCPServer.OnErrorHandler(this.BspTcpServer_OnError);
            BspTcpServer.OnReceiveData += new BSPTCPServer.OnReceiveDataHandler(this.BspTcpServer_OnReceiveData);

            //MobileSocketListener = new Thread(StartSocketListner);
            DataExtractor = new Thread(Extractors);
            SMSSender = new Thread(SendSMSProcess);
            EMailSender = new Thread(EmailSend);
            GeofenceChecker = new Thread(GeofenceCheck);
            SpeedControl = new Thread(SpeedController);
            UpdateObjectList = new Thread(UpdateObjectListRows);

            string[] lines = System.IO.File.ReadAllLines(@"C:\123\services.txt");
            if (lines[0] == "t")
                StartSocketListner();
            // MobileSocketListener.Start();
            if (lines[1] == "t")
                DataExtractor.Start();
            if (lines[2] == "t")
                SMSSender.Start();
            if (lines[3] == "t")
                EMailSender.Start();
            if (lines[4] == "t")
                GeofenceChecker.Start();
            if (lines[5] == "t")
                SpeedControl.Start();
            if (lines[6] == "t")
                UpdateObjectList.Start();
        }
        private void ExtractorRunner(object obj)
        {
            AVL.GPSData.JDataKeeper keeper = (AVL.GPSData.JDataKeeper)obj;

            //WebClassLibrary.JActionsInfo action = new WebClassLibrary.JActionsInfo();
            // action.Method = keeper.ExtractorMethod;

            string className = "";
            string methodname = "";
            while (true)
            {
                try
                {
                    className = "";
                    methodname = "";
                    //  action.runAction();
                    string[] entries = keeper.ExtractorMethod.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < entries.Length - 1; i++)
                    {
                        className += entries[i] + ".";
                    }
                    className = className.Remove(className.Length - 1);//entries[entries.Length - 2];// 
                    methodname = entries[entries.Length - 1];
                    AVL.Tools.InvokeMethod("AVL",
                      className,
                       methodname,
                        null, false);
                    Thread.Sleep(1000);
                }
                catch (Exception er)
                {
                    System.IO.File.AppendAllText(@"C:\123\ExtractorLog.txt", er.Message + " [" + DateTime.Now + "][" + methodname + "](Line" + er.StackTrace + ")" + Environment.NewLine);
                }
            }

        }
        private void Extractors()
        {
            //ابتدا اطلاعات تمام جدول های مختلف که در آن بایت ذخیره می شود
            // را از جدول
            //AVLDataKeeper
            //می گیرد.
			List<string> threadNames = new List<string>();
			ClassLibrary.JDataBase DB;
			DB = new ClassLibrary.JDataBase();
            AVL.GPSData.JDataKeeper keeper;
			try
            {
				while (true)
                {
                    try
                    {
                        string query = @"SELECT * FROM [AVLDataKeeper]";
                        DB.setQuery(query);
                        DataTable DT = DB.Query_DataTable();

                        foreach (DataRow dr in DT.Rows)
                        {
							if (!threadNames.Contains(dr["TableName"].ToString()))
                            {
                                System.Threading.Thread t = new Thread(new ParameterizedThreadStart(ExtractorRunner));
								t.Name = dr["TableName"].ToString();

                                if (!threads.Contains(t))
                                {
                                    keeper=new AVL.GPSData.JDataKeeper();
                                    keeper.Code=int.Parse(dr["Code"].ToString());
                                    keeper.Description=dr["Description"].ToString();
                                    keeper.DeviceModelCode=int.Parse(dr["DeviceModelCode"].ToString());
                                    keeper.ExtractorMethod=dr["ExtractorMethod"].ToString();
                                    keeper.TableName=dr["TableName"].ToString();
									t.Start(keeper);
									threadNames.Add(dr["TableName"].ToString());
                                    threads.Add(t);
                                }
                                else
                                    t = null;
                            }
                        }

                        Thread.Sleep(3600000);
                    }
                    catch (Exception er)
                    {
                        System.IO.File.AppendAllText(@"C:\123\DataKeeperLog.txt", er.Message + " [" + DateTime.Now + "](stacktrace:" + er.StackTrace + ")" + Environment.NewLine);
                    }
                    finally
                    {
                    }
                }
            }
            catch (System.Threading.ThreadAbortException er)
            {

            }
            finally
            {
				DB.Dispose();
			}
        }
        public void EmailSend()
        {
            ClassLibrary.EMail.JEMailManagers email;
            while (true)
            {
                try
                {
                    email = new ClassLibrary.EMail.JEMailManagers();
                    email.SendEMails();
                    Thread.Sleep(20000);
                }
                catch (Exception er)
                {
                    System.IO.File.AppendAllText(@"C:\123\EmailLog.txt", er.Message + " [" + DateTime.Now + "](Line" + er.StackTrace + ")" + Environment.NewLine);
                }
            }
        }
        public void SendSMSProcess()
        {
            ClassLibrary.JDataBase Db;
            ClassLibrary.SMS.ClsMainSmsClass sms;
            while (_SMSSender)
            {
                Db = new ClassLibrary.JDataBase();
                try
                {
                    sms = new ClassLibrary.SMS.ClsMainSmsClass();
                    sms.SendSMSService(Db);
                    Db.Dispose();
                    Thread.Sleep(2000);
                }
                catch (Exception er)
                {
                    Db.Dispose();
                    ClassLibrary.JSystem.Except.AddException(er);
                    System.IO.File.AppendAllText(@"C:\123\SMSLog.txt", er.Message + " [" + DateTime.Now + "](Line" + er.StackTrace + ")" + Environment.NewLine);
                }
                finally
                {
                    Db.Dispose();
                }
            }
            try
            {
                SMSSender.Abort();
            }
            catch (ThreadAbortException er)
            {

            }
        }
        private void StartSocketListner()
        {
            BspTcpServer.Port = ushort.Parse("8572");
            BspTcpServer.IsListen = true;
        }
        private void BspTcpServer_OnReceiveData(object sender, System.Net.Sockets.Socket client, byte[] bytes)
        {
            // Tahlilgaran android application
            if (bytes[0] == (byte)150)
            {
                if (bytes[1] == (byte)1)
                {
                    BspTcpServer.SendData(client, "OK - " + ClassLibrary.BSPTCPServer.GetClientInfo(client).IP);
                    byte[] NewByte = new byte[42];
                    int counter = 0;
                    for (int i = 2; i < 44; i++)
                    {
                        NewByte[counter] = bytes[i];
                        counter++;
                    }
                    ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                    try
                    {
                        DB.setQuery(@"declare @a int
                                        Select @a = Code from [AVLDevice] where [IMEI] = @imei
                                        IF @a > 0
	                                        insert into AVLTSIPAndroidSocket (ip,Data,GetDate,IsProceced) values(@ip,@Data,@GetDate,@IsProceced)");
                        DB.Params.Add("ip", ClassLibrary.BSPTCPServer.GetClientInfo(client).IP);
                        DB.Params.Add("Data", NewByte);
                        DB.Params.Add("GetDate", DateTime.Now);
                        DB.Params.Add("IsProceced", 0);
                        byte[] tempData = new byte[8];
                        Buffer.BlockCopy(NewByte, 0, tempData, 0, 8);
                        DB.Params.Add("imei", System.Text.Encoding.ASCII.GetString(tempData));
                        DB.Query_Execute();
                    }

                    catch (Exception er)
                    {
                        System.IO.File.AppendAllText(@"C:\123\SocketLog.txt", er.Message + " [" + DateTime.Now + "](Line" + er.StackTrace + ")" + Environment.NewLine);
                    }
                    finally
                    {
                        DB.Dispose();
                    }
                    return;
                    //  return;
                }
            }
        }
        private void BspTcpServer_OnClientConnect(object sender, System.Net.Sockets.Socket client)
        {
            ClassLibrary.Socket.JSocketManager.Connect(client);
            lock (listLock)
            {
                try
                {
                    //lbSocketConnect.Text =  (int.Parse(lbSocketConnect.Text) + 1).ToString();
                    SocketConnect++;
                    //SetText(SocketConnect.ToString(), 3);
                }
                catch { }
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
                    //SetText(SocketConnect.ToString(), 3);
                }
                catch { }
            }
        }
        private void BspTcpServer_OnError(object sender, System.Net.Sockets.Socket client, Exception exception)
        {
            ClassLibrary.JSystem.Except.AddException(exception);
            System.IO.File.AppendAllText(@"C:\123\SocketLog.txt", exception.Message + " [" + DateTime.Now + "](Line" + exception.StackTrace + ")" + Environment.NewLine);

        }

    }
}
