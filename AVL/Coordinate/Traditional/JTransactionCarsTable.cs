using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Coordinate.Traditional
{
    public class JTransactionCarsTable:    ClassLibrary.JTable
    {
        public string CarID { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }

        public DateTime RegisterDateTime;
        public JTransactionCarsTable()
            : base("avlsite_com_1.dbo.TransactionCars")
        {

        }
    }
}
