namespace Globals
{
    partial class JDynamicReportForm
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
            this.listBoxReports = new System.Windows.Forms.ListBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPrview = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDesign = new System.Windows.Forms.Button();
            this.rBWord = new System.Windows.Forms.RadioButton();
            this.rBFastReport = new System.Windows.Forms.RadioButton();
            this.tBReportCaption = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxReports
            // 
            this.listBoxReports.FormattingEnabled = true;
            this.listBoxReports.ItemHeight = 16;
            this.listBoxReports.Location = new System.Drawing.Point(136, 42);
            this.listBoxReports.Name = "listBoxReports";
            this.listBoxReports.Size = new System.Drawing.Size(237, 260);
            this.listBoxReports.TabIndex = 0;
            this.listBoxReports.SelectedIndexChanged += new System.EventHandler(this.listBoxReports_SelectedIndexChanged);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(12, 42);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(118, 23);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "جدید";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(12, 71);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(118, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "ویرایش";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 100);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(118, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnPrview
            // 
            this.btnPrview.Location = new System.Drawing.Point(12, 148);
            this.btnPrview.Name = "btnPrview";
            this.btnPrview.Size = new System.Drawing.Size(118, 23);
            this.btnPrview.TabIndex = 1;
            this.btnPrview.Text = "پیش نمایش";
            this.btnPrview.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(12, 177);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(118, 23);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "چاپ";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "لیست گزارشات تهیه شده:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnDesign);
            this.groupBox1.Controls.Add(this.rBWord);
            this.groupBox1.Controls.Add(this.rBFastReport);
            this.groupBox1.Controls.Add(this.tBReportCaption);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(379, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 260);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ویرایش گزارش";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(40, 135);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "ذخیره";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDesign
            // 
            this.btnDesign.Location = new System.Drawing.Point(147, 135);
            this.btnDesign.Name = "btnDesign";
            this.btnDesign.Size = new System.Drawing.Size(101, 23);
            this.btnDesign.TabIndex = 13;
            this.btnDesign.Text = "طراحی";
            this.btnDesign.UseVisualStyleBackColor = true;
            this.btnDesign.Click += new System.EventHandler(this.btnDesign_Click);
            // 
            // rBWord
            // 
            this.rBWord.AutoSize = true;
            this.rBWord.Location = new System.Drawing.Point(180, 89);
            this.rBWord.Name = "rBWord";
            this.rBWord.Size = new System.Drawing.Size(68, 20);
            this.rBWord.TabIndex = 12;
            this.rBWord.TabStop = true;
            this.rBWord.Text = "فایل ورد";
            this.rBWord.UseVisualStyleBackColor = true;
            // 
            // rBFastReport
            // 
            this.rBFastReport.AutoSize = true;
            this.rBFastReport.Checked = true;
            this.rBFastReport.Location = new System.Drawing.Point(87, 89);
            this.rBFastReport.Name = "rBFastReport";
            this.rBFastReport.Size = new System.Drawing.Size(87, 20);
            this.rBFastReport.TabIndex = 11;
            this.rBFastReport.TabStop = true;
            this.rBFastReport.Text = "گزارش ساز";
            this.rBFastReport.UseVisualStyleBackColor = true;
            // 
            // tBReportCaption
            // 
            this.tBReportCaption.Location = new System.Drawing.Point(6, 58);
            this.tBReportCaption.Name = "tBReportCaption";
            this.tBReportCaption.Size = new System.Drawing.Size(244, 23);
            this.tBReportCaption.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "عنوان گزارش:";
            // 
            // JDynamicReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 314);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPrview);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.listBoxReports);
            this.Name = "JDynamicReportForm";
            this.Text = "DynamicReportForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxReports;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnPrview;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDesign;
        private System.Windows.Forms.RadioButton rBWord;
        private System.Windows.Forms.RadioButton rBFastReport;
        private System.Windows.Forms.TextBox tBReportCaption;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
    }
}