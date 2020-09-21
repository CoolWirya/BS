using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Communication
{
    public class NoStorageTable : ClassLibrary.JTable
    {
        public NoStorageTable()
            : base("NoStorage")
        { }

        public string ClassName;
        public int ObjectCode;
        public int Year;
        public int LastNo;
        public int Parent;
        public string reserve;
		public int SecretariatCode;
    }
}
