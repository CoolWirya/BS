using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Bascol
{
    class JTruckTable : JTable
    {
        public JTruckTable()
            : base("BascolTruck")
        {
        }

        #region Property
        /// <summary>
        /// تاریخ شروع
        /// </summary>
        public DateTime StartDate;
        /// <summary>
        /// تاریخ پایان
        /// </summary>
        public DateTime EndDate;
        /// <summary>
        /// نام
        /// </summary>
        public string Name;
        /// <summary>
        /// قیمت
        /// </summary>
        public int Price;
        /// <summary>
        /// 
        /// </summary>
        public string Shortcut;
        #endregion
    }
}
