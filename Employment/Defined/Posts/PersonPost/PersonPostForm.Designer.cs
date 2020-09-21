namespace Employment
{
    partial class JEPersonPostForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JEPersonPostForm));
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDateEnd = new ClassLibrary.DateEdit(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtContractCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSelectPerson = new System.Windows.Forms.Button();
            this.cmbPostsFree = new System.Windows.Forms.ComboBox();
            this.btnAddPost = new System.Windows.Forms.Button();
            this.btnDelPost = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPCode = new System.Windows.Forms.TextBox();
            this.jDGPosts = new ClassLibrary.JDataGrid();
            this.txtDateStart = new ClassLibrary.DateEdit(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.jDGPosts)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(494, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "organizationpost";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(536, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "startDate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(541, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "endDate";
            // 
            // txtDateEnd
            // 
            this.txtDateEnd.ChangeColorIfNotEmpty = true;
            this.txtDateEnd.ChangeColorOnEnter = true;
            this.txtDateEnd.Date = new System.DateTime(((long)(0)));
            this.txtDateEnd.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDateEnd.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateEnd.InsertInDatesTable = true;
            this.txtDateEnd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDateEnd.Location = new System.Drawing.Point(374, 213);
            this.txtDateEnd.Mask = "0000/00/00";
            this.txtDateEnd.Name = "txtDateEnd";
            this.txtDateEnd.NotEmpty = false;
            this.txtDateEnd.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateEnd.Size = new System.Drawing.Size(100, 23);
            this.txtDateEnd.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(37, 461);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(123, 47);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(190, 461);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(123, 47);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtContractCode
            // 
            this.txtContractCode.Location = new System.Drawing.Point(327, 139);
            this.txtContractCode.Name = "txtContractCode";
            this.txtContractCode.Size = new System.Drawing.Size(147, 23);
            this.txtContractCode.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(528, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "contractno";
            // 
            // btnSelectPerson
            // 
            this.btnSelectPerson.Location = new System.Drawing.Point(213, 28);
            this.btnSelectPerson.Name = "btnSelectPerson";
            this.btnSelectPerson.Size = new System.Drawing.Size(95, 23);
            this.btnSelectPerson.TabIndex = 13;
            this.btnSelectPerson.Text = "...";
            this.btnSelectPerson.UseVisualStyleBackColor = true;
            this.btnSelectPerson.Click += new System.EventHandler(this.btnSelectPerson_Click);
            // 
            // cmbPostsFree
            // 
            this.cmbPostsFree.FormattingEnabled = true;
            this.cmbPostsFree.Location = new System.Drawing.Point(142, 102);
            this.cmbPostsFree.Name = "cmbPostsFree";
            this.cmbPostsFree.Size = new System.Drawing.Size(332, 24);
            this.cmbPostsFree.TabIndex = 3;
            // 
            // btnAddPost
            // 
            this.btnAddPost.Location = new System.Drawing.Point(151, 226);
            this.btnAddPost.Name = "btnAddPost";
            this.btnAddPost.Size = new System.Drawing.Size(89, 33);
            this.btnAddPost.TabIndex = 15;
            this.btnAddPost.Text = "Add";
            this.btnAddPost.UseVisualStyleBackColor = true;
            this.btnAddPost.Click += new System.EventHandler(this.btnAddPost_Click);
            // 
            // btnDelPost
            // 
            this.btnDelPost.Location = new System.Drawing.Point(56, 226);
            this.btnDelPost.Name = "btnDelPost";
            this.btnDelPost.Size = new System.Drawing.Size(89, 33);
            this.btnDelPost.TabIndex = 16;
            this.btnDelPost.Text = "Delete";
            this.btnDelPost.UseVisualStyleBackColor = true;
            this.btnDelPost.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(554, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "pcode";
            // 
            // txtPCode
            // 
            this.txtPCode.Location = new System.Drawing.Point(314, 28);
            this.txtPCode.Name = "txtPCode";
            this.txtPCode.ReadOnly = true;
            this.txtPCode.Size = new System.Drawing.Size(160, 23);
            this.txtPCode.TabIndex = 0;
            // 
            // jDGPosts
            // 
            this.jDGPosts.AllowUserToAddRows = false;
            this.jDGPosts.AllowUserToDeleteRows = false;
            this.jDGPosts.AllowUserToOrderColumns = true;
            this.jDGPosts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jDGPosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jDGPosts.EnableContexMenu = true;
            this.jDGPosts.KeyName = null;
            this.jDGPosts.Location = new System.Drawing.Point(3, 19);
            this.jDGPosts.Name = "jDGPosts";
            this.jDGPosts.ReadHeadersFromDB = false;
            this.jDGPosts.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jDGPosts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jDGPosts.ShowRowNumber = true;
            this.jDGPosts.Size = new System.Drawing.Size(608, 168);
            this.jDGPosts.TabIndex = 18;
            this.jDGPosts.TableName = null;
            // 
            // txtDateStart
            // 
            this.txtDateStart.ChangeColorIfNotEmpty = true;
            this.txtDateStart.ChangeColorOnEnter = true;
            this.txtDateStart.Date = new System.DateTime(((long)(0)));
            this.txtDateStart.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDateStart.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateStart.InsertInDatesTable = true;
            this.txtDateStart.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDateStart.Location = new System.Drawing.Point(374, 176);
            this.txtDateStart.Mask = "0000/00/00";
            this.txtDateStart.Name = "txtDateStart";
            this.txtDateStart.NotEmpty = false;
            this.txtDateStart.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateStart.Size = new System.Drawing.Size(100, 23);
            this.txtDateStart.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(555, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(315, 65);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(159, 23);
            this.txtName.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPCode);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.btnDelPost);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnAddPost);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbPostsFree);
            this.groupBox1.Controls.Add(this.btnSelectPerson);
            this.groupBox1.Controls.Add(this.txtDateStart);
            this.groupBox1.Controls.Add(this.txtContractCode);
            this.groupBox1.Controls.Add(this.txtDateEnd);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(614, 265);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.jDGPosts);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 265);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(614, 190);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "لیست سمت ها";
            // 
            // JEPersonPostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(614, 517);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "JEPersonPostForm";
            this.Text = "PersonPostForm";
            this.Load += new System.EventHandler(this.JEPersonPostForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jDGPosts)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ClassLibrary.DateEdit txtDateEnd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtContractCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSelectPerson;
        private System.Windows.Forms.ComboBox cmbPostsFree;
        private System.Windows.Forms.Button btnAddPost;
        private System.Windows.Forms.Button btnDelPost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPCode;
        private ClassLibrary.JDataGrid jDGPosts;
        private ClassLibrary.DateEdit txtDateStart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}