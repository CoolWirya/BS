namespace ManagementShares
{
    partial class JNewIncreaseShareForm
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
            this.person = new ClassLibrary.JUCPerson();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnIncrease = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbAllCost = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtShareCount = new ClassLibrary.TextEdit(this.components);
            this.txtShareCost = new ClassLibrary.TextEdit(this.components);
            this.txtComment = new ClassLibrary.TextEdit(this.components);
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // person
            // 
            this.person.Dock = System.Windows.Forms.DockStyle.Top;
            this.person.FilterPerson = null;
            this.person.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.person.LableGroup = null;
            this.person.Location = new System.Drawing.Point(0, 0);
            this.person.Name = "person";
            this.person.PersonType = ClassLibrary.JPersonTypes.None;
            this.person.ReadOnly = true;
            this.person.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.person.SelectedCode = 0;
            this.person.Size = new System.Drawing.Size(622, 190);
            this.person.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnIncrease);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 343);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 44);
            this.panel1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(25, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 32);
            this.button2.TabIndex = 1;
            this.button2.Text = "انصراف";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnIncrease
            // 
            this.btnIncrease.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIncrease.Location = new System.Drawing.Point(527, 7);
            this.btnIncrease.Name = "btnIncrease";
            this.btnIncrease.Size = new System.Drawing.Size(75, 32);
            this.btnIncrease.TabIndex = 0;
            this.btnIncrease.Text = "اعمال";
            this.btnIncrease.UseVisualStyleBackColor = true;
            this.btnIncrease.Click += new System.EventHandler(this.btnIncrease_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbAllCost);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtShareCount);
            this.groupBox1.Controls.Add(this.txtShareCost);
            this.groupBox1.Controls.Add(this.txtComment);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 190);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(622, 153);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // lbAllCost
            // 
            this.lbAllCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAllCost.AutoSize = true;
            this.lbAllCost.ForeColor = System.Drawing.Color.Blue;
            this.lbAllCost.Location = new System.Drawing.Point(351, 126);
            this.lbAllCost.Name = "lbAllCost";
            this.lbAllCost.Size = new System.Drawing.Size(112, 16);
            this.lbAllCost.TabIndex = 10;
            this.lbAllCost.Text = "سرمایه کل شرکت:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(485, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "سرمایه کل شرکت:";
            // 
            // txtShareCount
            // 
            this.txtShareCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShareCount.ChangeColorIfNotEmpty = false;
            this.txtShareCount.ChangeColorOnEnter = true;
            this.txtShareCount.InBackColor = System.Drawing.SystemColors.Info;
            this.txtShareCount.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtShareCount.Location = new System.Drawing.Point(360, 93);
            this.txtShareCount.Name = "txtShareCount";
            this.txtShareCount.Negative = true;
            this.txtShareCount.NotEmpty = false;
            this.txtShareCount.NotEmptyColor = System.Drawing.Color.Red;
            this.txtShareCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtShareCount.SelectOnEnter = true;
            this.txtShareCount.Size = new System.Drawing.Size(100, 23);
            this.txtShareCount.TabIndex = 8;
            this.txtShareCount.TextMode = ClassLibrary.TextModes.Integer;
            this.txtShareCount.TextChanged += new System.EventHandler(this.txtShareCost_TextChanged);
            // 
            // txtShareCost
            // 
            this.txtShareCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShareCost.ChangeColorIfNotEmpty = false;
            this.txtShareCost.ChangeColorOnEnter = true;
            this.txtShareCost.InBackColor = System.Drawing.SystemColors.Info;
            this.txtShareCost.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtShareCost.Location = new System.Drawing.Point(360, 60);
            this.txtShareCost.Name = "txtShareCost";
            this.txtShareCost.Negative = true;
            this.txtShareCost.NotEmpty = false;
            this.txtShareCost.NotEmptyColor = System.Drawing.Color.Red;
            this.txtShareCost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtShareCost.SelectOnEnter = true;
            this.txtShareCost.Size = new System.Drawing.Size(100, 23);
            this.txtShareCost.TabIndex = 6;
            this.txtShareCost.TextMode = ClassLibrary.TextModes.Money;
            this.txtShareCost.TextChanged += new System.EventHandler(this.txtShareCost_TextChanged);
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.ChangeColorIfNotEmpty = false;
            this.txtComment.ChangeColorOnEnter = true;
            this.txtComment.InBackColor = System.Drawing.SystemColors.Info;
            this.txtComment.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtComment.Location = new System.Drawing.Point(47, 26);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Negative = true;
            this.txtComment.NotEmpty = false;
            this.txtComment.NotEmptyColor = System.Drawing.Color.Red;
            this.txtComment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtComment.SelectOnEnter = true;
            this.txtComment.Size = new System.Drawing.Size(202, 90);
            this.txtComment.TabIndex = 5;
            this.txtComment.TextMode = ClassLibrary.TextModes.Text;
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
            this.txtDate.Location = new System.Drawing.Point(360, 26);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(100, 23);
            this.txtDate.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "توضیحات:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(502, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "تعداد کل سهام:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(466, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "مبلغ اسمی هر سهم:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(473, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "تاریخ افزایش سرمایه:";
            // 
            // JNewIncreaseShareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 387);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.person);
            this.Name = "JNewIncreaseShareForm";
            this.Text = "افزایش سرمایه";
            this.Shown += new System.EventHandler(this.JNewIncreaseShareForm_Shown);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ClassLibrary.JUCPerson person;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.TextEdit txtShareCount;
        private ClassLibrary.TextEdit txtShareCost;
        private ClassLibrary.TextEdit txtComment;
        private ClassLibrary.DateEdit txtDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnIncrease;
        private System.Windows.Forms.Label lbAllCost;
        private System.Windows.Forms.Label label5;
    }
}