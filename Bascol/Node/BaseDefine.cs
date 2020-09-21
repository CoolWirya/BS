using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Bascol
{
    class JBascolBaseDefine : JBaseDefine
    {
        public void ListView()
        {
            Nodes.Insert(JBascolStaticNodes._TruckNode());
            Nodes.Insert(JBascolStaticNodes._Products());
            Nodes.Insert(JBascolStaticNodes._ConfigBascol());
            Nodes.Insert(JBascolStaticNodes._ConfigTax());
            Nodes.Insert(JBascolStaticNodes._ChangPlok());
        }

        public JNode[] TreeView()
        {
            JNode[] gNodes = new JNode[5];
            gNodes[0] = JBascolStaticNodes._TruckNode();
            gNodes[1] = JBascolStaticNodes._Products();
            gNodes[2] = JBascolStaticNodes._ConfigBascol();
            gNodes[3] = JBascolStaticNodes._ConfigTax();
            gNodes[4] = JBascolStaticNodes._ChangPlok();
            return gNodes;
        }
    }
}
