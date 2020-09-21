using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finance
{
    public class JDocumentDetailesTable:JTable
    {
        public int DocCode;
        public DateTime DateSave;
        public DateTime DateModifie;
        public int GroupCode;
        public int KolCode;
        public int MoeinCode;
        public int TafziliCode1;
        public int TafziliCode2;
        public int TafziliCode3;
        public int TafziliCode4;
        public int TafziliCode5;
        public decimal BedPrice;
        public decimal BesPrice;
        public string Description;
        public string ClassName;
        public int ObjectCode;

        public JDocumentDetailesTable()
            : base("FinDocumentDetails")
        {
        }
    }
}
