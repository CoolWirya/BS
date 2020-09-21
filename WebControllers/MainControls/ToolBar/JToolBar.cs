using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebControllers.MainControls.ToolBar
{
    [Serializable()]
    public class JToolBar : ISerializable
    {
        public JToolBar()
        {
        }
        public JToolBar(SerializationInfo info, StreamingContext ctxt)
        {
            Buttons = (List<JToolBarItem>)info.GetValue("Name", typeof(List<JToolBarItem>));

        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Name", Buttons);
        }

        public List<JToolBarItem> Buttons;

        public void AddButton(string Name, string Text, WebClassLibrary.JActionsInfo Action, string ImageUrl = WebClassLibrary.JDomains.Images.Root+ WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Button)
        {
            if (Buttons == null) Buttons = new List<JToolBarItem>();
            JToolBarItem item = new JToolBarItem();
            item.Name = Name;
            item.ImageUrl = ImageUrl;
            item.Text = ClassLibrary.JLanguages._Text(Text);
            item.Action = Action;
            Buttons.Add(item);
        }
    }

    [Serializable()]
    public class JToolBarItem:ISerializable
    {
        public JToolBarItem() { }
        public JToolBarItem(SerializationInfo info, StreamingContext ctxt)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            Text = (string)info.GetValue("Text", typeof(string));
            ImageUrl = (string)info.GetValue("ImageUrl", typeof(string));
            Action = (WebClassLibrary.JActionsInfo)info.GetValue("Action", typeof(WebClassLibrary.JActionsInfo));

        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Name", Name);
            info.AddValue("Text", Text);
            info.AddValue("ImageUrl", ImageUrl);
            info.AddValue("Action", Action);
        }
        public string Name;
        public string Text;
        public string ImageUrl;
        public WebClassLibrary.JActionsInfo Action;
    }
}