using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ManagementShares
{
    public class JSheetLogTable:JTable
    {
        public int SCode ;
        public int Operation ;
        public int PCode;
        public int NewPCode;
        public int NewSCode;
        public int OperationCode;
        public JSheetLogTable()
            : base("ShareSheetLog")
        {
        }
    }
}
