using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebAVL.Forms
{
    public partial class JLinePathMap : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).Provider = WebControllers.MainControls.OpenLayersMap.MapProvider.GoogleStreets;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).CenterPosition = "46.294956,38.068636";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).Zoom = "12";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).Action = "WebBusManagement.FormsManagement.JLinePathMap.GetLineMarker";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).TimerEnabled = false;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).TimerInterval = 0;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMap).MarkerClick = false;

            LineMapActionString.Value = WebClassLibrary.JDataManager.EncryptString("WebBusManagement.FormsManagement.JLinePathMap.GetLineMarker");

            if (!IsPostBack)
            {
                LoadLines();
            }

        }

        public void LoadLines()
        {
            DataTable dt = BusManagment.Line.JLines.GetWebDataTable(0);
            cmbLines.DataSource = dt;
            cmbLines.DataTextField = "LineNumber";
            cmbLines.DataValueField = "Code";
            cmbLines.DataBind();
        }

        public int GetLineCodeFromLineNumber(string LineNumber)
        {
            int res = 0;
            string Query = @"Select top 1 Code From AUTLine where LineNumber=" + LineNumber;
            DataTable DtMarkers = WebClassLibrary.JWebDataBase.GetDataTable(Query);
            res = Convert.ToInt32(DtMarkers.Rows[0][0].ToString());
            return res;
        }


        public object[] GetLineMarker(string[] Param)
        {
            DataTable DtMarkers;
            WebControllers.MainControls.OpenLayersMap.JMapData mapData = new WebControllers.MainControls.OpenLayersMap.JMapData();

            float num1;
            bool res = float.TryParse(Param[0].ToString(), out num1);

            if (res == true)
            {

//                string Query = @"SELECT als.*,ast.Lat as Latitude,ast.Lng as Longitude,ast.Name FROM AUTLineStation als LEFT JOIN AUTStation ast ON als.StationCode=ast.Code
//                                 left join AutLine al on al.Code = als.LineCode
//                                 Where al.LineNumber=" + num1 + @" and IsBack = " + Param[1].ToString() + @"
//                                 and ast.Lng is not null and ast.lat is not null
//                                 ORDER BY als.Priority ASC";
                string Query = @"select afp.Code,afp.LineCode,afp.Latitude,afp.Longitude,afp.OrderNo,afp.PathType from AUTFleetLinePoints afp
								 left join AUTLine al on al.Code = afp.LineCode
								 where al.LineNumber = " + num1 + @" and afp.PathType = " + Param[1].ToString() + @"
								 and afp.Latitude is not null and afp.Longitude is not null
								 order by afp.OrderNo asc";

                DtMarkers = WebClassLibrary.JWebDataBase.GetDataTable(Query);
                //DtMarkers = BusManagment.Line.JLinePoints.GetDataTable(GetLineCodeFromLineNumber(num1.ToString()));
                string[] ColorArray = new string[0];
                int JNumber = 1;
                if (DtMarkers != null)
                {
                    int DtMarkersRowCount = 0;
                    DtMarkersRowCount = DtMarkers.Rows.Count;
                    if (DtMarkersRowCount > 0)
                    {
                        ColorArray = new string[DtMarkersRowCount];
                        for (int i = 0; i < DtMarkersRowCount; i++)
                        {
                            ColorArray[i] = "ff0000";

                            string direction_arrow = "";

                            if (i == 0 || i == (DtMarkers.Rows.Count - 1))
                            {
                                if (i == 0)
                                {
                                    direction_arrow = "../WebBusManagement/Images/ViewMapArrow/A.png";    //Start Point
                                }
                                else
                                {
                                    direction_arrow = "../WebBusManagement/Images/ViewMapArrow/B.png";    //Finish Point
                                }
                            }
                            else
                            {
                                direction_arrow = "../WebBusManagement/Images/station_s64.png";
                            }

                            mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarker(Convert.ToSingle(DtMarkers.Rows[i]["Longitude"]),
                                Convert.ToSingle(DtMarkers.Rows[i]["Latitude"]), "LinePoint" + JNumber.ToString(),
                                "نقطه " + JNumber.ToString(), direction_arrow, 16, 16, 40, 20));
                            JNumber++;
                        }
                    }
                    return new object[] { DtMarkersRowCount, mapData.Generate(), ColorArray };
                }
                else
                {
                    return new object[] { 0, 0, 0 };
                }
            }
            else
            {
                return null;
            }
        }

    }
}