using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Data;

namespace Automation
{
    public class JAObject: JAutomation
    {
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// آدرس تابعی که هنگام انتخاب شی باید اجرا شود
        /// </summary>
        public string action { get; set; }
        /// <summary>
        /// قبل از ارجاع
        /// </summary>
        public string BeforRefer { get; set; }
        /// <summary>
        /// بعد از ارجاع
        /// </summary>
        public string AfterRefer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// کد کلاسهای داینامیک
        /// </summary>
        public int DynamicClassCode { get; set; }
        /// <summary>
        /// کد شی در سیستم خودش
        /// </summary>
        public int ObjectCode { get; set; }
        /// <summary>
        /// کد پست فرستنده
        /// </summary>
        public int sender_post_code { get; set; }
        /// <summary>
        /// کد کاربر فرستنده
        /// </summary>
        public int sender_user_code { get; set; }
        /// <summary>
        /// عنوان کامل فرستنده
        /// </summary>
        public string sender_full_title { get; set; }
        /// <summary>
        /// تاریخ و زمان ایجاد
        /// </summary>
        public DateTime create_date_time { get; set; }
        /// <summary>
        /// عنوان شی
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// گرفتن داده از داخل شی
        /// </summary>
        public string ActionGetData { get; set; }
        /// <summary>
        /// کد وضعیت
        /// </summary>
        public int StatusObject { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int WorkFlowNode { get; set; }
        
        #endregion

        // سازنده های کلاس
        #region Constructors
        /// <summary>
        /// سازنده
        /// </summary>
        public JAObject()
        {
        }
        /// <summary>
        /// سازنده
        /// </summary>
        public JAObject(int pCode)
        {
            GetData(pCode);
        }
        #endregion

        // Insert , Update , Delete
        #region BaseFunctions
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            JDataBase DB = new JDataBase();
            try
            {
                return Insert(DB);
            }
            finally
            {
                DB.Dispose();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public int Insert(JDataBase db)
        {
            return Insert(db, false);
        }
        public int Insert(JDataBase db, bool pManualInsert)
        {
            JObjectTable ActionTable = new JObjectTable();
            ActionTable.SetValueProperty(this);
            if (pManualInsert == true)
                ActionTable.Set_ComplexInsert(false);
            Code = ActionTable.Insert(db);
            if (Code > 0)
            {
            }
            return Code;
        }

        public bool Update(JDataBase db)
        {

            JObjectTable ActionTable = new JObjectTable();
            ActionTable.SetValueProperty(this);
            return ActionTable.Update(db);
        }

        public void Delete()
        {
            JObjectTable ActionTable = new JObjectTable();
            ActionTable.SetValueProperty(this);
            ActionTable.Delete();
        }

        public void Save(JDataBase pDB)
        {
            JObjectTable ActionTable = new JObjectTable();
            ActionTable.SetValueProperty(this);
            ActionTable.Update(pDB);
        }
        #endregion BaseFunctions

        //Forms
        #region Forms

        #endregion Forms

        // GetInfo
        #region GetInfo
        
        /// <summary>
        /// تنظیم مقادیر کلاس
        /// </summary>
        /// <param name="pCode">کد object</param>
        /// <returns>Boolean</returns>
        public Boolean GetData(int pCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                return GetData(pCode, db);
            }
            finally
            {
                db.Dispose();
            }
        }
        public Boolean GetData(int pCode, JDataBase db)
        {
            try
            {
                db.setQuery("SELECT * FROM " + JTableNamesAutomation.Objects + " WHERE " + ClassLibrary.Objects.Code + "=" + JDataBase.Quote(pCode.ToString()));
                if (db.Query_DataReader() && db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                //db.Dispose();
            }
        }

        public Boolean GetData(string pClassName, int pObjectCode, int pDynamicClassCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("SELECT * FROM " + JTableNamesAutomation.Objects + " WHERE ClassName=" +
                    JDataBase.Quote(pClassName) +
                    " AND DynamicClassCode = " + pDynamicClassCode.ToString() +
                    " AND ObjectCode = " + pObjectCode.ToString());
                if (db.Query_DataReader() && db.DataReader.Read())
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
        /// جستجوی شی خاص بر اساس نوع و کد خارجی آن
        /// </summary>
        /// <param name="objecttype"></param>
        /// <param name="externalCode"></param>
        /// <returns></returns>
        public Boolean Find(string pClassName, int pObjectCode, int pDynamicClassCode)
        {
            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                return Find(pClassName, pObjectCode, pDynamicClassCode, db);
            }
            finally
            {
                db.Dispose();
            }
            return false;
        }

        public Boolean Find(string pClassName, int pObjectCode, int pDynamicClassCode, JDataBase pDB)
        {
            JDataBase db = pDB;
            try
            {
                db.setQuery("SELECT * FROM Objects WHERE ClassName='" + pClassName.ToString() +
                    "' AND DynamicClassCode = '"+pDynamicClassCode.ToString()+
                    "' And ObjectCode = " + pObjectCode.ToString());
                db.Query_DataReader();
                if (db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
            }
            finally
            {
            }
            return false;
        }

        #endregion GetInfo

        // Node
        #region Node
        public JNode GetNode()
        {
            return null;
        }
        #endregion Node

        public int BeforReferRun(JARefer pRefer, JDataBase pDB)
        {
            int retEvent = 0;
            try
            {
                if (BeforRefer != null && BeforRefer.Length > 0)
                {
                    ClassLibrary.JAction Action = new JAction("BeforRefer", BeforRefer, new object[] { pRefer,pDB }, null);
                    retEvent = (int) Action.run();
                }
            }
            catch
            {
                return retEvent;
            }
            return retEvent;
        }

        public int AfterReferRun(JARefer pRefer, JDataBase pDB)
        {
            int retEvent = 0;
            try
            {
                if (AfterRefer != null && AfterRefer.Length > 0)
                {
                    ClassLibrary.JAction Action = new JAction("AfterRefer", AfterRefer, new object[] { pRefer,pDB }, null);
                    retEvent = (int)Action.run();
                }
            }
            catch
            {
                return retEvent;
            }
            return retEvent;
        }
    }

    public class JObjects : JAutomation
    {
        // سازنده های کلاس
        #region Constructors
        /// <summary>
        /// سازنده
        /// </summary>
        public JObjects()
        {
        }
        #endregion

        // View Nodes
        #region View
        public JNode[] TreeView()
        {
            return null;
        }
        public void ListView()
        {

        }


		public static DataTable GetDistinctObjects()
		{
			JDataBase db = new JDataBase();
			try
			{
                db.setQuery(@"select ClassName+case when DynamicClassCode=0 then '' else cast(DynamicClassCode as nvarchar) end Code ,
								isnull((select Text from dic where name = ClassName),ClassName)+
								case when DynamicClassCode=0 then '' else cast(DynamicClassCode as nvarchar) end Text
								from Objects where len(ClassName)>0 group by ClassName,DynamicClassCode");
				return db.Query_DataTable();
			}
			finally
			{
				db.Dispose();
			}
		}

        #endregion View
    }
}
