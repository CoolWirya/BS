using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using Telerik.Web.UI;
using BusManagment.Zone;
using BusManagment.Line;

namespace WebBusStatisticalReports.FormsStatisticalReports
{
    public partial class JHourStatisticalReportControl : System.Web.UI.UserControl
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
                ((WebControllers.MainControls.Date.JDateControl)txtDate).SetDate(DateTime.Now);
                txtStartTimeHour.Text = "07";
                txtStartTimeMinute.Text = "00";
                txtStartTimeSecond.Text = "00";
                txtFinishTimeHour.Text = "08";
                txtFinishTimeMinute.Text = "59";
                txtFinishTimeSecond.Text = "59";
                LoadBus();
                LoadZones();
                LoadLines();
            }
        }

        public void GetReport(DateTime? StartEventDate = null, TimeSpan? StartTime = null, TimeSpan? EndTime = null, int ZoneCode = 0, int LineNumber = 0, int BusNumebr = 0)
        {
            //string WhereStr = " where 1=1 ";
            //DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            //DateTime StartDTime = DateTime.Now, EndDTime = DateTime.Now;
            //if (StartEventDate.HasValue == true)
            //{
            //    if ((StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime) && !StartTime.HasValue)
            //        WhereStr += @" and convert(date,EventDate) between '" + StartEventDate.Value.Date + "' and '" + StartEventDate.Value.Date + "'";

            //    if ((StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime) && StartTime.HasValue)
            //    {
            //        StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day, StartTime.Value.Hours, StartTime.Value.Minutes, StartTime.Value.Seconds);
            //        EndDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day, EndTime.Value.Hours, EndTime.Value.Minutes, EndTime.Value.Seconds);
            //        WhereStr += @" and EventDate between '" + StartDTime.ToString() + "' and '" + EndDTime.ToString() + "'";
            //    }
            //}
            //DataTable DtReport = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT top 100 percent max(Code)Code,COUNT(*)TransactionCount,SUM(TicketPrice) * 10 as InCome,
            //                                                                    cast (DATEPART(hour,'" + StartDTime.ToString() + @"') AS nvarchar)
            //                                                                    +N' - '+
            //                                                                    cast(DATEPART(hour,'" + EndDTime.ToString() + @"') AS NVARCHAR)HourEvent 
            //                                                                    FROM AUTTicketTransaction
            //                                                                 " + WhereStr);
            string WhereStr = "";
            if (ZoneCode > 0)
                WhereStr += " and zonecode = " + ZoneCode;

            if (LineNumber > 0)
                WhereStr += " and linenumber = " + LineNumber;

            if (BusNumebr > 0)
                WhereStr += " and busnumber = " + BusNumebr;
            string Q = @"select datepart(hour,eventdate)HourN,count(*)TransactionCount,sum(cast(TicketPrice as float))*10 InCome from AUTTicketTransaction
                                                                             where 1=1  and EventDate >= '" + StartEventDate.Value.ToShortDateString() + @" " + StartTime.Value.Hours + @":" + StartTime.Value.Minutes + @":" + StartTime.Value.Seconds + @"'
                                                                             and EventDate <= '" + StartEventDate.Value.ToShortDateString() + @" " + EndTime.Value.Hours + @":" + EndTime.Value.Minutes + @":" + EndTime.Value.Seconds + @"'
                                                                             and TicketPrice > 0 and CardType = 0 " + WhereStr + @"
                                                                             group by datepart(hour,eventdate)
                                                                             order by HourN";
            DataTable DtReport = WebClassLibrary.JWebDataBase.GetDataTable(Q);

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
                RadHtmlChartCOL.PlotArea.XAxis.TitleAppearance.Text = "ساعات";
                //RadHtmlChartCOL.PlotArea.XAxis.LabelsAppearance.RotationAngle = 45;
                RadHtmlChartCOL.PlotArea.YAxis.TitleAppearance.Text = "تعداد تراکنش";
                RadHtmlChartCOL.PlotArea.XAxis.DataLabelsField = "HourN";
                Telerik.Web.UI.ColumnSeries CS;
                CS = new Telerik.Web.UI.ColumnSeries();
                CS.DataFieldY = "TransactionCount";
                CS.Appearance.FillStyle.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#3399ff");
                CS.TooltipsAppearance.Color = Color.White;
                CS.TooltipsAppearance.DataFormatString = "{0:N0} عدد";
                CS.LabelsAppearance.Visible = true;
                CS.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                CS.LabelsAppearance.RotationAngle = 90;
                CS.LabelsAppearance.DataFormatString = "{0:N0}";
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
                RadHtmlChartPIE.PlotArea.XAxis.TitleAppearance.Text = "ساعات";
                RadHtmlChartPIE.PlotArea.YAxis.TitleAppearance.Text = "تعداد تراکنش";
                Telerik.Web.UI.PieSeries CSP = new Telerik.Web.UI.PieSeries();
                CSP.TooltipsAppearance.Color = Color.White;
                CSP.TooltipsAppearance.DataFormatString = "{0:N0} عدد";
                CSP.LabelsAppearance.Visible = true;
                CSP.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                CSP.LabelsAppearance.DataFormatString = "{0:N0}";
                Telerik.Web.UI.PieSeriesItem PI;
                bool Explode = false;
                for (int i = 0; i < DtReport.Rows.Count; i++)
                {
                    if (i == 0)
                        Explode = true;
                    else
                        Explode = false;
                    PI = new Telerik.Web.UI.PieSeriesItem(Convert.ToDecimal(DtReport.Rows[i]["TransactionCount"].ToString()), GetColor(i), DtReport.Rows[i]["HourN"].ToString(), Explode, true, true);
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
                RadHtmlChartCOLIncome.PlotArea.XAxis.TitleAppearance.Text = "ساعات";
                //RadHtmlChartCOLIncome.PlotArea.XAxis.LabelsAppearance.RotationAngle = 45;
                RadHtmlChartCOLIncome.PlotArea.YAxis.TitleAppearance.Text = "درآمد";
                RadHtmlChartCOLIncome.PlotArea.XAxis.DataLabelsField = "HourN";
                Telerik.Web.UI.ColumnSeries CSIncome;
                CSIncome = new Telerik.Web.UI.ColumnSeries();
                CSIncome.DataFieldY = "InCome";
                CSIncome.LabelsAppearance.DataFormatString = "{0:N0}";
                CSIncome.Appearance.FillStyle.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#3399ff");
                CSIncome.TooltipsAppearance.Color = Color.White;
                CSIncome.TooltipsAppearance.DataFormatString = "{0:N0} ریال";
                CSIncome.LabelsAppearance.Visible = true;
                CSIncome.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                CSIncome.LabelsAppearance.RotationAngle = 90;
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
                RadHtmlChartPIEIncome.PlotArea.XAxis.TitleAppearance.Text = "ساعات";
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
                    PIIncome = new Telerik.Web.UI.PieSeriesItem(Convert.ToDecimal(DtReport.Rows[i]["InCome"].ToString()), GetColor(i), DtReport.Rows[i]["HourN"].ToString(), ExplodeIncome, true, true);
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
            if (((WebControllers.MainControls.Date.JDateControl)txtDate).GetDate() >= DateTime.Now.AddYears(-1))
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
                    GetReport(((WebControllers.MainControls.Date.JDateControl)txtDate).GetDate(), TsStartTime, TsEndTime, Convert.ToInt32(cmbZone.SelectedValue), Convert.ToInt32(cmbLine.SelectedValue), Convert.ToInt32(cmbBus.SelectedValue));
                }
                else if (TimeFlag == 1)
                {
                    GetReport(((WebControllers.MainControls.Date.JDateControl)txtDate).GetDate(), null, null, Convert.ToInt32(cmbZone.SelectedValue), Convert.ToInt32(cmbLine.SelectedValue), Convert.ToInt32(cmbBus.SelectedValue));
                }
            }
            else
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('فقط امکان نمایش اطلاعات تا یک سال قبل وجود دارد');", "ErMessage");
            }
        }

        protected void cmbZone_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (Convert.ToInt32(cmbZone.SelectedValue) > 0)
            {
                DataTable dtLines = WebClassLibrary.JWebDataBase.GetDataTable("SELECT [Code],convert(nvarchar,[LineNumber])+' - - > '+[LineName] as [lineName],LineNumber FROM AUTLine Where ZoneCode = " + cmbZone.SelectedValue + " Order By LineNumber ASC");
                var p = (from v in dtLines.AsEnumerable()
                         select new { Code = Convert.ToInt32(v["Code"]), lineName = v["lineName"].ToString() }).ToList();
                p.Insert(0, new { Code = 0, lineName = "همه" });
                cmbLine.DataSource = p;
                cmbLine.DataTextField = "lineName";
                cmbLine.DataValueField = "Code";
                cmbLine.DataBind();

                DataTable dtBus = WebClassLibrary.JWebDataBase.GetDataTable(@"Select Code,BusNumber from AUTBus Where Active = 1 
                                                                              and LastLineNumber in (SELECT LineNumber FROM AUTLine 
                                                                              Where ZoneCode = " + cmbZone.SelectedValue + ") Order By BusNumber ASC");
                var p2 = (from v in dtBus.AsEnumerable()
                          select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
                p2.Insert(0, new { Code = 0, BUSNumber = "همه" });
                cmbBus.DataSource = p2;
                cmbBus.DataTextField = "BUSNumber";
                cmbBus.DataValueField = "Code";
                cmbBus.DataBind();
            }
            else
            {
                LoadLines();
                LoadBus();
            }
        }

        protected void cmbLine_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (Convert.ToInt32(cmbLine.SelectedValue) > 0)
            {
                //DataTable dtZones = WebClassLibrary.JWebDataBase.GetDataTable(@"select * from AUTZone Where Code =
                //    (Select ZoneCode From AutLine Where Code = " + cmbLine.SelectedValue + ")");
                //var p = (from v in dtZones.AsEnumerable()
                //         select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
                //p.Insert(0, new { Code = 0, Name = "همه" });
                //cmbZone.DataSource = p;
                //cmbZone.DataTextField = "Name";
                //cmbZone.DataValueField = "Code";
                //cmbZone.DataBind();

                DataTable dtBus = WebClassLibrary.JWebDataBase.GetDataTable(@"Select Code,BusNumber from AUTBus Where Active = 1 
                                                                              and LastLineNumber in (SELECT LineNumber FROM AUTLine 
                                                                              Where Code = " + cmbLine.SelectedValue + ") Order By BusNumber ASC");
                var p2 = (from v in dtBus.AsEnumerable()
                          select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
                p2.Insert(0, new { Code = 0, BUSNumber = "همه" });
                cmbBus.DataSource = p2;
                cmbBus.DataTextField = "BUSNumber";
                cmbBus.DataValueField = "Code";
                cmbBus.DataBind();
            }
            else
            {
                //LoadZones();
                LoadBus();
            }
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

        public void LoadLines()
        {
            DataTable dt = JLines.GetWebDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), lineName = v["lineName"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, lineName = "همه" });
            cmbLine.DataSource = p;
            cmbLine.DataTextField = "lineName";
            cmbLine.DataValueField = "Code";
            cmbLine.DataBind();
        }

        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            var p = (from v in dt.AsEnumerable()
                     select new { Code = v["Code"].ToString(), BUSNumber = v["BUSNumber"].ToString() }).ToList();
            p.Insert(0, new { Code = "0", BUSNumber = "همه" });
            cmbBus.DataSource = p;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }

        protected void cmbBus_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (Convert.ToInt32(cmbBus.SelectedValue) > 0)
            {
                DataTable dtLines = WebClassLibrary.JWebDataBase.GetDataTable("SELECT [Code],convert(nvarchar,[LineNumber])+' - - > '+[LineName] as [lineName],LineNumber FROM AUTLine Where LineNumber = (Select LastLineNumber From AutBus Where Code = " + cmbBus.SelectedValue + ") Order By LineNumber ASC");
                var p = (from v in dtLines.AsEnumerable()
                         select new { Code = Convert.ToInt32(v["Code"]), lineName = v["lineName"].ToString() }).ToList();
                p.Insert(0, new { Code = 0, lineName = "همه" });
                cmbLine.DataSource = p;
                cmbLine.DataTextField = "lineName";
                cmbLine.DataValueField = "Code";
                cmbLine.DataBind();

                DataTable dtZones = WebClassLibrary.JWebDataBase.GetDataTable(@"select * from AUTZone Where Code =
                    (Select top 1 ZoneCode From AutLine Where LineNumber = (Select LastLineNumber From AutBus Where Code = " + cmbBus.SelectedValue + "))");
                var p2 = (from v in dtZones.AsEnumerable()
                          select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
                p2.Insert(0, new { Code = 0, Name = "همه" });
                cmbZone.DataSource = p2;
                cmbZone.DataTextField = "Name";
                cmbZone.DataValueField = "Code";
                cmbZone.DataBind();
            }
            else
            {
                LoadZones();
                LoadLines();
            }
        }

    }
}