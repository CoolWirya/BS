using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Reseller
{
    public class JResellerDomain : ClassLibrary.JSystem
    {
        public int code { get; set; }
        public int adminPCode { get; set; }
        
      public string name{ get; set; }
        public string domain{ get; set; }
        public string regDate{ get; set; }
        public string  adminTell{ get; set; }
        public string adminAddress{ get; set; }
        public string iconAddress{ get; set; }
        public string title{ get; set; }
        public decimal deviceRegisterPrice{ get; set; }

        public JResellerDomain()
        {

        }
        public JResellerDomain(string domain)
        {
            GetData(domain);
        }
        public bool GetData(string domain)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("select top 1 * from AVLResellerDomain where domain='" + domain+"'");
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
    }
}
