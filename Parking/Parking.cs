using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Parking
{
    public class JParking : ClassLibrary.JSystem
    {

        public void ListView()
        {
            Nodes.Insert(JParkingStaticNodes._BaseDefine());
            Nodes.Insert(JParkingStaticNodes._PublicDefine());
            Nodes.Insert(JParkingStaticNodes._Information());
            Nodes.Insert(JParkingStaticNodes._Calculate());
            
            Nodes.Insert(ClassLibrary.JStaticNode._ReportManagment(ClassLibrary.ProjectsEnum.Parking));
        }

        public JNode[] TreeView()
        {
            JNode[] N = new JNode[5];
            N[0] = JParkingStaticNodes._BaseDefine();
            N[1] = JParkingStaticNodes._PublicDefine();
            N[2] = JParkingStaticNodes._Information();
            N[3] = JParkingStaticNodes._Calculate();
            N[4] = JParkingStaticNodes._ReportManagment(ClassLibrary.ProjectsEnum.Parking);
          
            return N;
        }

      

      
    }
}
