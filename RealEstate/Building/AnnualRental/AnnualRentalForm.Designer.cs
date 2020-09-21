namespace RealEstate
{
    partial class JAnnualRentalForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEndDate = new ClassLibrary.DateEdit(this.components);
            this.txtStartDate = new ClassLibrary.DateEdit(this.components);
            this.btnDel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrice = new ClassLibrary.TextEdit(this.components);
            this.btnSabt = new System.Windows.Forms.Button();
            this.jdgvList = new ClassLibrary.JJanusGrid();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDesc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEndDate);
            this.groupBox1.Controls.Add(this.txtStartDate);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.btnSabt);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(634, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(547, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "توضیحات :";
            // 
            // txtDesc
            // 
            this.txtDesc.ChangeColorIfNotEmpty = false;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(173, 46);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(368, 23);
            this.txtDesc.TabIndex = 4;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(363, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "تاریخ پایان :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(547, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "تاریخ شروع :";
            // 
            // txtEndDate
            // 
            this.txtEndDate.ChangeColorIfNotEmpty = true;
            this.txtEndDate.ChangeColorOnEnter = true;
            this.txtEndDate.Date = new System.DateTime(((long)(0)));
            this.txtEndDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtEndDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEndDate.InsertInDatesTable = true;
            this.txtEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtEndDate.Location = new System.Drawing.Point(257, 15);
            this.txtEndDate.Mask = "0000/00/00";
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.NotEmpty = false;
            this.txtEndDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtEndDate.Size = new System.Drawing.Size(100, 23);
            this.txtEndDate.TabIndex = 2;
            // 
            // txtStartDate
            // 
            this.txtStartDate.ChangeColorIfNotEmpty = true;
            this.txtStartDate.ChangeColorOnEnter = true;
            this.txtStartDate.Date = new System.DateTime(((long)(0)));
            this.txtStartDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtStartDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtStartDate.InsertInDatesTable = true;
            this.txtStartDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtStartDate.Location = new System.Drawing.Point(441, 15);
            this.txtStartDate.Mask = "0000/00/00";
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.NotEmpty = false;
            this.txtStartDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtStartDate.Size = new System.Drawing.Size(100, 23);
            this.txtStartDate.TabIndex = 1;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(12, 45);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 25);
            this.btnDel.TabIndex = 6;
            this.btnDel.Text = "حذف";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "مبلغ اجاره :";
            // 
            // txtPrice
            // 
            this.txtPrice.ChangeColorIfNotEmpty = false;
            this.txtPrice.ChangeColorOnEnter = true;
            this.txtPrice.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPrice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPrice.Location = new System.Drawing.Point(67, 15);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Negative = true;
            this.txtPrice.NotEmpty = false;
            this.txtPrice.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrice.SelectOnEnter = true;
            this.txtPrice.Size = new System.Drawing.Size(100, 23);
            this.txtPrice.TabIndex = 3;
            this.txtPrice.TextMode = ClassLibrary.TextModes.Money;
            // 
            // btnSabt
            // 
            this.btnSabt.Location = new System.Drawing.Point(93, 45);
            this.btnSabt.Name = "btnSabt";
            this.btnSabt.Size = new System.Drawing.Size(75, 25);
            this.btnSabt.TabIndex = 5;
            this.btnSabt.Text = "ثبت";
            this.btnSabt.UseVisualStyleBackColor = true;
            this.btnSabt.Click += new System.EventHandler(this.btnSabt_Click);
            // 
            // jdgvList
            // 
            this.jdgvList.ActionClassName = "";
            this.jdgvList.ActionMenu = null;
            this.jdgvList.DataSource = null;
            this.jdgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jdgvList.Edited = false;
            this.jdgvList.Location = new System.Drawing.Point(0, 84);
            this.jdgvList.MultiSelect = true;
            this.jdgvList.Name = "jdgvList";
            this.jdgvList.ShowNavigator = true;
            this.jdgvList.ShowToolbar = true;
            this.jdgvList.Size = new System.Drawing.Size(634, 363);
            this.jdgvList.TabIndex = 1;
            // 
            // JAnnualRentalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 447);
            this.Controls.Add(this.jdgvList);
            this.Controls.Add(this.groupBox1);
            this.Name = "JAnnualRentalForm";
            this.Text = "AnnualRentalForm";
            this.Load += new System.EventHandler(this.JAnnualRentalForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit txtPrice;
        private System.Windows.Forms.Button btnSabt;
        private ClassLibrary.JJanusGrid jdgvList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.DateEdit txtEndDate;
        private ClassLibrary.DateEdit txtStartDate;
        private System.Windows.Forms.Label label4;
        private ClassLibrary.TextEdit txtDesc;
    }
}