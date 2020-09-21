using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Finance
{
    public class JFinBaseDefine : JBaseDefine
    {
        public void ListView()
        {
            Nodes.Insert(JFStaticNode._JConcernTypeNode());
            Nodes.Insert(JFStaticNode._BankTypesNode());
            Nodes.Insert(JFStaticNode._BranchTypesNode());
            Nodes.Insert(JFStaticNode._TotalAcountNode());
        }

        public JNode[] TreeView()
        {
            JNode[] gNodes = new JNode[4];
            gNodes[0] = JFStaticNode._JConcernTypeNode();
            gNodes[1] = JFStaticNode._BankTypesNode();
            gNodes[2] = JFStaticNode._BranchTypesNode();
            gNodes[3] = JFStaticNode._TotalAcountNode();
            return gNodes;
        }
    }
}
