namespace StoreManagement
{
    partial class JPaymentContractForm
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
            this.txtPrice = new ClassLibrary.TextEdit(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.chkTax = new System.Windows.Forms.CheckBox();
            this.lblDuty = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMaksore = new ClassLibrary.TextEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.jJanusGrid1 = new ClassLibrary.JJanusGrid();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.ChangeColorIfNotEmpty = false;
            this.txtPrice.ChangeColorOnEnter = true;
            this.txtPrice.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPrice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPrice.Location = new System.Drawing.Point(629, 23);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Negative = true;
            this.txtPrice.NotEmpty = false;
            this.txtPrice.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrice.SelectOnEnter = true;
            this.txtPrice.Size = new System.Drawing.Size(101, 23);
            this.txtPrice.TabIndex = 20;
            this.txtPrice.Text = "0";
            this.txtPrice.TextMode = ClassLibrary.TextModes.Money;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(736, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "مبلغ پرداختی :";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.ChangeColorIfNotEmpty = false;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(434, 80);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(296, 23);
            this.txtDesc.TabIndex = 7;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(736, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "توضیحان :";
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
            this.txtDate.Location = new System.Drawing.Point(434, 22);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(100, 23);
            this.txtDate.TabIndex = 2;
            this.txtDate.Leave += new System.EventHandler(this.txtDate_Leave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(539, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "تاریخ پرداخت :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.chkTax);
            this.groupBox2.Controls.Add(this.lblDuty);
            this.groupBox2.Controls.Add(this.lblTax);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtMaksore);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblTotal);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnDel);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.txtPrice);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtDesc);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtDate);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(832, 115);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "اطلاعات پرداختی";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(317, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 16);
            this.label13.TabIndex = 71;
            this.label13.Text = "جمع عوارض :";
            // 
            // chkTax
            // 
            this.chkTax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTax.AutoSize = true;
            this.chkTax.Location = new System.Drawing.Point(447, 54);
            this.chkTax.Name = "chkTax";
            this.chkTax.Size = new System.Drawing.Size(161, 20);
            this.chkTax.TabIndex = 6;
            this.chkTax.Text = "محاسبه مالیات / عوارض";
            this.chkTax.UseVisualStyleBackColor = true;
            this.chkTax.CheckedChanged += new System.EventHandler(this.chkTax_CheckedChanged);
            // 
            // lblDuty
            // 
            this.lblDuty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDuty.AutoSize = true;
            this.lblDuty.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblDuty.ForeColor = System.Drawing.Color.Red;
            this.lblDuty.Location = new System.Drawing.Point(292, 74);
            this.lblDuty.Name = "lblDuty";
            this.lblDuty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDuty.Size = new System.Drawing.Size(19, 19);
            this.lblDuty.TabIndex = 70;
            this.lblDuty.Text = "0";
            // 
            // lblTax
            // 
            this.lblTax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTax.AutoSize = true;
            this.lblTax.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTax.ForeColor = System.Drawing.Color.Red;
            this.lblTax.Location = new System.Drawing.Point(292, 49);
            this.lblTax.Name = "lblTax";
            this.lblTax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTax.Size = new System.Drawing.Size(19, 19);
            this.lblTax.TabIndex = 69;
            this.lblTax.Text = "0";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(317, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 16);
            this.label9.TabIndex = 68;
            this.label9.Text = "جمع مالیات :";
            // 
            // txtMaksore
            // 
            this.txtMaksore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMaksore.ChangeColorIfNotEmpty = false;
            this.txtMaksore.ChangeColorOnEnter = true;
            this.txtMaksore.InBackColor = System.Drawing.SystemColors.Info;
            this.txtMaksore.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMaksore.Location = new System.Drawing.Point(629, 51);
            this.txtMaksore.Name = "txtMaksore";
            this.txtMaksore.Negative = true;
            this.txtMaksore.NotEmpty = false;
            this.txtMaksore.NotEmptyColor = System.Drawing.Color.Red;
            this.txtMaksore.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMaksore.SelectOnEnter = true;
            this.txtMaksore.Size = new System.Drawing.Size(101, 23);
            this.txtMaksore.TabIndex = 1;
            this.txtMaksore.Text = "0";
            this.txtMaksore.TextMode = ClassLibrary.TextModes.Money;
            this.txtMaksore.TextChanged += new System.EventHandler(this.txtMaksore_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(736, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 16);
            this.label4.TabIndex = 66;
            this.label4.Text = "مبلغ مکسوره :";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTotal.ForeColor = System.Drawing.Color.Red;
            this.lblTotal.Location = new System.Drawing.Point(293, 21);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTotal.Size = new System.Drawing.Size(19, 19);
            this.lblTotal.TabIndex = 64;
            this.lblTotal.Text = "0";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(318, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 16);
            this.label1.TabIndex = 63;
            this.label1.Text = "جمع کل پرداختی :";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(12, 54);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(84, 28);
            this.btnDel.TabIndex = 13;
            this.btnDel.Text = "حذف -";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(84, 28);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "افزودن +";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // jJanusGrid1
            // 
            this.jJanusGrid1.ActionClassName = "";
            this.jJanusGrid1.ActionMenu = null;
            this.jJanusGrid1.DataSource = null;
            this.jJanusGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jJanusGrid1.Edited = false;
            this.jJanusGrid1.Location = new System.Drawing.Point(0, 115);
            this.jJanusGrid1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jJanusGrid1.MultiSelect = true;
            this.jJanusGrid1.Name = "jJanusGrid1";
            this.jJanusGrid1.ShowNavigator = true;
            this.jJanusGrid1.ShowToolbar = true;
            this.jJanusGrid1.Size = new System.Drawing.Size(832, 313);
            this.jJanusGrid1.TabIndex = 17;
            // 
            // JPaymentContractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 428);
            this.Controls.Add(this.jJanusGrid1);
            this.Controls.Add(this.groupBox2);
            this.Name = "JPaymentContractForm";
            this.Text = "PaymentContractForm";
            this.Load += new System.EventHandler(this.JPaymentContractForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ClassLibrary.TextEdit txtPrice;
        private System.Windows.Forms.Label label7;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.DateEdit txtDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotal;
        private ClassLibrary.TextEdit txtMaksore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkTax;
        private System.Windows.Forms.Label lblDuty;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label label9;
        private ClassLibrary.JJanusGrid jJanusGrid1;
    }
}