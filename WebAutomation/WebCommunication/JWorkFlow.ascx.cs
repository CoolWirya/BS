using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClassLibrary;

namespace WebAutomation.WebCommunication
{
    public partial class JWorkFlow : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetReport();

        }

        public void GetReport()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("WebAutomation_WebCommunication_JWorkFlow");
            jGridView.ClassName = "WebAutomation_WebCommunication_JWorkFlow";
            jGridView.SQL = "SELECT  Code, ClassName, DynamicClassCode FROM WorkflowObjects ";
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            //jGridView.HiddenColumns = "Code";
            jGridView.Title = "WorkFlow";
            jGridView.PageOrderByField = "Code";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("DesignWorkFlow", "DesignWorkFlow", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebAutomation.WebCommunication.JWorkFlow._DesignWorkFlow", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Actions = new List<JActionsInfo>();
            //jGridView.Actions.Add(new JActionsInfo("Menu", JDomains.JActionEvents.GridItemRightClick, "WebAutomation.JARefer.GetInboxMenu", null, null));
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, "WebAutomation.WebCommunication.JWorkFlow._DesignWorkFlow", null, null));
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).GridView = jGridView;
            ((WebControllers.MainControls.Grid.JGridViewControl)RadGridReport).LoadGrid(true);
        }
        public string _DesignWorkFlow()
        {
            return _DesignWorkFlow(null);
        }

        public string _DesignWorkFlow(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("DesignWorkFlow"
                , "~/WebAutomation/WebCommunication/JDesignWorkFlow.ascx"
                , "طراحی گردش کار"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("ClassRank", code) }
                , WindowTarget.NewWindow
                , true, true, true, 630, 350);
        }
    }
}