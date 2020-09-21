using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProjectManagement.Forms
{
    public partial class AskUser : System.Web.UI.UserControl
    {
        public delegate void Clicked();
        public Clicked ok, no;

        public string Message { set { txtText.Text = value; } }
        protected void Page_Load(object sender, EventArgs e)
        {
            RadButton1.Click += RadButton1_Click;
        }
        

        protected void RadButton1_Click(object sender, EventArgs e)
        {
            if (ok != null) ok();
        }

        protected void RadButton2_Click(object sender, EventArgs e)
        {
            if (no != null) no();
        }
    }
}