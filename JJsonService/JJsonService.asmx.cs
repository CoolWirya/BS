using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
//using Telerik.Web.UI;
using WebClassLibrary;

namespace JJsonService
{
	public class JPage : Page
	{
		public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
		{
		}
		public override bool EnableEventValidation
		{
			get
			{
				return base.EnableEventValidation;
			}
			set
			{
				base.EnableEventValidation = false;
			}
		}
		public string script = "";
		//protected override void OnLoadComplete(EventArgs e)
		//{
		//    base.OnLoadComplete(e);
		//    //script = LoadControl();
		//    //Page pageHolder = new JPage();
		//    Control ControlToRender = LoadControl("FormManager/testUC.ascx");
		//    HtmlForm form = new HtmlForm();
		//    form.Controls.Add(ControlToRender);
		//    this.Controls.Add(form);
		//    //pageHolder.SetRenderMethodDelegate(PageRender);
		//    StringBuilder SB = new StringBuilder();
		//    StringWriter SW = new StringWriter(SB);
		//    HtmlTextWriter htmlTW = new HtmlTextWriter(SW);
		//    try
		//    {
		//        ControlToRender.RenderControl(htmlTW);
		//        script = SB.ToString();
		//    }
		//    catch (Exception)
		//    {
		//        script = SB.ToString();
		//    }
		//}
		protected override void Render(HtmlTextWriter writer)
		{
			base.Render(writer);
			//Control ControlToRender = LoadControl("FormManager/testUC.ascx");
			//HtmlForm form = new HtmlForm();
			//form.Controls.Add(ControlToRender);
			//this.Controls.Add(form);
			//pageHolder.SetRenderMethodDelegate(PageRender);
			//StringBuilder SB = new StringBuilder();
			//StringWriter SW = new StringWriter(SB);
			//HtmlTextWriter htmlTW = new HtmlTextWriter(SW);
			//try
			//{
			//    ControlToRender.RenderControl(htmlTW);
			//    script = SB.ToString();
			//}
			//catch (Exception)
			//{
			//    script = SB.ToString();
			//}
		}
		//protected override void OnPreRender(EventArgs e)
		//{
		//    base.OnPreRender(e);
		//    Control ControlToRender = LoadControl("FormManager/testUC.ascx");
		//    HtmlForm form = new HtmlForm();
		//    form.Controls.Add(ControlToRender);
		//    this.Controls.Add(form);
		//    //pageHolder.SetRenderMethodDelegate(PageRender);
		//    StringBuilder SB = new StringBuilder();
		//    StringWriter SW = new StringWriter(SB);
		//    HtmlTextWriter htmlTW = new HtmlTextWriter(SW);
		//    try
		//    {
		//        ControlToRender.RenderControl(htmlTW);
		//        script = SB.ToString();
		//    }
		//    catch (Exception)
		//    {
		//        script = SB.ToString();
		//    }
		//}
	}

	/// <summary>
	/// Summary description for test
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	[System.Web.Script.Services.ScriptService]
	//[System.ServiceModel.Activation.AspNetCompatibilityRequirements(RequirementsMode=System.ServiceModel.Activation.AspNetCompatibilityRequirementsMode.Required)]
	public class JJsonService : System.Web.Services.WebService, System.Web.SessionState.IRequiresSessionState
	{
		//	WindowBehaviors WindowOptions = WindowBehaviors.None;

		#region Services
		[WebMethod(EnableSession = true)]
		public string test1(string data, JJson.JsonRequestType requestType, JJson.JsonResponseType responseType)
		{
			if (requestType == JJson.JsonRequestType.Direct)
				return data.Split('|')[0].Split(':')[1];
			if (responseType == JJson.JsonResponseType.Table)
				return getDT(data);
			else if (responseType == JJson.JsonResponseType.Row)
				return data.Replace("|", "?!?");
			else if (responseType == JJson.JsonResponseType.Item)
				return data.Split('|')[0].Split(':')[1];//data.Contains("|") ? data.Split('|')[0].Contains(":") ? data.Split('|')[0].Split(':')[1] : data.Split('|')[0] :data.Split(':')[1] : data.Split('|')[0] ;
			//if (requestType == JJson.JsonRequestType.SQL)
			//	return data;
			//if (data.Contains("|"))
			return data.Split('|')[0].Split(':')[1];
			//	return data.Split(':')[1];
		}

