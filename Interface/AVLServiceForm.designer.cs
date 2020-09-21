namespace ERP
{
    partial class AVLServiceForm
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.chkTicket = new System.Windows.Forms.CheckBox();
            this.chkAVL = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelConnectn = new System.Windows.Forms.ToolStripStatusLabel();
            this.ChkSocket = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkServiceProcess = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.chkEventLog = new System.Windows.Forms.CheckBox();
            this.chkSendQuery = new System.Windows.Forms.CheckBox();
            this.chkSendSMS = new System.Windows.Forms.CheckBox();
            this.chkCalenderRapir = new System.Windows.Forms.CheckBox();
            this.lbSocketConnect = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_CheckPrintTimer = new System.Windows.Forms.TextBox();
            this.txt_InsertPrintDate = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_InsertPrintTimer = new System.Windows.Forms.TextBox();
            this.chkTransactionPrintInsertDailyMontly = new System.Windows.Forms.CheckBox();
            this.chkTicketHandHeldTransaction = new System.Windows.Forms.CheckBox();
            this.chkTransactionPrintInsert = new System.Windows.Forms.CheckBox();
            this.chkTransactionPrintCheck = new System.Windows.Forms.CheckBox();
            this.chkDistanceMeasurement = new System.Windows.Forms.CheckBox();
            this.chkKillSleepCon = new System.Windows.Forms.CheckBox();
            this.chkOffline = new System.Windows.Forms.CheckBox();
            this.TxtPort = new System.Windows.Forms.TextBox();
            this.BspTcpServer = new ClassLibrary.BSPTCPServer();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 220);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(494, 189);
            this.listBox1.TabIndex = 2;
            // 
            // chkTicket
            // 
            this.chkTicket.AutoSize = true;
            this.chkTicket.Location = new System.Drawing.Point(8, 30);
            this.chkTicket.Name = "chkTicket";
            this.chkTicket.Size = new System.Drawing.Size(56, 17);
            this.chkTicket.TabIndex = 4;
            this.chkTicket.Text = "Ticket";
            this.chkTicket.UseVisualStyleBackColor = true;
            this.chkTicket.CheckedChanged += new System.EventHandler(this.chkTicket_CheckedChanged_2);
            // 
            // chkAVL
            // 
            this.chkAVL.AutoSize = true;
            this.chkAVL.Location = new System.Drawing.Point(8, 7);
            this.chkAVL.Name = "chkAVL";
            this.chkAVL.Size = new System.Drawing.Size(46, 17);
            this.chkAVL.TabIndex = 4;
            this.chkAVL.Text = "AVL";
            this.chkAVL.UseVisualStyleBackColor = true;
            this.chkAVL.CheckedChanged += new System.EventHandler(this.chkAVL_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Save Log";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label
            // 
            this.label.Dock = System.Windows.Forms.DockStyle.Top;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(0, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(494, 46);
            this.label.TabIndex = 0;
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelConnectn});
            this.statusStrip1.Location = new System.Drawing.Point(0, 409);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(494, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelConnectn
            // 
            this.toolStripStatusLabelConnectn.Name = "toolStripStatusLabelConnectn";
            this.toolStripStatusLabelConnectn.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabelConnectn.Text = "toolStripStatusLabel1";
            // 
            // ChkSocket
            // 
            this.ChkSocket.AutoSize = true;
            this.ChkSocket.Location = new System.Drawing.Point(8, 151);
            this.ChkSocket.Name = "ChkSocket";
            this.ChkSocket.Size = new System.Drawing.Size(60, 17);
            this.ChkSocket.TabIndex = 8;
            this.ChkSocket.Text = "Socket";
            this.ChkSocket.UseVisualStyleBackColor = true;
            this.ChkSocket.CheckedChanged += new System.EventHandler(this.ChkSocket_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkServiceProcess);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.chkEventLog);
            this.panel1.Controls.Add(this.chkSendQuery);
            this.panel1.Controls.Add(this.chkSendSMS);
            this.panel1.Controls.Add(this.chkCalenderRapir);
            this.panel1.Controls.Add(this.lbSocketConnect);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_CheckPrintTimer);
            this.panel1.Controls.Add(this.txt_InsertPrintDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_InsertPrintTimer);
            this.panel1.Controls.Add(this.chkTransactionPrintInsertDailyMontly);
            this.panel1.Controls.Add(this.chkTicketHandHeldTransaction);
            this.panel1.Controls.Add(this.chkTransactionPrintInsert);
            this.panel1.Controls.Add(this.chkTransactionPrintCheck);
            this.panel1.Controls.Add(this.chkDistanceMeasurement);
            this.panel1.Controls.Add(this.chkKillSleepCon);
            this.panel1.Controls.Add(this.chkOffline);
            this.panel1.Controls.Add(this.TxtPort);
            this.panel1.Controls.Add(this.ChkSocket);
            this.panel1.Controls.Add(this.chkTicket);
            this.panel1.Controls.Add(this.chkAVL);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 174);
            this.panel1.TabIndex = 9;
            // 
            // chkServiceProcess
            // 
            this.chkServiceProcess.AutoSize = true;
            this.chkServiceProcess.Location = new System.Drawing.Point(297, 32);
            this.chkServiceProcess.Name = "chkServiceProcess";
            this.chkServiceProcess.Size = new System.Drawing.Size(103, 17);
            this.chkServiceProcess.TabIndex = 32;
            this.chkServiceProcess.Text = "Service Process";
            this.chkServiceProcess.UseVisualStyleBackColor = true;
            this.chkServiceProcess.CheckedChanged += new System.EventHandler(this.chkServiceProcess_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(327, 141);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 23);
            this.button2.TabIndex = 31;
            this.button2.Text = "Insert Date Static Date";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // chkEventLog
            // 
            this.chkEventLog.AutoSize = true;
            this.chkEventLog.Location = new System.Drawing.Point(8, 98);
            this.chkEventLog.Name = "chkEventLog";
            this.chkEventLog.Size = new System.Drawing.Size(72, 17);
            this.chkEventLog.TabIndex = 30;
            this.chkEventLog.Text = "EventLog";
            this.chkEventLog.UseVisualStyleBackColor = true;
            this.chkEventLog.CheckedChanged += new System.EventHandler(this.chkEventLog_CheckedChanged);
            // 
            // chkSendQuery
            // 
            this.chkSendQuery.AutoSize = true;
            this.chkSendQuery.Location = new System.Drawing.Point(8, 98);
            this.chkSendQuery.Name = "chkSendQuery";
            this.chkSendQuery.Size = new System.Drawing.Size(72, 17);
            this.chkSendQuery.TabIndex = 30;
            this.chkSendQuery.Text = "EventLog";
            this.chkSendQuery.UseVisualStyleBackColor = true;
            this.chkSendQuery.CheckedChanged += new System.EventHandler(this.chkSendQuery_CheckedChanged);
            // 
            // chkSendSMS
            // 
            this.chkSendSMS.AutoSize = true;
            this.chkSendSMS.Location = new System.Drawing.Point(297, 9);
            this.chkSendSMS.Name = "chkSendSMS";
            this.chkSendSMS.Size = new System.Drawing.Size(116, 17);
            this.chkSendSMS.TabIndex = 29;
            this.chkSendSMS.Text = "Send SMS Service";
            this.chkSendSMS.UseVisualStyleBackColor = true;
            this.chkSendSMS.CheckedChanged += new System.EventHandler(this.chkSendSMS_CheckedChanged);
            // 
            // chkCalenderRapir
            // 
            this.chkCalenderRapir.AutoSize = true;
            this.chkCalenderRapir.Location = new System.Drawing.Point(9, 75);
            this.chkCalenderRapir.Name = "chkCalenderRapir";
            this.chkCalenderRapir.Size = new System.Drawing.Size(102, 17);
            this.chkCalenderRapir.TabIndex = 28;
            this.chkCalenderRapir.Text = "Calender Repair";
            this.chkCalenderRapir.UseVisualStyleBackColor = true;
            this.chkCalenderRapir.CheckedChanged += new System.EventHandler(this.chkCalenderRapir_CheckedChanged);
            // 
            // lbSocketConnect
            // 
            this.lbSocketConnect.AutoSize = true;
            this.lbSocketConnect.Location = new System.Drawing.Point(203, 152);
            this.lbSocketConnect.Name = "lbSocketConnect";
            this.lbSocketConnect.Size = new System.Drawing.Size(13, 13);
            this.lbSocketConnect.TabIndex = 27;
            this.lbSocketConnect.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(388, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "MiliSecound";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Timer";
            // 
            // txt_CheckPrintTimer
            // 
            this.txt_CheckPrintTimer.Location = new System.Drawing.Point(327, 85);
            this.txt_CheckPrintTimer.Name = "txt_CheckPrintTimer";
            this.txt_CheckPrintTimer.Size = new System.Drawing.Size(54, 20);
            this.txt_CheckPrintTimer.TabIndex = 24;
            this.txt_CheckPrintTimer.Text = "600";
            // 
            // txt_InsertPrintDate
            // 
            this.txt_InsertPrintDate.Location = new System.Drawing.Point(418, 111);
            this.txt_InsertPrintDate.Mask = "0000/00/00";
            this.txt_InsertPrintDate.Name = "txt_InsertPrintDate";
            this.txt_InsertPrintDate.Size = new System.Drawing.Size(66, 20);
            this.txt_InsertPrintDate.TabIndex = 23;
            this.txt_InsertPrintDate.Text = "20140321";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(388, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(294, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Timer";
            this.label1.Visible = false;
            // 
            // txt_InsertPrintTimer
            // 
            this.txt_InsertPrintTimer.Location = new System.Drawing.Point(327, 111);
            this.txt_InsertPrintTimer.Name = "txt_InsertPrintTimer";
            this.txt_InsertPrintTimer.Size = new System.Drawing.Size(54, 20);
            this.txt_InsertPrintTimer.TabIndex = 19;
            this.txt_InsertPrintTimer.Text = "3600000";
            this.txt_InsertPrintTimer.Visible = false;
            // 
            // chkTransactionPrintInsertDailyMontly
            // 
            this.chkTransactionPrintInsertDailyMontly.AutoSize = true;
            this.chkTransactionPrintInsertDailyMontly.Location = new System.Drawing.Point(8, 124);
            this.chkTransactionPrintInsertDailyMontly.Name = "chkTransactionPrintInsertDailyMontly";
            this.chkTransactionPrintInsertDailyMontly.Size = new System.Drawing.Size(219, 17);
            this.chkTransactionPrintInsertDailyMontly.TabIndex = 18;
            this.chkTransactionPrintInsertDailyMontly.Text = "Transaction Print Insert ( Daily - Monthly )";
            this.chkTransactionPrintInsertDailyMontly.UseVisualStyleBackColor = true;
            this.chkTransactionPrintInsertDailyMontly.CheckedChanged += new System.EventHandler(this.chkTransactionPrintInsertDailyMontly_CheckedChanged);
            // 
            // chkTicketHandHeldTransaction
            // 
            this.chkTicketHandHeldTransaction.AutoSize = true;
            this.chkTicketHandHeldTransaction.Location = new System.Drawing.Point(132, 98);
            this.chkTicketHandHeldTransaction.Name = "chkTicketHandHeldTransaction";
            this.chkTicketHandHeldTransaction.Size = new System.Drawing.Size(107, 17);
            this.chkTicketHandHeldTransaction.TabIndex = 17;
            this.chkTicketHandHeldTransaction.Text = "Ticket HandHeld";
            this.chkTicketHandHeldTransaction.UseVisualStyleBackColor = true;
            this.chkTicketHandHeldTransaction.CheckedChanged += new System.EventHandler(this.chkTicketHandHeldTransaction_CheckedChanged);
            // 
            // chkTransactionPrintInsert
            // 
            this.chkTransactionPrintInsert.AutoSize = true;
            this.chkTransactionPrintInsert.Location = new System.Drawing.Point(132, 76);
            this.chkTransactionPrintInsert.Name = "chkTransactionPrintInsert";
            this.chkTransactionPrintInsert.Size = new System.Drawing.Size(135, 17);
            this.chkTransactionPrintInsert.TabIndex = 17;
            this.chkTransactionPrintInsert.Text = "Transaction Print Insert";
            this.chkTransactionPrintInsert.UseVisualStyleBackColor = true;
            this.chkTransactionPrintInsert.Visible = false;
            this.chkTransactionPrintInsert.CheckedChanged += new System.EventHandler(this.chkTransactionPrintInsert_CheckedChanged);
            // 
            // chkTransactionPrintCheck
            // 
            this.chkTransactionPrintCheck.AutoSize = true;
            this.chkTransactionPrintCheck.Location = new System.Drawing.Point(132, 53);
            this.chkTransactionPrintCheck.Name = "chkTransactionPrintCheck";
            this.chkTransactionPrintCheck.Size = new System.Drawing.Size(140, 17);
            this.chkTransactionPrintCheck.TabIndex = 16;
            this.chkTransactionPrintCheck.Text = "Transaction Print Check";
            this.chkTransactionPrintCheck.UseVisualStyleBackColor = true;
            this.chkTransactionPrintCheck.CheckedChanged += new System.EventHandler(this.chkTransactionPrintCheck_CheckedChanged);
            // 
            // chkDistanceMeasurement
            // 
            this.chkDistanceMeasurement.AutoSize = true;
            this.chkDistanceMeasurement.Location = new System.Drawing.Point(132, 32);
            this.chkDistanceMeasurement.Name = "chkDistanceMeasurement";
            this.chkDistanceMeasurement.Size = new System.Drawing.Size(135, 17);
            this.chkDistanceMeasurement.TabIndex = 11;
            this.chkDistanceMeasurement.Text = "Distance Measurement";
            this.chkDistanceMeasurement.UseVisualStyleBackColor = true;
            this.chkDistanceMeasurement.CheckedChanged += new System.EventHandler(this.chkDistanceMeasurement_CheckedChanged);
            // 
            // chkKillSleepCon
            // 
            this.chkKillSleepCon.AutoSize = true;
            this.chkKillSleepCon.Location = new System.Drawing.Point(132, 9);
            this.chkKillSleepCon.Name = "chkKillSleepCon";
            this.chkKillSleepCon.Size = new System.Drawing.Size(120, 17);
            this.chkKillSleepCon.TabIndex = 10;
            this.chkKillSleepCon.Text = "KillSleepConnection";
            this.chkKillSleepCon.UseVisualStyleBackColor = true;
            this.chkKillSleepCon.CheckedChanged += new System.EventHandler(this.chkKillSleepCon_CheckedChanged);
            // 
            // chkOffline
            // 
            this.chkOffline.AutoSize = true;
            this.chkOffline.Location = new System.Drawing.Point(8, 53);
            this.chkOffline.Name = "chkOffline";
            this.chkOffline.Size = new System.Drawing.Size(98, 17);
            this.chkOffline.TabIndex = 10;
            this.chkOffline.Text = "OffLine+SQLite";
            this.chkOffline.UseVisualStyleBackColor = true;
            this.chkOffline.CheckedChanged += new System.EventHandler(this.chkOffline_CheckedChanged);
            // 
            // TxtPort
            // 
            this.TxtPort.Location = new System.Drawing.Point(68, 149);
            this.TxtPort.Name = "TxtPort";
            this.TxtPort.Size = new System.Drawing.Size(100, 20);
            this.TxtPort.TabIndex = 9;
            this.TxtPort.Text = "8572";
            this.TxtPort.TextChanged += new System.EventHandler(this.TxtPort_TextChanged);
            // 
            // BspTcpServer
            // 
            this.BspTcpServer.IsListen = false;
            this.BspTcpServer.LiveTime = 0;
            this.BspTcpServer.Port = ((ushort)(0));
            this.BspTcpServer.OnReceiveData += new ClassLibrary.BSPTCPServer.OnReceiveDataHandler(this.BspTcpServer_OnReceiveData);
            this.BspTcpServer.OnClientConnect += new ClassLibrary.BSPTCPServer.OnClientConnectHandler(this.BspTcpServer_OnClientConnect);
            this.BspTcpServer.OnClientDisconnect += new ClassLibrary.BSPTCPServer.OnClientDisconnectHandler(this.BspTcpServer_OnClientDisconnect);
            this.BspTcpServer.OnError += new ClassLibrary.BSPTCPServer.OnErrorHandler(this.BspTcpServer_OnError);
            // 
            // AVLServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 431);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label);
            this.Name = "AVLServiceForm";
            this.Text = "ServiceForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AVLServiceForm_FormClosed);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.CheckBox chkTicket;
        private System.Windows.Forms.CheckBox chkAVL;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private ClassLibrary.BSPTCPServer BspTcpServer;
        private System.Windows.Forms.CheckBox ChkSocket;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtPort;
        private System.Windows.Forms.CheckBox chkOffline;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelConnectn;
        private System.Windows.Forms.CheckBox chkKillSleepCon;
        private System.Windows.Forms.CheckBox chkDistanceMeasurement;
        private System.Windows.Forms.CheckBox chkTransactionPrintCheck;
        private System.Windows.Forms.CheckBox chkTransactionPrintInsert;
        private System.Windows.Forms.CheckBox chkTransactionPrintInsertDailyMontly;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_InsertPrintTimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txt_InsertPrintDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_CheckPrintTimer;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lbSocketConnect;
        private System.Windows.Forms.CheckBox chkCalenderRapir;
        private System.Windows.Forms.CheckBox chkSendSMS;
        private System.Windows.Forms.CheckBox chkEventLog;
        private System.Windows.Forms.CheckBox chkSendQuery;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox chkTicketHandHeldTransaction;
        private System.Windows.Forms.CheckBox chkServiceProcess;
    }
}