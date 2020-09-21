using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusManagment.CardBlackList
{

    public class JCardBlackLists : JSystem
    {
        public static string GetWebQuery()
        {
            return "select * from AUTCardBlackList";
        }
    }
}
