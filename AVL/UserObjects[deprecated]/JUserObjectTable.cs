using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.UserObjects
{
    public class JUserObjectTable : ClassLibrary.JTable
    {

       public int code;
       public int personCode;
       public int objectListCode;
       public DateTime registerDatetime;
       public bool isActive;

       public JUserObjectTable()
           : base("AVLUserObjects")
       {

       }
    }
}
