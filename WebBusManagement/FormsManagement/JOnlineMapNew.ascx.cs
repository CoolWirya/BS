using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JOnlineMapNew : System.Web.UI.UserControl
    {
        public static bool DataLoaded = false;
        public static System.Drawing.Image NearNextBus, OutLine, UnknownDriver, Overspeed, LongStop, DefaultMarker;
        public static System.Collections.Hashtable Arrows;
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    Map1.CenterLatitude = ClassLibrary.JConfig.CityCenterLat;
        //    Map1.CenterLongitude = ClassLibrary.JConfig.CityCenterLong;
        //    string ImgUrl = "";
        //    System.Data.DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable("select Code,BUSNumber,LastLatitude,LastLongitude,LastCourse from AUTBus where Active = 1 and IsValid = 1 and LastDate > DATEADD(hour,-24,getdate())");
        //    //Map1.Interval = 10000;
        //    Map1.MarkerWithLabelAddress = "/Script/FastMarkerOverlay.js";
        //    foreach (System.Data.DataRow dr in dt.Rows)
        //    {
        //        if (Convert.ToInt32(dr["LastCourse"].ToString()) < 150)
        //        {
        //            ImgUrl = "../WebBusManagement/Images/bus_s64_right.png";
        //        }
        //        else
        //        {
        //            ImgUrl = "../WebBusManagement/Images/bus_s64.png";
        //        }
        //        Map1.Markers.Add(new AVL.Controls.Map.Marker()
        //        {
        //            IconUrl = ImgUrl,
        //            InfoWindowHtml = "",
        //            Latitude = Convert.ToDouble(dr["LastLatitude"].ToString()),
        //            Longitude = Convert.ToDouble(dr["LastLongitude"].ToString()),
        //            Title = dr["BUSNumber"].ToString(),
        //            UID = Convert.ToInt32(dr["Code"].ToString())
        //        });
        //    }
        //}

        int code = 1;
        private Control createGrid()
        {
            string RulesQuery = "";
            if (WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.RulesQuery"] != null) 
                RulesQuery = WebClassLibrary.SessionManager.Current.Session
                    ["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.RulesQuery"].ToString();
            string query = @"SELECT bus.Code
						,driver.Name DriverName
	                    ,Cards.RfidNumber DriverSerialCard
						,zone.Name
						,bus.LastLineNumber LineNumber
	                    ,bus.BUSNumber
	                    ,bus.LastDate
						,BusOwner.Name OwnerName
	                    ,bus.lastSpeed Speed
                        " + RulesQuery + @"
                        FROM AUTBus bus 
						LEFT JOIN AUTLine line on line.LineNumber = bus.LastLineNumber
						LEFT JOIN AUTZone zone on zone.Code = line.ZoneCode
						LEFT JOIN Cards on  Cards.PCode = bus.LastPersonCode and Cards.PCode <> 0 and Cards.PCode <> 11000003
                        LEFT JOIN AUTBusOwner owner ON owner.BusCode = bus.Code
						LEFT JOIN CLSAllPerson driver ON driver.Code = bus.LastDriverPersonCode
						LEFT JOIN CLSAllPerson BusOwner ON BusOwner.Code = owner.CodePerson
                        WHERE bus.Active = 1 AND bus.IsValid = 1
                            AND " + ClassLibrary.JPermission.getObjectSql("BusManagment.Bus.JBuses.GetDataTable", "bus.Code");

            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("AVL_ObjectList");
            jGridView.Parameters = new object[] { WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode };
            jGridView.ClassName = "WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL";
            jGridView.SQL = query;

            jGridView.Title = "متحرک";

            jGridView.Actions = new List<WebClassLibrary.JActionsInfo>();
            jGridView.Actions.Add(new WebClassLibrary.JActionsInfo("GridItemDblClick", WebClassLibrary.JDomains.JActionEvents.GridItemDblClick, "WebBusManagement.FormsManagement.JOnlineMapNew._ShowObject", null, null));

            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();

            //jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            //jGridView.Buttons = "excel,print,record_print";
            jGridView.PageOrderByField = "LastDate desc";

            jGridView.Bind();

            return jGridView;
        }


        public string _ShowObject(string code)
        {
            if (WebClassLibrary.SessionManager.Current.Session["OnlineMapCenter"] != null &&
                WebClassLibrary.SessionManager.Current.Session["OnlineMapCenter"].ToString() == code)
                WebClassLibrary.SessionManager.Current.Session["OnlineMapCenter"] = "";
            else
                WebClassLibrary.SessionManager.Current.Session.Add("OnlineMapCenter", code);
            return "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            /*
             * 
             * To show different icon for each object(related to its type - car , person ... -)
             * needs a method named GetIcon
             * 
             */
            if (WebClassLibrary.SessionManager.Current.Session["FirstLoadMad"] != null)
                WebClassLibrary.SessionManager.Current.Session["FirstLoadMad"] = null;
            if (WebClassLibrary.SessionManager.Current.Session["OnlineMapCenter"] != null)
                WebClassLibrary.SessionManager.Current.Session["OnlineMapCenter"] = null;
            if (WebClassLibrary.SessionManager.Current.Session["SesionObjects"] != null)
                WebClassLibrary.SessionManager.Current.Session["SesionObjects"] = null;
            if (WebClassLibrary.SessionManager.Current.Session["Series"] != null)
                WebClassLibrary.SessionManager.Current.Session["Series"] = null;

            if (!Page.IsPostBack)
            {
                LoadRulesAndIcons(this.Server);
                //togglepanel.Controls.Add(createGrid());

                //WebClassLibrary.JWebManager.RunClientScript("GetRadWindow().set_title('نقشه آنلاین')", "ConfirmDialog");
                //Get usercode from session
                code = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;// int.Parse(Request["code"].ToString());
                //ShowAllMarkers(code);
                //System.Data.DataTable table = AVL.Area.JAreas.GetDataTable(code);
                //string type = "خط ";
                //if (table == null)
                //    return;
                //ddlAreas.Items.Clear();
                //foreach (System.Data.DataRow dr in table.Rows)
                //{
                //    ddlAreas.Items.Add(new ListItem(dr["Name"].ToString(), dr["code"].ToString()));
                //}
                //table = AVL.RegisterDevice.JRegisterDevices.GetDataTable(code);
                //if (table == null)
                //    return;
                //lsbDefaltObjects.Items.Clear();
                //foreach (System.Data.DataRow dr in table.Rows)
                //{
                //    if (int.Parse(dr["ObjectCode"].ToString())<1)
                //    lsbDefaltObjects.Items.Add(new ListItem(dr["Name"].ToString()+"["+dr["IMEI"].ToString()+"]", dr["Code"].ToString()));
                //}
                if (WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.OnlineMapLastStyle"] != null)
                    WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.OnlineMapLastStyle"] = null;
            }
        }
        public static void LoadRulesAndIcons(HttpServerUtility Server)
        {
            //            Getting rules and rules' names
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            string Query = @"
                declare @RulesQuery nvarchar(max) = ''
                set @RulesQuery =
                    (select 
	                    (
	                        select CONCAT(',case when ', cast(Condition as nvarchar(max)), N' then N''بلی'' else N''خیر'' end ', 'N''', Name, '''') 
	                        from AUTMapRule where IsDefault = 0 FOR XML PATH, TYPE
                        ).value('.[1]','nvarchar(max)')
                    )

                declare @RulesName nvarchar(max) = ''
                set @RulesName =
                    (select 
                        STUFF(
	                        (select CONCAT(',', Name) from AUTMapRule where IsDefault = 0 and HasVisualStyle = 1 FOR XML PATH, TYPE).value('.[1]','nvarchar(max)')
                        , 1, 1, '')
                    )

                select REPLACE(@RulesQuery, '@bus', 'bus') RulesQuery, @RulesName RulesName";
            db.setQuery(Query);
            try
            {
                //            Saving rules and rules' names in the session
                DataTable dt = db.Query_DataTable();
                string strRulesQuery = "", strRulesName = "";
                if (dt != null && dt.Rows.Count > 0)
                {
                    strRulesQuery = dt.Rows[0]["RulesQuery"].ToString();
                    strRulesName = dt.Rows[0]["RulesName"].ToString();
                    WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.RulesQuery"]
                        = strRulesQuery;
                    WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.RulesName"]
                        = strRulesName;
                }
                else
                    return;

                //            Getting rules' datatable and saving in the session
                db.setQuery("select Name, ImageCode, Color, IsDefault from AUTMapRule");
                DataTable dtRules = db.Query_DataTable();
                if (dtRules != null && dtRules.Rows.Count > 0)
                {
                    WebClassLibrary.SessionManager.Current.Session["WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL.0.RulesDataTable"]
                        = dtRules;

                    //            Saving Markers in static fields
                    if (!DataLoaded)
                    {
                        Arrows = new System.Collections.Hashtable(); 
                        NearNextBus = null; OutLine = null; UnknownDriver = null; Overspeed = null; LongStop = null; DefaultMarker = null;
                        ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
                        Size IconSize = new Size(32, 32);
                        foreach (DataRow row in dtRules.Rows)
                        {
                            int ImageCode = Convert.ToInt32(row["ImageCode"]);
                            string Name = Convert.ToString(row["Name"]);
                            if (archive.Retrieve(ImageCode))
                            {
                                ClassLibrary.JFile file = archive.Content;
                                if (file != null)
                                {
                                    System.Drawing.Image image = System.Drawing.Image.FromStream(file.Stream);
                                    System.Drawing.Image ResizedImage = ResizeImage(image, IconSize);
                                    switch (Name)
                                    {
                                        case JMapSetting.DefaultMarker:
                                            DefaultMarker = ResizedImage;
                                            break;
                                        case JMapSetting.NearNextBus:
                                            NearNextBus = ResizedImage;
                                            break;
                                        case JMapSetting.OutLine:
                                            OutLine = ResizedImage;
                                            break;
                                        case JMapSetting.UnknownDriver:
                                            UnknownDriver = ResizedImage;
                                            break;
                                        case JMapSetting.Overspeed:
                                            Overspeed = ResizedImage;
                                            break;
                                        case JMapSetting.LongStop:
                                            LongStop = ResizedImage;
                                            break;
                                    }
                                }
                            }

                        }

                        //            Saving Arrows in static fields
                        string ArrowUrl = "~/WebBusManagement/Images/arrow.png";
                        string ArrowPath = Server.MapPath(ArrowUrl);
                        System.Drawing.Image Arrow = System.Drawing.Image.FromFile(ArrowPath);
                        for (int AngleIndex = 1; AngleIndex <= 16; AngleIndex++)
                        {
                            float angle = -(float)(22.5 * (AngleIndex - 1));
                            System.Drawing.Image RotatedImage = RotateImage(Arrow, angle);
                            System.Drawing.Image FinalImage = ResizeImage(RotatedImage, new Size(10,10));
                            Arrows.Add(AngleIndex, FinalImage);
                        }
                        DataLoaded = true;
                    }

                }
                else
                    return;

            }
            catch(Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
        }

        static System.Drawing.Image RotateImage(System.Drawing.Image image, float Angle)
        {
            Bitmap RotatedImage = new Bitmap(image.Width, image.Height);
            using (Graphics graphics = Graphics.FromImage(RotatedImage))
            {
                graphics.TranslateTransform((float)image.Width / 2, (float)image.Height / 2);
                graphics.RotateTransform(Angle);
                graphics.TranslateTransform(-(float)image.Width / 2, -(float)image.Height / 2);
                //graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(image, 0, 0);
            }
            return RotatedImage;
        }
        static System.Drawing.Image ResizeImage(System.Drawing.Image image, Size NewSize)
        {
            System.Drawing.Image ResizedImage = new Bitmap(NewSize.Width, NewSize.Height);
            System.Drawing.Graphics graphic =
                         System.Drawing.Graphics.FromImage(ResizedImage);

            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = CompositingQuality.HighQuality;
            graphic.DrawImage(image, 0, 0, NewSize.Width, NewSize.Height);

            return ResizedImage;
        }

        //protected void btnFind_Click(object sender, EventArgs e)
        //{
        //    code = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
        //    string areaCode = ddlAreas.SelectedValue;
        //    AVL.Area.JArea area = new AVL.Area.JArea(areaCode, code.ToString());
        //    GoogleMap1.Markers.Clear();
        //    if (area != null && !string.IsNullOrEmpty(area.ObjectsCodes))
        //        foreach (string objectsCodes in area.ObjectsCodes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            CreateMarker(new AVL.ObjectList.JObjectList(int.Parse(objectsCodes), code));

        //        }
        //    if (GoogleMap1.Markers.Count > 0)
        //    {
        //        GoogleMap1.CenterLongitude = GoogleMap1.Markers[0].Longitude;
        //        GoogleMap1.CenterLatitude = GoogleMap1.Markers[0].Latitude;
        //    }
        //    GoogleMap1.SpecifiedArea = true;
        //    AVL.Controls.Map.Line line = new AVL.Controls.Map.Line() { Color = "red" };
        //    string[] pp;
        //    foreach (string p in area.Points.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries))
        //    {
        //        pp = p.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        //        line.Points.Add(new AVL.Controls.Map.Point()
        //        {
        //            Latitude = double.Parse(pp[0]),
        //            Longitude = double.Parse(pp[1])
        //        });
        //    }
        //    GoogleMap1.Lines.Add(line);
        //}

        //protected void btnShowAll_Click(object sender, EventArgs e)
        //{
        //    code = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
        //    ShowAllMarkers(code);
        //    if (GoogleMap1.Markers.Count > 0)
        //    {
        //        GoogleMap1.CenterLongitude = GoogleMap1.Markers[0].Longitude;
        //        GoogleMap1.CenterLatitude = GoogleMap1.Markers[0].Latitude;
        //    }
        //    GoogleMap1.SpecifiedArea = false;
        //}

        //  private void ShowAllMarkers(int userCode)
        //  {
        //      GoogleMap1.Markers.Clear();
        ////      System.Data.DataTable table = AVL.UserObjects.JUserObjects.GetDataTable(userCode);
        //      System.Data.DataTable table = AVL.ObjectList.JObjectLists.GetDataTableToday(userCode);
        //      if (table != null)
        //      {
        //          foreach (System.Data.DataRow dr in table.Rows)
        //          {
        //              // CreateMarker(new AVL.ObjectList.JObjectList(int.Parse(dr["objectListCode"].ToString())));
        //              CreateMarker(new AVL.ObjectList.JObjectList()
        //              {
        //                  ClassName = dr["ClassName"].ToString(),
        //                  Code = int.Parse(dr["Code"].ToString()),
        //                  DynamicObjectCode = int.Parse(dr["DynamicObjectCode"].ToString()),
        //                  Label = dr["Label"].ToString(),
        //                  LastLat = float.Parse(dr["LastLat"].ToString()),
        //                  LastLng = float.Parse(dr["LastLng"].ToString()),
        //                  ObjectCode = int.Parse(dr["ObjectCode"].ToString()),
        //                  personCode = int.Parse(dr["personCode"].ToString()),
        //                  RegisterDateTime = DateTime.Parse(dr["RegisterDateTime"].ToString()),
        //                  Type = dr["Type"].ToString()
        //              });
        //          }
        //          if (GoogleMap1.Markers.Count > 0)
        //          {
        //              GoogleMap1.CenterLongitude = GoogleMap1.Markers[0].Longitude;
        //              GoogleMap1.CenterLatitude = GoogleMap1.Markers[0].Latitude;
        //          }
        //      }
        //  }

        //  private void CreateMarker(AVL.ObjectList.JObjectList ol)
        //  {
        //      if (ol != null)
        //      {
        //          GoogleMap1.Markers.Add(new AVL.Controls.Map.Marker()
        //          {
        //              IconUrl = AVL.Tools.InvokeMethod(ol.ClassName.Split('.')[0], ol.ClassName, "GetIcon", new object[] { ol.Code.ToString() }).ToString(), //"/WebAVL/Icons/bus.png",
        //              InfoWindowHtml = AVL.Tools.InvokeMethod(ol.ClassName.Split('.')[0], ol.ClassName, "GetHtmlString", new object[] { }).ToString(),
        //              Latitude = (double)ol.LastLat,// 38.040665,
        //              Longitude = (double)ol.LastLng,// 46.3000,
        //              Title = "شماره : " + ol.ObjectCode.ToString(),
        //              UID = ol.Code
        //          });
        //      }
        //  }

        protected void lsbDefaltObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx?f=d");
        }
       
    }
}