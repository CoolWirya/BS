using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreManagement
{
    public class JStoreManagment : JSystem
    {
        public void ListView()
        {
            Nodes.Insert(JStoreStaticNode._BaseDefine());
            Nodes.Insert(JStoreStaticNode._RegisterGoods());
            Nodes.Insert(JStoreStaticNode._RegisterServices());            
            Nodes.Insert(JStoreStaticNode._RequestGood());
            Nodes.Insert(JStoreStaticNode._PayContract());
            Nodes.Insert(JStoreStaticNode._ReportBillGoods());
            Nodes.Insert(JStoreStaticNode._ReportBillContract());

            //Nodes.Insert(ClassLibrary.JStaticNode._ReportManagment(ProjectsEnum.Restaurant));
        }

        public JNode[] TreeView()
        {
            JNode[] Nodes = new JNode[7];
            Nodes[0] = JStoreStaticNode._BaseDefine();
            Nodes[1] = JStoreStaticNode._RegisterGoods();
            Nodes[2] = JStoreStaticNode._RegisterServices();            
            Nodes[3] = JStoreStaticNode._RequestGood();
            Nodes[4] = JStoreStaticNode._PayContract();
            Nodes[5] = JStoreStaticNode._ReportBillGoods();
            Nodes[6] = JStoreStaticNode._ReportBillContract();

            //Nodes[5] = ClassLibrary.JStaticNode._ReportManagment(ProjectsEnum.Restaurant);
            return Nodes;
        }
    }
}
