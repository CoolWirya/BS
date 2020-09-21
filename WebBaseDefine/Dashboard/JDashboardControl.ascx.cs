using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBaseDefine.Dashboard
{
    public partial class JDashboardControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (IsPostBack)
            //    return;
            //columnChartMethod();
            //columnChartTimer.Interval = 10 * 1000;
            //columnChartTimer.Enabled = true;
        }

        void columnChartMethod()
        {
     //       DataTable DtReport = WebClassLibrary.JWebDataBase.GetDataTable(
     //           @"select top 100 percent max(DP.Code)Code,DP.[Date] as DateEventDate,sum(cast(DP.TCount as float)) as TransactionCount,
     //               sum(cast(DP.Price as float)) * 10 as InCome
     //               from [dbo].[AUTDailyPerformanceRportOnBus] DP
					//WHERE DP.[Date] between GETDATE() - 30 AND GETDATE() and DP.BusCode in (select Code from AUTBus where FleetCode = 1000001 and Active = 1 and IsValid = 1) and DP.TCount > 0 and DP.Price > 0 and DP.TicketPrice > 0 and DP.Error = 0
					//group by DP.[Date]");
     //       RadHtmlChartColumn.PlotArea.Series.Clear();
     //       RadHtmlChartColumn.ChartTitle.Appearance.TextStyle.FontFamily = "MyBYekan";
     //       RadHtmlChartColumn.PlotArea.XAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
     //       RadHtmlChartColumn.PlotArea.YAxis.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
     //       RadHtmlChartColumn.PlotArea.XAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
     //       RadHtmlChartColumn.PlotArea.YAxis.TitleAppearance.TextStyle.FontFamily = "MyBYekan";
     //       RadHtmlChartColumn.ChartTitle.Text = "";
     //       RadHtmlChartColumn.DataSource = DtReport;
     //       RadHtmlChartColumn.PlotArea.XAxis.TitleAppearance.Text = "تاریخ";
     //       RadHtmlChartColumn.PlotArea.XAxis.LabelsAppearance.RotationAngle = 45;
     //       RadHtmlChartColumn.PlotArea.YAxis.TitleAppearance.Text = "تعداد تراکنش";
     //       RadHtmlChartColumn.PlotArea.XAxis.DataLabelsField = "DateEventDate";
     //       Telerik.Web.UI.ColumnSeries CS;
     //       CS = new Telerik.Web.UI.ColumnSeries();
     //       CS.DataFieldY = "TransactionCount";
     //       CS.Appearance.FillStyle.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#3399ff");
     //       CS.TooltipsAppearance.Color = Color.White;
     //       CS.TooltipsAppearance.DataFormatString = "{0:N0} عدد";
     //       CS.LabelsAppearance.Visible = true;
     //       CS.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
     //       CS.LabelsAppearance.RotationAngle = 90;
     //       CS.LabelsAppearance.DataFormatString = "{0:N0}";
     //       RadHtmlChartColumn.PlotArea.Series.Add(CS);
     //       RadHtmlChartColumn.DataBind();
        }

        protected void columnChartTimer_Tick(object sender, EventArgs e)
        {
            columnChartMethod();
        }
    }
}