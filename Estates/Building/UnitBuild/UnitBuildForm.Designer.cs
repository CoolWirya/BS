namespace Estates
{
    partial class JUnitBuildForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JUnitBuildForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbJobs = new ClassLibrary.JComboBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtArea = new ClassLibrary.TextEdit(this.components);
            this.cmbFloor = new ClassLibrary.JComboBox(this.components);
            this.txtPlaqueRegistration = new ClassLibrary.TextEdit(this.components);
            this.cmbUsage = new ClassLibrary.JComboBox(this.components);
            this.txtNumber = new ClassLibrary.TextEdit(this.components);
            this.txtPlaque = new ClassLibrary.TextEdit(this.components);
            this.cmbConstructionName = new ClassLibrary.JComboBox(this.components);
            this.cmbType = new ClassLibrary.JComboBox(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.DelPrimaryOwners = new System.Windows.Forms.Button();
            this.AddPrimaryOwners = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvPrimeryOwners = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnok = new System.Windows.Forms.Button();
            this.jPropertyValueUserControl1 = new Globals.Property.JPropertyValueUserControl();
            this.ArchiveList = new ArchivedDocuments.JArchiveList();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrimeryOwners)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage5.SuspendLayout();
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(475, 388);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmbJobs);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtArea);
            this.tabPage1.Controls.Add(this.cmbFloor);
            this.tabPage1.Controls.Add(this.txtPlaqueRegistration);
            this.tabPage1.Controls.Add(this.cmbUsage);
            this.tabPage1.Controls.Add(this.txtNumber);
            this.tabPage1.Controls.Add(this.txtPlaque);
            this.tabPage1.Controls.Add(this.cmbConstructionName);
            this.tabPage1.Controls.Add(this.cmbType);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(467, 359);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "مشخصات";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmbJobs
            // 
            this.cmbJobs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbJobs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbJobs.ChangeColorIfNotEmpty = true;
            this.cmbJobs.ChangeColorOnEnter = true;
            this.cmbJobs.FormattingEnabled = true;
            this.cmbJobs.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbJobs.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbJobs.Location = new System.Drawing.Point(143, 264);
            this.cmbJobs.Name = "cmbJobs";
            this.cmbJobs.NotEmpty = false;
            this.cmbJobs.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbJobs.SelectOnEnter = true;
            this.cmbJobs.Size = new System.Drawing.Size(189, 24);
            this.cmbJobs.TabIndex = 22;
            this.cmbJobs.SelectedIndexChanged += new System.EventHandler(this.txtPlaque_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(398, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "شغل:";
            // 
            // txtArea
            // 
            this.txtArea.ChangeColorIfNotEmpty = false;
            this.txtArea.ChangeColorOnEnter = true;
            this.txtArea.InBackColor = System.Drawing.SystemColors.Info;
            this.txtArea.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtArea.Location = new System.Drawing.Point(143, 176);
            this.txtArea.Name = "txtArea";
            this.txtArea.Negative = true;
            this.txtArea.NotEmpty = false;
            this.txtArea.NotEmptyColor = System.Drawing.Color.Red;
            this.txtArea.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtArea.SelectOnEnter = true;
            this.txtArea.Size = new System.Drawing.Size(189, 23);
            this.txtArea.TabIndex = 5;
            this.txtArea.TextMode = ClassLibrary.TextModes.Real;
            this.txtArea.TextChanged += new System.EventHandler(this.txtPlaque_TextChanged);
            // 
            // cmbFloor
            // 
            this.cmbFloor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFloor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFloor.ChangeColorIfNotEmpty = true;
            this.cmbFloor.ChangeColorOnEnter = true;
            this.cmbFloor.FormattingEnabled = true;
            this.cmbFloor.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbFloor.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbFloor.Location = new System.Drawing.Point(143, 117);
            this.cmbFloor.Name = "cmbFloor";
            this.cmbFloor.NotEmpty = false;
            this.cmbFloor.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbFloor.SelectOnEnter = true;
            this.cmbFloor.Size = new System.Drawing.Size(189, 24);
            this.cmbFloor.TabIndex = 3;
            this.cmbFloor.SelectedIndexChanged += new System.EventHandler(this.txtPlaque_TextChanged);
            // 
            // txtPlaqueRegistration
            // 
            this.txtPlaqueRegistration.ChangeColorIfNotEmpty = false;
            this.txtPlaqueRegistration.ChangeColorOnEnter = true;
            this.txtPlaqueRegistration.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPlaqueRegistration.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPlaqueRegistration.Location = new System.Drawing.Point(143, 235);
            this.txtPlaqueRegistration.Name = "txtPlaqueRegistration";
            this.txtPlaqueRegistration.Negative = true;
            this.txtPlaqueRegistration.NotEmpty = false;
            this.txtPlaqueRegistration.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPlaqueRegistration.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPlaqueRegistration.SelectOnEnter = true;
            this.txtPlaqueRegistration.Size = new System.Drawing.Size(189, 23);
            this.txtPlaqueRegistration.TabIndex = 7;
            this.txtPlaqueRegistration.TextMode = ClassLibrary.TextModes.Integer;
            this.txtPlaqueRegistration.TextChanged += new System.EventHandler(this.txtPlaque_TextChanged);
            // 
            // cmbUsage
            // 
            this.cmbUsage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbUsage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUsage.ChangeColorIfNotEmpty = true;
            this.cmbUsage.ChangeColorOnEnter = true;
            this.cmbUsage.FormattingEnabled = true;
            this.cmbUsage.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbUsage.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbUsage.Location = new System.Drawing.Point(143, 205);
            this.cmbUsage.Name = "cmbUsage";
            this.cmbUsage.NotEmpty = false;
            this.cmbUsage.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbUsage.SelectOnEnter = true;
            this.cmbUsage.Size = new System.Drawing.Size(189, 24);
            this.cmbUsage.TabIndex = 6;
            this.cmbUsage.SelectedIndexChanged += new System.EventHandler(this.txtPlaque_TextChanged);
            // 
            // txtNumber
            // 
            this.txtNumber.ChangeColorIfNotEmpty = false;
            this.txtNumber.ChangeColorOnEnter = true;
            this.txtNumber.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNumber.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNumber.Location = new System.Drawing.Point(143, 147);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Negative = true;
            this.txtNumber.NotEmpty = false;
            this.txtNumber.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNumber.SelectOnEnter = true;
            this.txtNumber.Size = new System.Drawing.Size(189, 23);
            this.txtNumber.TabIndex = 4;
            this.txtNumber.TextMode = ClassLibrary.TextModes.Text;
            this.txtNumber.TextChanged += new System.EventHandler(this.txtPlaque_TextChanged);
            // 
            // txtPlaque
            // 
            this.txtPlaque.ChangeColorIfNotEmpty = false;
            this.txtPlaque.ChangeColorOnEnter = true;
            this.txtPlaque.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPlaque.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPlaque.Location = new System.Drawing.Point(143, 88);
            this.txtPlaque.Name = "txtPlaque";
            this.txtPlaque.Negative = true;
            this.txtPlaque.NotEmpty = false;
            this.txtPlaque.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPlaque.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPlaque.SelectOnEnter = true;
            this.txtPlaque.Size = new System.Drawing.Size(189, 23);
            this.txtPlaque.TabIndex = 2;
            this.txtPlaque.TextMode = ClassLibrary.TextModes.Text;
            this.txtPlaque.TextChanged += new System.EventHandler(this.txtPlaque_TextChanged);
            // 
            // cmbConstructionName
            // 
            this.cmbConstructionName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbConstructionName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbConstructionName.BackColor = System.Drawing.SystemColors.Info;
            this.cmbConstructionName.ChangeColorIfNotEmpty = true;
            this.cmbConstructionName.ChangeColorOnEnter = true;
            this.cmbConstructionName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbConstructionName.FormattingEnabled = true;
            this.cmbConstructionName.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbConstructionName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbConstructionName.Location = new System.Drawing.Point(143, 28);
            this.cmbConstructionName.Name = "cmbConstructionName";
            this.cmbConstructionName.NotEmpty = false;
            this.cmbConstructionName.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbConstructionName.SelectOnEnter = true;
            this.cmbConstructionName.Size = new System.Drawing.Size(189, 24);
            this.cmbConstructionName.TabIndex = 0;
            this.cmbConstructionName.SelectedIndexChanged += new System.EventHandler(this.cmbConstructionName_SelectedIndexChanged);
            // 
            // cmbType
            // 
            this.cmbType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbType.BackColor = System.Drawing.SystemColors.Info;
            this.cmbType.ChangeColorIfNotEmpty = true;
            this.cmbType.ChangeColorOnEnter = true;
            this.cmbType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbType.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbType.Location = new System.Drawing.Point(143, 58);
            this.cmbType.Name = "cmbType";
            this.cmbType.NotEmpty = false;
            this.cmbType.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbType.SelectOnEnter = true;
            this.cmbType.Size = new System.Drawing.Size(189, 24);
            this.cmbType.TabIndex = 1;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.txtPlaque_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(370, 239);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 16);
            this.label9.TabIndex = 21;
            this.label9.Text = "پلاک ثبتی:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(330, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "شماره شناسایی:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(380, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "نوع واحد:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(391, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "کاربری:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(362, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "شماره واحد:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(343, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "نام مجتمع/بازار:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(401, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "متراژ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(398, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "طبقه:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.DelPrimaryOwners);
            this.tabPage3.Controls.Add(this.AddPrimaryOwners);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.dgvPrimeryOwners);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(467, 359);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "مالکین اولیه";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // DelPrimaryOwners
            // 
            this.DelPrimaryOwners.Location = new System.Drawing.Point(305, 330);
            this.DelPrimaryOwners.Name = "DelPrimaryOwners";
            this.DelPrimaryOwners.Size = new System.Drawing.Size(75, 23);
            this.DelPrimaryOwners.TabIndex = 1;
            this.DelPrimaryOwners.Text = "حذف";
            this.DelPrimaryOwners.UseVisualStyleBackColor = true;
            this.DelPrimaryOwners.Click += new System.EventHandler(this.DelPrimaryOwners_Click);
            // 
            // AddPrimaryOwners
            // 
            this.AddPrimaryOwners.Location = new System.Drawing.Point(386, 330);
            this.AddPrimaryOwners.Name = "AddPrimaryOwners";
            this.AddPrimaryOwners.Size = new System.Drawing.Size(75, 23);
            this.AddPrimaryOwners.TabIndex = 0;
            this.AddPrimaryOwners.Text = "اضافه";
            this.AddPrimaryOwners.UseVisualStyleBackColor = true;
            this.AddPrimaryOwners.Click += new System.EventHandler(this.AddPrimaryOwners_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(375, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "لیست مالکین:";
            // 
            // dgvPrimeryOwners
            // 
            this.dgvPrimeryOwners.AllowUserToAddRows = false;
            this.dgvPrimeryOwners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrimeryOwners.Location = new System.Drawing.Point(6, 31);
            this.dgvPrimeryOwners.MultiSelect = false;
            this.dgvPrimeryOwners.Name = "dgvPrimeryOwners";
            this.dgvPrimeryOwners.Size = new System.Drawing.Size(455, 293);
            this.dgvPrimeryOwners.TabIndex = 0;
            this.dgvPrimeryOwners.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPrimeryOwners_CellEndEdit);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtDesc);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(467, 359);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "توضیحات";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtDesc
            // 
            this.txtDesc.ChangeColorIfNotEmpty = true;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(3, 3);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(461, 353);
            this.txtDesc.TabIndex = 0;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtPlaque_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.jPropertyValueUserControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(467, 359);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "ویژگی ها";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.ArchiveList);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(467, 359);
            this.tabPage5.TabIndex = 5;
            this.tabPage5.Text = "تصاویر";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(16, 406);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 33);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "ذخیره";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(412, 406);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 33);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "خروج";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.Close_Click);
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(97, 406);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 33);
            this.btnok.TabIndex = 2;
            this.btnok.Text = "تایید";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.ok_Click);
            // 
            // jPropertyValueUserControl1
            // 
            this.jPropertyValueUserControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.jPropertyValueUserControl1.ClassName = null;
            this.jPropertyValueUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jPropertyValueUserControl1.Location = new System.Drawing.Point(3, 3);
            this.jPropertyValueUserControl1.Name = "jPropertyValueUserControl1";
            this.jPropertyValueUserControl1.ObjectCode = 0;
            this.jPropertyValueUserControl1.Size = new System.Drawing.Size(461, 353);
            this.jPropertyValueUserControl1.TabIndex = 0;
            this.jPropertyValueUserControl1.ValueObjectCode = 0;
            // 
            // ArchiveList
            // 
            this.ArchiveList.ClassName = "";
            this.ArchiveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchiveList.Location = new System.Drawing.Point(3, 3);
            this.ArchiveList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ArchiveList.Name = "ArchiveList";
            this.ArchiveList.ObjectCode = 0;
            this.ArchiveList.PlaceCode = 0;
            this.ArchiveList.Size = new System.Drawing.Size(461, 353);
            this.ArchiveList.SubjectCode = 0;
            this.ArchiveList.TabIndex = 0;
            this.ArchiveList.AfterFileAdded += new ArchivedDocuments.JArchiveList.FileAdded(this.txtPlaque_TextChanged);
            this.ArchiveList.AfterDescriptioEdited += new ArchivedDocuments.JArchiveList.DescriptioEdited(this.txtPlaque_TextChanged);
            // 
            // JUnitBuildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 444);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Name = "JUnitBuildForm";
            this.Text = "اعیان";
            this.Load += new System.EventHandler(this.JUnitBuildForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JUnitBuildForm_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrimeryOwners)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button AddPrimaryOwners;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvPrimeryOwners;
        private System.Windows.Forms.Button DelPrimaryOwners;
        private System.Windows.Forms.TabPage tabPage4;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage5;
        private ArchivedDocuments.JArchiveList ArchiveList;
        private System.Windows.Forms.Button btnok;
        private ClassLibrary.TextEdit txtPlaque;
        private ClassLibrary.JComboBox cmbConstructionName;
        private ClassLibrary.JComboBox cmbType;
        private ClassLibrary.TextEdit txtNumber;
        private ClassLibrary.JComboBox cmbUsage;
        private ClassLibrary.TextEdit txtPlaqueRegistration;
        private ClassLibrary.JComboBox cmbFloor;
        private Globals.Property.JPropertyValueUserControl jPropertyValueUserControl1;
        private ClassLibrary.TextEdit txtArea;
        private ClassLibrary.JComboBox cmbJobs;
        private System.Windows.Forms.Label label5;


    }
}