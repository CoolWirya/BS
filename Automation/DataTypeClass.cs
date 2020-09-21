using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation
{
    /// <summary>
    /// رده بندی - طبقه بندی
    /// </summary>
    enum JTaxonomyLetter
    {
        /// <summary>
        /// عادی
        /// </summary>
        Tlnormal,
        /// <summary>
        /// محرمانه
        /// </summary>
        Tlsecret,
    }
    /// <summary>
    /// فوریت نامه
    /// </summary>
    enum JUrgencyLetter
    {
        /// <summary>
        /// عادی
        /// </summary>
        Unormal,
        /// <summary>
        /// فوری
        /// </summary>
        Uimmediate,
        /// <summary>
        /// خیلی فوری
        /// </summary>
        Usudden,
    }

    /// <summary>
    /// نوع نامه
    /// </summary>
    enum JTypeLetter
    {
        /// <summary>
        /// وارده
        /// </summary>
        TlIncoming,
        /// <summary>
        /// صادره
        /// </summary>
        TlIssued,
    }
}
