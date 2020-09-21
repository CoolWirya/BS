using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace CMSClassLibrary.Template
{
    class JTemplateTable : JTable
    {
        public JTemplateTable():base(JTableNamesCMS.CMSTemplateStyles)
        { }
        public string Path;
        public int ExtensionCode;
        public bool IsDefault;
    }
}
