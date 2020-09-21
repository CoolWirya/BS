using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Meeting
{
    public class JMetStaticNodes : JStaticNode
    {
        /// <summary>
        /// تعاریف اولیه
        /// </summary>
        /// <returns></returns>
        public static JNode _BaseDefine()
        {
            JNode Node = new JNode(0, "Meeting.JmetBaseDefine");
            Node.Name = "BaseDefine";
            //Node.Icone = 4;
            Node.Hint = "BaseDefine";

            JAction Ac = new JAction("BaseDefine", "Meeting.JmetBaseDefine.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("BaseDefine", "Meeting.JmetBaseDefine.TreeView");
            Node.ChildsAction = CAc;
            return Node;
        }
        /// <summary>
        /// جلسه
        /// </summary>
        /// <returns></returns>
        public static JNode _MeetingNode()
        {
            JNode Node = new JNode(0, "Meeting.JMeetings");
            Node.Name = "Meetings";
            //Node.Icone = 4;
            Node.Hint = "Meetings";

            JAction Ac = new JAction("Meetings", "Meeting.JMeetingss.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }
        /// <summary>
        ///جستجو جلسه
        /// </summary>
        /// <returns></returns>
        public static JNode _SearchMeetingNode()
        {
            JNode Node = new JNode(0, "Meeting.JMeetings");
            Node.Name = "SearchMeetings";
            //Node.Icone = 4;
            Node.Hint = "SearchMeetings";

            JAction Ac = new JAction("SearchMeetings", "Meeting.JSearch.ShowForm", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }

        public static JNode _LegistlationNode()
        {
            JNode Node = new JNode(0, "Meeting.JLegislation");
            Node.Name = "JLegislation";
            //Node.Icone = 4;
            Node.Hint = "JLegislation";

            JAction Ac = new JAction("JLegislation", "Meeting.JLegislations.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }

        public static JNode _LegistlationGroupNode()
        {
            JNode Node = new JNode(0, "Meeting.JLegislationGroup");
            Node.Name = "JLegislationGroup";
            //Node.Icone = 4;
            Node.Hint = "JLegislationGroup";

            JAction Ac = new JAction("JLegislationGroup", "Meeting.JLegislationGroups.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }

        public static JNode _CommissionType()
        {
            JNode Node = new JNode(0, "Meeting.JCommissions");
            Node.Name = "CommissionType";
            JAction Ac = new JAction("CommissionType", "Meeting.JCommissions.ListView");
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }

        public static JNode _CommissionPersons()
        {
            JNode Node = new JNode(0, "Meeting.JCommissions");
            Node.Name = "CommissionPersons";
            JAction Ac = new JAction("CommissionPersons", "Meeting.JCommissionPersonss.ListView");
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }
    }
}
