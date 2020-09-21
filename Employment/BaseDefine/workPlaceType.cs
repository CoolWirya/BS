using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{
     public class JWorkPlaceType : JSubBaseDefine
    {
            public JWorkPlaceType()
            : base(JTableNameEmployment.workPlaceType)
        {
        }
    }

     public class JWorkPlaceTypes : JSubBaseDefines
     {
         public JWorkPlaceTypes()
             : base(JTableNameEmployment.workPlaceType)
         {

         }
     }
}
