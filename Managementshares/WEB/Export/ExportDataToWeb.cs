using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;
using System.Security.Cryptography;

namespace ManagementShares
{
    public class JExportDataToWeb
    {
        string prefixTableName = "te216_";
        /// <summary>
        /// اطلاعات سهامداران
        /// </summary>
        /// <param name="PCode"></param>
        /// <returns></returns>
        private DataTable GetAllPerson()
        {
            string query = "SELECT * FROM clsAllPerson WHERE Code IN (SELECT PCode FROM ShareSheet WHERE Status = 1)";
            //if (maxCode>-1)
            query += " AND Code IN (SELECT ChangedCode FROM ShareWebLog WHERE Applyed = 0 AND Operation = 'i')";
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(query);
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// کدها را از دیتاتیبل برمیگرداند
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        //private string GetCodes(DataTable table)
        //{
        //    string codes = "";
        //    if(table!=null)
        //        foreach (DataRow row in table.Rows)
        //        {
        //            codes += row["Code"].ToString() + ",";
        //        }
        //    if (codes.Length > 0)
        //        return (codes.Substring(0, codes.Length - 1));
        //    else
        //        return codes;
        //}
         
     
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int GetMaxUserCodeWeb()
        {
            ClassLibrary.JConnection Cn = new ClassLibrary.JConnection();
            if (Cn.GetData("ManagementShares.WEB.JWebUserChange", 0))
            {
                ClassLibrary.JMySQLDataBase MyDB = new ClassLibrary.JMySQLDataBase(Cn);
                try
                {
                    MyDB.setQuery(string.Format(" SELECT Max(id) FROM {0}users ", prefixTableName));
                    return Convert.ToInt32(MyDB.Query_ExecutSacler());
                }
                catch(Exception ex)
                {
                    return -1;
                }
                finally
                {
                    MyDB.Dispose();
                }
            }
            else
                return -1;
        }
        
        /// <summary>
        /// ایجاد پسورد کد شده با استفاده از شماره شناسنامه 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string GeneratePassword(string input)
        {
            string salt = "abcdefghijklmnopqrstuvwxyz";
            int len = salt.Length;
            string saltPass = "";
            Random rnd = new Random(10000000);
            for (int i = 0; i < 32; i++)
            {
                saltPass += salt[rnd.Next(0, len - 1)];
            }
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input); //+ ":" + saltPass
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return (sb.ToString() + ":").ToLower(); //+saltPass
        }
        /// <summary>
        /// دستور درج کاربران
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private string GetInsertUserCommand(DataTable table)
        {
            string query = "";
            foreach (DataRow row in table.Rows)
            {
                ///
                //7d2a383e54274888b4b73b97e1aaa491:abcdefghijklmnopqrstuvwxyz
                string Name = row["Name"].ToString();
                string id = row["Code"].ToString();
                string userName = row["SharePCode"].ToString();
                string pass = GeneratePassword(row["IDNo"].ToString());
                string email = "U@sepad.org";
                string userType = "deprecated";
                query += string.Format(@" INSERT INTO {9}users (`id`, `username`, `name`, `password`, `email`, `usertype`, `block`, `activation`, `sendEmail`) VALUES
                 (""{0}"", ""{1}"",""{2}"",""{3}"",""{4}"",""{5}"",""{6}"",""{7}"", ""{8}"") ",id,userName, Name , pass, email, userType, 0, 0, 1, prefixTableName);

                query += string.Format(@" INSERT INTO {2}user_usergroup_map (`user_id`, `group_id`) VALUES
                 (""{0}"",""{1}"") ", userName, userName, prefixTableName);
            }
            return query;
        }

        private string GetInsertCommand(DataTable table, string TableName)
        {
            string query = "";
            string cols = "";
            string values = "";
            foreach (DataColumn col in table.Columns)
            {
                cols += "`" + col.ColumnName + "`,";
            }
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    values += "\"" + row[col.ColumnName].ToString() + "\",";
                }

                query += string.Format(" INSERT INTO {0} ({1}) VALUES({2}) ", TableName, cols.Substring(0, cols.Length - 1), values.Substring(0, values.Length - 1));
            }
            return query;
        }

