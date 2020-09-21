using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RealEstate;

namespace WebRealEstate.Building.Joint
{
	public partial class JointFormControl : System.Web.UI.UserControl
	{
		private JJoint _JJoint;
		private int code;
		public int Code
		{
			get
			{
				if (ViewState["Code"] != null)
					return (int)ViewState["Code"];
				return 0;
			}
			set
			{
				ViewState["Code"] = value;
			}
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack)
				return;
			if (int.TryParse(Request["Code"], out code))
				Code = code;
			_JJoint = new JJoint();
			_JJoint.GetData(Code);
			txtCode.Text = _JJoint.Code.ToString();
			txtType.Text = _JJoint.Type;
			FillCombobox();
			cmbComplex.SelectedValue = _JJoint.MarketCode.ToString();
		}
		//protected override void OnPreRender(EventArgs e)
		//{
		//	base.OnPreRender(e);
		//	#region btnOK_Settings
		//	JJson.JsonResponse btnOK_res = new JJson.JsonResponse();
		//	btnOK_res.Type = JJson.JsonResponseType.RefreshGridAndClose;
		//	btnOK_res.Params = new List<JJson.JsonResponseParam>();
		//	btnOK_res.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Condition, ReturnField = "return field", Condition = new List<JJson.JsonConditionParam>() { new JJson.JsonConditionParam() { Condition = "=='true'", Action = JJson.JsonAction.CloseWindowAndRefreshGrid, Message = "" }, new JJson.JsonConditionParam() { Condition = "=='false'", Action = JJson.JsonAction.ConditionalMessage, Message = "عملیات با خطا مواجه شده است. لطفاً مجددا سعی نمایید" } } });
		//	btnOK.OnSuccessControlsAction = new List<JJson.JsonResponse>() { btnOK_res };
		//	JJson.JsonRequest btnOK_req = new JJson.JsonRequest();
		//	btnOK_req.URL = "JJsonService/JJsonService.asmx/Run";
		//	btnOK_req.Type = JJson.JsonRequestType.Classes;
		//	btnOK_req.data = "JJsonAdditionalLibrary.WebRealEstate.Building.Joint.JalJoint->AddJoint";
		//	btnOK_req.Params = new List<JJson.JsonRequestParam>();
		//	btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Code", Type = JJson.JsonAction.Value, ControlID = txtCode.ClientID });
		//	btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Type", Type = JJson.JsonAction.Value, ControlID = txtType.ClientID });
		//	btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "MarketCode", Type = JJson.JsonAction.Value, ControlID = cmbComplex.ClientID });
		//	btnOK.Request = new List<JJson.JsonRequest>() { btnOK_req };
		//	List<JJson.JsonValidation> validations = new List<JJson.JsonValidation>();
		//	validations.Add(new JJson.JsonValidation() { ControlID = txtType.ClientID, ValueType = JJson.JsonAction.Value, Message = "نوع وارد نشده است", RegexType = JJson.JsonRegexType.Alphanumeric });
		//	btnOK.Validations = new List<List<JJson.JsonValidation>>() { validations };
		//	JJson.JsonResponse btnOK_error = new JJson.JsonResponse();
		//	btnOK_error.Params = new List<JJson.JsonResponseParam>();
		//	btnOK_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
		//	btnOK.OnErrorControlsAction = new List<JJson.JsonResponse>() { btnOK_error };
		//	#endregion
		//}

		private void FillCombobox()
		{
			cmbComplex.DataTextField = estMarket.Title.ToString();
			cmbComplex.DataValueField = estMarket.Code.ToString();
			cmbComplex.DataSource = jMarkets.GetDataTable(0);
			cmbComplex.DataBind();
		}
	}
}