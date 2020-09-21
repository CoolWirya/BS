using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreManagement
{
    public class JGoodsBaseDefine : JBaseDefine
    {
        public void ListView()
        {
            Nodes.Insert(JStoreStaticNode._GoodsGroupNode());
            Nodes.Insert(JStoreStaticNode._GoodsTypeNode());
            Nodes.Insert(JStoreStaticNode._MeasureNode());
            Nodes.Insert(JStoreStaticNode._StorageTypeNode());            
        }

        public JNode[] TreeView()
        {
            JNode[] TNodes = new JNode[5];
            TNodes[0] = JStoreStaticNode._GoodsGroupNode();
            TNodes[1] = JStoreStaticNode._GoodsTypeNode();
            TNodes[2] = JStoreStaticNode._MeasureNode();
            TNodes[3] = JStoreStaticNode._StorageTypeNode();
            return TNodes;
        }
    }
}
