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

        private void LoadImage()
        {
            BusManagment.Bus.JBus bus = new BusManagment.Bus.JBus(Code);
            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
            //try
            //{
            //    if (archive.Retrieve(bus.ImageCode))
            //    {
            //        ClassLibrary.JFile image = archive.Content;
            //        if (image != null)
            //            busImage.DataValue = WebClassLibrary.JDataManager.ReadToEnd(image.Stream);
            //    }
            //    else
            //        busImage.DataValue = WebClassLibrary.JDataManager.LoadFile("~/" + WebClassLibrary.JDomains.Images.ControlImages.NoPersonImage);
            //}
            //catch { }
        }

        private void SaveImage()
        {
            if (Code == 0) return;
            if (busImage.DataValue == null) return;
            BusManagment.Bus.JBus bus = new BusManagment.Bus.JBus(Code);
            ArchivedDocuments.JArchiveDocument archive = new ArchivedDocuments.JArchiveDocument(ArchivedDocuments.JConstantArchiveSubjects.ImagesArchiveCode.GetHashCode(), ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode());
            try
            {
                ClassLibrary.JFile jFile = new ClassLibrary.JFile();
                jFile.Content = busImage.DataValue;
                jFile.FileName = busImage.ToolTip;
                jFile.Extension = System.IO.Path.GetExtension(jFile.FileName);
                jFile.FileText = jFile.FileName;
                //if (bus.ImageCode > 0 && archive.Retrieve(bus.ImageCode))
                //    archive.UpdateArchive(jFile, archive.Code, WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode, "تصویر اتوبوس");
                //else
                //    bus.ImageCode = archive.ArchiveDocument(jFile, bus.GetType().FullName, bus.Code, JLanguages._Text("BusPicture"), true);
                if (bus.Update())// person.Update())
                {

                }
            }
            catch { }

        }

        protected void upldPhoto_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
        {
            busImage.DataValue = WebClassLibrary.JDataManager.ReadToEnd(e.File.InputStream);
            busImage.ToolTip = e.File.FileName;
            SaveImage();
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
            DataTable dt = BusOwners.GetWebOwners(Code);
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
            if (dt != null && dt.Rows.Count > 0)
            { 
                for (i = 0; i < dt.Rows.Count; i++)
                {
                    DtRow = DtBusPersonForGrid.NewRow();
                    DtRow["ردیف"] = j.ToString();
                    DtRow["کد شخص"] = dt.Rows[i][1].ToString();
                    DtRow["نام شخص"] = dt.Rows[i][2].ToString();
                    DtRow["تاریخ شروع"] = dt.Rows[i][3].ToString();
                    DtRow["تاریخ پایان"] = dt.Rows[i][4].ToString();
                    DtRow["وضعیت"] = dt.Rows[i][5].ToString() == "True" ? "فعال" : "غیر فعال";
                    DtBusPersonForGrid.Rows.Add(DtRow);
                    j++;
                }
            }
            GridViewBusPerson.DataSource = DtBusPersonForGrid;
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
                chkISValidBus.Checked = Bus.IsValid == 1;
                if (Bus.IsValid == 0 && JPermission.CheckPermission("WebBusManagement.FormsManagement.JBusesUpdateControl.MakeValid"))
                    chkISValidBus.Enabled = true;
                else
                    chkISValidBus.Enabled = false;
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
            //else
            //{
            //    ((WebControllers.ArchiveDocument.JArchiveControl)jArchiveControl).ClassName = "BusManagment.Bus.JBus";
            //    ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControl).Code = 0;
            //    ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControl).SQL = "SELECT [code],[Plaque] as Title,[Model] FROM [dbo].[AUTAutomobile]";
            //}
        }

        public int BusSave(int CarCode)
        {
            BusManagment.Bus.JBus Bus = new BusManagment.Bus.JBus();
            Bus.Code = Code;
            if (Code > 0)
                Bus.GetData(Code);
            Bus.BUSNumber = Convert.ToDouble(txtBusCode.Text);
            Bus.CarCode = CarCode;
            Bus.FleetCode = Convert.ToInt32(cmbFleet.SelectedValue);
            Bus.Active = chkBusStatus.Checked;
            if (
                (Code == 0 && (!chkISValidBus.Checked || (JPermission.CheckPermission("WebBusManagement.FormsManagement.JBusesUpdateControl.MakeValid")))) || 
                (Code > 0 && (Bus.IsValid == (chkISValidBus.Checked ? 1: 0) || (chkISValidBus.Checked && JPermission.CheckPermission("WebBusManagement.FormsManagement.JBusesUpdateControl.MakeValid")))))
                Bus.IsValid = (chkISValidBus.Checked ? 1 : 0); 
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

        public bool SaveBusOwner(int BusCode, int CodePerson, DateTime StartDate, DateTime FinishDate, bool IsActive, JDataBase db, bool UpdateTicketTransaction)
        {
            if (UpdateTicketTransaction)
            {
                JDataBase db2 = new JDataBase();
                db2.setQuery(@"
                    declare @dates table (TranDate Date)

                    update AUTTicketTransaction set OwnerCode = @OwnerCode output Cast(inserted.EventDate as date) into @dates 
                    where BusCode = @BusCode and (OwnerCode is null or OwnerCode in (0, -1)) and EventDate between @BeginDate and @FinishDate

	                declare @DateTimeN DateTime

	                declare Date_Cursor_Temp_ProcessTicket1 CURSOR FOR 
	                select TranDate from @dates

	                OPEN Date_Cursor_Temp_ProcessTicket1
	                FETCH NEXT FROM Date_Cursor_Temp_ProcessTicket1 INTO @DateTimeN
	                WHILE @@FETCH_STATUS = 0
	                BEGIN
                        declare @WorkDate int
                        select @WorkDate = isnull(Code,0) from AUTWorkedDay where Date=cast(@DateTimeN as date)

                        if(@WorkDate = 0 OR @WorkDate is NULL)
                        BEGIN
	                        Insert into AUTWorkedDay Values
	                        (
		                        (select isnull(Max(Code),0) +1 from AUTWorkedDay),
		                        cast(@DateTimeN as Date),
		                        1
	                        )
                        END
                        ELSE
                        BEGIN
	                        Update AUTWorkedDay set Active=1 WHERE Code =@WorkDate
                        END

	                    FETCH NEXT FROM Date_Cursor_Temp_ProcessTicket1 INTO @DateTimeN
	                END
	                CLOSE Date_Cursor_Temp_ProcessTicket1;
	                DEALLOCATE Date_Cursor_Temp_ProcessTicket1;");
                db2.AddParams("OwnerCode", CodePerson.ToString());
                db2.AddParams("BusCode", BusCode.ToString());
                db2.AddParams("BeginDate", StartDate.ToString("yyyy-MM-dd 00:00:00"));
                db2.AddParams("FinishDate", FinishDate.ToString("yyyy-MM-dd 23:59:59"));
                db2.Query_Execute(true);
            }
            BusManagment.Bus.JBusOwner BusOwner = new BusManagment.Bus.JBusOwner();
            BusOwner.BusCode = BusCode;
            BusOwner.CodePerson = CodePerson;
            BusOwner.StartDate = StartDate;
            BusOwner.EndDate = FinishDate;
            BusOwner.IsActive = IsActive;
            return BusOwner.Insert(db) > 0 ? true : false;
        }

        public bool SaveBusDevice(int BusCode, int InstallerCode, int DeviceCode, DateTime StartDate, string FinishDate, bool IsActive, JDataBase db)
        {
            BusManagment.JBusDevise BusDevice = new BusManagment.JBusDevise();
            BusDevice.BusCode = BusCode;
            BusDevice.Installer = InstallerCode;
            BusDevice.DeviceCode = DeviceCode;
            BusDevice.StartDate = StartDate;
            //BusDevice.EndDate = FinishDate;
            BusDevice.Active = IsActive;
            SaveInstallAndUinstallDevice(StartDate, DeviceCode, BusCode, InstallerCode);
            return BusDevice.Insert(db) > 0 ? true : false;
        }

        public void SaveInstallAndUinstallDevice(DateTime EventDate, int DeviceCode, int BusCode, int InstallerCode)
        {
            BusManagment.JBusInstallAndUnistallDevise BusInstallDevice = new BusManagment.JBusInstallAndUnistallDevise();
            BusInstallDevice.EventDate = EventDate;
            BusInstallDevice.DeviceCode = DeviceCode;
            BusInstallDevice.BusCode = BusCode;
            BusInstallDevice.Installer = InstallerCode;
            BusInstallDevice.Type = false;
            BusInstallDevice.Insert();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            int BackCode, InsertCode;
            List<string> ChangedOwners = new List<string>();

            if (hdChangedOwners.Value.Length > 0)
            {
                ChangedOwners = (hdChangedOwners.Value.Substring(1)).Split(',').ToList();
            }

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
                    string ActiveStatusBusPerson = "";
                    for (i = 0; i < GridViewBusPerson.Rows.Count; i++)
                    {
                        ActiveStatusBusPerson = GridViewBusPerson.Rows[i].Cells[6].Text;
                        if (ActiveStatusBusPerson == "فعال")
                        {
                            ActiveStatusBusPerson = "True";
                        }
                        else
                        {
                            ActiveStatusBusPerson = "False";
                        }
                        bool UpdateTicketTransaction = ChangedOwners.Contains(GridViewBusPerson.Rows[i].Cells[2].Text);
                        result = SaveBusOwner(InsertCode, Convert.ToInt32(GridViewBusPerson.Rows[i].Cells[2].Text),
                                 ClassLibrary.JDateTime.GregorianDate(GridViewBusPerson.Rows[i].Cells[4].Text),
                                 ClassLibrary.JDateTime.GregorianDate(GridViewBusPerson.Rows[i].Cells[5].Text),
                                 Convert.ToBoolean(ActiveStatusBusPerson), db, UpdateTicketTransaction);
                        if (result == false)
                        {
                            db.Rollback("BusUpdate");
                            break;
                        }
                    }

                    int BusDeviceI;
                    for (BusDeviceI = 0; BusDeviceI < GridViewBusDevice.Rows.Count; BusDeviceI++)
                    {
                        if (GridViewBusDevice.Rows[BusDeviceI].Cells[5].Text.Length >= 8)
                        {
                            result = SaveBusDevice(InsertCode, Convert.ToInt32(GridViewBusDevice.Rows[BusDeviceI].Cells[3].Text.ToString()),
                                                   Convert.ToInt32(GridViewBusDevice.Rows[BusDeviceI].Cells[2].Text.ToString()),
                                                   ClassLibrary.JDateTime.GregorianDate(GridViewBusDevice.Rows[BusDeviceI].Cells[5].Text),
                                                   GridViewBusDevice.Rows[BusDeviceI].Cells[6].Text,
                                                   true,
                                                   db);
                        }
                        else
                        {
                            result = SaveBusDevice(InsertCode, Convert.ToInt32(GridViewBusDevice.Rows[BusDeviceI].Cells[3].Text.ToString()),
                                                  Convert.ToInt32(GridViewBusDevice.Rows[BusDeviceI].Cells[2].Text.ToString()),
                                                  DateTime.Now,
                                                  GridViewBusDevice.Rows[BusDeviceI].Cells[6].Text,
                                                  true,
                                                  db);
                        }
                        if (result == false)
                        {
                            db.Rollback("BusUpdate");
                            break;
                        }
                    }

                    if (result == true)
                    {
                        db.Commit();
                        try
                        {
                            ClassLibrary.JDataBase dbAccProc = new ClassLibrary.JDataBase();
                            dbAccProc.setQuery("EXEC SP_FinInsertTafzili");
                            dbAccProc.Query_Execute();
                        }
                        catch { }
                    }
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
                            if (GridViewBusPerson.Rows.Count > 0 && chkStatus.Checked)
                            {
                                for(int k = 0; k < GridViewBusPerson.Rows.Count; k++)
                                {
                                    bool Status = GridViewBusPerson.Rows[k].Cells[6].Text == "فعال";
                                    if (Status)
                                    {
                                        Page.ClientScript.RegisterStartupScript(GetType(), "Duplicate Person", "alert('امکان ثبت دو مالک فعال وجود ندارد');", true);
                                        return;
                                    }
                                }
                            }
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
                                if(GridViewBusPerson.Rows[i].Cells[4].Text.ToString() != "&nbsp;")
                                    DtRow["تاریخ شروع"] = GridViewBusPerson.Rows[i].Cells[4].Text.ToString();
                                if (GridViewBusPerson.Rows[i].Cells[5].Text.ToString() != "&nbsp;")
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

                            hdChangedOwners.Value += "," + ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode;

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
                            if (GridViewBusPerson.Rows.Count > 1 && chkStatus.Checked)
                            {
                                for (int k = 0; k < GridViewBusPerson.Rows.Count; k++)
                                {
                                    bool Status = GridViewBusPerson.Rows[k].Cells[6].Text == "فعال";
                                    if (Status & GridViewBusPerson.Rows[k].Cells[1].Text != GridViewBusPersonSelectedRowId.Value)
                                    {
                                        Page.ClientScript.RegisterStartupScript(GetType(), "Duplicate Person", "alert('امکان ثبت دو مالک فعال وجود ندارد');", true);
                                        return;
                                    }
                                }
                            }
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
                                    if (GridViewBusPerson.Rows[i].Cells[4].Text.ToString() != "&nbsp;")
                                        DtRow["تاریخ شروع"] = GridViewBusPerson.Rows[i].Cells[4].Text.ToString();
                                    if (GridViewBusPerson.Rows[i].Cells[5].Text.ToString() != "&nbsp;")
                                    DtRow["تاریخ پایان"] = GridViewBusPerson.Rows[i].Cells[5].Text.ToString();
                                    DtRow["وضعیت"] = GridViewBusPerson.Rows[i].Cells[6].Text.ToString();
                                    DtBusPersonForGrid.Rows.Add(DtRow);
                                }
                                else
                                {
                                    DateTime LastStartDate = new DateTime(), LastFinishDate = new DateTime();

                                    LastStartDate = ClassLibrary.JDateTime.GregorianDate(GridViewBusPerson.Rows[i].Cells[4].Text.ToString());

                                    LastFinishDate = ClassLibrary.JDateTime.GregorianDate(GridViewBusPerson.Rows[i].Cells[5].Text.ToString());

                                    if (((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode
                                        != Convert.ToInt32(GridViewBusPerson.Rows[i].Cells[2].Text)
                                        || LastStartDate != ((WebControllers.MainControls.Date.JDateControl)txtStartDate).GetDate()
                                        || LastFinishDate != ((WebControllers.MainControls.Date.JDateControl)txtFinishDate).GetDate())
                                    {
                                        hdChangedOwners.Value += "," + Convert.ToInt32(GridViewBusPerson.Rows[i].Cells[2].Text);
                                    }

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
                            btnSave.Enabled = true;
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
            btnSave.Enabled = false;
        }

        protected void BtnBusDeviceSave_Click(object sender, EventArgs e)
        {
            if (GridViewBusDeviceSelectedRowId.Value == "0")
            {
                if (((WebControllers.MainControls.Date.JDateControl)txtDeviceStartDate).GetFarsiDate().Length == 10)
                {
                    //if (((WebControllers.MainControls.Date.JDateControl)txtDeviceFinishDate).GetFarsiDate().Length == 10)
                    //{
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
                            DtRow["تاریخ پایان"] = "";
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
                    //}
                    //else
                    //{
                    //    Page.ClientScript.RegisterStartupScript(GetType(), "Set FinishDate", "alert('لطفا تاریخ پایان را انتخاب کنید');", true);
                    //}
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
                    //if (((WebControllers.MainControls.Date.JDateControl)txtDeviceFinishDate).GetFarsiDate().Length == 10)
                    //{
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
                                    DtRow["تاریخ پایان"] = "";
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
                    //}
                    //else
                    //{
                    //    Page.ClientScript.RegisterStartupScript(GetType(), "Set FinishDate", "alert('لطفا تاریخ پایان را انتخاب کنید');", true);
                    //}
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
            //((WebControllers.MainControls.Date.JDateControl)txtDeviceFinishDate).SetDate(Convert.ToDateTime(ClassLibrary.JDateTime.GregorianDate(GridViewBusDevice.SelectedRow.Cells[6].Text.ToString())));
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BusManagment.Bus.JBus Bus = new BusManagment.Bus.JBus();
            Bus.Code = Code;
            if (Bus.Delete(true))
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }

    }
}