using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;


namespace Legal
{
    class JAssertionTable : JTable
    {

       #region Property

        /// <summary>
        /// شماره 
        /// </summary>
        public string Number;
        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime Date;
        /// <summary>
        /// موضوع
        /// </summary>
        public string Subject;
        /// <summary>
        /// خلاصه اظهارات
        /// </summary>
        public string AssertionDescription;
        /// <summary>
        /// خلاصه جواب
        /// </summary>
        public string AnswerDescription;

       #endregion

        public JAssertionTable()
            : base(JTableNamesPetition.Assertion, "")
    {
    }

    }
}
