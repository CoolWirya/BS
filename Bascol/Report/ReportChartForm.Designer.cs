namespace Bascol
{
    partial class JReportChartForm
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dateEdit1 = new ClassLibrary.DateEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btndupu = new System.Windows.Forms.Button();
            this.btndelu = new System.Windows.Forms.Button();
            this.btndup = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnwb = new System.Windows.Forms.Button();
            this.btnw = new System.Windows.Forms.Button();
            this.btnweight = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chklistTozin = new System.Windows.Forms.CheckedListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chklistUsers = new System.Windows.Forms.CheckedListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chklistTrucks = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkListBascol = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.dateEdit1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(915, 160);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(46, 93);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(117, 28);
            this.btnSearch.TabIndex = 91;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(46, 125);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(117, 28);
            this.btnPrint.TabIndex = 90;
            this.btnPrint.Text = "چاپ";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // dateEdit1
            // 
            this.dateEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateEdit1.ChangeColorIfNotEmpty = true;
            this.dateEdit1.ChangeColorOnEnter = true;
            this.dateEdit1.Date = new System.DateTime(((long)(0)));
            this.dateEdit1.InBackColor = System.Drawing.SystemColors.Info;
            this.dateEdit1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.dateEdit1.InsertInDatesTable = true;
            this.dateEdit1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dateEdit1.Location = new System.Drawing.Point(68, 48);
            this.dateEdit1.Mask = "0000/00/00";
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.NotEmpty = false;
            this.dateEdit1.NotEmptyColor = System.Drawing.Color.Red;
            this.dateEdit1.Size = new System.Drawing.Size(100, 23);
            this.dateEdit1.TabIndex = 77;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 76;
            this.label1.Text = "تاریخ پایان:";
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
            this.txtDate.Location = new System.Drawing.Point(68, 19);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(100, 23);
            this.txtDate.TabIndex = 75;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 74;
            this.label2.Text = "تاریخ شروع:";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btndupu);
            this.groupBox7.Controls.Add(this.btndelu);
            this.groupBox7.Controls.Add(this.btndup);
            this.groupBox7.Controls.Add(this.button4);
            this.groupBox7.Controls.Add(this.btnwb);
            this.groupBox7.Controls.Add(this.btnw);
            this.groupBox7.Controls.Add(this.btnweight);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox7.Location = new System.Drawing.Point(0, 563);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(915, 112);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            // 
            // btndupu
            // 
            this.btndupu.Location = new System.Drawing.Point(30, 61);
            this.btndupu.Name = "btndupu";
            this.btndupu.Size = new System.Drawing.Size(151, 43);
            this.btndupu.TabIndex = 13;
            this.btndupu.Text = "نمودار قبوض المثنی بر اساس کاربران";
            this.btndupu.UseVisualStyleBackColor = true;
            // 
            // btndelu
            // 
            this.btndelu.Location = new System.Drawing.Point(330, 61);
            this.btndelu.Name = "btndelu";
            this.btndelu.Size = new System.Drawing.Size(151, 43);
            this.btndelu.TabIndex = 12;
            this.btndelu.Text = "نمودار قبوض حذف شده بر اساس کاربران";
            this.btndelu.UseVisualStyleBackColor = true;
            // 
            // btndup
            // 
            this.btndup.Location = new System.Drawing.Point(30, 18);
            this.btndup.Name = "btndup";
            this.btndup.Size = new System.Drawing.Size(151, 43);
            this.btndup.TabIndex = 11;
            this.btndup.Text = "نمودار قبوض المثنی";
            this.btndup.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(330, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(151, 43);
            this.button4.TabIndex = 10;
            this.button4.Text = "نمودار توزین های حذف شده";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnwb
            // 
            this.btnwb.Location = new System.Drawing.Point(542, 20);
            this.btnwb.Name = "btnwb";
            this.btnwb.Size = new System.Drawing.Size(199, 43);
            this.btnwb.TabIndex = 9;
            this.btnwb.Text = "نمودار توزین بر اساس باسکول";
            this.btnwb.UseVisualStyleBackColor = true;
            // 
            // btnw
            // 
            this.btnw.Location = new System.Drawing.Point(747, 64);
            this.btnw.Name = "btnw";
            this.btnw.Size = new System.Drawing.Size(151, 43);
            this.btnw.TabIndex = 8;
            this.btnw.Text = "نمودار کل توزین ها";
            this.btnw.UseVisualStyleBackColor = true;
            // 
            // btnweight
            // 
            this.btnweight.Location = new System.Drawing.Point(747, 20);
            this.btnweight.Name = "btnweight";
            this.btnweight.Size = new System.Drawing.Size(151, 43);
            this.btnweight.TabIndex = 7;
            this.btnweight.Text = "نمودار توزین بر اساس کاربر";
            this.btnweight.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chklistTozin);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox6.Location = new System.Drawing.Point(432, 19);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(120, 138);
            this.groupBox6.TabIndex = 95;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "توزین";
            // 
            // chklistTozin
            // 
            this.chklistTozin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chklistTozin.FormattingEnabled = true;
            this.chklistTozin.Location = new System.Drawing.Point(3, 19);
            this.chklistTozin.Name = "chklistTozin";
            this.chklistTozin.Size = new System.Drawing.Size(114, 112);
            this.chklistTozin.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chklistUsers);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox5.Location = new System.Drawing.Point(552, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(120, 138);
            this.groupBox5.TabIndex = 94;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "کاربران";
            // 
            // chklistUsers
            // 
            this.chklistUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chklistUsers.FormattingEnabled = true;
            this.chklistUsers.Location = new System.Drawing.Point(3, 19);
            this.chklistUsers.Name = "chklistUsers";
            this.chklistUsers.Size = new System.Drawing.Size(114, 112);
            this.chklistUsers.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chklistTrucks);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox4.Location = new System.Drawing.Point(672, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(120, 138);
            this.groupBox4.TabIndex = 93;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ماشین";
            // 
            // chklistTrucks
            // 
            this.chklistTrucks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chklistTrucks.FormattingEnabled = true;
            this.chklistTrucks.Location = new System.Drawing.Point(3, 19);
            this.chklistTrucks.Name = "chklistTrucks";
            this.chklistTrucks.Size = new System.Drawing.Size(114, 112);
            this.chklistTrucks.TabIndex = 92;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkListBascol);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(792, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(120, 138);
            this.groupBox3.TabIndex = 92;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "شماره باسکول";
            // 
            // chkListBascol
            // 
            this.chkListBascol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkListBascol.FormattingEnabled = true;
            this.chkListBascol.Location = new System.Drawing.Point(3, 19);
            this.chkListBascol.Name = "chkListBascol";
            this.chkListBascol.Size = new System.Drawing.Size(114, 112);
            this.chkListBascol.TabIndex = 92;
            // 
            // JReportChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 675);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox1);
            this.Name = "JReportChartForm";
            this.Text = "ReportChartForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnPrint;
        private ClassLibrary.DateEdit dateEdit1;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.DateEdit txtDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btndupu;
        private System.Windows.Forms.Button btndelu;
        private System.Windows.Forms.Button btndup;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnwb;
        private System.Windows.Forms.Button btnw;
        private System.Windows.Forms.Button btnweight;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckedListBox chklistTozin;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckedListBox chklistUsers;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckedListBox chklistTrucks;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox chkListBascol;
    }
}