using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace JJson.Controls
{
	public class JBaseLabel : Label
	{
		public override void RenderControl(System.Web.UI.HtmlTextWriter writer)
		{
			this.Attributes.CssStyle.Add("margin-top", "10px");
			this.Attributes.CssStyle.Add("margin-bottom", "10px");
            this.Attributes.CssStyle.Add("padding-right","20px");
			this.Width = 150;
			base.RenderControl(writer);
		}
	}
}
