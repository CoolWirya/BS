using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace CMSClassLibrary.Content
{
    class JContentTable :JTable 
    {
        public JContentTable()
            : base(JTableNamesCMS.CMSContents)
        { }

        public int CategoryCode;
        public string Title;
        public string Text;
        public DateTime Created;
        public int CreatedBy;
        public DateTime Modified;
        public int ModifiedBy;
        public bool State;
        public int Status;
        public int Access;
        public int Site;
    }
}
