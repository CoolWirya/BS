using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Automation
{
    public class JASubsidiaries :JSystem
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
        public JASubsidiaries()
        {
        }
        #endregion Constructors
        //properties
        #region Properties
        /// <summary>
        /// کد رکورد در جدول
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// نام شرکت
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///   مدیر شرکت
        /// </summary>
        public string managing_director { get; set; }
        /// <summary>
        /// تلفن
        /// </summary>
        public string phone_number { get; set; }
        /// <summary>
        /// آدرس
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// ناو سرور
        /// </summary>
        public string server_name { get; set; }
        /// <summary>
        /// نام کاربری بانک اطلاعاتی
        /// </summary>
        public string server_user { get; set; }
        /// <summary>
        /// کلمه رمز بانک اطلاعاتی
        /// </summary>
        public string server_pass { get; set; }
        /// <summary>
        /// نام بانک اطلاعاتی
        /// </summary>
        public string database_name { get; set; }
        /// <summary>
        /// کد دسترسی سریع
        /// </summary>
        public int access_code { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string description { get; set; }
        #endregion properties
        // Insert , Update , Delete
        #region BaseFunctions
        /// <summary>
        /// درج شرکت اقماری جدید در بانک اطلاعاتی
        /// </summary>
        /// <returns>بر می گرداند True در صورت درج صحیح مقدار</returns>
        public bool Insert()
        {
            if (Find(Code) || Find(Name))
                return false;
            JASubsidiariesTable JST = new JASubsidiariesTable();
            JST.SetValueProperty(this);
            int mCode = JST.Insert();
            if (mCode != 0)
            {
                Code = mCode;
                Nodes.Insert(GetNode());
                return true;
            }
            return false;
        }
        /// <summary>
        /// ویرایش اطلاعات شزکت اقماری
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            if (Find(Code))
            {
                JASubsidiariesTable JST = new JASubsidiariesTable();
                JST.SetValueProperty(this);
                //JST.
                Nodes.Refresh(GetNode());
                return JST.Update();
            }
            return false;
        }
        /// <summary>
        /// حذف شرکت اقماری از بانک اطلاعاتی
        /// </summary>
        /// <returns></returns>
        public bool Delete(int pCode)
        {
            if (Find(pCode))
            {
                if (JMessages.Message(JLanguages._Text("Do you want delete this Item?"), JLanguages._Text("Question"), JMessageType.Question) != System.Windows.Forms.DialogResult.Yes)
                    return false;
                GetData(pCode);
                JASubsidiariesTable JST = new JASubsidiariesTable();
                JST.SetValueProperty(this);
                if (JST.Delete())
                {
                    Nodes.Delete(GetNode());
                    return true;
                }
            }
            return false;
        }
        #endregion BaseFunctions
        // GetInfo
        #region GetInfo
        /// <summary>
        /// جستجوی  شرکت اقماری
        /// </summary>
        /// <param name="PName"></param>
        /// <returns></returns>
        public Boolean Find(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO(); 
            try
            {
                db.setQuery("SELECT * FROM Subsidiaries WHERE [Code]=" + JDataBase.Quote(pCode.ToString()));
                db.Query_DataReader();
                return db.DataReader.HasRows;
            }
            finally
            {
                db.Dispose();
            }
        }
        /// <summary>
        /// جستجوی  شرکت اقماری
        /// </summary>
        /// <param name="PName"></param>
        /// <returns></returns>
        public Boolean Find()
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            string strSQL = "SELECT * FROM Subsidiaries WHERE 1=1 ";
            if (Code != null && Code != 0) strSQL += " AND code = " + Code.ToString();
            if (Name != null) strSQL += " AND name like '%" + Name +"%'";
            if (managing_director != null) strSQL += " AND managing_director like '%" + managing_director.ToString() + "%'";
            if (phone_number != null) strSQL += " AND phone_number like '%" + phone_number.ToString() + "%'";
            if (address != null) strSQL += " AND address like '%" + address.ToString() + "%'";
            if (server_name != null) strSQL += " AND server_name like '%" + server_name.ToString() + "%'";
            if (server_user != null) strSQL += " AND server_user like '%" + server_user.ToString() + "%'";
            if (server_pass != null) strSQL += " AND server_pass like '%" + server_pass.ToString() + "%'";
            if (database_name != null) strSQL += " AND database_name = " + database_name.ToString() + "%'";
            if (access_code != null && access_code != 0) strSQL += " AND access_code = " + access_code.ToString();
            if (description != null) strSQL += " AND description  like '%" + description.ToString() + "%'";
 
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public Boolean Find(string PName)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM Subsidiaries WHERE [name]=" + JDataBase.Quote(PName));
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
        public Boolean GetData(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM Subsidiaries WHERE [code]=" + JDataBase.Quote(pCode.ToString()));
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
        ///// <summary>
        ///// لیست شرکت های اقماری
        ///// </summary>
        //public string ListView()
        //{
        //    return null;
        //}
        
        #endregion GetInfo
        //Forms
        #region Forms
        /// <summary>
        /// نمایش فرم شرکت اقماری برای ویرایش اطلاعات یک شرکت اقماری
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public bool UpdateForm(int Code)
        {
            if (GetData(Code))
            {
                JfrmSubsidiaries jc = new JfrmSubsidiaries(this);
                jc.State = JFormState.Update;
                jc.ShowDialog();
            }
            return true;
        }

        public bool InsertForm()
        {
            JfrmSubsidiaries jc = new JfrmSubsidiaries(this);
            jc.State = JFormState.Insert;
            jc.ShowDialog();
            return true;
        }

        #endregion Forms
        // Node
        #region Node
        public JNode GetNode()
        {
            return JAStaticAction._SubsidiariesNode(this);
        }
        #endregion Node
    }

    public class JASubsidiariess : JSystem
    {
                //properties
        #region Properties
        private string _SQL = "SELECT [code],[name] FROM Subsidiaries %WHERE% ORDER BY [name]";

        private JASubsidiaries[] _Items;
        public JASubsidiaries[] Items
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
        public JASubsidiariess()
            : this("")
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        public JASubsidiariess(string where)
        {
            if (where.Length > 0)
                where = "AND" + where;
            _SQL = _SQL.Replace("%WHERE%", "WHERE 1=1 "+where);
            _getItems();
        }
        #endregion Constructors
        // GetInfo
        #region GetInfo
        /// <summary>
        /// خواندن اطلاعات شرکت های اقماری از بانک اطلاعاتی و قرار دادن در متغیر 
        /// </summary>
        private void _getItems()
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(_SQL);
                DB.Query_DataSet();
                _Items = new JASubsidiaries[DB.DataSet.Tables[0].Rows.Count];
                int count = 0;
                foreach (DataRow DR in DB.DataSet.Tables[0].Rows)
                {
                    Items[count] = new JASubsidiaries();
                    Items[count].GetData(int.Parse(DR["code"].ToString()));
                    count++;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
        }
        /// <summary>
        ///لیست شرکت های اقماری را بر میگرداند
        /// </summary>
        /// <returns>اطلاعات شرکت های اقماری</returns>        
        public DataTable GetAllSubsidiaries()
        {
            JDataBase db = new JDataBase();
            try
            {
                string strSql = "SELECT [code],[name] ,(CASE ISNULL(CAST(access_code AS nvarchar(20)), '0') WHEN '0' THEN [name] ELSE [name] + '_' + CAST(access_code AS nvarchar(20)) END)AS 'full_title',[server_name],[server_pass],[server_user],[database_name],[managing_director],[phone_number],[address],[description],[access_code] FROM Subsidiaries ";
                strSql += " ORDER BY [name] ";
                db.setQuery(strSql);
                return db.Query_DataTable();
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
            JAction InsertAction = new JAction("New", "Automation.JASubsidiaries.InsertForm");
            Nodes.GlobalMenuActions = new JPopupMenu("Automation.JASubsidiaries", 0);
            Nodes.GlobalMenuActions.Insert(InsertAction);

            foreach (JASubsidiaries Sec in Items)
            {
                Nodes.Insert(Sec.GetNode());
            }
        }

        public JNode[] TreeView()
        {
            return null;
        }
        #endregion View
    }
}
