using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Telerik.Web.UI;

namespace WebControllers.MainControls.Menu
{
	public class JMenu
	{
		public List<JMenuItem> MenuItems;

		public void AddMenuItem(string Text, WebClassLibrary.JActionsInfo Action, string ImageUrl = "")
		{
			if (MenuItems == null) MenuItems = new List<JMenuItem>();
			JMenuItem menuitem = new JMenuItem();
			menuitem.Action = Action;
			menuitem.Text = Text;
			menuitem.ImageUrl = ImageUrl;
			MenuItems.Add(menuitem);
		}

	}
	[Serializable()]
	public class JMenuItem : ISerializable
	{
		public string Text;
		public string ImageUrl;
		public WebClassLibrary.JActionsInfo Action;
		public JMenuItem() { }
		public JMenuItem(SerializationInfo info, StreamingContext ctxt)
		{
			Text = (string)info.GetValue("Text", typeof(string));
			ImageUrl = (string)info.GetValue("ImageUrl", typeof(string));
			Action = (WebClassLibrary.JActionsInfo)info.GetValue("Action", typeof(WebClassLibrary.JActionsInfo));

		}

		public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue("Text", Text);
			info.AddValue("ImageUrl", ImageUrl);
			info.AddValue("Action", Action);
		}
		public static WebControllers.MainControls.Menu.JMenuItem Parse(Telerik.Web.UI.RadMenuItem menuItem)
		{
			WebControllers.MainControls.Menu.JMenuItem item = new JMenuItem();
			item.Text = menuItem.Text;
			if (item.Action == null) item.Action = new WebClassLibrary.JActionsInfo();
			List<WebClassLibrary.JActionsInfo> actions = WebClassLibrary.JNode.GetActions(menuItem.Value, false);
			if (actions.Count > 0)
				item.Action = actions.First();
			item.ImageUrl = menuItem.ImageUrl;
			return item;
		}
	}
}