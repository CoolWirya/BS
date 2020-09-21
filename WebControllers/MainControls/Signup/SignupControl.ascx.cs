using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace WebControllers.MainControls.Signup
{
    public partial class SignupControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNext1_Click(object sender, EventArgs e)
        {
            if (rbnShareCodeYes.Checked)
            {
                RadMultiPage1.SelectedIndex = 1;
                RadTabStrip1.Tabs[1].Visible = true;
                RadTabStrip1.Tabs[1].Selected = true;
            }
            else if (rbnShareCodeNo.Checked)
            {
                RadMultiPage1.SelectedIndex = 2;
                RadTabStrip1.Tabs[2].Visible = true;
                RadTabStrip1.Tabs[2].Selected = true;
            }
        }

        protected void btnNext2_Click(object sender, EventArgs e)
        {
            // Check ShareCode, CodeMelli

            // Create New User

            // Go To Final Tab
            RadMultiPage1.SelectedIndex = 1;
            RadTabStrip1.Tabs[3].Visible = true;
            RadTabStrip1.Tabs[3].Selected = true;
        }

        protected void btnNext3_Click(object sender, EventArgs e)
        {
            // Check User Data
            

            // Create New User

            // Go To Final Tab
            RadMultiPage1.SelectedIndex = 1;
            RadTabStrip1.Tabs[3].Visible = true;
            RadTabStrip1.Tabs[3].Selected = true;
        }
    }
}