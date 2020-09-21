using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    public class JLgStaticNodes : JStaticNode
    {
        /// <summary>
        /// تعاریف پایه
        /// </summary>
        /// <returns></returns>
        public static JNode _BaseDefine()
        {
            JNode Node = new JNode(0, "Legal.JLgBaseDefine");
            Node.Name = "BaseDefine";
            //Node.Icone = 4;
            Node.Hint = "BaseDefine";

            JAction Ac = new JAction("BaseDefine", "Legal.JLgBaseDefine.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("BaseDefine", "Legal.JLgBaseDefine.TreeView");
            Node.ChildsAction = CAc;
            Node.Icone = JImageIndex.BaseDefine.GetHashCode();
            return Node;
        }

        public static JNode _ContractLetterNode()
        {
            //تعریف نود متن قرارداد
            JNode nodeNotary = new JNode(0, "Legal.JContractdefine");
            nodeNotary.Name = "ContractLetter";
            nodeNotary.MouseClickAction = new JAction("ContractLetter", "Legal.JContractdefines.ListView", null, null, true);
            nodeNotary.MouseDBClickAction = nodeNotary.MouseClickAction;
            nodeNotary.Icone = JImageIndex.Contract1.GetHashCode();
            return nodeNotary;
        }

        /// <summary>
        /// قراردادها
        /// </summary>
        /// <returns></returns>
        public static JNode _Contracts()
        {
            JNode Node = new JNode(0, "Legal.JContractNodes");
            Node.Name = "Contracts";
            //Node.Icone = 4;
            Node.Hint = "Contracts";

            JAction Ac = new JAction("Contracts", "Legal.JContractNodes.ContractView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("Contracts", "Legal.JContractNodes.ContractTree");
            Node.ChildsAction = CAc;
            Node.Icone = JImageIndex.Contract1.GetHashCode();
            return Node;
        }


        public static JNode _DocumentAccounting()
        {
            JNode Node = new JNode(0, "Legal.DocumentAccounting");
            Node.Name = "DocumentAccounting";
            Node.Hint = "DocumentAccounting";

            JAction Ac = new JAction("Contracts", "Legal.DocumentAccounting.JDocumentAccountings.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            Node.Icone = JImageIndex.Contract1.GetHashCode();
            return Node;
        }


        /// <summary>
        /// انواع موضوع دادخواست / شکوائیه
        /// </summary>
        /// <returns></returns>
        public static JNode _SubjectTypesNode()
        {
            JNode Node = new JNode(0, "Legal.JDefineSubjectType");
            Node.Name = "LegalSubjectType";
            //Node.Icone = 4;
            Node.Hint = "LegalSubjectType";

            JAction Ac = new JAction("LegalSubjectType", "Legal.JDefineSubjectTypes.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            Node.Icone = JImageIndex.BaseDefine.GetHashCode();
            return Node;
        }

        /// <summary>
        /// انواع قرارداد
        /// </summary>
        /// <returns></returns>
        public static JNode _ContractDynamicType()
        {
             JNode Node = new JNode(0, "Legal.JContractDynamicType");
            Node.Name = "ContractDynamicType";
            //Node.Icone = 4;
            Node.Hint = "ContractDynamicType";

            JAction Ac = new JAction("ContractDynamicType", "Legal.JContractDynamicTypes.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("Contracts", "Legal.JContractNodes.DynamicContractTree");
            Node.ChildsAction = CAc;
            Node.Icone = JImageIndex.SubjectDocument.GetHashCode();
            return Node;
        }

        /// <summary>
        /// انواع قرارداد
        /// </summary>
        /// <returns></returns>
        public static JNode _DefineField()
        {
            JNode Node = new JNode(0, "Legal.JDefineField");
            Node.Name = "DefineField";
            //Node.Icone = 4;
            Node.Hint = "DefineField";

            JAction Ac = new JAction("DefineField", "Legal.JDefineFields.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            Node.Icone = JImageIndex.SubjectDocument.GetHashCode();
            return Node;
        }

        public static JNode _ComplexNode()
        {
            //تعریف نود مجتمع قضایی
            JNode node = new JNode(0, "Legal.JJudicialComplexs");
            node.Name = "JudicalComplex";
            node.MouseClickAction = new JAction("JudicalComplex", "Legal.JJudicialComplexs.ListView", null, null, true);
            node.MouseDBClickAction = node.MouseClickAction;
            node.Icone = JImageIndex.CompanyTypes.GetHashCode();
            return node;
        }

        public static JNode _BranchNode()
        {
            //تعریف نود شعبه قضایی
            JNode nodeBranch = new JNode(0, "Legal.JJudicialBranch");
            nodeBranch.Name = "JudicialBranch";
            nodeBranch.MouseClickAction = new JAction("JudicialBranch", "Legal.JJudicialBranches.ListView", null, null, true);
            nodeBranch.MouseDBClickAction = nodeBranch.MouseClickAction;
            nodeBranch.Icone = JImageIndex.Secretariat.GetHashCode();
            return nodeBranch;
        }

        public static JNode _NotaryNode()
        {
            //تعریف نود دفتر اسناد رسمی
            JNode nodeNotary = new JNode(0, "Legal.JNotary");
            nodeNotary.Name = "Notary";
            nodeNotary.MouseClickAction = new JAction("Notary", "Legal.JNotarys.ListView", null, null, true);
            nodeNotary.MouseDBClickAction = nodeNotary.MouseClickAction;
            nodeNotary.Icone = JImageIndex.ResCostCenter.GetHashCode();
            return nodeNotary;
        }

        

        public static JNode _DocumentTypeNode()
        {
            //تعریف نود نوع سند
            JNode nodeNotary = new JNode(0, "Legal.JDocumentType");
            nodeNotary.Name = "DocumentType";
            nodeNotary.MouseClickAction = new JAction("DocumentType", "Legal.JDocumentTypes.ListView", null, null, true);
            nodeNotary.MouseDBClickAction = nodeNotary.MouseClickAction;
            nodeNotary.Icone = JImageIndex.Documents.GetHashCode();
            return nodeNotary;
        }

        public static JNode _AdvocacyNode()
        {
            //تعریف نود وکالت
            JNode nodeNotary = new JNode(0, "Legal.JAdvocacy");
            nodeNotary.Name = "Advocacy";
            nodeNotary.MouseClickAction = new JAction("Advocacy", "Legal.JAdvocacys.ListView", null, null, true);
            nodeNotary.MouseDBClickAction = nodeNotary.MouseClickAction;
            nodeNotary.Icone = JImageIndex.Relation.GetHashCode();
            return nodeNotary;
        }

        public static JNode _PetitionNode()
        {
            //تعریف نود دادخواست
            JNode nodePetition = new JNode(0, "Legal.JPetition");
            nodePetition.Name = "دادخواست/شکوائیه";
            nodePetition.MouseClickAction = new JAction("Petition", "Legal.JPetitions.ListView", null, null, true);
            nodePetition.MouseDBClickAction = nodePetition.MouseClickAction;
            nodePetition.Icone = JImageIndex.LetterInternal.GetHashCode();
            return nodePetition;
        }

        public static JNode _NotaryLetterNode()
        {
            //تعریف نود وکالت
            JNode nodeNotary = new JNode(0, "Legal.JNotaryLetter");
            nodeNotary.Name = "NotaryLetter";
            nodeNotary.MouseClickAction = new JAction("NotaryLetter", "Legal.JNotaryLetters.ListView", null, null, true);
            nodeNotary.MouseDBClickAction = nodeNotary.MouseClickAction;
            nodeNotary.Icone = JImageIndex.Relation.GetHashCode();
            return nodeNotary;
        }

        public static JNode _NotaryLetterSubject()
        {
            //تعریف نود موضوع نامه محضر
            JNode Lettersubject=new JNode(0,"Legal.JNotaryLetterSubject");
            Lettersubject.Name="NotaryLetterSubject";
            Lettersubject.MouseClickAction=new JAction("NotarySubject","Legal.JNotaryLetterSubjects.ListView",null,null,true);
            Lettersubject.MouseDBClickAction=Lettersubject.MouseClickAction;
            Lettersubject.Icone = JImageIndex.SubjectDocument.GetHashCode();
            return Lettersubject;
        }

        public static JNode _NoticeNode()
        {
            //تعریف نود اخطاریه
            JNode nodeNotary = new JNode(0, "Legal.JNotice");
            nodeNotary.Name = "Notice";
            nodeNotary.MouseClickAction = new JAction("Notice", "Legal.JNotices.ListView", null, null, true);
            nodeNotary.MouseDBClickAction = nodeNotary.MouseClickAction;
            nodeNotary.Icone = JImageIndex.Notice.GetHashCode();
            return nodeNotary;
        }

        public static JNode _DecisionNode()
        {
            //تعریف نود رای دادگاه
            JNode nodeNotary = new JNode(0, "Legal.JDecision");
            nodeNotary.Name = "Decision";
            nodeNotary.MouseClickAction = new JAction("Decision", "Legal.JDecisions.ListView", null, null, true);
            nodeNotary.MouseDBClickAction = nodeNotary.MouseClickAction;
            nodeNotary.Icone = JImageIndex.Secretariat.GetHashCode();
            return nodeNotary;
        }

        public static JNode _ExecutiveNode()
        {
            //تعریف نود رای اجرائیه
            JNode nodeNotary = new JNode(0, "Legal.JExecutive");
            nodeNotary.Name = "Executive";
            nodeNotary.MouseClickAction = new JAction("Executive", "Legal.JExecutives.ListView", null, null, true);
            nodeNotary.MouseDBClickAction = nodeNotary.MouseClickAction;
            nodeNotary.Icone = JImageIndex.BaseDefine.GetHashCode();
            return nodeNotary;
        }
        public static JNode _DistraintNode()
        {

            //تعریف نود توقیف اموال
            JNode NodeDistraint = new JNode(0, "Legal.JDistraint");
            NodeDistraint.Name = "Distraint";
            NodeDistraint.MouseClickAction = new JAction("Distraint", "Legal.JDistraints.ListView", null, null, true);
            NodeDistraint.MouseDBClickAction = NodeDistraint.MouseClickAction;
            NodeDistraint.Icone = JImageIndex.Distraint.GetHashCode();
            return NodeDistraint;
        }

        public static JNode _ExpertiseNode()
        {
            //تعریف نود نظر کار شناسی
            JNode NodeExpertise=new JNode(0,"Legal.JExpertise");
            NodeExpertise.Name = "Expertise";
            NodeExpertise.MouseClickAction = new JAction("Expertise", "Legal.JExpertises.ListView", null, null, true);
            NodeExpertise.MouseDBClickAction = NodeExpertise.MouseClickAction;
            NodeExpertise.Icone = JImageIndex.Expertise.GetHashCode();
            return NodeExpertise;
        }

        public static JNode _AssertionNode()
        {
            //تعریف نود اظهارنامه
            JNode nodeAssertion = new JNode(0, "Legal.JAssertion");
            nodeAssertion.Name = "Assertion";
            nodeAssertion.MouseClickAction = new JAction("Assertion", "Legal.JAssertions.ListView", null, null, true);
            nodeAssertion.MouseDBClickAction = nodeAssertion.MouseClickAction;
            nodeAssertion.Icone = JImageIndex.LetterSubject.GetHashCode();
            return nodeAssertion;
        }
        public static JNode _BreakupOrgNode()
        {
            //تعریف نود 
            JNode nodeAssertion = new JNode(0, "Legal.JbreakupOrg");
            nodeAssertion.Name = "breakupOrganization";
            nodeAssertion.MouseClickAction = new JAction("breakupOrganization", "Legal.JbreakupOrgs.ListView", null, null, true);
            nodeAssertion.MouseDBClickAction = nodeAssertion.MouseClickAction;
            nodeAssertion.Icone = JImageIndex.Secretariat.GetHashCode();
            return nodeAssertion;
        }
    }
}
