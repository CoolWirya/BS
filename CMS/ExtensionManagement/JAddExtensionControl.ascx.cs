using JJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.ExtensionManagement
{
    public partial class JAddExtensionControl : System.Web.UI.UserControl
    {
        public int Code = 0;
        HiddenField SiteId;
        CMSClassLibrary.Extension.JExtension extension;
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteId = new HiddenField();
            int PCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;
            if (WebClassLibrary.SessionManager.Current.Session["SiteCode"] != null)
                SiteId.Value = WebClassLibrary.SessionManager.Current.Session["SiteCode"].ToString();
            txtType.Items.Add("Module");
            txtType.Items.Add("Template");
            txtType.Items.Add("Component");
            txtType.Items.Add("Plugin");
            txtState.TrueText = ClassLibrary.JLanguages._Text("Enabled");
            txtState.FalseText = ClassLibrary.JLanguages._Text("Disabled");
            Titlelbl.Text = ClassLibrary.JLanguages._Text("Title");
            Statelbl.Text = ClassLibrary.JLanguages._Text("State");
            Typelbl.Text = ClassLibrary.JLanguages._Text("Type");
            Paramlbl.Text = ClassLibrary.JLanguages._Text("Parameters");
            Classlbl.Text = ClassLibrary.JLanguages._Text("ClassName");
            btnOK.Text = ClassLibrary.JLanguages._Text("Save");
            btnCancel.Text = ClassLibrary.JLanguages._Text("Cancel");
            Codelbl.Text = ClassLibrary.JLanguages._Text("ExtensionCode");

            if (!int.TryParse(Request["Code"], out Code))
                return;
            FillForm();
           
        }

        public void FillForm()
        {
            extension = new CMSClassLibrary.Extension.JExtension(Code);
            lblCode.Text = Code.ToString();
            if(extension != null)
            {
                txtName.Text = extension.Name;
                txtParam.Text = extension.Params;
                txtState.SelectedValue = bool.Parse(extension.State.ToString());
                txtType.Items.FindByValue(extension.Type.ToString()).Selected = true;
                txtClass.Text = extension.ClassName;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            WebClassLibrary.JWebManager.CloseWindow();
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            this.Controls.Add(SiteId);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            #region btnOK_Settings
            JJson.JsonResponse btnOK_res = new JJson.JsonResponse();
            btnOK_res.Type = JJson.JsonResponseType.RefreshGridAndClose;
            btnOK_res.Params = new List<JJson.JsonResponseParam>();
            btnOK_res.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Condition, ReturnField = "Return_Field_Name_On_Response", Condition = new List<JJson.JsonConditionParam>() { new JJson.JsonConditionParam() { Condition = "=='true'", Action = JJson.JsonAction.CloseWindowAndRefreshGrid, Message = "" }, new JJson.JsonConditionParam() { Condition = "=='false'", Action = JJson.JsonAction.ConditionalMessage, Message = "عملیات با خطا مواجه شده است. لطفاً مجددا سعی نمایید" } } });
            btnOK.OnSuccessControlsAction = new List<JJson.JsonResponse>() { btnOK_res };
            JJson.JsonRequest btnOK_req = new JJson.JsonRequest();
            btnOK_req.URL = "JJsonService/JJsonService.asmx/Run";
            btnOK_req.Type = JJson.JsonRequestType.Classes;
            if (Code > 0)
                btnOK_req.data = "CMSClassLibrary.Extension.JExtension->Update";
            else
                btnOK_req.data = "CMSClassLibrary.Extension.JExtension->Insert";
            btnOK_req.Params = new List<JJson.JsonRequestParam>();
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Code", Type = JJson.JsonAction.Html, ControlID = lblCode.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "State", Type = JJson.JsonAction.Gender, ControlID = txtState.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Name", Type = JJson.JsonAction.Value, ControlID = txtName.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Params", Type = JJson.JsonAction.Value, ControlID = txtParam.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "ClassName", Type = JJson.JsonAction.Value, ControlID = txtClass.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Type", Type = JJson.JsonAction.Value, ControlID = txtType.ClientID });
            btnOK.Request = new List<JJson.JsonRequest>() { btnOK_req };
            JJson.JsonResponse btnOK_error = new JJson.JsonResponse();
            btnOK_error.Params = new List<JJson.JsonResponseParam>();
            btnOK_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
            btnOK.OnErrorControlsAction = new List<JJson.JsonResponse>() { btnOK_error };
            #endregion

        }
    }
}