using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

namespace WebBusManagement.FormsManagement
{
    public partial class JBusEventRegisterUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            //((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlOwner).PersonCode
            if (!IsPostBack)
            {
                LoadBusEvent();
                LoadBus();
                LoadtxtFaaliyat();
                LoadTarrifCode();
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(DateTime.Now);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(DateTime.Now);
                _SetForm();
            }


        }


        public void LoadTarrifCheckBoxList(int BusNumber = 0, int DriverCode = 0, DateTime? StartDate = null, DateTime? EndDate = null)
        {
            //            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select a.Code,N'کد تعرفه '+cast(a.Code as nvarchar)+N' خط '+cast(al.LineNumber as nvarchar)+N' اتوبوس '+cast(ab.BUSNumber as nvarchar)
            //                                                                        +N' راننده '+cap.Name+N' تاریخ '+dbo.DateEnToFa(a.Date)Name from AUTTariff a
            //                                                                        left join AUTLine al on al.Code = a.LineCode
            //                                                                        left join AUTBus ab on ab.Code = a.BusCode
            //                                                                        left join clsAllPerson cap on cap.Code = a.DriverCode
            //                                                                        where a.BusCode is not null
            //                                                                        order by a.Code");
            //            cmbTarrif.DataSource = Dt;
            //            cmbTarrif.DataTextField = "Name";
            //            cmbTarrif.DataValueField = "Code";
            //            cmbTarrif.DataBind();
            string WhereStr = "";
            if (BusNumber > 0)
                WhereStr += " and  a.BusCode = " + BusNumber;
            if (DriverCode > 0)
                WhereStr += " and  a.DriverCode = " + DriverCode;
            if (StartDate.HasValue)
                WhereStr += " and  a.Date between '" + StartDate.Value.ToShortDateString() + " 00:00:00' and '" + EndDate.Value.ToShortDateString() + " 23:59:59' ";
            cmbTarrif.DataSource = WebClassLibrary.JWebDataBase.GetDataTable(@"select a.Code,N'کد تعرفه '+cast(a.Code as nvarchar)+N' خط '+cast(al.LineNumber as nvarchar)+N' اتوبوس '+
                                                                                cast(ab.BUSNumber as nvarchar)
                                                                                +N' راننده '+cap.Name+N' تاریخ '+dbo.DateEnToFa(a.Date)Name from AUTTariff a
                                                                                left join AUTLine al on al.Code = a.LineCode
                                                                                left join AUTBus ab on ab.Code = a.BusCode
                                                                                left join clsAllPerson cap on cap.Code = a.DriverCode
                                                                                where a.BusCode is not null " + WhereStr + @"
                                                                                order by a.Code");
            cmbTarrif.DataTextField = "Name";
            cmbTarrif.DataValueField = "Code";
            cmbTarrif.DataBind();
        }

        public void LoadTarrifCode()
        {
            lstTarrif.DataSource = WebClassLibrary.JWebDataBase.GetDataTable(@"select a.Code,N'کد تعرفه '+cast(a.Code as nvarchar)+N' خط '+cast(al.LineNumber as nvarchar)+N' اتوبوس '+
                                                                                cast(ab.BUSNumber as nvarchar)
                                                                                +N' راننده '+cap.Name+N' تاریخ '+dbo.DateEnToFa(a.Date)Name from AUTTariff a
                                                                                left join AUTLine al on al.Code = a.LineCode
                                                                                left join AUTBus ab on ab.Code = a.BusCode
                                                                                left join clsAllPerson cap on cap.Code = a.DriverCode
                                                                                where a.BusCode is not null and a.code in (select tarrifCode from AUTBusEventRegisterTarrifCode where BusEventRegisterCode = " + Code + @")
                                                                                order by a.Code");
            lstTarrif.DataTextField = "Name";
            lstTarrif.DataValueField = "Code";
            lstTarrif.DataBind();
        }

        public void LoadBusEvent()
        {
            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable("SELECT [Code],[Name] FROM [dbo].[AUTBusEventDetailes] order by [Code]");
            cmbBusEvent.DataSource = dt;
            cmbBusEvent.DataTextField = "Name";
            cmbBusEvent.DataValueField = "Code";
            cmbBusEvent.DataBind();
        }

        public void LoadBus()
        {
            DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
            cmbBus.DataSource = dt;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }


        public void LoadtxtFaaliyat()
        {
            DataTable DttxtDriverWorkStatus = new DataTable();
            DttxtDriverWorkStatus = WebClassLibrary.JWebDataBase.GetDataTable(@"select 0 Code , N'-' Name Union ALL select Code,Name from subdefine where bcode = 9101054");
            cmdStateTarrif.DataSource = DttxtDriverWorkStatus;
            cmdStateTarrif.DataTextField = "Name";
            cmdStateTarrif.DataValueField = "Code";
            cmdStateTarrif.DataBind();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                BusManagment.BusEvent.JBusEventRegister Event = new BusManagment.BusEvent.JBusEventRegister();
                Event.GetData(Code);
                cmbBus.SelectedValue = Event.BusCode.ToString();
                ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlDriver).PersonCode = Event.DriverPCode;
                cmbBusEvent.SelectedValue = Event.BusEventDetailesCode.ToString();
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).SetDate(Event.StartDate);
                ((WebControllers.MainControls.Date.JDateControl)txtToDate).SetDate(Event.EndDate);
                txtStartTimeHour.Text = Event.StartTime.Split(new string[] {":"},StringSplitOptions.None)[0];
                txtStartTimeMinute.Text = Event.StartTime.Split(new string[] { ":" }, StringSplitOptions.None)[1];
                txtFinishTimeHour.Text = Event.EndTime.Split(new string[] { ":" }, StringSplitOptions.None)[0];
                txtFinishTimeMinute.Text = Event.EndTime.Split(new string[] { ":" }, StringSplitOptions.None)[1];
                cmbStatus.SelectedValue = Event.Status.ToString();

                LoadTarrifCheckBoxList(Convert.ToInt32(cmbBus.SelectedValue), Convert.ToInt32(((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlDriver).PersonCode),
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(), ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());

            }
        }

        public bool Save()
        {
            BusManagment.BusEvent.JBusEventRegister Event = new BusManagment.BusEvent.JBusEventRegister();
            Event.Code = Code;
            Event.BusCode = Convert.ToInt32(cmbBus.SelectedValue);
            Event.DriverPCode = ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlDriver).PersonCode;
            Event.BusEventDetailesCode = Convert.ToInt32(cmbBusEvent.SelectedValue);
            Event.StartDate = ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate();
            Event.EndDate = ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate();
            Event.StartTime = txtStartTimeHour.Text + ":" + txtStartTimeMinute.Text + ":00";
            Event.EndTime = txtFinishTimeHour.Text + ":" + txtFinishTimeMinute.Text + ":00";
            Event.Status = Convert.ToInt32(cmbStatus.SelectedValue);
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            Db.setQuery(@"delete from [AUTBusEventRegisterTarrifCode] where BusEventRegisterCode = " + Code);
            try 
            {
                if (Code > 0)
                {
                    if (Event.Update())
                        if (Db.Query_Execute() >= 0)
                        {
                            for (int i = 0; i < lstTarrif.Items.Count; i++)
                            {
                                Db.setQuery(@"
                                        declare @tarif_code int = " + lstTarrif.Items[i].Value.ToString() + @"
                                        INSERT INTO [dbo].[AUTBusEventRegisterTarrifCode]
                                                   ([BusEventRegisterCode]
                                                   ,[TarrifCode])
                                             VALUES
                                                   (
                                                   " + Code + @"
                                                   ,@tarif_code)
                                        if((select status from AUTTariff where code = @tarif_code) = 1)
                                        begin
                                            exec [dbo].[SP_TarrifeTaeeidByTarrifCode] @tarif_code = @tarif_code
                                        end");
                                Db.Query_Execute();
                                if (cmdStateTarrif.SelectedItem != null && cmdStateTarrif.SelectedItem.Value != "0")
                                {
                                    Db.setQuery("update AUTTariff set FaliyatCode = " + cmdStateTarrif.SelectedItem.Value + " where code = " + lstTarrif.Items[i].Value.ToString());
                                    Db.Query_Execute();
                                }
                            }
                            return true;
                        }
                        else
                            return false;
                }
                else
                {
                    Code = Event.Insert(Db);
                    if (Code > 0)
                    {
                        //Db.setQuery("select isnull(max(code),0) from AUTBusEventRegister");
                        //DataTable MCodeDt = Db.Query_DataTable();
                        for (int i = 0; i < lstTarrif.Items.Count; i++)
                        {
                            Db.setQuery(@"
                                        declare @tarif_code int = " + lstTarrif.Items[i].Value.ToString() + @"
                                        INSERT INTO [dbo].[AUTBusEventRegisterTarrifCode]
                                                   ([BusEventRegisterCode]
                                                   ,[TarrifCode])
                                             VALUES
                                                   (" + Code + @"
                                                   ,@tarif_code)
                                        if((select status from AUTTariff where code = @tarif_code) = 1)
                                        begin
                                            exec [dbo].[SP_TarrifeTaeeidByTarrifCode] @tarif_code = @tarif_code
                                        end");
                            Db.Query_Execute();
                            if (cmdStateTarrif.SelectedItem != null && cmdStateTarrif.SelectedItem.Value != "0")
                            {
                                Db.setQuery("update AUTTariff set FaliyatCode = " + cmdStateTarrif.SelectedItem.Value + " where code = " + lstTarrif.Items[i].Value.ToString());
                                Db.Query_Execute();
                            }
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }// ? true : false;
                }
            }
            finally 
            {
                Db.Dispose();
            }
            return false;
 
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.RunClientScript("alert('ثبت با موفقیت انجام شد');", "ConfirmDialog");

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BusManagment.BusEvent.JBusEventRegister Event = new BusManagment.BusEvent.JBusEventRegister();
            Event.Code = Code;
            if (Event.Delete())
            {
                ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
                Db.setQuery(@"
                    declare @t table(TarifCode int)
					declare @tarif_code int 
                    delete from AUTBusEventRegisterTarrifCode output deleted.TarrifCode into @t where BusEventRegisterCode = " + Code + @"
					set @tarif_code = (select top 1 TarifCode from @t)
                    if((select status from AUTTariff where code = @tarif_code) = 1)
                    begin
                        exec [dbo].[SP_TarrifeTaeeidByTarrifCode] @tarif_code = @tarif_code
                    end");
                if (Db.Query_Execute() >= 0)
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('واقعه با موفقیت حذف شد');", "ConfirmDialog");
                }
            }
        }

        protected void BtnInsertTarrif_Click(object sender, EventArgs e)
        {
            RadListBoxItem NewItem = new RadListBoxItem();
            NewItem.Value = cmbTarrif.SelectedValue;
            NewItem.Text = cmbTarrif.SelectedItem.Text;
            lstTarrif.Items.Add(NewItem);
        }

        protected void btnLoadTarrif_Click(object sender, EventArgs e)
        {
            LoadTarrifCheckBoxList(Convert.ToInt32(cmbBus.SelectedValue), Convert.ToInt32(((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControlDriver).PersonCode),
                ((WebControllers.MainControls.Date.JDateControl)txtFromDate).GetDate(), ((WebControllers.MainControls.Date.JDateControl)txtToDate).GetDate());
        }
    }
}