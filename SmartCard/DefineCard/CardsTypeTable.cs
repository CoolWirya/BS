using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCard
{
    public class JCardsTypeTable : JTable
    {
        public JCardsTypeTable()
            : base("CardsType")
        {
        }

        /// <summary>
        /// نوع کارت
        /// </summary>
        public int TypeCode;

    }
}
