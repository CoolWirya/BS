using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Bascol
{
    public class JBascol : JSystem
    {
        public void ListView()
        {
            Nodes.Insert(JBascolStaticNodes._BaseDefine());
            Nodes.Insert(JBascolStaticNodes._TozinNode());
            Nodes.Insert(JBascolStaticNodes._ReportUser());
            Nodes.Insert(JBascolStaticNodes._ReportManger());
            //Nodes.Insert(JBascolStaticNodes._ReportChart());            
            //Nodes.Insert(ClassLibrary.JStaticNode._ReportManagment(ClassLibrary.ProjectsEnum.Meeting));
        }

        public JNode[] TreeView()
        {
            JNode[] Nodes = new JNode[5];
            Nodes[0] = JBascolStaticNodes._BaseDefine();
            Nodes[1] = JBascolStaticNodes._TozinNode();
            Nodes[2] = JBascolStaticNodes._ReportUser();
            Nodes[3] = JBascolStaticNodes._ReportManger();
            //Nodes[4] = JBascolStaticNodes._ReportChart();
            //Nodes[3] = ClassLibrary.JStaticNode._ReportManagment(ClassLibrary.ProjectsEnum.Meeting);
            return Nodes;
        }
    }
}
