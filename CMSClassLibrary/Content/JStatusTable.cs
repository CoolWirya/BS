using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace CMSClassLibrary.Content
{
    class JStatusTable : JTable
    {
        public JStatusTable():base(JTableNamesCMS.CMSStatus)
        { }

        public string Name;
        public bool State;
        public int Site;

    }
}
