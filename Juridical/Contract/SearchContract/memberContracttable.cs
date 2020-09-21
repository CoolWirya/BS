using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Security
{
    class JmemberContracttable: JTable
    {

       
        /// <summary>
        /// كد شخص
        /// </summary>
        public int PersonCode;
        /// <summary>
        /// كد قرارداد
        /// </summary>
        public int CodeContract;
        /// <summary>
        /// تاريخ اتمام
        /// </summary>
        public DateTime Expire_Date;
        /// <summary>
        /// سمت
        /// </summary>
        public int JobPostion;
        /// <summary>
        /// متن نمايشي
        /// </summary>
        public string Hint;
        /// <summary>
        /// وضعيت حراستي
        /// </summary>
        public Boolean Status;
        
         public JmemberContracttable()
            : base(JTabSecurity.MemberContract)
        {

        }
    }
}
