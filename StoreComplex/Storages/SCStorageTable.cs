using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreComplex
{
    public class JSCStorageTable  :JTable
    {
        public JSCStorageTable()
            : base("SCStorage")
        {
        }
        public string Title ;
        public int Type ;
        public int BoxCount ;
        public int BoxMeter ;
        public string Description ;
    }
}