		[WebMethod(EnableSession = true)]
		public string getDT(string code)
		{
			//System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
			DataTable dt = new DataTable();
			dt.Columns.Add("col1", typeof(int));
			dt.Columns.Add("col2", typeof(float));
			dt.Columns.Add("col3", typeof(string));
			DataRow dr = dt.NewRow();
			dr.ItemArray = new object[] { 1, 1.5, "red" };
			//dr.AcceptChanges();
			dt.Rows.Add(dr);
			dt.AcceptChanges();
			dr = dt.NewRow();
			dr.ItemArray = new object[] { 2, 2.5, "green" };
			//dr.AcceptChanges();
			dt.Rows.Add(dr);
			dt.AcceptChanges();
			DataSet ds = new DataSet();
			ds.Tables.Add(dt);
			//return ds.GetXml();
			return JJson.Methods.GetJson(dt);
		}

		[WebMethod(EnableSession = true)]
		//[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
		public string Run(string data, JJson.JsonRequestType requestType, JJson.JsonResponseType responseType)
		{
			if (requestType == JJson.JsonRequestType.LoadControl)
			{
				return "loaded";
				//List<object> objs = new List<object>();
				//string[] datas = data.Split('|');
				//for (int i = 1; i < datas.Length; i++)
				//	objs.Add(datas[i].Split(':')[1]);
				//return LoadControl(datas[0].Split(':')[1], objs.ToArray());
			}
			WebClassLibrary.SessionItemCollection sic = WebClassLibrary.JSessionParser.ParseSession(Session.SessionID);
			if (sic == null || sic.Count <= 0)
				return "No Session Detected";
			JJson.Methods.ReinitializeSessions(sic);
			//LoadControl<UserControl>(data.Split('|')[0].Split(':')[1], uc => { });
			string response = "";
			switch (requestType)
			{
				case JJson.JsonRequestType.SQL:
					switch (responseType)
					{
						case JJson.JsonResponseType.Table:
							response = JJson.Methods.GetJson(JJson.Methods.ExecuteQuery(data));
							break;
						case JJson.JsonResponseType.Row:
							response = JJson.Methods.GetJson(JJson.Methods.ExecuteQuery(data), 0);
							break;
						case JJson.JsonResponseType.Item:
							response = JJson.Methods.GetJson(JJson.Methods.ExecuteQuery(data), 0, 0);
							break;
						default:
							break;
					}
					break;
				case JJson.JsonRequestType.Direct:
					response = data;
					break;
				case JJson.JsonRequestType.Other:
					response = data;
					break;
				case JJson.JsonRequestType.Classes:
					string[] tmp = data.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);
					response = RunClassMethod(tmp[0], tmp[1], tmp[2]);
					break;
				default:
					break;
			}
			return response;
		}

