namespace ERP
{
	partial class SchoolServiceForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.BspTcpServer = new ClassLibrary.BSPTCPServer();
			this.lbSocketConnect = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.TxtPort = new System.Windows.Forms.TextBox();
			this.ChkSocket = new System.Windows.Forms.CheckBox();
			this.toolStripStatusLabelConnectn = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.label = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.panel1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// BspTcpServer
			// 
			this.BspTcpServer.IsListen = false;
			//this.BspTcpServer.LiveTime = 0;
			this.BspTcpServer.Port = ((ushort)(0));
			this.BspTcpServer.OnReceiveData += new ClassLibrary.BSPTCPServer.OnReceiveDataHandler(this.BspTcpServer_OnReceiveData);
			this.BspTcpServer.OnClientConnect += new ClassLibrary.BSPTCPServer.OnClientConnectHandler(this.BspTcpServer_OnClientConnect);
			this.BspTcpServer.OnClientDisconnect += new ClassLibrary.BSPTCPServer.OnClientDisconnectHandler(this.BspTcpServer_OnClientDisconnect);
			this.BspTcpServer.OnError += new ClassLibrary.BSPTCPServer.OnErrorHandler(this.BspTcpServer_OnError);
			// 
			// lbSocketConnect
			// 
			this.lbSocketConnect.AutoSize = true;
			this.lbSocketConnect.Location = new System.Drawing.Point(207, 18);
			this.lbSocketConnect.Name = "lbSocketConnect";
			this.lbSocketConnect.Size = new System.Drawing.Size(13, 13);
			this.lbSocketConnect.TabIndex = 27;
			this.lbSocketConnect.Text = "0";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lbSocketConnect);
			this.panel1.Controls.Add(this.TxtPort);
			this.panel1.Controls.Add(this.ChkSocket);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 46);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(523, 150);
			this.panel1.TabIndex = 14;
			// 
			// TxtPort
			// 
			this.TxtPort.Location = new System.Drawing.Point(72, 15);
			this.TxtPort.Name = "TxtPort";
			this.TxtPort.Size = new System.Drawing.Size(100, 20);
			this.TxtPort.TabIndex = 9;
			this.TxtPort.Text = "1000";
			// 
			// ChkSocket
			// 
			this.ChkSocket.AutoSize = true;
			this.ChkSocket.Location = new System.Drawing.Point(12, 17);
			this.ChkSocket.Name = "ChkSocket";
			this.ChkSocket.Size = new System.Drawing.Size(60, 17);
			this.ChkSocket.TabIndex = 8;
			this.ChkSocket.Text = "Socket";
			this.ChkSocket.UseVisualStyleBackColor = true;
			// 
			// toolStripStatusLabelConnectn
			// 
			this.toolStripStatusLabelConnectn.Name = "toolStripStatusLabelConnectn";
			this.toolStripStatusLabelConnectn.Size = new System.Drawing.Size(118, 17);
			this.toolStripStatusLabelConnectn.Text = "toolStripStatusLabel1";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelConnectn});
			this.statusStrip1.Location = new System.Drawing.Point(0, 475);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(523, 22);
			this.statusStrip1.TabIndex = 13;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// label
			// 
			this.label.Dock = System.Windows.Forms.DockStyle.Top;
			this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label.Location = new System.Drawing.Point(0, 0);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(523, 46);
			this.label.TabIndex = 10;
			this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(9, 11);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 12;
			this.button1.Text = "Save Log";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// listBox1
			// 
			this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(0, 0);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(523, 497);
			this.listBox1.TabIndex = 11;
			// 
			// SchoolServiceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(523, 497);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.label);
			this.Controls.Add(this.listBox1);
			this.Name = "SchoolServiceForm";
			this.Text = "SchoolServiceForm";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ClassLibrary.BSPTCPServer BspTcpServer;
		private System.Windows.Forms.Label lbSocketConnect;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox TxtPort;
		private System.Windows.Forms.CheckBox ChkSocket;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelConnectn;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.Label label;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox listBox1;
	}
}