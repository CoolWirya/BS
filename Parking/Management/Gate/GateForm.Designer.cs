namespace Parking
{
    partial class GateForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnApplay = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.BtnSendGroup = new System.Windows.Forms.Button();
            this.btnOptionDevice = new System.Windows.Forms.Button();
            this.txtIPSystemParking = new ClassLibrary.TextEdit(this.components);
            this.TxtIpCamera = new ClassLibrary.TextEdit(this.components);
            this.TxtIpSubnet = new ClassLibrary.TextEdit(this.components);
            this.TxtipDevice = new ClassLibrary.TextEdit(this.components);
            this.TxtIpCenter = new ClassLibrary.TextEdit(this.components);
            this.txtReaderName = new ClassLibrary.TextEdit(this.components);
            this.CmbTypeGate = new ClassLibrary.JComboBox(this.components);
            this.cmbComplex = new ClassLibrary.JComboBox(this.components);
            this.txtName = new ClassLibrary.TextEdit(this.components);
            this.Txtport = new ClassLibrary.TextEdit(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ChkState = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(492, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "نام گيت :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(271, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "مجتمع :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(578, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "نوع :";
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(7, 234);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(83, 32);
            this.BtnSave.TabIndex = 8;
            this.BtnSave.Text = "ثبت";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(257, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "نام دستگاه كارت خوان :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(555, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "IP  مركز :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(337, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "IP رايانه :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(314, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "Ip زير شبكه :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(120, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 16);
            this.label10.TabIndex = 20;
            this.label10.Text = "Ip دوربين :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(528, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 16);
            this.label6.TabIndex = 22;
            this.label6.Text = "IP كارت خوان :";
            // 
            // BtnApplay
            // 
            this.BtnApplay.Location = new System.Drawing.Point(96, 234);
            this.BtnApplay.Name = "BtnApplay";
            this.BtnApplay.Size = new System.Drawing.Size(83, 32);
            this.BtnApplay.TabIndex = 24;
            this.BtnApplay.Text = "اعمال";
            this.BtnApplay.UseVisualStyleBackColor = true;
            this.BtnApplay.Click += new System.EventHandler(this.BtnApplay_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(185, 234);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 32);
            this.button3.TabIndex = 25;
            this.button3.Text = "خروج";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // BtnSendGroup
            // 
            this.BtnSendGroup.Enabled = false;
            this.BtnSendGroup.Location = new System.Drawing.Point(334, 234);
            this.BtnSendGroup.Name = "BtnSendGroup";
            this.BtnSendGroup.Size = new System.Drawing.Size(124, 32);
            this.BtnSendGroup.TabIndex = 26;
            this.BtnSendGroup.Text = "ارسال  به دستگاه";
            this.BtnSendGroup.UseVisualStyleBackColor = true;
            this.BtnSendGroup.Click += new System.EventHandler(this.BtnSendGroup_Click);
            // 
            // btnOptionDevice
            // 
            this.btnOptionDevice.Enabled = false;
            this.btnOptionDevice.Location = new System.Drawing.Point(464, 234);
            this.btnOptionDevice.Name = "btnOptionDevice";
            this.btnOptionDevice.Size = new System.Drawing.Size(160, 32);
            this.btnOptionDevice.TabIndex = 27;
            this.btnOptionDevice.Text = "تنظيم پارامترهاي دستگاه";
            this.btnOptionDevice.UseVisualStyleBackColor = true;
            this.btnOptionDevice.Click += new System.EventHandler(this.btnOptionDevice_Click);
            // 
            // txtIPSystemParking
            // 
            this.txtIPSystemParking.ChangeColorIfNotEmpty = false;
            this.txtIPSystemParking.ChangeColorOnEnter = true;
            this.txtIPSystemParking.InBackColor = System.Drawing.SystemColors.Info;
            this.txtIPSystemParking.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtIPSystemParking.Location = new System.Drawing.Point(199, 22);
            this.txtIPSystemParking.Name = "txtIPSystemParking";
            this.txtIPSystemParking.Negative = true;
            this.txtIPSystemParking.NotEmpty = false;
            this.txtIPSystemParking.NotEmptyColor = System.Drawing.Color.Red;
            this.txtIPSystemParking.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIPSystemParking.SelectOnEnter = true;
            this.txtIPSystemParking.Size = new System.Drawing.Size(114, 23);
            this.txtIPSystemParking.TabIndex = 23;
            this.txtIPSystemParking.TextMode = ClassLibrary.TextModes.Text;
            // 
            // TxtIpCamera
            // 
            this.TxtIpCamera.ChangeColorIfNotEmpty = false;
            this.TxtIpCamera.ChangeColorOnEnter = true;
            this.TxtIpCamera.InBackColor = System.Drawing.SystemColors.Info;
            this.TxtIpCamera.InForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtIpCamera.Location = new System.Drawing.Point(6, 22);
            this.TxtIpCamera.Name = "TxtIpCamera";
            this.TxtIpCamera.Negative = true;
            this.TxtIpCamera.NotEmpty = false;
            this.TxtIpCamera.NotEmptyColor = System.Drawing.Color.Red;
            this.TxtIpCamera.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtIpCamera.SelectOnEnter = true;
            this.TxtIpCamera.Size = new System.Drawing.Size(114, 23);
            this.TxtIpCamera.TabIndex = 21;
            this.TxtIpCamera.TextMode = ClassLibrary.TextModes.Text;
            // 
            // TxtIpSubnet
            // 
            this.TxtIpSubnet.ChangeColorIfNotEmpty = false;
            this.TxtIpSubnet.ChangeColorOnEnter = true;
            this.TxtIpSubnet.InBackColor = System.Drawing.SystemColors.Info;
            this.TxtIpSubnet.InForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtIpSubnet.Location = new System.Drawing.Point(198, 70);
            this.TxtIpSubnet.Name = "TxtIpSubnet";
            this.TxtIpSubnet.Negative = true;
            this.TxtIpSubnet.NotEmpty = false;
            this.TxtIpSubnet.NotEmptyColor = System.Drawing.Color.Red;
            this.TxtIpSubnet.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtIpSubnet.SelectOnEnter = true;
            this.TxtIpSubnet.Size = new System.Drawing.Size(115, 23);
            this.TxtIpSubnet.TabIndex = 19;
            this.TxtIpSubnet.Text = "255.255.255.255";
            this.TxtIpSubnet.TextMode = ClassLibrary.TextModes.Text;
            // 
            // TxtipDevice
            // 
            this.TxtipDevice.ChangeColorIfNotEmpty = false;
            this.TxtipDevice.ChangeColorOnEnter = true;
            this.TxtipDevice.InBackColor = System.Drawing.SystemColors.Info;
            this.TxtipDevice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtipDevice.Location = new System.Drawing.Point(407, 22);
            this.TxtipDevice.Name = "TxtipDevice";
            this.TxtipDevice.Negative = true;
            this.TxtipDevice.NotEmpty = false;
            this.TxtipDevice.NotEmptyColor = System.Drawing.Color.Red;
            this.TxtipDevice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtipDevice.SelectOnEnter = true;
            this.TxtipDevice.Size = new System.Drawing.Size(115, 23);
            this.TxtipDevice.TabIndex = 16;
            this.TxtipDevice.TextMode = ClassLibrary.TextModes.Text;
            // 
            // TxtIpCenter
            // 
            this.TxtIpCenter.ChangeColorIfNotEmpty = false;
            this.TxtIpCenter.ChangeColorOnEnter = true;
            this.TxtIpCenter.InBackColor = System.Drawing.SystemColors.Info;
            this.TxtIpCenter.InForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtIpCenter.Location = new System.Drawing.Point(409, 70);
            this.TxtIpCenter.Name = "TxtIpCenter";
            this.TxtIpCenter.Negative = true;
            this.TxtIpCenter.NotEmpty = false;
            this.TxtIpCenter.NotEmptyColor = System.Drawing.Color.Red;
            this.TxtIpCenter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtIpCenter.SelectOnEnter = true;
            this.TxtIpCenter.Size = new System.Drawing.Size(115, 23);
            this.TxtIpCenter.TabIndex = 14;
            this.TxtIpCenter.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtReaderName
            // 
            this.txtReaderName.ChangeColorIfNotEmpty = false;
            this.txtReaderName.ChangeColorOnEnter = true;
            this.txtReaderName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtReaderName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtReaderName.Location = new System.Drawing.Point(120, 69);
            this.txtReaderName.Name = "txtReaderName";
            this.txtReaderName.Negative = true;
            this.txtReaderName.NotEmpty = false;
            this.txtReaderName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtReaderName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtReaderName.SelectOnEnter = true;
            this.txtReaderName.Size = new System.Drawing.Size(139, 23);
            this.txtReaderName.TabIndex = 10;
            this.txtReaderName.TextMode = ClassLibrary.TextModes.Text;
            // 
            // CmbTypeGate
            // 
            this.CmbTypeGate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.CmbTypeGate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbTypeGate.BaseCode = 0;
            this.CmbTypeGate.ChangeColorIfNotEmpty = true;
            this.CmbTypeGate.ChangeColorOnEnter = true;
            this.CmbTypeGate.FormattingEnabled = true;
            this.CmbTypeGate.InBackColor = System.Drawing.SystemColors.Info;
            this.CmbTypeGate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbTypeGate.Items.AddRange(new object[] {
            "ورودی",
            "خروجی",
            "ورودی-خروجی"});
            this.CmbTypeGate.Location = new System.Drawing.Point(407, 69);
            this.CmbTypeGate.Name = "CmbTypeGate";
            this.CmbTypeGate.NotEmpty = false;
            this.CmbTypeGate.NotEmptyColor = System.Drawing.Color.Red;
            this.CmbTypeGate.SelectOnEnter = true;
            this.CmbTypeGate.Size = new System.Drawing.Size(157, 24);
            this.CmbTypeGate.TabIndex = 7;
            // 
            // cmbComplex
            // 
            this.cmbComplex.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbComplex.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbComplex.BaseCode = 0;
            this.cmbComplex.ChangeColorIfNotEmpty = true;
            this.cmbComplex.ChangeColorOnEnter = true;
            this.cmbComplex.Enabled = false;
            this.cmbComplex.FormattingEnabled = true;
            this.cmbComplex.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbComplex.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbComplex.Location = new System.Drawing.Point(75, 21);
            this.cmbComplex.Name = "cmbComplex";
            this.cmbComplex.NotEmpty = false;
            this.cmbComplex.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbComplex.SelectOnEnter = true;
            this.cmbComplex.Size = new System.Drawing.Size(190, 24);
            this.cmbComplex.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.ChangeColorIfNotEmpty = false;
            this.txtName.ChangeColorOnEnter = true;
            this.txtName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName.Location = new System.Drawing.Point(353, 22);
            this.txtName.Name = "txtName";
            this.txtName.Negative = true;
            this.txtName.NotEmpty = false;
            this.txtName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.SelectOnEnter = true;
            this.txtName.Size = new System.Drawing.Size(133, 23);
            this.txtName.TabIndex = 3;
            this.txtName.TextMode = ClassLibrary.TextModes.Text;
            // 
            // Txtport
            // 
            this.Txtport.ChangeColorIfNotEmpty = false;
            this.Txtport.ChangeColorOnEnter = true;
            this.Txtport.InBackColor = System.Drawing.SystemColors.Info;
            this.Txtport.InForeColor = System.Drawing.SystemColors.WindowText;
            this.Txtport.Location = new System.Drawing.Point(6, 70);
            this.Txtport.Name = "Txtport";
            this.Txtport.Negative = true;
            this.Txtport.NotEmpty = false;
            this.Txtport.NotEmptyColor = System.Drawing.Color.Red;
            this.Txtport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txtport.SelectOnEnter = true;
            this.Txtport.Size = new System.Drawing.Size(114, 23);
            this.Txtport.TabIndex = 29;
            this.Txtport.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(144, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 16);
            this.label11.TabIndex = 28;
            this.label11.Text = "پورت :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Txtport);
            this.groupBox1.Controls.Add(this.TxtipDevice);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtIPSystemParking);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.TxtIpCenter);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.TxtIpCamera);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.TxtIpSubnet);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(624, 107);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تنظيمات سخت افزاري دستگاهها";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ChkState);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbComplex);
            this.groupBox2.Controls.Add(this.txtReaderName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.CmbTypeGate);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(624, 107);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "اطلاعات گيت";
            // 
            // ChkState
            // 
            this.ChkState.AutoSize = true;
            this.ChkState.Checked = true;
            this.ChkState.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkState.Location = new System.Drawing.Point(3, 71);
            this.ChkState.Name = "ChkState";
            this.ChkState.Size = new System.Drawing.Size(109, 20);
            this.ChkState.TabIndex = 11;
            this.ChkState.Text = "گيت فعال است";
            this.ChkState.UseVisualStyleBackColor = true;
            // 
            // GateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 274);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOptionDevice);
            this.Controls.Add(this.BtnSendGroup);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.BtnApplay);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GateForm";
            this.Text = "تنظيمات گيت";
            this.Load += new System.EventHandler(this.GateForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GateForm_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ClassLibrary.TextEdit txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.JComboBox cmbComplex;
        private ClassLibrary.JComboBox CmbTypeGate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnSave;
        private ClassLibrary.TextEdit txtReaderName;
        private System.Windows.Forms.Label label5;
        private ClassLibrary.TextEdit TxtIpCenter;
        private System.Windows.Forms.Label label7;
        private ClassLibrary.TextEdit TxtipDevice;
        private System.Windows.Forms.Label label8;
        private ClassLibrary.TextEdit TxtIpSubnet;
        private System.Windows.Forms.Label label9;
        private ClassLibrary.TextEdit TxtIpCamera;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private ClassLibrary.TextEdit txtIPSystemParking;
        private System.Windows.Forms.Button BtnApplay;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button BtnSendGroup;
        private System.Windows.Forms.Button btnOptionDevice;
        private ClassLibrary.TextEdit Txtport;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ChkState;
    }
}