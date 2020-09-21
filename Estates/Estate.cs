using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ClassLibrary;

namespace Estates
{
    public class JEstate :JSystem
    {
        public void ListView()
        {            
            Nodes.Insert(JEsStaticNode._GroundsNode());
            Nodes.Insert(JEsStaticNode._BaseDefine());
            Nodes.Insert(JEsStaticNode._AggregationSeparation());
            Nodes.Insert(JEsStaticNode._TarefeNode());
            Nodes.Insert(JEsStaticNode._RequestTransferSheet());
            Nodes.Insert(ClassLibrary.JStaticNode._ReportManagment(ClassLibrary.ProjectsEnum.Estates));
          
        }

        public JNode[] TreeView()
        {
            JNode[] N = new JNode[6];
            N[0] = JEsStaticNode._BaseDefine();
            N[1] = JEsStaticNode._GroundsNode();
            N[2] = JEsStaticNode._AggregationSeparation();
            N[3] = JEsStaticNode._TarefeNode();
            N[4] = JEsStaticNode._RequestTransferSheet();
            N[5] = ClassLibrary.JStaticNode._ReportManagment(ClassLibrary.ProjectsEnum.Estates);
            return N;
        }
        
    }
}
