using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Parking
{
    public class JBaseShiftTable : JTable
    {
        /// <summary>
        /// نام شيفت
        /// </summary>
        public string Name;
        /// <summary>
        /// ساعت شروع
        /// </summary>
        public string StatrtTime;
        /// <summary>
        /// ساعت پايان
        /// </summary>
        public string EndTime;
        /// <summary>
        /// كد مجتمع
        /// </summary>
        public int Market;
        /// <summary>
        /// شيفت مي تواند حساب را ببندد
        /// </summary>
        public Boolean Isclose = false;

        public JBaseShiftTable()
            : base(JTableNamesParking.DefShift)
        {

        }

    }
}
