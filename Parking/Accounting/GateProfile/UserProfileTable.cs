using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
namespace Parking
{
 public   class JUserProfileTable:JTable
    {
     public JUserProfileTable()
            : base(JTableNamesParking.ParkingUser)
        {

        }

     
     /// <summary>
     ///   تاريخ تشكيل
     /// </summary>
     public DateTime DateShift;
     /// <summary>
     ///  ساعت تشكيل
     /// </summary>
     public string Time;
     /// <summary>
     /// شماره گيت
     /// </summary>
     public int Gate;
     /// <summary>
     /// توضيحات
     /// </summary>
     public string Hint;
     /// <summary>
     /// كاربر
     /// </summary>
     public int Oprator;
     /// <summary>
     /// مبلغ
     /// </summary>
     public int Amount;
     /// <summary>
     /// مجتمع
     /// </summary>
     public int Market;
     /// <summary>
     /// شيفت
     /// </summary>
     public int Shift;
    }
}
