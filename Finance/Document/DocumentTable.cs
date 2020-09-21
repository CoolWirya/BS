using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finance
{
    public class JDocumentTable:JTable
    {
        public DateTime DateSave;
        public DateTime DateModifie;
        public int UserCode;
        public int PostCode;
        public string Description;
        public DateTime Date;

        public JDocumentTable()
            : base("FinDocument")
        {
        }
    }
}
