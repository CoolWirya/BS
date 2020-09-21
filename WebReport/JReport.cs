using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebReport
{
    public class JReport
    {
        public JReport()
        { }

        #region Properties
        public int Code { get; set; }
        public string ClassName { get; set; }
        public int ObjectCode { get; set; }
        public string Name { get; set; }
        public byte[] Template { get; set; }


        /// <summary>
        /// پایگاه داده
        /// </summary>
        private static JDataBase _PrivateDatabase;
        private JDataBase _Database
        {
            get
            {
                if (_PrivateDatabase == null)
                    _PrivateDatabase = new JDataBase();
                return _PrivateDatabase;
            }
            set
            {
                _PrivateDatabase = value;
            }
        }
        #endregion

        public int Save()
        {
            if (Code > 0)
                if (Update()) return Code;
                else return 0;
            else
                return Insert();
        }
        public int Insert()
        {
            return Insert(new JFile());
        }

        public int Insert(JFile pFile)
        {
            JReportTable RT = new JReportTable();
            RT.SetValueProperty(this);
            // return RT.Insert();



            /// بررسی وجود فایل در آرشیو 
            //bool deleted = false;
            //int repeat = SearchFile(pFile, ref deleted);
            //if (repeat > 0)
            //{
            //    /// در صورتی که فایل وجود دارد ولی حذف شده، آنرا از حالت حذف خارج میکند
            //    if (deleted)
            //        _UnDeleteContent(repeat);
            //    return repeat;
            //}


            JDataBase db = this._Database;
            try
            {
                string InsertSQL =
                            @"DECLARE @Code INT " +
                            JDataBase.GetInsertSQL("rptReport", "0", false) +
                            @"INSERT INTO rptReport" +
                            @"(ClassName,ObjectCode,Name,Template,Code)  VALUES
                                 (@ClassName,@ObjectCode,@Name,@Template,@Code)
                            SELECT @Code";


                db.setQuery(InsertSQL);
                db.Params.Clear();
                db.AddParams("ClassName", RT.ClassName);
                db.AddParams("ObjectCode", RT.ObjectCode);
                db.AddParams("Name", RT.Name);
                if (pFile.Content == null || pFile.Content.Length == 0)
                    db.AddParams("Template", new byte[0]);
                else
                    db.AddParams("Template", pFile.Content);
                int ContentCode = Convert.ToInt32(db.Query_ExecutSacler());
                return ContentCode;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
            }
        }


        public bool GetData(int pCode)
        {
            JReportTable GH = new JReportTable();
            return GH.GetData(this, pCode);
        }

        public bool Update()
        {
            JReportTable RT = new JReportTable();
            RT.SetValueProperty(this);
            return RT.Update();
        }

        public bool Delete()
        {
            JReportTable RT = new JReportTable();
            RT.SetValueProperty(this);
            return RT.Delete();
        }
    }

    public class JReports
    {
        public static DataTable GetReportsByClassNameObjectCode(string className, int objectCode)
        {
            return WebClassLibrary.JWebDataBase.GetDataTable("Select * From rptReport Where ClassName=N'" + className + "' AND ObjectCode=" + objectCode);
        }

        public static DataTable GetDataTable(int pCode = 0)
        {
            JReportTable jReportTable = new JReportTable();
            return jReportTable.GetDataTable(pCode);
        }
    }

    public class JReportTable : ClassLibrary.JTable
    {
        public JReportTable()
            : base("rptReport")
        { }

        public string ClassName;
        public int ObjectCode;
        public string Name;
        public byte[] Template;
    }
}