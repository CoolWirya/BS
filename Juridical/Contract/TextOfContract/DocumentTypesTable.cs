using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    class JDocumentTypesTable : JTable
    {
        #region Properties

        /// <summary>
        /// عنوان سند
        /// </summary>
        public string Title;

        #endregion

        public JDocumentTypesTable()
        : base("LegDocumentType", "")
        {
        }

    }
}
