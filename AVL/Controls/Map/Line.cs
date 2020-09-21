using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Controls.Map
{
    public class Line
    {

        public Line()
        {
            this.Color = "#000000";
            this.Weight = 2;
            this.Opacity = 1f;
            this.Geodisc = true;
            this.MarkerUID = 0;
            this.StartDate = DateTime.Now;
            this.EndDate = DateTime.Now;
        }
        public string Color { get; set; }
        public byte Weight { get; set; }
        public bool Geodisc { get; set; }
        public float Opacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int MarkerUID { get; set; }

        private List<Point> _points = new List<Point>();
        [System.Web.UI.PersistenceMode(System.Web.UI.PersistenceMode.InnerProperty)]
        public List<Point> Points
        {
            get { return _points; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ObjectCoordinate"></param>
        /// <param name="SouthWest"></param>
        /// <param name="NorthEast"></param>
        /// <returns></returns>
        public bool IsInTheArea(Point ObjectCoordinate, AVL.Controls.Map.Point SouthWest, AVL.Controls.Map.Point NorthEast)
        {
            return AVL.Geofence.JGeofence.IsInTheArea(ObjectCoordinate, SouthWest, NorthEast);
        }
        public bool IsInTheLine(Point ObjectCoordinate)
        {
            return AVL.Geofence.JGeofence.IsInTheLine(ObjectCoordinate, this.Points);
        }

        public bool IsInTheCircle( AVL.Controls.Map.Point CenterPoint,double radius,AVL.Controls.Map.Point Point)
        {

            return AVL.Geofence.JGeofence.IsInTheCircle(CenterPoint, radius, Point);
        }
    }
}
