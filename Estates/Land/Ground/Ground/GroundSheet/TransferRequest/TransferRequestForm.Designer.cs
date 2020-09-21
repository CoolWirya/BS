namespace Estates
{
    partial class JTransferRequestForm
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
            this.textEdit1 = new ClassLibrary.TextEdit(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtDesc = new ClassLibrary.TextEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.jucBuyer = new ClassLibrary.JUCPerson();
            this.jucSeller = new ClassLibrary.JUCPerson();
            this.chkManager = new System.Windows.Forms.CheckBox();
            this.chkManagerSaham = new System.Windows.Forms.CheckBox();
            this.chkRespon = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ArchiveList = new ArchivedDocuments.JArchiveList();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDesign = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSabt = new System.Windows.Forms.Button();
            this.txtPrice = new ClassLibrary.NumEdit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textEdit1
            // 
            this.textEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textEdit1.ChangeColorIfNotEmpty = false;
            this.textEdit1.ChangeColorOnEnter = true;
            this.textEdit1.InBackColor = System.Drawing.SystemColors.Info;
            this.textEdit1.InForeColor = System.Drawing.SystemColors.WindowText;
            this.textEdit1.Location = new System.Drawing.Point(124, 6);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Negative = true;
            this.textEdit1.NotEmpty = false;
            this.textEdit1.NotEmptyColor = System.Drawing.Color.Red;
            this.textEdit1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textEdit1.SelectOnEnter = true;
            this.textEdit1.Size = new System.Drawing.Size(126, 20);
            this.textEdit1.TabIndex = 37;
            this.textEdit1.Tag = "=";
            this.textEdit1.Text = "0";
            this.textEdit1.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(723, 415);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtPrice);
            this.tabPage1.Controls.Add(this.txtDesc);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.chkManager);
            this.tabPage1.Controls.Add(this.chkManagerSaham);
            this.tabPage1.Controls.Add(this.chkRespon);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtDate);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(715, 386);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "اطلاعات درخواست";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtDesc
            // 
            this.txtDesc.ChangeColorIfNotEmpty = false;
            this.txtDesc.ChangeColorOnEnter = true;
            this.txtDesc.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtDesc.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDesc.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDesc.Location = new System.Drawing.Point(3, 216);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Negative = true;
            this.txtDesc.NotEmpty = false;
            this.txtDesc.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDesc.SelectOnEnter = true;
            this.txtDesc.Size = new System.Drawing.Size(275, 167);
            this.txtDesc.TabIndex = 84;
            this.txtDesc.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(210, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 85;
            this.label4.Text = "توضیحات:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.jucBuyer);
            this.groupBox1.Controls.Add(this.jucSeller);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(278, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 380);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // jucBuyer
            // 
            this.jucBuyer.Dock = System.Windows.Forms.DockStyle.Top;
            this.jucBuyer.FilterPerson = null;
            this.jucBuyer.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.jucBuyer.LableGroup = "خریدار";
            this.jucBuyer.Location = new System.Drawing.Point(3, 201);
            this.jucBuyer.Name = "jucBuyer";
            this.jucBuyer.PersonType = ClassLibrary.JPersonTypes.None;
            this.jucBuyer.ReadOnly = false;
            this.jucBuyer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.jucBuyer.SelectedCode = 0;
            this.jucBuyer.Size = new System.Drawing.Size(428, 181);
            this.jucBuyer.TabIndex = 2;
            // 
            // jucSeller
            // 
            this.jucSeller.Dock = System.Windows.Forms.DockStyle.Top;
            this.jucSeller.FilterPerson = null;
            this.jucSeller.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.jucSeller.LableGroup = "فروشنده";
            this.jucSeller.Location = new System.Drawing.Point(3, 19);
            this.jucSeller.Name = "jucSeller";
            this.jucSeller.PersonType = ClassLibrary.JPersonTypes.None;
            this.jucSeller.ReadOnly = true;
            this.jucSeller.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.jucSeller.SelectedCode = 0;
            this.jucSeller.Size = new System.Drawing.Size(428, 182);
            this.jucSeller.TabIndex = 1;
            // 
            // chkManager
            // 
            this.chkManager.AutoSize = true;
            this.chkManager.Location = new System.Drawing.Point(80, 153);
            this.chkManager.Name = "chkManager";
            this.chkManager.Size = new System.Drawing.Size(110, 20);
            this.chkManager.TabIndex = 7;
            this.chkManager.Text = "تایید مدیر عامل";
            this.chkManager.UseVisualStyleBackColor = true;
            // 
            // chkManagerSaham
            // 
            this.chkManagerSaham.AutoSize = true;
            this.chkManagerSaham.Location = new System.Drawing.Point(76, 127);
            this.chkManagerSaham.Name = "chkManagerSaham";
            this.chkManagerSaham.Size = new System.Drawing.Size(114, 20);
            this.chkManagerSaham.TabIndex = 6;
            this.chkManagerSaham.Text = "تایید مدیر سهام";
            this.chkManagerSaham.UseVisualStyleBackColor = true;
            // 
            // chkRespon
            // 
            this.chkRespon.AutoSize = true;
            this.chkRespon.Location = new System.Drawing.Point(95, 101);
            this.chkRespon.Name = "chkRespon";
            this.chkRespon.Size = new System.Drawing.Size(95, 20);
            this.chkRespon.TabIndex = 5;
            this.chkRespon.Text = "تایید مسئول";
            this.chkRespon.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "وضعیت:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "مبلغ انتقال:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "تاریخ درخواست انتقال:";
            // 
            // txtDate
            // 
            this.txtDate.ChangeColorIfNotEmpty = true;
            this.txtDate.ChangeColorOnEnter = true;
            this.txtDate.Date = new System.DateTime(((long)(0)));
            this.txtDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDate.InsertInDatesTable = true;
            this.txtDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDate.Location = new System.Drawing.Point(34, 21);
            this.txtDate.Mask = "0000/00/00";
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDate.Size = new System.Drawing.Size(100, 23);
            this.txtDate.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ArchiveList);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(715, 386);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "تصاویر";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ArchiveList
            // 
            this.ArchiveList.AllowUserAddFile = true;
            this.ArchiveList.AllowUserAddFromArchive = true;
            this.ArchiveList.AllowUserAddImage = true;
            this.ArchiveList.AllowUserDeleteFile = true;
            this.ArchiveList.ClassName = "";
            this.ArchiveList.ClassNames = null;
            this.ArchiveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchiveList.EnabledChange = true;
            this.ArchiveList.Location = new System.Drawing.Point(3, 3);
            this.ArchiveList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ArchiveList.Name = "ArchiveList";
            this.ArchiveList.ObjectCode = 0;
            this.ArchiveList.ObjectCodes = null;
            this.ArchiveList.PlaceCode = 0;
            this.ArchiveList.Size = new System.Drawing.Size(709, 380);
            this.ArchiveList.SubjectCode = 0;
            this.ArchiveList.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnDesign);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnSabt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 415);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 36);
            this.panel1.TabIndex = 8;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(4, 7);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(135, 26);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDesign
            // 
            this.btnDesign.Location = new System.Drawing.Point(295, 6);
            this.btnDesign.Name = "btnDesign";
            this.btnDesign.Size = new System.Drawing.Size(135, 26);
            this.btnDesign.TabIndex = 9;
            this.btnDesign.Text = "طراحی";
            this.btnDesign.UseVisualStyleBackColor = true;
            this.btnDesign.Click += new System.EventHandler(this.btnDesign_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(436, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(135, 26);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "چاپ";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSabt
            // 
            this.btnSabt.Location = new System.Drawing.Point(577, 6);
            this.btnSabt.Name = "btnSabt";
            this.btnSabt.Size = new System.Drawing.Size(137, 26);
            this.btnSabt.TabIndex = 8;
            this.btnSabt.Text = "ثبت";
            this.btnSabt.UseVisualStyleBackColor = true;
            this.btnSabt.Click += new System.EventHandler(this.btnSabt_Click);
            // 
            // txtPrice
            // 
            this.txtPrice.ChangeColorIfNotEmpty = false;
            this.txtPrice.ChangeColorOnEnter = true;
            this.txtPrice.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPrice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPrice.Location = new System.Drawing.Point(8, 62);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Negative = true;
            this.txtPrice.NotEmpty = false;
            this.txtPrice.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPrice.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPrice.SelectOnEnter = true;
            this.txtPrice.Size = new System.Drawing.Size(187, 23);
            this.txtPrice.TabIndex = 86;
            this.txtPrice.TextMode = ClassLibrary.TextModes.Money;
            // 
            // JTransferRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 451);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "JTransferRequestForm";
            this.Text = "TransferRequestForm";
            this.Load += new System.EventHandler(this.TransferRequestForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ClassLibrary.TextEdit textEdit1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ClassLibrary.DateEdit txtDate;
        private ClassLibrary.JUCPerson jucSeller;
        private ClassLibrary.JUCPerson jucBuyer;
        private System.Windows.Forms.TabPage tabPage2;
        private ArchivedDocuments.JArchiveList ArchiveList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSabt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkManager;
        private System.Windows.Forms.CheckBox chkManagerSaham;
        private System.Windows.Forms.CheckBox chkRespon;
        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.TextEdit txtDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDesign;
        private ClassLibrary.NumEdit txtPrice;

    }
}