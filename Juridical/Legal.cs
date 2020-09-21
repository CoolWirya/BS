using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
namespace Legal
{
    /// <summary>
    /// حقوقی
    /// </summary>
    public class JLegal: ClassLibrary.JSystem
    {
        
        public JLegal()
        {
          
        }
        public void ListView()
        {           
            Nodes.Insert(JLgStaticNodes._BaseDefine());
            Nodes.Insert(JLgStaticNodes._AdvocacyNode());
            Nodes.Insert(JLgStaticNodes._NotaryLetterNode());
            Nodes.Insert(JLgStaticNodes._PetitionNode());
            Nodes.Insert(JLgStaticNodes._NoticeNode());
            Nodes.Insert(JLgStaticNodes._DecisionNode());
            Nodes.Insert(JLgStaticNodes._ExecutiveNode());
            Nodes.Insert(JLgStaticNodes._DistraintNode());
            Nodes.Insert(JLgStaticNodes._ExpertiseNode());
            Nodes.Insert(JLgStaticNodes._AssertionNode());
            Nodes.Insert(JLgStaticNodes._BreakupOrgNode());
            Nodes.Insert(ClassLibrary.JStaticNode._ReportManagment(ClassLibrary.ProjectsEnum.Legal));

            JFreeClass.RUN(new JAction("GetDocumant", "ClassLibrary.JMainFrame.Check"));
        }
        public JNode[] TreeView()
        {
           
            JNode [] TNodes = new JNode[14];
            TNodes[0] = JLgStaticNodes._BaseDefine();
            //----
            TNodes[1] = new JNode(0, this);
            TNodes[1].Name = "Probate";
            TNodes[1].MouseClickAction = new JAction("Probate", "Legal.JProbates.ListView");
            //------
            TNodes[2] = JLgStaticNodes._AdvocacyNode();
            TNodes[3] = JLgStaticNodes._NotaryLetterNode();
            TNodes[4] = JLgStaticNodes._PetitionNode();
            TNodes[5] = JLgStaticNodes._NoticeNode();
            TNodes[6] = JLgStaticNodes._DecisionNode();
            TNodes[7] = JLgStaticNodes._ExecutiveNode();
            TNodes[8] = JLgStaticNodes._DistraintNode();
            TNodes[9] = JLgStaticNodes._ExpertiseNode();
            TNodes[10] = JLgStaticNodes._AssertionNode();
            TNodes[11] = JLgStaticNodes._BreakupOrgNode();
            TNodes[12] = ClassLibrary.JStaticNode._ReportManagment(ClassLibrary.ProjectsEnum.Legal);

            return TNodes;
        }
    }
}
