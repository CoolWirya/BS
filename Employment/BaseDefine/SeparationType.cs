using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{   
    public class JSeparationType : JSubBaseDefine
    {
        public JSeparationType()
            : base(JTableNameEmployment.SeparationType)
        {
        }
    }

    public class JSeparationTypes : JSubBaseDefines
    {
        public JSeparationTypes()
            : base(JTableNameEmployment.SeparationType)
        {
        }
    }
}
