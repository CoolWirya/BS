using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{
    public class JTableOrgChart : JTable
    {
        #region Properties

        public int PostCode;        

        public int ParentCode;

        #endregion


        public JTableOrgChart()
            : base("OrgChart", "ParentCode")
        {
        }
    }
}
