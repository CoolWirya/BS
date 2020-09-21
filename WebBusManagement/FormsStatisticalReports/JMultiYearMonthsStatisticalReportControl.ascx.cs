using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsStatisticalReports
{
    public partial class JMultiYearMonthsStatisticalReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadYears();
            }
        }

        public void LoadYears()
        {
            string Year = ClassLibrary.JDateTime.FarsiYear(DateTime.Now.AddYears(-1));
            for (int i = Convert.ToInt32(Year); i > 1390; i--)
            {
                Telerik.Web.UI.RadComboBoxItem RBI = new Telerik.Web.UI.RadComboBoxItem();
                RBI.Value = i.ToString();
                RBI.Text = i.ToString();
                cmbFromYear.Items.Add(RBI);
                // cmbToYear.Items.Add(RBI);
            }
            Year = ClassLibrary.JDateTime.FarsiYear(DateTime.Now);
            for (int i = Convert.ToInt32(Year); i > 1390; i--)
            {
                Telerik.Web.UI.RadComboBoxItem RBI = new Telerik.Web.UI.RadComboBoxItem();
                RBI.Value = i.ToString();
                RBI.Text = i.ToString();
                //cmbFromYear.Items.Add(RBI);
                cmbToYear.Items.Add(RBI);
            }
        }

        public void GetReport(int FromYear, int ToYear)
        {
            string WhereStr = "";
            if (ClassLibrary.JDateTime.FarsiYear(DateTime.Now) == FromYear.ToString() || ClassLibrary.JDateTime.FarsiYear(DateTime.Now) == ToYear.ToString())
                WhereStr = @"and date <= getdate()";
            DataTable DtReport = WebClassLibrary.JWebDataBase.GetDataTable(@"select A.TCount,A.SPrice,A.y YearM,
                                                                                    case A.Mount 
                                                                                    when 1 then N'فروردین'
                                                                                    when 2 then N'اردیبهشت'
                                                                                    when 3 then N'خرداد'
                                                                                    when 4 then N'تیر'
                                                                                    when 5 then N'مرداد'
                                                                                    when 6 then N'شهریور'
                                                                                    when 7 then N'مهر'
                                                                                    when 8 then N'آبان'
                                                                                    when 9 then N'آذر'
                                                                                    when 10 then N'دی'
                                                                                    when 11 then N'بهمن'
                                                                                    when 12 then N'اسفند'
                                                                                    end MountName 
                                                                                    from (
                                                                                    select substring(dbo.dateentofa(date),1,4)Y,substring(dbo.dateentofa(date),6,2)Mount,sum(tcount)TCount,sum(cast((tcount * ticketprice) as float)) * 10.0 SPrice
                                                                                    from AUTDailyPerformanceRportOnBus AU
                                                                                    where substring(dbo.dateentofa(date),1,4) >= " + FromYear + @" and substring(dbo.dateentofa(date),1,4) <= " + ToYear + @"
                                                                                    and CardType = 0 and TicketPrice > 0
                                                                                    " + WhereStr + @" and AU.BusCode in (select Code from AUTBus where FleetCode = 1000001 and Active = 1 and IsValid = 1) and AU.TCount > 0 and AU.Price > 0 and AU.TicketPrice > 0 and AU.Error = 0 
                                                                                    group by substring(dbo.dateentofa(date),1,4),substring(dbo.dateentofa(date),6,2)
                                                                                    )A
                                                                                    order by A.Y,A.Mount");
            if (DtReport != null)
            {
                #region Transaction
                //RadHtmlChartCOL.PlotArea.Series.Clear();
                //RadHtmlChartCOL.ChartTitle.Appearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartCOL.PlotArea.XAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartCOL.PlotArea.YAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartCOL.PlotArea.XAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartCOL.PlotArea.YAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartCOL.ChartTitle.Text = "";
                //RadHtmlChartCOL.DataSource = DtReport;
                //RadHtmlChartCOL.PlotArea.XAxis.TitleAppearance.Text = "ماه ها";
                //RadHtmlChartCOL.PlotArea.XAxis.LabelsAppearance.RotationAngle = 45;
                //RadHtmlChartCOL.PlotArea.YAxis.TitleAppearance.Text = "تعداد تراکنش";
                //RadHtmlChartCOL.PlotArea.XAxis.DataLabelsField = "MountName";
                //Telerik.Web.UI.ColumnSeries CS;
                //CS = new Telerik.Web.UI.ColumnSeries();
                //CS.DataFieldY = "TCount";
                //CS.Appearance.FillStyle.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#3399ff");
                //CS.TooltipsAppearance.Color = Color.White;
                //CS.TooltipsAppearance.DataFormatString = "{0} عدد";
                //CS.LabelsAppearance.Visible = true;
                //CS.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                ////CS.LabelsAppearance.RotationAngle = 90;
                //RadHtmlChartCOL.PlotArea.Series.Add(CS);
                //RadHtmlChartCOL.DataBind();

                //RadHtmlChartPIE.PlotArea.Series.Clear();
                //RadHtmlChartPIE.ChartTitle.Appearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartPIE.PlotArea.XAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartPIE.PlotArea.YAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartPIE.PlotArea.XAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartPIE.PlotArea.YAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartPIE.Legend.Appearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartPIE.ChartTitle.Text = "";
                //RadHtmlChartPIE.Legend.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartLegendPosition.Left;
                //RadHtmlChartPIE.Legend.Appearance.Visible = true;
                //RadHtmlChartPIE.PlotArea.XAxis.TitleAppearance.Text = "ماه ها";
                //RadHtmlChartPIE.PlotArea.YAxis.TitleAppearance.Text = "تعداد تراکنش";
                //Telerik.Web.UI.PieSeries CSP = new Telerik.Web.UI.PieSeries();
                //CSP.TooltipsAppearance.Color = Color.White;
                //CSP.TooltipsAppearance.DataFormatString = "{0} عدد";
                //CSP.LabelsAppearance.Visible = true;
                //CSP.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                //Telerik.Web.UI.PieSeriesItem PI;
                //bool Explode = false;
                //for (int i = 0; i < DtReport.Rows.Count; i++)
                //{
                //    if (i == 0)
                //        Explode = true;
                //    else
                //        Explode = false;
                //    PI = new Telerik.Web.UI.PieSeriesItem(Convert.ToDecimal(DtReport.Rows[i]["TCount"].ToString()), GetColor(i), DtReport.Rows[i]["MountName"].ToString(), Explode, true, true);
                //    CSP.SeriesItems.Add(PI);
                //}
                //RadHtmlChartPIE.PlotArea.Series.Add(CSP);

                RadHtmlChartLine.PlotArea.XAxis.Items.Clear();
                RadHtmlChartLine.PlotArea.Series.Clear();
                RadHtmlChartLine.Legend.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartLegendPosition.Bottom;
                RadHtmlChartLine.ChartTitle.Appearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartLine.PlotArea.XAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartLine.PlotArea.YAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartLine.PlotArea.XAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartLine.PlotArea.XAxis.LabelsAppearance.RotationAngle = 45;
                RadHtmlChartLine.PlotArea.YAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartLine.Legend.Appearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartLine.ChartTitle.Text = "";
                //RadHtmlChartLine.PlotArea.XAxis.DataLabelsField = "MountName";
                // for (int i = 0; i < DtReport.Rows.Count; i++)
                // {
                RadHtmlChartLine.PlotArea.XAxis.Items.Add("فروردین");
                RadHtmlChartLine.PlotArea.XAxis.Items.Add("اردیبهشت");
                RadHtmlChartLine.PlotArea.XAxis.Items.Add("خرداد");
                RadHtmlChartLine.PlotArea.XAxis.Items.Add("تیر");
                RadHtmlChartLine.PlotArea.XAxis.Items.Add("مرداد");
                RadHtmlChartLine.PlotArea.XAxis.Items.Add("شهریور");
                RadHtmlChartLine.PlotArea.XAxis.Items.Add("مهر");
                RadHtmlChartLine.PlotArea.XAxis.Items.Add("آبان");
                RadHtmlChartLine.PlotArea.XAxis.Items.Add("آذر");
                RadHtmlChartLine.PlotArea.XAxis.Items.Add("دی");
                RadHtmlChartLine.PlotArea.XAxis.Items.Add("بهمن");
                RadHtmlChartLine.PlotArea.XAxis.Items.Add("اسفند");
                //}
                RadHtmlChartLine.Legend.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartLegendPosition.Left;
                RadHtmlChartLine.Legend.Appearance.Visible = true;
                RadHtmlChartLine.PlotArea.XAxis.TitleAppearance.Text = "ماه ها";
                RadHtmlChartLine.PlotArea.YAxis.TitleAppearance.Text = "میزان درآمد";
                Telerik.Web.UI.LineSeries CSPLine = new Telerik.Web.UI.LineSeries();
                CSPLine.TooltipsAppearance.Color = Color.White;
                CSPLine.TooltipsAppearance.DataFormatString = "{0:N0} عدد";
                CSPLine.LabelsAppearance.Visible = false;
                CSPLine.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                CSPLine.LabelsAppearance.DataFormatString = "{0:N0}";
                //CSPLine.DataFieldY = "TCount";
                int CYear = Convert.ToInt32(DtReport.Rows[0]["YearM"].ToString());
                CSPLine.Name = CYear.ToString();
                int LineCounter = 0;
                for (int i = 0; i < DtReport.Rows.Count; i++)
                {
                    if (CYear == Convert.ToInt32(DtReport.Rows[i]["YearM"].ToString()))
                        CSPLine.SeriesItems.Add(Convert.ToDecimal(DtReport.Rows[i]["TCount"].ToString()));
                    else
                    {
                        CSPLine.Appearance.FillStyle.BackgroundColor = GetColor(LineCounter);
                        LineCounter++;
                        RadHtmlChartLine.PlotArea.Series.Add(CSPLine);
                        // CSPLine.SeriesItems.Clear();
                        CSPLine = new Telerik.Web.UI.LineSeries();
                        CSPLine.TooltipsAppearance.Color = Color.White;
                        CSPLine.TooltipsAppearance.DataFormatString = "{0:N0} عدد";
                        CSPLine.LabelsAppearance.Visible = false;
                        CSPLine.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                        CSPLine.LabelsAppearance.DataFormatString = "{0:N0}";
                        CYear = Convert.ToInt32(DtReport.Rows[i]["YearM"].ToString());
                        CSPLine.Name = CYear.ToString();
                        CSPLine.SeriesItems.Add(Convert.ToDecimal(DtReport.Rows[i]["TCount"].ToString()));
                    }
                }
                CSPLine.Appearance.FillStyle.BackgroundColor = GetColor(LineCounter);
                RadHtmlChartLine.PlotArea.Series.Add(CSPLine);

                #endregion
                #region Income
                //RadHtmlChartCOLIncome.PlotArea.Series.Clear();
                //RadHtmlChartCOLIncome.ChartTitle.Appearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartCOLIncome.PlotArea.XAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartCOLIncome.PlotArea.YAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartCOLIncome.PlotArea.XAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartCOLIncome.PlotArea.YAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartCOLIncome.ChartTitle.Text = "";
                //RadHtmlChartCOLIncome.DataSource = DtReport;
                //RadHtmlChartCOLIncome.PlotArea.XAxis.TitleAppearance.Text = "ماه ها";
                //RadHtmlChartCOLIncome.PlotArea.XAxis.LabelsAppearance.RotationAngle = 45;
                //RadHtmlChartCOLIncome.PlotArea.YAxis.TitleAppearance.Text = "درآمد";
                //RadHtmlChartCOLIncome.PlotArea.XAxis.DataLabelsField = "MountName";
                //Telerik.Web.UI.ColumnSeries CSIncome;
                //CSIncome = new Telerik.Web.UI.ColumnSeries();
                //CSIncome.DataFieldY = "SPrice";
                //CSIncome.LabelsAppearance.DataFormatString = "{0:N0}";
                //CSIncome.Appearance.FillStyle.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#3399ff");
                //CSIncome.TooltipsAppearance.Color = Color.White;
                //CSIncome.TooltipsAppearance.DataFormatString = "{0:N0} ریال";
                //CSIncome.LabelsAppearance.Visible = true;
                //CSIncome.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                ////CS.LabelsAppearance.RotationAngle = 90;
                //RadHtmlChartCOLIncome.PlotArea.Series.Add(CSIncome);
                //RadHtmlChartCOLIncome.DataBind();

                //RadHtmlChartPIEIncome.PlotArea.Series.Clear();
                //RadHtmlChartPIEIncome.ChartTitle.Appearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartPIEIncome.PlotArea.XAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartPIEIncome.PlotArea.YAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartPIEIncome.PlotArea.XAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartPIEIncome.PlotArea.YAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartPIEIncome.Legend.Appearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartPIEIncome.ChartTitle.Text = "";
                //RadHtmlChartPIEIncome.Legend.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartLegendPosition.Left;
                //RadHtmlChartPIEIncome.Legend.Appearance.Visible = true;
                //RadHtmlChartPIEIncome.PlotArea.XAxis.TitleAppearance.Text = "ماه ها";
                //RadHtmlChartPIEIncome.PlotArea.YAxis.TitleAppearance.Text = "درآمد";
                //Telerik.Web.UI.PieSeries CSPIncome = new Telerik.Web.UI.PieSeries();
                //CSPIncome.TooltipsAppearance.Color = Color.White;
                //CSPIncome.TooltipsAppearance.DataFormatString = "{0:N0} ریال";
                //CSPIncome.LabelsAppearance.Visible = true;
                //CSPIncome.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                //CSPIncome.LabelsAppearance.DataFormatString = "{0:N0}";
                //Telerik.Web.UI.PieSeriesItem PIIncome;
                //bool ExplodeIncome = false;
                //for (int i = 0; i < DtReport.Rows.Count; i++)
                //{
                //    if (i == 0)
                //        Explode = true;
                //    else
                //        Explode = false;
                //    PIIncome = new Telerik.Web.UI.PieSeriesItem(Convert.ToDecimal(DtReport.Rows[i]["SPrice"].ToString()), GetColor(i), DtReport.Rows[i]["MountName"].ToString(), ExplodeIncome, true, true);
                //    CSPIncome.SeriesItems.Add(PIIncome);
                //}
                //RadHtmlChartPIEIncome.PlotArea.Series.Add(CSPIncome);

                RadHtmlChartLineINCOME.PlotArea.XAxis.Items.Clear();
                RadHtmlChartLineINCOME.PlotArea.Series.Clear();
                RadHtmlChartLine.Legend.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartLegendPosition.Bottom;
                RadHtmlChartLineINCOME.ChartTitle.Appearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartLineINCOME.PlotArea.XAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartLineINCOME.PlotArea.YAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartLineINCOME.PlotArea.XAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartLineINCOME.PlotArea.YAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartLineINCOME.PlotArea.XAxis.LabelsAppearance.RotationAngle = 45;
                RadHtmlChartLineINCOME.Legend.Appearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartLineINCOME.ChartTitle.Text = "";
                //RadHtmlChartLine.PlotArea.XAxis.DataLabelsField = "MountName";
                //for (int i = 0; i < DtReport.Rows.Count; i++)
                //{
                //    RadHtmlChartLineINCOME.PlotArea.XAxis.Items.Add(DtReport.Rows[i]["MountName"].ToString());
                //}
                RadHtmlChartLineINCOME.PlotArea.XAxis.Items.Add("فروردین");
                RadHtmlChartLineINCOME.PlotArea.XAxis.Items.Add("اردیبهشت");
                RadHtmlChartLineINCOME.PlotArea.XAxis.Items.Add("خرداد");
                RadHtmlChartLineINCOME.PlotArea.XAxis.Items.Add("تیر");
                RadHtmlChartLineINCOME.PlotArea.XAxis.Items.Add("مرداد");
                RadHtmlChartLineINCOME.PlotArea.XAxis.Items.Add("شهریور");
                RadHtmlChartLineINCOME.PlotArea.XAxis.Items.Add("مهر");
                RadHtmlChartLineINCOME.PlotArea.XAxis.Items.Add("آبان");
                RadHtmlChartLineINCOME.PlotArea.XAxis.Items.Add("آذر");
                RadHtmlChartLineINCOME.PlotArea.XAxis.Items.Add("دی");
                RadHtmlChartLineINCOME.PlotArea.XAxis.Items.Add("بهمن");
                RadHtmlChartLineINCOME.PlotArea.XAxis.Items.Add("اسفند");
                RadHtmlChartLineINCOME.Legend.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartLegendPosition.Left;
                RadHtmlChartLineINCOME.Legend.Appearance.Visible = true;
                RadHtmlChartLineINCOME.PlotArea.XAxis.TitleAppearance.Text = "ماه ها";
                RadHtmlChartLineINCOME.PlotArea.YAxis.TitleAppearance.Text = "میزان درآمد";
                Telerik.Web.UI.LineSeries CSPLineINCOME = new Telerik.Web.UI.LineSeries();
                CSPLineINCOME.TooltipsAppearance.Color = Color.White;
                CSPLineINCOME.TooltipsAppearance.DataFormatString = "{0:N0} ریال";
                CSPLineINCOME.LabelsAppearance.Visible = false;
                CSPLineINCOME.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                CSPLineINCOME.LabelsAppearance.DataFormatString = "{0:N0}";
                //CSPLine.DataFieldY = "TCount";
                int CYearINCOME = Convert.ToInt32(DtReport.Rows[0]["YearM"].ToString());
                CSPLineINCOME.Name = CYearINCOME.ToString();
                int IncomeLineCounter = 0;
                for (int i = 0; i < DtReport.Rows.Count; i++)
                {
                    //CSPLineINCOME.SeriesItems.Add(Convert.ToDecimal(DtReport.Rows[i]["SPrice"].ToString()));
                    if (CYearINCOME == Convert.ToInt32(DtReport.Rows[i]["YearM"].ToString()))
                        CSPLineINCOME.SeriesItems.Add(Convert.ToDecimal(DtReport.Rows[i]["SPrice"].ToString()));
                    else
                    {
                        CSPLineINCOME.Appearance.FillStyle.BackgroundColor = GetColor(IncomeLineCounter);
                        IncomeLineCounter++;
                        RadHtmlChartLineINCOME.PlotArea.Series.Add(CSPLineINCOME);
                        //CSPLineINCOME.SeriesItems.Clear();
                        CSPLineINCOME = new Telerik.Web.UI.LineSeries();
                        CSPLineINCOME.TooltipsAppearance.Color = Color.White;
                        CSPLineINCOME.TooltipsAppearance.DataFormatString = "{0:N0} ریال";
                        CSPLineINCOME.LabelsAppearance.Visible = false;
                        CSPLineINCOME.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                        CSPLineINCOME.LabelsAppearance.DataFormatString = "{0:N0}";
                        CYearINCOME = Convert.ToInt32(DtReport.Rows[i]["YearM"].ToString());
                        CSPLineINCOME.Name = CYearINCOME.ToString();
                        CSPLineINCOME.SeriesItems.Add(Convert.ToDecimal(DtReport.Rows[i]["SPrice"].ToString()));
                    }
                }
                CSPLineINCOME.Appearance.FillStyle.BackgroundColor = GetColor(IncomeLineCounter);
                RadHtmlChartLineINCOME.PlotArea.Series.Add(CSPLineINCOME);
                //RadHtmlChartLineINCOME.PlotArea.Series.Add(CSPLineINCOME);
                #endregion
            }
            else
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('اطلاعاتی موجود نمی باشد');", "ErMessage");
            }

        }

        public void GetReportOneYear(int FromYear)
        {
            string WhereStr = "";
            if (ClassLibrary.JDateTime.FarsiYear(DateTime.Now) == FromYear.ToString())
                WhereStr = @"and substring(dbo.dateentofa(date),6,2) <= " + ClassLibrary.JDateTime.FarsiMonth(DateTime.Now);
            DataTable DtReport = WebClassLibrary.JWebDataBase.GetDataTable(@"select A.TCount,A.SPrice,
                                                                                case A.Mount 
                                                                                when 1 then N'فروردین'+ ' '  + cast(B.B as nvarchar) + '  '+N'اتوبوس'
                                                                                when 2 then N'اردیبهشت'+ ' '  + cast(B.B as nvarchar) + '  '+N'اتوبوس'
                                                                                when 3 then N'خرداد'+ ' '  + cast(B.B as nvarchar) + '  '+N'اتوبوس'
                                                                                when 4 then N'تیر'+ ' '  + cast(B.B as nvarchar) + '  '+N'اتوبوس'
                                                                                when 5 then N'مرداد'+ ' '  + cast(B.B as nvarchar) + '  '+N'اتوبوس'
                                                                                when 6 then N'شهریور'+ ' '  + cast(B.B as nvarchar) + '  '+N'اتوبوس'
                                                                                when 7 then N'مهر'+ ' '  + cast(B.B as nvarchar) + '  '+N'اتوبوس'
                                                                                when 8 then N'آبان'+ ' '  + cast(B.B as nvarchar) + '  '+N'اتوبوس'
                                                                                when 9 then N'آذر'+ ' '  + cast(B.B as nvarchar) + '  '+N'اتوبوس'
                                                                                when 10 then N'دی'+ ' '  + cast(B.B as nvarchar) + '  '+N'اتوبوس'
                                                                                when 11 then N'بهمن'+ ' '  + cast(B.B as nvarchar) + '  '+N'اتوبوس'
                                                                                when 12 then N'اسفند'+ ' '  + cast(B.B as nvarchar) + '  '+N'اتوبوس'
                                                                                end MountName 
                                                                                from (
                                                                                select substring(dbo.dateentofa(date),6,2)Mount,sum(tcount)TCount,sum(cast((tcount * ticketprice) as float)) * 10.0 SPrice
                                                                                from AUTDailyPerformanceRportOnBus AU
                                                                                where substring(dbo.dateentofa(date),1,4) = " + FromYear + @"
                                                                                and CardType = 0 and TicketPrice > 0
                                                                                " + WhereStr + @" and AU.BusCode in (select Code from AUTBus where FleetCode = 1000001 and Active = 1 and IsValid = 1) and AU.TCount > 0 and AU.Price > 0 and AU.TicketPrice > 0 and AU.Error = 0 
                                                                                group by substring(dbo.dateentofa(date),6,2)
                                                                                )A
                                                                                left join (
                                                                                select M,count(*)B from (
                                                                                select substring(dbo.dateentofa(date),6,2)M,BusNumber from AUTDailyPerformanceRportOnBus
                                                                                where substring(dbo.dateentofa(date),1,4) = " + FromYear + @"
                                                                                and CardType = 0 and BusCode in (select Code from AUTBus where FleetCode = 1000001 and Active = 1 and IsValid = 1) and TCount > 0 and Price > 0 and TicketPrice > 0 and Error = 0 
                                                                                " + WhereStr + @"
                                                                                group by substring(dbo.dateentofa(date),6,2),busnumber
                                                                                )BusCounter
                                                                                group by M
                                                                                )B on A.Mount = B.M
                                                                                order by A.Mount");
            if (DtReport != null)
            {
                #region Transaction
                //RadHtmlChartCOL.PlotArea.Series.Clear();
                //RadHtmlChartCOL.ChartTitle.Appearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartCOL.PlotArea.XAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartCOL.PlotArea.YAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartCOL.PlotArea.XAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartCOL.PlotArea.YAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartCOL.ChartTitle.Text = "";
                //RadHtmlChartCOL.DataSource = DtReport;
                //RadHtmlChartCOL.PlotArea.XAxis.TitleAppearance.Text = "ماه ها";
                //RadHtmlChartCOL.PlotArea.XAxis.LabelsAppearance.RotationAngle = 45;
                //RadHtmlChartCOL.PlotArea.YAxis.TitleAppearance.Text = "تعداد تراکنش";
                //RadHtmlChartCOL.PlotArea.XAxis.DataLabelsField = "MountName";
                //Telerik.Web.UI.ColumnSeries CS;
                //CS = new Telerik.Web.UI.ColumnSeries();
                //CS.DataFieldY = "TCount";
                //CS.Appearance.FillStyle.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#3399ff");
                //CS.TooltipsAppearance.Color = Color.White;
                //CS.TooltipsAppearance.DataFormatString = "{0:N0} عدد";
                //CS.LabelsAppearance.Visible = true;
                //CS.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                //CS.LabelsAppearance.DataFormatString = "{0:N0}";
                ////CS.LabelsAppearance.RotationAngle = 90;
                //RadHtmlChartCOL.PlotArea.Series.Add(CS);
                //RadHtmlChartCOL.DataBind();

                //RadHtmlChartPIE.PlotArea.Series.Clear();
                //RadHtmlChartPIE.ChartTitle.Appearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartPIE.PlotArea.XAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartPIE.PlotArea.YAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartPIE.PlotArea.XAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartPIE.PlotArea.YAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartPIE.Legend.Appearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartPIE.ChartTitle.Text = "";
                //RadHtmlChartPIE.Legend.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartLegendPosition.Left;
                //RadHtmlChartPIE.Legend.Appearance.Visible = true;
                //RadHtmlChartPIE.PlotArea.XAxis.TitleAppearance.Text = "ماه ها";
                //RadHtmlChartPIE.PlotArea.YAxis.TitleAppearance.Text = "تعداد تراکنش";
                //Telerik.Web.UI.PieSeries CSP = new Telerik.Web.UI.PieSeries();
                //CSP.TooltipsAppearance.Color = Color.White;
                //CSP.TooltipsAppearance.DataFormatString = "{0:N0} عدد";
                //CSP.LabelsAppearance.Visible = true;
                //CSP.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                //CSP.LabelsAppearance.DataFormatString = "{0:N0}";
                //Telerik.Web.UI.PieSeriesItem PI;
                //bool Explode = false;
                //for (int i = 0; i < DtReport.Rows.Count; i++)
                //{
                //    if (i == 0)
                //        Explode = true;
                //    else
                //        Explode = false;
                //    PI = new Telerik.Web.UI.PieSeriesItem(Convert.ToDecimal(DtReport.Rows[i]["TCount"].ToString()), GetColor(i), DtReport.Rows[i]["MountName"].ToString(), Explode, true, true);
                //    CSP.SeriesItems.Add(PI);
                //}
                //RadHtmlChartPIE.PlotArea.Series.Add(CSP);

                RadHtmlChartLine.PlotArea.XAxis.Items.Clear();
                RadHtmlChartLine.PlotArea.Series.Clear();
                RadHtmlChartLine.ChartTitle.Appearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartLine.PlotArea.XAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartLine.PlotArea.YAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartLine.PlotArea.XAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartLine.PlotArea.YAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartLine.Legend.Appearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartLine.ChartTitle.Text = "";
                //RadHtmlChartLine.PlotArea.XAxis.DataLabelsField = "MountName";
                for (int i = 0; i < DtReport.Rows.Count; i++)
                {
                    RadHtmlChartLine.PlotArea.XAxis.Items.Add(DtReport.Rows[i]["MountName"].ToString());
                }
                RadHtmlChartLine.Legend.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartLegendPosition.Left;
                RadHtmlChartLine.Legend.Appearance.Visible = true;
                RadHtmlChartLine.PlotArea.XAxis.TitleAppearance.Text = "ماه ها";
                RadHtmlChartLine.PlotArea.YAxis.TitleAppearance.Text = "تعداد تراکنش";
                Telerik.Web.UI.LineSeries CSPLine = new Telerik.Web.UI.LineSeries();
                CSPLine.TooltipsAppearance.Color = Color.White;
                CSPLine.TooltipsAppearance.DataFormatString = "{0:N0} عدد";
                CSPLine.LabelsAppearance.Visible = true;
                CSPLine.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                //CSPLine.DataFieldY = "TCount";
                for (int i = 0; i < DtReport.Rows.Count; i++)
                {
                    CSPLine.SeriesItems.Add(Convert.ToDecimal(DtReport.Rows[i]["TCount"].ToString()));
                }
                RadHtmlChartLine.PlotArea.Series.Add(CSPLine);

                #endregion
                #region Income
                //RadHtmlChartCOLIncome.PlotArea.Series.Clear();
                //RadHtmlChartCOLIncome.ChartTitle.Appearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartCOLIncome.PlotArea.XAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartCOLIncome.PlotArea.YAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartCOLIncome.PlotArea.XAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartCOLIncome.PlotArea.YAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartCOLIncome.ChartTitle.Text = "";
                //RadHtmlChartCOLIncome.DataSource = DtReport;
                //RadHtmlChartCOLIncome.PlotArea.XAxis.TitleAppearance.Text = "ماه ها";
                //RadHtmlChartCOLIncome.PlotArea.XAxis.LabelsAppearance.RotationAngle = 45;
                //RadHtmlChartCOLIncome.PlotArea.YAxis.TitleAppearance.Text = "درآمد";
                //RadHtmlChartCOLIncome.PlotArea.XAxis.DataLabelsField = "MountName";
                //Telerik.Web.UI.ColumnSeries CSIncome;
                //CSIncome = new Telerik.Web.UI.ColumnSeries();
                //CSIncome.DataFieldY = "SPrice";
                //CSIncome.LabelsAppearance.DataFormatString = "{0:N0}";
                //CSIncome.Appearance.FillStyle.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#3399ff");
                //CSIncome.TooltipsAppearance.Color = Color.White;
                //CSIncome.TooltipsAppearance.DataFormatString = "{0:N0} ریال";
                //CSIncome.LabelsAppearance.Visible = true;
                //CSIncome.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                ////CS.LabelsAppearance.RotationAngle = 90;
                //RadHtmlChartCOLIncome.PlotArea.Series.Add(CSIncome);
                //RadHtmlChartCOLIncome.DataBind();

                //RadHtmlChartPIEIncome.PlotArea.Series.Clear();
                //RadHtmlChartPIEIncome.ChartTitle.Appearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartPIEIncome.PlotArea.XAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartPIEIncome.PlotArea.YAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartPIEIncome.PlotArea.XAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartPIEIncome.PlotArea.YAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartPIEIncome.Legend.Appearance.TextStyle.FontFamily = "MyBYekan";
                //RadHtmlChartPIEIncome.ChartTitle.Text = "";
                //RadHtmlChartPIEIncome.Legend.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartLegendPosition.Left;
                //RadHtmlChartPIEIncome.Legend.Appearance.Visible = true;
                //RadHtmlChartPIEIncome.PlotArea.XAxis.TitleAppearance.Text = "ماه ها";
                //RadHtmlChartPIEIncome.PlotArea.YAxis.TitleAppearance.Text = "درآمد";
                //Telerik.Web.UI.PieSeries CSPIncome = new Telerik.Web.UI.PieSeries();
                //CSPIncome.TooltipsAppearance.Color = Color.White;
                //CSPIncome.TooltipsAppearance.DataFormatString = "{0:N0} ریال";
                //CSPIncome.LabelsAppearance.Visible = true;
                //CSPIncome.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                //CSPIncome.LabelsAppearance.DataFormatString = "{0:N0}";
                //Telerik.Web.UI.PieSeriesItem PIIncome;
                //bool ExplodeIncome = false;
                //for (int i = 0; i < DtReport.Rows.Count; i++)
                //{
                //    if (i == 0)
                //        Explode = true;
                //    else
                //        Explode = false;
                //    PIIncome = new Telerik.Web.UI.PieSeriesItem(Convert.ToDecimal(DtReport.Rows[i]["SPrice"].ToString()), GetColor(i), DtReport.Rows[i]["MountName"].ToString(), ExplodeIncome, true, true);
                //    CSPIncome.SeriesItems.Add(PIIncome);
                //}
                //RadHtmlChartPIEIncome.PlotArea.Series.Add(CSPIncome);

                RadHtmlChartLineINCOME.PlotArea.XAxis.Items.Clear();
                RadHtmlChartLineINCOME.PlotArea.Series.Clear();
                RadHtmlChartLineINCOME.ChartTitle.Appearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartLineINCOME.PlotArea.XAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartLineINCOME.PlotArea.YAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartLineINCOME.PlotArea.XAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartLineINCOME.PlotArea.YAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartLineINCOME.Legend.Appearance.TextStyle.FontFamily = "MyBYekan";
                RadHtmlChartLineINCOME.ChartTitle.Text = "";
                //RadHtmlChartLine.PlotArea.XAxis.DataLabelsField = "MountName";
                for (int i = 0; i < DtReport.Rows.Count; i++)
                {
                    RadHtmlChartLineINCOME.PlotArea.XAxis.Items.Add(DtReport.Rows[i]["MountName"].ToString());
                }
                RadHtmlChartLineINCOME.Legend.Appearance.Position = Telerik.Web.UI.HtmlChart.ChartLegendPosition.Left;
                RadHtmlChartLineINCOME.Legend.Appearance.Visible = true;
                RadHtmlChartLineINCOME.PlotArea.XAxis.TitleAppearance.Text = "ماه ها";
                RadHtmlChartLineINCOME.PlotArea.YAxis.TitleAppearance.Text = "درآمد";
                Telerik.Web.UI.LineSeries CSPLineINCOME = new Telerik.Web.UI.LineSeries();
                CSPLineINCOME.TooltipsAppearance.Color = Color.White;
                CSPLineINCOME.TooltipsAppearance.DataFormatString = "{0:N0} ریال";
                CSPLineINCOME.LabelsAppearance.Visible = true;
                CSPLineINCOME.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                CSPLineINCOME.LabelsAppearance.DataFormatString = "{0:N0}";
                //CSPLine.DataFieldY = "TCount";
                for (int i = 0; i < DtReport.Rows.Count; i++)
                {
                    CSPLineINCOME.SeriesItems.Add(Convert.ToDecimal(DtReport.Rows[i]["SPrice"].ToString()));
                }
                RadHtmlChartLineINCOME.PlotArea.Series.Add(CSPLineINCOME);
                #endregion
            }
            else
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('اطلاعاتی موجود نمی باشد');", "ErMessage");
            }

        }

        public static Color GetColor(int index)
        {
            try { return colors[index]; }
            catch
            {
                return colors[index % colors.Length];
            }
        }

        /// <summary>
        /// The list of hardcoded colors.
        /// </summary>
        /// <remarks>
        /// Can be extended manually by the developer or the class can be modified so that the property can be modified during runtime.
        /// </remarks>
        private static readonly Color[] colors =
        {
            Color.Green,
            Color.Blue,
            Color.Red,
            Color.Violet,
            Color.Chocolate,
            Color.Black,
            Color.DarkCyan,
            Color.DarkSlateBlue,
        };

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbFromYear.SelectedValue == cmbToYear.SelectedValue)
                GetReportOneYear(Convert.ToInt32(cmbFromYear.SelectedValue));
            else
                GetReport(Convert.ToInt32(cmbFromYear.SelectedValue), Convert.ToInt32(cmbToYear.SelectedValue));
        }
    }
}