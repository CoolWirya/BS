using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.Contract
{
    class ContractTable :ClassLibrary.JTable
    {
        public DateTime StartDate;
        public DateTime EndDate;
        public int Code_Driver;
         public int Code_Owner;
         public ContractTable()
            : base("AUTContract")
        {
        }
    }
}
