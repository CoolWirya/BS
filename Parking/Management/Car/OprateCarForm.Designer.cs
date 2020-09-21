namespace Parking
{
    partial class OprateCarForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkDefult = new System.Windows.Forms.CheckBox();
            this.cmbCarColor = new ClassLibrary.JComboBox(this.components);
            this.cmbTypeCar = new ClassLibrary.JComboBox(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtp4 = new ClassLibrary.TextEdit(this.components);
            this.txtp3 = new ClassLibrary.NumEdit();
            this.txtp2 = new ClassLibrary.TextEdit(this.components);
            this.txtp1 = new ClassLibrary.NumEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescription = new ClassLibrary.TextEdit(this.components);
            this.txtCarOwner = new ClassLibrary.TextEdit(this.components);
            this.label16 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ArchiveList = new ArchivedDocuments.JArchiveList();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.textEdit1 = new ClassLibrary.TextEdit(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnApplay = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.ArchiveList.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(613, 378);
            this.tabControl1.TabIndex = 55;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(605, 349);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "خودرو";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkDefult);
            this.groupBox2.Controls.Add(this.cmbCarColor);
            this.groupBox2.Controls.Add(this.cmbTypeCar);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Controls.Add(this.txtCarOwner);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(599, 340);
            this.groupBox2.TabIndex = 103;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "کارت پارکینگ";
            // 
            // chkDefult
            // 
            this.chkDefult.AutoSize = true;
            this.chkDefult.Checked = true;
            this.chkDefult.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDefult.Location = new System.Drawing.Point(474, 303);
            this.chkDefult.Name = "chkDefult";
            this.chkDefult.Size = new System.Drawing.Size(115, 20);
            this.chkDefult.TabIndex = 130;
            this.chkDefult.Text = "خودرو فعال كارت";
            this.chkDefult.UseVisualStyleBackColor = true;
            // 
            // cmbCarColor
            // 
            this.cmbCarColor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCarColor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCarColor.BaseCode = 0;
            this.cmbCarColor.ChangeColorIfNotEmpty = true;
            this.cmbCarColor.ChangeColorOnEnter = true;
            this.cmbCarColor.FormattingEnabled = true;
            this.cmbCarColor.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbCarColor.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCarColor.Location = new System.Drawing.Point(42, 35);
            this.cmbCarColor.Name = "cmbCarColor";
            this.cmbCarColor.NotEmpty = false;
            this.cmbCarColor.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbCarColor.SelectOnEnter = true;
            this.cmbCarColor.Size = new System.Drawing.Size(172, 24);
            this.cmbCarColor.TabIndex = 127;
            // 
            // cmbTypeCar
            // 
            this.cmbTypeCar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbTypeCar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTypeCar.BaseCode = 0;
            this.cmbTypeCar.ChangeColorIfNotEmpty = true;
            this.cmbTypeCar.ChangeColorOnEnter = true;
            this.cmbTypeCar.FormattingEnabled = true;
            this.cmbTypeCar.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbTypeCar.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbTypeCar.Location = new System.Drawing.Point(310, 35);
            this.cmbTypeCar.Name = "cmbTypeCar";
            this.cmbTypeCar.NotEmpty = false;
            this.cmbTypeCar.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbTypeCar.SelectOnEnter = true;
            this.cmbTypeCar.Size = new System.Drawing.Size(193, 24);
            this.cmbTypeCar.TabIndex = 126;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtp4);
            this.panel1.Controls.Add(this.txtp3);
            this.panel1.Controls.Add(this.txtp2);
            this.panel1.Controls.Add(this.txtp1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(162, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 52);
            this.panel1.TabIndex = 124;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label4.Location = new System.Drawing.Point(119, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 16);
            this.label4.TabIndex = 115;
            this.label4.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label3.Location = new System.Drawing.Point(119, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 16);
            this.label3.TabIndex = 115;
            this.label3.Text = "-";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(184, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 16);
            this.label13.TabIndex = 114;
            this.label13.Text = "مثال :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label12.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label12.Location = new System.Drawing.Point(136, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 16);
            this.label12.TabIndex = 113;
            this.label12.Text = "12";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label11.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label11.Location = new System.Drawing.Point(88, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 16);
            this.label11.TabIndex = 112;
            this.label11.Text = "541";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label10.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label10.Location = new System.Drawing.Point(57, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 16);
            this.label10.TabIndex = 111;
            this.label10.Text = "ط";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label9.Location = new System.Drawing.Point(21, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 16);
            this.label9.TabIndex = 110;
            this.label9.Text = "47";
            // 
            // txtp4
            // 
            this.txtp4.ChangeColorIfNotEmpty = false;
            this.txtp4.ChangeColorOnEnter = true;
            this.txtp4.InBackColor = System.Drawing.SystemColors.Info;
            this.txtp4.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtp4.Location = new System.Drawing.Point(133, 24);
            this.txtp4.MaxLength = 2;
            this.txtp4.Name = "txtp4";
            this.txtp4.Negative = true;
            this.txtp4.NotEmpty = false;
            this.txtp4.NotEmptyColor = System.Drawing.Color.Red;
            this.txtp4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtp4.SelectOnEnter = true;
            this.txtp4.Size = new System.Drawing.Size(29, 23);
            this.txtp4.TabIndex = 109;
            this.txtp4.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // txtp3
            // 
            this.txtp3.ChangeColorIfNotEmpty = false;
            this.txtp3.ChangeColorOnEnter = true;
            this.txtp3.InBackColor = System.Drawing.SystemColors.Info;
            this.txtp3.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtp3.Location = new System.Drawing.Point(85, 24);
            this.txtp3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtp3.MaxLength = 3;
            this.txtp3.Name = "txtp3";
            this.txtp3.Negative = true;
            this.txtp3.NotEmpty = false;
            this.txtp3.NotEmptyColor = System.Drawing.Color.Red;
            this.txtp3.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtp3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtp3.SelectOnEnter = true;
            this.txtp3.Size = new System.Drawing.Size(32, 23);
            this.txtp3.TabIndex = 108;
            this.txtp3.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // txtp2
            // 
            this.txtp2.ChangeColorIfNotEmpty = false;
            this.txtp2.ChangeColorOnEnter = true;
            this.txtp2.InBackColor = System.Drawing.SystemColors.Info;
            this.txtp2.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtp2.Location = new System.Drawing.Point(52, 24);
            this.txtp2.MaxLength = 1;
            this.txtp2.Name = "txtp2";
            this.txtp2.Negative = true;
            this.txtp2.NotEmpty = false;
            this.txtp2.NotEmptyColor = System.Drawing.Color.Red;
            this.txtp2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtp2.SelectOnEnter = true;
            this.txtp2.Size = new System.Drawing.Size(29, 23);
            this.txtp2.TabIndex = 107;
            this.txtp2.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtp1
            // 
            this.txtp1.ChangeColorIfNotEmpty = false;
            this.txtp1.ChangeColorOnEnter = true;
            this.txtp1.InBackColor = System.Drawing.SystemColors.Info;
            this.txtp1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtp1.Location = new System.Drawing.Point(16, 24);
            this.txtp1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtp1.MaxLength = 2;
            this.txtp1.Name = "txtp1";
            this.txtp1.Negative = true;
            this.txtp1.NotEmpty = false;
            this.txtp1.NotEmptyColor = System.Drawing.Color.Red;
            this.txtp1.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtp1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtp1.SelectOnEnter = true;
            this.txtp1.Size = new System.Drawing.Size(32, 23);
            this.txtp1.TabIndex = 105;
            this.txtp1.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(184, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 16);
            this.label7.TabIndex = 104;
            this.label7.Text = "پلاك :";
            // 
            // txtDescription
            // 
            this.txtDescription.ChangeColorIfNotEmpty = false;
            this.txtDescription.ChangeColorOnEnter = true;
            this.txtDescription.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDescription.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDescription.Location = new System.Drawing.Point(42, 206);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Negative = true;
            this.txtDescription.NotEmpty = false;
            this.txtDescription.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDescription.SelectOnEnter = true;
            this.txtDescription.Size = new System.Drawing.Size(450, 74);
            this.txtDescription.TabIndex = 123;
            this.txtDescription.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtCarOwner
            // 
            this.txtCarOwner.ChangeColorIfNotEmpty = false;
            this.txtCarOwner.ChangeColorOnEnter = true;
            this.txtCarOwner.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCarOwner.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCarOwner.Location = new System.Drawing.Point(43, 151);
            this.txtCarOwner.Name = "txtCarOwner";
            this.txtCarOwner.Negative = true;
            this.txtCarOwner.NotEmpty = false;
            this.txtCarOwner.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCarOwner.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCarOwner.SelectOnEnter = true;
            this.txtCarOwner.Size = new System.Drawing.Size(449, 23);
            this.txtCarOwner.TabIndex = 122;
            this.txtCarOwner.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(230, 38);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 16);
            this.label16.TabIndex = 120;
            this.label16.Text = "رنگ خودرو :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(523, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 16);
            this.label8.TabIndex = 106;
            this.label8.Text = "توضيحات :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(505, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 16);
            this.label6.TabIndex = 102;
            this.label6.Text = "صاحب خودرو :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(519, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 101;
            this.label5.Text = "نوع خودرو :";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ArchiveList);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(605, 349);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "تصاویر";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ArchiveList
            // 
            this.ArchiveList.AllowUserAddFile = true;
            this.ArchiveList.AllowUserAddFromArchive = true;
            this.ArchiveList.AllowUserAddImage = true;
            this.ArchiveList.AllowUserDeleteFile = true;
            this.ArchiveList.ClassName = "";
            this.ArchiveList.ClassNames = null;
            this.ArchiveList.Controls.Add(this.txtDesc);
            this.ArchiveList.Controls.Add(this.textEdit1);
            this.ArchiveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchiveList.EnabledChange = true;
            this.ArchiveList.Location = new System.Drawing.Point(3, 3);
            this.ArchiveList.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.ArchiveList.Name = "ArchiveList";
            this.ArchiveList.ObjectCode = 0;
            this.ArchiveList.ObjectCodes = null;
            this.ArchiveList.PlaceCode = 0;
            this.ArchiveList.Size = new System.Drawing.Size(599, 343);
            this.ArchiveList.SubjectCode = 0;
            this.ArchiveList.TabIndex = 2;
            // 
            // txtDesc
            // 
            this.txtDesc.BackColor = System.Drawing.SystemColors.Window;
            this.txtDesc.ChangeColorIfNotEmpty = true;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDesc.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(0, 23);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(3, 14, 3, 14);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(599, 23);
            this.txtDesc.TabIndex = 3;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // textEdit1
            // 
            this.textEdit1.BackColor = System.Drawing.SystemColors.Info;
            this.textEdit1.ChangeColorIfNotEmpty = true;
            this.textEdit1.ChangeColorOnEnter = true;
            this.textEdit1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textEdit1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textEdit1.InBackColor = System.Drawing.SystemColors.Info;
            this.textEdit1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.textEdit1.Location = new System.Drawing.Point(0, 0);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(3, 21, 3, 21);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Negative = true;
            this.textEdit1.NotEmpty = false;
            this.textEdit1.NotEmptyColor = System.Drawing.Color.Red;
            this.textEdit1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textEdit1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textEdit1.SelectOnEnter = true;
            this.textEdit1.Size = new System.Drawing.Size(599, 23);
            this.textEdit1.TabIndex = 3;
            this.textEdit1.TextMode = ClassLibrary.TextModes.Text;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(4, 385);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 30);
            this.btnSave.TabIndex = 56;
            this.btnSave.Text = "ثبت";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnApplay
            // 
            this.btnApplay.Location = new System.Drawing.Point(135, 385);
            this.btnApplay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnApplay.Name = "btnApplay";
            this.btnApplay.Size = new System.Drawing.Size(125, 30);
            this.btnApplay.TabIndex = 57;
            this.btnApplay.Text = "تاييد";
            this.btnApplay.UseVisualStyleBackColor = true;
            this.btnApplay.Click += new System.EventHandler(this.btnApplay_Click);
            // 
            // OprateCarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 428);
            this.Controls.Add(this.btnApplay);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "OprateCarForm";
            this.Text = "OprateCarForm";
            this.Load += new System.EventHandler(this.OprateCarForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ArchiveList.ResumeLayout(false);
            this.ArchiveList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkDefult;
        private ClassLibrary.JComboBox cmbCarColor;
        private ClassLibrary.JComboBox cmbTypeCar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private ClassLibrary.TextEdit txtp4;
        private ClassLibrary.NumEdit txtp3;
        private ClassLibrary.TextEdit txtp2;
        private ClassLibrary.NumEdit txtp1;
        private System.Windows.Forms.Label label7;
        private ClassLibrary.TextEdit txtDescription;
        private ClassLibrary.TextEdit txtCarOwner;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSave;
        private ArchivedDocuments.JArchiveList ArchiveList;
        private ClassLibrary.TextEdit txtDesc;
        private ClassLibrary.TextEdit textEdit1;
        private System.Windows.Forms.Button btnApplay;
    }
}