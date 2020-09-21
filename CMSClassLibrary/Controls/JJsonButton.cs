using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using JJson;

[assembly: TagPrefix("CMSClassLibrary.Controls", "JJson")]
namespace CMSClassLibrary.Controls
{
	[ToolboxData("<{0}:JJsonButton runat=server Event=click></{0}:JJsonButton>")]
	public class JJsonButton : Button
	{
		#region Properties
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

		[Bindable(true)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Localizable(true)]
		public List<JsonResponse> OnSuccessControlsAction
		{
			get
			{
				if (ViewState["OnSuccessControlsActions"] == null)
					return new List<JsonResponse>();
				return (List<JsonResponse>)ViewState["OnSuccessControlsActions"];
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
		public List<JsonResponse> OnErrorControlsAction
		{
			get
			{
				if (ViewState["OnErrorControlsActions"] == null)
					return new List<JsonResponse>();
				return (List<JsonResponse>)ViewState["OnErrorControlsActions"];
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
		public List<JsonRequest> Request
		{
			get
			{
				if (ViewState["Request"] == null)
					return new List<JsonRequest>();
				return (List<JsonRequest>)ViewState["Request"];
			}

			set
			{
				ViewState["Request"] = value;
			}
		}

		[Bindable(true)]
		[Category("Appearance")]
		[DefaultValue(null)]
		[Localizable(true)]
		public List<List<JsonValidation>> Validations
		{
			get
			{
				if (ViewState["Validations"] == null)
					return new List<List<JsonValidation>>();
				return (List<List<JsonValidation>>)ViewState["Validations"];
			}

			set
			{
				ViewState["Validations"] = value;
			}
		}
		#endregion

		#region Events

		//public static implicit operator List<JsonRequest>(JsonRequest req)
		//{
		//	return new List<JsonRequest>() { req };
		//}
		//public static implicit operator List<JsonResponse>(JsonResponse res)
		//{
		//	return new List<JsonResponse>() { res };
		//}
		//public static implicit operator List<List<JsonValidation>>(List<JsonValidation> validation)
		//{
		//	return new List<List<JsonValidation>>() { validation };
		//}


		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			Methods.RegisterJsonScript(Request, OnSuccessControlsAction, OnErrorControlsAction, Validations, this.Page, this.ClientID, Event.ToString());
		}
		public override void RenderControl(HtmlTextWriter writer)
		{
			//this.Attributes.CssStyle.Add("margin-top", "10px");
			this.Attributes.CssStyle.Add("margin-bottom", "10px");
			base.RenderControl(writer);
		}
		#endregion
	}
}
