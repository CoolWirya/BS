using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Estates
{
    public class JDefaultOwnersTable : JTable
    {
        public JDefaultOwnersTable()
            : base("estDefaultOwners")
        {

        }
        public int PCode;
        public decimal Share;
        public int type = 2;// Ground
    }


    public enum JDefaultOwnersEnum
    {
        Code
      ,PCode
      ,Share
    }
}
