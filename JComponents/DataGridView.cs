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
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using WebClassLibrary;
using WebControllers.MainControls;
using WebControllers.MainControls.ToolBar;

public static class Extensions
{
	public static void ExporttoExcel(this DataTable table)
	{
		string s = "";
		HttpContext.Current.Response.Clear();
		HttpContext.Current.Response.ClearContent();
		HttpContext.Current.Response.ClearHeaders();
		//HttpContext.Current.Response.Buffer = true;
		HttpContext.Current.Response.ContentType = "application/ms-excel";
		s += @"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">";
		HttpContext.Current.Response.AddHeader("Content-type", "application/vnd.ms-excel");
		HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=Reports.xls");
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
		byte[] bytes = new byte[s.Length * sizeof(char)];
		System.Buffer.BlockCopy(s.ToCharArray(), 0, bytes, 0, bytes.Length);
		try
		{
			HttpContext.Current.Response.OutputStream.Write(bytes, 0, bytes.Length);
			HttpContext.Current.Response.Flush();
			HttpContext.Current.Response.End();
		}
		catch (Exception ex)
		{
		}
		//Stream s = HttpContext.Current.Response.OutputStream;


		//HttpContext.Current.Response.Clear();
		//HttpContext.Current.Response.ClearContent();
		//HttpContext.Current.Response.ClearHeaders();
		//HttpContext.Current.Response.Cookies.Clear();
		////Add the header & other information      
		//HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Private);
		//HttpContext.Current.Response.CacheControl = "private";
		//HttpContext.Current.Response.Charset = System.Text.UTF8Encoding.UTF8.WebName;
		//HttpContext.Current.Response.ContentEncoding = System.Text.UTF8Encoding.UTF8;
		//HttpContext.Current.Response.AppendHeader("Content-Length", s.Length.ToString());
		//HttpContext.Current.Response.AppendHeader("Pragma", "cache");
		//HttpContext.Current.Response.AppendHeader("Expires", "60");
		//HttpContext.Current.Response.AppendHeader("Content-Disposition",
		//"attachment; " +
		//"filename=\"ExcelReport.xlsx\"; " +
		//"size=" + s.Length.ToString() + "; " +
		//"creation-date=" + DateTime.Now.ToString("R") + "; " +
		//"modification-date=" + DateTime.Now.ToString("R") + "; " +
		//"read-date=" + DateTime.Now.ToString("R"));
		//HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
		////Write it back to the client    
		//byte[] bytes = null;
		//s.Read(bytes, 0, (int)s.Length);
		//HttpContext.Current.Response.BinaryWrite(bytes);
		//HttpContext.Current.Response.End();
	}
	public static string GetColumns(this JQuery query)
	{
		ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
		DataTable dt = WebClassLibrary.JWebDataBase.GetDataTableStructure(query.QueryText, db);
		string columnNames = string.Join(",", dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName));
		return columnNames;
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
}
namespace JComponents
{
	[Serializable()]
	public class RowStyle
	{
		public string columnName;
		public int fromTime;
		public int toTime;
		public string color;

	}
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

	[DefaultProperty("DataSource")]
	[ToolboxData("<{0}:DataGridView runat=\"server\">")]
	[Serializable()]
	public class DataGridView : CompositeControl, ISerializable
	{
		#region Constructors
		public DataGridView()
		{
		}

		public DataGridView(SerializationInfo info, StreamingContext ctxt)
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
			ToolBar = (JToolBar)info.GetValue("ToolBar", typeof(JToolBar));
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
			DetailKeyFields = (string)info.GetValue("DetailKeyFields", typeof(string));
			IsDetailQueryIn = (bool)info.GetValue("IsDetailQueryIn", typeof(bool));
			PreQuery = (string)info.GetValue("PreQuery", typeof(string));
			Actions = (List<JActionsInfo>)info.GetValue("Actions", typeof(List<JActionsInfo>));
		}

