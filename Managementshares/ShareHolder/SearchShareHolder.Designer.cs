namespace ManagementShares
{
    partial class JSearchShareHolder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JSearchShareHolder));
            ClassLibrary.JPopupMenu jPopupMenu1 = new ClassLibrary.JPopupMenu();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSheetNo = new ClassLibrary.TextEdit(this.components);
            this.txtShareHolderNo = new ClassLibrary.TextEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtFam = new ClassLibrary.TextEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new ClassLibrary.TextEdit(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdPerson = new ClassLibrary.JDataGrid();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPerson)).BeginInit();
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
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 486);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(835, 48);
            this.panel1.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(643, 6);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(724, 6);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSheetNo);
            this.groupBox1.Controls.Add(this.txtShareHolderNo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtFam);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(835, 96);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // txtSheetNo
            // 
            this.txtSheetNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSheetNo.ChangeColorIfNotEmpty = false;
            this.txtSheetNo.ChangeColorOnEnter = true;
            this.txtSheetNo.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSheetNo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSheetNo.Location = new System.Drawing.Point(335, 51);
            this.txtSheetNo.Name = "txtSheetNo";
            this.txtSheetNo.Negative = true;
            this.txtSheetNo.NotEmpty = false;
            this.txtSheetNo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSheetNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSheetNo.SelectOnEnter = true;
            this.txtSheetNo.Size = new System.Drawing.Size(100, 23);
            this.txtSheetNo.TabIndex = 3;
            this.txtSheetNo.TextMode = ClassLibrary.TextModes.Integer;
            this.txtSheetNo.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtSheetNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShareHolderNo_KeyDown);
            this.txtSheetNo.Leave += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtShareHolderNo
            // 
            this.txtShareHolderNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShareHolderNo.ChangeColorIfNotEmpty = false;
            this.txtShareHolderNo.ChangeColorOnEnter = true;
            this.txtShareHolderNo.InBackColor = System.Drawing.SystemColors.Info;
            this.txtShareHolderNo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtShareHolderNo.Location = new System.Drawing.Point(592, 51);
            this.txtShareHolderNo.Name = "txtShareHolderNo";
            this.txtShareHolderNo.Negative = true;
            this.txtShareHolderNo.NotEmpty = false;
            this.txtShareHolderNo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtShareHolderNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtShareHolderNo.SelectOnEnter = true;
            this.txtShareHolderNo.Size = new System.Drawing.Size(100, 23);
            this.txtShareHolderNo.TabIndex = 2;
            this.txtShareHolderNo.TextMode = ClassLibrary.TextModes.Integer;
            this.txtShareHolderNo.TextChanged += new System.EventHandler(this.txtShareHolderNo_TextChanged);
            this.txtShareHolderNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShareHolderNo_KeyDown);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(471, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "SheetNo:";
            // 
            // txtFam
            // 
            this.txtFam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFam.ChangeColorIfNotEmpty = true;
            this.txtFam.ChangeColorOnEnter = true;
            this.txtFam.InBackColor = System.Drawing.SystemColors.Info;
            this.txtFam.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFam.Location = new System.Drawing.Point(287, 18);
            this.txtFam.Name = "txtFam";
            this.txtFam.Negative = true;
            this.txtFam.NotEmpty = false;
            this.txtFam.NotEmptyColor = System.Drawing.Color.Red;
            this.txtFam.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFam.SelectOnEnter = true;
            this.txtFam.Size = new System.Drawing.Size(148, 23);
            this.txtFam.TabIndex = 1;
            this.txtFam.TextMode = ClassLibrary.TextModes.Text;
            this.txtFam.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtFam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShareHolderNo_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(494, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fam:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.ChangeColorIfNotEmpty = true;
            this.txtName.ChangeColorOnEnter = true;
            this.txtName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName.Location = new System.Drawing.Point(592, 18);
            this.txtName.Name = "txtName";
            this.txtName.Negative = true;
            this.txtName.NotEmpty = false;
            this.txtName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtName.SelectOnEnter = true;
            this.txtName.Size = new System.Drawing.Size(100, 23);
            this.txtName.TabIndex = 0;
            this.txtName.TextMode = ClassLibrary.TextModes.Text;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShareHolderNo_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(27, 54);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 34);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(701, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "ShareHolderCode:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(768, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // grdPerson
            // 
            this.grdPerson.ActionMenu = jPopupMenu1;
            this.grdPerson.AllowUserToAddRows = false;
            this.grdPerson.AllowUserToDeleteRows = false;
            this.grdPerson.AllowUserToOrderColumns = true;
            this.grdPerson.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdPerson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPerson.EnableContexMenu = true;
            this.grdPerson.KeyName = null;
            this.grdPerson.Location = new System.Drawing.Point(0, 96);
            this.grdPerson.Name = "grdPerson";
            this.grdPerson.ReadHeadersFromDB = false;
            this.grdPerson.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.grdPerson.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPerson.ShowRowNumber = true;
            this.grdPerson.Size = new System.Drawing.Size(835, 390);
            this.grdPerson.TabIndex = 1;
            this.grdPerson.TableName = null;
            this.grdPerson.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdPerson_CellMouseDoubleClick);
            // 
            // JSearchShareHolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 534);
            this.Controls.Add(this.grdPerson);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "JSearchShareHolder";
            this.NextControlOnPressEnter = false;
            this.Text = "SearchShareHolder";
            this.Shown += new System.EventHandler(this.JSearchShareHolder_Shown);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPerson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private ClassLibrary.TextEdit txtName;
        private ClassLibrary.TextEdit txtFam;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.JDataGrid grdPerson;
        private System.Windows.Forms.Label label4;
        private ClassLibrary.TextEdit txtSheetNo;
        private ClassLibrary.TextEdit txtShareHolderNo;
    }
}