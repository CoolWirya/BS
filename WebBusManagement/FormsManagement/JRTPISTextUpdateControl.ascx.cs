using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JRTPISTextUpdateControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                txtRTPISText.Text = BusManagment.Settings.JBusSettings.Get("RTPISText").ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if(txtRTPISText.Text!="")
            {
                BusManagment.Settings.JBusSettings.Set("RTPISText", txtRTPISText.Text);
                WebClassLibrary.JWebManager.RunClientScript("alert('متن مورد نظر با موفقیت بروز رسانی شد');", "UpdateSettings");
            }
        }
    }
}