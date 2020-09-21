using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Coordinate
{
    /// <summary>
    /// This class will be sued for Coordinate table and GPSData table.
    /// Data is same but always should insert into GPSData and 
    /// in the Coordinate table can insert or update depending on the case.
    /// </summary>
    public class JCoordinate : ClassLibrary.JSystem
    {

        public string IMEI { get; set; }
        public string Battery { get; set; }
        public int DeviceCode { get; set; }
        public int ObjectCode { get; set; }
        public int Code { get; set; }
        public float lng { get; set; }
        public float lat { get; set; }
        public DateTime RegisterDateTime { get; set; }
        public DateTime DeviceSendDateTime { get; set; }
        
        public float Altitude { get; set; }
        public float Speed { get; set; }
        public int Angle { get; set; }
        public string location { get; set; }
        public JCoordinate()
        {

        }
        public string GetHtmlString(string id)
        {
            AVL.Coordinate.JCoordinate c=new JCoordinate();
            c.GetData(id);
            return string.Format(@"<div id='{0}' style='background-color:white;color:black;font-size:12px;border-radius:20px;box-shadow:0px 0px 1px gray;padding:5px '><img src='{1}' height='32px' width='32px' onClick=""var a=getElementById('{0}');a.parentNode.removeChild(a)""/><ul><li>مختصات جغرافیایی: {2}</li><li>ارتفاع: {3}</li><li>زاویه جغرافیایی:{4}</li><div>",
                "infoWindow"+id,
                "/WebAvl/Icons/Close.png",
                c.lat.ToString()+","+c.lng,
                c.Altitude,
                c.Angle);
        }
        public int Insert(bool isWeb = false,bool checkpermission=true)
        {
            bool hasPermission = true;
            if(checkpermission)
                hasPermission=ClassLibrary.JPermission.CheckPermission("AVL.Coordinate.JCoordinate.Insert");
            if (!hasPermission)
                return 0;
            JCoordinateTable AT = new JCoordinateTable();
            AT.SetValueProperty(this);
            Code = AT.Insert(0,true);


            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("AVL.Coordinate.JCoordinate", Code, 0, 0, 0, "ثبت مختصات", "", 0);
            if (Code > 0 && !isWeb)
                Nodes.DataTable.Merge(JCoordinates.GetDataTable(Code));
            return Code;
        }


        public bool Delete(bool isWeb = false)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.Coordinate.JCoordinate.Delete"))
                return false;
            JCoordinateTable AT = new JCoordinateTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                if (!isWeb)
                    Nodes.Delete(Nodes.CurrentNode);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("AVL.Coordinate.JCoordinate", AT.Code, 0, 0, 0, "حذف مختصات", "", 0);
                return true;
            }
            else return false;
        }
        public bool Update(bool isWeb = false)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.Coordinate.JCoordinate.Update"))
                return false;
            JCoordinateTable AT = new JCoordinateTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                if (!isWeb)
                    Nodes.Refreshdata(Nodes.CurrentNode, JCoordinates.GetDataTable(Code).Rows[0]);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("AVL.Coordinate.JCoordinate", AT.Code, 0, 0, 0, "ویرایش مختصات", "", 0);
                return true;
            }
            else
                return false;
        }

        public bool GetData(string pCode)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("select top 1 * from AVLCoordinate where Code=" + pCode);
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

        
        public static string[] GetObjects(string bounds)
        {

             List<string> bb = new List<string>();
             List<AVL.Controls.Map.GCommunicateObject> __datas = new List<AVL.Controls.Map.GCommunicateObject>();
        
            //Get all the objects of the current user.
            System.Data.DataTable dt = AVL.ObjectList.JObjectLists.GetDataTableToday(WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode);
            //Create an array to store data that will be send back to the google map control.
            AVL.Controls.Map.GCommunicateObject[] objects = new AVL.Controls.Map.GCommunicateObject[dt.Rows.Count];
            //Extract south west and north east from bounds string
            AVL.Controls.Map.BoundsObject NESW = AVL.Controls.Map.GCommunicateObject.BoundsStringtoPoints(bounds);
            //First item of returned array from BoundsStringtoPoints method is alwas South West, and second one is always North East
            AVL.Controls.Map.Point SW = NESW.SouthWest;
            AVL.Controls.Map.Point NE = NESW.NorthEast;
            //Loop through objects returned from AVLObjectList table.
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //Create a point object with latitude and longitude of current row.
                AVL.Controls.Map.PointD p = new AVL.Controls.Map.PointD(
                        Convert.ToDouble(dt.Rows[i]["LastLng"].ToString()),
                         Convert.ToDouble(dt.Rows[i]["LastLat"].ToString()));
                //Geofence using a circle. Specify whether point is in the area or not.
                //There is some other types of geofence methods in AVL.Geofence.JGeofence
                //Note that distance between 2 coordinate in map is so small.
                if (AVL.Geofence.JGeofence.IsInTheCircle(
                                 new AVL.Controls.Map.Point() { Latitude = SW.Latitude + (NE.Latitude - SW.Latitude) / 2, Longitude = SW.Longitude + (NE.Longitude - SW.Longitude) / 2 },
                                 ((NE.Latitude - SW.Latitude) / 2) > ((NE.Longitude - SW.Longitude) / 2) ? ((NE.Latitude - SW.Latitude) / 2) : ((NE.Longitude - SW.Longitude) / 2),
                                 new AVL.Controls.Map.Point() { Latitude = p.Y, Longitude = p.X }))
                {
                    //If point is in the area, it is allowed to pass through google map,
                    __datas.Add(new AVL.Controls.Map.GCommunicateObject()
                    {
                        ID = "Bus_" + dt.Rows[i]["Code"].ToString(),
                        Location = p
                    });
                }
            }
            //We need to pass just IDs of objects as an array of strings.
            //Here we do joining of objects that are so close to each other.
            //If third argumant increase,then objects should be closer to be joined.otherwise method will join the objects with longer distance.
            bb.Clear();
            foreach (AVL.Controls.Map.GCommunicateObject g in
                AVL.Controls.Map.Marker.JoinMarkers(NE.Longitude - SW.Longitude, __datas.ToArray(), 50))// o) //
                bb.Add(g.ID.ToString());
            return bb.ToArray();
        }
        public static List<AVL.Controls.Map.GCommunicateObject> GetCommunicationObjects(string bounds,string id,Dictionary<string,string[]> objects,int currentUserCode)
        {

            bool isinarea = true;
            System.Data.DataTable dt;
            string ids = " AND ol.Code IN(";
            if (id == "1")
            {
                if (objects[currentUserCode.ToString()].Length > 0)
                {
                    foreach (string aa in objects[currentUserCode.ToString()])
                        ids += aa + ",";
                    ids = ids.Remove(ids.Length - 1);
                    ids += ")";
                }
                else
                {
                    return null;
                }
            }
            else if (id.Contains(','))
            {
                foreach (string aa in id.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    ids += aa + ",";
                ids = ids.Remove(ids.Length - 1);
                ids += ")";
            }
            //Get fresh data from database.
            dt = WebClassLibrary.JWebDataBase.GetDataTable("select ol.* from AVLObjectList ol inner join " +
                " AVLCash c ON c.userCode=ol.personCode  where ol.personCode=" +
                    WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode + " AND  ol.lastSendDate > DATEADD(hour,-24,getdate())   AND (c.paid > 0) "+ ids);
            List<AVL.Controls.Map.GCommunicateObject> s = new List<AVL.Controls.Map.GCommunicateObject>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //Extract north east and south west from bounds string.
                AVL.Controls.Map.BoundsObject SwNe = AVL.Controls.Map.GCommunicateObject.BoundsStringtoPoints(bounds);
                AVL.Controls.Map.Point SW = SwNe.SouthWest;
                AVL.Controls.Map.Point NE = SwNe.NorthEast;
                //Create a point with latitude and longitude of current row.
                AVL.Controls.Map.PointD p = new AVL.Controls.Map.PointD(
                        Convert.ToDouble(dt.Rows[i]["LastLng"].ToString()),
                         Convert.ToDouble(dt.Rows[i]["LastLat"].ToString()));
                //Is in area or not? 
                if (!id.Contains(','))
                {
                    if (AVL.Geofence.JGeofence.IsInTheCircle(
                                     new AVL.Controls.Map.Point() { Latitude = SW.Latitude + (NE.Latitude - SW.Latitude) / 2, Longitude = SW.Longitude + (NE.Longitude - SW.Longitude) / 2 },
                                     ((NE.Latitude - SW.Latitude) / 2) > ((NE.Longitude - SW.Longitude) / 2) ? ((NE.Latitude - SW.Latitude) / 2) : ((NE.Longitude - SW.Longitude) / 2),
                                     new AVL.Controls.Map.Point() { Latitude = p.Y, Longitude = p.X }))
                    { isinarea = true; }
                    else
                        isinarea = false;
                }
                if (isinarea)
                {
                    AVL.Controls.Map.GCommunicateObject gObject = new AVL.Controls.Map.GCommunicateObject();
                    gObject.ID = "Bus_" + dt.Rows[i]["Code"].ToString();
                    gObject.Title = dt.Rows[i]["Label"].ToString();
                    WebClassLibrary.JActionsInfo action = new WebClassLibrary.JActionsInfo();
                    //     action.Name = dt.Rows[i]["ClassName"].ToString();
                    action.Method = dt.Rows[i]["ClassName"].ToString() + ".GetIcon";
                    action.ParameterValue = new List<object>();
                    action.ParameterValue.Add(dt.Rows[i]["ObjectCode"].ToString());
                    gObject.Icon = action.runAction().ToString();
                    // مختصات جدید مارکر
                    gObject.Location = new AVL.Controls.Map.PointD()
                    {
                        // NEW Longitude
                        X = Convert.ToDouble(dt.Rows[i]["LastLng"].ToString()),
                        //NEW Latitude
                        Y = Convert.ToDouble(dt.Rows[i]["LastLat"].ToString())
                    };
                    s.Add(gObject);
                }

            }
            return s;
        }
    }
}
