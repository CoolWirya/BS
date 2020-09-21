using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.ObjectList.Object.Bus
{
    public class JBus : ClassLibrary.JSystem
    {
        public int Code { get; set; }
        public int ObjectCode { get; set; }
        /// <summary>
        /// کد مالک که در 
        /// AVLOwner
        /// ذخیره شده است.
        /// </summary>
        public int DriverCode { get; set; }
        /// <summary>
        /// شماره پلاک
        /// </summary>
        public string BusNumber { get; set; }
        /// <summary>
        /// شماره خطی که اتوبوس در آن کار می کند.
        /// </summary>
        public int LineCode { get; set; }

		

    }
}
