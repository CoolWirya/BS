using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estates
{
    public class JSheetLogTable: ClassLibrary.JTable
    {
        public JSheetLogTable()
            : base("estSheetLog")
        {
            
        }
         public int SheetCode;
         public DateTime CreateDate;
         public int Creator;
         public int Action;
         public string Desc;
    }    
}
