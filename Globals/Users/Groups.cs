using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Globals
{
    public class JGroup:JSystem
    {
        public int Code { get; set; }
        public string Name {get;set;}
        public int[] UsersCode = new int[0];

        public JGroup()
        {
        }

        public int AddUser(int PUserCode)
        {
            return 0;
        }

        public Boolean DeleteUser(int PUserCode)
        {
            return true;
        }

        public Boolean Update()
        {
            return true;
        }

        public Boolean Insert()
        {
            return true;
        }

        public Boolean Delete()
        {
            return true;
        }

    }
}
