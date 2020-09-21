using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    class JJudicialBranchTable:JTable
    {
        public JJudicialBranchTable()
            : base(JTableNamesLegal.JudicialBranch)
        {
        }
        #region field

        public string Name;
        public int JudicialComplex;
        public int City;
        public string Tel;
        public string Fax;
        public string Address;
        
        #endregion 
    }
    enum JJudicialBranchEnum
    {
        Code,
        Name,
        JudicialComplex,
        City,
        Tel,
        Fax,
        
    }
}
