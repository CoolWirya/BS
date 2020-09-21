namespace ManagementShares.ShareCompany
{
	partial class SharePCodeChange
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
			this.jucPerson2 = new ClassLibrary.JUCPerson();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnAutoGet = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtNewSharepCode = new System.Windows.Forms.TextBox();
			this.txtOldSharepCode = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnApply = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// jucPerson2
			// 
			this.jucPerson2.CompanyCode = 1;
			this.jucPerson2.Dock = System.Windows.Forms.DockStyle.Top;
			this.jucPerson2.FilterPerson = null;
			this.jucPerson2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.jucPerson2.LableGroup = null;
			this.jucPerson2.Location = new System.Drawing.Point(0, 0);
			this.jucPerson2.Name = "jucPerson2";
			this.jucPerson2.PersonType = ClassLibrary.JPersonTypes.None;
			this.jucPerson2.ReadOnly = false;
			this.jucPerson2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.jucPerson2.SearchOnCode = ClassLibrary.SearchOnCode.SharePCode;
			this.jucPerson2.SelectedCode = 0;
			this.jucPerson2.ShareSelectedCode = ((long)(0));
			this.jucPerson2.Size = new System.Drawing.Size(583, 182);
			this.jucPerson2.TabIndex = 1;
			this.jucPerson2.TafsiliCode = false;
			this.jucPerson2.AfterCodeSelected += new ClassLibrary.JUCPerson.CodeSelected(this.jucPerson2_AfterCodeSelected);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnAutoGet);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.txtNewSharepCode);
			this.panel1.Controls.Add(this.txtOldSharepCode);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 182);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(583, 128);
			this.panel1.TabIndex = 2;
			// 
			// btnAutoGet
			// 
			this.btnAutoGet.Location = new System.Drawing.Point(228, 92);
			this.btnAutoGet.Name = "btnAutoGet";
			this.btnAutoGet.Size = new System.Drawing.Size(30, 23);
			this.btnAutoGet.TabIndex = 0;
			this.btnAutoGet.Text = "@";
			this.btnAutoGet.UseVisualStyleBackColor = true;
			this.btnAutoGet.Click += new System.EventHandler(this.btnAutoGet_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(439, 73);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(118, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "کد سهامداری جدید:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(439, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(116, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "کد سهامداری قدیم:";
			// 
			// txtNewSharepCode
			// 
			this.txtNewSharepCode.Location = new System.Drawing.Point(264, 92);
			this.txtNewSharepCode.Name = "txtNewSharepCode";
			this.txtNewSharepCode.Size = new System.Drawing.Size(288, 23);
			this.txtNewSharepCode.TabIndex = 0;
			// 
			// txtOldSharepCode
			// 
			this.txtOldSharepCode.Location = new System.Drawing.Point(264, 32);
			this.txtOldSharepCode.Name = "txtOldSharepCode";
			this.txtOldSharepCode.ReadOnly = true;
			this.txtOldSharepCode.Size = new System.Drawing.Size(288, 23);
			this.txtOldSharepCode.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnClose);
			this.panel2.Controls.Add(this.btnApply);
			this.panel2.Controls.Add(this.btnOK);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 310);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(583, 43);
			this.panel2.TabIndex = 3;
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(12, 8);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnApply
			// 
			this.btnApply.Location = new System.Drawing.Point(415, 8);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(75, 23);
			this.btnApply.TabIndex = 0;
			this.btnApply.Text = "Apply";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(496, 8);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// SharePCodeChange
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(583, 353);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.jucPerson2);
			this.Controls.Add(this.panel2);
			this.Name = "SharePCodeChange";
			this.Text = "SharePCodeChange";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private ClassLibrary.JUCPerson jucPerson2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtNewSharepCode;
		private System.Windows.Forms.TextBox txtOldSharepCode;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnAutoGet;

	}
}