using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    class JNotaryTable:JTable
    {
        public JNotaryTable()
            : base(JTableNamesLegal.NotaryTable)
        {
        }
        public int NumNotary;
        public string HeadOffice;
        public string Assistant;
        public int City;   
        public string Address;
        public string Tel;
        public string Mobile;
        public string Fax; 

    }
    enum JNotaryTableEnum
    {
        Code,
        NumNotary,
        HeadOffice,
        Assistant,
        City,
        Address,
        Tel,
        Mobile,
        Fax, 
    }
}
