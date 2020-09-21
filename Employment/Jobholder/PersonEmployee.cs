using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.Person
{
    public class JPersonEmployee : JPerson
    {
         public JPersonEmployee()
        {
        }
        /// <summary>
        /// کد
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// شماره پرسنلی
        /// </summary>
        public string PersonelCode { get; set; }
        /// <summary>
        /// تاریخ استخدام
        /// </summary>
        public string DateEmployee { get; set; }

        public int Insert()
        {
            return 0;
        }
        
    }
}
