using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManagement;
using System.Data;

namespace WebProjectManagement.Forms
{
    public partial class DetailedProjectImprovementReport : System.Web.UI.UserControl
    {
        //        protected void Page_Load(object sender, EventArgs e)
        //        {
        //            int Code;
        //            int.TryParse(Request["Code"], out Code);


        //            string query = @"
        // DROP TABLE #Temp
        //create table #Temp (code int,pcode int,p float ,projectCode int,projectPercentage float)
        //DECLARE @itemParentCode int, @percentage FLOAT, @percentageTEMP FLOAT,@itemCode int,@pcode int
        //DECLARE @tblTemp TABLE(code int)--,pcode int,p float ,projectPercentage float)
        //declare  @TEMPitems table (code int)
        // insert into @TEMPitems select Code from pmItems 

        // declare  @temp int,@tempcode int

        //		insert into @tblTemp select Code from pmItems

        //WHILE((select COUNT(code) from @tblTemp)>0)
        //BEGIN
        //	SET @itemCode= (select top 1 code from @tblTemp)
        //	SET @itemParentCode = (SELECT ParentItemCode FROM pmItems WHERE Code=@itemCode)
        //	SET @pcode =@itemParentCode
        //	SET @percentage =1
        //	WHILE(@itemParentCode>0)
        //	BEGIN
        //		SET @percentageTEMP = (SELECT WeightPercentage  FROM pmItems WHERE Code=@itemCode)
        //		SET @percentage= @percentage*@percentageTEMP/100
        //		SET @itemCode = @itemParentCode
        //		SET @itemParentCode = (SELECT ParentItemCode FROM pmItems WHERE Code=@itemParentCode)
        //	END
        //	SET @percentage =@percentage * (SELECT WeightPercentage  FROM pmItems WHERE Code=@itemCode)
        //	SET @itemCode= (select top 1 code from @tblTemp)
        //	INSERT INTO #Temp VALUES(@itemCode,@pcode,@percentageTEMP,1,@percentage)
        //	DELETE FROM @tblTemp WHERE code=@itemCode
        //END

        //<#PreviusSQL#>

        //SELECT  i.*,t.projectPercentage,p.Name as projectname,
        //p.Name,
        // ((SELECT SUM(ir.WeightPercentage) FROM pmItemReport ir 
        // WHERE ir.ItemCode=t.code AND RegisterDate BETWEEN N'2017-01-1 15:01:50.567' AND N'2017-01-28 15:01:50.567')*t.projectPercentage/100 )AS totalImprovement 
        // FROM #Temp t
        //inner join pmItems i on i.Code=t.code
        //inner join pmProjects p on p.Code=i.ProjectCode 
        //WHERE i.ProjectCode=" + Code;

        //         string    query2 = @"select * from pmItems i 
        //where Code not in (select ParentItemCode from pmItems) AND ProjectCode="+Code;
        //            try
        //            {
        //                string s = "";
        //                DataTable t =  query.ExecuteQuery( true);
        //                DataTable t2 = query2.ExecuteQuery(true);

        //                int pn;
        //                int max = int.MinValue;
        //                foreach (DataRow dr in t.Rows)
        //                {
        //                    pn = dr.Field<int>("PriorityNumber");
        //                    max = Math.Max(max, pn);
        //                }
        //                DataTable dt = new DataTable();
        //               // dt.Columns.Add("Code");
        //                dt.Columns.Add("ProjectName");
        //                dt.Columns.Add("ItemName");
        //                dt.Columns.Add("projectPercentage");
        //                for (int i = 0; i < max; i++)
        //                {
        //                    dt.Columns.Add("ItemName"+(i+1));
        //                    dt.Columns.Add("projectPercentage" + (i + 1));
        //                }
        //                dt.Columns.Add("TotalImprovement");
        //                List<object> array;
        //                DataRow tmp;
        //                foreach (DataRow dr in t2.Rows)
        //                {
        //                    tmp = t.Select("Code=" + dr["Code"].ToString())[0];
        //                    array = new List<object>();
        //                  //  array.Add(dr["Code"]);
        //                    array.Add(t.Rows[0]["projectname"]);
        //                    foreach (string j in GetLatestChildren(dr["Name"].ToString() + "!+!" + tmp["projectPercentage"] + "!#!", dr["ParentItemCode"].ToString().ToInt32(), t).Split(new string[] { "!#!" }, StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray())
        //                        array.AddRange(j.Split(new string[] { "!+!" }, StringSplitOptions.RemoveEmptyEntries));
        //                    for (int k = 1; array.Count+1 < dt.Columns.Count; k++)
        //                        array.Add("-");
        //                    array.Add(tmp["totalImprovement"].ToString());
        //                    dt.Rows.Add(array.ToArray());
        //                }



