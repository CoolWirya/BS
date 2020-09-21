namespace BusManagment.Fleet
{
    partial class FleetSearch
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
            this.DateEnd = new ClassLibrary.DateEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearchStartDate = new System.Windows.Forms.Button();
            this.DateStart = new ClassLibrary.DateEdit(this.components);
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.jJanusGridResault = new ClassLibrary.JJanusGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DateEnd);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnSearchStartDate);
            this.panel1.Controls.Add(this.DateStart);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 131);
            this.panel1.TabIndex = 0;
            // 
            // DateEnd
            // 
            this.DateEnd.ChangeColorIfNotEmpty = true;
            this.DateEnd.ChangeColorOnEnter = true;
            this.DateEnd.Date = new System.DateTime(((long)(0)));
            this.DateEnd.InBackColor = System.Drawing.SystemColors.Info;
            this.DateEnd.InForeColor = System.Drawing.SystemColors.WindowText;
            this.DateEnd.InsertInDatesTable = true;
            this.DateEnd.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.DateEnd.Location = new System.Drawing.Point(57, 48);
            this.DateEnd.Mask = "0000/00/00";
            this.DateEnd.Name = "DateEnd";
            this.DateEnd.NotEmpty = false;
            this.DateEnd.NotEmptyColor = System.Drawing.Color.Red;
            this.DateEnd.Size = new System.Drawing.Size(90, 20);
            this.DateEnd.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "End Date:";
            // 
            // btnSearchStartDate
            // 
            this.btnSearchStartDate.Location = new System.Drawing.Point(230, 80);
            this.btnSearchStartDate.Name = "btnSearchStartDate";
            this.btnSearchStartDate.Size = new System.Drawing.Size(98, 31);
            this.btnSearchStartDate.TabIndex = 5;
            this.btnSearchStartDate.Text = "Search";
            this.btnSearchStartDate.UseVisualStyleBackColor = true;
            this.btnSearchStartDate.Click += new System.EventHandler(this.btnSearchStartDate_Click);
            // 
            // DateStart
            // 
            this.DateStart.ChangeColorIfNotEmpty = true;
            this.DateStart.ChangeColorOnEnter = true;
            this.DateStart.Date = new System.DateTime(((long)(0)));
            this.DateStart.InBackColor = System.Drawing.SystemColors.Info;
            this.DateStart.InForeColor = System.Drawing.SystemColors.WindowText;
            this.DateStart.InsertInDatesTable = true;
            this.DateStart.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.DateStart.Location = new System.Drawing.Point(230, 48);
            this.DateStart.Mask = "0000/00/00";
            this.DateStart.Name = "DateStart";
            this.DateStart.NotEmpty = false;
            this.DateStart.NotEmptyColor = System.Drawing.Color.Red;
            this.DateStart.Size = new System.Drawing.Size(98, 20);
            this.DateStart.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(385, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(141, 20);
            this.txtName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Start Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(492, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // jJanusGridResault
            // 
            this.jJanusGridResault.ActionClassName = "";
            this.jJanusGridResault.ActionMenu = null;
            this.jJanusGridResault.DataSource = null;
            this.jJanusGridResault.Edited = false;
            this.jJanusGridResault.Location = new System.Drawing.Point(0, 117);
            this.jJanusGridResault.MultiSelect = true;
            this.jJanusGridResault.Name = "jJanusGridResault";
            this.jJanusGridResault.ShowNavigator = true;
            this.jJanusGridResault.ShowToolbar = true;
            this.jJanusGridResault.Size = new System.Drawing.Size(540, 286);
            this.jJanusGridResault.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Location = new System.Drawing.Point(0, 409);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(540, 39);
            this.panel2.TabIndex = 7;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(455, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // FleetSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 449);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.jJanusGridResault);
            this.Controls.Add(this.panel1);
            this.Name = "FleetSearch";
            this.Text = "FleetSearch";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearchStartDate;
        private ClassLibrary.DateEdit DateStart;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.JJanusGrid jJanusGridResault;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOk;
        private ClassLibrary.DateEdit DateEnd;
        private System.Windows.Forms.Label label3;
    }
}