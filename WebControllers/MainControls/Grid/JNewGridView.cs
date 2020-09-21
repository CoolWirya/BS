using ClassLibrary;
using ClassLibrary.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using WebClassLibrary;
using WebControllers.MainControls.ToolBar;

namespace WebControllers.MainControls.Grid
{
    [Serializable()]
    public struct RowStyle
    {
        public string columnName;
        public int fromTime;
        public int toTime;
        public string color;

    }

    [Serializable()]
    public class RowBGColor
    {
        public string ComparisonField;
        public string ComparisonValue;
        public string ComparisonOperator;
        public string Color;
    }

    public enum SQLTypeEnum
    {
        Query = 0,
        QueryFromAction = 1
    }

    //[Serializable()]
    //public class RowStyle
    //{
    //	public string columnName;
    //	public int fromTime;
    //	public int toTime;
    //	public string color;

    //}
    public enum GridEvent
    {
        click,
        dblclick,
        change,
        textchange,
        keyup,
        keydown,
        keypress,
        mouseover,
        mouseout,
        blur,
        refreshGrid,
        refreshAllGrids


        ,RightClick
    }

    public enum GridRequestType
    {
        SQL,
        ClassMethod
    }

    [Serializable]
    public class GridEventArgs
    {
        public string Field;
        public string BeforeEventControls;
        public string Control;
        public string AfterEventControls;
        public GridEvent BeforeEvent;
        public GridEvent Event;
        public GridEvent AfterEvent;
        public JActionsInfo Action;
    }

    [Serializable]
    public class GridContextMenuItem
    {
        public string Text;
        public JActionsInfo Action;
    }

    [Serializable]
    public class FilterItem
    {
        public string Field;
        public string Value;
        public string Property;
        public string ToString()
        {
            return Field + "$(\"#" + Value + ")." + Property + ";";
        }
    }

    [Serializable]
    public enum GridButtonParameterTypes
    {
        Static,
        Dynamic
    }

    [Serializable]
    public class GridButton
    {
        public string ID;
        public string Text;
        public string IconUrl;
        public string Control;
        //public object[] Parameters;
    }

    [Serializable]
    public class GridStaticButtonKeyValue
    {
        public string Key;
        public string Value;
    }

    public static class Extensions
    {
        //public static void ExporttoExcel(this DataTable table)
        //{
        //	string s = "";
        //	HttpContext.Current.Response.Clear();
        //	HttpContext.Current.Response.ClearContent();
        //	HttpContext.Current.Response.ClearHeaders();
        //	//HttpContext.Current.Response.Buffer = true;
        //	HttpContext.Current.Response.ContentType = "application/ms-excel";
        //	s += @"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">";
        //	HttpContext.Current.Response.AddHeader("Content-type", "application/vnd.ms-excel");
        //	HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=Reports.xls");
        //	//HttpContext.Current.Response.Charset = "utf-8";
        //	//HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
        //	s += "<font style='font-size:10.0pt; font-family:Calibri;'>";
        //	s += "<BR><BR><BR>";
        //	s += "<Table border='1' bgColor='#ffffff' " +
        //	  "borderColor='#000000' cellSpacing='0' cellPadding='0' " +
        //	  "style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>";
        //	int columnscount = table.Columns.Count;
        //	for (int j = 0; j < columnscount; j++)
        //	{
        //		s += "<Td>";
        //		s += "<B>";
        //		s += JLanguages._Text(table.Columns[j].ColumnName);
        //		s += "</B>";
        //		s += "</Td>";
        //	}
        //	s += "</TR>";
        //	foreach (DataRow row in table.Rows)
        //	{
        //		s += "<TR>";
        //		for (int i = 0; i < table.Columns.Count; i++)
        //		{
        //			s += "<Td>";
        //			s += row[i].ToString();
        //			s += "</Td>";
        //		}

        //		s += "</TR>";
        //	}
        //	s += "</Table>";
        //	s += "</font>";
        //	byte[] bytes = new byte[s.Length * sizeof(char)];
        //	System.Buffer.BlockCopy(s.ToCharArray(), 0, bytes, 0, bytes.Length);
        //	try
        //	{
        //		HttpContext.Current.Response.OutputStream.Write(bytes, 0, bytes.Length);
        //		HttpContext.Current.Response.Flush();
        //		HttpContext.Current.Response.End();
        //	}
        //	catch (Exception ex)
        //	{
        //	}
        //	//Stream s = HttpContext.Current.Response.OutputStream;


        //	//HttpContext.Current.Response.Clear();
        //	//HttpContext.Current.Response.ClearContent();
        //	//HttpContext.Current.Response.ClearHeaders();
        //	//HttpContext.Current.Response.Cookies.Clear();
        //	////Add the header & other information      
        //	//HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Private);
        //	//HttpContext.Current.Response.CacheControl = "private";
        //	//HttpContext.Current.Response.Charset = System.Text.UTF8Encoding.UTF8.WebName;
        //	//HttpContext.Current.Response.ContentEncoding = System.Text.UTF8Encoding.UTF8;
        //	//HttpContext.Current.Response.AppendHeader("Content-Length", s.Length.ToString());
        //	//HttpContext.Current.Response.AppendHeader("Pragma", "cache");
        //	//HttpContext.Current.Response.AppendHeader("Expires", "60");
        //	//HttpContext.Current.Response.AppendHeader("Content-Disposition",
        //	//"attachment; " +
        //	//"filename=\"ExcelReport.xlsx\"; " +
        //	//"size=" + s.Length.ToString() + "; " +
        //	//"creation-date=" + DateTime.Now.ToString("R") + "; " +
        //	//"modification-date=" + DateTime.Now.ToString("R") + "; " +
        //	//"read-date=" + DateTime.Now.ToString("R"));
        //	//HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //	////Write it back to the client    
        //	//byte[] bytes = null;
        //	//s.Read(bytes, 0, (int)s.Length);
        //	//HttpContext.Current.Response.BinaryWrite(bytes);
        //	//HttpContext.Current.Response.End();
        //}
        public static string GetColumns(this JQuery query, string pClassName, string pObjectCode)
        {
            return GetColumns(query, null,pClassName,pObjectCode);
        }
        public static string GetColumns(this JQuery query, JDataBase pDB, string pClassName, string pObjectCode)
        {
            ClassLibrary.JDataBase db;
            if (pDB != null)
                db = pDB;
            else
                db = new ClassLibrary.JDataBase();
            try
            {
                DataTable dt = WebClassLibrary.JWebDataBase.GetDataTableStructure(query.QueryText, db,pClassName,pObjectCode);
                string columnNames = string.Join(",", dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName));
                return columnNames;
            }
            catch
            {

            }
            finally
            {
                //if (pDB == null)
                //    db.Dispose();
            }
            return "";
        }
        public static string GetXmlFromDataset(this DataSet ds)
        {
            XmlTextWriter xwriter = null;
            try
            {
                xwriter = new XmlTextWriter(new MemoryStream(), Encoding.UTF8);
                xwriter.WriteStartElement("NewDataSet");
                //start enumerate in table collection
				if(ds!=null)
                foreach (DataTable dt in ds.Tables)
                {
                    int rowNum = 0;
                    DateTime tmp = DateTime.MinValue;
                    foreach (DataRow dr in dt.Rows)
                    {
                        xwriter.WriteStartElement(dt.TableName);
                        DateTime tmpDate = DateTime.MinValue;
                        foreach (DataColumn dc in dr.Table.Columns)
                        {
                            string colValue = String.Empty;
                            //switch (dc.DataType.Name)
                            //{
                            //	case "DateTime":
                            //		if (DateTime.TryParse(dr[dc,
                            //				 DataRowVersion.Current].ToString(),
                            //				 out tmpDate))
                            //			colValue = tmpDate.ToString("yyyy-MM-ddTHH:mm:ss");
                            //		else
                            //			colValue = dr[dc, DataRowVersion.Current].ToString();
                            //		break;
                            //	default:
                            //		colValue = dr[dc, DataRowVersion.Current].ToString();
                            //		break;
                            //}
                            //xwriter.WriteStartElement(dc.ColumnName.Replace(" ", "_x0020_"));
                            //if (isStatefull || String.Compare(
                            //	   dc.DataType.Name, "string", true) != 0)
                            //{
                            //	xwriter.WriteAttributeString("datatype", dc.DataType.Name);
                            //}
                            //if (isStatefull)
                            //{
                            //	xwriter.WriteAttributeString("stat", "0");
                            //}
                            colValue = dr[dc, DataRowVersion.Current].ToString();
                            string tagName = (dt.TableName.ToLower() != "pager" ? dc.ColumnName.Replace(" ", "_x0020_").ToLower() : dc.ColumnName.Replace(" ", "_x0020_")).Replace("/", "_");
                            if (string.IsNullOrWhiteSpace(colValue))
                            {
                                xwriter.WriteRaw("<" + tagName + "></" + tagName + ">");
                                continue;
                            }
                            xwriter.WriteStartElement(tagName);
                            xwriter.WriteString(colValue);
                            xwriter.WriteEndElement();
                        }
                        //end <table> element
                        xwriter.WriteEndElement();
                        rowNum++;
                    }
                }
                //end <newdataset> element
                xwriter.WriteEndElement();
                xwriter.Flush();
                xwriter.BaseStream.Seek(0, SeekOrigin.Begin);
                StreamReader reader = new StreamReader(xwriter.BaseStream);
                return reader.ReadToEnd();
            }
            finally
            {
                if (xwriter != null)
                {
                    xwriter.Close();
                    xwriter = null;
                }
            }
        }

