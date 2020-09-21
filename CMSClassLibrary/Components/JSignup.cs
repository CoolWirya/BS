using ClassLibrary;
using Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using CMSClassLibrary.Controls;
using CMSClassLibrary.BaseControls;
using JJson;



namespace CMSClassLibrary.Components
{
	public class JSignup : JBaseCompositeControl
	{
		JJsonTextBox txtFirstName, txtLastName, txtFatherName,txtDesc, txtpersonelCode,
			txtShsh, txtNCode;
		JEnabled Gender;
		CheckBox LegalConfirm;
		Controls.JPersianDatePicker Birthday;
		JStateCity BirthdayPlace;
		Controls.JJsonButton btnSubmit;
		JBaseLabel fName;
		JBaseLabel lName;
		JBaseLabel fatherName;
		JBaseLabel desc;
		JBaseLabel personelCode;
		JBaseLabel shsh;
		JBaseLabel ncode;
		JBaseLabel sader;
		JBaseLabel birthday;
		JBaseLabel birthdayPlace;
		JBaseLabel gender;
		JBaseLabel legalConfirm;
		JStateCity Sader;

		// Home Info
		JJsonTextBox txtHomeAddress, txtPostalCode, txtTel, txtFax, txtMobile, txtEmail;
		JStateCity City;
		JBaseLabel homeAddress, postalCode, tel, fax, mobile, email, city;

		//Work Info

		JJsonTextBox txtWorkAddress, txtWorkPostalCode, txtWorkTel, txtWorkFax;
		JStateCity WorkCity;
		JBaseLabel workAddress, workPostalCode, workTel, workFax, workCity;

        HiddenField EventParam, EventId;



		public JSignup()
		{
			JPerson p = new JPerson();
            EventParam = new HiddenField();
            EventId = new HiddenField();
			txtFirstName = new JJsonTextBox();
            txtFirstName.ID = "txtFirstname";
			txtLastName = new JJsonTextBox();
			txtFatherName = new JJsonTextBox();
			txtHomeAddress = new JJsonTextBox();
            txtHomeAddress.Width = 300;
			txtWorkAddress = new JJsonTextBox();
            txtWorkAddress.Width = 300;
			txtDesc = new JJsonTextBox();
            txtDesc.Width = 154;
			txtpersonelCode = new JJsonTextBox();
			txtShsh = new JJsonTextBox();
			txtNCode = new JJsonTextBox();
			Gender = new JEnabled();
			Gender.Style = JGenderStyle.Horizontal;
            Gender.TrueString = "female";
            Gender.FalseString = "male";
            Gender.TrueText = "زن";
            Gender.FalseText = "مرد";
            Birthday = new CMSClassLibrary.Controls.JPersianDatePicker();
			LegalConfirm = new CheckBox();
            btnSubmit = new CMSClassLibrary.Controls.JJsonButton();
			txtDesc.TextMode = TextBoxMode.MultiLine;
			txtPostalCode = new JJsonTextBox();
			txtTel = new JJsonTextBox();
			txtFax = new JJsonTextBox();
			txtMobile = new JJsonTextBox();
			txtEmail = new JJsonTextBox();
            txtEmail.Width = 300;
			txtWorkPostalCode = new JJsonTextBox();
			txtWorkTel = new JJsonTextBox();
			txtWorkFax = new JJsonTextBox();
			BirthdayPlace = new JStateCity();
			BirthdayPlace.Mode=JState.Both;
			City = new JStateCity();
			City.Mode = JState.Both;
			WorkCity = new JStateCity();
			WorkCity.Mode = JState.Both;
			Sader = new JStateCity();
			Sader.Mode = JState.Both;


			fName = new JBaseLabel();
			lName = new JBaseLabel();
			fatherName = new JBaseLabel();
			homeAddress = new JBaseLabel();
			workAddress = new JBaseLabel();
			desc = new JBaseLabel();
			personelCode = new JBaseLabel();
			shsh = new JBaseLabel();
			ncode = new JBaseLabel();
			sader = new JBaseLabel();
			birthday = new JBaseLabel();
			gender = new JBaseLabel();
			legalConfirm = new JBaseLabel();
			birthdayPlace = new JBaseLabel();
			city=new JBaseLabel();
			email=new JBaseLabel();
			mobile=new JBaseLabel();
			fax=new JBaseLabel();
			tel=new JBaseLabel();
			postalCode=new JBaseLabel();
			workCity=new JBaseLabel();
			 workFax=new JBaseLabel();
			workTel=new JBaseLabel();
			workPostalCode=new JBaseLabel();
			
			
			 

			fName.Text = "FirstName";
			lName.Text = "LastName";
			fatherName.Text = "FatherName";
			homeAddress.Text = "HomeAddress";
			workAddress.Text = "WorkAddress";
			desc.Text = "Description";
			personelCode.Text = "PersonelCode";
			shsh.Text = "ShSh";
			ncode.Text = "NCode";
			birthday.Text = "BirthdayDate";
			gender.Text = "Gender";
			legalConfirm.Text = "LegalConfirm";
			sader.Text = "ShShPlace";
			btnSubmit.Text = "Submit";
            btnSubmit.ID = "signup_submit";
			birthdayPlace.Text = "BirthdayPlace";
			city.Text = "State-City";
			email.Text = "Email";
			mobile.Text = "Mobile";
			fax.Text = "Fax";
			tel.Text = "Telephone";
			postalCode.Text = "PostalCode";
			workCity.Text = "Work State-City";
			workFax.Text = "Work Fax";
			workTel.Text = "Work Telephone";
			workPostalCode.Text = "Work PostalCode";


			

		}

