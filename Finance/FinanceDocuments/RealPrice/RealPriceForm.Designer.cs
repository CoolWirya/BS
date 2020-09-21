namespace Finance
{
    partial class JRealPriceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JRealPriceForm));
            this.PersonReciver = new ClassLibrary.JUCPerson();
            this.personExport = new ClassLibrary.JUCPerson();
            this.cmbConcern = new ClassLibrary.JComboBox(this.components);
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtDeliverDate = new ClassLibrary.DateEdit(this.components);
            this.label20 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtPrice = new ClassLibrary.TextEdit(this.components);
            this.label22 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSaveClose = new System.Windows.Forms.Button();
            this.btnSwap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PersonReciver
            // 
            this.PersonReciver.FilterPerson = null;
            this.PersonReciver.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.PersonReciver.LableGroup = null;
            this.PersonReciver.Location = new System.Drawing.Point(394, 44);
            this.PersonReciver.Name = "PersonReciver";
            this.PersonReciver.PersonType = ClassLibrary.JPersonTypes.None;
            this.PersonReciver.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PersonReciver.SelectedCode = 0;
            this.PersonReciver.Size = new System.Drawing.Size(392, 178);
            this.PersonReciver.TabIndex = 4;
            // 
            // personExport
            // 
            this.personExport.FilterPerson = null;
            this.personExport.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.personExport.LableGroup = null;
            this.personExport.Location = new System.Drawing.Point(0, 43);
            this.personExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.personExport.Name = "personExport";
            this.personExport.PersonType = ClassLibrary.JPersonTypes.None;
            this.personExport.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.personExport.SelectedCode = 0;
            this.personExport.Size = new System.Drawing.Size(388, 179);
            this.personExport.TabIndex = 5;
            // 
            // cmbConcern
            // 
            this.cmbConcern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbConcern.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbConcern.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbConcern.BaseCode = 0;
            this.cmbConcern.ChangeColorIfNotEmpty = true;
            this.cmbConcern.ChangeColorOnEnter = true;
            this.cmbConcern.FormattingEnabled = true;
            this.cmbConcern.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbConcern.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbConcern.Location = new System.Drawing.Point(468, 14);
            this.cmbConcern.Name = "cmbConcern";
            this.cmbConcern.NotEmpty = false;
            this.cmbConcern.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbConcern.SelectOnEnter = true;
            this.cmbConcern.Size = new System.Drawing.Size(135, 24);
            this.cmbConcern.TabIndex = 3;
            this.cmbConcern.SelectedIndexChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.ChangeColorIfNotEmpty = true;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(17, 260);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(769, 53);
            this.txtDesc.TabIndex = 6;
            this.txtDesc.TabStop = false;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 87;
            this.label2.Text = "توضیحات:";
            // 
            // txtDeliverDate
            // 
            this.txtDeliverDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeliverDate.BackColor = System.Drawing.SystemColors.Info;
            this.txtDeliverDate.ChangeColorIfNotEmpty = true;
            this.txtDeliverDate.ChangeColorOnEnter = true;
            this.txtDeliverDate.Date = new System.DateTime(((long)(0)));
            this.txtDeliverDate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDeliverDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDeliverDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDeliverDate.InsertInDatesTable = true;
            this.txtDeliverDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDeliverDate.Location = new System.Drawing.Point(297, 12);
            this.txtDeliverDate.Mask = "0000/00/00";
            this.txtDeliverDate.Name = "txtDeliverDate";
            this.txtDeliverDate.NotEmpty = false;
            this.txtDeliverDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDeliverDate.Size = new System.Drawing.Size(100, 23);
            this.txtDeliverDate.TabIndex = 2;
            this.txtDeliverDate.TextChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(423, 17);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(37, 16);
            this.label20.TabIndex = 84;
            this.label20.Text = "بابت:";
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(12, 18);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(42, 16);
            this.label23.TabIndex = 86;
            this.label23.Text = "مبلغ :";
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.ChangeColorIfNotEmpty = false;
            this.txtPrice.ChangeColorOnEnter = true;
            this.txtPrice.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPrice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPrice.Location = new System.Drawing.Point(60, 15);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Negative = true;
            this.txtPrice.NotEmpty = false;
            this.txtPrice.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrice.SelectOnEnter = true;
            this.txtPrice.Size = new System.Drawing.Size(132, 23);
            this.txtPrice.TabIndex = 1;
            this.txtPrice.TextMode = ClassLibrary.TextModes.Money;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtNo_TextChanged);
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(212, 15);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(79, 16);
            this.label22.TabIndex = 85;
            this.label22.Text = "تاريخ تحويل :";
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(7, 325);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 24);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "تایید";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(709, 325);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 25);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSaveClose
            // 
            this.btnSaveClose.Location = new System.Drawing.Point(88, 325);
            this.btnSaveClose.Name = "btnSaveClose";
            this.btnSaveClose.Size = new System.Drawing.Size(75, 25);
            this.btnSaveClose.TabIndex = 8;
            this.btnSaveClose.Text = "ذخیره";
            this.btnSaveClose.UseVisualStyleBackColor = true;
            this.btnSaveClose.Visible = false;
            this.btnSaveClose.Click += new System.EventHandler(this.btnSaveClose_Click);
            // 
            // btnSwap
            // 
            this.btnSwap.Image = ((System.Drawing.Image)(resources.GetObject("btnSwap.Image")));
            this.btnSwap.Location = new System.Drawing.Point(331, 59);
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.Size = new System.Drawing.Size(48, 35);
            this.btnSwap.TabIndex = 88;
            this.btnSwap.UseVisualStyleBackColor = true;
            this.btnSwap.Click += new System.EventHandler(this.btnSwap_Click);
            // 
            // JRealPriceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 357);
            this.Controls.Add(this.btnSwap);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSaveClose);
            this.Controls.Add(this.PersonReciver);
            this.Controls.Add(this.personExport);
            this.Controls.Add(this.cmbConcern);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDeliverDate);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label22);
            this.Name = "JRealPriceForm";
            this.Text = "مبلغ نقدی";
            this.Load += new System.EventHandler(this.JRealPriceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ClassLibrary.JUCPerson PersonReciver;
        private ClassLibrary.JUCPerson personExport;
        private ClassLibrary.JComboBox cmbConcern;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.DateEdit txtDeliverDate;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label23;
        private ClassLibrary.TextEdit txtPrice;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSaveClose;
        private System.Windows.Forms.Button btnSwap;
    }
}