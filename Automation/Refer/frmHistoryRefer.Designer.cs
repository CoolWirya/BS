namespace Automation
{
    partial class JHistoryRefer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JHistoryRefer));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbObjectType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtresponse_secret = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtresponse = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtmessage_secret = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtmessage = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txturgency = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtrespite_date_time = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtview_date_time = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtrespnse_date_time = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtsecret_level = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtstatus = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtrefertype = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtreceiver_full_title = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtreceiver_post = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtsender_post = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.jDataTreeView1 = new ClassLibrary.JDataTreeView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnActive = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.btnrefer = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
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
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtCode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbObjectType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(872, 43);
            this.panel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = global::Automation.Properties.Resources.search22;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(342, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 27);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(436, 9);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 23);
            this.txtCode.TabIndex = 11;
            this.txtCode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtCode_MouseDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(542, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Code:";
            // 
            // cmbObjectType
            // 
            this.cmbObjectType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbObjectType.FormattingEnabled = true;
            this.cmbObjectType.Location = new System.Drawing.Point(591, 9);
            this.cmbObjectType.Name = "cmbObjectType";
            this.cmbObjectType.Size = new System.Drawing.Size(194, 24);
            this.cmbObjectType.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(791, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "objecttype:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(872, 585);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.txtdescription);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.txtresponse_secret);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.txtresponse);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.txtmessage_secret);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.txtmessage);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.txturgency);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.txtrespite_date_time);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.txtview_date_time);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.txtrespnse_date_time);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.txtsecret_level);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.txtstatus);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.txtrefertype);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.txtreceiver_full_title);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.txtreceiver_post);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txtsender_post);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(487, 585);
            this.panel4.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(390, 416);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(75, 16);
            this.label18.TabIndex = 41;
            this.label18.Text = "description:";
            // 
            // txtdescription
            // 
            this.txtdescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdescription.Location = new System.Drawing.Point(12, 412);
            this.txtdescription.Name = "txtdescription";
            this.txtdescription.Size = new System.Drawing.Size(318, 23);
            this.txtdescription.TabIndex = 40;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(358, 387);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(107, 16);
            this.label17.TabIndex = 39;
            this.label17.Text = "response_secret:";
            // 
            // txtresponse_secret
            // 
            this.txtresponse_secret.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtresponse_secret.Location = new System.Drawing.Point(12, 383);
            this.txtresponse_secret.Name = "txtresponse_secret";
            this.txtresponse_secret.Size = new System.Drawing.Size(318, 23);
            this.txtresponse_secret.TabIndex = 38;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(400, 358);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 16);
            this.label16.TabIndex = 37;
            this.label16.Text = "response:";
            // 
            // txtresponse
            // 
            this.txtresponse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtresponse.Location = new System.Drawing.Point(12, 354);
            this.txtresponse.Name = "txtresponse";
            this.txtresponse.Size = new System.Drawing.Size(318, 23);
            this.txtresponse.TabIndex = 36;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(359, 329);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 16);
            this.label15.TabIndex = 35;
            this.label15.Text = "message_secret:";
            // 
            // txtmessage_secret
            // 
            this.txtmessage_secret.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtmessage_secret.Location = new System.Drawing.Point(12, 325);
            this.txtmessage_secret.Name = "txtmessage_secret";
            this.txtmessage_secret.Size = new System.Drawing.Size(318, 23);
            this.txtmessage_secret.TabIndex = 34;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(401, 300);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 16);
            this.label14.TabIndex = 33;
            this.label14.Text = "message:";
            // 
            // txtmessage
            // 
            this.txtmessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtmessage.Location = new System.Drawing.Point(12, 296);
            this.txtmessage.Name = "txtmessage";
            this.txtmessage.Size = new System.Drawing.Size(318, 23);
            this.txtmessage.TabIndex = 32;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(407, 271);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 16);
            this.label13.TabIndex = 31;
            this.label13.Text = "urgency:";
            // 
            // txturgency
            // 
            this.txturgency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txturgency.Location = new System.Drawing.Point(12, 267);
            this.txturgency.Name = "txturgency";
            this.txturgency.Size = new System.Drawing.Size(318, 23);
            this.txturgency.TabIndex = 30;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(354, 242);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 16);
            this.label12.TabIndex = 29;
            this.label12.Text = "respite_date_time";
            // 
            // txtrespite_date_time
            // 
            this.txtrespite_date_time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtrespite_date_time.Location = new System.Drawing.Point(12, 238);
            this.txtrespite_date_time.Name = "txtrespite_date_time";
            this.txtrespite_date_time.Size = new System.Drawing.Size(318, 23);
            this.txtrespite_date_time.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(362, 213);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 16);
            this.label11.TabIndex = 27;
            this.label11.Text = "view_date_time:";
            // 
            // txtview_date_time
            // 
            this.txtview_date_time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtview_date_time.Location = new System.Drawing.Point(12, 209);
            this.txtview_date_time.Name = "txtview_date_time";
            this.txtview_date_time.Size = new System.Drawing.Size(318, 23);
            this.txtview_date_time.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(343, 184);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 16);
            this.label10.TabIndex = 25;
            this.label10.Text = "response_date_time:";
            // 
            // txtrespnse_date_time
            // 
            this.txtrespnse_date_time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtrespnse_date_time.Location = new System.Drawing.Point(12, 180);
            this.txtrespnse_date_time.Name = "txtrespnse_date_time";
            this.txtrespnse_date_time.Size = new System.Drawing.Size(318, 23);
            this.txtrespnse_date_time.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(384, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "secret_level:";
            // 
            // txtsecret_level
            // 
            this.txtsecret_level.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsecret_level.Location = new System.Drawing.Point(12, 151);
            this.txtsecret_level.Name = "txtsecret_level";
            this.txtsecret_level.Size = new System.Drawing.Size(318, 23);
            this.txtsecret_level.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(418, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "status:";
            // 
            // txtstatus
            // 
            this.txtstatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtstatus.Location = new System.Drawing.Point(12, 122);
            this.txtstatus.Name = "txtstatus";
            this.txtstatus.Size = new System.Drawing.Size(318, 23);
            this.txtstatus.TabIndex = 20;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(400, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "refertype:";
            // 
            // txtrefertype
            // 
            this.txtrefertype.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtrefertype.Location = new System.Drawing.Point(12, 93);
            this.txtrefertype.Name = "txtrefertype";
            this.txtrefertype.Size = new System.Drawing.Size(318, 23);
            this.txtrefertype.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(354, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Sender_Date_time:";
            // 
            // txtreceiver_full_title
            // 
            this.txtreceiver_full_title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtreceiver_full_title.Location = new System.Drawing.Point(12, 64);
            this.txtreceiver_full_title.Name = "txtreceiver_full_title";
            this.txtreceiver_full_title.Size = new System.Drawing.Size(318, 23);
            this.txtreceiver_full_title.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(375, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "receiver_post:";
            // 
            // txtreceiver_post
            // 
            this.txtreceiver_post.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtreceiver_post.Location = new System.Drawing.Point(12, 35);
            this.txtreceiver_post.Name = "txtreceiver_post";
            this.txtreceiver_post.Size = new System.Drawing.Size(318, 23);
            this.txtreceiver_post.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(382, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "sender_post:";
            // 
            // txtsender_post
            // 
            this.txtsender_post.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsender_post.Location = new System.Drawing.Point(12, 6);
            this.txtsender_post.Name = "txtsender_post";
            this.txtsender_post.Size = new System.Drawing.Size(318, 23);
            this.txtsender_post.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.jDataTreeView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(487, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 585);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "گردش";
            // 
            // jDataTreeView1
            // 
            this.jDataTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jDataTreeView1.Location = new System.Drawing.Point(3, 19);
            this.jDataTreeView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.jDataTreeView1.Name = "jDataTreeView1";
            this.jDataTreeView1.Size = new System.Drawing.Size(379, 563);
            this.jDataTreeView1.TabIndex = 0;
            this.jDataTreeView1.SelectedItemChange += new System.Windows.Forms.TreeViewEventHandler(this.jDataTreeView1_SelectedItemChange);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnActive);
            this.panel3.Controls.Add(this.BtnExit);
            this.panel3.Controls.Add(this.btnrefer);
            this.panel3.Controls.Add(this.btnView);
            this.panel3.Controls.Add(this.BtnDelete);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 585);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(872, 43);
            this.panel3.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = global::Automation.Properties.Resources.file_del25;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(411, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 32);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnActive
            // 
            this.btnActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActive.Image = global::Automation.Properties.Resources.Back1;
            this.btnActive.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActive.Location = new System.Drawing.Point(595, 6);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(87, 32);
            this.btnActive.TabIndex = 21;
            this.btnActive.Text = "Active";
            this.btnActive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActive.UseVisualStyleBackColor = true;
            // 
            // BtnExit
            // 
            this.BtnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExit.Image = global::Automation.Properties.Resources.round_exit___gel27;
            this.BtnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExit.Location = new System.Drawing.Point(318, 6);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(87, 32);
            this.BtnExit.TabIndex = 20;
            this.BtnExit.Text = "Exit";
            this.BtnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnrefer
            // 
            this.btnrefer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnrefer.Image = global::Automation.Properties.Resources.back28;
            this.btnrefer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrefer.Location = new System.Drawing.Point(688, 6);
            this.btnrefer.Name = "btnrefer";
            this.btnrefer.Size = new System.Drawing.Size(87, 32);
            this.btnrefer.TabIndex = 19;
            this.btnrefer.Text = "Refer";
            this.btnrefer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnrefer.UseVisualStyleBackColor = true;
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Image = global::Automation.Properties.Resources.view_save11;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(781, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(87, 32);
            this.btnView.TabIndex = 18;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // BtnDelete
            // 
            this.BtnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDelete.Image = global::Automation.Properties.Resources.delete28;
            this.BtnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDelete.Location = new System.Drawing.Point(502, 6);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(87, 32);
            this.BtnDelete.TabIndex = 15;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDelete.UseVisualStyleBackColor = true;
            // 
            // JHistoryRefer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 628);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "JHistoryRefer";
            this.Text = "frmHistoryRefer";
            this.Load += new System.EventHandler(this.frmHistoryRefer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbObjectType;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtsender_post;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtsecret_level;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtstatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtrefertype;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtreceiver_full_title;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtreceiver_post;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtresponse;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtmessage_secret;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtmessage;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txturgency;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtrespite_date_time;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtview_date_time;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtrespnse_date_time;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtresponse_secret;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnActive;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button btnrefer;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnSearch;
        private ClassLibrary.JDataTreeView jDataTreeView1;
    }
}