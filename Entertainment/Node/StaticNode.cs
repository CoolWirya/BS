using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Entertainment
{
    public class JEntertainmentStaticNode
    {

        public static void ShowForm()
        {
            BulletinForm tmp = new BulletinForm();
            tmp.ShowDialog();
        }

        public static void ShowAddUserForm()
        {
            JAddUserForm tmp = new JAddUserForm();
            tmp.ShowDialog();
        }

        public static void ShowDailyMessageForm()
        {
            DailyMessage.DailyMessageForm tmp = new Entertainment.DailyMessage.DailyMessageForm();
            tmp.ShowDialog();
        }

        public static JNode _BulletinForm()
        {
            JNode Node = new JNode(0, "Entertainment.JEntertainmentStaticNode");
            Node.Name = "Bulletin";
            Node.Hint = "Bulletin";

            JAction Ac = new JAction("Bulletin", "Entertainment.JEntertainmentStaticNode.ShowForm", null, null, true);
            Node.MouseClickAction = Ac;
            return Node;
        }

        public static JNode _CommunicatorForm()
        {
            JNode Node = new JNode(0, "Entertainment.JEntertainmentStaticNode");
            Node.Name = "Communicator";
            Node.Hint = "Communicator";

            JAction Ac = new JAction("Communicator", "Entertainment.JEntertainmentStaticNode.ShowAddUserForm", null, null, true);
            Node.MouseClickAction = Ac;
            return Node;
        }

        internal static JNode _DailyMessageForm()
        {
            JNode Node = new JNode(0, "Entertainment.JEntertainmentStaticNode");
            Node.Name = "DailyMessage";
            Node.Hint = "DailyMessage";

            JAction Ac = new JAction("DailyMessage", "Entertainment.JEntertainmentStaticNode.ShowDailyMessageForm", null, null, true);
            Node.MouseClickAction = Ac;
            return Node;
        }
    }
}
