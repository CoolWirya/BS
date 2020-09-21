using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Estates
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
        public string Number;
        /// <summary>
        ///  زیربنا
        /// </summary>
        public string Infrastructure;
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
}
