using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement.Token
{
    public class JToken : ClassLibrary.JSystem
    {
        public const string CLASSNAME = "ProjectManagement.Token.JToken";
        public int Code { get; set; }
        public int userCode { get; set; }
        public string token { get; set; }
        public DateTime ExpirationDate {get;set; }
        public JToken()
        {
        }
        public JToken(int Code)
        {
            this.GetData("SELECT TOP 1 * FROM pmTokens WHERE Code=" + Code.ToString());
        }

        public bool CheckToken(string token)
        {
           return this.GetData(string.Format("SELECT TOP 1 * FROM pmTokens WHERE ExpirationDate >= N'{0}' AND  token=N'{1}'",DateTime.Now.ToString(),token));
        }

        public Boolean GetData(string query)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery(query);
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    ClassLibrary.JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }


        public int Insert(bool checkPermission = true)
        {
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".Insert");
            if (!hasPermission)
                return 0;
            JTokenTable AT = new JTokenTable();
            AT.SetValueProperty(this);
            Code = AT.Insert(0, true);

            return Code;
        }


        public bool Update(bool checkPermission = true)
        {
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = ClassLibrary.JPermission.CheckPermission(CLASSNAME + ".Update");
            if (!hasPermission)
                return false;
            JTokenTable AT = new JTokenTable();
            AT.SetValueProperty(this);
            if (AT.Update())
                return true;
            else
                return false;
        }
    }
}
