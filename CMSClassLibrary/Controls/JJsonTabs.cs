using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Web.UI;
using JJson;


namespace CMSClassLibrary.Controls
{
    public class JJsonTabs:BaseControls.JBaseCompositeControl
    {
        LiteralControl TabScript;

        public JJsonTabs()
        {
            TabScript = new LiteralControl();
        }
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            TabScript.Text = "<div id=\"tab-container\" class='tab-container'><ul class='etabs'><li class='tab'><a href=\"#tabs1-html\">اقتصادی</a></li>"+
   "<li class='tab'><a href=\"#tabs1-js\">اخبار داخلی</a></li><li class='tab'><a href=\"#tabs1-css\">دیگر دسته بندی ها</a></li></ul>"+
 "<div class='panel-container'><div id=\"tabs1-html\"> متن موردنظر وارد شود</div><div id=\"tabs1-js\">متن موردنظر وارد شود</div><div id=\"tabs1-css\">متن موردنظر وارد شود</div></div></div>";
            this.Controls.Add(TabScript);
        }
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
            Methods.RegisterTabScript(this.Page,this.ClientID);
        }

    }
}
