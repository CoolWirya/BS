using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Communication
{
    class JSecretariatLettersTable : JTable
    {
        #region Properties
        
        /// <summary>
        /// کد نامه
        /// </summary>
        public int Letter_Code;
        /// <summary>
        /// کد دبیرخانه
        /// </summary>
        public int secretariat_code;
        /// <summary>
        /// شماره ثبت 
        /// </summary>
        public int register_no;
        /// <summary>
        /// شماره نامه 
        /// </summary>
        public string letter_no;
        /// <summary>
        /// تاریخ ثبت 
        /// </summary>
        public DateTime register_date_time;
        /// <summary>
        /// پست ثبت کننده 
        /// </summary>
        public int register_post_code;

        #endregion
        public JSecretariatLettersTable() :
            base(JTableNamesLetters.secretariatLetters, "")
        {
        }
    }
}
