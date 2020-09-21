using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace CMSClassLibrary.Site
{
    class JSiteTable : JTable
    {
        public JSiteTable() : base(JTableNamesCMS.CMSSites)
        { }

        public string Title;
        public string Description;
        public string Domain;
    }
}
