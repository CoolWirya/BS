using JJson.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;

namespace JJson.BaseControls
{
	public class JBaseCompositeControl : CompositeControl
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
		[DefaultValue(JsonCompositeEvent.OnChange)]
		[Localizable(true)]
		public JsonCompositeEvent Event
		{
			get
			{
				if (ViewState["Event"] == null)
					return JsonCompositeEvent.OnChange;
				return (JsonCompositeEvent)ViewState["Event"];
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

		protected JJsonHiddenField Value;
		protected override void CreateChildControls()
		{
			base.CreateChildControls();
			Value = new JJsonHiddenField();
			Value.ID = this.ClientID + "_value";
			Value.ClientIDMode = ClientIDMode.Static;
			Value.Event = JsonEvent.textchange;
			Controls.Add(Value);
		}

		protected override void RecreateChildControls()
		{
			base.RecreateChildControls();
			EnsureChildControls();
		}
	}
}
