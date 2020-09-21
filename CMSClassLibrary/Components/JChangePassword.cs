using CMSClassLibrary.BaseControls;
using JJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace CMSClassLibrary.Components
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
            JsonResponse btnChange_res = new JsonResponse();
            btnChange_res.Type = JsonResponseType.Item;
            btnChange_res.Params = new List<JsonResponseParam>();
            btnChange_res.Params.Add(new JsonResponseParam() { Action = JsonAction.Message });
			btnChange.OnSuccessControlsAction = new List<JsonResponse>() { btnChange_res };
            JsonRequest btnChange_req = new JsonRequest();
			btnChange_req.URL = "JJsonService/JJsonService.asmx/Run";
			btnChange_req.data = "JJsonAdditionalLibrary.JsonComponents.JLoginManager->ChangePassword";
            btnChange_req.Type = JsonRequestType.Classes;
            btnChange_req.Params = new List<JsonRequestParam>();
            btnChange_req.Params.Add(new JsonRequestParam() { Name = "Password", Type = JsonAction.Value, ControlID = txtCurrentPass.ClientID });
            btnChange_req.Params.Add(new JsonRequestParam() { Name = "NewPassword", Type = JsonAction.Value, ControlID = txtNewPass.ClientID });

			btnChange.Request = new List<JsonRequest>() { btnChange_req };
            List<JsonValidation> btnChange_validations = new List<JsonValidation>();
            btnChange_validations.Add(new JsonValidation() { ControlID = txtCurrentPass.ClientID, ValueType = JsonAction.Value, Message = "کلمه عبور فعلی وارد نشده است", RegexType = JsonRegexType.Alphanumeric });
            btnChange_validations.Add(new JsonValidation() { ControlID = txtNewPass.ClientID, ValueType = JsonAction.Value, Message = "کلمه عبور جدید وارد نشده است", RegexType = JsonRegexType.Alphanumeric });
            btnChange_validations.Add(new JsonValidation() { ControlID = txtConfirmNewPass.ClientID, ValueType = JsonAction.Value, OtherControlID = txtNewPass.ClientID, OtherValueType = JsonAction.Value, Message = "کلمه عبور جدید و تکرار آن با هم برابر نیست", RegexType = JsonRegexType.Value, CustomRegex = " != " });
			btnChange.Validations = new List<List<JsonValidation>>() { btnChange_validations };
            JsonResponse btnChange_error = new JsonResponse();
            btnChange_error.Params = new List<JsonResponseParam>();
            btnChange_error.Params.Add(new JsonResponseParam() { Action = JsonAction.Message });
			btnChange.OnErrorControlsAction = new List<JsonResponse>() { btnChange_error }; ;
			#endregion

		}
	}
}
