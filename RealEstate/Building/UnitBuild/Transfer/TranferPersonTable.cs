using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace RealEstate
{
    public class JTranferPersonTable : JTable
    {
        #region Property

        /// <summary>
        /// کد انتقال
        /// </summary>
        public int TransferCode;
        /// <summary>
        /// کد شخص
        /// </summary>
        public int PersonCode;
        /// <summary>
        /// نوع شخص
        /// </summary>
        public int PersonType;
        /// <summary>
        /// سهم قدیم
        /// </summary>
        public decimal OldShare;
        /// <summary>
        /// سهم جدید
        /// </summary>
        public decimal NewShare;

        #endregion

        public JTranferPersonTable()
            : base(JRETableNames.RestTransferPersons, "")
        {
        }
    }
}
