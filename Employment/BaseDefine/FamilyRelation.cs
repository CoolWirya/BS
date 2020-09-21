using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{
    public class JFamilyRelation : JSubBaseDefine
    {
        public JFamilyRelation()
            : base(JBaseDefine.FamilyRelation)
        {
        }
    }

    public class JFamilyRelations : JSubBaseDefines
    {
        public JFamilyRelations()
            : base(JBaseDefine.FamilyRelation)
        {

        }
    }
}
