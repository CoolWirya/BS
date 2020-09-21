using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebERP
{
    public partial class EmailVarification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userId =Page.Request["q"];
            string number =Page.Request["n"];
            string email =Page.Request["s"];

            AVL.UserVerify.JUserVarify j = new AVL.UserVerify.JUserVarify();
            j.email = email;
            j.emailVarified = true;
            j.phonenumber = number;
            j.phoneVarified = true;
            j.userID = userId;
            if (j.VarifyEmail())
            {
                lblMsg.Text = "ایمیل تایید شد. می توانید از لینک زیر برای ورود استفاده کنید.";
                //HyperLink1.Visible = true;
            }
            else
                lblMsg.Text = "خطا رخ داده است.";
        }
    }
}