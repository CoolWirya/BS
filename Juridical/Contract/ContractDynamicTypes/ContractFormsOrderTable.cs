using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    public class JContractFormsOrderTable:JTable
    {
        public JContractFormsOrderTable()
            : base(JTableNamesContracts.ContractFormsOrder)
        {
        }

        /// <summary>
        /// کد نوع قرارداد از جدول ContractDynamicTypes
        /// </summary>
        public int ContractTypeCode;
        /// <summary>
        /// نام فرم
        /// </summary>
        public string FormName;
        /// <summary>
        /// ترتیب نمایش
        /// </summary>
        public int ShowOrder;
        /// <summary>
        /// نمایش فرم
        /// </summary>
        public bool Show;
    }

    public enum JContractFormsOrderEnum
    {
        Code,
        ContractTypeCode,
        FormName,
        ShowOrder,
        Show 
    }
}
