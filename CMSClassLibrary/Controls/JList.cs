using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMSClassLibrary.BaseControls;

namespace CMSClassLibrary.Controls
{
    public class JList : JBaseCompositeControl
    {
        string[] Items;
        string[] titles;
        System.Web.UI.LiteralControl control;
        public JList()
        {
            control = new System.Web.UI.LiteralControl();
        }

        public JList(string param)
        {
            control = new System.Web.UI.LiteralControl();
            Items = param.Split(',');
            titles = new string[Items.Length];
            for (int i = 0; i < Items.Length; i++)
            {
                CMSClassLibrary.Content.JContent c = new Content.JContent(Int32.Parse(Items[i]));
                if (c != null)
                    titles[i] = c.Title;
            }
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            this.Event = JJson.JsonCompositeEvent.OnSelect;
            control.Text = "<div><ul class=\"jlist\">";
            for (int i = 0; i < Items.Length; i++)
            {
                control.Text += "<li><a href=\"#\" onclick=\"dispatchListEvent(this);return false;\" itemid=\"" + Items[i] + "\" > " + titles[i] + "</a></li>";
            }
            control.Text += "</ul></div>";
            this.Controls.Add(control);
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            base.Render(writer);
            JJson.Methods.RegisterListScript(this.Page, this.ClientID);
            JJson.Methods.RegisterJsonScript(this.Request, this.OnSuccessControlsAction, this.OnErrorControlsAction, this.Validations, this.Page,this.ClientID,this.Event.ToString(),true);
        }
    }
}
