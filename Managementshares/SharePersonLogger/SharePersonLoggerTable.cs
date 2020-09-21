using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ManagementShares
{
    public class JSharePersonLoggerTable : JTable
    {
        public JSharePersonLoggerTable()
            : base("SharePersonLogger")
        {
        }
        public DateTime TDate;
        public int SCode;
        public int SheetType;
        public int Az;
        public int Ela;
		public int PCode;
		public int PCode2;
		public int InSum;
        public int OutSum;
        public decimal Cost;
        public int OperationCode;
        public bool Disabled;
		public int Ordered;
	}
}
