using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

namespace WebBusManagement.WebService
{
    /// <summary>
    /// Summary description for AvlWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AvlWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public bool AddAvl(float Longitude, float Latitude, uint Altitude, uint Speed, uint Cource, string EventDate, uint SimCharge, uint BusSerial, string IMEI, byte[] Header_Version, uint BatteryCharge,
            uint GpsAnttena, uint GsmAnttena, long recordNumber, uint transactionid, uint Dir)
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            db.Params.Clear();
            if (db.Params.Count > 0)
            {
                try
                {
                    db.Params.Remove("Longitude");
                    db.Params.Remove("Latitude");
                    db.Params.Remove("Altitude");
                    db.Params.Remove("Speed");
                    db.Params.Remove("Course");
                    db.Params.Remove("EventDate");
                    db.Params.Remove("SimCardCharge");
                    db.Params.Remove("BusSerial");
                    db.Params.Remove("IMEI");
                    db.Params.Remove("Version");
                    db.Params.Remove("BatteryCharge");
                    db.Params.Remove("GpsAnt");
                    db.Params.Remove("GsmAnt");
                    db.Params.Remove("recordNumber");
                    db.Params.Remove("TransactionID");
                    db.Params.Remove("Dir");
                }
                catch
                {
                }
            }

            db.setQuery(@"EXEC SP_InsertAUTAvlTransaction_Zarrin_Save_Just_Point
	                    @Longitude,
	                    @Latitude,
	                    @Altitude,
	                    @Speed,
	                    @Course,
	                    @EventDate,
	                    @SimCardCharge,
	                    @BusSerial,
	                    @IMEI,
	                    @Version,
	                    @BatteryCharge,
	                    @GpsAnt,
	                    @GsmAnt,
	                    @recordNumber,
	                    @TransactionID,
                        @Dir");
            db.AddParams("Longitude", ConvertNMEAToDecimal(Longitude));
            db.AddParams("Latitude", ConvertNMEAToDecimal(Latitude));
            db.AddParams("Altitude", Altitude.ToString());
            db.AddParams("Speed", Speed.ToString());
            db.AddParams("Course", Cource.ToString());
            db.AddParams("EventDate", EventDate.ToString());
            db.AddParams("SimCardCharge", SimCharge.ToString());
            db.AddParams("BusSerial", BusSerial.ToString());
            db.AddParams("IMEI", IMEI.ToString());
            db.AddParams("Version", Header_Version.ToString());
            db.AddParams("BatteryCharge", BatteryCharge.ToString());
            db.AddParams("GpsAnt", GpsAnttena.ToString());
            db.AddParams("GsmAnt", GsmAnttena.ToString());
            db.AddParams("recordNumber", recordNumber.ToString());
            db.AddParams("TransactionID", transactionid.ToString());
            db.AddParams("Dir", Dir);
            if (db.Query_Execute() >= 0)
            {
                db.Params.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static double ConvertNMEAToDecimal(double d)
        {
            double o = 0;
            string[] str = d.ToString("00.0000").Split(new char[] { '.', '/' });
            try
            {
                o = Convert.ToDouble(str[1].Substring(0, 2) + "." + str[1].Substring(2, 2));
            }
            catch
            {
                o = Convert.ToDouble(str[1].Substring(0, 2) + "/" + str[1].Substring(2, 2));
            }
            return Convert.ToDouble(str[0]) + (o / 60);
        }

    }
}
