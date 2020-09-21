using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement.Template
{
    public class JTemplateTable : ClassLibrary.JTable
    {
        public string Name;
        public decimal TotalWeight;
        public JTemplateTable() : base("pmTemplate")
        {

        }
    }
}
