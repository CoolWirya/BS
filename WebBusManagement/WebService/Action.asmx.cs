using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebBusManagement.WebService
{
    /// <summary>
    /// Summary description for Action
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Action : System.Web.Services.WebService, System.Web.SessionState.IRequiresSessionState
    {
        [WebMethod(EnableSession = true)]
        public object[] RunAction(string actionString, string[] param)
        {
            actionString = WebClassLibrary.JDataManager.DecryptString(actionString);
            ClassLibrary.JAction action = new ClassLibrary.JAction("", actionString, new object[] { param }, null);
            return (object[])action.run();
        }

        /*
         * AVL
         * /
         */
        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod]
        //[WebMethod(EnableSession = true)]
        public AVL.Controls.Map.GCommunicateObject[] GetCarsNew(string bounds)
        {
            //تشخیص مختصات صفحه. 
            //bounds
            //تشکیل شده از 2 نقطه چپ پایین و راست بالا که با 
            //داشتن این 2 نقطه می توان چهارچوب صفحه را تشخیص و تنها اتوبوس هایی که در این محدوده 
            // هستند را به حرکت داد.
            if (string.IsNullOrEmpty(bounds))
                return null;
            string _sw = bounds.Split(new string[] { "), " }, StringSplitOptions.RemoveEmptyEntries)[0];
            string _ne = bounds.Split(new string[] { "), " }, StringSplitOptions.RemoveEmptyEntries)[1];
            float lat, lng;
            lat = float.Parse(_sw.Split(new string[] { "((", ",", "\"" }, StringSplitOptions.RemoveEmptyEntries)[0].Trim(), new System.Globalization.CultureInfo("en-US"));
            lng = float.Parse(_sw.Split(new string[] { "((", ",", "\"" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim(), new System.Globalization.CultureInfo("en-US"));
            AVL.Controls.Map.Point SW = new AVL.Controls.Map.Point()
            {
                Latitude = lat,
                Longitude = lng
            };
            lat = float.Parse(_ne.Split(new string[] { "(", ",", "\"" }, StringSplitOptions.RemoveEmptyEntries)[0].Trim(), new System.Globalization.CultureInfo("en-US"));
            lng = float.Parse(_ne.Split(new string[] { "))", ",", "\"" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim(), new System.Globalization.CultureInfo("en-US"));
            AVL.Controls.Map.Point NE = new AVL.Controls.Map.Point()
            {
                Latitude = lat,
                Longitude = lng
            };
            string query = "select Code,BUSNumber,LastLatitude,LastLongitude,LastCourse from AUTBus where Active = 1 and IsValid = 1 and LastDate > DATEADD(hour,-24,getdate())";
           //تشخیص اتوبوس های در چهارچوب توسط 
            //sql
            //انجام می شود.
            query += " AND " +
         string.Format("LastLatitude BETWEEN {0} AND {1} AND LastLongitude BETWEEN {2} AND {3} ; ",
        SW.Latitude,
        NE.Latitude,
        SW.Longitude,
        NE.Longitude);

            System.Data.DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(query);
            //List<AVL.Controls.Map.GCommunicateObject> busses = new List<AVL.Controls.Map.GCommunicateObject>();
            AVL.Controls.Map.GCommunicateObject[] buses = new AVL.Controls.Map.GCommunicateObject[dt.Rows.Count];
            string ImgUrl = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[i]["LastCourse"].ToString()) < 150)
                {
                    ImgUrl = "../WebBusManagement/Images/bus_s64_right.png";
                }
                else
                {
                    ImgUrl = "../WebBusManagement/Images/bus_s64.png";
                }

                buses[i] = new AVL.Controls.Map.GCommunicateObject()
                {
                    Icon = ImgUrl,
                    ID = "Bus_" + dt.Rows[i]["Code"].ToString(),
                    Location = new AVL.Controls.Map.PointD(Convert.ToDouble(dt.Rows[i]["LastLatitude"].ToString()), Convert.ToDouble(dt.Rows[i]["LastLongitude"].ToString())),
                    Title = dt.Rows[i]["BUSNumber"].ToString()
                };
            }
            buses = AVL.Controls.Map.Marker.JoinMarkers(NE.Longitude - SW.Longitude, buses, 80);
            return buses;
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod]
        public string GetPoupuoCars(string id)
        {
            return id.ToString();// string.Format("<strong>SAMPLE {0}</strong>", id);
        }

    }
}
