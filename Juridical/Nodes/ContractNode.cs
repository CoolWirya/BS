using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    public class JContractNode : JBaseDefine
    {
        public void ListView()
        {
            Nodes.Insert(JLgStaticNodes._ContractLetterNode());
        }

        public JNode[] TreeView()
        {
            JNode[] gNodes = new JNode[1];
            gNodes[0] = JLgStaticNodes._ContractLetterNode();
            return gNodes;
        }
    }
}
