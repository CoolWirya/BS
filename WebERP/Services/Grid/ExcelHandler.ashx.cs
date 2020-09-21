using ClassLibrary;
using ClassLibrary.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using WebClassLibrary;
//using Excel = Microsoft.Office.Interop.Excel;

namespace WebERP.Services
{
    /// <summary>
    /// Summary description for ExcelHandler
    /// </summary>
    public class ExcelHandler : IHttpHandler, IReadOnlySessionState
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
            if (table.Rows.Count < 500)
            {
                //HttpContext.Current.Response.ContentType = "application/ms-excel";
                s += @"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">";
                context.Response.Clear();
                context.Response.AddHeader("Content-Disposition", "attachment;filename=Reports.xls");
                context.Response.AddHeader("Content-type", "application/vnd.ms-excel");
                context.Response.ContentEncoding = System.Text.Encoding.UTF8;
                context.Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());
                HttpContext.Current.Response.Buffer = true;
                //HttpContext.Current.Response.Charset = "utf-8";
                //HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
                s += "<font style='font-size:10.0pt; font-family:Calibri;'>";
                s += "<BR><BR><BR>";
                s += "<Table border='1' bgColor='#ffffff' " +
                  "borderColor='#000000' cellSpacing='0' cellPadding='0' " +
                  "style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>";
                int columnscount = table.Columns.Count;
                for (int j = 0; j < columnscount; j++)
                {
                    s += "<Td>";
                    s += "<B>";
                    s += JLanguages._Text(table.Columns[j].ColumnName);
                    s += "</B>";
                    s += "</Td>";
                }
                s += "</TR>";
                foreach (DataRow row in table.Rows)
                {
                    s += "<TR>";
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        s += "<Td>";
                        s += row[i].ToString();
                        s += "</Td>";
                    }

