namespace Security
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtNumber = new ClassLibrary.TextEdit(this.components);
            this.ChkActive = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDatetOut = new ClassLibrary.DateEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txDatein = new ClassLibrary.DateEdit(this.components);
            this.CmbTypeGh = new ClassLibrary.JComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBuild = new ClassLibrary.TextEdit(this.components);
            this.PersonSearch = new System.Windows.Forms.Button();
            this.txtPerson = new ClassLibrary.TextEdit(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdContracts = new ClassLibrary.JJanusGrid();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TxtNumber);
            this.groupBox1.Controls.Add(this.ChkActive);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDatetOut);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txDatein);
            this.groupBox1.Controls.Add(this.CmbTypeGh);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBuild);
            this.groupBox1.Controls.Add(this.PersonSearch);
            this.groupBox1.Controls.Add(this.txtPerson);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(960, 142);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "املاك";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(862, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = " شماره قرارداد :";
            // 
            // TxtNumber
            // 
            this.TxtNumber.ChangeColorIfNotEmpty = false;
            this.TxtNumber.ChangeColorOnEnter = true;
            this.TxtNumber.InBackColor = System.Drawing.SystemColors.Info;
            this.TxtNumber.InForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtNumber.Location = new System.Drawing.Point(710, 68);
            this.TxtNumber.Name = "TxtNumber";
            this.TxtNumber.Negative = true;
            this.TxtNumber.NotEmpty = false;
            this.TxtNumber.NotEmptyColor = System.Drawing.Color.Red;
            this.TxtNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtNumber.SelectOnEnter = true;
            this.TxtNumber.Size = new System.Drawing.Size(150, 23);
            this.TxtNumber.TabIndex = 23;
            this.TxtNumber.TextMode = ClassLibrary.TextModes.Text;
            // 
            // ChkActive
            // 
            this.ChkActive.AutoSize = true;
            this.ChkActive.Location = new System.Drawing.Point(17, 26);
            this.ChkActive.Name = "ChkActive";
            this.ChkActive.Size = new System.Drawing.Size(160, 20);
            this.ChkActive.TabIndex = 16;
            this.ChkActive.Text = "فقط فعال ها را نشان بده";
            this.ChkActive.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(307, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "تاريخ پايان قرارداد :";
            // 
            // txtDatetOut
            // 
            this.txtDatetOut.ChangeColorIfNotEmpty = true;
            this.txtDatetOut.ChangeColorOnEnter = true;
            this.txtDatetOut.Date = new System.DateTime(((long)(0)));
            this.txtDatetOut.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDatetOut.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDatetOut.InsertInDatesTable = true;
            this.txtDatetOut.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDatetOut.Location = new System.Drawing.Point(205, 23);
            this.txtDatetOut.Mask = "0000/00/00";
            this.txtDatetOut.Name = "txtDatetOut";
            this.txtDatetOut.NotEmpty = false;
            this.txtDatetOut.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDatetOut.Size = new System.Drawing.Size(100, 23);
            this.txtDatetOut.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(584, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "تاريخ شروع قراداد :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txDatein
            // 
            this.txDatein.ChangeColorIfNotEmpty = true;
            this.txDatein.ChangeColorOnEnter = true;
            this.txDatein.Date = new System.DateTime(((long)(0)));
            this.txDatein.InBackColor = System.Drawing.SystemColors.Info;
            this.txDatein.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txDatein.InsertInDatesTable = true;
            this.txDatein.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txDatein.Location = new System.Drawing.Point(449, 24);
            this.txDatein.Mask = "0000/00/00";
            this.txDatein.Name = "txDatein";
            this.txDatein.NotEmpty = false;
            this.txDatein.NotEmptyColor = System.Drawing.Color.Red;
            this.txDatein.Size = new System.Drawing.Size(133, 23);
            this.txDatein.TabIndex = 18;
            // 
            // CmbTypeGh
            // 
            this.CmbTypeGh.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CmbTypeGh.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbTypeGh.BaseCode = 0;
            this.CmbTypeGh.ChangeColorIfNotEmpty = true;
            this.CmbTypeGh.ChangeColorOnEnter = true;
            this.CmbTypeGh.FormattingEnabled = true;
            this.CmbTypeGh.InBackColor = System.Drawing.SystemColors.Info;
            this.CmbTypeGh.InForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbTypeGh.Location = new System.Drawing.Point(710, 23);
            this.CmbTypeGh.Name = "CmbTypeGh";
            this.CmbTypeGh.NotEmpty = false;
            this.CmbTypeGh.NotEmptyColor = System.Drawing.Color.Red;
            this.CmbTypeGh.SelectOnEnter = true;
            this.CmbTypeGh.Size = new System.Drawing.Size(175, 24);
            this.CmbTypeGh.TabIndex = 17;
            this.CmbTypeGh.SelectedIndexChanged += new System.EventHandler(this.CmbTypeGh_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(358, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "كد املاك:";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button2.Location = new System.Drawing.Point(171, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(884, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "نوع قرارداد :";
            // 
            // txtBuild
            // 
            this.txtBuild.ChangeColorIfNotEmpty = false;
            this.txtBuild.ChangeColorOnEnter = true;
            this.txtBuild.Enabled = false;
            this.txtBuild.InBackColor = System.Drawing.SystemColors.Info;
            this.txtBuild.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBuild.Location = new System.Drawing.Point(205, 64);
            this.txtBuild.Name = "txtBuild";
            this.txtBuild.Negative = true;
            this.txtBuild.NotEmpty = false;
            this.txtBuild.NotEmptyColor = System.Drawing.Color.Red;
            this.txtBuild.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBuild.SelectOnEnter = true;
            this.txtBuild.Size = new System.Drawing.Size(147, 23);
            this.txtBuild.TabIndex = 15;
            this.txtBuild.TextMode = ClassLibrary.TextModes.Text;
            // 
            // PersonSearch
            // 
            this.PersonSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PersonSearch.Location = new System.Drawing.Point(419, 66);
            this.PersonSearch.Name = "PersonSearch";
            this.PersonSearch.Size = new System.Drawing.Size(28, 26);
            this.PersonSearch.TabIndex = 13;
            this.PersonSearch.Text = "...";
            this.PersonSearch.UseVisualStyleBackColor = true;
            this.PersonSearch.Click += new System.EventHandler(this.PersonSearch_Click);
            // 
            // txtPerson
            // 
            this.txtPerson.ChangeColorIfNotEmpty = false;
            this.txtPerson.ChangeColorOnEnter = true;
            this.txtPerson.Enabled = false;
            this.txtPerson.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPerson.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPerson.Location = new System.Drawing.Point(449, 68);
            this.txtPerson.Name = "txtPerson";
            this.txtPerson.Negative = true;
            this.txtPerson.NotEmpty = false;
            this.txtPerson.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPerson.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPerson.SelectOnEnter = true;
            this.txtPerson.Size = new System.Drawing.Size(133, 23);
            this.txtPerson.TabIndex = 12;
            this.txtPerson.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(584, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "كد شناسايي فرد :";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(3, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(954, 29);
            this.button1.TabIndex = 10;
            this.button1.Text = "جستجو ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grdContracts);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(960, 448);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "اطلاعات قراردادها";
            // 
            // grdContracts
            // 
            this.grdContracts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdContracts.Location = new System.Drawing.Point(3, 19);
            this.grdContracts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdContracts.MultiSelect = false;
            this.grdContracts.Name = "grdContracts";
            this.grdContracts.Size = new System.Drawing.Size(954, 426);
            this.grdContracts.TabIndex = 0;
            this.grdContracts.Click += new System.EventHandler(this.grdContracts_Click);
            this.grdContracts.OnRowDBClick += new ClassLibrary.JJanusGrid.RowDBClick(this.grdContracts_OnRowDBClick);
            // 
            // FrmGetContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 590);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmGetContract";
            this.Text = "فرم جستجوي قرارداد";
            this.Load += new System.EventHandler(this.FrmContractPerson_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
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
        private ClassLibrary.JComboBox CmbTypeGh;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.DateEdit txDatein;
        private System.Windows.Forms.Label label4;
        private ClassLibrary.DateEdit txtDatetOut;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private ClassLibrary.TextEdit TxtNumber;
    }
}
