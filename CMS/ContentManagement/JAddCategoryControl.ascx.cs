using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.ContentManagement
{
    public partial class JAddCategoryControl : System.Web.UI.UserControl
    {
        int code;
        HiddenField SiteId;
        CMSClassLibrary.Content.JCategory newCategory;
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteId = new HiddenField();
            if (WebClassLibrary.SessionManager.Current.Session["SiteCode"] != null)
                SiteId.Value = WebClassLibrary.SessionManager.Current.Session["SiteCode"].ToString();
            DataTable Categories = CMSClassLibrary.Content.JCategories.GetDataTable("1=1");
            if (Categories != null)
            {
                txtParent.DataSource = Categories.DefaultView;
                txtParent.DataTextField = "Name";
                txtParent.DataValueField = "Code";
                txtParent.DataBind();
            }
            if (!int.TryParse(Request["Code"], out code))
                return;
            FillForm();

        }
        public void FillForm()
        {
            newCategory = new CMSClassLibrary.Content.JCategory(code);
            lblCode.Text = newCategory.Code.ToString();
            txtName.Text = newCategory.Title;
            txtAccess.Items.FindByValue(newCategory.Access.ToString()).Selected = true;
            if(newCategory.ParentCode != null)
            txtParent.Items.FindByValue(newCategory.ParentCode.ToString()).Selected = true;
            txtState.SelectedValue = bool.Parse(newCategory.State.ToString());
            txtParams.Text = newCategory.Parameters;
            txtDesc.Text = newCategory.Description;
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
            Paramslbl.Text = JLanguages._Text("Parameters");
            Accesslbl.Text = JLanguages._Text("Access");
            Desclbl.Text = JLanguages._Text("Description");
            btnOK.Text = JLanguages._Text("Save");
            btnCancel.Text = JLanguages._Text("Cancel");
            Parentlbl.Text = JLanguages._Text("ParentCategory");
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
            btnOK.OnSuccessControlsAction = new List<JJson.JsonResponse>() { btnOK_res};
            JJson.JsonRequest btnOK_req = new JJson.JsonRequest();
           btnOK_req.URL = "JJsonService/JJsonService.asmx/Run";
            btnOK_req.Type = JJson.JsonRequestType.Classes;
            if(code > 0)
                btnOK_req.data = "CMSClassLibrary.Content.JCategory->Update";
            else
                btnOK_req.data = "CMSClassLibrary.Content.JCategory->Insert";
            btnOK_req.Params = new List<JJson.JsonRequestParam>();
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Code", Type = JJson.JsonAction.Html, ControlID = lblCode.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "ParentCode", Type = JJson.JsonAction.Value, ControlID = txtParent.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "State", Type = JJson.JsonAction.Gender, ControlID = txtState.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Title", Type = JJson.JsonAction.Value, ControlID = txtName.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Name", Type = JJson.JsonAction.Value, ControlID = txtName.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Access", Type = JJson.JsonAction.Value, ControlID = txtAccess.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Site", Type = JJson.JsonAction.Value, ControlID = SiteId.ClientID});
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Parameters", Type = JJson.JsonAction.Value, ControlID = txtParams.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Description", Type = JJson.JsonAction.Value, ControlID = txtDesc.ClientID });
            btnOK.Request = new List<JJson.JsonRequest>() { btnOK_req};
            JJson.JsonResponse btnOK_error = new JJson.JsonResponse();
            btnOK_error.Params = new List<JJson.JsonResponseParam>();
            btnOK_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
            btnOK.OnErrorControlsAction = new List<JJson.JsonResponse>() { btnOK_error};
            #endregion
			
        }
    }
}