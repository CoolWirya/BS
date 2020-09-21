using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace RealEstate
{
    class jMarketFloorsTable : JTable
    {
        #region Property

        /// <summary>
        ///  کد مجتمع
        /// </summary>
        public int MarketCode;
        /// <summary>
        ///  نام مجتمع
        /// </summary>
        public string Name;
        /// <summary>
        ///  شماره طبقه
        /// </summary>
        public int Number;
        /// <summary>
        ///  زیربنا
        /// </summary>
        public decimal Infrastructure;
        /// <summary>
        ///  توضیحات
        /// </summary>
        public string Description;

        #endregion

        public jMarketFloorsTable()
            : base(JTableNamesEstate.MarketFloors,"" )
        {
        }
    }
    public enum estMarketFloors
    {
        #region Property

        Code,
        MarketCode,
        Name,
        Number,
        Infrastructure,
        Description,

        #endregion
    }
}
