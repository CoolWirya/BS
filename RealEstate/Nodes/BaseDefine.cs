using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace RealEstate
{
    class JREsBaseDefine : JBaseDefine
    {
        public void ListView()
        {
            Nodes.Insert(JREsStaticNode._MarketUsageNode());
            Nodes.Insert(JREsStaticNode._UnitJobsNode());
            Nodes.Insert(JREsStaticNode._UnitBuildTypeNode());
            Nodes.Insert(JREsStaticNode._JointTypes());
            Nodes.Insert(JREsStaticNode._JointStatus());
            Nodes.Insert(JREsStaticNode._JDoorBuilding());
            
        }

        public JNode[] TreeView()
        {
            JNode[] gNodes = new JNode[7];
            gNodes[0] = JREsStaticNode._MarketUsageNode();
            gNodes[2] = JREsStaticNode._UnitJobsNode();
            gNodes[3] = JREsStaticNode._UnitBuildTypeNode();
            gNodes[4] = JREsStaticNode._JointTypes();
            gNodes[5] = JREsStaticNode._JointStatus();
            gNodes[6] = JREsStaticNode._JDoorBuilding();
            return gNodes;
        }
    }
}
