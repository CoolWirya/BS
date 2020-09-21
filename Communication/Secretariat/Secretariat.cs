using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Communication
{
    /// <summary>
    /// کلاس دبیرخانه برای مدیریت اطلاعات یک دبیرخانه
    /// </summary>
    public class JCSecretariat : JCommunication
    {
        override public string ToString()
        {
            return Name;
        }
        // سازنده های کلاس
        #region Constructors
        /// <summary>
        /// سازنده
        /// </summary>
        public JCSecretariat()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCode"></param>
        public JCSecretariat(int pCode)
        {
            GetData(pCode);
        }
        #endregion Constructors
        //properties
        #region Properties
        /// <summary>
        /// کد رکورد در جدول
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// نام دبیرخانه
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// کد مخزن شماره نامه
        /// </summary>
        public int Strg_Code { get; set; }
        /// <summary>
        /// نام مخزن شماره نامه
        /// </summary>
        public string Storage_Name { get; set; }
        /// <summary>
        /// کد پست مدیر دبیرخانه
        /// </summary>
        public int Manager_user_post_code { get; set; }
        /// <summary>
        /// پیشوند شماره نامه
        /// </summary>
        public string Prifix { get; set; }
        /// <summary>
        /// پسوند شماره نامه
        /// </summary>
        public string Suffix { get; set; }

        #endregion properties
        // Insert , Update , Delete
        #region BaseFunctions
        /// <summary>
        /// درج دبیرخانه جدید در بانک اطلاعاتی
        /// </summary>
        /// <returns>بر می گرداند True در صورت درج صحیح مقدار</returns>
        public bool Insert(DataTable pdtPerson)
        {
            JDataBase tempDb = new JDataBase();
            JCSecretariatTable JST = new JCSecretariatTable();
            JsecretariatUser tmpUser = new JsecretariatUser();
            try
            {
                if (JPermission.CheckPermission("Communication.JCSecretariat.Insert"))
                {
                    tempDb.beginTransaction("InsertSecretariat");
                    if (Find(Code, tempDb) || Find(Name))
                    {
                        tempDb.Rollback("InsertSecretariat");
                        return false;
                    }
                    JST.SetValueProperty(this);
                    Code = JST.Insert(tempDb);
                    if (Code > 0)
                    {
                        if (pdtPerson==null || tmpUser.Update(pdtPerson, Code, tempDb))
                        {
                            if (tempDb.Commit())
                            {
                                Nodes.RefreshNode();
                                //Nodes.DataTable.Merge(JCSecretariats.GetDataTable(Code));
                                return true;
                            }
                            else
                            {
                                tempDb.Rollback("UpdateSecretariat");
                                return false;
                            }
                        }
                        else
                        {
                            tempDb.Rollback("InsertSecretariat");
                            return false;
                        }
                    }
                    else
                    {
                        tempDb.Rollback("InsertSecretariat");
                        return false;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                tempDb.Rollback("InsertSecretariat");
                return false;
            }
            finally
            {
                tempDb.Dispose();
                JST.Dispose();
            }
        }
        /// <summary>
        /// ویرایش دبیرخانه
        /// </summary>
        /// <returns></returns>
        public bool Update(DataTable pdtPerson)
        {
            JDataBase tempDb = new JDataBase();
            JsecretariatUser tmpUser = new JsecretariatUser();
            JCSecretariatTable JST = new JCSecretariatTable();
            try
            {
                if (JPermission.CheckPermission("Communication.JCSecretariat.Update"))
                {
                    tempDb.beginTransaction("UpdateSecretariat");
                    if (Find(Code, tempDb))
                    {                        
                        JST.SetValueProperty(this);
                        if (JST.Update(tempDb))
                        {
                            if (tmpUser.Update(pdtPerson, Code, tempDb))
                            {
                                if (tempDb.Commit())
                                {
                                    //Nodes.Refresh(GetNode());
                                    return true;
                                }
                                else
                                {
                                    tempDb.Rollback("UpdateSecretariat");
                                    return false;
                                }
                            }
                            else
                            {
                                tempDb.Rollback("UpdateSecretariat");
                                return false;
                            }
                        }
                        else
                        {
                            tempDb.Rollback("UpdateSecretariat");
                            return false;
                        }
                    }
                    else
                    {
                        tempDb.Rollback("UpdateSecretariat");
                        return false;                     
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                tempDb.Rollback("UpdateSecretariat");
                return false;
            }
            finally
            {
                tempDb.Dispose();
                JST.Dispose();
            }
        }
        /// <summary>
        /// حذف دبیرخانه از بانک اطلاعاتی
        /// </summary>
        /// <returns></returns>
        public bool Delete(int pCode)
        {
            JDataBase tempDb = new JDataBase();
            JCSecretariatTable JST = new JCSecretariatTable();
            JsecretariatUserTable tmpUser = new JsecretariatUserTable();
            try
            {
                if (JPermission.CheckPermission("Communication.JCSecretariat.Delete"))
                {
                    tempDb.beginTransaction("DeleteSecretariat");
                    if (Find(pCode, tempDb))
                    {
                        if (JMessages.Message(JLanguages._Text("Do you want to remove this secreatariat"), JLanguages._Text("Question"), JMessageType.Question) != System.Windows.Forms.DialogResult.Yes)
                            return false;
                        GetData(pCode);
                        JST.SetValueProperty(this);
                        if (tmpUser.DeleteManual(" SecCode=" + Code.ToString(), tempDb) || tmpUser.GetDeleteCount() == 0)
                        {
                            if (JST.Delete(tempDb))
                            {
                                if (tempDb.Commit())
                                {
                                    //Nodes.Delete(GetNode());
                                    return true;
                                }
                                else
                                {
                                    tempDb.Rollback("DeleteSecretariat");
                                    return false;
                                }
                            }
                            else
                            {
                                tempDb.Rollback("DeleteSecretariat");
                                return false;
                            }
                        }
                        else
                        {
                            tempDb.Rollback("DeleteSecretariat");
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                tempDb.Rollback("DeleteSecretariat");
                return false;
            }
            finally
            {
                tempDb.Dispose();
            }
            return false;
        }
        #endregion BaseFunctions
        // GetInfo
        #region GetInfo
        public Boolean Find(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                return Find(pCode, db);
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// جستجوی  دبیرخانه
        /// </summary>
        /// <param name="PName"></param>
        /// <returns></returns>
        public Boolean Find(int pCode, JDataBase db)
        {
            //JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM secretariat WHERE [Code]=" + JDataBase.Quote(pCode.ToString()));
                db.Query_DataReader();
                return db.DataReader.HasRows;
            }
            finally
            {
                //db.Dispose();
            }
        }
        /// <summary>
        /// جستجوی  دبیرخانه
        /// </summary>
        /// <param name="PName"></param>
        /// <returns></returns>
        public Boolean Find()
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            string strSQL = "SELECT * FROM secretariat WHERE 1=1 ";
            if (Code != null) strSQL += " AND Code = " + Code.ToString();
            if (Name != null) strSQL += " AND name = '" + Name + "'";
            if (Storage_Name != null) strSQL += " AND str_code = " + Storage_Name.ToString();

            try
            {
                db.setQuery(strSQL);
                db.Query_DataReader();
                return db.DataReader.HasRows;
            }
            finally
            {
                db.Dispose();
            }
        }
        public Boolean Find(string PName)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                return Find(PName, db);
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean Find(string PName,JDataBase db)
        {
            //JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM secretariat WHERE [name]=" + JDataBase.Quote(PName));
                db.Query_DataReader();
                return db.DataReader.HasRows;
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean GetData(int pCode, JDataBase db)
        {
            try
            {
                db.setQuery("SELECT * FROM secretariat WHERE [Code]=" + JDataBase.Quote(pCode.ToString()));
                db.Query_DataReader();
                if (db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
             //   db.Dispose();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean GetData(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM secretariat WHERE [Code]=" + JDataBase.Quote(pCode.ToString()));
                db.Query_DataReader();
                if (db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {

                db.Dispose();
            }
        }
                /// <summary>
        /// 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public static int GetDataByUserPCode(int pUserPostCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery(@"
select SecCode from secretariat s inner join secretariatUser su on s.Code = su.SecCode where su.Pcode = " + JDataBase.Quote(JMainFrame.CurrentPersonCode.ToString()) +
                      @" union
                              select Code from secretariat s where s.manager_user_post_code = " + JDataBase.Quote(pUserPostCode.ToString()));

                DataTable dt = db.Query_DataTable();
                if (dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0][0]);
                return 0;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static DataTable GetScretariatCode(int pUserPostCode , JDataBase db)
        {
            try
            {
                db.setQuery("SELECT * FROM secretariat WHERE manager_user_post_code=" + JDataBase.Quote(pUserPostCode.ToString()));
                DataTable dt = db.Query_DataTable();
                return dt;
            }
            finally
            {
            }
        }

        public static DataTable GetScretariatUserCodes(int pUserPostCode, JDataBase db)
        {
            try
            {
                db.setQuery(@"select s.* from secretariat s inner join secretariatUser su on s.Code = su.SecCode where su.Pcode = " + JDataBase.Quote(pUserPostCode.ToString()) +
                              @" union
                              select * from secretariat s where s.manager_user_post_code = " + JDataBase.Quote(pUserPostCode.ToString()));
                DataTable dt = db.Query_DataTable();
                return dt;
            }
            finally
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean GetDataByUserPostCode(int pUser_Post_Code)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM secretariat WHERE manager_user_post_code=" + JDataBase.Quote(pUser_Post_Code.ToString()));
                db.Query_DataReader();
                if (db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// لیست دبیرخانه ها
        /// </summary>
        public string ListView()
        {
            return null;
        }
        /// <summary>
        /// لیست کاربران دبیرخانه
        /// </summary>
        public void ListUsers()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public int GetRegister_NO(int pCode, JDataBase DB)
        {
            try
            {
                if (GetData(pCode))
                {
                    DB.setQuery("update storageletterno set last_register_no = last_register_no +1  WHERE Code=" + Strg_Code.ToString() +
                        "SELECT SL.last_register_no FROM storageletterno SL WHERE SL.Code=" + Strg_Code.ToString());
                    int Num = (int)DB.Query_ExecutSacler();
                    while (Num == 0)
                    {
                        GetRegister_NO(pCode, DB);
                    }
                    return Num;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
            finally
            {
            }
        }

        /// <summary>
        /// لیست دبیرخانه ها را بر میگرداند
        /// </summary>
        /// <param name="pStorageLetterNo">در صورتی که کد مخزن صفر باشد تمامی دبیرخانه ها را بر میگرداند  در غیر این صورت ، دبیرخانه هایی که از آن مخزن استفاده میکنند را می دهد</param>
        /// <returns>اطلاعات دبیرخانه</returns>        
        public DataTable GetSecretariat(int pStorageLetterNo)
        {
            return GetSecretariat(pStorageLetterNo, "");
        }

        /// <summary>
        /// لیست دبیرخانه ها را بر میگرداند
        /// </summary>
        /// <param name="pStorageLetterNo">در صورتی که کد مخزن صفر باشد تمامی دبیرخانه ها را بر میگرداند  در غیر این صورت ، دبیرخانه هایی که از آن مخزن استفاده میکنند را می دهد</param>
        /// <returns>اطلاعات دبیرخانه</returns>        
        public DataTable GetSecretariat(int pStorageLetterNo, string pFieldsName)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {

                if (pFieldsName.Length < 1)
                    pFieldsName = JCSecretariatTable.getFields();
                string strSql = "SELECT " + pFieldsName + " FROM secretariat ";
                if (pStorageLetterNo > 0)
                {
                    strSql += " where Code = " + pStorageLetterNo;
                }
                DB.setQuery(strSql);
                return DB.Query_DataTable();
            }
            finally
            {
                DB.Dispose();
            }
        }

        #endregion GetInfo
        // Node
        #region Node
        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "Communication.JCSecretariat");
            Node.Name = pRow["name"].ToString();
            Node.Icone = JImageIndex.Default.GetHashCode();
            //اکشن ویرایش
            JAction editAction = new JAction();

            if (pRow != null)
                editAction = new JAction("edit...", "Communication.JCSecretariat.ShowDialog", null , new object[] { Node.Code });

            //اکشن حذف
            JAction deleteaction = new JAction("Delete...", "Communication.JCSecretariat.DeleteSecretariat", new object[] { Node.Code }, null);
            Node.DeleteClickAction = deleteaction;
            //اکشن جدید
            JAction newAction = new JAction("دبیرخانه جدید...", "Communication.JLetters.ShowDialog", null, null);
            Node.MouseDBClickAction = editAction;

            JPopupMenu pMenu = new JPopupMenu("Communication.JCSecretariat", Node.Code);

            pMenu.Insert(editAction);
            pMenu.Insert(deleteaction);
            pMenu.Insert(newAction);
            Node.Popup = pMenu;
            return Node;

        }
        #endregion Node

        public void ShowDialog()
        {
            ShowDialog(Code);
        }

        public void ShowDialog(int pCode)
        {
            JfrmSecretariat fsm = new JfrmSecretariat(pCode);
            fsm.ShowDialog();
        }
    }
    /// <summary>
    /// لیست دبیرخانه ها
    /// </summary>
    public class JCSecretariats : JCommunication
    {
        //properties
        #region Properties
        private string _SQL = "SELECT [Code],[name] FROM secretariat %WHERE% ORDER BY [name]";

        private JCSecretariat[] _Items;
        public JCSecretariat[] Items
        {
            get
            {
                return _Items;
            }
        }

        #endregion properties
        // سازنده های کلاس
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public JCSecretariats()
            : this("")
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        public JCSecretariats(string where)
        {
            if (where.Length > 0)
                where = "AND" + where;
            _SQL = _SQL.Replace("%WHERE%", "WHERE 1=1 " + where);
            _getItems();
        }
        #endregion Constructors
        // GetInfo
        #region GetInfo



        /// <summary>
        /// خواندن اطلاعات دبیرخانه ها از بانک اطلاعاتی و و قرار دادن در متغیر 
        /// </summary>
        private void _getItems()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(_SQL);
                DB.Query_DataSet();
                _Items = new JCSecretariat[DB.DataSet.Tables[0].Rows.Count];
                int count = 0;
                foreach (DataRow DR in DB.DataSet.Tables[0].Rows)
                {
                    Items[count] = new JCSecretariat();
                    Items[count].GetData(int.Parse(DR["Code"].ToString()));
                    count++;
                }
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static DataTable GetDataTable(int pCode)
        {
            string Where = " where 1=1 ";
            if (pCode != 0)
                Where = Where + " And Code=" + pCode;
            string Query = "select * from Secretariat " + Where;
                //" And " + JPermission.getObjectSql("Meeting.JCommissions.GetDataTable", ".CommissionCode");
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                return db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static DataTable GetDataTable()
        {
            string Query = "select * from Secretariat";
            //" And " + JPermission.getObjectSql("Meeting.JCommissions.GetDataTable", ".CommissionCode");
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(Query);
                return db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        #endregion GetInfo
        // View Nodes
        #region View
        public void ListView()
        {
            //JAction InsertAction = new JAction("New", "Communication.JCSecretariat.InsertForm");
            //Nodes.GlobalMenuActions = new JPopupMenu("Communication.JCSecretariat", 0);
            //Nodes.GlobalMenuActions.Insert(InsertAction);

            //foreach (JCSecretariat Sec in Items)
            //{
            //    Nodes.Insert(Sec.GetNode());
            //}

            //JToolbarNode TN = new JToolbarNode();
            //TN.Click = InsertAction;
            //TN.Icon = JImageIndex.Add;

            //Nodes.AddToolbar(TN);
            JSystem.Nodes.ObjectBase = new JAction("GetSecretariat", "Communication.JCSecretariat.GetNode");
            JSystem.Nodes.DataTable = GetDataTable();

            JAction newAction = new JAction("دبیرخانه جدید...", "Communication.JCSecretariat.ShowDialog", null, null);

            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = " دبیرخانه جدید...";
            TN.Click = newAction;
            JSystem.Nodes.AddToolbar(TN);

        }

        public static JNode GetSecretariatNode()
        {
            if (JPermission.CheckPermission("Communication.JCSecretariat.ShowDialog", false))
            {

                JNode Node = new JNode(0, "Communication.JCSecretariats");
                Node.Name = "دبیرخانه";


                JAction Ac = new JAction("Form", "Communication.JCSecretariats.ListView", null, null, true);
                Node.MouseClickAction = Ac;
                Node.MouseDBClickAction = Ac;
                return Node;
            }
            return null;
        }


        public JNode[] TreeView()
        {
            return null;
        }
        #endregion View
    }
}
