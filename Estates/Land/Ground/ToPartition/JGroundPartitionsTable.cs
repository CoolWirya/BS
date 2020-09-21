using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Estates
{
    public class JGroundPartitionsTable:JTable
    {
        public JGroundPartitionsTable()
            : base(JTableNamesEstates.GroundPartitions)
        {
        }


        public int PartitionCode;
        public int GroundsPartition;

        
    }
}
