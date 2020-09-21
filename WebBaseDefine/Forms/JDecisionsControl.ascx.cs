using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using JComponents;
using WebClassLibrary;

namespace WebBaseDefine.Forms
{
	public partial class JDecisionsControl : System.Web.UI.UserControl
	{
		int code = 0;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack || !int.TryParse(Request["Code"], out code))
				return;
			JPermissionDecision pd = new JPermissionDecision(code);
			DecisionTextBox.Text = pd.Name;
		}
	}
}