using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.AndroidKeys
{
    public class JAndroidKeyTable : ClassLibrary.JTable
    {
        public string IMEI;
        public string RegKey;
        public DateTime ExpireDate;
        public JAndroidKeyTable() : base("AVLAndroidKey")
        {

        }
    }
}
