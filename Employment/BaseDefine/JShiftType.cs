using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{
    public class JShiftType : JSubBaseDefine
    {
        public JShiftType()
            : base(JTableNameEmployment.ShiftType)
        {
        }
    }

    public class JShiftTypes : JSubBaseDefines
    {
        public JShiftTypes()
            : base(JTableNameEmployment.ShiftType)
        {
        }
    }
}