                    s += "</TR>";
                }
                s += "</Table>";
                s += "</font>";
                try
                {
                    context.Response.Write(s);
                    context.Response.Flush();
                    context.Response.End();
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                #region interop
                //Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                //xlApp.DisplayAlerts = false;

                //Excel.Workbook xlWorkBook;
                //Excel.Worksheet xlWorkSheet;
                //object misValue = System.Reflection.Missing.Value;

                //xlWorkBook = xlApp.Workbooks.Add(misValue);
                //xlWorkSheet = xlWorkBook.Worksheets.get_Item(1) as Excel.Worksheet;
                //xlWorkSheet.DisplayRightToLeft = true;

                //xlWorkSheet.Cells[1, 1] = "Your title here";

                ////Span the title across columns A through H
                //Microsoft.Office.Interop.Excel.Range titleRange = xlApp.get_Range("A1:" + GetExcelColumnName(table.Columns.Count) + "1", Type.Missing);
                //titleRange.Merge(Type.Missing);

                ////Center the title horizontally then vertically at the above defined range
                //titleRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                //titleRange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                ////Increase the font-size of the title
                //titleRange.Font.Size = 16;

                ////Make the title bold
                //titleRange.Font.Bold = true;

                ////Give the title background color
                //titleRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);

                ////Set the title row height
                //titleRange.RowHeight = 50;

                ////Populate headers, assume row[0] contains the title and row[1] contains all the headers
                //int iCol = 0;
                //foreach (DataColumn c in table.Columns)
                //{
                //    iCol++;
                //    xlWorkSheet.Cells[2, iCol] = JLanguages._Text(c.ColumnName);//JLanguages._Text(table.Columns[j].ColumnName)
                //}

                ////Populate rest of the data. Start at row[2] since row[1] contains title and row[0] contains headers
                //int iRow = 2; //We start at row 2
                //foreach (DataRow r in table.Rows)
                //{
                //    iRow++;
                //    iCol = 0;
                //    foreach (DataColumn c in table.Columns)
                //    {
                //        iCol++;
                //        xlWorkSheet.Cells[iRow, iCol] = JLanguages._Text(r[c.ColumnName].ToString());
                //    }
                //}

                ////Select the header row (row 2 aka row[1])
                //Microsoft.Office.Interop.Excel.Range headerRange = xlApp.get_Range("A2:" + GetExcelColumnName(table.Columns.Count) + "2", Type.Missing);

                ////Set the header row fonts bold
                //headerRange.Font.Bold = true;

                ////Center the header row horizontally
                //headerRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                ////Put a border around the header row
                //headerRange.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous,
                //    Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium,
                //    Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic,
                //    Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);

                ////Give the header row background color
                //headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);

                ////Set page orientation to landscape
                //xlWorkSheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;

                ////Set margins
                //xlWorkSheet.PageSetup.TopMargin = 0;
                //xlWorkSheet.PageSetup.RightMargin = 0;
                //xlWorkSheet.PageSetup.BottomMargin = 30;
                //xlWorkSheet.PageSetup.LeftMargin = 0;

                ////Set Header and Footer (see code list below)
                ////&P - the current page number.
                ////&N - the total number of pages.
                ////&B - use a bold font*.
                ////&I - use an italic font*.
                ////&U - use an underline font*.
                ////&& - the '&' character.
                ////&D - the current date.
                ////&T - the current time.
                ////&F - workbook name.
                ////&A - worksheet name.
                ////&"FontName" - use the specified font name*.
                ////&N - use the specified font size*.
                ////EXAMPLE: xlWorkSheet.PageSetup.RightFooter = "&F"
                //xlWorkSheet.PageSetup.RightHeader = "";
                //xlWorkSheet.PageSetup.CenterHeader = "";
                //xlWorkSheet.PageSetup.LeftHeader = "";
                //xlWorkSheet.PageSetup.RightFooter = "";
                //xlWorkSheet.PageSetup.CenterFooter = "Page &P of &N";
                //xlWorkSheet.PageSetup.LeftFooter = "";

                ////Set gridlines
                //xlWorkBook.Windows[1].DisplayGridlines = true;
                //xlWorkSheet.PageSetup.PrintGridlines = true;


                ///* 
                ////Color every other column but skip top two
                //Microsoft.Office.Interop.Excel.Range workSheetMinusHeader = xlApp.get_Range("A1", "F1");
                //Microsoft.Office.Interop.Excel.FormatCondition format =
                //    (Microsoft.Office.Interop.Excel.FormatCondition)workSheetMinusHeader.EntireColumn.FormatConditions.Add(
                //        Microsoft.Office.Interop.Excel.XlFormatConditionType.xlExpression,
                //        Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlEqual,
                //        "=IF(ROW()<3,,MOD(ROW(),2)=0)");
                //format.Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbWhiteSmoke;

                ////Put a border around the entire work sheet
                //workSheetMinusHeader.EntireColumn.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous,
                //    Microsoft.Office.Interop.Excel.XlBorderWeight.xlMedium,
                //    Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic,
                //    Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);
                //*/

                ////Set the font size and text wrap of columns for the entire worksheet
                //for (int i = 1; i <= table.Columns.Count; i++)
                //{
                //    ((Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Columns[i, Type.Missing]).Font.Size = 12;
                //    //((Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Columns[i, Type.Missing]).WrapText = true;
                //    ((Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Columns[i, Type.Missing]).EntireColumn.AutoFit();
                //}
                ////xlWorkSheet.Rows.AutoFit();///////////////////////////////////////////////////////////////////
                ////xlWorkSheet.Columns.AutoFit();///////////////////////////////////////////////////////////////////


                ////Select everything except title row (first row) and set row height for the selected rows
                ////xlWorkSheet.Range["a2", xlWorkSheet.Range["a2"].End[Microsoft.Office.Interop.Excel.XlDirection.xlDown].End[Microsoft.Office.Interop.Excel.XlDirection.xlToRight]].RowHeight = 45;

                ////Format date columns
                ////string[] dateColumns = new string[] { "N", "O", "P", "Q" };
                //string[] dateColumns = new string[] { };
                //foreach (string thisColumn in dateColumns)
                //{
                //    Microsoft.Office.Interop.Excel.Range rg = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, thisColumn];
                //    rg.EntireColumn.NumberFormat = "MM/DD/YY";
                //}
                //string Path = HttpContext.Current.Server.MapPath("~/Reports/csharp-Excel.xls");

                //xlWorkBook.SaveAs(Path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                //xlWorkBook.Close(true, misValue, misValue);
                //xlApp.Quit();

                //releaseObject(xlWorkSheet);
                //releaseObject(xlWorkBook);
                //releaseObject(xlApp);
                #endregion

                int columnscount = table.Columns.Count;
                for (int j = 0; j < columnscount; j++)
                {
                    table.Columns[j].ColumnName  = JLanguages._Text(table.Columns[j].ColumnName);
                }

                System.IO.StringWriter sw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);

                // Render grid view control.
                System.Web.UI.WebControls.DataGrid dg = new System.Web.UI.WebControls.DataGrid();
                dg.DataSource = table; //ds.Tables[0];
                dg.DataBind();
                dg.RenderControl(htw);

                string Path = HttpContext.Current.Server.MapPath("~/Reports/Reoprt_" + ClassLibrary.JMainFrame.CurrentPostCode + ".xls");
                // Write the rendered content to a file.
                string renderedGridView = sw.ToString();
                System.IO.File.WriteAllText(Path, renderedGridView, System.Text.Encoding.UTF8);
                try
                {
                    context.Response.Clear();
                    context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    context.Response.AddHeader("content-disposition", "attachment;filename= Reports.xls");
                    //context.Response.ContentType = "image/png";
                    context.Response.WriteFile(Path);
                }
                catch (Exception ex)
                {
                }
            }





        }
        private string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}