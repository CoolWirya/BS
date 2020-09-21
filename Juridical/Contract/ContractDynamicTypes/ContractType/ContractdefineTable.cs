using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    public class JContractdefineTable : JTable
    {
        #region Properties

        /// <summary>
        /// نوع قرارداد
        /// </summary>
        public int ContractType;
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title;
        /// <summary>
        /// کد متن فایل 
        /// </summary>
        public int FileCode;

        #endregion

        public JContractdefineTable()
            : base("LegContractType" , "")
        {
        }
    }

    public enum JContractdefineEnum
    {
        Code,
        ContractType,
        Title,
        FileCode,
    }
}
