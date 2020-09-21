using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Estates
{
    public class JGroundPartitionTable:JTable
    {
       public JGroundPartitionTable()
            : base(JTableNamesEstates.GroundPartition)
        {
        }
        /// <summary>
        /// کد زمین تفکیک شده
        /// </summary>
      public int GroundMainCode;
        /// <summary>
        /// کد حکمی که طی آن زمین تفکیک می شود
        /// </summary>
      public  int CourtCode;


    }
    public enum JGroundPartitionEnum
    {
        GroundMainCode,
        CourtCode,
        Code
    }
}
