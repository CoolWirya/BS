using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebBaseNet 
{
    public class ScheduleServiceTable:ClassLibrary.JTable 
    {
        public int Code;
        //public DateTime Date { get; set; }
        // public int BusCode { get; set; }
        // public int BusFailureCode { get; set; }
        public int CodeBaseNet;
        public int TypeService;
        public bool IsActive;
    


      




        public ScheduleServiceTable() 
            : base("ScheduleService")
        {
        }
    }
}