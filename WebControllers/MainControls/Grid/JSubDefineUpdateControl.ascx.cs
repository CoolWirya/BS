using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControllers.MainControls.Grid
{
	public partial class JSubDefineUpdateControl : System.Web.UI.UserControl
	{
		int Code = 0;
		int BCode = 0;

		protected void Page_Load(object sender, EventArgs e)
		{
			int.TryParse(Request["Code"], out Code);
			string sessionVal = WebClassLibrary.SessionManager.Current.Objects.Get("__subdefine_" + JSubDefine._ConstClassName.Replace(".", "_")).ToString();
			int.TryParse(sessionVal, out BCode);
			BCodeHiddenField.Value = sessionVal;
			if (BCode == 0)
			{
				WebClassLibrary.JWebManager.CloseWindow();
				return;
			}
			_SetForm();
		}

		public void _SetForm()
		{
			if (Code > 0)
			{
				ClassLibrary.JSubBaseDefine jSubBaseDefine = new ClassLibrary.JSubBaseDefine(BCode, Code);
				txtName.Text = jSubBaseDefine.Name;
			}
		}

		public bool Save()
		{
			if (BCode == 0) return false;
			ClassLibrary.JSubBaseDefine jSubBaseDefine = new ClassLibrary.JSubBaseDefine(BCode, Code);
			jSubBaseDefine.BCode = BCode;
			jSubBaseDefine.Name = txtName.Text;

			if (Code > 0)
			{
				return jSubBaseDefine.Update();
			}
			else
				return jSubBaseDefine.Insert() > 0 ? true : false;
		}

		protected void btnSave_Click(object sender, EventArgs e)
		{
			if (Save())
			{
				//WebClassLibrary.JWebManager.CloseAndRefresh();

                WebClassLibrary.JWebManager.RefreshGrid();
                WebClassLibrary.JWebManager.CloseWindow();
			}
		}

		protected void btnDelete_Click(object sender, EventArgs e)
		{
			ClassLibrary.JSubBaseDefine jSubBaseDefine = new ClassLibrary.JSubBaseDefine(BCode);
            if (jSubBaseDefine.Delete(Code))
            {
                WebClassLibrary.JWebManager.RefreshGrid();
                WebClassLibrary.JWebManager.CloseWindow();
            }
		}
	}
}