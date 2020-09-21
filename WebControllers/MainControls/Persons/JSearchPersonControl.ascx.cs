using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControllers.MainControls
{
	public partial class JSearchPersonControl : System.Web.UI.UserControl
	{


		public bool isReadOnly
		{
			set
			{
				if (value == true)
					btnSearch.Visible = false;
				else
					btnSearch.Visible = true;
			}
		}

		public string PersonName
		{
			get
			{
				return txtPersonName.Text;
			}
		}
		public int PersonCode
		{
			get
			{
				int d;
				int.TryParse(txtPersonCode.Text, out d);
				return d;
			}
			set
			{
				if (value != 0)
				{
					txtPersonCode.Text = value.ToString();
					txtPersonName.Text = (new ClassLibrary.JAllPerson(value)).Name;
				}
				else
				{
					txtPersonCode.Text = "";
					txtPersonName.Text = "";
				}
			}
		}
		protected override void OnPreRender(EventArgs e)
		{
           
			base.OnPreRender(e);
			#region txtPersonCode_Settings
			JJson.JsonResponse txtPersonCode_res = new JJson.JsonResponse();
			txtPersonCode_res.Type = JJson.JsonResponseType.Item;
			txtPersonCode_res.Params = new List<JJson.JsonResponseParam>();
			txtPersonCode_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = txtPersonName.ClientID, Action = JJson.JsonAction.Value, ReturnField = "Return_Field_Name_On_Response" });
			txtPersonCode.OnSuccessControlsAction = new List<JJson.JsonResponse>() { txtPersonCode_res };
			JJson.JsonRequest txtPersonCode_req = new JJson.JsonRequest();
			txtPersonCode_req.URL = "WebControllers/MainControls/CustomListSelector/JCustomListSelectorService.asmx/Run";////GetTitleByCode";
			txtPersonCode_req.Type = JJson.JsonRequestType.SQL;
			txtPersonCode_req.data = "Select Name from clsAllPerson Where Code =@code";
			txtPersonCode_req.Params = new List<JJson.JsonRequestParam>();
			txtPersonCode_req.Params.Add(new JJson.JsonRequestParam() { Name = "@code", Type = JJson.JsonAction.Value, ControlID = txtPersonCode.ClientID });
			txtPersonCode.Request = new List<JJson.JsonRequest>() { txtPersonCode_req };
			JJson.JsonResponse txtPersonCode_error = new JJson.JsonResponse();
			txtPersonCode_error.Params = new List<JJson.JsonResponseParam>();
			txtPersonCode_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
			txtPersonCode.OnErrorControlsAction = new List<JJson.JsonResponse>() { txtPersonCode_error };
			#endregion
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			btnSearch.OnClientClicked = "CallShowMenu_" + txtPersonCode.ClientID;
		}

		protected void btnSearch_Click(object sender, EventArgs e)
		{
		}

		protected void btnUnSelect_Click(object sender, EventArgs e)
		{
			PersonCode = 0;
			txtPersonCode.Text = "";
			txtPersonName.Text = "";
		}

		protected void txtPersonCode_TextChanged(object sender, EventArgs e)
		{
            //qq
			System.Data.DataTable dt = new System.Data.DataTable();
			dt = WebClassLibrary.JWebDataBase.GetDataTable("Select Code, Name from clsAllPerson Where Code =" + txtPersonCode.Text, true);
			if (dt != null && dt.Rows.Count > 0)
			{
				txtPersonName.Text = dt.Rows[0]["Name"].ToString();
			}
			else
			{
				txtPersonCode.Text = string.Empty;
				txtPersonName.Text = string.Empty;
			}
		}
	}
}