namespace StoreManagement
{
    partial class JReportContractForm
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
            this.jucPersonBuyer = new ClassLibrary.JUCPerson();
            this.jucPersonSeller = new ClassLibrary.JUCPerson();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDate1 = new ClassLibrary.DateEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkHiver = new System.Windows.Forms.CheckBox();
            this.chkAutomn = new System.Windows.Forms.CheckBox();
            this.chkSpring = new System.Windows.Forms.CheckBox();
            this.chkete = new System.Windows.Forms.CheckBox();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.jJanusGridReport = new ClassLibrary.JJanusGrid();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // jucPersonBuyer
            // 
            this.jucPersonBuyer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jucPersonBuyer.FilterPerson = null;
            this.jucPersonBuyer.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.jucPersonBuyer.LableGroup = "خریدار";
            this.jucPersonBuyer.Location = new System.Drawing.Point(-5, 9);
            this.jucPersonBuyer.Name = "jucPersonBuyer";
            this.jucPersonBuyer.PersonType = ClassLibrary.JPersonTypes.None;
            this.jucPersonBuyer.ReadOnly = false;
            this.jucPersonBuyer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.jucPersonBuyer.SelectedCode = 0;
            this.jucPersonBuyer.Size = new System.Drawing.Size(428, 182);
            this.jucPersonBuyer.TabIndex = 3;
            this.jucPersonBuyer.TafsiliCode = false;
            // 
            // jucPersonSeller
            // 
            this.jucPersonSeller.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.jucPersonSeller.FilterPerson = null;
            this.jucPersonSeller.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.jucPersonSeller.LableGroup = "فروشنده";
            this.jucPersonSeller.Location = new System.Drawing.Point(429, 9);
            this.jucPersonSeller.Name = "jucPersonSeller";
            this.jucPersonSeller.PersonType = ClassLibrary.JPersonTypes.None;
            this.jucPersonSeller.ReadOnly = false;
            this.jucPersonSeller.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.jucPersonSeller.SelectedCode = 0;
            this.jucPersonSeller.Size = new System.Drawing.Size(437, 182);
            this.jucPersonSeller.TabIndex = 2;
            this.jucPersonSeller.TafsiliCode = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDate1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.BtnPrint);
            this.groupBox1.Controls.Add(this.btnReport);
            this.groupBox1.Controls.Add(this.jucPersonSeller);
            this.groupBox1.Controls.Add(this.jucPersonBuyer);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(872, 265);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // txtDate1
            // 
            this.txtDate1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDate1.ChangeColorIfNotEmpty = true;
            this.txtDate1.ChangeColorOnEnter = true;
            this.txtDate1.Date = new System.DateTime(((long)(0)));
            this.txtDate1.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDate1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDate1.InsertInDatesTable = true;
            this.txtDate1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDate1.Location = new System.Drawing.Point(345, 213);
            this.txtDate1.Mask = "0000/00/00";
            this.txtDate1.Name = "txtDate1";
            this.txtDate1.NotEmpty = false;
            this.txtDate1.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate1.Size = new System.Drawing.Size(100, 23);
            this.txtDate1.TabIndex = 101;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(451, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 100;
            this.label3.Text = "تا تاریخ :";
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
            this.txtDate.Location = new System.Drawing.Point(514, 213);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(100, 23);
            this.txtDate.TabIndex = 99;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(620, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 98;
            this.label2.Text = " از تاریخ :";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.chkHiver);
            this.groupBox5.Controls.Add(this.chkAutomn);
            this.groupBox5.Controls.Add(this.chkSpring);
            this.groupBox5.Controls.Add(this.chkete);
            this.groupBox5.Location = new System.Drawing.Point(694, 187);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(172, 70);
            this.groupBox5.TabIndex = 97;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "فصل";
            // 
            // chkHiver
            // 
            this.chkHiver.AutoSize = true;
            this.chkHiver.Location = new System.Drawing.Point(37, 46);
            this.chkHiver.Name = "chkHiver";
            this.chkHiver.Size = new System.Drawing.Size(71, 20);
            this.chkHiver.TabIndex = 3;
            this.chkHiver.Text = "زمستان";
            this.chkHiver.UseVisualStyleBackColor = true;
            // 
            // chkAutomn
            // 
            this.chkAutomn.AutoSize = true;
            this.chkAutomn.Location = new System.Drawing.Point(114, 47);
            this.chkAutomn.Name = "chkAutomn";
            this.chkAutomn.Size = new System.Drawing.Size(49, 20);
            this.chkAutomn.TabIndex = 2;
            this.chkAutomn.Text = "پاییز";
            this.chkAutomn.UseVisualStyleBackColor = true;
            // 
            // chkSpring
            // 
            this.chkSpring.AutoSize = true;
            this.chkSpring.Location = new System.Drawing.Point(114, 22);
            this.chkSpring.Name = "chkSpring";
            this.chkSpring.Size = new System.Drawing.Size(47, 20);
            this.chkSpring.TabIndex = 1;
            this.chkSpring.Text = "بهار";
            this.chkSpring.UseVisualStyleBackColor = true;
            // 
            // chkete
            // 
            this.chkete.AutoSize = true;
            this.chkete.Location = new System.Drawing.Point(37, 22);
            this.chkete.Name = "chkete";
            this.chkete.Size = new System.Drawing.Size(71, 20);
            this.chkete.TabIndex = 0;
            this.chkete.Text = "تابستان";
            this.chkete.UseVisualStyleBackColor = true;
            // 
            // BtnPrint
            // 
            this.BtnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPrint.Location = new System.Drawing.Point(55, 209);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(120, 33);
            this.BtnPrint.TabIndex = 95;
            this.BtnPrint.Text = "چاپ";
            this.BtnPrint.UseVisualStyleBackColor = true;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.Location = new System.Drawing.Point(181, 209);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(120, 33);
            this.btnReport.TabIndex = 94;
            this.btnReport.Text = "جستجو";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // jJanusGridReport
            // 
            this.jJanusGridReport.ActionMenu = null;
            this.jJanusGridReport.DataSource = null;
            this.jJanusGridReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jJanusGridReport.Edited = false;
            this.jJanusGridReport.Location = new System.Drawing.Point(0, 265);
            this.jJanusGridReport.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.jJanusGridReport.MultiSelect = true;
            this.jJanusGridReport.Name = "jJanusGridReport";
            this.jJanusGridReport.ShowNavigator = true;
            this.jJanusGridReport.ShowToolbar = true;
            this.jJanusGridReport.Size = new System.Drawing.Size(872, 402);
            this.jJanusGridReport.TabIndex = 5;
            // 
            // JReportContractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 667);
            this.Controls.Add(this.jJanusGridReport);
            this.Controls.Add(this.groupBox1);
            this.Name = "JReportContractForm";
            this.Text = "ReportContractForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ClassLibrary.JUCPerson jucPersonBuyer;
        private ClassLibrary.JUCPerson jucPersonSeller;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkHiver;
        private System.Windows.Forms.CheckBox chkAutomn;
        private System.Windows.Forms.CheckBox chkSpring;
        private System.Windows.Forms.CheckBox chkete;
        private System.Windows.Forms.Button BtnPrint;
        private System.Windows.Forms.Button btnReport;
        private ClassLibrary.DateEdit txtDate1;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.DateEdit txtDate;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.JJanusGrid jJanusGridReport;
    }
}