namespace ManagementShares
{
    partial class JPollingForm
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
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtAlternateMembers = new ClassLibrary.TextEdit(this.components);
			this.txtMainMembers = new ClassLibrary.TextEdit(this.components);
			this.txtTitle = new ClassLibrary.TextEdit(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtAlternateMembers);
			this.groupBox1.Controls.Add(this.txtMainMembers);
			this.groupBox1.Controls.Add(this.txtTitle);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(546, 104);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(128, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(90, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "تعداد انتخاب 2:";
			this.label3.Visible = false;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(426, 60);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(114, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "تعداد انتخاب اصلی:";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(426, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "عنوان انتخابات:";
			// 
			// txtAlternateMembers
			// 
			this.txtAlternateMembers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtAlternateMembers.ChangeColorIfNotEmpty = false;
			this.txtAlternateMembers.ChangeColorOnEnter = true;
			this.txtAlternateMembers.InBackColor = System.Drawing.SystemColors.Info;
			this.txtAlternateMembers.InForeColor = System.Drawing.SystemColors.WindowText;
			this.txtAlternateMembers.Location = new System.Drawing.Point(22, 60);
			this.txtAlternateMembers.Name = "txtAlternateMembers";
			this.txtAlternateMembers.Negative = true;
			this.txtAlternateMembers.NotEmpty = false;
			this.txtAlternateMembers.NotEmptyColor = System.Drawing.Color.Red;
			this.txtAlternateMembers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtAlternateMembers.SelectOnEnter = true;
			this.txtAlternateMembers.Size = new System.Drawing.Size(100, 23);
			this.txtAlternateMembers.TabIndex = 2;
			this.txtAlternateMembers.TextMode = ClassLibrary.TextModes.Integer;
			this.txtAlternateMembers.Visible = false;
			// 
			// txtMainMembers
			// 
			this.txtMainMembers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtMainMembers.ChangeColorIfNotEmpty = false;
			this.txtMainMembers.ChangeColorOnEnter = true;
			this.txtMainMembers.InBackColor = System.Drawing.SystemColors.Info;
			this.txtMainMembers.InForeColor = System.Drawing.SystemColors.WindowText;
			this.txtMainMembers.Location = new System.Drawing.Point(327, 57);
			this.txtMainMembers.Name = "txtMainMembers";
			this.txtMainMembers.Negative = true;
			this.txtMainMembers.NotEmpty = false;
			this.txtMainMembers.NotEmptyColor = System.Drawing.Color.Red;
			this.txtMainMembers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtMainMembers.SelectOnEnter = true;
			this.txtMainMembers.Size = new System.Drawing.Size(100, 23);
			this.txtMainMembers.TabIndex = 1;
			this.txtMainMembers.TextMode = ClassLibrary.TextModes.Integer;
			// 
			// txtTitle
			// 
			this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTitle.ChangeColorIfNotEmpty = false;
			this.txtTitle.ChangeColorOnEnter = true;
			this.txtTitle.InBackColor = System.Drawing.SystemColors.Info;
			this.txtTitle.InForeColor = System.Drawing.SystemColors.WindowText;
			this.txtTitle.Location = new System.Drawing.Point(22, 22);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Negative = true;
			this.txtTitle.NotEmpty = false;
			this.txtTitle.NotEmptyColor = System.Drawing.Color.Red;
			this.txtTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtTitle.SelectOnEnter = true;
			this.txtTitle.Size = new System.Drawing.Size(405, 23);
			this.txtTitle.TabIndex = 0;
			this.txtTitle.TextMode = ClassLibrary.TextModes.Text;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 124);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(546, 41);
			this.panel1.TabIndex = 1;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(378, 6);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 32);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "بازگشت";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(459, 6);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 32);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "ثبت";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// JPollingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(546, 165);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.groupBox1);
			this.Name = "JPollingForm";
			this.Text = "انتخابات";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit txtAlternateMembers;
        private ClassLibrary.TextEdit txtMainMembers;
        private ClassLibrary.TextEdit txtTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}