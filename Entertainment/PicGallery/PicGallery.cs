using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Entertainment
{
    public class JPicGallery
    {
        #region Properties
        public int Code { get; set; }
        public string Text { get; set; }
        public string ClassName { get; set; }
        public int ArchiveCode { get; set; }
        #endregion

        #region Constructor
        public JPicGallery()
        { 
        }
        public JPicGallery(int Code)
        {
            GetData(Code);
        }
        #endregion

        #region Method
        public int Insert()
        {
            try
            {
                PicGalleryTable newsTable = new PicGalleryTable();
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
                PicGalleryTable newsTable = new PicGalleryTable();
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
                PicGalleryTable newsTable = new PicGalleryTable();
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
                string sql = " Select * From entPicGallery Where Code = '" + Code.ToString() + "'";

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

    public class JPicGallerys
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
                string sql = string.Format(@" SELECT Top {0}  [Code],[Text], [ArchiveCode]
                      ,ClassName
                       FROM [entPicGallery] Order By Code Desc ", newsCount);
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
            return @"SELECT top 100 percent [Code],[Text], [ArchiveCode]
                      ,ClassName
                       FROM [entPicGallery] Order By Code Desc";
        }

    }
}
