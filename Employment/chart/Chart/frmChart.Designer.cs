namespace Employment
{
    partial class JfrmChart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JfrmChart));
            this.label1 = new System.Windows.Forms.Label();
            this.txtChartTitle = new ClassLibrary.TextEdit(this.components);
            this.rdoDisactive = new System.Windows.Forms.RadioButton();
            this.rdoActive = new System.Windows.Forms.RadioButton();
            this.btnAction = new System.Windows.Forms.Button();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chart Title :";
            // 
            // txtChartTitle
            // 
            this.txtChartTitle.ChangeColorIfNotEmpty = true;
            this.txtChartTitle.ChangeColorOnEnter = true;
            this.txtChartTitle.InBackColor = System.Drawing.SystemColors.Info;
            this.txtChartTitle.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtChartTitle.Location = new System.Drawing.Point(95, 6);
            this.txtChartTitle.Name = "txtChartTitle";
            this.txtChartTitle.NotEmpty = false;
            this.txtChartTitle.NotEmptyColor = System.Drawing.Color.Red;
            this.txtChartTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtChartTitle.SelectOnEnter = true;
            this.txtChartTitle.Size = new System.Drawing.Size(375, 23);
            this.txtChartTitle.TabIndex = 1;
            // 
            // rdoDisactive
            // 
            this.rdoDisactive.AutoSize = true;
            this.rdoDisactive.Checked = true;
            this.rdoDisactive.Location = new System.Drawing.Point(95, 35);
            this.rdoDisactive.Name = "rdoDisactive";
            this.rdoDisactive.Size = new System.Drawing.Size(76, 20);
            this.rdoDisactive.TabIndex = 2;
            this.rdoDisactive.TabStop = true;
            this.rdoDisactive.Text = "Disactive";
            this.rdoDisactive.UseVisualStyleBackColor = true;
            // 
            // rdoActive
            // 
            this.rdoActive.AutoSize = true;
            this.rdoActive.Location = new System.Drawing.Point(177, 35);
            this.rdoActive.Name = "rdoActive";
            this.rdoActive.Size = new System.Drawing.Size(60, 20);
            this.rdoActive.TabIndex = 3;
            this.rdoActive.Text = "Active";
            this.rdoActive.UseVisualStyleBackColor = true;
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(395, 35);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(75, 23);
            this.btnAction.TabIndex = 4;
            this.btnAction.Text = "Action";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // JfrmChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(482, 67);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.rdoActive);
            this.Controls.Add(this.rdoDisactive);
            this.Controls.Add(this.txtChartTitle);
            this.Controls.Add(this.label1);
            this.Name = "JfrmChart";
            this.Load += new System.EventHandler(this.JfrmChart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit txtChartTitle;
        private System.Windows.Forms.RadioButton rdoDisactive;
        private System.Windows.Forms.RadioButton rdoActive;
        private System.Windows.Forms.Button btnAction;
    }
}
