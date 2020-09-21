using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Parking
{
    class JPElectronicTable:JTable
    {
        
        /// <summary>
        /// شماره کارت پارکینگ
        /// </summary>
        public int CardId;
        /// <summary>
        /// مبلغ شارژ
        /// </summary>
        public decimal Amount;
        /// <summary>
        /// وضعيت انتقال
        ///  </summary>
        public Boolean Statustransfer;
        /// <summary>
        /// تاريخ  اتمام اعتبار
        /// </summary>
        public DateTime DateExpire;
        /// <summary>
        /// تاريخ ايجاد
        ///  </summary>
        public DateTime DateCreate;
        public JPElectronicTable()
            : base(JTableNamesParking.PrkElectronic)
        {

        }
    }
}
