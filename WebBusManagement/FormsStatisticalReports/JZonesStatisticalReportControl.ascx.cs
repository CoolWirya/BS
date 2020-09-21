using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusManagment.Zone;
using System.Drawing;

namespace WebBusManagement.FormsStatisticalReports
{
    public partial class JZonesStatisticalReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
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

            if (!IsPostBack)
            {
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                LoadZones();
                LoadCardType();
            }
        }

        public void LoadCardType()
        {
            DataTable DtCardType = new DataTable();
            DtCardType = BusManagment.Card.JCards.GetDataTable(0);
            var p = (from v in DtCardType.AsEnumerable()
                     select new { Type = Convert.ToInt32(v["Type"]), Type1 = v["Type"].ToString() }).ToList();
            p.Insert(0, new { Type = -1, Type1 = "همه" });
            cmbCardType.DataSource = p;
            cmbCardType.DataTextField = "Type1";
            cmbCardType.DataValueField = "Type";
            cmbCardType.DataBind();
            cmbCardType.SelectedValue = "0";
        }

        public void LoadZones()
        {
            DataTable dt = JZones.GetDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, Name = "همه" });
            cmbZone.DataSource = p;
            cmbZone.DataTextField = "Name";
            cmbZone.DataValueField = "Code";
            cmbZone.DataBind();
        }

        public void GetReport(int ZoneCode = 0, int DayType = 0, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int CardType = -1)
        {
            DataTable DtReport = WebClassLibrary.JWebDataBase.GetDataTable(BusManagment.Zone.JZones.GetWebReportQueryForChart(ZoneCode, StartEventDate, EndEventDate, CardType));
            if (DtReport != null)
            {
                #region Transaction
                RadHtmlChartCOL.PlotArea.Series.Clear();
                RadHtmlChartCOL.ChartTitle.Appearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartCOL.PlotArea.XAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartCOL.PlotArea.YAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartCOL.PlotArea.XAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartCOL.PlotArea.YAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartCOL.ChartTitle.Text = "";
                RadHtmlChartCOL.DataSource = DtReport;
                RadHtmlChartCOL.PlotArea.XAxis.TitleAppearance.Text = "مناطق";
                //RadHtmlChartCOL.PlotArea.XAxis.LabelsAppearance.RotationAngle = 45;
                RadHtmlChartCOL.PlotArea.YAxis.TitleAppearance.Text = "تعداد تراکنش";
                RadHtmlChartCOL.PlotArea.XAxis.DataLabelsField = "Name";
                Telerik.Web.UI.ColumnSeries CS;
                CS = new Telerik.Web.UI.ColumnSeries();
                CS.DataFieldY = "sCount";
                CS.Appearance.FillStyle.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#3399ff");
                CS.TooltipsAppearance.Color = Color.White;
                CS.TooltipsAppearance.DataFormatString = "{0:N0} عدد";
                CS.LabelsAppearance.Visible = true;
                CS.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                CS.LabelsAppearance.DataFormatString = "{0:N0}";
                //CS.LabelsAppearance.RotationAngle = 90;
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
                RadHtmlChartPIE.PlotArea.XAxis.TitleAppearance.Text = "مناطق";
                RadHtmlChartPIE.PlotArea.YAxis.TitleAppearance.Text = "تعداد تراکنش";
                Telerik.Web.UI.PieSeries CSP = new Telerik.Web.UI.PieSeries();
                CSP.TooltipsAppearance.Color = Color.White;
                CSP.TooltipsAppearance.DataFormatString = "{0:N0} عدد";
                CSP.LabelsAppearance.Visible = true;
                CSP.LabelsAppearance.DataFormatString = "{0:N0}";
                CSP.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                Telerik.Web.UI.PieSeriesItem PI;
                bool Explode = false;
                for (int i = 0; i < DtReport.Rows.Count; i++)
                {
                    if (i == 0)
                        Explode = true;
                    else
                        Explode = false;
                    PI = new Telerik.Web.UI.PieSeriesItem(Convert.ToDecimal(DtReport.Rows[i]["sCount"].ToString()), GetColor(i), DtReport.Rows[i]["Name"].ToString(), Explode, true, true);
                    CSP.SeriesItems.Add(PI);
                }
                RadHtmlChartPIE.PlotArea.Series.Add(CSP);
                #endregion
                #region Income
                RadHtmlChartCOLIncome.PlotArea.Series.Clear();
                RadHtmlChartCOLIncome.ChartTitle.Appearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartCOLIncome.PlotArea.XAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartCOLIncome.PlotArea.YAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartCOLIncome.PlotArea.XAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartCOLIncome.PlotArea.YAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartCOLIncome.ChartTitle.Text = "";
                RadHtmlChartCOLIncome.DataSource = DtReport;
                RadHtmlChartCOLIncome.PlotArea.XAxis.TitleAppearance.Text = "مناطق";
                //RadHtmlChartCOL.PlotArea.XAxis.LabelsAppearance.RotationAngle = 45;
                RadHtmlChartCOLIncome.PlotArea.YAxis.TitleAppearance.Text = "درآمد";
                RadHtmlChartCOLIncome.PlotArea.XAxis.DataLabelsField = "Name";
                Telerik.Web.UI.ColumnSeries CSIncome;
                CSIncome = new Telerik.Web.UI.ColumnSeries();
                CSIncome.DataFieldY = "sPrice";
                CSIncome.LabelsAppearance.DataFormatString = "{0:N0}";
                CSIncome.Appearance.FillStyle.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#3399ff");
                CSIncome.TooltipsAppearance.Color = Color.White;
                CSIncome.TooltipsAppearance.DataFormatString = "{0:N0} ریال";
                CSIncome.LabelsAppearance.Visible = true;
                CSIncome.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                //CS.LabelsAppearance.RotationAngle = 90;
                RadHtmlChartCOLIncome.PlotArea.Series.Add(CSIncome);
                RadHtmlChartCOLIncome.DataBind();

                RadHtmlChartPIEIncome.PlotArea.Series.Clear();
                RadHtmlChartPIEIncome.ChartTitle.Appearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartPIEIncome.PlotArea.XAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartPIEIncome.PlotArea.YAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartPIEIncome.PlotArea.XAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartPIEIncome.PlotArea.YAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartPIEIncome.Legend.Appearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartPIEIncome.ChartTitle.Text = "";
                RadHtmlChartPIEIncome.Legend.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartLegendPosition.Left;
                RadHtmlChartPIEIncome.Legend.Appearance.Visible = true;
                RadHtmlChartPIEIncome.PlotArea.XAxis.TitleAppearance.Text = "مناطق";
                RadHtmlChartPIEIncome.PlotArea.YAxis.TitleAppearance.Text = "درآمد";
                Telerik.Web.UI.PieSeries CSPIncome = new Telerik.Web.UI.PieSeries();
                CSPIncome.TooltipsAppearance.Color = Color.White;
                CSPIncome.TooltipsAppearance.DataFormatString = "{0:N0} ریال";
                CSPIncome.LabelsAppearance.Visible = true;
                CSPIncome.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                CSPIncome.LabelsAppearance.DataFormatString = "{0:N0}";
                Telerik.Web.UI.PieSeriesItem PIIncome;
                bool ExplodeIncome = false;
                for (int i = 0; i < DtReport.Rows.Count; i++)
                {
                    if (i == 0)
                        Explode = true;
                    else
                        Explode = false;
                    PIIncome = new Telerik.Web.UI.PieSeriesItem(Convert.ToDecimal(DtReport.Rows[i]["sPrice"].ToString()), GetColor(i), DtReport.Rows[i]["Name"].ToString(), ExplodeIncome, true, true);
                    CSPIncome.SeriesItems.Add(PIIncome);
                }
                RadHtmlChartPIEIncome.PlotArea.Series.Add(CSPIncome);
                #endregion
            }
            else
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('اطلاعاتی موجود نمی باشد');", "ErMessage");
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate() >= DateTime.Now.AddYears(-1))
            {
                GetReport(Convert.ToInt32(cmbZone.SelectedValue), 0,
                    ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                    ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(),
                    Convert.ToInt32(cmbCardType.SelectedValue));
            }
            else
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('فقط امکان نمایش اطلاعات تا یک سال قبل وجود دارد');", "ErMessage");
            }
        }
    }
}