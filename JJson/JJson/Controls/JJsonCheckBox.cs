using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

[assembly: TagPrefix("JJson.Controls", "JJson")]
namespace JJson.Controls
{
	[ToolboxData("<{0}:JJsonCheckBox runat=server Event=change></{0}:JJsonCheckBox>")]
	public class JJsonCheckBox : CheckBox
	{
		#region Properties
		[Bindable(true)]
		[Category("Appearance")]
		[DefaultValue(JsonEvent.change)]
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
		public JsonResponse OnSuccessControlsAction
		{
			get
			{
				if (ViewState["OnSuccessControlsActions"] == null)
					return new JsonResponse();
				return (JsonResponse)ViewState["OnSuccessControlsActions"];
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
		public JsonResponse OnErrorControlsAction
		{
			get
			{
				if (ViewState["OnErrorControlsActions"] == null)
					return new JsonResponse();
				return (JsonResponse)ViewState["OnErrorControlsActions"];
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
		public JsonRequest Request
		{
			get
			{
				if (ViewState["Request"] == null)
					return new JsonRequest();
				return (JsonRequest)ViewState["Request"];
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
			//Methods.RegisterJsonScript(Request, OnSuccessControlsAction, OnErrorControlsAction, this.Page, this.ClientID, Event);
		}
		#endregion
	}
}
