namespace Interface
{
    partial class frmTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTest));
            this.ribbon1 = new Janus.Windows.Ribbon.Ribbon();
            this.ribbonTab1 = new Janus.Windows.Ribbon.RibbonTab();
            this.ribbonStatusBar1 = new Janus.Windows.Ribbon.RibbonStatusBar();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.uiPanel0 = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanel0Container = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.labelCommand2 = new Janus.Windows.Ribbon.LabelCommand();
            this.labelCommand1 = new Janus.Windows.Ribbon.LabelCommand();
            this.labelCommand3 = new Janus.Windows.Ribbon.LabelCommand();
            this.labelCommand4 = new Janus.Windows.Ribbon.LabelCommand();
            this.labelCommand5 = new Janus.Windows.Ribbon.LabelCommand();
            this.labelCommand6 = new Janus.Windows.Ribbon.LabelCommand();
            this.labelCommand7 = new Janus.Windows.Ribbon.LabelCommand();
            this.labelCommand8 = new Janus.Windows.Ribbon.LabelCommand();
            this.labelCommand9 = new Janus.Windows.Ribbon.LabelCommand();
            this.ribbonTab2 = new Janus.Windows.Ribbon.RibbonTab();
            this.ribbonTab3 = new Janus.Windows.Ribbon.RibbonTab();
            this.ribbonGroup1 = new Janus.Windows.Ribbon.RibbonGroup();
            this.buttonCommand1 = new Janus.Windows.Ribbon.ButtonCommand();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel0)).BeginInit();
            this.uiPanel0.SuspendLayout();
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
            // ribbon1
            // 
            this.ribbon1.ControlBoxMenu.RightPanelWidth = -1;
            this.ribbon1.ControlBoxMenu.SuperTipSettings.ImageListProvider = this.ribbon1.ControlBoxMenu;
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Name = "ribbon1";
            this.ribbon1.Size = new System.Drawing.Size(812, 152);
            // 
            // 
            // 
            this.ribbon1.SuperTipComponent.AutoPopDelay = 2000;
            this.ribbon1.SuperTipComponent.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ribbon1.SuperTipComponent.ImageList = null;
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.AddRange(new Janus.Windows.Ribbon.RibbonTab[] {
            this.ribbonTab1,
            this.ribbonTab2,
            this.ribbonTab3});
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Groups.AddRange(new Janus.Windows.Ribbon.RibbonGroup[] {
            this.ribbonGroup1});
            this.ribbonTab1.Key = "ribbonTab1";
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Text = "    اتوماسیون اداری    ";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ImageSize = new System.Drawing.Size(16, 16);
            this.ribbonStatusBar1.LeftPanelCommands.AddRange(new Janus.Windows.Ribbon.CommandBase[] {
            this.labelCommand7});
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 650);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Office2007ColorScheme = Janus.Windows.Ribbon.Office2007ColorScheme.Blue;
            this.ribbonStatusBar1.Office2007CustomColor = System.Drawing.Color.Empty;
            this.ribbonStatusBar1.RightPanelCommands.AddRange(new Janus.Windows.Ribbon.CommandBase[] {
            this.labelCommand1,
            this.labelCommand3,
            this.labelCommand4,
            this.labelCommand5,
            this.labelCommand6,
            this.labelCommand8,
            this.labelCommand9});
            this.ribbonStatusBar1.ShowToolTips = false;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(812, 23);
            // 
            // 
            // 
            this.ribbonStatusBar1.SuperTipComponent.AutoPopDelay = 2000;
            this.ribbonStatusBar1.SuperTipComponent.ImageList = null;
            this.ribbonStatusBar1.TabIndex = 1;
            this.ribbonStatusBar1.Text = "ribbonStatusBar1";
            this.ribbonStatusBar1.UseCompatibleTextRendering = false;
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.Tag = null;
            this.uiPanel0.Id = new System.Guid("6a544d46-2747-4e6c-80f9-621a13d8c7e0");
            this.uiPanelManager1.Panels.Add(this.uiPanel0);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("6a544d46-2747-4e6c-80f9-621a13d8c7e0"), Janus.Windows.UI.Dock.PanelDockStyle.Left, new System.Drawing.Size(200, 492), true);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // uiPanel0
            // 
            this.uiPanel0.InnerContainer = this.uiPanel0Container;
            this.uiPanel0.Location = new System.Drawing.Point(3, 155);
            this.uiPanel0.Name = "uiPanel0";
            this.uiPanel0.Size = new System.Drawing.Size(200, 492);
            this.uiPanel0.TabIndex = 4;
            this.uiPanel0.Text = "Panel 0";
            // 
            // uiPanel0Container
            // 
            this.uiPanel0Container.Location = new System.Drawing.Point(1, 23);
            this.uiPanel0Container.Name = "uiPanel0Container";
            this.uiPanel0Container.Size = new System.Drawing.Size(194, 468);
            this.uiPanel0Container.TabIndex = 0;
            // 
            // labelCommand2
            // 
            this.labelCommand2.AllowAddToQuickAccessBar = true;
            this.labelCommand2.Name = "labelCommand2";
            this.labelCommand2.SuperTipSettings.ImageListProvider = this.labelCommand2;
            this.labelCommand2.Text = "";
            // 
            // labelCommand1
            // 
            this.labelCommand1.AllowAddToQuickAccessBar = true;
            this.labelCommand1.Key = "labelCommand1";
            this.labelCommand1.Name = "labelCommand1";
            this.labelCommand1.SuperTipSettings.ImageListProvider = this.labelCommand1;
            this.labelCommand1.Text = " کاربر جاری ";
            // 
            // labelCommand3
            // 
            this.labelCommand3.AllowAddToQuickAccessBar = true;
            this.labelCommand3.Key = "labelCommand3";
            this.labelCommand3.Name = "labelCommand3";
            this.labelCommand3.SuperTipSettings.ImageListProvider = this.labelCommand3;
            this.labelCommand3.Text = " serverName";
            // 
            // labelCommand4
            // 
            this.labelCommand4.AllowAddToQuickAccessBar = true;
            this.labelCommand4.Key = "labelCommand4";
            this.labelCommand4.Name = "labelCommand4";
            this.labelCommand4.SuperTipSettings.ImageListProvider = this.labelCommand4;
            this.labelCommand4.Text = "نام سرور";
            // 
            // labelCommand5
            // 
            this.labelCommand5.AllowAddToQuickAccessBar = true;
            this.labelCommand5.Key = "labelCommand5";
            this.labelCommand5.Name = "labelCommand5";
            this.labelCommand5.SuperTipSettings.ImageListProvider = this.labelCommand5;
            this.labelCommand5.Text = "Date";
            // 
            // labelCommand6
            // 
            this.labelCommand6.AllowAddToQuickAccessBar = true;
            this.labelCommand6.Key = "labelCommand6";
            this.labelCommand6.Name = "labelCommand6";
            this.labelCommand6.SuperTipSettings.ImageListProvider = this.labelCommand6;
            this.labelCommand6.Text = "تاریخ";
            // 
            // labelCommand7
            // 
            this.labelCommand7.AllowAddToQuickAccessBar = true;
            this.labelCommand7.Key = "labelCommand7";
            this.labelCommand7.Name = "labelCommand7";
            this.labelCommand7.SuperTipSettings.ImageListProvider = this.labelCommand7;
            this.labelCommand7.Text = "";
            // 
            // labelCommand8
            // 
            this.labelCommand8.AllowAddToQuickAccessBar = true;
            this.labelCommand8.Key = "labelCommand8";
            this.labelCommand8.Name = "labelCommand8";
            this.labelCommand8.SuperTipSettings.ImageListProvider = this.labelCommand8;
            this.labelCommand8.Text = "Version";
            // 
            // labelCommand9
            // 
            this.labelCommand9.AllowAddToQuickAccessBar = true;
            this.labelCommand9.Key = "labelCommand9";
            this.labelCommand9.Name = "labelCommand9";
            this.labelCommand9.SuperTipSettings.ImageListProvider = this.labelCommand9;
            this.labelCommand9.Text = "نسخه";
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Key = "ribbonTab2";
            this.ribbonTab2.Name = "ribbonTab2";
            this.ribbonTab2.Text = "   املاک   ";
            // 
            // ribbonTab3
            // 
            this.ribbonTab3.Key = "ribbonTab3";
            this.ribbonTab3.Name = "ribbonTab3";
            this.ribbonTab3.Text = "   سهام   ";
            // 
            // ribbonGroup1
            // 
            this.ribbonGroup1.AllowAddToQuickAccessBar = true;
            this.ribbonGroup1.Commands.AddRange(new Janus.Windows.Ribbon.CommandBase[] {
            this.buttonCommand1});
            this.ribbonGroup1.DialogButtonSuperTipSettings.ImageListProvider = this.ribbonGroup1;
            this.ribbonGroup1.Key = "ribbonGroup1";
            this.ribbonGroup1.Name = "ribbonGroup1";
            this.ribbonGroup1.SuperTipSettings.ImageListProvider = this.ribbonGroup1;
            this.ribbonGroup1.Text = "Group 0";
            // 
            // buttonCommand1
            // 
            this.buttonCommand1.AllowAddToQuickAccessBar = true;
            this.buttonCommand1.Key = "buttonCommand1";
            this.buttonCommand1.Name = "buttonCommand1";
            this.buttonCommand1.SuperTipSettings.ImageListProvider = this.buttonCommand1;
            this.buttonCommand1.Text = "     ثبت مینوت     ";
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 673);
            this.Controls.Add(this.uiPanel0);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbon1);
            this.Name = "frmTest";
            this.Text = "Enterprise Resource Planning";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanel0)).EndInit();
            this.uiPanel0.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.Ribbon.Ribbon ribbon1;
        private Janus.Windows.Ribbon.RibbonTab ribbonTab1;
        private Janus.Windows.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanel uiPanel0;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanel0Container;
        private Janus.Windows.Ribbon.LabelCommand labelCommand7;
        private Janus.Windows.Ribbon.LabelCommand labelCommand1;
        private Janus.Windows.Ribbon.LabelCommand labelCommand3;
        private Janus.Windows.Ribbon.LabelCommand labelCommand4;
        private Janus.Windows.Ribbon.LabelCommand labelCommand5;
        private Janus.Windows.Ribbon.LabelCommand labelCommand6;
        private Janus.Windows.Ribbon.LabelCommand labelCommand8;
        private Janus.Windows.Ribbon.LabelCommand labelCommand9;
        private Janus.Windows.Ribbon.LabelCommand labelCommand2;
        private Janus.Windows.Ribbon.RibbonGroup ribbonGroup1;
        private Janus.Windows.Ribbon.ButtonCommand buttonCommand1;
        private Janus.Windows.Ribbon.RibbonTab ribbonTab2;
        private Janus.Windows.Ribbon.RibbonTab ribbonTab3;
    }
}