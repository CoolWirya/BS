using CMSClassLibrary.BaseControls;
using CMSClassLibrary.Controls;
using JJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using ClassLibrary;
using WebClassLibrary;

namespace CMSClassLibrary.Components
{
    public class JLogin : JBaseCompositeControl
	{
		TextBox txtUserName, txtPass;
		JJsonButton btnLogin;
        JBaseLabel lblUsername, lblPassword;
       

        public JLogin()
        {
            txtUserName = new TextBox();
            txtUserName.ID = "txtUsername";
            txtPass = new TextBox();
            lblPassword = new JBaseLabel();
            lblUsername = new JBaseLabel();
            lblPassword.Text = JLanguages._Text("Password");
            lblUsername.Text = JLanguages._Text("Username");
            btnLogin = new Controls.JJsonButton();
            btnLogin.Text = JLanguages._Text("Login");

        }

        public JLogin(string args)
        {
            txtUserName = new TextBox();
            txtUserName.ID = "txtUsername";
            txtPass = new TextBox();
            lblPassword = new JBaseLabel();
            lblUsername = new JBaseLabel();
            lblPassword.Text = JLanguages._Text("Password");
            lblUsername.Text = JLanguages._Text("Username");
            btnLogin = new Controls.JJsonButton();
            btnLogin.Text = JLanguages._Text("Login");
        }
		protected override void CreateChildControls()
            
		{
            this.Event = JsonCompositeEvent.OnLogin;
			txtPass.TextMode = TextBoxMode.Password;
            Controls.Add(lblUsername);
			Controls.Add(txtUserName);
            Controls.Add(lblPassword);
			Controls.Add(txtPass);
            Controls.Add(Methods.Space);
			Controls.Add(btnLogin);
           // btnLogin.Attributes.Add("onclick", "$(document).trigger({type:\"OnLogin\",name:$(\"#" + txtUserName.ClientID + "\").val());return false;");
           
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
            JsonResponse btnLogin_res = new JsonResponse();
            btnLogin_res.Type = JsonResponseType.Item;
            btnLogin_res.Params = new List<JsonResponseParam>();
            btnLogin_res.Params.Add(new JsonResponseParam() { Action = JsonAction.Message });
            //btnLogin_res.Params.Add(new JsonResponseParam() { Action = JsonAction.JText, Value = "$(document).trigger({type:\"OnLogin\",name:$(\"#" + txtUserName.ClientID + "\").val()});return false;" });
            btnLogin.OnSuccessControlsAction = new List<JsonResponse>() { btnLogin_res };
            JsonRequest btnLogin_req = new JsonRequest();
            btnLogin_req.URL = "../JJsonService/JJsonService.asmx/Run";
            btnLogin_req.Type = JsonRequestType.Classes;
            btnLogin_req.data = "JJsonAdditionalLibrary.JsonComponents.JLoginManager->Login";
            btnLogin_req.Params = new List<JsonRequestParam>();
            btnLogin_req.Params.Add(new JsonRequestParam() { Name = "UserName", Type = JsonAction.Value, ControlID = txtUserName.ClientID });
            btnLogin_req.Params.Add(new JsonRequestParam() { Name = "Password", Type = JsonAction.Value, ControlID = txtPass.ClientID });
            btnLogin.Request = new List<JsonRequest>() { btnLogin_req };
            List<JsonValidation> btnLogin_validations = new List<JsonValidation>();
            btnLogin_validations.Add(new JsonValidation() { ControlID = txtUserName.ClientID, ValueType = JsonAction.Value, Message = "نام کاربری وارد نشده است", RegexType = JsonRegexType.Alphanumeric });
            btnLogin_validations.Add(new JsonValidation() { ControlID = txtUserName.ClientID, ValueType = JsonAction.Value, Message = "کلمه عبور وارد نشده است", RegexType = JsonRegexType.Alphanumeric });
            btnLogin.Validations = new List<List<JsonValidation>>() { btnLogin_validations };
            JsonResponse btnLogin_error = new JsonResponse();
            btnLogin_error.Params = new List<JsonResponseParam>();
            btnLogin_error.Params.Add(new JsonResponseParam() { Action = JsonAction.Message });
            btnLogin.OnErrorControlsAction = new List<JsonResponse>() { btnLogin_error };
			#endregion
		}
	}
}
