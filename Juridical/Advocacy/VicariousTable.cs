using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    class JVicariousTable : JTable
    {
        #region Property

        /// <summary>
        /// کد شخص
        /// </summary>
        public int Person_Code;
        /// <summary>
        /// کد وکالت
        /// </summary>
        public int Advocacy_Code;

        #endregion

        public JVicariousTable()
            : base(JTableNamesLegal.LegVicariousTable)
        {
        }
    }
}
