using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Parking
{
  public   class JCardMarketTable:JTable
       
    {
        
        /// <summary>
        /// شماره كارت
        /// </summary>
        public int ID_Card;
        /// <summary>
        /// مجتمع/بازار
        /// </summary>
        public int MarketCode;
        /// <summary>
        /// تاریخ انقضاء کارت
        /// </summary>
        public DateTime ExpireDate;
        /// <summary>
        /// وضعیت کارت
        /// </summary>
        public int StatusCard;
        /// <summary>
        /// فعال ،غير فعال
        /// </summary>
        public bool Publish;
        /// <summary>
        /// گروه کارت
       
        public int GroupCard;
        /// </summary>
        ///  /// <summary>
        /// شماره كارت
        /// </summary>
        public int CardNumber;
        public JCardMarketTable()
            : base(JTableNamesParking.ParkingMarket)
        {
        }
    }
}
