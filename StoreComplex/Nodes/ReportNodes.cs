using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreComplex
{
    public class JReportNodes : JBaseDefine
    {
        public void ListView()
        {
            Nodes.Insert(JSCStaticNodes._RenewReport());
            Nodes.Insert(JSCStaticNodes._RenewPrivateReport());
            Nodes.Insert(JSCStaticNodes._GeneralReport());
        }

        public JNode[] TreeView()
        {
            JNode[] gNodes = new JNode[3];
            gNodes[0] = JSCStaticNodes._RenewReport();
            gNodes[1] = JSCStaticNodes._RenewPrivateReport();
            gNodes[2] = JSCStaticNodes._GeneralReport();
            return gNodes;
        }

    }
}