        private string GetUpdateCommand(DataTable table, string TableName)
        {
            string query = "";
            string cols = "";
            string values = "";
            foreach (DataColumn col in table.Columns)
            {
                cols += "`" + col.ColumnName + "`,";
            }
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    values += "\"" + row[col.ColumnName].ToString() + "\",";
                }
                query += string.Format(" INSERT INTO {0} ({1}) VALUES({2}) ", TableName, cols.Substring(0, cols.Length - 1), values.Substring(0, values.Length - 1));
            }
            return query;
        }


        /// <summary>
        /// اشخاصی که در سایت وجود ندارند
        /// </summary>
        /// <returns></returns>
        private DataTable GetNewPerson()
        {
            //int maxCode = GetMaxUserCodeWeb();
            return GetAllPerson();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public  bool ExportToWeb()
        {
            if (JPermission.CheckPermission("ManagementShares.JExportDataToWeb.ExportToWeb"))
            {
                string exportCommad = GetExportCommand();
                ClassLibrary.JConnection Cn1 = new ClassLibrary.JConnection();
                if (Cn1.GetData("ManagementShares.WEB.JWebUserChange", 0))
                {
                    ClassLibrary.JMySQLDataBase MyDB = new ClassLibrary.JMySQLDataBase(Cn1);
                    if (!string.IsNullOrEmpty(exportCommad))
                    {
                        MyDB.setQuery(exportCommad);
                        MyDB.Query_Execute();
                    }
                }
                /// انتخاب اشخاص جدید
                DataTable newPerson = GetNewPerson();
                if (newPerson != null)
                {
                    /// درج کاربران برای اشخاص جدید
                    ClassLibrary.JConnection Cn = new ClassLibrary.JConnection();
                    if (Cn.GetData("ManagementShares.WEB.JWebUserChange", 0))
                    {
                        ClassLibrary.JMySQLDataBase MyDB = new ClassLibrary.JMySQLDataBase(Cn);
                        try
                        {
                            string insertCommand = GetInsertUserCommand(newPerson);
                            if (!string.IsNullOrEmpty(insertCommand))
                            {
                                MyDB.setQuery(insertCommand);
                                //  MyDB.beginTransaction("InsertUsers");
                                MyDB.Query_Execute();
                                //  MyDB.Commit();
                                return true;
                            }
                        }
                        catch (Exception ex)
                        {
                            return false;
                            //   MyDB.Rollback("InsertUsers");
                        }
                        finally
                        {
                            MyDB.Dispose();
                            string query = " UPDATE  ShareWebLog Set Applyed  = 0 ";
                            JDataBase db = new JDataBase();
                            try
                            {
                                db.setQuery(query);
                                db.Query_Execute();
                            }
                            finally
                            {
                                db.Dispose();
                            }
                        }
                    }
                }

            }
            return false;
        }

        public void ShowDialog()
        {
            JExportDataToWebForm form = new JExportDataToWebForm();
            form.ShowDialog();
        }

        /// <summary>
        /// ساخت دستورات بروزرسانی وب سایت با توجه به لاگ
        /// </summary>
        /// <returns></returns>
        public string GetExportCommand()
        {
            string query = " SELECT * FROM ShareWebLog WHERE Applyed  = 0 ";
            string exportCommand = "";
            JDataBase db = new JDataBase();
            DataTable webLog;
            DataTable tableToExport;
            try
            {
                db.setQuery(query);
                webLog = db.Query_DataTable();
                foreach (DataRow row in webLog.Rows)
                {
                    db.setQuery(string.Format(" SELECT * FROM {0} WHERE Code = {1} ", row["TableName"].ToString(), row["ChangedCode"].ToString()));
                    tableToExport = db.Query_DataTable();
                    if (tableToExport.Rows.Count > 0)
                    {
                        string tableName = row["TableName"].ToString();
                        string fieldNames = "";
                        string fieldValues = "";
                        string fieldUpdate = "";
                        foreach (DataColumn col in tableToExport.Columns)
                        {
                            fieldNames += col.ColumnName + ",";
                            fieldValues += "'" +tableToExport.Rows[0][col.ColumnName].ToString() + "',";
                            fieldUpdate += col.ColumnName + " = '"  + tableToExport.Rows[0][col.ColumnName].ToString() + "',";
                        }
                        fieldNames = fieldNames.Substring(0, fieldNames.Length - 1);
                        fieldValues = fieldValues.Substring(0, fieldValues.Length - 1);
                        fieldUpdate = fieldUpdate.Substring(0, fieldUpdate.Length - 1);
                        if (Convert.ToChar(row["Operation"]) == 'i')
                            exportCommand += string.Format(" INSERT INTO {0} ({1}) VALUES ({2})",tableName, fieldValues, fieldNames)+";";
                        if (Convert.ToChar(row["Operation"]) == 'u')
                            exportCommand += string.Format(" UPDATE {0} SET {1} WHERE Code = {2} ", tableName, fieldUpdate, row["ChangedCode"].ToString()) + ";";
                        if (Convert.ToChar(row["Operation"]) == 'd')
                            exportCommand += string.Format(" DELETE FROM {0} WHERE Code = {1}", tableName, row["ChangedCode"].ToString()) + ";";
                    }
                }
                return exportCommand;
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
