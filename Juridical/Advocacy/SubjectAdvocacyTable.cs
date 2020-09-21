using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    class JSubjectAdvocacyTable : JTable
    {

        #region Property

        /// <summary>
        /// کد وکالت
        /// </summary>
        public int Advocacy_Code;
        /// <summary>
        /// کد موضوع
        /// </summary>
        public int SubjectCode;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description;

        #endregion

        public JSubjectAdvocacyTable()
            : base(JTableNamesLegal.SubjectTable, "")
        {
        }
    }
}
