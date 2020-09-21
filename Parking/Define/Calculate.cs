using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
namespace Parking
{
    class JCalculate:JBaseDefine
    {
        
            public void ListView()
            {
               
                Nodes.Insert(JParkingStaticNodes._ShowDamge());
                Nodes.Insert(JParkingStaticNodes._Showshift());

            }

            public JNode[] TreeView()
            {
                JNode[] N = new JNode[2];
                
                N[0] = JParkingStaticNodes._ShowDamge();
                N[1] = JParkingStaticNodes._Showshift();
                return N;
            }
        
    }
}
