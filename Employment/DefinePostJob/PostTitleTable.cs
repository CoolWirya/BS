using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{
    public class JPostTitleTable : JTable
    {
        public JPostTitleTable()
            : base("EmpPostTitle")
        {
        }

        #region Property
        /// <summary>
        /// کد پست 
        /// </summary>
        public int PostNumber;
        /// <summary>
        /// عنوان شغلی کد
        /// </summary>
        public string Title;
        /// <summary>
        ///  
        /// </summary>
        public int ParentCode;
        /// <summary>
        /// 
        /// </summary>
        public int CompanyCode;
        #endregion
    }
}
