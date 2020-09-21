using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace RealEstate
{
 public    class JPrintableGhabzTable:JTable
    {
        //public int Code = 0;
        public string CodeGhabz = "0";
        public int CodeUnitBuild = 0;
        public int PreviousDebt = 0;
        public int Yaraneh = 0;
        public int debt = 0;
        public DateTime PaymentDeadline = DateTime.Now;
        public int Month = 1;
        public int CodeCustomer = 0;
        public int CodeMarket = 0;
        public Boolean StatusPay = false;
        public int CodeUser =0;
        public DateTime DateCreate = DateTime.Now;
        public int BastanKari = 0;
        public JPrintableGhabzTable()
            : base(JRETableNames.PrintedCharge)
        {

        }
    }
}
