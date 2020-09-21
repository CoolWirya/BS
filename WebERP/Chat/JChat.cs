using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    public class JChat : ClassLibrary.JSystem
    {
        public int code { get; set; }
        public string message { get; set; }
        /// <summary>
        /// This is made for avl project which the sender  and receiver is IMEI of device
        /// Thats why sender and recevier are string and nvarchar(20) in database
        /// </summary>
        public string sender { get; set; }
        public string senderName { get; set; }
        public string receiver { get; set; }
        public DateTime registerDate { get; set; }
        public int GroupID { get; set; }
        
        public int messageType { get; set; }
        public bool Delete(int CODE=0)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            if(CODE==0)
            DB.setQuery("delete from AVLChat where code=" + code.ToString());
            else
                DB.setQuery("delete from AVLChat where code=" + CODE);
            if (DB.Query_Execute(true)>1)

            //JChatTable AT = new JChatTable();
            //AT.SetValueProperty(this);
            //if (AT.Delete())
            {
             return true;
            }
            else return false;
        }

        public int Insert()
        {
            JChatTable AT = new JChatTable();
            AT.SetValueProperty(this);
            code = AT.Insert();
            return code;
        }
    }
    public class JChats:ClassLibrary.JSystem
    {
        public static System.Data.DataTable GetMessages(string imei,string gpID)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = string.Format(@"SELECT *  FROM AVLChat where receiver='{0}' AND GroupID={1}", imei,gpID);
                if(gpID=="0")
                    query= string.Format(@"SELECT *  FROM AVLChat where receiver='{0}'", imei);
                DB.setQuery(query);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }


    }
    public class JChatTable : ClassLibrary.JTable {
        public JChatTable() : base("AVLChat") { }
        public string message;
        public string sender;
        public string senderName;
        public string receiver;
        public DateTime registerDate;
        public int GroupID;
        public int messageType;
    }
}
