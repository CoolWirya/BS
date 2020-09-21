using System;
using System.Collections.Generic;
using WebProjectManagement.Forms;
using ProjectManagement;
using ProjectManagement.Template;
namespace WebProjectManagement.Forms
{
    public partial class TemplateUpdate : System.Web.UI.UserControl
    {
        int code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out code);

            if (code > 0)
            {
                JTemplate t = new JTemplate(code);
                txtName.Text = t.Name;
                txtTotalWeight.Text = t.TotalWeight.ToString();
            }
            else
            {
                txtTotalWeight.Text = "100";
                ddlTemplates.Items.Add(new System.Web.UI.WebControls.ListItem("هیچکدام", "-1"));
                foreach (System.Data.DataRow dr in ProjectManagement.Template.JTemplates.GetDataTable().Rows)
                    ddlTemplates.Items.Add(new System.Web.UI.WebControls.ListItem(dr["Name"].ToString(), dr["Code"].ToString()));
            }
            pnlPrompt.Visible = false;
            pnlPrompt.Controls.Add(InitPromptBox());
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTotalWeight.Text.ContainsNonDigit())
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('برای وزن فقط عدد وارد کنید.');", "ConfirmDialog");
                return;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفا نام را وارد کنید.');", "ConfirmDialog");
                return;
            }
            JTemplate t = new JTemplate(code);
            t.Name = txtName.Text;
            t.TotalWeight = txtTotalWeight.Text.ToDecimal();
            bool success = false;
            if (t.Code > 0)
                success = t.Update();
            else
            {
                success = t.Insert(ddlTemplates.SelectedValue.ToInt32()) > 0;
            }
            if (success)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('الگو ذخیره شد');", "ConfirmDialog");
                WebClassLibrary.JWebManager.RunClientScript("window.parent.document.getElementById('" + ((System.Web.UI.WebControls.WebControl)WebClassLibrary.SessionManager.Current.Session[JWebProjectManagement._ConstClassName.Replace(".", "_") + "_Templates"]).ClientID + "_refreshStaticButton').click();", "refreshGrid");

                WebClassLibrary.JWebManager.RunClientScript("CloseDialog(null);", "closedialoge");
            }
            else
                WebClassLibrary.JWebManager.RunClientScript("alert('متاسفانه خطایی رخ داده است. نمی توان الگو را ذخیره کرد');", "ConfirmDialog");

        }
       
        protected void RadButton2_Click(object sender, EventArgs e)
        {
            pnlPrompt.Visible = true;
        }

        private AskUser InitPromptBox()
        {

            AskUser askUser = (AskUser)LoadControl(JWebProjectManagement.FORMS_PLACE + "AskUser.ascx");
            askUser.Message = "آیا مطمئن هستید که الگو حذف شود؟ تمام آیتم ها نیز حذف خواهند شد!";
            askUser.ok = new AskUser.Clicked(() =>
            {
                JTemplate t = new JTemplate(code);
                if (t.Delete())
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('الگو حذف شد');", "ConfirmDialog");

                    WebClassLibrary.JWebManager.RunClientScript("window.parent.document.getElementById('" + ((System.Web.UI.WebControls.WebControl)WebClassLibrary.SessionManager.Current.Session[WebProjectManagement.JWebProjectManagement._ConstClassName.Replace(".", "_") + "_Templates"]).ClientID + "_refreshStaticButton').click();", "refreshGrid");
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