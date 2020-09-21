using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Parking
{
    public class JCarTable : JTable
    {
        public JCarTable()
            : base(JTableNamesParking.Car)
        {

        }

        /// <summary>
        /// کد کارت پارکینگ
        /// </summary>
        public int IDCardParking = 0;
        /// <summary>
        /// نوع خودرو
        /// </summary>
        public int TypeCar = 0;
        /// <summary>
        /// شماره پلاک خودرو
        /// </summary>
        public string Plaque = "";
        /// <summary>
        /// رنگ خودرو
        /// </summary>
        public int CarColor = 0;
        /// <summary>
        /// وضعیت کارت
        /// </summary>
        public bool StatusCard = false;
        /// <summary>
        /// صاحب خودرو
        /// </summary>
        public string CarOwner = "";
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description = "";
        /// <summary>
        /// پيش فرض
        /// </summary>
        public bool Defult = false;
        /// <summary>
        /// شماره كارت
        /// </summary>
        public int CardNumber = 0;
    }
}
