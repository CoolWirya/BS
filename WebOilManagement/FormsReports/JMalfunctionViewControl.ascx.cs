using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ClassLibrary;
using WebClassLibrary;

namespace WebOilManagement.FormsReports
{
    public partial class JMalfunctionViewControl : System.Web.UI.UserControl
    {
        

        #region Public
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
        protected void Page_Load(object sender, EventArgs e)
        {



            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("WebOilManagement.FormsReports.JMalfunctionViewControl".Replace(".", "_"));
            jGridView.ClassName = "WebOilManagement.FormsReports.JMalfunctionViewControl";
            jGridView.SQL = "Select * From (" + OilProductsDistributionCompany.Failure.JMalfunctiones.GetWebQuery() + " AND OM.Code IN (" + Request["Query"] + "))S";
            jGridView.Title = Request["Title"];
            jGridView.PageSize = 100;
            jGridView.PageOrderByField = "Code Desc";
            //jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            //jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._MalfunctionNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            //jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, _ConstClassName + "._MalfunctionUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            //jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            //jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._MalfunctionUpdate", null, null));
            //JWebManager.AddWindow(jGridView.GenerateWindow(true, false, false), true);
            ((WebControllers.MainControls.Grid.JGridViewControl)grdMalFunction).GridView = jGridView;
            ((WebControllers.MainControls.Grid.JGridViewControl)grdMalFunction).LoadGrid(true);
        }
        /// ---------------------------------------------------------------------------------------------------------------------------------------------------------
        #endregion Public

      
    }
}