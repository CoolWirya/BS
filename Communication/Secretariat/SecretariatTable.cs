using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Communication
{
    class JCSecretariatTable: ClassLibrary.JTable
    {
        public string Name;
        public int Strg_Code;
        public int Manager_user_post_code;
        public string Prifix;
        public string Suffix;

        public JCSecretariatTable()
            : base("secretariat")
        {            
        }
    }
}
