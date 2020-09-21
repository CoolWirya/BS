using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace ERP
{
    public partial class SocketTestLangari : Form
    {
        BSPTCPServer BspTcpServer;
        public SocketTestLangari()
        {
            InitializeComponent();

            BspTcpServer = new BSPTCPServer();
        }

        

        private void BspTcpServer_OnReceiveData(object sender, System.Net.Sockets.Socket client, byte[] bytes, string data)
        {
            if (bytes[0] == (byte)200)
            {
                if (bytes[1] == (byte)3)
                {
                    string str = "\r\n Recieved data from your device is : " + data + " - " + DateTime.Now.ToString();
                    textBox1.Text += str + "\r\n";
                    //byte[] res = System.Text.Encoding.UTF8.GetBytes(str);
                    //client.Client.Send(res);
                    BspTcpServer.SendData(client, "OK");
                    return;
                }
                Array.Resize(ref bytes, bytes.Length - 2);
            }
            //ClassLibrary.Socket.JSocketManager.GetData(client, bytes);
            //BspTcpServer.SendData(client, "OK");
        }

        private void BspTcpServer_OnClientConnect(object sender, System.Net.Sockets.Socket client)
        {
            ClassLibrary.Socket.JSocketManager.Connect(client);
            string str = "\r\n Client Connect " + DateTime.Now.ToString();
            textBox1.Text += str + "\r\n";
        }

        private void BspTcpServer_OnClientDisconnect(object sender, System.Net.Sockets.Socket client)
        {
            ClassLibrary.Socket.JSocketManager.DisConnect(client);
            string str = "\r\n Client Disconnect " + DateTime.Now.ToString();
            textBox1.Text += str + "\r\n";
        }

        private void BspTcpServer_OnError(object sender, System.Net.Sockets.TcpClient client, Exception exception)
        {
            string str = "\r\n ERROR " + DateTime.Now.ToString();
            textBox1.Text += str + "\r\n";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                BspTcpServer.Port = ushort.Parse("9258");
                BspTcpServer.IsListen = true;
                textBox1.Text += "\r\n Port 9258 Is Open \r\n";
            }
            else
            {
                textBox1.Text += "\r\n Port 9258 Is Close \r\n";
            }
        }
    }
}
