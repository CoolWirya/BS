using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebControllers.MainControls
{
    public class JDockPanel
    {
        public JDockPanel(string uniqueid, string title)
        {
            uniqueID = uniqueid;
            Title = title;
        }
        public JDockPanel()
        {
        }
        
        public string uniqueID;
        public string Title;

        public Telerik.Web.UI.RadDock Generate()
        {
            Telerik.Web.UI.RadDock radDock = new Telerik.Web.UI.RadDock();
            radDock.UniqueName = Guid.NewGuid().ToString();
            radDock.ID = uniqueID;
            radDock.Title = Title;
            radDock.DockMode = Telerik.Web.UI.DockMode.Docked;
            radDock.Width = Unit.Pixel(200);
            Telerik.Web.UI.DockCommand command = new Telerik.Web.UI.DockCommand();
            command.Name = "Close";
            command.Text = "Close";
            radDock.Commands.Add(command);
            return radDock;
        }
    }
}