using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Finance
{
    public class JFinance : JSystem
    {
        public static string CurrencyString = " ریال ";
        public void ListView()
        {
            Nodes.Insert(JFStaticNode._BaseDefine());
            Nodes.Insert(JFStaticNode._ShareProfit());
           
            //Nodes.Insert(ClassLibrary.JStaticNode._ReportManagment(ClassLibrary.ProjectsEnum.Finance));

            JToolbarNode NewDocument = new JToolbarNode();
            NewDocument.Name = "Finances";
            Nodes.AddToolbar(NewDocument);
        }

        public JNode[] TreeView()
        {
            JNode[] TNodes = new JNode[3];
            TNodes[0] = JFStaticNode._BaseDefine();
            TNodes[1] = JFStaticNode._ShareProfit();
            
            //TNodes[2] = ClassLibrary.JStaticNode._ReportManagment(ClassLibrary.ProjectsEnum.Finance);

            //TNodes[1] = new JNode(0, this);
            //TNodes[1].Name = "Probate";
            //TNodes[1].MouseClickAction = new JAction("Probate", "Finance.JAssetShares.ListView");
            return TNodes;
        }
    }
}
