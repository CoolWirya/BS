using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Meeting
{
    public class JLegislationGroup : JSubBaseDefine
    {
        public JLegislationGroup()
            : base(JBaseDefine.LegislationGroupType)
        {
        }
    }

    public class JLegislationGroups : JSubBaseDefines
    {
        public JLegislationGroups()
            : base(JBaseDefine.LegislationGroupType)
        {
        }
    }
}
