using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Entertainment
{
    public class JEntertainment : JSystem
    {
        public void ListView()
        {
            Nodes.Insert(JEntertainmentStaticNode._BulletinForm());
            Nodes.Insert(JEntertainmentStaticNode._CommunicatorForm());
            Nodes.Insert(JEntertainmentStaticNode._DailyMessageForm());
        }

        public JNode[] TreeView()
        {
            JNode[] Nodes = new JNode[3];
            Nodes[0] = JEntertainmentStaticNode._BulletinForm();
            Nodes[1] = JEntertainmentStaticNode._CommunicatorForm();
            Nodes[2] = JEntertainmentStaticNode._DailyMessageForm();
            return Nodes;
        }
    }
}
