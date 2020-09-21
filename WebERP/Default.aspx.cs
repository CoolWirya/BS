using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using System.Web.Services;
using WebControllers.MainControls.Grid;

namespace WebERP
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebClassLibrary.SessionManager.Current.Session["UrlAuthority"] = HttpContext.Current.Request.Url.Authority;
            if (
                WebClassLibrary.SessionManager.Current.MainFrame == null
                ||
                WebClassLibrary.SessionManager.Current.MainFrame.isAuthenticated == false) Response.Redirect("~/" + ClassLibrary.JConfig.LoginPage);
            if (
                IsPostBack 
                || 
                ClientScript.IsStartupScriptRegistered("run dashboard") 
                ||
                !JPermission.CheckPermission("WebBaseDefine.JDashboard._Dashboard")
                )
                return;
            ClientScript.RegisterStartupScript(this.GetType(), "run dashboard", "<script>ShowMenu('" + WebBaseDefine.JDashboard.DashboardActionString + "');</script>", false);
        }

        protected void RadSplitter1_Load(object sender, EventArgs e)
        {
            if (WebClassLibrary.SessionManager.Current.MainFrame.isAuthenticated == false) Response.Redirect("~/" + ClassLibrary.JConfig.LoginPage);
            QsfSkinManager.Skin = WebClassLibrary.JWebSettings.GetKey("WebSiteSkin");
            if (Request.QueryString["act"] != null && Request.QueryString["act"] == "logout")
            {
                WebClassLibrary.SessionManager.Current.Dispose();
                WebClassLibrary.JWebManager.Redirect(ClassLibrary.JConfig.LoginPage);
            }

            if (Request.QueryString["cp"] != null && Request.QueryString["cp"] != "")
            {
                string strPost = WebClassLibrary.JDataManager.DecryptString(Request.QueryString["cp"]);
                int postCode = 0;
                int.TryParse(strPost, out postCode);
                WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostCode = postCode;
            }

            WebControllers.MainControls.Tree.JTree jTree = new WebControllers.MainControls.Tree.JTree();

            jTree.SessionUniqueID = "MainMenuTree";
            jTree.Nodes = WebClassLibrary.JApplicationsManager.GetApplicationsNodes();
            jTree.Title = "منوی اصلی";
            Telerik.Web.UI.RadPanelBar rpb = new Telerik.Web.UI.RadPanelBar();
            rpb = jTree.Generate();
            rpb.ExpandMode = Telerik.Web.UI.PanelBarExpandMode.FullExpandedItem;
            rpb.Height = new Unit(100, UnitType.Percentage);

            RightPane.Controls.Add(rpb);
        }

        [WebMethod()]
        public static string MenuItemClick(string menuItem)
        {
            try
            {
                IEnumerable<WebClassLibrary.JActionsInfo> actionInfo =
                WebClassLibrary.JNode.GetActions(menuItem).Where(m => m.Event == WebClassLibrary.JDomains.JActionEvents.MouseClick);
                if (actionInfo != null && actionInfo.Count() > 0)
                {
                    return actionInfo.First().runAction().ToString();
                }
                return "";
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Extensions.AddReferenceText("~/Style/DataGridView.css", this.Page);
        }
    }
}