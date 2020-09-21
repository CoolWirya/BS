using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    class JProbateTable:JTable
    {
        public JProbateTable()
            : base(JTableNamesLegal.Probate)
        {
        }
       
        /// <summary>
        /// کدشعبه قضایی صادر کننده حکم
        /// </summary>
        public int JudicialBranchCode;
        /// <summary>
        /// کد درخواست کننده گواهی
        /// </summary>
        public int ApplicatorCode;
        /// <summary>
        /// تاریخ صدور
        /// </summary>
        public DateTime Dateissued;
        /// <summary>
        /// کدشخص متوفی
        /// </summary>
        public int DeadCode;
        /// <summary>
        /// لیست ورثه
        /// </summary>
        
    }
    public enum JProbateTableEnum
    {
        Code,
        JudicialBranch,
        Applicator,
        Dateissued,
        DeadCode,
        DeadName
    }
}
