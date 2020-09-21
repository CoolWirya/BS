using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace RealEstate
{
    public class JDefaultOwnersTable : JTable
    {
        public JDefaultOwnersTable()
            : base(JRETableNames.DefaultOwners)
        {

        }
        public int PCode;
        public decimal Share;
    }


    public enum JDefaultOwnersEnum
    {
        Code
      ,PCode
      ,Share
    }
}
