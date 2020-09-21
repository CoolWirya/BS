using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusManagment.Zone;
using BusManagment.Fleet;
using BusManagment.Line;
using BusManagment.Station;
using BusManagment.Price;
using Telerik.Web.UI;
using ClassLibrary;

namespace WebBusManagement.FormsManagement
{
    public partial class JLineUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            LoadZones();
            LoadFleet();
            LoadLine();
            LoadStationsGo();
            LoadStationsBack();
            _SetForm();

            //Line Path
            //((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).Provider = WebControllers.MainControls.OpenLayersMap.MapProvider.GoogleStreets;
            //((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).CenterPosition = "46.294956,38.068636";
            //((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).Zoom = "12";
            //((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).Action = "WebBusManagement.FormsManagement.JLineUpdateControl.ServiceAction";
            //((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).TimerEnabled = false;
            //((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).TimerInterval = 0;
            //((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).MouseClickAddUserMarker = true;
            //((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).CanAddMultipleMarkers = true;
            //((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).DrawMarkers = true;
            //((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).DrawLines = true;
            //((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).HasRightClick = true;
            //((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).MarkerClick = false;
            //((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).DrawMarkersInfo = "LinePath{!~!}LP{!~!}../WebBusManagement/Images/station_s64.png{!~!}32{!~!}32{!~!}10{!~!}5";
            //((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).DrawLinesInfo = "Line{!~!}Line{!~!}ff0000{!~!}0.7{!~!}8{!~!}false";

