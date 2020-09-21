namespace Automation
{
    partial class JReferMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JReferMain));
            ClassLibrary.JPopupMenu jPopupMenu1 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbcReferType = new System.Windows.Forms.TabControl();
            this.tbpInternalrefer = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.jdgvRefer = new ClassLibrary.JDataGrid();
            this.rchDesc = new System.Windows.Forms.RichTextBox();
            this.btnAddRefer = new System.Windows.Forms.Button();
            this.btnDelRefer = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cdbReferInternal = new ClassLibrary.JCodingBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.cdbReferExternal = new ClassLibrary.JCodingBox();
            this.cmbEmprise = new ClassLibrary.JComboBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tbpExternalRefer = new System.Windows.Forms.TabPage();
            this.btnEmprise1 = new System.Windows.Forms.Button();
            this.btnEmprise = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nedPersuit = new ClassLibrary.DateEdit(this.components);
            this.txtSecretEmperise = new ClassLibrary.TextEdit(this.components);
            this.cmbsecuritylevel = new ClassLibrary.JComboBox(this.components);
            this.txtNormalEmperise = new ClassLibrary.TextEdit(this.components);
            this.cmbUrgency = new ClassLibrary.JComboBox(this.components);
            this.tbpAttachments = new System.Windows.Forms.TabPage();
            this.jArchiveList1 = new ArchivedDocuments.JArchiveList();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbcReferType.SuspendLayout();
            this.tbpInternalrefer.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jdgvRefer)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tbpExternalRefer.SuspendLayout();
            this.tbpAttachments.SuspendLayout();
            this.panel6.SuspendLayout();
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
            // tbcReferType
            // 
            this.tbcReferType.Controls.Add(this.tbpInternalrefer);
            this.tbcReferType.Controls.Add(this.tbpExternalRefer);
            this.tbcReferType.Controls.Add(this.tbpAttachments);
            this.tbcReferType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcReferType.Location = new System.Drawing.Point(0, 0);
            this.tbcReferType.Name = "tbcReferType";
            this.tbcReferType.RightToLeftLayout = true;
            this.tbcReferType.SelectedIndex = 0;
            this.tbcReferType.Size = new System.Drawing.Size(703, 424);
            this.tbcReferType.TabIndex = 2;
            // 
            // tbpInternalrefer
            // 
            this.tbpInternalrefer.Controls.Add(this.groupBox3);
            this.tbpInternalrefer.Controls.Add(this.groupBox2);
            this.tbpInternalrefer.Controls.Add(this.groupBox1);
            this.tbpInternalrefer.Location = new System.Drawing.Point(4, 25);
            this.tbpInternalrefer.Name = "tbpInternalrefer";
            this.tbpInternalrefer.Padding = new System.Windows.Forms.Padding(3);
            this.tbpInternalrefer.Size = new System.Drawing.Size(695, 395);
            this.tbpInternalrefer.TabIndex = 0;
            this.tbpInternalrefer.Text = "Simple Refer";
            this.tbpInternalrefer.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.jdgvRefer);
            this.groupBox3.Controls.Add(this.rchDesc);
            this.groupBox3.Controls.Add(this.btnAddRefer);
            this.groupBox3.Controls.Add(this.btnDelRefer);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 131);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(689, 261);
            this.groupBox3.TabIndex = 60;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "توضیحات";
            // 
            // jdgvRefer
            // 
            this.jdgvRefer.ActionMenu = jPopupMenu1;
            this.jdgvRefer.AllowUserToAddRows = false;
            this.jdgvRefer.AllowUserToDeleteRows = false;
            this.jdgvRefer.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.jdgvRefer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.jdgvRefer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jdgvRefer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jdgvRefer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.jdgvRefer.EnableContexMenu = true;
            this.jdgvRefer.KeyName = null;
            this.jdgvRefer.Location = new System.Drawing.Point(3, 154);
            this.jdgvRefer.Name = "jdgvRefer";
            this.jdgvRefer.ReadHeadersFromDB = false;
            this.jdgvRefer.ReadOnly = true;
            this.jdgvRefer.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jdgvRefer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jdgvRefer.ShowRowNumber = true;
            this.jdgvRefer.Size = new System.Drawing.Size(683, 104);
            this.jdgvRefer.TabIndex = 54;
            this.jdgvRefer.TableName = null;
            // 
            // rchDesc
            // 
            this.rchDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rchDesc.Location = new System.Drawing.Point(3, 19);
            this.rchDesc.Name = "rchDesc";
            this.rchDesc.Size = new System.Drawing.Size(682, 100);
            this.rchDesc.TabIndex = 49;
            this.rchDesc.Text = "";
            // 
            // btnAddRefer
            // 
            this.btnAddRefer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddRefer.Location = new System.Drawing.Point(89, 125);
            this.btnAddRefer.Name = "btnAddRefer";
            this.btnAddRefer.Size = new System.Drawing.Size(75, 23);
            this.btnAddRefer.TabIndex = 56;
            this.btnAddRefer.Text = "اضافه ";
            this.btnAddRefer.UseVisualStyleBackColor = true;
            this.btnAddRefer.Click += new System.EventHandler(this.btnAddRefer_Click);
            // 
            // btnDelRefer
            // 
            this.btnDelRefer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelRefer.Location = new System.Drawing.Point(8, 125);
            this.btnDelRefer.Name = "btnDelRefer";
            this.btnDelRefer.Size = new System.Drawing.Size(75, 23);
            this.btnDelRefer.TabIndex = 57;
            this.btnDelRefer.Text = "حذف";
            this.btnDelRefer.UseVisualStyleBackColor = true;
            this.btnDelRefer.Click += new System.EventHandler(this.btnDelRefer_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cdbReferInternal);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(689, 57);
            this.groupBox2.TabIndex = 59;
            this.groupBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(10, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 23);
            this.button1.TabIndex = 23;
            this.button1.TabStop = false;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(533, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Internal Refer Receiver:";
            // 
            // cdbReferInternal
            // 
            this.cdbReferInternal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cdbReferInternal.dataTable = null;
            this.cdbReferInternal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cdbReferInternal.Location = new System.Drawing.Point(39, 18);
            this.cdbReferInternal.Name = "cdbReferInternal";
            this.cdbReferInternal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cdbReferInternal.SelectedIndex = -1;
            this.cdbReferInternal.SelectedValue = null;
            this.cdbReferInternal.Size = new System.Drawing.Size(494, 29);
            this.cdbReferInternal.TabIndex = 50;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.cdbReferExternal);
            this.groupBox1.Controls.Add(this.cmbEmprise);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(689, 71);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(6, 14);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(28, 23);
            this.button6.TabIndex = 44;
            this.button6.TabStop = false;
            this.button6.Text = "...";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(535, 20);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(147, 16);
            this.label18.TabIndex = 43;
            this.label18.Text = "External Refer Receiver:";
            this.label18.Visible = false;
            // 
            // cdbReferExternal
            // 
            this.cdbReferExternal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cdbReferExternal.dataTable = null;
            this.cdbReferExternal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cdbReferExternal.Location = new System.Drawing.Point(37, 14);
            this.cdbReferExternal.Name = "cdbReferExternal";
            this.cdbReferExternal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cdbReferExternal.SelectedIndex = -1;
            this.cdbReferExternal.SelectedValue = null;
            this.cdbReferExternal.Size = new System.Drawing.Size(494, 29);
            this.cdbReferExternal.TabIndex = 51;
            this.cdbReferExternal.Visible = false;
            // 
            // cmbEmprise
            // 
            this.cmbEmprise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEmprise.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbEmprise.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbEmprise.BaseCode = 0;
            this.cmbEmprise.ChangeColorIfNotEmpty = true;
            this.cmbEmprise.ChangeColorOnEnter = true;
            this.cmbEmprise.FormattingEnabled = true;
            this.cmbEmprise.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbEmprise.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbEmprise.Location = new System.Drawing.Point(8, 45);
            this.cmbEmprise.Name = "cmbEmprise";
            this.cmbEmprise.NotEmpty = false;
            this.cmbEmprise.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbEmprise.SelectOnEnter = true;
            this.cmbEmprise.Size = new System.Drawing.Size(523, 24);
            this.cmbEmprise.TabIndex = 52;
            this.cmbEmprise.Visible = false;
            this.cmbEmprise.SelectedIndexChanged += new System.EventHandler(this.cmbEmprise_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(618, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 53;
            this.label3.Text = "Emprise:";
            this.label3.Visible = false;
            // 
            // tbpExternalRefer
            // 
            this.tbpExternalRefer.Controls.Add(this.btnEmprise1);
            this.tbpExternalRefer.Controls.Add(this.btnEmprise);
            this.tbpExternalRefer.Controls.Add(this.label9);
            this.tbpExternalRefer.Controls.Add(this.label10);
            this.tbpExternalRefer.Controls.Add(this.label6);
            this.tbpExternalRefer.Controls.Add(this.label5);
            this.tbpExternalRefer.Controls.Add(this.label8);
            this.tbpExternalRefer.Controls.Add(this.nedPersuit);
            this.tbpExternalRefer.Controls.Add(this.txtSecretEmperise);
            this.tbpExternalRefer.Controls.Add(this.cmbsecuritylevel);
            this.tbpExternalRefer.Controls.Add(this.txtNormalEmperise);
            this.tbpExternalRefer.Controls.Add(this.cmbUrgency);
            this.tbpExternalRefer.Location = new System.Drawing.Point(4, 25);
            this.tbpExternalRefer.Name = "tbpExternalRefer";
            this.tbpExternalRefer.Size = new System.Drawing.Size(695, 395);
            this.tbpExternalRefer.TabIndex = 5;
            this.tbpExternalRefer.Text = "Advance Refer";
            this.tbpExternalRefer.UseVisualStyleBackColor = true;
            // 
            // btnEmprise1
            // 
            this.btnEmprise1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmprise1.Location = new System.Drawing.Point(228, 149);
            this.btnEmprise1.Name = "btnEmprise1";
            this.btnEmprise1.Size = new System.Drawing.Size(32, 23);
            this.btnEmprise1.TabIndex = 24;
            this.btnEmprise1.Text = "...";
            this.btnEmprise1.UseVisualStyleBackColor = true;
            this.btnEmprise1.Click += new System.EventHandler(this.btnEmprise1_Click);
            // 
            // btnEmprise
            // 
            this.btnEmprise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmprise.Location = new System.Drawing.Point(229, 68);
            this.btnEmprise.Name = "btnEmprise";
            this.btnEmprise.Size = new System.Drawing.Size(32, 23);
            this.btnEmprise.TabIndex = 23;
            this.btnEmprise.Text = "...";
            this.btnEmprise.UseVisualStyleBackColor = true;
            this.btnEmprise.Click += new System.EventHandler(this.btnEmprise_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(578, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 16);
            this.label9.TabIndex = 2;
            this.label9.Text = "مهلت پاسخ :";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(577, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 16);
            this.label10.TabIndex = 20;
            this.label10.Text = "Security Level :";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(577, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Secret Emprise:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(577, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Normal Emprise:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(577, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "Urgency:";
            // 
            // nedPersuit
            // 
            this.nedPersuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nedPersuit.ChangeColorIfNotEmpty = true;
            this.nedPersuit.ChangeColorOnEnter = true;
            this.nedPersuit.Date = new System.DateTime(((long)(0)));
            this.nedPersuit.InBackColor = System.Drawing.SystemColors.Info;
            this.nedPersuit.InForeColor = System.Drawing.SystemColors.WindowText;
            this.nedPersuit.InsertInDatesTable = true;
            this.nedPersuit.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.nedPersuit.Location = new System.Drawing.Point(470, 11);
            this.nedPersuit.Mask = "0000/00/00";
            this.nedPersuit.Name = "nedPersuit";
            this.nedPersuit.NotEmpty = false;
            this.nedPersuit.NotEmptyColor = System.Drawing.Color.Red;
            this.nedPersuit.Size = new System.Drawing.Size(100, 23);
            this.nedPersuit.TabIndex = 22;
            // 
            // txtSecretEmperise
            // 
            this.txtSecretEmperise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSecretEmperise.ChangeColorIfNotEmpty = true;
            this.txtSecretEmperise.ChangeColorOnEnter = true;
            this.txtSecretEmperise.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSecretEmperise.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSecretEmperise.Location = new System.Drawing.Point(264, 68);
            this.txtSecretEmperise.Multiline = true;
            this.txtSecretEmperise.Name = "txtSecretEmperise";
            this.txtSecretEmperise.Negative = true;
            this.txtSecretEmperise.NotEmpty = false;
            this.txtSecretEmperise.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSecretEmperise.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSecretEmperise.SelectOnEnter = true;
            this.txtSecretEmperise.Size = new System.Drawing.Size(306, 50);
            this.txtSecretEmperise.TabIndex = 18;
            this.txtSecretEmperise.TextMode = ClassLibrary.TextModes.Text;
            // 
            // cmbsecuritylevel
            // 
            this.cmbsecuritylevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbsecuritylevel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbsecuritylevel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbsecuritylevel.BaseCode = 0;
            this.cmbsecuritylevel.ChangeColorIfNotEmpty = true;
            this.cmbsecuritylevel.ChangeColorOnEnter = true;
            this.cmbsecuritylevel.FormattingEnabled = true;
            this.cmbsecuritylevel.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbsecuritylevel.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbsecuritylevel.Location = new System.Drawing.Point(264, 38);
            this.cmbsecuritylevel.Name = "cmbsecuritylevel";
            this.cmbsecuritylevel.NotEmpty = false;
            this.cmbsecuritylevel.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbsecuritylevel.SelectOnEnter = true;
            this.cmbsecuritylevel.Size = new System.Drawing.Size(306, 24);
            this.cmbsecuritylevel.TabIndex = 21;
            // 
            // txtNormalEmperise
            // 
            this.txtNormalEmperise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNormalEmperise.BackColor = System.Drawing.SystemColors.Window;
            this.txtNormalEmperise.ChangeColorIfNotEmpty = true;
            this.txtNormalEmperise.ChangeColorOnEnter = true;
            this.txtNormalEmperise.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNormalEmperise.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNormalEmperise.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNormalEmperise.Location = new System.Drawing.Point(266, 152);
            this.txtNormalEmperise.Multiline = true;
            this.txtNormalEmperise.Name = "txtNormalEmperise";
            this.txtNormalEmperise.Negative = true;
            this.txtNormalEmperise.NotEmpty = false;
            this.txtNormalEmperise.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNormalEmperise.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNormalEmperise.SelectOnEnter = true;
            this.txtNormalEmperise.Size = new System.Drawing.Size(303, 50);
            this.txtNormalEmperise.TabIndex = 15;
            this.txtNormalEmperise.TextMode = ClassLibrary.TextModes.Text;
            // 
            // cmbUrgency
            // 
            this.cmbUrgency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUrgency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbUrgency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUrgency.BackColor = System.Drawing.SystemColors.Info;
            this.cmbUrgency.BaseCode = 0;
            this.cmbUrgency.ChangeColorIfNotEmpty = true;
            this.cmbUrgency.ChangeColorOnEnter = true;
            this.cmbUrgency.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbUrgency.FormattingEnabled = true;
            this.cmbUrgency.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbUrgency.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbUrgency.Location = new System.Drawing.Point(267, 122);
            this.cmbUrgency.Name = "cmbUrgency";
            this.cmbUrgency.NotEmpty = false;
            this.cmbUrgency.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbUrgency.SelectOnEnter = true;
            this.cmbUrgency.Size = new System.Drawing.Size(302, 24);
            this.cmbUrgency.TabIndex = 14;
            // 
            // tbpAttachments
            // 
            this.tbpAttachments.Controls.Add(this.jArchiveList1);
            this.tbpAttachments.Location = new System.Drawing.Point(4, 25);
            this.tbpAttachments.Name = "tbpAttachments";
            this.tbpAttachments.Size = new System.Drawing.Size(695, 395);
            this.tbpAttachments.TabIndex = 4;
            this.tbpAttachments.Text = "Attachments";
            this.tbpAttachments.UseVisualStyleBackColor = true;
            // 
            // jArchiveList1
            // 
            this.jArchiveList1.AllowUserAddFile = true;
            this.jArchiveList1.AllowUserAddFromArchive = true;
            this.jArchiveList1.AllowUserAddImage = true;
            this.jArchiveList1.AllowUserDeleteFile = true;
            this.jArchiveList1.ClassName = "";
            this.jArchiveList1.ClassNames = null;
            this.jArchiveList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jArchiveList1.EnabledChange = true;
            this.jArchiveList1.Location = new System.Drawing.Point(0, 0);
            this.jArchiveList1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.jArchiveList1.Name = "jArchiveList1";
            this.jArchiveList1.ObjectCode = 0;
            this.jArchiveList1.ObjectCodes = null;
            this.jArchiveList1.PlaceCode = 0;
            this.jArchiveList1.Size = new System.Drawing.Size(695, 395);
            this.jArchiveList1.SubjectCode = 0;
            this.jArchiveList1.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnClose);
            this.panel6.Controls.Add(this.btnSend);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 424);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(703, 41);
            this.panel6.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(14, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 32);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSend.Location = new System.Drawing.Point(609, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(87, 32);
            this.btnSend.TabIndex = 20;
            this.btnSend.Text = "Refer";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.Btnsend_Click);
            // 
            // JReferMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 465);
            this.Controls.Add(this.tbcReferType);
            this.Controls.Add(this.panel6);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JReferMain";
            this.Text = "frmReferMain";
            this.Load += new System.EventHandler(this.JReferMain_Load);
            this.Shown += new System.EventHandler(this.JReferMain_Shown);
            this.tbcReferType.ResumeLayout(false);
            this.tbpInternalrefer.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jdgvRefer)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tbpExternalRefer.ResumeLayout(false);
            this.tbpExternalRefer.PerformLayout();
            this.tbpAttachments.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcReferType;
        private System.Windows.Forms.TabPage tbpInternalrefer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TabPage tbpAttachments;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TabPage tbpExternalRefer;
        public ClassLibrary.JComboBox cmbUrgency;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        public ClassLibrary.TextEdit txtNormalEmperise;
        public ClassLibrary.JComboBox cmbsecuritylevel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        public ClassLibrary.TextEdit txtSecretEmperise;
        private ClassLibrary.DateEdit nedPersuit;
        private System.Windows.Forms.RichTextBox rchDesc;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label18;
        private ClassLibrary.JCodingBox cdbReferExternal;
        private ClassLibrary.JCodingBox cdbReferInternal;
        private ClassLibrary.JComboBox cmbEmprise;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddRefer;
        private System.Windows.Forms.Button btnDelRefer;
        private ClassLibrary.JDataGrid jdgvRefer;
        private System.Windows.Forms.Button btnClose;
        private ArchivedDocuments.JArchiveList jArchiveList1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnEmprise1;
        private System.Windows.Forms.Button btnEmprise;
    }
}