		[WebMethod(EnableSession = true)]
		public string RunClassMethod(string className, string methodName, string data)
		{
			try
			{
				string response = "";
				List<string> props = new List<string>();
				List<object> vals = new List<object>();
				string[] pvs = data.Split('|');
				string[] pv;
				for (int i = 0; i < pvs.Length; i++)
				{
					if (pvs.Length <= 0)
						continue;
					pv = pvs[i].Split(':');
					props.Add(pv[0].ToLower());
					vals.Add((object)pv[1]);
				}
				//Assembly asm = Assembly.Load(className.Substring(0, className.IndexOf(".")));
				//object obj = asm.CreateInstance(className);
				object obj = Activator.CreateInstance(className.Substring(0, className.IndexOf(".")), className).Unwrap();
				Type t = obj.GetType();
				for (int i = 0; i < pvs.Length; i++)
				{
					PropertyInfo pi = t.GetProperty(props[i].ToLower(), BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
					if (pi == null || vals[i] == null || vals[i].ToString() == "")
						continue;
					//object val = Convert.ChangeType(vals[i], Type.GetType(pi.PropertyType.FullName));
					object val = null;
					Type piType = Type.GetType(pi.PropertyType.FullName);
					try
					{

						val = Convert.ChangeType(vals[i], piType);
					}
					catch
					{
						if (piType == typeof(int))
							val = 0;
					}
					pi.SetValue(obj, val, null);
				}
				//PropertyInfo[] pis = t.GetProperties();
				//foreach (PropertyInfo pi in t.GetProperties())
				//{
				//    int index = props.IndexOf(pi.Name.ToLower());
				//    if (index < 0)
				//        continue;
				//    pi.SetValue(t., vals[index], null);
				//}
				MethodInfo mi = t.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);// | BindingFlags.GetField | BindingFlags.GetProperty | BindingFlags.SetField | BindingFlags.SetProperty | BindingFlags.Static | BindingFlags.NonPublic);
				if (mi == null)
					return "";
				response = mi.Invoke(obj, null).ToString();
				//response = t.InvokeMember(methodName, BindingFlags.InvokeMethod, null, obj, null).ToString();

				//PropertyInfo fi = t.GetProperty("trace", BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase);
				//response = (fi.GetValue(obj, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase, null, null, null) as List<string>).Aggregate((x, y) => x + "\r\n" + y);
				return response;
			}
			catch (Exception ex)
			{
				return ex.InnerException != null && ex.InnerException.Message != "" ? ex.InnerException.ToString() : ex.Message;
			}
		}

		//public string LoadControl<T>(string uc, Action<T> initControlAction) where T : UserControl
		//{
		//    Page pageHolder = new JPage();
		//    T ControlToRender = (T)pageHolder.LoadControl(uc);
		//    pageHolder.Controls.Add(ControlToRender);
		//    initControlAction(ControlToRender);
		//    StringWriter result = new StringWriter();
		//    System.Web.HttpContext.Current.Server.Execute(pageHolder, result, false);
		//    return result.ToString();
		//}
		protected void PageRender(HtmlTextWriter htw, Control c)
		{
			//StringBuilder SB = new StringBuilder();
			StringWriter sw = new StringWriter();
			//HtmlTextWriter htmlTW = new HtmlTextWriter(SW);
			//c.RenderControl(htw);
			//htw = htmlTW;
			HttpContext.Current.Server.Execute((Page)c, sw, false);
			htw.Write(sw);
		}

		[WebMethod(EnableSession = true)]
		public string LoadControl(string uc, object[] parameters)
		{
			//uc = uc.Replace('/', '.');
			//uc = uc.Replace(HttpContext.Current.Request.ApplicationPath, "");
			//List<Type> constParamTypes = new List<Type>();
			//foreach (object constParam in parameters)
			//	constParamTypes.Add(constParam.GetType());
			JPage pageHolder = new JPage();
			//Control ControlToRender = pageHolder.LoadControl(uc);
			//ConstructorInfo ci = ControlToRender.GetType().BaseType.GetConstructor(constParamTypes.ToArray());
			//if (ci == null)
			//	throw new MemberAccessException("The requested constructor was not found on : " + ControlToRender.GetType().BaseType.ToString());
			//else
			//	ci.Invoke(ControlToRender, parameters);
			Assembly asm = Assembly.LoadFile(Server.MapPath("~/bin/" + uc.Substring(0, uc.IndexOf("/")) + ".dll"));
			uc = uc.Replace('/', '.');
			Type t = asm.GetType(uc.Substring(0, uc.Length - 5));
			Control ControlToRender = (Control)Activator.CreateInstance(t, null);
			HtmlForm form = new HtmlForm();
			form.Controls.Add(ControlToRender);
			pageHolder.Controls.Add(new HtmlHead("header"));
			form.Controls.Add(new ScriptManager());
			StringWriter writer = new StringWriter();
			//pageHolder.Controls.Add(ControlToRender);
			pageHolder.Controls.Add(form);
			HttpContext.Current.Server.Execute(pageHolder, writer, false);
			return writer.ToString();

			//pageHolder.SetRenderMethodDelegate(PageRender);
			//StringBuilder SB = new StringBuilder();
			//StringWriter SW = new StringWriter(SB);
			//HtmlTextWriter htmlTW = new HtmlTextWriter(SW);
			//pageHolder.PreRender += pageHolder_PreRender;
			//try
			//{
			//    //ControlToRender.RenderControl(htmlTW);
			//    //return SB.ToString();
			//}
			//catch (Exception)
			//{
			//    //return SB.ToString();
			//}
			////while (pageHolder.script.Length <= 0) ;
			//return pageHolder.script;
			//return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(ControlToRender);
		}

