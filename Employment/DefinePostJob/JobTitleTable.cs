using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{
    public class JobTitleTable : JTable
    {
        public JobTitleTable()
            : base("EmpJobTitle")
        {
        }

        #region Property
        /// <summary>
        /// کد شغل 
        /// </summary>
        public int JobCode;
        /// <summary>
        /// عنوان شغلی کد
        /// </summary>
        public int TitleCode;
        /// <summary>
        /// سطح 
        /// </summary>
        public int Level;
        /// <summary>
        /// گروه 
        /// </summary>
        public int Group;
        /// <summary>
        /// نوع مدرک
        /// </summary>
        public int DegreeCode;
        /// <summary>
        /// تجربه
        /// </summary>
        public int Expreince;
        /// <summary>
        /// 
        /// </summary>
        public int CompanyCode;
        #endregion
    }
}
