using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using JJson;
using System.Data;

namespace CMS.ContentManagement
{
    public partial class JAddContentControl : System.Web.UI.UserControl
    {
        public CMSClassLibrary.Content.JContent newContent;
        public int code = 0;
        HiddenField SiteId;
        bool UpdateMode;
        DateTime dd;
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteId = new HiddenField();
            int PCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode;
            
               
            if (WebClassLibrary.SessionManager.Current.Session["SiteCode"] != null)
            {
                SiteId.Value = WebClassLibrary.SessionManager.Current.Session["SiteCode"].ToString();
                UpdateMode = true;
                dd = DateTime.Now;
            }
            else
                UpdateMode = false;
            hdnPCode.Value = PCode.ToString() ;
            DataTable sites = CMSClassLibrary.Site.JSites.GetDataTable("1=1");
            DataTable Statuses = CMSClassLibrary.Content.JStatuses.GetDataTable("1=1");
            txtStatus.DataSource = Statuses.DefaultView;
            txtStatus.DataTextField = "Name";
            txtStatus.DataValueField = "Code";
            txtStatus.DataBind();
            DataTable Categories = CMSClassLibrary.Content.JCategories.GetDataTable("1=1");
            txtCategory.DataSource = Categories.DefaultView;
            txtCategory.DataTextField = "Name";
            txtCategory.DataValueField = "Code";
            txtCategory.DataBind();
            
            if (!int.TryParse(Request["Code"], out code))
                return;
            FillForm();
           
        }

        public JAddContentControl()
        {
           
        }

        public void FillForm()
        {
            newContent = new CMSClassLibrary.Content.JContent(code); 
            lblCode.Text = newContent.Code.ToString();
            txtName.Text = newContent.Title;
            txtAccess.Items.FindByValue(newContent.Access.ToString()).Selected = true;
            txtCategory.Items.FindByValue(newContent.CategoryCode.ToString()).Selected = true;
            txtState.SelectedValue = bool.Parse(newContent.State.ToString());
            txtStatus.Items.FindByValue(newContent.Status.ToString()).Selected = true;
            elrteText.Value = newContent.Text.Replace(".@&quotes@.", "\""); 
            hdnDateForInsert.Value = newContent.Created.ToString();
            hdnDateForUpdate.Value = newContent.Modified.ToString();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            WebClassLibrary.JWebManager.CloseWindow();
        }
       
        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            Codelbl.Text = JLanguages._Text("Code");
            Titlelbl.Text = JLanguages._Text("Title");
            Statelbl.Text = JLanguages._Text("State");
            Statuslbl.Text = JLanguages._Text("Status");
            Accesslbl.Text = JLanguages._Text("Access");
            Textlbl.Text = JLanguages._Text("Text");
            btnOK.Text = JLanguages._Text("Save");
            btnCancel.Text = JLanguages._Text("Cancel");
            Categorylbl.Text = JLanguages._Text("Category");
            this.Controls.Add(SiteId);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            Methods.RegisterEditorContentScript(this.Page,txtText.ClientID ,elrteText.ClientID,hdnDateForInsert.ClientID,hdnDateForUpdate.ClientID,UpdateMode.ToString());
            #region btnOK_Settings
            JJson.JsonResponse btnOK_res = new JJson.JsonResponse();
            btnOK_res.Type = JJson.JsonResponseType.RefreshGridAndClose;
            btnOK_res.Params = new List<JJson.JsonResponseParam>();
            btnOK_res.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Condition, ReturnField = "Return_Field_Name_On_Response", Condition = new List<JJson.JsonConditionParam>() { new JJson.JsonConditionParam() { Condition = "=='true'", Action = JJson.JsonAction.CloseWindowAndRefreshGrid, Message = "" }, new JJson.JsonConditionParam() { Condition = "=='false'", Action = JJson.JsonAction.ConditionalMessage, Message = "عملیات با خطا مواجه شده است. لطفاً مجددا سعی نمایید" } } });
            btnOK.OnSuccessControlsAction = new List<JJson.JsonResponse>() { btnOK_res};
            JJson.JsonRequest btnOK_req = new JJson.JsonRequest();
            btnOK_req.URL = "JJsonService/JJsonService.asmx/Run";
            btnOK_req.Type = JJson.JsonRequestType.Classes;
            if(code > 0)
                btnOK_req.data = "CMSClassLibrary.Content.JContent->Update";
            else
                btnOK_req.data = "CMSClassLibrary.Content.JContent->Insert";
            btnOK_req.Params = new List<JJson.JsonRequestParam>();
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Code", Type = JJson.JsonAction.Html, ControlID = lblCode.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "CategoryCode", Type = JJson.JsonAction.Value, ControlID = txtCategory.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "State", Type = JJson.JsonAction.Gender, ControlID = txtState.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Title", Type = JJson.JsonAction.Value, ControlID = txtName.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Status", Type = JJson.JsonAction.Value, ControlID = txtStatus.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Access", Type = JJson.JsonAction.Value, ControlID = txtAccess.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Site", Type = JJson.JsonAction.Value, ControlID = SiteId.ClientID});
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Text", Type = JJson.JsonAction.Value, ControlID = elrteText.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Created", Type = JJson.JsonAction.Value, ControlID = hdnDateForInsert.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "CreatedBy", Type = JJson.JsonAction.Value, ControlID = hdnPCode.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Modified", Type = JJson.JsonAction.Value, ControlID = hdnDateForUpdate.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "ModifiedBy", Type = JJson.JsonAction.Value, ControlID = hdnPCode.ClientID });
            btnOK.Request = new List<JJson.JsonRequest>() { btnOK_req};
            JJson.JsonResponse btnOK_error = new JJson.JsonResponse();
            btnOK_error.Params = new List<JJson.JsonResponseParam>();
            btnOK_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
            btnOK.OnErrorControlsAction = new List<JJson.JsonResponse>() {btnOK_error };
            #endregion
			
        }

        
    }
}