		void pageHolder_PreRender(object sender, EventArgs e)
		{

		}
		//[WebMethod(EnableSession = true)]
		//public string LoadControl(string uc, bool showInWindow = false)
		//{
		//    using (Page page = new Page())
		//    {
		//        Control userControl = showInWindow ? GenerateWindow(Guid.NewGuid().ToString(), "title", true, 640, 480, false, uc) : page.LoadControl(uc);
		//        //(userControl.FindControl("lblMessage") as Label).Text = message;
		//        //if (showInWindow)
		//        //	page.PreRender += (sender, args) => page.Controls.Add(userControl);
		//        //else
		//        //	page.Controls.Add(userControl);
		//        using (StringWriter writer = new StringWriter())
		//        {
		//            //HtmlHead head = new HtmlHead("header");
		//            HtmlForm form = new HtmlForm();
		//            form.Name = "form1";
		//            form.Controls.Add(userControl);
		//            //page.Controls.Add(head);
		//            page.Controls.Add(form);
		//            //page.EnableViewState = false;


		//            //page.Controls.Add(userControl);


		//            //}
		//            //else
		//            //	//page.Controls.Add(userControl);
		//            //{
		//            //	RadScriptManager rsm = new RadScriptManager();
		//            //	RadAjaxManager ram = new RadAjaxManager();
		//            //	RadAjaxPanel rap = new RadAjaxPanel();
		//            //	RadWindowManager rwm = new RadWindowManager();
		//            //	rwm.Windows.Add((RadWindow)userControl);
		//            //	//ram.ClientEvents.OnRequestStart = "function(){alert('start');}";
		//            //	//ram.ClientEvents.OnResponseEnd = "function(){alert('end');}";
		//            //	rap.Controls.Add(rwm);
		//            //	form.Controls.Add(rsm);
		//            //	form.Controls.Add(ram);
		//            //	form.Controls.Add(rap);
		//            //	//form.Controls.Add(userControl);
		//            //	//rwm.Load += (sender, args) => rwm.Windows.Add((RadWindow)userControl);
		//            //	page.Controls.Add(form);
		//            //	//RadAjaxManager.GetCurrent(page).ResponseScripts.Add(String.Format("$find('{0}').show();", userControl.ClientID));
		//            //	//page.PreRender += (sender, args) => page.Controls.Add(form);
		//            //}

		//            //HttpContext.Current.Server.Execute(page, writer, false);
		//            //return writer.ToString();

		//            string s = RenderControl(page);
		//            return s;
		//            //HtmlTextWriter htw = new HtmlTextWriter(writer);
		//            //page.Load += page_Load;
		//            //userControl.RenderControl(htw);
		//            //return htw.ToString();
		//        }
		//    }
		//}

		private string RenderControl(Control control)
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			StringWriter sw = new StringWriter(sb);
			HtmlTextWriter writer = new HtmlTextWriter(sw);

