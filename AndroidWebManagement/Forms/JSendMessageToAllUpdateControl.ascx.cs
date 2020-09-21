using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AndroidWebManagement.Forms
{
    public partial class JSendMessageToAllUpdateControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool Save()
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
//            db.setQuery(@"insert into ShareMessage([Code]
//                                              ,[SenderCode]
//                                              ,[ReceiverCode]
//                                              ,[sDate]
//                                              ,[Title]
//                                              ,[Body]
//                                              ,[Type]) values((select max(code)+1 from ShareMessage)," + WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode + @",
//                                                0
//                                                ,'" + ClassLibrary.JDateTime.FarsiDate(DateTime.Now).ToString() + @"'
//                                                ,'" + txtSubject.Text + @"'
//                                                 ,'" + txtBody.Text + @"',2)");

            db.setQuery(@"insert into ShareMessage([Code]
                            ,[SenderCode]
                            ,[ReceiverCode]
                            ,[sDate]
                            ,[Title]
                            ,[Body]
                            ,[Type])
                            select ROW_NUMBER() over (order by Code)+(select max(code) from ShareMessage),"+ WebClassLibrary.SessionManager.Current.MainFrame.CurrentPersonCode + @"
                            ,pcode,'" + ClassLibrary.JDateTime.FarsiDate(DateTime.Now).ToString() + @"'
                            ,'" + txtSubject.Text + @"','" + txtBody.Text + @"',2
                            from users where guide is not null");
            return db.Query_Execute() >= 0 ? true : false;
        }
        //((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlInstaller).PersonCode

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.RunClientScript("alert('با موفقیت ثبت شد');", "OKDialog");
        }
    }
}