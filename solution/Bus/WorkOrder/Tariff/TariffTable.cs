using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusManagment.WorkOrder
{
    class TariffTable:ClassLibrary.JTable
    {
        public int LineCode;
        public int BusCode;
        public int DriverCode;
        public DateTime StartDate;
        public DateTime EndDate;
        public int ShiftCode;
        public TariffTable()
            : base("AUTTariff")
        {
        }
    }
}
