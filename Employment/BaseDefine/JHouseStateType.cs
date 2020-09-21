using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{
    public class JHouseStateType : JSubBaseDefine
    {
        public JHouseStateType()
            : base(JTableNameEmployment.HouseStateType)
        {
        }
    }

    public class JHouseStateTypes : JSubBaseDefines
    {
        public JHouseStateTypes()
            : base(JTableNameEmployment.HouseStateType)
        {
        }
    }
}
