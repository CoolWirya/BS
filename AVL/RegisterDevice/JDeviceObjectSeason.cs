using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.RegisterDevice
{
    public class JDeviceObjectSeason:WebClassLibrary.JSessionClass
    {
        private const string SESSION_VARS = "ObjectListCode,ObjectListLabel,title";
        public JDeviceObjectSeason()
            : base(SESSION_VARS)
        {
        }
        public JDeviceObjectSeason(string sessionUniqueID)
            : base(SESSION_VARS, sessionUniqueID)
        {
        }

        public string ObjectListCode;
        public string ObjectListLabel;
        public string title;
    }
}
