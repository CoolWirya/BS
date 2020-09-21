namespace Globals.Property
{
    partial class JDefinePropertyForm
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
            this.jDefinePropertyUserControl1 = new Globals.Property.JDefinePropertyUserControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // jDefinePropertyUserControl1
            // 
            this.jDefinePropertyUserControl1.ClassName = null;
            this.jDefinePropertyUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jDefinePropertyUserControl1.Location = new System.Drawing.Point(0, 0);
            this.jDefinePropertyUserControl1.Name = "jDefinePropertyUserControl1";
            this.jDefinePropertyUserControl1.ObjectCode = 0;
            this.jDefinePropertyUserControl1.Size = new System.Drawing.Size(574, 408);
            this.jDefinePropertyUserControl1.TabIndex = 0;
            this.jDefinePropertyUserControl1.AfterPropertyDeleted += new Globals.Property.JDefinePropertyUserControl.PropertyDeleted(this.jDefinePropertyUserControl1_AfterPropertyDeleted);
            this.jDefinePropertyUserControl1.AfterPropertyAdded += new Globals.Property.JDefinePropertyUserControl.PropertyAdded(this.jDefinePropertyUserControl1_AfterPropertyAdded);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 408);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(574, 43);
            this.panel1.TabIndex = 1;
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(496, 8);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 0;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(415, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // JDefinePropertyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 451);
            this.Controls.Add(this.jDefinePropertyUserControl1);
            this.Controls.Add(this.panel1);
            this.Name = "JDefinePropertyForm";
            this.Text = "DefinePropertyForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private JDefinePropertyUserControl jDefinePropertyUserControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnApply;
    }
}