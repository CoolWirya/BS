using Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAutomation.WebCommunication
{
	public partial class JSecretariatControl : System.Web.UI.UserControl
	{
		int code;
		void SetForm()
		{
			JCSecretariat jclass = null;
			if (code <= 0)
				return;
			jclass = new JCSecretariat(code);
			NameTextBox.Text = jclass.Name;
			ManagerAutoCompleteTextBox.SelectedValue = jclass.Manager_user_post_code.ToString();
			//cmbStorageLetterNo.SelectedValue = jclass.Strg_Code;
			PrefixTextBox.Text = jclass.Prifix;
			PostFixTextBox.Text = jclass.Suffix;
			UsersGridView.DataSource = JsecretariatUsers.GetData(jclass.Code);
			UsersGridView.DataBind();
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			int.TryParse(Request["Code"], out code);
			SetForm();
		}
	}
}