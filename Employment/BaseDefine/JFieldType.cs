using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{
    public class JFieldType : JSubBaseDefine
    {
        public JFieldType()
            : base(JTableNameEmployment.FieldType)
        {
        }
    }

    public class JFieldTypes : JSubBaseDefines
    {
        public JFieldTypes()
            : base(JTableNameEmployment.FieldType)
        {
        }
    }
}
