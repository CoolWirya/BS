using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusManagment.Station;
using ClassLibrary;
using BusManagment.SellerTicket;

namespace WebBusManagement.FormsManagement
{
    public partial class JCountersUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            LoadCountersType();
            LoadStations();
            _SetForm();

            ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).Code = 0;
            ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).SQL = "SELECT [Code],[Tel],[MacAddress],[IMEI] as Title,[Barcode] FROM [dbo].[AUTDevice]";

            //Counters
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapCounters).Provider = WebControllers.MainControls.OpenLayersMap.MapProvider.GoogleStreets;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapCounters).CenterPosition = "46.294956,38.068636";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapCounters).Zoom = "12";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapCounters).Action = "WebBusManagement.FormsManagement.JCountersUpdateControl.ServiceAction";
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapCounters).TimerEnabled = false;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapCounters).TimerInterval = 0;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapCounters).MouseClickAddUserMarker = true;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapCounters).CanAddMultipleMarkers = false;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapCounters).DrawMarkers = true;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapCounters).DrawLines = false;
            ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapCounters).MarkerClick = false;
        }

        public void LoadCountersDevice()
        {
            BusManagment.JSellerTicketDevises SellerTicketDevice = new BusManagment.JSellerTicketDevises();
            GridViewSellerTicketDevice.DataSource = SellerTicketDevice.GetWebDevices(Code);
            GridViewSellerTicketDevice.DataBind();
        }

        public void LoadCountersType()
        {
            DataTable DtCounters = new DataTable();
            DtCounters = (new BusManagment.SellerTicket.JSellerTicketTypes()).GetList();
            cmbCountersType.DataSource = DtCounters;
            cmbCountersType.DataTextField = "Name";
            cmbCountersType.DataValueField = "Code";
            cmbCountersType.DataBind();
        }

        public void LoadStations()
        {
            DataTable DtStation = new DataTable();
            DtStation = JStations.GetDataTable(0);
            cmbStation.DataSource = DtStation;
            cmbStation.DataTextField = "Name";
            cmbStation.DataValueField = "Code";
            cmbStation.DataBind();
        }

        public void LoadCountersPerson()
        {
            BusManagment.SellerTicket.JSellerOwners SellerOwners = new BusManagment.SellerTicket.JSellerOwners();
            GridViewCountersPerson.DataSource = SellerOwners.GetWebPrices(Code);
            GridViewCountersPerson.DataBind();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                BusManagment.SellerTicket.JSellerTicket SellerTicket = new BusManagment.SellerTicket.JSellerTicket();
                SellerTicket.GetData(Code);
                cmbCountersType.SelectedValue = SellerTicket.Type.ToString();
                cmbStation.SelectedValue = SellerTicket.StationCode.ToString();
                txtAddress.Text = SellerTicket.Adress;
                txtTel.Text = SellerTicket.Tel;
                if ((SellerTicket.longs != Convert.ToDecimal(0)) && (SellerTicket.lat != Convert.ToDecimal(0)))
                {
                    ((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapCounters).UserMarkers =
                        new List<WebControllers.MainControls.OpenLayersMap.UserMarker>() { new WebControllers.MainControls.OpenLayersMap.UserMarker("USM_" + SellerTicket.longs.ToString() + SellerTicket.lat.ToString(), Convert.ToDouble(SellerTicket.longs), Convert.ToDouble(SellerTicket.lat)) };
                    txtLon.Text = SellerTicket.longs.ToString();
                    txtLat.Text = SellerTicket.lat.ToString();
                }
                if (!IsPostBack)
                {
                    LoadCountersPerson();
                    LoadCountersDevice();
                }
            }
            ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode = 0;
        }

        public bool SaveSellerInDb(int Code_sellerTicket, DateTime StartDate, DateTime FinishDate, bool Active, int pCode, JDataBase db)
        {
            BusManagment.SellerTicket.JSellerOwner SellerOwner = new BusManagment.SellerTicket.JSellerOwner();
            SellerOwner.PCode = pCode;
            SellerOwner.Code_sellerTicket = Code_sellerTicket;
            SellerOwner.StartDate = StartDate;
            SellerOwner.EndDate = FinishDate;
            SellerOwner.Active = Active;
            return SellerOwner.Insert(db) > 0 ? true : false;
        }

        public bool SaveSellerTicektDevice(int SellerTicektCode, int InstallerCode, int DeviceCode, DateTime StartDate, DateTime FinishDate, bool IsActive, JDataBase db)
        {
            BusManagment.JSellerTicketDevise SellerTicketDevice = new BusManagment.JSellerTicketDevise();
            SellerTicketDevice.SellerTicketCode = SellerTicektCode;
            SellerTicketDevice.Installer = InstallerCode;
            SellerTicketDevice.DeviceCode = DeviceCode;
            SellerTicketDevice.StartDate = StartDate;
            SellerTicketDevice.EndDate = FinishDate;
            SellerTicketDevice.Active = IsActive;
            return SellerTicketDevice.Insert(db) > 0 ? true : false;
        }

        public int Save()
        {
            BusManagment.SellerTicket.JSellerTicket SellerTicket = new BusManagment.SellerTicket.JSellerTicket();
            SellerTicket.Code = Code;
            SellerTicket.Adress = txtAddress.Text;
            SellerTicket.Tel = txtTel.Text;
            SellerTicket.Type = Convert.ToInt32(cmbCountersType.SelectedValue);
            SellerTicket.StationCode = Convert.ToInt32(cmbStation.SelectedValue);
            if (((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapCounters).UserMarkers.Count() > 0)
            {
                SellerTicket.longs = Convert.ToDecimal(((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapCounters).UserMarkers[0].Longitude);
                SellerTicket.lat = Convert.ToDecimal(((WebControllers.MainControls.OpenLayersMap.OpenLayersMap)OpenLayersMapCounters).UserMarkers[0].Latitude);
            }
            else if (txtLat.Text != "" && txtLon.Text != "")
            {
                try
                {
                    SellerTicket.longs = Convert.ToDecimal(txtLon.Text);
                    SellerTicket.lat = Convert.ToDecimal(txtLat.Text);
                }
                catch { }
            }
            bool UpdateRes;
            if (Code > 0)
            {
                UpdateRes = SellerTicket.Update(true);
                if (UpdateRes == true)
                    return 0;
                else
                    return -1;
            }
            else
            {
                return SellerTicket.Insert(true);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int BackCode, InsertCode;
            BackCode = Save();
            JDataBase db = new JDataBase();
            try
            {
                db.beginTransaction("CountersUpdate");
                if (BackCode == 0)
                {
                    JSellerTickets.DeleteBySellerTicketCode(Code, db);
                    InsertCode = Code;
                }
                else
                {
                    InsertCode = BackCode;
                }

                bool result = true;
                int i;
                for (i = 0; i < GridViewCountersPerson.Rows.Count; i++)
                {
                    result = SaveSellerInDb(InsertCode,
                             ClassLibrary.JDateTime.GregorianDate(GridViewCountersPerson.Rows[i].Cells[4].Text),
                             ClassLibrary.JDateTime.GregorianDate(GridViewCountersPerson.Rows[i].Cells[5].Text),
                             Convert.ToBoolean(GridViewCountersPerson.Rows[i].Cells[6].Text),
                             Convert.ToInt32(GridViewCountersPerson.Rows[i].Cells[2].Text), db);
                    if (result == false)
                    {
                        db.Rollback("CountersUpdate");
                        break;
                    }
                }

                int SellerTicektDeviceI;
                for (SellerTicektDeviceI = 0; SellerTicektDeviceI < GridViewSellerTicketDevice.Rows.Count; SellerTicektDeviceI++)
                {
                    result = SaveSellerTicektDevice(InsertCode, Convert.ToInt32(GridViewSellerTicketDevice.Rows[SellerTicektDeviceI].Cells[3].Text.ToString()),
                                           Convert.ToInt32(GridViewSellerTicketDevice.Rows[SellerTicektDeviceI].Cells[2].Text.ToString()),
                                           ClassLibrary.JDateTime.GregorianDate(GridViewSellerTicketDevice.Rows[SellerTicektDeviceI].Cells[5].Text),
                                           ClassLibrary.JDateTime.GregorianDate(GridViewSellerTicketDevice.Rows[SellerTicektDeviceI].Cells[6].Text),
                                           true,
                                           db);
                    if (result == false)
                    {
                        db.Rollback("CountersUpdate");
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

        protected void BtnCountersPersonSave_Click(object sender, EventArgs e)
        {
            if (GridViewCountersPersonSelectedRowId.Value == "0")
            {
                if (((WebControllers.MainControls.Date.JDateControl)txtStartDate).GetFarsiDate().Length == 10)
                {
                    if (((WebControllers.MainControls.Date.JDateControl)txtFinishDate).GetFarsiDate().Length == 10)
                    {
                        if (((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode > 0)
                        {
                            DataTable DtCountersPersonForGrid = new DataTable();
                            DataRow DtRow = DtCountersPersonForGrid.NewRow();
                            DtCountersPersonForGrid.Columns.Add("ردیف");
                            DtCountersPersonForGrid.Columns.Add("کد شخص");
                            DtCountersPersonForGrid.Columns.Add("نام شخص");
                            DtCountersPersonForGrid.Columns.Add("تاریخ شروع");
                            DtCountersPersonForGrid.Columns.Add("تاریخ پایان");
                            DtCountersPersonForGrid.Columns.Add("وضعیت");
                            int i, j;
                            j = 1;
                            for (i = 0; i < GridViewCountersPerson.Rows.Count; i++)
                            {
                                DtRow = DtCountersPersonForGrid.NewRow();
                                DtRow["ردیف"] = j.ToString();
                                DtRow["کد شخص"] = GridViewCountersPerson.Rows[i].Cells[2].Text.ToString();
                                DtRow["نام شخص"] = GridViewCountersPerson.Rows[i].Cells[3].Text.ToString();
                                DtRow["تاریخ شروع"] = GridViewCountersPerson.Rows[i].Cells[4].Text.ToString();
                                DtRow["تاریخ پایان"] = GridViewCountersPerson.Rows[i].Cells[5].Text.ToString();
                                DtRow["وضعیت"] = GridViewCountersPerson.Rows[i].Cells[6].Text.ToString();
                                DtCountersPersonForGrid.Rows.Add(DtRow);
                                j++;
                            }
                            DtRow = DtCountersPersonForGrid.NewRow();
                            DtRow["ردیف"] = j;
                            DtRow["کد شخص"] = ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode;
                            DtRow["نام شخص"] = ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonName;
                            DtRow["تاریخ شروع"] = ((WebControllers.MainControls.Date.JDateControl)txtStartDate).GetFarsiDate();
                            DtRow["تاریخ پایان"] = ((WebControllers.MainControls.Date.JDateControl)txtFinishDate).GetFarsiDate();
                            if (chkStatus.Checked)
                            {
                                DtRow["وضعیت"] = "فعال";
                            }
                            else
                            {
                                DtRow["وضعیت"] = "غیر فعال";
                            }
                            DtCountersPersonForGrid.Rows.Add(DtRow);

                            GridViewCountersPerson.DataSource = DtCountersPersonForGrid;
                            GridViewCountersPerson.DataBind();


                            ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode = 0;
                            chkStatus.Checked = false;
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(GetType(), "Set Person", "alert('لطفا شخص را انتخاب کنید');", true);
                        }
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
            else if (Convert.ToInt32(GridViewCountersPersonSelectedRowId.Value) > 0)
            {
                if (((WebControllers.MainControls.Date.JDateControl)txtStartDate).GetFarsiDate().Length == 10)
                {
                    if (((WebControllers.MainControls.Date.JDateControl)txtFinishDate).GetFarsiDate().Length == 10)
                    {
                        if (((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode > 0)
                        {
                            DataTable DtCountersPersonForGrid = new DataTable();
                            DataRow DtRow = DtCountersPersonForGrid.NewRow();
                            DtCountersPersonForGrid.Columns.Add("ردیف");
                            DtCountersPersonForGrid.Columns.Add("کد شخص");
                            DtCountersPersonForGrid.Columns.Add("نام شخص");
                            DtCountersPersonForGrid.Columns.Add("تاریخ شروع");
                            DtCountersPersonForGrid.Columns.Add("تاریخ پایان");
                            DtCountersPersonForGrid.Columns.Add("وضعیت");
                            int i, j;
                            j = 1;
                            for (i = 0; i < GridViewCountersPerson.Rows.Count; i++)
                            {
                                if (GridViewCountersPerson.Rows[i].Cells[1].Text != GridViewCountersPersonSelectedRowId.Value)
                                {
                                    DtRow = DtCountersPersonForGrid.NewRow();
                                    DtRow["ردیف"] = j.ToString();
                                    DtRow["کد شخص"] = GridViewCountersPerson.Rows[i].Cells[2].Text.ToString();
                                    DtRow["نام شخص"] = GridViewCountersPerson.Rows[i].Cells[3].Text.ToString();
                                    DtRow["تاریخ شروع"] = GridViewCountersPerson.Rows[i].Cells[4].Text.ToString();
                                    DtRow["تاریخ پایان"] = GridViewCountersPerson.Rows[i].Cells[5].Text.ToString();
                                    DtRow["وضعیت"] = GridViewCountersPerson.Rows[i].Cells[6].Text.ToString();
                                    DtCountersPersonForGrid.Rows.Add(DtRow);
                                }
                                else
                                {
                                    DtRow = DtCountersPersonForGrid.NewRow();
                                    DtRow["ردیف"] = j.ToString();
                                    DtRow["کد شخص"] = ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode;
                                    DtRow["نام شخص"] = ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonName;
                                    DtRow["تاریخ شروع"] = ((WebControllers.MainControls.Date.JDateControl)txtStartDate).GetFarsiDate();
                                    DtRow["تاریخ پایان"] = ((WebControllers.MainControls.Date.JDateControl)txtFinishDate).GetFarsiDate();
                                    if (chkStatus.Checked)
                                    {
                                        DtRow["وضعیت"] = "فعال";
                                    }
                                    else
                                    {
                                        DtRow["وضعیت"] = "غیر فعال";
                                    }
                                    DtCountersPersonForGrid.Rows.Add(DtRow);
                                }
                                j++;
                            }
                            GridViewCountersPerson.DataSource = DtCountersPersonForGrid;
                            GridViewCountersPerson.DataBind();
                            GridViewCountersPersonSelectedRowId.Value = "0";
                            ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode = 0;
                            chkStatus.Checked = false;
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(GetType(), "Set Person", "alert('لطفا شخص را انتخاب کنید');", true);
                        }
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

        protected void btnDelCountersPerson_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(GridViewCountersPersonSelectedRowId.Value) > 0)
            {
                DataTable DtCountersPersonForGrid = new DataTable();
                DataRow DtRow = DtCountersPersonForGrid.NewRow();
                DtCountersPersonForGrid.Columns.Add("ردیف");
                DtCountersPersonForGrid.Columns.Add("کد شخص");
                DtCountersPersonForGrid.Columns.Add("نام شخص");
                DtCountersPersonForGrid.Columns.Add("تاریخ شروع");
                DtCountersPersonForGrid.Columns.Add("تاریخ پایان");
                DtCountersPersonForGrid.Columns.Add("وضعیت");
                int i, j;
                j = 1;
                for (i = 0; i < GridViewCountersPerson.Rows.Count; i++)
                {
                    if (GridViewCountersPerson.Rows[i].Cells[1].Text != GridViewCountersPersonSelectedRowId.Value)
                    {
                        DtRow = DtCountersPersonForGrid.NewRow();
                        DtRow["ردیف"] = j.ToString();
                        DtRow["کد شخص"] = GridViewCountersPerson.Rows[i].Cells[2].Text.ToString();
                        DtRow["نام شخص"] = GridViewCountersPerson.Rows[i].Cells[3].Text.ToString();
                        DtRow["تاریخ شروع"] = GridViewCountersPerson.Rows[i].Cells[4].Text.ToString();
                        DtRow["تاریخ پایان"] = GridViewCountersPerson.Rows[i].Cells[5].Text.ToString();
                        DtRow["وضعیت"] = GridViewCountersPerson.Rows[i].Cells[6].Text.ToString();
                        DtCountersPersonForGrid.Rows.Add(DtRow);
                    }
                    j++;
                }
                GridViewCountersPerson.DataSource = DtCountersPersonForGrid;
                GridViewCountersPerson.DataBind();
                GridViewCountersPersonSelectedRowId.Value = "0";
                btnDelCountersPerson.Visible = false;
            }
        }

        protected void GridViewCountersPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Code = "";
            Code = GridViewCountersPerson.SelectedRow.Cells[1].Text.ToString();
            GridViewCountersPersonSelectedRowId.Value = Code;
            ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode = Convert.ToInt32(GridViewCountersPerson.SelectedRow.Cells[2].Text.ToString());
            ((WebControllers.MainControls.Date.JDateControl)txtStartDate).SetDate(Convert.ToDateTime(ClassLibrary.JDateTime.GregorianDate(GridViewCountersPerson.SelectedRow.Cells[4].Text.ToString())));
            ((WebControllers.MainControls.Date.JDateControl)txtFinishDate).SetDate(Convert.ToDateTime(ClassLibrary.JDateTime.GregorianDate(GridViewCountersPerson.SelectedRow.Cells[5].Text.ToString())));
            if (GridViewCountersPerson.SelectedRow.Cells[6].Text.ToString() == "فعال")
            {
                chkStatus.Checked = true;
            }
            else
            {
                chkStatus.Checked = false;
            }
            btnDelCountersPerson.Visible = true;
        }

        protected void BtnSellerTicketDeviceSave_Click(object sender, EventArgs e)
        {
            if (GridViewSellerTicketDeviceSelectedRowId.Value == "0")
            {
                if (((WebControllers.MainControls.Date.JDateControl)txtDeviceStartDate).GetFarsiDate().Length == 10)
                {
                    if (((WebControllers.MainControls.Date.JDateControl)txtDeviceFinishDate).GetFarsiDate().Length == 10)
                    {
                        if (((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlInstaller).PersonCode > 0)
                        {
                            if (((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).Code > 0)
                            {
                                DataTable DtBusDeviceForGrid = new DataTable();
                                DataRow DtRow = DtBusDeviceForGrid.NewRow();
                                DtBusDeviceForGrid.Columns.Add("ردیف");
                                DtBusDeviceForGrid.Columns.Add("کد دستگاه");
                                DtBusDeviceForGrid.Columns.Add("کد نصاب");
                                DtBusDeviceForGrid.Columns.Add("نام نصاب");
                                DtBusDeviceForGrid.Columns.Add("تاریخ شروع");
                                DtBusDeviceForGrid.Columns.Add("تاریخ پایان");
                                int i, j;
                                j = 1;
                                for (i = 0; i < GridViewSellerTicketDevice.Rows.Count; i++)
                                {
                                    DtRow = DtBusDeviceForGrid.NewRow();
                                    DtRow["ردیف"] = j.ToString();
                                    DtRow["کد دستگاه"] = GridViewSellerTicketDevice.Rows[i].Cells[2].Text.ToString();
                                    DtRow["کد نصاب"] = GridViewSellerTicketDevice.Rows[i].Cells[3].Text.ToString();
                                    DtRow["نام نصاب"] = GridViewSellerTicketDevice.Rows[i].Cells[4].Text.ToString();
                                    DtRow["تاریخ شروع"] = GridViewSellerTicketDevice.Rows[i].Cells[5].Text.ToString();
                                    DtRow["تاریخ پایان"] = GridViewSellerTicketDevice.Rows[i].Cells[6].Text.ToString();
                                    DtBusDeviceForGrid.Rows.Add(DtRow);
                                    j++;
                                }
                                DtRow = DtBusDeviceForGrid.NewRow();
                                DtRow["ردیف"] = j;
                                DtRow["کد دستگاه"] = ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).Code;
                                DtRow["کد نصاب"] = ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlInstaller).PersonCode;
                                DtRow["نام نصاب"] = ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlInstaller).PersonName;
                                DtRow["تاریخ شروع"] = ((WebControllers.MainControls.Date.JDateControl)txtDeviceStartDate).GetFarsiDate();
                                DtRow["تاریخ پایان"] = ((WebControllers.MainControls.Date.JDateControl)txtDeviceFinishDate).GetFarsiDate();
                                DtBusDeviceForGrid.Rows.Add(DtRow);

                                GridViewSellerTicketDevice.DataSource = DtBusDeviceForGrid;
                                GridViewSellerTicketDevice.DataBind();


                                ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlInstaller).PersonCode = 0;
                                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).Code = 0;
                                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).SQL = "SELECT [Code],[Tel],[MacAddress],[IMEI] as Title,[Barcode] FROM [dbo].[AUTDevice]";

                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "Set Device", "alert('لطفا دستگاه را انتخاب کنید');", true);
                            }
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(GetType(), "Set Device", "alert('لطفا نصاب را انتخاب کنید');", true);
                        }
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
            else if (Convert.ToInt32(GridViewSellerTicketDeviceSelectedRowId.Value) > 0)
            {
                if (((WebControllers.MainControls.Date.JDateControl)txtDeviceStartDate).GetFarsiDate().Length == 10)
                {
                    if (((WebControllers.MainControls.Date.JDateControl)txtDeviceFinishDate).GetFarsiDate().Length == 10)
                    {
                        if (((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlInstaller).PersonCode > 0)
                        {
                            if (((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).Code > 0)
                            {
                                DataTable DtBusDeviceForGrid = new DataTable();
                                DataRow DtRow = DtBusDeviceForGrid.NewRow();
                                DtBusDeviceForGrid.Columns.Add("ردیف");
                                DtBusDeviceForGrid.Columns.Add("کد دستگاه");
                                DtBusDeviceForGrid.Columns.Add("کد نصاب");
                                DtBusDeviceForGrid.Columns.Add("نام نصاب");
                                DtBusDeviceForGrid.Columns.Add("تاریخ شروع");
                                DtBusDeviceForGrid.Columns.Add("تاریخ پایان");
                                int i, j;
                                j = 1;
                                for (i = 0; i < GridViewSellerTicketDevice.Rows.Count; i++)
                                {
                                    if (GridViewSellerTicketDevice.Rows[i].Cells[1].Text != GridViewSellerTicketDeviceSelectedRowId.Value)
                                    {
                                        DtRow = DtBusDeviceForGrid.NewRow();
                                        DtRow["ردیف"] = j.ToString();
                                        DtRow["کد دستگاه"] = GridViewSellerTicketDevice.Rows[i].Cells[2].Text.ToString();
                                        DtRow["کد نصاب"] = GridViewSellerTicketDevice.Rows[i].Cells[3].Text.ToString();
                                        DtRow["نام نصاب"] = GridViewSellerTicketDevice.Rows[i].Cells[4].Text.ToString();
                                        DtRow["تاریخ شروع"] = GridViewSellerTicketDevice.Rows[i].Cells[5].Text.ToString();
                                        DtRow["تاریخ پایان"] = GridViewSellerTicketDevice.Rows[i].Cells[6].Text.ToString();
                                        DtBusDeviceForGrid.Rows.Add(DtRow);
                                    }
                                    else
                                    {
                                        DtRow = DtBusDeviceForGrid.NewRow();
                                        DtRow["ردیف"] = j;
                                        DtRow["کد دستگاه"] = ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).Code;
                                        DtRow["کد نصاب"] = ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlInstaller).PersonCode;
                                        DtRow["نام نصاب"] = ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlInstaller).PersonName;
                                        DtRow["تاریخ شروع"] = ((WebControllers.MainControls.Date.JDateControl)txtDeviceStartDate).GetFarsiDate();
                                        DtRow["تاریخ پایان"] = ((WebControllers.MainControls.Date.JDateControl)txtDeviceFinishDate).GetFarsiDate();
                                        DtBusDeviceForGrid.Rows.Add(DtRow);
                                    }
                                    j++;
                                }
                                GridViewSellerTicketDevice.DataSource = DtBusDeviceForGrid;
                                GridViewSellerTicketDevice.DataBind();
                                GridViewSellerTicketDeviceSelectedRowId.Value = "0";
                                ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlInstaller).PersonCode = 0;
                                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).Code = 0;
                                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).SQL = "SELECT [Code],[Tel],[MacAddress],[IMEI] as Title,[Barcode] FROM [dbo].[AUTDevice]";
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "Set Device", "alert('لطفا دستگاه را انتخاب کنید');", true);
                            }
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(GetType(), "Set Device", "alert('لطفا نصاب را انتخاب کنید');", true);
                        }
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

        protected void GridViewSellerTicketDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Code = "";
            Code = GridViewSellerTicketDevice.SelectedRow.Cells[1].Text.ToString();
            GridViewSellerTicketDeviceSelectedRowId.Value = Code;
            ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).Code = Convert.ToInt32(GridViewSellerTicketDevice.SelectedRow.Cells[2].Text.ToString());
            ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).SQL = "SELECT [Code],[Tel],[MacAddress],[IMEI] as Title,[Barcode] FROM [dbo].[AUTDevice]";
            ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlInstaller).PersonCode = Convert.ToInt32(GridViewSellerTicketDevice.SelectedRow.Cells[3].Text.ToString());
            ((WebControllers.MainControls.Date.JDateControl)txtDeviceStartDate).SetDate(Convert.ToDateTime(ClassLibrary.JDateTime.GregorianDate(GridViewSellerTicketDevice.SelectedRow.Cells[5].Text.ToString())));
            ((WebControllers.MainControls.Date.JDateControl)txtDeviceFinishDate).SetDate(Convert.ToDateTime(ClassLibrary.JDateTime.GregorianDate(GridViewSellerTicketDevice.SelectedRow.Cells[6].Text.ToString())));
            btnDelSellerTicketDevice.Visible = true;
        }

        protected void btnDelSellerTicketDevice_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(GridViewSellerTicketDeviceSelectedRowId.Value) > 0)
            {
                DataTable DtBusDeviceForGrid = new DataTable();
                DataRow DtRow = DtBusDeviceForGrid.NewRow();
                DtBusDeviceForGrid.Columns.Add("ردیف");
                DtBusDeviceForGrid.Columns.Add("کد دستگاه");
                DtBusDeviceForGrid.Columns.Add("کد نصاب");
                DtBusDeviceForGrid.Columns.Add("نام نصاب");
                DtBusDeviceForGrid.Columns.Add("تاریخ شروع");
                DtBusDeviceForGrid.Columns.Add("تاریخ پایان");
                int i, j;
                j = 1;
                for (i = 0; i < GridViewSellerTicketDevice.Rows.Count; i++)
                {
                    if (GridViewSellerTicketDevice.Rows[i].Cells[1].Text != GridViewSellerTicketDeviceSelectedRowId.Value)
                    {
                        DtRow = DtBusDeviceForGrid.NewRow();
                        DtRow["ردیف"] = j.ToString();
                        DtRow["کد دستگاه"] = GridViewSellerTicketDevice.Rows[i].Cells[2].Text.ToString();
                        DtRow["کد نصاب"] = GridViewSellerTicketDevice.Rows[i].Cells[3].Text.ToString();
                        DtRow["نام نصاب"] = GridViewSellerTicketDevice.Rows[i].Cells[4].Text.ToString();
                        DtRow["تاریخ شروع"] = GridViewSellerTicketDevice.Rows[i].Cells[5].Text.ToString();
                        DtRow["تاریخ پایان"] = GridViewSellerTicketDevice.Rows[i].Cells[6].Text.ToString();
                        DtBusDeviceForGrid.Rows.Add(DtRow);
                    }
                    j++;
                }
                GridViewSellerTicketDevice.DataSource = DtBusDeviceForGrid;
                GridViewSellerTicketDevice.DataBind();
                GridViewSellerTicketDeviceSelectedRowId.Value = "0";
                ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlInstaller).PersonCode = 0;
                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).Code = 0;
                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).SQL = "SELECT [Code],[Tel],[MacAddress],[IMEI] as Title,[Barcode] FROM [dbo].[AUTDevice]";
                btnDelSellerTicketDevice.Visible = false;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BusManagment.SellerTicket.JSellerTicket SellerTicket = new BusManagment.SellerTicket.JSellerTicket();
            SellerTicket.Code = Code;
            if (SellerTicket.Delete(true))
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }

    }
}