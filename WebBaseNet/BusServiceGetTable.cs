using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebBaseNet 
{
    public class BusServiceGetTable:ClassLibrary.JTable 
    {
        public int CodeSS;
        public DateTime Date { get; set; }
        public int BusCode { get; set; }
        // public int BusFailureCode { get; set; }
        public DateTime Dates; 
        public DateTime StartDate;





        public BusServiceGetTable()  
            : base("BusSN")
        {
        }
    }
}