using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Parking
{
    public class JCardParkingTable : JTable
    {
        public JCardParkingTable()
            : base(JTableNamesParking.CardParking)
        {

        }


       
        /// </summary>
        public int IDCardParking;


        /// <summary>
        /// فعال غير فعال
        /// </summary>
        public bool StatusParking;
        /// <summary>
        /// علت غير فعال بودن
        /// </summary>
        public int InactiveDue;
        /// <summary>
        /// مبلغ شارژ الكترونيك
        /// </summary>
        public DateTime DateExpire;
        /// <summary>
        /// تاريخ صدور
        /// </summary>
        public DateTime DateActive;
        /// <summary>
        ///گروه كارت
        /// </summary>
        public int CodeGroup;
       

    }
}
