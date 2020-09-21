using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legal.Person
{
    /// <summary>
    /// اشخاص املاک
    /// </summary>
    class JLPerson: ClassLibrary.JPerson
    {
        /// <summary>
        /// فوت فرد
        /// </summary>
        /// <returns></returns>
        public bool Death()
        {
            return false;
        }

        /// <summary>
        /// تعیین ورثه
        /// </summary>
        public void Heirs()
        {
        }

        /// <summary>
        /// توقیف اموال
        /// </summary>
        public void Distraint()
        {
        }

        /// <summary>
        /// توقیف اموال
        /// </summary>
        /// <param name="pFinanceCode">کد اموال شخص</param>
        public void Distraint(int pFinanceCode)
        {
        }

        /// <summary>
        ///رد توقیف اموال
        /// </summary>
        /// <param name="pDistraintCode">کد توقیف</param>
        public void RejectDistraint(int pDistraintCode)
        {
        }

        /// <summary>
        /// ممنوع المعامله
        /// </summary>
        public void ProhibitedTransaction()
        {
        }

        /// <summary>
        ///رد ممنوع المعامله
        /// </summary>
        public void RejectProhibitedTransaction()
        {
        }

    }
}
