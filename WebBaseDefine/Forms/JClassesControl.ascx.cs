using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using ClassLibrary.Domains;

namespace WebBaseDefine.Forms
{
	public partial class JClassesControl : System.Web.UI.UserControl
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
			GroupDropDownList.DataSource = JApplication.JApplicationType.GetData();
			GroupDropDownList.DataValueField = "value";
			GroupDropDownList.DataTextField = "FarsiName";
			GroupDropDownList.DataBind();
			GroupDropDownList.SelectedValue = JApplication.JApplicationType.Automation.ToString();
			if (!int.TryParse(Request["Code"], out code))
				return;
			Code = code;
			JPermissionDefineClass cls = new JPermissionDefineClass(code);
			SQLTextBox.Text = cls.SQL;
			ClassNameTextBox.Text = cls.ClassName;
			GroupDropDownList.SelectedValue = cls.ParentCode.ToString();
		}
	}
}