		public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue("ID", ID);
			info.AddValue("SUID", SUID);
			info.AddValue("Title", Title);
			info.AddValue("Click", Click);
			info.AddValue("DoubleClick", DoubleClick);
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
			info.AddValue("ToolBar", ToolBar);
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
		}

		#endregion

		#region Static Buttons Actions

		public string Print(string className, int objectCode, string sql, bool oneRecord, params object[] parameters)
		{
			JQuery jQuery = new JQuery(className, objectCode, parameters);
			if (oneRecord)
				sql = "SELECT * FROM (" + (string.IsNullOrWhiteSpace(jQuery.QueryText) ? sql : jQuery.QueryText) + " )t WHERE t.Code = " + parameters[parameters.Length - 1];
			else
				sql = string.IsNullOrWhiteSpace(jQuery.QueryText) ? sql : jQuery.QueryText;
			return WebClassLibrary.JWebManager.LoadClientControl(className
					, "~/WebReport/Viewer/JReportSelectorControl.ascx"
					, "چاپ"
					, new List<Tuple<string, string>>(){ new Tuple<string, string>("ObjectCode", objectCode.ToString())
                                               ,  new Tuple<string, string>("rSUID", "Report_Dt")
                                               , new Tuple<string, string>("ClassName",className) 
                                               , new Tuple<string,string>("SQL1",sql) }
					, WebClassLibrary.WindowTarget.NewWindow
					, true, true, true, 750, 500);
		}

		public void ToExcel(string className, int objectCode, string sql, params object[] parameters)
		{
			JQuery jQuery = new JQuery(className, objectCode, parameters);
			sql = string.IsNullOrWhiteSpace(jQuery.QueryText) ? sql : jQuery.QueryText;
			JWebDataBase.GetDataTable(sql).ExporttoExcel();
		}

		#endregion

		#region Properties

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
				DoubleClick = new GridEventArgs() { Action = value[0] };
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
				return "Refresh,Print,record_print,PDF,Excel,Word,CSV,Forms,FormManagers,Close";
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
		public string DetailKeyFields
		{
			get
			{
				if (ViewState["DetailKeyFields"] != null)
					return ViewState["DetailKeyFields"].ToString();
				return "";
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
					return ViewState["PageOrderByField"].ToString();
				return "Code";
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
				return null;
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
		public JToolBar ToolBar
		{
			get
			{
				if (ViewState["ToolBar"] != null)
					return ViewState["ToolBar"] as JToolBar;
				return null;
			}
			set
			{
				ViewState["ToolBar"] = value;
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

		#endregion

		#region Overrides

		protected override void CreateChildControls()
		{
			base.CreateChildControls();
			bindButtons();
			Controls.Add(buttons);
			if (gv == null)
				gv = new GridView();
			gv.ID = "_GV_";
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
			Controls.Add(gv);

			pager = new System.Web.UI.HtmlControls.HtmlGenericControl("Div");
			pager.Attributes.Add("class", "Pager");
			pager.Attributes.Add("style", "position: fixed; top: " + (PageSize + 1) * 36 + "px;");
			Controls.Add(pager);

			LastSortingField = new HiddenField();
			LastSortingField.ClientIDMode = System.Web.UI.ClientIDMode.Static;
			LastSortingField.ID = "_LastSortingField";
			LastSortingField.Value = "Code|Asc";
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
			writeScript();
		}

		#endregion

		#region Methods

		public void Bind()
		{
			JQuery jQuery = new JQuery(ClassName, ObjectCode, Parameters);
			Columns = jQuery.GetColumns();
			string[] cols = Columns.Split(',');
			if (cols == null || cols.Length == 0)
				return;
			DataTable dummy = new DataTable();
			dummy.Columns.Add("rownumber");
			for (int i = 0; i < cols.Length; i++)
			{
				dummy.Columns.Add(ClassLibrary.JLanguages._Text(cols[i].ToLower()));
				dummy.Columns[i + 1].ExtendedProperties.Add("colName", cols[i].ToLower());
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
			WebClassLibrary.JWebManager.SetControlType(WebClassLibrary.JDomains.JControls.DataGridView, SUID);
			if (isMaximized) radWindow.InitialBehaviors |= Telerik.Web.UI.WindowBehaviors.Maximize;
			if (isClosable) radWindow.InitialBehaviors |= Telerik.Web.UI.WindowBehaviors.Close;
			radWindow.Modal = isModal;
			radWindow.Controls.Add(this);
			return radWindow;
		}

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
			if (ToolBar == null)
				return;
			for (int i = 0; i < ToolBar.Buttons.Count; i++)
			{
				HtmlButton button = new HtmlButton();
				button.Attributes.Add("style", "margin-left:2px;border-left: 1px black solid; width: auto; height: 50px;padding-left:0px;padding-right:35px; background: url(../" + ToolBar.Buttons[i].ImageUrl.Replace("~/", "") + ") right center no-repeat;background-color:#d5d0d0;max-height:50px;text-align:left");
				button.Attributes.Add("onclick", "ShowMenu('" + ToolBar.Buttons[i].Action.ActionToString() + "'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());return false;");
				button.InnerText = JLanguages._Text(ToolBar.Buttons[i].Text);
				buttons.Controls.Add(button);
			}
			bindStaticButtons();
		}

		void bindStaticButtons()
		{
			if (string.IsNullOrWhiteSpace(Buttons))
				return;
			string[] btn = Buttons.Split(',');
			if (btn != null && btn.Length > 0)
				foreach (string item in btn)
				{
					HtmlButton button = new HtmlButton();
					switch (item.ToLower())
					{
						case "refresh":
							button.Attributes.Add("style", "vertical-align:top;margin-left:2px; width: auto; height: 50px;padding-left:0px;padding-right:35px; background: url(../" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_Refresh + ") center center no-repeat;background-color:#d5d0d0;max-height:50px;text-align:center");
							button.Attributes.Add("onclick", this.ClientID + @"GetTablePager('" + ClassName + "'," + ObjectCode + ",'" + string.Join(",", Parameters == null ? new object[] { } : Parameters) + @"', 1, " + PageSize + @", lastSortingField[0], lastSortingField[1]," + this.ClientID + @"_filterItems);return false;");
							buttons.Controls.Add(button);
							break;
						case "print":
							button.Attributes.Add("style", "vertical-align:top;margin-left:2px; width: auto; height: 50px;padding-left:0px;padding-right:35px; background: url(../" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_Print + ") center center no-repeat;background-color:#d5d0d0;max-height:50px;text-align:center");
							button.Attributes.Add("onclick", "ShowMenu('" + new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "JComponents.DataGridView.Print", null, new List<object>() { ClassName, ObjectCode, SQL, false, Parameters }).ActionToString() + "'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());return false;");
							buttons.Controls.Add(button);
							break;
						case "record_print":
							button.Attributes.Add("style", "vertical-align:top;margin-left:2px; width: auto; height: 50px;padding-left:0px;padding-right:35px; background: url(../" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_RecordPrint + ") center center no-repeat;background-color:#d5d0d0;max-height:50px;text-align:center");
							button.Attributes.Add("onclick", "ShowMenu('" + new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "JComponents.DataGridView.Print", null, new List<object>() { ClassName, ObjectCode, SQL, true, Parameters }).ActionToString() + "'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());return false;");
							buttons.Controls.Add(button);
							break;
						case "pdf":
							button.Attributes.Add("style", "vertical-align:top;margin-left:2px; width: auto; height: 50px;padding-left:0px;padding-right:35px; background: url(../" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_PDF + ") center center no-repeat;background-color:#d5d0d0;max-height:50px;text-align:center");
							//button.Attributes.Add("onclick", "ShowMenu('" + 1 + "'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());return false;");
							//button.Attributes.Add("onclick", "parent.location='Services/PdfHandler.ashx?className=" + ClassName + "&objectCode=" + ObjectCode + "&sql=" + SQL + "&parameters=" + string.Join(",", Parameters == null ? new object[] { } : Parameters) + "';return false;");
							button.Attributes.Add("disabled", "disabled");
							buttons.Controls.Add(button);
							break;
						case "excel":
							button.Attributes.Add("style", "vertical-align:top;margin-left:2px; width: auto; height: 50px;padding-left:0px;padding-right:35px; background: url(../" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_Excel + ") center center no-repeat;background-color:#d5d0d0;max-height:50px;text-align:center");
							//button.Attributes.Add("onclick", "ShowMenu('" + new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "JComponents.DataGridView.ToExcel", null, new List<object>() { ClassName, ObjectCode, SQL, Parameters }).ActionToString() + "'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());return false;");
							button.Attributes.Add("onclick", "parent.location='Services/ExcelHandler.ashx?className=" + ClassName + "&objectCode=" + ObjectCode + "&sql=" + SQL + "&parameters=" + string.Join(",", Parameters == null ? new object[] { } : Parameters) + "';return false;");
							buttons.Controls.Add(button);
							break;
						case "word":
							button.Attributes.Add("style", "vertical-align:top;margin-left:2px; width: auto; height: 50px;padding-left:0px;padding-right:35px; background: url(../" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_Word + ") center center no-repeat;background-color:#d5d0d0;max-height:50px;text-align:center");
							//button.Attributes.Add("onclick", "ShowMenu('" + 1 + "'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());return false;");
							button.Attributes.Add("onclick", "parent.location='Services/WordHandler.ashx?className=" + ClassName + "&objectCode=" + ObjectCode + "&sql=" + SQL + "&parameters=" + string.Join(",", Parameters == null ? new object[] { } : Parameters) + "';return false;");
							buttons.Controls.Add(button);
							break;
						case "csv":
							button.Attributes.Add("style", "vertical-align:top;margin-left:2px; width: auto; height: 50px;padding-left:0px;padding-right:35px; background: url(../" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_CSV + ") center center no-repeat;background-color:#d5d0d0;max-height:50px;text-align:center");
							//button.Attributes.Add("onclick", "ShowMenu('" + 1 + "'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());return false;");
							button.Attributes.Add("onclick", "parent.location='Services/CSVHandler.ashx?className=" + ClassName + "&objectCode=" + ObjectCode + "&sql=" + SQL + "&parameters=" + string.Join(",", Parameters == null ? new object[] { } : Parameters) + "';return false;");
							buttons.Controls.Add(button);
							break;
						case "formmanagers":
							button.Attributes.Add("style", "vertical-align:top;margin-left:2px; width: auto; height: 50px;padding-left:0px;padding-right:35px; background: url(../" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_FormManagers + ") center center no-repeat;background-color:#d5d0d0;max-height:50px;text-align:center");
							button.Attributes.Add("onclick", "ShowMenu('" + 1 + "'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());return false;");
							buttons.Controls.Add(button);
							break;
						case "forms":
							button.Attributes.Add("style", "vertical-align:top;margin-left:2px; width: auto; height: 50px;padding-left:0px;padding-right:35px; background: url(../" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_Forms + ") center center no-repeat;background-color:#d5d0d0;max-height:50px;text-align:center");
							button.Attributes.Add("onclick", "ShowMenu('" + 1 + "'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());return false;");
							buttons.Controls.Add(button);
							break;
					}
				}
			// Help Button
			HtmlButton helpButton = new HtmlButton();
			helpButton.Attributes.Add("style", "vertical-align:top;margin-left:2px; width: auto; height: 50px;padding-left:0px;padding-right:35px; background: url(../" + WebClassLibrary.JDomains.Images.GridViewImages.GridView_Help + ") center center no-repeat;background-color:#d5d0d0;max-height:50px;text-align:center");
			helpButton.Attributes.Add("onclick", "ShowMenu('" + 1 + "'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());return false;");
			buttons.Controls.Add(helpButton);
		}
		void writeScript()
		{
			string rightClickEventStr = @"$('#" + this.ClientID + @"').find('[id*=_GV_] tr').not($('#" + this.ClientID + @"').find('[id*=_GV_] tr:first-child')).mousedown(function (e) {
											if( e.button == 2 ) {
												$('#" + this.ClientID + @"').find('[id*=_GV_] tr.selectedRow').removeClass('selectedRow');
												$(this).addClass('selectedRow');
												$('#" + this.ClientID + @"').find('[id*=ContextMenuDiv]').css({'top': e.pageY + 'px', 'left': e.pageX + 'px'}).slideDown();
												return false; 
											} 
											return true;
										});";
			List<string> fis = new List<string>();
			for (int i = 0; i < FilterItems.Count; i++)
				fis.Add(FilterItems[i].ToString());
			List<string> fieldsList = Columns.Split(',').ToList().ConvertAll(x => x.ToLower());
			string gridHeaderStr = "$('#" + this.ClientID + @"').find('[id*=_GV_] th').each(function () {";
			for (int i = 0; i < fieldsList.Count; i++)
				gridHeaderStr += "$(this).parent().children('th:eq(" + (i + 1) + ")').attr('colName', '" + fieldsList[i] + "');\r\n";
			gridHeaderStr += "});";
			string clickEventStr = @"$('#" + this.ClientID + @"').find('[id*=_GV_] tr').not($('#" + this.ClientID + @"').find('[id*=_GV_] tr:first-child')).click(function (e) {
															$('#" + this.ClientID + @"').find('[id*=_GV_] tr.selectedRow').removeClass('selectedRow');
															$('#" + this.ClientID + @"').children('[id*=_SelectedKey]').val($(this).children('td:eq(" + (KeyField == null ? 1 : (fieldsList.IndexOf(KeyField.ToLower()) + 1)) + @")').html());
															$(this).addClass('selectedRow');";
			clickEventStr += Click == null ? "" : @"$('#" + Click.Control + @"').val($(this).children('td:eq(" + (fieldsList.IndexOf(Click.Field.ToLower()) + 1) + @")').html());";
			clickEventStr += "});";
			string afterDoubleClickEventStr = "";
			string[] afterDoubleClickControls = null;
			if (DoubleClick != null && !string.IsNullOrWhiteSpace(DoubleClick.AfterEventControls) && DoubleClick.AfterEvent == GridEvent.refreshGrid)
			{
				afterDoubleClickControls = DoubleClick.AfterEventControls.Split(',');
				for (int i = 0; i < afterDoubleClickControls.Length; i++)
					afterDoubleClickEventStr += afterDoubleClickControls[i] + "GetTablePager(" + afterDoubleClickControls[i] + "_query, $('#" + afterDoubleClickControls[i] + "').find('#_LastOpenedPage').val(), " + PageSize + @", $('#" + afterDoubleClickControls[i] + "').find('#_LastSortingField').val().split('|')[0], $('#" + afterDoubleClickControls[i] + "').find('#_LastSortingField').val().split('|')[1]," + this.ClientID + @"_filterItems);\r\n";
			}
			//				afterDoubleClickEventStr = " var " + this.ClientID + "_afterDoubleClickControls = '" + DoubleClick.AfterEventControls + "'.split(','); for(var i=0; i<" + this.ClientID + @"_afterDoubleClickControls.length;i++){
			//												alert(" + this.ClientID + "_afterDoubleClickControls[i]);"
			//												+ this.ClientID + "_afterDoubleClickControls[i]+\"GetTablePager\"](" + this.ClientID + "_afterDoubleClickControls[i]+\"_query\", $('#'+" + this.ClientID + @"_afterDoubleClickControls[i]).find('#_LastOpenedPage').val(), " + PageSize + @", $('#'+" + this.ClientID + @"_afterDoubleClickControls[i]).find('#_LastSortingField').val().split('|')[0], $('#'+" + this.ClientID + @"_afterDoubleClickControls[i]).find('#_LastSortingField').val().split('|')[1]);
			//												}";
			string doubleClickEventStr = @"$('#" + this.ClientID + @"').find('[id*=_GV_] tr').not($('#" + this.ClientID + @"').find('[id*=_GV_] tr:first-child')).dblclick(function (e) {
															$('#" + this.ClientID + @"').find('[id*=_GV_] tr.selectedRow').removeClass('selectedRow');
															$('#" + this.ClientID + @"').children('[id*=_SelectedKey]').val($(this).children('td:eq(" + (KeyField == null ? 1 : (fieldsList.IndexOf(KeyField.ToLower()) + 1)) + @")').html());
															$(this).addClass('selectedRow');";
			doubleClickEventStr += DoubleClick == null ? "" : @"ShowMenu('" + DoubleClick.Action.ActionToString() + @"'+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());";
			doubleClickEventStr += DoubleClick == null ? "" : (DoubleClick.Control == null || DoubleClick.Field == null) ? "" : @"$('#" + DoubleClick.Control + @"').val($(this).children('td:eq(" + (fieldsList.IndexOf(DoubleClick.Field.ToLower()) + 1) + @")').html());";
			doubleClickEventStr += afterDoubleClickEventStr;
			doubleClickEventStr += "return false;});";
			string contextMenuEvenstStr = ContextMenu == null ? "" : @"$('#" + this.ClientID + @"').find('[id*=ContextMenuDiv] ul li a').click(function (e) {
																			ShowMenu($(this).attr('action')+'{!::!}'+$('#" + this.ClientID + @"').find('[id*=_SelectedKey]').val());return false;
																		});";
			//string query = @"var " + this.ClientID + "_query = \"" + (SQL != null ? "(" + SQL.Replace("'", "''") + ")t1" : Table) + "\";\r\n";
			string query = @" var " + this.ClientID + "_query =" + (HasVariableSQL ? "'('+ $('#" + this.ClientID + @"').find('[id*=_VarSQL]').val() +')t1'" : " \"" + (SQL != null ? "(" + SQL + ")t1" : Table) + "\"") + ";\r\n";
			string fields = @"var " + this.ClientID + @"_fields = new Array('rownumber', '" + fieldsList.Aggregate((x, y) => x + "','" + y) + "');\r\n";
			string filterItems = @"var " + this.ClientID + "_filterItems = [" + (fis != null && fis.Count > 0 ? "'" + fis.Aggregate((x, y) => x + "','" + y) + "'" : "") + "];\r\n";
			string s = @"$(document).ready(function () { " +
				//query +
				//fields +
				gridHeaderStr +
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
//---------------------------------------------------------------------------------------------------------
							//" + this.ClientID + @"GetTablePager(" + this.ClientID + @"_query, 1, " + PageSize + @", 'code', 'Asc'," + this.ClientID + @"_filterItems);
							" + this.ClientID + @"GetTablePager('" + ClassName + "'," + ObjectCode + ",'" + string.Join(",", Parameters == null ? new object[] { } : Parameters) + @"', 1, " + PageSize + @", 'code', 'Asc'," + this.ClientID + @"_filterItems);
