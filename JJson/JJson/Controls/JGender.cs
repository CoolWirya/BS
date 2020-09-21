using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.ComponentModel;
using JJson.BaseControls;

namespace JJson.Controls
{
    public class JGender : JBaseCompositeControl
	{
		public JGenderStyle Style { get; set; }
       

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
        //[DefaultValue(JsonEvent.blur)]
		[Localizable(true)]
        public JsonEvent Event
        {
            get
            {
                if (ViewState["Event"] == null)
                    return JsonEvent.blur;
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
	
		public bool SelectedValue
		{
			get
			{
				Value.Value = Male.Checked == true ? "false" : "true";
				return Boolean.Parse(Value.Value);
			}
			set
			{
				Value.Value = value.ToString();
				if (value == true)
					Female.Checked = true;
				else
					Male.Checked = true;
			}
		}

		RadioButton Male, Female;

		public JGender()
		{

		}
		protected override void CreateChildControls()
		{
            base.CreateChildControls();

			Male = new RadioButton();
			Male.ID =  "male";
			Male.Text = "Male";
			Male.GroupName = this.ClientID + "_gender";
			Female = new RadioButton();
			Female.ID =  "female";
			Female.Text = "Female";
			Female.GroupName = this.ClientID + "_gender";
			Controls.Add(Male);
			if (Style == JGenderStyle.Vertical)
			{
				Controls.Add(Methods.NewLine);
				Female.Attributes.CssStyle.Add("margin-right", "150px");
			}
			Controls.Add(Female);
			//System.Web.UI.HtmlControls.HtmlButton btn = new System.Web.UI.HtmlControls.HtmlButton();
			//btn.Attributes.Add("onclick", "$(\"#"+this.ClientID+"_value\").val('true');$(\"#"+this.ClientID+"_value\").trigger(\"input\");return false;");
			//Controls.Add(btn);
		}

		

		protected override void OnPreRender(EventArgs e)
		{
            base.OnPreRender(e);
            Methods.RegisterJsonScript(Request,OnSuccessControlsAction,OnErrorControlsAction,Validations,this.Page,this.ClientID,this.Event.ToString(),true);
			Methods.RegisterGenderScript(this.Page, this.ClientID, "");
			#region Value_Settings
			JJson.JsonResponse Value_res = new JJson.JsonResponse();
			Value_res.Type = JJson.JsonResponseType.Item;
			Value_res.Params = new List<JJson.JsonResponseParam>();
			//Value_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = Control_To_Set.ClientID, Action = JJson.JsonAction.DataBind, Name = "", Value = "" });
			Value_res.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Condition, ReturnField = "return field", Condition = new List<JJson.JsonConditionParam>() { new JJson.JsonConditionParam() { Condition = "=='false'", Action = JJson.JsonAction.ConditionalValue, Message = this.ClientID + "_male|prop(\"checked\",true)" }, new JJson.JsonConditionParam() { Condition = "=='true'", Action = JJson.JsonAction.ConditionalValue, Message = this.ClientID + "_female|prop(\"checked\",true)" } } });
			Value.OnSuccessControlsAction = new List<JsonResponse>() { Value_res };
			JJson.JsonRequest Value_req = new JJson.JsonRequest();
			Value_req.URL = "WebControllers/JJsonServices/JJsonService.asmx/Run";
			Value_req.Type = JJson.JsonRequestType.Classes;
			Value_req.data = "JJson.Controls.GenderManager->GetGenderState";
			Value_req.Params = new List<JJson.JsonRequestParam>();
			Value_req.Params.Add(new JJson.JsonRequestParam() { Name = "Value", Type = JJson.JsonAction.Value, ControlID = this.ClientID + "_value" });
			Value.Request = new List<JsonRequest>() { Value_req };
			List<JJson.JsonValidation> Value_validations = new List<JJson.JsonValidation>();
			//Value_validations.Add(new JJson.JsonValidation() { ControlID = Control.ClientID, ValueType = JJson.JsonAction.Value, Message = "Validation message", RegexType = JJson.JsonRegexType.Alphanumeric });
			Value.Validations = new List<List<JsonValidation>>() { Value_validations };
			JJson.JsonResponse Value_error = new JJson.JsonResponse();
			Value_error.Params = new List<JJson.JsonResponseParam>();
			Value_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
			Value.OnErrorControlsAction = new List<JsonResponse>() { Value_error };
            #endregion


		}

	}

	public class GenderManager
	{
		public string Value { get; set; }
		public string GetGenderState()
		{
			return Value;
		}
	}
}
