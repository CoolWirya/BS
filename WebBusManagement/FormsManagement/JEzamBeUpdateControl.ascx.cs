using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsManagement
{
    public partial class JEzamBeUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            if (!IsPostBack)
            {
                LoadLine();
                LoadBus();
                LoadtxtEzamBe();
                _SetForm();
            }
            else
                LoadEzamBeGrid();
        }

        public void LoadtxtEzamBe()
        {
            DataTable DttxtEzamBe = new DataTable();
            DttxtEzamBe = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Name from subdefine where bcode = 9101058");
            var p = (from v in DttxtEzamBe.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, Name = "هیچکدام" });
            cmbEzamBe.DataSource = p;
            cmbEzamBe.DataTextField = "Name";
            cmbEzamBe.DataValueField = "Code";
            cmbEzamBe.DataBind();
        }

        public void LoadLine()
        {
            DataTable DtLine = new DataTable();
            DtLine = BusManagment.Line.JLines.GetWebDataTable(0);
            var p = (from v in DtLine.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), lineName = v["lineName"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, lineName = "هیچکدام" });
            cmbLine.DataSource = p;
            cmbLine.DataTextField = "lineName";
            cmbLine.DataValueField = "Code";
            cmbLine.DataBind();
        }

        public void LoadBus()
        {
            DataTable DtBus = new DataTable();
            DtBus = BusManagment.Bus.JBuses.GetAllBusesOnly();
            var p = (from v in DtBus.AsEnumerable()
                     select new { Code = Convert.ToInt32(v["Code"]), BUSNumber = v["BUSNumber"].ToString() }).ToList();
            p.Insert(0, new { Code = 0, BUSNumber = "ندارد" });
            cmbBus.DataSource = p;
            cmbBus.DataTextField = "BUSNumber";
            cmbBus.DataValueField = "Code";
            cmbBus.DataBind();
        }

        public void _SetForm()
        {
            DataTable DtAllPerson = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code, clsAllPerson.Name from clsAllPerson");
            //cmbDriversName.DataSource = DtAllPerson;
            //cmbDriversName.DataTextField = "Name";
            //cmbDriversName.DataValueField = "Code";
            //cmbDriversName.DataBind();

            if (Code > 0)
            {
                ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                DB.setQuery("select DriverCode from AUTTariff where Code=" + Code);
                int pCode = 0;
                try { pCode = Convert.ToInt32(DB.Query_DataTable().Rows[0][0].ToString()); }
                catch { }
                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControl1).Code = pCode;
                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControl1).SQL = "select cap.Code,cast(isnull(EmpEmployee.PersonNumber,0) as nvarchar)+' - '+cap.Name Title from clsAllPerson cap left join EmpEmployee on cap.Code = EmpEmployee.pCode";
                txtTariffCode.Text = Code.ToString();
                DataTable DtEzamBe = WebClassLibrary.JWebDataBase.GetDataTable(@"select dbo.DateEnToFa(th.Date)Date,cap.Name,ath.LineCode, th.DriverCode from AUTTariff th
                                                                                                left join clsAllPerson cap on cap.Code = th.DriverCode 
                                                                                                left join AutTarrifHokmeKar ath on ath.DriverPCode = th.DriverCode
                                                                                                where th.code =" + Code);
                if (DtEzamBe != null && DtEzamBe.Rows.Count > 0)
                {
                    txtDate.Text = DtEzamBe.Rows[0]["Date"].ToString();
                    cmbLine.SelectedValue = DtEzamBe.Rows[0]["LineCode"].ToString();
                }
                LoadEzamBeGrid();
            }
        }

        public void LoadEzamBeGrid()
        {
            //           WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusReports_JBusReports");
            //            jGridView.ClassName = "WebBusReports_JBusReports_GetReport";
            //            jGridView.SQL = @"select a.Code,a.TarrifCode,al.LineNumber,s.name EzamBe,a.BusNumberBeJa,a.StartTime,a.FinishTime from AutTarrifEzamBe a
            //                                    left join autline al on al.Code = a.LineCode
            //                                    left join subdefine s on s.Code = a.EzamBe
            //                                    where a.TarrifCode = " + Code;
            //            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            //            jGridView.PageSize = 50;
            //            jGridView.HiddenColumns = "Code";
            //            jGridView.Title = "JEzamBeUpdateControl";
            //            jGridView.Buttons = "excel,print,record_print";
            //            //jGridView.SumFields = new Dictionary<string, double>();
            //            //jGridView.SumFields.Add("TransactionCount", 0);
            //            //jGridView.SumFields.Add("InCome", 0);
            //            
            //            


            //            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select a.Code N'کد',a.TarrifCode N'کد تعرفه',al.LineNumber N'شماره مسیر',s.name N'اعزام به',
            //                                                                        ab.BusNumber N'اتوبوس به جا',a.NumOfSevice N'تعداد سرویس',a.StartTime N'ساعت شروع',a.FinishTime N'ساعت پایان',
            //																		case a.IsOk when 0 then N'تایید نشده' else N'تایید شده' end as N'وضعیت',cap.Name N'راننده' from AutTarrifEzamBe a
            //                                                                        left join autline al on al.Code = a.LineCode
            //                                                                        left join subdefine s on s.Code = a.EzamBe
            //																		left join AUTBus ab on ab.Code = a.BusNumberBeJa
            //                                                                        left join clsAllPerson cap on cap.Code = a.DriverPCode
            //                                                                           where a.TarrifCode = " + Code);

            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code N'کد',TarrifCode N'کد تعرفه',LineNumber N'شماره مسیر',name N'اعزام به',
                                                                        BusNumber N'اتوبوس به جا',NumOfSevice N'تعداد سرویس',
                                                                        StartTime N'ساعت شروع',
                                                                        FinishTime N'ساعت پایان',
                                                                        case IsOk when 0 then N'تایید نشده' else N'تایید شده' end as N'وضعیت',driverName N'راننده'
                                                                        ,case IsService when 0 then N'خیر' else N'بلی' end as N'سرویس'
                                                                        from
                                                                        (
	                                                                        SELECT teb.Code,teb.TarrifCode,l.LineNumber,sd.name,bus.BUSNumber,teb.NumOfSevice, cast(teb.StartTime as time)StartTime, cast(teb.FinishTime as time)FinishTime,teb.IsOk,cap.Name driverName,0 IsService FROM AutTarrifEzamBe teb 
		                                                                    LEFT JOIN AUTLine l ON l.code = teb.LineCode
                                                                            LEFT JOIN AUTBus bus ON bus.Code = teb.BusCodeBeJa
		                                                                    LEFT JOIN subdefine sd ON sd.Code = teb.EzamBe
		                                                                    LEFT JOIN clsAllPerson cap ON cap.Code = teb.DriverPCode
	                                                                        WHERE teb.TarrifCode = " + Code + @"
                                                                        )T");
            RadGridReport.DataSource = Dt;
            RadGridReport.DataBind();
        }

        public bool Save()
        {
            //BusManagment.WorkOrder.JHokmeKar HokmeKar = new BusManagment.WorkOrder.JHokmeKar();
            //HokmeKar.Code = Code;
            return true;
            //  if (Code > 0)
            // return HokmeKar.Update(true);
            //  else
            //return HokmeKar.Insert(true) > 0 ? true : false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                ClearForm();
                WebClassLibrary.JWebManager.RunClientScript("alert('تغییرات با موفقیت ثبت شد');", "ConfirmDialog");
                //WebClassLibrary.JWebManager.CloseAndRefresh();
            }
            else
                WebClassLibrary.JWebManager.RunClientScript("alert('خطا در انجام عملیات');", "ConfirmDialog");
        }

        protected void BtnSaveAndLoadGrid_Click(object sender, EventArgs e)
        {
            DateTime StartTime = new DateTime(), FinishTime = new DateTime();
            try
            {
                StartTime = Convert.ToDateTime(ClassLibrary.JDateTime.GregorianDate(txtDate.Text, txtStartTimeHour.Text + ":" + txtStartTimeMinute.Text + ":00"));
            }
            catch
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('ساعت شروع قابل قبول نیست');", "ConfirmDialog");
                return;
            }
            try
            {
                FinishTime = Convert.ToDateTime(ClassLibrary.JDateTime.GregorianDate(txtDate.Text, txtFinishTimeHour.Text + ":" + txtFinishTimeMinute.Text + ":00"));
            }
            catch
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('ساعت پایان قابل قبول نیست');", "ConfirmDialog");
                return;
            }
            BusManagment.WorkOrder.JTariff tarif = new BusManagment.WorkOrder.JTariff();
            if (!tarif.GetData(Code))
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('خطا در انجام عملیات');", "ConfirmDialog");
                return;
            }
            BusManagment.Shift.JShift shift = new BusManagment.Shift.JShift();
            if (!shift.GetData(tarif.ShiftCode))
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('خطا در انجام عملیات');", "ConfirmDialog");
                return;
            }
            if (StartTime < new DateTime(tarif.Date.Year, tarif.Date.Month, tarif.Date.Day, shift.StartTime.Hours, shift.StartTime.Minutes, shift.StartTime.Seconds)
                | StartTime > new DateTime(tarif.Date.Year, tarif.Date.Month, tarif.Date.Day, shift.EndTime.Hours, shift.EndTime.Minutes, shift.EndTime.Seconds))
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('ساعت شروع به کار  خارج از شیفت کاری قرار دارد');", "ConfirmDialog");
                return;
            }
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            //DB.setQuery("select Code from AutTarrifHokmeKar where DriverPCode =" + cmbDriversName.SelectedValue);
            //int SelectedCode = Convert.ToInt32(DB.Query_DataTable().Rows[0][0].ToString());
            BusManagment.WorkOrder.JEzamBe EzamBe = new BusManagment.WorkOrder.JEzamBe();
            EzamBe.TarrifCode = Convert.ToInt32(txtTariffCode.Text);
            EzamBe.LineCode = Convert.ToInt32(cmbLine.SelectedValue);
            EzamBe.EzamBe = Convert.ToInt32(cmbEzamBe.SelectedValue);
            EzamBe.BusCodeBeJa = Convert.ToInt32(cmbBus.SelectedValue);
            EzamBe.DriverPCode = ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControl1).Code;
            try
            {
                EzamBe.NumOfSevice = Convert.ToInt32(txtNumOfService.Text);
            }
            catch
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('تعداد سرویس قابل قبول نیست');", "ConfirmDialog");
                return;
            }
                EzamBe.StartTime = StartTime;
                EzamBe.FinishTime = FinishTime;
            //EzamBe.Code = Convert.ToInt32(SelectedCode);
            //bool IsService = Convert.ToBoolean(hidIsService.Value);
            int ezamBeCode = 0;
            int.TryParse(hidEditCode.Value, out ezamBeCode);
            EzamBe.Code = ezamBeCode;
