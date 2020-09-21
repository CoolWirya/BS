using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebControllers.MainControls.Help
{
    public partial class JHelpControl : System.Web.UI.UserControl
    {
        string ClassName;
        int ObjectCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            ClassName = Request["ClassName"];
            int.TryParse(Request["ObjectCode"], out ObjectCode);

            JHelp jHelp = new JHelp();
            jHelp.GetData(ClassName, ObjectCode);

            if (JHelps.CanEditHelp())
            {
                lblHelp.Visible = false;
                txtHelp.Content = jHelp.Text;
            }
            else
            {
                txtHelp.Visible = false;
                lblHelp.Text = jHelp.Text;
                divButtons.Visible = false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            JHelp jHelp = new JHelp();
            jHelp.GetData(ClassName, ObjectCode);
            jHelp.Text = txtHelp.Content;
            jHelp.ModifiedDate = DateTime.Now;
            jHelp.ClassName = ClassName;
            jHelp.ObjectCode = ObjectCode;
            jHelp.Name = "";
            jHelp.Save();
        }
    }
}