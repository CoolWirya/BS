using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace CMSClassLibrary.Controls
{
	public class JNewLineControl : Literal
	{
		public override void RenderControl(System.Web.UI.HtmlTextWriter writer)
		{
			this.Text = "<br />";
			base.RenderControl(writer);
		}
	}
}
