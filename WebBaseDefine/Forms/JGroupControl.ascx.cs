using ClassLibrary;
using ClassLibrary.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBaseDefine.Forms
{
	public partial class JGroupControl : System.Web.UI.UserControl
	{
		int code = 0;
		public int Code
		{
			get
			{
				return (int)ViewState["Code"];
			}
			set
			{
				ViewState["Code"] = value;
			}
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack)
				return;
			if (!int.TryParse(Request["Code"], out code))
				return;
			Code = code;
			JPermissionDefineGroup pdg = new JPermissionDefineGroup(Code);
			GroupNameTextBox.Text = pdg.GroupName;
		}
	}
}