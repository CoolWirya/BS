using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{
    public class JEStaticAction : JStaticAction
    {
        public static JAction _TreeDBClick()
        {
            return new JAction("ShowOrgChart", "Employment.JEChart.ShowForm");
        }
        public static JAction _PersonPostDBClick()
        {
            return new JAction("ShowForm", "Employment.JPersonPost.ShowForm");
        }
        public static JAction _ContractDBClick()
        {
            return new JAction("ShowForm", "Employment.JEContract.ShowForm");
        }
        public static JAction _ContractDelete(int pCode)
        {
            return new JAction("Delete", "Employment.JEContract.Delete", new object[] { pCode }, null, false);
        }
        
        public static JAction _PostNew()
        {
            return new JAction("ShowForm", "Employment.JEPost.ShowForm");
        }
    }
}
