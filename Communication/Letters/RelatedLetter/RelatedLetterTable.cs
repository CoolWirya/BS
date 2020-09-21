using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Communication
{
    class JRelatedLetterTable :JTable
    {
        #region Peroperties
        /// <summary>
        /// کد نامه
        /// </summary>
        public int letter_code;
        /// <summary>
        /// کد نامه وابسته
        /// </summary>
        public int dependent_LetterCode;
        /// <summary>
        /// نوع  عطف/پیرو
        /// </summary>
        public int type;
        
        #endregion Peroperties

        public JRelatedLetterTable()
            : base("letterdependent", "")
        {
        }   
    }
}

