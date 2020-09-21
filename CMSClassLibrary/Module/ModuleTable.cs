using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace CMSClassLibrary.Module
{
    class JModuleTable : JTable
    {
        public JModuleTable(): base(JTableNamesCMS.CMSModules)
        { }

      //  public int Code;
        public string Name;
        public bool State;
        public string Parameters;
        public int Site;
        public string Position;
        public int PosOrder;
        public int ExtCode;
        public bool Home;

    }
}
