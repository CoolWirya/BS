using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusManagment.Fleet;
using ClassLibrary;
using BusManagment.Bus;

namespace WebBusManagement.FormsManagement
{
    public partial class JBusesUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            LoadFleet();
            // Custom List Search
            ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).Code = 0;
            ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).SQL = "SELECT Code,CASE [TYPE] WHEN 1 THEN N'کنسول' ELSE N'کارتخوان' END AS DeviceType,IMEI AS Title,Model FROM [dbo].[AUTDevice]";
            // Archive Document
            _SetForm();
        }

        public void LoadFleet()
        {
            DataTable DtFleet = new DataTable();
            DtFleet = JFleets.GetDataTable(0);
            cmbFleet.DataSource = DtFleet;
            cmbFleet.DataTextField = "Name";
            cmbFleet.DataValueField = "Code";
            cmbFleet.DataBind();
        }

        public void LoadBusPerson()
        {
            BusManagment.Bus.JBusOwners BusOwners = new BusManagment.Bus.JBusOwners();
            GridViewBusPerson.DataSource = BusOwners.GetWebOwners(Code);
            GridViewBusPerson.DataBind();
        }

        public void LoadBusDevice()
        {
            BusManagment.JBusDevices BusDevice = new BusManagment.JBusDevices();
            GridViewBusDevice.DataSource = BusDevice.GetWebDevices(Code);
            GridViewBusDevice.DataBind();
        }

        public void _SetForm()
        {

            //((WebControllers.Property.JPropertyViewControl)JPropertyViewControl).ClassName = "BusManagment.JBus";
            //((WebControllers.Property.JPropertyViewControl)JPropertyViewControl).ObjectCode = 1;
            //((WebControllers.Property.JPropertyViewControl)JPropertyViewControl).ValueObjectCode = Code;
            //((WebControllers.Property.JPropertyViewControl)JPropertyViewControl).isMultiple = false;
            //((WebControllers.Property.JPropertyViewControl)JPropertyViewControl).LoadProperty();

            if (Code > 0)
            {
                BusManagment.Bus.JBus Bus = new BusManagment.Bus.JBus();
                Bus.GetData(Code);
                txtBusCode.Text = Bus.BUSNumber.ToString();
                cmbFleet.SelectedValue = Bus.FleetCode.ToString();
                chkBusStatus.Checked = Bus.Active;
                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControl).Code = Bus.CarCode;
                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControl).SQL = "SELECT [code],[Plaque] as Title,[Model] FROM [dbo].[AUTAutomobile]";
                if (!IsPostBack)
                {
                    LoadBusPerson();
                    LoadBusDevice();
                }
                ((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl).ClassName = "BusManagment.Bus.JBus";
                ((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl).ObjectCode = Code;
                ((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl).LoadArchive();

            }
            else
            {
                ((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl).ClassName = "BusManagment.Bus.JBus";
                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControl).Code = 0;
                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControl).SQL = "SELECT [code],[Plaque] as Title,[Model] FROM [dbo].[AUTAutomobile]";
            }
        }

        public int BusSave(int CarCode)
        {
            BusManagment.Bus.JBus Bus = new BusManagment.Bus.JBus();
            Bus.Code = Code;
            Bus.BUSNumber = Convert.ToDouble(txtBusCode.Text);
            Bus.CarCode = CarCode;
            Bus.FleetCode = Convert.ToInt32(cmbFleet.SelectedValue);
            Bus.Active = chkBusStatus.Checked;
            bool UpdateRes;
            int InsertBackCode;
            if (Code > 0)
            {
                UpdateRes = Bus.Update(true);
                if (UpdateRes == true)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                InsertBackCode = Bus.Insert(true);
                if (InsertBackCode > 0)
                {
                    return InsertBackCode;
                }
                else
                {
                    return -1;
                }
            }
        }

        public bool SaveBusOwner(int BusCode, int CodePerson, DateTime StartDate, DateTime FinishDate, bool IsActive, JDataBase db)
        {
            BusManagment.Bus.JBusOwner BusOwner = new BusManagment.Bus.JBusOwner();
            BusOwner.BusCode = BusCode;
            BusOwner.CodePerson = CodePerson;
            BusOwner.StartDate = StartDate;
            BusOwner.EndDate = FinishDate;
            BusOwner.IsActive = IsActive;
            return BusOwner.Insert(db) > 0 ? true : false;
        }

        public bool SaveBusDevice(int BusCode, int InstallerCode, int DeviceCode, DateTime StartDate, DateTime FinishDate, bool IsActive, JDataBase db)
        {
            BusManagment.JBusDevise BusDevice = new BusManagment.JBusDevise();
            BusDevice.BusCode = BusCode;
            BusDevice.Installer = InstallerCode;
            BusDevice.DeviceCode = DeviceCode;
            BusDevice.StartDate = StartDate;
            BusDevice.EndDate = FinishDate;
            BusDevice.Active = IsActive;
            return BusDevice.Insert(db) > 0 ? true : false;
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            int BackCode, InsertCode;
            if (((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControl).Code > 0)
            {
                BackCode = BusSave(((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControl).Code);
                JDataBase db = new JDataBase();
                try
                {
                    db.beginTransaction("BusUpdate");
                    if (BackCode == 0)
                    {
                        BusManagment.Bus.JBusOwners.DeleteByBusCode(Code, db);
                        BusManagment.JBusDevices.DeleteByBusCode(Code, db);
                        InsertCode = Code;
                    }
                    else
                    {
                        InsertCode = BackCode;
                    }

                    bool result = true;
                    int i;
                    for (i = 0; i < GridViewBusPerson.Rows.Count; i++)
                    {
                        result = SaveBusOwner(InsertCode, Convert.ToInt32(GridViewBusPerson.Rows[i].Cells[2].Text),
                                 ClassLibrary.JDateTime.GregorianDate(GridViewBusPerson.Rows[i].Cells[4].Text),
                                 ClassLibrary.JDateTime.GregorianDate(GridViewBusPerson.Rows[i].Cells[5].Text),
                                 Convert.ToBoolean(GridViewBusPerson.Rows[i].Cells[6].Text), db);
                        if (result == false)
                        {
                            db.Rollback("BusUpdate");
                            break;
                        }
                    }

                    int BusDeviceI;
                    for (BusDeviceI = 0; BusDeviceI < GridViewBusDevice.Rows.Count; BusDeviceI++)
                    {
                        result = SaveBusDevice(InsertCode, Convert.ToInt32(GridViewBusDevice.Rows[BusDeviceI].Cells[3].Text.ToString()),
                                               Convert.ToInt32(GridViewBusDevice.Rows[BusDeviceI].Cells[2].Text.ToString()),
                                               ClassLibrary.JDateTime.GregorianDate(GridViewBusDevice.Rows[BusDeviceI].Cells[5].Text),
                                               ClassLibrary.JDateTime.GregorianDate(GridViewBusDevice.Rows[BusDeviceI].Cells[6].Text),
                                               true,
                                               db);
                        if (result == false)
                        {
                            db.Rollback("BusUpdate");
                            break;
                        }
                    }

                    if (result == true)
                        db.Commit();

                    ((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl).ClassName = "BusManagment.Bus.JBus";
                    ((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl).ObjectCode = Code;
                    ((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl).SaveToArchive();

                    WebClassLibrary.JWebManager.CloseAndRefresh();
                }
                finally
                {
                    db.Dispose();
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "Set Person", "alert('لطفا اتومبیل را انتخاب کنید');", true);
            }
        }




        protected void BtnBusPersonSave_Click(object sender, EventArgs e)
        {
            if (GridViewBusPersonSelectedRowId.Value == "0")
            {
                if (((WebControllers.MainControls.Date.JDateControl)txtStartDate).GetFarsiDate().Length == 10)
                {
                    if (((WebControllers.MainControls.Date.JDateControl)txtFinishDate).GetFarsiDate().Length == 10)
                    {
                        if (((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode > 0)
                        {
                            DataTable DtBusPersonForGrid = new DataTable();
                            DataRow DtRow = DtBusPersonForGrid.NewRow();
                            DtBusPersonForGrid.Columns.Add("ردیف");
                            DtBusPersonForGrid.Columns.Add("کد شخص");
                            DtBusPersonForGrid.Columns.Add("نام شخص");
                            DtBusPersonForGrid.Columns.Add("تاریخ شروع");
                            DtBusPersonForGrid.Columns.Add("تاریخ پایان");
                            DtBusPersonForGrid.Columns.Add("وضعیت");
                            int i, j;
                            j = 1;
                            for (i = 0; i < GridViewBusPerson.Rows.Count; i++)
                            {
                                DtRow = DtBusPersonForGrid.NewRow();
                                DtRow["ردیف"] = j.ToString();
                                DtRow["کد شخص"] = GridViewBusPerson.Rows[i].Cells[2].Text.ToString();
                                DtRow["نام شخص"] = GridViewBusPerson.Rows[i].Cells[3].Text.ToString();
                                DtRow["تاریخ شروع"] = GridViewBusPerson.Rows[i].Cells[4].Text.ToString();
                                DtRow["تاریخ پایان"] = GridViewBusPerson.Rows[i].Cells[5].Text.ToString();
                                DtRow["وضعیت"] = GridViewBusPerson.Rows[i].Cells[6].Text.ToString();
                                DtBusPersonForGrid.Rows.Add(DtRow);
                                j++;
                            }
                            DtRow = DtBusPersonForGrid.NewRow();
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
                            DtBusPersonForGrid.Rows.Add(DtRow);

                            GridViewBusPerson.DataSource = DtBusPersonForGrid;
                            GridViewBusPerson.DataBind();


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
            else if (Convert.ToInt32(GridViewBusPersonSelectedRowId.Value) > 0)
            {
                if (((WebControllers.MainControls.Date.JDateControl)txtStartDate).GetFarsiDate().Length == 10)
                {
                    if (((WebControllers.MainControls.Date.JDateControl)txtFinishDate).GetFarsiDate().Length == 10)
                    {
                        if (((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode > 0)
                        {
                            DataTable DtBusPersonForGrid = new DataTable();
                            DataRow DtRow = DtBusPersonForGrid.NewRow();
                            DtBusPersonForGrid.Columns.Add("ردیف");
                            DtBusPersonForGrid.Columns.Add("کد شخص");
                            DtBusPersonForGrid.Columns.Add("نام شخص");
                            DtBusPersonForGrid.Columns.Add("تاریخ شروع");
                            DtBusPersonForGrid.Columns.Add("تاریخ پایان");
                            DtBusPersonForGrid.Columns.Add("وضعیت");
                            int i, j;
                            j = 1;
                            for (i = 0; i < GridViewBusPerson.Rows.Count; i++)
                            {
                                if (GridViewBusPerson.Rows[i].Cells[1].Text != GridViewBusPersonSelectedRowId.Value)
                                {
                                    DtRow = DtBusPersonForGrid.NewRow();
                                    DtRow["ردیف"] = j.ToString();
                                    DtRow["کد شخص"] = GridViewBusPerson.Rows[i].Cells[2].Text.ToString();
                                    DtRow["نام شخص"] = GridViewBusPerson.Rows[i].Cells[3].Text.ToString();
                                    DtRow["تاریخ شروع"] = GridViewBusPerson.Rows[i].Cells[4].Text.ToString();
                                    DtRow["تاریخ پایان"] = GridViewBusPerson.Rows[i].Cells[5].Text.ToString();
                                    DtRow["وضعیت"] = GridViewBusPerson.Rows[i].Cells[6].Text.ToString();
                                    DtBusPersonForGrid.Rows.Add(DtRow);
                                }
                                else
                                {
                                    DtRow = DtBusPersonForGrid.NewRow();
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
                                    DtBusPersonForGrid.Rows.Add(DtRow);
                                }
                                j++;
                            }
                            GridViewBusPerson.DataSource = DtBusPersonForGrid;
                            GridViewBusPerson.DataBind();
                            GridViewBusPersonSelectedRowId.Value = "0";
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

        protected void btnDelBusPerson_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(GridViewBusPersonSelectedRowId.Value) > 0)
            {
                DataTable DtBusPersonForGrid = new DataTable();
                DataRow DtRow = DtBusPersonForGrid.NewRow();
                DtBusPersonForGrid.Columns.Add("ردیف");
                DtBusPersonForGrid.Columns.Add("کد شخص");
                DtBusPersonForGrid.Columns.Add("نام شخص");
                DtBusPersonForGrid.Columns.Add("تاریخ شروع");
                DtBusPersonForGrid.Columns.Add("تاریخ پایان");
                DtBusPersonForGrid.Columns.Add("وضعیت");
                int i, j;
                j = 1;
                for (i = 0; i < GridViewBusPerson.Rows.Count; i++)
                {
                    if (GridViewBusPerson.Rows[i].Cells[1].Text != GridViewBusPersonSelectedRowId.Value)
                    {
                        DtRow = DtBusPersonForGrid.NewRow();
                        DtRow["ردیف"] = j.ToString();
                        DtRow["کد شخص"] = GridViewBusPerson.Rows[i].Cells[2].Text.ToString();
                        DtRow["نام شخص"] = GridViewBusPerson.Rows[i].Cells[3].Text.ToString();
                        DtRow["تاریخ شروع"] = GridViewBusPerson.Rows[i].Cells[4].Text.ToString();
                        DtRow["تاریخ پایان"] = GridViewBusPerson.Rows[i].Cells[5].Text.ToString();
                        DtRow["وضعیت"] = GridViewBusPerson.Rows[i].Cells[6].Text.ToString();
                        DtBusPersonForGrid.Rows.Add(DtRow);
                    }
                    j++;
                }
                GridViewBusPerson.DataSource = DtBusPersonForGrid;
                GridViewBusPerson.DataBind();
                GridViewBusPersonSelectedRowId.Value = "0";
                btnDelBusPerson.Visible = false;
            }
        }

        protected void GridViewBusPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Code = "";
            Code = GridViewBusPerson.SelectedRow.Cells[1].Text.ToString();
            GridViewBusPersonSelectedRowId.Value = Code;
            ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode = Convert.ToInt32(GridViewBusPerson.SelectedRow.Cells[2].Text.ToString());
            ((WebControllers.MainControls.Date.JDateControl)txtStartDate).SetDate(Convert.ToDateTime(ClassLibrary.JDateTime.GregorianDate(GridViewBusPerson.SelectedRow.Cells[4].Text.ToString())));
            ((WebControllers.MainControls.Date.JDateControl)txtFinishDate).SetDate(Convert.ToDateTime(ClassLibrary.JDateTime.GregorianDate(GridViewBusPerson.SelectedRow.Cells[5].Text.ToString())));
            if (GridViewBusPerson.SelectedRow.Cells[6].Text.ToString() == "فعال")
            {
                chkStatus.Checked = true;
            }
            else
            {
                chkStatus.Checked = false;
            }
            btnDelBusPerson.Visible = true;
        }

        protected void BtnBusDeviceSave_Click(object sender, EventArgs e)
        {
            if (GridViewBusDeviceSelectedRowId.Value == "0")
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
                                for (i = 0; i < GridViewBusDevice.Rows.Count; i++)
                                {
                                    DtRow = DtBusDeviceForGrid.NewRow();
                                    DtRow["ردیف"] = j.ToString();
                                    DtRow["کد دستگاه"] = GridViewBusDevice.Rows[i].Cells[2].Text.ToString();
                                    DtRow["کد نصاب"] = GridViewBusDevice.Rows[i].Cells[3].Text.ToString();
                                    DtRow["نام نصاب"] = GridViewBusDevice.Rows[i].Cells[4].Text.ToString();
                                    DtRow["تاریخ شروع"] = GridViewBusDevice.Rows[i].Cells[5].Text.ToString();
                                    DtRow["تاریخ پایان"] = GridViewBusDevice.Rows[i].Cells[6].Text.ToString();
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

                                GridViewBusDevice.DataSource = DtBusDeviceForGrid;
                                GridViewBusDevice.DataBind();


                                ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlInstaller).PersonCode = 0;
                                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).Code = 0;
                                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).SQL = "SELECT Code,CASE [TYPE] WHEN 1 THEN N'کنسول' ELSE N'کارتخوان' END AS DeviceType,IMEI AS Title,Model FROM [dbo].[AUTDevice]";

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
            else if (Convert.ToInt32(GridViewBusDeviceSelectedRowId.Value) > 0)
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
                                for (i = 0; i < GridViewBusDevice.Rows.Count; i++)
                                {
                                    if (GridViewBusDevice.Rows[i].Cells[1].Text != GridViewBusDeviceSelectedRowId.Value)
                                    {
                                        DtRow = DtBusDeviceForGrid.NewRow();
                                        DtRow["ردیف"] = j.ToString();
                                        DtRow["کد دستگاه"] = GridViewBusDevice.Rows[i].Cells[2].Text.ToString();
                                        DtRow["کد نصاب"] = GridViewBusDevice.Rows[i].Cells[3].Text.ToString();
                                        DtRow["نام نصاب"] = GridViewBusDevice.Rows[i].Cells[4].Text.ToString();
                                        DtRow["تاریخ شروع"] = GridViewBusDevice.Rows[i].Cells[5].Text.ToString();
                                        DtRow["تاریخ پایان"] = GridViewBusDevice.Rows[i].Cells[6].Text.ToString();
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
                                GridViewBusDevice.DataSource = DtBusDeviceForGrid;
                                GridViewBusDevice.DataBind();
                                GridViewBusDeviceSelectedRowId.Value = "0";
                                ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlInstaller).PersonCode = 0;
                                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).Code = 0;
                                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).SQL = "SELECT Code,CASE [TYPE] WHEN 1 THEN N'کنسول' ELSE N'کارتخوان' END AS DeviceType,IMEI AS Title,Model FROM [dbo].[AUTDevice]";
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

        protected void GridViewBusDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Code = "";
            Code = GridViewBusDevice.SelectedRow.Cells[1].Text.ToString();
            GridViewBusDeviceSelectedRowId.Value = Code;
            ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).Code = Convert.ToInt32(GridViewBusDevice.SelectedRow.Cells[2].Text.ToString());
            ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).SQL = "SELECT Code,CASE [TYPE] WHEN 1 THEN N'کنسول' ELSE N'کارتخوان' END AS DeviceType,IMEI AS Title,Model FROM [dbo].[AUTDevice]";
            ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlInstaller).PersonCode = Convert.ToInt32(GridViewBusDevice.SelectedRow.Cells[3].Text.ToString());
            ((WebControllers.MainControls.Date.JDateControl)txtDeviceStartDate).SetDate(Convert.ToDateTime(ClassLibrary.JDateTime.GregorianDate(GridViewBusDevice.SelectedRow.Cells[5].Text.ToString())));
            ((WebControllers.MainControls.Date.JDateControl)txtDeviceFinishDate).SetDate(Convert.ToDateTime(ClassLibrary.JDateTime.GregorianDate(GridViewBusDevice.SelectedRow.Cells[6].Text.ToString())));
            btnDelBusDevice.Visible = true;
        }

        protected void btnDelBusDevice_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(GridViewBusDeviceSelectedRowId.Value) > 0)
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
                for (i = 0; i < GridViewBusDevice.Rows.Count; i++)
                {
                    if (GridViewBusDevice.Rows[i].Cells[1].Text != GridViewBusDeviceSelectedRowId.Value)
                    {
                        DtRow = DtBusDeviceForGrid.NewRow();
                        DtRow["ردیف"] = j.ToString();
                        DtRow["کد دستگاه"] = GridViewBusDevice.Rows[i].Cells[2].Text.ToString();
                        DtRow["کد نصاب"] = GridViewBusDevice.Rows[i].Cells[3].Text.ToString();
                        DtRow["نام نصاب"] = GridViewBusDevice.Rows[i].Cells[4].Text.ToString();
                        DtRow["تاریخ شروع"] = GridViewBusDevice.Rows[i].Cells[5].Text.ToString();
                        DtRow["تاریخ پایان"] = GridViewBusDevice.Rows[i].Cells[6].Text.ToString();
                        DtBusDeviceForGrid.Rows.Add(DtRow);
                    }
                    j++;
                }
                GridViewBusDevice.DataSource = DtBusDeviceForGrid;
                GridViewBusDevice.DataBind();
                GridViewBusDeviceSelectedRowId.Value = "0";
                ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlInstaller).PersonCode = 0;
                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).Code = 0;
                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).SQL = "SELECT Code,CASE [TYPE] WHEN 1 THEN N'کنسول' ELSE N'کارتخوان' END AS DeviceType,IMEI AS Title,Model FROM [dbo].[AUTDevice]";
                btnDelBusDevice.Visible = false;
            }
        }

    }
}