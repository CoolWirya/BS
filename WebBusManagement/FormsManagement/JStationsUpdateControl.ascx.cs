using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusManagment.Zone;
using System.Data;
using BusManagment.Station;
using ClassLibrary;

namespace WebBusManagement.FormsManagement
{
    public partial class JStationsUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            LoadZones();
            StationType();
            _SetForm();

            //Stations
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).Provider = WebControllers.MainControls.OpenLayersMap.MapProvider.GoogleStreets;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).CenterPosition = ClassLibrary.JConfig.CityCenterLong.ToString()
                + "," + ClassLibrary.JConfig.CityCenterLat.ToString();
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).Zoom = "15";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).Action = "WebBusManagement.FormsManagement.JStationsUpdateControl.ServiceAction";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).TimerEnabled = false;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).TimerInterval = 0;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).MouseClickAddUserMarker = true;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).CanAddMultipleMarkers = false;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).DrawMarkers = true;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).DrawLines = false;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).MarkerClick = false;


            PathMapStationAc.Value = WebClassLibrary.JDataManager.EncryptString("WebBusManagement.FormsManagement.JStationsUpdateControl.GetStation");

        }

        public void GetStationBusLocation()
        {
            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select top 100 Latitude,Longitude,Course,Speed from AUTAvlTransaction 
                                                                        where EventDate between DATEADD(hour,-23,getdate()) and DATEADD(hour,-22,getdate())
                                                                        and dbo.GetGpsDistance(Latitude,Longitude,38.08551660000000,46.30283330000000)<50");
            if (Dt != null)
            {
                if (Dt.Rows.Count > 0)
                {

                }
            }
        }

        public void LoadZones()
        {
            DataTable DtZone = new DataTable();
            DtZone = JZones.GetDataTable(0);
            cmbZoneCode.DataSource = DtZone;
            cmbZoneCode.DataTextField = "Name";
            cmbZoneCode.DataValueField = "Code";
            cmbZoneCode.DataBind();
        }

        public void StationType()
        {
            DataTable Station = new DataTable();
            Station = (new BusManagment.Station.JStationTypes()).GetList();
            cmbStationType.DataSource = Station;
            cmbStationType.DataTextField = "Name";
            cmbStationType.DataValueField = "Code";
            cmbStationType.DataBind();
        }


        public string SetCenterStationMapScript = "";
        public void _SetForm()
        {
            ((WebControllers.Property.JPropertyViewControl)JPropertyViewControl).ClassName = "BusManagment.Station";
            ((WebControllers.Property.JPropertyViewControl)JPropertyViewControl).ObjectCode = 1000002;
            ((WebControllers.Property.JPropertyViewControl)JPropertyViewControl).ValueObjectCode = Code;
            ((WebControllers.Property.JPropertyViewControl)JPropertyViewControl).isMultiple = false;
            ((WebControllers.Property.JPropertyViewControl)JPropertyViewControl).LoadProperty();

            if (Code > 0)
            {
                BusManagment.Station.JStation Station = new BusManagment.Station.JStation();
                Station.GetData(Code);
                txtName.Text = Station.Name;
                cmbZoneCode.SelectedValue = Station.ZoneCode.ToString();
                cmbStationType.SelectedValue = Station.StationTypeCode.ToString();
                chkIsTerminal.Checked = Station.isTerminal;
                txtAddress.Text = Station.Address;
                txtMainCode.Text = Station.StationCode;
                txtRadius.Text = Station.Radius.ToString();
                txtAngle.Text = Station.Angle.ToString();
                txtIMEI.Text = Station.IMEI.ToString();
                txtMinSpeed.Text = Station.MinSpeed.ToString();
                if ((Station.Lng != Convert.ToDecimal(0)) && (Station.Lat != Convert.ToDecimal(0)))
                {
                    txtLat.Text = Station.Lat.ToString();
                    txtLng.Text = Station.Lng.ToString();
                    LatV.Value = Station.Lat.ToString();
                    LngV.Value = Station.Lng.ToString();

                    ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).UserMarkers =
                        new List<WebControllers.MainControls.OpenLayersMap.UserMarker>() { new WebControllers.MainControls.OpenLayersMap.UserMarker("USM_" + Station.Lat.ToString() + Station.Lng.ToString(), Convert.ToDouble(Station.Lat), Convert.ToDouble(Station.Lng)) };

                    // List<WebControllers.MainControls.OpenLayersMap.UserMarker>  aa = new List<WebControllers.MainControls.OpenLayersMap.UserMarker>();


                    //((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).CenterPosition = Station.Lat.ToString() + "," + Station.Lng.ToString();
                    //((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).Zoom = "18";



                    //                    DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select top 100 Latitude,Longitude,Course,Speed from AUTAvlTransaction 
                    //                                                                        where EventDate between DATEADD(hour,-23,getdate()) and DATEADD(hour,-22,getdate())
                    //                                                                        and dbo.GetGpsDistance(Latitude,Longitude," + Station.Lat.ToString() + @"," + Station.Lng.ToString() + @")<50");
                    //if (Dt != null)
                    //{
                    //    if (Dt.Rows.Count > 0)
                    //    {
                    //        for (int i = 0; i < Dt.Rows.Count; i++ )
                    //        {
                    //            aa.Add(new WebControllers.MainControls.OpenLayersMap.UserMarker("Station_" + Dt.Rows[i]["Latitude"].ToString() + Dt.Rows[i]["Longitude"].ToString(), Convert.ToDouble(Dt.Rows[i]["Latitude"].ToString()), Convert.ToDouble(Dt.Rows[i]["Longitude"].ToString())));
                    //        }
                    //    }
                    //}

                    // aa.Add(new WebControllers.MainControls.OpenLayersMap.UserMarker("USM_" + Station.Lat.ToString() + Station.Lng.ToString(), Convert.ToDouble(Station.Lat), Convert.ToDouble(Station.Lng)));

                    //((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).UserMarkers = aa;

                    SetCenterStationMapScript = "MapSetCenterWithZoom(" + Station.Lng.ToString() + "," + Station.Lat.ToString() + ",13);";

                }
                LoadImage();
            }
        }

        public string[] GetStation(string[] param)
        {
            DataTable DtLineCode = WebClassLibrary.JWebDataBase.GetDataTable(@"select top 100 Code,Latitude,Longitude,Course,Speed from AUTAvlTransaction 
                                                                        where EventDate between DATEADD(hour,-23,getdate()) and DATEADD(hour,-22,getdate())
                                                                        and dbo.GetGpsDistance(Latitude,Longitude," + param[0].ToString() + @"," + param[1].ToString() + @")<50");

            WebControllers.MainControls.OpenLayersMap.JMapData mapData = new WebControllers.MainControls.OpenLayersMap.JMapData();
            mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarker(Convert.ToSingle(param[1].ToString()),
                            Convert.ToSingle(param[0].ToString()), "USM_" + param[0].ToString(),
                            "",
                            "", 24, 24, 0, 0));

            if (DtLineCode != null)
            {

                for (int i = 0; i < DtLineCode.Rows.Count; i++)
                {
                    mapData.AddData(new WebControllers.MainControls.OpenLayersMap.JMapDataMarker(Convert.ToSingle(DtLineCode.Rows[i]["Longitude"]),
                            Convert.ToSingle(DtLineCode.Rows[i]["Latitude"]), "Station_" + DtLineCode.Rows[i]["Code"].ToString(),
                            "",
                            "", 24, 24, 0, 0));
                }

                return mapData.GenerateMarkerStation();
            }
            return new string[] { "" };
        }

        public bool Save()
        {
            Int64 IMEI = 0;
            int MinSpeed = 0, ZoneCode = 0, StationTypeCode = 0, Radius = 0, Angle = 0;
            Int64.TryParse(txtIMEI.Text.Trim(), out IMEI);
            Int32.TryParse(txtMinSpeed.Text, out MinSpeed);
            Int32.TryParse(cmbZoneCode.SelectedValue, out ZoneCode);
            Int32.TryParse(cmbStationType.SelectedValue, out StationTypeCode);
            Int32.TryParse(txtRadius.Text, out Radius);
            Int32.TryParse(txtAngle.Text, out Angle);
            BusManagment.Station.JStation Station = new BusManagment.Station.JStation();
            Station.Code = Code;
            Station.Name = txtName.Text;
            Station.ZoneCode = ZoneCode;
            Station.StationTypeCode = StationTypeCode;
            Station.isTerminal = chkIsTerminal.Checked;
            Station.Address = txtAddress.Text;
            Station.StationCode = txtMainCode.Text;
            Station.Radius = Radius;
            Station.Angle = Angle;
            Station.IMEI = IMEI;
            Station.MinSpeed = MinSpeed;
            if (IMEI > 0 && Station.FindDuplicate())
                return false;
            //  if (((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).UserMarkers.Count() > 0)
            // {
            //     Station.Lng = Convert.ToDecimal(((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).UserMarkers[0].Longitude);
            //    Station.Lat = Convert.ToDecimal(((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).UserMarkers[0].Latitude);
            // }
            // else
            // {
            try
            {
                Station.Lng = Convert.ToDecimal(txtLng.Text);
                Station.Lat = Convert.ToDecimal(txtLat.Text);
            }
            catch
            {
                try
                {
                    Station.Lng = (decimal)(float.Parse(txtLng.Text.Split(' ')[0]) + float.Parse(txtLng.Text.Split(' ')[1]) / 60);
                    Station.Lat = (decimal)(float.Parse(txtLat.Text.Split(' ')[0]) + float.Parse(txtLat.Text.Split(' ')[1]) / 60);
                }
                catch
                {
                    Station.Lat = 0;
                    Station.Lng = 0;
                }
            }
            // }


            //BusManagment.Query.JQueryAutoAuto QueryAuto = new BusManagment.Query.JQueryAutoAuto();

            if (Code > 0)
            {




                ((WebControllers.Property.JPropertyViewControl)JPropertyViewControl).ValueObjectCode = Code;
                if (Station.Update(true)) return true;
                //{
                //    QueryAuto.Name = "Update Station";
                //    QueryAuto.QueryText = @"update station set 'Name' = '" + txtName.Text + @"','Lat'='" + txtLat.Text + @"','Lon'='" + txtLng.Text + @"','Radius' = " + txtRadius.Text + @",'Angle' = " + txtAngle.Text + @" where ""Code"" = " + Code;
                //    QueryAuto.DataBaseName = "Local_Bus_Sqlite";
                //    QueryAuto.Insert();

                //    ((WebControllers.Property.JPropertyViewControl)JPropertyViewControl).Save();
                //    return true;
                //}
            }
            else
            {
                Code = Station.Insert(true);
                if (Code > 0) return true;
                //{
                //    QueryAuto.Name = "Insert Station";
                //    QueryAuto.QueryText = @"insert into station('Code','Name','Lat','Lon','Radius','Angle')  values(" + Code + ",'" + txtName.Text + @"','" + txtLat.Text + @"','" + txtLng.Text + @"'," + txtRadius.Text + @"," + txtAngle.Text + @")";
                //    QueryAuto.DataBaseName = "Local_Bus_Sqlite";
                //    QueryAuto.Insert();

                //    ((WebControllers.Property.JPropertyViewControl)JPropertyViewControl).ValueObjectCode = Code;
                //    ((WebControllers.Property.JPropertyViewControl)JPropertyViewControl).Save();
                //    return true;
                //}

            }

            return false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT [Code]
            //                                                                                ,[ZoneCode]+1000000 ZCode
            //                                                                                ,[LineNumber]
            //	                                                                            ,substring(cast([LineNumber] as nvarchar),1,3)LineN
            //	                                                                            ,substring(cast([LineNumber] as nvarchar),5,1)IsBackS
            //                                                                                ,[Name]
            //                                                                                ,[Scode]
            //                                                                                ,[SOCode]
            //                                                                                ,[Lan] OLDLAN
            //                                                                                ,[Lat] OLDLAT
            //																				
            //																				,
            //
            //
            //																				CASE
            //WHEN len(Lan)=7 THEN ROUND (cast(substring(Lan, 1, 1) as numeric(10,5)) +  cast(substring(Lan, 3, 2) as numeric(10,5))/60 +  cast(substring(Lan, 6, 2) as numeric(10,5))/3600,4) 
            //WHEN len(Lan)=8  THEN ROUND (cast(substring(Lan, 1, 2) as numeric(10,5)) +  cast(substring(Lan, 4, 2) as numeric(10,5))/60 +  cast(substring(Lan, 7, 2) as numeric(10,5))/3600,4)
            //ELSE
            //ROUND (CAST (Lan as Numeric(10,5)),4)
            //END AS Lan,
            //CASE
            //WHEN len(Lat)=7 THEN ROUND (cast(substring(Lat, 1, 1) as numeric(10,5)) +  cast(substring(Lat, 3, 2) as numeric(10,5))/60 +  cast(substring(Lat, 6, 2) as numeric(10,5))/3600,4) 
            //WHEN len(Lat)=8  THEN ROUND (cast(substring(Lat, 1, 2) as numeric(10,5)) +  cast(substring(Lat, 4, 2) as numeric(10,5))/60 +  cast(substring(Lat, 7, 2) as numeric(10,5))/3600,4)
            //ELSE
            //ROUND (CAST (Lat as Numeric(10,5)),4)
            //END AS Lat
            //                                                                            FROM [dbo].[NSList] 
            //																			where Linenumber not in (2000) and Lan Is Not Null and Lat Is Not Null
            //																			and Len(lan) in (8) and Len(lat) in (8)
            //																			order by LineNumber");
            //            ClassLibrary.JDataBase dbinsert = new ClassLibrary.JDataBase();
            //            string qurey = "";
            //            DataTable QuerySatation;
            //            for (int i = 0; i < dt.Rows.Count; i++)
            //            {
            //                QuerySatation = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code from AUTStation where (Name = N'" + dt.Rows[i]["Name"].ToString() + @"' and ZoneCode = " + dt.Rows[i]["ZCode"].ToString() + @") and lat = '" + dt.Rows[i]["Lat"].ToString() + "' and lng = '" + dt.Rows[i]["Lan"].ToString() + "' ");
            //                if (QuerySatation != null)
            //                {
            //                    if (QuerySatation.Rows.Count > 0)
            //                    {
            //                        qurey = @" INSERT INTO [dbo].[AUTLineStation]
            //                                                           ([Code]
            //                                                           ,[LineCode]
            //                                                           ,[StationCode]
            //                                                           ,[IsBack]
            //                                                           ,[Priority])
            //                                                     VALUES
            //                                                           ((select isnull(max(code),0)+1 from AUTLineStation)
            //                                                           ,(select code from autline where linenumber = " + dt.Rows[i]["LineN"].ToString() + @")
            //                                                           ," + QuerySatation.Rows[0]["Code"].ToString() + @"
            //                                                           ," + dt.Rows[i]["IsBackS"].ToString() + @"
            //                                                           ," + Convert.ToInt32(i + 1).ToString() + @") ";
            //                    }
            //                    else
            //                    {
            //                        BusManagment.Station.JStation s = new JStation();
            //                        s.StationCode = dt.Rows[i]["SOCode"].ToString();
            //                        s.Name = dt.Rows[i]["Name"].ToString();
            //                        s.ZoneCode = Convert.ToInt32(dt.Rows[i]["ZCode"].ToString());
            //                        s.StationTypeCode = 81140151;
            //                        s.Lat = Convert.ToDecimal(dt.Rows[i]["Lat"].ToString());
            //                        s.Lng = Convert.ToDecimal(dt.Rows[i]["Lan"].ToString());
            //                        s.isTerminal = false;
            //                        s.Insert(true);
            //                        DataTable Scodedt = WebClassLibrary.JWebDataBase.GetDataTable(@"select max(COde)Code from AUTStation");
            //                        qurey = @" INSERT INTO [dbo].[AUTLineStation]
            //                                                           ([Code]
            //                                                           ,[LineCode]
            //                                                           ,[StationCode]
            //                                                           ,[IsBack]
            //                                                           ,[Priority])
            //                                                     VALUES
            //                                                           ((select isnull(max(code),0)+1 from AUTLineStation)
            //                                                           ,(select code from autline where linenumber = " + dt.Rows[i]["LineN"].ToString() + @")
            //                                                           ," + Scodedt.Rows[0]["Code"].ToString() + @"
            //                                                           ," + dt.Rows[i]["IsBackS"].ToString() + @"
            //                                                           ," + Convert.ToInt32(i + 1).ToString() + @") ";
            //                    }
            //                }
            //                else
            //                {
            //                    BusManagment.Station.JStation s = new JStation();
            //                    s.StationCode = dt.Rows[i]["SOCode"].ToString();
            //                    s.Name = dt.Rows[i]["Name"].ToString();
            //                    s.ZoneCode = Convert.ToInt32(dt.Rows[i]["ZCode"].ToString());
            //                    s.StationTypeCode = 81140151;
            //                    s.Lat = Convert.ToDecimal(dt.Rows[i]["Lat"].ToString());
            //                    s.Lng = Convert.ToDecimal(dt.Rows[i]["Lan"].ToString());
            //                    s.isTerminal = false;
            //                    s.Insert(true);
            //                    DataTable Scodedt = WebClassLibrary.JWebDataBase.GetDataTable(@"select max(COde)Code from AUTStation");
            //                    qurey = @" INSERT INTO [dbo].[AUTLineStation]
            //                                                           ([Code]
            //                                                           ,[LineCode]
            //                                                           ,[StationCode]
            //                                                           ,[IsBack]
            //                                                           ,[Priority])
            //                                                     VALUES
            //                                                           ((select isnull(max(code),0)+1 from AUTLineStation)
            //                                                           ,(select code from autline where linenumber = " + dt.Rows[i]["LineN"].ToString() + @")
            //                                                           ," + Scodedt.Rows[0]["Code"].ToString() + @"
            //                                                           ," + dt.Rows[i]["IsBackS"].ToString() + @"
            //                                                           ," + Convert.ToInt32(i + 1).ToString() + @") ";
            //                }
            //                dbinsert.setQuery(qurey);
            //                dbinsert.Query_Execute();

            //             //   dbinsert.setQuery("Update NSList set Linenumber = 2000 where Code = " + dt.Rows[i]["Code"].ToString());
            //               // dbinsert.Query_Execute();
            //            }

            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //BusManagment.Query.JQueryAutoAuto QueryAuto = new BusManagment.Query.JQueryAutoAuto();
            BusManagment.Line.JLineStation LineStation = new BusManagment.Line.JLineStation();
            LineStation.DeleteByStationCode(Code);
            BusManagment.Station.JStation Station = new BusManagment.Station.JStation();
            Station.Code = Code;
            if (Station.Delete(true)) { WebClassLibrary.JWebManager.CloseAndRefresh(); }
            //{
            //    QueryAuto.Name = "Delete Station";
            //    QueryAuto.QueryText = @"delete from station where ""code"" = " + Code;
            //    QueryAuto.DataBaseName = "Local_Bus_Sqlite";
            //    QueryAuto.Insert();
            //    WebClassLibrary.JWebManager.CloseAndRefresh();
            //}

        }

        protected void btnSaveFromMap_Click(object sender, EventArgs e)
        {
            decimal lng, lat;
            ClassLibrary.JDataBase db = null;
            
            try
            {
                db= new ClassLibrary.JDataBase();
                if (((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).UserMarkers.Count() > 0)
                {
                    lng = Convert.ToDecimal(((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).UserMarkers[0].Longitude);
                    lat = Convert.ToDecimal(((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStations).UserMarkers[0].Latitude);
                    if (Code > 0)
                    {
                        //BusManagment.Station.JStation Station = new BusManagment.Station.JStation();
                        // Station.Code = Code;
                        db.setQuery("update autstation set lat = " + lat.ToString() + ", lng = " + lng.ToString() + " where code = " + Code);

                        if (db.Query_Execute() >= 0)
                        {
                            WebClassLibrary.JWebManager.RunClientScript("alert('نقطه جدید ایستگاه با موفقیت ثبت شد');", "UpdateSettings");
                        }
                        txtLng.Text = lng.ToString();
                        txtLat.Text = lat.ToString();

                    }
                }
            }
            finally
            {
                db.Dispose();
            }
        }
        protected void btnSetAngle_Click(object sender, EventArgs e)
        {
            ClassLibrary.JDataBase db1 = null;
            try
            {
                db1 = new ClassLibrary.JDataBase();
                db1.setQuery("exec [dbo].[UpdateCourseByStationCode] @station_code = " + Code);
                db1.Query_Execute(true);
            }
            finally
            {
                if (db1 != null)
                    db1.Dispose();
            }

        }

        protected void btnSetAngleFinal_Click(object sender, EventArgs e)
        {
            ClassLibrary.JDataBase db1 = null;
            try
            {
                db1 = new ClassLibrary.JDataBase();
                db1.setQuery("exec [dbo].[UpdateCourseByStationCode_Final] @station_code = " + Code);
                db1.Query_Execute(true);
            }
            finally
            {
                if (db1 != null)
                    db1.Dispose();
            }
        }

        protected void upldPhoto_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
        {
            imgStation.DataValue = WebClassLibrary.JDataManager.ReadToEnd(e.File.InputStream);
            imgStation.ToolTip = e.File.FileName;
            SaveImage();
        }

        private void SaveImage()
        {
            if (Code == 0) return;
            if (imgStation.DataValue == null) return;
            BusManagment.Station.JStation Station = new BusManagment.Station.JStation(Code);
            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
            try
            {
                ClassLibrary.JFile jFile = new ClassLibrary.JFile();
                jFile.Content = imgStation.DataValue;
                jFile.FileName = imgStation.ToolTip;
                jFile.Extension = System.IO.Path.GetExtension(jFile.FileName);
                jFile.FileText = jFile.FileName;
                if (Station.ImageCode > 0 && archive.Retrieve(Station.ImageCode))
                    archive.UpdateArchive(jFile, archive.Code, WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode, "تصویر ایستگاه");
                else
                    Station.ImageCode = archive.ArchiveDocument(jFile, Station.GetType().FullName, Station.Code, JLanguages._Text("StationPicture"), true);
                if (Station.Update())// person.Update())
                {

                }
            }
            catch { }

        }

        private void LoadImage()
        {
            BusManagment.Station.JStation Station = new BusManagment.Station.JStation(Code);
            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
            try
            {
                if (archive.Retrieve(Station.ImageCode))
                {
                    ClassLibrary.JFile image = archive.Content;
                    if (image != null)
                        imgStation.DataValue = WebClassLibrary.JDataManager.ReadToEnd(image.Stream);
                }
                else
                    imgStation.DataValue = WebClassLibrary.JDataManager.LoadFile("~/" + WebClassLibrary.JDomains.Images.ControlImages.NoStation);
            }
            catch { }

        }
    }
}