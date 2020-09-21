using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Coordinate
{
    public class JCoordinates : ClassLibrary.JSystem
    {
        public static System.Data.DataTable GetDataTable(int pCode )
        {            
            if (!ClassLibrary.JPermission.CheckPermission("AVL.Coordinate.JCoordinates.GetDataTable"))
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT * FROM [AVLCoordinate]  WHERE 1=1 ";
                if(pCode != 0)
                    query += " AND Code=" + pCode;
//                query += " AND "+ ClassLibrary.JPermission.getObjectSql("AVL.Coordinate.JCoordinates.GetDataTable", "AVLCoordinate.Code");


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
        public static System.Data.DataTable GetDataTable(int oCode,int personCode)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.Coordinate.JCoordinates.GetDataTable"))
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT * FROM [AVLCoordinate] WHERE ";

                query += "  ObjectCode=" + oCode + " AND personCode=" + personCode ;
              //  query +=" AND "+ ClassLibrary.JPermission.getObjectSql("AVL.Coordinate.JCoordinates.GetDataTable", "AVLCoordinate.Code");


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

        /// <summary>
        /// return rows in 1 minute ago
        /// 
        /// </summary>
        /// <param name="checkpermission"></param>
        /// <returns></returns>
        public static System.Data.DataTable GetDataTable(bool checkpermission=true)
        {
            bool _hasPermision=true;
            if (checkpermission)
                ClassLibrary.JPermission.CheckPermission("AVL.Coordinate.Traditional.JTransactionCars.GetDataTablePoints");
            if (!_hasPermision)
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"select * from (SELECT 
row_number() over(order by [DeviceSendDateTime]  ) as Row, *
  FROM [AVLCoordinate] where lat IS NOT NULL 
AND lng IS NOT NULL 
AND   DeviceSendDateTime >DATEADD (second , -1 , GETDATE() ) ";
                if (_hasPermision)
                    ;//   query += " AND "+ ClassLibrary.JPermission.getObjectSql("AVL.Coordinate.Traditional.JTransactionCars.GetDataTablePoints", "TransactionCars.CarID");
                query += " ) a";
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

        public static System.Data.DataTable GetDataTablePoints(string devicecode = "0", string fromDate = "1/1/1", string toDate = "1/1/1", string StartRow = "0", string LastRow = "",bool checkPermission=true)
        {
            bool haspermission = true;
            if (checkPermission)
                haspermission = (ClassLibrary.JPermission.CheckPermission("AVL.Coordinate.Traditional.JTransactionCars.GetDataTablePoints"));
            if(!haspermission)
                    return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"select * from (SELECT 
                                row_number() over(order by [DeviceSendDateTime]  ) as Row, *
                                FROM [AVLCoordinate] where 
                                lat IS NOT NULL 
                                AND lng IS NOT NULL 
                                AND   DeviceSendDateTime BETWEEN '" + fromDate +
                                "' AND '" + toDate +
                                "' AND  DeviceCode = " + devicecode;

                if (!string.IsNullOrEmpty(LastRow))
                    query += string.Format(" ) a WHERE a.Row BETWEEN  {0} AND {1}", StartRow, LastRow);
                else
                    query += ") a";
                query += " order by DeviceSendDateTime";
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