        //                int columnscount = dt.Columns.Count;               

        //                for (int j = 0; j < columnscount; j++)
        //                {
        //                    dt.Columns[j].ColumnName =ClassLibrary. JLanguages._Text(dt.Columns[j].ColumnName);
        //                }

        //                System.IO.StringWriter sw = new System.IO.StringWriter();
        //                System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);

        //                // Render grid view control.
        //                System.Web.UI.WebControls.DataGrid dg = new System.Web.UI.WebControls.DataGrid();
        //                dg.Style.Add(System.Web.UI.HtmlTextWriterStyle.Direction, "rtl");
        //                dg.DataSource = dt; //ds.Tables[0];
        //                dg.DataBind();
        //                dg.RenderControl(htw);

        //                string Path = HttpContext.Current.Server.MapPath("~/Reports/Reoprt_" + ClassLibrary.JMainFrame.CurrentPostCode + ".xls");
        //                // Write the rendered content to a file.
        //                string renderedGridView = sw.ToString();
        //                System.IO.File.WriteAllText(Path, renderedGridView, System.Text.Encoding.UTF8);
        //                try
        //                {
        //                    Context.Response.Clear();
        //                    HttpContext.Current.Response.AddHeader(
        //                        "content-disposition", string.Format("attachment; filename={0}", "report.xls"));
        //                    HttpContext.Current.Response.ContentType = "application/ms-excel";
        //                    //context.Response.ContentType = "image/png";
        //                    Context.Response.WriteFile(Path);
        //                }
        //                catch (Exception ex)
        //                {
        //                }
        //            }
        //            catch (Exception er)
        //            {
        //            }


        //            WebClassLibrary.JWebManager.RunClientScript("CloseDialog(null);", "closedialoge");
        //        }

