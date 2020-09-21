using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Finance
{
    class JGroupAccountsTable:JTable
    {
		public JGroupAccountsTable()
			: base(JTableNamesFinance.GroupAccounts)
        {
        }

		public string Name;
		public TypesOfAccountsGroup AccountType;
		public string Description;


    }
    enum JTotalAccountEnum
    {
		Code,
		Name,
		AccountType,
		Description,
    }

}
