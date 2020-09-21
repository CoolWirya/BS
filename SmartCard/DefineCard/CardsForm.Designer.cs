namespace SmartCard
{
    partial class JCardsForm
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
            this.jPropertyValueUserControl1 = new Globals.Property.JPropertyValueUserControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.jucPerson1 = new ClassLibrary.JUCPerson();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRFID = new ClassLibrary.TextEdit(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.TxtCardCode = new ClassLibrary.NumEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRead = new System.Windows.Forms.Button();
            this.LblSerial = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.cmbCardType = new ClassLibrary.JComboBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cmbPassengerCardType = new ClassLibrary.JComboBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // jPropertyValueUserControl1
            // 
            this.jPropertyValueUserControl1.AutoScroll = true;
            this.jPropertyValueUserControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.jPropertyValueUserControl1.ClassName = null;
            this.jPropertyValueUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jPropertyValueUserControl1.Location = new System.Drawing.Point(3, 3);
            this.jPropertyValueUserControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jPropertyValueUserControl1.Name = "jPropertyValueUserControl1";
            this.jPropertyValueUserControl1.ObjectCode = -1;
            this.jPropertyValueUserControl1.Size = new System.Drawing.Size(525, 331);
            this.jPropertyValueUserControl1.TabIndex = 107;
            this.jPropertyValueUserControl1.ValueObjectCode = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.BtnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 386);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 37);
            this.panel1.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 7);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 27);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "خروج";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(308, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "چاپ";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(384, 7);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(70, 27);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "جدید";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Location = new System.Drawing.Point(460, 7);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(70, 27);
            this.BtnSave.TabIndex = 0;
            this.BtnSave.Text = "تایید";
            this.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(539, 386);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.jucPerson1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(531, 357);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "CardPerson";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // jucPerson1
            // 
            this.jucPerson1.Dock = System.Windows.Forms.DockStyle.Top;
            this.jucPerson1.FilterPerson = null;
            this.jucPerson1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.jucPerson1.LableGroup = null;
            this.jucPerson1.Location = new System.Drawing.Point(3, 182);
            this.jucPerson1.Name = "jucPerson1";
            this.jucPerson1.PersonType = ClassLibrary.JPersonTypes.None;
            this.jucPerson1.ReadOnly = false;
            this.jucPerson1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.jucPerson1.SearchOnCode = ClassLibrary.SearchOnCode.Code;
            this.jucPerson1.SelectedCode = 0;
            this.jucPerson1.Size = new System.Drawing.Size(525, 182);
            this.jucPerson1.TabIndex = 1;
            this.jucPerson1.TafsiliCode = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbPassengerCardType);
            this.groupBox1.Controls.Add(this.txtRFID);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.TxtCardCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnRead);
            this.groupBox1.Controls.Add(this.LblSerial);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkStatus);
            this.groupBox1.Controls.Add(this.cmbCardType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(525, 179);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtRFID
            // 
            this.txtRFID.ChangeColorIfNotEmpty = false;
            this.txtRFID.ChangeColorOnEnter = true;
            this.txtRFID.InBackColor = System.Drawing.SystemColors.Info;
            this.txtRFID.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRFID.Location = new System.Drawing.Point(61, 22);
            this.txtRFID.Name = "txtRFID";
            this.txtRFID.Negative = true;
            this.txtRFID.NotEmpty = false;
            this.txtRFID.NotEmptyColor = System.Drawing.Color.Red;
            this.txtRFID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRFID.SelectOnEnter = true;
            this.txtRFID.Size = new System.Drawing.Size(365, 23);
            this.txtRFID.TabIndex = 0;
            this.txtRFID.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(61, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 24);
            this.button2.TabIndex = 3;
            this.button2.Text = "انواع کارت اشخاص...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(8, 144);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(418, 23);
            this.txtDesc.TabIndex = 7;
            // 
            // TxtCardCode
            // 
            this.TxtCardCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtCardCode.ChangeColorIfNotEmpty = false;
            this.TxtCardCode.ChangeColorOnEnter = true;
            this.TxtCardCode.InBackColor = System.Drawing.SystemColors.Info;
            this.TxtCardCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtCardCode.Location = new System.Drawing.Point(199, 116);
            this.TxtCardCode.MaxLength = 9;
            this.TxtCardCode.Name = "TxtCardCode";
            this.TxtCardCode.Negative = true;
            this.TxtCardCode.NotEmpty = false;
            this.TxtCardCode.NotEmptyColor = System.Drawing.Color.Red;
            this.TxtCardCode.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.TxtCardCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtCardCode.SelectOnEnter = true;
            this.TxtCardCode.Size = new System.Drawing.Size(227, 23);
            this.TxtCardCode.TabIndex = 5;
            this.TxtCardCode.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(432, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 109;
            this.label2.Text = "توضیحات :";
            // 
            // btnRead
            // 
            this.btnRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRead.Location = new System.Drawing.Point(23, 22);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(32, 23);
            this.btnRead.TabIndex = 1;
            this.btnRead.Text = "*";
            this.btnRead.UseVisualStyleBackColor = true;
            // 
            // LblSerial
            // 
            this.LblSerial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblSerial.AutoSize = true;
            this.LblSerial.Location = new System.Drawing.Point(432, 27);
            this.LblSerial.Name = "LblSerial";
            this.LblSerial.Size = new System.Drawing.Size(74, 16);
            this.LblSerial.TabIndex = 96;
            this.LblSerial.Text = "RFID كارت :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(432, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 103;
            this.label1.Text = "نوع شخص:";
            // 
            // chkStatus
            // 
            this.chkStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkStatus.AutoSize = true;
            this.chkStatus.Checked = true;
            this.chkStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStatus.Location = new System.Drawing.Point(113, 118);
            this.chkStatus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(80, 20);
            this.chkStatus.TabIndex = 6;
            this.chkStatus.Text = "كارت فعال";
            this.chkStatus.UseVisualStyleBackColor = true;
            // 
            // cmbCardType
            // 
            this.cmbCardType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCardType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCardType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCardType.BaseCode = 0;
            this.cmbCardType.ChangeColorIfNotEmpty = true;
            this.cmbCardType.ChangeColorOnEnter = true;
            this.cmbCardType.FormattingEnabled = true;
            this.cmbCardType.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbCardType.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbCardType.Location = new System.Drawing.Point(199, 54);
            this.cmbCardType.Name = "cmbCardType";
            this.cmbCardType.NotEmpty = false;
            this.cmbCardType.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbCardType.SelectOnEnter = true;
            this.cmbCardType.Size = new System.Drawing.Size(227, 24);
            this.cmbCardType.TabIndex = 2;
            this.cmbCardType.SelectedIndexChanged += new System.EventHandler(this.cmbCardType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(432, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 105;
            this.label3.Text = "شماره کارت :";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.jPropertyValueUserControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(531, 337);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Properties";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cmbPassengerCardType
            // 
            this.cmbPassengerCardType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPassengerCardType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbPassengerCardType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPassengerCardType.BaseCode = 0;
            this.cmbPassengerCardType.ChangeColorIfNotEmpty = true;
            this.cmbPassengerCardType.ChangeColorOnEnter = true;
            this.cmbPassengerCardType.FormattingEnabled = true;
            this.cmbPassengerCardType.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbPassengerCardType.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbPassengerCardType.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cmbPassengerCardType.Location = new System.Drawing.Point(199, 84);
            this.cmbPassengerCardType.Name = "cmbPassengerCardType";
            this.cmbPassengerCardType.NotEmpty = false;
            this.cmbPassengerCardType.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbPassengerCardType.SelectOnEnter = true;
            this.cmbPassengerCardType.Size = new System.Drawing.Size(227, 24);
            this.cmbPassengerCardType.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(432, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 111;
            this.label4.Text = "نوع کارت:";
            // 
            // JCardsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 423);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JCardsForm";
            this.Text = "CardsForm";
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Globals.Property.JPropertyValueUserControl jPropertyValueUserControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ClassLibrary.JUCPerson jucPerson1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Label LblSerial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkStatus;
        private ClassLibrary.JComboBox cmbCardType;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox txtDesc;
        private ClassLibrary.NumEdit TxtCardCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button button2;
        private ClassLibrary.TextEdit txtRFID;
        private System.Windows.Forms.Label label4;
        private ClassLibrary.JComboBox cmbPassengerCardType;
    }
}