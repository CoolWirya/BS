namespace Parking
{
    partial class JTrafficForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.BtnRefresh = new System.Windows.Forms.Button();
            this.BtnEndShift = new System.Windows.Forms.Button();
            this.BtnShift = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnManualAdd = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.txtNumber = new ClassLibrary.TextEdit(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIDCardParking = new ClassLibrary.TextEdit(this.components);
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.TyperCard = new ClassLibrary.TextEdit(this.components);
            this.txtCard = new ClassLibrary.TextEdit(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAmount = new ClassLibrary.TextEdit(this.components);
            this.txtDuration = new ClassLibrary.TextEdit(this.components);
            this.txtTimeOut = new ClassLibrary.TextEdit(this.components);
            this.txtDateOut = new ClassLibrary.TextEdit(this.components);
            this.txtTimeIn = new ClassLibrary.TextEdit(this.components);
            this.txtDateIn = new ClassLibrary.TextEdit(this.components);
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pctcpClient = new ClassLibrary.BSPTCPClient();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.BtnRefresh);
            this.panel1.Controls.Add(this.BtnEndShift);
            this.panel1.Controls.Add(this.BtnShift);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 44);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button1.Location = new System.Drawing.Point(636, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 44);
            this.button1.TabIndex = 3;
            this.button1.Text = "دوباره سازي صفحه";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnRefresh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.BtnRefresh.Location = new System.Drawing.Point(727, 0);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(91, 44);
            this.BtnRefresh.TabIndex = 2;
            this.BtnRefresh.Text = "تست ارتباط";
            this.BtnRefresh.UseVisualStyleBackColor = true;
            // 
            // BtnEndShift
            // 
            this.BtnEndShift.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnEndShift.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.BtnEndShift.Location = new System.Drawing.Point(818, 0);
            this.BtnEndShift.Name = "BtnEndShift";
            this.BtnEndShift.Size = new System.Drawing.Size(91, 44);
            this.BtnEndShift.TabIndex = 1;
            this.BtnEndShift.Text = "بستن شيفت";
            this.BtnEndShift.UseVisualStyleBackColor = true;
            // 
            // BtnShift
            // 
            this.BtnShift.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnShift.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.BtnShift.Location = new System.Drawing.Point(909, 0);
            this.BtnShift.Name = "BtnShift";
            this.BtnShift.Size = new System.Drawing.Size(95, 44);
            this.BtnShift.TabIndex = 0;
            this.BtnShift.Text = "شروع شيفت";
            this.BtnShift.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnManualAdd);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.txtNumber);
            this.groupBox4.Controls.Add(this.btnAdd);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txtIDCardParking);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 44);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1004, 53);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ورود اطلاعات";
            // 
            // btnManualAdd
            // 
            this.btnManualAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnManualAdd.Location = new System.Drawing.Point(149, 16);
            this.btnManualAdd.Name = "btnManualAdd";
            this.btnManualAdd.Size = new System.Drawing.Size(102, 30);
            this.btnManualAdd.TabIndex = 8;
            this.btnManualAdd.Text = "ثبت دستی";
            this.btnManualAdd.UseVisualStyleBackColor = true;
            this.btnManualAdd.Click += new System.EventHandler(this.btnManualAdd_Click);
            // 
            // label28
            // 
            this.label28.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(499, 20);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(118, 16);
            this.label28.TabIndex = 7;
            this.label28.Text = "شماره واحد تجاری :";
            // 
            // txtNumber
            // 
            this.txtNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNumber.ChangeColorIfNotEmpty = false;
            this.txtNumber.ChangeColorOnEnter = true;
            this.txtNumber.InBackColor = System.Drawing.SystemColors.Info;
            this.txtNumber.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNumber.Location = new System.Drawing.Point(365, 17);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Negative = true;
            this.txtNumber.NotEmpty = false;
            this.txtNumber.NotEmptyColor = System.Drawing.Color.Red;
            this.txtNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNumber.SelectOnEnter = true;
            this.txtNumber.Size = new System.Drawing.Size(128, 23);
            this.txtNumber.TabIndex = 6;
            this.txtNumber.TextMode = ClassLibrary.TextModes.Text;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.Location = new System.Drawing.Point(12, 15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(131, 33);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "ثبت اطلاعات - F2";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(847, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "شماره کارت پارکینگ :";
            // 
            // txtIDCardParking
            // 
            this.txtIDCardParking.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIDCardParking.ChangeColorIfNotEmpty = false;
            this.txtIDCardParking.ChangeColorOnEnter = true;
            this.txtIDCardParking.InBackColor = System.Drawing.SystemColors.Info;
            this.txtIDCardParking.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtIDCardParking.Location = new System.Drawing.Point(713, 20);
            this.txtIDCardParking.Name = "txtIDCardParking";
            this.txtIDCardParking.Negative = true;
            this.txtIDCardParking.NotEmpty = false;
            this.txtIDCardParking.NotEmptyColor = System.Drawing.Color.Red;
            this.txtIDCardParking.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtIDCardParking.SelectOnEnter = true;
            this.txtIDCardParking.Size = new System.Drawing.Size(128, 23);
            this.txtIDCardParking.TabIndex = 3;
            this.txtIDCardParking.TextMode = ClassLibrary.TextModes.Text;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.TyperCard);
            this.groupBox6.Controls.Add(this.txtCard);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.txtAmount);
            this.groupBox6.Controls.Add(this.txtDuration);
            this.groupBox6.Controls.Add(this.txtTimeOut);
            this.groupBox6.Controls.Add(this.txtDateOut);
            this.groupBox6.Controls.Add(this.txtTimeIn);
            this.groupBox6.Controls.Add(this.txtDateIn);
            this.groupBox6.Controls.Add(this.label34);
            this.groupBox6.Controls.Add(this.label33);
            this.groupBox6.Controls.Add(this.label32);
            this.groupBox6.Controls.Add(this.label31);
            this.groupBox6.Controls.Add(this.label30);
            this.groupBox6.Controls.Add(this.label29);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(0, 97);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1004, 105);
            this.groupBox6.TabIndex = 12;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "اطلاعات ورود و خروج";
            // 
            // TyperCard
            // 
            this.TyperCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TyperCard.ChangeColorIfNotEmpty = false;
            this.TyperCard.ChangeColorOnEnter = true;
            this.TyperCard.InBackColor = System.Drawing.SystemColors.Info;
            this.TyperCard.InForeColor = System.Drawing.SystemColors.WindowText;
            this.TyperCard.Location = new System.Drawing.Point(725, 67);
            this.TyperCard.Name = "TyperCard";
            this.TyperCard.Negative = true;
            this.TyperCard.NotEmpty = false;
            this.TyperCard.NotEmptyColor = System.Drawing.Color.Red;
            this.TyperCard.ReadOnly = true;
            this.TyperCard.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TyperCard.SelectOnEnter = true;
            this.TyperCard.Size = new System.Drawing.Size(182, 23);
            this.TyperCard.TabIndex = 149;
            this.TyperCard.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TyperCard.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtCard
            // 
            this.txtCard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCard.ChangeColorIfNotEmpty = false;
            this.txtCard.ChangeColorOnEnter = true;
            this.txtCard.InBackColor = System.Drawing.SystemColors.Info;
            this.txtCard.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCard.Location = new System.Drawing.Point(725, 27);
            this.txtCard.Name = "txtCard";
            this.txtCard.Negative = true;
            this.txtCard.NotEmpty = false;
            this.txtCard.NotEmptyColor = System.Drawing.Color.Red;
            this.txtCard.ReadOnly = true;
            this.txtCard.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCard.SelectOnEnter = true;
            this.txtCard.Size = new System.Drawing.Size(182, 23);
            this.txtCard.TabIndex = 148;
            this.txtCard.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCard.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(913, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 16);
            this.label11.TabIndex = 147;
            this.label11.Text = "شماره کارت :";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(931, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 145;
            this.label4.Text = "نوع كارت :";
            // 
            // txtAmount
            // 
            this.txtAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAmount.ChangeColorIfNotEmpty = false;
            this.txtAmount.ChangeColorOnEnter = true;
            this.txtAmount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtAmount.ForeColor = System.Drawing.Color.DarkMagenta;
            this.txtAmount.InBackColor = System.Drawing.SystemColors.Info;
            this.txtAmount.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAmount.Location = new System.Drawing.Point(18, 67);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Negative = true;
            this.txtAmount.NotEmpty = false;
            this.txtAmount.NotEmptyColor = System.Drawing.Color.Red;
            this.txtAmount.ReadOnly = true;
            this.txtAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAmount.SelectOnEnter = true;
            this.txtAmount.Size = new System.Drawing.Size(199, 27);
            this.txtAmount.TabIndex = 12;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAmount.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtDuration
            // 
            this.txtDuration.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDuration.ChangeColorIfNotEmpty = false;
            this.txtDuration.ChangeColorOnEnter = true;
            this.txtDuration.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDuration.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDuration.Location = new System.Drawing.Point(18, 27);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Negative = true;
            this.txtDuration.NotEmpty = false;
            this.txtDuration.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDuration.ReadOnly = true;
            this.txtDuration.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDuration.SelectOnEnter = true;
            this.txtDuration.Size = new System.Drawing.Size(87, 23);
            this.txtDuration.TabIndex = 11;
            this.txtDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDuration.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtTimeOut
            // 
            this.txtTimeOut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTimeOut.ChangeColorIfNotEmpty = false;
            this.txtTimeOut.ChangeColorOnEnter = true;
            this.txtTimeOut.InBackColor = System.Drawing.SystemColors.Info;
            this.txtTimeOut.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTimeOut.Location = new System.Drawing.Point(270, 71);
            this.txtTimeOut.Name = "txtTimeOut";
            this.txtTimeOut.Negative = true;
            this.txtTimeOut.NotEmpty = false;
            this.txtTimeOut.NotEmptyColor = System.Drawing.Color.Red;
            this.txtTimeOut.ReadOnly = true;
            this.txtTimeOut.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTimeOut.SelectOnEnter = true;
            this.txtTimeOut.Size = new System.Drawing.Size(135, 23);
            this.txtTimeOut.TabIndex = 10;
            this.txtTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTimeOut.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtDateOut
            // 
            this.txtDateOut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDateOut.ChangeColorIfNotEmpty = false;
            this.txtDateOut.ChangeColorOnEnter = true;
            this.txtDateOut.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDateOut.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateOut.Location = new System.Drawing.Point(270, 27);
            this.txtDateOut.Name = "txtDateOut";
            this.txtDateOut.Negative = true;
            this.txtDateOut.NotEmpty = false;
            this.txtDateOut.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateOut.ReadOnly = true;
            this.txtDateOut.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDateOut.SelectOnEnter = true;
            this.txtDateOut.Size = new System.Drawing.Size(135, 23);
            this.txtDateOut.TabIndex = 9;
            this.txtDateOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDateOut.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtTimeIn
            // 
            this.txtTimeIn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTimeIn.ChangeColorIfNotEmpty = false;
            this.txtTimeIn.ChangeColorOnEnter = true;
            this.txtTimeIn.InBackColor = System.Drawing.SystemColors.Info;
            this.txtTimeIn.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTimeIn.Location = new System.Drawing.Point(503, 67);
            this.txtTimeIn.Name = "txtTimeIn";
            this.txtTimeIn.Negative = true;
            this.txtTimeIn.NotEmpty = false;
            this.txtTimeIn.NotEmptyColor = System.Drawing.Color.Red;
            this.txtTimeIn.ReadOnly = true;
            this.txtTimeIn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTimeIn.SelectOnEnter = true;
            this.txtTimeIn.Size = new System.Drawing.Size(135, 23);
            this.txtTimeIn.TabIndex = 8;
            this.txtTimeIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTimeIn.TextMode = ClassLibrary.TextModes.Text;
            // 
            // txtDateIn
            // 
            this.txtDateIn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDateIn.ChangeColorIfNotEmpty = false;
            this.txtDateIn.ChangeColorOnEnter = true;
            this.txtDateIn.InBackColor = System.Drawing.SystemColors.Info;
            this.txtDateIn.InForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDateIn.Location = new System.Drawing.Point(503, 27);
            this.txtDateIn.Name = "txtDateIn";
            this.txtDateIn.Negative = true;
            this.txtDateIn.NotEmpty = false;
            this.txtDateIn.NotEmptyColor = System.Drawing.Color.Red;
            this.txtDateIn.ReadOnly = true;
            this.txtDateIn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDateIn.SelectOnEnter = true;
            this.txtDateIn.Size = new System.Drawing.Size(135, 23);
            this.txtDateIn.TabIndex = 7;
            this.txtDateIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDateIn.TextMode = ClassLibrary.TextModes.Text;
            // 
            // label34
            // 
            this.label34.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(217, 70);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(42, 16);
            this.label34.TabIndex = 5;
            this.label34.Text = "مبلغ :";
            // 
            // label33
            // 
            this.label33.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(105, 30);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(154, 16);
            this.label33.TabIndex = 4;
            this.label33.Text = "مدت زمان حضور به دقیقه :";
            // 
            // label32
            // 
            this.label32.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(400, 70);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(85, 16);
            this.label32.TabIndex = 3;
            this.label32.Text = "ساعت خروج :";
            // 
            // label31
            // 
            this.label31.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(411, 30);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(74, 16);
            this.label31.TabIndex = 2;
            this.label31.Text = "تاریخ خروج :";
            // 
            // label30
            // 
            this.label30.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(636, 70);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(79, 16);
            this.label30.TabIndex = 1;
            this.label30.Text = "ساعت ورود :";
            // 
            // label29
            // 
            this.label29.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(642, 30);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(68, 16);
            this.label29.TabIndex = 0;
            this.label29.Text = "تاریخ ورود :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblMessage);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 651);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1004, 61);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "هشدار ها";
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblMessage.ForeColor = System.Drawing.Color.Maroon;
            this.lblMessage.Location = new System.Drawing.Point(904, 22);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(16, 19);
            this.lblMessage.TabIndex = 16;
            this.lblMessage.Text = "-";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(937, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 16);
            this.label12.TabIndex = 15;
            this.label12.Text = "پیغام :";
            // 
            // pctcpClient
            // 
            this.pctcpClient.OnReceiveData += new ClassLibrary.BSPTCPClient.OnReceiveDataHandler(this.pctcpClient_OnReceiveData);
            this.pctcpClient.OnError += new ClassLibrary.BSPTCPClient.OnErrorHandler(this.pctcpClient_OnError);
            this.pctcpClient.OnDisconnect += new ClassLibrary.BSPTCPClient.OnDisconnectHandler(this.pctcpClient_OnDisconnect);
            this.pctcpClient.OnConnect += new ClassLibrary.BSPTCPClient.OnConnectHandler(this.pctcpClient_OnConnect);
            // 
            // JTrafficForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 712);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JTrafficForm";
            this.Text = "TrafficForm";
            this.Load += new System.EventHandler(this.JTrafficForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JTrafficForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnShift;
        private System.Windows.Forms.Button BtnRefresh;
        private System.Windows.Forms.Button BtnEndShift;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private ClassLibrary.TextEdit txtIDCardParking;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label28;
        private ClassLibrary.TextEdit txtNumber;
        private System.Windows.Forms.Button btnManualAdd;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private ClassLibrary.TextEdit txtTimeOut;
        private ClassLibrary.TextEdit txtDateOut;
        private ClassLibrary.TextEdit txtTimeIn;
        private ClassLibrary.TextEdit txtDateIn;
        private ClassLibrary.TextEdit txtAmount;
        private ClassLibrary.TextEdit txtDuration;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private ClassLibrary.TextEdit txtCard;
        private ClassLibrary.TextEdit TyperCard;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label12;
        private ClassLibrary.BSPTCPClient pctcpClient;
    }
}