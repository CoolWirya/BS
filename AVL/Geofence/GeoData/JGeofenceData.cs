using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Geofence.GeoData
{
    public class JGeofenceData : ClassLibrary.JSystem
    {
        public int Code { get; set; }
        public DateTime LastDate { get;set;}
        public int ObjectCode { get; set; }
        public int GeoCode { get; set; }
        public bool entered { get; set; }

        public bool IsGeofence { get; set; }

        /// <summary>
        /// insert data int GeofenceData with check permission definition.
        /// </summary>
        /// <param name="isWeb"></param>
        /// <param name="checkPermission"></param>
        /// <returns></returns>
        public int Insert(bool isWeb = false,bool checkPermission=true)
        {
            bool haspermission = true;
            if(checkPermission)
                haspermission=(ClassLibrary.JPermission.CheckPermission("AVL.Geofence.GeoData.JGeofenceData.Insert"));
            if (!haspermission)
                return 0;
            JGeofeneceDataTable AT = new JGeofeneceDataTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();


            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("AVL.Geofence.GeoData.JGeofenceData", Code, 0, 0, 0, "ثبت اطلاعات ژئوفنس", "", 0);
            return Code;
        }
        /// <summary>
        /// returned an area that coordinate is inside it.
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns>If coordinate is not inside any area, it returns null.</returns>
        public static AVL.Area.JArea CheckGeofence(AVL.Coordinate.JCoordinate coordinate)
        {
            System.Data.DataTable AreaTable = AVL.Area.JAreas.GetAreas(false);
            AVL.Area.JArea area;
            AVL.Geofence.GeoData.JGeofenceData geof;
            List<AVL.Controls.Map.Point> points;
            AVL.Controls.Map.Point currentPoint = new AVL.Controls.Map.Point()
            {
                Latitude = coordinate.lat,
                Longitude = coordinate.lng
            };
            foreach (System.Data.DataRow dr in AreaTable.Rows)
            {
                area = new AVL.Area.JArea()
                {
                    ObjectsCodes = dr["ObjectsCodes"].ToString(),
                    IsGeofence = bool.Parse(dr["IsGeofence"].ToString()),
                    Points = dr["Points"].ToString()
                };
                points = AVL.Area.JArea.ExtractPoints(area.Points);
                if (!AVL.Geofence.JGeofence.IsInThePolygon(currentPoint, points)
                        || !AVL.Geofence.JGeofence.IsInTheLine(currentPoint, points))
                {
                    geof = new AVL.Geofence.GeoData.JGeofenceData()
                    {
                        entered = false,
                        GeoCode = area.code,
                        IsGeofence = area.IsGeofence,
                        LastDate = coordinate.DeviceSendDateTime,
                        ObjectCode = coordinate.ObjectCode
                    };
                    geof.Insert(false, false);
                    return area;
                }
            }
            return null;
                          
        }
    }
}
