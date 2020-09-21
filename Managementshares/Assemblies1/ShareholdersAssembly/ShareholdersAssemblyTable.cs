using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementShares
{
    public class JShareholdersAssemblyTable : ClassLibrary.JTable
    {
        public int pCode;
        public int CCode;
        public int Share;
        public bool PrintVote;
        public bool present;
        public DateTime PresentDate;
        public int id;

        public JShareholdersAssemblyTable()
            : base("ShareholdersAssembly")
        {
        }

    }
}
