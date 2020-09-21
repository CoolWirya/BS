namespace Bascol
{
    partial class JWeightForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JWeightForm));
            this.label1 = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lsTrucks = new System.Windows.Forms.ListBox();
            this.btnPrint2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnChangePrice = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnHamgam = new System.Windows.Forms.Button();
            this.btnKhales = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBlackList = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnSabt = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lblDay = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.cmbTruck = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.txtPlak3 = new System.Windows.Forms.TextBox();
            this.txtPlak1 = new System.Windows.Forms.TextBox();
            this.txtPlak2 = new System.Windows.Forms.TextBox();
            this.cmbPlak = new System.Windows.Forms.ComboBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblBedehkariName = new System.Windows.Forms.Label();
            this.lblBascolNum = new System.Windows.Forms.Label();
            this.txtHamrah = new ClassLibrary.TextEdit(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBedehkari = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPay = new ClassLibrary.TextEdit(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.com = new System.IO.Ports.SerialPort(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Name = "label1";
            // 
            // lblWeight
            // 
            resources.ApplyResources(this.lblWeight, "lblWeight");
            this.lblWeight.ForeColor = System.Drawing.Color.Black;
            this.lblWeight.Name = "lblWeight";
            // 
            // lsTrucks
            // 
            resources.ApplyResources(this.lsTrucks, "lsTrucks");
            this.lsTrucks.FormattingEnabled = true;
            this.lsTrucks.Name = "lsTrucks";
            this.lsTrucks.SelectedIndexChanged += new System.EventHandler(this.lsTrucks_SelectedIndexChanged);
            this.lsTrucks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsTrucks_KeyDown);
            // 
            // btnPrint2
            // 
            resources.ApplyResources(this.btnPrint2, "btnPrint2");
            this.btnPrint2.Name = "btnPrint2";
            this.btnPrint2.UseVisualStyleBackColor = true;
            this.btnPrint2.Click += new System.EventHandler(this.btnPrint2_Click);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label6.Name = "label6";
            // 
            // btnChangePrice
            // 
            resources.ApplyResources(this.btnChangePrice, "btnChangePrice");
            this.btnChangePrice.Name = "btnChangePrice";
            this.btnChangePrice.UseVisualStyleBackColor = true;
            this.btnChangePrice.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 900;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnHamgam
            // 
            resources.ApplyResources(this.btnHamgam, "btnHamgam");
            this.btnHamgam.Name = "btnHamgam";
            this.btnHamgam.UseVisualStyleBackColor = true;
            this.btnHamgam.Click += new System.EventHandler(this.btnHamgam_Click);
            // 
            // btnKhales
            // 
            resources.ApplyResources(this.btnKhales, "btnKhales");
            this.btnKhales.Name = "btnKhales";
            this.btnKhales.UseVisualStyleBackColor = true;
            this.btnKhales.Click += new System.EventHandler(this.btnKhales_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(209)))), ((int)(((byte)(231)))));
            this.groupBox2.Controls.Add(this.btnBlackList);
            this.groupBox2.Controls.Add(this.btnReport);
            this.groupBox2.Controls.Add(this.btnSabt);
            this.groupBox2.Controls.Add(this.btnChangePrice);
            this.groupBox2.Controls.Add(this.btnKhales);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Controls.Add(this.btnHamgam);
            this.groupBox2.Controls.Add(this.btnPrint2);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // btnBlackList
            // 
            resources.ApplyResources(this.btnBlackList, "btnBlackList");
            this.btnBlackList.Name = "btnBlackList";
            this.btnBlackList.UseVisualStyleBackColor = true;
            this.btnBlackList.Click += new System.EventHandler(this.btnBlackList_Click);
            // 
            // btnReport
            // 
            resources.ApplyResources(this.btnReport, "btnReport");
            this.btnReport.Name = "btnReport";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnSabt
            // 
            resources.ApplyResources(this.btnSabt, "btnSabt");
            this.btnSabt.Name = "btnSabt";
            this.btnSabt.UseVisualStyleBackColor = true;
            this.btnSabt.Click += new System.EventHandler(this.btnSabt_Click);
            this.btnSabt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnSabt_KeyDown);
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.lblWeight);
            this.groupBox3.Controls.Add(this.label6);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lsTrucks);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(209)))), ((int)(((byte)(231)))));
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.lblDay);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblB);
            this.groupBox1.Controls.Add(this.cmbTruck);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbProduct);
            this.groupBox1.Controls.Add(this.txtPlak3);
            this.groupBox1.Controls.Add(this.txtPlak1);
            this.groupBox1.Controls.Add(this.txtPlak2);
            this.groupBox1.Controls.Add(this.cmbPlak);
            this.groupBox1.Controls.Add(this.lblTime);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.lblUserName);
            this.groupBox1.Controls.Add(this.lblBedehkariName);
            this.groupBox1.Controls.Add(this.lblBascolNum);
            this.groupBox1.Controls.Add(this.txtHamrah);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblBedehkari);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtPay);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.ForeColor = System.Drawing.Color.Red;
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
            // 
            // lblDay
            // 
            resources.ApplyResources(this.lblDay, "lblDay");
            this.lblDay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblDay.Name = "lblDay";
            // 
            // groupBox5
            // 
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Name = "label7";
            // 
            // lblB
            // 
            resources.ApplyResources(this.lblB, "lblB");
            this.lblB.ForeColor = System.Drawing.Color.Red;
            this.lblB.Name = "lblB";
            // 
            // cmbTruck
            // 
            resources.ApplyResources(this.cmbTruck, "cmbTruck");
            this.cmbTruck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTruck.FormattingEnabled = true;
            this.cmbTruck.Items.AddRange(new object[] {
            resources.GetString("cmbTruck.Items"),
            resources.GetString("cmbTruck.Items1"),
            resources.GetString("cmbTruck.Items2"),
            resources.GetString("cmbTruck.Items3"),
            resources.GetString("cmbTruck.Items4"),
            resources.GetString("cmbTruck.Items5"),
            resources.GetString("cmbTruck.Items6"),
            resources.GetString("cmbTruck.Items7"),
            resources.GetString("cmbTruck.Items8"),
            resources.GetString("cmbTruck.Items9"),
            resources.GetString("cmbTruck.Items10"),
            resources.GetString("cmbTruck.Items11"),
            resources.GetString("cmbTruck.Items12"),
            resources.GetString("cmbTruck.Items13"),
            resources.GetString("cmbTruck.Items14"),
            resources.GetString("cmbTruck.Items15"),
            resources.GetString("cmbTruck.Items16"),
            resources.GetString("cmbTruck.Items17"),
            resources.GetString("cmbTruck.Items18"),
            resources.GetString("cmbTruck.Items19"),
            resources.GetString("cmbTruck.Items20"),
            resources.GetString("cmbTruck.Items21"),
            resources.GetString("cmbTruck.Items22"),
            resources.GetString("cmbTruck.Items23"),
            resources.GetString("cmbTruck.Items24"),
            resources.GetString("cmbTruck.Items25"),
            resources.GetString("cmbTruck.Items26"),
            resources.GetString("cmbTruck.Items27"),
            resources.GetString("cmbTruck.Items28"),
            resources.GetString("cmbTruck.Items29"),
            resources.GetString("cmbTruck.Items30"),
            resources.GetString("cmbTruck.Items31")});
            this.cmbTruck.Name = "cmbTruck";
            this.cmbTruck.SelectedIndexChanged += new System.EventHandler(this.cmbTruck_SelectedIndexChanged);
            this.cmbTruck.Leave += new System.EventHandler(this.cmbTruck_Leave);
            this.cmbTruck.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbTruck_KeyDown);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // cmbProduct
            // 
            resources.ApplyResources(this.cmbProduct, "cmbProduct");
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Items.AddRange(new object[] {
            resources.GetString("cmbProduct.Items"),
            resources.GetString("cmbProduct.Items1"),
            resources.GetString("cmbProduct.Items2"),
            resources.GetString("cmbProduct.Items3"),
            resources.GetString("cmbProduct.Items4"),
            resources.GetString("cmbProduct.Items5"),
            resources.GetString("cmbProduct.Items6"),
            resources.GetString("cmbProduct.Items7"),
            resources.GetString("cmbProduct.Items8"),
            resources.GetString("cmbProduct.Items9"),
            resources.GetString("cmbProduct.Items10"),
            resources.GetString("cmbProduct.Items11"),
            resources.GetString("cmbProduct.Items12"),
            resources.GetString("cmbProduct.Items13"),
            resources.GetString("cmbProduct.Items14"),
            resources.GetString("cmbProduct.Items15"),
            resources.GetString("cmbProduct.Items16"),
            resources.GetString("cmbProduct.Items17"),
            resources.GetString("cmbProduct.Items18"),
            resources.GetString("cmbProduct.Items19"),
            resources.GetString("cmbProduct.Items20"),
            resources.GetString("cmbProduct.Items21"),
            resources.GetString("cmbProduct.Items22"),
            resources.GetString("cmbProduct.Items23"),
            resources.GetString("cmbProduct.Items24"),
            resources.GetString("cmbProduct.Items25"),
            resources.GetString("cmbProduct.Items26"),
            resources.GetString("cmbProduct.Items27"),
            resources.GetString("cmbProduct.Items28"),
            resources.GetString("cmbProduct.Items29"),
            resources.GetString("cmbProduct.Items30"),
            resources.GetString("cmbProduct.Items31")});
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbProduct_KeyDown);
            // 
            // txtPlak3
            // 
            resources.ApplyResources(this.txtPlak3, "txtPlak3");
            this.txtPlak3.Name = "txtPlak3";
            this.txtPlak3.TextChanged += new System.EventHandler(this.txtPlak3_TextChanged);
            this.txtPlak3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPlak3_KeyDown);
            // 
            // txtPlak1
            // 
            resources.ApplyResources(this.txtPlak1, "txtPlak1");
            this.txtPlak1.Name = "txtPlak1";
            this.txtPlak1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPlak1_KeyDown);
            // 
            // txtPlak2
            // 
            resources.ApplyResources(this.txtPlak2, "txtPlak2");
            this.txtPlak2.Name = "txtPlak2";
            this.txtPlak2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPlak2_KeyDown);
            // 
            // cmbPlak
            // 
            resources.ApplyResources(this.cmbPlak, "cmbPlak");
            this.cmbPlak.DisplayMember = "21";
            this.cmbPlak.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlak.FormattingEnabled = true;
            this.cmbPlak.Items.AddRange(new object[] {
            resources.GetString("cmbPlak.Items"),
            resources.GetString("cmbPlak.Items1"),
            resources.GetString("cmbPlak.Items2"),
            resources.GetString("cmbPlak.Items3"),
            resources.GetString("cmbPlak.Items4"),
            resources.GetString("cmbPlak.Items5"),
            resources.GetString("cmbPlak.Items6"),
            resources.GetString("cmbPlak.Items7"),
            resources.GetString("cmbPlak.Items8"),
            resources.GetString("cmbPlak.Items9"),
            resources.GetString("cmbPlak.Items10"),
            resources.GetString("cmbPlak.Items11"),
            resources.GetString("cmbPlak.Items12"),
            resources.GetString("cmbPlak.Items13"),
            resources.GetString("cmbPlak.Items14"),
            resources.GetString("cmbPlak.Items15"),
            resources.GetString("cmbPlak.Items16"),
            resources.GetString("cmbPlak.Items17"),
            resources.GetString("cmbPlak.Items18"),
            resources.GetString("cmbPlak.Items19"),
            resources.GetString("cmbPlak.Items20"),
            resources.GetString("cmbPlak.Items21"),
            resources.GetString("cmbPlak.Items22"),
            resources.GetString("cmbPlak.Items23"),
            resources.GetString("cmbPlak.Items24"),
            resources.GetString("cmbPlak.Items25"),
            resources.GetString("cmbPlak.Items26"),
            resources.GetString("cmbPlak.Items27"),
            resources.GetString("cmbPlak.Items28"),
            resources.GetString("cmbPlak.Items29"),
            resources.GetString("cmbPlak.Items30"),
            resources.GetString("cmbPlak.Items31")});
            this.cmbPlak.Name = "cmbPlak";
            this.cmbPlak.ValueMember = "21";
            this.cmbPlak.SelectedIndexChanged += new System.EventHandler(this.cmbPlak_SelectedIndexChanged);
            this.cmbPlak.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyDown);
            // 
            // lblTime
            // 
            resources.ApplyResources(this.lblTime, "lblTime");
            this.lblTime.Name = "lblTime";
            // 
            // lblDate
            // 
            resources.ApplyResources(this.lblDate, "lblDate");
            this.lblDate.Name = "lblDate";
            // 
            // lblUserName
            // 
            resources.ApplyResources(this.lblUserName, "lblUserName");
            this.lblUserName.ForeColor = System.Drawing.Color.Green;
            this.lblUserName.Name = "lblUserName";
            // 
            // lblBedehkariName
            // 
            resources.ApplyResources(this.lblBedehkariName, "lblBedehkariName");
            this.lblBedehkariName.ForeColor = System.Drawing.Color.Red;
            this.lblBedehkariName.Name = "lblBedehkariName";
            // 
            // lblBascolNum
            // 
            resources.ApplyResources(this.lblBascolNum, "lblBascolNum");
            this.lblBascolNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblBascolNum.Name = "lblBascolNum";
            // 
            // txtHamrah
            // 
            resources.ApplyResources(this.txtHamrah, "txtHamrah");
            this.txtHamrah.ChangeColorIfNotEmpty = false;
            this.txtHamrah.ChangeColorOnEnter = true;
            this.txtHamrah.InBackColor = System.Drawing.SystemColors.Info;
            this.txtHamrah.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtHamrah.Name = "txtHamrah";
            this.txtHamrah.Negative = true;
            this.txtHamrah.NotEmpty = false;
            this.txtHamrah.NotEmptyColor = System.Drawing.Color.Red;
            this.txtHamrah.SelectOnEnter = true;
            this.txtHamrah.TextMode = ClassLibrary.TextModes.Integer;
            this.txtHamrah.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHamrah_KeyDown);
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label13.Name = "label13";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lblBedehkari
            // 
            resources.ApplyResources(this.lblBedehkari, "lblBedehkari");
            this.lblBedehkari.ForeColor = System.Drawing.Color.Red;
            this.lblBedehkari.Name = "lblBedehkari";
            this.lblBedehkari.TextChanged += new System.EventHandler(this.lblBedehkari_TextChanged);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // txtPay
            // 
            resources.ApplyResources(this.txtPay, "txtPay");
            this.txtPay.ChangeColorIfNotEmpty = false;
            this.txtPay.ChangeColorOnEnter = true;
            this.txtPay.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPay.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPay.Name = "txtPay";
            this.txtPay.Negative = true;
            this.txtPay.NotEmpty = false;
            this.txtPay.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPay.SelectOnEnter = true;
            this.txtPay.TextMode = ClassLibrary.TextModes.Integer;
            this.txtPay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPay_KeyDown);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // com
            // 
            this.com.DtrEnable = true;
            this.com.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.com_DataReceived);
            // 
            // JWeightForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.MaximizeBox = false;
            this.Name = "JWeightForm";
            this.Load += new System.EventHandler(this.JWeightForm_Load);
            this.Shown += new System.EventHandler(this.JWeightForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JWeightForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.JWeightForm_KeyDown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.ListBox lsTrucks;
        private System.Windows.Forms.Button btnSabt;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPrint2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnChangePrice;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnHamgam;
        private System.Windows.Forms.Button btnKhales;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblBascolNum;
        private ClassLibrary.TextEdit txtHamrah;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBedehkari;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private ClassLibrary.TextEdit txtPay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblBedehkariName;
        private System.IO.Ports.SerialPort com;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.ComboBox cmbPlak;
        private System.Windows.Forms.TextBox txtPlak2;
        private System.Windows.Forms.TextBox txtPlak3;
        private System.Windows.Forms.TextBox txtPlak1;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.ComboBox cmbTruck;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnBlackList;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}