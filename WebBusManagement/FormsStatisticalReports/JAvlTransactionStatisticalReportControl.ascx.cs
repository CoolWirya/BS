using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

namespace WebBusManagement.FormsStatisticalReports
{
    public partial class JAvlTransactionStatisticalReportControl : System.Web.UI.UserControl
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
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now.AddDays(-1));
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                txtStartTimeHour.Text = "00";
                txtStartTimeMinute.Text = "00";
                txtStartTimeSecond.Text = "00";
                txtFinishTimeHour.Text = "23";
                txtFinishTimeMinute.Text = "59";
                txtFinishTimeSecond.Text = "59";
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

        public void GetReport(DateTime? StartEventDate = null, DateTime? EndEventDate = null, TimeSpan? StartTime = null, TimeSpan? EndTime = null)
        {
            DataTable DtReport = WebClassLibrary.JWebDataBase.GetDataTable(@"select top 100 percent cast(aat.EventDate as date)EventDate,count(aat.Code)TransactionCount 
                                                                                from AUTAvlTransaction aat
                                                                                where cast(aat.EventDate as Date) between '" + StartEventDate.Value.ToShortDateString() + " " + StartTime.ToString() + @"'
                                                                                and '" + EndEventDate.Value.ToShortDateString() + " " + EndTime.ToString() + @"'
                                                                                group by cast(aat.EventDate as Date)");
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
                RadHtmlChartCOL.PlotArea.XAxis.TitleAppearance.Text = "تاریخ ها";
                //RadHtmlChartCOL.PlotArea.XAxis.LabelsAppearance.RotationAngle = 45;
                RadHtmlChartCOL.PlotArea.YAxis.TitleAppearance.Text = "تعداد تراکنش";
                RadHtmlChartCOL.PlotArea.XAxis.DataLabelsField = "EventDate";
                Telerik.Web.UI.ColumnSeries CS;
                CS = new Telerik.Web.UI.ColumnSeries();
                CS.DataFieldY = "TransactionCount";
                CS.Appearance.FillStyle.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#3399ff");
                CS.TooltipsAppearance.Color = Color.White;
                CS.TooltipsAppearance.DataFormatString = "{0:N0} عدد";
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
                RadHtmlChartPIE.PlotArea.XAxis.TitleAppearance.Text = "تاریخ ها";
                RadHtmlChartPIE.PlotArea.YAxis.TitleAppearance.Text = "تعداد تراکنش";
                Telerik.Web.UI.PieSeries CSP = new Telerik.Web.UI.PieSeries();
                CSP.TooltipsAppearance.Color = Color.White;
                CSP.TooltipsAppearance.DataFormatString = "{0:N0} عدد";
                CSP.LabelsAppearance.Visible = true;
                CSP.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                CS.LabelsAppearance.DataFormatString = "{0:N0}";
                Telerik.Web.UI.PieSeriesItem PI;
                bool Explode = false;
                for (int i = 0; i < DtReport.Rows.Count; i++)
                {
                    if (i == 0)
                        Explode = true;
                    else
                        Explode = false;
                    PI = new Telerik.Web.UI.PieSeriesItem(Convert.ToDecimal(DtReport.Rows[i]["TransactionCount"].ToString()), GetColor(i), DtReport.Rows[i]["EventDate"].ToString(), Explode, true, true);
                    CSP.SeriesItems.Add(PI);
                }
                RadHtmlChartPIE.PlotArea.Series.Add(CSP);
            }
            else
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('اطلاعاتی موجود نمی باشد');", "ErMessage");
            }
            //TransactionColumnChart.DataSource = DtReport;
            //Telerik.Web.UI.LineSeries lsTransaction = new Telerik.Web.UI.LineSeries();
            //lsTransaction.Name = "تعداد تراکنش AVL";
            //lsTransaction.DataFieldY = "TransactionCount";
            //TransactionColumnChart.PlotArea.Series.Clear();
            //TransactionColumnChart.PlotArea.XAxis.DataLabelsField = "EventDate";
            ////TransactionColumnChart.PlotArea.XAxis.LabelsAppearance.RotationAngle = 90;
            ////TransactionColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.Margin = "0";
            //TransactionColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.Color = System.Drawing.Color.Black;
            ////TransactionColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.FontFamily = "Tahoma";
            ////TransactionColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.FontSize = 10;
            //TransactionColumnChart.PlotArea.Series.Add(lsTransaction);
            //TransactionColumnChart.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate() >= DateTime.Now.AddYears(-1))
            {
                TimeSpan TsStartTime;
                TimeSpan TsEndTime;
                int TimeFlag = 0;
                try
                {
                    TsStartTime = new TimeSpan(
                            Convert.ToInt32(txtStartTimeHour.Text)
                            , Convert.ToInt32(txtStartTimeMinute.Text), Convert.ToInt32(txtStartTimeSecond.Text));
                }
                catch
                {
                    TsStartTime = new TimeSpan(0, 0, 0);
                    TimeFlag = 1;
                }

                try
                {
                    TsEndTime = new TimeSpan(
                            Convert.ToInt32(txtFinishTimeHour.Text)
                            , Convert.ToInt32(txtFinishTimeMinute.Text), Convert.ToInt32(txtFinishTimeSecond.Text));
                }
                catch
                {
                    TsEndTime = new TimeSpan(0, 0, 0);
                    TimeFlag = 1;
                }

                if (TimeFlag == 0)
                {
                    GetReport(((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(), ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(), TsStartTime, TsEndTime);
                }
                else if (TimeFlag == 1)
                {
                    GetReport(((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(), ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(),
                        null, null);
                }
            }
            else
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('فقط امکان نمایش اطلاعات تا یک سال قبل وجود دارد');", "ErMessage");
            }

        }
    }
}