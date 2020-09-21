namespace Bascol
{
    partial class JReportManagerForm
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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chklistTozin = new System.Windows.Forms.CheckedListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.listUsers = new System.Windows.Forms.ListBox();
            this.chklistUsers = new System.Windows.Forms.CheckedListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chklistTrucks = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkListBascol = new System.Windows.Forms.CheckedListBox();
            this.txtEndDate = new ClassLibrary.DateEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.v = new System.Windows.Forms.GroupBox();
            this.chkNotConfirm = new System.Windows.Forms.CheckBox();
            this.chkDelGhabz = new System.Windows.Forms.CheckBox();
            this.rbReportC = new System.Windows.Forms.RadioButton();
            this.rbBedehi = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnReturnConfirm = new System.Windows.Forms.Button();
            this.lblTotalDuty = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalTax = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotalPay_h = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalPay = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConfirmPay = new System.Windows.Forms.Button();
            this.btnback_del = new System.Windows.Forms.Button();
            this.btndel = new System.Windows.Forms.Button();
            this.jJanusGrid1 = new ClassLibrary.JJanusGrid();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.v.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.txtEndDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.v);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(918, 160);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(34, 85);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(140, 28);
            this.btnSearch.TabIndex = 91;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(34, 117);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(140, 28);
            this.btnPrint.TabIndex = 90;
            this.btnPrint.Text = "چاپ";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.chklistTozin);
            this.groupBox6.Location = new System.Drawing.Point(216, 19);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(120, 138);
            this.groupBox6.TabIndex = 89;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "توزین";
            // 
            // chklistTozin
            // 
            this.chklistTozin.CheckOnClick = true;
            this.chklistTozin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chklistTozin.FormattingEnabled = true;
            this.chklistTozin.Location = new System.Drawing.Point(3, 19);
            this.chklistTozin.Name = "chklistTozin";
            this.chklistTozin.Size = new System.Drawing.Size(114, 112);
            this.chklistTozin.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.listUsers);
            this.groupBox5.Controls.Add(this.chklistUsers);
            this.groupBox5.Location = new System.Drawing.Point(336, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(176, 138);
            this.groupBox5.TabIndex = 88;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "کاربران";
            // 
            // listUsers
            // 
            this.listUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listUsers.FormattingEnabled = true;
            this.listUsers.ItemHeight = 16;
            this.listUsers.Location = new System.Drawing.Point(3, 19);
            this.listUsers.Name = "listUsers";
            this.listUsers.Size = new System.Drawing.Size(170, 116);
            this.listUsers.TabIndex = 1;
            // 
            // chklistUsers
            // 
            this.chklistUsers.CheckOnClick = true;
            this.chklistUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chklistUsers.FormattingEnabled = true;
            this.chklistUsers.HorizontalScrollbar = true;
            this.chklistUsers.Location = new System.Drawing.Point(3, 19);
            this.chklistUsers.Name = "chklistUsers";
            this.chklistUsers.Size = new System.Drawing.Size(170, 112);
            this.chklistUsers.TabIndex = 0;
            this.chklistUsers.ThreeDCheckBoxes = true;
            this.chklistUsers.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.chklistTrucks);
            this.groupBox4.Location = new System.Drawing.Point(512, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(120, 138);
            this.groupBox4.TabIndex = 87;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ماشین";
            // 
            // chklistTrucks
            // 
            this.chklistTrucks.CheckOnClick = true;
            this.chklistTrucks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chklistTrucks.FormattingEnabled = true;
            this.chklistTrucks.Location = new System.Drawing.Point(3, 19);
            this.chklistTrucks.Name = "chklistTrucks";
            this.chklistTrucks.Size = new System.Drawing.Size(114, 112);
            this.chklistTrucks.TabIndex = 92;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.chkListBascol);
            this.groupBox3.Location = new System.Drawing.Point(632, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(120, 138);
            this.groupBox3.TabIndex = 86;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "شماره باسکول";
            // 
            // chkListBascol
            // 
            this.chkListBascol.CheckOnClick = true;
            this.chkListBascol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkListBascol.FormattingEnabled = true;
            this.chkListBascol.Location = new System.Drawing.Point(3, 19);
            this.chkListBascol.Name = "chkListBascol";
            this.chkListBascol.Size = new System.Drawing.Size(114, 112);
            this.chkListBascol.TabIndex = 92;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEndDate.ChangeColorIfNotEmpty = true;
            this.txtEndDate.ChangeColorOnEnter = true;
            this.txtEndDate.Date = new System.DateTime(((long)(0)));
            this.txtEndDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtEndDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEndDate.InsertInDatesTable = true;
            this.txtEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtEndDate.Location = new System.Drawing.Point(15, 51);
            this.txtEndDate.Mask = "0000/00/00";
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.NotEmpty = false;
            this.txtEndDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtEndDate.Size = new System.Drawing.Size(100, 23);
            this.txtEndDate.TabIndex = 77;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 54);
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
            this.txtDate.Location = new System.Drawing.Point(15, 22);
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
            this.label2.Location = new System.Drawing.Point(121, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 74;
            this.label2.Text = "تاریخ شروع:";
            // 
            // v
            // 
            this.v.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.v.Controls.Add(this.chkNotConfirm);
            this.v.Controls.Add(this.chkDelGhabz);
            this.v.Controls.Add(this.rbReportC);
            this.v.Controls.Add(this.rbBedehi);
            this.v.Location = new System.Drawing.Point(752, 19);
            this.v.Name = "v";
            this.v.Size = new System.Drawing.Size(163, 138);
            this.v.TabIndex = 0;
            this.v.TabStop = false;
            // 
            // chkNotConfirm
            // 
            this.chkNotConfirm.AutoSize = true;
            this.chkNotConfirm.Location = new System.Drawing.Point(20, 100);
            this.chkNotConfirm.Name = "chkNotConfirm";
            this.chkNotConfirm.Size = new System.Drawing.Size(128, 20);
            this.chkNotConfirm.TabIndex = 3;
            this.chkNotConfirm.Text = "فقط تائید نشده ها";
            this.chkNotConfirm.UseVisualStyleBackColor = true;
            // 
            // chkDelGhabz
            // 
            this.chkDelGhabz.AutoSize = true;
            this.chkDelGhabz.Location = new System.Drawing.Point(29, 74);
            this.chkDelGhabz.Name = "chkDelGhabz";
            this.chkDelGhabz.Size = new System.Drawing.Size(119, 20);
            this.chkDelGhabz.TabIndex = 2;
            this.chkDelGhabz.Text = "قبوض حذف شده";
            this.chkDelGhabz.UseVisualStyleBackColor = true;
            // 
            // rbReportC
            // 
            this.rbReportC.AutoSize = true;
            this.rbReportC.Checked = true;
            this.rbReportC.Location = new System.Drawing.Point(57, 48);
            this.rbReportC.Name = "rbReportC";
            this.rbReportC.Size = new System.Drawing.Size(91, 20);
            this.rbReportC.TabIndex = 1;
            this.rbReportC.TabStop = true;
            this.rbReportC.Text = "گزارش کامل";
            this.rbReportC.UseVisualStyleBackColor = true;
            // 
            // rbBedehi
            // 
            this.rbBedehi.AutoSize = true;
            this.rbBedehi.Location = new System.Drawing.Point(33, 22);
            this.rbBedehi.Name = "rbBedehi";
            this.rbBedehi.Size = new System.Drawing.Size(115, 20);
            this.rbBedehi.TabIndex = 0;
            this.rbBedehi.Text = "گزارش بدهی ها";
            this.rbBedehi.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnReturnConfirm);
            this.groupBox7.Controls.Add(this.lblTotalDuty);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.lblTotalTax);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.lblTotalPay_h);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.lblTotalPay);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.btnConfirmPay);
            this.groupBox7.Controls.Add(this.btnback_del);
            this.groupBox7.Controls.Add(this.btndel);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox7.Location = new System.Drawing.Point(0, 577);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(918, 86);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            // 
            // btnReturnConfirm
            // 
            this.btnReturnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReturnConfirm.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnConfirm.Location = new System.Drawing.Point(745, 51);
            this.btnReturnConfirm.Name = "btnReturnConfirm";
            this.btnReturnConfirm.Size = new System.Drawing.Size(140, 32);
            this.btnReturnConfirm.TabIndex = 30;
            this.btnReturnConfirm.Text = " برگشت تایید پرداخت";
            this.btnReturnConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnReturnConfirm.UseVisualStyleBackColor = true;
            this.btnReturnConfirm.Click += new System.EventHandler(this.btnReturnConfirm_Click);
            // 
            // lblTotalDuty
            // 
            this.lblTotalDuty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalDuty.AutoSize = true;
            this.lblTotalDuty.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTotalDuty.ForeColor = System.Drawing.Color.Red;
            this.lblTotalDuty.Location = new System.Drawing.Point(152, 53);
            this.lblTotalDuty.Name = "lblTotalDuty";
            this.lblTotalDuty.Size = new System.Drawing.Size(19, 19);
            this.lblTotalDuty.TabIndex = 29;
            this.lblTotalDuty.Text = "0";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(172, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "جمع عوارض :";
            // 
            // lblTotalTax
            // 
            this.lblTotalTax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalTax.AutoSize = true;
            this.lblTotalTax.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTotalTax.ForeColor = System.Drawing.Color.Red;
            this.lblTotalTax.Location = new System.Drawing.Point(154, 23);
            this.lblTotalTax.Name = "lblTotalTax";
            this.lblTotalTax.Size = new System.Drawing.Size(19, 19);
            this.lblTotalTax.TabIndex = 27;
            this.lblTotalTax.Text = "0";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(172, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 16);
            this.label8.TabIndex = 26;
            this.label8.Text = "جمع مالیات :";
            // 
            // lblTotalPay_h
            // 
            this.lblTotalPay_h.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPay_h.AutoSize = true;
            this.lblTotalPay_h.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTotalPay_h.ForeColor = System.Drawing.Color.Red;
            this.lblTotalPay_h.Location = new System.Drawing.Point(361, 50);
            this.lblTotalPay_h.Name = "lblTotalPay_h";
            this.lblTotalPay_h.Size = new System.Drawing.Size(19, 19);
            this.lblTotalPay_h.TabIndex = 25;
            this.lblTotalPay_h.Text = "0";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(382, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "جمع کل مبلغ پرداختی  :";
            // 
            // lblTotalPay
            // 
            this.lblTotalPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPay.AutoSize = true;
            this.lblTotalPay.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTotalPay.ForeColor = System.Drawing.Color.Red;
            this.lblTotalPay.Location = new System.Drawing.Point(361, 23);
            this.lblTotalPay.Name = "lblTotalPay";
            this.lblTotalPay.Size = new System.Drawing.Size(19, 19);
            this.lblTotalPay.TabIndex = 23;
            this.lblTotalPay.Text = "0";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(382, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "جمع کل مبلغ :";
            // 
            // btnConfirmPay
            // 
            this.btnConfirmPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmPay.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmPay.Location = new System.Drawing.Point(745, 16);
            this.btnConfirmPay.Name = "btnConfirmPay";
            this.btnConfirmPay.Size = new System.Drawing.Size(140, 32);
            this.btnConfirmPay.TabIndex = 19;
            this.btnConfirmPay.Text = "تایید پرداخت";
            this.btnConfirmPay.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnConfirmPay.UseVisualStyleBackColor = true;
            this.btnConfirmPay.Click += new System.EventHandler(this.btnConfirmPay_Click);
            // 
            // btnback_del
            // 
            this.btnback_del.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnback_del.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnback_del.Location = new System.Drawing.Point(598, 50);
            this.btnback_del.Name = "btnback_del";
            this.btnback_del.Size = new System.Drawing.Size(140, 32);
            this.btnback_del.TabIndex = 18;
            this.btnback_del.Text = "برگشت حذف";
            this.btnback_del.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnback_del.UseVisualStyleBackColor = true;
            this.btnback_del.Click += new System.EventHandler(this.btnback_del_Click);
            // 
            // btndel
            // 
            this.btndel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btndel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndel.Location = new System.Drawing.Point(598, 16);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(140, 32);
            this.btndel.TabIndex = 15;
            this.btndel.Text = "حذف توزین";
            this.btndel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btndel.UseVisualStyleBackColor = true;
            this.btndel.Click += new System.EventHandler(this.btndel_Click);
            // 
            // jJanusGrid1
            // 
            this.jJanusGrid1.ActionMenu = null;
            this.jJanusGrid1.DataSource = null;
            this.jJanusGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jJanusGrid1.Edited = false;
            this.jJanusGrid1.Location = new System.Drawing.Point(0, 160);
            this.jJanusGrid1.MultiSelect = false;
            this.jJanusGrid1.Name = "jJanusGrid1";
            this.jJanusGrid1.ShowNavigator = true;
            this.jJanusGrid1.ShowToolbar = true;
            this.jJanusGrid1.Size = new System.Drawing.Size(918, 417);
            this.jJanusGrid1.TabIndex = 3;
            // 
            // JReportManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 663);
            this.Controls.Add(this.jJanusGrid1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox1);
            this.Name = "JReportManagerForm";
            this.Text = "ReportManager";
            this.Load += new System.EventHandler(this.JReportManagerForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.v.ResumeLayout(false);
            this.v.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private ClassLibrary.DateEdit txtEndDate;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.DateEdit txtDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox v;
        private System.Windows.Forms.RadioButton rbReportC;
        private System.Windows.Forms.RadioButton rbBedehi;
        private System.Windows.Forms.GroupBox groupBox7;
        private ClassLibrary.JJanusGrid jJanusGrid1;
        private System.Windows.Forms.Button btnConfirmPay;
        private System.Windows.Forms.Button btnback_del;
        private System.Windows.Forms.Button btndel;
        private System.Windows.Forms.CheckedListBox chklistTozin;
        private System.Windows.Forms.CheckedListBox chklistUsers;
        private System.Windows.Forms.CheckedListBox chklistTrucks;
        private System.Windows.Forms.CheckedListBox chkListBascol;
        private System.Windows.Forms.CheckBox chkDelGhabz;
        private System.Windows.Forms.CheckBox chkNotConfirm;
        private System.Windows.Forms.Label lblTotalPay_h;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalPay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalDuty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalTax;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnReturnConfirm;
        private System.Windows.Forms.ListBox listUsers;
    }
}