using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Refer
{
    public class JGroupNameTable:ClassLibrary.JTable
    {

        public JGroupNameTable()
            :base("RefGroupName")
        {

        }
        public int PostCode;
        public string GroupName;
        public int PostCodeGuest;

    }
}