//---------------------------------------------------------------------------------------------------------
							$('#" + this.ClientID + @"').find('.Pager .page').live('click', function () {
								$('#" + this.ClientID + @"').find('#_LastOpenedPage').val($(this).attr('page'));
								var lastSortingField = $('#" + this.ClientID + @"').find('#_LastSortingField').val().split('|');
//---------------------------------------------------------------------------------------------------------
								//" + this.ClientID + @"GetTablePager(" + this.ClientID + @"_query, parseInt($(this).attr('page')), " + PageSize + @", lastSortingField[0], lastSortingField[1]," + this.ClientID + @"_filterItems);
								" + this.ClientID + @"GetTablePager('" + ClassName + "'," + ObjectCode + ",'" + string.Join(",", Parameters == null ? new object[] { } : Parameters) + @"', parseInt($(this).attr('page')), " + PageSize + @", lastSortingField[0], lastSortingField[1]," + this.ClientID + @"_filterItems);
//---------------------------------------------------------------------------------------------------------
							});
							$('#" + this.ClientID + @"').find('[id*=_GV_] tr').mouseover(function () {
								$(this).css({ cursor: 'hand', cursor: 'pointer' });
							});
							$('#" + this.ClientID + @"').find('[id*=_GV_] tr').mouseout(function () {
								$(this).css({ cursor: 'hand', cursor: 'pointer' });
							});" +
							clickEventStr +
							doubleClickEventStr +
							rightClickEventStr +
							contextMenuEvenstStr +
							@"$('#" + this.ClientID + @"').find('[id*=_GV_] th').click(function () {
								if ($(this).attr('sm') == 'asc')
									$(this).attr('sm', 'desc');
								else
									$(this).attr('sm', 'asc');
								$('#" + this.ClientID + @"').find('#_LastSortingField').val($(this).attr('colName') + '|' + $(this).attr('sm'));
								var page = $('#" + this.ClientID + @"').find('#_LastOpenedPage').val();
