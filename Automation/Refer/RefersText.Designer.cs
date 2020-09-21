namespace Automation
{
    partial class RefersText
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RefersText));
            ClassLibrary.JPopupMenu jPopupMenu1 = new ClassLibrary.JPopupMenu();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dgrRefers = new ClassLibrary.JDataGrid();
            this.ReferCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reciever = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgrRefers)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "arrow_left.png");
            this.imageList1.Images.SetKeyName(1, "clock.png");
            // 
            // dgrRefers
            // 
            this.dgrRefers.ActionMenu = jPopupMenu1;
            this.dgrRefers.AllowUserToAddRows = false;
            this.dgrRefers.AllowUserToDeleteRows = false;
            this.dgrRefers.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgrRefers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgrRefers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgrRefers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrRefers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReferCode,
            this.Sender,
            this.Reciever,
            this.Date,
            this.Time});
            this.dgrRefers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrRefers.EnableContexMenu = true;
            this.dgrRefers.KeyName = null;
            this.dgrRefers.Location = new System.Drawing.Point(0, 0);
            this.dgrRefers.Name = "dgrRefers";
            this.dgrRefers.ReadHeadersFromDB = false;
            this.dgrRefers.ReadOnly = true;
            this.dgrRefers.RegistryPath = "Software\\Sepad\\Automation\\GridSettings";
            this.dgrRefers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrRefers.ShowRowNumber = true;
            this.dgrRefers.Size = new System.Drawing.Size(338, 226);
            this.dgrRefers.TabIndex = 0;
            this.dgrRefers.TableName = null;
            this.dgrRefers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgrRefers_MouseDoubleClick);
            this.dgrRefers.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgrRefers_DataBindingComplete);
            this.dgrRefers.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgrRefers_KeyUp);
            // 
            // ReferCode
            // 
            this.ReferCode.DataPropertyName = "ReferCode";
            this.ReferCode.HeaderText = "کد";
            this.ReferCode.Name = "ReferCode";
            this.ReferCode.ReadOnly = true;
            this.ReferCode.Width = 44;
            // 
            // Sender
            // 
            this.Sender.DataPropertyName = "Sender";
            this.Sender.HeaderText = "فرستنده";
            this.Sender.Name = "Sender";
            this.Sender.ReadOnly = true;
            this.Sender.Width = 71;
            // 
            // Reciever
            // 
            this.Reciever.DataPropertyName = "Reciever";
            this.Reciever.HeaderText = "گیرنده";
            this.Reciever.Name = "Reciever";
            this.Reciever.ReadOnly = true;
            this.Reciever.Width = 63;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "تاریخ";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 57;
            // 
            // Time
            // 
            this.Time.DataPropertyName = "Time";
            this.Time.HeaderText = "زمان";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Width = 53;
            // 
            // RefersText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgrRefers);
            this.Name = "RefersText";
            this.Size = new System.Drawing.Size(338, 226);
            ((System.ComponentModel.ISupportInitialize)(this.dgrRefers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private ClassLibrary.JDataGrid dgrRefers;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReferCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reciever;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;


    }
}
