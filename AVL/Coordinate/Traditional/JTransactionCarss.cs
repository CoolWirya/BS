using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Coordinate.Traditional
{
    public class JTransactionCarss : ClassLibrary.JSystem
    {
        public static System.Data.DataTable GetDataTable(int pCode = 0)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.Coordinate.Traditional.JTransactionCars.GetDataTable"))
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
				string query = @"SELECT CarID
      ,[LastLatitude]
      , LastLongitude
	  , LastDate
  FROM [avlsite_com_1].[dbo].[Cars] WHERE  LastLatitude IS NOT NULL AND LastLongitude IS NOT NULL AND 
  LastDate BETWEEN DATEADD(dd, DATEDIFF(dd,0,GETDATE()), 0) 
AND DATEADD(dd, DATEDIFF(dd,0,GETDATE()), 1)
    ";
			//	string query = @"SELECT * FROM [avlsite_com_1].[dbo].[TransactionCars] WHERE ";
                if (pCode != 0)
                    query += " AND CarID=" + pCode;
               // query += " AND "+ClassLibrary.JPermission.getObjectSql("AVL.Coordinate.Traditional.JTransactionCars.GetDataTable", "TransactionCars.CarID");


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
        public static System.Data.DataTable GetDataTableAllCars(int pCode = 0)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.Coordinate.Traditional.JTransactionCars.GetDataTableAllCars"))
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT CarID
      ,[LastLatitude]
      , LastLongitude
	  , LastDate
  FROM [avlsite_com_1].[dbo].[Cars] WHERE 1=1 ";
                if (pCode != 0)
                    query += " AND CarID=" + pCode;
               // query += " AND "+ ClassLibrary.JPermission.getObjectSql("AVL.Coordinate.Traditional.JTransactionCars.GetDataTableAllCars", "TransactionCars.CarID");


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
   
        public static System.Data.DataTable GetDataTableInArea(AVL.Controls.Map.Point SouthWest, AVL.Controls.Map.Point NorthEast)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.Coordinate.Traditional.JTransactionCars.GetDataTableInArea"))
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT CarID
      ,[LastLatitude]
      , LastLongitude
	  , LastDate
  FROM [avlsite_com_1].[dbo].[Cars] WHERE  LastLatitude IS NOT NULL AND LastLongitude IS NOT NULL AND 
  LastDate BETWEEN DATEADD(dd, DATEDIFF(dd,0,GETDATE()), 0) 
AND DATEADD(dd, DATEDIFF(dd,0,GETDATE()), 1)
  AND  " + 
         string.Format("LastLatitude BETWEEN {0} AND {1} AND LastLongitude BETWEEN {2} AND {3} ",
        SouthWest.Latitude,
        NorthEast.Latitude,
        SouthWest.Longitude,
        NorthEast.Longitude);

                //    query += " AND "+ ClassLibrary.JPermission.getObjectSql("AVL.Coordinate.Traditional.JTransactionCars.GetDataTableInArea", "TransactionCars.CarID");


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

        public static System.Data.DataTable GetDataTableInDate(string id = "0", string fromDate = "1/1/1", string toDate = "1/1/1")
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.Coordinate.Traditional.JTransactionCars.GetDataTableInDate"))
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"SELECT CarID
      ,Latitude
      , Longitude
	  , LastDate
  FROM [avlsite_com_1].[dbo].[Cars] WHERE  LastLatitude IS NOT NULL AND LastLongitude IS NOT NULL AND 
  LastDate BETWEEN DATEADD(dd, DATEDIFF(dd,0,GETDATE()), 0) 
AND DATEADD(dd, DATEDIFF(dd,0,GETDATE()), 1)
   ";

                //query += " AND "+ClassLibrary.JPermission.getObjectSql("AVL.Coordinate.Traditional.JTransactionCars.GetDataTableInDate", "TransactionCars.CarID");


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

        public static System.Data.DataTable GetDataTablePoints(string id = "0", string fromDate = "1/1/1", string toDate = "1/1/1",string StartRow ="0", string LastRow="")
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.Coordinate.Traditional.JTransactionCars.GetDataTablePoints"))
                return null;
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                string query = @"select * from (SELECT 
row_number() over(order by [DateSend]  ) as Row, [TransactionID]
      ,[CarID]
      ,[Longitude]
      ,[Latitude]
      ,[Altitude]
      ,[DateSend]
      ,[DateReceive]
  FROM [avlsite_com_1].[dbo].[TransactionCars] where Latitude IS NOT NULL 
AND Longitude IS NOT NULL 
AND   DateSend BETWEEN '" + fromDate +
"' AND '" + toDate +
 "' AND  CarID=" + id ;

              //  query +=  " AND "+ClassLibrary.JPermission.getObjectSql("AVL.Coordinate.Traditional.JTransactionCars.GetDataTablePoints", "TransactionCars.CarID");


                if (!string.IsNullOrEmpty(LastRow))
                    query+=string.Format(" ) a WHERE a.Row BETWEEN  {0} AND {1}", StartRow, LastRow);

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
