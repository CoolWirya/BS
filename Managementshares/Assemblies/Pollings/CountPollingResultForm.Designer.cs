namespace ManagementShares
{
    partial class JCountPollingResultForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("حاضرین", System.Windows.Forms.HorizontalAlignment.Right);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstPollings = new System.Windows.Forms.ListView();
            this.imgListAgents = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.Chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lstCandidas = new System.Windows.Forms.ListView();
            this.lvcolName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvcolHandle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlList = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart1)).BeginInit();
            this.pnlList.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lstPollings);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 443);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(868, 100);
            this.panel1.TabIndex = 2;
            // 
            // lstPollings
            // 
            this.lstPollings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstPollings.Location = new System.Drawing.Point(0, 0);
            this.lstPollings.Name = "lstPollings";
            this.lstPollings.RightToLeftLayout = true;
            this.lstPollings.Size = new System.Drawing.Size(868, 100);
            this.lstPollings.TabIndex = 0;
            this.lstPollings.UseCompatibleStateImageBehavior = false;
            this.lstPollings.View = System.Windows.Forms.View.List;
            this.lstPollings.DoubleClick += new System.EventHandler(this.lstPollings_DoubleClick);
            // 
            // imgListAgents
            // 
            this.imgListAgents.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgListAgents.ImageSize = new System.Drawing.Size(64, 64);
            this.imgListAgents.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // splitter1
            // 
            this.splitter1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.splitter1.Location = new System.Drawing.Point(332, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 443);
            this.splitter1.TabIndex = 10;
            this.splitter1.TabStop = false;
            // 
            // Chart1
            // 
            this.Chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(223)))), ((int)(((byte)(240)))));
            this.Chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.Chart1.BackSecondaryColor = System.Drawing.Color.White;
            this.Chart1.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.Chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.Chart1.BorderlineWidth = 2;
            this.Chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Area3DStyle.Inclination = 10;
            chartArea1.Area3DStyle.IsClustered = true;
            chartArea1.Area3DStyle.PointDepth = 70;
            chartArea1.Area3DStyle.Rotation = 10;
            chartArea1.Area3DStyle.WallWidth = 0;
            chartArea1.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("B Nazanin", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(165)))), ((int)(((byte)(191)))), ((int)(((byte)(228)))));
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "Default";
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            this.Chart1.ChartAreas.Add(chartArea1);
            this.Chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Enabled = false;
            legend1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend1.IsTextAutoFit = false;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend1.Name = "Default";
            legend1.TitleFont = new System.Drawing.Font("Tahoma", 9F);
            this.Chart1.Legends.Add(legend1);
            this.Chart1.Location = new System.Drawing.Point(342, 0);
            this.Chart1.Name = "Chart1";
            series1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series1.ChartArea = "Default";
            series1.Color = System.Drawing.Color.SkyBlue;
            series1.CustomProperties = "LabelStyle=Bottom";
            series1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Default";
            series1.Name = "Default";
            this.Chart1.Series.Add(series1);
            this.Chart1.Size = new System.Drawing.Size(526, 443);
            this.Chart1.TabIndex = 11;
            title1.Font = new System.Drawing.Font("B Titr", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            title1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            title1.Name = "Title1";
            title1.ShadowColor = System.Drawing.Color.Silver;
            title1.ShadowOffset = 3;
            title1.Text = "انتخابات";
            this.Chart1.Titles.Add(title1);
            // 
            // lstCandidas
            // 
            this.lstCandidas.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstCandidas.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lstCandidas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lvcolName,
            this.lvcolHandle});
            this.lstCandidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCandidas.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            listViewGroup1.Header = "حاضرین";
            listViewGroup1.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Right;
            listViewGroup1.Name = "listGrpPresents";
            this.lstCandidas.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.lstCandidas.LargeImageList = this.imgListAgents;
            this.lstCandidas.Location = new System.Drawing.Point(0, 0);
            this.lstCandidas.Margin = new System.Windows.Forms.Padding(2);
            this.lstCandidas.Name = "lstCandidas";
            this.lstCandidas.RightToLeftLayout = true;
            this.lstCandidas.Size = new System.Drawing.Size(332, 443);
            this.lstCandidas.TabIndex = 2;
            this.lstCandidas.TileSize = new System.Drawing.Size(400, 60);
            this.lstCandidas.UseCompatibleStateImageBehavior = false;
            this.lstCandidas.View = System.Windows.Forms.View.Tile;
            // 
            // lvcolHandle
            // 
            this.lvcolHandle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnlList
            // 
            this.pnlList.Controls.Add(this.lstCandidas);
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlList.Location = new System.Drawing.Point(0, 0);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(332, 443);
            this.pnlList.TabIndex = 5;
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // JCountPollingResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 543);
            this.Controls.Add(this.Chart1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlList);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "JCountPollingResultForm";
            this.Text = "";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Chart1)).EndInit();
            this.pnlList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lstPollings;
        private System.Windows.Forms.ImageList imgListAgents;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart1;
        internal System.Windows.Forms.ListView lstCandidas;
        internal System.Windows.Forms.ColumnHeader lvcolName;
        internal System.Windows.Forms.ColumnHeader lvcolHandle;
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.Timer timer1;



    }
}