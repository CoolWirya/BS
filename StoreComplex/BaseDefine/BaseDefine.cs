using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreComplex
{
    public class JSCBaseDefine:JBaseDefine
    {
        public void ListView()
        {
            Nodes.Insert(JSCStaticNodes._SCStorages());
            Nodes.Insert(JSCStaticNodes._SCServices());
            Nodes.Insert(JSCStaticNodes._SCGoods());
            Nodes.Insert(JSCStaticNodes._Goods());
        }

        public JNode[] TreeView()
        {
            JNode[] gNodes = new JNode[4];
            gNodes[0] = JSCStaticNodes._SCStorages();
            gNodes[1] = JSCStaticNodes._SCServices();
            gNodes[2] = JSCStaticNodes._SCGoods();
            gNodes[3] = JSCStaticNodes._Goods();
            return gNodes;
        }

     

    }
}
