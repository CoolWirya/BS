namespace Globals.DynamicSearch
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtValue = new ClassLibrary.TextEdit(this.components);
            this.cmbListField = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtValue
            // 
            this.txtValue.ChangeColorIfNotEmpty = false;
            this.txtValue.ChangeColorOnEnter = true;
            this.txtValue.InBackColor = System.Drawing.SystemColors.Info;
            this.txtValue.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtValue.Location = new System.Drawing.Point(3, 4);
            this.txtValue.Name = "txtValue";
            this.txtValue.Negative = true;
            this.txtValue.NotEmpty = false;
            this.txtValue.NotEmptyColor = System.Drawing.Color.Red;
            this.txtValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtValue.SelectOnEnter = true;
            this.txtValue.Size = new System.Drawing.Size(256, 20);
            this.txtValue.TabIndex = 18;
            this.txtValue.TextMode = ClassLibrary.TextModes.Text;
            // 
            // cmbListField
            // 
            this.cmbListField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbListField.FormattingEnabled = true;
            this.cmbListField.Location = new System.Drawing.Point(265, 3);
            this.cmbListField.Name = "cmbListField";
            this.cmbListField.Size = new System.Drawing.Size(192, 21);
            this.cmbListField.TabIndex = 17;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.cmbListField);
            this.Name = "UserControl1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(460, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ClassLibrary.TextEdit txtValue;
        private System.Windows.Forms.ComboBox cmbListField;
    }
}
