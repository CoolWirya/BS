using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.GPSData
{
    public class JSocketManagerTable : ClassLibrary.JTable
    {
        public int code;
        public string Ip;
        public byte[] Data;
        public DateTime GetDate;
        public bool IsProceced;

        public JSocketManagerTable()
            : base("ClsSocketClientDataManager")
        {
        }

    }
}
