using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AndroidWebManagement.Forms
{
    public partial class JDeleteSendBoxNewUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            _SetForm();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                DB.setQuery(@"delete from ShareMessage where code = " + Code);
                DB.Query_Execute();
            }
        }
    }
}