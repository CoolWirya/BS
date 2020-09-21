using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finance
{

    public enum TypesOfAccountsGroup
    {
        Abalancesheet = 1 ,// ترازنامه ای
        Income = 2 ,//سود و زیانی
        Disciplinary = 3 ,//انتظامی

    }

    public class JGroupAccounts
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public TypesOfAccountsGroup AccountType { get; set; }
        public string Description { get; set; }
        public JGroupAccounts()
        {

        }

    }
}
