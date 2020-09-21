using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf.IO;
using ClassLibrary.DataBase;
using WebClassLibrary;
using System.Data;
using System.Web.Services;
using System.Web.SessionState;

namespace WebERP.Services.ProjectManagementStuffs
{
    /// <summary>
    /// Summary description for PdfGenerator
    /// </summary>
    public class PdfGenerator : IHttpHandler, IReadOnlySessionState
    {
        [WebMethod(EnableSession = true)]
        public void ProcessRequest(HttpContext context)
        {
            string s = "";
            string className = context.Request.QueryString["className"];
            int objectCode = int.Parse(context.Request.QueryString["objectCode"]);
            string parameters = context.Request.QueryString["parameters"];
            object[] _params = parameters.Split(',').Select(x => Convert.ChangeType(x, typeof(object))).ToArray();
            string sql = "";//context.Request.QueryString["sql"].Replace("?!?", "'");
            JQuery jQuery = new JQuery(className, objectCode, _params);
            sql = string.IsNullOrWhiteSpace(jQuery.QueryText) ? sql : jQuery.QueryText;
            DataTable table = JWebDataBase.GetDataTable(sql);

            PdfDocument document = new PdfDocument();
            document.Info.Title = "PDF Report";
            string text = "";

            if (table != null)
            {
                foreach (DataColumn dc in table.Columns)
                    text += dc.ColumnName + " | ";
                text += "\n";
                int i = 0;
                foreach (DataRow dr in table.Rows)
                {
                    for (i = 0; i < dr.ItemArray.Length; i++)
                        text += dr.ItemArray[i] + " | ";
                    text += "\n";
                }
            }



            // Sample uses DIN A4, page height is 29.7 cm. We use margins of 2.5 cm.
            LayoutHelper helper = new LayoutHelper(document, XUnit.FromCentimeter(1), XUnit.FromCentimeter(29.7 - .5));
            XUnit left = XUnit.FromCentimeter(.5);

            Random r = new Random();

            const int headerFontSize = 14;
            const int normalFontSize = 10;

            XFont fontHeader = new XFont("Arial", headerFontSize, XFontStyle.BoldItalic);
            XFont fontNormal = new XFont("Arial", normalFontSize,XFontStyle.Regular,new XPdfFontOptions(PdfFontEncoding.Unicode));

            XTextFormatter formatter = null;

            int line;
            int requested = headerFontSize + 2 + normalFontSize, required = headerFontSize + 5;
            //Header
            XUnit top = helper.GetLinePosition(requested, required);
            formatter = new XTextFormatter(helper.Gfx);
            formatter.DrawString("Report", fontHeader, XBrushes.Black, new XRect(left, top, helper.Page.Width, helper.Page.Height), XStringFormats.TopLeft);
          

            //content
            XPen pen = new XPen(XColor.FromName("BLACK"), 1);
            XBrush brush = new XSolidBrush(XColor.FromArgb(20));
            string[] lines = text.Split('\n');
            for (line = 0; line < lines.Length; ++line)
            {

                requested = normalFontSize + 2+ ((int)formatter.Font.GetHeight());
                required = normalFontSize;
                top = helper.GetLinePosition(requested, required);

                //helper.Gfx.DrawRectangle(new XSolidBrush(XColor.FromArgb(255-(line+r.Next(2,245)),line+ r.Next(2, 205), line + r.Next(2, 205))),
                //    new XRect(left,top, helper.Page.Width, top + formatter.Font.GetHeight()));
                helper.Gfx.DrawLine(pen, left, top , helper.Page.Width, top );

                formatter = new XTextFormatter(helper.Gfx);
                formatter.DrawString(lines[line], fontNormal, XBrushes.Black,
  new XRect(left, top, helper.Page.Width, helper.Page.Height), XStringFormats.TopLeft);





            }
            

            // Save the document...

            string Path = HttpContext.Current.Server.MapPath("~/Reports/Reoprt_" + ClassLibrary.JMainFrame.CurrentPostCode + ".pdf");
            document.Save(Path);

            context.Response.ContentType = "application/pdf";
            context.Response.WriteFile(Path);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
    public class LayoutHelper
    {
        private readonly PdfDocument _document;
        private readonly XUnit _topPosition;
        private readonly XUnit _bottomMargin;
        private XUnit _currentPosition;

        public LayoutHelper(PdfDocument document, XUnit topPosition, XUnit bottomMargin)
        {
            _document = document;
            _topPosition = topPosition;
            _bottomMargin = bottomMargin;
            // Set a value outside the page - a new page will be created on the first request.
            _currentPosition = bottomMargin + 10000;
        }

        public XUnit GetLinePosition(XUnit requestedHeight)
        {
            return GetLinePosition(requestedHeight, -1f);
        }

        public XUnit GetLinePosition(XUnit requestedHeight, XUnit requiredHeight)
        {
            XUnit required = requiredHeight == -1f ? requestedHeight : requiredHeight;
            if (_currentPosition + required > _bottomMargin)
                CreatePage();
            XUnit result = _currentPosition;
            _currentPosition += requestedHeight;
            return result;
        }

        public XGraphics Gfx { get; private set; }
        public PdfPage Page { get; private set; }

        void CreatePage()
        {
            Page = _document.AddPage();
            Page.Size = PageSize.A4;
            Gfx = XGraphics.FromPdfPage(Page);
            _currentPosition = _topPosition;
        }
    }
}