//            if (IsService)
//            {
//                DB.setQuery(@"declare @ezambe_code as int = isnull((select max(code) from AutTarrifEzamBe), 0) + 1
//                            INSERT INTO AutTarrifEzamBe 
//                            SELECT @ezambe_code, t.Code,bs.DriverPersonCode,l.Code,'-',0,1,bs.FirstStationCode,bs.LastStationCode,bs.FirstStationDate, bs.LastStationDate,1,GETDATE() FROM AutBusServices bs
//		                        INNER JOIN AUTBus b ON b.BUSNumber = bs.BusNumber
//		                        INNER JOIN AUTLine l ON l.LineNumber = b.LastLineNumber
//		                        INNER JOIN AUTTariff t on t.BusCode = b.Code AND bs.Date = CAST(t.Date AS DATE) AND CAST(bs.FirstStationDate AS TIME) BETWEEN t.StartTime AND t.EndTime
//		                        LEFT JOIN clsAllPerson cap ON cap.Code = t.DriverCode
//	                        WHERE t.Code = " + Code + " AND bs.Code = " + ezamBeCode + @" AND bs.FirstStationDate BETWEEN t.Date + t.StartTime AND t.Date + t.EndTime
//                            AND NOT EXISTS(SELECT * FROM AutTarrifEzamBe WHERE TarrifCode = t.Code AND LineCode = l.Code ANd FirstStationCode = bs.FirstStationCode AND LastStationCode = bs.LastStationCode
//                            AND StartTime = bs.FirstStationDate and FinishTime = bs.LastStationDate and IsOk = 1)
//                            UPDATE AutBusServices bs set EzamBeCode = " + ezamBeCode + @" WHERE code = " + hidEditCode.Value + @"
//                ");
//                if (DB.Query_Execute() >= 0)
//                {
//                    ClearForm();
//                    LoadEzamBeGrid();
//                }
//            }
//            else
//            {
                if (ezamBeCode <= 0)
                {
                    ezamBeCode = EzamBe.Insert(true);
                    if (ezamBeCode > 0)
                    {
                        ClearForm();
                        LoadEzamBeGrid();
                        WebClassLibrary.JWebManager.RunClientScript("alert('تغییرات با موفقیت ثبت شد');", "ConfirmDialog");
                    }
                    else
                        WebClassLibrary.JWebManager.RunClientScript("alert('خطا در انجام عملیات');", "ConfirmDialog");
                }
                else
                {
                    if (EzamBe.Update(true))
                    {
                        ClearForm();
                        LoadEzamBeGrid();
                        WebClassLibrary.JWebManager.RunClientScript("alert('تغییرات با موفقیت ثبت شد');", "ConfirmDialog");
                    }
                    else
                        WebClassLibrary.JWebManager.RunClientScript("alert('خطا در انجام عملیات');", "ConfirmDialog");
                }
            //}
        }

        void ClearForm()
        {
            hidEditCode.Value = "0";
            cmbBus.SelectedIndex = 0;
            cmbEzamBe.SelectedIndex = 0;
            cmbLine.SelectedIndex = 0;
            //hidIsService.Value = "False";
            txtNumOfService.Text = "";
            txtStartTimeHour.Text = "";
            txtStartTimeMinute.Text = "";
            txtFinishTimeHour.Text = "";
            txtFinishTimeMinute.Text = "";
            BtnDeleteEzamBe.Visible = false;
            BtnIsOk.Visible = false;
        }

        protected void RadGridReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BusManagment.WorkOrder.JEzamBe EzamBe = new BusManagment.WorkOrder.JEzamBe();
            //EzamBe.Code = Convert.ToInt32(RadGridReport.SelectedRow.Cells[1].Text.ToString());
            //if(EzamBe.Delete())
            //{
            //    LoadEzamBeGrid();
            //}
            hidEditCode.Value = RadGridReport.SelectedRow.Cells[1].Text.ToString();
            //Control control = RadGridReport.SelectedRow.FindControl("IsServiceLabel");
            //if (control != null)
            //    hidIsService.Value = (control as Label).Text;
            try
            {
                cmbLine.SelectedValue = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code from AutLine where LineNumber = " + RadGridReport.SelectedRow.Cells[3].Text.ToString()).Rows[0][0].ToString();
            }
            catch 
            {
                cmbLine.SelectedValue = "0";
            }
            try
            {
                cmbEzamBe.SelectedValue = cmbEzamBe.Items.FindItemByText(RadGridReport.SelectedRow.Cells[4].Text.ToString()).Value;
            }
            catch
            {
                cmbEzamBe.SelectedValue = "0";
            }
            try
            {
                cmbBus.SelectedValue = cmbBus.Items.FindItemByText(RadGridReport.SelectedRow.Cells[5].Text.ToString()).Value;
            }
            catch 
            {
                cmbBus.SelectedValue = "0";
            }
            txtNumOfService.Text = RadGridReport.SelectedRow.Cells[6].Text.ToString();
            try
            {
                txtStartTimeHour.Text = RadGridReport.SelectedRow.Cells[7].Text.ToString().Split(':')[0];
                    //.Substring(RadGridReport.SelectedRow.Cells[7].Text.ToString().Split(':')[0].Length - 3, RadGridReport.SelectedRow.Cells[7].Text.ToString().Split(':')[0].Length - 1);
                txtStartTimeMinute.Text = RadGridReport.SelectedRow.Cells[7].Text.ToString().Split(':')[1];
                txtFinishTimeHour.Text = RadGridReport.SelectedRow.Cells[8].Text.ToString().Split(':')[0];
                    //.Substring(RadGridReport.SelectedRow.Cells[7].Text.ToString().Split(':')[0].Length - 3, RadGridReport.SelectedRow.Cells[7].Text.ToString().Split(':')[0].Length - 1);
                txtFinishTimeMinute.Text = RadGridReport.SelectedRow.Cells[8].Text.ToString().Split(':')[1];
            }
            catch { }
            BtnDeleteEzamBe.Visible = true;
            BtnIsOk.Visible = true;
            //EzamBe.StartTime = Convert.ToDateTime(ClassLibrary.JDateTime.GregorianDate(txtDate.Text, txtStartTimeHour.Text + ":" + txtStartTimeMinute.Text + ":00"));
            //EzamBe.FinishTime = Convert.ToDateTime(ClassLibrary.JDateTime.GregorianDate(txtDate.Text, txtFinishTimeHour.Text + ":" + txtFinishTimeMinute.Text + ":00"));
        }

        protected void BtnDeleteEzamBe_Click(object sender, EventArgs e)
        {
            BusManagment.WorkOrder.JEzamBe EzamBe = new BusManagment.WorkOrder.JEzamBe();
            EzamBe.GetData(Convert.ToInt32(RadGridReport.SelectedRow.Cells[1].Text.ToString()));
            if (EzamBe.Delete())
            {
                ClearForm();
                LoadEzamBeGrid();
                WebClassLibrary.JWebManager.RunClientScript("alert('عملیات حذف با موفقیت انجام شد');", "ConfirmDialog");
            }
            else
                WebClassLibrary.JWebManager.RunClientScript("alert('خطا در انجام عملیات');", "ConfirmDialog");
        }

        protected void BtnIsOk_Click(object sender, EventArgs e)
        {
            int EzamBeCode = Convert.ToInt32(hidEditCode.Value);
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select IsOk from AutTarrifEzamBe where Code = " + EzamBeCode);
            if (Dt.Rows[0]["IsOk"].ToString() == "0")
            {
                if(BusManagment.WorkOrder.JEzamBe.Approve(EzamBeCode))
                {
                    ClearForm();
                    LoadEzamBeGrid();
                    WebClassLibrary.JWebManager.RunClientScript("alert('تغییرات با موفقیت ثبت شد');", "ConfirmDialog");
                }
                else
                    WebClassLibrary.JWebManager.RunClientScript("alert('خطا در انجام عملیات');", "ConfirmDialog");

            }
            else
            {
                if (BusManagment.WorkOrder.JEzamBe.Disapprove(EzamBeCode))
                {
                    ClearForm();
                    LoadEzamBeGrid();
                    WebClassLibrary.JWebManager.RunClientScript("alert('تغییرات با موفقیت ثبت شد');", "ConfirmDialog");
                }
                else
                    WebClassLibrary.JWebManager.RunClientScript("alert('خطا در انجام عملیات');", "ConfirmDialog");
            }
        }

        protected void RadGridReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            if (e.Row.Cells[7].Text.Contains("&gt;"))
                e.Row.Cells[7].Text = e.Row.Cells[7].Text.Substring(e.Row.Cells[7].Text.IndexOf("&gt;") + 4);
            if (e.Row.Cells[8].Text.Contains("&gt;"))
                e.Row.Cells[8].Text = e.Row.Cells[8].Text.Substring(e.Row.Cells[8].Text.IndexOf("&gt;") + 4);
            TableCell cell = new TableCell();
            cell.Controls.Add(new Label() { ID = "IsServiceLabel", Text = e.Row.Cells[11].Text == "خیر" ? "False" : "True", Visible = false });
            cell.Visible = false;
            e.Row.Cells.Add(cell);
        }

        //protected void RadGridReport_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        //{
        //    if (e.Item is GridDataItem)
        //    {
        //        GridDataItem item = e.Item as GridDataItem;
        //        item["XmlColumn1"].Text = Server.HtmlEncode(item["XmlColumn1"].Text);
        //        item["XmlColumn2"].Text = Server.HtmlEncode(item["XmlColumn2"].Text);
        //    }

        //}

    }
}