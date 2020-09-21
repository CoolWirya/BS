namespace Parking
{
    partial class CardMarketForm
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
            ClassLibrary.JPopupMenu jPopupMenu1 = new ClassLibrary.JPopupMenu();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChkState = new System.Windows.Forms.CheckBox();
            this.cmbStatusCard = new ClassLibrary.JComboBox(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtExpireDate = new ClassLibrary.DateEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbGroupCard = new ClassLibrary.JComboBox(this.components);
            this.cmbComplex = new ClassLibrary.JComboBox(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.grdMarket = new ClassLibrary.JDataGrid();
            this.BtnDel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMarket)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ChkState);
            this.groupBox1.Controls.Add(this.cmbStatusCard);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtExpireDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbGroupCard);
            this.groupBox1.Controls.Add(this.cmbComplex);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(616, 130);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تعريف ويژگيهاي كارت در بازار";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // ChkState
            // 
            this.ChkState.AutoSize = true;
            this.ChkState.Location = new System.Drawing.Point(22, 41);
            this.ChkState.Name = "ChkState";
            this.ChkState.Size = new System.Drawing.Size(50, 20);
            this.ChkState.TabIndex = 85;
            this.ChkState.Text = "فعال";
            this.ChkState.UseVisualStyleBackColor = true;
            // 
            // cmbStatusCard
            // 
            this.cmbStatusCard.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbStatusCard.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStatusCard.BaseCode = 0;
            this.cmbStatusCard.ChangeColorIfNotEmpty = true;
            this.cmbStatusCard.ChangeColorOnEnter = true;
            this.cmbStatusCard.FormattingEnabled = true;
            this.cmbStatusCard.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbStatusCard.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbStatusCard.Location = new System.Drawing.Point(100, 88);
            this.cmbStatusCard.Name = "cmbStatusCard";
            this.cmbStatusCard.NotEmpty = false;
            this.cmbStatusCard.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbStatusCard.SelectOnEnter = true;
            this.cmbStatusCard.Size = new System.Drawing.Size(134, 24);
            this.cmbStatusCard.TabIndex = 84;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(38, 88);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 24);
            this.btnSave.TabIndex = 45;
            this.btnSave.Text = "+";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(238, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 16);
            this.label8.TabIndex = 83;
            this.label8.Text = "توضيح وضعيت :";
            // 
            // txtExpireDate
            // 
            this.txtExpireDate.ChangeColorIfNotEmpty = true;
            this.txtExpireDate.ChangeColorOnEnter = true;
            this.txtExpireDate.Date = new System.DateTime(((long)(0)));
            this.txtExpireDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtExpireDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtExpireDate.InsertInDatesTable = true;
            this.txtExpireDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtExpireDate.Location = new System.Drawing.Point(156, 40);
            this.txtExpireDate.Mask = "0000/00/00";
            this.txtExpireDate.Name = "txtExpireDate";
            this.txtExpireDate.NotEmpty = false;
            this.txtExpireDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtExpireDate.Size = new System.Drawing.Size(78, 23);
            this.txtExpireDate.TabIndex = 82;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 81;
            this.label4.Text = "تاريخ انقضاء :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(541, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 80;
            this.label3.Text = "گروه كارت :";
            // 
            // cmbGroupCard
            // 
            this.cmbGroupCard.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbGroupCard.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGroupCard.BaseCode = 0;
            this.cmbGroupCard.ChangeColorIfNotEmpty = true;
            this.cmbGroupCard.ChangeColorOnEnter = true;
            this.cmbGroupCard.FormattingEnabled = true;
            this.cmbGroupCard.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbGroupCard.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbGroupCard.Location = new System.Drawing.Point(349, 88);
            this.cmbGroupCard.Name = "cmbGroupCard";
            this.cmbGroupCard.NotEmpty = false;
            this.cmbGroupCard.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbGroupCard.SelectOnEnter = true;
            this.cmbGroupCard.Size = new System.Drawing.Size(157, 24);
            this.cmbGroupCard.TabIndex = 79;
            this.cmbGroupCard.SelectedIndexChanged += new System.EventHandler(this.cmbGroupCard_SelectedIndexChanged);
            // 
            // cmbComplex
            // 
            this.cmbComplex.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbComplex.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbComplex.BaseCode = 0;
            this.cmbComplex.ChangeColorIfNotEmpty = true;
            this.cmbComplex.ChangeColorOnEnter = true;
            this.cmbComplex.FormattingEnabled = true;
            this.cmbComplex.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbComplex.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbComplex.Location = new System.Drawing.Point(349, 39);
            this.cmbComplex.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbComplex.Name = "cmbComplex";
            this.cmbComplex.NotEmpty = false;
            this.cmbComplex.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbComplex.SelectOnEnter = true;
            this.cmbComplex.Size = new System.Drawing.Size(157, 24);
            this.cmbComplex.TabIndex = 78;
            this.cmbComplex.SelectedIndexChanged += new System.EventHandler(this.cmbComplex_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(530, 43);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 16);
            this.label17.TabIndex = 77;
            this.label17.Text = "مجتمع/بازار :";
            // 
            // grdMarket
            // 
            this.grdMarket.ActionMenu = jPopupMenu1;
            this.grdMarket.AllowUserToAddRows = false;
            this.grdMarket.AllowUserToDeleteRows = false;
            this.grdMarket.AllowUserToOrderColumns = true;
            this.grdMarket.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdMarket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMarket.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdMarket.EnableContexMenu = true;
            this.grdMarket.KeyName = null;
            this.grdMarket.Location = new System.Drawing.Point(0, 130);
            this.grdMarket.Name = "grdMarket";
            this.grdMarket.ReadHeadersFromDB = false;
            this.grdMarket.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.grdMarket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdMarket.ShowRowNumber = true;
            this.grdMarket.Size = new System.Drawing.Size(616, 263);
            this.grdMarket.TabIndex = 1;
            this.grdMarket.TableName = null;
            // 
            // BtnDel
            // 
            this.BtnDel.Location = new System.Drawing.Point(9, 400);
            this.BtnDel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(123, 42);
            this.BtnDel.TabIndex = 46;
            this.BtnDel.Text = "حذف";
            this.BtnDel.UseVisualStyleBackColor = true;
            this.BtnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // CardMarketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 445);
            this.Controls.Add(this.BtnDel);
            this.Controls.Add(this.grdMarket);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CardMarketForm";
            this.Text = "CardMarketForm";
            this.Load += new System.EventHandler(this.CardMarketForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMarket)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.JComboBox cmbComplex;
        private System.Windows.Forms.Label label17;
        private ClassLibrary.JComboBox cmbStatusCard;
        private System.Windows.Forms.Label label8;
        private ClassLibrary.DateEdit txtExpireDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.JComboBox cmbGroupCard;
        private ClassLibrary.JDataGrid grdMarket;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button BtnDel;
        private System.Windows.Forms.CheckBox ChkState;
    }
}