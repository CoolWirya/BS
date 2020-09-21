namespace Automation
{
    partial class JExternalRefer
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
            this.dgRefer = new ClassLibrary.UC_Grid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckSent = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtReceiver = new ClassLibrary.TextEdit(this.components);
            this.button6 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgRefer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 364);
            this.panel1.TabIndex = 3;
            // 
            // dgRefer
            // 
            this.dgRefer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgRefer.Location = new System.Drawing.Point(0, 0);
            this.dgRefer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgRefer.MultiSelect = false;
            this.dgRefer.Name = "dgRefer";
            this.dgRefer.Size = new System.Drawing.Size(659, 364);
            this.dgRefer.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnConfirm);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 419);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(659, 52);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(536, 17);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckSent);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtReceiver);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(659, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // ckSent
            // 
            this.ckSent.AutoSize = true;
            this.ckSent.Location = new System.Drawing.Point(30, 18);
            this.ckSent.Name = "ckSent";
            this.ckSent.Size = new System.Drawing.Size(53, 20);
            this.ckSent.TabIndex = 46;
            this.ckSent.Text = "Sent";
            this.ckSent.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(99, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 45;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtReceiver
            // 
            this.txtReceiver.ChangeColorIfNotEmpty = true;
            this.txtReceiver.ChangeColorOnEnter = true;
            this.txtReceiver.InBackColor = System.Drawing.SystemColors.Info;
            this.txtReceiver.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtReceiver.Location = new System.Drawing.Point(180, 16);
            this.txtReceiver.Name = "txtReceiver";
            this.txtReceiver.Negative = true;
            this.txtReceiver.NotEmpty = false;
            this.txtReceiver.NotEmptyColor = System.Drawing.Color.Red;
            this.txtReceiver.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtReceiver.SelectOnEnter = true;
            this.txtReceiver.Size = new System.Drawing.Size(370, 23);
            this.txtReceiver.TabIndex = 44;
            this.txtReceiver.TextMode = ClassLibrary.TextModes.Text;
            this.txtReceiver.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReceiver_KeyDown);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(-65, 15);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(28, 23);
            this.button6.TabIndex = 43;
            this.button6.TabStop = false;
            this.button6.Text = "...";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(556, 19);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(97, 16);
            this.label18.TabIndex = 42;
            this.label18.Text = "Refer Receiver:";
            // 
            // JExternalRefer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 471);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "JExternalRefer";
            this.Text = "frmExternalRefer";
            this.Load += new System.EventHandler(this.JExternalRefer_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConfirm;
        private ClassLibrary.UC_Grid dgRefer;
        private ClassLibrary.TextEdit txtReceiver;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox ckSent;
    }
}