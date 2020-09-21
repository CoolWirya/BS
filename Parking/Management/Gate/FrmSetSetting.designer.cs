namespace Parking
{
    partial class FrmSettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettingForm));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnSetIP = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.MaskedTextBox();
            this.txtTime = new System.Windows.Forms.MaskedTextBox();
            this.btnSetDateTime = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnVolume = new System.Windows.Forms.Button();
            this.txtSubnet = new System.Windows.Forms.MaskedTextBox();
            this.txtServerIP = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtVolume = new System.Windows.Forms.NumericUpDown();
            this.btnFormat = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtVolume)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "handheld_device.png");
            // 
            // btnSetIP
            // 
            this.btnSetIP.Location = new System.Drawing.Point(11, 20);
            this.btnSetIP.Name = "btnSetIP";
            this.btnSetIP.Size = new System.Drawing.Size(75, 23);
            this.btnSetIP.TabIndex = 12;
            this.btnSetIP.Text = "تنظیم IP";
            this.btnSetIP.UseVisualStyleBackColor = true;
            this.btnSetIP.Click += new System.EventHandler(this.btnSetIP_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(92, 22);
            this.txtIP.Mask = "000.000.000.000";
            this.txtIP.Name = "txtIP";
            this.txtIP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtIP.Size = new System.Drawing.Size(100, 21);
            this.txtIP.TabIndex = 0;
            this.txtIP.Text = "192168000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 27);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = " IP جدید:";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(105, 33);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDate.Size = new System.Drawing.Size(70, 21);
            this.txtDate.TabIndex = 3;
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(178, 33);
            this.txtTime.Mask = "00:00";
            this.txtTime.Name = "txtTime";
            this.txtTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTime.Size = new System.Drawing.Size(46, 21);
            this.txtTime.TabIndex = 4;
            this.txtTime.ValidatingType = typeof(System.DateTime);
            // 
            // btnSetDateTime
            // 
            this.btnSetDateTime.Location = new System.Drawing.Point(24, 33);
            this.btnSetDateTime.Name = "btnSetDateTime";
            this.btnSetDateTime.Size = new System.Drawing.Size(75, 23);
            this.btnSetDateTime.TabIndex = 18;
            this.btnSetDateTime.Text = "تنظیم زمان";
            this.btnSetDateTime.UseVisualStyleBackColor = true;
            this.btnSetDateTime.Click += new System.EventHandler(this.btnSetDateTime_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(231, 38);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "زمان جدید:";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(10, 22);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(122, 23);
            this.btnReset.TabIndex = 20;
            this.btnReset.Text = "ریست کردن دستگاه";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(205, 28);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "صدا(0..100):";
            // 
            // btnVolume
            // 
            this.btnVolume.Location = new System.Drawing.Point(59, 25);
            this.btnVolume.Name = "btnVolume";
            this.btnVolume.Size = new System.Drawing.Size(75, 23);
            this.btnVolume.TabIndex = 23;
            this.btnVolume.Text = "تنظیم صدا";
            this.btnVolume.UseVisualStyleBackColor = true;
            this.btnVolume.Click += new System.EventHandler(this.btnVolume_Click);
            // 
            // txtSubnet
            // 
            this.txtSubnet.Location = new System.Drawing.Point(92, 44);
            this.txtSubnet.Mask = "000.000.000.000";
            this.txtSubnet.Name = "txtSubnet";
            this.txtSubnet.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSubnet.Size = new System.Drawing.Size(100, 21);
            this.txtSubnet.TabIndex = 1;
            this.txtSubnet.Text = "255255255000";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(92, 67);
            this.txtServerIP.Mask = "000.000.000.000";
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtServerIP.Size = new System.Drawing.Size(100, 21);
            this.txtServerIP.TabIndex = 2;
            this.txtServerIP.Text = "192168000001";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(198, 47);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "آدرس زیر شبکه:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(234, 70);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "IP مرکز:";
            // 
            // txtVolume
            // 
            this.txtVolume.Location = new System.Drawing.Point(140, 25);
            this.txtVolume.Name = "txtVolume";
            this.txtVolume.Size = new System.Drawing.Size(59, 21);
            this.txtVolume.TabIndex = 51;
            // 
            // btnFormat
            // 
            this.btnFormat.Location = new System.Drawing.Point(156, 22);
            this.btnFormat.Name = "btnFormat";
            this.btnFormat.Size = new System.Drawing.Size(122, 23);
            this.btnFormat.TabIndex = 73;
            this.btnFormat.Text = "فرمت حافظه دستگاه";
            this.btnFormat.UseVisualStyleBackColor = true;
            this.btnFormat.Click += new System.EventHandler(this.btnFormat_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnSetIP);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Controls.Add(this.txtSubnet);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtServerIP);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(309, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 144);
            this.groupBox1.TabIndex = 74;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تنظيم ادرس هاي كارت خوان";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSetDateTime);
            this.groupBox2.Controls.Add(this.txtDate);
            this.groupBox2.Controls.Add(this.txtTime);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(5, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(298, 70);
            this.groupBox2.TabIndex = 75;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "تنظبم تاريخ و ساعت";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnVolume);
            this.groupBox3.Controls.Add(this.txtVolume);
            this.groupBox3.Location = new System.Drawing.Point(5, 74);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(298, 74);
            this.groupBox3.TabIndex = 76;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "تنظيم صدا";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnFormat);
            this.groupBox4.Controls.Add(this.btnReset);
            this.groupBox4.Location = new System.Drawing.Point(5, 152);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(592, 62);
            this.groupBox4.TabIndex = 77;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ساير عمليات";
            // 
            // FrmSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 223);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "FrmSettingForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تنظيمات كارت خوان";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtVolume)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnSetIP;
        private System.Windows.Forms.MaskedTextBox txtIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtDate;
        private System.Windows.Forms.MaskedTextBox txtTime;
        private System.Windows.Forms.Button btnSetDateTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnVolume;
        private System.Windows.Forms.MaskedTextBox txtSubnet;
        private System.Windows.Forms.MaskedTextBox txtServerIP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown txtVolume;
        private System.Windows.Forms.Button btnFormat;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

