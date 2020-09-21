using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCard
{
    public class JCardsTable : JTable
    {
        public JCardsTable()
            : base("Cards","pCode")
        { 
        }

        /// <summary>
        /// وضعیت کارت
        /// </summary>
        public bool Status;
        /// <summary>
        /// 
        /// </summary>
        public Int64 RfidNumber;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description;
        /// <summary>
        /// نوع کارت
        /// </summary>
        public int CardType;
        /// <summary>
        /// کد کارت
        /// </summary>
        public int CardCode;
        /// <summary>
        /// صاحب کارت
        /// </summary>
        public int pCode;
        /// <summary>
        /// نوع کارت مسافر
        /// </summary>
        public int PassengerCardType;
    }
}
