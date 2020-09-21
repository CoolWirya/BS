using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ManagementShares
{
    public class JAssemblyTable:JTable
    {
        public string Title ;
        public DateTime Date ;
        public int CompanyCode;
        public string Commands;

        public JAssemblyTable()
            : base("ShareAssemblies")
        {
        }
    }
}
