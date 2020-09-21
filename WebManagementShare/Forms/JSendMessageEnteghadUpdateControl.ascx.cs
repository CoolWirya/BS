using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebManagementShare.Forms
{
    public partial class JSendMessageEnteghadUpdateControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool Save()
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            db.setQuery(@"insert into ShareMessage([Code]
                                              ,[SenderCode]
                                              ,[ReceiverCode]
                                              ,[sDate]
                                              ,[Title]
                                              ,[Body]
                                              ,[Type]) values((select isnull(max(code),0)+1 from ShareMessage)," + WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode + @",
                                                (select top 1 pcode from users where IsAdmin=1)
                                                ,'" + ClassLibrary.JDateTime.FarsiDate(DateTime.Now).ToString().Substring(0,10) + @"'
                                                ,'" + txtSubject.Text + @"'
                                                 ,'" + txtBody.Text + @"',3)");
            return db.Query_Execute() >= 0 ? true : false;
        }
        //((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlInstaller).PersonCode

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }
    }
}