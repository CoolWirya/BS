namespace ArchivedDocuments
{
    partial class JArchiveForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnArchive = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPlaceName = new ClassLibrary.TextEdit(this.components);
            this.txtSubjectName = new ClassLibrary.TextEdit(this.components);
            this.txtPlaceCode = new ClassLibrary.TextEdit(this.components);
            this.txtSubjectCode = new ClassLibrary.TextEdit(this.components);
            this.btnSearchPlace = new System.Windows.Forms.Button();
            this.btnSearchSubject = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.jJanusGrid1 = new ClassLibrary.JJanusGrid();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnArchive);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 407);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(574, 44);
            this.panel1.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(406, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnArchive
            // 
            this.btnArchive.Location = new System.Drawing.Point(487, 6);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Size = new System.Drawing.Size(75, 32);
            this.btnArchive.TabIndex = 0;
            this.btnArchive.Text = "Archive";
            this.btnArchive.UseVisualStyleBackColor = true;
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPlaceName);
            this.groupBox1.Controls.Add(this.txtSubjectName);
            this.groupBox1.Controls.Add(this.txtPlaceCode);
            this.groupBox1.Controls.Add(this.txtSubjectCode);
            this.groupBox1.Controls.Add(this.btnSearchPlace);
            this.groupBox1.Controls.Add(this.btnSearchSubject);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtPlaceName
            // 
            this.txtPlaceName.ChangeColorIfNotEmpty = true;
            this.txtPlaceName.ChangeColorOnEnter = true;
            this.txtPlaceName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPlaceName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPlaceName.Location = new System.Drawing.Point(50, 51);
            this.txtPlaceName.Name = "txtPlaceName";
            this.txtPlaceName.Negative = true;
            this.txtPlaceName.NotEmpty = false;
            this.txtPlaceName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPlaceName.ReadOnly = true;
            this.txtPlaceName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPlaceName.SelectOnEnter = true;
            this.txtPlaceName.Size = new System.Drawing.Size(346, 23);
            this.txtPlaceName.TabIndex = 9;
            this.txtPlaceName.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.ChangeColorIfNotEmpty = true;
            this.txtSubjectName.ChangeColorOnEnter = true;
            this.txtSubjectName.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSubjectName.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSubjectName.Location = new System.Drawing.Point(50, 16);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Negative = true;
            this.txtSubjectName.NotEmpty = false;
            this.txtSubjectName.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSubjectName.ReadOnly = true;
            this.txtSubjectName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSubjectName.SelectOnEnter = true;
            this.txtSubjectName.Size = new System.Drawing.Size(346, 23);
            this.txtSubjectName.TabIndex = 8;
            this.txtSubjectName.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtPlaceCode
            // 
            this.txtPlaceCode.ChangeColorIfNotEmpty = true;
            this.txtPlaceCode.ChangeColorOnEnter = true;
            this.txtPlaceCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPlaceCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPlaceCode.Location = new System.Drawing.Point(402, 51);
            this.txtPlaceCode.Name = "txtPlaceCode";
            this.txtPlaceCode.Negative = true;
            this.txtPlaceCode.NotEmpty = false;
            this.txtPlaceCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPlaceCode.ReadOnly = true;
            this.txtPlaceCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPlaceCode.SelectOnEnter = true;
            this.txtPlaceCode.Size = new System.Drawing.Size(64, 23);
            this.txtPlaceCode.TabIndex = 7;
            this.txtPlaceCode.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtSubjectCode
            // 
            this.txtSubjectCode.ChangeColorIfNotEmpty = true;
            this.txtSubjectCode.ChangeColorOnEnter = true;
            this.txtSubjectCode.InBackColor = System.Drawing.SystemColors.Info;
            this.txtSubjectCode.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSubjectCode.Location = new System.Drawing.Point(402, 16);
            this.txtSubjectCode.Name = "txtSubjectCode";
            this.txtSubjectCode.Negative = true;
            this.txtSubjectCode.NotEmpty = false;
            this.txtSubjectCode.NotEmptyColor = System.Drawing.Color.Red;
            this.txtSubjectCode.ReadOnly = true;
            this.txtSubjectCode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSubjectCode.SelectOnEnter = true;
            this.txtSubjectCode.Size = new System.Drawing.Size(64, 23);
            this.txtSubjectCode.TabIndex = 6;
            this.txtSubjectCode.TextMode = ClassLibrary.TextModes.Text;
            // 
            // btnSearchPlace
            // 
            this.btnSearchPlace.Location = new System.Drawing.Point(12, 51);
            this.btnSearchPlace.Name = "btnSearchPlace";
            this.btnSearchPlace.Size = new System.Drawing.Size(32, 23);
            this.btnSearchPlace.TabIndex = 5;
            this.btnSearchPlace.Text = "...";
            this.btnSearchPlace.UseVisualStyleBackColor = true;
            this.btnSearchPlace.Click += new System.EventHandler(this.btnSearchPlace_Click);
            // 
            // btnSearchSubject
            // 
            this.btnSearchSubject.Location = new System.Drawing.Point(12, 12);
            this.btnSearchSubject.Name = "btnSearchSubject";
            this.btnSearchSubject.Size = new System.Drawing.Size(32, 23);
            this.btnSearchSubject.TabIndex = 4;
            this.btnSearchSubject.Text = "...";
            this.btnSearchSubject.UseVisualStyleBackColor = true;
            this.btnSearchSubject.Click += new System.EventHandler(this.btnSearchSubject_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(472, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "PlaceArchive:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(472, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "SubjectArchive:";
            // 
            // jJanusGrid1
            // 
            this.jJanusGrid1.ActionMenu = null;
            this.jJanusGrid1.DataSource = null;
            this.jJanusGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jJanusGrid1.Location = new System.Drawing.Point(0, 212);
            this.jJanusGrid1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jJanusGrid1.MultiSelect = false;
            this.jJanusGrid1.Name = "jJanusGrid1";
            this.jJanusGrid1.Size = new System.Drawing.Size(574, 195);
            this.jJanusGrid1.TabIndex = 3;
            // 
            // txtDescription
            // 
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDescription.Location = new System.Drawing.Point(0, 114);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(574, 98);
            this.txtDescription.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(492, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Description:";
            // 
            // JArchiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 451);
            this.Controls.Add(this.jJanusGrid1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "JArchiveForm";
            this.Text = "ArchiveForm";
            this.Load += new System.EventHandler(this.ArchiveForm_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchPlace;
        private System.Windows.Forms.Button btnSearchSubject;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnArchive;
        private ClassLibrary.TextEdit txtPlaceCode;
        private ClassLibrary.TextEdit txtSubjectCode;
        private ClassLibrary.TextEdit txtPlaceName;
        private ClassLibrary.TextEdit txtSubjectName;
        private ClassLibrary.JJanusGrid jJanusGrid1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;

    }
}