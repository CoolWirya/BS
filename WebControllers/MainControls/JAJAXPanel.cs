using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebControllers.MainControls
{
    public class JAJAXPanel
    {
        public static Telerik.Web.UI.RadAjaxPanel NewAJAXPanel()
        {
            Telerik.Web.UI.RadAjaxPanel radAjaxPanel = new Telerik.Web.UI.RadAjaxPanel();
            radAjaxPanel.LoadingPanelID = "ralpConfiguration";
            radAjaxPanel.ID = "_" + Guid.NewGuid().ToString();
            return radAjaxPanel;
        }
    }
}