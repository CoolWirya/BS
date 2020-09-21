using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary.DataBase;

namespace WebControllers.MainControls.Grid
{
	public partial class JGridQueryControl : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack)
				return;
			int objectCode = 0;
			int.TryParse(Request["ObjectCode"], out objectCode);
			string parameters = Request["Parameters"];
			object[] _params = string.IsNullOrWhiteSpace(parameters) ? new object[] { } : parameters.Split(',').Select(x => Convert.ChangeType(x, typeof(object))).ToArray();
			string sql = "";
			if (string.IsNullOrWhiteSpace(Request["ClassName"]))
				sql = Request["Query"];
			JQuery jQuery = new JQuery(Request["ClassName"], Request["Query"], objectCode,null, _params);
			if (!string.IsNullOrWhiteSpace(jQuery.QueryText))
				sql = jQuery.QueryText;
			QueryTextBox.Text = sql;
		}
	}
}