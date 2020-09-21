using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Entertainment
{
    public class JBulletinType : JSubBaseDefine
    {
        public JBulletinType()
            : base(JBaseDefine.BulletinType)
        {
        }
    }

    public class JBulletinTypes : JSubBaseDefines
    {
        public JBulletinTypes()
            : base(JBaseDefine.BulletinType)
        {
        }
    }

}
