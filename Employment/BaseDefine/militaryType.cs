using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{
    public class JmilitaryType : JSubBaseDefine
    {
        public JmilitaryType()
            : base(JTableNameEmployment.MilitaryType)
        {
        }
    }

    public class JmilitaryTypes : JSubBaseDefines
    {
        public JmilitaryTypes()
            : base(JTableNameEmployment.MilitaryType)
        {
        }
    }
}
