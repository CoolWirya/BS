using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
	public partial class WebForm1 : System.Web.UI.Page
	{
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			//JJson.JsonResponse jres = new JJson.JsonResponse();
			//jres.Params = new List<JJson.JsonResponseParam>();
			//jres.Params.Add(new JJson.JsonResponseParam() { ControlToSet = test.ClientID, Action = JJson.JsonAction.Value, ReturnField = "name" });
			//jjtb.OnSuccessControlsAction = jres;
			//JJson.JsonRequest jreq = new JJson.JsonRequest();
			//jreq.URL = "test.asmx/test1";
			//jreq.Type = JJson.JsonRequestType.Other;
			//jreq.data = "select * from person where id = @id";
			//jreq.Params = new List<JJson.JsonRequestParam>();
			//jreq.Params.Add(new JJson.JsonRequestParam() { Name = "id", Type = JJson.JsonAction.Value, Value = "10", ControlID = jjtb.ClientID });
			//jjtb.Request = jreq;
			//JJson.JsonResponse jerr = new JJson.JsonResponse();
			//jerr.Params = new List<JJson.JsonResponseParam>();
			//jerr.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
			//jjtb.OnErrorControlsAction = jerr;


			//#region jjtb_Settings
			//JJson.JsonResponse jjtb_res = new JJson.JsonResponse();
			//jjtb_res.Type = JJson.JsonResponseType.Table;
			//jjtb_res.Params = new List<JJson.JsonResponseParam>();
			////jjtb_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = test.ClientID, Action = JJson.JsonAction.Value, ReturnField = "Return_Field_Name_On_Response" });
			//jjtb_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = ddl2.ClientID, Action = JJson.JsonAction.DataBind, Name = "col3", Value = "col1" });
			//jjtb.OnSuccessControlsAction = jjtb_res;
			//JJson.JsonRequest jjtb_req = new JJson.JsonRequest();
			//jjtb_req.URL = "test.asmx/test1";
			//jjtb_req.Type = JJson.JsonRequestType.Other;
			//jjtb_req.data = "Constant_Data_Or_Sql_Query_[with_Parameter_like_@ID]";
			//jjtb_req.Params = new List<JJson.JsonRequestParam>();
			//jjtb_req.Params.Add(new JJson.JsonRequestParam() { Name = "Return_Field_Name_On_Response", Type = JJson.JsonAction.Value, Value = "Value_for_send_request_on_constant_action", ControlID = jjtb.ClientID });
			//jjtb.Request = jjtb_req;
			//JJson.JsonResponse jjtb_error = new JJson.JsonResponse();
			//jjtb_error.Params = new List<JJson.JsonResponseParam>();
			//jjtb_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
			//jjtb.OnErrorControlsAction = jjtb_error;
			//#endregion

			//#region ddl2_Settings
			//JJson.JsonResponse ddl2_res = new JJson.JsonResponse();
			//ddl2_res.Type = JJson.JsonResponseType.Item;
			//ddl2_res.Params = new List<JJson.JsonResponseParam>();
			//ddl2_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = test.ClientID, Action = JJson.JsonAction.Value, ReturnField = "" });
			//ddl2_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = test.ClientID, Action = JJson.JsonAction.Css, Name = "color", ReturnField = "" });
			//ddl2.OnSuccessControlsAction = ddl2_res;
			//JJson.JsonRequest ddl2_req = new JJson.JsonRequest();
			//ddl2_req.URL = "test.asmx/test1";
			//ddl2_req.Type = JJson.JsonRequestType.Direct;
			//ddl2_req.data = "";
			//ddl2_req.Params = new List<JJson.JsonRequestParam>();
			//ddl2_req.Params.Add(new JJson.JsonRequestParam() { Name = "field1", Type = JJson.JsonAction.DropDownText, Value = "", ControlID = ddl2.ClientID });
			//ddl2.Request = ddl2_req;
			//JJson.JsonResponse ddl2_error = new JJson.JsonResponse();
			//ddl2_error.Params = new List<JJson.JsonResponseParam>();
			//ddl2_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
			//ddl2.OnErrorControlsAction = ddl2_error;
			//#endregion


			//#region jjb_Settings
			//JJson.JsonResponse jjb_res = new JJson.JsonResponse();
			//jjb_res.Type = JJson.JsonResponseType.Table;
			//jjb_res.Params = new List<JJson.JsonResponseParam>();
			//jjb_res.Params.Add(new JJson.JsonResponseParam() { BindControlType = JJson.JsonBindableType.DropDownList, ControlToSet = ddl.ClientID, Action = JJson.JsonAction.DataBind, ReturnField = "Return_Field_Name_On_Response", Name = "col3", Value = "col1" });
			//jjb.OnSuccessControlsAction = jjb_res;
			//JJson.JsonRequest jjb_req = new JJson.JsonRequest();
			//jjb_req.URL = "test.asmx/test1";
			//jjb_req.Type = JJson.JsonRequestType.Other;
			//jjb_req.data = "";
			//jjb_req.Params = new List<JJson.JsonRequestParam>();
			//jjb_req.Params.Add(new JJson.JsonRequestParam() { Name = "field1", Type = JJson.JsonAction.Value, Value = "Value_for_send_request_on_constant_action", ControlID = jjb.ClientID });
			//jjb.Request = jjb_req;
			//JJson.JsonResponse jjb_error = new JJson.JsonResponse();
			//jjb_error.Params = new List<JJson.JsonResponseParam>();
			//jjb_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
			//jjb.OnErrorControlsAction = jjb_error;
			//#endregion

			#region jjtb_Settings
			JJson.JsonResponse jjtb_res = new JJson.JsonResponse();
			jjtb_res.Type = JJson.JsonResponseType.Table;
			jjtb_res.Params = new List<JJson.JsonResponseParam>();
			jjtb_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = ddl2.ClientID, Action = JJson.JsonAction.DataBind, Name = "col3", Value = "col1" });
			jjtb.OnSuccessControlsAction = jjtb_res;
			JJson.JsonRequest jjtb_req = new JJson.JsonRequest();
			jjtb_req.URL = "test.asmx/test1";
			jjtb_req.Type = JJson.JsonRequestType.Other;
			jjtb_req.data = "SELECT col3,col1 FROM TableName WHERE CODE = @CODE";
			jjtb_req.Params = new List<JJson.JsonRequestParam>();
			jjtb_req.Params.Add(new JJson.JsonRequestParam() { Name = "@CODE", Type = JJson.JsonAction.Value, ControlID = jjtb.ClientID });
			jjtb.Request = jjtb_req;
			JJson.JsonResponse jjtb_error = new JJson.JsonResponse();
			jjtb_error.Params = new List<JJson.JsonResponseParam>();
			jjtb_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
			jjtb.OnErrorControlsAction = jjtb_error;
			#endregion
			
			#region ddl2_Settings
			JJson.JsonResponse ddl2_res = new JJson.JsonResponse();
			ddl2_res.Type = JJson.JsonResponseType.Item;
			ddl2_res.Params = new List<JJson.JsonResponseParam>();
			ddl2_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = test.ClientID, Action = JJson.JsonAction.Value, ReturnField = "Return_Field_Name_On_Response" });
			ddl2.OnSuccessControlsAction = ddl2_res;
			JJson.JsonRequest ddl2_req = new JJson.JsonRequest();
			ddl2_req.URL = "test.asmx/test1";
			ddl2_req.Type = JJson.JsonRequestType.Other;
			ddl2_req.Params = new List<JJson.JsonRequestParam>();
			ddl2_req.Params.Add(new JJson.JsonRequestParam() { Name = "field1", Type = JJson.JsonAction.DropDownText, ControlID = ddl2.ClientID });
			ddl2.Request = ddl2_req;
			JJson.JsonResponse ddl2_error = new JJson.JsonResponse();
			ddl2_error.Params = new List<JJson.JsonResponseParam>();
			ddl2_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
			ddl2.OnErrorControlsAction = ddl2_error;
			#endregion
			

		}
		protected void Page_Load(object sender, EventArgs e)
		{

		}
	}
}