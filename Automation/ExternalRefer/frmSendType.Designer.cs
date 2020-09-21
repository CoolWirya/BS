namespace Automation
{
    partial class JSendType
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
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.cmbSendTypeExternal = new ClassLibrary.JComboBox(this.components);
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(254, 167);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 47;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 46;
            this.label2.Text = "Description:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(4, 10);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 16);
            this.label17.TabIndex = 43;
            this.label17.Text = "Send Type:";
            // 
            // txtDesc
            // 
            this.txtDesc.ChangeColorIfNotEmpty = true;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(86, 37);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(392, 124);
            this.txtDesc.TabIndex = 45;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // cmbSendTypeExternal
            // 
            this.cmbSendTypeExternal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbSendTypeExternal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSendTypeExternal.ChangeColorIfNotEmpty = true;
            this.cmbSendTypeExternal.ChangeColorOnEnter = true;
            this.cmbSendTypeExternal.FormattingEnabled = true;
            this.cmbSendTypeExternal.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbSendTypeExternal.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbSendTypeExternal.Location = new System.Drawing.Point(86, 7);
            this.cmbSendTypeExternal.Name = "cmbSendTypeExternal";
            this.cmbSendTypeExternal.NotEmpty = false;
            this.cmbSendTypeExternal.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbSendTypeExternal.SelectOnEnter = true;
            this.cmbSendTypeExternal.Size = new System.Drawing.Size(391, 24);
            this.cmbSendTypeExternal.TabIndex = 44;
            this.cmbSendTypeExternal.SelectedIndexChanged += new System.EventHandler(this.cmbSendTypeExternal_SelectedIndexChanged);
            // 
            // JSendType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 195);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.cmbSendTypeExternal);
            this.Controls.Add(this.label17);
            this.Name = "JSendType";
            this.Text = "frmSendType";
            this.Load += new System.EventHandler(this.JSendType_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ClassLibrary.JComboBox cmbSendTypeExternal;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.Button btnConfirm;
    }
}