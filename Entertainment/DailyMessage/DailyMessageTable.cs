using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Entertainment
{
    class JDailyMessageTable : JTable
    {
        public JDailyMessageTable()
            : base("entDailyMessage")
        { }

        public DateTime Date { get; set; }
        public string Text { get; set; }
    }
}
