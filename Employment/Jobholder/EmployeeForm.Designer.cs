namespace Employment
{
    partial class JEmployeeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JEmployeeForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.txtPersonelNo = new ClassLibrary.NumEdit();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.numEdit1 = new ClassLibrary.NumEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
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
            this.label1.Location = new System.Drawing.Point(421, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "PersonNo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(421, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "EmpDate";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numEdit1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.txtPersonelNo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(547, 215);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(291, 88);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(121, 23);
            this.txtDate.TabIndex = 10;
            this.txtDate.Text = "13881217";
            // 
            // txtPersonelNo
            // 
            this.txtPersonelNo.ChangeColorIfNotEmpty = true;
            this.txtPersonelNo.ChangeColorOnEnter = true;
            this.txtPersonelNo.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPersonelNo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPersonelNo.Location = new System.Drawing.Point(312, 29);
            this.txtPersonelNo.Name = "txtPersonelNo";
            this.txtPersonelNo.Negative = true;
            this.txtPersonelNo.NotEmpty = false;
            this.txtPersonelNo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPersonelNo.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtPersonelNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPersonelNo.SelectOnEnter = true;
            this.txtPersonelNo.Size = new System.Drawing.Size(100, 23);
            this.txtPersonelNo.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(378, 222);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(458, 221);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // numEdit1
            // 
            this.numEdit1.ChangeColorIfNotEmpty = true;
            this.numEdit1.ChangeColorOnEnter = true;
            this.numEdit1.InBackColor = System.Drawing.SystemColors.Info;
            this.numEdit1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.numEdit1.Location = new System.Drawing.Point(312, 59);
            this.numEdit1.Name = "numEdit1";
            this.numEdit1.Negative = true;
            this.numEdit1.NotEmpty = false;
            this.numEdit1.NotEmptyColor = System.Drawing.Color.Red;
            this.numEdit1.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.numEdit1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numEdit1.SelectOnEnter = true;
            this.numEdit1.Size = new System.Drawing.Size(100, 23);
            this.numEdit1.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(421, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "PersonelCode";
            // 
            // JEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 254);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JEmployeeForm";
            this.Text = "EmployeeForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.NumEdit txtPersonelNo;
        private System.Windows.Forms.Button btnSave;
        private ClassLibrary.DateEdit txtDate;
        private System.Windows.Forms.Button btnClose;
        private ClassLibrary.NumEdit numEdit1;
        private System.Windows.Forms.Label label2;
    }
}