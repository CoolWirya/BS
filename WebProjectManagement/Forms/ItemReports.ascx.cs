using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Drawing;
using ProjectManagement;
using System.Data;

namespace WebProjectManagement.Forms
{
    public partial class ItemReports : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadChartStuffs();
            if (!IsPostBack)
            {
                cmbProjects.DataSource = ProjectManagement.Project.JProjects.GetDataTable(true);
                cmbProjects.DataTextField = "Name";
                cmbProjects.DataValueField = "Code";
                cmbProjects.DataBind();
                cmbProjects.SelectedIndex = 0;
                cmbProjects_SelectedIndexChanged(cmbProjects,new Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs("","","",""));
            }
        }


        private void LoadChartStuffs()
        {

            Page.ClientScript.RegisterClientScriptInclude("JqueryChart1", this.ResolveUrl("~/WebControllers/MainControls/JqueryChart/jquery.min.js"));
            Page.ClientScript.RegisterClientScriptInclude("JqueryChart2", this.ResolveUrl("~/WebControllers/MainControls/JqueryChart/jquery.jqplot.min.js"));
            Page.ClientScript.RegisterClientScriptInclude("JqueryChart3", this.ResolveUrl("~/WebControllers/MainControls/JqueryChart/syntaxhighlighter/scripts/shCore.min.js"));
            Page.ClientScript.RegisterClientScriptInclude("JqueryChart4", this.ResolveUrl("~/WebControllers/MainControls/JqueryChart/syntaxhighlighter/scripts/shBrushJScript.min.js"));
            Page.ClientScript.RegisterClientScriptInclude("JqueryChart5", this.ResolveUrl("~/WebControllers/MainControls/JqueryChart/syntaxhighlighter/scripts/shBrushXml.min.js"));
            Page.ClientScript.RegisterClientScriptInclude("JqueryChart6", this.ResolveUrl("~/WebControllers/MainControls/JqueryChart/plugins/jqplot.barRenderer.min.js"));
            Page.ClientScript.RegisterClientScriptInclude("JqueryChart7", this.ResolveUrl("~/WebControllers/MainControls/JqueryChart/plugins/jqplot.pointLabels.min.js"));
            Page.ClientScript.RegisterClientScriptInclude("JqueryChart8", this.ResolveUrl("~/WebControllers/MainControls/JqueryChart/plugins/jqplot.highlighter.min.js"));
            Page.ClientScript.RegisterClientScriptInclude("JqueryChart9", this.ResolveUrl("~/WebControllers/MainControls/JqueryChart/plugins/jqplot.cursor.min.js"));
            Page.ClientScript.RegisterClientScriptInclude("JqueryChart10", this.ResolveUrl("~/WebControllers/MainControls/JqueryChart/plugins/jqplot.categoryAxisRenderer.min.js"));
            Page.ClientScript.RegisterClientScriptInclude("JqueryChart11", this.ResolveUrl("~/WebControllers/MainControls/JqueryChart/plugins/jqplot.logAxisRenderer.min.js"));
            Page.ClientScript.RegisterClientScriptInclude("JqueryChart12", this.ResolveUrl("~/WebControllers/MainControls/JqueryChart/plugins/jqplot.canvasTextRenderer.min.js"));
            Page.ClientScript.RegisterClientScriptInclude("JqueryChart13", this.ResolveUrl("~/WebControllers/MainControls/JqueryChart/plugins/jqplot.canvasAxisLabelRenderer.min.js"));
            Page.ClientScript.RegisterClientScriptInclude("JqueryChart14", this.ResolveUrl("~/WebControllers/MainControls/JqueryChart/plugins/jqplot.canvasAxisTickRenderer.min.js"));
            Page.ClientScript.RegisterClientScriptInclude("JqueryChart15", this.ResolveUrl("~/WebControllers/MainControls/JqueryChart/plugins/jqplot.dateAxisRenderer.min.js"));
            Page.ClientScript.RegisterClientScriptInclude("JqueryChart16", this.ResolveUrl("~/WebControllers/MainControls/JqueryChart/plugins/jqplot.categoryAxisRenderer.min.js"));
            Page.ClientScript.RegisterClientScriptInclude("JqueryChart17", this.ResolveUrl("~/WebControllers/MainControls/JqueryChart/plugins/jqplot.pieRenderer.min.js"));
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(cmbItems.SelectedValue))
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفا آیتم را انتخاب کنید.');", "ConfirmDialog");
                return;
            }
            DataTable DtReport = WebClassLibrary.JWebDataBase.GetDataTable(@"select * from pmItemReport WHERE ItemCode=" + cmbItems.SelectedValue);
            if (DtReport != null)
            {
                RadHtmlChartCOL.PlotArea.Series.Clear();
                RadHtmlChartCOL.ChartTitle.Appearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartCOL.PlotArea.XAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartCOL.PlotArea.YAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartCOL.PlotArea.XAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartCOL.PlotArea.YAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartCOL.ChartTitle.Text = "";
                RadHtmlChartCOL.DataSource = DtReport;
                RadHtmlChartCOL.PlotArea.XAxis.TitleAppearance.Text = "تاریخ";
                //RadHtmlChartCOL.PlotArea.XAxis.LabelsAppearance.RotationAngle = 45;
                RadHtmlChartCOL.PlotArea.YAxis.TitleAppearance.Text = "اطلاعات ورودی";
                RadHtmlChartCOL.PlotArea.XAxis.DataLabelsField = "RegisterDate";
                Telerik.Web.UI.ColumnSeries CS;
                CS = new Telerik.Web.UI.ColumnSeries();
                CS.DataFieldY = "WeightPercentage";
                CS.Appearance.FillStyle.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#3399ff");
                CS.TooltipsAppearance.Color = System.Drawing.Color.White;
                CS.TooltipsAppearance.DataFormatString = "{0:N0} درصد";
                CS.LabelsAppearance.DataFormatString = "{0:N0}";
                CS.LabelsAppearance.Visible = true;
                CS.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                CS.LabelsAppearance.RotationAngle = 90;
                RadHtmlChartCOL.PlotArea.Series.Add(CS);
                RadHtmlChartCOL.DataBind();

                RadHtmlChartPIE.PlotArea.Series.Clear();
                RadHtmlChartPIE.ChartTitle.Appearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartPIE.PlotArea.XAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartPIE.PlotArea.YAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartPIE.PlotArea.XAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartPIE.PlotArea.YAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartPIE.Legend.Appearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartPIE.ChartTitle.Text = "";
                RadHtmlChartPIE.Legend.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartLegendPosition.Left;
                RadHtmlChartPIE.Legend.Appearance.Visible = true;
                RadHtmlChartPIE.PlotArea.XAxis.TitleAppearance.Text = "تاریخ";
                RadHtmlChartPIE.PlotArea.YAxis.TitleAppearance.Text = "اطلاعات ورودی";
                Telerik.Web.UI.PieSeries CSP = new Telerik.Web.UI.PieSeries();
                CSP.TooltipsAppearance.Color = Color.White;
                CSP.TooltipsAppearance.DataFormatString = "{0:N0} درصد پیشرفت";
                CSP.LabelsAppearance.Visible = true;
                CSP.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                CS.LabelsAppearance.DataFormatString = "{0:N0}";
                Telerik.Web.UI.PieSeriesItem PI;
                bool Explode = false;
                decimal total = 0, temp;
                for (int i = 0; i < DtReport.Rows.Count; i++)
                {
                    temp = Convert.ToDecimal(DtReport.Rows[i]["WeightPercentage"].ToString());
                    total += temp;
                    if (i == 0)
                        Explode = true;
                    else
                        Explode = false;
                    PI = new Telerik.Web.UI.PieSeriesItem(temp, GetColor(i), "درصد", Explode, true, true);
                    CSP.SeriesItems.Add(PI);
                }
                if (100 - total > 0)
                {
                    temp = 100 - total;
                    PI = new Telerik.Web.UI.PieSeriesItem(temp, Color.Transparent, "باقی مانده", Explode, true, true);
                    CSP.SeriesItems.Add(PI);
                }
                RadHtmlChartPIE.PlotArea.Series.Add(CSP);



                //Archivedocumnet not workin
                //ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());

                //Telerik.Web.UI.RadBinaryImage img;
                //foreach (DataRow dr in DtReport.Rows)
                //{
                //    System.Data.DataTable dt = archive.RetrieveForWeb(typeof(ProjectManagement.ItemReport.JItemReport).FullName, dr["Code"].ToString().ToInt32(), null);
                //    foreach (DataRow dr2 in dt.Rows)
                //    {//ArchiveCode
                //        if (archive.Retrieve(dr2["Code"].ToString().ToInt32()))
                //        {
                //            ClassLibrary.JFile image = archive.RetrieveContent(dr2["ArchiveCode"].ToString().ToInt32());// archive.Content;
                //            if (image != null)
                //            {
                //                img = new Telerik.Web.UI.RadBinaryImage();
                //                img.DataValue = WebClassLibrary.JDataManager.ReadToEnd(image.Stream);
                //                pnlImages.Controls.Add(img);
                //            }
                //        }
                //    }
                //}
                Tools.LoadItemReportImages(pnlImages, DtReport);
            }
        }
    
        public static Color GetColor(int index)
        {
            return colors[index % colors.Length];
        }

        /// <summary>
        /// The list of hardcoded colors.
        /// </summary>
        /// <remarks>
        /// Can be extended manually by the developer or the class can be modified so that the property can be modified during runtime.
        /// </remarks>
        private static readonly Color[] colors =
        {
            Color.Red,
            Color.Blue,
            Color.Green,
            Color.Navy,
            Color.Purple,
            Color.Orange,
            Color.Violet,
            Color.NavajoWhite,
            Color.MediumSeaGreen,
            Color.HotPink,
            Color.Brown,
            Color.BurlyWood,
            Color.Chartreuse,
            Color.Chocolate,
            Color.Coral,
            Color.Crimson,
            Color.Cyan,
            Color.DarkGoldenrod,
            Color.DarkKhaki,
            Color.DarkMagenta,
            Color.DarkOliveGreen,
            Color.DarkRed,
            Color.Firebrick,
            Color.Fuchsia,
            Color.GreenYellow,
            Color.Lime,
            Color.Maroon,
            Color.MediumPurple,
            Color.Moccasin,
            Color.OrangeRed,
            Color.PaleTurquoise,
            Color.Orchid,
            Color.RosyBrown,
            Color.SandyBrown,
            Color.Tan,
            Color.Turquoise,
            Color.YellowGreen
        };

        protected void cmbProjects_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            cmbItems.DataSource = ProjectManagement.Item.JItems.GetLatestChildren(e.Value.ToInt32());
            cmbItems.DataTextField = "Name";
            cmbItems.DataValueField = "Code";
            cmbItems.DataBind();
        }
    }
}