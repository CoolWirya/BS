using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreComplex
{
    public class JRenewPrivateTable :JTable
    {
          public JRenewPrivateTable()
            : base("SCRenewPrivate")
        {
        }

          #region Properties
          /// <summary>
          /// کد اجاره انبار در رسید 
          /// </summary>
          public int PrivateCode ;
          /// <summary>
          /// تاریخ
          /// </summary>
          public DateTime Date ;
          /// <summary>
          /// مبلغ
          /// </summary>
          public decimal Cost ;
          /// <summary>
          /// تعداد باکس قابل تمدید
          /// </summary>
          public decimal BoxCount ;
          /// <summary>
          /// توضیحات
          /// </summary>
          public string Description ;
          #endregion
    }
}
