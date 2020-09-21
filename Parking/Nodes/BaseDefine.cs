using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Parking
{
    public class JParkingBaseDefine : JBaseDefine
    {
        public void ListView()
        {
            Nodes.Insert(JParkingStaticNodes._ColorCar());
            Nodes.Insert(JParkingStaticNodes._JTypeCar());
            Nodes.Insert(JParkingStaticNodes._Status());
            Nodes.Insert(JParkingStaticNodes._DueToInactivity());
            Nodes.Insert(JParkingStaticNodes._ControlStatus());
        

        }

        public JNode[] TreeView()
        {
            JNode[] gNodes = new JNode[5];
            gNodes[0] = JParkingStaticNodes._ColorCar();
            gNodes[1] = JParkingStaticNodes._JTypeCar();
            gNodes[2] = JParkingStaticNodes._Status();
            gNodes[3] = JParkingStaticNodes._DueToInactivity();
            gNodes[4] = JParkingStaticNodes._ControlStatus();
            

            return gNodes;
        }

    }
}
