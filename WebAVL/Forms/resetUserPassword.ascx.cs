using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAVL.Forms
{
    public partial class resetUserPassword : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string code = Request.QueryString["Code"];
            Globals.JUser user = new Globals.JUser();
            user.GetData(int.Parse(code));
            user.password = TextBox1.Text;
            user.Update();
            WebClassLibrary.JWebManager.RunClientScript("alert('عملیات موفق.');", "ConfirmDialog");
            WebClassLibrary.JWebManager.CloseWindow();
        }
    }
}