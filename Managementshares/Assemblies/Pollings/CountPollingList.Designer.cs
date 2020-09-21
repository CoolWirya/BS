namespace ManagementShares
{
    partial class JCountPollingList
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDetail = new System.Windows.Forms.Button();
            this.btnPrintResult = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnNewVote = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdCountedList = new ClassLibrary.JJanusGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdResult = new ClassLibrary.JJanusGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbError = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.chAutoUpdate = new System.Windows.Forms.CheckBox();
            this.lbCounted = new System.Windows.Forms.Label();
            this.lbPresence = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDetail);
            this.panel1.Controls.Add(this.btnPrintResult);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.btnNewVote);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 638);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(907, 40);
            this.panel1.TabIndex = 3;
            // 
            // btnDetail
            // 
            this.btnDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetail.Location = new System.Drawing.Point(482, 6);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(75, 31);
            this.btnDetail.TabIndex = 4;
            this.btnDetail.Text = "چاپ جزئی";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // btnPrintResult
            // 
            this.btnPrintResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintResult.Location = new System.Drawing.Point(563, 6);
            this.btnPrintResult.Name = "btnPrintResult";
            this.btnPrintResult.Size = new System.Drawing.Size(75, 31);
            this.btnPrintResult.TabIndex = 3;
            this.btnPrintResult.Text = "چاپ نتایج";
            this.btnPrintResult.UseVisualStyleBackColor = true;
            this.btnPrintResult.Click += new System.EventHandler(this.btnPrintResult_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.Location = new System.Drawing.Point(644, 6);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 31);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "حذف";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Location = new System.Drawing.Point(725, 6);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 31);
            this.btnView.TabIndex = 1;
            this.btnView.Text = "مشاهده";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnNewVote
            // 
            this.btnNewVote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewVote.Location = new System.Drawing.Point(806, 6);
            this.btnNewVote.Name = "btnNewVote";
            this.btnNewVote.Size = new System.Drawing.Size(75, 31);
            this.btnNewVote.TabIndex = 0;
            this.btnNewVote.Text = "برگه جدید";
            this.btnNewVote.UseVisualStyleBackColor = true;
            this.btnNewVote.Click += new System.EventHandler(this.btnNewVote_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grdCountedList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 349);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(907, 289);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "برگه های شمارش شده";
            // 
            // grdCountedList
            // 
            this.grdCountedList.ActionClassName = "";
            this.grdCountedList.ActionMenu = null;
            this.grdCountedList.DataSource = null;
            this.grdCountedList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCountedList.Edited = false;
            this.grdCountedList.Location = new System.Drawing.Point(3, 19);
            this.grdCountedList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdCountedList.MultiSelect = false;
            this.grdCountedList.Name = "grdCountedList";
            this.grdCountedList.ShowNavigator = false;
            this.grdCountedList.ShowToolbar = true;
            this.grdCountedList.Size = new System.Drawing.Size(901, 267);
            this.grdCountedList.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdResult);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(907, 349);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "منتخبین";
            // 
            // grdResult
            // 
            this.grdResult.ActionClassName = "";
            this.grdResult.ActionMenu = null;
            this.grdResult.DataSource = null;
            this.grdResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdResult.Edited = false;
            this.grdResult.Location = new System.Drawing.Point(378, 19);
            this.grdResult.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.grdResult.MultiSelect = false;
            this.grdResult.Name = "grdResult";
            this.grdResult.ShowNavigator = false;
            this.grdResult.ShowToolbar = false;
            this.grdResult.Size = new System.Drawing.Size(526, 327);
            this.grdResult.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbError);
            this.groupBox3.Controls.Add(this.btnRefresh);
            this.groupBox3.Controls.Add(this.chAutoUpdate);
            this.groupBox3.Controls.Add(this.lbCounted);
            this.groupBox3.Controls.Add(this.lbPresence);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(3, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(375, 327);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // lbError
            // 
            this.lbError.ForeColor = System.Drawing.Color.Red;
            this.lbError.Location = new System.Drawing.Point(9, 107);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(349, 18);
            this.lbError.TabIndex = 6;
            this.lbError.Text = "تعداد حق رأی شمارش شده بیشتر از تعداد حاضرین است!";
            this.lbError.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Location = new System.Drawing.Point(9, 280);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 33);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "بروزرسانی";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // chAutoUpdate
            // 
            this.chAutoUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chAutoUpdate.AutoSize = true;
            this.chAutoUpdate.Checked = true;
            this.chAutoUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chAutoUpdate.Location = new System.Drawing.Point(244, 287);
            this.chAutoUpdate.Name = "chAutoUpdate";
            this.chAutoUpdate.Size = new System.Drawing.Size(125, 20);
            this.chAutoUpdate.TabIndex = 4;
            this.chAutoUpdate.Text = "بروزرسانی خودکار";
            this.chAutoUpdate.UseVisualStyleBackColor = true;
            // 
            // lbCounted
            // 
            this.lbCounted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCounted.Location = new System.Drawing.Point(103, 57);
            this.lbCounted.Name = "lbCounted";
            this.lbCounted.Size = new System.Drawing.Size(86, 13);
            this.lbCounted.TabIndex = 3;
            this.lbCounted.Text = "label4";
            // 
            // lbPresence
            // 
            this.lbPresence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPresence.Location = new System.Drawing.Point(103, 25);
            this.lbPresence.Name = "lbPresence";
            this.lbPresence.Size = new System.Drawing.Size(86, 13);
            this.lbPresence.TabIndex = 2;
            this.lbPresence.Text = "1200000";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "تعداد آراء شمارش شده:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "تعداد حق رأی حاضر در مجمع:";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 342);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(907, 7);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // JCountPollingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 678);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JCountPollingList";
            this.Text = "شمارش آراء";
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnNewVote;
        private System.Windows.Forms.GroupBox groupBox2;
        private ClassLibrary.JJanusGrid grdCountedList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Splitter splitter1;
        private ClassLibrary.JJanusGrid grdResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCounted;
        private System.Windows.Forms.Label lbPresence;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckBox chAutoUpdate;
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.Button btnPrintResult;
        private System.Windows.Forms.Button btnDetail;

    }
}