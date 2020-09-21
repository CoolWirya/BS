using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace StoreComplex
{
    public class JStoreComplex : ClassLibrary.JSystem
    {
        public void ListView()
        {
            Nodes.Insert(JSCStaticNodes._BaseDefine());
            Nodes.Insert(JSCStaticNodes._SCContracts());
            Nodes.Insert(JSCStaticNodes._Reports());
        }

        public JNode[] TreeView()
        {
            JNode[] N = new JNode[3];
            N[0] = JSCStaticNodes._BaseDefine();
            N[1] = JSCStaticNodes._SCContracts();
            N[2] = JSCStaticNodes._Reports();
            
            //N[1] = Legal.JContractNodes._BaseContracts(Finance.JOwnershipType.Other);
            return N;
        }
    }
}
