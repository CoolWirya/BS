using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;
using System.Runtime.Serialization;

namespace Communication.Letter
{
    [Serializable()]
    public class JCLetterCopy
    {
        #region Constructor
        public JCLetterCopy()
        {
        }
        #endregion

        public JCLetterCopy(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            Code = (int)info.GetValue("Code", typeof(int));
            letter_code = (int)info.GetValue("letter_code", typeof(int));
            copy_type = (int)info.GetValue("copy_type", typeof(int));
            receiver_post_code = (int)info.GetValue("receiver_post_code", typeof(int));
            receiver_user_code = (int)info.GetValue("receiver_user_code", typeof(int));
            receiver_full_title = (string)info.GetValue("receiver_full_title", typeof(string));
            copy_reason = (string)info.GetValue("copy_reason", typeof(string));
            register_post_code = (int)info.GetValue("register_post_code", typeof(int));
            register_user_code = (int)info.GetValue("register_user_code", typeof(int));
            register_full_title = (string)info.GetValue("register_full_title", typeof(string));
            receiver_external_code = (int)info.GetValue("receiver_external_code", typeof(int));
            receiver_subsidiaries_code = (int)info.GetValue("receiver_subsidiaries_code", typeof(int));
            send_type = (int)info.GetValue("send_type", typeof(int));
            respite_date_time = Convert.ToDateTime(info.GetValue("respite_date_time", typeof(DateTime)));
        }
        //Serialization function.
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //You can use any custom name for your name-value pair. But make sure you
            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
            // then you should read the same with "EmployeeId"
            info.AddValue("Code", Code);
            info.AddValue("letter_code", letter_code);
            info.AddValue("copy_type", copy_type);
            info.AddValue("receiver_post_code", receiver_post_code);
            info.AddValue("receiver_user_code", receiver_user_code);
            info.AddValue("receiver_full_title", receiver_full_title);
            info.AddValue("copy_reason", copy_reason);
            info.AddValue("register_post_code", register_post_code);
            info.AddValue("register_user_code", register_user_code);
            info.AddValue("register_full_title", register_full_title);
            info.AddValue("receiver_external_code", receiver_external_code);
            info.AddValue("receiver_subsidiaries_code", receiver_subsidiaries_code);
            info.AddValue("send_type", send_type);
            info.AddValue("respite_date_time", respite_date_time);
        }


        #region Properties
        public int Code { get; set; }
        public int letter_code { get; set; }
        public int copy_type { get; set; }
        public int receiver_post_code { get; set; }
        public int receiver_user_code { get; set; }
        public string receiver_full_title { get; set; }
        public string copy_reason { get; set; }
        public int register_post_code { get; set; }
        public int register_user_code { get; set; }
        public string register_full_title { get; set; }
        public int receiver_external_code { get; set; }
        public int receiver_subsidiaries_code { get; set; }
        public int send_type { get; set; }
        public DateTime respite_date_time { get; set; }
        #endregion

        #region Method
        public int Insert()
        {
            JDataBase db = new JDataBase();
            try
            {
                JCLetterCopyTable jcLetterCopyTable = new JCLetterCopyTable();
                jcLetterCopyTable.SetValueProperty(this);
                return jcLetterCopyTable.Insert();
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool Update()
        {
            JDataBase db = new JDataBase();
            try
            {
                JCLetterCopyTable jcLetterCopyTable = new JCLetterCopyTable();
                jcLetterCopyTable.SetValueProperty(this);
                return jcLetterCopyTable.Update();
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool Delete()
        {
            JCLetterCopyTable jcLetterCopyTable = new JCLetterCopyTable();
            return jcLetterCopyTable.DeleteManual("Code = " + this.Code.ToString());
        }

        public bool Delete(int code)
        {
            JCLetterCopyTable jcLetterCopyTable = new JCLetterCopyTable();
            return jcLetterCopyTable.DeleteManual("Code = " + code.ToString());
        }

        public bool DeleteByLetterCode(int letterCode)
        {
            JCLetterCopyTable jcLetterCopyTable = new JCLetterCopyTable();
            return jcLetterCopyTable.DeleteManual("letter_code = " + letterCode.ToString());
        }
        #endregion

        #region GetData
        public DataTable GetLetterCopies(int letterCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Select * From LetterCopy Where letter_code = " + letterCode);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
        #endregion
    }
}
