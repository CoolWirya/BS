using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement.Token
{
    public class JTokenTable : ClassLibrary.JTable
    {
        public int userCode;
        public string token;
        public DateTime ExpirationDate;

        public JTokenTable():base("pmTokens")
        {

        }
    }
}
