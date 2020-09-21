using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{
    public class JEPersonPostTable :JTable
    {

        public int PCode;
        /// <summary>
        /// کد پست
        /// </summary>
        public int PostCode;
        /// <summary>
        /// وضعیت پست
        /// </summary>
        public bool Active;
        /// <summary>
        /// تاریخ شروع
        /// </summary>
        public DateTime DateStart;
        /// <summary>
        /// تاریخ پایان
        /// </summary>
        public DateTime DateEnd;
        /// <summary>
        /// شماره قرارداد
        /// </summary>
        public string ContractCode;
        
        public JEPersonPostTable()
            : base("emppersonpost")
        { 
        }
    }
   public enum JEPersonPostEnum
    {
        Code,
        PCode,
        /// <summary>
        /// کد پست
        /// </summary>
        PostCode,
        /// <summary>
        /// وضعیت پست
        /// </summary>
        Active,
        /// <summary>
        /// تاریخ شروع
        /// </summary>
        DateStart,
        /// <summary>
        /// تاریخ پایان
        /// </summary>
        DateEnd,
        /// <summary>
        /// شماره قرارداد
        /// </summary>
        ContractCode,
       /// <summary>
       /// عنوان پست
       /// </summary>
        PostName,
    }
}
