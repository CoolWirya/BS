using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Estates
{
    public class JUsageGroundTable:JTable
    {
        public JUsageGroundTable()
            : base(JTableNamesEstate.GroundUsageTable)
        {
        }
        public string Name;
        public string Density;
        public int Persent;
        public string Parking;
        public string Access;
        public string Comment;
    }
    enum JUsageGroundTableEnum
    {
        Name,
        Density,
        Persent,
        Parking,
        Access,
        Comment,
    }
}
