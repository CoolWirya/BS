using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using WebClassLibrary;

namespace WebControllers.FormManager
{
    public partial class JWebForms : System.Web.UI.UserControl
    {
        private const string SUID = "Forms";
        public string className;//= "WebControllers.FormManager.JWebForms";
        protected void Page_Load(object sender, EventArgs e)
        {
            WebClassLibrary.JSUIDManager formSUID = new WebClassLibrary.JSUIDManager(SUID);
            //className = formSUID.GetObject("ClassName").ToString();
			className = Request["ClassName"];
            SetForm();
        }
        public void SetForm()
        {
            gridView.DataSource = ClassLibrary.JForms.GetListForm(className);
            gridView.DataBind();
        }
        protected void gridView1_PageIndexChanged(object sender, Telerik.Web.UI.GridPageChangedEventArgs e)
        {
            gridView.CurrentPageIndex = e.NewPageIndex;
            gridView.DataBind();
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            WebClassLibrary.JSUIDManager jSUIDManager = new WebClassLibrary.JSUIDManager(SUID);
            jSUIDManager.SetObject("JWebFormsTemporaryURL", Request.Url.AbsoluteUri);
            jSUIDManager.SetObject("ClassName", className);
            jSUIDManager.SetObject("ObjectCode", 0);
            WebClassLibrary.JWebManager.LoadControl(SUID
                    , "~/WebControllers/FormManager/JFormDefineControl.ascx"
                    , "فرم جدید"
                    , null
                    , WebClassLibrary.WindowTarget.CurrentWindow
                    , true, true, true, 600, 400);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridView.SelectedItems == null || gridView.SelectedItems.Count < 1)
            {
                JWebManager.ShowMessage("رکوردی برای ویرایش انتخاب نشده است");
                return;
            }
            string formCode = (gridView.SelectedItems[0] as GridDataItem)["Code"].Text;
            string formName = (gridView.SelectedItems[0] as GridDataItem)["FormName"].Text;
            string sqlQuery = (gridView.SelectedItems[0] as GridDataItem)["Sql"].Text;
            WebClassLibrary.JSUIDManager jSUIDManager = new WebClassLibrary.JSUIDManager("Forms");
            jSUIDManager.SetObject("JWebFormsTemporaryURL", Request.Url.AbsoluteUri);
            jSUIDManager.SetObject("ClassName", className);
            jSUIDManager.SetObject("ObjectCode", formCode);
            jSUIDManager.SetObject("FormName", formName);
            jSUIDManager.SetObject("SqlQuery", sqlQuery);
            WebClassLibrary.JWebManager.LoadControl(SUID
                    , "~/WebControllers/FormManager/JFormDefineControl.ascx"
                    , "ویرایش فرم"
                    , null
                    , WebClassLibrary.WindowTarget.CurrentWindow
                    , true, true, true, 600, 400);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridView.Items == null || gridView.Items.Count <= 0)
                return;
            if (gridView.SelectedIndexes == null || gridView.SelectedIndexes.Count == 0)
            {
                JWebManager.ShowMessage("رکوردی برای ویرایش انتخاب نشده است");
                return;
            }
            int formCode = int.Parse((gridView.SelectedItems[0] as GridDataItem)["Code"].Text);
            JFormObjects jFormObjects = new JFormObjects();
            if (jFormObjects.GetDataTable(Convert.ToInt32(formCode)).Rows.Count > 0)
            {
                JWebManager.ShowMessage("از این فرم استفاده شده است. امکان حذف وجود ندارد.");
                return;
            }
            JForms jForms = new JForms();
            jForms.Code = formCode;
            jForms.Delete();
            //Globals.Property.JProperties PropTB = new Globals.Property.JProperties(className, formCode);
            SetForm();
        }
    }
}