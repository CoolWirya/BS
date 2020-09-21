namespace Communication
{
    partial class JUC_Copy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JUC_Copy));
            this.panel9 = new System.Windows.Forms.Panel();
            this.jJanusGrid1 = new ClassLibrary.UC_Grid();
            this.panel8 = new System.Windows.Forms.Panel();
            this.textEdit2 = new ClassLibrary.TextEdit(this.components);
            this.label16 = new System.Windows.Forms.Label();
            this.lblGroupRefer = new System.Windows.Forms.Label();
            this.cdbOrgChartForRefer = new ClassLibrary.JCodingBox();
            this.btnOrgChartForRefer = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlCopy = new System.Windows.Forms.Panel();
            this.pnlExternalCtr = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPersuitExternal = new ClassLibrary.DateEdit(this.components);
            this.txtCopyReasonExternal = new ClassLibrary.JComboBox(this.components);
            this.btnExAdd = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCopyExternalFullName = new ClassLibrary.TextEdit(this.components);
            this.cmbSendTypeExternal = new ClassLibrary.JComboBox(this.components);
            this.cdbCopyExternal = new ClassLibrary.JCodingBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlInternalCrt = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPersuitInternal = new ClassLibrary.DateEdit(this.components);
            this.txtCopyReasonInternal = new ClassLibrary.JComboBox(this.components);
            this.btnInternalAdd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cdbCopyInternal = new ClassLibrary.JCodingBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.internalCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.externalCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbTitles = new ClassLibrary.JComboBox(this.components);
            this.grdCopy = new ClassLibrary.JJanusGrid();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlCopy.SuspendLayout();
            this.pnlExternalCtr.SuspendLayout();
            this.pnlInternalCrt.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.jJanusGrid1);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 199);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(840, 287);
            this.panel9.TabIndex = 2;
            // 
            // jJanusGrid1
            // 
            this.jJanusGrid1.Location = new System.Drawing.Point(0, 0);
            this.jJanusGrid1.MultiSelect = false;
            this.jJanusGrid1.Name = "jJanusGrid1";
            this.jJanusGrid1.Size = new System.Drawing.Size(651, 275);
            this.jJanusGrid1.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.textEdit2);
            this.panel8.Controls.Add(this.label16);
            this.panel8.Controls.Add(this.lblGroupRefer);
            this.panel8.Controls.Add(this.cdbOrgChartForRefer);
            this.panel8.Controls.Add(this.btnOrgChartForRefer);
            this.panel8.Controls.Add(this.label15);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(840, 181);
            this.panel8.TabIndex = 1;
            // 
            // textEdit2
            // 
            this.textEdit2.ChangeColorIfNotEmpty = true;
            this.textEdit2.ChangeColorOnEnter = true;
            this.textEdit2.InBackColor = System.Drawing.SystemColors.Info;
            this.textEdit2.InForeColor = System.Drawing.SystemColors.WindowText;
            this.textEdit2.Location = new System.Drawing.Point(47, 78);
            this.textEdit2.Multiline = true;
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Negative = true;
            this.textEdit2.NotEmpty = false;
            this.textEdit2.NotEmptyColor = System.Drawing.Color.Red;
            this.textEdit2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textEdit2.SelectOnEnter = true;
            this.textEdit2.Size = new System.Drawing.Size(649, 75);
            this.textEdit2.TabIndex = 26;
            this.textEdit2.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(697, 78);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(103, 13);
            this.label16.TabIndex = 25;
            this.label16.Text = "Emprise Description:";
            // 
            // lblGroupRefer
            // 
            this.lblGroupRefer.Location = new System.Drawing.Point(0, 0);
            this.lblGroupRefer.Name = "lblGroupRefer";
            this.lblGroupRefer.Size = new System.Drawing.Size(100, 23);
            this.lblGroupRefer.TabIndex = 27;
            // 
            // cdbOrgChartForRefer
            // 
            this.cdbOrgChartForRefer.dataTable = null;
            this.cdbOrgChartForRefer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cdbOrgChartForRefer.Location = new System.Drawing.Point(0, 0);
            this.cdbOrgChartForRefer.Name = "cdbOrgChartForRefer";
            this.cdbOrgChartForRefer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cdbOrgChartForRefer.SelectedIndex = -1;
            this.cdbOrgChartForRefer.SelectedValue = null;
            this.cdbOrgChartForRefer.Size = new System.Drawing.Size(293, 27);
            this.cdbOrgChartForRefer.TabIndex = 28;
            // 
            // btnOrgChartForRefer
            // 
            this.btnOrgChartForRefer.Location = new System.Drawing.Point(19, 16);
            this.btnOrgChartForRefer.Name = "btnOrgChartForRefer";
            this.btnOrgChartForRefer.Size = new System.Drawing.Size(28, 23);
            this.btnOrgChartForRefer.TabIndex = 22;
            this.btnOrgChartForRefer.TabStop = false;
            this.btnOrgChartForRefer.Text = "...";
            this.btnOrgChartForRefer.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(761, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 13);
            this.label15.TabIndex = 21;
            this.label15.Text = "Receiver:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(16, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(709, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Send Type:";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(16, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 25);
            this.button2.TabIndex = 24;
            this.button2.TabStop = false;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(709, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Copy Receiver:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grdCopy);
            this.panel1.Controls.Add(this.pnlCopy);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 395);
            this.panel1.TabIndex = 0;
            // 
            // pnlCopy
            // 
            this.pnlCopy.Controls.Add(this.pnlExternalCtr);
            this.pnlCopy.Controls.Add(this.pnlInternalCrt);
            this.pnlCopy.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCopy.Location = new System.Drawing.Point(0, 0);
            this.pnlCopy.Name = "pnlCopy";
            this.pnlCopy.Size = new System.Drawing.Size(794, 242);
            this.pnlCopy.TabIndex = 4;
            // 
            // pnlExternalCtr
            // 
            this.pnlExternalCtr.Controls.Add(this.label7);
            this.pnlExternalCtr.Controls.Add(this.txtPersuitExternal);
            this.pnlExternalCtr.Controls.Add(this.txtCopyReasonExternal);
            this.pnlExternalCtr.Controls.Add(this.btnExAdd);
            this.pnlExternalCtr.Controls.Add(this.label6);
            this.pnlExternalCtr.Controls.Add(this.txtCopyExternalFullName);
            this.pnlExternalCtr.Controls.Add(this.label2);
            this.pnlExternalCtr.Controls.Add(this.cmbSendTypeExternal);
            this.pnlExternalCtr.Controls.Add(this.button2);
            this.pnlExternalCtr.Controls.Add(this.cdbCopyExternal);
            this.pnlExternalCtr.Controls.Add(this.label3);
            this.pnlExternalCtr.Controls.Add(this.label4);
            this.pnlExternalCtr.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlExternalCtr.Location = new System.Drawing.Point(0, 104);
            this.pnlExternalCtr.Name = "pnlExternalCtr";
            this.pnlExternalCtr.Size = new System.Drawing.Size(794, 138);
            this.pnlExternalCtr.TabIndex = 30;
            this.pnlExternalCtr.TabStop = false;
            this.pnlExternalCtr.Text = "External Copy";
            this.pnlExternalCtr.Visible = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(711, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "مهلت پاسخ :";
            // 
            // txtPersuitExternal
            // 
            this.txtPersuitExternal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPersuitExternal.ChangeColorIfNotEmpty = true;
            this.txtPersuitExternal.ChangeColorOnEnter = true;
            this.txtPersuitExternal.Date = new System.DateTime(((long)(0)));
            this.txtPersuitExternal.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPersuitExternal.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPersuitExternal.InsertInDatesTable = true;
            this.txtPersuitExternal.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtPersuitExternal.Location = new System.Drawing.Point(594, 103);
            this.txtPersuitExternal.Mask = "0000/00/00";
            this.txtPersuitExternal.Name = "txtPersuitExternal";
            this.txtPersuitExternal.NotEmpty = false;
            this.txtPersuitExternal.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPersuitExternal.Size = new System.Drawing.Size(100, 20);
            this.txtPersuitExternal.TabIndex = 3;
            // 
            // txtCopyReasonExternal
            // 
            this.txtCopyReasonExternal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCopyReasonExternal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCopyReasonExternal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtCopyReasonExternal.BaseCode = 0;
            this.txtCopyReasonExternal.ChangeColorIfNotEmpty = true;
            this.txtCopyReasonExternal.ChangeColorOnEnter = true;
            this.txtCopyReasonExternal.FormattingEnabled = true;
            this.txtCopyReasonExternal.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCopyReasonExternal.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCopyReasonExternal.Location = new System.Drawing.Point(16, 74);
            this.txtCopyReasonExternal.Name = "txtCopyReasonExternal";
            this.txtCopyReasonExternal.NotEmpty = false;
            this.txtCopyReasonExternal.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCopyReasonExternal.SelectOnEnter = true;
            this.txtCopyReasonExternal.Size = new System.Drawing.Size(678, 21);
            this.txtCopyReasonExternal.TabIndex = 2;
            this.txtCopyReasonExternal.Leave += new System.EventHandler(this.txtCopyReasonExternal_Leave);
            // 
            // btnExAdd
            // 
            this.btnExAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExAdd.Location = new System.Drawing.Point(549, 102);
            this.btnExAdd.Name = "btnExAdd";
            this.btnExAdd.Size = new System.Drawing.Size(33, 25);
            this.btnExAdd.TabIndex = 4;
            this.btnExAdd.Text = "+";
            this.btnExAdd.UseVisualStyleBackColor = true;
            this.btnExAdd.Click += new System.EventHandler(this.button4_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(709, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Copy Reason:";
            // 
            // txtCopyExternalFullName
            // 
            this.txtCopyExternalFullName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCopyExternalFullName.BackColor = System.Drawing.SystemColors.Info;
            this.txtCopyExternalFullName.ChangeColorIfNotEmpty = true;
            this.txtCopyExternalFullName.ChangeColorOnEnter = true;
            this.txtCopyExternalFullName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCopyExternalFullName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCopyExternalFullName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCopyExternalFullName.Location = new System.Drawing.Point(0, 107);
            this.txtCopyExternalFullName.Name = "txtCopyExternalFullName";
            this.txtCopyExternalFullName.Negative = true;
            this.txtCopyExternalFullName.NotEmpty = false;
            this.txtCopyExternalFullName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCopyExternalFullName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCopyExternalFullName.SelectOnEnter = true;
            this.txtCopyExternalFullName.Size = new System.Drawing.Size(640, 20);
            this.txtCopyExternalFullName.TabIndex = 29;
            this.txtCopyExternalFullName.TextMode = ClassLibrary.TextModes.Text;
            this.txtCopyExternalFullName.Visible = false;
            // 
            // cmbSendTypeExternal
            // 
            this.cmbSendTypeExternal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSendTypeExternal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSendTypeExternal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSendTypeExternal.BackColor = System.Drawing.SystemColors.Info;
            this.cmbSendTypeExternal.BaseCode = 0;
            this.cmbSendTypeExternal.ChangeColorIfNotEmpty = true;
            this.cmbSendTypeExternal.ChangeColorOnEnter = true;
            this.cmbSendTypeExternal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbSendTypeExternal.FormattingEnabled = true;
            this.cmbSendTypeExternal.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbSendTypeExternal.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbSendTypeExternal.Location = new System.Drawing.Point(16, 47);
            this.cmbSendTypeExternal.Name = "cmbSendTypeExternal";
            this.cmbSendTypeExternal.NotEmpty = false;
            this.cmbSendTypeExternal.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbSendTypeExternal.SelectOnEnter = true;
            this.cmbSendTypeExternal.Size = new System.Drawing.Size(676, 21);
            this.cmbSendTypeExternal.TabIndex = 1;
            // 
            // cdbCopyExternal
            // 
            this.cdbCopyExternal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cdbCopyExternal.dataTable = null;
            this.cdbCopyExternal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cdbCopyExternal.Location = new System.Drawing.Point(42, 16);
            this.cdbCopyExternal.Name = "cdbCopyExternal";
            this.cdbCopyExternal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cdbCopyExternal.SelectedIndex = -1;
            this.cdbCopyExternal.SelectedValue = null;
            this.cdbCopyExternal.Size = new System.Drawing.Size(652, 27);
            this.cdbCopyExternal.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(709, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Copy Reciver:";
            this.label3.Visible = false;
            // 
            // pnlInternalCrt
            // 
            this.pnlInternalCrt.Controls.Add(this.label18);
            this.pnlInternalCrt.Controls.Add(this.txtPersuitInternal);
            this.pnlInternalCrt.Controls.Add(this.txtCopyReasonInternal);
            this.pnlInternalCrt.Controls.Add(this.btnInternalAdd);
            this.pnlInternalCrt.Controls.Add(this.label5);
            this.pnlInternalCrt.Controls.Add(this.button1);
            this.pnlInternalCrt.Controls.Add(this.cdbCopyInternal);
            this.pnlInternalCrt.Controls.Add(this.label1);
            this.pnlInternalCrt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInternalCrt.Location = new System.Drawing.Point(0, 0);
            this.pnlInternalCrt.Name = "pnlInternalCrt";
            this.pnlInternalCrt.Size = new System.Drawing.Size(794, 104);
            this.pnlInternalCrt.TabIndex = 25;
            this.pnlInternalCrt.TabStop = false;
            this.pnlInternalCrt.Text = "Internal Copy";
            this.pnlInternalCrt.Visible = false;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(706, 78);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 13);
            this.label18.TabIndex = 28;
            this.label18.Text = "مهلت پاسخ :";
            // 
            // txtPersuitInternal
            // 
            this.txtPersuitInternal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPersuitInternal.ChangeColorIfNotEmpty = true;
            this.txtPersuitInternal.ChangeColorOnEnter = true;
            this.txtPersuitInternal.Date = new System.DateTime(((long)(0)));
            this.txtPersuitInternal.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPersuitInternal.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPersuitInternal.InsertInDatesTable = true;
            this.txtPersuitInternal.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtPersuitInternal.Location = new System.Drawing.Point(597, 75);
            this.txtPersuitInternal.Mask = "0000/00/00";
            this.txtPersuitInternal.Name = "txtPersuitInternal";
            this.txtPersuitInternal.NotEmpty = false;
            this.txtPersuitInternal.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPersuitInternal.Size = new System.Drawing.Size(100, 20);
            this.txtPersuitInternal.TabIndex = 2;
            // 
            // txtCopyReasonInternal
            // 
            this.txtCopyReasonInternal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCopyReasonInternal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtCopyReasonInternal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtCopyReasonInternal.BaseCode = 0;
            this.txtCopyReasonInternal.ChangeColorIfNotEmpty = true;
            this.txtCopyReasonInternal.ChangeColorOnEnter = true;
            this.txtCopyReasonInternal.FormattingEnabled = true;
            this.txtCopyReasonInternal.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCopyReasonInternal.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCopyReasonInternal.Location = new System.Drawing.Point(42, 46);
            this.txtCopyReasonInternal.Name = "txtCopyReasonInternal";
            this.txtCopyReasonInternal.NotEmpty = false;
            this.txtCopyReasonInternal.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCopyReasonInternal.SelectOnEnter = true;
            this.txtCopyReasonInternal.Size = new System.Drawing.Size(655, 21);
            this.txtCopyReasonInternal.TabIndex = 1;
            this.txtCopyReasonInternal.Leave += new System.EventHandler(this.txtCopyReasonInternal_Leave);
            // 
            // btnInternalAdd
            // 
            this.btnInternalAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInternalAdd.Location = new System.Drawing.Point(549, 72);
            this.btnInternalAdd.Name = "btnInternalAdd";
            this.btnInternalAdd.Size = new System.Drawing.Size(33, 25);
            this.btnInternalAdd.TabIndex = 3;
            this.btnInternalAdd.Text = "+";
            this.btnInternalAdd.UseVisualStyleBackColor = true;
            this.btnInternalAdd.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(709, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Copy Reason:";
            // 
            // cdbCopyInternal
            // 
            this.cdbCopyInternal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cdbCopyInternal.dataTable = null;
            this.cdbCopyInternal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cdbCopyInternal.Location = new System.Drawing.Point(42, 18);
            this.cdbCopyInternal.Name = "cdbCopyInternal";
            this.cdbCopyInternal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cdbCopyInternal.SelectedIndex = -1;
            this.cdbCopyInternal.SelectedValue = null;
            this.cdbCopyInternal.Size = new System.Drawing.Size(655, 27);
            this.cdbCopyInternal.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(703, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Copy Receiver:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(794, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.internalCopyToolStripMenuItem,
            this.externalCopyToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(51, 22);
            this.toolStripSplitButton1.Text = "Copy";
            // 
            // internalCopyToolStripMenuItem
            // 
            this.internalCopyToolStripMenuItem.Name = "internalCopyToolStripMenuItem";
            this.internalCopyToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.internalCopyToolStripMenuItem.Text = "Internal Copy";
            this.internalCopyToolStripMenuItem.Click += new System.EventHandler(this.internalCopyToolStripMenuItem_Click);
            // 
            // externalCopyToolStripMenuItem
            // 
            this.externalCopyToolStripMenuItem.Name = "externalCopyToolStripMenuItem";
            this.externalCopyToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.externalCopyToolStripMenuItem.Text = "External Copy";
            this.externalCopyToolStripMenuItem.Click += new System.EventHandler(this.externalCopyToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::Communication.Properties.Resources.del;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton1.Text = "Delete";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 28);
            this.panel2.TabIndex = 8;
            // 
            // cmbTitles
            // 
            this.cmbTitles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTitles.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbTitles.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTitles.BaseCode = 0;
            this.cmbTitles.ChangeColorIfNotEmpty = true;
            this.cmbTitles.ChangeColorOnEnter = true;
            this.cmbTitles.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbTitles.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbTitles.Location = new System.Drawing.Point(52, 2);
            this.cmbTitles.Name = "cmbTitles";
            this.cmbTitles.NotEmpty = false;
            this.cmbTitles.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbTitles.SelectOnEnter = true;
            this.cmbTitles.Size = new System.Drawing.Size(950, 21);
            this.cmbTitles.TabIndex = 4;
            this.cmbTitles.TabStop = false;
            // 
            // grdCopy
            // 
            this.grdCopy.ActionMenu = null;
            this.grdCopy.DataSource = null;
            this.grdCopy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCopy.Edited = false;
            this.grdCopy.Location = new System.Drawing.Point(0, 242);
            this.grdCopy.MultiSelect = true;
            this.grdCopy.Name = "grdCopy";
            this.grdCopy.ShowNavigator = true;
            this.grdCopy.ShowToolbar = true;
            this.grdCopy.Size = new System.Drawing.Size(794, 153);
            this.grdCopy.TabIndex = 5;
            // 
            // JUC_Copy
            // 
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "JUC_Copy";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(794, 423);
            this.Load += new System.EventHandler(this.JUC_Copy_Load);
            this.panel9.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pnlCopy.ResumeLayout(false);
            this.pnlExternalCtr.ResumeLayout(false);
            this.pnlExternalCtr.PerformLayout();
            this.pnlInternalCrt.ResumeLayout(false);
            this.pnlInternalCrt.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel9; private ClassLibrary.UC_Grid jJanusGrid1;
        private System.Windows.Forms.Panel panel8;
        private ClassLibrary.TextEdit textEdit2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblGroupRefer;
        private ClassLibrary.JCodingBox cdbOrgChartForRefer;
        private ClassLibrary.JComboBox cmbTitles;
        private System.Windows.Forms.Button btnOrgChartForRefer;
        private System.Windows.Forms.Label label15;
        private ClassLibrary.JComboBox cmbSendTypeExternal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.JCodingBox cdbCopyExternal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private ClassLibrary.JCodingBox cdbCopyInternal;
        private System.Windows.Forms.GroupBox pnlExternalCtr;
        private System.Windows.Forms.GroupBox pnlInternalCrt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlCopy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.Button btnInternalAdd;
        private System.Windows.Forms.Button btnExAdd;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem internalCopyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem externalCopyToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private ClassLibrary.TextEdit txtCopyExternalFullName;
        private System.Windows.Forms.Label label3;
        public ClassLibrary.JComboBox txtCopyReasonInternal;
        public ClassLibrary.JComboBox txtCopyReasonExternal;
        private System.Windows.Forms.Label label7;
        private ClassLibrary.DateEdit txtPersuitExternal;
        private System.Windows.Forms.Label label18;
        private ClassLibrary.DateEdit txtPersuitInternal;
        private ClassLibrary.JJanusGrid grdCopy;
    }
}
