using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ERP
{
	public partial class SchoolServiceForm : Form
	{
		Thread SocketAvl;
		bool _SocketAvl = false;
		private readonly object listLock = new object();
		
		public SchoolServiceForm()
		{
			InitializeComponent();
			SocketAvl = new Thread(SocketAvlProcess);
		}

		private void SocketAvlProcess()
		{
			ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
			try
			{
				while (_SocketAvl)
				{
					Thread.Sleep(1);
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
			SocketAvl.Abort();
		}

		private void BspTcpServer_OnClientConnect(object sender, System.Net.Sockets.TcpClient client)
		{
			ClassLibrary.Socket.JSocketManager.Connect(client);
			lock (listLock)
			{
				lbSocketConnect.Text = (int.Parse(lbSocketConnect.Text) + 1).ToString();
			}

		}

		private void BspTcpServer_OnClientDisconnect(object sender, System.Net.Sockets.TcpClient client)
		{
			ClassLibrary.Socket.JSocketManager.DisConnect(client);
			lock (listLock)
			{
				lbSocketConnect.Text = (int.Parse(lbSocketConnect.Text) - 1).ToString();
			}

		}

		private void BspTcpServer_OnError(object sender, System.Net.Sockets.TcpClient client, Exception exception)
		{
			ClassLibrary.JSystem.Except.AddException(exception);
		}

		private void BspTcpServer_OnReceiveData(object sender, System.Net.Sockets.TcpClient client, byte[] bytes, string data)
		{
			//ClassLibrary.Socket.JSocketManager.GetData(client, bytes, "SmartSchools.Socket.JSocket.ProcessData");
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//SMSServise.SMSService s = new SMSServise.SMSService();
			//s.SendSMS(ClassLibrary.JSMSSendType.WebService);
		}
	}
}
