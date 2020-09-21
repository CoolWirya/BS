using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace RealEstate
{
    public class JRealEstate: ClassLibrary.JSystem
    {
        public void ListView()
        {
            Nodes.Insert(JREsStaticNode._BaseDefine());
            Nodes.Insert(JREsStaticNode._MarketNode());
            Nodes.Insert(JREsStaticNode._BuildNode());
            Nodes.Insert(JREsStaticNode._EnviromentsNode());
            Nodes.Insert(JREsStaticNode._RepresentativeOfTheContractNode());
            Nodes.Insert(JREsStaticNode._DefaultOwnersNode());
            Nodes.Insert(JREsStaticNode._PrintBillForm());
            Nodes.Insert(JREsStaticNode._AggregateNode());
            Nodes.Insert(JREsStaticNode._BreakDownNode());
            Nodes.Insert(JREsStaticNode._ReportUnitBuild());
            Nodes.Insert(ClassLibrary.JStaticNode._ReportManagment(ClassLibrary.ProjectsEnum.RealState));
            Nodes.Insert(JREsStaticNode._jSearchContract());
            
        }

        public JNode[] TreeView()
        {
            JNode[] N = new JNode[13];
            N[0] = JREsStaticNode._BaseDefine();
            N[1] = JREsStaticNode._MarketNode();
            N[2] = JREsStaticNode._BuildNode();
            N[3] = JREsStaticNode._EnviromentsNode();
            N[4] = JREsStaticNode._RepresentativeOfTheContractNode();
            N[5] = JREsStaticNode._DefaultOwnersNode();
            N[6] = JREsStaticNode._PrintBillForm();
            N[7] = JREsStaticNode._AggregateNode();
            N[8] = JREsStaticNode._BreakDownNode();
            N[9] = JREsStaticNode._ReportUnitBuild();
            N[10] = ClassLibrary.JStaticNode._ReportManagment(ClassLibrary.ProjectsEnum.RealState);
            N[11] = JREsStaticNode._jSearchContract();
            
            return N;
        }
    }
}

