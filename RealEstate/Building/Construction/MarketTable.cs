using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace RealEstate
{
    class JMarketTable : JTable
    {

        #region Property

        /// <summary>
        /// شماره مجتمع
        /// </summary>
        //public int MarketNumber;
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title;
        /// <summary>
        /// زیربنا
        /// </summary>
        public decimal Infrastructure;
        /// <summary>
        /// تاریخ شروع ساخت
        /// </summary>
        public DateTime StartBuilding;
        /// <summary>
        /// تاریخ پایان
        /// </summary>
        public DateTime EndBuilding;
        /// <summary>
        /// پروانه ساخت
        /// </summary>
        public string PermitBuilding;
        /// <summary>
        /// پروانه بهره برداری
        /// </summary>
        public string PermitResult;
        /// <summary>
        /// نام مدیریت
        /// </summary>
        public string ManagerName;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description;
        #endregion

        public JMarketTable()
            : base(JTableNamesEstate.Market,"" )
        {
        }

    }

    public enum estMarket
    {

        #region Property
        Code,
        /// <summary>
        /// شماره مجتمع
        /// </summary>
        //MarketNumber,
        /// <summary>
        /// عنوان
        /// </summary>
        Title,
        /// <summary>
        /// زیربنا
        /// </summary>
        Infrastructure,
        /// <summary>
        /// تاریخ شروع ساخت
        /// </summary>
        StartBuilding,
        /// <summary>
        /// تاریخ پایان
        /// </summary>
        EndBuilding,
        /// <summary>
        /// پروانه ساخت
        /// </summary>
        PermitBuilding,
        /// <summary>
        /// پروانه بهره برداری
        /// </summary>
        PermitResult,
        /// <summary>
        /// نام مدیریت
        /// </summary>
        ManagerName,
        /// <summary>
        /// توضیحات
        /// </summary>
        Description,
        #endregion
    }
}
