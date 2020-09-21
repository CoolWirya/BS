using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ShareProfit
{
    public class JSPBaseDefine: JBaseDefine
    {
            public void ListView()
            {
                JBaseDefine PaymentSourcesNode = new JBaseDefine();

                Nodes.Insert(PaymentSourcesNode.GetNode(JBaseDefine.PaymentSource));
                Nodes.Insert(PaymentSourcesNode.GetNode(JBaseDefine.PaymentType));
                Nodes.Insert(JSPStaticNode._CoursesNode());
                //Nodes.Insert(JSPStaticNode._SPDocumentsNodes());
            
            }

            public JNode[] TreeView()
            {
                JBaseDefine PaymentSourcesNode = new JBaseDefine();
                
                JNode[] gNodes = new JNode[3];
                gNodes[0] = PaymentSourcesNode.GetNode(JBaseDefine.PaymentSource);
                gNodes[1] = PaymentSourcesNode.GetNode(JBaseDefine.PaymentType);
                gNodes[2] = JSPStaticNode._CoursesNode();
                //gNodes[2] = JSPStaticNode._SPDocumentsNodes();
                return gNodes;
            }
    }
}
