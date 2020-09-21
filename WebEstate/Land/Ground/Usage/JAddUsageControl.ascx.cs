using Estates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebEstate.Land.Ground.Usage
{
    public partial class JAddUsageControl : System.Web.UI.UserControl
    {
        private JUsageGround _newUsage;
		int code = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
			if (!int.TryParse(Request["Code"], out code))
				return;
			FillForm();
        }

		void FillForm()
		{
			_newUsage = new JUsageGround(code);
			lblCode.Text = _newUsage.Code.ToString();
			txtTitle.Text = _newUsage.Name;
			numDensity.Text = _newUsage.Density;
			numPercent.Text = _newUsage.Persent.ToString();
			txtParking.Text = _newUsage.Parking;
			txtAccess.Text = _newUsage.Access;
			txtComment.Text = _newUsage.Comment;
		}

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
			#region btnOK_Settings
			JJson.JsonResponse btnOK_res = new JJson.JsonResponse();
            btnOK_res.Type = JJson.JsonResponseType.RefreshGridAndClose;
            btnOK_res.Params = new List<JJson.JsonResponseParam>();
            btnOK_res.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message, ReturnField = "Return_Field_Name_On_Response" });
            btnOK.OnSuccessControlsAction =new List<JJson.JsonResponse>(){ btnOK_res};
            JJson.JsonRequest btnOK_req = new JJson.JsonRequest();
			btnOK_req.URL = "JJsonService/JJsonService.asmx/Run";
            btnOK_req.Type = JJson.JsonRequestType.Classes;
			btnOK_req.data = "JJsonAdditionalLibrary.WebEstate.Land.Ground.Usage.JAddUsage->Insert";
            btnOK_req.Params = new List<JJson.JsonRequestParam>();
			btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Code", Type = JJson.JsonAction.Html, ControlID = lblCode.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Name", Type = JJson.JsonAction.Value, ControlID = txtTitle.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Density", Type = JJson.JsonAction.Value, ControlID = numDensity.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Persent", Type = JJson.JsonAction.Value, ControlID = numPercent.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Parking", Type = JJson.JsonAction.Value, ControlID = txtParking.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Access", Type = JJson.JsonAction.Value, ControlID = txtAccess.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Comment", Type = JJson.JsonAction.Value, ControlID = txtComment.ClientID });
            btnOK.Request =new List<JJson.JsonRequest>(){ btnOK_req};
            List<JJson.JsonValidation> validations = new List<JJson.JsonValidation>();
            validations.Add(new JJson.JsonValidation() { ControlID = txtTitle.ClientID, ValueType = JJson.JsonAction.Value, Message = "عنوان وارد نشده است", RegexType = JJson.JsonRegexType.Alphanumeric });
            btnOK.Validations =new List<List<JJson.JsonValidation>>(){ validations};
            JJson.JsonResponse btnOK_error = new JJson.JsonResponse();
            btnOK_error.Params = new List<JJson.JsonResponseParam>();
            btnOK_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
            btnOK.OnErrorControlsAction =new List<JJson.JsonResponse>(){ btnOK_error};
            #endregion
        }

		protected void btnExit_Click(object sender, EventArgs e)
		{
			WebClassLibrary.JWebManager.CloseWindow();
		}

		//protected void btnOK_Click(object sender, EventArgs e)
		//{
		//	_newUsage = new JUsageGround();
		//	_newUsage.Name = txtTitle.Text;
		//	_newUsage.Density = numDensity.Text;
		//	_newUsage.Persent = int.Parse(numPercent.Text);
		//	_newUsage.Parking = txtParking.Text;
		//	_newUsage.Access = txtAccess.Text;
		//	_newUsage.Comment = txtComment.Text;
		//	_newUsage.Insert();
		//}
    }
}