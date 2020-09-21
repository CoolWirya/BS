using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    public class JPersonContractTable : JTable
    {
        
        #region Property

        
        /// <summary>
        /// کد قرارداد
        /// </summary>
        public int ContractSubjectCode;
        /// <summary>
        /// کد شخص
        /// </summary>
        public int PersonCode;
        /// <summary>
        /// نوع شخص
        /// </summary>
        public int Type;
        /// <summary>
        /// سهم
        /// </summary>
        public float Share;
        /// <summary>
        /// کد سهم قدیم
        /// </summary>
        public int OldAssetShare;
        /// <summary>
        /// کد سهم جدید
        /// </summary>
        public int NewAssetShare;

        #endregion

        public JPersonContractTable()
            : base(JTableNamesLegal.PersonContract, "")
        {
        }
    }
}