        //private string GetLatestChildren(string s,int itemcode, DataTable dt)
        //{
        //    foreach (DataRow dr in dt.Select("Code="+itemcode))
        //    {
        //        s = GetLatestChildren(s+dr["Name"].ToString()+"!+!"+ dr["projectPercentage"].ToString() + "!#!", dr["ParentItemCode"].ToString().ToInt32(), dt)+"!#!";
        //    }
        //    return s;
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            DetailedProjectImprovementReporter(Request["Code"], this.Context);
        }
        public void DetailedProjectImprovementReporter(string code, HttpContext Context)
        {
            int Code;
            int.TryParse(code, out Code);
            Context.Response.Clear();


            string query;
            query = @"
SELECT i.*,i.WeightPercentage as projectPercentage,p.Name as projectname ,
(CASE WHEN SUM(f.itemImprovementPercentage) IS NULL THEN 0 ELSE SUM(f.itemImprovementPercentage) END) as itemImprovementPercentage ,
(CASE WHEN SUM(f.totalImprovement) IS NULL THEN 0 ELSE SUM(f.totalImprovement) END)  as totalImprovement
 FROM 
 pmItems i 
inner join pmProjects p on p.Code=i.ProjectCode
inner join(SELECT i2.Code, (SELECT sum( ir.WeightPercentage) FROM pmItemReport ir WHERE ir.ItemCode=i2.code) AS itemImprovementPercentage ,
 ((SELECT SUM(ir.WeightPercentage) FROM pmItemReport ir WHERE ir.ItemCode=i2.code  )*i2.WeightPercentage/100 )AS totalImprovement 
 FROM  pmItems i2 inner join pmProjects p2 on p2.Code=i2.ProjectCode 
group by i2.Code,i2.WeightPercentage)  f on f.Code=i.Code
WHERE ProjectCode=" + Code + @"
group by i.Code,i.ItemDescription,i.Name,i.ParentItemCode,i.ProjectCode,i.WeightPercentage,p.Name";

            string query2 = @"select * from pmItems i 
where Code not in (select ParentItemCode from pmItems) AND ProjectCode=" + Code;
            try
            {
                string s = "";
                DataTable t = query.ExecuteQuery(true);
                DataTable t2 = query2.ExecuteQuery(true);

                List<ProjectManagement.MixedObjects.ItemFamily> ifamilies = ProjectManagement.MixedObjects.ItemFamily.ExtractFamilies(t);
                if (ifamilies.Count < 1)
                {
                    Context.Response.Clear();
                    //context.Response.ContentType = "image/png";
                    Context.Response.Write("هیچ آیتمی برای پروژه یافت نداشت.");
                    return;
                }
                int max = FindMaxPerioriyNumber(ifamilies, int.MinValue);
                //foreach(ProjectManagement.MixedObjects.ItemFamily y in ifamilies)
                //    foreach (ProjectManagement.MixedObjects.ItemFamily j in y.Children)
                //        Context.Response.Write(j.Name+" "+j.PriorityNumber);
                //Context.Response.Write("\n\nmax=" + max+ "\n\n");
                DataTable dt = new DataTable();
                dt.Columns.Add("Code");
                dt.Columns.Add("ProjectName");
                dt.Columns.Add("ItemName");
                string columns = "ItemName,";
                for (int i = 0; i < max; i++)
                {
                    dt.Columns.Add("ItemName" + (i + 1));
                    columns += "ItemName" + (i + 1) + ",";
                }
                float totalImprove = 0, totalWeight = 0;
                dt.Columns.Add("projectPercentage");
                dt.Columns.Add("parentProjectPercentage");
                dt.Columns.Add("itemImprovementPercentage");
                dt.Columns.Add("parentitemImprovementPercentage");
                dt.Columns.Add("TotalImprovement");
                columns += "projectPercentage,parentProjectPercentage,itemImprovementPercentage,parentitemImprovementPercentage,TotalImprovement";
                List<object> array;
                DataRow tmp;
                Dictionary<string, float> weights = new Dictionary<string, float>(), percent = new Dictionary<string, float>();
                string projectname = t.Rows[0]["projectname"].ToString();
                foreach (DataRow dr in t2.Rows)
                {
                    tmp = t.Select("Code=" + dr["Code"].ToString())[0];
                    array = new List<object>();
                    array.Add(dr["Code"]);
                    array.Add(projectname);
                    foreach (string j in GetLatestChildren(dr["Name"].ToString() + "!#!", dr["ParentItemCode"].ToString().ToInt32(), t).Split(new string[] { "!#!" }, StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray())
                        array.AddRange(j.Split(new string[] { "!+!" }, StringSplitOptions.RemoveEmptyEntries));
                    for (int k = 0; array.Count + 5 < dt.Columns.Count; k++)
                        array.Add("-");
                    if (!weights.Keys.Contains(array[2].ToString()))
                    {
                        percent.Add(array[2].ToString(), 0);
                        weights.Add(array[2].ToString(), 0);
                    }
                    totalImprove += tmp["totalImprovement"].ToString().ToFloat(3);
                    totalWeight += tmp["projectPercentage"].ToString().ToFloat(3);
                    weights[array[2].ToString()] += tmp["projectPercentage"].ToString().ToFloat(3);
                    percent[array[2].ToString()] += tmp["itemImprovementPercentage"].ToString().ToFloat(3);

                    array.Add(tmp["projectPercentage"].ToString().ToFloat(3));
                    array.Add("");//
                    array.Add(tmp["itemImprovementPercentage"].ToString().ToFloat(3));//
                    array.Add("");//
                    array.Add(tmp["totalImprovement"].ToString().ToFloat(3));
                    dt.Rows.Add(array.ToArray());
                }
                DataRow[] rows;
                foreach (string f in weights.Keys)
                {
                    rows = dt.Select("ItemName='" + f + "'");
                    foreach (DataRow dr in rows)
                    {
                        dr[dt.Columns.Count - 2] = percent[f] / rows.Count();
                        dr[dt.Columns.Count - 4] = weights[f];
                    }
                }



                DataView dv = dt.DefaultView;
                dv.Sort = columns;
                dt = dv.ToTable(false, (columns).Split(','));

                object[] total = new object[dt.Columns.Count];
                total[0] = "مجموع";
                for (int i = 3; i < total.Length - 2; i++)
                    total[i] = "";
                total[total.Length - 5] = totalWeight;
                total[total.Length - 4] = totalWeight;
                total[total.Length - 2] = "";
                total[total.Length - 1] = totalImprove;
                dt.Rows.Add(total);

                int columnscount = dt.Columns.Count;

                for (int j = 0; j < columnscount; j++)
                {
                    dt.Columns[j].ColumnName = ClassLibrary.JLanguages._Text(dt.Columns[j].ColumnName);
                }

                System.IO.StringWriter sw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htw = new System.Web.UI.HtmlTextWriter(sw);
                htw.WriteLine("<html>");
                htw.WriteLine("<head></head>");
                htw.WriteLine("<body>");
                htw.WriteLine(String.Format("<div style='direction:rtl;'><H1>گزارش پروژه {0}</H1>", projectname));
                // Render grid view control.

                // System.Web.UI.WebControls.DataGrid dg = new System.Web.UI.WebControls.DataGrid();
                System.Web.UI.WebControls.GridView dg = new System.Web.UI.WebControls.GridView();
                dg.DataSource = dt; //ds.Tables[0];
                dg.Style.Add(System.Web.UI.HtmlTextWriterStyle.Direction, "rtl");
                dg.DataBound += (sender, args) =>
                {
                    System.Web.UI.WebControls.GridView grid = (System.Web.UI.WebControls.GridView)sender;
                    if (grid.Columns.Count == 0) return;
                    System.Web.UI.WebControls.BoundField col = (System.Web.UI.WebControls.BoundField)grid.Columns[1];
                    col.HeaderText = ClassLibrary.JLanguages._Text(col.HeaderText);
                };
                dg.DataBind();
                //Mergin Cells
                for (int i = dg.Rows.Count - 1; i > 0; i--)
                {
                    System.Web.UI.WebControls.GridViewRow row = dg.Rows[i];
                    System.Web.UI.WebControls.GridViewRow previousRow = dg.Rows[i - 1];
                    for (int j = 0; j < row.Cells.Count; j++)
                    {
                        if ((row.Cells[j].Text == previousRow.Cells[j].Text && previousRow.Cells[j].Text != "-" && (j < row.Cells.Count - 3 || j == row.Cells.Count - 2)))
                        {
                            if (previousRow.Cells[j].RowSpan == 0)
                            {
                                if (row.Cells[j].RowSpan == 0)
                                {
                                    previousRow.Cells[j].RowSpan += 2;
                                }
                                else
                                {
                                    previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
                                }
                                row.Cells[j].Visible = false;
                            }
                        }
                    }
                }
                dg.RenderControl(htw);
                htw.WriteLine("</div>");
                htw.WriteLine("</body>");
                htw.WriteLine("</html>");
                string Path = HttpContext.Current.Server.MapPath("~/Reports/Reoprt_" + ClassLibrary.JMainFrame.CurrentPostCode + ".xls");
                // Write the rendered content to a file.
                string renderedGridView = TranslateColumns(sw.ToString(), columns.Split(','));//.Replace("table","table dir='rtl'").Replace("td", "td dir='rtl'");
                System.IO.File.WriteAllText(Path, renderedGridView, System.Text.Encoding.UTF8);
                try
                {
                    Context.Response.Clear();
                    HttpContext.Current.Response.AddHeader(
                        "content-disposition", string.Format("attachment; filename={0}", projectname.Replace(" ","_") + "_Detailed_Report.xls"));
                    HttpContext.Current.Response.ContentType = "application/ms-excel";
                    //context.Response.ContentType = "image/png";
                    Context.Response.WriteFile(Path);
                }
                catch (Exception ex)
                {
                }
            }
            catch (Exception er)
            {
                //context.Response.ContentType = "image/png";
                Context.Response.Write(er.Message + "-" + er.StackTrace);
            }
            WebClassLibrary.JWebManager.RunClientScript("CloseDialog(null);", "closedialoge");
            WebClassLibrary.JWebManager.RunClientScript("GetRadWindow().close();", "ConfirmDialog");
        }

        private string TranslateColumns(string text, string[] words)
        {
            foreach (string s in words)
            {
                text = text.Replace(s, ClassLibrary.JLanguages._Text(s));
            }
            return text;
        }

        private string GetLatestChildren(string s, int itemcode, DataTable dt)
        {
            string r;
            string tosend;
            foreach (DataRow dr in dt.Select("Code=" + itemcode))
            {
                tosend = s + dr["Name"].ToString() + "!#!";
                s = GetLatestChildren(tosend, dr["ParentItemCode"].ToString().ToInt32(), dt) + "!#!";
            }
            return s;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private int FindMaxPerioriyNumber(List<ProjectManagement.MixedObjects.ItemFamily> ifamilies, int max)
        {
            int pn;
            foreach (ProjectManagement.MixedObjects.ItemFamily dr in ifamilies)
            {
                pn = FindMaxPerioriyNumber(dr.Children, max);
                max = Math.Max(dr.PriorityNumber, pn);
            }
            return max;
        }
    }
}