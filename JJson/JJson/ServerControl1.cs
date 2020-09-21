using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly: TagPrefix("JJson", "JJson")]
namespace JJson
{
	[Serializable]
	public struct JResponse
	{
		public string ControlToSet;
		public string ReturnField;
		public JAction Action;
		public string Name;
		public string Value;
		public string CssUnit;
	}
	[Serializable]
	public struct JRequest
	{
		public JsonRequestType Type;
		public string data;
		public List<JRequestParam> Params;
		public string URL;
	}
	[Serializable]
	public struct JRequestParam
	{
		public JAction Type;
		public string Value;
		public string Name;
		public string ControlID;
	}
	public enum JsonRequestType
	{
		SQL,
		Other
	}
	public enum JsonEvent
	{
		click,
		change,
		keyup,
		keydown,
		keypress,
		mouseover,
		mouseout
	}
	public enum JAction
	{
		Value,
		Text,
		Index,
		Attribute,
		Css,
		Property,
		Message,
		Redirect,
		Constant
	}
	//[DefaultProperty("Text")]
	[ToolboxData("<{0}:JJsonTextBox runat=server></{0}:JJsonTextBox>")]
	public class JJsonTextBox : TextBox
	{
		//[Bindable(true)]
		//[Category("Appearance")]
		//[DefaultValue("")]
		//[Localizable(true)]
		//public string Text
		//{
		//	get
		//	{
		//		String s = (String)ViewState["Text"];
		//		return ((s == null) ? "[" + this.ID + "]" : s);
		//	}

		//	set
		//	{
		//		ViewState["Text"] = value;
		//	}
		//}

		[Bindable(true)]
		[Category("Appearance")]
		[DefaultValue(JsonEvent.click)]
		[Localizable(true)]
		public JsonEvent Event
		{
			get
			{
				if (ViewState["Event"] == null)
					return JsonEvent.click;
				return (JsonEvent)ViewState["Event"];
			}

			set
			{
				ViewState["Event"] = value;
			}
		}

		//[Bindable(true)]
		//[Category("Appearance")]
		//[DefaultValue("")]
		//[Localizable(true)]
		//public string ServiceURL
		//{
		//	get
		//	{
		//		if (ViewState["ServiceURL"] == null)
		//			return "";
		//		return ViewState["ServiceURL"].ToString();
		//	}

		//	set
		//	{
		//		ViewState["ServiceURL"] = value;
		//	}
		//}

		[Bindable(true)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Localizable(true)]
		public List<JResponse> OnSuccessControlsActions
		{
			get
			{
				if (ViewState["OnSuccessControlsActions"] == null)
					return new List<JResponse>();
				return (List<JResponse>)ViewState["OnSuccessControlsActions"];
			}

			set
			{
				ViewState["OnSuccessControlsActions"] = value;
			}
		}

		[Bindable(true)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Localizable(true)]
		public List<JResponse> OnErrorControlsActions
		{
			get
			{
				if (ViewState["OnErrorControlsActions"] == null)
					return new List<JResponse>();
				return (List<JResponse>)ViewState["OnErrorControlsActions"];
			}

			set
			{
				ViewState["OnErrorControlsActions"] = value;
			}
		}

		[Bindable(true)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Localizable(true)]
		public JRequest Request
		{
			get
			{
				if (ViewState["Request"] == null)
					return new JRequest();
				return (JRequest)ViewState["Request"];
			}

			set
			{
				ViewState["Request"] = value;
			}
		}

