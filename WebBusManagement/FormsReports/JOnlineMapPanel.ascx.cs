using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClassLibrary;

namespace WebBusManagement.FormsReports
{
    public partial class JOnlineMapPanel : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetReport();
            LoadColors();
        }

        void LoadColors() 
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            db.setQuery("select Name, Color from AUTMapRule");
            try
            {
                System.Data.DataTable dt = db.Query_DataTable();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        string Name = row["Name"].ToString();
                        System.Drawing.Color color = System.Drawing.Color.FromArgb(Convert.ToInt32(row["Color"]));
                        string qwe = color.HexConverter();
                        switch (Name)
                        {
                            case WebBusManagement.FormsManagement.JMapSetting.NearNextBus:
                                dvNearNextBus.Style.Add("background-color", color.HexConverter());
                                break;
                            case WebBusManagement.FormsManagement.JMapSetting.OutLine:
                                dvOutLine.Style.Add("background-color", color.HexConverter());
                                break;
                            case WebBusManagement.FormsManagement.JMapSetting.UnknownDriver:
                                dvUnknownDriver.Style.Add("background-color", color.HexConverter());
                                break;
                            case WebBusManagement.FormsManagement.JMapSetting.Overspeed:
                                dvOverspeed.Style.Add("background-color", color.HexConverter());
                                break;
                            case WebBusManagement.FormsManagement.JMapSetting.LongStop:
                                dvLongStop.Style.Add("background-color", color.HexConverter());
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
        }
        public void GetReport()
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
                        WHERE bus.Active = 1 AND bus.IsValid = 1 AND owner.IsActive = 1
                            AND bus.lastdate BETWEEN cast( Dateadd(day, -7 , Getdate()) as date) AND Dateadd(minute, 5, Getdate())
                            AND " + ClassLibrary.JPermission.getObjectSql("BusManagment.Bus.JBuses.GetDataTable", "bus.Code");
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport;//new WebControllers.MainControls.Grid.JGridView("WebBusManagement_FormsReports_JTariffReportControl");
            jGridView.ClassName = "WebBusManagement_FormsManagement_JOnlineMapNew_createGridNORMAL";
            jGridView.SQL = query;
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            //jGridView.HiddenColumns = "Code";
            jGridView.Title = "JOnlineMapPanel";
            jGridView.PageOrderByField = " LastDate Desc";
            //jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            //jGridView.Toolbar.AddButton("New", "New", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JTariffReportControl._TariffNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            //jGridView.Toolbar.AddButton("Edit", "Edit", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JTariffReportControl._TariffUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            //jGridView.Toolbar.AddButton("EzamBe", "EzamBe", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JTariffReportControl._EzamBeUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            //jGridView.Toolbar.AddButton("DriversNew", "DriversNew", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JTariffReportControl._DriversNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            //jGridView.Toolbar.AddButton("TarrifHokmeKar", "TarrifHokmeKar", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JTariffReportControl._TarrifHokmeKar", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            //jGridView.Toolbar.AddButton("TarrifEmptyPrint", "TarrifEmptyPrint", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JTariffReportControl._TarrifEmptyPrint", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));
            //jGridView.Toolbar.AddButton("BusEventRegister", "BusEventRegister", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebBusManagement.FormsReports.JTariffReportControl._TarrifEmptyPrint" + "._BusEventRegisterNew", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Edit));


            jGridView.Actions = new List<WebClassLibrary.JActionsInfo>();
            jGridView.Actions.Add(new WebClassLibrary.JActionsInfo("GridItemDblClick", WebClassLibrary.JDomains.JActionEvents.GridItemDblClick, "WebBusManagement.FormsReports.JOnlineMapPanel._ShowObject", null, null));
            //jGridView.Buttons = "excel,print,record_print,refresh";

            //
            jGridView.Bind();
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
        public string DefaultMarker
        {
            get
            {
                if (!WebBusManagement.FormsManagement.JOnlineMapNew.DataLoaded)
                    WebBusManagement.FormsManagement.JOnlineMapNew.LoadRulesAndIcons(this.Server);
                if (WebBusManagement.FormsManagement.JOnlineMapNew.DefaultMarker != null)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    WebBusManagement.FormsManagement.JOnlineMapNew.DefaultMarker.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    string imgString = Convert.ToBase64String(ms.ToArray());
                    return String.Format("data:image/Bmp;base64,{0}", imgString);
                }
                else // when WebBusManagement.FormsManagement.JOnlineMapNew.DefaultMarker is null
                {
                    return "/WebBusManagement/Images/station_s32.png";
                }
            }
        }
        public string NearNextBus
        {
            get
            {
                if (!WebBusManagement.FormsManagement.JOnlineMapNew.DataLoaded)
                    WebBusManagement.FormsManagement.JOnlineMapNew.LoadRulesAndIcons(this.Server);
                if (WebBusManagement.FormsManagement.JOnlineMapNew.NearNextBus != null)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    WebBusManagement.FormsManagement.JOnlineMapNew.NearNextBus.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    string imgString = Convert.ToBase64String(ms.ToArray());
                    return String.Format("data:image/Bmp;base64,{0}", imgString);
                }
                else // when WebBusManagement.FormsManagement.JOnlineMapNew.NearNextBus is null
                {
                    return "/WebBusManagement/Images/station_s32.png";
                }
            }
        }
        public string OutLine
        {
            get
            {
                if (!WebBusManagement.FormsManagement.JOnlineMapNew.DataLoaded)
                    WebBusManagement.FormsManagement.JOnlineMapNew.LoadRulesAndIcons(this.Server);
                if (WebBusManagement.FormsManagement.JOnlineMapNew.OutLine != null)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    WebBusManagement.FormsManagement.JOnlineMapNew.OutLine.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    string imgString = Convert.ToBase64String(ms.ToArray());
                    return String.Format("data:image/Bmp;base64,{0}", imgString);
                }
                else // when WebBusManagement.FormsManagement.JOnlineMapNew.OutLine is null
                {
                    return "/WebBusManagement/Images/station_s32.png";
                }
            }
        }
        public string UnknownDriver
        {
            get
            {
                if (!WebBusManagement.FormsManagement.JOnlineMapNew.DataLoaded)
                    WebBusManagement.FormsManagement.JOnlineMapNew.LoadRulesAndIcons(this.Server);
                if (WebBusManagement.FormsManagement.JOnlineMapNew.UnknownDriver != null)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    WebBusManagement.FormsManagement.JOnlineMapNew.UnknownDriver.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    string imgString = Convert.ToBase64String(ms.ToArray());
                    return String.Format("data:image/Bmp;base64,{0}", imgString);
                }
                else // when WebBusManagement.FormsManagement.JOnlineMapNew.UnknownDriver is null
                {
                    return "/WebBusManagement/Images/station_s32.png";
                }
            }
        }
        public string Overspeed
        {
            get
            {
                if (!WebBusManagement.FormsManagement.JOnlineMapNew.DataLoaded)
                    WebBusManagement.FormsManagement.JOnlineMapNew.LoadRulesAndIcons(this.Server);
                if (WebBusManagement.FormsManagement.JOnlineMapNew.Overspeed != null)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    WebBusManagement.FormsManagement.JOnlineMapNew.Overspeed.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    string imgString = Convert.ToBase64String(ms.ToArray());
                    return String.Format("data:image/Bmp;base64,{0}", imgString);
                }
                else // when WebBusManagement.FormsManagement.JOnlineMapNew.Overspeed is null
                {
                    return "/WebBusManagement/Images/station_s32.png";
                }
            }
        }
        public string LongStop
        {
            get
            {
                if (!WebBusManagement.FormsManagement.JOnlineMapNew.DataLoaded)
                    WebBusManagement.FormsManagement.JOnlineMapNew.LoadRulesAndIcons(this.Server);
                if (WebBusManagement.FormsManagement.JOnlineMapNew.LongStop != null)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    WebBusManagement.FormsManagement.JOnlineMapNew.LongStop.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    string imgString = Convert.ToBase64String(ms.ToArray());
                    return String.Format("data:image/Bmp;base64,{0}", imgString);
                }
                else // when WebBusManagement.FormsManagement.JOnlineMapNew.LongStop is null
                {
                    return "/WebBusManagement/Images/station_s32.png";
                }
            }
        }
    }
}