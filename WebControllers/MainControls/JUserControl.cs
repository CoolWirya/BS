using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace WebControllers.MainControls
{
	public class JUserControl : UserControl
	{
		public string ExtraField
		{
			get
			{
				if (ViewState["ExtraField"] == null)
					return "";
				return ViewState["ExtraField"].ToString();
			}
			set
			{
				ViewState["ExtraField"] = value;
			}
		}

		public string ControlToSet
		{
			get
			{
				if (ViewState["ControlToSet"] == null)
					return "";
				return ViewState["ControlToSet"].ToString();
			}
			set
			{
				ViewState["ControlToSet"] = value;
			}
		}

		public string PropertyToSet
		{
			get
			{
				if (ViewState["PropertyToSet"] == null)
					return "";
				return ViewState["PropertyToSet"].ToString();
			}
			set
			{
				ViewState["PropertyToSet"] = value;
			}
		}
	}
}