using JJson.BaseControls;
using JJson.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace JJson.Components
{
    public class JLogin : JBaseCompositeControl
	{
		TextBox txtUserName, txtPass;
		JJsonButton btnLogin;
		protected override void CreateChildControls()
            
		{
            this.Event = JsonCompositeEvent.OnLogin;
			txtUserName = new TextBox();
			txtPass = new TextBox();
			txtPass.TextMode = TextBoxMode.Password;
			btnLogin = new Controls.JJsonButton();
			Controls.Add(txtUserName);
			Controls.Add(txtPass);
			Controls.Add(btnLogin);
		}

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            base.Render(writer);
            Methods.RegisterJsonScript(Request,OnSuccessControlsAction,OnErrorControlsAction,Validations,this.Page,this.ClientID,this.Event.ToString(),true);
        }

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			#region btnLogin_Settings
			JJson.JsonResponse btnLogin_res = new JJson.JsonResponse();
			btnLogin_res.Type = JJson.JsonResponseType.Item;
			btnLogin_res.Params = new List<JJson.JsonResponseParam>();
			btnLogin_res.Params.Add(new JJson.JsonResponseParam() { Action = JsonAction.Message });
			btnLogin.OnSuccessControlsAction = new List<JsonResponse>() { btnLogin_res };
			JJson.JsonRequest btnLogin_req = new JJson.JsonRequest();
			btnLogin_req.URL = "JJsonService/JJsonService.asmx/Run";
			btnLogin_req.Type = JJson.JsonRequestType.Classes;
			btnLogin_req.data = "JJsonAdditionalLibrary.JsonComponents.JLoginManager->Login";
			btnLogin_req.Params = new List<JJson.JsonRequestParam>();
			btnLogin_req.Params.Add(new JJson.JsonRequestParam() { Name = "UserName", Type = JJson.JsonAction.Value, ControlID = txtUserName.ClientID });
			btnLogin_req.Params.Add(new JJson.JsonRequestParam() { Name = "Password", Type = JJson.JsonAction.Value, ControlID = txtPass.ClientID });
			btnLogin.Request = new List<JsonRequest>() { btnLogin_req };
			List<JJson.JsonValidation> btnLogin_validations = new List<JJson.JsonValidation>();
			btnLogin_validations.Add(new JJson.JsonValidation() { ControlID = txtUserName.ClientID, ValueType = JJson.JsonAction.Value, Message = "نام کاربری وارد نشده است", RegexType = JJson.JsonRegexType.Alphanumeric });
			btnLogin_validations.Add(new JJson.JsonValidation() { ControlID = txtUserName.ClientID, ValueType = JJson.JsonAction.Value, Message = "کلمه عبور وارد نشده است", RegexType = JJson.JsonRegexType.Alphanumeric });
			btnLogin.Validations = new List<List<JsonValidation>>() { btnLogin_validations };
			JJson.JsonResponse btnLogin_error = new JJson.JsonResponse();
			btnLogin_error.Params = new List<JJson.JsonResponseParam>();
			btnLogin_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
			btnLogin.OnErrorControlsAction = new List<JsonResponse>() { btnLogin_error };
			#endregion
		}
	}
}
