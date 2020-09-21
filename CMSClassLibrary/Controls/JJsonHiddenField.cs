using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JJson;

[assembly: TagPrefix("CMSClassLibrary.Controls", "JJson")]
namespace CMSClassLibrary.Controls
{
	[ToolboxData("<{0}:JJsonHiddenField runat=server Event=textchange></{0}:JJsonHiddenField>")]
	public class JJsonHiddenField : HiddenField
	{
		#region Properties
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

		[Bindable(true)]
		[Category("Appearance")]
		[DefaultValue(JsonEvent.textchange)]
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
		#endregion

		#region Events
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			Methods.RegisterJsonScript(Request, OnSuccessControlsAction, OnErrorControlsAction, Validations, this.Page, this.ClientID, Event.ToString());
		}

		#endregion
	}
}
