using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace CMSClassLibrary.Content
{
    class JCategoryTable:JTable
    {
        public JCategoryTable() :
            base(JTableNamesCMS.CMSCategories)
        { }

        public int ParentCode;
        public string Name;
        public string Title;
        public bool State;
        public string Parameters;
        public string Description;
        public int Access;
        public int Site;

    }
}
