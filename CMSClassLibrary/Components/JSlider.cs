using CMSClassLibrary.BaseControls;
using JJson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace CMSClassLibrary.Components
{
    public class JSlider : JBaseCompositeControl
    {
         Literal HTMLText = new Literal();
        string[] images;
        public string InnerText { get; set; }
        protected override void OnPreRender(EventArgs e)
        {
            Methods.RegisterSliderScript(this.Page, this.ClientID, "");
            base.OnPreRender(e);
        }
        public JSlider(string parameters)
        {
            images = parameters.Split(',');
           
        }
        public override void RenderControl(System.Web.UI.HtmlTextWriter writer)
        {
            base.RenderControl(writer);
            EnsureChildControls();
            //string script = "$(document).ready(function(){$(document).bind(\"MenuSelect\",function (event){" +
            //    "$(\"#"+this.ClientID+"\").hide();});});";
            //this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "script2", script, true);
            Methods.RegisterJsonScript(Request, OnSuccessControlsAction, OnErrorControlsAction, Validations, this.Page, this.ClientID, this.Event.ToString(), true);
        }

        protected override void RecreateChildControls()
        {
            EnsureChildControls();
        }

       
        protected override void CreateChildControls()
        {
            this.Event = JsonCompositeEvent.OnSelect;
            string text = "<script>$(document).ready(function(){" +
                "$(\"#" + this.ClientID + "\").makeSlider('" + this.ClientID + "');});</script>";
            InnerText = "<div id=\"slideshow\"><div id=\"slideshowWindow\">";
            for (int i = 0; i < images.Length;i++ )
            {
                InnerText += "<div class=\"slide\"><img src=\"" + images[i] + "\" /><div class=\"slideText\"> <h2 class=\"slideTitle\">Slide</h2><p class=\"slideDes\"></p></div></div>";
            }
               // HTMLText.Text += "<div class=\"slide\"><img src=\"../Images/Mobl/slide1.jpg\" /><div class=\"slideText\"> <h2 class=\"slideTitle\">Slide</h2><p class=\"slideDes\"></p></div></div>";
            //for (int i = 1; i <= 3; i++)
            //    HTMLText.Text = HTMLText.Text + "<div class=\"slide\"><img src=\"../Images/slide" + i + ".jpg\" /><div class=\"slideText\"> <h2 class=\"slideTitle\">Slide " + i + "</h2><p class=\"slideDes\"></p></div></div>";
            InnerText = InnerText + "<span class=\"nav\" id=\"leftNav\">Move Left</span>";
            InnerText = InnerText + "<span class=\"nav\" id=\"rightNav\">Move Right</span></div></div>";

            //HTMLText.Text = "<div id=\"slideshow\"><ul class=\"bjqs\">";
            //for (int i = 1; i <= 3; i++)
            //    HTMLText.Text = HTMLText.Text + "<a><img src=\"../Images/" + i + ".jpg\" /></img></a>";
            //HTMLText.Text = HTMLText.Text + "</ul></div>";
            HTMLText.Text = InnerText + text;
            this.Controls.Add(HTMLText);
            this.Controls.Add(new Literal() { ID = "ROW", Text = "<br/>" });

        }

        public string GetHtml()
        {
            return HTMLText.Text;
        }
    }
}
