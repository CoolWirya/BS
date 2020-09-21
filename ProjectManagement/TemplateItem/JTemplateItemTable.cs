using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement.TemplateItem
{
  public  class JTemplateItemTable : ClassLibrary.JTable
    {
        public string Name;
        public int ParentItemCode;
        public decimal WeightPercentage;
         public int TemplateCode;
        public int Ordered;
        public JTemplateItemTable() : base("pmTemplateItem")
        {

        }
    }
}
