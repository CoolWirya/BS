using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using Globals;


namespace Automation
{
    class JAUser: JUser
    {
        public Boolean Insert()
        {
            return true;
        }

        public Boolean Delete()
        {
            return true;
        }

        public Boolean Update()
        {
            return true;
        }

        public Boolean Find(string UserName)
        {
            return true;
        }

        public Boolean GetData(string UserName)
        {
            return true;
        }

    }


    class JAUsers : JAutomation
    {
        public int[] UsersCode;

        public JAUsers()
        {

        }

    }
}
