using ClassLibrary;
using Globals.Property;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControllers.FormManager
{
    public partial class JFormDefineControl : System.Web.UI.UserControl
    {
        int formCode = 0;
        string className;
        string JWebFormsTemporaryURL;
        WebClassLibrary.JSUIDManager formSUID;
        protected void Page_Load(object sender, EventArgs e)
        {
            formSUID = new WebClassLibrary.JSUIDManager("Forms");
            className = formSUID.GetObject("ClassName").ToString();
            JWebFormsTemporaryURL = formSUID.GetObject("JWebFormsTemporaryURL").ToString();
            formCode = int.Parse(formSUID.GetObject("ObjectCode").ToString());
            if (formCode > 0)
            {
                txtFormName.Text = Regex.Replace(formSUID.GetObject("FormName").ToString(), @"&nbsp;", "").Trim();
                txtQuery.Text = Regex.Replace(formSUID.GetObject("SqlQuery").ToString(), @"&nbsp;", "").Trim();
                cbxMultiple.Enabled = false;
                cbxMultiple.Checked = (new JForms(formCode)).isMultiple;
            }
            SetForm();
        }
        void SetForm()
        {
            DataTable dt = Employment.JEOrganizationChart.GetUserPosts();
            foreach (DataRow dr in dt.Rows)
            {
                ListItem li = new ListItem();
                li.Text = dr[1].ToString();
                li.Value = dr[0].ToString();
                clbPosts.Items.Add(li);
            }
            if (formCode > 0)
            {
                dt = (new JFormUserPostCode()).GetData(formCode);
                foreach (DataRow cDataRow in dt.Rows)
                    for (int i = 0; i < clbPosts.Items.Count; i++)
                        if (clbPosts.Items[i].Selected = Convert.ToInt32(clbPosts.Items[i].Value) == Convert.ToInt32(cDataRow[0]))
                            break;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtQuery.Text != "" && txtQuery.Text.IndexOf("@ObjectCode") < 0)
            {
                WebClassLibrary.JWebManager.ShowMessage("پارامتر @ObjectCode در کوئری استفاده نشده است.");
                return;
            }
            JForms jForms = null;
            JFormUserPostCode jFormUserPostCode = new JFormUserPostCode();
            if (formCode == 0)
            {
                jForms = new JForms();
                jForms.isMultiple = cbxMultiple.Checked;
                jForms.ClassName = className;
                jForms.FormName = txtFormName.Text;
                jForms.SQL = txtQuery.Text;
                jForms.user_code = JMainFrame.CurrentUserCode;
                jForms.Date = DateTime.Now;
                formCode = jForms.Insert();
                if (formCode <= 0)
                {
                    WebClassLibrary.JWebManager.ShowMessage("ثبت فرم جدید با خطا مواجه شد.");
                    return;
                }
                // افزودن اعضای انتخاب شده به جدول FormUserPostCode
                for (int i = 0; i < clbPosts.Items.Count; i++)
                    if (clbPosts.Items[i].Selected)
                        jFormUserPostCode.Insert(formCode, Convert.ToInt32(clbPosts.Items[i].Value));
            }
            else
            {
                jForms = new JForms(formCode);
                jFormUserPostCode.DeleteByFormCode(jForms.Code);
                for (int i = 0; i < clbPosts.Items.Count; i++)
                    if (clbPosts.Items[i].Selected)
                        jFormUserPostCode.Insert(formCode, Convert.ToInt32(clbPosts.Items[i].Value));
                jForms.FormName = txtFormName.Text;
                jForms.SQL = txtQuery.Text;
                jForms.Update();
            }
            //HttpContext.Current.Response.Redirect(JWebFormsTemporaryURL);
            formSUID = new WebClassLibrary.JSUIDManager("Forms");
            formSUID.SetObject("JWebFormsTemporaryURL", Request.Url.AbsoluteUri);
            formSUID.SetObject("ClassName", className);
            formSUID.SetObject("ObjectCode", formCode);
            WebClassLibrary.JWebManager.LoadControl("Forms"
                    , "~/WebControllers/FormManager/JFormDefinePropertyControl.ascx"
                    , "فیلدهای فرم"
                    , null
                    , WebClassLibrary.WindowTarget.CurrentWindow
                    , true, true, true, 600, 400);
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Redirect(JWebFormsTemporaryURL);
        }
    }
}