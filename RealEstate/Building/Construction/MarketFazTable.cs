using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace RealEstate
{
    class JMarketFazTable: JTable
    {
        #region Property

        /// <summary>
        ///  کد مجتمع
        /// </summary>
        public int MarketCode;
        /// <summary>
        ///  نام مجتمع
        /// </summary>
        public string Title;
        /// <summary>
        ///  زیربنا
        /// </summary>
        public decimal Area;

        #endregion

        public JMarketFazTable()
            : base(JTableNamesEstate.MarketFaz,"" )
        {
        }
    }
    public enum estMarketFaz
    {
        #region Property

        Code,
        MarketCode,
        Title,
        Area,        

        #endregion
    }
}
