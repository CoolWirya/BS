using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBaseDefine.Forms
{
    public partial class JPersonTafsiliCodeUpdateControl : System.Web.UI.UserControl
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
                ClassLibrary.JDataBase TafDb = new ClassLibrary.JDataBase();
                TafDb.setQuery(@"select * from finComparativeCode where Code = " + Code);
                System.Data.DataTable dt = TafDb.Query_DataTable();
                ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlOwner).PersonCode = Convert.ToInt32(dt.Rows[0]["ObjectCode"].ToString());
                txtTafsiliCode.Text = dt.Rows[0]["Value"].ToString();
            }
        }

        public bool Save()
        {
            ClassLibrary.JDataBase TafDb = new ClassLibrary.JDataBase();
            if (Code > 0)
            {
                TafDb.setQuery(@"update finComparativeCode set ObjectCode = " + ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlOwner).PersonCode + @"
                   ,Value = '" + txtTafsiliCode.Text + @"' where Code = " + Code);
                return TafDb.Query_Execute() >= 0 ? true : false;
            }
            else
            {
                //TafDb.setQuery(@"select ISNULL(count(*),0)C from [dbo].[finComparativeCode] where [Value] = '" + txtTafsiliCode.Text + @"' ");
                //if (TafDb.Query_DataTable().Rows[0]["C"].ToString() == "0")
                //{
                    TafDb.setQuery(@"INSERT INTO [dbo].[finComparativeCode]
                                   ([Code]
                                   ,[ClassName]
                                   ,[ObjectCode]
                                   ,[CreatorPostCode]
                                   ,[CreatorUserCode]
                                   ,[Comment]
                                   ,[Status]
                                   ,[DivideType]
                                   ,[Value]
                                   ,[State])
                             VALUES
                                   ((select ISNULL(max(code),0)+1 from finComparativeCode)
                                   ,'ClassLibrary.Person.AllPerson'
                                   ," + ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlOwner).PersonCode + @"
                                   ," + WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostCode + @"
                                   ," + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode + @"
                                   ,N'کد تفصیلی برای " + ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlOwner).PersonCode + @"'
                                   ,1
                                   ,0
                                   ,'" + txtTafsiliCode.Text + @"'
                                   ,1)");
                    return TafDb.Query_Execute() >= 0 ? true : false;
                //}
                //else
                //{
                //    return false;
                //}
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                    WebClassLibrary.JWebManager.RunClientScript("alert('ثبت با موفقیت انجام شد');", "ConfirmDialog");
        }

        public bool Delete()
        {
            if (Code > 0)
            {
                ClassLibrary.JDataBase TafDb = new ClassLibrary.JDataBase();
                TafDb.setQuery(@"delete finComparativeCode where Code = " + Code);
                return TafDb.Query_Execute() >= 0 ? true : false;
            }
            else
                return false;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Delete())
                WebClassLibrary.JWebManager.RunClientScript("alert('حذف با موفقیت انجام شد');", "ConfirmDialog");
        }


    }
}