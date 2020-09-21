using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Paid
{
    //مروبوط به جدول پرداختی ها
    public class JAVLPaids : ClassLibrary.JSystem
    {

        public static bool HasPaidNotPay()
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            DB.setQuery("select * from AVLPaid where state=0 and usercode=" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode);
            System.Data.DataTable dt = DB.Query_DataTable();
            if (dt != null && dt.Rows.Count >= 1)
                return true;
            return false;

        }
    }

}
