using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.GPSData
{
    
    public class JSocketManager
    {
        /*
         * Table Fields 
       [Code]
      ,[Ip]
      ,[Data]
      ,[GetDate]
      ,[IsProceced]*/

        public int Code { get; set; }
        public string Ip { get; set; }
        public byte[] Data { get; set; }
        public DateTime GetDate { get;set;}
        public bool IsProceced { get; set; }

        /// <summary>
        /// Insert Data with specified query.
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="isWeb"></param>
        /// <returns></returns>
        public int Insert(string Query,bool isWeb = false)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.GPSData.JSocketManager.Insert"))
                return 0;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = Query;
               // + " WHERE " + ClassLibrary.JPermission.getObjectSql("AVL.GPSData.JSocketManager", "JSocketManager.Code");


                DB.setQuery(query);
                return DB.Query_DataTable().Rows.Count;
                
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public bool Update(bool isWeb = false)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.GPSData.JSocketManager.Update"))
                return false;
            JSocketManagerTable AT = new JSocketManagerTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                return true;
            }
            else
                return false;
        }
        public bool GetData(string code)
        {
            return PerformGetData("select top 1 * from clsSocketDataManager where code= "+code);
        }
        public bool PerformGetData(string query)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery(query);
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    ClassLibrary.JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

    }
}
