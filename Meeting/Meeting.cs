using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Meeting
{
    public class JMeeting : JSystem
    {
        public void ListView()
        {
            Nodes.Insert(JMetStaticNodes._BaseDefine());
            Nodes.Insert(JMetStaticNodes._MeetingNode());
            Nodes.Insert(JMetStaticNodes._SearchMeetingNode());
            Nodes.Insert(ClassLibrary.JStaticNode._ReportManagment(ClassLibrary.ProjectsEnum.Meeting));
        }

        public JNode[] TreeView()
        {
            JNode[] Nodes = new JNode[4];
            Nodes[0] = JMetStaticNodes._BaseDefine();
            Nodes[1] = JMetStaticNodes._MeetingNode();
            Nodes[2] = JMetStaticNodes._SearchMeetingNode();
            
            Nodes[3] = ClassLibrary.JStaticNode._ReportManagment(ClassLibrary.ProjectsEnum.Meeting);
            return Nodes;
        }
    }
}