            ////Station
            //((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStationShow).Action = "WebBusManagement.FormsManagementJLineUpdateControl.ServiceAction";
            //((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStationShow).TimerEnabled = false;
            //((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapStationShow).TimerInterval = 0;
        }

        public void LoadZones()
        {
            DataTable DtZone = new DataTable();
            DtZone = JZones.GetDataTable(0);
            cmbZoneName.DataSource = DtZone;
            cmbZoneName.DataTextField = "Name";
            cmbZoneName.DataValueField = "Code";
            cmbZoneName.DataBind();
        }

        public void LoadFleet()
        {
            DataTable DtFleet = new DataTable();
            DtFleet = JFleets.GetDataTable(0);
            cmbFleetName.DataSource = DtFleet;
            cmbFleetName.DataTextField = "Name";
            cmbFleetName.DataValueField = "Code";
            cmbFleetName.DataBind();
        }

        public void LoadLine()
        {
            DataTable DtLine = new DataTable();
            DtLine = (new BusManagment.Line.JLineTypes()).GetList();
            cmbLineType.DataSource = DtLine;
            cmbLineType.DataTextField = "Name";
            cmbLineType.DataValueField = "Code";
            cmbLineType.DataBind();
        }

        public void LoadLinePrice()
        {
            BusManagment.Price.JPrices Price = new BusManagment.Price.JPrices();
            GridViewPrice.DataSource = Price.GetWebPrices(Code);
            GridViewPrice.DataBind();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                BusManagment.Line.JLine line = new BusManagment.Line.JLine();
                line.GetData(Code);
                txtLineName.Text = line.LineName;
                txtLineNumber.Text = line.LineNumber.ToString();
                cmbZoneName.SelectedValue = line.ZoneCode.ToString();
                cmbFleetName.SelectedValue = line.Fleet.ToString();
                cmbLineType.SelectedValue = line.LineType.ToString();
                txt_NumOfServicePerDay.Text = line.NumOfServicePerDay.ToString();
                txt_TimeOfService.Text = line.TimeOfService.ToString();
                chkStatus.Checked = line.Status;
                chkRotate.Checked = line.Rotate;
                txtDistance.Text = line.Distance.ToString();
                if (!IsPostBack)
                {
                    LoadLinePrice();
                    LoadLineStationGo();
                    LoadLineStationBack();
                }

                // MapPath
                //List<WebControllers.MainControls.OpenLayersMap.UserMarker> userMarker = new List<WebControllers.MainControls.OpenLayersMap.UserMarker>();
                //foreach (DataRow row in BusManagment.Line.JLinePoints.GetDataTable(Code).Rows)
                //{
                //    userMarker.Add(new WebControllers.MainControls.OpenLayersMap.UserMarker() { Latitude = Convert.ToDouble(row["Latitude"]), Longitude = Convert.ToDouble(row["Longitude"]) });
                //}
                //((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).UserMarkers = userMarker;
            }
        }

        public int Save()
        {
            BusManagment.Line.JLine line = new BusManagment.Line.JLine();
            line.Code = Code;
            line.LineName = txtLineName.Text;
            line.LineNumber = Convert.ToDouble(txtLineNumber.Text);
            line.ZoneCode = Convert.ToInt32(cmbZoneName.SelectedValue);
            line.Fleet = Convert.ToInt32(cmbFleetName.SelectedValue);
            line.LineType = Convert.ToInt32(cmbLineType.SelectedValue);
            line.NumOfServicePerDay = Convert.ToInt32(txt_NumOfServicePerDay.Text);
            line.TimeOfService = Convert.ToInt32(txt_TimeOfService.Text);
            line.Status = chkStatus.Checked;
            line.Rotate = chkRotate.Checked;
            if (txtDistance.Text != "")
            {
                line.Distance = Convert.ToSingle(txtDistance.Text);
            }
            if (Code > 0)
            {
                if (line.Update(true) != true)
                    return 0;
            }
            else
            {
                Code = line.Insert(true);
            }
            //if (Code > 0)
            //{
            //    BusManagment.Line.JLinePoints.UpdateLinePoints(Code,
            //        ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapLinePath).UserMarkers.Select(m => new JLinePoint() { Latitude = (double)m.Latitude, Longitude = (double)m.Longitude, LineCode = this.Code, OrderNo = 0 }).ToList(), true);
            //}
            return Code;
        }

        public bool PriceSaveInDb(int LineCode, int CuPrice, DateTime StartDate, DateTime FinishDate, TimeSpan StartTime, TimeSpan FinishTime, JDataBase db)
        {
            BusManagment.Price.JPrice Price = new BusManagment.Price.JPrice();
            Price.LineCode = LineCode;
            Price.Price = CuPrice;
            Price.StartDate = StartDate;
            Price.Enddate = FinishDate;
            Price.StartTime = StartTime;
            Price.EndTime = FinishTime;
            return Price.Insert(db) > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int BackCode, InsertCode;
            BackCode = Save();
            JDataBase db = new JDataBase();
            try
            {
                db.beginTransaction("LinePriceUpdate");
                if (BackCode == 0)
                {
                    JPrices.DeleteByLineCode(Code, db);
                    JLineStations.DeleteByLineCode(Code, db);
                    InsertCode = Code;
                }
                else
                {
                    InsertCode = BackCode;
                }

                bool result = true;

                int LineStationGoI, LineStationGoJ;
                for (LineStationGoI = 0; LineStationGoI < lstStationGo.Items.Count; LineStationGoI++)
                {
                    LineStationGoJ = LineStationGoI + 1;
                    result = SaveLineStattion(InsertCode, Convert.ToInt32(lstStationGo.Items[LineStationGoI].Value), false, LineStationGoJ);
                    if (result == false)
                    {
                        db.Rollback("LinePriceUpdate");
                        break;
                    }
                }

                int LineStationBackI, LineStationBackJ;
                for (LineStationBackI = 0; LineStationBackI < lstStationBack.Items.Count; LineStationBackI++)
                {
                    LineStationBackJ = LineStationBackI + 1;
                    result = SaveLineStattion(InsertCode, Convert.ToInt32(lstStationBack.Items[LineStationBackI].Value), true, LineStationBackJ);
                    if (result == false)
                    {
                        db.Rollback("LinePriceUpdate");
                        break;
                    }
                }


                int i;
                for (i = 0; i < GridViewPrice.Rows.Count; i++)
                {
                    TimeSpan TsStartTime;
                    if (GridViewPrice.Rows[i].Cells[5].Text.ToString().Length == 5)
                    {
                        TsStartTime = new TimeSpan(
                        Convert.ToInt32(GridViewPrice.Rows[i].Cells[5].Text.Substring(0, 2).ToString())
                        , Convert.ToInt32(Convert.ToInt64(GridViewPrice.Rows[i].Cells[5].Text.Substring(3, 2).ToString())), 0);
                    }
                    else
                    {
                        TsStartTime = new TimeSpan(0, 0, 0);
                    }

                    TimeSpan TsEndTime;
                    if (GridViewPrice.Rows[i].Cells[6].Text.ToString().Length == 5)
                    {
                        TsEndTime = new TimeSpan(
                        Convert.ToInt32(GridViewPrice.Rows[i].Cells[6].Text.Substring(0, 2).ToString())
                        , Convert.ToInt32(Convert.ToInt64(GridViewPrice.Rows[i].Cells[6].Text.Substring(3, 2).ToString())), 0);
                    }
                    else
                    {
                        TsEndTime = new TimeSpan(23, 59, 59);
                    }

                    result = PriceSaveInDb(InsertCode, Convert.ToInt32(GridViewPrice.Rows[i].Cells[2].Text.ToString()),
                        Convert.ToDateTime(ClassLibrary.JDateTime.GregorianDate(GridViewPrice.Rows[i].Cells[3].Text.ToString())),
                        Convert.ToDateTime(ClassLibrary.JDateTime.GregorianDate(GridViewPrice.Rows[i].Cells[4].Text.ToString())),
                        TsStartTime, TsEndTime, db);
                    if (result == false)
                    {
                        db.Rollback("LinePriceUpdate");
                        break;
                    }
                }
                if (result == true)
                    db.Commit();

                WebClassLibrary.JWebManager.CloseAndRefresh();
            }
            finally
            {
                db.Dispose();
            }

        }

        //Price

        protected void BtnPriceSave_Click(object sender, EventArgs e)
        {
            //Insert
            if (GridViewPriceSelectedRowId.Value == "0")
            {
                if (((WebControllers.MainControls.Date.JDateControl)txtStartDate).GetFarsiDate().Length == 10)
                {
                    if (((WebControllers.MainControls.Date.JDateControl)txtFinishDate).GetFarsiDate().Length == 10)
                    {
                        DataTable DtPriceForGrid = new DataTable();
                        DataRow DtRow = DtPriceForGrid.NewRow();
                        DtPriceForGrid.Columns.Add("ردیف");
                        DtPriceForGrid.Columns.Add("مبلغ");
                        DtPriceForGrid.Columns.Add("تاریخ شروع");
                        DtPriceForGrid.Columns.Add("تاریخ پایان");
                        DtPriceForGrid.Columns.Add("ساعت شروع");
                        DtPriceForGrid.Columns.Add("ساعت پایان");
                        int i, j;
                        j = 1;
                        for (i = 0; i < GridViewPrice.Rows.Count; i++)
                        {
                            DtRow = DtPriceForGrid.NewRow();
                            DtRow["ردیف"] = j.ToString();
                            DtRow["مبلغ"] = GridViewPrice.Rows[i].Cells[2].Text.ToString();
                            DtRow["تاریخ شروع"] = GridViewPrice.Rows[i].Cells[3].Text.ToString();
                            DtRow["تاریخ پایان"] = GridViewPrice.Rows[i].Cells[4].Text.ToString();
                            DtRow["ساعت شروع"] = GridViewPrice.Rows[i].Cells[5].Text.ToString();
                            DtRow["ساعت پایان"] = GridViewPrice.Rows[i].Cells[6].Text.ToString();
                            DtPriceForGrid.Rows.Add(DtRow);
                            j++;
                        }
                        DtRow = DtPriceForGrid.NewRow();
                        DtRow["ردیف"] = j;
                        DtRow["مبلغ"] = txtPrice.Text;
                        DtRow["تاریخ شروع"] = ((WebControllers.MainControls.Date.JDateControl)txtStartDate).GetFarsiDate();
                        DtRow["تاریخ پایان"] = ((WebControllers.MainControls.Date.JDateControl)txtFinishDate).GetFarsiDate();
                        DtRow["ساعت شروع"] = txtStartTimeHour.Text + ":" + txtStartTimeMinute.Text;
                        DtRow["ساعت پایان"] = txtFinishTimeHour.Text + ":" + txtFinishTimeMinute.Text;
                        DtPriceForGrid.Rows.Add(DtRow);

                        GridViewPrice.DataSource = DtPriceForGrid;
                        GridViewPrice.DataBind();

                        txtPrice.Text = "";
                        txtStartTimeHour.Text = "";
                        txtStartTimeMinute.Text = "";
                        txtFinishTimeHour.Text = "";
                        txtFinishTimeMinute.Text = "";
                        txtPrice.Focus();
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "Set FinishDate", "alert('لطفا تاریخ پایان را انتخاب کنید');", true);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "Set StartDate", "alert('لطفا تاریخ شروع را انتخاب کنید');", true);
                }
            }
            //Update
            else if (Convert.ToInt32(GridViewPriceSelectedRowId.Value) > 0)
            {
                if (((WebControllers.MainControls.Date.JDateControl)txtStartDate).GetFarsiDate().Length == 10)
                {
                    if (((WebControllers.MainControls.Date.JDateControl)txtFinishDate).GetFarsiDate().Length == 10)
                    {
                        DataTable DtPriceForGrid = new DataTable();
                        DataRow DtRow = DtPriceForGrid.NewRow();
                        DtPriceForGrid.Columns.Add("ردیف");
                        DtPriceForGrid.Columns.Add("مبلغ");
                        DtPriceForGrid.Columns.Add("تاریخ شروع");
                        DtPriceForGrid.Columns.Add("تاریخ پایان");
                        DtPriceForGrid.Columns.Add("ساعت شروع");
                        DtPriceForGrid.Columns.Add("ساعت پایان");
                        int i, j;
                        j = 1;
                        for (i = 0; i < GridViewPrice.Rows.Count; i++)
                        {
                            if (GridViewPrice.Rows[i].Cells[1].Text != GridViewPriceSelectedRowId.Value)
                            {
                                DtRow = DtPriceForGrid.NewRow();
                                DtRow["ردیف"] = j.ToString();
                                DtRow["مبلغ"] = GridViewPrice.Rows[i].Cells[2].Text.ToString();
                                DtRow["تاریخ شروع"] = GridViewPrice.Rows[i].Cells[3].Text.ToString();
                                DtRow["تاریخ پایان"] = GridViewPrice.Rows[i].Cells[4].Text.ToString();
                                DtRow["ساعت شروع"] = GridViewPrice.Rows[i].Cells[5].Text.ToString();
                                DtRow["ساعت پایان"] = GridViewPrice.Rows[i].Cells[6].Text.ToString();
                                DtPriceForGrid.Rows.Add(DtRow);
                            }
                            else
                            {
                                DtRow = DtPriceForGrid.NewRow();
                                DtRow["ردیف"] = j.ToString();
                                DtRow["مبلغ"] = txtPrice.Text;
                                DtRow["تاریخ شروع"] = ((WebControllers.MainControls.Date.JDateControl)txtStartDate).GetFarsiDate();
                                DtRow["تاریخ پایان"] = ((WebControllers.MainControls.Date.JDateControl)txtFinishDate).GetFarsiDate();
                                DtRow["ساعت شروع"] = txtStartTimeHour.Text + ":" + txtStartTimeMinute.Text;
                                DtRow["ساعت پایان"] = txtFinishTimeHour.Text + ":" + txtFinishTimeMinute.Text;
                                DtPriceForGrid.Rows.Add(DtRow);
                            }
                            j++;
                        }
                        GridViewPrice.DataSource = DtPriceForGrid;
                        GridViewPrice.DataBind();
                        GridViewPriceSelectedRowId.Value = "0";
                        txtPrice.Text = "";
                        txtStartTimeHour.Text = "";
                        txtStartTimeMinute.Text = "";
                        txtFinishTimeHour.Text = "";
                        txtFinishTimeMinute.Text = "";
                        txtPrice.Focus();
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "Set FinishDate", "alert('لطفا تاریخ پایان را انتخاب کنید');", true);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "Set StartDate", "alert('لطفا تاریخ شروع را انتخاب کنید');", true);
                }
            }
        }

        protected void GridViewPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            string PriceCode = "";
            PriceCode = GridViewPrice.SelectedRow.Cells[1].Text.ToString();
            GridViewPriceSelectedRowId.Value = PriceCode;
            txtPrice.Text = GridViewPrice.SelectedRow.Cells[2].Text.ToString();
            ((WebControllers.MainControls.Date.JDateControl)txtStartDate).SetDate(Convert.ToDateTime(ClassLibrary.JDateTime.GregorianDate(GridViewPrice.SelectedRow.Cells[3].Text.ToString())));
            ((WebControllers.MainControls.Date.JDateControl)txtFinishDate).SetDate(Convert.ToDateTime(ClassLibrary.JDateTime.GregorianDate(GridViewPrice.SelectedRow.Cells[4].Text.ToString())));
            if (GridViewPrice.SelectedRow.Cells[5].Text.ToString().Length == 5)
            {
                txtStartTimeHour.Text = GridViewPrice.SelectedRow.Cells[5].Text.ToString().Substring(0, 2);
                txtStartTimeMinute.Text = GridViewPrice.SelectedRow.Cells[5].Text.ToString().Substring(3, 2);
            }
            if (GridViewPrice.SelectedRow.Cells[6].Text.ToString().Length == 5)
            {
                txtFinishTimeHour.Text = GridViewPrice.SelectedRow.Cells[6].Text.ToString().Substring(0, 2);
                txtFinishTimeMinute.Text = GridViewPrice.SelectedRow.Cells[6].Text.ToString().Substring(3, 2);
            }
            btnDelPrice.Visible = true;
            txtPrice.Focus();
        }

        protected void btnDelPrice_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(GridViewPriceSelectedRowId.Value) > 0)
            {
                DataTable DtPriceForGrid = new DataTable();
                DataRow DtRow = DtPriceForGrid.NewRow();
                DtPriceForGrid.Columns.Add("ردیف");
                DtPriceForGrid.Columns.Add("مبلغ");
                DtPriceForGrid.Columns.Add("تاریخ شروع");
                DtPriceForGrid.Columns.Add("تاریخ پایان");
                DtPriceForGrid.Columns.Add("ساعت شروع");
                DtPriceForGrid.Columns.Add("ساعت پایان");
                int i, j;
                j = 1;
                for (i = 0; i < GridViewPrice.Rows.Count; i++)
                {
                    if (GridViewPrice.Rows[i].Cells[1].Text != GridViewPriceSelectedRowId.Value)
                    {
                        DtRow = DtPriceForGrid.NewRow();
                        DtRow["ردیف"] = j.ToString();
                        DtRow["مبلغ"] = GridViewPrice.Rows[i].Cells[2].Text.ToString();
                        DtRow["تاریخ شروع"] = GridViewPrice.Rows[i].Cells[3].Text.ToString();
                        DtRow["تاریخ پایان"] = GridViewPrice.Rows[i].Cells[4].Text.ToString();
                        DtRow["ساعت شروع"] = GridViewPrice.Rows[i].Cells[5].Text.ToString();
                        DtRow["ساعت پایان"] = GridViewPrice.Rows[i].Cells[6].Text.ToString();
                        DtPriceForGrid.Rows.Add(DtRow);
                    }
                    j++;
                }
                GridViewPrice.DataSource = DtPriceForGrid;
                GridViewPrice.DataBind();
                GridViewPriceSelectedRowId.Value = "0";
                txtPrice.Text = "";
                txtStartTimeHour.Text = "";
                txtStartTimeMinute.Text = "";
                txtFinishTimeHour.Text = "";
                txtFinishTimeMinute.Text = "";
                txtPrice.Focus();
                btnDelPrice.Visible = false;
            }
        }


        //Station


        public void LoadLineStationGo()
        {
            lstStationGo.DataSource = JLineStations.GetLineStations(Code, false);
            lstStationGo.DataTextField = "StationName";
            lstStationGo.DataValueField = "StationCode";
            lstStationGo.DataBind();
        }

        public void LoadLineStationBack()
        {
            lstStationBack.DataSource = JLineStations.GetLineStations(Code, true);
            lstStationBack.DataTextField = "StationName";
            lstStationBack.DataValueField = "StationCode";
            lstStationBack.DataBind();
        }

        public void LoadStationsGo()
        {
            DataTable DtStation = new DataTable();
            DtStation = JStations.GetDataTable(0);
            cmbStationGo.DataSource = DtStation;
            cmbStationGo.DataTextField = "Name";
            cmbStationGo.DataValueField = "Code";
            cmbStationGo.DataBind();
        }

        public void LoadStationsBack()
        {
            DataTable DtStation = new DataTable();
            DtStation = JStations.GetDataTable(0);
            cmbStationBack.DataSource = DtStation;
            cmbStationBack.DataTextField = "Name";
            cmbStationBack.DataValueField = "Code";
            cmbStationBack.DataBind();
        }

        protected void BtnInsertStationGo_Click(object sender, EventArgs e)
        {
            RadListBoxItem NewItem = new RadListBoxItem();
            NewItem.Value = cmbStationGo.SelectedValue;
            NewItem.Text = cmbStationGo.SelectedItem.Text;
            lstStationGo.Items.Add(NewItem);
        }

        protected void BtnInsertStationBack_Click(object sender, EventArgs e)
        {
            RadListBoxItem NewItem = new RadListBoxItem();
            NewItem.Value = cmbStationBack.SelectedValue;
            NewItem.Text = cmbStationBack.SelectedItem.Text;
            lstStationBack.Items.Add(NewItem);
        }


        public bool SaveLineStattion(int LineCode, int StationCode, bool IsBack, float Priority)
        {
            BusManagment.Line.JLineStation LineStation = new BusManagment.Line.JLineStation();
            LineStation.LineCode = LineCode;
            LineStation.StationCode = StationCode;
            LineStation.IsBack = IsBack;
            LineStation.Priority = Priority;
            return LineStation.Insert() > 0 ? true : false;
        }
    }
}