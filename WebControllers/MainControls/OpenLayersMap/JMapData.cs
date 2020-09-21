using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebControllers.MainControls.OpenLayersMap
{
    public class JMapData
    {
        public const string Seprator = "{!~!}";
        public const string BigSeprator = "{!~!~!}";
        public JMapData()
        {
            Data = new List<object>();
        }

        public List<object> Data;

        public void AddData(MapPropertyActions action, string value)
        {
            Data.Add(new string[] { action.ToString(), value });
        }
        public void AddData(MapVoidActions action)
        {
            Data.Add(action.ToString());
        }
        public void AddData(JMapDataMarker marker)
        {
            Data.Add(marker);
        }
        public void AddData(JMapDataMarkerWithEventDate marker)
        {
            Data.Add(marker);
        }
        public void AddData(JMapDataLine line)
        {
            Data.Add(line);
        }
        public void AddData(List<JMapDataMarker> markers)
        {
            Data.Add(markers);
        }
        public void AddData(List<JMapDataLine> lines)
        {
            Data.Add(lines);
        }
        public string[] Generate()
        {
            List<string> result = new List<string>();
            foreach (object item in Data)
            {
                if (item is string)
                {
                    result.Add(item.ToString());
                }
                else if (item is string[])
                {
                    string[] itm = (string[])item;
                    result.Add(itm[0]);
                    result.Add(itm[1]);
                }
                else if (item is JMapDataMarker)
                {
                    result.Add("Marker");
                    JMapDataMarker marker = (JMapDataMarker)item;
                    string itm = marker.Latitude.ToString() + Seprator +
                                 marker.Longitude.ToString() + Seprator +
                                 marker.Name + Seprator +
                                 marker.Title + Seprator +
                                 marker.ImageURL + Seprator +
                                 marker.Width + Seprator +
                                 marker.Height + Seprator +
                                 marker.TitleWidth + Seprator +
                                 marker.TitleHeight;
                    result.Add(itm);
                }
                else if (item is JMapDataMarkerWithEventDate)
                {
                    result.Add("Marker");
                    JMapDataMarkerWithEventDate marker = (JMapDataMarkerWithEventDate)item;
                    string itm = marker.Latitude.ToString() + Seprator +
                                 marker.Longitude.ToString() + Seprator +
                                 marker.Name + Seprator +
                                 marker.Title + Seprator +
                                 marker.ImageURL + Seprator +
                                 marker.Width + Seprator +
                                 marker.Height + Seprator +
                                 marker.TitleWidth + Seprator +
                                 marker.TitleHeight + Seprator +
                                 marker.EventDate + Seprator +
                                 marker.SecoundFromPrePoint;
                    result.Add(itm);
                }
                else if (item is JMapDataLine)
                {
                    result.Add("Line");
                    JMapDataLine line = (JMapDataLine)item;
                    string itm = line.LatitudeA.ToString() + Seprator +
                                 line.LongitudeA.ToString() + Seprator +
                                 line.LatitudeB.ToString() + Seprator +
                                 line.LongitudeB.ToString() + Seprator +
                                 line.Name + Seprator +
                                 line.Title + Seprator +
                                 line.Width + Seprator +
                                 (line.hasDirectionMarker == true ? "true" : "false");
                    result.Add(itm);
                }
                else if (item is List<JMapDataMarker>)
                {
                    List<JMapDataMarker> markers = (List<JMapDataMarker>)item;
                    foreach (JMapDataMarker marker in markers)
                    {
                        result.Add("Marker");
                        string itm = marker.Latitude.ToString() + Seprator +
                                     marker.Longitude.ToString() + Seprator +
                                     marker.Name + Seprator +
                                     marker.Title + Seprator +
                                     marker.ImageURL + Seprator +
                                     marker.Width + Seprator +
                                     marker.Height + Seprator +
                                     marker.TitleWidth + Seprator +
                                     marker.TitleHeight;
                        result.Add(itm);
                    }
                }
                else if (item is List<JMapDataLine>)
                {
                    List<JMapDataLine> lines = (List<JMapDataLine>)item;
                    foreach (JMapDataLine line in lines)
                    {
                        result.Add("Line");
                        string itm = line.LatitudeA.ToString() + Seprator +
                                     line.LongitudeA.ToString() + Seprator +
                                     line.LatitudeB.ToString() + Seprator +
                                     line.LongitudeB.ToString() + Seprator +
                                     line.Name + Seprator +
                                     line.Title + Seprator +
                                     line.Width + Seprator +
                                     (line.hasDirectionMarker == true ? "true" : "false");
                        result.Add(itm);
                    }
                }
            }
            return result.ToArray();
        }

        public string[] GenerateMarkerWithEventDate()
        {
            List<string> result = new List<string>();
            foreach (object item in Data)
            {
                if (item is string)
                {
                    result.Add(item.ToString());
                }
                else if (item is string[])
                {
                    string[] itm = (string[])item;
                    result.Add(itm[0]);
                    result.Add(itm[1]);
                }
                else if (item is JMapDataMarker)
                {
                    result.Add("Marker");
                    JMapDataMarker marker = (JMapDataMarker)item;
                    string itm = marker.Latitude.ToString() + Seprator +
                                 marker.Longitude.ToString() + Seprator +
                                 marker.Name + Seprator +
                                 marker.Title + Seprator +
                                 marker.ImageURL + Seprator +
                                 marker.Width + Seprator +
                                 marker.Height + Seprator +
                                 marker.TitleWidth + Seprator +
                                 marker.TitleHeight;
                    result.Add(itm);
                }
                else if (item is JMapDataMarkerWithEventDate)
                {
                    result.Add("Marker");
                    JMapDataMarkerWithEventDate marker = (JMapDataMarkerWithEventDate)item;
                    string itm = marker.Latitude.ToString() + Seprator +
                                 marker.Longitude.ToString() + Seprator +
                                 marker.Name + Seprator +
                                 marker.Title + Seprator +
                                 marker.ImageURL + Seprator +
                                 marker.Width + Seprator +
                                 marker.Height + Seprator +
                                 marker.TitleWidth + Seprator +
                                 marker.TitleHeight + Seprator +
                                 marker.EventDate + Seprator +
                                 marker.SecoundFromPrePoint;
                    result.Add(itm);
                }
                else if (item is JMapDataLine)
                {
                    result.Add("Line");
                    JMapDataLine line = (JMapDataLine)item;
                    string itm = line.LatitudeA.ToString() + Seprator +
                                 line.LongitudeA.ToString() + Seprator +
                                 line.LatitudeB.ToString() + Seprator +
                                 line.LongitudeB.ToString() + Seprator +
                                 line.Name + Seprator +
                                 line.Title + Seprator +
                                 line.Width + Seprator +
                                 (line.hasDirectionMarker == true ? "true" : "false");
                    result.Add(itm);
                }
                else if (item is List<JMapDataMarker>)
                {
                    List<JMapDataMarker> markers = (List<JMapDataMarker>)item;
                    foreach (JMapDataMarker marker in markers)
                    {
                        result.Add("Marker");
                        string itm = marker.Latitude.ToString() + Seprator +
                                     marker.Longitude.ToString() + Seprator +
                                     marker.Name + Seprator +
                                     marker.Title + Seprator +
                                     marker.ImageURL + Seprator +
                                     marker.Width + Seprator +
                                     marker.Height + Seprator +
                                     marker.TitleWidth + Seprator +
                                     marker.TitleHeight;
                        result.Add(itm);
                    }
                }
                else if (item is List<JMapDataLine>)
                {
                    List<JMapDataLine> lines = (List<JMapDataLine>)item;
                    foreach (JMapDataLine line in lines)
                    {
                        result.Add("Line");
                        string itm = line.LatitudeA.ToString() + Seprator +
                                     line.LongitudeA.ToString() + Seprator +
                                     line.LatitudeB.ToString() + Seprator +
                                     line.LongitudeB.ToString() + Seprator +
                                     line.Name + Seprator +
                                     line.Title + Seprator +
                                     line.Width + Seprator +
                                     (line.hasDirectionMarker == true ? "true" : "false");
                        result.Add(itm);
                    }
                }
            }
            return result.ToArray();
        }

        public static string GeneratePopup(string HTML, int Width, int Height)
        {
            return Width.ToString() + Seprator + Height.ToString() + Seprator + HTML;
        }


        public string[] GenerateMarkerStation()
        {
            List<string> result = new List<string>();
            foreach (object item in Data)
            {
                if (item is string)
                {
                    result.Add(item.ToString());
                }
                else if (item is string[])
                {
                    string[] itm = (string[])item;
                    result.Add(itm[0]);
                    result.Add(itm[1]);
                }
                else if (item is JMapDataMarker)
                {
                    result.Add("Marker");
                    JMapDataMarker marker = (JMapDataMarker)item;
                    string itm = BigSeprator + marker.Latitude.ToString() + Seprator +
                                 marker.Longitude.ToString() + Seprator +
                                 marker.Name + Seprator +
                                 marker.Title + Seprator +
                                 marker.ImageURL + Seprator +
                                 marker.Width + Seprator +
                                 marker.Height + Seprator +
                                 marker.TitleWidth + Seprator +
                                 marker.TitleHeight;
                    result.Add(itm);
                }
                else if (item is JMapDataMarkerWithEventDate)
                {
                    result.Add("Marker");
                    JMapDataMarkerWithEventDate marker = (JMapDataMarkerWithEventDate)item;
                    string itm = marker.Latitude.ToString() + Seprator +
                                 marker.Longitude.ToString() + Seprator +
                                 marker.Name + Seprator +
                                 marker.Title + Seprator +
                                 marker.ImageURL + Seprator +
                                 marker.Width + Seprator +
                                 marker.Height + Seprator +
                                 marker.TitleWidth + Seprator +
                                 marker.TitleHeight + Seprator +
                                 marker.EventDate + Seprator +
                                 marker.SecoundFromPrePoint;
                    result.Add(itm);
                }
                else if (item is JMapDataLine)
                {
                    result.Add("Line");
                    JMapDataLine line = (JMapDataLine)item;
                    string itm = line.LatitudeA.ToString() + Seprator +
                                 line.LongitudeA.ToString() + Seprator +
                                 line.LatitudeB.ToString() + Seprator +
                                 line.LongitudeB.ToString() + Seprator +
                                 line.Name + Seprator +
                                 line.Title + Seprator +
                                 line.Width + Seprator +
                                 (line.hasDirectionMarker == true ? "true" : "false");
                    result.Add(itm);
                }
                else if (item is List<JMapDataMarker>)
                {
                    List<JMapDataMarker> markers = (List<JMapDataMarker>)item;
                    foreach (JMapDataMarker marker in markers)
                    {
                        result.Add("Marker");
                        string itm = marker.Latitude.ToString() + Seprator +
                                     marker.Longitude.ToString() + Seprator +
                                     marker.Name + Seprator +
                                     marker.Title + Seprator +
                                     marker.ImageURL + Seprator +
                                     marker.Width + Seprator +
                                     marker.Height + Seprator +
                                     marker.TitleWidth + Seprator +
                                     marker.TitleHeight;
                        result.Add(itm);
                    }
                }
                else if (item is List<JMapDataLine>)
                {
                    List<JMapDataLine> lines = (List<JMapDataLine>)item;
                    foreach (JMapDataLine line in lines)
                    {
                        result.Add("Line");
                        string itm = line.LatitudeA.ToString() + Seprator +
                                     line.LongitudeA.ToString() + Seprator +
                                     line.LatitudeB.ToString() + Seprator +
                                     line.LongitudeB.ToString() + Seprator +
                                     line.Name + Seprator +
                                     line.Title + Seprator +
                                     line.Width + Seprator +
                                     (line.hasDirectionMarker == true ? "true" : "false");
                        result.Add(itm);
                    }
                }
            }
            return result.ToArray();
        }


    }

    public class JMapDataMarkerWithEventDate
    {
        public JMapDataMarkerWithEventDate(float Latitude, float Longitude, string Name, string Title, string ImageURL, int Width, int Height, int TitleWidth, int TitleHeight, DateTime EventDate, int SecoundFromPrePoint)
        {
            this.Latitude = Latitude;
            this.Longitude = Longitude;
            this.Name = Name;
            this.Title = Title;
            this.ImageURL = ImageURL;
            this.Width = Width;
            this.Height = Height;
            this.TitleWidth = TitleWidth;
            this.TitleHeight = TitleHeight;
            this.EventDate = EventDate;
            this.SecoundFromPrePoint = SecoundFromPrePoint;
        }

        public static List<JMapDataMarkerWithEventDate> Parse(string markers)
        {
            List<JMapDataMarkerWithEventDate> mapDataMarker = new List<JMapDataMarkerWithEventDate>();
            foreach (string marker in markers.Split(new string[] { JMapData.BigSeprator }, StringSplitOptions.None))
            {
                string[] markerDetail = marker.Split(new string[] { JMapData.Seprator }, StringSplitOptions.None);
                mapDataMarker.Add(new JMapDataMarkerWithEventDate(Convert.ToSingle(markerDetail[0])
                                                    , Convert.ToSingle(markerDetail[1])
                                                    , markerDetail[2]
                                                    , markerDetail[3]
                                                    , markerDetail[4]
                                                    , Convert.ToInt32(markerDetail[5])
                                                    , Convert.ToInt32(markerDetail[6])
                                                    , Convert.ToInt32(markerDetail[7])
                                                    , Convert.ToInt32(markerDetail[8])
                                                    , Convert.ToDateTime(markerDetail[9])
                                                    , Convert.ToInt32(markerDetail[10])));
            }
            return mapDataMarker;
        }

        public static string Generate(List<JMapDataMarkerWithEventDate> Markers)
        {
            string result = "";
            foreach (JMapDataMarkerWithEventDate item in Markers)
                result += JMapData.BigSeprator
                        + item.Latitude + JMapData.Seprator
                        + item.Longitude + JMapData.Seprator
                        + item.Name + JMapData.Seprator
                        + item.Title + JMapData.Seprator
                        + item.ImageURL + JMapData.Seprator
                        + item.Width + JMapData.Seprator
                        + item.Height + JMapData.Seprator
                        + item.TitleWidth + JMapData.Seprator
                        + item.TitleHeight + JMapData.Seprator
                        + item.EventDate + JMapData.Seprator
                        + item.SecoundFromPrePoint;
            return result.Length > JMapData.BigSeprator.Length ? result.Substring(JMapData.BigSeprator.Length) : "";
        }

        public float Latitude;
        public float Longitude;
        public string Name;
        public string Title;
        public string ImageURL;
        public int Width;
        public int Height;
        public int TitleWidth;
        public int TitleHeight;
        public DateTime EventDate;
        public int SecoundFromPrePoint;
    }

    public class JMapDataMarker
    {
        public JMapDataMarker(float Latitude, float Longitude, string Name, string Title, string ImageURL, int Width, int Height, int TitleWidth, int TitleHeight)
        {
            this.Latitude = Latitude;
            this.Longitude = Longitude;
            this.Name = Name;
            this.Title = Title;
            this.ImageURL = ImageURL;
            this.Width = Width;
            this.Height = Height;
            this.TitleWidth = TitleWidth;
            this.TitleHeight = TitleHeight;
        }

        public static List<JMapDataMarker> Parse(string markers)
        {
            List<JMapDataMarker> mapDataMarker = new List<JMapDataMarker>();
            foreach (string marker in markers.Split(new string[] { JMapData.BigSeprator }, StringSplitOptions.None))
            {
                string[] markerDetail = marker.Split(new string[] { JMapData.Seprator }, StringSplitOptions.None);
                mapDataMarker.Add(new JMapDataMarker(Convert.ToSingle(markerDetail[0])
                                                    , Convert.ToSingle(markerDetail[1])
                                                    , markerDetail[2]
                                                    , markerDetail[3]
                                                    , markerDetail[4]
                                                    , Convert.ToInt32(markerDetail[5])
                                                    , Convert.ToInt32(markerDetail[6])
                                                    , Convert.ToInt32(markerDetail[7])
                                                    , Convert.ToInt32(markerDetail[8])));
            }
            return mapDataMarker;
        }

        public static string Generate(List<JMapDataMarker> Markers)
        {
            string result = "";
            foreach (JMapDataMarker item in Markers)
                result += JMapData.BigSeprator
                        + item.Latitude + JMapData.Seprator
                        + item.Longitude + JMapData.Seprator
                        + item.Name + JMapData.Seprator
                        + item.Title + JMapData.Seprator
                        + item.ImageURL + JMapData.Seprator
                        + item.Width + JMapData.Seprator
                        + item.Height + JMapData.Seprator
                        + item.TitleWidth + JMapData.Seprator +
                        item.TitleHeight;
            return result.Length > JMapData.BigSeprator.Length ? result.Substring(JMapData.BigSeprator.Length) : "";
        }

        public float Latitude;
        public float Longitude;
        public string Name;
        public string Title;
        public string ImageURL;
        public int Width;
        public int Height;
        public int TitleWidth;
        public int TitleHeight;
    }
    public class JMapDataLine
    {
        public JMapDataLine(float LatitudeA, float LongitudeA, float LatitudeB, float LongitudeB, string Name, string Title, string Color, int Opacity, int Width, bool hasDirectionMarker)
        {
            this.LatitudeA = LatitudeA;
            this.LongitudeA = LongitudeA;
            this.LatitudeB = LatitudeB;
            this.LongitudeB = LongitudeB;
            this.Name = Name;
            this.Title = Title;
            this.Color = Color;
            this.Opacity = Opacity;
            this.Width = Width;
            this.hasDirectionMarker = hasDirectionMarker;
        }
        public static List<JMapDataLine> Parse(string markers)
        {
            List<JMapDataLine> mapDataMarker = new List<JMapDataLine>();
            foreach (string marker in markers.Split(new string[] { JMapData.BigSeprator }, StringSplitOptions.None))
            {
                string[] markerDetail = marker.Split(new string[] { JMapData.Seprator }, StringSplitOptions.None);
                mapDataMarker.Add(new JMapDataLine(Convert.ToSingle(markerDetail[0])
                                                    , Convert.ToSingle(markerDetail[1])
                                                    , Convert.ToSingle(markerDetail[2])
                                                    , Convert.ToSingle(markerDetail[3])
                                                    , markerDetail[4]
                                                    , markerDetail[5]
                                                    , markerDetail[6]
                                                    , Convert.ToInt32(markerDetail[7])
                                                    , Convert.ToInt32(markerDetail[8])
                                                    , markerDetail[9] == "True" ? true : false));
            }
            return mapDataMarker;
        }
        public static string Generate(List<JMapDataLine> Lines)
        {
            string result = "";
            foreach (JMapDataLine item in Lines)
                result += JMapData.BigSeprator
                        + item.LatitudeA + JMapData.Seprator
                        + item.LongitudeA + JMapData.Seprator
                        + item.LatitudeB + JMapData.Seprator
                        + item.LongitudeB + JMapData.Seprator
                        + item.Name + JMapData.Seprator
                        + item.Title + JMapData.Seprator
                        + item.Color + JMapData.Seprator
                        + item.Opacity + JMapData.Seprator
                        + item.Width + JMapData.Seprator
                        + (item.hasDirectionMarker == true ? "True" : "False");
            return result.Length > JMapData.BigSeprator.Length ? result.Substring(JMapData.BigSeprator.Length) : "";
        }

        public float LatitudeA;
        public float LongitudeA;
        public float LatitudeB;
        public float LongitudeB;
        public string Name;
        public string Title;
        public string Color;
        public int Opacity;
        public int Width;
        public bool hasDirectionMarker;
    }
    public class UserMarker
    {
        public string Name;
        public double Latitude;
        public double Longitude;

        public UserMarker() { }
        public UserMarker(string Name, double Latitude, double Longitude)
        {
            this.Name = Name;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
        }
        public static List<UserMarker> Parse(string userPoints)
        {
            var q = from v in userPoints.Split(new string[] { "{!~!}" }, StringSplitOptions.None)
                    where v != ""
                    select new UserMarker() { Name = v.Split(',')[0].ToString(), Longitude = Convert.ToDouble(v.Split(',')[1]), Latitude = Convert.ToDouble(v.Split(',')[2]) };
            return q != null ? q.ToList() : null;
        }
        public static string Generate(List<UserMarker> userPoints)
        {
            string result = "";
            foreach (UserMarker item in userPoints)
                result += "{!~!}" + item.Name + "," + item.Longitude + "," + item.Latitude;
            if (result.Length > 5) result = result.Substring(5);
            return result;
        }

        public static string GenerateInfo(string Name, string Title, string ImageURL, int ImageWidth, int ImageHeight)
        {
            return Name + JMapData.Seprator + Title + JMapData.Seprator + ImageURL + JMapData.Seprator + ImageWidth + JMapData.Seprator + ImageHeight;
        }
    }
    public class UserLine
    {
        public double LatitudeA;
        public double LongitudeA;
        public double LatitudeB;
        public double LongitudeB;

        public static List<UserLine> Parse(string userPoints)
        {
            var q = from v in userPoints.Split(new string[] { "{!~!}" }, StringSplitOptions.None)
                    from z in v.Split(',')
                    select new UserLine() { LongitudeA = Convert.ToDouble(z[1]), LatitudeA = Convert.ToDouble(z[0]), LongitudeB = Convert.ToDouble(z[3]), LatitudeB = Convert.ToDouble(z[2]) };
            return q != null ? q.ToList() : null;
        }
        public static string Generate(List<UserLine> userPoints)
        {
            string result = "";
            foreach (UserLine item in userPoints)
                result += "{!~!}" + item.LongitudeA + "," + item.LatitudeA + "#" + item.LongitudeB + "," + item.LatitudeB;
            if (result.Length > 5) result = result.Substring(5);
            return result;
        }
        public static string GenerateInfo(string Name, string Title, string Color, int Opacity, int LineWidth, bool hasDirection)
        {
            return Name + JMapData.Seprator + Title + JMapData.Seprator + Color + JMapData.Seprator + Opacity + JMapData.Seprator + LineWidth + JMapData.Seprator + (hasDirection == true ? "True" : "False");
        }

    }

    public enum MapVoidActions
    {
        ClearAll,
        ClearMarkers,
        ClearLines,
    }
    public enum MapPropertyActions
    {
        TimerInterval
    }

    public enum MapProvider
    {
        GoogleStreets,
        GooglePhysical,
        GoogleHybrid,
        GoogleSatellite,
        OpenStreetMap
    }

}