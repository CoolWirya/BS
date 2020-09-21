using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.GPSData.TSIPAndroid
{
    //مربوط به جدول 
    //AVLTSIPAndroidSocket
    public class JTSIPAndroid:ClassLibrary.JSystem
    {
        public int Code { get; set; }
        public string Ip { get; set; }
        public byte[] Data { get; set; }
        public DateTime GetDate { get; set; }
        public bool IsProceced { get; set; }

        public bool Proceced(int Code)
        {
            ClassLibrary.JDataBase db = ClassLibrary.JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("UPDATE [AVLArea] SET [IsProceced]='true' WHERE [Code] = " + Code);
                if (db.Query_Execute() >= 0)
                {
                    return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
