using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CMS.TemplateManagement
{
    public partial class JAddTemplateControl : System.Web.UI.UserControl
    {
        public int Code = 0;
        CMSClassLibrary.Template.JTemplate templateStyle;
        protected void Page_Load(object sender, EventArgs e)
        {
            int PCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;
            DataTable Templates = CMSClassLibrary.Extension.JExtensions.GetDataTable("Type='Template'");
            txtExtension.DataSource = Templates.DefaultView;
            txtExtension.DataTextField = "Name";
            txtExtension.DataValueField = "Code";
            txtExtension.DataBind();

            Pathlbl.Text = ClassLibrary.JLanguages._Text("Path");
            Defaultlbl.Text = ClassLibrary.JLanguages._Text("IsDefault");
            Extensionlbl.Text = ClassLibrary.JLanguages._Text("Template");
            btnOK.Text = ClassLibrary.JLanguages._Text("Save");
            btnCancel.Text = ClassLibrary.JLanguages._Text("Cancel");
            Codelbl.Text = ClassLibrary.JLanguages._Text("Template Style Code");
            if (!int.TryParse(Request["Code"], out Code))
                return;
            FillForm();
        }

        public void FillForm()
        {
            templateStyle = new CMSClassLibrary.Template.JTemplate(Code);
            lblCode.Text = Code.ToString();
            if (templateStyle != null)
            {
                txtPath.Text = templateStyle.Path;
                txtDefault.Checked = bool.Parse(templateStyle.IsDefault.ToString());
                txtExtension.Items.FindByValue(templateStyle.ExtensionCode.ToString()).Selected = true;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            WebClassLibrary.JWebManager.CloseWindow();
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
                btnOK_req.data = "CMSClassLibrary.Template.JTemplate->Update";
            else
                btnOK_req.data = "CMSClassLibrary.Template.JTemplate->Insert";
            btnOK_req.Params = new List<JJson.JsonRequestParam>();
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Code", Type = JJson.JsonAction.Html, ControlID = lblCode.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "IsDefault", Type = JJson.JsonAction.CheckState, ControlID = txtDefault.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Path", Type = JJson.JsonAction.Value, ControlID = txtPath.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "ExtensionCode", Type = JJson.JsonAction.Value, ControlID = txtExtension.ClientID });
            btnOK.Request = new List<JJson.JsonRequest>() { btnOK_req };
            JJson.JsonResponse btnOK_error = new JJson.JsonResponse();
            btnOK_error.Params = new List<JJson.JsonResponseParam>();
            btnOK_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
            btnOK.OnErrorControlsAction = new List<JJson.JsonResponse>() { btnOK_error };
            #endregion

        }

    }
}