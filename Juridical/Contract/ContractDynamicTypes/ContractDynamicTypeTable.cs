using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    public class JContractDynamicTypeTable : JTable
    {
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title;
        /// <summary>
        /// نام کلاس
        /// </summary>
        public string ClassName;
        /// <summary>
        /// نوع ثبت اموال: انتقال / اجاره / مشارکت / ... ا
        /// </summary>
        public int AssetTransferType;
        /// <summary>
        /// انتقال دارایی صورت گیرد یا خیر
        /// </summary>
        public bool TransferAsst;
        public string PrtClassName;
        /// <summary>
        /// کد شی برای ویژگی ها
        /// </summary>
        public int PrtObjectCode;
        /// <summary>
        /// مبلغ کل قرارداد
        /// </summary>
        public decimal AllPrice ;
        /// <summary>
        /// درصد نقدی
        /// </summary>
        public int RealPercent ;
        /// <summary>
        /// درصد اقساط
        /// </summary>
        public int InstallmentPercent ;
        /// <summary>
        /// تعداد اقساط
        /// </summary>
        public int InstallmentCount ;
        /// <summary>
        /// مبلغ پایانی
        /// </summary>
        public int EndPricePercent ;
        public JContractDynamicTypeTable()
            : base(Legal.JTableNamesContracts.ContractDynamicType)
        {
        }

    }

    public enum JContractDynamicTypeEnum
    {
        Code,
        Title,
        ClassName,
        AssetTransferType
    }
}
