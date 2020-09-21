using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.UserVerify
{
    public class JUserVarifyTable: ClassLibrary.JTable
    {
        public JUserVarifyTable():
            base("AVLUserVarify")
        {

        }
        public string userID;
        public string email;
        public string phonenumber;
    }
}
