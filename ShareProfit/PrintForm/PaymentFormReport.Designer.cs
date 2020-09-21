namespace ShareProfit
{
    partial class JPaymentFormReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JPaymentFormReport));
            this.rbBoth = new System.Windows.Forms.RadioButton();
            this.rbUnPayed = new System.Windows.Forms.RadioButton();
            this.rbPayed = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.chAllCourses = new System.Windows.Forms.CheckBox();
            this.chListCourses = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPCode = new ClassLibrary.NumEdit();
            this.txtFromSheet = new ClassLibrary.NumEdit();
            this.txtToSheet = new ClassLibrary.NumEdit();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbCity = new ClassLibrary.JCodingBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbPayLoc = new ClassLibrary.JCodingBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.Images.SetKeyName(0, "aktion.png");
            this.imageList.Images.SetKeyName(1, "alert.png");
            this.imageList.Images.SetKeyName(2, "All software is current.png");
            this.imageList.Images.SetKeyName(3, "amor.png");
            this.imageList.Images.SetKeyName(4, "antivirus.png");
            this.imageList.Images.SetKeyName(5, "applixware.png");
            this.imageList.Images.SetKeyName(6, "ark.png");
            this.imageList.Images.SetKeyName(7, "arts.png");
            // 
            // rbBoth
            // 
            this.rbBoth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbBoth.AutoSize = true;
            this.rbBoth.Location = new System.Drawing.Point(543, 74);
            this.rbBoth.Name = "rbBoth";
            this.rbBoth.Size = new System.Drawing.Size(51, 20);
            this.rbBoth.TabIndex = 2;
            this.rbBoth.Text = "Both";
            this.rbBoth.UseVisualStyleBackColor = true;
            // 
            // rbUnPayed
            // 
            this.rbUnPayed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbUnPayed.AutoSize = true;
            this.rbUnPayed.Checked = true;
            this.rbUnPayed.Location = new System.Drawing.Point(519, 48);
            this.rbUnPayed.Name = "rbUnPayed";
            this.rbUnPayed.Size = new System.Drawing.Size(75, 20);
            this.rbUnPayed.TabIndex = 1;
            this.rbUnPayed.TabStop = true;
            this.rbUnPayed.Text = "UnPayed";
            this.rbUnPayed.UseVisualStyleBackColor = true;
            // 
            // rbPayed
            // 
            this.rbPayed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbPayed.AutoSize = true;
            this.rbPayed.Location = new System.Drawing.Point(534, 22);
            this.rbPayed.Name = "rbPayed";
            this.rbPayed.Size = new System.Drawing.Size(60, 20);
            this.rbPayed.TabIndex = 0;
            this.rbPayed.Text = "Payed";
            this.rbPayed.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(474, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 16);
            this.label5.TabIndex = 36;
            this.label5.Text = "HomeCityName:";
            // 
            // chAllCourses
            // 
            this.chAllCourses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chAllCourses.AutoSize = true;
            this.chAllCourses.Location = new System.Drawing.Point(533, 22);
            this.chAllCourses.Name = "chAllCourses";
            this.chAllCourses.Size = new System.Drawing.Size(87, 20);
            this.chAllCourses.TabIndex = 0;
            this.chAllCourses.Text = "AllCourses";
            this.chAllCourses.UseVisualStyleBackColor = true;
            this.chAllCourses.CheckedChanged += new System.EventHandler(this.chAllCourses_CheckedChanged);
            // 
            // chListCourses
            // 
            this.chListCourses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chListCourses.CheckOnClick = true;
            this.chListCourses.FormattingEnabled = true;
            this.chListCourses.Location = new System.Drawing.Point(80, 47);
            this.chListCourses.Name = "chListCourses";
            this.chListCourses.Size = new System.Drawing.Size(540, 94);
            this.chListCourses.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(383, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 16);
            this.label4.TabIndex = 35;
            this.label4.Text = "ManagementsharesHolderCode:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(513, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 37;
            this.label1.Text = "SheetNo:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(383, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 38;
            this.label2.Text = "From:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 16);
            this.label3.TabIndex = 39;
            this.label3.Text = "To:";
            // 
            // txtPCode
            // 
            this.txtPCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPCode.ChangeColorIfNotEmpty = true;
            this.txtPCode.ChangeColorOnEnter = true;
            this.txtPCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPCode.Location = new System.Drawing.Point(326, 16);
            this.txtPCode.Name = "txtPCode";
            this.txtPCode.Negative = true;
            this.txtPCode.NotEmpty = false;
            this.txtPCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPCode.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtPCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPCode.SelectOnEnter = true;
            this.txtPCode.Size = new System.Drawing.Size(100, 23);
            this.txtPCode.TabIndex = 0;
            this.txtPCode.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtFromSheet
            // 
            this.txtFromSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromSheet.ChangeColorIfNotEmpty = true;
            this.txtFromSheet.ChangeColorOnEnter = true;
            this.txtFromSheet.InBackColor = System.Drawing.SystemColors.Info;
            this.txtFromSheet.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFromSheet.Location = new System.Drawing.Point(277, 91);
            this.txtFromSheet.Name = "txtFromSheet";
            this.txtFromSheet.Negative = true;
            this.txtFromSheet.NotEmpty = false;
            this.txtFromSheet.NotEmptyColor = System.Drawing.Color.Red;
            this.txtFromSheet.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtFromSheet.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFromSheet.SelectOnEnter = true;
            this.txtFromSheet.Size = new System.Drawing.Size(100, 23);
            this.txtFromSheet.TabIndex = 2;
            this.txtFromSheet.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtToSheet
            // 
            this.txtToSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToSheet.ChangeColorIfNotEmpty = true;
            this.txtToSheet.ChangeColorOnEnter = true;
            this.txtToSheet.InBackColor = System.Drawing.SystemColors.Info;
            this.txtToSheet.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtToSheet.Location = new System.Drawing.Point(133, 91);
            this.txtToSheet.Name = "txtToSheet";
            this.txtToSheet.Negative = true;
            this.txtToSheet.NotEmpty = false;
            this.txtToSheet.NotEmptyColor = System.Drawing.Color.Red;
            this.txtToSheet.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtToSheet.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtToSheet.SelectOnEnter = true;
            this.txtToSheet.Size = new System.Drawing.Size(100, 23);
            this.txtToSheet.TabIndex = 3;
            this.txtToSheet.TextMode = ClassLibrary.TextModes.Text;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(593, 422);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 32);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbCity
            // 
            this.cmbCity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCity.dataTable = null;
            this.cmbCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbCity.Location = new System.Drawing.Point(133, 49);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.SelectedIndex = -1;
            this.cmbCity.SelectedValue = null;
            this.cmbCity.Size = new System.Drawing.Size(293, 27);
            this.cmbCity.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 412);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 47;
            this.label6.Text = "PayLoc:";
            this.label6.Visible = false;
            // 
            // cmbPayLoc
            // 
            this.cmbPayLoc.dataTable = null;
            this.cmbPayLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbPayLoc.Location = new System.Drawing.Point(91, 403);
            this.cmbPayLoc.Name = "cmbPayLoc";
            this.cmbPayLoc.SelectedIndex = -1;
            this.cmbPayLoc.SelectedValue = null;
            this.cmbPayLoc.Size = new System.Drawing.Size(293, 27);
            this.cmbPayLoc.TabIndex = 0;
            this.cmbPayLoc.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbCity);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPCode);
            this.groupBox1.Controls.Add(this.txtFromSheet);
            this.groupBox1.Controls.Add(this.txtToSheet);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(685, 134);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "مشخصات سهامداران";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.rbBoth);
            this.groupBox2.Controls.Add(this.rbPayed);
            this.groupBox2.Controls.Add(this.rbUnPayed);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(685, 100);
            this.groupBox2.TabIndex = 51;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "پرداخت سود";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(54, 26);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.Size = new System.Drawing.Size(290, 68);
            this.textBox1.TabIndex = 3;
            this.textBox1.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chAllCourses);
            this.groupBox3.Controls.Add(this.chListCourses);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 234);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(685, 153);
            this.groupBox3.TabIndex = 52;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "دوره پرداخت سود";
            // 
            // PaymentFormReport
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 474);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmbPayLoc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.groupBox1);
            this.Name = "PaymentFormReport";
            this.Text = "PrintPaymentForm";
            this.Load += new System.EventHandler(this.PaymentFormReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbBoth;
        private System.Windows.Forms.RadioButton rbUnPayed;
        private System.Windows.Forms.RadioButton rbPayed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chAllCourses;
        private System.Windows.Forms.CheckedListBox chListCourses;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.NumEdit txtPCode;
        private ClassLibrary.NumEdit txtFromSheet;
        private ClassLibrary.NumEdit txtToSheet;
        private System.Windows.Forms.Button btnSearch;
        private ClassLibrary.JCodingBox cmbCity;
        private System.Windows.Forms.Label label6;
        private ClassLibrary.JCodingBox cmbPayLoc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox1;
    }
}