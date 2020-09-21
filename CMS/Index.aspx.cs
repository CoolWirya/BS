using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS
{
    public partial class Index1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string TemplatePath = HttpContext.Current.Server.MapPath("~/TemplateManagement/Templates/Beez/index.aspx");
            HttpContext.Current.Server.Transfer("~/administrator/CMS/TemplateManagement/Templates/Beez/index.aspx");
        }
    }
}