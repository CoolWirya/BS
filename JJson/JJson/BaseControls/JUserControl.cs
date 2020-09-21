using JJson.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JJson.BaseControls
{
	public class JUserControl : UserControl
	{
		JJsonHiddenField hdnBaseCode;
		public int BaseCode
		{
			get
			{
				return (int)ViewState["BaseCode"];
			}
			set
			{
				ViewState["BaseCode"] = value;
				if (hdnBaseCode == null)
					hdnBaseCode = new JJsonHiddenField() { Event = JsonEvent.textchange, ID = this.ClientID + "_BaseCode", ClientIDMode = System.Web.UI.ClientIDMode.Static };
				hdnBaseCode.Value = value.ToString();
			}
		}

		public override void RenderControl(HtmlTextWriter writer)
		{
			base.RenderControl(writer);
			hdnBaseCode = new JJsonHiddenField() { Event = JsonEvent.textchange, ID = this.ClientID + "_BaseCode", ClientIDMode = System.Web.UI.ClientIDMode.Static };
			this.Controls.Add(hdnBaseCode);
		}
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);

			#region hdnBaseCode_Settings
			JJson.JsonResponse hdnBaseCode_res = new JJson.JsonResponse();
			hdnBaseCode_res.Type = JJson.JsonResponseType.Item;
			hdnBaseCode_res.Params = new List<JJson.JsonResponseParam>();
			hdnBaseCode_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = Control_To_Set.ClientID, Action = JJson.JsonAction.Value, ReturnField = "Return_Field_Name_On_Response" });
			hdnBaseCode.OnSuccessControlsAction = new List<JsonResponse>() { hdnBaseCode_res };
			JJson.JsonRequest hdnBaseCode_req = new JJson.JsonRequest();
			hdnBaseCode_req.URL = "URL";
			hdnBaseCode_req.Type = JJson.JsonRequestType.Other;
			hdnBaseCode_req.Params = new List<JJson.JsonRequestParam>();
			hdnBaseCode_req.Params.Add(new JJson.JsonRequestParam() { Name = "field1", Type = JJson.JsonAction.Value, ControlID = Control_for_send_request_on_all_actions_except_Constant_type.ClientID });
			hdnBaseCode.Request = hdnBaseCode_req;
			JJson.JsonResponse hdnBaseCode_error = new JJson.JsonResponse();
			hdnBaseCode_error.Params = new List<JJson.JsonResponseParam>();
			hdnBaseCode_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
			hdnBaseCode.OnErrorControlsAction = hdnBaseCode_error;
			#endregion
			
		}
	}
}
