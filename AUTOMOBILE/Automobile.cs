using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace AUTOMOBILE
{
    public class JAutomobile
    {

        public void ListView()
        {
        }

        public ClassLibrary.JNode[] TreeView()
        {
            JNode[] Node = new JNode[3];
            Node[0] = AutomobileDefine.JAutomobileDefine.GetTreeNode();
            Node[1] = (new ClassLibrary.JBaseDefine()).GetNode(ClassLibrary.JBaseDefine.AutomobileType);
            Node[2] = Device.JDevice.GetTreeNode();

            return Node;

        }
    }
}