        public static string HexConverter(this Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        public static void AddReferenceText(string path, Page page, bool isCss = true)
        {
            string str = "";
            if (isCss)
                str = @"<link href=""" + page.ResolveUrl(path) + @""" type=""text/css"" rel=""stylesheet"" />";
            else
                str = @"<script src=""" + page.ResolveUrl(path) + @"""></script>";
            Literal cssFile = new Literal() { Text = str };
            page.Header.Controls.Add(cssFile);
        }

        public static string GetQuery(this List<RowBGColor> rowColors)
        {
            if (rowColors == null || rowColors.Count == 0)
                return ",'default' C630N_BG_COLOR";
            string template = "{0} WHEN {1} {2} {3} THEN {4}";
            string column = "";
            for (int i = 0; i < rowColors.Count; i++)
                column += string.Format(template, i == 0 ? ", CASE" : " ", rowColors[i].ComparisonField, rowColors[i].ComparisonOperator, rowColors[i].ComparisonValue, rowColors[i].Color);
            column += " END C630N_BG_COLOR";
            return column;
        }
    }

    [DefaultProperty("DataSource")]
    [ToolboxData("<{0}:JGridView runat=\"server\">")]
    [Serializable()]
    public class JGridView : CompositeControl, ISerializable
    {
        #region Constructors
        public JGridView()
        {
        }

        public JGridView(string SUID)
        {
            this.SUID = SUID.Replace(".","_");
        }

        public JGridView(SerializationInfo info, StreamingContext ctxt)
        {
            ID = (string)info.GetValue("ID", typeof(string));
            SUID = (string)info.GetValue("SUID", typeof(string));
            Title = (string)info.GetValue("Title", typeof(string));
            Click = (GridEventArgs)info.GetValue("Click", typeof(GridEventArgs));
            DoubleClick = (GridEventArgs)info.GetValue("DoubleClick", typeof(GridEventArgs));
            DataSource = (DataTable)info.GetValue("DataSource", typeof(DataTable));
            ContextMenu = (List<GridContextMenuItem>)info.GetValue("ContextMenu", typeof(List<GridContextMenuItem>));
            Columns = (string)info.GetValue("Columns", typeof(string));
            Table = (string)info.GetValue("Table", typeof(string));
            PageIndex = (int)info.GetValue("PageIndex", typeof(int));
            PageSize = (int)info.GetValue("PageSize", typeof(int));
            HeaderBackColor = (Color)info.GetValue("HeaderBackColor", typeof(Color));
            HeaderColor = (Color)info.GetValue("HeaderColor", typeof(Color));
            RowBackColor = (Color)info.GetValue("RowBackColor", typeof(Color));
            RowColor = (Color)info.GetValue("RowColor", typeof(Color));
            WhereClause = (string)info.GetValue("WhereClause", typeof(string));
            Url = (string)info.GetValue("Url", typeof(string));
            SQL = (string)info.GetValue("SQL", typeof(string));
            RequestType = (GridRequestType)info.GetValue("RequestType", typeof(GridRequestType));
            //gv = (GridView)info.GetValue("gv", typeof(GridView));
            //pager = (HtmlGenericControl)info.GetValue("pager", typeof(HtmlGenericControl));
            //contextMenu = (HtmlGenericControl)info.GetValue("contextMenu", typeof(HtmlGenericControl));
            //ul = (HtmlGenericControl)info.GetValue("ul", typeof(HtmlGenericControl));
            //LastSortingField = (HiddenField)info.GetValue("LastSortingField", typeof(HiddenField));
            //LastOpenedPage = (HiddenField)info.GetValue("LastOpenedPage", typeof(HiddenField));
            //SelectedValue = (string)info.GetValue("SelectedValue", typeof(string));
            FilterItems = (List<FilterItem>)info.GetValue("FilterItems", typeof(List<FilterItem>));
            HasVariableSQL = (bool)info.GetValue("HasVariableSQL", typeof(bool));
            ClassName = (string)info.GetValue("ClassName", typeof(string));
            ObjectCode = (int)info.GetValue("ObjectCode", typeof(int));
            Parameters = (object[])info.GetValue("Parameters", typeof(object[]));
            //GridButtons = (List<GridButton>)info.GetValue("GridButtons", typeof(List<GridButton>));
            Toolbar = (JToolBar)info.GetValue("Toolbar", typeof(JToolBar));
            RowStyles = (List<RowStyle>)info.GetValue("RowStyles", typeof(List<RowStyle>));
            SQLType = (int)info.GetValue("SQLType", typeof(int));
            PageOrderByField = (string)info.GetValue("PageOrderByField", typeof(string));
            CssClass = (string)info.GetValue("CssClass", typeof(string));
            Buttons = (string)info.GetValue("Buttons", typeof(string));
            HiddenColumns = (string)info.GetValue("HiddenColumns", typeof(string));
            RefreshTimerEnabled = (bool)info.GetValue("RefreshTimerEnabled", typeof(bool));
            RefreshTimerInterval = (int)info.GetValue("RefreshTimerInterval", typeof(int));
            FilterQuery = (string)info.GetValue("FilterQuery", typeof(string));
            SumFields = (Dictionary<string, double>)info.GetValue("SumFields", typeof(Dictionary<string, double>));
            DetailDataSource = (string)info.GetValue("DetailDataSource", typeof(string));
            DetailKeyFields = (Dictionary<string, string>)info.GetValue("DetailKeyFields", typeof(Dictionary<string, string>));
            IsDetailQueryIn = (bool)info.GetValue("IsDetailQueryIn", typeof(bool));
            PreQuery = (string)info.GetValue("PreQuery", typeof(string));
            Actions = (List<JActionsInfo>)info.GetValue("Actions", typeof(List<JActionsInfo>));
            RowColors = (List<RowBGColor>)info.GetValue("RowColors", typeof(List<RowBGColor>));
            RightClick = (GridEventArgs)info.GetValue("RightClick", typeof(GridEventArgs));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("ID", ID);
            info.AddValue("SUID", SUID);
            info.AddValue("Title", Title);
            info.AddValue("Click", Click);
            info.AddValue("DoubleClick", DoubleClick);

            info.AddValue("RightClick", RightClick);

            info.AddValue("DataSource", DataSource);
            info.AddValue("ContextMenu", ContextMenu);
            info.AddValue("Columns", Columns);
            info.AddValue("Table", Table);
            info.AddValue("PageIndex", PageIndex);
            info.AddValue("PageSize", PageSize);
            info.AddValue("HeaderBackColor", HeaderBackColor);
            info.AddValue("HeaderColor", HeaderColor);
            info.AddValue("RowBackColor", RowBackColor);
            info.AddValue("RowColor", RowColor);
            info.AddValue("WhereClause", WhereClause);
            info.AddValue("SQL", SQL);
            info.AddValue("Url", Url);
            info.AddValue("RequestType", RequestType);
            //info.AddValue("gv", gv);
            //info.AddValue("pager", pager);
            //info.AddValue("contextMenu", contextMenu);
            //info.AddValue("ul", ul);
            //info.AddValue("LastOpenedPage", LastOpenedPage);
            //info.AddValue("LastSortingField", LastSortingField);
            //info.AddValue("SelectedValue", SelectedValue);
            info.AddValue("FilterItems", FilterItems);
            info.AddValue("HasVariableSQL", HasVariableSQL);
            info.AddValue("ClassName", ClassName);
            info.AddValue("ObjectCode", ObjectCode);
            info.AddValue("Parameters", Parameters);
            //info.AddValue("GridButtons", GridButtons);
            info.AddValue("Toolbar", Toolbar);
            info.AddValue("RowStyles", RowStyles);
            info.AddValue("SQLType", SQLType);
            info.AddValue("PageOrderByField", PageOrderByField);
            info.AddValue("CssClass", CssClass);
            info.AddValue("Buttons", Buttons);
            info.AddValue("HiddenColumns", HiddenColumns);
            info.AddValue("RefreshTimerEnabled", RefreshTimerEnabled);
            info.AddValue("RefreshTimerInterval", RefreshTimerInterval);
            info.AddValue("FilterQuery", FilterQuery);
            info.AddValue("SumFields", SumFields);
            info.AddValue("DetailDataSource", DetailDataSource);
            info.AddValue("DetailKeyFields", DetailKeyFields);
            info.AddValue("IsDetailQueryIn", IsDetailQueryIn);
            info.AddValue("PreQuery", PreQuery);
            info.AddValue("Actions", Actions);
            info.AddValue("RowColors", RowColors);
        }

        #endregion

        #region Static Buttons Actions

        private List<GridStaticButtonKeyValue> staticButtonsActions;

        public string Print(string className, int objectCode, string sql, bool oneRecord, params object[] parameters)
        {
            JQuery jQuery = new JQuery(className, SQL, objectCode, RowColors.GetQuery(), parameters);
            return WebClassLibrary.JWebManager.LoadClientControl(className
                    , "~/WebReport/Viewer/JReportSelectorControl.ascx"
                    , "چاپ"
                    , new List<Tuple<string, string>>(){ new Tuple<string, string>("ObjectCode", objectCode.ToString())
                                               ,  new Tuple<string, string>("rSUID", "Report_Dt")
                                               , new Tuple<string, string>("ClassName",className) 
                                               //, new Tuple<string,string>("SQL1",sql)
                                               , new Tuple<string,string>("QueryCode",jQuery.Code.ToString()) }
                    , WebClassLibrary.WindowTarget.NewWindow
                    , true, true, true, 750, 500);
        }

        public string FormManager(string className, params object[] objectCode)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("FormManagers"
                            , "~/WebControllers/FormManager/JFormListControl.ascx"
                            , "فرم ساز"
                            , new List<Tuple<string, string>>(){
								new Tuple<string, string>("ObjectCode", objectCode[0].ToString())
								, new Tuple<string, string>("ClassName", className)
							}
                            , WebClassLibrary.WindowTarget.NewWindow
                            , true, false, true, 700, 400);
        }

        public string Forms(string className)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("Forms"
                            , "~/WebControllers/FormManager/JWebForms.ascx"
                            , "فرم ها"
                            , new List<Tuple<string, string>>() { new Tuple<string, string>("ClassName", className) }
                            , WebClassLibrary.WindowTarget.NewWindow
                            , true, true, true, 600, 350);
        }

        public string Query(string className, int objectCode, string query, params object[] parameters)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("GridQuery"
                            , "~/WebControllers/MainControls/Grid/JGridQueryControl.ascx"
                            , "پرس و جو"
                            , new List<Tuple<string, string>>()
							{
								new Tuple<string, string>("ClassName", className)
								,new Tuple<string, string>("ObjectCode", objectCode.ToString())
								,new Tuple<string, string>("Query", query)
								,new Tuple<string, string>("Parameters", string.Join(",", Parameters == null ? new object[] { } : Parameters))
							}
                            , WebClassLibrary.WindowTarget.NewWindow
                            , true, true, true, 600, 550);
        }

        #endregion

        #region Properties
        string clientId = "grid_" + Guid.NewGuid().ToString().Replace("-", "_");
        public override string ClientID
        {
            get
            {
                return clientId;
            }
        }

        public int AutRefreshInterval;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public List<RowBGColor> RowColors
        {
            get
            {
                if (ViewState["RowColors"] != null)
                    return (List<RowBGColor>)ViewState["RowColors"];
                return new List<RowBGColor>();
            }
            set
            {
                ViewState["RowColors"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public List<JActionsInfo> Actions
        {
            get
            {
                if (ViewState["Actions"] != null)
                    return (List<JActionsInfo>)ViewState["Actions"];
                return new List<JActionsInfo>();
            }
            set
            {
                ViewState["Actions"] = value;
                //if (value == null || value.Count == 0)
                //	return;
                //DoubleClick = new GridEventArgs() { Action = value[0] };
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public int SQLType
        {
            get
            {
                if (ViewState["SQLType"] != null)
                    return (int)ViewState["SQLType"];
                return 0;
            }
            set
            {
                ViewState["SQLType"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public List<RowStyle> RowStyles
        {
            get
            {
                if (ViewState["RowStyles"] != null)
                    return (List<RowStyle>)ViewState["RowStyles"];
                return new List<RowStyle>();
            }
            set
            {
                ViewState["RowStyles"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public string Buttons
        {
            get
            {
                if (ViewState["Buttons"] != null)
                    return ViewState["Buttons"].ToString();
                return "Refresh,Print,record_print,PDF,Excel,Word,CSV,Forms,FormManagers,Query,Close,RightClick";
            }
            set
            {
                ViewState["Buttons"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public string CssClass
        {
            get
            {
                if (ViewState["CssClass"] != null)
                    return ViewState["CssClass"].ToString();
                return "";
            }
            set
            {
                ViewState["CssClass"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public string HiddenColumns
        {
            get
            {
                if (ViewState["HiddenColumns"] != null)
                    return ViewState["HiddenColumns"].ToString();
                return "";
            }
            set
            {
                ViewState["HiddenColumns"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public string DetailDataSource
        {
            get
            {
                if (ViewState["DetailDataSource"] != null)
                    return ViewState["DetailDataSource"].ToString();
                return "";
            }
            set
            {
                ViewState["DetailDataSource"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public Dictionary<string, string> DetailKeyFields
        {
            get
            {
                if (ViewState["DetailKeyFields"] != null)
                    //return ViewState["DetailKeyFields"].ToString();
                    return (Dictionary<string, string>)ViewState["DetailKeyFields"];
                //return "";
                return new Dictionary<string, string>();
            }
            set
            {
                ViewState["DetailKeyFields"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public Dictionary<string, double> SumFields
        {
            get
            {
                if (ViewState["SumFields"] != null)
                    return (Dictionary<string, double>)ViewState["SumFields"];
                return new Dictionary<string, double>();
            }
            set
            {
                ViewState["SumFields"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public string MoneyColumns
        {
            get
            {
                if (ViewState["MoneyColumns"] != null)
                    return ViewState["MoneyColumns"].ToString();
                return "";
            }
            set
            {
                ViewState["MoneyColumns"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public string FilterQuery
        {
            get
            {
                if (ViewState["FilterQuery"] != null)
                    return ViewState["FilterQuery"].ToString();
                return "";
            }
            set
            {
                ViewState["FilterQuery"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public string PreQuery
        {
            get
            {
                if (ViewState["PreQuery"] != null)
                    return ViewState["PreQuery"].ToString();
                return "";
            }
            set
            {
                ViewState["PreQuery"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public bool RefreshTimerEnabled
        {
            get
            {
                if (ViewState["RefreshTimerEnabled"] != null)
                    return (bool)ViewState["RefreshTimerEnabled"];
                return false;
            }
            set
            {
                ViewState["RefreshTimerEnabled"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public bool IsDetailQueryIn
        {
            get
            {
                if (ViewState["IsDetailQueryIn"] != null)
                    return (bool)ViewState["IsDetailQueryIn"];
                return false;
            }
            set
            {
                ViewState["IsDetailQueryIn"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public int RefreshTimerInterval
        {
            get
            {
                if (ViewState["RefreshTimerInterval"] != null)
                    return (int)ViewState["RefreshTimerInterval"];
                return 1000;
            }
            set
            {
                ViewState["RefreshTimerInterval"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public string PageOrderByField
        {
            get
            {
                if (ViewState["PageOrderByField"] != null)
                    return Regex.Replace(ViewState["PageOrderByField"].ToString(), @"\s+", " ");
                return "Code Asc";
            }
            set
            {
                ViewState["PageOrderByField"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public string SelectedValue
        {
            get
            {
                return SelectedKey != null ? SelectedKey.Value : "";
            }
            set
            {
                SelectedKey.Value = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(false)]
        [Localizable(true)]
        public bool HasVariableSQL
        {
            get
            {
                if (ViewState["HasVariableSQL"] != null)
                    return (bool)ViewState["HasVariableSQL"];
                return false;
            }
            set
            {
                ViewState["HasVariableSQL"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public List<FilterItem> FilterItems
        {
            get
            {
                if (ViewState["FilterItems"] != null)
                    return (List<FilterItem>)ViewState["FilterItems"];
                return new List<FilterItem>();
            }
            set
            {
                ViewState["FilterItems"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public string KeyField
        {
            get
            {
                if (ViewState["KeyField"] != null)
                    return ViewState["KeyField"].ToString();
                return null;
            }
            set
            {
                ViewState["KeyField"] = value;
            }
        }

        [Bindable(true)]
        [Category("Events")]
        [DefaultValue(null)]
        [Localizable(true)]
        public string SUID
        {
            get
            {
                if (ViewState["SUID"] != null)
                    return ViewState["SUID"].ToString();
                return null;
            }
            set
            {
                ViewState["SUID"] = value;
            }
        }

        [Bindable(true)]
        [Category("Events")]
        [DefaultValue(null)]
        [Localizable(true)]
        public string Title
        {
            get
            {
                if (ViewState["Title"] != null)
                    return ViewState["Title"].ToString();
                return null;
            }
            set
            {
                ViewState["Title"] = value;
            }
        }

        [Bindable(true)]
        [Category("Events")]
        [DefaultValue(null)]
        [Localizable(true)]
        public GridEventArgs Click
        {
            get
            {
                if (ViewState["Click"] != null)
                    return ViewState["Click"] as GridEventArgs;
                return null;
            }
            set
            {
                ViewState["Click"] = value;
                if (value == null)
                    return;
                value.Event = GridEvent.click;
            }
        }

        [Bindable(true)]
        [Category("Events")]
        [DefaultValue(null)]
        [Localizable(true)]
        public GridEventArgs DoubleClick
        {
            get
            {
                if (ViewState["DoubleClick"] != null)
                    return ViewState["DoubleClick"] as GridEventArgs;
                return null;
            }
            set
            {
                ViewState["DoubleClick"] = value;
                if (value == null)
                    return;
                value.Event = GridEvent.dblclick;
            }
        }



        public GridEventArgs RightClick
        {
            get
            {
                if (ViewState["RightClick"] != null)
                    return ViewState["RightClick"] as GridEventArgs;
                return null;
            }
            set
            {
                ViewState["RightClick"] = value;
                if (value == null)
                    return;
                value.Event = GridEvent.RightClick;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public DataTable DataSource
        {
            get
            {
                if (ViewState["DataSource"] != null)
                    return ViewState["DataSource"] as DataTable;
                return null;
            }
            set
            {
                ViewState["DataSource"] = value;
                if (gv == null)
                    gv = new GridView() { ID = "_GV_" };
                gv.DataSource = value;
                gv.DataBind();
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public List<GridContextMenuItem> ContextMenu
        {
            get
            {
                if (ViewState["ContextMenu"] != null)
                    return ViewState["ContextMenu"] as List<GridContextMenuItem>;
                return null;
            }
            set
            {
                ViewState["ContextMenu"] = value;
            }
        }

        //[Bindable(true)]
        //[Category("Data")]
        //[DefaultValue("")]
        //[Localizable(true)]
        //public string XMLDataSource
        //{
        //	get
        //	{
        //		if (!string.IsNullOrWhiteSpace(ViewState["XMLDataSource"].ToString()))
        //			return ViewState["XMLDataSource"].ToString();
        //		return "";
        //	}
        //	set
        //	{
        //		ViewState["XMLDataSource"] = value;
        //		DataSet ds = new DataSet();
        //		ds.ReadXml(new System.IO.StringReader(value));
        //		gv.DataSource = ds.Tables[0];
        //		gv.DataBind();
        //	}
        //}

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public string Columns
        {
            get
            {
                if (ViewState["Columns"] != null)
                    return ViewState["Columns"].ToString();
                return null;
            }
            set
            {
                ViewState["Columns"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public string Table
        {
            get
            {
                if (ViewState["Table"] != null)
                    return ViewState["Table"].ToString();
                return null;
            }
            set
            {
                ViewState["Table"] = "(select " + (Columns == null ? "*" : Columns.Split(',').ToList().Aggregate((x, y) => x.ToLower() + "," + y.ToLower())) + " from " + value + " where 1 = 1 " + WhereClause + ")t1";
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string WhereClause
        {
            get
            {
                if (ViewState["WhereClause"] == null)
                    return "";
                return " and " + ViewState["WhereClause"].ToString();
            }
            set
            {
                ViewState["WhereClause"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public string SQL
        {
            get
            {
                if (ViewState["SQL"] != null)
                    return ViewState["SQL"].ToString();
                return "";
            }
            set
            {
                ViewState["SQL"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public string ClassName
        {
            get
            {
                if (ViewState["ClassName"] != null)
                    return ViewState["ClassName"].ToString();
                return Title;
            }
            set
            {
                ViewState["ClassName"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public int ObjectCode
        {
            get
            {
                if (ViewState["ObjectCode"] != null)
                    return (int)ViewState["ObjectCode"];
                return 0;
            }
            set
            {
                ViewState["ObjectCode"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public object[] Parameters
        {
            get
            {
                if (ViewState["Parameters"] != null)
                    return (object[])ViewState["Parameters"];
                return null;
            }
            set
            {
                ViewState["Parameters"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Url
        {
            get
            {
                if (ViewState["Url"] == null || RequestType == GridRequestType.SQL)
                    return "../Controls.aspx/GetTablePager";
                return ViewState["Url"].ToString();
            }
            set
            {
                ViewState["Url"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public GridRequestType RequestType
        {
            get
            {
                if (ViewState["RequestType"] != null)
                    return (GridRequestType)ViewState["RequestType"];
                return GridRequestType.SQL;
            }
            set
            {
                ViewState["RequestType"] = value;
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public int PageIndex
        {
            get
            {
                int pi;
                if (LastOpenedPage == null)
                    return 0;
                if (int.TryParse(LastOpenedPage.Value, out pi))
                    return pi;
                return (int)ViewState["PageIndex"];
            }
            set
            {
                ViewState["pageIndex"] = value;
                if (LastOpenedPage == null)
                    LastOpenedPage = new HiddenField();
                LastOpenedPage.Value = value.ToString();
            }
        }

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public int PageSize
        {
            get
            {
                if (ViewState["PageSize"] == null)
                    return 50;
                return (int)ViewState["PageSize"];
            }
            set
            {
                ViewState["PageSize"] = value;
            }
        }

        [Bindable(true)]
        [Category("Appearence")]
        [DefaultValue(null)]
        [Localizable(true)]
        public Color HeaderColor
        {
            get
            {
                if (ViewState["HeaderColor"] == null)
                    return Color.White;
                return (Color)ViewState["HeaderColor"];
            }
            set
            {
                ViewState["HeaderColor"] = value;
            }
        }

        [Bindable(true)]
        [Category("Appearence")]
        [DefaultValue(null)]
        [Localizable(true)]
        public Color HeaderBackColor
        {
            get
            {
                if (ViewState["HeaderBackColor"] == null)
                    return Color.FromArgb(255, 80, 124, 209);
                return (Color)ViewState["HeaderBackColor"];
            }
            set
            {
                ViewState["HeaderBackColor"] = value;
            }
        }

        [Bindable(true)]
        [Category("Appearence")]
        [DefaultValue(null)]
        [Localizable(true)]
        public Color RowColor
        {
            get
            {
                if (ViewState["RowColor"] == null)
                    return Color.FromArgb(255, 51, 51, 51);
                return (Color)ViewState["RowColor"];
            }
            set
            {
                ViewState["RowColor"] = value;
            }
        }

        [Bindable(true)]
        [Category("Appearence")]
        [DefaultValue("EFF3FB")]
        [Localizable(true)]
        public Color RowBackColor
        {
            get
            {
                if (ViewState["RowBackColor"] == null)
                    return Color.FromArgb(255, 239, 243, 251);
                return (Color)ViewState["RowBackColor"];
            }
            set
            {
                ViewState["RowBackColor"] = value;
            }
        }

        //[Bindable(true)]
        //[Category("Data")]
        //[DefaultValue(null)]
        //[Localizable(true)]
        //public List<GridButton> GridButtons
        //{
        //	get
        //	{
        //		if (ViewState["GridButtons"] != null)
        //			return ViewState["GridButtons"] as List<GridButton>;
        //		return null;
        //	}
        //	set
        //	{
        //		ViewState["GridButtons"] = value;
        //	}
        //}

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue(null)]
        [Localizable(true)]
        public JToolBar Toolbar
        {
            get
            {
                if (ViewState["Toolbar"] != null)
                    return ViewState["Toolbar"] as JToolBar;
                return null;
            }
            set
            {
                ViewState["Toolbar"] = value;
            }
        }

        #endregion

        #region Controls

        private GridView gv;
        private HtmlGenericControl pager;
        private HtmlGenericControl contextMenu;
        private HtmlGenericControl buttons;
        private HtmlGenericControl ul;
        private HiddenField LastSortingField;
        private HiddenField LastOpenedPage;
        private HiddenField SelectedKey;
        private HiddenField VarSQL;
        private TextBox PageSizeTextBox;

        #endregion

        #region Overrides

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            bindButtons();
            Controls.Add(buttons);
            if (gv == null)
                gv = new GridView();
            gv.ID = this.ClientID + "__GV_";
            gv.AutoGenerateColumns = true;
            //gv.RowStyle.BackColor = RowBackColor;
            //gv.ForeColor = RowColor;
            ////gv.RowStyle.ForeColor = RowColor;
            //gv.HeaderStyle.BackColor = HeaderBackColor;
            //gv.HeaderStyle.ForeColor = Color.White;
            //gv.AlternatingRowStyle.BackColor = Color.White;
            //gv.HeaderStyle.Font.Bold = true;
            //gv.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
            //gv.RowStyle.HorizontalAlign = HorizontalAlign.Center;
            gv.CellPadding = 4;
            gv.GridLines = GridLines.None;
            System.Web.UI.HtmlControls.HtmlGenericControl gridViewDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("Div");
            gridViewDiv.Attributes.Add("style", "max-height:75%; overflow-y: scroll; overflow-x: scroll; margin:3px");
            gridViewDiv.Controls.Add(gv);
            Controls.Add(gridViewDiv);

            pager = new System.Web.UI.HtmlControls.HtmlGenericControl("Div");
            pager.Attributes.Add("class", "Pager");
            pager.Attributes.Add("style", "display:inline");
            //pager.Attributes.Add("style", "position: fixed; top: " + (PageSize + 1) * 36 + "px;");
            //pager.Attributes.Add("style", "position: fixed; top: " + (gv.Height.Value + 10) + "px;");
            System.Web.UI.HtmlControls.HtmlGenericControl pagerContainerDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("Div");
            pagerContainerDiv.Controls.Add(pager);
            Controls.Add(pagerContainerDiv);

            LastSortingField = new HiddenField();
            LastSortingField.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            LastSortingField.ID = "_LastSortingField";
            LastSortingField.Value = "Code Asc";
            Controls.Add(LastSortingField);

            if (LastOpenedPage == null)
                LastOpenedPage = new HiddenField();
            LastOpenedPage.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            LastOpenedPage.ID = "_LastOpenedPage";
            LastOpenedPage.Value = "1";
            Controls.Add(LastOpenedPage);

            SelectedKey = new HiddenField();
            SelectedKey.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            SelectedKey.ID = "_SelectedKey";
            SelectedKey.Value = "0";
            Controls.Add(SelectedKey);

            VarSQL = new HiddenField();
            VarSQL.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            VarSQL.ID = "_VarSQL";
            Controls.Add(VarSQL);

            PageSizeTextBox = new TextBox();
            PageSizeTextBox.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            PageSizeTextBox.ID = "_PageSizeTextBox";
            PageSizeTextBox.Text = PageSize.ToString();
            PageSizeTextBox.Width = 40;
            PageSizeTextBox.Attributes.Add("autocomplete", "off");
            PageSizeTextBox.Attributes.Add("style", "direction: ltr; vertical-align: bottom; margin-right: 5px;");
            pagerContainerDiv.Controls.Add(PageSizeTextBox);

            if (ContextMenu == null)
                return;
            bindContextMenu();
            contextMenu.Controls.Add(ul);
            Controls.Add(contextMenu);

            //if (ContextMenu == null || ContextMenu.Count == 0)
            //	return;
        }

        protected override void RecreateChildControls()
        {
            base.RecreateChildControls();
            EnsureChildControls();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            this.Attributes.Add("id", ClientID);
            writeScript();
        }

        #endregion

        #region Methods

        private void FillStaticButtonsActions()
        {
            if (staticButtonsActions == null)
                staticButtonsActions = new List<GridStaticButtonKeyValue>();
            string[] btn = Buttons.Split(',');
            if (btn != null && btn.Length > 0)
                foreach (string item in btn)
                {
                    switch (item.ToLower())
                    {
                        case "refresh":
                            //"$('#" + this.ClientID + @"').find('[id*=_GV_] tr.filterRow input').val();" + this.ClientID + @"_filterItems_fields = [];" + this.ClientID + @"_filterItems_vals = [];" +
                            staticButtonsActions.Add(new GridStaticButtonKeyValue() { Key = this.ClientID + "_" + item.ToLower() + "StaticButton", Value = this.ClientID + @"RefreshTablePager('" + ClassName + "'," + ObjectCode + ",'" + string.Join(",", Parameters == null ? new object[] { } : Parameters) + @"', 1, $('#" + this.ClientID + @"').find('[id*=_PageSizeTextBox]').val(), $('#" + this.ClientID + @"').find('#_LastSortingField').val(), ''," + this.ClientID + @"_filterItems_fields.join('?!?')+'[:.?!?.:]'+" + this.ClientID + @"_filterItems_vals.join('?!?')," + this.ClientID + @"_sumFields);return false;" });
                            break;
                        case "print":
                            staticButtonsActions.Add(new GridStaticButtonKeyValue() { Key = this.ClientID + "_" + item.ToLower() + "StaticButton", Value = "ShowMenu('" + new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebControllers.MainControls.Grid.JGridView.Print", null, new List<object>() { ClassName, ObjectCode, SQL, false, Parameters }).ActionToString() + "'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());return false;" });
                            break;
                        case "record_print":
                            staticButtonsActions.Add(new GridStaticButtonKeyValue() { Key = this.ClientID + "_" + item.ToLower() + "StaticButton", Value = "ShowMenu('" + new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebControllers.MainControls.Grid.JGridView.Print", null, new List<object>() { ClassName, ObjectCode, SQL, true, Parameters }).ActionToString() + "'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());return false;" });
                            break;


                        case "RightClick":
                            staticButtonsActions.Add(new GridStaticButtonKeyValue() { Key = this.ClientID + "_" + item.ToLower() + "StaticButton", Value = "ShowMenu('" + new JActionsInfo("Click", JDomains.JActionEvents.MouseRightClick, "WebControllers.MainControls.Grid.JGridView.Print", null, new List<object>() { ClassName, ObjectCode, SQL, true, Parameters }).ActionToString() + "'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());return false;" });
                            break;



                        case "pdf":
                            staticButtonsActions.Add(new GridStaticButtonKeyValue() { Key = this.ClientID + "_" + item.ToLower() + "StaticButton", Value = "return false;" });
                            break;
                        case "excel":
                            //staticButtonsActions.Add(new GridStaticButtonKeyValue() { Key = this.ClientID + "_" + item.ToLower() + "StaticButton", Value = "parent.location='Services/Grid/ExcelHandler.ashx?className=" + ClassName + "&objectCode=" + ObjectCode + "&sql=" + SQL.Replace("'", "?!?").Replace("\r\n", " ").Replace("\n\r", " ").Replace("\r", " ").Replace("\n", " ").Replace("/", "_") + "&parameters=" + string.Join(",", Parameters == null ? new object[] { } : Parameters) + "';return false;" });
                            staticButtonsActions.Add(new GridStaticButtonKeyValue() { Key = this.ClientID + "_" + item.ToLower() + "StaticButton", Value = "parent.location='Services/Grid/ExcelHandler.ashx?className=" + ClassName + "&objectCode=" + ObjectCode + "&parameters=" + string.Join(",", Parameters == null ? new object[] { } : Parameters) + "';return false;" });
                            break;
                        case "word":
                            //staticButtonsActions.Add(new GridStaticButtonKeyValue() { Key = this.ClientID + "_" + item.ToLower() + "StaticButton", Value = "parent.location='Services/Grid/WordHandler.ashx?className=" + ClassName + "&objectCode=" + ObjectCode + "&sql=" + SQL.Replace("'", "?!?").Replace("\r\n", " ").Replace("\n\r", " ").Replace("\r", " ").Replace("\n", " ").Replace("/", "_") + "&parameters=" + string.Join(",", Parameters == null ? new object[] { } : Parameters) + "';return false;" });
                            staticButtonsActions.Add(new GridStaticButtonKeyValue() { Key = this.ClientID + "_" + item.ToLower() + "StaticButton", Value = "parent.location='Services/Grid/WordHandler.ashx?className=" + ClassName + "&objectCode=" + ObjectCode + "&parameters=" + string.Join(",", Parameters == null ? new object[] { } : Parameters) + "';return false;" });
                            break;
                        case "csv":
                            //staticButtonsActions.Add(new GridStaticButtonKeyValue() { Key = this.ClientID + "_" + item.ToLower() + "StaticButton", Value = "parent.location='Services/Grid/CSVHandler.ashx?className=" + ClassName + "&objectCode=" + ObjectCode + "&sql=" + SQL.Replace("'", "?!?").Replace("\r\n", " ").Replace("\n\r", " ").Replace("\r", " ").Replace("\n", " ").Replace("/", "_") + "&parameters=" + string.Join(",", Parameters == null ? new object[] { } : Parameters) + "';return false;" });
                            staticButtonsActions.Add(new GridStaticButtonKeyValue() { Key = this.ClientID + "_" + item.ToLower() + "StaticButton", Value = "parent.location='Services/Grid/CSVHandler.ashx?className=" + ClassName + "&objectCode=" + ObjectCode + "&parameters=" + string.Join(",", Parameters == null ? new object[] { } : Parameters) + "';return false;" });
                            break;
                        case "formmanagers":
                            staticButtonsActions.Add(new GridStaticButtonKeyValue() { Key = this.ClientID + "_" + item.ToLower() + "StaticButton", Value = "ShowMenu('" + new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebControllers.MainControls.Grid.JGridView.FormManager", null, new List<object>() { ClassName }).ActionToString() + "'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());return false;" });
                            break;
                        case "forms":
                            staticButtonsActions.Add(new GridStaticButtonKeyValue() { Key = this.ClientID + "_" + item.ToLower() + "StaticButton", Value = "ShowMenu('" + new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebControllers.MainControls.Grid.JGridView.Forms", null, new List<object>() { ClassName }).ActionToString() + "');return false;" });
                            break;
                        case "query":
                            if (!JPermission.CheckPermission("WebControllers.MainControls.Grid.Query.Show"))
                                break;
                            staticButtonsActions.Add(new GridStaticButtonKeyValue() { Key = this.ClientID + "_" + item.ToLower() + "StaticButton", Value = "ShowMenu('" + new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebControllers.MainControls.Grid.JGridView.Query", null, new List<object>() { ClassName, ObjectCode, SQL, Parameters }).ActionToString() + "');return false;" });
                            break;
                    }
                }

        }
        public void Bind()
        {
            JQuery jQuery = new JQuery(ClassName, SQL, ObjectCode, RowColors.GetQuery(), Parameters);
            if (string.IsNullOrWhiteSpace(jQuery.QueryText))
                jQuery.QueryText = SQL;
            Columns = jQuery.GetColumns((WebClassLibrary.SessionManager.Current.Session["WebClassLibrary.JWebDataBase.GetPagerData." + ClassName + "." + ObjectCode+".DB"] as JDataBase),ClassName,ObjectCode.ToString());
            string[] cols = Columns.Split(',');
            if (cols == null || cols.Length == 0)
                return;
            DataTable dummy = new DataTable();
            dummy.Columns.Add(JLanguages._Text("rownumber"));
            for (int i = 0; i < cols.Length; i++)
            {
                //int count = dummy.Columns.Cast<DataColumn>().Count(x => x.ColumnName.ToLower() == ClassLibrary.JLanguages._Text(cols[i].ToLower()).Replace(" ", "_").Replace("/", "_"));
                //dummy.Columns.Add(ClassLibrary.JLanguages._Text(cols[i].ToLower()).Replace(" ", "_x0020_").Replace("/", "_x0020_") + (count > 0 ? "__" + count : ""));
                //dummy.Columns[i + 1].ExtendedProperties.Add("colName", cols[i].ToLower());
                dummy.Columns.Add(dummy.Columns.Contains(ClassLibrary.JLanguages._Text(cols[i].ToLower())) ? cols[i].ToLower() : ClassLibrary.JLanguages._Text(cols[i].ToLower()));
                dummy.Columns[i + 1].ExtendedProperties.Add("colName", cols[i].ToLower().Replace("/", "_"));
            }
            dummy.Rows.Add();
            this.DataSource = dummy;
            this.DataBind();
            //if (gv == null)
            //	gv = new GridView();
            //gv.DataSource = dummy;
            //gv.DataBind();
            if (SUID == null)
                return;
            WebClassLibrary.SessionManager.Current.Session.Add(SUID, this);
        }

        public Telerik.Web.UI.RadWindow GenerateWindow(bool isMaximized = true, bool isClosable = false, bool isModal = false)
        {
            //if (PageSize == 0) PageSize = 10;
            //if (Buttons == null || Buttons == "") Buttons = "Refresh,Print,record_print,PDF,Excel,Word,CSV,Forms,FormManagers,Close";
            //if (PageOrderByField == "") PageOrderByField = "Code";
            //sumFields = SumFields;
            //rowStyles = RowStyles;
            //contextMenuItems = ContextMenuItems;
            //detailKeyFields = DetailKeyFields;
            //SessionSave();
            Telerik.Web.UI.RadWindow radWindow = (new JWindow(SUID, Title)).Generate();
            radWindow.NavigateUrl = "Controls.aspx?SUID=" + SUID;
            radWindow.Title = ClassLibrary.JLanguages._Text(Title);
            WebClassLibrary.JWebManager.SetControlType(WebClassLibrary.JDomains.JControls.JGridView, SUID);
            if (isMaximized) radWindow.InitialBehaviors |= Telerik.Web.UI.WindowBehaviors.Maximize;
            if (isClosable) radWindow.InitialBehaviors |= Telerik.Web.UI.WindowBehaviors.Close;
            radWindow.Modal = isModal;
            radWindow.Controls.Add(this);
            Bind();
            return radWindow;
        }

        public void SessionSave() { }
        void bindContextMenu()
        {
            contextMenu = new HtmlGenericControl("Div");
            contextMenu.ID = "ContextMenuDiv";
            contextMenu.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            contextMenu.Attributes.Add("style", "display: none; position: absolute; background-color: #a1c6d4;");

            ul = new HtmlGenericControl("ul");
            ul.Attributes.Add("style", "list-style: none; padding-top: 0; padding-left: 0; margin-top: 5px;");
            if (ContextMenu == null)
                return;
            //if (contextMenu == null)
            //	//ul = new HtmlGenericControl("ul");
            //	bindContextMenu();
            for (int i = 0; i < ContextMenu.Count; i++)
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                li.Attributes.Add("style", "padding-bottom:5px;");
                HtmlAnchor a = new HtmlAnchor();
                a.Attributes.Add("href", "#");
                a.Attributes.Add("action", ContextMenu[i].Action.ActionToString());
                //a.Attributes.Add("onclick", "ShowMenu('" + value[i].Action.ActionToString() + "{!::!}$('#" + this.ClientID + @"').find('[id*=_GV_] tr').not($('#" + this.ClientID + @"').find('[id*=_GV_] tr:first-child')).children('td:eq(2)').html()');return false;");
                a.InnerText = ContextMenu[i].Text;
                li.Controls.Add(a);
                ul.Controls.Add(li);
            }
        }
        string dialogConfig = "";
        //void bindButtons()
        //{
        //	buttons = new HtmlGenericControl("Div");
        //	buttons.ID = "ButtonsDiv";
        //	buttons.ClientIDMode = System.Web.UI.ClientIDMode.Static;
        //	buttons.Attributes.Add("style", "min-height: 60px");
        //	if (GridButtons == null)
        //		return;
        //	for (int i = 0; i < GridButtons.Count; i++)
        //	{
        //		HtmlButton button = new HtmlButton();
        //		button.Attributes.Add("style", "border-left: 1px black solid; width: auto; height: 50px;padding-left:0px;padding-right:35px; background: url(../" + GridButtons[i].IconUrl.Replace("~/", "") + ") right center no-repeat;background-color:#d5d0d0;max-height:50px;text-align:left");
        //		button.Attributes.Add("onclick", "javascript:$('#" + this.ClientID + GridButtons[i].ID + "DialogDiv').dialog({open: function( event, ui ) {$('#" + this.ClientID + GridButtons[i].ID + "DialogDiv').find(\"*\").css(\"position\", \"static\");$('#" + this.ClientID + GridButtons[i].ID + "DialogDiv').find(\"*\").css(\"overflow\", \"hidden\");},width: 400,height: 400,resizable: false,modal: true,buttons: {\"بستن\": function () {$(this).dialog(\"close\");}}});return false;");
        //		//$('#" + this.ClientID + GridButtons[i].ID + "DialogDiv').find(\"*\").css(\"position\", \"static\");$('#" + this.ClientID + GridButtons[i].ID + "DialogDiv').find(\"*\").css(\"overflow\", \"hidden\");
        //		//button.Attributes.Add("onclick", this.ClientID + GridButtons[i].ID + "DialogDiv_dialog.dialog(\"open\");return false;");
        //		HtmlGenericControl controlDiv = new HtmlGenericControl("Div");
        //		controlDiv.Attributes.Add("style", "display: none;overflow-y: scroll;");
        //		controlDiv.ID = this.ClientID + GridButtons[i].ID + "DialogDiv";
        //		controlDiv.ClientIDMode = System.Web.UI.ClientIDMode.Static;
        //		//controlDiv.Attributes.Add("onload", "");
        //		controlDiv.Attributes.Add("runat", "server");
        //		Control control = WebClassLibrary.JWebManager.CurrentPage.LoadControl(GridButtons[i].Control);
        //		//Control control = WebClassLibrary.JWebManager.CurrentPage.LoadControl(,);
        //		controlDiv.Controls.Add(control);
        //		Controls.Add(controlDiv);
        //		//WebClassLibrary.JWebManager.AddToContentZone(controlDiv);
        //		//dialogConfig = "$(document).ready(function () {";
        //		//dialogConfig += "$('#" + controlDiv.ID + "').find(\"*\").css(\"position\", \"static\");";
        //		//dialogConfig += "$('#" + controlDiv.ID + "').find(\"*\").css(\"overflow\", \"hidden\");";
        //		//dialogConfig += "var " + controlDiv.ID + "_dialog = $('#" + controlDiv.ID + "').dialog({"
        //		//				+ "	resizable: false,"
        //		//				+ "	width: 400,"
        //		//				+ "	height: 400,"
        //		//				+ "	modal: true,"
        //		//				+ "	autoOpen: false,"
        //		//				+ "	buttons: {"
        //		//				+ "		\"بستن\": function () {"
        //		//				+ "			$(this).dialog(\"close\");"
        //		//				+ "		}"
        //		//				+ "	}"
        //		//				+ "});";
        //		//dialogConfig += "});";
        //		button.InnerText = GridButtons[i].Text;
        //		buttons.Controls.Add(button);
        //	}
        //}

        void bindButtons()
        {
            buttons = new HtmlGenericControl("Div");
            buttons.ID = "ButtonsDiv";
            buttons.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            buttons.Attributes.Add("style", "min-height: 60px");
            if (Toolbar != null)
            //return;
            {


                if (staticButtonsActions == null)
                    staticButtonsActions = new List<GridStaticButtonKeyValue>();
                if (Toolbar.Buttons != null)
                    for (int i = 0; i < Toolbar.Buttons.Count; i++)
                    {
                        HtmlButton button = new HtmlButton();
                        button.Attributes.Add("style", "margin-left:2px;border-left: 1px black solid; width: auto; height: 50px;padding-left:0px;padding-right:35px; background: url(../" + Toolbar.Buttons[i].ImageUrl.Replace("~/", "") + ") right center no-repeat;background-color:#d5d0d0;max-height:50px;text-align:left");
                        //button.Attributes.Add("onclick", "ShowMenu('" + Toolbar.Buttons[i].Action.ActionToString() + "'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());return false;");
                        button.Attributes.Add("id", this.ClientID + "_" + Toolbar.Buttons[i].Text.Replace(" ", "_") + "DynamicButton");
                        staticButtonsActions.Add(new GridStaticButtonKeyValue() { Key = this.ClientID + "_" + Toolbar.Buttons[i].Text.Replace(" ", "_") + "DynamicButton", Value = "ShowMenu('" + Toolbar.Buttons[i].Action.ActionToString() + "'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());return false;" });
                        button.InnerText = JLanguages._Text(Toolbar.Buttons[i].Text);
                        buttons.Controls.Add(button);
                    }
            }
            bindStaticButtons();
        }

        void bindStaticButtons()
        {
            if (string.IsNullOrWhiteSpace(Buttons))
                return;
            string styleText = "vertical-align:top;margin-left:2px; width: auto; height: 50px;padding-left:0px;padding-right:35px;background-color:#d5d0d0;max-height:50px;text-align:center";
            string[] btn = Buttons.Split(',');
            if (btn != null && btn.Length > 0)
                foreach (string item in btn)
                {
                    HtmlButton button = new HtmlButton();
                    switch (item.ToLower())
                    {
                        case "refresh":
                            button.Attributes.Add("style", "background: url(../" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_Refresh + ") center center no-repeat;" + styleText);
                            //button.Attributes.Add("onclick", this.ClientID + @"GetTablePager('" + ClassName + "'," + ObjectCode + ",'" + string.Join(",", Parameters == null ? new object[] { } : Parameters) + @"', 1, " + PageSize + @", lastSortingField[0], lastSortingField[1]," + this.ClientID + @"_filterItems);return false;");
                            buttons.Controls.Add(button);
                            button.Attributes.Add("id", this.ClientID + "_" + item.ToLower() + "StaticButton");
                            break;
                        case "print":
                            button.Attributes.Add("style", "background: url(../" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_Print + ") center center no-repeat;" + styleText);
                            //button.Attributes.Add("onclick", "ShowMenu('" + new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebControllers.MainControls.Grid.JGridView.Print", null, new List<object>() { ClassName, ObjectCode, SQL, false, Parameters }).ActionToString() + "'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());return false;");
                            buttons.Controls.Add(button);
                            button.Attributes.Add("id", this.ClientID + "_" + item.ToLower() + "StaticButton");
                            break;
                        case "record_print":
                            button.Attributes.Add("style", "background: url(../" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_RecordPrint + ") center center no-repeat;" + styleText);
                            //button.Attributes.Add("onclick", "ShowMenu('" + new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebControllers.MainControls.Grid.JGridView.Print", null, new List<object>() { ClassName, ObjectCode, SQL, true, Parameters }).ActionToString() + "'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());return false;");
                            buttons.Controls.Add(button);
                            button.Attributes.Add("id", this.ClientID + "_" + item.ToLower() + "StaticButton");
                            break;
                        case "pdf":
                            button.Attributes.Add("style", "background: url(../" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_PDF + ") center center no-repeat;" + styleText);
                            //button.Attributes.Add("onclick", "ShowMenu('" + 1 + "'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());return false;");
                            //button.Attributes.Add("onclick", "parent.location='Services/PdfHandler.ashx?className=" + ClassName + "&objectCode=" + ObjectCode + "&sql=" + SQL + "&parameters=" + string.Join(",", Parameters == null ? new object[] { } : Parameters) + "';return false;");
                            button.Attributes.Add("disabled", "disabled");
                            buttons.Controls.Add(button);
                            button.Attributes.Add("id", this.ClientID + "_" + item.ToLower() + "StaticButton");
                            break;
                        case "excel":
                            button.Attributes.Add("style", "background: url(../" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_Excel + ") center center no-repeat;" + styleText);
                            //button.Attributes.Add("onclick", "ShowMenu('" + new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebControllers.MainControls.Grid.JGridView.ToExcel", null, new List<object>() { ClassName, ObjectCode, SQL, Parameters }).ActionToString() + "'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());return false;");
                            //button.Attributes.Add("onclick", "parent.location='Services/ExcelHandler.ashx?className=" + ClassName + "&objectCode=" + ObjectCode + "&sql=" + SQL + "&parameters=" + string.Join(",", Parameters == null ? new object[] { } : Parameters) + "';return false;");
                            buttons.Controls.Add(button);
                            button.Attributes.Add("id", this.ClientID + "_" + item.ToLower() + "StaticButton");
                            break;
                        case "word":
                            button.Attributes.Add("style", "background: url(../" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_Word + ") center center no-repeat;" + styleText);
                            //button.Attributes.Add("onclick", "ShowMenu('" + 1 + "'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());return false;");
                            //button.Attributes.Add("onclick", "parent.location='Services/WordHandler.ashx?className=" + ClassName + "&objectCode=" + ObjectCode + "&sql=" + SQL + "&parameters=" + string.Join(",", Parameters == null ? new object[] { } : Parameters) + "';return false;");
                            buttons.Controls.Add(button);
                            button.Attributes.Add("id", this.ClientID + "_" + item.ToLower() + "StaticButton");
                            break;
                        case "csv":
                            button.Attributes.Add("style", "background: url(../" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_CSV + ") center center no-repeat;" + styleText);
                            //button.Attributes.Add("onclick", "ShowMenu('" + 1 + "'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());return false;");
                            //button.Attributes.Add("onclick", "parent.location='Services/CSVHandler.ashx?className=" + ClassName + "&objectCode=" + ObjectCode + "&sql=" + SQL + "&parameters=" + string.Join(",", Parameters == null ? new object[] { } : Parameters) + "';return false;");
                            buttons.Controls.Add(button);
                            button.Attributes.Add("id", this.ClientID + "_" + item.ToLower() + "StaticButton");
                            break;
                        case "formmanagers":
                            button.Attributes.Add("style", "background: url(../" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_FormManagers + ") center center no-repeat;" + styleText);
                            //button.Attributes.Add("onclick", "ShowMenu('" + 1 + "'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());return false;");
                            buttons.Controls.Add(button);
                            button.Attributes.Add("id", this.ClientID + "_" + item.ToLower() + "StaticButton");
                            break;
                        case "forms":
                            button.Attributes.Add("style", "background: url(../" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_Forms + ") center center no-repeat;" + styleText);
                            //button.Attributes.Add("onclick", "ShowMenu('" + 1 + "'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());return false;");
                            buttons.Controls.Add(button);
                            button.Attributes.Add("id", this.ClientID + "_" + item.ToLower() + "StaticButton");
                            break;
                        case "query":
                            if (!JPermission.CheckPermission("WebControllers.MainControls.Grid.Query.Show"))
                                break;
                            button.Attributes.Add("style", "background: url(../" + WebClassLibrary.JDomains.Images.MenuImages.Setting + ") center center no-repeat;" + styleText);
                            //button.Attributes.Add("onclick", "ShowMenu('" + 1 + "'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());return false;");
                            buttons.Controls.Add(button);
                            button.Attributes.Add("id", this.ClientID + "_" + item.ToLower() + "StaticButton");
                            break;
                    }
                }
            // Help Button
            HtmlButton helpButton = new HtmlButton();
            helpButton.Attributes.Add("style", "background: url(../" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_Help + ") center center no-repeat;" + styleText);
            //helpButton.Attributes.Add("onclick", "ShowMenu('" + 1 + "'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());return false;");
            helpButton.Attributes.Add("id", this.ClientID + "_helpStaticButton");
            buttons.Controls.Add(helpButton);
        }
        void writeScript()
        {

            if (ClassName == null)
                return;

            FillStaticButtonsActions();
            string staticButtonsScript = "";
            for (int i = 0; i < staticButtonsActions.Count; i++)
            {
                staticButtonsScript += "$('#" + staticButtonsActions[i].Key + "').click(function (e) {"
                                     + "	" + staticButtonsActions[i].Value
                                     + "});\r\n";
            }
            try
            {
                if (Actions != null && Actions.Count > 0)
                    DoubleClick = new GridEventArgs() { Action = Actions.First(x => x.Event == JDomains.JActionEvents.GridItemDblClick) };
            }
            catch { }
            JQuery jQuery = new JQuery(ClassName, SQL, ObjectCode, RowColors.GetQuery(), Parameters);
            bool hasDBQuery = !string.IsNullOrWhiteSpace(jQuery.QueryText);
            string rightClickEventStr = @"$('#" + this.ClientID + @"').find('[id*=_GV_] tr').not($('#" + this.ClientID + @"').find('[id*=_GV_] tr:first-child')).mousedown(function (e) {
											if( e.button == 2 ) {
												$('#" + this.ClientID + @"').find('[id*=_GV_] tr.selectedRow').removeClass('selectedRow');
												$(this).addClass('selectedRow');
												$('#" + this.ClientID + @"').find('[id*=ContextMenuDiv]').css({'top': e.pageY + 'px', 'left': e.pageX + 'px'}).slideDown();
												return false; 
											} 
											return true;
										});";
            //List<string> fis = new List<string>();
            //for (int i = 0; i < FilterItems.Count; i++)
            //	fis.Add(FilterItems[i].ToString());
            List<string> fieldsList = Columns.Split(',').ToList().ConvertAll(x => x.ToLower().Replace("/", "_"));
            //List<string> fieldsList = new List<string>();
            //List<string> cols = Columns.Split(',').ToList();
            //for (int i = 0; i < cols.Count; i++)
            //{
            //	int count = fieldsList.Count(x => x.ToLower() == ClassLibrary.JLanguages._Text(cols[i].ToLower()).Replace(" ", "_x0020_").Replace("/", "_x0020_"));
            //	fieldsList.Add(ClassLibrary.JLanguages._Text(cols[i].ToLower()).Replace(" ", "_x0020_").Replace("/", "_x0020_") + (count > 0 ? "__" + count : ""));
            // }

            string gridHeaderStr = "$('#" + this.ClientID + @"').find('[id*=_GV_] th').each(function () {";
            for (int i = 0; i < fieldsList.Count; i++)
                gridHeaderStr += "$(this).parent().children('th:eq(" + (i + 1) + ")').attr('colName', '" + fieldsList[i] + "');\r\n";
            gridHeaderStr += "});";
            string clickEventStr = @"$('#" + this.ClientID + @"').find('[id*=_GV_] tr').not($('#" + this.ClientID + @"').find('[id*=_GV_] tr:first-child')).click(function (e) {
															$('#" + this.ClientID + @"').find('[id*=_GV_] tr.selectedRow').removeClass('selectedRow');
															$('#" + this.ClientID + @"').children('[id*=_SelectedKey]').val($(this).children('td:eq(" + (KeyField == null ? 1 : (fieldsList.IndexOf(KeyField.ToLower()) + 1)) + @")').children('div').html());
															$(this).addClass('selectedRow');";
            clickEventStr += Click == null ? "" : @"$('#" + Click.Control + @"').val($(this).children('td:eq(" + (fieldsList.IndexOf(Click.Field.ToLower()) + 1) + @")').children('div').html());";
            clickEventStr += "});";
            string afterDoubleClickEventStr = "";
            string[] afterDoubleClickControls = null;
            if (DoubleClick != null && !string.IsNullOrWhiteSpace(DoubleClick.AfterEventControls) && DoubleClick.AfterEvent == GridEvent.refreshGrid)
            {
                afterDoubleClickControls = DoubleClick.AfterEventControls.Split(',');
                for (int i = 0; i < afterDoubleClickControls.Length; i++)
                    afterDoubleClickEventStr += afterDoubleClickControls[i] + "GetTablePager(" + afterDoubleClickControls[i] + "_query, $('#" + afterDoubleClickControls[i] + "').find('#_LastOpenedPage').val(), $('#" + this.ClientID + @"').find('[id*=_PageSizeTextBox]').val(), $('#" + afterDoubleClickControls[i] + "').find('#_LastSortingField').val().split('|')[0], $('#" + afterDoubleClickControls[i] + "').find('#_LastSortingField').val().split('|')[1]," + this.ClientID + @"_filterItems_fields.join('?!?')+'[:.?!?.:]'+" + this.ClientID + @"_filterItems_vals.join('?!?')," + this.ClientID + @"_sumFields);\r\n";
            }
            //				afterDoubleClickEventStr = " var " + this.ClientID + "_afterDoubleClickControls = '" + DoubleClick.AfterEventControls + "'.split(','); for(var i=0; i<" + this.ClientID + @"_afterDoubleClickControls.length;i++){
            //												alert(" + this.ClientID + "_afterDoubleClickControls[i]);"
            //												+ this.ClientID + "_afterDoubleClickControls[i]+\"GetTablePager\"](" + this.ClientID + "_afterDoubleClickControls[i]+\"_query\", $('#'+" + this.ClientID + @"_afterDoubleClickControls[i]).find('#_LastOpenedPage').val(), " + PageSize + @", $('#'+" + this.ClientID + @"_afterDoubleClickControls[i]).find('#_LastSortingField').val().split('|')[0], $('#'+" + this.ClientID + @"_afterDoubleClickControls[i]).find('#_LastSortingField').val().split('|')[1]);
            //												}";
            string doubleClickEventStr = @"$('#" + this.ClientID + @"').find('[id*=_GV_] tr').not($('#" + this.ClientID + @"').find('[id*=_GV_] tr:first-child')).dblclick(function (e) {
															var idx_dbl = $('#" + this.ClientID + @"').find('[id*=_GV_] tr.filterRow').index();
															if(idx_dbl == $(this).index())
																return false;
															$('#" + this.ClientID + @"').find('[id*=_GV_] tr.selectedRow').removeClass('selectedRow');
															$('#" + this.ClientID + @"').children('[id*=_SelectedKey]').val($(this).children('td:eq(" + (KeyField == null ? 1 : (fieldsList.IndexOf(KeyField.ToLower()) + 1)) + @")').children('div').html());
															$(this).addClass('selectedRow');";
            doubleClickEventStr += DoubleClick == null ? "" : @"ShowMenu('" + DoubleClick.Action.ActionToString() + "'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());";
            doubleClickEventStr += DoubleClick == null ? "" : (DoubleClick.Control == null || DoubleClick.Field == null) ? "" : @"$('#" + DoubleClick.Control + @"').val($(this).children('td:eq(" + (fieldsList.IndexOf(DoubleClick.Field.ToLower()) + 1) + @")').children('div').html());";
            doubleClickEventStr += afterDoubleClickEventStr;
            doubleClickEventStr += "return false;});";
            string contextMenuEvenstStr = ContextMenu == null ? "" : @"$('#" + this.ClientID + @"').find('[id*=ContextMenuDiv] ul li a').click(function (e) {
																			ShowMenu($(this).attr('action')+'{!::!}'+$('#" + this.ClientID + @"').children('[id*=_SelectedKey]').val());return false;
																		});";
            //string query = @"var " + this.ClientID + "_query = \"" + (SQL != null ? "(" + SQL.Replace("'", "''") + ")t1" : Table) + "\";\r\n";
            //string query = @" var " + this.ClientID + "_query =" + (hasDBQuery ? "''" : (HasVariableSQL ? "'('+ $('#" + this.ClientID + @"').find('[id*=_VarSQL]').val() +')t1'" : " \"" + (SQL != null ? "(" + SQL.Replace("'", "?!?").Replace("\r\n", " ").Replace("\n\r", " ").Replace("\r", " ").Replace("\n", " ") + ")t1" : Table) + "\"")) + ";\r\n";
            string query = @" var " + this.ClientID + "_query ='';\r\n";
            string fields = @"var " + this.ClientID + @"_fields = new Array('" + JLanguages._Text("rownumber") + "', '" + fieldsList.Aggregate((x, y) => x + "','" + y) + "');\r\n";
            //string filterItems = @"var " + this.ClientID + "_filterItems = [" + (fis != null && fis.Count > 0 ? "'" + fis.Aggregate((x, y) => x + "','" + y) + "'" : "") + "];\r\n";
            string filterItems_fields = @"var " + this.ClientID + "_filterItems_fields = [];\r\n";
            string filterItems_vals = @"var " + this.ClientID + "_filterItems_vals = [];\r\n";
            string sumFields = @"var " + this.ClientID + "_sumFields = " + (SumFields != null && SumFields.Count > 0 ? "'" + SumFields.Keys.Aggregate((x, y) => x.ToLower() + "," + y.ToLower()) + "'" : "''") + ";\r\n";

            string moneyColumns = @"var " + this.ClientID + "_moneyColumns = [];\r\n";
            if(!string.IsNullOrWhiteSpace(MoneyColumns))
            {
                moneyColumns += this.ClientID + "_moneyColumns = [" + string.Join(",", MoneyColumns.Split(',').Select(x => "'" + x + "'")) + "];\r\n";
            }
            string pageSizeTextBox = @"$($('#" + this.ClientID + @"').find('[id*=_PageSizeTextBox]')).on('input',function(){
											if($(this).val() > " + this.ClientID + @"_recordCount)
												$(this).val(" + this.ClientID + @"_recordCount);
											else if($(this).val() < 5)
												$(this).val(5);
									   });" + Environment.NewLine;
            pageSizeTextBox += @"$($('#" + this.ClientID + @"').find('[id*=_PageSizeTextBox]')).live('keypress', function(e) {
											var code = e.keyCode || e.which;
											if(code == 13){
												" + this.ClientID + @"GetTablePager('" + ClassName + "'," + ObjectCode + ",'" + string.Join(",", Parameters == null ? new object[] { } : Parameters) + @"', parseInt($('#" + this.ClientID + @"').find('.Pager .page').attr('page')), $('#" + this.ClientID + @"').find('[id*=_PageSizeTextBox]').val(), $('#" + this.ClientID + @"').find('#_LastSortingField').val(), ''," + this.ClientID + @"_filterItems_fields.join('?!?')+'[:.?!?.:]'+" + this.ClientID + @"_filterItems_vals.join('?!?')," + this.ClientID + @"_sumFields);
												return false;
											}
									   });";
            string filterItem_InputEvent = @"function " + this.ClientID + @"_onInput_FilterBox(field, filterBoxId) {
												var field_index = " + this.ClientID + @"_filterItems_fields.indexOf(field);
												if(field_index >= 0)
													" + this.ClientID + @"_filterItems_vals[field_index] = $('#' + filterBoxId).val();
												else {
													" + this.ClientID + @"_filterItems_fields.push(field);
													" + this.ClientID + @"_filterItems_vals.push($('#' + filterBoxId).val());
												}
												//" + this.ClientID + @"GetTablePager('" + ClassName + "'," + ObjectCode + ",'" + string.Join(",", Parameters == null ? new object[] { } : Parameters) + @"', parseInt($('#" + this.ClientID + @"').find('.Pager .page').attr('page')), $('#" + this.ClientID + @"').find('[id*=_PageSizeTextBox]').val(), $('#" + this.ClientID + @"').find('#_LastSortingField').val(), ''," + this.ClientID + @"_filterItems_fields.join('?!?')+'[:.?!?.:]'+" + this.ClientID + @"_filterItems_vals.join('?!?')," + this.ClientID + @"_sumFields);
											};" + Environment.NewLine;
            filterItem_InputEvent += "function " + this.ClientID + @"_onInput_ExecFilter(){
											" + this.ClientID + @"GetTablePager('" + ClassName + "'," + ObjectCode + ",'" + string.Join(",", Parameters == null ? new object[] { } : Parameters) + @"', parseInt($('#" + this.ClientID + @"').find('.Pager .page').attr('page')), $('#" + this.ClientID + @"').find('[id*=_PageSizeTextBox]').val(), $('#" + this.ClientID + @"').find('#_LastSortingField').val(), ''," + this.ClientID + @"_filterItems_fields.join('?!?')+'[:.?!?.:]'+" + this.ClientID + @"_filterItems_vals.join('?!?')," + this.ClientID + @"_sumFields);
									 }";
            filterItem_InputEvent += "function " + this.ClientID + @"_onInput_RemoveFilter(){
											" + this.ClientID + @"GetTablePager('" + ClassName + "'," + ObjectCode + ",'" + string.Join(",", Parameters == null ? new object[] { } : Parameters) + @"', parseInt($('#" + this.ClientID + @"').find('.Pager .page').attr('page')), $('#" + this.ClientID + @"').find('[id*=_PageSizeTextBox]').val(), $('#" + this.ClientID + @"').find('#_LastSortingField').val(), '',[].join('?!?')+'[:.?!?.:]'+[].join('?!?')," + this.ClientID + @"_sumFields);
									 }";
            string filterItem_KeypressEvent = "function " + this.ClientID + @"_KeypressEvent(event){
                                            if(event.keyCode == 13) {event.preventDefault(); " + this.ClientID + @"_onInput_ExecFilter();}
									 }";
            string orderByFields = "$('#" + this.ClientID + @"').find('#_LastSortingField').val('" + PageOrderByField + "');";
            string s = @"$(document).ready(function () { " +
                //query +
                //fields +
                gridHeaderStr +
                orderByFields +
                            @"
							$(this).click(function(e){if (e.button != 2) $('#" + this.ClientID + @"').find('[id*=ContextMenuDiv]').hide();});
							document.oncontextmenu = function() { return false;};
							//$('#" + this.ClientID + @"').find('[id*=_GV_] tr').not($('#" + this.ClientID + @"').find('[id*=_GV_] tr:first-child')).each(function () {
							//	$(this).css({'border-bottom' : 'solid black 1px'});
							//});
							//$('#" + this.ClientID + @"').find('[id*=_GV_] tr:first-child th').each(function () {
							//	$(this).css({'align' : 'center'});
							//});
							//$('#" + this.ClientID + @"').find('[id*=_GV_] tr').not($('#" + this.ClientID + @"').find('[id*=_GV_] tr:first-child')).css({ 'background-color': 'White', 'color': 'Black' });
                            //$('#" + this.ClientID + @"').find('#_LastSortingField').val().split('|')[1]
//---------------------------------------------------------------------------------------------------------
							" + this.ClientID + @"GetTablePager('" + ClassName + "'," + ObjectCode + ",'" + string.Join(",", Parameters == null ? new object[] { } : Parameters) + @"', 1, $('#" + this.ClientID + @"').find('[id*=_PageSizeTextBox]').val(), $('#" + this.ClientID + @"').find('#_LastSortingField').val(), ''," + this.ClientID + @"_filterItems_fields.join('?!?')+'[:.?!?.:]'+" + this.ClientID + @"_filterItems_vals.join('?!?')," + this.ClientID + @"_sumFields);
//---------------------------------------------------------------------------------------------------------
							$('#" + this.ClientID + @"').find('.Pager .page').live('click', function () {
								$('#" + this.ClientID + @"').find('#_LastOpenedPage').val($(this).attr('page'));
								//var lastSortingField = $('#" + this.ClientID + @"').find('#_LastSortingField').val().split('|');
                                var lastSortingField = $('#" + this.ClientID + @"').find('#_LastSortingField').val();
//---------------------------------------------------------------------------------------------------------
								" + this.ClientID + @"GetTablePager('" + ClassName + "'," + ObjectCode + ",'" + string.Join(",", Parameters == null ? new object[] { } : Parameters) + @"', parseInt($(this).attr('page')), $('#" + this.ClientID + @"').find('[id*=_PageSizeTextBox]').val(), lastSortingField, ''," + this.ClientID + @"_filterItems_fields.join('?!?')+'[:.?!?.:]'+" + this.ClientID + @"_filterItems_vals.join('?!?')," + this.ClientID + @"_sumFields);
//---------------------------------------------------------------------------------------------------------
							});
							$('#" + this.ClientID + @"').find('[id*=_GV_] tr').mouseover(function () {
								$(this).css({ cursor: 'hand', cursor: 'pointer' });
							});
							$('#" + this.ClientID + @"').find('[id*=_GV_] tr').mouseout(function () {
								$(this).css({ cursor: 'hand', cursor: 'pointer' });
							});" +
                            pageSizeTextBox +
                            clickEventStr +
                            staticButtonsScript +
                            doubleClickEventStr +
                            rightClickEventStr +
                            contextMenuEvenstStr +
                            @"$('#" + this.ClientID + @"').find('[id*=_GV_] th').click(function () {
								if ($(this).attr('sm') == 'asc')
									$(this).attr('sm', 'desc');
								else
									$(this).attr('sm', 'asc');
								//$('#" + this.ClientID + @"').find('#_LastSortingField').val($(this).attr('colName') + '|' + $(this).attr('sm'));
                                $('#" + this.ClientID + @"').find('#_LastSortingField').val($(this).attr('colName') + ' ' + $(this).attr('sm'));
								var page = $('#" + this.ClientID + @"').find('#_LastOpenedPage').val();
//---------------------------------------------------------------------------------------------------------
								" + this.ClientID + @"GetTablePager('" + ClassName + "'," + ObjectCode + ",'" + string.Join(",", Parameters == null ? new object[] { } : Parameters) + @"', page, $('#" + this.ClientID + @"').find('[id*=_PageSizeTextBox]').val(), $(this).attr('colName')+' '+ $(this).attr('sm'),''," + this.ClientID + @"_filterItems_fields.join('?!?')+'[:.?!?.:]'+" + this.ClientID + @"_filterItems_vals.join('?!?')," + this.ClientID + @"_sumFields);
//---------------------------------------------------------------------------------------------------------
							});
						});";
            string pager = "\r\n var " + this.ClientID + "_recordCount = 0;\r\n" +
                                @"
                                var pparameters,ppageIndex,ppageSize,psortField,psortMode,pfilterItems;

                                function " + this.ClientID + @"GetTablePager(className, objectCode, parameters, pageIndex, pageSize, sortField, sortMode, filterItems, sumFields,refresh) {
								
                                pparameters = parameters;
                                ppageIndex = pageIndex;
                                ppageSize = pageSize;
                                psortField = sortField;
                                psortMode = sortMode;
                                pfilterItems = filterItems;

                                if(!className || className == '(undefined)t1')
									return;
								var functionname = 'GetTablePager';
								if(refresh)
									functionname = 'RefreshTablePager';
								else
									functionname = 'GetTablePager';
                                ShowWarining('در  حال بارگذاری ...', true, 3, false);
								$.ajax({
									type: 'POST',
									url: '../Controls.aspx/'+functionname," +
                                    "data: '{\"className\": \"' + className + '\", \"objectCode\": \"' + objectCode + '\", \"parameters\": \"' + parameters + '\", \"pageIndex\": \"' + pageIndex + '\", \"pageSize\": \"' + pageSize + '\", \"sortField\": \"' + sortField + '\", \"sortMode\": \"' + sortMode + '\", \"filterItems\": \"' + filterItems + '\", \"sumFields\": \"' + sumFields + '\"}'," +
                                    @"contentType: 'application/json; charset=utf-8',
									dataType: 'json',
									success: function (response) {" + @"
										var xmlDoc = $.parseXML(response.d);
										var xml = $(xmlDoc);
										fillGrid(response.d, $('#" + this.ClientID + @"').find('[id*=_GV_]').attr('id'), '" + this.ClientID + @"', " + this.ClientID + @"_fields, " + this.ClientID + @"_filterItems_fields, " + this.ClientID + @"_filterItems_vals);
										//fillGrid(response.d, '" + this.ClientID + @"', " + this.ClientID + @"_fields);
										var pager = xml.find('Pager');
                                        ASPSnippetsPager($('#" + this.ClientID + @"').find('.Pager'),{
											                                                                ActiveCssClass: 'current',
											                                                                PagerCssClass: 'pager',
											                                                                PageIndex: parseInt(pager.find('PageIndex').text()),
											                                                                PageSize: parseInt(pager.find('PageSize').text()),
											                                                                RecordCount: parseInt(pager.find('RecordCount').text())
                                                                										}
                                        );
//										$('#" + this.ClientID + @"').find('.Pager').ASPSnippets_Pager({
//											ActiveCssClass: 'current',
//											PagerCssClass: 'pager',
//											PageIndex: parseInt(pager.find('PageIndex').text()),
//											PageSize: parseInt(pager.find('PageSize').text()),
//											RecordCount: parseInt(pager.find('RecordCount').text())
//										});
                                        " + this.ClientID + @"_recordCount = parseInt(pager.find('RecordCount').text());
                                        HideWarining();
                                        $('#" + this.ClientID + @"').find('[id*=_GV_] tr:not(:first):not(:first) td').each(function(){
                                            if(this.innerHTML != '' && this.innerHTML.indexOf('</td>') == -1)
                                            {
                                                $(this).attr('title',this.innerHTML.replace('<br>',' '));
                                                this.innerHTML = ""<div style = 'overflow-x: hidden'>"" + this.innerHTML + ""</div>"";
                                            }
                                        });
									},
									failure: function (response) {
		                                ShowWarining(response.d, true, 1, false);
									},
									error: function (response) {
		                                ShowWarining(response.d, true, 1, false);
									}
								});
							};

							function " + this.ClientID + @"RefreshTablePager(className, objectCode, parameters, pageIndex, pageSize, sortField, sortMode, filterItems, sumFields) {
									var refresh = true;
									" + this.ClientID + @"GetTablePager(className, objectCode, parameters, pageIndex, pageSize, sortField, sortMode, filterItems, sumFields, refresh);
							};";

            if(AutRefreshInterval>0)
            {
                pager += 
                        @"$(function () {
                        setInterval(RefrshAutoGridTable, "+AutRefreshInterval+ @");
                        });

                        function RefrshAutoGridTable() {
									var refresh = true;
									" + this.ClientID + @"GetTablePager('" + ClassName + "'," + ObjectCode + ",pparameters,ppageIndex,ppageSize,psortField,psortMode,pfilterItems," + this.ClientID + @"_sumFields);
							};";
            }
            //		function " + this.ClientID + @"OnSuccess(response) {
            //			var xmlDoc = $.parseXML(response.d);
            //			var xml = $(xmlDoc);
            //	//		var data = xml.find('Table');
            //	//		var row = $('#" + this.ClientID + @"').find('[id*=_GV_] tr:last-child').clone(true);
            //	//		$('#" + this.ClientID + @"').find('[id*=_GV_] tr').not($('#" + this.ClientID + @"').find('[id*=_GV_] tr:first-child')).remove();
            //	//		$.each(data, function () {
            //	//			var d = $(this);
            //	//			for (var i = 0; i < fields.length; i++) {
            //	//				//alert(fields[i]);
            //	//				//alert(d.find(fields[i]).text());
            //	//				$('td', row).eq(i).html(d.find(fields[i]).text());
            //	//			}
            //	//			$('#" + this.ClientID + @"').find('[id*=_GV_]').append(row);
            //	//			row = $('#" + this.ClientID + @"').find('[id*=_GV_] tr:last-child').clone(true);
            //	//		});
            //			fillGrid(response.d, $('#" + this.ClientID + @"').find('[id*=_GV_]').attr('id'), " + this.ClientID + @"_fields);
            //			var pager = xml.find('Pager');
            //			$('#" + this.ClientID + @"').children('.Pager').ASPSnippets_Pager({
            //				ActiveCssClass: 'current',
            //				PagerCssClass: 'pager',
            //				PageIndex: parseInt(pager.find('PageIndex').text()),
            //				PageSize: parseInt(pager.find('PageSize').text()),
            //				RecordCount: parseInt(pager.find('RecordCount').text())
            //			});
            //		};
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered(this.ClientID + "__GV__script_pager"))
                this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), this.ClientID + "__GV__script_pager", query
                    + fields
                    //+ filterItems 
                    + filterItems_fields
                    + filterItems_vals
                    + sumFields
                    +moneyColumns +
                pager, true);
            if (!this.Page.ClientScript.IsStartupScriptRegistered(this.ClientID + "__GV__script"))
                this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), this.ClientID + "__GV__script", filterItem_InputEvent + filterItem_KeypressEvent + s, true);

            //if (!this.Page.ClientScript.IsClientScriptBlockRegistered("dialogConfig__GV__script"))
            //	this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "dialogConfig__GV__script", dialogConfig, true);
            Extensions.AddReferenceText("~/Style/DataGridView.css", this.Page);
            //Extensions.AddReferenceText("~/Script/ASPSnippets_Pager.min.js", this.Page, false);
        }

        #endregion
    }
}