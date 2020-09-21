using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace ManagementShares
{
    public class JStaticNode
    {

        public static JNode _ShareCompanyNode()
        {
            JNode Node = new JNode(0, "ManagementShares.JShareCompany");
            Node.Name = "JShareCompany";
            //Node.Icone = 4;
            Node.Hint = "JShareCompany";

            JAction Ac = new JAction("JShareCompany", "ManagementShares.JShareCompanies.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            Node.Icone = JImageIndex.Bazar.GetHashCode();
            return Node;
        }

        public static JNode[] _ShareComanies()
        {
            JNode[] Nodes = new JNode[0];
            DataTable companies = new DataTable();
            companies = JShareCompanies.GetDataTable();
            foreach (DataRow row in companies.Rows)
            {
                Array.Resize(ref Nodes, Nodes.Length + 1);
                JShareCompany sc = new JShareCompany(Convert.ToInt32(row["Code"]));
                JNode node = new JNode(sc.Code, "ShareCompany" + Nodes.Length);
                node.MouseClickAction = new JAction("ShareCompany", "ManagementShares.JShareSheets.ListView", new object[] { sc.Code }, null);
                node.Popup.Insert(new JAction("ShareCompany", "ManagementShares.JShareCompanyForm.ShowDialog", null, new object[] { sc.Code }));
                //node.MouseDBClickAction = new JAction("ShareCompany", "ManagementShares.FormWebUserChange.ShowDialog");
                node.Name = (new JOrganization(sc.PCode)).Name;
                Nodes[Nodes.Length - 1] = node;
                node.Childs = _CompanyOperationNodes(sc.Code);
            }
            return Nodes;
        }

        public static JNode[] _CompanyOperationNodes(int pCompanyCode)
        {
            JNode[] gNodes = new JNode[12];
            gNodes[0] = _PersonNode(pCompanyCode);
            gNodes[1] = _DeactiveSheets(pCompanyCode);
            gNodes[2] = _IncreaseShare(pCompanyCode);
            gNodes[3] = _JoinSheets(pCompanyCode);
            gNodes[4] = _BreakSheets(pCompanyCode);
            gNodes[5] = _Assemblies(pCompanyCode);
            gNodes[6] = _DocumentShareOld(pCompanyCode);

            gNodes[7] = _AgentNode(pCompanyCode);

            gNodes[8] = _TransferNode(pCompanyCode);

            gNodes[9] = _ReportNode(pCompanyCode);
            gNodes[10] = _SharePrice(pCompanyCode);
            gNodes[11] = _CompanyPrice(pCompanyCode);

			

            //gNodes[10] = _TransferWebNode(pCompanyCode);

            //gNodes[11] = _TransferDataToWebNode(pCompanyCode);


            return gNodes;
        }

        public static JNode _DocumentShareOld(int CompanyCode)
        {
            JNode node = new JNode(0, "DocumentShareOld");
            node.Name = "DocumentShareOld";
            JAction Ac = new JAction("DocumentShareOld", "ManagementShares.JDocumentShareOlds.ListView",new object[] { CompanyCode } , null);
            node.MouseClickAction = Ac;
            node.MouseDBClickAction = Ac;
            node.Icone = JImageIndex.Bazar.GetHashCode(); 
            return node;
        }

        public static JNode _SharePrice(int CompanyCode)
        {
            JNode node = new JNode(0, "SharePrice");
            node.Name = "SharePrice";
            JAction Ac = new JAction("DocumentShareOld", "ManagementShares.JSharePrice.ShowForm", new object[] { CompanyCode }, null);
            node.MouseClickAction = Ac;
            node.MouseDBClickAction = Ac;
            node.Icone = JImageIndex.Bazar.GetHashCode();
            return node;
        }

        public static JNode _CompanyPrice(int CompanyCode)
        {
            JNode node = new JNode(0, "CompanyPrice");
            node.Name = "CompanyPrice";
            JAction Ac = new JAction("DocumentShareOld", "ManagementShares.JShareCompany.ShowDialog", new object[] { CompanyCode }, null);
            node.MouseClickAction = Ac;
            node.MouseDBClickAction = Ac;
            node.Icone = JImageIndex.Bazar.GetHashCode();
            return node;
        }

        public static JNode _DeactiveSheets(int CompanyCode)
        {
            JNode node = new JNode(0, "DeActiveSheets");
            node.Name = "DeActiveSheets";
            node.MouseClickAction = new JAction("ShareCompany", "ManagementShares.JShareSheets.DeActiveListView", new object[] { CompanyCode }, null);
            return node;
        }

        public static JNode _Assemblies(int CompanyCode)
        {
            JNode node = new JNode(0, "Assemblies");
            node.Name = "Assemblies";
            node.MouseClickAction = new JAction("Assemblies", "ManagementShares.JAssemblies.ListView", null, new object[] { CompanyCode });
            ManagementShares.JAssemblies _Assemblies = new JAssemblies(CompanyCode);
            node.Childs = _Assemblies.TreeView();
            return node;
        }


        public static JNode _BreakSheets(int pCompanyCode)
        {
            JNode node = new JNode(0, "ManagementShares.JShareCompany");
            node.MouseClickAction = new JAction("ShareCompany", "ManagementShares.JShareCompany.ShowBreakSheetsForm", new object[] { pCompanyCode }, null);
            node.Name = "BreakSheets";
            return node;
        }


        public static JNode _IncreaseShare(int pCompanyCode)
        {
            JNode node = new JNode(0, "ManagementShares.JShareCompany");
            node.MouseClickAction = new JAction("ShareCompany", "ManagementShares.JShareCompany.ShowIncreaseShareForm", new object[] { pCompanyCode }, null);
            node.Name = "IncreaseShare";
            return node;
        }
        public static JNode _JoinSheets(int pCompanyCode)
        {
            JNode node = new JNode(0, "ManagementShares.JShareCompany");
            node.MouseClickAction = new JAction("ShareCompany", "ManagementShares.JShareCompany.ShowJoinSheetsForm", new object[] { pCompanyCode }, null);
            node.Name = "JoinSheets";
            return node;
        }

        public static JNode _AgentNode(int pCompanyCode)
        {
            JNode node = new JNode(0, "ManagementShares.JShareAgent");
            node.MouseClickAction = new JAction("ShareCompany", "ManagementShares.JShareAgents.ListView", new object[] { pCompanyCode }, null);
            node.Name = "Agents";
            return node; 
        }
        public static JNode _PersonNode(int companyCode)
        {
            JNode node = new JNode(0, "ManagementShares.JSharePeople");
            node.MouseClickAction = new JAction("ShareCompany", "ManagementShares.JShareSheets.PersonListView", new object[]{ companyCode }, null);
            node.Name = "ShareHolders";
            return node; 
        }

        public static JNode _ReportNode(int pCompanyCode)
        {
            JNode node = new JNode(0, "ManagementShares.JShareReport");
            node.MouseClickAction = new JAction("ShareCompany", "ManagementShares.JShareReport.ShowReportForm", new object[] { pCompanyCode }, null);
            node.Name = "Reports";
            return node;
        }

        public static JNode _TransferNode(int pCompanyCode)
        {
            JNode node = new JNode(0, "ManagementShares.JShareTransfer");
            node.MouseClickAction = new JAction("ShareCompany", "ManagementShares.JTransferSheets.ListView", new object[] { pCompanyCode } , null);
            node.Name = "JShareTransfer";
            return node; 
        }

        public static JNode _TransferWebNode()
        {
            JNode Node = new JNode(0, "JManagementshares");
            Node.MouseClickAction = new JAction("test", "ManagementShares.FormWebUserChange.ShowDialog");
            Node.MouseDBClickAction = new JAction("test", "ManagementShares.FormWebUserChange.ShowDialog");
            Node.Name = "ChangeDataFromWeb";
            return Node;
        }

        public static JNode _TransferDataToWebNode()
        {
            JNode Node = new JNode(0, "JManagementshares");
            Node.MouseClickAction = new JAction("test", "ManagementShares.JExportDataToWeb.ShowDialog");
            Node.MouseDBClickAction = new JAction("test", "ManagementShares.JExportDataToWeb.ShowDialog");
            Node.Name = "TransferDataToWeb";
            return Node;
        }

    }
}
