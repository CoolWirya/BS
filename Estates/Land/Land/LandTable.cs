using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Estates
{
    class JLandTable:JTable
    {
       public JLandTable()
            : base(JTableNamesEstate.LandTable)
        {
        }
        /// <summary>
        /// کد اراضی
        /// </summary>
        //public int Code;
        /// <summary>
        /// نام
        /// </summary>
        public string Name;
        /// <summary>
        /// پلاک ثبتی
        /// </summary>
        public string Plaque;
        /// <summary>
        /// بخش
        /// </summary>
        public string Section;
        /// <summary>
        /// مساحت اراضی
        /// </summary>
        /// <returns></returns>    
        public double Area;
    }
}
