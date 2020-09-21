using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation
{
    class JASubsidiariesTable: ClassLibrary.JTable
    {
        public string name;
        public int    managing_director;
        public string phone_number;
        public string address;
        public string server_name;
        public string server_user;
        public string server_pass;
        public string database_name;
        public string access_code;
        public string description;

        public JASubsidiariesTable()
            : base("Subsidiaries")
        {
        }
    }
}
