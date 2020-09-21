using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.AndroidKeys
{
    public class JAndroidKey:ClassLibrary.JSystem
    {
        public int code { get; set; }
      public string IMEI { get; set; }
        public string RegKey { get; set; }
        public DateTime ExpireDate { get; set; }

        public int Insert()
        {
            JAndroidKeyTable AT = new JAndroidKeyTable();
            AT.SetValueProperty(this);
            code = AT.Insert();
            return code;
        }
        public bool GetValidByKey(string key)
        {
            return GetData(String.Format(" RegKey='{0}' AND ExpireDate > '{1}' ", key,DateTime.Now.ToString()));
        }

        public bool GetData(string whereClause)
        {
            ClassLibrary.JDataBase db = ClassLibrary.JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT top 1 * FROM [AVLAndroidKey] WHERE " + whereClause);
                if (db.Query_DataReader() && db.DataReader.Read())
                {
                    ClassLibrary.JTable.SetToClassProperty(this, db.DataReader);
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
