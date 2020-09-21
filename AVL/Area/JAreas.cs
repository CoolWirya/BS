using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Area
{
    public class JAreas : ClassLibrary.JSystem
    {
        public static System.Data.DataTable GetDataTable(int pCode)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.Area.JAreas.GetDataTable"))
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT * FROM [AVLArea] WHERE ";

                query += "  personCode=" + pCode  ;
             //   query += " AND "+ClassLibrary.JPermission.getObjectSql("AVL.Area.JAreas.GetDataTable", "AVLArea.Code");


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
        public static System.Data.DataTable GetAreas(bool checkPermission)
        {
            bool hasPermission = true;
            if (checkPermission)
                ClassLibrary.JPermission.CheckPermission("AVL.Area.JAreas.GetAreas");
            if (!hasPermission)
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT * FROM [AVLArea] ";
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
        public static System.Data.DataTable GetAreas(string pCode, bool checkPermission = true)
        {
            bool hasPermission = true;
            if(checkPermission)
                ClassLibrary.JPermission.CheckPermission("AVL.Area.JAreas.GetAreas");
            if (!hasPermission)
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT * FROM [AVLArea] WHERE ";

                query += "   personCode=" + pCode;
             //   query += " AND "+ClassLibrary.JPermission.getObjectSql("AVL.Area.JAreas.GetAreas", "AVLArea.Code");


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
        public static System.Data.DataTable GetAreas(int deviceCode,int personCode)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT * FROM [AVLArea] WHERE deviceCode ="+deviceCode;
                if(personCode>0)
                query += " and  personCode=" + personCode;
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
        public static System.Data.DataTable GetAreas(string pCode, string ObjectCode)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.Area.JAreas.GetAreas"))
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT * FROM [AVLArea] WHERE ";

                query += "   personCode=" + pCode + " AND (ObjectsCodes LIKE '%" + ObjectCode + ",%')";
               // query += ClassLibrary.JPermission.getObjectSql("AVL.Area.JAreas.GetAreas", "AVLArea.Code");


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
        public static System.Data.DataTable GetAreas(string pCode, string ObjectCode, bool IsGeofence = false)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.Area.JAreas.GetAreas"))
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT * FROM [AVLArea] WHERE [IsGeofence] = '" + IsGeofence.ToString() + "'";

                query += " AND  personCode=" + pCode + " AND (ObjectsCodes LIKE '%" + ObjectCode + ",%')";
              //  query += ClassLibrary.JPermission.getObjectSql("AVL.Area.JAreas.GetAreas", "AVLArea.Code");


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
