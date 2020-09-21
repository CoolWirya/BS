using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{
    /// <summary>
    /// عناوین شغلی
    /// </summary>
    public class JMetiertopic: JESubBaseDefine
    {
        public JMetiertopic()
            : base(JEBaseDefine.MetierCode)
        {
        }
    }

    public class JMetiertopics : JESubBaseDefines
    {
        public JMetiertopics()
            : base(JEBaseDefine.MetierCode)
        {
        }       
    }
}
