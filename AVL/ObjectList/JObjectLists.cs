using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.ObjectList
{
    public class JObjectLists : ClassLibrary.JSystem
    {
        /// <summary>
        /// تمام دیتای جدول را برمی گرداند.
        /// </summary>
        /// <param name="checkPermission"></param>
        /// <returns></returns>
        public static System.Data.DataTable GetDataTable(bool checkPermission)
        {
            bool hasPermission = true;
            if (checkPermission)
                hasPermission = ClassLibrary.JPermission.CheckPermission("AVL.ObjectList.JObjectList.GetDataTable");
            if (!hasPermission)
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT * FROM AVLObjectList";

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
        public static System.Data.DataTable GetDataTable(int pCode)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.ObjectList.JObjectList.GetDataTable"))
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT * FROM AVLObjectList"
                + " WHERE personCode=" + pCode;
                //+" AND "                + ClassLibrary.JPermission.getObjectSql("AVL.ObjectList.JObjectList.GetDataTable", "ObjectList.Code");


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
        public static System.Data.DataTable GetDataTable(int objectCode,int pCode)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.ObjectList.JObjectList.GetDataTable"))
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT * FROM AVLObjectList"
                + " WHERE Code=" + objectCode + " AND personCode=" + pCode;// +" AND " + ClassLibrary.JPermission.getObjectSql("AVL.ObjectList.JObjectList.GetDataTable", "AVLObjectList.Code");


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
        public static System.Data.DataTable GetDataTableToday(int pCode)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.ObjectList.JObjectList.GetDataTable"))
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query;
                try
                {
                    //string parameters = WebClassLibrary.SessionManager.Current.Session["OnlineMapLastFilter"].ToString();
                }
                catch { }
                    query = @"SELECT ol.* FROM AVLObjectList ol inner join AVLCash c On c.userCode=ol.personCode "
                + " WHERE ol.personCode=" + pCode + " AND  ol.lastSendDate > DATEADD(hour,-24,getdate()) AND (c.paid>0) ";// ";//" AND " + ClassLibrary.JPermission.getObjectSql("AVL.ObjectList.JObjectList.GetDataTable", "AVLObjectList.Code");



                AVL.SubUserObjects.jSubUserObjects user = new SubUserObjects.jSubUserObjects();
                user.GetData(WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode);
                if (user.Code > 0)
                {
                    string parentObjects = user.objects.Remove(user.objects.Length - 1);
                    query += "   OR Code IN ( " + parentObjects + ")";
                }

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
}
