using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Reseller
{
    public class JResellerDomainTable : ClassLibrary.JTable
    {
        public string name;
        public string domain;
        public string regDate;
        public string adminTell;
        public string adminAddress;
        public string iconAddress;
        public string title;
        public decimal deviceRegisterPrice;
        public int adminPCode;
        public JResellerDomainTable() : base("AVLResellerDomain")
        {

        }
    }
}
