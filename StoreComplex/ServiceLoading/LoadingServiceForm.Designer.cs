namespace StoreComplex
{
    partial class JLoadingForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbLocation = new ClassLibrary.JComboBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.txtCost = new ClassLibrary.TextEdit(this.components);
            this.txtTime = new System.Windows.Forms.MaskedTextBox();
            this.txtWorkerCount = new ClassLibrary.TextEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWorkerDuration = new ClassLibrary.TextEdit(this.components);
            this.txtSerial = new ClassLibrary.TextEdit(this.components);
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(99, 163);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 26);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "انصراف";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(18, 163);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 26);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "ثبت";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbLocation);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtCost);
            this.groupBox1.Controls.Add(this.txtTime);
            this.groupBox1.Controls.Add(this.txtWorkerCount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtWorkerDuration);
            this.groupBox1.Controls.Add(this.txtSerial);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmbLocation
            // 
            this.cmbLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLocation.BaseCode = 0;
            this.cmbLocation.ChangeColorIfNotEmpty = true;
            this.cmbLocation.ChangeColorOnEnter = true;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbLocation.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbLocation.Location = new System.Drawing.Point(220, 85);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.NotEmpty = false;
            this.cmbLocation.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbLocation.SelectOnEnter = true;
            this.cmbLocation.Size = new System.Drawing.Size(100, 24);
            this.cmbLocation.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(119, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "هزینه سرویس:";
            // 
            // txtCost
            // 
            this.txtCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCost.ChangeColorIfNotEmpty = false;
            this.txtCost.ChangeColorOnEnter = true;
            this.txtCost.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCost.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCost.Location = new System.Drawing.Point(19, 117);
            this.txtCost.Name = "txtCost";
            this.txtCost.Negative = true;
            this.txtCost.NotEmpty = false;
            this.txtCost.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCost.SelectOnEnter = true;
            this.txtCost.Size = new System.Drawing.Size(100, 23);
            this.txtCost.TabIndex = 7;
            this.txtCost.TextMode = ClassLibrary.TextModes.Money;
            // 
            // txtTime
            // 
            this.txtTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTime.Location = new System.Drawing.Point(77, 53);
            this.txtTime.Mask = "90.00";
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(43, 23);
            this.txtTime.TabIndex = 3;
            this.txtTime.ValidatingType = typeof(System.DateTime);
            // 
            // txtWorkerCount
            // 
            this.txtWorkerCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkerCount.ChangeColorIfNotEmpty = false;
            this.txtWorkerCount.ChangeColorOnEnter = true;
            this.txtWorkerCount.InBackColor = System.Drawing.SystemColors.Info;
            this.txtWorkerCount.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtWorkerCount.Location = new System.Drawing.Point(19, 85);
            this.txtWorkerCount.Name = "txtWorkerCount";
            this.txtWorkerCount.Negative = true;
            this.txtWorkerCount.NotEmpty = false;
            this.txtWorkerCount.NotEmptyColor = System.Drawing.Color.Red;
            this.txtWorkerCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtWorkerCount.SelectOnEnter = true;
            this.txtWorkerCount.Size = new System.Drawing.Size(100, 23);
            this.txtWorkerCount.TabIndex = 5;
            this.txtWorkerCount.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "سریال رسید/حواله:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(119, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "ساعت:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "تعداد نیرو:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(336, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "محل تخلیه:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "تاریخ:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(326, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "مدت (دقیقه):";
            // 
            // txtWorkerDuration
            // 
            this.txtWorkerDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkerDuration.ChangeColorIfNotEmpty = false;
            this.txtWorkerDuration.ChangeColorOnEnter = true;
            this.txtWorkerDuration.InBackColor = System.Drawing.SystemColors.Info;
            this.txtWorkerDuration.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtWorkerDuration.Location = new System.Drawing.Point(220, 117);
            this.txtWorkerDuration.Name = "txtWorkerDuration";
            this.txtWorkerDuration.Negative = true;
            this.txtWorkerDuration.NotEmpty = false;
            this.txtWorkerDuration.NotEmptyColor = System.Drawing.Color.Red;
            this.txtWorkerDuration.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtWorkerDuration.SelectOnEnter = true;
            this.txtWorkerDuration.Size = new System.Drawing.Size(100, 23);
            this.txtWorkerDuration.TabIndex = 6;
            this.txtWorkerDuration.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // txtSerial
            // 
            this.txtSerial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSerial.ChangeColorIfNotEmpty = false;
            this.txtSerial.ChangeColorOnEnter = true;
            this.txtSerial.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSerial.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSerial.Location = new System.Drawing.Point(220, 18);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Negative = true;
            this.txtSerial.NotEmpty = false;
            this.txtSerial.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSerial.ReadOnly = true;
            this.txtSerial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSerial.SelectOnEnter = true;
            this.txtSerial.Size = new System.Drawing.Size(67, 23);
            this.txtSerial.TabIndex = 0;
            this.txtSerial.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtDate
            // 
            this.txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDate.ChangeColorIfNotEmpty = true;
            this.txtDate.ChangeColorOnEnter = true;
            this.txtDate.Date = new System.DateTime(((long)(0)));
            this.txtDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDate.InsertInDatesTable = true;
            this.txtDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDate.Location = new System.Drawing.Point(220, 53);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(100, 23);
            this.txtDate.TabIndex = 1;
            // 
            // JLoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 197);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.Name = "JLoadingForm";
            this.Text = "سرویس تخلیه/بارگیری";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private ClassLibrary.TextEdit txtCost;
        private System.Windows.Forms.MaskedTextBox txtTime;
        private ClassLibrary.TextEdit txtWorkerCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.TextEdit txtWorkerDuration;
        private ClassLibrary.TextEdit txtSerial;
        private ClassLibrary.DateEdit txtDate;
        private ClassLibrary.JComboBox cmbLocation;

    }
}