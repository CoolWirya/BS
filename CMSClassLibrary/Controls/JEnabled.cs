using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.ComponentModel;
using CMSClassLibrary.BaseControls;
using JJson;

namespace CMSClassLibrary.Controls
{
    public class JEnabled : JBaseCompositeControl
	{
		public JGenderStyle Style { get; set; }

        public string TrueString { get; set; }
        public string FalseString { get; set; }
        public string TrueText { get; set; }
        public string FalseText { get; set; }

      
	
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

		public JEnabled()
		{
            Male = new RadioButton();
            Female = new RadioButton();

		}
		protected override void CreateChildControls()
		{
            base.CreateChildControls();

			Male.ID =  FalseString;
			Male.Text = FalseText;
			Male.GroupName = this.ClientID + "_group";
			Female.ID =  TrueString;
			Female.Text = TrueText;
			Female.GroupName = this.ClientID + "_group";
			Controls.Add(Male);
			if (Style == JGenderStyle.Vertical)
			{
				Controls.Add(Methods.NewLine);
				Female.Attributes.CssStyle.Add("margin-right", "150px");
			}
			Controls.Add(Female);
            //System.Web.UI.HtmlControls.HtmlButton btn = new System.Web.UI.HtmlControls.HtmlButton();
            //btn.Attributes.Add("onclick", "$(\"#" + this.ClientID + "_value\").val('true');$(\"#" + this.ClientID + "_value\").trigger(\"input\");return false;");
            //Controls.Add(btn);
		}

		

		protected override void OnPreRender(EventArgs e)
		{
            base.OnPreRender(e);
            Methods.RegisterJsonScript(Request,OnSuccessControlsAction,OnErrorControlsAction,Validations,this.Page,this.ClientID,this.Event.ToString(),true);
			Methods.RegisterEnabledScript(this.Page, this.ClientID, this.TrueString,this.FalseString);

			#region Value_Settings
            JsonResponse Value_res = new JsonResponse();
            Value_res.Type = JsonResponseType.Item;
            Value_res.Params = new List<JsonResponseParam>();
            //Value_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = Control_To_Set.ClientID, Action = JJson.JsonAction.DataBind, Name = "", Value = "" });
            Value_res.Params.Add(new JsonResponseParam() { Action = JsonAction.Condition, ReturnField = "return field", Condition = new List<JsonConditionParam>() { new JsonConditionParam() { Condition = "=='false'", Action = JsonAction.ConditionalValue, Message = this.ClientID + "_" + FalseString + "|prop(\"checked\",true)" }, new JsonConditionParam() { Condition = "=='true'", Action = JsonAction.ConditionalValue, Message = this.ClientID + "_" + TrueString + "|prop(\"checked\",true)" } } });
            Value.OnSuccessControlsAction = new List<JsonResponse>() { Value_res };
            JsonRequest Value_req = new JsonRequest();
            Value_req.URL = "WebControllers/JJsonServices/JJsonService.asmx/Run";
            Value_req.Type = JsonRequestType.Classes;
            Value_req.data = "JJson.Controls.GenderManager->GetGenderState";
            Value_req.Params = new List<JsonRequestParam>();
            Value_req.Params.Add(new JsonRequestParam() { Name = "Value", Type = JsonAction.Value, ControlID = this.ClientID + "_value" });
            Value.Request = new List<JsonRequest>() { Value_req };
            List<JsonValidation> Value_validations = new List<JsonValidation>();
            //Value_validations.Add(new JJson.JsonValidation() { ControlID = Control.ClientID, ValueType = JJson.JsonAction.Value, Message = "Validation message", RegexType = JJson.JsonRegexType.Alphanumeric });
            Value.Validations = new List<List<JsonValidation>>() { Value_validations };
            JsonResponse Value_error = new JsonResponse();
            Value_error.Params = new List<JsonResponseParam>();
            Value_error.Params.Add(new JsonResponseParam() { Action = JsonAction.Message });
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
