using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace ClassLibrary
{


    public abstract class BaseThread : IDisposable
    {
        private Thread _thread;

        protected BaseThread()
        {
            _thread = new Thread(new ThreadStart(this.RunThread));
            _thread.Priority = ThreadPriority.Normal;
        }

        // Thread methods / properties
        public void Start()
        {
            _thread.Start();
        }
        public void Join()
        {
            try
            {
                _thread.Join();
                _thread.Abort();
                _thread = null;
            }
            catch
            {
            };

        }

        public bool IsAlive { get { return _thread.IsAlive; } }

        // Override in base class
        public abstract void RunThread();

        public virtual void Dispose()
        {

        }

    }

    public delegate void FinishedEvent(object source, BSPTCPServer pBSPTCPServer, System.Net.Sockets.Socket pTcpClient);


    public class SocketThread : BaseThread
    {

        private int _LiveTimeCounter = 0;

        private BSPTCPServer _BSPTCPServer;
        private System.Net.Sockets.Socket _TcpClient;
        private bool Filished;
        private Thread _Timer;

        public event FinishedEvent onFinished;

        public SocketThread(BSPTCPServer pBSPTCPServer, System.Net.Sockets.Socket pTcpClient)
        {
            _BSPTCPServer = pBSPTCPServer;
            _TcpClient = pTcpClient;
            Filished = false;
            _Timer = new Thread(this.TimerCallBack);
            _Timer.Start();
        }

        private void TimerCallBack()
        {
            while (true)
            {
                Thread.Sleep(100);
                if (Filished)
                {
                    Thread.Sleep(100);
                    break;
                }
            }

            Join();
            onFinished(this, _BSPTCPServer, _TcpClient);
        }

        public override void RunThread()
        {
            try
            {
                CheckClientReceiveData(_TcpClient);
                if (_TcpClient != null)
                    _TcpClient.Close();
                Filished = true;
            }
            catch
            {
                Filished = true;
            }
        }

        private void CheckClientReceiveData(object obj)
        {
            System.Net.Sockets.Socket client = (System.Net.Sockets.Socket)obj;
            try
            {
                DateTime D1;
                D1 = DateTime.Now;
                while (client.Connected && _BSPTCPServer.IsListen)
                {
                    try
                    {
                        byte[] readBuffer = new byte[client.ReceiveBufferSize];
                        using (var writer = new MemoryStream())
                        {
                            bool TimeOut = false;
                            client.ReceiveTimeout = 10000 * 60 * 2;
                            client.SendTimeout = 10000 * 60 * 2;
                            int numberOfBytesRead = client.Receive(readBuffer);
                            if (numberOfBytesRead <= 0)
                            {
                                break;
                            }
                            writer.Write(readBuffer, 0, numberOfBytesRead);
                            if ((DateTime.Now - D1).TotalSeconds > 4 * 60)
                                TimeOut = true;
                            if (writer.Length > 0)
                            {
                                D1 = DateTime.Now;
                                _BSPTCPServer.ReceiveData(this, client, writer.ToArray());
                            }
                            else
                                if (TimeOut)
                                {
                                    _BSPTCPServer.Disconnect(client);
                                    return;
                                }
                        }
                    }
                        

                    catch (IOException exception)
                    {
                        _BSPTCPServer.Disconnect(client);
                        return;
                    }
                }

                _BSPTCPServer.Disconnect(client);
                return;
            }
            catch (Exception exception)
            {
            }
        }


        public override void Dispose()
        {
            base.Dispose();
            _BSPTCPServer = null;
            _TcpClient = null;
            _Timer = null;
            GC.Collect();

        }
    }
}
