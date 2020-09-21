using BusManagment.Line;
using BusManagment.Zone;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace WebBusManagement.FormsStatisticalReports
{
    public partial class JBusServicesLineStatisticalReportControl : System.Web.UI.UserControl
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
                LoadZones();
                LoadLines();
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

        protected void cmbZone_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
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
            }
            else
            {
                LoadLines();
            }
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

        protected void cmbLine_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            //if (Convert.ToInt32(cmbLine.SelectedValue) > 0)
            //{
            //    DataTable dtZones = WebClassLibrary.JWebDataBase.GetDataTable(@"select * from AUTZone Where Code =
            //        (Select ZoneCode From AutLine Where Code = " + cmbLine.SelectedValue + ")");
            //    var p = (from v in dtZones.AsEnumerable()
            //             select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
            //    p.Insert(0, new { Code = 0, Name = "همه" });
            //    cmbZone.DataSource = p;
            //    cmbZone.DataTextField = "Name";
            //    cmbZone.DataValueField = "Code";
            //    cmbZone.DataBind();
            //}
            //else
            //{
            //    LoadZones();
            //}
            if (Convert.ToInt32(cmbLine.SelectedValue) > 0)
            {
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

        public void GetReport(DateTime? StartEventDate = null, DateTime? EndEventDate = null, int ZoneCode = 0, int LineNumber = 0, int BusNumebr = 0)
        {
            string WhereStr = "", WhereStrBusCount = "";
            DateTime NullDatetime = new DateTime(0001, 1, 1, 12, 00, 00);
            if (StartEventDate.HasValue == true)
            {
                if (StartEventDate.HasValue && StartEventDate.Value.Date > NullDatetime)
                {
                    DateTime StartDTime = new DateTime(StartEventDate.Value.Year, StartEventDate.Value.Month, StartEventDate.Value.Day);
                    DateTime EndDTime = new DateTime(EndEventDate.Value.Year, EndEventDate.Value.Month, EndEventDate.Value.Day);
                    WhereStr += @" and A.[Date] between '" + StartDTime.ToShortDateString() + " 00:00:00' and '" + EndDTime.ToShortDateString() + " 23:59:59'";
                    WhereStrBusCount += @" and B.[Date] between '" + StartDTime.ToShortDateString() + " 00:00:00' and '" + EndDTime.ToShortDateString() + " 23:59:59'";
                }
            }
            if (ZoneCode > 0)
            {
                WhereStr += @" and az.Code = " + ZoneCode;
                WhereStrBusCount += @" and az0.Code = " + ZoneCode;
            }
            if (LineNumber > 0)
            {
                WhereStr += @" and al.Code = " + LineNumber;
                WhereStrBusCount += @" and al0.Code = " + LineNumber;
            }
            if (BusNumebr > 0)
            { 
                WhereStr += " and A.busNumber = " + BusNumebr;
                WhereStrBusCount += @" and b.busNumber = " + BusNumebr;
            }
            DataTable DtReport = WebClassLibrary.JWebDataBase.GetDataTable(@"select N'خط '+cast(Z.DateEventDate  as nvarchar)+N' - '+cast(Z.BusCount as nvarchar)+N' اتوبوس' DateEventDate,z.TransactionCount from (
                                                                                SELECT al.LineNumber DateEventDate
                                                                                ,count(*) TransactionCount
                                                                                ,(select count(*) from (
                                                                                select b.BusNumber from [AutBusServices] B
                                                                                left join [dbo].[AUTBus] AB on b.busNumber = AB.BusNumber
                                                                                left join AUTLine al0 on al0.LineNumber = b.LineNumber
                                                                                left join AUTZone az0 on az0.Code = al0.ZoneCode
                                                                                where al0.linenumber = al.LineNumber
                                                                                "+ WhereStrBusCount + @"
                                                                                group by b.BusNumber)A)BusCount
                                                                                FROM [AutBusServices] A 
                                                                                left join [dbo].[AUTBus] AB on A.busNumber = AB.BusNumber
                                                                                left join AUTLine al on al.LineNumber = A.LineNumber
                                                                                left join AUTZone az on az.Code = al.ZoneCode
                                                                                where 
                                                                                (ISNULL(A.EzamBeCode,0) = 0 OR (ISNULL(A.EzamBeCode,0) > 0 AND ISOK = 11))
                                                                                " + WhereStr + @"
                                                                                group by al.LineNumber
                                                                                )Z where Z.DateEventDate is not null");
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
                RadHtmlChartCOL.PlotArea.XAxis.TitleAppearance.Text = "خط";
                RadHtmlChartCOL.PlotArea.XAxis.LabelsAppearance.RotationAngle = 90;
                RadHtmlChartCOL.PlotArea.YAxis.TitleAppearance.Text = "تعداد سرویس";
                RadHtmlChartCOL.PlotArea.XAxis.DataLabelsField = "DateEventDate";
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
                RadHtmlChartPIE.PlotArea.XAxis.TitleAppearance.Text = "خط";
                RadHtmlChartPIE.PlotArea.YAxis.TitleAppearance.Text = "تعداد سرویس";
                Telerik.Web.UI.PieSeries CSP = new Telerik.Web.UI.PieSeries();
                CSP.TooltipsAppearance.Color = Color.White;
                CSP.TooltipsAppearance.DataFormatString = "{0:N0} عدد";
                CSP.LabelsAppearance.DataFormatString = "{0:N0}";
                CSP.LabelsAppearance.Visible = true;
                CSP.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                Telerik.Web.UI.PieSeriesItem PI;
                bool Explode = false;
                for (int i = 0; i < DtReport.Rows.Count; i++)
                {
                    if (i == 0)
                        Explode = true;
                    else
                        Explode = false;
                    PI = new Telerik.Web.UI.PieSeriesItem(Convert.ToDecimal(DtReport.Rows[i]["TransactionCount"].ToString()), GetColor(i), DtReport.Rows[i]["DateEventDate"].ToString(), Explode, true, true);
                    CSP.SeriesItems.Add(PI);
                }
                RadHtmlChartPIE.PlotArea.Series.Add(CSP);
                #endregion
            }
            else
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('اطلاعاتی موجود نمی باشد');", "ErMessage");
            }
            //TransactionColumnChart.DataSource = DtReport;
            //Telerik.Web.UI.ColumnSeries lsTransaction = new Telerik.Web.UI.ColumnSeries();
            //lsTransaction.Name = "تعداد سرویس در روز";
            ////lsTransaction.LabelsAppearance.DataField = "DateEventDate";
            ////lsTransaction.LabelsAppearance.TextStyle.FontFamily = "Tahoma";
            ////lsTransaction.LabelsAppearance.TextStyle.FontSize = 12;
            //lsTransaction.DataFieldY = "TransactionCount";
            //TransactionColumnChart.PlotArea.Series.Clear();
            //TransactionColumnChart.PlotArea.XAxis.DataLabelsField = "DateEventDate";
            //TransactionColumnChart.PlotArea.XAxis.LabelsAppearance.RotationAngle = 90;
            //TransactionColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.Margin = "0";
            //TransactionColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.Color = System.Drawing.Color.Black;
            //TransactionColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.FontFamily = "Tahoma";
            //TransactionColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.FontSize = 10;
            //TransactionColumnChart.PlotArea.Series.Add(lsTransaction);
            //TransactionColumnChart.DataBind();

            //IncomColumnChart.DataSource = DtReport;
            //Telerik.Web.UI.ColumnSeries lsIncome = new Telerik.Web.UI.ColumnSeries();
            //lsIncome.Name = "میزان درآمد در روز";
            ////lsIncome.LabelsAppearance.DataField = "DateEventDate";
            ////lsIncome.LabelsAppearance.TextStyle.FontFamily = "Tahoma";
            ////lsIncome.LabelsAppearance.TextStyle.FontSize = 12;
            //lsIncome.DataFieldY = "InCome";
            //IncomColumnChart.PlotArea.Series.Clear();
            //IncomColumnChart.PlotArea.XAxis.DataLabelsField = "DateEventDate";
            //IncomColumnChart.PlotArea.XAxis.LabelsAppearance.RotationAngle = 90;
            //IncomColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.Margin = "0";
            //IncomColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.Color = System.Drawing.Color.Black;
            //IncomColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.FontFamily = "Tahoma";
            //IncomColumnChart.PlotArea.XAxis.LabelsAppearance.TextStyle.FontSize = 10;
            //IncomColumnChart.PlotArea.Series.Add(lsIncome);
            //IncomColumnChart.DataBind();

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
            System.Drawing.Color.DarkGoldenrod,
            Color.DarkKhaki,
            Color.DarkMagenta,
            Color.DarkOliveGreen,
            Color.DarkRed,
            Color.Firebrick,
            System.Drawing.Color.Fuchsia,
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
                GetReport(((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(), ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(), Convert.ToInt32(cmbZone.SelectedValue), Convert.ToInt32(cmbLine.SelectedValue), Convert.ToInt32(cmbBus.SelectedValue));
            }
            else
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('فقط امکان نمایش اطلاعات تا یک سال قبل وجود دارد');", "ErMessage");
            }
        }
    }
}