using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JJson.BaseControls;
using System.Web.UI.WebControls;

namespace JJson.Components
{
    public class JMenu:JBaseCompositeControl
    {
        Literal Menu;
        protected override void CreateChildControls()
        {
            //base.CreateChildControls();
            this.Event = JsonCompositeEvent.OnSelect;
            Menu = new Literal();
            Menu.Text = "<div class=\"container\"><nav><ul class=\"mcd-menu\">";
            for(int i=0;i<6;i++)
            {
                Menu.Text += "<li><a href=\"#\" class=" + (i == 0 ? "\"active\"" : "") + "><strong>Item" + i + "</strong><small>sweet home</small></a></li>";
            }
            Menu.Text += " <li class=\"float\"> <a class=\"search\"><input type=\"text\" value=\"search ...\">  "+
                "<button><i class=\"fa fa-search\"></i></button></a><a href=\"\" class=\"search-mobile\"><i class=\"fa fa-search\"></i></a> </li>";
            Menu.Text += "</ul></nav></div>";
            this.Controls.Add(Menu);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Methods.RegisterMenuScript(this.Page,this.ClientID);
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            base.Render(writer);
        }
    }
}
