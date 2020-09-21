using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation
{
    public class jWorkFlowTable: ClassLibrary.JTable
    {
        public string Name;
        public JNodeType NodeType;
        public int Ordered;
        public string PostCode;
        public string ClassName;
        public int DynamicClassCode;
        public string Condition;
        public string NextNodes;
        public string SQL;
        public string Action;
        public int PositionX;
        public int PositionY;

        public jWorkFlowTable()
            : base("WorkFlowNode")
        {
        }
    }
}
