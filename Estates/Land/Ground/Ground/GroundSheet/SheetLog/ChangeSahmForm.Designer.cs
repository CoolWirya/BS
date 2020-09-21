namespace Estates
{
    partial class JChangeSahmForm
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
            ClassLibrary.JPopupMenu jPopupMenu1 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtM = new ClassLibrary.TextEdit(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalSahm = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.jDataGrid1 = new ClassLibrary.JDataGrid();
            this.btnDiv = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblS = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSB = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblMB = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblM = new ClassLibrary.TextEdit(this.components);
            this.btnConfirm = new System.Windows.Forms.Button();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.jDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtM
            // 
            this.txtM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtM.ChangeColorIfNotEmpty = true;
            this.txtM.ChangeColorOnEnter = true;
            this.txtM.InBackColor = System.Drawing.SystemColors.Info;
            this.txtM.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtM.Location = new System.Drawing.Point(134, 109);
            this.txtM.Name = "txtM";
            this.txtM.Negative = true;
            this.txtM.NotEmpty = false;
            this.txtM.NotEmptyColor = System.Drawing.Color.Red;
            this.txtM.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtM.SelectOnEnter = true;
            this.txtM.Size = new System.Drawing.Size(107, 23);
            this.txtM.TabIndex = 44;
            this.txtM.TextMode = ClassLibrary.TextModes.Real;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 16);
            this.label10.TabIndex = 45;
            this.label10.Text = "میزان متراژ جدید :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 46;
            this.label1.Text = "میزان سهم کل :";
            // 
            // lblTotalSahm
            // 
            this.lblTotalSahm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalSahm.AutoSize = true;
            this.lblTotalSahm.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTotalSahm.ForeColor = System.Drawing.Color.Red;
            this.lblTotalSahm.Location = new System.Drawing.Point(217, 14);
            this.lblTotalSahm.Name = "lblTotalSahm";
            this.lblTotalSahm.Size = new System.Drawing.Size(16, 16);
            this.lblTotalSahm.TabIndex = 47;
            this.lblTotalSahm.Text = "0";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 16);
            this.label3.TabIndex = 48;
            this.label3.Text = "میزان سهم باقیمانده :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(459, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 16);
            this.label2.TabIndex = 49;
            this.label2.Text = "0";
            // 
            // jDataGrid1
            // 
            this.jDataGrid1.ActionMenu = jPopupMenu1;
            this.jDataGrid1.AllowUserToAddRows = false;
            this.jDataGrid1.AllowUserToDeleteRows = false;
            this.jDataGrid1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.jDataGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.jDataGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.jDataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jDataGrid1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.jDataGrid1.EnableContexMenu = true;
            this.jDataGrid1.KeyName = null;
            this.jDataGrid1.Location = new System.Drawing.Point(0, 170);
            this.jDataGrid1.Name = "jDataGrid1";
            this.jDataGrid1.ReadHeadersFromDB = false;
            this.jDataGrid1.ReadOnly = true;
            this.jDataGrid1.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.jDataGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jDataGrid1.ShowRowNumber = true;
            this.jDataGrid1.Size = new System.Drawing.Size(583, 134);
            this.jDataGrid1.TabIndex = 50;
            this.jDataGrid1.TableName = null;
            // 
            // btnDiv
            // 
            this.btnDiv.Location = new System.Drawing.Point(389, 106);
            this.btnDiv.Name = "btnDiv";
            this.btnDiv.Size = new System.Drawing.Size(88, 26);
            this.btnDiv.TabIndex = 51;
            this.btnDiv.Text = "تقسیم";
            this.btnDiv.UseVisualStyleBackColor = true;
            this.btnDiv.Click += new System.EventHandler(this.btnDiv_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(81, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 52;
            this.label5.Text = "متراژ :";
            // 
            // lblS
            // 
            this.lblS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblS.AutoSize = true;
            this.lblS.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblS.ForeColor = System.Drawing.Color.Red;
            this.lblS.Location = new System.Drawing.Point(217, 78);
            this.lblS.Name = "lblS";
            this.lblS.Size = new System.Drawing.Size(16, 16);
            this.lblS.TabIndex = 55;
            this.lblS.Text = "0";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 16);
            this.label7.TabIndex = 54;
            this.label7.Text = "میزان سهم  :";
            // 
            // lblSB
            // 
            this.lblSB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSB.AutoSize = true;
            this.lblSB.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblSB.ForeColor = System.Drawing.Color.Red;
            this.lblSB.Location = new System.Drawing.Point(458, 78);
            this.lblSB.Name = "lblSB";
            this.lblSB.Size = new System.Drawing.Size(16, 16);
            this.lblSB.TabIndex = 59;
            this.lblSB.Text = "0";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(306, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 16);
            this.label9.TabIndex = 58;
            this.label9.Text = "میزان سهم  باقیمانده :";
            // 
            // lblMB
            // 
            this.lblMB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMB.AutoSize = true;
            this.lblMB.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblMB.ForeColor = System.Drawing.Color.Red;
            this.lblMB.Location = new System.Drawing.Point(458, 44);
            this.lblMB.Name = "lblMB";
            this.lblMB.Size = new System.Drawing.Size(16, 16);
            this.lblMB.TabIndex = 57;
            this.lblMB.Text = "0";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(347, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 16);
            this.label12.TabIndex = 56;
            this.label12.Text = "متراژ باقیمانده :";
            // 
            // lblM
            // 
            this.lblM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblM.ChangeColorIfNotEmpty = true;
            this.lblM.ChangeColorOnEnter = true;
            this.lblM.InBackColor = System.Drawing.SystemColors.Info;
            this.lblM.InForeColor = System.Drawing.SystemColors.WindowText;
            this.lblM.Location = new System.Drawing.Point(153, 41);
            this.lblM.Name = "lblM";
            this.lblM.Negative = true;
            this.lblM.NotEmpty = false;
            this.lblM.NotEmptyColor = System.Drawing.Color.Red;
            this.lblM.ReadOnly = true;
            this.lblM.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblM.SelectOnEnter = true;
            this.lblM.Size = new System.Drawing.Size(107, 23);
            this.lblM.TabIndex = 60;
            this.lblM.TextMode = ClassLibrary.TextModes.Real;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(483, 106);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(88, 26);
            this.btnConfirm.TabIndex = 61;
            this.btnConfirm.Text = "تایید";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(84, 141);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(432, 23);
            this.txtDesc.TabIndex = 63;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 62;
            this.label4.Text = "توضیحات :";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(295, 106);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(88, 26);
            this.btnDel.TabIndex = 64;
            this.btnDel.Text = "حذف";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // JChangeSahmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 304);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblM);
            this.Controls.Add(this.lblSB);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblMB);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblS);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnDiv);
            this.Controls.Add(this.jDataGrid1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTotalSahm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtM);
            this.Controls.Add(this.label10);
            this.Name = "JChangeSahmForm";
            this.Text = "ChangeSahmForm";
            this.Load += new System.EventHandler(this.JChangeSahmForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jDataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ClassLibrary.TextEdit txtM;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalSahm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.JDataGrid jDataGrid1;
        private System.Windows.Forms.Button btnDiv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblMB;
        private System.Windows.Forms.Label label12;
        private ClassLibrary.TextEdit lblM;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDel;
    }
}