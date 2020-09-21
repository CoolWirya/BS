namespace RealEstate
{
    partial class AmalkardFrm
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
            this.grdwar = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnNewWarning = new System.Windows.Forms.Button();
            this.grdwarning = new ClassLibrary.JJanusGrid();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnNewWritable = new System.Windows.Forms.Button();
            this.grdTahod = new ClassLibrary.JJanusGrid();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnServices = new System.Windows.Forms.Button();
            this.grdSer = new ClassLibrary.JJanusGrid();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.grdwar.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdwar
            // 
            this.grdwar.Controls.Add(this.tabPage1);
            this.grdwar.Controls.Add(this.tabPage2);
            this.grdwar.Controls.Add(this.tabPage3);
            this.grdwar.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdwar.Location = new System.Drawing.Point(0, 0);
            this.grdwar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdwar.Name = "grdwar";
            this.grdwar.RightToLeftLayout = true;
            this.grdwar.SelectedIndex = 0;
            this.grdwar.Size = new System.Drawing.Size(787, 501);
            this.grdwar.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(779, 472);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "اخطاريه ها";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnNewWarning);
            this.groupBox3.Controls.Add(this.grdwarning);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(773, 464);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "اخطاريه ها";
            // 
            // BtnNewWarning
            // 
            this.BtnNewWarning.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnNewWarning.Location = new System.Drawing.Point(3, 428);
            this.BtnNewWarning.Name = "BtnNewWarning";
            this.BtnNewWarning.Size = new System.Drawing.Size(767, 33);
            this.BtnNewWarning.TabIndex = 5;
            this.BtnNewWarning.Text = "جديد";
            this.BtnNewWarning.UseVisualStyleBackColor = true;
            this.BtnNewWarning.Click += new System.EventHandler(this.BtnNewWarning_Click);
            // 
            // grdwarning
            // 
            this.grdwarning.ActionMenu = null;
            this.grdwarning.DataSource = null;
            this.grdwarning.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdwarning.Location = new System.Drawing.Point(3, 19);
            this.grdwarning.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdwarning.MultiSelect = false;
            this.grdwarning.Name = "grdwarning";
            this.grdwarning.ShowNavigator = true;
            this.grdwarning.ShowToolbar = false;
            this.grdwarning.Size = new System.Drawing.Size(767, 411);
            this.grdwarning.TabIndex = 1;
            this.grdwarning.OnRowDBClick += new ClassLibrary.JJanusGrid.RowDBClick(this.grdwarning_OnRowDBClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(779, 472);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "تعهدات كتبي";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnNewWritable);
            this.groupBox2.Controls.Add(this.grdTahod);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(773, 464);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "تعهدات كتبي";
            // 
            // BtnNewWritable
            // 
            this.BtnNewWritable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnNewWritable.Location = new System.Drawing.Point(3, 428);
            this.BtnNewWritable.Name = "BtnNewWritable";
            this.BtnNewWritable.Size = new System.Drawing.Size(767, 33);
            this.BtnNewWritable.TabIndex = 4;
            this.BtnNewWritable.Text = "جديد";
            this.BtnNewWritable.UseVisualStyleBackColor = true;
            this.BtnNewWritable.Click += new System.EventHandler(this.BtnNewWritable_Click);
            // 
            // grdTahod
            // 
            this.grdTahod.ActionMenu = null;
            this.grdTahod.DataSource = null;
            this.grdTahod.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdTahod.Location = new System.Drawing.Point(3, 19);
            this.grdTahod.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdTahod.MultiSelect = false;
            this.grdTahod.Name = "grdTahod";
            this.grdTahod.ShowNavigator = true;
            this.grdTahod.ShowToolbar = false;
            this.grdTahod.Size = new System.Drawing.Size(767, 409);
            this.grdTahod.TabIndex = 1;
            this.grdTahod.OnRowDBClick += new ClassLibrary.JJanusGrid.RowDBClick(this.grdTahod_OnRowDBClick);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(779, 472);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "خدمات";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnServices);
            this.groupBox1.Controls.Add(this.grdSer);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(779, 472);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "خدمات";
            // 
            // btnServices
            // 
            this.btnServices.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnServices.Location = new System.Drawing.Point(3, 436);
            this.btnServices.Name = "btnServices";
            this.btnServices.Size = new System.Drawing.Size(773, 33);
            this.btnServices.TabIndex = 3;
            this.btnServices.Text = "جديد";
            this.btnServices.UseVisualStyleBackColor = true;
            this.btnServices.Click += new System.EventHandler(this.btnServices_Click);
            // 
            // grdSer
            // 
            this.grdSer.ActionMenu = null;
            this.grdSer.DataSource = null;
            this.grdSer.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdSer.Location = new System.Drawing.Point(3, 19);
            this.grdSer.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.grdSer.MultiSelect = false;
            this.grdSer.Name = "grdSer";
            this.grdSer.ShowNavigator = true;
            this.grdSer.ShowToolbar = false;
            this.grdSer.Size = new System.Drawing.Size(773, 418);
            this.grdSer.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.checkBox1.Location = new System.Drawing.Point(524, 501);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(263, 38);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "سوابق واحد را براي كل قراردادها نمايش بده";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Location = new System.Drawing.Point(0, 501);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "دوباره سازي";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AmalkardFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 539);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.grdwar);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AmalkardFrm";
            this.Text = "عملكرد واحد";
            this.Load += new System.EventHandler(this.AmalkardFrm_Load);
            this.grdwar.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl grdwar;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private ClassLibrary.JJanusGrid grdwarning;
        private ClassLibrary.JJanusGrid grdTahod;
        private ClassLibrary.JJanusGrid grdSer;
        private System.Windows.Forms.Button btnServices;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnNewWarning;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnNewWritable;
    }
}