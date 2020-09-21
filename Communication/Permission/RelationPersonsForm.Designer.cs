namespace Communication
{
    partial class JRelationPersonsForm
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
            this.BtnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSelOrganization = new System.Windows.Forms.Button();
            this.cdbSender = new ClassLibrary.JCodingBox();
            this.cmbTitles = new ClassLibrary.JComboBox(this.components);
            this.SenderLable = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dtvOrganizatinChart = new ClassLibrary.JDataTreeView();
            this.DecissionlistBox = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.cdbSender.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnExit);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 575);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(832, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // BtnExit
            // 
            this.BtnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExit.Location = new System.Drawing.Point(48, 18);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(75, 23);
            this.BtnExit.TabIndex = 5;
            this.BtnExit.Text = "خروج";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(595, 18);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(676, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Insert";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSelOrganization);
            this.groupBox2.Controls.Add(this.cdbSender);
            this.groupBox2.Controls.Add(this.SenderLable);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(832, 52);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnSelOrganization
            // 
            this.btnSelOrganization.Location = new System.Drawing.Point(93, 19);
            this.btnSelOrganization.Name = "btnSelOrganization";
            this.btnSelOrganization.Size = new System.Drawing.Size(28, 23);
            this.btnSelOrganization.TabIndex = 17;
            this.btnSelOrganization.TabStop = false;
            this.btnSelOrganization.Text = "...";
            this.btnSelOrganization.UseVisualStyleBackColor = true;
            // 
            // cdbSender
            // 
            this.cdbSender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cdbSender.Controls.Add(this.cmbTitles);
            this.cdbSender.dataTable = null;
            this.cdbSender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cdbSender.Location = new System.Drawing.Point(126, 19);
            this.cdbSender.Name = "cdbSender";
            this.cdbSender.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cdbSender.SelectedIndex = -1;
            this.cdbSender.SelectedValue = null;
            this.cdbSender.Size = new System.Drawing.Size(625, 27);
            this.cdbSender.TabIndex = 15;
            this.cdbSender.Leave += new System.EventHandler(this.cdbSender_Leave);
            // 
            // cmbTitles
            // 
            this.cmbTitles.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbTitles.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTitles.BaseCode = 0;
            this.cmbTitles.ChangeColorIfNotEmpty = true;
            this.cmbTitles.ChangeColorOnEnter = true;
            this.cmbTitles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTitles.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbTitles.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbTitles.Location = new System.Drawing.Point(0, 0);
            this.cmbTitles.Name = "cmbTitles";
            this.cmbTitles.NotEmpty = false;
            this.cmbTitles.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbTitles.SelectOnEnter = true;
            this.cmbTitles.Size = new System.Drawing.Size(625, 24);
            this.cmbTitles.TabIndex = 1;
            // 
            // SenderLable
            // 
            this.SenderLable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SenderLable.AutoSize = true;
            this.SenderLable.Location = new System.Drawing.Point(767, 25);
            this.SenderLable.Name = "SenderLable";
            this.SenderLable.Size = new System.Drawing.Size(54, 16);
            this.SenderLable.TabIndex = 16;
            this.SenderLable.Text = "Sender:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 52);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dtvOrganizatinChart);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DecissionlistBox);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(832, 523);
            this.splitContainer1.SplitterDistance = 466;
            this.splitContainer1.TabIndex = 2;
            // 
            // dtvOrganizatinChart
            // 
            this.dtvOrganizatinChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtvOrganizatinChart.Location = new System.Drawing.Point(0, 0);
            this.dtvOrganizatinChart.Name = "dtvOrganizatinChart";
            this.dtvOrganizatinChart.Size = new System.Drawing.Size(466, 523);
            this.dtvOrganizatinChart.TabIndex = 7;
            // 
            // DecissionlistBox
            // 
            this.DecissionlistBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DecissionlistBox.FormattingEnabled = true;
            this.DecissionlistBox.ItemHeight = 16;
            this.DecissionlistBox.Location = new System.Drawing.Point(0, 0);
            this.DecissionlistBox.Name = "DecissionlistBox";
            this.DecissionlistBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.DecissionlistBox.Size = new System.Drawing.Size(362, 516);
            this.DecissionlistBox.TabIndex = 5;
            // 
            // JRelationPersonsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 628);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "JRelationPersonsForm";
            this.Text = "RelationPersonsForm";
            this.Load += new System.EventHandler(this.JRelationPersonsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.cdbSender.ResumeLayout(false);
            this.cdbSender.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ClassLibrary.JDataTreeView dtvOrganizatinChart;
        private System.Windows.Forms.ListBox DecissionlistBox;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSelOrganization;
        private ClassLibrary.JCodingBox cdbSender;
        private ClassLibrary.JComboBox cmbTitles;
        private System.Windows.Forms.Label SenderLable;
    }
}