using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Entertainment
{
    public class JNews
    {
        #region Properties
        public int Code { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int ArchiveCode { get; set; }
        #endregion

        #region Constructor
        public JNews()
        { 
        }
        public JNews(int Code)
        {
            GetData(Code);
        }
        #endregion

        #region Method
        public int Insert()
        {
            try
            {
                JNewsTable newsTable = new JNewsTable();
                newsTable.SetValueProperty(this);
                return newsTable.Insert();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
            }
            return 0;
        }

        public bool Update()
        {
            try
            {
                JNewsTable newsTable = new JNewsTable();
                newsTable.SetValueProperty(this);
                return newsTable.Update();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
            }
            return false;
        }

        public bool Delete()
        {
            try
            {
                JNewsTable newsTable = new JNewsTable();
                newsTable.SetValueProperty(this);
                return newsTable.Delete();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
            }
            return false;
        }
        #endregion

        #region GetData
        public void GetData(int Code)
        {
            JDataBase db = new JDataBase();
            try
            {
                string sql = " Select * From EntNews Where Code = '" + Code.ToString() + "'";

                db.setQuery(sql);
                db.Query_DataReader();
                if (db.DataReader.Read())
                    JTable.SetToClassProperty(this, db.DataReader);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }

        }
        #endregion
    }

    public class JNewss
    {
        /// <summary>
        /// در وب سرویس موبایل سهام استفاده شده
        /// قبل از هر تغییری هماهنگ شود
        /// </summary>
        /// <param name="newsCount"></param>
        /// <returns></returns>
        public static DataTable GetData(int newsCount)
        {
            JDataBase db = new JDataBase();
            try
            {
				string sql = string.Format(@" SELECT Top {0} nws.[Code],nws.[Title], nws.[Body], AI.[ArchiveCode]
                      ,(Select Fa_Date FROM StaticDates WHERE En_Date = Convert(date, nws.[Date])) 'Date'
                       FROM [EntNews] nws
                       left join ArchiveInterface AI on nws.ArchiveCode = AI.Code
                       Order By nws.Date Desc ", newsCount);
                db.setQuery(sql);
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

        public static string GetSqlQuery()
        {
            return @"SELECT top 100 percent [Code],[Title], [Body]
                      ,(Select Fa_Date FROM StaticDates WHERE En_Date = Convert(date, [Date])) 'Date'
                       FROM [EntNews] Order By Date Desc";
        }

    }
}
