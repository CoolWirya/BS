using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
namespace Employment
{
    public class JWorkTimeType : JSubBaseDefine
    {
        public JWorkTimeType()
            : base(JTableNameEmployment.WorkTimeType)
        {
        }
    }

    public class JWorkTimeTypes : JSubBaseDefines
    {
        public JWorkTimeTypes()
            : base(JTableNameEmployment.WorkTimeType)
        {
        }
    }
}
