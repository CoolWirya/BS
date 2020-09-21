using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Web.UI;
using WebClassLibrary;

namespace WebControllers.MainControls.Tree
{
    public class JTree : JSessionClass
    {
        public JTree()
            : base("")
        {
        }

        public string CssClass;
        public List<JNode> Nodes;
        public string Title;

        public Telerik.Web.UI.RadPanelBar Generate()
        {
            RadPanelBar radPanelBar = new RadPanelBar();
            AddToTree(radPanelBar, Nodes, null);
            radPanelBar.ID = "panel_" + SessionUniqueID;
            radPanelBar.CssClass = CssClass;
            //radPanelBar.ItemClick += radPanelBar_ItemClick;
            //radPanelBar.OnClientItemClicked = "ShowMenu('test')";
            //radPanelBar.OnClientItemClicked = "alert('test')";
            radPanelBar.ExpandMode = PanelBarExpandMode.FullExpandedItem;
            return radPanelBar;
        }

        public Telerik.Web.UI.RadDock GenerateDock()
        {
            Telerik.Web.UI.RadDock radDock = (new JDockPanel("dock_" + SessionUniqueID, Title)).Generate();
            radDock.ContentContainer.Controls.Add(Generate());
            return radDock;
        }

        private void AddToTree(RadPanelBar radPanelBar, List<JNode> nodes, RadPanelItem parent)
        {
            if (nodes == null || nodes.Count() == 0) return;
            foreach (JNode node in nodes)
            {
                if (!ClassLibrary.JPermission.CheckPermission(node.ClassName,node.ObjectCode)) 
                    continue;
                RadPanelItem panelNode = new RadPanelItem(ClassLibrary.JLanguages._Text(node.Name));
                if (node.Actions != null && node.Actions.Count() > 0)
                    panelNode.Value = node.ActionsToString();
                panelNode.ImageUrl = node.ImageURL;
                //panelNode.Expanded = true;
                panelNode.NavigateUrl = "javascript:ShowMenu('" + panelNode.Value + "')";
                if (parent == null)
                    radPanelBar.Items.Add(panelNode);
                else
                    parent.Items.Add(panelNode);
                AddToTree(radPanelBar, node._Childs, panelNode);
            }
        }

        //private void radPanelBar_ItemClick(object sender, RadPanelBarEventArgs e)
        //{
        //    IEnumerable<WebClassLibrary.JActionsInfo> actionInfo =
        //        WebClassLibrary.JNode.GetActions(e.Item.Value.ToString()).Where(m => m.Event == WebClassLibrary.JDomains.JActionEvents.MouseClick);
        //    if (actionInfo != null && actionInfo.Count() > 0)
        //    {
        //        actionInfo.First().runAction();
        //    }
        //}
    }
}