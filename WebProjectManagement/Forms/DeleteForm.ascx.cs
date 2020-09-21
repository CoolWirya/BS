using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProjectManagement.Forms
{
    public partial class DeleteForm : System.Web.UI.UserControl
    {
        int type, code;

        AskUser askUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Type"], out type);
            int.TryParse(Request["Code"], out code);

            if (code > 0)
                WebClassLibrary.JWebManager.CloseAndRefresh();

            askUser = (AskUser)LoadControl(JWebProjectManagement.FORMS_PLACE + "AskUser.ascx");

            switch (type)
            {
                case 0://delete item report
                    ProjectManagement.ItemReport.JItemReport r = new ProjectManagement.ItemReport.JItemReport(code);
                    askUser.Message = "آیا مطمئن هستید که گزارش حذف شود؟";
                    askUser.ok = new AskUser.Clicked(() =>
                    {
                        if (r.Delete())
                            WebClassLibrary.JWebManager.RunClientScript("alert('گزارش حذف شد.');", "ConfirmDialog");
                        else
                            WebClassLibrary.JWebManager.RunClientScript("alert('خطا در عملیات.');", "ConfirmDialog");
                        WebClassLibrary.JWebManager.RunClientScript("CloseDialog(null);", "closedialoge");
                    });
                    askUser.no = new AskUser.Clicked(() =>
                    {
                        content.Controls.Clear();
                        WebClassLibrary.JWebManager.CloseAndRefresh();
                    });
                    break;
            }
            content.Visible = true;
            content.Controls.Add(askUser);
        }
    }
}