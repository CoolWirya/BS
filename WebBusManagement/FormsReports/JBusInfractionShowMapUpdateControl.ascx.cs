using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsReports
{
    public partial class JBusInfractionShowMapUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        int RuleCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            if (!IsPostBack)
            {
                GetReport(Code);
                //Stations
                ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).Provider = WebControllers.MainControls.OpenLayersMap.MapProvider.GoogleStreets;
                ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).CenterPosition = ClassLibrary.JConfig.CityCenterLong.ToString()
                    + "," + ClassLibrary.JConfig.CityCenterLat.ToString();
                ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).Zoom = "14";
                ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).Action = "WebBusManagement.FormsReports.JBusInfractionShowMapUpdateControl.test";
                ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).TimerEnabled = false;
                ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).TimerInterval = 0;
                //((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).MouseClickAddUserMarker = false;
                //((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).CanAddMultipleMarkers = false;
                //((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).DrawMarkers = false;
                //((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).DrawLines = false;
                ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).MarkerClick = false;

                BusServiceCode.Value = Code.ToString();

                PathMapStationAc.Value = WebClassLibrary.JDataManager.EncryptString("WebBusManagement.FormsReports.JBusInfractionShowMapUpdateControl.GetStation");

            }
        }
        public string[] test(string[] param)
        {
            return null;
            int i = 0;
            int.TryParse(param[1].Split('_')[1], out i);

            DataTable Data = WebClassLibrary.JWebDataBase.GetDataTable("select top 10 Code,(select LastLineNumber from AUTBUS where Code = BusCode) LineNumber,(select BusNumber from AUTBUS where Code = BusCode) BusNumber,StartDate ,EndDate from dbo.AUTInfractionRegister where Code = " + i.ToString(), false);
            DataTable DataLineCode2 = null;
            DataTable Dt2 = WebClassLibrary.JWebDataBase.GetDataTable("select Code, RuleCode from dbo.AUTInfractionRegister where Code=" + i.ToString(), false);
            if (Data != null)
            {
                DataLineCode2 = WebClassLibrary.JWebDataBase.GetDataTable(@"select Speed from AUTAvlTransaction where BusCode = (select code from AUTBus where BUSNumber = "
                              + Data.Rows[0]["BusNumber"].ToString() + @") and EventDate between '"
                              + Data.Rows[0]["StartDate"].ToString() + @"' and '"
                              + Data.Rows[0]["EndDate"].ToString() + @"' order by code");

            }
            if (Dt2 != null)
            {

                RuleCode = Int32.Parse(Dt2.Rows[0]["RuleCode"].ToString());

            }

            if (RuleCode == 4)
            {

                string Speed = DataLineCode2.Rows[0]["Speed"].ToString();
                return new string[]
                {
                 WebControllers.MainControls.OpenLayersMap.JMapData.GeneratePopup("<div class='Popup'>" + Speed + "</div>", 70, 32)
                };

            }
            return new string[] { "" };
        }
        private void getInfractionIcon(int RuleCode, int Param, int course, out string iconPath)
        {
            //string[] result = null;
            iconPath = "/defaultInfraction.png";
            //string MapIcon = "";
            DataTable DtLineCode = null;
            DataTable DtLineCode2 = null;
            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable("select top 10 Code,(select LastLineNumber from AUTBUS where Code = BusCode) LineNumber,(select BusNumber from AUTBUS where Code = BusCode) BusNumber,StartDate ,EndDate from dbo.AUTInfractionRegister where Code = " + Param, false);


            if (Dt != null)
            {
                if (Dt.Rows.Count > 0)
                {
                    DtLineCode = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Latitude,Longitude,Course,Speed from AUTAvlTransaction where BusCode = (select code from AUTBus where BUSNumber = "
                                + Dt.Rows[0]["BusNumber"].ToString() + @") and EventDate between '"
                                + Dt.Rows[0]["StartDate"].ToString() + @"' and '"
                                + Dt.Rows[0]["EndDate"].ToString() + @"' order by code");
                    DtLineCode2 = WebClassLibrary.JWebDataBase.GetDataTable(@"select Speed from AUTAvlTransaction where BusCode = (select code from AUTBus where BUSNumber = "
                                + Dt.Rows[0]["BusNumber"].ToString() + @") and EventDate between '"
                                + Dt.Rows[0]["StartDate"].ToString() + @"' and '"
                                + Dt.Rows[0]["EndDate"].ToString() + @"' order by code");

                }
            }

            if (DtLineCode != null && DtLineCode.Rows.Count > 0)
            {
                for (int i = 0; i < DtLineCode.Rows.Count; i++)
                {

                    switch (RuleCode)
                    {
                        case 1://nearnextbus
                            if (course >= 330 || course < 30)            // Up
                                iconPath = "/arrow_up_orange.png";
                            else if (course >= 30 && course < 60)        // Up Right
                                iconPath = "/arrow_upright_orange.png";
                            else if (course >= 60 && course < 120)       // Right
                                iconPath = "/arrow_right_orange.png";
                            else if (course >= 120 && course < 150)      // Down Right
                                iconPath = "/arrow_downright_orange.png";
                            else if (course >= 150 && course < 210)      // Down
                                iconPath = "/arrow_down_orange.png";
                            else if (course >= 210 && course < 240)      // Down Left
                                iconPath = "/arrow_downleft_orange.png";
                            else if (course >= 240 && course < 300)      // Left
                                iconPath = "/arrow_left_orange.png";
                            else if (course >= 300 && course < 330)      // Up Left
                                iconPath = "/arrow_upleft_orange.png";
                            break;
                        case 2://outline
                            if (course >= 330 || course < 30)            // Up
                                iconPath = "/arrow_up_green.png";
                            else if (course >= 30 && course < 60)        // Up Right
                                iconPath = "/arrow_upright_green.png";
                            else if (course >= 60 && course < 120)       // Right
                                iconPath = "/arrow_right_green.png";
                            else if (course >= 120 && course < 150)      // Down Right
                                iconPath = "/arrow_downright_green.png";
                            else if (course >= 150 && course < 210)      // Down
                                iconPath = "/arrow_down_green.png";
                            else if (course >= 210 && course < 240)      // Down Left
                                iconPath = "/arrow_downleft_green.png";
                            else if (course >= 240 && course < 300)      // Left
                                iconPath = "/arrow_left_green.png";
                            else if (course >= 300 && course < 330)      // Up Left
                                iconPath = "/arrow_upleft_green.png";
                            break;
                        case 3://unknowndriver
                            if (course >= 330 || course < 30)            // Up
                                iconPath = "/arrow_up_grey.png";
                            else if (course >= 30 && course < 60)        // Up Right
                                iconPath = "/arrow_upright_grey.png";
                            else if (course >= 60 && course < 120)       // Right
                                iconPath = "/arrow_right_grey.png";
                            else if (course >= 120 && course < 150)      // Down Right
                                iconPath = "/arrow_downright_grey.png";
                            else if (course >= 150 && course < 210)      // Down
                                iconPath = "/arrow_down_grey.png";
                            else if (course >= 210 && course < 240)      // Down Left
                                iconPath = "/arrow_downleft_grey.png";
                            else if (course >= 240 && course < 300)      // Left
                                iconPath = "/arrow_left_grey.png";
                            else if (course >= 300 && course < 330)      // Up Left
                                iconPath = "/arrow_upleft_grey.png";
                            break;
                        case 4://overspeed
                            if (course >= 330 || course < 30)            // Up
                                iconPath = "/arrow_up_red.png";
                            else if (course >= 30 && course < 60)        // Up Right
                                iconPath = "/arrow_upright_red.png";
                            else if (course >= 60 && course < 120)       // Right
                                iconPath = "/arrow_right_red.png";
                            else if (course >= 120 && course < 150)      // Down Right
                                iconPath = "/arrow_downright_red.png";
                            else if (course >= 150 && course < 210)      // Down
                                iconPath = "/arrow_down_red.png";
                            else if (course >= 210 && course < 240)      // Down Left
                                iconPath = "/arrow_downleft_red.png";
                            else if (course >= 240 && course < 300)      // Left
                                iconPath = "/arrow_left_red.png";
                            else if (course >= 300 && course < 330)      // Up Left
                                iconPath = "/arrow_upleft_red.png";
                            break;
                        case 5://longstop
                            if (course >= 330 || course < 30)            // Up
                                iconPath = "/arrow_up_purple.png";
                            else if (course >= 30 && course < 60)        // Up Right
                                iconPath = "/arrow_upright_purple.png";
                            else if (course >= 60 && course < 120)       // Right
                                iconPath = "/arrow_right_purple.png";
                            else if (course >= 120 && course < 150)      // Down Right
                                iconPath = "/arrow_downright_purple.png";
                            else if (course >= 150 && course < 210)      // Down
                                iconPath = "/arrow_down_purple.png";
                            else if (course >= 210 && course < 240)      // Down Left
                                iconPath = "/arrow_downleft_purple.png";
                            else if (course >= 240 && course < 300)      // Left
                                iconPath = "/arrow_left_purple.png";
                            else if (course >= 300 && course < 330)      // Up Left
                                iconPath = "/arrow_upleft_purple.png";
                            break;
                    }
                }
            }

            //return result;
        }
        public string[] GetStation(string[] param)
        {

            DataTable DtLineCode = null;
            DataTable DtLineStation = null;
            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable("select top 10 Code,(select LastLineNumber from AUTBUS where Code = BusCode) LineNumber,(select BusNumber from AUTBUS where Code = BusCode) BusNumber,StartDate ,EndDate from dbo.AUTInfractionRegister where Code = " + param[0].ToString(), false);
            DataTable Dt2 = WebClassLibrary.JWebDataBase.GetDataTable("select Code, RuleCode from dbo.AUTInfractionRegister where Code=" + param[0].ToString(), false);
            if (Dt != null)
            {
                if (Dt.Rows.Count > 0)
                {
                    DtLineCode = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Latitude,Longitude,Course,Speed  from AUTAvlTransaction where BusCode = (select code from AUTBus where BUSNumber = "
                                + Dt.Rows[0]["BusNumber"].ToString() + @") and EventDate between '"
                                + Dt.Rows[0]["StartDate"].ToString() + @"' and '"
                                + Dt.Rows[0]["EndDate"].ToString() + @"' order by code");


                    DtLineStation = WebClassLibrary.JWebDataBase.GetDataTable(@"
                    select s.Code,s.Lat,s.Lng,S.Name,als.IsBack from autLineStation als 
                    inner join AUTLine a ON als.LineCode=a.Code 
                    inner join AUTStation s on s.Code = als.StationCode
                    where a.LineNumber=" + Dt.Rows[0]["LineNumber"].ToString() + @" order by IsBack,Priority");
                }
            }

            if (Dt2 != null)
            {

                RuleCode = Int32.Parse(Dt2.Rows[0]["RuleCode"].ToString());

            }
            WebControllers.MainControls.OpenLayersMap.JMapData mapData = new WebControllers.MainControls.OpenLayersMap.JMapData();

            string MapIcon = "";
            int Param = Int32.Parse(param[0]);
            if (DtLineCode != null && DtLineCode.Rows.Count > 0)
            {
                for (int i = 0; i < DtLineCode.Rows.Count; i++)
                {

                    if (i == 0 || i == (DtLineCode.Rows.Count - 1))
                    {
                        if (i == 0)
                        {
                            MapIcon = "../WebBusManagement/Images/ViewMapArrowNew/A.png";    //Start Point
                        }
                        else
                        {
                            MapIcon = "../WebBusManagement/Images/ViewMapArrowNew/B.png";    //End Point
                        }

                    }

                    else
                    {
                        int course = Convert.ToInt32(DtLineCode.Rows[i]["Course"]) * 2;
                        string iconPath = "";
                        getInfractionIcon(RuleCode, Param, course, out iconPath);
                        MapIcon = "../WebBusManagement/Images/ViewMapArrowNew" + iconPath;

                    }


                    mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarker(Convert.ToSingle(DtLineCode.Rows[i]["Longitude"].ToString()),
                                              Convert.ToSingle(DtLineCode.Rows[i]["Latitude"].ToString()), "LinePoint_" + param[0].ToString(),
                                               "", MapIcon, 24, 24, 0, 0));
                }


                try
                {
                    if (DtLineStation != null && DtLineStation.Rows.Count > 0)
                    {
                        for (int i = 0; i < DtLineStation.Rows.Count; i++)
                        {


                            MapIcon = "../WebBusManagement/Images/station_s32.png";    //Start Point
                            mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarker(Convert.ToSingle(DtLineStation.Rows[i]["lng"].ToString()),
                                Convert.ToSingle(DtLineStation.Rows[i]["lat"].ToString()), "LinePoint_" + DtLineStation.Rows[i]["Code"].ToString(),
                                DtLineStation.Rows[i]["Name"].ToString(),
                                MapIcon, 24, 24, 90, 20));


                        }
                    }
                }
                catch (Exception ex)
                {
                    ClassLibrary.JMainFrame.Except.AddException(ex);
                }
                return mapData.GenerateMarkerStation();
            }
            return new string[] { "" };
        }



        public void GetReport(int BusServiceCode = 0)
        {

            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable("select top 10 Code,(select BusNumber from AUTBUS where Code = BusCode) BusNumber,StartDate ,EndDate from dbo.AUTInfractionRegister where Code = " + BusServiceCode.ToString(), false);

            if (Dt != null)
            {
                if (Dt.Rows.Count > 0)
                {
                    WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;
                    jGridView.ClassName = "WebBusManagement_FormsReports_JBusServiceShowMapUpdateControl_" + BusServiceCode.ToString();
                    jGridView.SQL = @"select bps.[Code]
                              ,bps.[EventDate]
                              ,bps.[BusNumber]
                              ,bps.[StationCode]
	                          ,ast.Name StationName
                              ,bps.[DriverPersonCode]
	                          ,cap.Name DriverName
                              ,bps.[InsertDate] 
	                          from AutBusPassingStations  bps
	                          left join AUTStation ast on ast.Code = bps.StationCode
	                          left join clsAllPerson cap on cap.Code = bps.DriverPersonCode
	                          where bps.BusNumber = " + Dt.Rows[0]["BusNumber"].ToString() + @" 
                              and bps.EventDate between '" + Dt.Rows[0]["StartDate"].ToString() + @"' and '" + Dt.Rows[0]["EndDate"].ToString() + @"'";
                    jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
                    jGridView.PageSize = 10;
                    //jGridView.HiddenColumns = "Code";
                    jGridView.Title = "JBusServiceShowMapUpdateControl";
                    jGridView.PageOrderByField = "EventDate asc";
                    jGridView.Buttons = "excel,print,record_print";
                    jGridView.Bind();
                }
            }
        }

        protected void btnSaveGo_Click(object sender, EventArgs e)
        {
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            string[] Param = new string[3] { "@Service_code", "@PathType", "@precision_factor" };// precision_factor is horizontal precision distance
            try
            {
                Db.ExecuteProcedure_Query("[dbo].[SP_UpdateAUTFleetLinePointsBySevice]", Param, new string[3] { Code.ToString(), 1.ToString(), 15.ToString() });
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
                Db.Dispose();
            }
        }

        protected void btnSaveBack_Click(object sender, EventArgs e)
        {
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            string[] Param = new string[3] { "@Service_code", "@PathType", "@precision_factor" };// precision_factor is horizontal precision distance
            try
            {
                Db.ExecuteProcedure_Query("[dbo].[SP_UpdateAUTFleetLinePointsBySevice]", Param, new string[3] { Code.ToString(), 2.ToString(), 15.ToString() });
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
                Db.Dispose();
            }
        }

    }
}
