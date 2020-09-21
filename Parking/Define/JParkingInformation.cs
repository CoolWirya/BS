using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Parking
{
    public class JParkingInformation : JBaseDefine
    {
        public void ListView()
        {
            Nodes.Insert(JParkingStaticNodes._CarNode());
            Nodes.Insert(JParkingStaticNodes._CardParkingNode());
          

        }

        public JNode[] TreeView()
        {
            JNode[] N = new JNode[2];
            N[0] = JParkingStaticNodes._CarNode();
            N[1] = JParkingStaticNodes._CardParkingNode();
            
            return N;
        }
    }
}
