using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Estates
{
    class JMarketTable : JTable
    {

        #region Property

        /// <summary>
        /// شماره مجتمع
        /// </summary>
        public int MarketNumber;
        /// <summary>
        /// عنوان
        /// </summary>
        public string Title;
        /// <summary>
        /// زیربنا
        /// </summary>
        public string Infrastructure;
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

        #endregion

        public JMarketTable()
            : base(JTableNamesEstate.Market,"" )
        {
        }

    }
}
