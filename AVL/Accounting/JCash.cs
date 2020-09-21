using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Accounting
{
    //مربوط به جدول صندوق
    public class JCash:ClassLibrary.JSystem
    {
        public int code{get;set;}
      public int userCode{get;set;}
      public decimal  paid { get; set; }

      public JCash()
      {

      }
      //اگر کد برابر صفر باشد تنها مقادیر مربوط به دیتای کاربر فعلی را می گیرد.
      public JCash(int code, int userCode)
      {
          GetData( code,  userCode);
      }

      public int Insert(bool isWeb = false)
      {
          if (!ClassLibrary.JPermission.CheckPermission("AVL.Accounting.JCash.Insert"))
              return 0;
          JCashTable AT = new JCashTable();
          AT.SetValueProperty(this);
          code = AT.Insert();


          ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
          jHistory.Save("AVL.Accounting.JCash", code, 0, 0, 0, "ثبت در صندوق", "", 0);
          
          return code;
      }

      public bool Update(bool isWeb = false)
      {
          if (!ClassLibrary.JPermission.CheckPermission("AVL.Accounting.JCash.Update"))
              return false;
          JCashTable AT = new JCashTable();
          AT.SetValueProperty(this);
          if (AT.Update())
          {
              ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
              jHistory.Save("AVL.Accounting.JCash.Update", AT.Code, 0, 0, 0, "ویرایش صندوق", "", 0);
              return true;
          }
          else
              return false;
      }

        //اگر کد برابر صفر باشد تنها مقادیر مربوط به دیتای کاربر فعلی را می گیرد.
      public bool GetData(int code=0, int userCode=-1)
      {
          ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
          try
          {
              if (code == 0)
              {
                  DB.setQuery("select top 1 * from AVLCash where  userCode=" + userCode);
              }
              else
              {
                  DB.setQuery("select top 1 * from AVLCash where code=" + code + " AND userCode=" + userCode);
              }
              DB.Query_DataReader();
              if (DB.DataReader.Read())
              {
                  ClassLibrary.JTable.SetToClassProperty(this, DB.DataReader);
                  return true;
              }
              return false;
          }
          finally
          {
              DB.Dispose();
          }
      }
    }
}
