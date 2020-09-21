using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace RealEstate
{
    /// <summary>
    /// شغل اعیان
    /// </summary>
    public class JUnitJob : JSubBaseDefine
    {
        public JUnitJob()
            : base(JBaseDefine.UnitJobs)
        {
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class JUnitJobs : JSubBaseDefines
    {
        public JUnitJobs()
            : base(JBaseDefine.UnitJobs)
        {

        }

    }
}
