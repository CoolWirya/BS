using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using WebClassLibrary;
using ClassLibrary.DataBase;
using WebControllers.MainControls.Grid;

namespace WebERP
{
    public partial class Controls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            QsfSkinManager.Skin = WebClassLibrary.JWebSettings.GetKey("WebSiteSkin");
            if (!IsPostBack)
            {
                if (Request.QueryString["SUID"] != null)
                {
                    Generate(Request.QueryString["SUID"]);
                }
            }
            else
            {
                Generate(hSUID.Value);
            }
        }

        public void Generate(string SUID)
        {
            if (WebClassLibrary.SessionManager.Current.MainFrame.isAuthenticatedBySUID(SUID) == false) Response.Redirect(WebClassLibrary.JDomains.JErrorUrl.UserNotAuthenticated);
            // Set hidden control value to SUID for next postback.
            hSUID.Value = SUID;

            // Indicates control type
            if (WebClassLibrary.JWebManager.GetControlType(SUID) == WebClassLibrary.JDomains.JControls.JGridView)
            {
                ////// Grid View Control
                //WebControllers.MainControls.Grid.JGridView jGrid = new WebControllers.MainControls.Grid.JGridView(SUID);
                //WebControllers.MainControls.Grid.JGridViewControl jGridViewControl = (WebControllers.MainControls.Grid.JGridViewControl)Page.LoadControl("~/WebControllers/MainControls/Grid/JGridViewControl.ascx");
                //jGridViewControl.ID = "grid_" + SUID;
                //jGridViewControl.GridView = jGrid;
                //Page.FindControl("ContentZone").Controls.Add(jGridViewControl);

                WebControllers.MainControls.Grid.JGridView dgv = Session[SUID] as WebControllers.MainControls.Grid.JGridView;
                //JComponents.DataGridView dgv = Session[SUID] as JComponents.DataGridView;
                //dgv.ID = "grid_" + SUID;
                //dgv.PageIndex = 1;
                //dgv.PageSize = 10;
                //dgv.Columns = "Code,Name";
                //dgv.Table = "clsallperson";
                //dgv.Bind();
                Page.FindControl("ContentZone").Controls.Add(dgv);
            }
            else if (WebClassLibrary.JWebManager.GetControlType(SUID) == WebClassLibrary.JDomains.JControls.JUserControl)
            {
                // Custom User Control
                try
                {
                    System.Web.UI.Control control = Page.LoadControl(WebClassLibrary.JWebManager.GetControlPath());
                    control.ID = "control_" + SUID;
                    Page.FindControl("ContentZone").Controls.Add(control);
                }
                catch (Exception Ex)
                {
                    try
                    {
                        WebClassLibrary.JWebManager.Redirect("Error.aspx?err=5&msg=" + WebClassLibrary.JWebManager.GetControlPath().Replace("~", "") + "&r=" + Ex.Message);
                    }
                    catch { }
                }

            }
            //else if (WebClassLibrary.JWebManager.GetControlType(SUID) == WebClassLibrary.JDomains.JControls.DataGridView)
            //{
            //    // Grid View Control
            //    //WebControllers.MainControls.Grid.JGridView jGrid = new WebControllers.MainControls.Grid.JGridView(SUID);
            //    WebControllers.MainControls.Grid.JGridView dgv = Session[SUID] as WebControllers.MainControls.Grid.JGridView;
            //    //JComponents.DataGridView dgv = Session[SUID] as JComponents.DataGridView;
            //    //dgv.ID = "grid_" + SUID;
            //    //dgv.PageIndex = 1;
            //    //dgv.PageSize = 10;
            //    //dgv.Columns = "Code,Name";
            //    //dgv.Table = "clsallperson";
            //    //dgv.Bind();
            //    Page.FindControl("ContentZone").Controls.Add(dgv);
            //}
        }

        [WebMethod()]
        public static string MenuItemClick(string menuItem)
        {
            string[] inp;
            if (menuItem == "")
                return "";
            inp = menuItem.Split(new string[] { "{!::!}" }, StringSplitOptions.None);
            menuItem = inp[0];

            try
            {
                IEnumerable<WebClassLibrary.JActionsInfo> actionInfo =
                WebClassLibrary.JNode.GetActions(menuItem);//.Where(m => m.Event == WebClassLibrary.JDomains.JActionEvents.MouseClick);
                if (actionInfo != null && actionInfo.Count() > 0)
                {
                    WebClassLibrary.JActionsInfo actInfo = actionInfo.First();
                    if (inp.Count() > 1)
                        for (int i = 1; i < inp.Count(); i++)
                        {
                            actInfo.ParameterValue.Add(inp[i]);
                        }
                    var result = actInfo.runAction();
                    if (result != null)
                        return result.ToString();
                    return "";
                }
                return "";
            }
            catch (Exception ex)
            {
                return "";
            }
        }

		[WebMethod]
		//public static string GetTablePager(string table, int pageIndex, int pageSize, string sortField, string sortMode, string filterItems)
        public static string RefreshTablePager(string className, string objectCode, string parameters, int pageIndex, int pageSize, string sortField, string sortMode, string filterItems, string sumFields)
		{
			string SessionName ="WebClassLibrary.JWebDataBase.GetPagerData." + className + "." + objectCode.ToString()+".DB";
			if (SessionManager.Current.Session[SessionName] != null)
			{
				try
				{
					(SessionManager.Current.Session[SessionName] as JDataBase).Dispose();
					SessionManager.Current.Session[SessionName] = null;
				}
				catch
				{
				}
			}
			return GetTablePager( className,  objectCode,  parameters,  pageIndex,  pageSize,  sortField,  sortMode,  filterItems,  sumFields);
		}

		[WebMethod]
        public static string GetTablePager(string className, string objectCode, string parameters, int pageIndex, int pageSize, string sortField, string sortMode, string filterItems, string sumFields)
        {
            string sql = "";
            string[] fis = filterItems.Split(new string[] { "[:.?!?.:]" }, StringSplitOptions.None);
            string whereClause = "";
            if (fis != null && fis.Length == 2)
            {
                string[] fis_fields = fis[0].Split(new string[] { "?!?" }, StringSplitOptions.None);
                string[] fis_vals = fis[1].Split(new string[] { "?!?" }, StringSplitOptions.None);
                try
                {
                    for (int i = 0; i < fis_fields.Length; i++)
                        if (string.IsNullOrWhiteSpace(fis_vals[i]))
                            continue;
                        else
                            whereClause += " AND [" + fis_fields[i] + "] LIKE N'%" + fis_vals[i] + "%' ";
                }
                catch { }
            }

			if (WebClassLibrary.SessionManager.Current.Session[className+"."+objectCode.ToString()+"."+"OnlineMapLastFilter"] == null)
                WebClassLibrary.SessionManager.Current.Session.Add(className + "." + objectCode.ToString() + "." + "OnlineMapLastFilter", whereClause);
			else
                WebClassLibrary.SessionManager.Current.Session[className + "." + objectCode.ToString() + "." + "OnlineMapLastFilter"] = whereClause;

            string query = "[spGetTablePager]";
            SqlCommand cmd = new SqlCommand(query);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@TableName", table.Replace("'", "?!?").Replace("\r\n", " ").Replace("\n\r", " "));
            object[] _params = parameters.Split(',').Select(x => Convert.ChangeType(x, typeof(object))).ToArray();
            JQuery jQuery = new JQuery(className, int.Parse(objectCode), _params);
            if (string.IsNullOrWhiteSpace(jQuery.QueryText))
                return null;
            sql = jQuery.QueryText ;
            string guid = "";
            if (WebClassLibrary.SessionManager.Current.Session["ViewsList"] == null)
                WebClassLibrary.SessionManager.Current.Session["ViewsList"] = new Dictionary<string, string>();
            Dictionary<string, string> viewsList = (WebClassLibrary.SessionManager.Current.Session["ViewsList"] as Dictionary<string, string>);
            if (viewsList.ContainsKey(className + "___" + objectCode))
                guid = viewsList[className + "___" + objectCode];
            else
            {
                guid = Guid.NewGuid().ToString().Replace("-", "_");
                //viewsList.Add(className + "___" + objectCode, guid);
            }
            cmd.Parameters.AddWithValue("@GUID", guid);
            cmd.Parameters.AddWithValue("@TableName", sql.Replace("'", "?!?").Replace("\r\n", " ").Replace("\n\r", " ").Replace("\r", " ").Replace("\n", " "));
            //cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
            //cmd.Parameters.AddWithValue("@PageSize", pageSize);
            cmd.Parameters.AddWithValue("@SortingField", sortField);
            cmd.Parameters.AddWithValue("@SortingMode", sortMode);
            //cmd.Parameters.AddWithValue("@SumFields", sumFields);
            //cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
            //cmd.Parameters.Add("@SumFieldsResult", SqlDbType.NVarChar, 5000).Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@WhereClause", whereClause);
            return JWebDataBase.GetPagerData(className, objectCode,cmd, sql, pageIndex, pageSize, filterItems, sumFields, jQuery.RowColors, sortField, sortMode, whereClause).GetXmlFromDataset();//.GetXml();
        }
    }
}