using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AVL.Controls.ToggleSlide
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:TogglePanel runat=server></{0}:TogglePanel>")]
    public class TogglePanel : Panel
    {
        private double _OpenHeightWidth = 0;
        public TogglePanel()//:base(HtmlTextWriterTag.Div) 
        {

        }
        public string ButtonIconUrl { get; set; }
        private System.Web.UI.WebControls.Orientation _orientation = Orientation.Horizontal;
        public Orientation Orientation { get { return this._orientation; } set { _orientation = value; } }
        protected override void RenderContents(HtmlTextWriter output)
        {
            base.RenderContents(output);
        }
        protected override void RenderChildren(HtmlTextWriter writer)
        {
            if (this._orientation == System.Web.UI.WebControls.Orientation.Horizontal)
            {
                _OpenHeightWidth = this.Height.Value;
                string str = @"<img " + string.Format(@"src='{0}' alt='toggle' onClick=""var a=document.getElementById('{1}');", this.ButtonIconUrl, this.ClientID) + @"if(a.style.height=='0px') {a.style.height='" + _OpenHeightWidth + @"px'; $(this).css('transform'); $(this).css({'transform': 'rotateX(180deg)'});} else {a.style.height='0px'; $(this).css('transform');$(this).css({'transform': 'rotateX(0deg)'})} "" class='ButtonIcon'/>";
                writer.Write(str);

            }
            else
            {
                _OpenHeightWidth = this.Width.Value;
                writer.Write(string.Format(@"<img src='{0}' alt='toggle' onClick=""var a=document.getElementById('{1}');if(a.style.width=='40px') a.style.width='" + _OpenHeightWidth + @"px';else a.style.width='40px'; "" style='position:relative;left:0px;top:0px;'/>", this.ButtonIconUrl, this.ClientID));

            }
            base.RenderChildren(writer);
        }

        

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
        }

        public override void RenderEndTag(HtmlTextWriter writer)
        {
            base.RenderEndTag(writer);
        }
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }
    }
}
