using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ManagementShares
{
    public class JManagementshares: JSystem
    {

        public JNode[] TreeView()
        {
            JNode[] nodes = new JNode[0];
            nodes = JStaticNode._ShareComanies();
           return nodes;
        }
    }
}
