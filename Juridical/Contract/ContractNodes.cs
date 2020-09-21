using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    public class JContractNodes : JSystem
    {
        public void ListView()
        {
            Nodes.Insert(JLgStaticNodes._ContractDynamicType());
            //Nodes.Insert(JLgStaticNodes._ContractLetterNode());
            Nodes.Insert(JLgStaticNodes._Contracts());
            Nodes.Insert(ClassLibrary.JStaticNode._ReportManagment(ProjectsEnum.Contract));
        }

        public JNode[] TreeView()
        {
            JNode[] gNodes = new JNode[4];
            gNodes[0] = JLgStaticNodes._ContractDynamicType();
            //gNodes[1] = JLgStaticNodes._ContractLetterNode();
            gNodes[1] = JLgStaticNodes._Contracts();
            gNodes[2] = ClassLibrary.JStaticNode._ReportManagment(ProjectsEnum.Contract);
            gNodes[3] = JLgStaticNodes._DocumentAccounting();
            return gNodes;
        }

        public void ContractView()
        {
            ContractView(0);
        }

        public void ContractView(int pContractType)
        {
            Nodes.ObjectBase = new JAction("Contract", "Legal.JSubjectContract.GetNode");
            Nodes.DataTable = JSubjectContracts.GetDataTable(0, pContractType);

            if (pContractType > 0)
            {
                //قرارداد جدید
                JToolbarNode TN  = new JToolbarNode();
                TN.Click = new JAction("NewContract...", "Legal.JGeneralContract.ShowForms", null, new object[] { pContractType });
                TN.Icon = JImageIndex.Add;
                Nodes.AddToolbar(TN);
                
                //Hassanzadeh
                JAction PrintContractAction = new JAction("ContractPrint...", "Legal.JSubjectContract.CreateContractPrint", null, null);
                JToolbarNode PrintContract = new JToolbarNode();
                PrintContract.Click = PrintContractAction;
                PrintContract.Icon = JImageIndex.Print;
                PrintContract.Hint = " چاپ قرارداد ";
                Nodes.AddToolbar(PrintContract);

            }
        }


        public void ContractDynamicView(Finance.JOwnershipType pOwnershipType)
        {
            Nodes.ObjectBase = new JAction("Contract", "Legal.JSubjectContract.GetNode");
            Nodes.DataTable = JSubjectContracts.GetDataTable(pOwnershipType, null);
        }

        public JNode[] ContractTree()
        {
            return ContractTree(0);
        }

        public JNode[] ContractTree(int pFinanceCode)
        {
            JNode[] _Node = new JNode[6];
            _Node[0] = _BaseContracts(Finance.JOwnershipType.Definitive, pFinanceCode);
            _Node[1] = _BaseContracts(Finance.JOwnershipType.Goodwill, pFinanceCode);
            _Node[2] = _BaseContracts(Finance.JOwnershipType.GoodwillPeace, pFinanceCode);
            _Node[3] = _BaseContracts(Finance.JOwnershipType.Rentals, pFinanceCode);
            _Node[4] = _BaseContracts(Finance.JOwnershipType.Other, pFinanceCode);
            _Node[5] = _BaseContracts(Finance.JOwnershipType.Personel, pFinanceCode);
            return _Node;
        }

        public JNode[] DynamicContractTree()
        {
            JNode[] _Node = new JNode[6];
            _Node[0] = _BaseDynamicContracts(Finance.JOwnershipType.Definitive);
            _Node[1] = _BaseDynamicContracts(Finance.JOwnershipType.Goodwill);
            _Node[2] = _BaseDynamicContracts(Finance.JOwnershipType.GoodwillPeace);
            _Node[3] = _BaseDynamicContracts(Finance.JOwnershipType.Rentals);
            _Node[4] = _BaseDynamicContracts(Finance.JOwnershipType.Other);
            _Node[5] = _BaseDynamicContracts(Finance.JOwnershipType.Personel);
            return _Node;
        }

        public JNode[] ContractSubTree(Finance.JOwnershipType pOwnershipType)
        {
            return ContractSubTree(pOwnershipType, 0);
        }

        public JNode[] ContractSubTree(Finance.JOwnershipType pOwnershipType, int pFinanceCode)
        {
            System.Data.DataTable DataTable = JContractDynamicTypes.GetDataTable(pOwnershipType, pFinanceCode);
            if (DataTable == null) return null;
            JNode[] _Nodes = new JNode[DataTable.Rows.Count];
            int _Count = 0;
            foreach (System.Data.DataRow DR in DataTable.Rows)
            {
                JNode _Node = new JNode((int)DR["Code"], "Legal.JContractDynamicTypes");
                _Node.Name = DR["Title"].ToString();
                _Node.MouseClickAction = new JAction("Contracts", "Legal.JContractNodes.ContractView", new object[] { (int)DR["Code"] }, null, true);
                _Nodes[_Count] = _Node;
                _Node.Icone = JImageIndex.Contract.GetHashCode();
                _Count++;
            }

            return _Nodes;
        }

        public static JNode _BaseContracts(Finance.JOwnershipType pOwnershipType)
        {
            return _BaseContracts(pOwnershipType , 0);
        }

        public static JNode _BaseContracts(Finance.JOwnershipType pOwnershipType, int pFinanceCode)
        {
            JNode Node = new JNode(0, "Legal.JContractNodes");
            Node.Name = pOwnershipType.ToString();
            //Node.Icone = 4;
            Node.Hint = pOwnershipType.ToString();

            Node.MouseClickAction = new JAction("Contracts", "Legal.JContractNodes.ContractView", new object[] { pOwnershipType }, null, true);

            JAction CAc = new JAction("Contracts", "Legal.JContractNodes.ContractSubTree", new object[] { pOwnershipType, pFinanceCode }, null);
            Node.ChildsAction = CAc;
            Node.Icone = JImageIndex.ContractEmployee.GetHashCode();
            return Node;
        }

        public static JNode _BaseDynamicContracts(Finance.JOwnershipType pOwnershipType)
        {
            JNode Node = new JNode(0, "Legal.JContractNodes");
            Node.Name = pOwnershipType.ToString();
            //Node.Icone = 4;
            Node.Hint = pOwnershipType.ToString();

            JAction Ac = new JAction("ContractDynamicType", "Legal.JContractDynamicTypes.ListView", new object[] { pOwnershipType }, null, true);
            Node.MouseClickAction = Ac;
            Node.Icone = JImageIndex.Contract1.GetHashCode();
            return Node;
        }
    }
}
