using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Product
{
    public class JProductTable : ClassLibrary.JTable
    {
        public int code;
        public string ClassName;
        public string Name;
        public JProductTable():base("AccProduct")
        {

        }
    }
}
