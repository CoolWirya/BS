namespace Bascol
{
    partial class JReportUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JReportUserForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrice = new ClassLibrary.TextEdit(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblTotal1 = new System.Windows.Forms.Label();
            this.lblCount1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkBedehi = new System.Windows.Forms.CheckBox();
            this.txtplok2 = new System.Windows.Forms.MaskedTextBox();
            this.chkAllUser = new System.Windows.Forms.CheckBox();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.btnPrint2 = new System.Windows.Forms.Button();
            this.lblBestankari = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblBedehkari = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEndDate = new ClassLibrary.DateEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDate = new ClassLibrary.DateEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chklistTozin = new System.Windows.Forms.CheckedListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chklistTrucks = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkListBascol = new System.Windows.Forms.CheckedListBox();
            this.jJanusGrid1 = new ClassLibrary.JJanusGrid();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.jJanusGridBedehi = new ClassLibrary.JJanusGrid();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtPrice);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.lblCount);
            this.groupBox1.Controls.Add(this.lblTotal1);
            this.groupBox1.Controls.Add(this.lblCount1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chkBedehi);
            this.groupBox1.Controls.Add(this.txtplok2);
            this.groupBox1.Controls.Add(this.chkAllUser);
            this.groupBox1.Controls.Add(this.chkDate);
            this.groupBox1.Controls.Add(this.btnPrint2);
            this.groupBox1.Controls.Add(this.lblBestankari);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.lblBedehkari);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtEndDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.label2);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // btnUpdate
            // 
            resources.ApplyResources(this.btnUpdate, "btnUpdate");
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // txtPrice
            // 
            resources.ApplyResources(this.txtPrice, "txtPrice");
            this.txtPrice.ChangeColorIfNotEmpty = false;
            this.txtPrice.ChangeColorOnEnter = true;
            this.txtPrice.InBackColor = System.Drawing.SystemColors.Info;
            this.txtPrice.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Negative = true;
            this.txtPrice.NotEmpty = false;
            this.txtPrice.NotEmptyColor = System.Drawing.Color.Red;
            this.txtPrice.SelectOnEnter = true;
            this.txtPrice.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Name = "label6";
            // 
            // lblTotal
            // 
            resources.ApplyResources(this.lblTotal, "lblTotal");
            this.lblTotal.ForeColor = System.Drawing.Color.Red;
            this.lblTotal.Name = "lblTotal";
            // 
            // lblCount
            // 
            resources.ApplyResources(this.lblCount, "lblCount");
            this.lblCount.ForeColor = System.Drawing.Color.Red;
            this.lblCount.Name = "lblCount";
            // 
            // lblTotal1
            // 
            resources.ApplyResources(this.lblTotal1, "lblTotal1");
            this.lblTotal1.Name = "lblTotal1";
            // 
            // lblCount1
            // 
            resources.ApplyResources(this.lblCount1, "lblCount1");
            this.lblCount1.Name = "lblCount1";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // chkBedehi
            // 
            resources.ApplyResources(this.chkBedehi, "chkBedehi");
            this.chkBedehi.Name = "chkBedehi";
            this.chkBedehi.UseVisualStyleBackColor = true;
            this.chkBedehi.CheckedChanged += new System.EventHandler(this.chkBedehi_CheckedChanged);
            // 
            // txtplok2
            // 
            resources.ApplyResources(this.txtplok2, "txtplok2");
            this.txtplok2.Name = "txtplok2";
            // 
            // chkAllUser
            // 
            resources.ApplyResources(this.chkAllUser, "chkAllUser");
            this.chkAllUser.Name = "chkAllUser";
            this.chkAllUser.UseVisualStyleBackColor = true;
            // 
            // chkDate
            // 
            resources.ApplyResources(this.chkDate, "chkDate");
            this.chkDate.Name = "chkDate";
            this.chkDate.UseVisualStyleBackColor = true;
            this.chkDate.CheckedChanged += new System.EventHandler(this.chkDate_CheckedChanged);
            // 
            // btnPrint2
            // 
            resources.ApplyResources(this.btnPrint2, "btnPrint2");
            this.btnPrint2.Name = "btnPrint2";
            this.btnPrint2.UseVisualStyleBackColor = true;
            this.btnPrint2.Click += new System.EventHandler(this.btnPrint2_Click);
            // 
            // lblBestankari
            // 
            resources.ApplyResources(this.lblBestankari, "lblBestankari");
            this.lblBestankari.ForeColor = System.Drawing.Color.Red;
            this.lblBestankari.Name = "lblBestankari";
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblBedehkari
            // 
            resources.ApplyResources(this.lblBedehkari, "lblBedehkari");
            this.lblBedehkari.ForeColor = System.Drawing.Color.Red;
            this.lblBedehkari.Name = "lblBedehkari";
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtEndDate
            // 
            resources.ApplyResources(this.txtEndDate, "txtEndDate");
            this.txtEndDate.ChangeColorIfNotEmpty = true;
            this.txtEndDate.ChangeColorOnEnter = true;
            this.txtEndDate.Date = new System.DateTime(((long)(0)));
            this.txtEndDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtEndDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEndDate.InsertInDatesTable = true;
            this.txtEndDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.NotEmpty = false;
            this.txtEndDate.NotEmptyColor = System.Drawing.Color.Red;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtDate
            // 
            resources.ApplyResources(this.txtDate, "txtDate");
            this.txtDate.ChangeColorIfNotEmpty = true;
            this.txtDate.ChangeColorOnEnter = true;
            this.txtDate.Date = new System.DateTime(((long)(0)));
            this.txtDate.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDate.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDate.InsertInDatesTable = true;
            this.txtDate.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.txtDate.Name = "txtDate";
            this.txtDate.NotEmpty = false;
            this.txtDate.NotEmptyColor = System.Drawing.Color.Red;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chklistTozin);
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // chklistTozin
            // 
            resources.ApplyResources(this.chklistTozin, "chklistTozin");
            this.chklistTozin.FormattingEnabled = true;
            this.chklistTozin.Name = "chklistTozin";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chklistTrucks);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // chklistTrucks
            // 
            resources.ApplyResources(this.chklistTrucks, "chklistTrucks");
            this.chklistTrucks.FormattingEnabled = true;
            this.chklistTrucks.Name = "chklistTrucks";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkListBascol);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // chkListBascol
            // 
            resources.ApplyResources(this.chkListBascol, "chkListBascol");
            this.chkListBascol.FormattingEnabled = true;
            this.chkListBascol.Name = "chkListBascol";
            // 
            // jJanusGrid1
            // 
            this.jJanusGrid1.ActionClassName = "";
            this.jJanusGrid1.ActionMenu = null;
            this.jJanusGrid1.DataSource = null;
            resources.ApplyResources(this.jJanusGrid1, "jJanusGrid1");
            this.jJanusGrid1.Edited = false;
            this.jJanusGrid1.MultiSelect = false;
            this.jJanusGrid1.Name = "jJanusGrid1";
            this.jJanusGrid1.ShowNavigator = true;
            this.jJanusGrid1.ShowToolbar = true;
            this.jJanusGrid1.SelectionChanged += new System.EventHandler(this.jJanusGrid1_SelectionChanged);
            this.jJanusGrid1.OnRowDBClick += new ClassLibrary.JJanusGrid.RowDBClick(this.jJanusGrid1_OnRowDBClick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox4);
            this.groupBox5.Controls.Add(this.groupBox3);
            this.groupBox5.Controls.Add(this.groupBox6);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // jJanusGridBedehi
            // 
            this.jJanusGridBedehi.ActionClassName = "";
            this.jJanusGridBedehi.ActionMenu = null;
            this.jJanusGridBedehi.DataSource = null;
            resources.ApplyResources(this.jJanusGridBedehi, "jJanusGridBedehi");
            this.jJanusGridBedehi.Edited = false;
            this.jJanusGridBedehi.MultiSelect = true;
            this.jJanusGridBedehi.Name = "jJanusGridBedehi";
            this.jJanusGridBedehi.ShowNavigator = true;
            this.jJanusGridBedehi.ShowToolbar = true;
            // 
            // JReportUserForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.jJanusGridBedehi);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.jJanusGrid1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "JReportUserForm";
            this.Load += new System.EventHandler(this.JReportUserForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.JJanusGrid jJanusGrid1;
        private ClassLibrary.DateEdit txtEndDate;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.DateEdit txtDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtplok2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckedListBox chklistTozin;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckedListBox chklistTrucks;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox chkListBascol;
        private System.Windows.Forms.Button btnPrint2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblBestankari;
        private System.Windows.Forms.Label lblBedehkari;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkBedehi;
        private System.Windows.Forms.CheckBox chkAllUser;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblTotal1;
        private System.Windows.Forms.Label lblCount1;
        private ClassLibrary.JJanusGrid jJanusGridBedehi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label7;
        private ClassLibrary.TextEdit txtPrice;
    }
}