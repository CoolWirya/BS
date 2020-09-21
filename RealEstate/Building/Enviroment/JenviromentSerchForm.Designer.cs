namespace RealEstate
{
    partial class bndEnv
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbdoor = new ClassLibrary.JComboBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTypeEnviroment = new ClassLibrary.JComboBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cmbComplex = new ClassLibrary.JComboBox(this.components);
            this.cmbState = new ClassLibrary.JComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFloor = new ClassLibrary.JComboBox(this.components);
            this.grdContracts = new ClassLibrary.JJanusGrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.BtnSelect = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbdoor);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbTypeEnviroment);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbComplex);
            this.groupBox1.Controls.Add(this.cmbState);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbFloor);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(719, 142);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "پارامترهاي جستجو";
            // 
            // cmbdoor
            // 
            this.cmbdoor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbdoor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbdoor.BaseCode = 0;
            this.cmbdoor.ChangeColorIfNotEmpty = true;
            this.cmbdoor.ChangeColorOnEnter = true;
            this.cmbdoor.FormattingEnabled = true;
            this.cmbdoor.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbdoor.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbdoor.Location = new System.Drawing.Point(12, 62);
            this.cmbdoor.Name = "cmbdoor";
            this.cmbdoor.NotEmpty = false;
            this.cmbdoor.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbdoor.SelectOnEnter = true;
            this.cmbdoor.Size = new System.Drawing.Size(249, 24);
            this.cmbdoor.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(278, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "درب:";
            // 
            // cmbTypeEnviroment
            // 
            this.cmbTypeEnviroment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbTypeEnviroment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTypeEnviroment.BaseCode = 0;
            this.cmbTypeEnviroment.ChangeColorIfNotEmpty = true;
            this.cmbTypeEnviroment.ChangeColorOnEnter = true;
            this.cmbTypeEnviroment.FormattingEnabled = true;
            this.cmbTypeEnviroment.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbTypeEnviroment.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbTypeEnviroment.Location = new System.Drawing.Point(12, 20);
            this.cmbTypeEnviroment.Name = "cmbTypeEnviroment";
            this.cmbTypeEnviroment.NotEmpty = false;
            this.cmbTypeEnviroment.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbTypeEnviroment.SelectOnEnter = true;
            this.cmbTypeEnviroment.Size = new System.Drawing.Size(249, 24);
            this.cmbTypeEnviroment.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "نوع :";
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
            this.cmbComplex.Location = new System.Drawing.Point(342, 20);
            this.cmbComplex.Name = "cmbComplex";
            this.cmbComplex.NotEmpty = false;
            this.cmbComplex.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbComplex.SelectOnEnter = true;
            this.cmbComplex.Size = new System.Drawing.Size(273, 24);
            this.cmbComplex.TabIndex = 16;
            this.cmbComplex.SelectedIndexChanged += new System.EventHandler(this.CmbComplex_SelectedIndexChanged);
            // 
            // cmbState
            // 
            this.cmbState.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbState.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbState.BaseCode = 0;
            this.cmbState.ChangeColorIfNotEmpty = true;
            this.cmbState.ChangeColorOnEnter = true;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbState.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbState.Items.AddRange(new object[] {
            "معلق",
            "آماده براي اجاره",
            "در حال اجاره",
            "رزو تا رسيدن زمان مناسب",
            "در دست تعمير",
            "در حال اخذ قرارداد"});
            this.cmbState.Location = new System.Drawing.Point(342, 110);
            this.cmbState.Name = "cmbState";
            this.cmbState.NotEmpty = false;
            this.cmbState.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbState.SelectOnEnter = true;
            this.cmbState.Size = new System.Drawing.Size(273, 24);
            this.cmbState.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(629, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "واقع در بازار:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(648, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "وضعيت :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(658, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "طبقه :";
            // 
            // cmbFloor
            // 
            this.cmbFloor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbFloor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFloor.BaseCode = 0;
            this.cmbFloor.ChangeColorIfNotEmpty = true;
            this.cmbFloor.ChangeColorOnEnter = true;
            this.cmbFloor.FormattingEnabled = true;
            this.cmbFloor.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbFloor.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbFloor.Location = new System.Drawing.Point(342, 67);
            this.cmbFloor.Name = "cmbFloor";
            this.cmbFloor.NotEmpty = false;
            this.cmbFloor.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbFloor.SelectOnEnter = true;
            this.cmbFloor.Size = new System.Drawing.Size(273, 24);
            this.cmbFloor.TabIndex = 18;
            // 
            // grdContracts
            // 
            this.grdContracts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdContracts.Location = new System.Drawing.Point(0, 142);
            this.grdContracts.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdContracts.MultiSelect = false;
            this.grdContracts.Name = "grdContracts";
            this.grdContracts.Size = new System.Drawing.Size(719, 506);
            this.grdContracts.TabIndex = 22;
            this.grdContracts.OnRowDBClick += new ClassLibrary.JJanusGrid.RowDBClick(this.grdContracts_OnRowDBClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnSelect);
            this.groupBox2.Controls.Add(this.BtnSearch);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 577);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(719, 71);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "عمليات";
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(557, 22);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(147, 37);
            this.BtnSearch.TabIndex = 0;
            this.BtnSearch.Text = "جستجو";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // BtnSelect
            // 
            this.BtnSelect.Enabled = false;
            this.BtnSelect.Location = new System.Drawing.Point(6, 22);
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Size = new System.Drawing.Size(147, 37);
            this.BtnSelect.TabIndex = 1;
            this.BtnSelect.Text = "انتخاب";
            this.BtnSelect.UseVisualStyleBackColor = true;
            this.BtnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // bndEnv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 648);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grdContracts);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "bndEnv";
            this.Text = "JenviromentSerchForm";
            this.Load += new System.EventHandler(this.JenviromentSerchForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.JComboBox cmbComplex;
        private ClassLibrary.JComboBox cmbState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.JComboBox cmbFloor;
        private ClassLibrary.JJanusGrid grdContracts;
        private ClassLibrary.JComboBox cmbdoor;
        private System.Windows.Forms.Label label5;
        private ClassLibrary.JComboBox cmbTypeEnviroment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Button BtnSelect;

    }
}