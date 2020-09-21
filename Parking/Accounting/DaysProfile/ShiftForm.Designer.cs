namespace Parking
{
    partial class JShiftForm
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
            this.cmbHeadShift = new ClassLibrary.JComboBox(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.Txtnumber = new ClassLibrary.NumEdit();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtMoney = new ClassLibrary.NumEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDescription = new ClassLibrary.TextEdit(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.BtnReport = new System.Windows.Forms.Button();
            this.btnGate = new System.Windows.Forms.Button();
            this.btnDamgeReport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnshift = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbHeadShift
            // 
            this.cmbHeadShift.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbHeadShift.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbHeadShift.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbHeadShift.BaseCode = 0;
            this.cmbHeadShift.ChangeColorIfNotEmpty = true;
            this.cmbHeadShift.ChangeColorOnEnter = true;
            this.cmbHeadShift.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbHeadShift.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbHeadShift.Location = new System.Drawing.Point(223, 32);
            this.cmbHeadShift.Name = "cmbHeadShift";
            this.cmbHeadShift.NotEmpty = false;
            this.cmbHeadShift.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbHeadShift.SelectOnEnter = true;
            this.cmbHeadShift.Size = new System.Drawing.Size(164, 24);
            this.cmbHeadShift.TabIndex = 33;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(441, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 16);
            this.label11.TabIndex = 20;
            this.label11.Text = "سرشیفت :";
            // 
            // txtDate
            // 
            this.txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDate.ChangeColorIfNotEmpty = true;
            this.txtDate.ChangeColorOnEnter = true;
            this.txtDate.Date = new System.DateTime(((long)(0)));
            this.txtDate.Enabled = false;
            this.txtDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDate.InsertInDatesTable = true;
            this.txtDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDate.Location = new System.Drawing.Point(223, 89);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(79, 23);
            this.txtDate.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(397, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "تاریخ  شروع به كار :";
            // 
            // Txtnumber
            // 
            this.Txtnumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txtnumber.ChangeColorIfNotEmpty = false;
            this.Txtnumber.ChangeColorOnEnter = true;
            this.Txtnumber.Enabled = false;
            this.Txtnumber.InBackColor = System.Drawing.SystemColors.Info;
            this.Txtnumber.InForeColor = System.Drawing.SystemColors.WindowText;
            this.Txtnumber.Location = new System.Drawing.Point(308, 89);
            this.Txtnumber.Name = "Txtnumber";
            this.Txtnumber.Negative = true;
            this.Txtnumber.NotEmpty = false;
            this.Txtnumber.NotEmptyColor = System.Drawing.Color.Red;
            this.Txtnumber.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.Txtnumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txtnumber.SelectOnEnter = true;
            this.Txtnumber.Size = new System.Drawing.Size(79, 23);
            this.Txtnumber.TabIndex = 31;
            this.Txtnumber.TextMode = ClassLibrary.TextModes.Text;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.txtMoney);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtDescription);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.Txtnumber);
            this.groupBox4.Controls.Add(this.cmbHeadShift);
            this.groupBox4.Controls.Add(this.txtDate);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox4.Size = new System.Drawing.Size(530, 334);
            this.groupBox4.TabIndex = 37;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "اطلاعات تفكيكي";
            // 
            // txtMoney
            // 
            this.txtMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoney.ChangeColorIfNotEmpty = false;
            this.txtMoney.ChangeColorOnEnter = true;
            this.txtMoney.InBackColor = System.Drawing.SystemColors.Info;
            this.txtMoney.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMoney.Location = new System.Drawing.Point(223, 149);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Negative = true;
            this.txtMoney.NotEmpty = false;
            this.txtMoney.NotEmptyColor = System.Drawing.Color.Red;
            this.txtMoney.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtMoney.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMoney.SelectOnEnter = true;
            this.txtMoney.Size = new System.Drawing.Size(164, 23);
            this.txtMoney.TabIndex = 36;
            this.txtMoney.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(447, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 16);
            this.label10.TabIndex = 35;
            this.label10.Text = "مبلغ دخل:";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.ChangeColorIfNotEmpty = false;
            this.txtDescription.ChangeColorOnEnter = true;
            this.txtDescription.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDescription.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDescription.Location = new System.Drawing.Point(34, 200);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Negative = true;
            this.txtDescription.NotEmpty = false;
            this.txtDescription.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDescription.SelectOnEnter = true;
            this.txtDescription.Size = new System.Drawing.Size(353, 61);
            this.txtDescription.TabIndex = 19;
            this.txtDescription.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(438, 222);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 16);
            this.label12.TabIndex = 34;
            this.label12.Text = "توضيحات :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(380, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(144, 50);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "ذخیره";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // BtnReport
            // 
            this.BtnReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnReport.Enabled = false;
            this.BtnReport.Location = new System.Drawing.Point(3, 69);
            this.BtnReport.Name = "BtnReport";
            this.BtnReport.Size = new System.Drawing.Size(176, 50);
            this.BtnReport.TabIndex = 1;
            this.BtnReport.Text = "نمايش گزارش عملكرد ";
            this.BtnReport.UseVisualStyleBackColor = true;
            this.BtnReport.Click += new System.EventHandler(this.BtnReport_Click);
            // 
            // btnGate
            // 
            this.btnGate.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGate.Enabled = false;
            this.btnGate.Location = new System.Drawing.Point(3, 19);
            this.btnGate.Name = "btnGate";
            this.btnGate.Size = new System.Drawing.Size(176, 50);
            this.btnGate.TabIndex = 2;
            this.btnGate.Text = "نمايش گزارش عملكرد گيت ها";
            this.btnGate.UseVisualStyleBackColor = true;
            this.btnGate.Click += new System.EventHandler(this.btnGate_Click);
            // 
            // btnDamgeReport
            // 
            this.btnDamgeReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDamgeReport.Enabled = false;
            this.btnDamgeReport.Location = new System.Drawing.Point(3, 119);
            this.btnDamgeReport.Name = "btnDamgeReport";
            this.btnDamgeReport.Size = new System.Drawing.Size(176, 50);
            this.btnDamgeReport.TabIndex = 0;
            this.btnDamgeReport.Text = "مشاهده گزارشات ثبت شده";
            this.btnDamgeReport.UseVisualStyleBackColor = true;
            this.btnDamgeReport.Click += new System.EventHandler(this.btnDamgeReport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnshift);
            this.groupBox1.Controls.Add(this.btnDamgeReport);
            this.groupBox1.Controls.Add(this.BtnReport);
            this.groupBox1.Controls.Add(this.btnGate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(530, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 334);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "گزارشات";
            // 
            // btnshift
            // 
            this.btnshift.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnshift.Enabled = false;
            this.btnshift.Location = new System.Drawing.Point(3, 169);
            this.btnshift.Name = "btnshift";
            this.btnshift.Size = new System.Drawing.Size(176, 50);
            this.btnshift.TabIndex = 3;
            this.btnshift.Text = "مشاهده عملكرد شيفتها";
            this.btnshift.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 267);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(524, 64);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "عمليات";
            // 
            // JShiftForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 334);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Name = "JShiftForm";
            this.Text = "شیفت روزانه";
            this.Load += new System.EventHandler(this.JShiftForm_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private ClassLibrary.DateEdit txtDate;
        private System.Windows.Forms.Label label11;
        private ClassLibrary.JComboBox cmbHeadShift;
        private ClassLibrary.NumEdit Txtnumber;
        private System.Windows.Forms.GroupBox groupBox4;
        private ClassLibrary.NumEdit txtMoney;
        private System.Windows.Forms.Label label10;
        private ClassLibrary.TextEdit txtDescription;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button BtnReport;
        private System.Windows.Forms.Button btnGate;
        private System.Windows.Forms.Button btnDamgeReport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnshift;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}