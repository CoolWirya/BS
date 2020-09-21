using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Estates
{
    class JEsBaseDefine : JBaseDefine
    {
        public void ListView()
        {
            Nodes.Insert(JEsStaticNode._LandsNode());
            Nodes.Insert(JEsStaticNode._GroundUsageNode());
            Nodes.Insert(JEsStaticNode._EstateType());
            Nodes.Insert(JEsStaticNode._DocumentType());
        }

        public JNode[] TreeView()
        {
            JNode[] gNodes = new JNode[4];
            gNodes[0] = JEsStaticNode._LandsNode();
            gNodes[1] = JEsStaticNode._GroundUsageNode();
            gNodes[2] = JEsStaticNode._EstateType();
            gNodes[3] = JEsStaticNode._DocumentType();
            return gNodes;
        }
    }
    public class JAggregationSeparation:JSystem
    {
         public void ListView()
        {
            Nodes.Insert(JEsStaticNode._Aggregation());
            Nodes.Insert(JEsStaticNode._BreakDown());
            Nodes.Insert(JEsStaticNode._Partition());
           
        }

        public JNode[] TreeView()
        {
            JNode[] gNodes = new JNode[3];
            gNodes[0] = JEsStaticNode._Aggregation();
            gNodes[1] = JEsStaticNode._BreakDown();
            gNodes[2] = JEsStaticNode._Partition();
            return gNodes;
        }
    }

}
