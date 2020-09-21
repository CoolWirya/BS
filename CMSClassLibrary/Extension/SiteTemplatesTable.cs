using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace CMSClassLibrary.Extension
{
    class SiteTemplatesTable: JTable
    {
        public SiteTemplatesTable() :base(JTableNamesCMS.CMSSiteTemplates)
        { }

        public int SiteCode;
        public int StyleCode;
    }
}
