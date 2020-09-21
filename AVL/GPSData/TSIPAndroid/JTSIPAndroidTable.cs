using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.GPSData.TSIPAndroid
{
    //مربوط به جدول 
    //AVLTSIPAndroidSocket
    public class JTSIPAndroidTable : ClassLibrary.JTable
    {
        public string Ip;
        public byte[] Data;
        public DateTime GetDate;
        public bool IsProceced;

        public JTSIPAndroidTable()
            : base("AVLTSIPAndroidSocket")
        {

        }
    }
}
