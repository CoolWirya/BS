using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Estates
{
    class JDocumentType:JSubBaseDefine
    {
        public JDocumentType()
            : base(JBaseDefineEstates.DocumentType)
        {
        }
    }

    public class JDocumentTypes : JSubBaseDefines
    {
        public JDocumentTypes()
            : base(JBaseDefineEstates.DocumentType)
        {
        }

    }
}
