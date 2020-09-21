using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JJson;
using System.Data;

namespace CMS.ModuleManagement
{
    public partial class JAddModuleControl : System.Web.UI.UserControl
    {
        private CMSClassLibrary.Module.JModule newModule;
        int code = 0;
        HiddenField SiteId;
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteId = new HiddenField();
            if (WebClassLibrary.SessionManager.Current.Session["SiteCode"] != null)
                SiteId.Value = WebClassLibrary.SessionManager.Current.Session["SiteCode"].ToString();
            DataTable table = CMSClassLibrary.Extension.JExtensions.GetDataTable("1=1 and (Type='Module' or Type='Content')");
            txtType.DataSource = table.DefaultView;
            txtType.DataTextField = "Name";
            txtType.DataValueField = "Code";
            txtType.DataBind();
            DataTable sites = CMSClassLibrary.Site.JSites.GetDataTable("1=1");
            if (!int.TryParse(Request["Code"], out code))
                return;
            FillForm();

        }

        public void FillForm()
        {
            newModule = new CMSClassLibrary.Module.JModule(code);
            lblCode.Text = newModule.Code.ToString();
            txtName.Text = newModule.Name;
            txtOrder.Text = newModule.PosOrder.ToString();
            txtParams.Text = newModule.Parameters;
            txtType.Items.FindByValue(newModule.ExtCode.ToString()).Selected = true;
            txtPosition.Items.FindByValue(newModule.Position).Selected = true;
            txtState.SelectedValue = bool.Parse(newModule.State.ToString());

        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            SiteId.ID = "siteid";
            SiteId.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            this.Controls.Add(SiteId);
            
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
           // btnOK_res.Params.Add(new JJson.JsonResponseParam() { Action=JJson.JsonAction.JText,Value="alert('JJJJJJJJJJJJ');"});
            btnOK_res.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Condition, ReturnField = "Return_Field_Name_On_Response", Condition = new List<JJson.JsonConditionParam>() { new JJson.JsonConditionParam() { Condition = "=='true'", Action = JJson.JsonAction.CloseWindowAndRefreshGrid, Message = "" }, new JJson.JsonConditionParam() { Condition = "=='false'", Action = JJson.JsonAction.ConditionalMessage, Message = "عملیات با خطا مواجه شده است. لطفاً مجددا سعی نمایید" } } });
            btnOK.OnSuccessControlsAction =new List<JJson.JsonResponse>(){ btnOK_res};
            JJson.JsonRequest btnOK_req = new JJson.JsonRequest();
            btnOK_req.URL = "JJsonService/JJsonService.asmx/Run";
            btnOK_req.Type = JJson.JsonRequestType.Classes;
            if(code > 0)
                btnOK_req.data = "CMS.ModuleManagement.JModules->Update";
            else
                btnOK_req.data = "CMS.ModuleManagement.JModules->Insert";
            btnOK_req.Params = new List<JJson.JsonRequestParam>();
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Code", Type = JJson.JsonAction.Html, ControlID = lblCode.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Name", Type = JJson.JsonAction.Value, ControlID = txtName.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "State", Type = JJson.JsonAction.Gender, ControlID = txtState.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Parameters", Type = JJson.JsonAction.Value, ControlID = txtParams.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Site", Type = JJson.JsonAction.Value, ControlID=SiteId.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Position", Type = JJson.JsonAction.Value, ControlID = txtPosition.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "PosOrder", Type = JJson.JsonAction.Value, ControlID = txtOrder.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "ExtCode", Type = JJson.JsonAction.Value, ControlID = txtType.ClientID });
            btnOK.Request = new List<JJson.JsonRequest>(){ btnOK_req};
            JJson.JsonResponse btnOK_error = new JJson.JsonResponse();
            btnOK_error.Params = new List<JJson.JsonResponseParam>();
            btnOK_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
            btnOK.OnErrorControlsAction = new List<JJson.JsonResponse>(){ btnOK_error};
            #endregion

            #region txtState_Settings
            //JsonResponse txtState_res = new JsonResponse();
            //txtState_res.Type = JsonResponseType.Item;
            //txtState_res.Params = new List<JsonResponseParam>();
            //txtState_res.Params.Add(new JsonResponseParam() { ControlToSet = txtFirstName.ClientID, Action = JsonAction.Value, ReturnField = "Return_Field_Name_On_Response" });
            //txtState.OnSuccessControlsAction = new List<JsonResponse>() { txtState_res };
            //JsonRequest txtState_req = new JsonRequest();
            //txtState_req.URL = "JJsonService/JJsonService.asmx/Run";
            //txtState_req.data = "JJsonAdditionalLibrary.JsonComponents.JLoginManager->test";
            //txtState_req.Type = JsonRequestType.Classes;
            //txtState_req.Params = new List<JsonRequestParam>();
            //txtState_req.Params.Add(new JsonRequestParam() { Name = "gTest", Type = JsonAction.txtState, ControlID = txtState.ClientID });
            //txtState.Request = new List<JsonRequest>() { txtState_req };
            //List<JsonValidation> txtState_validations = new List<JsonValidation>();
            ////Value_validations.Add(new JJson.JsonValidation() { ControlID = Control.ClientID, ValueType = JJson.JsonAction.Value, Message = "Validation message", RegexType = JJson.JsonRegexType.Alphanumeric });
            //txtState.Validations = new List<List<JsonValidation>>() { txtState_validations };
            //JsonResponse txtState_error = new JsonResponse();
            //txtState_error.Params = new List<JsonResponseParam>();
            //txtState_error.Params.Add(new JsonResponseParam() { Action = JsonAction.Message });
            //txtState.OnErrorControlsAction = new List<JsonResponse>() { txtState_error };
            #endregion
			
        }
    }
}