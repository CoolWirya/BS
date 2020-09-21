using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace JJson.Controls
{
    public class JJsonEditor : Literal
    {
        public string width { get; set; }
        public string height { get; set; }
        string style;

        protected override void OnLoad(EventArgs e)
        {
        }

        protected override void CreateChildControls()
        {
            this.Text = "<div id=\"editor\"><div id=\"" + this.ClientID + "_editor\"></div></div>";
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Methods.RegisterEditorScript(this.Page, this.ClientID, style);
        }
    }
}
