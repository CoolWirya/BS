using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAVL.Forms
{
    public partial class ReisterSubuserUpdate : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtMobile.Text))
            {
                WebClassLibrary.JWebManager.ShowMessage("تمام فد هارا پر کنید.");
                return;
            }
            Globals.JUser user = new Globals.JUser();
            if (user.find(txtUsername.Text) > 0)
            {ClassLibrary.JPersonAddress pa=new ClassLibrary.JPersonAddress();
            if (pa.getData(txtMobile.Text))
            {
                if (pa.Code > 0)
                {
                    Employment.JEOrganizationChart oc = new Employment.JEOrganizationChart();
                    oc.user_code = user.code;
                    oc.parentcode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
                    if (oc.InsertNode(false))
                    {
                        ClassLibrary.JPermissionUser pu = new ClassLibrary.JPermissionUser();
                        pu.User_Post_Code = oc.code;


                        ClassLibrary.JPermissionGroupUsers gu = new ClassLibrary.JPermissionGroupUsers();
                        gu.User_Post_Code = oc.code;
                        gu.GroupCode = 1;// کد گروه
                        gu.Insert(false);

                    }
                }
                else
                    WebClassLibrary.JWebManager.ShowMessage("شماره همراه صحیح نمی باشد.");
            }
            }
            else
                WebClassLibrary.JWebManager.ShowMessage("کاربری با این نام کاربری وجود ندارد.");

        }
    }
}