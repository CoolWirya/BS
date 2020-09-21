using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finance
{
    public class JAssetLogTable: ClassLibrary.JTable
    {

        public JAssetLogTable()
            : base("FinAssetLog")
        {
        }

        public int ACode;
        public string ClassName;
        public int ObjectCode;
        public JOwnershipType Type;
        public string Comment;
    }
}