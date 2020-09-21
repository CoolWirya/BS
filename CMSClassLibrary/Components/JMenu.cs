using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMSClassLibrary.BaseControls;
using System.Web.UI.WebControls;
using JJson;
using WebClassLibrary;
using ClassLibrary;

namespace CMSClassLibrary.Components
{
    public class JMenu:JBaseCompositeControl
    {
        Literal Menu;
        string[] Items;
        public JMenu(string args)
        {
            Items = args.Split(',');
        }
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            this.Event = JsonCompositeEvent.OnSelect;
            Menu = new Literal();
            Menu.Text = "<div class=\"container1\"><nav><ul class=\"mcd-menu\">";
           // Menu.Text += "<input type=\"button\" value=\"item0\" onclick=\"dispatchMenuEvent(this);return false;\" itemid=\"9\"></button>";
            for (int i = 0; i < Items.Length; i++)
            {
                Menu.Text += "<li><a href=\"#\" onclick=\"dispatchMenuEvent(this);return false;\" itemid=\""+Items[i].Split('|')[0]+"\" ><strong>" + JLanguages._Text(Items[i].Split('|')[1]) + "</strong><small>sweet home</small></a></li>";
            } 
            // Menu.Text += "<li><a href=\"#\" class=\"active\" onclick=\"dispatchMenuEvent(this);return false;\" itemid=\"8\" ><strong>" + JLanguages._Text("صفحه اصلی") + "</strong><small>sweet home</small></a></li>";
            //Menu.Text += "<li><a href=\"#\" onclick=\"dispatchMenuEvent(this);return false;\" itemid=\"9\" ><strong>" + JLanguages._Text("مبلمان طبی") + "</strong><small>sweet home</small></a></li>";
            //Menu.Text += "<li><a href=\"#\" ><strong>" + JLanguages._Text("کاتالوگ") + "</strong><small>sweet home</small></a></li>";
            //Menu.Text += "<li><a href=\"#\" ><strong>" + JLanguages._Text("درباره ما") + "</strong><small>sweet home</small></a></li>";
            //Menu.Text += "<li><a href=\"#\" ><strong>" + JLanguages._Text("تماس با ما") + "</strong><small>sweet home</small></a></li>";
            //Menu.Text += "<li><a href=\"#\" ><strong>" + JLanguages._Text("تاریخچه مبلمان") + "</strong><small>sweet home</small></a></li>";
            
            //for(int i=0;i<6;i++)
            //{
            //    Menu.Text += "<li><a href=\"#\" class=" + (i == 0 ? "\"active\"" : "") + "><strong>Item" + i + "</strong><small>sweet home</small></a></li>";
            //}
            Menu.Text += " <li class=\"float\"> <a class=\"search\"><input type=\"text\" value=\"SEARCH ...\">  ";
               // "<button><i class=\"fa fa-search\"></i></button></a><a href=\"\" class=\"search-mobile\"><i class=\"fa fa-search\"></i>";
            Menu.Text += "</a> </li></ul></nav></div>";
            this.Controls.Add(Menu);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Literal script = new Literal();
           script.Text = Methods.RegisterMenuScript(this.Page,this.ClientID);
           this.Controls.Add(script);
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            base.Render(writer);
            Literal script = new Literal();
            script.Text = Methods.RegisterJsonScript(Request,this.OnSuccessControlsAction,this.OnErrorControlsAction,this.Validations,this.Page,this.ClientID,this.Event.ToString(),true);
            this.Controls.Add(script);
        }
    }
}
