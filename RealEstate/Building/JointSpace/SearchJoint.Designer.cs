namespace RealEstate
{
    partial class JSearchJoint
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
            this.jDataGrid1 = new ClassLibrary.JDataGrid();
            this.btnSelect = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCodeEnviroment = new ClassLibrary.NumEdit();
            this.txtComplex = new ClassLibrary.TextEdit(this.components);
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtTypeEnviroment = new ClassLibrary.TextEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtAdress = new ClassLibrary.TextEdit(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtNameEnviroment = new ClassLibrary.TextEdit(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.txtTypeSpace = new ClassLibrary.TextEdit(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtState = new ClassLibrary.TextEdit(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.jDataGrid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // jDataGrid1
            // 
            this.jDataGrid1.AllowUserToAddRows = false;
            this.jDataGrid1.AllowUserToDeleteRows = false;
            this.jDataGrid1.AllowUserToOrderColumns = true;
            this.jDataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jDataGrid1.EnableContexMenu = true;
            this.jDataGrid1.KeyName = null;
            this.jDataGrid1.Location = new System.Drawing.Point(6, 185);
            this.jDataGrid1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jDataGrid1.MultiSelect = false;
            this.jDataGrid1.Name = "jDataGrid1";
            this.jDataGrid1.ReadHeadersFromDB = false;
            this.jDataGrid1.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jDataGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jDataGrid1.ShowRowNumber = true;
            this.jDataGrid1.Size = new System.Drawing.Size(883, 320);
            this.jDataGrid1.TabIndex = 0;
            this.jDataGrid1.TableName = null;
            this.jDataGrid1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.jDataGrid1_MouseClick);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(6, 512);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(114, 46);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "انتخاب";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(765, 512);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 46);
            this.button2.TabIndex = 2;
            this.button2.Text = "خروج";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtState);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTypeSpace);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNameEnviroment);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAdress);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTypeEnviroment);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCodeEnviroment);
            this.groupBox1.Controls.Add(this.txtComplex);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(889, 177);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "جستجو";
            // 
            // txtCodeEnviroment
            // 
            this.txtCodeEnviroment.ChangeColorIfNotEmpty = false;
            this.txtCodeEnviroment.ChangeColorOnEnter = true;
            this.txtCodeEnviroment.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCodeEnviroment.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCodeEnviroment.Location = new System.Drawing.Point(582, 21);
            this.txtCodeEnviroment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCodeEnviroment.Name = "txtCodeEnviroment";
            this.txtCodeEnviroment.Negative = true;
            this.txtCodeEnviroment.NotEmpty = false;
            this.txtCodeEnviroment.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCodeEnviroment.NumType = ClassLibrary.NumEdit.NumTypes.Integer;
            this.txtCodeEnviroment.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCodeEnviroment.SelectOnEnter = true;
            this.txtCodeEnviroment.Size = new System.Drawing.Size(172, 23);
            this.txtCodeEnviroment.TabIndex = 0;
            this.txtCodeEnviroment.TextMode = ClassLibrary.TextModes.Text;
            this.txtCodeEnviroment.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numSpace_KeyUp);
            // 
            // txtComplex
            // 
            this.txtComplex.ChangeColorIfNotEmpty = false;
            this.txtComplex.ChangeColorOnEnter = true;
            this.txtComplex.InBackColor = System.Drawing.SystemColors.Info;
            this.txtComplex.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtComplex.Location = new System.Drawing.Point(582, 99);
            this.txtComplex.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtComplex.Name = "txtComplex";
            this.txtComplex.Negative = true;
            this.txtComplex.NotEmpty = false;
            this.txtComplex.NotEmptyColor = System.Drawing.Color.Red;
            this.txtComplex.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtComplex.SelectOnEnter = true;
            this.txtComplex.Size = new System.Drawing.Size(172, 23);
            this.txtComplex.TabIndex = 4;
            this.txtComplex.TextMode = ClassLibrary.TextModes.Text;
            this.txtComplex.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtSpaceType_KeyUp);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(791, 102);
            this.label20.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(54, 16);
            this.label20.TabIndex = 57;
            this.label20.Text = "مجتمع :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(758, 24);
            this.label19.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(87, 16);
            this.label19.TabIndex = 56;
            this.label19.Text = "شماره محيط :";
            // 
            // txtTypeEnviroment
            // 
            this.txtTypeEnviroment.ChangeColorIfNotEmpty = false;
            this.txtTypeEnviroment.ChangeColorOnEnter = true;
            this.txtTypeEnviroment.InBackColor = System.Drawing.SystemColors.Info;
            this.txtTypeEnviroment.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTypeEnviroment.Location = new System.Drawing.Point(162, 61);
            this.txtTypeEnviroment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTypeEnviroment.Name = "txtTypeEnviroment";
            this.txtTypeEnviroment.Negative = true;
            this.txtTypeEnviroment.NotEmpty = false;
            this.txtTypeEnviroment.NotEmptyColor = System.Drawing.Color.Red;
            this.txtTypeEnviroment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTypeEnviroment.SelectOnEnter = true;
            this.txtTypeEnviroment.Size = new System.Drawing.Size(172, 23);
            this.txtTypeEnviroment.TabIndex = 3;
            this.txtTypeEnviroment.TextMode = ClassLibrary.TextModes.Text;
            this.txtTypeEnviroment.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTypeEnviroment_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(334, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 62;
            this.label1.Text = "عنوان محيط :";
            // 
            // txtAdress
            // 
            this.txtAdress.ChangeColorIfNotEmpty = false;
            this.txtAdress.ChangeColorOnEnter = true;
            this.txtAdress.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAdress.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAdress.Location = new System.Drawing.Point(162, 102);
            this.txtAdress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAdress.Name = "txtAdress";
            this.txtAdress.Negative = true;
            this.txtAdress.NotEmpty = false;
            this.txtAdress.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAdress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAdress.SelectOnEnter = true;
            this.txtAdress.Size = new System.Drawing.Size(172, 23);
            this.txtAdress.TabIndex = 5;
            this.txtAdress.TextMode = ClassLibrary.TextModes.Text;
            this.txtAdress.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAdress_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(369, 105);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 64;
            this.label2.Text = "آدرس :";
            // 
            // txtNameEnviroment
            // 
            this.txtNameEnviroment.ChangeColorIfNotEmpty = false;
            this.txtNameEnviroment.ChangeColorOnEnter = true;
            this.txtNameEnviroment.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNameEnviroment.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNameEnviroment.Location = new System.Drawing.Point(162, 24);
            this.txtNameEnviroment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNameEnviroment.Name = "txtNameEnviroment";
            this.txtNameEnviroment.Negative = true;
            this.txtNameEnviroment.NotEmpty = false;
            this.txtNameEnviroment.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNameEnviroment.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNameEnviroment.SelectOnEnter = true;
            this.txtNameEnviroment.Size = new System.Drawing.Size(172, 23);
            this.txtNameEnviroment.TabIndex = 1;
            this.txtNameEnviroment.TextMode = ClassLibrary.TextModes.Text;
            this.txtNameEnviroment.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNameEnviroment_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(349, 27);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 66;
            this.label3.Text = "نام محيط :";
            // 
            // txtTypeSpace
            // 
            this.txtTypeSpace.ChangeColorIfNotEmpty = false;
            this.txtTypeSpace.ChangeColorOnEnter = true;
            this.txtTypeSpace.InBackColor = System.Drawing.SystemColors.Info;
            this.txtTypeSpace.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTypeSpace.Location = new System.Drawing.Point(582, 60);
            this.txtTypeSpace.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTypeSpace.Name = "txtTypeSpace";
            this.txtTypeSpace.Negative = true;
            this.txtTypeSpace.NotEmpty = false;
            this.txtTypeSpace.NotEmptyColor = System.Drawing.Color.Red;
            this.txtTypeSpace.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTypeSpace.SelectOnEnter = true;
            this.txtTypeSpace.Size = new System.Drawing.Size(172, 23);
            this.txtTypeSpace.TabIndex = 2;
            this.txtTypeSpace.TextMode = ClassLibrary.TextModes.Text;
            this.txtTypeSpace.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTypeSpace_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(787, 61);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 68;
            this.label4.Text = "نوع فضا :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(791, 142);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 70;
            this.label5.Text = "وضعيت :";
            // 
            // txtState
            // 
            this.txtState.ChangeColorIfNotEmpty = false;
            this.txtState.ChangeColorOnEnter = true;
            this.txtState.InBackColor = System.Drawing.SystemColors.Info;
            this.txtState.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtState.Location = new System.Drawing.Point(582, 139);
            this.txtState.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtState.Name = "txtState";
            this.txtState.Negative = true;
            this.txtState.NotEmpty = false;
            this.txtState.NotEmptyColor = System.Drawing.Color.Red;
            this.txtState.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtState.SelectOnEnter = true;
            this.txtState.Size = new System.Drawing.Size(172, 23);
            this.txtState.TabIndex = 6;
            this.txtState.TextMode = ClassLibrary.TextModes.Text;
            this.txtState.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtState_KeyUp);
            // 
            // JSearchJoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 562);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.jDataGrid1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JSearchJoint";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جستجو فضا";
            this.Load += new System.EventHandler(this.JSearchJoint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jDataGrid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ClassLibrary.JDataGrid jDataGrid1;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private ClassLibrary.TextEdit txtComplex;
        private System.Windows.Forms.Label label20;
        private ClassLibrary.NumEdit txtCodeEnviroment;
        private System.Windows.Forms.Label label19;
        private ClassLibrary.TextEdit txtNameEnviroment;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.TextEdit txtAdress;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.TextEdit txtTypeEnviroment;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit txtState;
        private System.Windows.Forms.Label label5;
        private ClassLibrary.TextEdit txtTypeSpace;
        private System.Windows.Forms.Label label4;

    }
}