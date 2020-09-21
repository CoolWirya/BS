using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    public class JDefineFieldTable : JTable
    {

        #region Properties        
        /// <summary>
        /// نام فیلد
        /// </summary>
        public string Name;
        /// <summary>
        /// نام کلاس
        /// </summary>
        public string ClassName;
        /// <summary>
        /// متن 
        /// </summary>
        public string Text;
        /// <summary>
        /// جداکننده 
        /// </summary>
        public string Separate;

        #endregion

        public JDefineFieldTable()
            : base(JTableNamesContracts.DefineField, "")
        {
        }
    }
}
