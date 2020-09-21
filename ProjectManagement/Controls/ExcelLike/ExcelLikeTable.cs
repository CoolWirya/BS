using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using ProjectManagement;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagement.Controls.ExcelLike
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:ExcelLikeTable runat=server></{0}:ExcelLikeTable>")]
    public class ExcelLikeTable : WebControl
    {
        private string _query, _readOnlyColumns = "Code,ParentItemCode,",_columnsToCalculateTotal="",_readFieldNames="";
        private DataTable _datatable;
        public const string SEPARATOR = "%^%", SEPARATOR_ID_VALUE="$",ATTRIBUTE_TAG="tag";
        private HiddenField _hiddenfield = new HiddenField();
        public const string FORMS_PLACE = "~/WebProjectManagement/Forms/";
        public string RedFieldNames { get { return _readFieldNames; } set { _readFieldNames = value; } }
        public int ProjectOrTemplateCode { get; set; }
        public int Type { get; set; }//1 = project, 0=template

        public string ReadOnlyColumns
        {
            get
            {
                return _readOnlyColumns;
            }

            set
            {
                _readOnlyColumns = value;
            }
        }
        public string ColumnsToCalculateTotal
        {
            get
            {
                return _columnsToCalculateTotal;
            }

            set
            {
                _columnsToCalculateTotal = value;
            }
        }

        public DataTable Datatable
        {
            get
            {
                return _datatable;
            }
            set { _datatable = value; }
        }

        

        public Dictionary<string,string> GetChangedData()
        {
            string[] data = Page.Request.Form["excellike_ChangedValues"].ToString().Split(new string[] { SEPARATOR }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary <string, string> res = new Dictionary<string, string>();
            string[] entry;
            foreach (string s in data)
            {
                entry = s.Split(new string[] { SEPARATOR_ID_VALUE }, StringSplitOptions.RemoveEmptyEntries);
                if (!res.ContainsKey(entry[0]))
                    res.Add(entry[0], entry[1]);
                else res[entry[0]] = entry[1];
            }
            return res;
        }

        string[] _colorEntities = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
        Random _random = new Random();
        private string ColorMaker()
        {

            return "#" + _colorEntities[_random.Next(10, 12)] + _colorEntities[_random.Next(0,16)] +
                _colorEntities[_random.Next(10, 12)] + _colorEntities[_random.Next(0, 16)] +
                _colorEntities[_random.Next(10, 12)] + _colorEntities[_random.Next(0, 16)];
        }
        private void CreateStyle(HtmlTextWriter output)
        {
            output.WriteLine(@"<style>
table[id*=__ExcelLike_] tbody tr th, table[id*=__ExcelLike_] tbody tr td {
            text-align: center;
            padding-bottom: 1px;
            padding-top: 2px;
            text-decoration: none;
            padding-left: 10px;
            padding-right: 10px;
            vertical-align: middle;
            min-width: 50px;
            max-width: 250px;
            white-space: nowrap;
            color: #000;
            border-style: solid;
            border-width: 0 0 1px;
            font-weight: normal;
        }
table[id*=__ExcelLike_] tr {
    border: 1px solid #828282;
    height: 20px;
    font-size: small;
}
table[id*=__ExcelLike_] tr:hover td{
        background: rgba(200, 54, 54, 0.2);
    }
table[id*=__ExcelLike_] tbody tr th {
    font-weight: bolder;
    -moz-border-bottom-colors: none;
    -moz-border-left-colors: none;
    -moz-border-right-colors: none;
    -moz-border-top-colors: none;
    background: #e2e2e2 url(WebResource.axd?d=vGgnKrt9lou0y6daYzagd9AMmT7mXOmp1ltR5SUBrDO6jKGQ4XupOqIUr…ER1YAFAX3CBlcWuJNsWNmkevx-PYf29z6GaLp6Lm-wzQt9SvxcVs1&t=635005039420000000) repeat-x scroll 0 -2300px;
    border-color: -moz-use-text-color -moz-use-text-color #828282;
    border-image: none;
    border-style: none none solid;
    border-width: 0 0 1px;
    border-left: 1px solid #828282;
    color: #333;
}
</style>");
        }
        protected override void Render(HtmlTextWriter output)
        {
            if (Datatable == null) return;
            CreateStyle(output);
            output.WriteLine("<table id='" + this.ID + "__ExcelLike_'>");
            string totalRow = "";
            //output.WriteLine("<tr>");
            // totalRow= "<tr>";
            //string temp,digit;
            //foreach (DataColumn dc in Datatable.Columns)
            //{
            //    temp = dc.ColumnName.Contains("-") ? dc.ColumnName.Split('-')[0] : dc.ColumnName;
            //    digit = dc.ColumnName.Contains("-") ? dc.ColumnName.Split('-')[1] : "";
            //    output.WriteLine("<th>" + ClassLibrary.JLanguages._Text(temp)+" "+digit + "</th>");
            //    totalRow += "<td><span id='" + dc.ColumnName + "'></span></td>";
            //}
            //totalRow += "</tr>";
            //output.WriteLine("</tr>");

            string[] readOnlyColumns = this.ReadOnlyColumns.Split(',');
            int row = 0, col = 0;

            string cell;
            string[] parts;
            List<string> names = new List<string>();
            Dictionary<string, string> colors = new Dictionary<string, string>();
            int addButtonIndex = 0,updownIndex=0;
            foreach (DataRow dr in Datatable.Rows)
            {
                col = 0;
                if (!colors.ContainsKey(dr[0].ToString()))
                    colors.Add(dr[0].ToString(), ColorMaker());
                //output.WriteLine("<tr style='background-color:" + colors[dr[1].ToString()] + ";'>");
                output.WriteLine("<tr style='background-color:" + (colors.Count % 2 == 0 ? "#a6bda2" : "#ececec") + "; '>");

                if (string.IsNullOrEmpty(dr.ItemArray[2].ToString()))
                {
                    if (updownIndex > 0)
                    {
                        output.WriteLine("<td>");
                        upbtns[updownIndex].RenderControl(output);
                        output.WriteLine("</td>");
                    }
                    else
                    {
                        output.WriteLine("<td>");
                        output.WriteLine("</td>");
                    }
                    if (updownIndex < downbtns.Count-1)
                    {
                        output.WriteLine("<td>");
                        downbtns[updownIndex].RenderControl(output);
                        output.WriteLine("</td>");
                    }
                    else
                    {
                        output.WriteLine("<td>");
                        output.WriteLine("</td>");
                    }
                    updownIndex++;
                }
                else
                {
                    output.WriteLine("<td>");
                    output.WriteLine("</td>");
                    output.WriteLine("<td>");
                    output.WriteLine("</td>");
                }

                foreach (DataColumn dc in Datatable.Columns)
                {
                    if ((readOnlyColumns.HasItem(dc.ColumnName) || string.IsNullOrEmpty(dr[dc.ColumnName].ToString())) && !(dr[dc.ColumnName] is KeyValuePair<string, string>))
                        output.WriteLine("<td><span id='" + dc.ColumnName + "_" + row + "'>" + dr[dc.ColumnName].ToString() + "</span></td>");
                    else
                    {
                        cell = dr[dc.ColumnName].ToString();
                        if (cell.Contains(SEPARATOR))
                        {
                            parts = cell.Split(new string[] { SEPARATOR }, StringSplitOptions.None);
                            if (names.Contains(parts[2]) && parts[0] == ("Name"))
                            {
                                output.WriteLine("<td><span id='" + parts[0] + "_" + row + "_" + col + "' >" + parts[2] + "</span></td>");
                                continue;
                            }
                            output.WriteLine(@"<td><input id='hidden_" + parts[0] + "_" + row + "_" + col + @"' value='" + parts[1] + @"' type='hidden'/>
                            <input id='" + parts[0] + "_" + row + "_" + col + "' type='text' value='" + parts[2] + @"' 
                            onchange='datachanged(this);'   " + (RedFieldNames.Contains(parts[1])&& parts[0]== "WeightPercentage" ? "style='color:red;'" : "") + "/></td>");
                            if (parts[0] == "Name" && !names.Contains(parts[2]))
                                names.Add(parts[2]);
                     if(       parts[0] == "WeightPercentage")
                            RedFieldNames = RedFieldNames.Replace(parts[1] + ",", "");
                        }
                        else
                        {
                            //                            output.WriteLine(@"<td><input id='" + dc.ColumnName + "_" + row + "_" + col + "' type='text' value='" + cell.ToString() +
                            //"/></td>");

                        }
                    }
                    col++;
                }
                string temp = dr[1].ToString();
                if (!string.IsNullOrEmpty(temp) && temp.Contains(SEPARATOR))
                {
                    output.WriteLine("<td>");
                    _addButtons[addButtonIndex].RenderControl(output);
                    output.WriteLine("</td>");
                    output.WriteLine("<td>");
                    int code = _addButtons[addButtonIndex].Attributes[ATTRIBUTE_TAG].ToInt32();
                    if (_deleteButtons.ContainsKey(code))
                        _deleteButtons[code].RenderControl(output);
                    output.WriteLine("</td>");
                    addButtonIndex++;
                }
                output.WriteLine("</tr>");
                row++;
            }
            output.WriteLine(totalRow);
            output.WriteLine("</table>");
            //_hiddenfield.ID = this.ID + "_ChangedValues";
            //_hiddenfield.RenderControl(output);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ImageButton b,delete,up,down;
            int index = 1;
            string itemCode ="0";
            bool deleteButton = true ;
            List<int> codes = new List<int>();

            if (this.Type == 0)//template
                foreach (System.Data.DataRow dr in ProjectManagement.TemplateItem.JTemplateItems.GetLatestChildren(this.ProjectOrTemplateCode).Rows)
                    codes.Add(dr["Code"].ToString().ToInt32());
            else //project
                foreach (System.Data.DataRow dr in ProjectManagement.Item.JItems.GetLatestChildren(this.ProjectOrTemplateCode).Rows)
                    codes.Add(dr["Code"].ToString().ToInt32());


            for (int i = 0; i < Datatable.Rows.Count; i++)
            {
                itemCode = "0";

                //add
                b = new ImageButton();
                b.Click += B_Click;                
                b.ToolTip = "اضافه کردن آیتم";
                b.ImageUrl = "~/Images/Controls/toolbar_add.png";
                b.Width = 16;
                b.Height = 16;

                for (index = 1; index < Datatable.Columns.Count; index++)
                {
                    if (!Datatable.Rows[i][index].ToString().StartsWith("Name"))
                    {
                        itemCode = Datatable.Rows[i][index - 1].ToString().Split(new string[] { SEPARATOR }, StringSplitOptions.None)[1];

                        deleteButton = codes.Contains(itemCode.ToInt32());

                        b.Attributes.Add(ATTRIBUTE_TAG, itemCode);


                        break;
                    }
                }

                if (string.IsNullOrEmpty(Datatable.Rows[i].ItemArray[2].ToString()))
                {
                    //down
                    down = new ImageButton();
                    down.Click += Down_Click; ; ;
                    down.ToolTip = "انتقال به پایین";
                    down.ImageUrl = "~/Images/Controls/arrow_down.png";
                    down.Width = 16;
                    down.Height = 16;
                    down.Attributes.Add(ATTRIBUTE_TAG, itemCode);
                    downbtns.Add(down);
                    this.Controls.Add(down);
                    //up
                    up = new ImageButton();
                    up.Click += Up_Click; ;
                    up.ToolTip = "انتقال به بالا";
                    up.ImageUrl = "~/Images/Controls/arrow_up.png";
                    up.Width = 16;
                    up.Height = 16;
                    up.Attributes.Add(ATTRIBUTE_TAG, itemCode);
                    this.Controls.Add(up);
                    upbtns.Add( up);
                }

                if (deleteButton)
                {
                    delete = new ImageButton();

                    // delete.Click += Delete_Click;
                    delete.CssClass = "deleteItem";
                    delete.ToolTip = "حذف آیتم";
                    delete.ImageUrl = "~/Images/Controls/toolbar_delete.png";
                    delete.Width = 16;
                    delete.Height = 16;
                    //delete.OnClientClick =// "javascript:void(0);";
                    //"GetRadWindow()._iframe.contentWindow.location.href=GetRadWindow()._iframe.contentWindow.location.href";
                    delete.Attributes.Add(ATTRIBUTE_TAG, itemCode);
                    _deleteButtons.Add(itemCode.ToInt32(),delete);
                    this.Controls.Add(delete);
                }

                _addButtons.Add(b);
                this.Controls.Add(b);
            }
        }
        private bool ChangeOrder(int currentIndex,int newIndex,string tableName,int itemCode,string where)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                
                string query = string.Format(@"UPDATE  UpdateTarget
SET Ordered = RowNum
FROM
(
    SELECT  x.Ordered, ROW_NUMBER() OVER(ORDER BY x.Ordered,x.Code) AS RowNum
    FROM    {0} x
    WHERE   {3}   And ParentItemCode=-1
) AS UpdateTarget; "
+ @"UPDATE TOP (1) {0} SET Ordered={2} WHERE Ordered={1} AND {3} AND Code <> {4};"//ChangeOthers order
+ "UPDATE {0} SET Ordered={1} WHERE Ordered={2} AND Code={4} AND  {3};"//change item order
,tableName,newIndex,currentIndex,where,itemCode);
                DB.setQuery(query);
                int res= DB.Query_Execute();

                return res>0;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }
        private void Down_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton b = (ImageButton)sender;
            if (this.Type == 1)//project
            {
                ProjectManagement.Item.JItem i = new Item.JItem(b.Attributes[ATTRIBUTE_TAG].ToInt32());
                ChangeOrder(i.Ordered, ++i.Ordered, "pmItems", i.Code, "ProjectCode=" + i.ProjectCode);
            }
            else //template
            {
                ProjectManagement.TemplateItem.JTemplateItem i = new TemplateItem.JTemplateItem(b.Attributes[ATTRIBUTE_TAG].ToInt32());
                ChangeOrder(i.Ordered,++ i.Ordered, "pmTemplateItem",i.Code, "TemplateCode=" + i.TemplateCode);

            }
            WebClassLibrary.JWebManager.RunClientScript("window.location.href = window.location.href;", "ConfirmDialog6");
        }

        private void Up_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton b = (ImageButton)sender;
            if (this.Type == 1)//project
            {
                ProjectManagement.Item.JItem i = new Item.JItem(b.Attributes[ATTRIBUTE_TAG].ToInt32());
                ChangeOrder(i.Ordered, --i.Ordered, "pmItems", i.Code, "ProjectCode=" + i.ProjectCode);
            }
            else //template
            {
                TemplateItem.JTemplateItem  i = new TemplateItem.JTemplateItem(b.Attributes[ATTRIBUTE_TAG].ToInt32());
                ChangeOrder(i.Ordered, --i.Ordered, "pmTemplateItem", i.Code, "TemplateCode=" + i.TemplateCode);
            }
            WebClassLibrary.JWebManager.RunClientScript("window.location.href = window.location.href;", "ConfirmDialog6");
        }

        //private void Delete_Click(object sender, EventArgs e)
        //{
        //    Button b = (Button)sender;
        //    if (this.Type == 1)//project
        //        ProjectManagement.Item.JItems.DeleteNodeIncludeSubNodes(b.ToolTip.ToInt32());
        //    else //template
        //        ProjectManagement.TemplateItem.JTemplateItems.DeleteItemIncludeSubItems(b.ToolTip.ToInt32());
        //}


        List<ImageButton> _addButtons = new List<ImageButton>();
        List<ImageButton> upbtns = new List<ImageButton>();
        List<ImageButton> downbtns = new List<ImageButton>();
        Dictionary<int, ImageButton> _deleteButtons = new Dictionary<int, ImageButton>();
        private void B_Click(object sender, EventArgs e)
        {
            ImageButton b = (ImageButton)sender;
            if (this.Type == 1)//project
            {
                ProjectManagement.Controls.ExtendedJWindow.ExtendedJWindow.LoadControl("SubItem"
                             , FORMS_PLACE + "ItemUpdate.ascx"
                             , "ایجاد آیتم"
                             , new List<Tuple<string, string>>() {
                                        new Tuple<string, string>("ItemCode", "-1"),
                                        new Tuple<string, string>("ParentCode",  b.Attributes[ATTRIBUTE_TAG]),
                                        new Tuple<string, string>("ProjectCode",this.ProjectOrTemplateCode.ToString())
                             }
                             , WebClassLibrary.WindowTarget.NewWindow
                             , "OnClienClosedTheWindow"
                             , true, false, true, 630, 350);
            }
            else //template
                ProjectManagement.Controls.ExtendedJWindow.ExtendedJWindow.LoadControl("SubItem"
                            , FORMS_PLACE + "TemplateItemUpdate.ascx"
                            , "ایجاد آیتم"
                            , new List<Tuple<string, string>>() {
                                        new Tuple<string, string>("ItemCode", "-1" ),
                                        new Tuple<string, string>("ParentCode",  b.Attributes[ATTRIBUTE_TAG]),
                                        new Tuple<string, string>("TemplateCode", this.ProjectOrTemplateCode.ToString())
                            }
                            , WebClassLibrary.WindowTarget.NewWindow
                             , "OnClienClosedTheWindow"
                            , true, false, true, 630, 350);
        }

        public static string CreateCellValue(string colName,string key,string value)
        {
            return colName +
                SEPARATOR +
                key +
                SEPARATOR +
                value;
        }

    }
}
