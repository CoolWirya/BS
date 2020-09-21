using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Geofence
{
    public class JGeofence : ClassLibrary.JSystem
    {
        public int code { get; set; }
        public int LineCode { get; set; }
        public int ObjectCode { get; set; }
        public DateTime  LastDate { get; set; }
        public bool InArea { get; set; }


        public bool GetData(string pCode)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                // Need to use a faster query. Prefered using row_number().
                DB.setQuery("select top 1 * from AVLGeofenceData where Code=" + pCode);
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
        /// <summary>
        /// SQuare
        /// </summary>
        /// <param name="ObjectCoordinate"></param>
        /// <param name="SouthWest"></param>
        /// <param name="NorthEast"></param>
        /// <returns></returns>
        public static bool IsInTheArea(AVL.Controls.Map.Point ObjectCoordinate, AVL.Controls.Map.Point SouthWest, AVL.Controls.Map.Point NorthEast)
        {
            if (ObjectCoordinate.Latitude >= SouthWest.Latitude && ObjectCoordinate.Latitude <= NorthEast.Latitude
                && ObjectCoordinate.Longitude >= SouthWest.Longitude && ObjectCoordinate.Longitude <= NorthEast.Longitude)
                return true;
            return false;
        }
      
        /// <summary>
        /// Line
        /// </summary>
        /// <param name="ObjectCoordinate"></param>
        /// <param name="Points"></param>
        /// <returns></returns>
        public static bool IsInTheLine(AVL.Controls.Map.Point ObjectCoordinate,List<AVL.Controls.Map.Point> Points)
        {
            AVL.Controls.Map.Point p1 = null, p2 = null;
            double Y;
            bool IsIn = false;
            for (int i = 0; i < Points.Count - 1; i++)
            {
                p1 = Points[i];
                p2 = Points[i + 1];

                Y = ((p2.Latitude - p1.Latitude) / (p2.Longitude - p1.Longitude) * (ObjectCoordinate.Longitude - p1.Longitude)) - p1.Latitude;

                if ((Y - ObjectCoordinate.Latitude) <= 0.00004 && (Y - ObjectCoordinate.Latitude) >= -0.00004)
                {
                    IsIn = true;
                    break;
                }
            }
            return IsIn;
        }

        public static double distance(AVL.Controls.Map.Point CenterPoint, AVL.Controls.Map.Point Point)
        {

            AVL.Controls.Map.Point p = new AVL.Controls.Map.Point()
            {
                Latitude = Point.Latitude - CenterPoint.Latitude,
                Longitude = Point.Longitude - CenterPoint.Longitude
            };
            double distance = Math.Sqrt(Math.Pow(p.Latitude, 2d) + Math.Pow(p.Longitude, 2d));
            return distance;
        }

        /// <summary>
        /// Circle
        /// </summary>
        /// <param name="CenterPoint"></param>
        /// <param name="radius"></param>
        /// <param name="Point"></param>
        /// <returns></returns>
        public static bool IsInTheCircle(AVL.Controls.Map.Point CenterPoint, double radius, AVL.Controls.Map.Point Point)
        {
            AVL.Controls.Map.Point p = new AVL.Controls.Map.Point()
            {
                Latitude = Point.Latitude - CenterPoint.Latitude,
                Longitude = Point.Longitude - CenterPoint.Longitude
            };
            double distance = Math.Sqrt(Math.Pow(p.Latitude, 2d) + Math.Pow(p.Longitude, 2d));
            if (distance <= radius)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Polygon
        /// </summary>
        /// <param name="point"></param>
        /// <param name="Points"></param>
        /// <returns></returns>
        public static bool IsInThePolygon(AVL.Controls.Map.Point point, List<AVL.Controls.Map.Point> Points)
        {
            double X = point.Longitude;
            double Y = point.Latitude;
            int sides = Points.Count() - 1;
            int j = sides - 1;
            bool pointStatus = false;
            for (int i = 0; i < sides; i++)
            {
                if (Points[i].Latitude < Y && Points[j].Latitude >= Y ||
            Points[j].Latitude < Y && Points[i].Latitude >= Y)
                {
                    if (Points[i].Longitude + (Y - Points[i].Latitude) /
            (Points[j].Latitude - Points[i].Latitude) * (Points[j].Longitude - Points[i].Longitude) < X)
                    {
                        pointStatus = !pointStatus;
                    }
                }
                j = i;
            }
            return pointStatus;
        }
    }
}
