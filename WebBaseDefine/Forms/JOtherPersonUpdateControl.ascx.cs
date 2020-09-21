using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace WebBaseDefine.Forms
{
	public partial class JOtherPersonUpdateControl : System.Web.UI.UserControl
	{
		int code;
		protected void Page_Load(object sender, EventArgs e)
		{
			int.TryParse(Request["Code"], out code);
			#region Set Form
			JOtherPerson person = new JOtherPerson(code);
			txtCode.Text = code.ToString();
			txtTitle.Text = person.Title;
			txtTel.Text = person.Phone;
			txtAddress.Text = person.Address;
			txtDesc.Text = person.Description;
			#endregion
		}
	}
}