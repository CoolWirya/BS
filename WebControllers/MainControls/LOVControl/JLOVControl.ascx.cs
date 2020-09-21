using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControllers.MainControls.LOVControl
{
	public partial class JLOVControl : System.Web.UI.UserControl
	{
		#region Properties
		public string SQL
		{
			get
			{
				if (ViewState["SQL"] != null)
					return ViewState["SQL"].ToString();
				return "";
			}
			set
			{
				ViewState["SQL"] = value;
			}
		}
		#endregion

		protected void Page_Load(object sender, EventArgs e)
		{

		}
	}
}