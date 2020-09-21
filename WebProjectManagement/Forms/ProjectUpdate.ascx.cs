using System;

using pm= ProjectManagement.Project;

namespace WebProjectManagement.Forms
{
    public partial class ProjectUpdate : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            pm.JProject p;
            if (Code < 1)
            {
                p = new pm.JProject() { StartDate = DateTime.Today, EndDate = DateTime.Today.AddMonths(1) };
                cmbTemplates.Items.Add(new System.Web.UI.WebControls.ListItem("هیچکدام", "-1"));
                foreach (System.Data.DataRow dr in ProjectManagement.Template.JTemplates.GetDataTable().Rows)
                    cmbTemplates.Items.Add(new System.Web.UI.WebControls.ListItem(dr["Name"].ToString(), dr["Code"].ToString()));
            }
            else
            {
                p = new pm.JProject(Code);
            }

            txtName.Text = p.Name;
            ((WebControllers.MainControls.Date.JDateControl)dateStart).SetDate(p.StartDate);
            ((WebControllers.MainControls.Date.JDateControl)dateEnd).SetDate(p.EndDate);
            txtTotalWeight.Text = p.TotalWeight.ToString("100");
            txtDescription.Text = p.ProjectDescription;
            txtLocationAddress.Text = p.LocationAddress;

            if (IsPostBack)
            {
                pnlPrompt.Visible = false;
                pnlPrompt.Controls.Add(InitPromptBox());
            }
        }

        protected void rdblTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cmbTemplates.Items.Clear();
            //if (rdblTemplate.SelectedIndex > 0) cmbTemplates.Visible = true;
            //System.Data.DataTable dt;
            //if (rdblTemplate.SelectedIndex == 1)
            //    dt = ProjectManagement.Template.JTemplates.GetDataTable();
            //else if (rdblTemplate.SelectedIndex == 2)
            //    dt = ProjectManagement.Project.JProjects.GetDataTable(true);
            //else
            //{
            //    cmbTemplates.Items.Clear();
            //    cmbTemplates.Visible = false;
            //    return;
            //}
            //if (dt == null) return;

            //cmbTemplates.DataSource = dt;
            //cmbTemplates.DataTextField = "Name";
            //cmbTemplates.DataValueField = "Code";
            //cmbTemplates.DataBind();
        }
        protected void RadButton2_Click(object sender, EventArgs e)
        {
            pnlPrompt.Visible = true;
        }

        private AskUser InitPromptBox()
        {

            AskUser askUser = (AskUser)LoadControl(JWebProjectManagement.FORMS_PLACE + "AskUser.ascx");
            askUser.Message = "آیا مطمئن هستید که پروژه حذف شود؟ تمام آیتم ها نیز حذف خواهند شد!";
            askUser.ok = new AskUser.Clicked(() =>
            {
                ProjectManagement.Project.JProject P = new ProjectManagement.Project.JProject(Code);
                if (P.Delete())
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('پروژه حذف شد');", "ConfirmDialog");
                    WebClassLibrary.JWebManager.RunClientScript("window.parent.document.getElementById('"+ ((System.Web.UI.WebControls.WebControl)WebClassLibrary.SessionManager.Current.Session[WebProjectManagement.JWebProjectManagement._ConstClassName.Replace(".", "_") + "_Projects"]).ClientID+ "_refreshStaticButton').click();", "refreshGrid");
                }
                else
                    WebClassLibrary.JWebManager.RunClientScript("alert('عملیات ناموفق');", "ConfirmDialog");
                WebClassLibrary.JWebManager.RunClientScript("CloseDialog(null);", "closedialoge");

            });
            askUser.no = new AskUser.Clicked(() => { pnlPrompt.Controls.Clear(); });
            return askUser;
        }
    }
}