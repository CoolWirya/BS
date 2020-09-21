namespace ShareProfit
{
    partial class JEditDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JEditDetails));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.txtRegName = new ClassLibrary.TextEdit(this.components);
            this.txtCost = new ClassLibrary.MoneyEdit(this.components);
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.txtStockNo = new ClassLibrary.TextEdit(this.components);
            this.txtSheetNo = new ClassLibrary.NumEdit();
            this.txtPCode = new ClassLibrary.NumEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.txtRegName);
            this.groupBox1.Controls.Add(this.txtCost);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.txtStockNo);
            this.groupBox1.Controls.Add(this.txtSheetNo);
            this.groupBox1.Controls.Add(this.txtPCode);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 176);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtDesc
            // 
            this.txtDesc.ChangeColorIfNotEmpty = true;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(46, 141);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(376, 23);
            this.txtDesc.TabIndex = 6;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtRegName
            // 
            this.txtRegName.ChangeColorIfNotEmpty = true;
            this.txtRegName.ChangeColorOnEnter = true;
            this.txtRegName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtRegName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRegName.Location = new System.Drawing.Point(46, 110);
            this.txtRegName.Name = "txtRegName";
            this.txtRegName.Negative = true;
            this.txtRegName.NotEmpty = false;
            this.txtRegName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtRegName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRegName.SelectOnEnter = true;
            this.txtRegName.Size = new System.Drawing.Size(376, 23);
            this.txtRegName.TabIndex = 5;
            this.txtRegName.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtCost
            // 
            this.txtCost.ChangeColorIfNotEmpty = true;
            this.txtCost.ChangeColorOnEnter = true;
            this.txtCost.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCost.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCost.LabelToDisplay = null;
            this.txtCost.Location = new System.Drawing.Point(46, 80);
            this.txtCost.Name = "txtCost";
            this.txtCost.Negative = true;
            this.txtCost.NotEmpty = false;
            this.txtCost.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCost.SelectOnEnter = true;
            this.txtCost.Size = new System.Drawing.Size(100, 23);
            this.txtCost.TabIndex = 4;
            this.txtCost.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // txtDate
            // 
            this.txtDate.ChangeColorIfNotEmpty = true;
            this.txtDate.ChangeColorOnEnter = true;
            this.txtDate.Date = new System.DateTime(((long)(0)));
            this.txtDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDate.InsertInDatesTable = true;
            this.txtDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDate.Location = new System.Drawing.Point(322, 80);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(100, 23);
            this.txtDate.TabIndex = 3;
            // 
            // txtStockNo
            // 
            this.txtStockNo.ChangeColorIfNotEmpty = true;
            this.txtStockNo.ChangeColorOnEnter = true;
            this.txtStockNo.InBackColor = System.Drawing.SystemColors.Info;
            this.txtStockNo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStockNo.Location = new System.Drawing.Point(46, 18);
            this.txtStockNo.Name = "txtStockNo";
            this.txtStockNo.Negative = true;
            this.txtStockNo.NotEmpty = false;
            this.txtStockNo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtStockNo.ReadOnly = true;
            this.txtStockNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtStockNo.SelectOnEnter = true;
            this.txtStockNo.Size = new System.Drawing.Size(376, 23);
            this.txtStockNo.TabIndex = 0;
            this.txtStockNo.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtSheetNo
            // 
            this.txtSheetNo.ChangeColorIfNotEmpty = true;
            this.txtSheetNo.ChangeColorOnEnter = true;
            this.txtSheetNo.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSheetNo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSheetNo.Location = new System.Drawing.Point(46, 49);
            this.txtSheetNo.Name = "txtSheetNo";
            this.txtSheetNo.Negative = true;
            this.txtSheetNo.NotEmpty = false;
            this.txtSheetNo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSheetNo.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtSheetNo.ReadOnly = true;
            this.txtSheetNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSheetNo.SelectOnEnter = true;
            this.txtSheetNo.Size = new System.Drawing.Size(100, 23);
            this.txtSheetNo.TabIndex = 2;
            this.txtSheetNo.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtPCode
            // 
            this.txtPCode.ChangeColorIfNotEmpty = true;
            this.txtPCode.ChangeColorOnEnter = true;
            this.txtPCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPCode.Location = new System.Drawing.Point(322, 49);
            this.txtPCode.Name = "txtPCode";
            this.txtPCode.Negative = true;
            this.txtPCode.NotEmpty = false;
            this.txtPCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPCode.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtPCode.ReadOnly = true;
            this.txtPCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPCode.SelectOnEnter = true;
            this.txtPCode.Size = new System.Drawing.Size(100, 23);
            this.txtPCode.TabIndex = 1;
            this.txtPCode.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(193, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "SheetNo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(315, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "ManagementsharesHolderCode:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(447, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "StockNo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(447, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "PayDate:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "PayCost:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(446, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "PayDesc:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(438, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "RegName:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(33, 182);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(124, 182);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // JEditDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(536, 216);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Name = "JEditDetails";
            this.Text = "EditPayDetails";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        public ClassLibrary.NumEdit txtPCode;
        public ClassLibrary.TextEdit txtStockNo;
        public ClassLibrary.NumEdit txtSheetNo;
        public ClassLibrary.TextEdit txtDesc;
        public ClassLibrary.TextEdit txtRegName;
        public ClassLibrary.MoneyEdit txtCost;
        public ClassLibrary.DateEdit txtDate;
    }
}