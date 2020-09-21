using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ClassLibrary;

namespace ShareProfit
{
    public class JShareProfit : JSystem
    {
        public void ListView()
        {
            Nodes.Insert(JSPStaticNode._CourseNode());
        }

        public JNode[] TreeView()
        {
            JNode[] N = new JNode[3];
            N[0] = JSPStaticNode._CourseNode();
            N[1] = JSPStaticNode._CoursesPayNode();
			N[2] = JSPStaticNode._ReportNode();
            return N;
        }
    }
}
