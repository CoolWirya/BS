namespace Legal
{
    partial class JContractTransferShareForm
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
            ClassLibrary.JPopupMenu jPopupMenu1 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPriceBase = new ClassLibrary.TextEdit(this.components);
            this.txtTime = new ClassLibrary.TimeEdit(this.components);
            this.chAgent = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chMosalehe = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtShIndex = new ClassLibrary.TextEdit(this.components);
            this.txtShNote = new ClassLibrary.TextEdit(this.components);
            this.txtPrice = new ClassLibrary.TextEdit(this.components);
            this.txtTax = new ClassLibrary.TextEdit(this.components);
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdSheets = new ClassLibrary.JDataGrid();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSheets)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(525, 6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 25);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "قبلی";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(606, 6);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 25);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = "بعدی";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 398);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 38);
            this.panel1.TabIndex = 12;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtPriceBase);
            this.groupBox3.Controls.Add(this.txtTime);
            this.groupBox3.Controls.Add(this.chAgent);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.chMosalehe);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtShIndex);
            this.groupBox3.Controls.Add(this.txtShNote);
            this.groupBox3.Controls.Add(this.txtPrice);
            this.groupBox3.Controls.Add(this.txtTax);
            this.groupBox3.Controls.Add(this.txtDate);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 230);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(690, 168);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(361, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "قیمت واحد:";
            // 
            // txtPriceBase
            // 
            this.txtPriceBase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPriceBase.ChangeColorIfNotEmpty = false;
            this.txtPriceBase.ChangeColorOnEnter = true;
            this.txtPriceBase.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPriceBase.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPriceBase.Location = new System.Drawing.Point(237, 30);
            this.txtPriceBase.Name = "txtPriceBase";
            this.txtPriceBase.Negative = true;
            this.txtPriceBase.NotEmpty = false;
            this.txtPriceBase.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPriceBase.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPriceBase.SelectOnEnter = true;
            this.txtPriceBase.Size = new System.Drawing.Size(100, 23);
            this.txtPriceBase.TabIndex = 5;
            this.txtPriceBase.Text = "0";
            this.txtPriceBase.TextMode = ClassLibrary.TextModes.Money;
            this.txtPriceBase.TextChanged += new System.EventHandler(this.txtPriceBase_TextChanged);
            // 
            // txtTime
            // 
            this.txtTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTime.ChangeColorIfNotEmpty = true;
            this.txtTime.ChangeColorOnEnter = true;
            this.txtTime.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtTime.InBackColor = System.Drawing.SystemColors.Info;
            this.txtTime.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTime.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtTime.Location = new System.Drawing.Point(541, 22);
            this.txtTime.Mask = "00:00";
            this.txtTime.Name = "txtTime";
            this.txtTime.NotEmpty = false;
            this.txtTime.NotEmptyColor = System.Drawing.Color.Red;
            this.txtTime.Size = new System.Drawing.Size(42, 24);
            this.txtTime.TabIndex = 0;
            this.txtTime.ValidatingType = typeof(System.DateTime);
            // 
            // chAgent
            // 
            this.chAgent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chAgent.AutoSize = true;
            this.chAgent.Location = new System.Drawing.Point(327, 135);
            this.chAgent.Name = "chAgent";
            this.chAgent.Size = new System.Drawing.Size(93, 20);
            this.chAgent.TabIndex = 7;
            this.chAgent.Text = "انتقال وکالت";
            this.chAgent.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(352, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "شماره ردیف:";
            // 
            // chMosalehe
            // 
            this.chMosalehe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chMosalehe.AutoSize = true;
            this.chMosalehe.Location = new System.Drawing.Point(508, 135);
            this.chMosalehe.Name = "chMosalehe";
            this.chMosalehe.Size = new System.Drawing.Size(154, 20);
            this.chMosalehe.TabIndex = 6;
            this.chMosalehe.Text = "انتقال به صورت مصالحه";
            this.chMosalehe.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(370, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "قیمت کل:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(612, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "مالیات:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(586, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "شماره دفتر:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(586, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "تاریخ انتقال:";
            // 
            // txtShIndex
            // 
            this.txtShIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShIndex.ChangeColorIfNotEmpty = false;
            this.txtShIndex.ChangeColorOnEnter = true;
            this.txtShIndex.InBackColor = System.Drawing.SystemColors.Info;
            this.txtShIndex.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtShIndex.Location = new System.Drawing.Point(237, 59);
            this.txtShIndex.Name = "txtShIndex";
            this.txtShIndex.Negative = true;
            this.txtShIndex.NotEmpty = false;
            this.txtShIndex.NotEmptyColor = System.Drawing.Color.Red;
            this.txtShIndex.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtShIndex.SelectOnEnter = true;
            this.txtShIndex.Size = new System.Drawing.Size(100, 23);
            this.txtShIndex.TabIndex = 3;
            this.txtShIndex.Text = "0";
            this.txtShIndex.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // txtShNote
            // 
            this.txtShNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShNote.ChangeColorIfNotEmpty = false;
            this.txtShNote.ChangeColorOnEnter = true;
            this.txtShNote.InBackColor = System.Drawing.SystemColors.Info;
            this.txtShNote.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtShNote.Location = new System.Drawing.Point(483, 58);
            this.txtShNote.Name = "txtShNote";
            this.txtShNote.Negative = true;
            this.txtShNote.NotEmpty = false;
            this.txtShNote.NotEmptyColor = System.Drawing.Color.Red;
            this.txtShNote.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtShNote.SelectOnEnter = true;
            this.txtShNote.Size = new System.Drawing.Size(100, 23);
            this.txtShNote.TabIndex = 2;
            this.txtShNote.Text = "0";
            this.txtShNote.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.ChangeColorIfNotEmpty = false;
            this.txtPrice.ChangeColorOnEnter = true;
            this.txtPrice.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPrice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPrice.Location = new System.Drawing.Point(237, 96);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Negative = true;
            this.txtPrice.NotEmpty = false;
            this.txtPrice.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrice.SelectOnEnter = true;
            this.txtPrice.Size = new System.Drawing.Size(100, 23);
            this.txtPrice.TabIndex = 5;
            this.txtPrice.Text = "0";
            this.txtPrice.TextMode = ClassLibrary.TextModes.Money;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            // 
            // txtTax
            // 
            this.txtTax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTax.ChangeColorIfNotEmpty = false;
            this.txtTax.ChangeColorOnEnter = true;
            this.txtTax.InBackColor = System.Drawing.SystemColors.Info;
            this.txtTax.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTax.Location = new System.Drawing.Point(483, 92);
            this.txtTax.Name = "txtTax";
            this.txtTax.Negative = true;
            this.txtTax.NotEmpty = false;
            this.txtTax.NotEmptyColor = System.Drawing.Color.Red;
            this.txtTax.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTax.SelectOnEnter = true;
            this.txtTax.Size = new System.Drawing.Size(100, 23);
            this.txtTax.TabIndex = 4;
            this.txtTax.Text = "0";
            this.txtTax.TextMode = ClassLibrary.TextModes.Money;
            // 
            // txtDate
            // 
            this.txtDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDate.ChangeColorIfNotEmpty = true;
            this.txtDate.ChangeColorOnEnter = true;
            this.txtDate.Date = new System.DateTime(((long)(0)));
            this.txtDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDate.InsertInDatesTable = true;
            this.txtDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDate.Location = new System.Drawing.Point(454, 21);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(81, 23);
            this.txtDate.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdSheets);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(690, 230);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "برگه های قابل فروش";
            // 
            // grdSheets
            // 
            this.grdSheets.ActionMenu = jPopupMenu1;
            this.grdSheets.AllowUserToAddRows = false;
            this.grdSheets.AllowUserToDeleteRows = false;
            this.grdSheets.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.grdSheets.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSheets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdSheets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSheets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSheets.EnableContexMenu = true;
            this.grdSheets.KeyName = null;
            this.grdSheets.Location = new System.Drawing.Point(3, 19);
            this.grdSheets.Name = "grdSheets";
            this.grdSheets.ReadHeadersFromDB = false;
            this.grdSheets.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.grdSheets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSheets.ShowRowNumber = true;
            this.grdSheets.Size = new System.Drawing.Size(684, 208);
            this.grdSheets.TabIndex = 2;
            this.grdSheets.TableName = null;
            this.grdSheets.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSheets_CellEndEdit);
            // 
            // JContractTransferShareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 436);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Name = "JContractTransferShareForm";
            this.Text = "انتقال سهام";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.JContractTransferShareForm_FormClosed);
            this.Load += new System.EventHandler(this.JContractTransferShareForm_Load);
            this.VisibleChanged += new System.EventHandler(this.JContractTransferShareForm_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSheets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private ClassLibrary.TimeEdit txtTime;
        private System.Windows.Forms.CheckBox chAgent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chMosalehe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit txtShIndex;
        private ClassLibrary.TextEdit txtShNote;
        private ClassLibrary.TextEdit txtPrice;
        private ClassLibrary.TextEdit txtTax;
        private ClassLibrary.DateEdit txtDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.JDataGrid grdSheets;
        private System.Windows.Forms.Label label6;
        private ClassLibrary.TextEdit txtPriceBase;

    }
}