//---------------------------------------------------------------------------------------------------------
								//" + this.ClientID + @"GetTablePager(" + this.ClientID + @"_query, page, " + PageSize + @", $(this).attr('colName'), $(this).attr('sm')," + this.ClientID + @"_filterItems);
								" + this.ClientID + @"GetTablePager('" + ClassName + "'," + ObjectCode + ",'" + string.Join(",", Parameters == null ? new object[] { } : Parameters) + @"', page, " + PageSize + @", $(this).attr('colName'), $(this).attr('sm')," + this.ClientID + @"_filterItems);
//---------------------------------------------------------------------------------------------------------
							});
						});";
			string pager = "\r\n function " + this.ClientID + @"GetTablePager(className, objectCode, parameters, pageIndex, pageSize, sortField, sortMode, filterItems) {
								if(!className || className == '(undefined)t1')
									return;
								$.ajax({
									type: 'POST',
									url: '../Controls.aspx/GetTablePager'," +
									"data: '{\"className\": \"' + className + '\", \"objectCode\": \"' + objectCode + '\", \"parameters\": \"' + parameters + '\", \"pageIndex\": \"' + pageIndex + '\", \"pageSize\": \"' + pageSize + '\", \"sortField\": \"' + sortField + '\", \"sortMode\": \"' + sortMode + '\", \"filterItems\": \"' + filterItems + '\"}'," +
									@"contentType: 'application/json; charset=utf-8',
									dataType: 'json',
									success: function (response) {" + @"
										var xmlDoc = $.parseXML(response.d);
										var xml = $(xmlDoc);
										fillGrid(response.d, $('#" + this.ClientID + @"').find('[id*=_GV_]').attr('id'), " + this.ClientID + @"_fields);
										var pager = xml.find('Pager');
										$('#" + this.ClientID + @"').children('.Pager').ASPSnippets_Pager({
											ActiveCssClass: 'current',
											PagerCssClass: 'pager',
											PageIndex: parseInt(pager.find('PageIndex').text()),
											PageSize: parseInt(pager.find('PageSize').text()),
											RecordCount: parseInt(pager.find('RecordCount').text())
										});
									},
									failure: function (response) {
										alert(response.d);
									},
									error: function (response) {
										alert(response.d);
									}
								});
							};";
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
				this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), this.ClientID + "__GV__script_pager", query +
				fields + filterItems +
				pager, true);
			if (!this.Page.ClientScript.IsStartupScriptRegistered(this.ClientID + "__GV__script"))
				this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), this.ClientID + "__GV__script", s, true);

			//if (!this.Page.ClientScript.IsClientScriptBlockRegistered("dialogConfig__GV__script"))
			//	this.Page.ClientScript.RegisterClientScriptBlock(this.Page.GetType(), "dialogConfig__GV__script", dialogConfig, true);
			Extensions.AddReferenceText("~/Style/DataGridView.css", this.Page);
			Extensions.AddReferenceText("~/Script/ASPSnippets_Pager.min.js", this.Page, false);
		}

		#endregion
	}

	//public class DGV : WebClassLibrary.JSessionClass
	//{
	//	private const string SESSION_VARS = "SQL,SQLType,PageOrderByField,PageSize,Actions,Toolbar,Buttons,ClassName,CssClass"
	//											+ ",HiddenColumns,FilterQuery,SumFields,RowStyles,DetailDataSource,DetailKeyFields,IsDetailQueryIn,PreQuery,ContextMenuItems";

	//	public DGV()
	//		: base(SESSION_VARS)
	//	{
	//		// SumFields = new Dictionary<string, double>();
	//	}

	//	public DGV(string sessionUniqueID)
	//		: base(SESSION_VARS, sessionUniqueID)
	//	{
	//		//  SumFields = new Dictionary<string, double>();
	//	}
	//}
}