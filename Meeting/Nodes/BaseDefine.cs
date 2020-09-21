using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Meeting
{
    class JmetBaseDefine : JBaseDefine
    {
        public void ListView()
        {
            Nodes.Insert(JMetStaticNodes._LegistlationGroupNode());
            Nodes.Insert(JMetStaticNodes._CommissionType());
            //Nodes.Insert(JMetStaticNodes._CommissionPersons());

        }

        public JNode[] TreeView()
        {
            JNode[] gNodes = new JNode[3];
            gNodes[0] = JMetStaticNodes._LegistlationGroupNode();
            gNodes[1] = JMetStaticNodes._CommissionType();
            //gNodes[2] = JMetStaticNodes._CommissionPersons();
            return gNodes;
        }
    }
}
