using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using BusManagment.Zone;
using BusManagment.Line;
using System.Drawing;

namespace WebBusManagement.FormsStatisticalReports
{
    public partial class JDriverStatisticalReportControl : System.Web.UI.UserControl
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
                LoadDriver();
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                LoadZones();
                LoadLines();
                LoadBus();
                LoadCardType();
                LoadBusOwner();
            }
        }

        public void LoadBusOwner()
        {
            DataTable dt = BusManagment.Bus.JBusOwners.GetBusOwners();
            var p = (from v in dt.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, Name = "همه" });
            cmbBusOwner.DataSource = p;
            cmbBusOwner.DataTextField = "Name";
            cmbBusOwner.DataValueField = "Code";
            cmbBusOwner.DataBind();
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
                     select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, BUSNumber = "همه" });
            cmbBus.DataSource = p;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }

        public void LoadDriver()
        {
            DataTable dt = BusManagment.Personel.JPersonels.GetDataTable(0);
            var p = (from v in dt.AsEnumerable()
                     select new { Name = v["Name"].ToString(), PersonCode = v["PersonCode"].ToString() }).ToList();
            p.Insert(0, new { Name = "همه", PersonCode = "0" });
            cmbDriver.DataSource = p;
            cmbDriver.DataTextField = "Name";
            cmbDriver.DataValueField = "PersonCode";
            cmbDriver.DataBind();
        }

        protected void BtnInsertDriver_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbDriver.SelectedValue) != 0)
            {
                RadListBoxItem NewItem = new RadListBoxItem();
                NewItem.Value = cmbDriver.SelectedValue;
                NewItem.Text = cmbDriver.SelectedItem.Text;
                lstDriver.Items.Add(NewItem);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate() >= DateTime.Now.AddYears(-1))
            {
                if (Convert.ToInt32(cmbZone.SelectedValue) == 0 & Convert.ToInt32(cmbLine.SelectedValue) == 0 & lstDriver.Items.Count == 0 & Convert.ToInt32(cmbBus.SelectedValue) == 0 & Convert.ToInt32(cmbBusOwner.SelectedValue) == 0)
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('لطفا منطقه ، خط ، اتوبوس یا راننده ها را جهت مشاهده نمودار مشخص کنید');", "ErMessage");
                }
                else
                {

                    WebClassLibrary.SessionManager.Current.Session["DriverChartFromId" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode] = "0";
                    WebClassLibrary.SessionManager.Current.Session["DriverChartToId" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode] = "20";

                    btnNextPage.Visible = true;
                    btnPrevPage.Visible = true;

                    int[] DriverNumberForLstDriver = new int[lstDriver.Items.Count];
                    for (int i = 0; i < lstDriver.Items.Count; i++)
                    {
                        DriverNumberForLstDriver[i] = Convert.ToInt32(lstDriver.Items[i].Value.ToString());
                    }
                    GetReport(DriverNumberForLstDriver, ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                        ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(),
                        Convert.ToInt32(cmbZone.SelectedValue),
                            Convert.ToInt32(cmbLine.SelectedValue), Convert.ToInt32(cmbBus.SelectedValue), Convert.ToInt32(cmbCardType.SelectedValue), Convert.ToInt32(cmbBusOwner.SelectedValue)
                            , Convert.ToInt32(WebClassLibrary.SessionManager.Current.Session["DriverChartFromId" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode].ToString())
                            , Convert.ToInt32(WebClassLibrary.SessionManager.Current.Session["DriverChartToId" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode].ToString()));
                }
            }
            else
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('فقط امکان نمایش اطلاعات تا یک سال قبل وجود دارد');", "ErMessage");
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

        public void GetReport(int[] DriverNumber, DateTime? StartEventDate = null, DateTime? EndEventDate = null, int ZoneCode = 0, int LineNumber = 0, int BusNumebr = 0, int CardType = -1, int BusOwner = 0, int FromID = 0, int ToID = 0)
        {
            DataTable DtReport = WebClassLibrary.JWebDataBase.GetDataTable(BusManagment.Driver.JDriverseLogs.GetWebDriverPerformanceReportQueryWithMultiDriver(DriverNumber, StartEventDate, EndEventDate, ZoneCode, LineNumber, BusNumebr, CardType, BusOwner, FromID, ToID));
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
                RadHtmlChartCOL.PlotArea.XAxis.TitleAppearance.Text = "راننده";
                RadHtmlChartCOL.PlotArea.XAxis.LabelsAppearance.RotationAngle = 90;
                RadHtmlChartCOL.PlotArea.YAxis.TitleAppearance.Text = "تعداد تراکنش";
                RadHtmlChartCOL.PlotArea.XAxis.DataLabelsField = "DriverName";
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
                RadHtmlChartPIE.PlotArea.XAxis.TitleAppearance.Text = "راننده";
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
                    PI = new Telerik.Web.UI.PieSeriesItem(Convert.ToDecimal(DtReport.Rows[i]["TransactionCount"].ToString()), GetColor(i), DtReport.Rows[i]["DriverName"].ToString(), Explode, true, true);
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
                RadHtmlChartCOLIncome.PlotArea.XAxis.TitleAppearance.Text = "راننده";
                RadHtmlChartCOLIncome.PlotArea.XAxis.LabelsAppearance.RotationAngle = 90;
                RadHtmlChartCOLIncome.PlotArea.YAxis.TitleAppearance.Text = "درآمد";
                RadHtmlChartCOLIncome.PlotArea.XAxis.DataLabelsField = "DriverName";
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
                RadHtmlChartPIEIncome.PlotArea.XAxis.TitleAppearance.Text = "راننده";
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
                    PIIncome = new Telerik.Web.UI.PieSeriesItem(Convert.ToDecimal(DtReport.Rows[i]["InCome"].ToString()), GetColor(i), DtReport.Rows[i]["DriverName"].ToString(), ExplodeIncome, true, true);
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
                LoadZones();
                LoadBus();
            }
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

        protected void btnNextPage_Click(object sender, EventArgs e)
        {
            try
            {
                WebClassLibrary.SessionManager.Current.Session["DriverChartFromId" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode] = (Convert.ToInt32(WebClassLibrary.SessionManager.Current.Session["DriverChartFromId" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode].ToString()) + 21).ToString();
                WebClassLibrary.SessionManager.Current.Session["DriverChartToId" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode] = (Convert.ToInt32(WebClassLibrary.SessionManager.Current.Session["DriverChartToId" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode].ToString()) + 20).ToString();
            }
            catch
            {
                WebClassLibrary.SessionManager.Current.Session["DriverChartFromId" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode] = "0";
                WebClassLibrary.SessionManager.Current.Session["DriverChartToId" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode] = "20";
            }
            int[] DriverNumberForLstDriver = new int[lstDriver.Items.Count];
            for (int i = 0; i < lstDriver.Items.Count; i++)
            {
                DriverNumberForLstDriver[i] = Convert.ToInt32(lstDriver.Items[i].Value.ToString());
            }
            GetReport(DriverNumberForLstDriver, ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(),
                Convert.ToInt32(cmbZone.SelectedValue),
                    Convert.ToInt32(cmbLine.SelectedValue), Convert.ToInt32(cmbBus.SelectedValue), Convert.ToInt32(cmbCardType.SelectedValue), Convert.ToInt32(cmbBusOwner.SelectedValue)
                    , Convert.ToInt32(WebClassLibrary.SessionManager.Current.Session["DriverChartFromId" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode].ToString())
                    , Convert.ToInt32(WebClassLibrary.SessionManager.Current.Session["DriverChartToId" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode].ToString()));
        }

        protected void btnPrevPage_Click(object sender, EventArgs e)
        {
            try
            {
                WebClassLibrary.SessionManager.Current.Session["DriverChartFromId" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode] = (Convert.ToInt32(WebClassLibrary.SessionManager.Current.Session["DriverChartFromId" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode].ToString()) - 21).ToString();
                WebClassLibrary.SessionManager.Current.Session["DriverChartToId" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode] = (Convert.ToInt32(WebClassLibrary.SessionManager.Current.Session["DriverChartToId" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode].ToString()) - 20).ToString();
                if (Convert.ToInt32(WebClassLibrary.SessionManager.Current.Session["DriverChartFromId" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode].ToString()) < 0)
                {
                    WebClassLibrary.SessionManager.Current.Session["DriverChartFromId" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode] = "0";
                    WebClassLibrary.SessionManager.Current.Session["DriverChartToId" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode] = "20";
                }
            }
            catch
            {
                WebClassLibrary.SessionManager.Current.Session["DriverChartFromId" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode] = "0";
                WebClassLibrary.SessionManager.Current.Session["DriverChartToId" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode] = "20";
            }
            int[] DriverNumberForLstDriver = new int[lstDriver.Items.Count];
            for (int i = 0; i < lstDriver.Items.Count; i++)
            {
                DriverNumberForLstDriver[i] = Convert.ToInt32(lstDriver.Items[i].Value.ToString());
            }
            GetReport(DriverNumberForLstDriver, ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(),
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate(),
                Convert.ToInt32(cmbZone.SelectedValue),
                    Convert.ToInt32(cmbLine.SelectedValue), Convert.ToInt32(cmbBus.SelectedValue), Convert.ToInt32(cmbCardType.SelectedValue), Convert.ToInt32(cmbBusOwner.SelectedValue)
                    , Convert.ToInt32(WebClassLibrary.SessionManager.Current.Session["DriverChartFromId" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode].ToString())
                    , Convert.ToInt32(WebClassLibrary.SessionManager.Current.Session["DriverChartToId" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode].ToString()));
        }
    }
}