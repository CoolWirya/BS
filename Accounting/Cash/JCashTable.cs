using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Cash
{
    //مربوط به جدول صندوق
   public  class JCashTable: ClassLibrary.JTable
   {
       public int userCode;
       public decimal paid;
       public JCashTable()
           : base("AVLCash")
       {

       }
    }
}
