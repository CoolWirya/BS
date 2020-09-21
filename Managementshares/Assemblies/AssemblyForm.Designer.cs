namespace ManagementShares
{
    partial class JAssemblyForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new ClassLibrary.TextEdit(this.components);
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtCommands = new ClassLibrary.TextEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCommands);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 274);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(502, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "تاریخ:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(497, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "عنوان:";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.ChangeColorIfNotEmpty = false;
            this.txtTitle.ChangeColorOnEnter = true;
            this.txtTitle.InBackColor = System.Drawing.SystemColors.Info;
            this.txtTitle.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTitle.Location = new System.Drawing.Point(12, 27);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Negative = true;
            this.txtTitle.NotEmpty = false;
            this.txtTitle.NotEmptyColor = System.Drawing.Color.Red;
            this.txtTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTitle.SelectOnEnter = true;
            this.txtTitle.Size = new System.Drawing.Size(430, 23);
            this.txtTitle.TabIndex = 2;
            this.txtTitle.TextMode = ClassLibrary.TextModes.Text;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
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
            this.txtDate.Location = new System.Drawing.Point(342, 56);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(100, 23);
            this.txtDate.TabIndex = 3;
            this.txtDate.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(29, 280);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 29);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "ثبت";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(110, 280);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtCommands
            // 
            this.txtCommands.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommands.ChangeColorIfNotEmpty = false;
            this.txtCommands.ChangeColorOnEnter = true;
            this.txtCommands.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCommands.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCommands.Location = new System.Drawing.Point(12, 85);
            this.txtCommands.Multiline = true;
            this.txtCommands.Name = "txtCommands";
            this.txtCommands.Negative = true;
            this.txtCommands.NotEmpty = false;
            this.txtCommands.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCommands.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCommands.SelectOnEnter = true;
            this.txtCommands.Size = new System.Drawing.Size(430, 168);
            this.txtCommands.TabIndex = 6;
            this.txtCommands.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(443, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "دستورات مجمع:";
            // 
            // JAssemblyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 321);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Name = "JAssemblyForm";
            this.Text = "مجمع";
            this.Load += new System.EventHandler(this.JAssemblyForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit txtTitle;
        private ClassLibrary.DateEdit txtDate;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.TextEdit txtCommands;
    }
}