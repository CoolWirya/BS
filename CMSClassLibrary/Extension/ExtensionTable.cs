using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMSClassLibrary.Extension
{
    class JExtensionTable : JTable
    {
        public JExtensionTable()
            : base(JTableNamesCMS.CMSExtensions)
        { }

        //  public int Code;
        public string Name;
        public bool State;
        public string Params;
        public string Type;
        public string ClassName;

    }
}
