using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{
    public class JCalcType : JSubBaseDefine
    {
        public JCalcType()
            : base(JTableNameEmployment.CalcType)
        {
        }
    }

    public class JCalcTypes : JSubBaseDefines
    {
        public JCalcTypes()
            : base(JTableNameEmployment.CalcType)
        {
        }
    }
}
