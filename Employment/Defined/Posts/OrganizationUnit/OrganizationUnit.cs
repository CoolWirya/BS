using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{
    class JEOrganizationUnit: JESubBaseDefine
    {
        /// <summary>
        /// واحدهای سازمانی
        /// </summary>
        public JEOrganizationUnit()
            : base(JEBaseDefine.OrganizationUnitCode)
        {
        }
    }
}
