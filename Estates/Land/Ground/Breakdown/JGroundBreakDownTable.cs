using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Estates
{
    public class JGroundBreakDownTable:JTable
    {
       public JGroundBreakDownTable()
            : base(JTableNamesEstates.GroundBreakDown)
        {
        }
        public string LetterNum;
        /// <summary>
        /// تاریخ درخواست تفکیک
        /// </summary>
        public DateTime LetterDate;
        /// <summary>
        /// اداره مخاطب برای در خولاست تفکیک
        /// </summary>
        public string RegistrationOffice;
        /// <summary>
        /// متن درخواست تفکیک زمین
        /// </summary>
        public string TextReuest;
        /// <summary>
        /// کد زمینی که تفکیک خواهد شد
        /// </summary>
        public int GroundBreakDown;
    }


    enum JGroundBreakDownEnum
    {
        Code,
        LetterNum,
        /// <summary>
        /// تاریخ درخواست تفکیک
        /// </summary>
        LetterDate,
        /// <summary>
        /// اداره مخاطب برای در خولاست تفکیک
        /// </summary>
        RegistrationOffice,
        /// <summary>
        /// متن درخواست تفکیک زمین
        /// </summary>
        TextReuest,
        /// <summary>
        /// کد زمینی که تفکیک خواهد شد
        /// </summary>
        GroundBreakDown,
    }

}
