using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    public class JRegistryOfficeLetterTable : JTable

    {
        public JRegistryOfficeLetterTable()
            : base("legRegistryOfficeLetters")
        {
        }
        #region Properties
        /// <summary>
        /// کد قرارداد
        /// </summary>
        public int ContractCode;
        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime Date;
        /// <summary>
        /// شماره
        /// </summary>
        public string Number;
        /// <summary>
        /// تاریخ نامه محضر
        /// </summary>
        public DateTime RepDate;
        /// <summary>
        /// شماره نامه محضر
        /// </summary>
        public string RepNumber;
         /// <summary>
        /// مبلغ سرقفلی
        /// </summary>
        public decimal Price;
        
        #endregion Properties
    }
}
