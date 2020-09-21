using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Estates
{
    class JGroundsBreakDownTable:JTable
    {
        public JGroundsBreakDownTable()
            : base(JTableNamesEstates.GroundsBreakDown)
        {
        }    
       public int BreakDownCode;
        /// <summary>
        /// کد زمین های حاصل از تفکیک
        /// </summary>
       public int GroundsBreakDown;
    }
    enum JGroundsBreakDownEnum
    {
        Code,
        /// <summary>
        /// کد زمینی که تفکیک  شده است
        /// </summary>
        BreakDownCode,
        /// <summary>
        /// کد زمین های حاصل از تفکیک
        /// </summary>
        GroundُsBreakDown,
    }
}
