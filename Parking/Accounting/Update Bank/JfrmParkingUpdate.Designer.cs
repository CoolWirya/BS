namespace Parking
{
    partial class JfrmParkingUpdate
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
            this.BtnUpdateCard = new System.Windows.Forms.Button();
            this.BtnUpdatBase = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdContractsGoodwill = new ClassLibrary.JJanusGrid();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnParkingRecord = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDateIn = new ClassLibrary.DateEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.TxtDateOut = new ClassLibrary.DateEdit(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnUpdateCard
            // 
            this.BtnUpdateCard.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnUpdateCard.Location = new System.Drawing.Point(658, 19);
            this.BtnUpdateCard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnUpdateCard.Name = "BtnUpdateCard";
            this.BtnUpdateCard.Size = new System.Drawing.Size(214, 31);
            this.BtnUpdateCard.TabIndex = 0;
            this.BtnUpdateCard.Text = "بروز رساني ونمايش اطلاعات كارتها";
            this.BtnUpdateCard.UseVisualStyleBackColor = true;
            this.BtnUpdateCard.Click += new System.EventHandler(this.BtnUpdateCard_Click);
            // 
            // BtnUpdatBase
            // 
            this.BtnUpdatBase.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnUpdatBase.Location = new System.Drawing.Point(444, 19);
            this.BtnUpdatBase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnUpdatBase.Name = "BtnUpdatBase";
            this.BtnUpdatBase.Size = new System.Drawing.Size(214, 31);
            this.BtnUpdatBase.TabIndex = 1;
            this.BtnUpdatBase.Text = "بروزرساني و نمايش اطلاعات گيت ها";
            this.BtnUpdatBase.UseVisualStyleBackColor = true;
            this.BtnUpdatBase.Click += new System.EventHandler(this.BtnUpdatBase_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdContractsGoodwill);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(875, 707);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "اطلاعات";
            // 
            // grdContractsGoodwill
            // 
            this.grdContractsGoodwill.ActionMenu = null;
            this.grdContractsGoodwill.DataSource = null;
            this.grdContractsGoodwill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdContractsGoodwill.Location = new System.Drawing.Point(3, 19);
            this.grdContractsGoodwill.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdContractsGoodwill.MultiSelect = false;
            this.grdContractsGoodwill.Name = "grdContractsGoodwill";
            this.grdContractsGoodwill.ShowNavigator = true;
            this.grdContractsGoodwill.ShowToolbar = true;
            this.grdContractsGoodwill.Size = new System.Drawing.Size(869, 685);
            this.grdContractsGoodwill.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(230, 19);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(214, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "بروزرساني و نمايش اطلاعات گروه ها";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.BtnUpdatBase);
            this.groupBox2.Controls.Add(this.BtnUpdateCard);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 707);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(875, 53);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "بروزرساني و نمايش";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TxtDateOut);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtDateIn);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.BtnParkingRecord);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 760);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(875, 57);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "نمايش ركوردهاي پاركينگ";
            // 
            // BtnParkingRecord
            // 
            this.BtnParkingRecord.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnParkingRecord.Location = new System.Drawing.Point(658, 19);
            this.BtnParkingRecord.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnParkingRecord.Name = "BtnParkingRecord";
            this.BtnParkingRecord.Size = new System.Drawing.Size(214, 35);
            this.BtnParkingRecord.TabIndex = 1;
            this.BtnParkingRecord.Text = "بروزرساني و تغيير ركوردهاي پاركينگ";
            this.BtnParkingRecord.UseVisualStyleBackColor = true;
            this.BtnParkingRecord.Click += new System.EventHandler(this.BtnParkingRecord_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(599, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "از تاريخ:";
            // 
            // txtDateIn
            // 
            this.txtDateIn.ChangeColorIfNotEmpty = true;
            this.txtDateIn.ChangeColorOnEnter = true;
            this.txtDateIn.Date = new System.DateTime(((long)(0)));
            this.txtDateIn.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDateIn.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateIn.InsertInDatesTable = true;
            this.txtDateIn.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDateIn.Location = new System.Drawing.Point(521, 25);
            this.txtDateIn.Mask = "0000/00/00";
            this.txtDateIn.Name = "txtDateIn";
            this.txtDateIn.NotEmpty = false;
            this.txtDateIn.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateIn.Size = new System.Drawing.Size(77, 23);
            this.txtDateIn.TabIndex = 89;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(450, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 90;
            this.label2.Text = "تا تاريخ :";
            // 
            // TxtDateOut
            // 
            this.TxtDateOut.ChangeColorIfNotEmpty = true;
            this.TxtDateOut.ChangeColorOnEnter = true;
            this.TxtDateOut.Date = new System.DateTime(((long)(0)));
            this.TxtDateOut.InBackColor = System.Drawing.SystemColors.Info;
            this.TxtDateOut.InForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtDateOut.InsertInDatesTable = true;
            this.TxtDateOut.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.TxtDateOut.Location = new System.Drawing.Point(376, 25);
            this.TxtDateOut.Mask = "0000/00/00";
            this.TxtDateOut.Name = "TxtDateOut";
            this.TxtDateOut.NotEmpty = false;
            this.TxtDateOut.NotEmptyColor = System.Drawing.Color.Red;
            this.TxtDateOut.Size = new System.Drawing.Size(77, 23);
            this.TxtDateOut.TabIndex = 91;
            // 
            // JfrmParkingUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 821);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JfrmParkingUpdate";
            this.Text = "بروز رساني اطلاعات پاركينگ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.JfrmParkingUpdate_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnUpdateCard;
        private System.Windows.Forms.Button BtnUpdatBase;
        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.JJanusGrid grdContractsGoodwill;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnParkingRecord;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.DateEdit TxtDateOut;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.DateEdit txtDateIn;
    }
}