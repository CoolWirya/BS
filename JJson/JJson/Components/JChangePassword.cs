using JJson.BaseControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace JJson.Components
{
    public class JChangePassword : JBaseCompositeControl
	{
		TextBox txtCurrentPass, txtNewPass, txtConfirmNewPass;
		Controls.JJsonButton btnChange;
		protected override void CreateChildControls()
		{
            
			txtCurrentPass = new TextBox();
			txtNewPass = new TextBox();
			txtConfirmNewPass = new TextBox();
			txtCurrentPass.TextMode = TextBoxMode.Password;
			txtNewPass.TextMode = TextBoxMode.Password;
			txtConfirmNewPass.TextMode = TextBoxMode.Password;
			btnChange = new Controls.JJsonButton();
			Controls.Add(txtCurrentPass);

			Controls.Add(txtNewPass);
			Controls.Add(txtConfirmNewPass);
			Controls.Add(btnChange);

		}
		protected override void RecreateChildControls()
		{
			EnsureChildControls();
		}

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			#region btnChange_Settings
			JJson.JsonResponse btnChange_res = new JJson.JsonResponse();
			btnChange_res.Type = JJson.JsonResponseType.Item;
			btnChange_res.Params = new List<JJson.JsonResponseParam>();
			btnChange_res.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
			btnChange.OnSuccessControlsAction = new List<JsonResponse>() { btnChange_res };
			JJson.JsonRequest btnChange_req = new JJson.JsonRequest();
			btnChange_req.URL = "JJsonService/JJsonService.asmx/Run";
			btnChange_req.data = "JJsonAdditionalLibrary.JsonComponents.JLoginManager->ChangePassword";
			btnChange_req.Type = JJson.JsonRequestType.Classes;
			btnChange_req.Params = new List<JJson.JsonRequestParam>();
			btnChange_req.Params.Add(new JJson.JsonRequestParam() { Name = "Password", Type = JJson.JsonAction.Value, ControlID = txtCurrentPass.ClientID });
			btnChange_req.Params.Add(new JJson.JsonRequestParam() { Name = "NewPassword", Type = JJson.JsonAction.Value, ControlID = txtNewPass.ClientID });

			btnChange.Request = new List<JsonRequest>() { btnChange_req };
			List<JJson.JsonValidation> btnChange_validations = new List<JJson.JsonValidation>();
			btnChange_validations.Add(new JJson.JsonValidation() { ControlID = txtCurrentPass.ClientID, ValueType = JJson.JsonAction.Value, Message = "کلمه عبور فعلی وارد نشده است", RegexType = JJson.JsonRegexType.Alphanumeric });
			btnChange_validations.Add(new JJson.JsonValidation() { ControlID = txtNewPass.ClientID, ValueType = JJson.JsonAction.Value, Message = "کلمه عبور جدید وارد نشده است", RegexType = JJson.JsonRegexType.Alphanumeric });
			btnChange_validations.Add(new JJson.JsonValidation() { ControlID = txtConfirmNewPass.ClientID, ValueType = JJson.JsonAction.Value, OtherControlID = txtNewPass.ClientID, OtherValueType = JsonAction.Value, Message = "کلمه عبور جدید و تکرار آن با هم برابر نیست", RegexType = JJson.JsonRegexType.Value, CustomRegex = " != " });
			btnChange.Validations = new List<List<JsonValidation>>() { btnChange_validations };
			JJson.JsonResponse btnChange_error = new JJson.JsonResponse();
			btnChange_error.Params = new List<JJson.JsonResponseParam>();
			btnChange_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
			btnChange.OnErrorControlsAction = new List<JsonResponse>() { btnChange_error }; ;
			#endregion

		}
	}
}
