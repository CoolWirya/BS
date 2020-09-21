using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    class JPersonAssertionTable : JTable
    {
        #region Property
        /// <summary>
        /// کد اظهارنامه
        /// </summary>
        public int AssertionCode;
        /// <summary>
        /// نام شخص
        /// </summary>
        public string Name;
        /// <summary>
        /// کد شخص
        /// </summary>
        public int PersonCode;
        /// <summary>
        /// نوع شخص
        /// </summary>
        public int PersonType;

        #endregion

        public JPersonAssertionTable()
            : base(JTableNamesPetition.AssertionPerson, "")
        {
        }
    }
}
