using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    public class JDeadPersonTable:JTable
    {
        public JDeadPersonTable()
            : base(JTableNamesClassLibrary.DeadPerson)
        {
        }

        /// <summary>
        /// شماره گواهی فوت
        /// </summary>
        public string DieNumber ;
        /// <summary>
        /// تاریخ فوت
        /// </summary>
        public DateTime DieDate ;
        /// <summary>
        /// تاریخ گواهی فوت
        /// </summary>
        public DateTime DeathCertificateDate ;
    }

    public enum JDeadPersonEnum
    {
       Code 
      , DieDate 
      , DieNumber 
      , DeathCertificateDate 
      , Comment 
    }
}
