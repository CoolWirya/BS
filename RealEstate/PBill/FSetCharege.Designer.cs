namespace RealEstate
{
    partial class FSetCharege
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
            ClassLibrary.JPopupMenu jPopupMenu2 = new ClassLibrary.JPopupMenu();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.grdGhabz = new ClassLibrary.JDataGrid();
            this.BtnChangeCharge = new System.Windows.Forms.Button();
            this.txtCureentbill = new ClassLibrary.TextEdit(this.components);
            this.label40 = new System.Windows.Forms.Label();
            this.txtYearbill = new ClassLibrary.TextEdit(this.components);
            this.label39 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtfirst = new ClassLibrary.TextEdit(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBadahi = new ClassLibrary.TextEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtTafsili = new ClassLibrary.TextEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtYaraneh = new ClassLibrary.TextEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txthint = new ClassLibrary.TextEdit(this.components);
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGhabz)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.grdGhabz);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(735, 549);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "تاريخچه صدور قبض";
            // 
            // grdGhabz
            // 
            this.grdGhabz.ActionMenu = jPopupMenu2;
            this.grdGhabz.AllowUserToAddRows = false;
            this.grdGhabz.AllowUserToDeleteRows = false;
            this.grdGhabz.AllowUserToOrderColumns = true;
            this.grdGhabz.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdGhabz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdGhabz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdGhabz.EnableContexMenu = true;
            this.grdGhabz.KeyName = null;
            this.grdGhabz.Location = new System.Drawing.Point(3, 20);
            this.grdGhabz.Name = "grdGhabz";
            this.grdGhabz.ReadHeadersFromDB = false;
            this.grdGhabz.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.grdGhabz.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdGhabz.ShowRowNumber = true;
            this.grdGhabz.Size = new System.Drawing.Size(729, 525);
            this.grdGhabz.TabIndex = 4;
            this.grdGhabz.TableName = null;
            this.grdGhabz.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdGhabz_CellContentClick);
            // 
            // BtnChangeCharge
            // 
            this.BtnChangeCharge.Location = new System.Drawing.Point(3, 120);
            this.BtnChangeCharge.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnChangeCharge.Name = "BtnChangeCharge";
            this.BtnChangeCharge.Size = new System.Drawing.Size(103, 63);
            this.BtnChangeCharge.TabIndex = 13;
            this.BtnChangeCharge.Text = "تغيير";
            this.BtnChangeCharge.UseVisualStyleBackColor = true;
            this.BtnChangeCharge.Click += new System.EventHandler(this.BtnChangeCharge_Click);
            // 
            // txtCureentbill
            // 
            this.txtCureentbill.ChangeColorIfNotEmpty = false;
            this.txtCureentbill.ChangeColorOnEnter = true;
            this.txtCureentbill.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCureentbill.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCureentbill.Location = new System.Drawing.Point(485, 86);
            this.txtCureentbill.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCureentbill.MaxLength = 10;
            this.txtCureentbill.Name = "txtCureentbill";
            this.txtCureentbill.Negative = true;
            this.txtCureentbill.NotEmpty = false;
            this.txtCureentbill.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCureentbill.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCureentbill.SelectOnEnter = true;
            this.txtCureentbill.Size = new System.Drawing.Size(123, 23);
            this.txtCureentbill.TabIndex = 10;
            this.txtCureentbill.TextMode = ClassLibrary.TextModes.Money;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(615, 89);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(117, 16);
            this.label40.TabIndex = 9;
            this.label40.Text = "شارژ قابل پرداخت  :";
            // 
            // txtYearbill
            // 
            this.txtYearbill.ChangeColorIfNotEmpty = false;
            this.txtYearbill.ChangeColorOnEnter = true;
            this.txtYearbill.InBackColor = System.Drawing.SystemColors.Info;
            this.txtYearbill.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtYearbill.Location = new System.Drawing.Point(485, 41);
            this.txtYearbill.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtYearbill.MaxLength = 10;
            this.txtYearbill.Name = "txtYearbill";
            this.txtYearbill.Negative = true;
            this.txtYearbill.NotEmpty = false;
            this.txtYearbill.NotEmptyColor = System.Drawing.Color.Red;
            this.txtYearbill.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtYearbill.SelectOnEnter = true;
            this.txtYearbill.Size = new System.Drawing.Size(123, 23);
            this.txtYearbill.TabIndex = 8;
            this.txtYearbill.TextMode = ClassLibrary.TextModes.Money;
            this.txtYearbill.TextChanged += new System.EventHandler(this.txtYearbill_TextChanged);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(369, 44);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(84, 16);
            this.label39.TabIndex = 7;
            this.label39.Text = "شارژ سالانه :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(633, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "مبلغ شارژ اصلي";
            // 
            // txtfirst
            // 
            this.txtfirst.ChangeColorIfNotEmpty = false;
            this.txtfirst.ChangeColorOnEnter = true;
            this.txtfirst.InBackColor = System.Drawing.SystemColors.Info;
            this.txtfirst.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtfirst.Location = new System.Drawing.Point(205, 41);
            this.txtfirst.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtfirst.MaxLength = 10;
            this.txtfirst.Name = "txtfirst";
            this.txtfirst.Negative = true;
            this.txtfirst.NotEmpty = false;
            this.txtfirst.NotEmptyColor = System.Drawing.Color.Red;
            this.txtfirst.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtfirst.SelectOnEnter = true;
            this.txtfirst.Size = new System.Drawing.Size(123, 23);
            this.txtfirst.TabIndex = 15;
            this.txtfirst.Text = "0";
            this.txtfirst.TextMode = ClassLibrary.TextModes.Money;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txthint);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtYaraneh);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtBadahi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTafsili);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtfirst);
            this.groupBox1.Controls.Add(this.label39);
            this.groupBox1.Controls.Add(this.BtnChangeCharge);
            this.groupBox1.Controls.Add(this.txtYearbill);
            this.groupBox1.Controls.Add(this.label40);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCureentbill);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 549);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(735, 190);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اطلاعات پايه صدور قبض";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtBadahi
            // 
            this.txtBadahi.ChangeColorIfNotEmpty = false;
            this.txtBadahi.ChangeColorOnEnter = true;
            this.txtBadahi.InBackColor = System.Drawing.SystemColors.Info;
            this.txtBadahi.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBadahi.Location = new System.Drawing.Point(205, 85);
            this.txtBadahi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBadahi.MaxLength = 10;
            this.txtBadahi.Name = "txtBadahi";
            this.txtBadahi.Negative = true;
            this.txtBadahi.NotEmpty = false;
            this.txtBadahi.NotEmptyColor = System.Drawing.Color.Red;
            this.txtBadahi.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBadahi.SelectOnEnter = true;
            this.txtBadahi.Size = new System.Drawing.Size(123, 23);
            this.txtBadahi.TabIndex = 20;
            this.txtBadahi.Text = "0";
            this.txtBadahi.TextMode = ClassLibrary.TextModes.Money;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "كد تفصيلي :";
            // 
            // txtTafsili
            // 
            this.txtTafsili.ChangeColorIfNotEmpty = false;
            this.txtTafsili.ChangeColorOnEnter = true;
            this.txtTafsili.InBackColor = System.Drawing.SystemColors.Info;
            this.txtTafsili.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTafsili.Location = new System.Drawing.Point(12, 41);
            this.txtTafsili.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTafsili.MaxLength = 10;
            this.txtTafsili.Name = "txtTafsili";
            this.txtTafsili.Negative = true;
            this.txtTafsili.NotEmpty = false;
            this.txtTafsili.NotEmptyColor = System.Drawing.Color.Red;
            this.txtTafsili.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTafsili.SelectOnEnter = true;
            this.txtTafsili.Size = new System.Drawing.Size(94, 23);
            this.txtTafsili.TabIndex = 18;
            this.txtTafsili.Text = "0";
            this.txtTafsili.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(337, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "بدهي قبلي(شارژ):";
            // 
            // txtYaraneh
            // 
            this.txtYaraneh.ChangeColorIfNotEmpty = false;
            this.txtYaraneh.ChangeColorOnEnter = true;
            this.txtYaraneh.InBackColor = System.Drawing.SystemColors.Info;
            this.txtYaraneh.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtYaraneh.Location = new System.Drawing.Point(12, 86);
            this.txtYaraneh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtYaraneh.MaxLength = 10;
            this.txtYaraneh.Name = "txtYaraneh";
            this.txtYaraneh.Negative = true;
            this.txtYaraneh.NotEmpty = false;
            this.txtYaraneh.NotEmptyColor = System.Drawing.Color.Red;
            this.txtYaraneh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtYaraneh.SelectOnEnter = true;
            this.txtYaraneh.Size = new System.Drawing.Size(94, 23);
            this.txtYaraneh.TabIndex = 22;
            this.txtYaraneh.Text = "0";
            this.txtYaraneh.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(146, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "يارانه :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(657, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "توضيحات :";
            // 
            // txthint
            // 
            this.txthint.ChangeColorIfNotEmpty = false;
            this.txthint.ChangeColorOnEnter = true;
            this.txthint.InBackColor = System.Drawing.SystemColors.Info;
            this.txthint.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txthint.Location = new System.Drawing.Point(112, 120);
            this.txthint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txthint.MaxLength = 10;
            this.txthint.Multiline = true;
            this.txthint.Name = "txthint";
            this.txthint.Negative = true;
            this.txthint.NotEmpty = false;
            this.txthint.NotEmptyColor = System.Drawing.Color.Red;
            this.txthint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txthint.SelectOnEnter = true;
            this.txthint.Size = new System.Drawing.Size(496, 63);
            this.txthint.TabIndex = 24;
            this.txthint.Text = "0";
            this.txthint.TextMode = ClassLibrary.TextModes.Text;
            // 
            // FSetCharege
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 739);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FSetCharege";
            this.Text = "اطلاعات مالي واحدهاي تجاري";
            this.Load += new System.EventHandler(this.FSetCharege_Load);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGhabz)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button BtnChangeCharge;
        private ClassLibrary.TextEdit txtCureentbill;
        private System.Windows.Forms.Label label40;
        private ClassLibrary.TextEdit txtYearbill;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit txtfirst;
        private ClassLibrary.JDataGrid grdGhabz;
        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.TextEdit txtTafsili;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.TextEdit txtBadahi;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.TextEdit txthint;
        private System.Windows.Forms.Label label5;
        private ClassLibrary.TextEdit txtYaraneh;
        private System.Windows.Forms.Label label4;
    }
}