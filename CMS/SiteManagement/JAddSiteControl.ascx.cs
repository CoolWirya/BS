using JJson;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.SiteManagement
{
    public partial class JAddSiteControl : System.Web.UI.UserControl
    {
        public int Code = 0;
        CMSClassLibrary.Site.JSite site;
        protected void Page_Load(object sender, EventArgs e)
        {
            int PCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;

            Titlelbl.Text = ClassLibrary.JLanguages._Text("Title");
            Domainlbl.Text = ClassLibrary.JLanguages._Text("Domain");
            Desclbl.Text = ClassLibrary.JLanguages._Text("Description");
            btnOK.Text = ClassLibrary.JLanguages._Text("Save");
            btnCancel.Text = ClassLibrary.JLanguages._Text("Cancel");
            Codelbl.Text = ClassLibrary.JLanguages._Text("Site Code");
            if (!int.TryParse(Request["Code"], out Code))
                return;
            FillForm();
        }

        public void FillForm()
        {
            site = new CMSClassLibrary.Site.JSite(Code);
            lblCode.Text = Code.ToString();
            if (site != null)
            {
                txtTitle.Text = site.Title;
                txtDomain.Text = site.Domain;
                txtDesc.Text = site.Description;
            }

          
        }

        

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            WebClassLibrary.JWebManager.CloseWindow();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            
            //#region txtTemp_Settings
            //JJson.JsonResponse txtTemp_res = new JJson.JsonResponse();
            //txtTemp_res.Type = JJson.JsonResponseType.Table;
            //txtTemp_res.Params = new List<JJson.JsonResponseParam>();
            //txtTemp_res.Params.Add(new JJson.JsonResponseParam() { Action=JsonAction.JText, Value="alert('dddd');" });
            //txtTemp_res.Params.Add(new JJson.JsonResponseParam() { BindControlType = JsonBindableType.DropDownList, ControlToSet = txtst.ClientID, Action = JJson.JsonAction.DataBind, Name = "Path", Value = "Code" });
            //txtTemp.OnSuccessControlsAction = new List<JJson.JsonResponse>() { txtTemp_res};
            //JJson.JsonRequest txtTemp_req = new JJson.JsonRequest();
            //txtTemp_req.URL = "JJsonService/JJsonService.asmx/Run";
            //txtTemp_req.data = "JJsonAdditionalLibrary.JsonComponents.JLoginManager->getStyles";
            //txtTemp_req.Type = JJson.JsonRequestType.Classes;
            //txtTemp_req.Params = new List<JJson.JsonRequestParam>();
            //txtTemp_req.Params.Add(new JJson.JsonRequestParam() { Name = "ExtensionCode", Type = JJson.JsonAction.Value, ControlID = txtTemp.ClientID });
            //txtTemp.Request = new List<JJson.JsonRequest>() { txtTemp_req};
            //JJson.JsonResponse txtTemp_error = new JJson.JsonResponse();
            //txtTemp_error.Params = new List<JJson.JsonResponseParam>();
            //txtTemp_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
            //txtTemp.OnErrorControlsAction = new List<JJson.JsonResponse>() { txtTemp_error};
            //#endregion
			

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
                btnOK_req.data = "CMSClassLibrary.Site.JSite->Update";
            else
                btnOK_req.data = "CMSClassLibrary.Site.JSite->Insert";
            btnOK_req.Params = new List<JJson.JsonRequestParam>();
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Code", Type = JJson.JsonAction.Html, ControlID = lblCode.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Title", Type = JJson.JsonAction.Value, ControlID = txtTitle.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Description", Type = JJson.JsonAction.Value, ControlID = txtDesc.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Domain", Type = JJson.JsonAction.Value, ControlID = txtDomain.ClientID });
            btnOK.Request = new List<JJson.JsonRequest>() { btnOK_req };
            JJson.JsonResponse btnOK_error = new JJson.JsonResponse();
            btnOK_error.Params = new List<JJson.JsonResponseParam>();
            btnOK_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
            btnOK.OnErrorControlsAction = new List<JJson.JsonResponse>() { btnOK_error };
            #endregion

        }
    }
}