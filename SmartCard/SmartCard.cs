using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCard
{
    public class JSmartCard
    {
        public void ListView()
        {
        }

        public ClassLibrary.JNode[] TreeView()
        {
            JNode[] Node = new JNode[1];
            Node[0] = SmartCard.JCards.GetTreeNode();
            return Node;
        }
    }
}
