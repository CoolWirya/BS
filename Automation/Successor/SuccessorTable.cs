using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Automation
{
    class JSuccessorTable: JTable
    {

        public JSuccessorTable()
            : base("AutoSuccessor")
        {
        }

        #region Properties

        /// <summary>
        /// کد پست 
        /// </summary>      
        public int Person_post_code;
        /// <summary>
        /// کد پست جانشین
        /// </summary>      
        public int Successer_post_code;
        /// <summary>
        /// تاریخ شروع
        /// </summary>
        public DateTime Start_date_time;
        /// <summary>
        /// تاریخ پایان
        /// </summary>
        public DateTime End_date_time;

        #endregion
    }
}
