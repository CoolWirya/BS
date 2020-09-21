using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Finance
{
    public class JAssetGroupTable : JTable
    {
        public JAssetGroupTable()
            : base(JTableNamesFinance.AssetGroup)
        {
        }
        #region Property
        /// <summary>
        /// نام گروه
        /// </summary>
        public string Name;
        /// <summary>
        /// نام کلاس
        /// </summary>
        public string ClassName;
        /// <summary>
        /// کد 
        /// </summary>
        public int ObjectCode;
        #endregion
    }
}
