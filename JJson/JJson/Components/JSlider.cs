using JJson.BaseControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace JJson.Components
{
    public class JSlider : JBaseCompositeControl
    {
        protected override void OnPreRender(EventArgs e)
        {
            Methods.RegisterSliderScript(this.Page, this.ClientID, "");
            base.OnPreRender(e);
        }

        public override void RenderControl(System.Web.UI.HtmlTextWriter writer)
        {
            base.RenderControl(writer);
            Methods.RegisterJsonScript(Request, OnSuccessControlsAction, OnErrorControlsAction, Validations, this.Page, this.ClientID, this.Event.ToString(), true);
        }

        //public void Render()
        //{
        //    System.IO.TextWriter w=
        //    System.Web.UI.HtmlTextWriter writer=new System.Web.UI.HtmlTextWriter();
        //    RenderControl(writer);

        //}

        protected override void CreateChildControls()
        {
            this.Event = JsonCompositeEvent.OnSelect;
            Literal HTMLText = new Literal();
            HTMLText.Text = "<div id=\"slideshow\"><div id=\"slideshowWindow\">";
            for (int i = 1; i <= 3; i++)
                HTMLText.Text = HTMLText.Text + "<div class=\"slide\"><img src=\"../Images/slide" + i + ".jpg\" /><div class=\"slideText\"> <h2 class=\"slideTitle\">Slide " + i + "</h2><p class=\"slideDes\"></p></div></div>";
            HTMLText.Text = HTMLText.Text + "<span class=\"nav\" id=\"leftNav\">Move Left</span>";
            HTMLText.Text = HTMLText.Text + "<span class=\"nav\" id=\"rightNav\">Move Right</span></div></div>";
            this.Controls.Add(HTMLText);
            this.Controls.Add(new Literal() { ID = "ROW", Text = "<br/>" });

        }

        public string InnerText { get; set; }
    }
}