		void process()
		{
			string success = "";
			string response = "";
			for (int i = 0; i < OnSuccessControlsActions.Count; i++)
			{
				string action = "";
				if (Request.Type == JsonRequestType.Other)
				{
					response += "var arr = msg.d.split(\"?!?\");var value;" +
					"for (var i = 0; i < arr.length; i++)" +
					"{" +
					"	var field = arr[i].split(\":\");" +
					"	if (field[0].toLowerCase() == \"" + OnSuccessControlsActions[i].ReturnField.ToLower() + "\"){" +
					"		value=field[1];break;}" +
					"}";
				}
				else
				{
				}
				switch (OnSuccessControlsActions[i].Action)
				{
					case JAction.Value:
						action = "val(value);";
						break;
					case JAction.Text:
						action = "text(value);";
						break;
					case JAction.Index:
						action = "prop(\"selectedIndex\",value);";
						break;
					case JAction.Attribute:
						action = "attr(\"" + OnSuccessControlsActions[i].Name + "\",value);";
						break;
					case JAction.Css:
						action = "css(\"" + OnSuccessControlsActions[i].Name + "\",\value;";
						break;
					case JAction.Property:
						action = "prop(\"" + OnSuccessControlsActions[i].Name + "\",value);";
						break;
					case JAction.Message:
						action = "alert(value);";
						break;
					case JAction.Redirect:
						break;
					default:
						break;
				}
				success += (action.ToLower().Contains("alert") ? "" : "$(\"#" + OnSuccessControlsActions[i].ControlToSet + "\").") + action + "\r\n";
			}
			string error = "alert(msg.responseText);";
			string data = "";
			if (Request.Type == JsonRequestType.SQL)
			{
				data += Request.data;
				for (int i = 0; i < Request.Params.Count; i++)
				{
					string action = "";
					switch (Request.Params[i].Type)
					{
						case JAction.Value:
							action = "val()";
							break;
						case JAction.Text:
							action = "text()";
							break;
						case JAction.Index:
							action = "prop(\"selectedIndex\")";
							break;
						case JAction.Attribute:
							action = "attr(\"" + Request.Params[i].Name + "\")";
							break;
						case JAction.Css:
							action = "css(\"" + Request.Params[i].Name + "\")";
							break;
						case JAction.Property:
							action = "prop(\"" + Request.Params[i].Name + "\")";
							break;
						//case JAction.Message:
						//	action = "alert(msg.d);";
						//	break;
						//case JAction.Redirect:
						//	break;
						default:
							break;
					}
					if (Request.Params[i].Type != JAction.Constant)
						data = data.Replace(Request.Params[i].Name, "'+$(\"#" + Request.Params[i].ControlID + "\")." + action + "+'");
					else
						data = data.Replace(Request.Params[i].Name, Request.Params[i].Value);
				}
			}
			else
			{
				for (int i = 0; i < Request.Params.Count; i++)
				{
					string action = "";
					switch (Request.Params[i].Type)
					{
						case JAction.Value:
							action = "val()";
							break;
						case JAction.Text:
							action = "text()";
							break;
						case JAction.Index:
							action = "prop(\"selectedIndex\")";
							break;
						case JAction.Attribute:
							action = "attr(\"" + Request.Params[i].Name + "\")";
							break;
						case JAction.Css:
							action = "css(\"" + Request.Params[i].Name + "\")";
							break;
						case JAction.Property:
							action = "prop(\"" + Request.Params[i].Name + "\")";
							break;
						//case JAction.Message:
						//	action = "alert(msg.d);";
						//	break;
						//case JAction.Redirect:
						//	break;
						default:
							break;
					}
					if (Request.Params[i].Type != JAction.Constant)
						data += Request.Params[i].Name + ":" + "'+$(\"#" + Request.Params[i].ControlID + "\")." + action + "+'|";
					else
						data += Request.Params[i].Name + ":" + Request.Params[i].Value + "|";
				}
				data = data.Substring(0, data.Length - 1);
			}
			string ajax = "$.ajax({" +
									"type: 'POST'," +
									"url: '" + Request.URL + "'," +
									"data: '{'" +
											"+ '\"data\":\"" + data + "\", '" +
											"+ '\"type\":\"" + Request.Type + "\" '" +
									"    + '}'," +
									"contentType: \"application/json; charset=utf-8\"," +
									"dataType: \"json\"," +
									"success: function (msg) {" +
									response + success +
									"		}," +
									"error: function (msg) {" +
									error +
									"		}" +
								"});";
			string text = "$(document).ready(function(){" +
								"$(\"#" + this.ClientID + "\")." + Event.ToString() + "(function(){" +
									ajax +
								"});" +
						   "});";
			this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), this.ClientID + "_" + Event.ToString() + "_Script", text, true);
		}
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			process();
		}
	}
}
