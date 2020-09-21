namespace Legal
{
    partial class FrmGetContract
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rdamosh = new System.Windows.Forms.RadioButton();
            this.rdaestate = new System.Windows.Forms.RadioButton();
            this.chkpersonliner = new System.Windows.Forms.CheckBox();
            this.ChkActive = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkAsset = new System.Windows.Forms.CheckBox();
            this.chkPerson = new System.Windows.Forms.CheckBox();
            this.TxtDateout1 = new ClassLibrary.DateEdit(this.components);
            this.txtBuild = new ClassLibrary.TextEdit(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDatein1 = new ClassLibrary.DateEdit(this.components);
            this.txtPerson = new ClassLibrary.TextEdit(this.components);
            this.chklistMarkets = new System.Windows.Forms.CheckedListBox();
            this.PersonSearch = new System.Windows.Forms.Button();
            this.txtDateDE = new ClassLibrary.DateEdit(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.chklistContracts = new System.Windows.Forms.CheckedListBox();
            this.TxtDateout = new ClassLibrary.DateEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDateDS = new ClassLibrary.DateEdit(this.components);
            this.txtDatein = new ClassLibrary.DateEdit(this.components);
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdContracts = new ClassLibrary.JJanusGrid();
            this.chklistContractType = new System.Windows.Forms.CheckedListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 63);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1121, 274);
            this.tabControl1.TabIndex = 92;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chklistContractType);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.chkAsset);
            this.tabPage1.Controls.Add(this.chkPerson);
            this.tabPage1.Controls.Add(this.TxtDateout1);
            this.tabPage1.Controls.Add(this.txtBuild);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtDatein1);
            this.tabPage1.Controls.Add(this.txtPerson);
            this.tabPage1.Controls.Add(this.chklistMarkets);
            this.tabPage1.Controls.Add(this.PersonSearch);
            this.tabPage1.Controls.Add(this.txtDateDE);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.chklistContracts);
            this.tabPage1.Controls.Add(this.TxtDateout);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtDateDS);
            this.tabPage1.Controls.Add(this.txtDatein);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabPage1.Size = new System.Drawing.Size(1113, 245);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "پارامترهاي جستجو";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdamosh);
            this.groupBox5.Controls.Add(this.rdaestate);
            this.groupBox5.Controls.Add(this.chkpersonliner);
            this.groupBox5.Controls.Add(this.ChkActive);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox5.Location = new System.Drawing.Point(3, 187);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1107, 55);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "جزئيات نمايش در خروجي";
            // 
            // rdamosh
            // 
            this.rdamosh.AutoSize = true;
            this.rdamosh.Location = new System.Drawing.Point(6, 22);
            this.rdamosh.Name = "rdamosh";
            this.rdamosh.Size = new System.Drawing.Size(74, 20);
            this.rdamosh.TabIndex = 1;
            this.rdamosh.Text = "مشاعات";
            this.rdamosh.UseVisualStyleBackColor = true;
            // 
            // rdaestate
            // 
            this.rdaestate.AutoSize = true;
            this.rdaestate.Checked = true;
            this.rdaestate.Location = new System.Drawing.Point(97, 22);
            this.rdaestate.Name = "rdaestate";
            this.rdaestate.Size = new System.Drawing.Size(111, 20);
            this.rdaestate.TabIndex = 0;
            this.rdaestate.TabStop = true;
            this.rdaestate.Text = "واحدهاي تجاري";
            this.rdaestate.UseVisualStyleBackColor = true;
            // 
            // chkpersonliner
            // 
            this.chkpersonliner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkpersonliner.AutoSize = true;
            this.chkpersonliner.Location = new System.Drawing.Point(805, 22);
            this.chkpersonliner.Name = "chkpersonliner";
            this.chkpersonliner.Size = new System.Drawing.Size(286, 20);
            this.chkpersonliner.TabIndex = 21;
            this.chkpersonliner.Text = "اطلاعات افراد طرف قرارداد را در يك خط نشان بده";
            this.chkpersonliner.UseVisualStyleBackColor = true;
            this.chkpersonliner.CheckedChanged += new System.EventHandler(this.chkpersonliner_CheckedChanged);
            // 
            // ChkActive
            // 
            this.ChkActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChkActive.AutoSize = true;
            this.ChkActive.Checked = true;
            this.ChkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkActive.Location = new System.Drawing.Point(520, 22);
            this.ChkActive.Name = "ChkActive";
            this.ChkActive.Size = new System.Drawing.Size(268, 20);
            this.ChkActive.TabIndex = 16;
            this.ChkActive.Text = "فقط  اطلاعات قراردادهاي جاري را نمايش بده";
            this.ChkActive.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(750, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 16);
            this.label9.TabIndex = 97;
            this.label9.Text = "تا";
            // 
            // chkAsset
            // 
            this.chkAsset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAsset.AutoSize = true;
            this.chkAsset.Checked = true;
            this.chkAsset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAsset.Location = new System.Drawing.Point(430, 102);
            this.chkAsset.Name = "chkAsset";
            this.chkAsset.Size = new System.Drawing.Size(279, 20);
            this.chkAsset.TabIndex = 19;
            this.chkAsset.Text = "جزئيات اطلاعات املاك را با خروجي تركيب شود";
            this.chkAsset.UseVisualStyleBackColor = true;
            this.chkAsset.CheckedChanged += new System.EventHandler(this.chkAsset_CheckedChanged);
            // 
            // chkPerson
            // 
            this.chkPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPerson.AutoSize = true;
            this.chkPerson.Checked = true;
            this.chkPerson.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPerson.Location = new System.Drawing.Point(414, 133);
            this.chkPerson.Name = "chkPerson";
            this.chkPerson.Size = new System.Drawing.Size(295, 20);
            this.chkPerson.TabIndex = 18;
            this.chkPerson.Text = "جزئيات اطلاعات اشخاص را با خروجي تركيب شود";
            this.chkPerson.UseVisualStyleBackColor = true;
            // 
            // TxtDateout1
            // 
            this.TxtDateout1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtDateout1.ChangeColorIfNotEmpty = true;
            this.TxtDateout1.ChangeColorOnEnter = true;
            this.TxtDateout1.Date = new System.DateTime(((long)(0)));
            this.TxtDateout1.InBackColor = System.Drawing.SystemColors.Info;
            this.TxtDateout1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtDateout1.InsertInDatesTable = true;
            this.TxtDateout1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.TxtDateout1.Location = new System.Drawing.Point(423, 8);
            this.TxtDateout1.Mask = "0000/00/00";
            this.TxtDateout1.Name = "TxtDateout1";
            this.TxtDateout1.NotEmpty = false;
            this.TxtDateout1.NotEmptyColor = System.Drawing.Color.Red;
            this.TxtDateout1.Size = new System.Drawing.Size(76, 23);
            this.TxtDateout1.TabIndex = 96;
            // 
            // txtBuild
            // 
            this.txtBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuild.ChangeColorIfNotEmpty = false;
            this.txtBuild.ChangeColorOnEnter = true;
            this.txtBuild.Enabled = false;
            this.txtBuild.InBackColor = System.Drawing.SystemColors.Info;
            this.txtBuild.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBuild.Location = new System.Drawing.Point(765, 101);
            this.txtBuild.Name = "txtBuild";
            this.txtBuild.Negative = true;
            this.txtBuild.NotEmpty = false;
            this.txtBuild.NotEmptyColor = System.Drawing.Color.Red;
            this.txtBuild.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBuild.SelectOnEnter = true;
            this.txtBuild.Size = new System.Drawing.Size(242, 23);
            this.txtBuild.TabIndex = 15;
            this.txtBuild.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(505, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 16);
            this.label8.TabIndex = 95;
            this.label8.Text = "الي";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button2.Location = new System.Drawing.Point(725, 101);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(879, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 16);
            this.label2.TabIndex = 93;
            this.label2.Text = "الي";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1013, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "اطلاعات املاك :";
            // 
            // txtDatein1
            // 
            this.txtDatein1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDatein1.ChangeColorIfNotEmpty = true;
            this.txtDatein1.ChangeColorOnEnter = true;
            this.txtDatein1.Date = new System.DateTime(((long)(0)));
            this.txtDatein1.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDatein1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDatein1.InsertInDatesTable = true;
            this.txtDatein1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDatein1.Location = new System.Drawing.Point(797, 8);
            this.txtDatein1.Mask = "0000/00/00";
            this.txtDatein1.Name = "txtDatein1";
            this.txtDatein1.NotEmpty = false;
            this.txtDatein1.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDatein1.Size = new System.Drawing.Size(76, 23);
            this.txtDatein1.TabIndex = 94;
            // 
            // txtPerson
            // 
            this.txtPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPerson.ChangeColorIfNotEmpty = false;
            this.txtPerson.ChangeColorOnEnter = true;
            this.txtPerson.Enabled = false;
            this.txtPerson.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPerson.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPerson.Location = new System.Drawing.Point(765, 132);
            this.txtPerson.Name = "txtPerson";
            this.txtPerson.Negative = true;
            this.txtPerson.NotEmpty = false;
            this.txtPerson.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPerson.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPerson.SelectOnEnter = true;
            this.txtPerson.Size = new System.Drawing.Size(242, 23);
            this.txtPerson.TabIndex = 12;
            this.txtPerson.TextMode = ClassLibrary.TextModes.Text;
            // 
            // chklistMarkets
            // 
            this.chklistMarkets.FormattingEnabled = true;
            this.chklistMarkets.Location = new System.Drawing.Point(143, 6);
            this.chklistMarkets.Name = "chklistMarkets";
            this.chklistMarkets.Size = new System.Drawing.Size(207, 76);
            this.chklistMarkets.TabIndex = 88;
            // 
            // PersonSearch
            // 
            this.PersonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PersonSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PersonSearch.Location = new System.Drawing.Point(728, 130);
            this.PersonSearch.Name = "PersonSearch";
            this.PersonSearch.Size = new System.Drawing.Size(28, 26);
            this.PersonSearch.TabIndex = 13;
            this.PersonSearch.Text = "...";
            this.PersonSearch.UseVisualStyleBackColor = true;
            this.PersonSearch.Click += new System.EventHandler(this.PersonSearch_Click);
            // 
            // txtDateDE
            // 
            this.txtDateDE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateDE.ChangeColorIfNotEmpty = true;
            this.txtDateDE.ChangeColorOnEnter = true;
            this.txtDateDE.Date = new System.DateTime(((long)(0)));
            this.txtDateDE.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDateDE.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateDE.InsertInDatesTable = true;
            this.txtDateDE.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDateDE.Location = new System.Drawing.Point(808, 47);
            this.txtDateDE.Mask = "0000/00/00";
            this.txtDateDE.Name = "txtDateDE";
            this.txtDateDE.NotEmpty = false;
            this.txtDateDE.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateDE.Size = new System.Drawing.Size(76, 23);
            this.txtDateDE.TabIndex = 92;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1013, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "مشخصات افراد:";
            // 
            // chklistContracts
            // 
            this.chklistContracts.FormattingEnabled = true;
            this.chklistContracts.Location = new System.Drawing.Point(3, 3);
            this.chklistContracts.Name = "chklistContracts";
            this.chklistContracts.Size = new System.Drawing.Size(134, 184);
            this.chklistContracts.TabIndex = 88;
            this.chklistContracts.SelectedIndexChanged += new System.EventHandler(this.chklistContracts_SelectedIndexChanged);
            // 
            // TxtDateout
            // 
            this.TxtDateout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtDateout.ChangeColorIfNotEmpty = true;
            this.TxtDateout.ChangeColorOnEnter = true;
            this.TxtDateout.Date = new System.DateTime(((long)(0)));
            this.TxtDateout.InBackColor = System.Drawing.SystemColors.Info;
            this.TxtDateout.InForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtDateout.InsertInDatesTable = true;
            this.TxtDateout.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.TxtDateout.Location = new System.Drawing.Point(542, 8);
            this.TxtDateout.Mask = "0000/00/00";
            this.TxtDateout.Name = "TxtDateout";
            this.TxtDateout.NotEmpty = false;
            this.TxtDateout.NotEmptyColor = System.Drawing.Color.Red;
            this.TxtDateout.Size = new System.Drawing.Size(76, 23);
            this.TxtDateout.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(624, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "تاريخ پايان قرارداد :";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(891, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 16);
            this.label5.TabIndex = 91;
            this.label5.Text = "تا";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(995, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "تاريخ شروع قرارداد :";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(994, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 16);
            this.label7.TabIndex = 89;
            this.label7.Text = "تاريخ ثبت قرارداد از:";
            // 
            // txtDateDS
            // 
            this.txtDateDS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDateDS.ChangeColorIfNotEmpty = true;
            this.txtDateDS.ChangeColorOnEnter = true;
            this.txtDateDS.Date = new System.DateTime(((long)(0)));
            this.txtDateDS.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDateDS.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateDS.InsertInDatesTable = true;
            this.txtDateDS.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDateDS.Location = new System.Drawing.Point(913, 47);
            this.txtDateDS.Mask = "0000/00/00";
            this.txtDateDS.Name = "txtDateDS";
            this.txtDateDS.NotEmpty = false;
            this.txtDateDS.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateDS.Size = new System.Drawing.Size(76, 23);
            this.txtDateDS.TabIndex = 90;
            // 
            // txtDatein
            // 
            this.txtDatein.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDatein.ChangeColorIfNotEmpty = true;
            this.txtDatein.ChangeColorOnEnter = true;
            this.txtDatein.Date = new System.DateTime(((long)(0)));
            this.txtDatein.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDatein.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDatein.InsertInDatesTable = true;
            this.txtDatein.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDatein.Location = new System.Drawing.Point(913, 8);
            this.txtDatein.Mask = "0000/00/00";
            this.txtDatein.Name = "txtDatein";
            this.txtDatein.NotEmpty = false;
            this.txtDatein.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDatein.Size = new System.Drawing.Size(76, 23);
            this.txtDatein.TabIndex = 24;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button3);
            this.groupBox7.Controls.Add(this.button1);
            this.groupBox7.Controls.Add(this.btnRefresh);
            this.groupBox7.Controls.Add(this.btnSelect);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1121, 63);
            this.groupBox7.TabIndex = 91;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "عمليات";
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Right;
            this.button3.Location = new System.Drawing.Point(952, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(166, 41);
            this.button3.TabIndex = 23;
            this.button3.Text = "تهيه گزارش طرف هاي فعال";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Location = new System.Drawing.Point(193, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 41);
            this.button1.TabIndex = 10;
            this.button1.Text = "جستجو ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRefresh.Location = new System.Drawing.Point(92, 19);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(101, 41);
            this.btnRefresh.TabIndex = 20;
            this.btnRefresh.Text = "پاك كردن صفحه";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSelect.Enabled = false;
            this.btnSelect.Location = new System.Drawing.Point(3, 19);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(89, 41);
            this.btnSelect.TabIndex = 22;
            this.btnSelect.Text = "انتخاب";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(-128, 596);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1121, 355);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "خروجي جستجو";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // grdContracts
            // 
            this.grdContracts.ActionClassName = "";
            this.grdContracts.ActionMenu = null;
            this.grdContracts.DataSource = null;
            this.grdContracts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdContracts.Edited = false;
            this.grdContracts.Location = new System.Drawing.Point(0, 337);
            this.grdContracts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdContracts.MultiSelect = false;
            this.grdContracts.Name = "grdContracts";
            this.grdContracts.ShowNavigator = true;
            this.grdContracts.ShowToolbar = true;
            this.grdContracts.Size = new System.Drawing.Size(1121, 404);
            this.grdContracts.TabIndex = 0;
            this.grdContracts.OnRowDBClick += new ClassLibrary.JJanusGrid.RowDBClick(this.grdContracts_OnRowDBClick);
            // 
            // chklistContractType
            // 
            this.chklistContractType.FormattingEnabled = true;
            this.chklistContractType.Location = new System.Drawing.Point(143, 93);
            this.chklistContractType.Name = "chklistContractType";
            this.chklistContractType.Size = new System.Drawing.Size(207, 94);
            this.chklistContractType.TabIndex = 98;
            // 
            // FrmGetContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 741);
            this.Controls.Add(this.grdContracts);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmGetContract";
            this.Text = "فرم جستجوي قرارداد";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmContractPerson_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button PersonSearch;
        private ClassLibrary.TextEdit txtPerson;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private ClassLibrary.TextEdit txtBuild;
        private ClassLibrary.JJanusGrid grdContracts;
        private System.Windows.Forms.CheckBox ChkActive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkPerson;
        private System.Windows.Forms.CheckBox chkAsset;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSelect;
        private ClassLibrary.DateEdit txtDatein;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.DateEdit TxtDateout;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox chklistContracts;
        private System.Windows.Forms.CheckedListBox chklistMarkets;
        private ClassLibrary.DateEdit txtDateDE;
        private System.Windows.Forms.Label label5;
        private ClassLibrary.DateEdit txtDateDS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rdaestate;
        private System.Windows.Forms.RadioButton rdamosh;
        private System.Windows.Forms.CheckBox chkpersonliner;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ClassLibrary.DateEdit TxtDateout1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.DateEdit txtDatein1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckedListBox chklistContractType;
    }
}
