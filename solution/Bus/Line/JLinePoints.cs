using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusManagment.Line
{
    public class JLinePoint
    {
        #region Properties
        public int Code { get; set; }
        public int LineCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int OrderNo { get; set; }
        public int PathType { get; set; }
        #endregion
    }
    public class JLinePoints
    {
        public static bool UpdateLinePoints(int LineCode, List<JLinePoint> linePoints, bool isAutoOrderNo, int PathType = 0)
        {

            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                int order = 1;
                db.beginTransaction("linePoints");
                db.setQuery("Delete From AUTFleetLinePoints Where LineCode = " + LineCode + "And PathType = " + PathType);
                db.Query_Execute();
                string sql = "";
                foreach (JLinePoint point in linePoints)
                {
                    sql += @"INSERT INTO AUTFleetLinePoints(Code,LineCode,Latitude,Longitude,OrderNo,PathType) VALUES
                             (ISNULL((Select MAX(Code) From AUTFleetLinePoints), 0) + 1, " + point.LineCode + ", " + point.Latitude + ", " + point.Longitude + ", " + (isAutoOrderNo == true ? order : point.OrderNo) + ", " + PathType + ") \r\n";
                    order++;
                }
                db.setQuery(sql);
                if (db.Query_Execute() > 0)
                {
                    db.Commit();
                    return true;
                }
                db.Rollback("linePoints");
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static bool DeleteLinePoints(int LineCode, int PathType = 0)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                int order = 1;
                db.beginTransaction("linePointsDel");
                db.setQuery("Delete From AUTFleetLinePoints Where LineCode = " + LineCode + " And PathType = " + PathType);
                if (db.Query_Execute() > 0)
                {
                    db.Commit();
                    return true;
                }
                db.Rollback("linePointsDel");
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static DataTable GetDataTable(int lineCode = 0, int PathType = 0)
        {
            string where = "";
            if (lineCode > 0)
                where = " Where LineCode=" + lineCode + " and PathType = " + PathType;
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                db.setQuery("Select * From AUTFleetLinePoints " + where + " Order By OrderNo ASC");
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
