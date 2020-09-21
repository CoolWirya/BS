namespace Automation
{
    partial class JAReferForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JAReferForm));
            this.grpObject = new System.Windows.Forms.GroupBox();
            this.grpDate = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlRecievers = new System.Windows.Forms.Panel();
            this.grpReciever = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbReferType = new System.Windows.Forms.Label();
            this.lbOPost = new System.Windows.Forms.Label();
            this.lbMainName = new System.Windows.Forms.Label();
            this.grpObject.SuspendLayout();
            this.grpDate.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pnlRecievers.SuspendLayout();
            this.grpReciever.SuspendLayout();
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
            // grpObject
            // 
            this.grpObject.Controls.Add(this.grpDate);
            this.grpObject.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpObject.Location = new System.Drawing.Point(0, 0);
            this.grpObject.Name = "grpObject";
            this.grpObject.Size = new System.Drawing.Size(814, 110);
            this.grpObject.TabIndex = 0;
            this.grpObject.TabStop = false;
            // 
            // grpDate
            // 
            this.grpDate.Controls.Add(this.label3);
            this.grpDate.Controls.Add(this.label2);
            this.grpDate.Location = new System.Drawing.Point(12, 10);
            this.grpDate.Name = "grpDate";
            this.grpDate.Size = new System.Drawing.Size(194, 95);
            this.grpDate.TabIndex = 3;
            this.grpDate.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Date";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox2);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 110);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(814, 65);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(539, 16);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(194, 24);
            this.comboBox2.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(739, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Privacy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(3, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Recievers";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(764, 333);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(34, 27);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlRecievers
            // 
            this.pnlRecievers.AutoScroll = true;
            this.pnlRecievers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlRecievers.Controls.Add(this.grpReciever);
            this.pnlRecievers.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRecievers.Location = new System.Drawing.Point(0, 175);
            this.pnlRecievers.Name = "pnlRecievers";
            this.pnlRecievers.Size = new System.Drawing.Size(814, 152);
            this.pnlRecievers.TabIndex = 6;
            // 
            // grpReciever
            // 
            this.grpReciever.Controls.Add(this.comboBox1);
            this.grpReciever.Controls.Add(this.textBox2);
            this.grpReciever.Controls.Add(this.textBox1);
            this.grpReciever.Controls.Add(this.lbReferType);
            this.grpReciever.Controls.Add(this.lbOPost);
            this.grpReciever.Controls.Add(this.lbMainName);
            this.grpReciever.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpReciever.Location = new System.Drawing.Point(0, 0);
            this.grpReciever.Name = "grpReciever";
            this.grpReciever.Size = new System.Drawing.Size(810, 49);
            this.grpReciever.TabIndex = 1;
            this.grpReciever.TabStop = false;
            this.grpReciever.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(31, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(194, 24);
            this.comboBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(337, 20);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(149, 23);
            this.textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(613, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(140, 23);
            this.textBox1.TabIndex = 3;
            // 
            // lbReferType
            // 
            this.lbReferType.AutoSize = true;
            this.lbReferType.Location = new System.Drawing.Point(235, 24);
            this.lbReferType.Name = "lbReferType";
            this.lbReferType.Size = new System.Drawing.Size(67, 16);
            this.lbReferType.TabIndex = 2;
            this.lbReferType.Text = "ReferType";
            // 
            // lbOPost
            // 
            this.lbOPost.AutoSize = true;
            this.lbOPost.Location = new System.Drawing.Point(492, 24);
            this.lbOPost.Name = "lbOPost";
            this.lbOPost.Size = new System.Drawing.Size(104, 16);
            this.lbOPost.TabIndex = 1;
            this.lbOPost.Text = "OrganizationPost";
            // 
            // lbMainName
            // 
            this.lbMainName.AutoSize = true;
            this.lbMainName.Location = new System.Drawing.Point(759, 23);
            this.lbMainName.Name = "lbMainName";
            this.lbMainName.Size = new System.Drawing.Size(41, 16);
            this.lbMainName.TabIndex = 0;
            this.lbMainName.Text = "Name";
            // 
            // JAReferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 488);
            this.Controls.Add(this.pnlRecievers);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpObject);
            this.Controls.Add(this.btnAdd);
            this.Name = "JAReferForm";
            this.Text = "ReferForm";
            this.grpObject.ResumeLayout(false);
            this.grpDate.ResumeLayout(false);
            this.grpDate.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.pnlRecievers.ResumeLayout(false);
            this.grpReciever.ResumeLayout(false);
            this.grpReciever.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpObject;
        private System.Windows.Forms.GroupBox grpDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlRecievers;
        private System.Windows.Forms.GroupBox grpReciever;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbReferType;
        private System.Windows.Forms.Label lbOPost;
        private System.Windows.Forms.Label lbMainName;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;

    }
}