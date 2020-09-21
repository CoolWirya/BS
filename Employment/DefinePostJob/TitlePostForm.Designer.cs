namespace Employment
{
    partial class JTitlePostForm
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbParent = new ClassLibrary.JComboBox(this.components);
            this.txtLevel = new ClassLibrary.TextEdit(this.components);
            this.txtJobCode = new ClassLibrary.TextEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(350, 57);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(101, 27);
            this.btnExit.TabIndex = 82;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(350, 24);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(101, 27);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "درج";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 45);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(82, 16);
            this.label10.TabIndex = 81;
            this.label10.Text = "عنوان پست :";
            // 
            // cmbParent
            // 
            this.cmbParent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbParent.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbParent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbParent.BaseCode = 0;
            this.cmbParent.ChangeColorIfNotEmpty = true;
            this.cmbParent.ChangeColorOnEnter = true;
            this.cmbParent.FormattingEnabled = true;
            this.cmbParent.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbParent.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbParent.Location = new System.Drawing.Point(127, 71);
            this.cmbParent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbParent.Name = "cmbParent";
            this.cmbParent.NotEmpty = false;
            this.cmbParent.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbParent.SelectOnEnter = true;
            this.cmbParent.Size = new System.Drawing.Size(157, 24);
            this.cmbParent.TabIndex = 3;
            // 
            // txtLevel
            // 
            this.txtLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLevel.ChangeColorIfNotEmpty = false;
            this.txtLevel.ChangeColorOnEnter = true;
            this.txtLevel.InBackColor = System.Drawing.SystemColors.Info;
            this.txtLevel.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLevel.Location = new System.Drawing.Point(127, 41);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Negative = true;
            this.txtLevel.NotEmpty = false;
            this.txtLevel.NotEmptyColor = System.Drawing.Color.Red;
            this.txtLevel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLevel.SelectOnEnter = true;
            this.txtLevel.Size = new System.Drawing.Size(157, 23);
            this.txtLevel.TabIndex = 2;
            this.txtLevel.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtJobCode
            // 
            this.txtJobCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJobCode.ChangeColorIfNotEmpty = false;
            this.txtJobCode.ChangeColorOnEnter = true;
            this.txtJobCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtJobCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJobCode.Location = new System.Drawing.Point(127, 12);
            this.txtJobCode.Name = "txtJobCode";
            this.txtJobCode.Negative = true;
            this.txtJobCode.NotEmpty = false;
            this.txtJobCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtJobCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtJobCode.SelectOnEnter = true;
            this.txtJobCode.Size = new System.Drawing.Size(157, 23);
            this.txtJobCode.TabIndex = 1;
            this.txtJobCode.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 80;
            this.label2.Text = "پدر :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 79;
            this.label1.Text = "کد پست :";
            // 
            // JTitlePostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 114);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbParent);
            this.Controls.Add(this.txtLevel);
            this.Controls.Add(this.txtJobCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "JTitlePostForm";
            this.Text = "TitlePostForm";
            this.Load += new System.EventHandler(this.JTitleJobForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label10;
        private ClassLibrary.JComboBox cmbParent;
        private ClassLibrary.TextEdit txtLevel;
        private ClassLibrary.TextEdit txtJobCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}