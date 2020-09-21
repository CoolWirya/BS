using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finance
{
    public class JComparativeCodeTable:JTable
    {
        public string ClassName;
        public int ObjectCode;
        public int CreatorPostCode;
        public int CreatorUserCode;
        public string Comment;
        public int Status;
        public int DivideType;
        public decimal Value;
        public int State;

        public JComparativeCodeTable()
            : base("finComparativeCode")
        {
        }
    }
}
