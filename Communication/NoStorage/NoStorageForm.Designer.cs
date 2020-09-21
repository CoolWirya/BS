namespace Communication
{
	partial class NoStorageForm
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbLastNumber = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbReservList = new System.Windows.Forms.ListBox();
            this.txtNumber = new ClassLibrary.TextEdit(this.components);
            this.btnGetNumber = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtReservNumber = new ClassLibrary.TextEdit(this.components);
            this.btnDeleteReservNumber = new System.Windows.Forms.Button();
            this.btnReservNumber = new System.Windows.Forms.Button();
            this.lbReserverTo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbReservEditList = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbFormName = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(349, 339);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbFormName);
            this.tabPage2.Controls.Add(this.lbLastNumber);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.lbReservList);
            this.tabPage2.Controls.Add(this.txtNumber);
            this.tabPage2.Controls.Add(this.btnGetNumber);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(341, 310);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "دریافت شماره";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbLastNumber
            // 
            this.lbLastNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbLastNumber.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbLastNumber.ForeColor = System.Drawing.Color.Red;
            this.lbLastNumber.Location = new System.Drawing.Point(192, 143);
            this.lbLastNumber.Name = "lbLastNumber";
            this.lbLastNumber.Size = new System.Drawing.Size(141, 17);
            this.lbLastNumber.TabIndex = 7;
            this.lbLastNumber.Text = "آخرین شماره ()";
            this.lbLastNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "شماره های رزرو شده:";
            // 
            // lbReservList
            // 
            this.lbReservList.FormattingEnabled = true;
            this.lbReservList.ItemHeight = 16;
            this.lbReservList.Location = new System.Drawing.Point(7, 57);
            this.lbReservList.Name = "lbReservList";
            this.lbReservList.Size = new System.Drawing.Size(179, 228);
            this.lbReservList.TabIndex = 6;
            this.lbReservList.SelectedIndexChanged += new System.EventHandler(this.lbReservList_SelectedIndexChanged);
            // 
            // txtNumber
            // 
            this.txtNumber.ChangeColorIfNotEmpty = false;
            this.txtNumber.ChangeColorOnEnter = true;
            this.txtNumber.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNumber.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNumber.Location = new System.Drawing.Point(192, 56);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Negative = true;
            this.txtNumber.NotEmpty = false;
            this.txtNumber.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNumber.ReadOnly = true;
            this.txtNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNumber.SelectOnEnter = true;
            this.txtNumber.Size = new System.Drawing.Size(142, 23);
            this.txtNumber.TabIndex = 5;
            this.txtNumber.TextMode = ClassLibrary.TextModes.Integer;
            this.txtNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumber_KeyDown);
            this.txtNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // btnGetNumber
            // 
            this.btnGetNumber.Location = new System.Drawing.Point(192, 85);
            this.btnGetNumber.Name = "btnGetNumber";
            this.btnGetNumber.Size = new System.Drawing.Size(142, 32);
            this.btnGetNumber.TabIndex = 4;
            this.btnGetNumber.Text = "دریافت شماره";
            this.btnGetNumber.UseVisualStyleBackColor = true;
            this.btnGetNumber.Click += new System.EventHandler(this.btnGetNumber_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtReservNumber);
            this.tabPage1.Controls.Add(this.btnDeleteReservNumber);
            this.tabPage1.Controls.Add(this.btnReservNumber);
            this.tabPage1.Controls.Add(this.lbReserverTo);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lbReservEditList);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(341, 310);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "رزرو شماره";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtReservNumber
            // 
            this.txtReservNumber.ChangeColorIfNotEmpty = false;
            this.txtReservNumber.ChangeColorOnEnter = true;
            this.txtReservNumber.InBackColor = System.Drawing.SystemColors.Info;
            this.txtReservNumber.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtReservNumber.Location = new System.Drawing.Point(8, 80);
            this.txtReservNumber.Name = "txtReservNumber";
            this.txtReservNumber.Negative = true;
            this.txtReservNumber.NotEmpty = false;
            this.txtReservNumber.NotEmptyColor = System.Drawing.Color.Red;
            this.txtReservNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtReservNumber.SelectOnEnter = true;
            this.txtReservNumber.Size = new System.Drawing.Size(142, 23);
            this.txtReservNumber.TabIndex = 7;
            this.txtReservNumber.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // btnDeleteReservNumber
            // 
            this.btnDeleteReservNumber.Location = new System.Drawing.Point(98, 264);
            this.btnDeleteReservNumber.Name = "btnDeleteReservNumber";
            this.btnDeleteReservNumber.Size = new System.Drawing.Size(50, 32);
            this.btnDeleteReservNumber.TabIndex = 6;
            this.btnDeleteReservNumber.Text = "-";
            this.btnDeleteReservNumber.UseVisualStyleBackColor = true;
            this.btnDeleteReservNumber.Visible = false;
            this.btnDeleteReservNumber.Click += new System.EventHandler(this.btnDeleteReservNumber_Click);
            // 
            // btnReservNumber
            // 
            this.btnReservNumber.Location = new System.Drawing.Point(8, 109);
            this.btnReservNumber.Name = "btnReservNumber";
            this.btnReservNumber.Size = new System.Drawing.Size(142, 32);
            this.btnReservNumber.TabIndex = 6;
            this.btnReservNumber.Text = "<--- رزور شماره";
            this.btnReservNumber.UseVisualStyleBackColor = true;
            this.btnReservNumber.Click += new System.EventHandler(this.btnReservNumber_Click);
            // 
            // lbReserverTo
            // 
            this.lbReserverTo.Location = new System.Drawing.Point(14, 17);
            this.lbReserverTo.Name = "lbReserverTo";
            this.lbReserverTo.Size = new System.Drawing.Size(134, 60);
            this.lbReserverTo.TabIndex = 5;
            this.lbReserverTo.Text = "از شماره رزرو تا شماره:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "شماره های رزرو شده:";
            // 
            // lbReservEditList
            // 
            this.lbReservEditList.FormattingEnabled = true;
            this.lbReservEditList.ItemHeight = 16;
            this.lbReservEditList.Location = new System.Drawing.Point(154, 36);
            this.lbReservEditList.Name = "lbReservEditList";
            this.lbReservEditList.Size = new System.Drawing.Size(179, 260);
            this.lbReservEditList.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbFormName
            // 
            this.lbFormName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbFormName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbFormName.ForeColor = System.Drawing.Color.Red;
            this.lbFormName.Location = new System.Drawing.Point(6, 3);
            this.lbFormName.Name = "lbFormName";
            this.lbFormName.Size = new System.Drawing.Size(329, 35);
            this.lbFormName.TabIndex = 8;
            this.lbFormName.Text = "آخرین شماره ()";
            this.lbFormName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NoStorageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 339);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "NoStorageForm";
            this.Text = "مدیریت اندیکاتور";
            this.Load += new System.EventHandler(this.NoStorageForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage2;
		private ClassLibrary.TextEdit txtNumber;
		private System.Windows.Forms.Button btnGetNumber;
		private System.Windows.Forms.TabPage tabPage1;
		private ClassLibrary.TextEdit txtReservNumber;
		private System.Windows.Forms.Button btnReservNumber;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox lbReservEditList;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox lbReservList;
		private System.Windows.Forms.Button btnDeleteReservNumber;
		private System.Windows.Forms.Label lbReserverTo;
		private System.Windows.Forms.Label lbLastNumber;
		private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbFormName;
    }
}