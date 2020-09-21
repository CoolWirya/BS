using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace CMSClassLibrary.Controls
{
	public class JSpaceControl:JBaseLabel
	{

		public override void RenderControl(System.Web.UI.HtmlTextWriter writer)
		{
			base.RenderControl(writer);
			this.Width = 70;

		}
	}
}
