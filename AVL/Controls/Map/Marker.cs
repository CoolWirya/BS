using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Controls.Map
{
    [Serializable]
    public class Marker
    {
        public int UID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Title { get; set; }

        private string _iconUrl = "bus.png";
        [System.Web.UI.UrlProperty]
        [System.ComponentModel.Editor("System.Web.UI.Design.ImageUrlEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public string IconUrl
        {
            get { return _iconUrl; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new NullReferenceException("Icon url can not set to a null or empty reference.");
                _iconUrl = value;
            }
        }
        public virtual string InfoWindowHtml { get; set; }
        public Marker()
        {
        }


        public static AVL.Controls.Map.GCommunicateObject[] JoinMarkers(double distance, AVL.Controls.Map.GCommunicateObject[] markers,int periority)
        {
            List<AVL.Controls.Map.GCommunicateObject> clustered = new List<AVL.Controls.Map.GCommunicateObject>();
            bool include = false;
            for (int i = 0; i < markers.Length; i++)
            {
                if (clustered.Count == 0)
                    clustered.Add(markers[i]);
                else
                {
                    foreach (AVL.Controls.Map.GCommunicateObject g in clustered)
                    {
                        if (Math.Sqrt(Math.Pow((g.Location.X - markers[i].Location.X), 2) + Math.Pow((g.Location.Y - markers[i].Location.Y), 2)) <= (distance / periority))
                        {
                            include = true;
                            break;
                        }
                        else
                        {
                            include = false;
                        }
                    }
                    if (!include)
                    {
                        clustered.Add(markers[i]);
                    }
                }
            }
            return clustered.ToArray();
        }
    }
}
