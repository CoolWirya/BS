using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using  ClassLibrary;

namespace Parking
{
 public   class JDayProfileTable:JTable
    {
  
        /// </summary>
   public string NameShift;
        /// <summary>
        /// تاریخ ثبت
        /// </summary>
   public DateTime Date;
        /// <summary>
        /// زمان ثبت
        /// </summary>
    public string Time;
        /// <summary>
        /// سر شیفت
        /// </summary>
    public int HeadShift;
        /// <summary>
        /// توضيحات
        /// </summary>
    public string Description;
        /// <summary>
        ///مجتمع
        /// </summary>
    public int Market;
        /// <summary>
        /// شيفت
        /// </summary>
   public   int shift;
        /// <summary>
        /// كاربر
        /// </summary>
     public int UserReg;
     public int AmountKol;
     public JDayProfileTable()
            : base(JTableNamesParking.DayProfile)
        {

        }
    }
}
