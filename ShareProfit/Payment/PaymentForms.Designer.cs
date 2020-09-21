namespace ShareProfit
{
    partial class JPaymentForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JPaymentForm));
			ClassLibrary.JPopupMenu jPopupMenu4 = new ClassLibrary.JPopupMenu();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			ClassLibrary.JPopupMenu jPopupMenu3 = new ClassLibrary.JPopupMenu();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.btnSave = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.txtSoodDaryafti = new System.Windows.Forms.TextBox();
			this.txtkolsood = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.Properties = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.jDataGridPayment = new ClassLibrary.JDataGrid();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.LBCaptionCourse = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.jDataGridSheets = new ClassLibrary.JDataGrid();
			this.nudEndSheetNo = new System.Windows.Forms.NumericUpDown();
			this.nudStartSheetNo = new System.Windows.Forms.NumericUpDown();
			this.dateEditPayDate = new ClassLibrary.DateEdit(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.jucPerson = new ClassLibrary.JUCPerson();
			this.txtSheetNo_OLD = new ClassLibrary.TextEdit(this.components);
			this.lbSheetNo = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.jArchiveList1 = new ArchivedDocuments.JArchiveList();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.jPropertyValueUserControl1 = new Globals.Property.JPropertyValueUserControl();
			this.txtSheetNo_old2 = new ClassLibrary.TextEdit(this.components);
			this.BtnPrint = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.Properties.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.jDataGridPayment)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.jDataGridSheets)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudEndSheetNo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudStartSheetNo)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.Images.SetKeyName(0, "aktion.png");
			this.imageList.Images.SetKeyName(1, "alert.png");
			this.imageList.Images.SetKeyName(2, "All software is current.png");
			this.imageList.Images.SetKeyName(3, "amor.png");
			this.imageList.Images.SetKeyName(4, "antivirus.png");
			this.imageList.Images.SetKeyName(5, "applixware.png");
			this.imageList.Images.SetKeyName(6, "ark.png");
			this.imageList.Images.SetKeyName(7, "arts.png");
			// 
			// btnSave
			// 
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSave.Location = new System.Drawing.Point(585, 6);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(195, 26);
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "پرداخت";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.txtSoodDaryafti);
			this.panel1.Controls.Add(this.txtkolsood);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 649);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(792, 38);
			this.panel1.TabIndex = 5;
			// 
			// txtSoodDaryafti
			// 
			this.txtSoodDaryafti.Location = new System.Drawing.Point(7, 9);
			this.txtSoodDaryafti.Name = "txtSoodDaryafti";
			this.txtSoodDaryafti.ReadOnly = true;
			this.txtSoodDaryafti.Size = new System.Drawing.Size(152, 23);
			this.txtSoodDaryafti.TabIndex = 7;
			// 
			// txtkolsood
			// 
			this.txtkolsood.Location = new System.Drawing.Point(270, 9);
			this.txtkolsood.Name = "txtkolsood";
			this.txtkolsood.ReadOnly = true;
			this.txtkolsood.Size = new System.Drawing.Size(152, 23);
			this.txtkolsood.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(157, 11);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(107, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "کل سود دریافتی :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(428, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(137, 16);
			this.label2.TabIndex = 4;
			this.label2.Text = "کل سود تخصیص یافته :";
			// 
			// Properties
			// 
			this.Properties.Controls.Add(this.tabPage1);
			this.Properties.Controls.Add(this.tabPage3);
			this.Properties.Controls.Add(this.tabPage2);
			this.Properties.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Properties.Location = new System.Drawing.Point(0, 0);
			this.Properties.Name = "Properties";
			this.Properties.RightToLeftLayout = true;
			this.Properties.SelectedIndex = 0;
			this.Properties.Size = new System.Drawing.Size(792, 649);
			this.Properties.TabIndex = 6;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.groupBox3);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(784, 620);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Details";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.jDataGridPayment);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox3.Location = new System.Drawing.Point(3, 365);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(778, 252);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "PaymentInfo";
			// 
			// jDataGridPayment
			// 
			this.jDataGridPayment.ActionMenu = jPopupMenu4;
			this.jDataGridPayment.AllowUserToAddRows = false;
			this.jDataGridPayment.AllowUserToDeleteRows = false;
			this.jDataGridPayment.AllowUserToOrderColumns = true;
			dataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue;
			this.jDataGridPayment.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
			this.jDataGridPayment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.jDataGridPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.jDataGridPayment.Dock = System.Windows.Forms.DockStyle.Fill;
			this.jDataGridPayment.EnableContexMenu = true;
			this.jDataGridPayment.KeyName = null;
			this.jDataGridPayment.Location = new System.Drawing.Point(3, 19);
			this.jDataGridPayment.Name = "jDataGridPayment";
			this.jDataGridPayment.ReadHeadersFromDB = false;
			this.jDataGridPayment.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
			this.jDataGridPayment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.jDataGridPayment.ShowRowNumber = true;
			this.jDataGridPayment.Size = new System.Drawing.Size(772, 230);
			this.jDataGridPayment.TabIndex = 1;
			this.jDataGridPayment.TableName = null;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.BtnPrint);
			this.groupBox1.Controls.Add(this.LBCaptionCourse);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.jDataGridSheets);
			this.groupBox1.Controls.Add(this.nudEndSheetNo);
			this.groupBox1.Controls.Add(this.nudStartSheetNo);
			this.groupBox1.Controls.Add(this.dateEditPayDate);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.jucPerson);
			this.groupBox1.Controls.Add(this.txtSheetNo_OLD);
			this.groupBox1.Controls.Add(this.lbSheetNo);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(778, 362);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "SearchPerson";
			// 
			// LBCaptionCourse
			// 
			this.LBCaptionCourse.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LBCaptionCourse.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.LBCaptionCourse.ForeColor = System.Drawing.Color.Red;
			this.LBCaptionCourse.Location = new System.Drawing.Point(3, 19);
			this.LBCaptionCourse.Name = "LBCaptionCourse";
			this.LBCaptionCourse.Size = new System.Drawing.Size(772, 37);
			this.LBCaptionCourse.TabIndex = 18;
			this.LBCaptionCourse.Text = "label2";
			this.LBCaptionCourse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(29, 193);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(123, 41);
			this.button1.TabIndex = 21;
			this.button1.Text = "لیست پرداخت ها";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// jDataGridSheets
			// 
			this.jDataGridSheets.ActionMenu = jPopupMenu3;
			this.jDataGridSheets.AllowUserToAddRows = false;
			this.jDataGridSheets.AllowUserToDeleteRows = false;
			this.jDataGridSheets.AllowUserToOrderColumns = true;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue;
			this.jDataGridSheets.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.jDataGridSheets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.jDataGridSheets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.jDataGridSheets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.jDataGridSheets.EnableContexMenu = true;
			this.jDataGridSheets.KeyName = null;
			this.jDataGridSheets.Location = new System.Drawing.Point(3, 240);
			this.jDataGridSheets.Name = "jDataGridSheets";
			this.jDataGridSheets.ReadHeadersFromDB = false;
			this.jDataGridSheets.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
			this.jDataGridSheets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.jDataGridSheets.ShowRowNumber = true;
			this.jDataGridSheets.Size = new System.Drawing.Size(772, 116);
			this.jDataGridSheets.TabIndex = 20;
			this.jDataGridSheets.TableName = null;
			this.jDataGridSheets.SelectionChanged += new System.EventHandler(this.jDataGridSheets_SelectionChanged);
			// 
			// nudEndSheetNo
			// 
			this.nudEndSheetNo.Location = new System.Drawing.Point(29, 164);
			this.nudEndSheetNo.Name = "nudEndSheetNo";
			this.nudEndSheetNo.Size = new System.Drawing.Size(123, 23);
			this.nudEndSheetNo.TabIndex = 19;
			// 
			// nudStartSheetNo
			// 
			this.nudStartSheetNo.Location = new System.Drawing.Point(29, 135);
			this.nudStartSheetNo.Name = "nudStartSheetNo";
			this.nudStartSheetNo.Size = new System.Drawing.Size(123, 23);
			this.nudStartSheetNo.TabIndex = 2;
			// 
			// dateEditPayDate
			// 
			this.dateEditPayDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.dateEditPayDate.ChangeColorIfNotEmpty = true;
			this.dateEditPayDate.ChangeColorOnEnter = true;
			this.dateEditPayDate.Date = new System.DateTime(((long)(0)));
			this.dateEditPayDate.InBackColor = System.Drawing.SystemColors.Info;
			this.dateEditPayDate.InForeColor = System.Drawing.SystemColors.WindowText;
			this.dateEditPayDate.InsertInDatesTable = true;
			this.dateEditPayDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
			this.dateEditPayDate.Location = new System.Drawing.Point(297, 85);
			this.dateEditPayDate.Mask = "0000/00/00";
			this.dateEditPayDate.Name = "dateEditPayDate";
			this.dateEditPayDate.NotEmpty = false;
			this.dateEditPayDate.NotEmptyColor = System.Drawing.Color.Red;
			this.dateEditPayDate.Size = new System.Drawing.Size(100, 23);
			this.dateEditPayDate.TabIndex = 17;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(403, 85);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "PayDate:";
			// 
			// jucPerson
			// 
			this.jucPerson.CompanyCode = 1;
			this.jucPerson.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.jucPerson.FilterPerson = null;
			this.jucPerson.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.jucPerson.LableGroup = null;
			this.jucPerson.Location = new System.Drawing.Point(3, 56);
			this.jucPerson.Name = "jucPerson";
			this.jucPerson.PersonType = ClassLibrary.JPersonTypes.None;
			this.jucPerson.ReadOnly = false;
			this.jucPerson.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.jucPerson.SearchOnCode = ClassLibrary.SearchOnCode.SharePCode;
			this.jucPerson.SelectedCode = 0;
			this.jucPerson.Size = new System.Drawing.Size(772, 303);
			this.jucPerson.TabIndex = 7;
			this.jucPerson.TafsiliCode = false;
			this.jucPerson.AfterCodeSelected += new ClassLibrary.JUCPerson.CodeSelected(this.jucPerson_AfterCodeSelected);
			this.jucPerson.Load += new System.EventHandler(this.jucPerson_Load);
			// 
			// txtSheetNo_OLD
			// 
			this.txtSheetNo_OLD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSheetNo_OLD.ChangeColorIfNotEmpty = false;
			this.txtSheetNo_OLD.ChangeColorOnEnter = true;
			this.txtSheetNo_OLD.InBackColor = System.Drawing.SystemColors.Info;
			this.txtSheetNo_OLD.InForeColor = System.Drawing.SystemColors.WindowText;
			this.txtSheetNo_OLD.Location = new System.Drawing.Point(568, 199);
			this.txtSheetNo_OLD.Name = "txtSheetNo_OLD";
			this.txtSheetNo_OLD.Negative = true;
			this.txtSheetNo_OLD.NotEmpty = false;
			this.txtSheetNo_OLD.NotEmptyColor = System.Drawing.Color.Red;
			this.txtSheetNo_OLD.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtSheetNo_OLD.SelectOnEnter = true;
			this.txtSheetNo_OLD.Size = new System.Drawing.Size(123, 23);
			this.txtSheetNo_OLD.TabIndex = 16;
			this.txtSheetNo_OLD.TabStop = false;
			this.txtSheetNo_OLD.TextMode = ClassLibrary.TextModes.Integer;
			this.txtSheetNo_OLD.Leave += new System.EventHandler(this.txtSheetNo_Leave);
			// 
			// lbSheetNo
			// 
			this.lbSheetNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbSheetNo.AutoSize = true;
			this.lbSheetNo.Location = new System.Drawing.Point(709, 202);
			this.lbSheetNo.Name = "lbSheetNo";
			this.lbSheetNo.Size = new System.Drawing.Size(61, 16);
			this.lbSheetNo.TabIndex = 0;
			this.lbSheetNo.Text = "SheetNo:";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.jArchiveList1);
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(784, 620);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Image";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// jArchiveList1
			// 
			this.jArchiveList1.AllowUserAddFile = true;
			this.jArchiveList1.AllowUserAddFromArchive = true;
			this.jArchiveList1.AllowUserAddImage = true;
			this.jArchiveList1.AllowUserCamera = true;
			this.jArchiveList1.AllowUserDeleteFile = true;
			this.jArchiveList1.ClassName = "";
			this.jArchiveList1.ClassNames = null;
			this.jArchiveList1.DataBaseClassName = "";
			this.jArchiveList1.DataBaseObjectCode = 0;
			this.jArchiveList1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.jArchiveList1.EnabledChange = true;
			this.jArchiveList1.ExtraObject = null;
			this.jArchiveList1.Location = new System.Drawing.Point(3, 3);
			this.jArchiveList1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.jArchiveList1.Name = "jArchiveList1";
			this.jArchiveList1.ObjectCode = 0;
			this.jArchiveList1.ObjectCodes = null;
			this.jArchiveList1.PlaceCode = 0;
			this.jArchiveList1.Size = new System.Drawing.Size(778, 614);
			this.jArchiveList1.SubjectCode = 0;
			this.jArchiveList1.TabIndex = 0;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.jPropertyValueUserControl1);
			this.tabPage3.Location = new System.Drawing.Point(4, 25);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(784, 620);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Properties";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// jPropertyValueUserControl1
			// 
			this.jPropertyValueUserControl1.AutoScroll = true;
			this.jPropertyValueUserControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.jPropertyValueUserControl1.ClassName = null;
			this.jPropertyValueUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.jPropertyValueUserControl1.Location = new System.Drawing.Point(3, 3);
			this.jPropertyValueUserControl1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.jPropertyValueUserControl1.Name = "jPropertyValueUserControl1";
			this.jPropertyValueUserControl1.ObjectCode = -1;
			this.jPropertyValueUserControl1.Size = new System.Drawing.Size(778, 614);
			this.jPropertyValueUserControl1.TabIndex = 1;
			this.jPropertyValueUserControl1.ValueObjectCode = 0;
			// 
			// txtSheetNo_old2
			// 
			this.txtSheetNo_old2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSheetNo_old2.ChangeColorIfNotEmpty = false;
			this.txtSheetNo_old2.ChangeColorOnEnter = true;
			this.txtSheetNo_old2.InBackColor = System.Drawing.SystemColors.Info;
			this.txtSheetNo_old2.InForeColor = System.Drawing.SystemColors.WindowText;
			this.txtSheetNo_old2.Location = new System.Drawing.Point(568, 199);
			this.txtSheetNo_old2.Name = "txtSheetNo_old2";
			this.txtSheetNo_old2.Negative = true;
			this.txtSheetNo_old2.NotEmpty = false;
			this.txtSheetNo_old2.NotEmptyColor = System.Drawing.Color.Red;
			this.txtSheetNo_old2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtSheetNo_old2.SelectOnEnter = true;
			this.txtSheetNo_old2.Size = new System.Drawing.Size(123, 20);
			this.txtSheetNo_old2.TabIndex = 16;
			this.txtSheetNo_old2.TabStop = false;
			this.txtSheetNo_old2.TextMode = ClassLibrary.TextModes.Integer;
			this.txtSheetNo_old2.Leave += new System.EventHandler(this.txtSheetNo_Leave);
			// 
			// BtnPrint
			// 
			this.BtnPrint.Location = new System.Drawing.Point(29, 77);
			this.BtnPrint.Name = "BtnPrint";
			this.BtnPrint.Size = new System.Drawing.Size(123, 38);
			this.BtnPrint.TabIndex = 22;
			this.BtnPrint.Text = "چاپ";
			this.BtnPrint.UseVisualStyleBackColor = true;
			this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
			// 
			// JPaymentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 687);
			this.Controls.Add(this.Properties);
			this.Controls.Add(this.panel1);
			this.Name = "JPaymentForm";
			this.Text = "Payment";
			this.Load += new System.EventHandler(this.JPaymentForm_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.Properties.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.jDataGridPayment)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.jDataGridSheets)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudEndSheetNo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudStartSheetNo)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl Properties;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox3;
        private ClassLibrary.JDataGrid jDataGridPayment;
        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.DateEdit dateEditPayDate;
        private ClassLibrary.TextEdit txtSheetNo_OLD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbSheetNo;
        private System.Windows.Forms.TabPage tabPage2;
        private ArchivedDocuments.JArchiveList jArchiveList1;
        private System.Windows.Forms.Label LBCaptionCourse;
		private ClassLibrary.JUCPerson jucPerson;
		private ClassLibrary.TextEdit txtSheetNo_old2;
		private System.Windows.Forms.NumericUpDown nudEndSheetNo;
		private System.Windows.Forms.NumericUpDown nudStartSheetNo;
		private ClassLibrary.JDataGrid jDataGridSheets;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtSoodDaryafti;
		private System.Windows.Forms.TextBox txtkolsood;
		private System.Windows.Forms.TabPage tabPage3;
		private Globals.Property.JPropertyValueUserControl jPropertyValueUserControl1;
		private System.Windows.Forms.Button BtnPrint;
        
    }
}