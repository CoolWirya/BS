using System;
using System.Drawing;
using System.Data;
using System.Web;
using System.Web.UI;
using ProjectManagement;
using System.IO;
using iTextSharp.text.pdf;

namespace WebProjectManagement.Forms
{
    public partial class TotalReportProjectsChart : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadChartStuffs();
            if (!IsPostBack)
            {
                ((WebControllers.MainControls.Date.JDateControl)dateFirst).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)dateSecond).SetDate(DateTime.Now);
                cmbProjects.DataSource = ProjectManagement.Project.JProjects.GetDataTable(true);
                cmbProjects.DataTextField = "Name";
                cmbProjects.DataValueField = "Code";
                cmbProjects.DataBind();
                cmbProjects.SelectedIndex = 0;
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
            string query = "";
            query = @"
SELECT f.Code,f.Name,convert(date,f.FirstDate) as FirstDate,
CAST((CASE WHEN SUM(f.FirstTotalImprovement) IS NULL THEN 0 
ELSE SUM(f.FirstTotalImprovement) END)  as numeric(36,2)) as FirstTotalImprovement,
 Convert(date,f.SecondDate) as SecondDate,cast(SUM(f.SecondTotalImprovement) as numeric(36,2)) as SecondTotalImprovement
FROM 
(
SELECT p.Code,p.Name,
 CONVERT(datetime,N'{1}') as FirstDate,
 ((SELECT SUM(ir.WeightPercentage) FROM pmItemReport ir 
 WHERE ir.ItemCode=i .code AND RegisterDate BETWEEN N'{0}' AND N'{1}' )*i.WeightPercentage/100 ) AS FirstTotalImprovement ,
 CONVERT(datetime, N'{2}') AS SecondDate,
 ((SELECT SUM(ir.WeightPercentage) FROM pmItemReport ir 
 WHERE ir.ItemCode=i.code AND RegisterDate BETWEEN N'{0}' AND N'{2}')*i.WeightPercentage/100 )AS SecondTotalImprovement 
 FROM 
 pmItems i 
inner join pmProjects p on p.Code=i.ProjectCode
WHERE i.Code in (select Code from pmItems where Code not in (select ParentItemCode from pmItems) AND i.ProjectCode=p.Code)
) as f where f.Code={3}
group by f.Code,f.Name,f.FirstDate, f.SecondDate ";
            query = string.Format(query,
  "1-1-1900 12:00:00",
  ((WebControllers.MainControls.Date.JDateControl)dateFirst).GetDate().AddHours(23).AddMinutes(59),
  ((WebControllers.MainControls.Date.JDateControl)dateSecond).GetDate().AddHours(23).AddMinutes(59),
  cmbProjects.SelectedValue);
            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(query);
            DataTable DtReport = new DataTable();
            DtReport.Columns.Add("Date");
            DtReport.Columns.Add("TotalImprovement");
            DtReport.Rows.Add(dt.Rows[0]["FirstDate"].ToString(), dt.Rows[0]["FirstTotalImprovement"].ToString());
            DtReport.Rows.Add(dt.Rows[0]["SecondDate"].ToString(), dt.Rows[0]["SecondTotalImprovement"].ToString());
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
                RadHtmlChartCOL.PlotArea.XAxis.TitleAppearance.Text = "Date";
                //RadHtmlChartCOL.PlotArea.XAxis.LabelsAppearance.RotationAngle = 45;
                RadHtmlChartCOL.PlotArea.YAxis.TitleAppearance.Text = "Reported Data";
                RadHtmlChartCOL.PlotArea.XAxis.DataLabelsField = "Date";
                Telerik.Web.UI.ColumnSeries CS;
                CS = new Telerik.Web.UI.ColumnSeries();
                CS.DataFieldY = "TotalImprovement";
                CS.Appearance.FillStyle.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#3399ff");
                CS.TooltipsAppearance.Color = System.Drawing.Color.White;
                CS.TooltipsAppearance.DataFormatString = "{0:N0} درصد";
                CS.LabelsAppearance.DataFormatString = "{0:N0}";
                CS.LabelsAppearance.Visible = true;
                CS.LabelsAppearance.TextStyle.FontFamily = "MyBYekan";
                // CS.LabelsAppearance.RotationAngle = 90;
                RadHtmlChartCOL.PlotArea.Series.Add(CS);
                RadHtmlChartCOL.DataBind();
                btnDownloadPDF.Enabled = true;
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

        protected void btnDownloadPDF_Click(object sender, EventArgs e)
        {
            string query = "";
            query = @"
SELECT f.Code,f.Name,f.FirstDate,
(CASE WHEN SUM(f.FirstTotalImprovement) IS NULL THEN 0 
ELSE SUM(f.FirstTotalImprovement) END) as FirstTotalImprovement,
 f.SecondDate,SUM(f.SecondTotalImprovement) as SecondTotalImprovement
FROM 
(
SELECT p.Code,p.Name,
 CONVERT(datetime,N'{1}') as FirstDate,
 ((SELECT SUM(ir.WeightPercentage) FROM pmItemReport ir 
 WHERE ir.ItemCode=i .code AND RegisterDate BETWEEN N'{0}' AND N'{1}' )*i.WeightPercentage/100 ) AS FirstTotalImprovement ,
 CONVERT(datetime, N'{2}') AS SecondDate,
 ((SELECT SUM(ir.WeightPercentage) FROM pmItemReport ir 
 WHERE ir.ItemCode=i.code AND RegisterDate BETWEEN N'{0}' AND N'{2}')*i.WeightPercentage/100 )AS SecondTotalImprovement 
 FROM 
 pmItems i 
inner join pmProjects p on p.Code=i.ProjectCode
WHERE i.Code in (select Code from pmItems where Code not in (select ParentItemCode from pmItems) AND i.ProjectCode=p.Code)
) as f where f.Code={3}
group by f.Code,f.Name,f.FirstDate, f.SecondDate ";
            query = string.Format(query,
  "1-1-1900 12:00:00",
  ((WebControllers.MainControls.Date.JDateControl)dateFirst).GetDate().AddHours(23).AddMinutes(59),
  ((WebControllers.MainControls.Date.JDateControl)dateSecond).GetDate().AddHours(23).AddMinutes(59),
  cmbProjects.SelectedValue);
            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(query);

            if (dt == null || dt.Rows.Count < 1) return;
            iTextSharp.text.Rectangle rec2 = new iTextSharp.text.Rectangle(iTextSharp.text.PageSize.A4);
            iTextSharp.text.Document doc = new iTextSharp.text.Document(rec2);
            FileStream fs = null;
            string Path = HttpContext.Current.Server.MapPath("~/Reports/Reoprt_" + ClassLibrary.JMainFrame.CurrentUserCode + ".pdf");
            try
            {
                fs = new FileStream(Path, FileMode.Create, FileAccess.Write, FileShare.None);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();
                string fontPath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\tahoma.ttf";
                BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font tahomaFont = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, iTextSharp.text.Color.BLACK);

                DataRow dr = dt.Rows[0];

                ColumnText ct = new ColumnText(writer.DirectContent);
                ct.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                ct.SetSimpleColumn(rec2.Width-10, 500, 400, 800, 24, iTextSharp.text.Element.ALIGN_RIGHT);
                ct.AddText(new iTextSharp.text.Chunk("گزارش پیشرفت : ", tahomaFont));
                ct.AddText(new iTextSharp.text.Chunk(dr["Name"].ToString(), tahomaFont));
                ct.Go();

                ColumnText ct2 = new ColumnText(writer.DirectContent);
                ct2.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                ct2.SetSimpleColumn(100, 50, rec2.Width, 750, 24, iTextSharp.text.Element.ALIGN_RIGHT);
                ct2.AddText(new iTextSharp.text.Chunk(dr["FirstDate"].ToString() + " :            ", tahomaFont));
                ct2.AddText(new iTextSharp.text.Chunk(dr["FirstTotalImprovement"].ToString(), tahomaFont));
                ct2.Go();

                ColumnText ct3 = new ColumnText(writer.DirectContent);
                ct3.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                ct3.SetSimpleColumn(100, 50, rec2.Width, 700, 24, iTextSharp.text.Element.ALIGN_RIGHT);
                ct3.AddText(new iTextSharp.text.Chunk(dr["SecondDate"].ToString() + " :            ", tahomaFont));
                ct3.AddText(new iTextSharp.text.Chunk(dr["SecondTotalImprovement"].ToString(), tahomaFont));
                ct3.Go();

            }
            catch (Exception er)
            {

            }
            finally
            {
                //     if (doc.PageNumber > 0)
                doc.Close();
                Response.ContentType = "application/pdf";
                Response.WriteFile(Path);
                //    if (fs != null) fs.Close();
            }

        }

        private void AddColumntText(PdfWriter writer,string text, iTextSharp.text.Font font)
        {
            ColumnText ct = new ColumnText(writer.DirectContent);
            ct.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            ct.SetSimpleColumn(100, 100, 500, 800, 24, iTextSharp.text.Element.ALIGN_RIGHT);
            ct.AddText(new iTextSharp.text.Chunk(text, font));
            ct.Go();
        }
    }
}