namespace Legal
{
    partial class JEnviromentForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRent = new ClassLibrary.TextEdit(this.components);
            this.txtPrice = new ClassLibrary.TextEdit(this.components);
            this.cmbJobs = new ClassLibrary.JComboBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbPony = new ClassLibrary.JComboBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPayment = new ClassLibrary.JComboBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cmbUsage = new ClassLibrary.JComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRent);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.cmbJobs);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbPony);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbPayment);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbUsage);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(684, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtRent
            // 
            this.txtRent.ChangeColorIfNotEmpty = false;
            this.txtRent.ChangeColorOnEnter = true;
            this.txtRent.InBackColor = System.Drawing.SystemColors.Info;
            this.txtRent.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRent.Location = new System.Drawing.Point(68, 22);
            this.txtRent.Name = "txtRent";
            this.txtRent.Negative = true;
            this.txtRent.NotEmpty = false;
            this.txtRent.NotEmptyColor = System.Drawing.Color.Red;
            this.txtRent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRent.SelectOnEnter = true;
            this.txtRent.Size = new System.Drawing.Size(133, 23);
            this.txtRent.TabIndex = 1;
            this.txtRent.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtPrice
            // 
            this.txtPrice.ChangeColorIfNotEmpty = false;
            this.txtPrice.ChangeColorOnEnter = true;
            this.txtPrice.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPrice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPrice.Location = new System.Drawing.Point(412, 25);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Negative = true;
            this.txtPrice.NotEmpty = false;
            this.txtPrice.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrice.SelectOnEnter = true;
            this.txtPrice.Size = new System.Drawing.Size(134, 23);
            this.txtPrice.TabIndex = 0;
            this.txtPrice.TextMode = ClassLibrary.TextModes.Text;
            // 
            // cmbJobs
            // 
            this.cmbJobs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbJobs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbJobs.BaseCode = 0;
            this.cmbJobs.ChangeColorIfNotEmpty = true;
            this.cmbJobs.ChangeColorOnEnter = true;
            this.cmbJobs.FormattingEnabled = true;
            this.cmbJobs.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbJobs.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbJobs.Location = new System.Drawing.Point(375, 65);
            this.cmbJobs.Name = "cmbJobs";
            this.cmbJobs.NotEmpty = false;
            this.cmbJobs.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbJobs.SelectOnEnter = true;
            this.cmbJobs.Size = new System.Drawing.Size(171, 24);
            this.cmbJobs.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(628, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "شغل:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(558, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "مبلغ قرض الحسنه:";
            // 
            // cmbPony
            // 
            this.cmbPony.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbPony.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPony.BaseCode = 0;
            this.cmbPony.ChangeColorIfNotEmpty = true;
            this.cmbPony.ChangeColorOnEnter = true;
            this.cmbPony.FormattingEnabled = true;
            this.cmbPony.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbPony.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbPony.Location = new System.Drawing.Point(30, 96);
            this.cmbPony.Name = "cmbPony";
            this.cmbPony.NotEmpty = false;
            this.cmbPony.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbPony.SelectOnEnter = true;
            this.cmbPony.Size = new System.Drawing.Size(171, 24);
            this.cmbPony.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(248, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "نحوه تسویه:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "مبلغ اجاره واقعي :";
            // 
            // cmbPayment
            // 
            this.cmbPayment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbPayment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPayment.BaseCode = 0;
            this.cmbPayment.ChangeColorIfNotEmpty = true;
            this.cmbPayment.ChangeColorOnEnter = true;
            this.cmbPayment.FormattingEnabled = true;
            this.cmbPayment.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbPayment.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbPayment.Location = new System.Drawing.Point(375, 99);
            this.cmbPayment.Name = "cmbPayment";
            this.cmbPayment.NotEmpty = false;
            this.cmbPayment.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbPayment.SelectOnEnter = true;
            this.cmbPayment.Size = new System.Drawing.Size(170, 24);
            this.cmbPayment.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(555, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "نحوه پرداخت اجاره:";
            // 
            // cmbUsage
            // 
            this.cmbUsage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbUsage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUsage.BaseCode = 0;
            this.cmbUsage.ChangeColorIfNotEmpty = true;
            this.cmbUsage.ChangeColorOnEnter = true;
            this.cmbUsage.FormattingEnabled = true;
            this.cmbUsage.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbUsage.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbUsage.Location = new System.Drawing.Point(30, 62);
            this.cmbUsage.Name = "cmbUsage";
            this.cmbUsage.NotEmpty = false;
            this.cmbUsage.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbUsage.SelectOnEnter = true;
            this.cmbUsage.Size = new System.Drawing.Size(171, 24);
            this.cmbUsage.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "نوع كاربري:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 314);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 40);
            this.panel1.TabIndex = 2;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(508, 8);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 25);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "قبلی";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(17, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(589, 8);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 25);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "بعدی";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtDesc);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 140);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(684, 174);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "تعهدات تهاتر";
            // 
            // txtDesc
            // 
            this.txtDesc.ChangeColorIfNotEmpty = false;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(3, 19);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(678, 152);
            this.txtDesc.TabIndex = 0;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // JEnviromentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 354);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "JEnviromentForm";
            this.Text = "اطلاعات قرارداد مشاعات";
            this.VisibleChanged += new System.EventHandler(this.JEnviromentForm_VisibleChanged);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.JEnviromentForm_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.JComboBox cmbUsage;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.JComboBox cmbPony;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.JComboBox cmbPayment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private ClassLibrary.JComboBox cmbJobs;
        private ClassLibrary.TextEdit txtPrice;
        private ClassLibrary.TextEdit txtRent;
    }
}