using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    public class JLgBaseDefine : JBaseDefine
    {
        public void ListView()
        {
            JBaseDefine RelationType = new JBaseDefine();
            Nodes.Insert(JLgStaticNodes._ComplexNode());
            Nodes.Insert(JLgStaticNodes._BranchNode());
            Nodes.Insert(JLgStaticNodes._NotaryNode());
            Nodes.Insert(JLgStaticNodes._SubjectTypesNode());
            Nodes.Insert(JLgStaticNodes._NotaryLetterSubject());
            Nodes.Insert(RelationType.GetNode(JBaseDefine.FamilyRelation));
           
        }

        public JNode[] TreeView()
        {
            JBaseDefine RelationType = new JBaseDefine();
            JNode[] gNodes = new JNode[6];
            gNodes[0] = JLgStaticNodes._ComplexNode();
            gNodes[1] = JLgStaticNodes._BranchNode();
            gNodes[2] = JLgStaticNodes._NotaryNode();
            gNodes[3] = JLgStaticNodes._SubjectTypesNode();
            gNodes[4] = JLgStaticNodes._NotaryLetterSubject();
            gNodes[5] = RelationType.GetNode(JBaseDefine.FamilyRelation);
            return gNodes;
        }
    }
}
