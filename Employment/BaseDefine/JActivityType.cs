using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{
    public class JActivityType : JSubBaseDefine
    {
        public JActivityType()
            : base(JTableNameEmployment.ActivityType)
        {
        }
    }

    public class JActivityTypes : JSubBaseDefines
    {
        public JActivityTypes()
            : base(JTableNameEmployment.ActivityType)
        {
        }
    }
}
