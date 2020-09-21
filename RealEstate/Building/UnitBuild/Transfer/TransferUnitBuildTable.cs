using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace RealEstate
{
    public class JTransferUnitBuildTable : JTable
    {

        #region Property

        /// <summary>
        /// کد دارائی 
        /// </summary>
        public int AssetCode;
        /// <summary>
        /// شماره 
        /// </summary>
        public string RequestNumber;
        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime RequestDate;
        /// <summary>
        /// موضوع
        /// </summary>
        public string ConfirmNumber;
        /// <summary>
        /// خلاصه اظهارات
        /// </summary>
        public DateTime ConfirmDate;
        /// <summary>
        /// خلاصه جواب
        /// </summary>
        public bool Confirm;
        /// <summary>
        /// توضیحات 
        /// </summary>
        public string Description;
        /// <summary>
        /// مبلغ حق انتقال 
        /// </summary>
        public string Price;
        /// <summary>
        /// تایید شده /نشده مدیر
        /// </summary>
        public bool Modir;
        /// <summary>
        ///  مالی تایید شده /نشده
        /// </summary>
        public bool Mali;
        /// <summary>
        ///  املاک تایید شده /نشده
        /// </summary>
        public bool Amlak;
        /// <summary>
        ///  فروشنده تایید شده /نشده
        /// </summary>
        public bool Seller;
        /// <summary>
        /// مبلغ فروش 
        /// </summary>
        public string PriceSell;
        /// <summary>
        /// نوع قرارداد 
        /// </summary>
        public int RequestType;
       #endregion

        public JTransferUnitBuildTable()
            : base(JRETableNames.RestTransferUnitBuild, "")
        {
        }
    }
}
