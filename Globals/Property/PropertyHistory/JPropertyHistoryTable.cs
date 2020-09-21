using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Globals.Property
{
    class JPropertyHistoryTable : JTable
    {
        public JPropertyHistoryTable()
            : base("PropertyHistory")
        {
        }
        public string ClassName;
        public int ObjectCode;
        public int TableCode;
        public int TableObjectCode;
        public int UserCode;
        public int UserPostCode;
        public string FieldName;
        public string OldValue;
        public string NewValue;
        public DateTime Date;

    }
}
