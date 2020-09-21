using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation
{
    public enum JAPrivacyMode
    {
        /// <summary>
        /// عادی
        /// </summary>
        Normal = 1,
        /// <summary>
        ///  محرمانه
        /// </summary>
        Secure = 2,
        /// <summary>
        /// خیلی محرمانه
        /// </summary>
        VerySecure = 3,
        /// <summary>
        /// سری
        /// </summary>
        Blocked = 4,
        /// <summary>
        /// بکلی سری
        /// </summary>
        CompletlyBlocked = 5
    }
    
    public class JAPrivacyTypes
    {
        
    }
}
