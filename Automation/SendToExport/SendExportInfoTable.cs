using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Automation
{
    class JSendExportInfoTable : JTable
    {
        #region Properties
        
        /// <summary>
        ///کد نامه
        /// </summary>
        public int LetterCode;
        /// <summary>
        ///نوع ارسال
        /// </summary>
        public int Type;
        /// <summary>
        ///شرح ارسال
        /// </summary>
        public string Description;
        #endregion

        public JSendExportInfoTable()
            : base("AutoSendToExport", "")
        {
        }
        
    }
}