        protected override void CreateChildControls()
        {
            this.Event = JsonCompositeEvent.OnRegister;
            Controls.Add(fName);
            Controls.Add(txtFirstName);
            Controls.Add(Methods.Space);
            Controls.Add(birthday);
            Controls.Add(Birthday);
            Controls.Add(Methods.NewLine);
            Controls.Add(lName);
            Controls.Add(txtLastName);
            Controls.Add(Methods.Space);
            Controls.Add(gender);
            Controls.Add(Gender);
            Controls.Add(Methods.NewLine);
            Controls.Add(fatherName);
            Controls.Add(txtFatherName);
            Controls.Add(Methods.Space);
            Controls.Add(birthdayPlace);
            Controls.Add(BirthdayPlace);
            Controls.Add(Methods.NewLine);
            Controls.Add(shsh);
            Controls.Add(txtShsh);
            Controls.Add(Methods.Space);
            Controls.Add(sader);
            Controls.Add(Sader);
            Controls.Add(Methods.NewLine);
            Controls.Add(ncode);
            Controls.Add(txtNCode);
            Controls.Add(Methods.Space);
            Controls.Add(personelCode);
            Controls.Add(txtpersonelCode);
            Controls.Add(Methods.NewLine);
            Controls.Add(desc);
            Controls.Add(txtDesc);
            Controls.Add(Methods.NewLine);
            Controls.Add(legalConfirm);
            Controls.Add(LegalConfirm);
            Controls.Add(Methods.NewLine);


            //Home
            Controls.Add(new Literal() { ID = "ROW1", Text = "Home Address<hr/>" });
            Controls.Add(Methods.NewLine);
            Controls.Add(city);
            Controls.Add(City);
            Controls.Add(Methods.NewLine);
            Controls.Add(homeAddress);
            Controls.Add(txtHomeAddress);
            Controls.Add(Methods.NewLine);
            Controls.Add(tel);
            Controls.Add(txtTel);
            Controls.Add(Methods.Space);
            Controls.Add(mobile);
            Controls.Add(txtMobile);
            Controls.Add(Methods.NewLine);
            Controls.Add(postalCode);
            Controls.Add(txtPostalCode);
            Controls.Add(Methods.Space);
            Controls.Add(fax);
            Controls.Add(txtFax);
            Controls.Add(Methods.NewLine);
            Controls.Add(email);
            Controls.Add(txtEmail);
            Controls.Add(Methods.NewLine);


            //Work
            Controls.Add(new Literal() { ID = "ROW", Text = "Work Address<hr/>" });
            Controls.Add(workAddress);
            Controls.Add(txtWorkAddress);
            Controls.Add(Methods.NewLine);
            Controls.Add(workTel);
            Controls.Add(txtWorkTel);
            Controls.Add(Methods.Space);
            Controls.Add(workCity);
            Controls.Add(WorkCity);
            Controls.Add(Methods.NewLine);
            Controls.Add(workPostalCode);
            Controls.Add(txtWorkPostalCode);
            Controls.Add(Methods.Space);
            Controls.Add(workFax);
            Controls.Add(txtWorkFax);
            Controls.Add(Methods.NewLine);

            Controls.Add(btnSubmit);
            Controls.Add(EventParam);
            Controls.Add(EventId);
        }

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
		}

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            base.Render(writer);
            string script = "$(document).ready(function(){$(document).on(\"OnLogin\",function (event){$(\"#" + EventParam.ClientID + "\").val(event.name);"+
                "$(\"#" + this.ClientID + "\").trigger(\"SetValue\");});});";
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(),"script2",script,true);
            Methods.RegisterJsonScript(Request,OnSuccessControlsAction,OnErrorControlsAction,Validations,this.Page,this.ClientID,this.Event.ToString(),true);
        }

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);


			#region btnSubmit_Settings
            JsonResponse btnSubmit_res = new JsonResponse();
            btnSubmit_res.Type = JsonResponseType.Item;
            btnSubmit_res.Params = new List<JsonResponseParam>();
            btnSubmit_res.Params.Add(new JsonResponseParam() { Action = JsonAction.Message });
			btnSubmit.OnSuccessControlsAction = new List<JsonResponse>() { btnSubmit_res };
            JsonRequest btnSubmit_req = new JsonRequest();
			btnSubmit_req.URL = "JJsonService/JJsonService.asmx/Run";
			btnSubmit_req.data = "JJsonAdditionalLibrary.JsonComponents.JLoginManager->Signup";
            btnSubmit_req.Type = JsonRequestType.Classes;
            btnSubmit_req.Params = new List<JsonRequestParam>();
            btnSubmit_req.Params.Add(new JsonRequestParam() { Name = "FirstName", Type = JsonAction.Value, ControlID = txtFirstName.ClientID });
            btnSubmit_req.Params.Add(new JsonRequestParam() { Name = "LastName", Type = JsonAction.Value, ControlID = txtLastName.ClientID });
            btnSubmit_req.Params.Add(new JsonRequestParam() { Name = "Gender", Type = JsonAction.Gender, ControlID = Gender.ClientID });
            btnSubmit_req.Params.Add(new JsonRequestParam() { Name = "FatherName", Type = JsonAction.Value, ControlID = txtFatherName.ClientID });
            btnSubmit_req.Params.Add(new JsonRequestParam() { Name = "BirthdayPlace", Type = JsonAction.StateCity, ControlID = BirthdayPlace.ClientID });
            btnSubmit_req.Params.Add(new JsonRequestParam() { Name = "Shsh", Type = JsonAction.Value, ControlID = txtShsh.ClientID });
            btnSubmit_req.Params.Add(new JsonRequestParam() { Name = "Sader", Type = JsonAction.StateCity, ControlID = Sader.ClientID });
            btnSubmit_req.Params.Add(new JsonRequestParam() { Name = "NCode", Type = JsonAction.Value, ControlID = txtNCode.ClientID });
            btnSubmit_req.Params.Add(new JsonRequestParam() { Name = "PersonelCode", Type = JsonAction.Value, ControlID = txtpersonelCode.ClientID });
            btnSubmit_req.Params.Add(new JsonRequestParam() { Name = "Birthday", Type = JsonAction.GregorianDate, ControlID = Birthday.ClientID });
            btnSubmit_req.Params.Add(new JsonRequestParam() { Name = "LegalConfirm", Type = JsonAction.Value, ControlID = LegalConfirm.ClientID });
            btnSubmit_req.Params.Add(new JsonRequestParam() { Name = "HomeAddress", Type = JsonAction.Value, ControlID = txtHomeAddress.ClientID });
            btnSubmit_req.Params.Add(new JsonRequestParam() { Name = "WorkAddress", Type = JsonAction.Value, ControlID = txtWorkAddress.ClientID });
            btnSubmit_req.Params.Add(new JsonRequestParam() { Name = "HomePostalCode", Type = JsonAction.Value, ControlID = txtPostalCode.ClientID });
            btnSubmit_req.Params.Add(new JsonRequestParam() { Name = "Tel", Type = JsonAction.Value, ControlID = txtTel.ClientID });
            btnSubmit_req.Params.Add(new JsonRequestParam() { Name = "Fax", Type = JsonAction.Value, ControlID = txtFax.ClientID });
            btnSubmit_req.Params.Add(new JsonRequestParam() { Name = "Mobile", Type = JsonAction.Value, ControlID = txtMobile.ClientID });
            btnSubmit_req.Params.Add(new JsonRequestParam() { Name = "Email", Type = JsonAction.Value, ControlID = txtEmail.ClientID });
            btnSubmit_req.Params.Add(new JsonRequestParam() { Name = "City", Type = JsonAction.StateCity, ControlID = City.ClientID });
            btnSubmit_req.Params.Add(new JsonRequestParam() { Name = "WorkPostalCode", Type = JsonAction.Value, ControlID = txtWorkPostalCode.ClientID });
            btnSubmit_req.Params.Add(new JsonRequestParam() { Name = "WorkTel", Type = JsonAction.Value, ControlID = txtWorkTel.ClientID });
            btnSubmit_req.Params.Add(new JsonRequestParam() { Name = "WorkFax", Type = JsonAction.Value, ControlID = txtWorkFax.ClientID });
            btnSubmit_req.Params.Add(new JsonRequestParam() { Name = "WorkCity", Type = JsonAction.StateCity, ControlID = WorkCity.ClientID });

			btnSubmit.Request = new List<JsonRequest>() { btnSubmit_req };
            List<JsonValidation> btnSubmit_validations = new List<JsonValidation>();
            btnSubmit_validations.Add(new JsonValidation() { ControlID = txtFirstName.ClientID, ValueType = JsonAction.Value, Message = "وارد کردن نام الزامی است", RegexType = JsonRegexType.Alphanumeric });
            btnSubmit_validations.Add(new JsonValidation() { ControlID = txtLastName.ClientID, ValueType = JsonAction.Value, Message = "وارد کردن نام خانوادگی الزامی است", RegexType = JsonRegexType.Alphanumeric });
            btnSubmit_validations.Add(new JsonValidation() { ControlID = txtShsh.ClientID, ValueType = JsonAction.Value, Message = "وارد کردن شماره شناسنامه الزامی است", RegexType = JsonRegexType.Alphanumeric });
            btnSubmit_validations.Add(new JsonValidation() { ControlID = txtNCode.ClientID, ValueType = JsonAction.Value, Message = "وارد کردن کد ملی الزامی است", RegexType = JsonRegexType.Alphanumeric });
            btnSubmit_validations.Add(new JsonValidation() { ControlID = txtpersonelCode.ClientID, ValueType = JsonAction.Value, Message = "وارد کردن کد پرسنلی الزامی است", RegexType = JsonRegexType.Alphanumeric });
			btnSubmit.Validations = new List<List<JsonValidation>>() { btnSubmit_validations };
            JsonResponse btnSubmit_error = new JsonResponse();
            btnSubmit_error.Params = new List<JsonResponseParam>();
            btnSubmit_error.Params.Add(new JsonResponseParam() { Action = JsonAction.Message });
			btnSubmit.OnErrorControlsAction = new List<JsonResponse>() { btnSubmit_error };
			#endregion

            
            #region Gender_Settings
            //JsonResponse Gender_res = new JsonResponse();
            //Gender_res.Type = JsonResponseType.Item;
            //Gender_res.Params = new List<JsonResponseParam>();
            //Gender_res.Params.Add(new JsonResponseParam() { ControlToSet = txtFirstName.ClientID, Action = JsonAction.Value, ReturnField = "Return_Field_Name_On_Response" });
            //Gender.OnSuccessControlsAction =new List<JsonResponse>(){ Gender_res};
            //JsonRequest Gender_req = new JsonRequest();
            //Gender_req.URL = "JJsonService/JJsonService.asmx/Run";
            //Gender_req.data = "JJsonAdditionalLibrary.JsonComponents.JLoginManager->test";
            //Gender_req.Type = JsonRequestType.Classes;
            //Gender_req.Params = new List<JsonRequestParam>();
            //Gender_req.Params.Add(new JsonRequestParam() { Name = "gTest", Type = JsonAction.Gender, ControlID = Gender.ClientID });
            //Gender.Request =new List<JsonRequest>(){ Gender_req};
            //List<JsonValidation> Gender_validations = new List<JsonValidation>();
            ////Value_validations.Add(new JJson.JsonValidation() { ControlID = Control.ClientID, ValueType = JJson.JsonAction.Value, Message = "Validation message", RegexType = JJson.JsonRegexType.Alphanumeric });
            //Gender.Validations = new List<List<JsonValidation>>() { Gender_validations };
            //JsonResponse Gender_error = new JsonResponse();
            //Gender_error.Params = new List<JsonResponseParam>();
            //Gender_error.Params.Add(new JsonResponseParam() { Action = JsonAction.Message });
            //Gender.OnErrorControlsAction = new List<JsonResponse>() { Gender_error };
            #endregion


            
            #region Birthday_Settings
            //JsonResponse Birthday_res = new JsonResponse();
            //Birthday_res.Type = JsonResponseType.Item;
            //Birthday_res.Params = new List<JsonResponseParam>();
            //Birthday_res.Params.Add(new JsonResponseParam() { ControlToSet = txtLastName.ClientID, Action = JsonAction.Value, ReturnField = "Return_Field_Name_On_Response" });
            //Birthday.OnSuccessControlsAction = new List<JsonResponse>() { Birthday_res };
            //JsonRequest Birthday_req = new JsonRequest();
            //Birthday_req.URL = "JJsonService/JJsonService.asmx/Run";
            //Birthday_req.data = "JJsonAdditionalLibrary.JsonComponents.JLoginManager->getDate";
            //Birthday_req.Type = JsonRequestType.Classes;
            //Birthday_req.Params = new List<JsonRequestParam>();
            //Birthday_req.Params.Add(new JsonRequestParam() { Name = "datePicker", Type = JsonAction.JalaliDate, ControlID = Birthday.ClientID });
            //Birthday.Request = new List<JsonRequest>() { Birthday_req };
            //JsonResponse Birthday_error = new JsonResponse();
            //Birthday_error.Params = new List<JsonResponseParam>();
            //Birthday_error.Params.Add(new JsonResponseParam() { Action = JsonAction.Message });
            //Birthday.OnErrorControlsAction = new List<JsonResponse>() { Birthday_error };
            #endregion

            
            #region BirthdayPlace_Settings
            JsonResponse BirthdayPlace_res = new JsonResponse();
            BirthdayPlace_res.Type = JsonResponseType.Item;
            BirthdayPlace_res.Params = new List<JsonResponseParam>();
            BirthdayPlace_res.Params.Add(new JsonResponseParam() { ControlToSet = txtFatherName.ClientID, Action = JsonAction.Value, ReturnField = "Return_Field_Name_On_Response" });
            BirthdayPlace.OnSuccessControlsAction =new List<JsonResponse>(){ BirthdayPlace_res};
            JsonRequest BirthdayPlace_req = new JsonRequest();
            BirthdayPlace_req.URL = "JJsonService/JJsonService.asmx/Run";
            BirthdayPlace_req.data = "JJsonAdditionalLibrary.JsonComponents.JLoginManager->getCity";
            BirthdayPlace_req.Type = JsonRequestType.Classes;
            BirthdayPlace_req.Params = new List<JsonRequestParam>();
            BirthdayPlace_req.Params.Add(new JsonRequestParam() { Name = "selectedCity", Type = JsonAction.Value, ControlID = BirthdayPlace.ClientID + "_city" });
            BirthdayPlace.Request =new List<JsonRequest>(){ BirthdayPlace_req};
            JsonResponse BirthdayPlace_error = new JsonResponse();
            BirthdayPlace_error.Params = new List<JsonResponseParam>();
            BirthdayPlace_error.Params.Add(new JsonResponseParam() { Action = JsonAction.Message });
            BirthdayPlace.OnErrorControlsAction =new List<JsonResponse>(){ BirthdayPlace_error};
            #endregion


            #region test_Settings
            JJson.JsonResponse test_res = new JJson.JsonResponse();
            test_res.Type = JJson.JsonResponseType.Item;
            test_res.Params = new List<JJson.JsonResponseParam>();
            test_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = txtFirstName.ClientID, Action = JJson.JsonAction.Value, ReturnField = "Return_Field_Name_On_Response" });
            List<JsonResponse> success = new List<JsonResponse>() { test_res};
            JJson.JsonRequest test_req = new JJson.JsonRequest();
            test_req.URL = "JJsonService/JJsonService.asmx/Run";
            test_req.data = "JJsonAdditionalLibrary.JsonComponents.JLoginManager->getCity";
            test_req.Type = JJson.JsonRequestType.Classes;
            test_req.Params = new List<JJson.JsonRequestParam>();
            test_req.Params.Add(new JJson.JsonRequestParam() { Name = "selectedCity", Type = JJson.JsonAction.Value, ControlID = EventParam.ClientID });
            List<JsonRequest> request = new List<JsonRequest>() { test_req};
            List<JsonValidation> validations = new List<JsonValidation>();
            List<List<JsonValidation>> allvalidations = new List<List<JsonValidation>>() { validations};
            JJson.JsonResponse test_error = new JJson.JsonResponse();
            test_error.Params = new List<JJson.JsonResponseParam>();
            test_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
            List<JsonResponse> error = new List<JsonResponse>() { test_error};
            Methods.RegisterJsonScript(request, success, error, allvalidations, this.Page, this.ClientID, "SetValue", true);
            #endregion
			

		}
	}
}
