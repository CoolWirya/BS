using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.TemplateManagement
{
    public partial class JSetTemplateControl : System.Web.UI.UserControl
    {
        HiddenField SiteId;
        int Code = 0;
        CMSClassLibrary.Extension.JSiteTemplate SiteTemplate;
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteId = new HiddenField();
            if (WebClassLibrary.SessionManager.Current.Session["SiteCode"] != null)
                SiteId.Value = WebClassLibrary.SessionManager.Current.Session["SiteCode"].ToString();
            CMSClassLibrary.Site.JSite site = new CMSClassLibrary.Site.JSite(Int32.Parse(SiteId.Value));
            if (site != null)
                txtSite.Text = site.Title;
            txtSite.Enabled = false;
            sitelbl.Text = ClassLibrary.JLanguages._Text("Site");
            templatelbl.Text = ClassLibrary.JLanguages._Text("Template");
            Codelbl.Text = ClassLibrary.JLanguages._Text("Code");
            btnOK.Text = ClassLibrary.JLanguages._Text("Save");
            btnCancel.Text = ClassLibrary.JLanguages._Text("Cancel");
            txtTemplate.DataSource = GetAllTemplateStyles().DefaultView;
            txtTemplate.DataTextField = "Style";
            txtTemplate.DataValueField = "Code";
            txtTemplate.DataBind();
            if (!int.TryParse(Request["Code"], out Code))
                return;
            FillForm();
        }
        public void FillForm()
        {
            SiteTemplate = new CMSClassLibrary.Extension.JSiteTemplate(Code);
            lblCode.Text = Code.ToString();
            if (SiteTemplate != null)
            {
                CMSClassLibrary.Site.JSite site = new CMSClassLibrary.Site.JSite(SiteTemplate.SiteCode);
                txtSite.Text = site.Title;
                txtSite.Enabled = false;
               txtTemplate.Items.FindByValue(SiteTemplate.StyleCode.ToString()).Selected = true;
            }
        }

        public DataTable GetAllTemplateStyles()
        {
            DataTable Result=new DataTable();
            Result.Columns.Add("Code");
            Result.Columns.Add("Style");
            DataTable Templates = CMSClassLibrary.Extension.JExtensions.GetDataTable("Type='Template'");
            DataTable styles;
            if (Templates != null)
            {
                foreach (DataRow dr in Templates.Rows)
                {
                    styles = CMSClassLibrary.Template.JTemplates.GetDataTable("ExtensionCode=" + dr["Code"]);
                    if(styles != null)
                    {
                        foreach(DataRow row in styles.Rows)
                        {
                            DataRow NewResultRow = Result.NewRow();
                            NewResultRow["Code"] = row["Code"].ToString();
                            NewResultRow["Style"] = dr["Name"].ToString() + "|" + row["Path"].ToString();
                            Result.Rows.Add(NewResultRow);
                        }
                    }
                }
            }
            return Result;
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
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
            btnOK_res.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Condition, ReturnField = "Return_Field_Name_On_Response", Condition = new List<JJson.JsonConditionParam>() { new JJson.JsonConditionParam() { Condition = "=='true'", Action = JJson.JsonAction.CloseWindowAndRefreshGrid, Message = "" }, new JJson.JsonConditionParam() { Condition = "=='false'", Action = JJson.JsonAction.ConditionalMessage, Message = "عملیات با خطا مواجه شده است. لطفاً مجددا سعی نمایید" } } });
            btnOK.OnSuccessControlsAction = new List<JJson.JsonResponse>() { btnOK_res };
            JJson.JsonRequest btnOK_req = new JJson.JsonRequest();
            btnOK_req.URL = "JJsonService/JJsonService.asmx/Run";
            btnOK_req.Type = JJson.JsonRequestType.Classes;
            if (Code > 0)
                btnOK_req.data = "CMSClassLibrary.Extension.JSiteTemplate->Update";
            else
                btnOK_req.data = "CMSClassLibrary.Extension.JSiteTemplate->Insert";
            btnOK_req.Params = new List<JJson.JsonRequestParam>();
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "Code", Type = JJson.JsonAction.Html, ControlID = lblCode.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "StyleCode", Type = JJson.JsonAction.Value, ControlID = txtTemplate.ClientID });
            btnOK_req.Params.Add(new JJson.JsonRequestParam() { Name = "SiteCode", Type = JJson.JsonAction.Value, ControlID = SiteId.ClientID });
            btnOK.Request = new List<JJson.JsonRequest>() { btnOK_req };
            JJson.JsonResponse btnOK_error = new JJson.JsonResponse();
            btnOK_error.Params = new List<JJson.JsonResponseParam>();
            btnOK_error.Params.Add(new JJson.JsonResponseParam() { Action = JJson.JsonAction.Message });
            btnOK.OnErrorControlsAction = new List<JJson.JsonResponse>() { btnOK_error };
            #endregion

        }
    }
}