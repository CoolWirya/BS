using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Estates
{
    public class JAboutTable:JTable
    {
        /// <summary>
        /// کدزمین مربوطه
        /// </summary>
        public int CodeGround;
        /// <summary>
        /// شمال ها
        /// </summary>
        public string North;
        /// <summary>
        /// جنوب ها
        /// </summary>
        public string South;
        /// <summary>
        /// غرب ها
        /// </summary>
        public string West;
        /// <summary>
        /// شرق ها
        /// </summary>
        public string East;
        /// <summary>
        /// تاریخ ثبت حدود اربعه
        /// </summary>
        public DateTime Date;

        public JAboutTable()
            : base(JTableNamesEstate.AboutTable)
        {
        }

    }
}
