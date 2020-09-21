using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement.Item
{
  public  class JItemTable : ClassLibrary.JTable
    {
        public string Name;
        public int ParentItemCode ;
        public decimal WeightPercentage ;
        public int ProjectCode ;
        public string ItemDescription;
        public int Ordered;
        public JItemTable():base("pmItems")
        {

        }
    }
}
