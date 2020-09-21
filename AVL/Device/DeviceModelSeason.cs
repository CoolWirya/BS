using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Device
{
    public class DeviceModelSeason:WebClassLibrary.JSessionClass
    {
        private const string SESSION_VARS = "DeviceModelCompany,DeviceModelModel,DeviceModelYear,DeviceModelCode,title";
        public DeviceModelSeason()
            : base(SESSION_VARS)
        {
        }
        public DeviceModelSeason(string sessionUniqueID)
            : base(SESSION_VARS, sessionUniqueID)
        {
        }

        public string DeviceModelCompany;
        public string DeviceModelModel;
        public string DeviceModelYear;
        public string DeviceModelCode;
        public string title;

    }
}
