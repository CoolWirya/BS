using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WebClassLibrary
{
    public class JWebSettings
    {

        private static DataTable dt;
        public static string GetKey(string keyName)
        {
            return GetKey(keyName, true);
        }
        public static string GetKey(string keyName, bool getStatic)
        {
            Load(getStatic);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow[] DR = dt.Select("KeyName = '" + keyName.Replace("'", "''") + "'");
                if (DR != null && DR.Length > 0)
                {
                    return DR[0]["KeyValue"].ToString();
                }
                else
                {
                    JWebDataBase.ExecuteQuery("Insert Into WebSettings(KeyName, KeyValue) VALUES(N'" + keyName.Replace("'", "''") + "', N'')");
                }
            }
            return null;
        }

        public static void SetKey(string keyName, string keyValue)
        {
            if (GetKey(keyName) == null)
                JWebDataBase.ExecuteQuery("Insert Into WebSettings(KeyName, KeyValue) VALUES(N'" + keyName.Replace("'", "''") + "', N'" + keyValue.Replace("'", "''") + "')");
            else
                JWebDataBase.ExecuteQuery("Update WebSettings SET KeyValue=N'" + keyValue.Replace("'", "''") + "' Where KeyName=N'" + keyName.Replace("'", "''") + "'");

        }

        public static List<Tuple<string, string>> GetAll()
        {
            Load(true);
            List<Tuple<string, string>> result = new List<Tuple<string, string>>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                    result.Add(new Tuple<string, string>(row["KeyName"].ToString(), row["KeyValue"].ToString()));
            }
            return result;
        }

        private static void Load(bool getStatic)
        {
            if (dt == null || !getStatic)
            {
                dt = null;
                dt = JWebDataBase.GetDataTable("Select * From WebSettings", false);
            }
        }
    }
}
