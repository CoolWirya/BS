using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JComponents
{
	[ToolboxData("<{0}:PersianDatePicker runat=server ></{0}:PersianDatePicker>")]
	public class PersianDatePicker : TextBox
	{
		#region Events
		//TextBox txt;

		//protected override void CreateChildControls()
		//{
		//	base.CreateChildControls();
		//	txt = new TextBox();
		//	txt.ID = this.ClientID + "_pers";
		//	txt.ClientIDMode = System.Web.UI.ClientIDMode.Static;
		//	txt.ReadOnly = true;
		//	txt.Width = 150;
		//	Controls.Add(txt);
		//}

		//protected override void RecreateChildControls()
		//{
		//	base.RecreateChildControls();
		//	EnsureChildControls();
		//}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			//string text = "$(document).ready(function(){$(\"#" + this.ClientID + "_pers\").persianDatepicker(null,null);});";
			string text = "$(document).ready(function(){$(\"#" + this.ClientID + "\").persianDatepicker(null,null);});";
			if (this.Page.ClientScript.IsStartupScriptRegistered(this.ClientID + "_datePicker_Script"))
				return;
			this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), this.ClientID + "_datePicker_Script", text, true);
		}
		#endregion
	}
}
