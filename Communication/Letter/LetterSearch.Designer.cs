namespace Communication.Letter
{
    partial class LetterSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LetterSearch));
            this.grdLetters = new ClassLibrary.JJanusGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.chbRefers = new System.Windows.Forms.CheckBox();
            this.txtReciever = new ClassLibrary.TextEdit(this.components);
            this.txtSender = new ClassLibrary.TextEdit(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.rbnTrash = new System.Windows.Forms.RadioButton();
            this.rbnArchive = new System.Windows.Forms.RadioButton();
            this.rbnKartable = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dateEnd = new ClassLibrary.DateEdit(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.dateStart = new ClassLibrary.DateEdit(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.txtContent = new ClassLibrary.TextEdit(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSubject = new ClassLibrary.TextEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtLetterNo = new ClassLibrary.TextEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdLetters
            // 
            this.grdLetters.ActionClassName = "";
            this.grdLetters.ActionMenu = null;
            this.grdLetters.DataSource = null;
            this.grdLetters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLetters.Edited = false;
            this.grdLetters.Location = new System.Drawing.Point(0, 233);
            this.grdLetters.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdLetters.MultiSelect = false;
            this.grdLetters.Name = "grdLetters";
            this.grdLetters.ShowNavigator = false;
            this.grdLetters.ShowToolbar = true;
            this.grdLetters.Size = new System.Drawing.Size(858, 308);
            this.grdLetters.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.chbRefers);
            this.panel1.Controls.Add(this.txtReciever);
            this.panel1.Controls.Add(this.txtSender);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.rbnTrash);
            this.panel1.Controls.Add(this.rbnArchive);
            this.panel1.Controls.Add(this.rbnKartable);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.dateEnd);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.dateStart);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtContent);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtSubject);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtLetterNo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(858, 233);
            this.panel1.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Location = new System.Drawing.Point(374, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 18);
            this.label9.TabIndex = 26;
            this.label9.Text = "جستجو در ارجاعات:";
            // 
            // chbRefers
            // 
            this.chbRefers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbRefers.AutoSize = true;
            this.chbRefers.Checked = true;
            this.chbRefers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbRefers.Enabled = false;
            this.chbRefers.Location = new System.Drawing.Point(353, 125);
            this.chbRefers.Name = "chbRefers";
            this.chbRefers.Size = new System.Drawing.Size(15, 14);
            this.chbRefers.TabIndex = 25;
            this.chbRefers.UseVisualStyleBackColor = true;
            // 
            // txtReciever
            // 
            this.txtReciever.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReciever.ChangeColorIfNotEmpty = false;
            this.txtReciever.ChangeColorOnEnter = true;
            this.txtReciever.InBackColor = System.Drawing.SystemColors.Info;
            this.txtReciever.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtReciever.Location = new System.Drawing.Point(87, 91);
            this.txtReciever.Name = "txtReciever";
            this.txtReciever.Negative = true;
            this.txtReciever.NotEmpty = false;
            this.txtReciever.NotEmptyColor = System.Drawing.Color.Red;
            this.txtReciever.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtReciever.SelectOnEnter = true;
            this.txtReciever.Size = new System.Drawing.Size(298, 23);
            this.txtReciever.TabIndex = 24;
            this.txtReciever.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtSender
            // 
            this.txtSender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSender.ChangeColorIfNotEmpty = false;
            this.txtSender.ChangeColorOnEnter = true;
            this.txtSender.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSender.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSender.Location = new System.Drawing.Point(87, 62);
            this.txtSender.Name = "txtSender";
            this.txtSender.Negative = true;
            this.txtSender.NotEmpty = false;
            this.txtSender.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSender.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSender.SelectOnEnter = true;
            this.txtSender.Size = new System.Drawing.Size(298, 23);
            this.txtSender.TabIndex = 23;
            this.txtSender.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.ForeColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(858, 48);
            this.label8.TabIndex = 22;
            this.label8.Text = "جستجو نامه ها...";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbnTrash
            // 
            this.rbnTrash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbnTrash.AutoSize = true;
            this.rbnTrash.Location = new System.Drawing.Point(587, 201);
            this.rbnTrash.Name = "rbnTrash";
            this.rbnTrash.Size = new System.Drawing.Size(147, 20);
            this.rbnTrash.TabIndex = 21;
            this.rbnTrash.Text = "جستجو در سطل زباله";
            this.rbnTrash.UseVisualStyleBackColor = true;
            this.rbnTrash.Visible = false;
            // 
            // rbnArchive
            // 
            this.rbnArchive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbnArchive.AutoSize = true;
            this.rbnArchive.Location = new System.Drawing.Point(579, 175);
            this.rbnArchive.Name = "rbnArchive";
            this.rbnArchive.Size = new System.Drawing.Size(155, 20);
            this.rbnArchive.TabIndex = 20;
            this.rbnArchive.Text = "جستجو در آرشیو اسناد";
            this.rbnArchive.UseVisualStyleBackColor = true;
            this.rbnArchive.Visible = false;
            // 
            // rbnKartable
            // 
            this.rbnKartable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbnKartable.AutoSize = true;
            this.rbnKartable.Checked = true;
            this.rbnKartable.Location = new System.Drawing.Point(610, 149);
            this.rbnKartable.Name = "rbnKartable";
            this.rbnKartable.Size = new System.Drawing.Size(124, 20);
            this.rbnKartable.TabIndex = 19;
            this.rbnKartable.TabStop = true;
            this.rbnKartable.Text = "جستجو در کارتابل";
            this.rbnKartable.UseVisualStyleBackColor = true;
            this.rbnKartable.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(87, 179);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(143, 42);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dateEnd
            // 
            this.dateEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateEnd.ChangeColorIfNotEmpty = true;
            this.dateEnd.ChangeColorOnEnter = true;
            this.dateEnd.Date = new System.DateTime(((long)(0)));
            this.dateEnd.InBackColor = System.Drawing.SystemColors.Info;
            this.dateEnd.InForeColor = System.Drawing.SystemColors.WindowText;
            this.dateEnd.InsertInDatesTable = true;
            this.dateEnd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dateEnd.Location = new System.Drawing.Point(87, 148);
            this.dateEnd.Mask = "0000/00/00";
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.NotEmpty = false;
            this.dateEnd.NotEmptyColor = System.Drawing.Color.Red;
            this.dateEnd.Size = new System.Drawing.Size(81, 23);
            this.dateEnd.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(174, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = "تا تاریخ:";
            // 
            // dateStart
            // 
            this.dateStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateStart.ChangeColorIfNotEmpty = true;
            this.dateStart.ChangeColorOnEnter = true;
            this.dateStart.Date = new System.DateTime(((long)(0)));
            this.dateStart.InBackColor = System.Drawing.SystemColors.Info;
            this.dateStart.InForeColor = System.Drawing.SystemColors.WindowText;
            this.dateStart.InsertInDatesTable = true;
            this.dateStart.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.dateStart.Location = new System.Drawing.Point(304, 148);
            this.dateStart.Mask = "0000/00/00";
            this.dateStart.Name = "dateStart";
            this.dateStart.NotEmpty = false;
            this.dateStart.NotEmptyColor = System.Drawing.Color.Red;
            this.dateStart.Size = new System.Drawing.Size(81, 23);
            this.dateStart.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(391, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "از تاریخ:";
            // 
            // txtContent
            // 
            this.txtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContent.ChangeColorIfNotEmpty = false;
            this.txtContent.ChangeColorOnEnter = true;
            this.txtContent.InBackColor = System.Drawing.SystemColors.Info;
            this.txtContent.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtContent.Location = new System.Drawing.Point(512, 120);
            this.txtContent.Name = "txtContent";
            this.txtContent.Negative = true;
            this.txtContent.NotEmpty = false;
            this.txtContent.NotEmptyColor = System.Drawing.Color.Red;
            this.txtContent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtContent.SelectOnEnter = true;
            this.txtContent.Size = new System.Drawing.Size(222, 23);
            this.txtContent.TabIndex = 9;
            this.txtContent.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(740, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "متن نامه:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(391, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "گیرنده:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(391, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "فرستنده:";
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.ChangeColorIfNotEmpty = false;
            this.txtSubject.ChangeColorOnEnter = true;
            this.txtSubject.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSubject.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSubject.Location = new System.Drawing.Point(512, 91);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Negative = true;
            this.txtSubject.NotEmpty = false;
            this.txtSubject.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSubject.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSubject.SelectOnEnter = true;
            this.txtSubject.Size = new System.Drawing.Size(222, 23);
            this.txtSubject.TabIndex = 3;
            this.txtSubject.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(740, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "موضوع نامه:";
            // 
            // txtLetterNo
            // 
            this.txtLetterNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLetterNo.ChangeColorIfNotEmpty = false;
            this.txtLetterNo.ChangeColorOnEnter = true;
            this.txtLetterNo.InBackColor = System.Drawing.SystemColors.Info;
            this.txtLetterNo.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLetterNo.Location = new System.Drawing.Point(597, 62);
            this.txtLetterNo.Name = "txtLetterNo";
            this.txtLetterNo.Negative = true;
            this.txtLetterNo.NotEmpty = false;
            this.txtLetterNo.NotEmptyColor = System.Drawing.Color.Red;
            this.txtLetterNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLetterNo.SelectOnEnter = true;
            this.txtLetterNo.Size = new System.Drawing.Size(137, 23);
            this.txtLetterNo.TabIndex = 1;
            this.txtLetterNo.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(740, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "شماره نامه: ";
            // 
            // LetterSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 541);
            this.Controls.Add(this.grdLetters);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LetterSearch";
            this.Text = "LetterSearch";
            this.Load += new System.EventHandler(this.LetterSearch_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ClassLibrary.JJanusGrid grdLetters;
        private System.Windows.Forms.Panel panel1;
        private ClassLibrary.TextEdit txtSubject;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.TextEdit txtLetterNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.TextEdit txtContent;
        private System.Windows.Forms.Label label5;
        private ClassLibrary.DateEdit dateEnd;
        private System.Windows.Forms.Label label7;
        private ClassLibrary.DateEdit dateStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RadioButton rbnTrash;
        private System.Windows.Forms.RadioButton rbnArchive;
        private System.Windows.Forms.RadioButton rbnKartable;
        private System.Windows.Forms.Label label8;
        private ClassLibrary.TextEdit txtReciever;
        private ClassLibrary.TextEdit txtSender;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chbRefers;
    }
}