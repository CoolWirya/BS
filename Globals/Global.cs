using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Globals
{
    public class JGlobals
    {
        public JGlobals()
        {
          
        }

        public void ListView()
        {
            //Nodes.Insert(JLgStaticNodes._BaseDefine());
            //Nodes.Insert(JLgStaticNodes._Contracts());
            //Nodes.Insert(JLgStaticNodes._AdvocacyNode());


            JFreeClass.RUN(new JAction("GetDocumant", "ClassLibrary.JMainFrame.Check"));
        }
        //public JNode[] TreeView()
        //{          
            //JNode [] TNodes = new JNode[11];
            //TNodes[0] = JLgStaticNodes._BaseDefine();
            //TNodes[1] = JLgStaticNodes._Contracts();
            //TNodes[2] = new JNode(0, this);
            //TNodes[2].Name = "Probate";
            //TNodes[2].MouseClickAction = new JAction("Probate", "Legal.JProbates.ListView");
            //TNodes[3] = JLgStaticNodes._AdvocacyNode();
            //TNodes[4] = JLgStaticNodes._NotaryLetterNode();
            //TNodes[5] = JLgStaticNodes._PetitionNode();
            //TNodes[6] = JLgStaticNodes._NoticeNode();
            //TNodes[7] = JLgStaticNodes._DecisionNode();
            //TNodes[8] = JLgStaticNodes._ExecutiveNode();
            //TNodes[9] = JLgStaticNodes._DistraintNode();
            //TNodes[10] = JLgStaticNodes._ExpertiseNode();
            //return TNodes;
        //}
    }
}
