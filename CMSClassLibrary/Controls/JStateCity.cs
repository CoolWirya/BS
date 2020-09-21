using ClassLibrary;
using CMSClassLibrary.BaseControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using JJson;

namespace CMSClassLibrary.Controls
{
    public class JStateCity : JBaseCompositeControl
	{
		public JState Mode { get; set; }

		DropDownList State;
		HtmlSelect City;
		HiddenField Value;
  

        
		public JStateCity()
		{
			State = new DropDownList();
			City = new HtmlSelect();
			Value = new HiddenField();
			//State.Event = JsonEvent.change;
			//City.Event = JsonEvent.change;
		}
		
		protected override void CreateChildControls()
		{
			Controls.Clear();
            base.CreateChildControls();
			State.ID = this.ClientID + "_state";
			State.ClientIDMode = System.Web.UI.ClientIDMode.Static;
			City.ID = this.ClientID + "_city";
			City.ClientIDMode = System.Web.UI.ClientIDMode.Static;
			if (Mode == JState.City || Mode == JState.Both)
				Controls.Add(City);
			if (Mode == JState.State || Mode == JState.Both)
				Controls.Add(State);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			JCities cities = new JCities();
			if (Mode == JState.State || Mode == JState.Both)
			{
				State.DataSource = cities.GetStates();
				State.DataTextField = "state";
				State.DataValueField = "code";
				State.DataBind();
			}
			//if (Mode == JState.City)
			//{
			//	City.DataSource = cities.GetNewCity(0);
			//	City.DataTextField = "city";
			//	City.DataValueField = "code";
			//	City.DataBind();
			//}
		}
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			//switch (Mode)
			//{
			//	case JState.State:
			//		break;
			//	case JState.City:
			//		break;
			//	case JState.Both:
			//		//JCities tmpCity = new JCities();
			//		//State.DataSource = tmpCity.GetStates();
			//		//State.DataTextField = "state";
			//		//State.DataValueField = "code";
			//		//State.DataBind();
			//		#region State_Settings
			//		JJson.JsonResponse State_res = new JJson.JsonResponse();
			//		State_res.Type = JJson.JsonResponseType.Table;
			//		State_res.Params = new List<JJson.JsonResponseParam>();
			//		State_res.Params.Add(new JJson.JsonResponseParam() { BindControlType = JsonBindableType.DropDownList, ControlToSet = this.ClientID + "_city", Action = JJson.JsonAction.DataBind, Name = "city", Value = "code" });
			//		State.OnSuccessControlsAction = new List<JsonResponse>() { State_res };
			//		JJson.JsonRequest State_req = new JJson.JsonRequest();
			//		State_req.URL = "JJsonService/JJsonService.asmx/Run";
			//		State_req.Type = JJson.JsonRequestType.Classes;
			//		State_req.data = "JJsonAdditionalLibrary.JsonComponents.JLoginManager->FillCity";
			//		State_req.Params = new List<JJson.JsonRequestParam>();
			//		State_req.Params.Add(new JJson.JsonRequestParam() { Name = "StateCode", Type = JJson.JsonAction.Value, ControlID = this.ClientID + "_state" });
			//		State.Request = new List<JsonRequest>() { State_req };
			//		List<JJson.JsonValidation> State_validations = new List<JJson.JsonValidation>();
			//		//State_validations.Add(new JJson.JsonValidation() { ControlID = Control.ClientID, ValueType = JJson.JsonAction.Value, Message = "Validation message", RegexType = JJson.JsonRegexType.Alphanumeric });
			//		State.Validations = new List<List<JsonValidation>>() { State_validations };
			//		JJson.JsonResponse State_error = new JJson.JsonResponse();
			//		State_error.Params = new List<JJson.JsonResponseParam>();
			//		State_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
			//		State.OnErrorControlsAction = new List<JsonResponse>() { State_error };
			//		#endregion
			//		break;
			//}
			JCities city = new JCities();
			DataTable states = city.GetStates();
			//string statesStr = "";
			//if (states != null)
			//	for (int i = 0; i < states.Rows.Count; i++)
			//	{
			//		statesStr += "<option id=\"" + states.Rows[i][0] + "\">" + states.Rows[i][1] + "</option>";
			//	}
			string success = "var res = eval('(' + msg.d + ')');"+
				//" var $" + this.ClientID + "_city_var = $(\"#" + this.ClientID + "_city\");" +
				//"$(\"#" + this.ClientID + "_city\").find('option').remove().end();" +
				//"alert($(\"select[id='" + this.ClientID + "_city'] option\"));" +
				//"$(\"select[id='" + this.ClientID + "_city'] option\").remove();" +
				//"$(\"#" + this.ClientID + "_city\").empty();" +
				"for (var i = 0; i < res.length; i++) {" +
					"$(\"#" + this.ClientID + "_city\").append($('<option></option>').val(res[i][\"code\"]).html(res[i][\"city\"]));" +
					//"$(\"#" + this.ClientID + "_city\").append('<option value=\"'+res[i][\"code+'\"]+'\">'+res[i][\"city\"]+'</option>');" +
					//"$('<option></option>').val(res[i][\"code\"]).html(res[i][\"city\"]).appendTo($" + this.ClientID + "_city_var);" +
					//"$('<option>'+res[i][\"city\"]+'</option>').appendTo($" + this.ClientID + "_city_var);" +
				"}alert('binded'); \r\n ";
			string json = "		$.ajax({" +
					"type: 'POST'," +
					"async: 'false'," +
					"url: 'JJsonService/JJsonService.asmx/Run'," +
					"data: '{'" +
					"		+ '\"data\":\"JJsonAdditionalLibrary.JsonComponents.JLoginManager->FillCity->StateCode:'+$(\"#" + this.ClientID + "_state\").val()+'\", '+ '\"requestType\":\"Classes\", '+ '\"responseType\":\"Table\"'" +
					"		+ '}'," +
					"contentType: \"application/json; charset=utf-8\"," +
					"dataType: \"json\"," +
					"success: function (msg) {" +
					success +
					"}," +
					"error: function (msg) {" +
					"	alert(msg.responseText);" +
					"}" +
				"});";
			string jquery = "$(document).ready(function () {"+
				//" var stateStr=eval('('+ '" + Methods.GetJson(states) + "' +')');" +
				//"$(\"#" + this.ClientID + "_state\").empty();" +
				//"for (var i = 0; i < stateStr.length; i++) {" +
				//"$(\"#" + this.ClientID + "_state\").append($('<option></option>').val(stateStr[i][\"code\"]).html(stateStr[i][\"state\"]));" +
				//"} \r\n " +
				"$(\"#" + this.ClientID + "_state\").change(function () {" +
				//"$(\"[id='Skinned" + this.ClientID + "_city']\").remove();" +
				"$(\"#" + this.ClientID + "_city\").empty();" +
					json +
				"});" +
                "$(\"#" + this.ClientID + "_city\").change(function() {$(\"#" + this.ClientID + "\").trigger('OnChange');});" +
			"});";
			this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), this.ClientID + "_change_JsonScript", jquery, true);
		}

		public override void RenderControl(System.Web.UI.HtmlTextWriter writer)
		{

			base.RenderControl(writer);
		}

		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			base.Render(writer);
            Methods.RegisterJsonScript(Request, OnSuccessControlsAction, OnErrorControlsAction, Validations, this.Page, this.ClientID, this.Event.ToString(),true);
			//writer.Write("<select id=\"" + this.ClientID + "_state\" runat=\"server\"></select>");
			//writer.Write("<select id=\"" + this.ClientID + "_city\" runat=\"server\"></select>");
		}

	}
}