			control.RenderControl(writer);
			return sb.ToString();
		}
		void page_Load(object sender, EventArgs e)
		{

		}

		#endregion

		#region Methods

		//private DataTable ExecuteQuery(string query)
		//{
		//    DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(query);
		//    return dt;
		//}

		//void ReinitializeSessions(SessionItemCollection sic)
		//{
		//    foreach (SessionItem si in sic)
		//        HttpContext.Current.Session[si.Key] = si.Value;
		//}

		//RadWindow GenerateWindow(string uId, string title, bool isModal, int width, int height, bool isMaximized, string url)
		//{
		//    if (isModal)
		//        WindowOptions = Telerik.Web.UI.WindowBehaviors.Close | Telerik.Web.UI.WindowBehaviors.Move | Telerik.Web.UI.WindowBehaviors.Resize;
		//    Telerik.Web.UI.RadWindow radWindow = new Telerik.Web.UI.RadWindow();
		//    radWindow.ID = "window_" + uId;
		//    radWindow.Title = title;
		//    radWindow.Modal = isModal;
		//    radWindow.AutoSize = true;
		//    radWindow.AutoSizeBehaviors = Telerik.Web.UI.WindowAutoSizeBehaviors.Height | Telerik.Web.UI.WindowAutoSizeBehaviors.Width;
		//    radWindow.Width = width;
		//    radWindow.MinWidth = width;
		//    radWindow.Height = height;
		//    radWindow.MinHeight = height;
		//    radWindow.VisibleOnPageLoad = true;
		//    radWindow.Visible = true;
		//    radWindow.DestroyOnClose = true;
		//    radWindow.VisibleOnPageLoad = true;
		//    radWindow.VisibleStatusbar = false;
		//    radWindow.AutoSize = false;
		//    radWindow.Behaviors = WindowOptions;
		//    if (isMaximized)
		//        radWindow.InitialBehaviors |= Telerik.Web.UI.WindowBehaviors.Maximize;
		//    radWindow.Style.Add("z-index", "2001");
		//    radWindow.RenderMode = Telerik.Web.UI.RenderMode.Lightweight;

		//    return radWindow;
		//}

		//private string GetJson(DataTable dt)
		//{
		//    if (dt == null || dt.Rows.Count < 1)
		//        return "";
		//    System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
		//    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
		//    Dictionary<string, object> row = null;
		//    foreach (DataRow dr in dt.Rows)
		//    {
		//        row = new Dictionary<string, object>();
		//        foreach (DataColumn col in dt.Columns)
		//            row.Add(col.ColumnName, dr[col]);
		//        rows.Add(row);
		//    }
		//    return serializer.Serialize(rows);
		//}

		//private string GetJson(DataTable dt, int rowIndex)
		//{
		//    if (dt == null || dt.Rows.Count < 1)
		//        return "";
		//    System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
		//    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
		//    Dictionary<string, object> row = null;
		//    DataRow dr = dt.Rows[rowIndex];
		//    row = new Dictionary<string, object>();
		//    foreach (DataColumn col in dt.Columns)
		//        row.Add(col.ColumnName, dr[col]);
		//    return serializer.Serialize(row);
		//}

		//private string GetJson(DataTable dt, int rowIndex, int colIndex)
		//{
		//    if (dt == null || dt.Rows.Count < 1)
		//        return "موردی یافت نشد";
		//    System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
		//    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
		//    Dictionary<string, object> row = null;
		//    DataRow dr = dt.Rows[rowIndex];
		//    row = new Dictionary<string, object>();
		//    row.Add(dt.Columns[colIndex].ColumnName, dr[colIndex]);
		//    //return serializer.Serialize(row);
		//    return dr[colIndex].ToString();
		//}

		public static string GetJsonDataTable(DataRow[] drs, List<string> cols = null)
		{
			string col = null;
			string res = "<NewDataSet>\\r\\n";
			for (int i = 0; i < drs.Length; i++)
			{
				res += "<datatable>\\r\\n";
				for (int j = 0; j < (cols == null ? drs[0].Table.Columns.Count : cols.Count); j++)
				{
					col = cols == null ? drs[0].Table.Columns[j].ColumnName : cols[j];
					res += "<" + col + ">" + drs[i][col] + "</" + col + ">\\r\\n";
				}
				res += "</datatable>\\r\\n";
			}
			res += "</NewDataSet>";
			return res;
		}

		#endregion
	}
}
