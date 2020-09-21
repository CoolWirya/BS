using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Parking
{
    public class JParkingpublicDefine : JBaseDefine
    {
        public void ListView()
        {
            
            Nodes.Insert(JParkingStaticNodes._ShowBaseShift());
            Nodes.Insert(JParkingStaticNodes._ShowGate());
            Nodes.Insert(JParkingStaticNodes._GroupParking());
            Nodes.Insert(JParkingStaticNodes._ShowUpdate());
            
         
        }

        public JNode[] TreeView()
        {
            JNode[] gNodes = new JNode[4];
           
            gNodes[0] = JParkingStaticNodes._ShowBaseShift();
            gNodes[1] = JParkingStaticNodes._ShowGate();
            gNodes[2] = JParkingStaticNodes._GroupParking();
            gNodes[3] = JParkingStaticNodes._ShowUpdate();
            return gNodes;
        }
    }
}
