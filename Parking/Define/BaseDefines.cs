using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Parking
{
    class JPrkBaseDefine : JBaseDefine
    {
        public void ListView()
        {
            Nodes.Insert(JParkingStaticNodes._ColorCar());
            Nodes.Insert(JParkingStaticNodes._JTypeCar());
      
            Nodes.Insert(JParkingStaticNodes._Status());
            Nodes.Insert(JParkingStaticNodes._DueToInactivity());
            Nodes.Insert(JParkingStaticNodes._ControlStatus());
            Nodes.Insert(JParkingStaticNodes._ShowTypeDamge());
           

        }

        public JNode[] TreeView()
        {
            JNode[] gNodes = new JNode[6];
            gNodes[0] = JParkingStaticNodes._ColorCar();
            gNodes[1] = JParkingStaticNodes._JTypeCar();
            gNodes[2] = JParkingStaticNodes._Status();
            gNodes[3] = JParkingStaticNodes._DueToInactivity();
            gNodes[4] = JParkingStaticNodes._ControlStatus();
            gNodes[5] = JParkingStaticNodes._ShowTypeDamge();
           
         
            return gNodes;
        }
    }
    public class JParkingBaseDefines
    {
        
        public static readonly int ColorCar = 1001;
        public static readonly int TypeCar = 1000;
        public static readonly int CalCulateGroupParking = 1002;
        public static readonly int GroupCard = 1004;
        public static readonly int Status = 1009;
        public static readonly int DueToInactivity = 1010;
        public static readonly int Payment = 1011;
        public static readonly int ControlStatus = 1012;
        public static readonly int PrkDamge = 1013;
    }
}
