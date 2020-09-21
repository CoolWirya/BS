namespace Parking
{
    partial class CreateGroupCard
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
            this.TxtFirst = new ClassLibrary.TextEdit(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtLast = new ClassLibrary.TextEdit(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbGroupCard = new ClassLibrary.JComboBox(this.components);
            this.cmbComplex = new ClassLibrary.JComboBox(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtFirst
            // 
            this.TxtFirst.ChangeColorIfNotEmpty = false;
            this.TxtFirst.ChangeColorOnEnter = true;
            this.TxtFirst.InBackColor = System.Drawing.SystemColors.Info;
            this.TxtFirst.InForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtFirst.Location = new System.Drawing.Point(113, 21);
            this.TxtFirst.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtFirst.Name = "TxtFirst";
            this.TxtFirst.Negative = true;
            this.TxtFirst.NotEmpty = false;
            this.TxtFirst.NotEmptyColor = System.Drawing.Color.Red;
            this.TxtFirst.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtFirst.SelectOnEnter = true;
            this.TxtFirst.Size = new System.Drawing.Size(116, 23);
            this.TxtFirst.TabIndex = 0;
            this.TxtFirst.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "از شماره كارت :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(272, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "تا شماره كارت :";
            // 
            // TxtLast
            // 
            this.TxtLast.ChangeColorIfNotEmpty = false;
            this.TxtLast.ChangeColorOnEnter = true;
            this.TxtLast.InBackColor = System.Drawing.SystemColors.Info;
            this.TxtLast.InForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtLast.Location = new System.Drawing.Point(373, 21);
            this.TxtLast.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtLast.Name = "TxtLast";
            this.TxtLast.Negative = true;
            this.TxtLast.NotEmpty = false;
            this.TxtLast.NotEmptyColor = System.Drawing.Color.Red;
            this.TxtLast.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TxtLast.SelectOnEnter = true;
            this.TxtLast.Size = new System.Drawing.Size(127, 23);
            this.TxtLast.TabIndex = 2;
            this.TxtLast.TextMode = ClassLibrary.TextModes.Integer;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(211, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 29);
            this.button1.TabIndex = 4;
            this.button1.Text = "تاييد";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "گروه كارت :";
            // 
            // cmbGroupCard
            // 
            this.cmbGroupCard.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbGroupCard.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbGroupCard.BaseCode = 0;
            this.cmbGroupCard.ChangeColorIfNotEmpty = true;
            this.cmbGroupCard.ChangeColorOnEnter = true;
            this.cmbGroupCard.FormattingEnabled = true;
            this.cmbGroupCard.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbGroupCard.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbGroupCard.Location = new System.Drawing.Point(373, 64);
            this.cmbGroupCard.Name = "cmbGroupCard";
            this.cmbGroupCard.NotEmpty = false;
            this.cmbGroupCard.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbGroupCard.SelectOnEnter = true;
            this.cmbGroupCard.Size = new System.Drawing.Size(121, 24);
            this.cmbGroupCard.TabIndex = 6;
            // 
            // cmbComplex
            // 
            this.cmbComplex.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbComplex.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbComplex.BaseCode = 0;
            this.cmbComplex.ChangeColorIfNotEmpty = true;
            this.cmbComplex.ChangeColorOnEnter = true;
            this.cmbComplex.FormattingEnabled = true;
            this.cmbComplex.InBackColor = System.Drawing.SystemColors.Info;
            this.cmbComplex.InForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbComplex.Location = new System.Drawing.Point(98, 64);
            this.cmbComplex.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbComplex.Name = "cmbComplex";
            this.cmbComplex.NotEmpty = false;
            this.cmbComplex.NotEmptyColor = System.Drawing.Color.Red;
            this.cmbComplex.SelectOnEnter = true;
            this.cmbComplex.Size = new System.Drawing.Size(131, 24);
            this.cmbComplex.TabIndex = 80;
            this.cmbComplex.SelectedIndexChanged += new System.EventHandler(this.cmbComplex_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 68);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 16);
            this.label17.TabIndex = 79;
            this.label17.Text = "مجتمع/بازار :";
            // 
            // CreateGroupCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 153);
            this.Controls.Add(this.cmbComplex);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cmbGroupCard);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtLast);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtFirst);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CreateGroupCard";
            this.Text = "CreateGroupCard";
            this.Load += new System.EventHandler(this.CreateGroupCard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ClassLibrary.TextEdit TxtFirst;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ClassLibrary.TextEdit TxtLast;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private ClassLibrary.JComboBox cmbGroupCard;
        private ClassLibrary.JComboBox cmbComplex;
        private System.Windows.Forms.Label label17;
    }
}