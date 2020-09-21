using ClassLibrary;
using Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using JJson.Controls;
using JJson.BaseControls;



namespace JJson.Components
{
	public class JSignup : JBaseCompositeControl
	{
		TextBox txtFirstName, txtLastName, txtFatherName,txtDesc, txtpersonelCode,
			txtShsh, txtNCode;
		JGender Gender;
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
		TextBox txtHomeAddress, txtPostalCode, txtTel, txtFax, txtMobile, txtEmail;
		JStateCity City;
		JBaseLabel homeAddress, postalCode, tel, fax, mobile, email, city;

		//Work Info

		TextBox txtWorkAddress, txtWorkPostalCode, txtWorkTel, txtWorkFax;
		JStateCity WorkCity;
		JBaseLabel workAddress, workPostalCode, workTel, workFax, workCity;

		



		public JSignup()
		{
			JPerson p = new JPerson();

			txtFirstName = new TextBox();
			txtLastName = new TextBox();
			txtFatherName = new TextBox();
			txtHomeAddress = new TextBox();
            txtHomeAddress.Width = 300;
			txtWorkAddress = new TextBox();
            txtWorkAddress.Width = 300;
			txtDesc = new TextBox();
            txtDesc.Width = 154;
			txtpersonelCode = new TextBox();
			txtShsh = new TextBox();
			txtNCode = new TextBox();
			Gender = new JGender();
			Gender.Style = JGenderStyle.Horizontal;
			Birthday = new JJson.Controls.JPersianDatePicker();
			LegalConfirm = new CheckBox();
			btnSubmit = new JJson.Controls.JJsonButton();
			txtDesc.TextMode = TextBoxMode.MultiLine;
			txtPostalCode = new TextBox();
			txtTel = new TextBox();
			txtFax = new TextBox();
			txtMobile = new TextBox();
			txtEmail = new TextBox();
            txtEmail.Width = 300;
			txtWorkPostalCode = new TextBox();
			txtWorkTel = new TextBox();
			txtWorkFax = new TextBox();
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
        }

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
		}

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            base.Render(writer);
            Methods.RegisterJsonScript(Request,OnSuccessControlsAction,OnErrorControlsAction,Validations,this.Page,this.ClientID,this.Event.ToString(),true);
        }

		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);


			#region btnSubmit_Settings
			JJson.JsonResponse btnSubmit_res = new JJson.JsonResponse();
			btnSubmit_res.Type = JJson.JsonResponseType.Item;
			btnSubmit_res.Params = new List<JJson.JsonResponseParam>();
			btnSubmit_res.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
			btnSubmit.OnSuccessControlsAction = new List<JsonResponse>() { btnSubmit_res };
			JJson.JsonRequest btnSubmit_req = new JJson.JsonRequest();
			btnSubmit_req.URL = "JJsonService/JJsonService.asmx/Run";
			btnSubmit_req.data = "JJsonAdditionalLibrary.JsonComponents.JLoginManager->Signup";
			btnSubmit_req.Type = JJson.JsonRequestType.Classes;
			btnSubmit_req.Params = new List<JJson.JsonRequestParam>();
			btnSubmit_req.Params.Add(new JJson.JsonRequestParam() { Name = "FirstName", Type = JJson.JsonAction.Value, ControlID = txtFirstName.ClientID });
			btnSubmit_req.Params.Add(new JJson.JsonRequestParam() { Name = "LastName", Type = JJson.JsonAction.Value, ControlID = txtLastName.ClientID });
			btnSubmit_req.Params.Add(new JJson.JsonRequestParam() { Name = "Gender", Type = JJson.JsonAction.Gender, ControlID = Gender.ClientID });
			btnSubmit_req.Params.Add(new JJson.JsonRequestParam() { Name = "FatherName", Type = JJson.JsonAction.Value, ControlID = txtFatherName.ClientID });
			btnSubmit_req.Params.Add(new JJson.JsonRequestParam() { Name = "BirthdayPlace", Type = JJson.JsonAction.StateCity, ControlID = BirthdayPlace.ClientID });
			btnSubmit_req.Params.Add(new JJson.JsonRequestParam() { Name = "Shsh", Type = JJson.JsonAction.Value, ControlID = txtShsh.ClientID });
			btnSubmit_req.Params.Add(new JJson.JsonRequestParam() { Name = "Sader", Type = JJson.JsonAction.StateCity, ControlID = Sader.ClientID });
			btnSubmit_req.Params.Add(new JJson.JsonRequestParam() { Name = "NCode", Type = JJson.JsonAction.Value, ControlID = txtNCode.ClientID });
			btnSubmit_req.Params.Add(new JJson.JsonRequestParam() { Name = "PersonelCode", Type = JJson.JsonAction.Value, ControlID = txtpersonelCode.ClientID });
			btnSubmit_req.Params.Add(new JJson.JsonRequestParam() { Name = "Birthday", Type = JJson.JsonAction.GregorianDate, ControlID=Birthday.ClientID });
			btnSubmit_req.Params.Add(new JJson.JsonRequestParam() { Name = "LegalConfirm", Type = JJson.JsonAction.Value, ControlID = LegalConfirm.ClientID });
			btnSubmit_req.Params.Add(new JJson.JsonRequestParam() { Name = "HomeAddress", Type = JJson.JsonAction.Value, ControlID = txtHomeAddress.ClientID });
			btnSubmit_req.Params.Add(new JJson.JsonRequestParam() { Name = "WorkAddress", Type = JJson.JsonAction.Value, ControlID = txtWorkAddress.ClientID });
			btnSubmit_req.Params.Add(new JJson.JsonRequestParam() { Name = "HomePostalCode", Type = JJson.JsonAction.Value, ControlID = txtPostalCode.ClientID });
            btnSubmit_req.Params.Add(new JJson.JsonRequestParam() { Name = "Tel", Type = JJson.JsonAction.Value, ControlID = txtTel.ClientID });
            btnSubmit_req.Params.Add(new JJson.JsonRequestParam() { Name = "Fax", Type = JJson.JsonAction.Value, ControlID = txtFax.ClientID });
            btnSubmit_req.Params.Add(new JJson.JsonRequestParam() { Name = "Mobile", Type = JJson.JsonAction.Value, ControlID = txtMobile.ClientID });
            btnSubmit_req.Params.Add(new JJson.JsonRequestParam() { Name = "Email", Type = JJson.JsonAction.Value, ControlID = txtEmail.ClientID });
            btnSubmit_req.Params.Add(new JJson.JsonRequestParam() { Name = "City", Type = JJson.JsonAction.StateCity, ControlID = City.ClientID });
            btnSubmit_req.Params.Add(new JJson.JsonRequestParam() { Name = "WorkPostalCode", Type = JJson.JsonAction.Value, ControlID = txtWorkPostalCode.ClientID });
            btnSubmit_req.Params.Add(new JJson.JsonRequestParam() { Name = "WorkTel", Type = JJson.JsonAction.Value, ControlID = txtWorkTel.ClientID });
            btnSubmit_req.Params.Add(new JJson.JsonRequestParam() { Name = "WorkFax", Type = JJson.JsonAction.Value, ControlID = txtWorkFax.ClientID });
            btnSubmit_req.Params.Add(new JJson.JsonRequestParam() { Name = "WorkCity", Type = JJson.JsonAction.StateCity, ControlID = WorkCity.ClientID });

			btnSubmit.Request = new List<JsonRequest>() { btnSubmit_req };
			List<JJson.JsonValidation> btnSubmit_validations = new List<JJson.JsonValidation>();
			btnSubmit_validations.Add(new JJson.JsonValidation() { ControlID = txtFirstName.ClientID, ValueType = JJson.JsonAction.Value, Message = "وارد کردن نام الزامی است", RegexType = JJson.JsonRegexType.Alphanumeric });
			btnSubmit_validations.Add(new JJson.JsonValidation() { ControlID = txtLastName.ClientID, ValueType = JJson.JsonAction.Value, Message = "وارد کردن نام خانوادگی الزامی است", RegexType = JJson.JsonRegexType.Alphanumeric });
			btnSubmit_validations.Add(new JJson.JsonValidation() { ControlID = txtShsh.ClientID, ValueType = JJson.JsonAction.Value, Message = "وارد کردن شماره شناسنامه الزامی است", RegexType = JJson.JsonRegexType.Alphanumeric });
			btnSubmit_validations.Add(new JJson.JsonValidation() { ControlID = txtNCode.ClientID, ValueType = JJson.JsonAction.Value, Message = "وارد کردن کد ملی الزامی است", RegexType = JJson.JsonRegexType.Alphanumeric });
			btnSubmit_validations.Add(new JJson.JsonValidation() { ControlID = txtpersonelCode.ClientID, ValueType = JJson.JsonAction.Value, Message = "وارد کردن کد پرسنلی الزامی است", RegexType = JJson.JsonRegexType.Alphanumeric });
			btnSubmit.Validations = new List<List<JsonValidation>>() { btnSubmit_validations };
			JJson.JsonResponse btnSubmit_error = new JJson.JsonResponse();
			btnSubmit_error.Params = new List<JJson.JsonResponseParam>();
			btnSubmit_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
			btnSubmit.OnErrorControlsAction = new List<JsonResponse>() { btnSubmit_error };
			#endregion

            
            #region Gender_Settings
            JJson.JsonResponse Gender_res = new JJson.JsonResponse();
            Gender_res.Type = JJson.JsonResponseType.Item;
            Gender_res.Params = new List<JJson.JsonResponseParam>();
            Gender_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = txtFirstName.ClientID, Action = JJson.JsonAction.Value, ReturnField = "Return_Field_Name_On_Response" });
            Gender.OnSuccessControlsAction =new List<JsonResponse>(){ Gender_res};
            JJson.JsonRequest Gender_req = new JJson.JsonRequest();
            Gender_req.URL = "JJsonService/JJsonService.asmx/Run";
            Gender_req.data = "JJsonAdditionalLibrary.JsonComponents.JLoginManager->test";
            Gender_req.Type = JJson.JsonRequestType.Classes;
            Gender_req.Params = new List<JJson.JsonRequestParam>();
            Gender_req.Params.Add(new JJson.JsonRequestParam() { Name = "gTest", Type = JJson.JsonAction.Gender, ControlID = Gender.ClientID });
            Gender.Request =new List<JsonRequest>(){ Gender_req};
            List<JJson.JsonValidation> Gender_validations = new List<JJson.JsonValidation>();
            //Value_validations.Add(new JJson.JsonValidation() { ControlID = Control.ClientID, ValueType = JJson.JsonAction.Value, Message = "Validation message", RegexType = JJson.JsonRegexType.Alphanumeric });
            Gender.Validations = new List<List<JsonValidation>>() { Gender_validations };
            JJson.JsonResponse Gender_error = new JJson.JsonResponse();
            Gender_error.Params = new List<JJson.JsonResponseParam>();
            Gender_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
            Gender.OnErrorControlsAction = new List<JsonResponse>() { Gender_error };
            #endregion


            
            #region Birthday_Settings
            JJson.JsonResponse Birthday_res = new JJson.JsonResponse();
            Birthday_res.Type = JJson.JsonResponseType.Item;
            Birthday_res.Params = new List<JJson.JsonResponseParam>();
            Birthday_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = txtLastName.ClientID, Action = JJson.JsonAction.Value, ReturnField = "Return_Field_Name_On_Response" });
            Birthday.OnSuccessControlsAction =new List<JsonResponse>(){ Birthday_res};
            JJson.JsonRequest Birthday_req = new JJson.JsonRequest();
            Birthday_req.URL = "JJsonService/JJsonService.asmx/Run";
            Birthday_req.data = "JJsonAdditionalLibrary.JsonComponents.JLoginManager->getDate";
            Birthday_req.Type = JJson.JsonRequestType.Classes;
            Birthday_req.Params = new List<JJson.JsonRequestParam>();
            Birthday_req.Params.Add(new JJson.JsonRequestParam() { Name = "datePicker", Type = JJson.JsonAction.JalaliDate, ControlID = Birthday.ClientID });
            Birthday.Request =new List<JsonRequest>(){ Birthday_req};
            JJson.JsonResponse Birthday_error = new JJson.JsonResponse();
            Birthday_error.Params = new List<JJson.JsonResponseParam>();
            Birthday_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
            Birthday.OnErrorControlsAction =new List<JsonResponse>(){ Birthday_error};
            #endregion

            
            #region BirthdayPlace_Settings
            JJson.JsonResponse BirthdayPlace_res = new JJson.JsonResponse();
            BirthdayPlace_res.Type = JJson.JsonResponseType.Item;
            BirthdayPlace_res.Params = new List<JJson.JsonResponseParam>();
            BirthdayPlace_res.Params.Add(new JJson.JsonResponseParam() { ControlToSet = txtFatherName.ClientID, Action = JJson.JsonAction.Value, ReturnField = "Return_Field_Name_On_Response" });
            BirthdayPlace.OnSuccessControlsAction =new List<JsonResponse>(){ BirthdayPlace_res};
            JJson.JsonRequest BirthdayPlace_req = new JJson.JsonRequest();
            BirthdayPlace_req.URL = "JJsonService/JJsonService.asmx/Run";
            BirthdayPlace_req.data = "JJsonAdditionalLibrary.JsonComponents.JLoginManager->getCity";
            BirthdayPlace_req.Type = JJson.JsonRequestType.Classes;
            BirthdayPlace_req.Params = new List<JJson.JsonRequestParam>();
            BirthdayPlace_req.Params.Add(new JJson.JsonRequestParam() { Name = "selectedCity", Type = JJson.JsonAction.Value, ControlID = BirthdayPlace.ClientID + "_city" });
            BirthdayPlace.Request =new List<JsonRequest>(){ BirthdayPlace_req};
            JJson.JsonResponse BirthdayPlace_error = new JJson.JsonResponse();
            BirthdayPlace_error.Params = new List<JJson.JsonResponseParam>();
            BirthdayPlace_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
            BirthdayPlace.OnErrorControlsAction =new List<JsonResponse>(){ BirthdayPlace_error};
            #endregion
			
			
		}
	}
}
