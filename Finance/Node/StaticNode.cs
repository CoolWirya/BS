using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Finance
{
    public class JFStaticNode : JStaticNode
    {
        /// <summary>
        /// تعاریف پایه
        /// </summary>
        /// <returns></returns>
        public static JNode _BaseDefine()
        {
            JNode Node = new JNode(0, "Finance.JFinBaseDefine");
            Node.Name = "BaseDefine";
            //Node.Icone = 4;
            Node.Hint = "BaseDefine";

            JAction Ac = new JAction("BaseDefine", "Finance.JFinBaseDefine.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("BaseDefine", "Finance.JFinBaseDefine.TreeView");
            Node.ChildsAction = CAc;
            return Node;
        }

        public static JNode _ShareProfit()
        {
            //تعریف نود دارائی
            JNode nodeNotary = new JNode(0, "Finance.JAssetShare");
            nodeNotary.Name = "Finances";
            nodeNotary.MouseClickAction = new JAction("Finance", "Finance.JAssetShares.ListView");
            return nodeNotary;
        }

        /// <summary>
        /// انواع بانک
        /// </summary>
        /// <returns></returns>
        public static JNode _BankTypesNode()
        {
            JNode Node = new JNode(0, "Finance.JBankType");
            Node.Name = "LegalBankType";
            //Node.Icone = 4;
            Node.Hint = "LegalBankType";

            JAction Ac = new JAction("BankType", "Finance.JBankTypes.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }

        /// <summary>
        /// انواع شعب بانک
        /// </summary>
        /// <returns></returns>
        public static JNode _BranchTypesNode()
        {
            JNode Node = new JNode(0, "Finance.JBranchType");
            Node.Name = "LegalBranchType";
            //Node.Icone = 4;
            Node.Hint = "LegalBranchType";

            JAction Ac = new JAction("branchType", "Finance.JBranchTypes.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }

        /// <summary>
        /// انواع بابت سند
        /// </summary>
        /// <returns></returns>
        public static JNode _JConcernTypeNode()
        {
            JNode Node = new JNode(0, "Finance.JConcernType");
            Node.Name = "LegalConcernType";
            //Node.Icone = 4;
            Node.Hint = "LegalConcernType";

            JAction Ac = new JAction("ConcernType", "Finance.JConcernTypes.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }
        public static JNode _TotalAcountNode()
        {
            //تعریف نودحساب کل
            JNode node = new JNode(0, "Finance.JTotalAccounts");
            node.Name = "TotalAccount";
            JAction Ac = new JAction("TotalAccount", "Finance.JTotalAccounts.ListView");
            node.MouseClickAction = Ac;
            node.MouseDBClickAction = Ac;
            return node;
        }

    }
}
