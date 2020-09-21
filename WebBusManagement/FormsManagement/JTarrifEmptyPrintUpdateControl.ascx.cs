using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsManagement
{
    public partial class JTarrifEmptyPrintUpdateControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadShift();
            LoadZones();
            LoadTariifNum();
            if (!IsPostBack)
            {
                ((WebControllers.MainControls.Date.JDateControl)txtDate).SetDate(DateTime.Now);
            }
        }

        public void LoadTariifNum()
        {
            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"Select Count(*)C from AutTarrifHokmeKar");
            txtNumOfEmptyTarrif.Text = Dt.Rows[0]["C"].ToString();
        }

        public void LoadZones()
        {
            DataTable dt = BusManagment.Zone.JZones.GetDataTable(0);
            //var p = (from v in dt.AsEnumerable()
            //         select new { Code = Convert.ToInt32(v["Code"]), Name = v["Name"].ToString() }).ToList();
            //p.Insert(0, new { Code = 0, Name = "همه" });
            cmbZone.DataSource = dt;
            cmbZone.DataTextField = "Name";
            cmbZone.DataValueField = "Code";
            cmbZone.DataBind();
        }

        public void LoadShift()
        {
            DataTable DtShift = new DataTable();
            DtShift = BusManagment.WorkOrder.JShifts.GetDataTable(0);
            cmbShift.DataSource = DtShift;
            cmbShift.DataTextField = "Title";
            cmbShift.DataValueField = "Code";
            cmbShift.DataBind();
        }

        public bool Save(DateTime date, int Shift, int Zone)
        {
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            Db.setQuery(@"INSERT INTO [dbo].[AUTTariff]
                               ([Code]
                               ,[LineCode]
                               ,[NumOfService]
                               ,[BusCode]
                               ,[DriverCode]
                               ,[DriverWorkType]
                               ,[DriverWorkStatus]
                               ,[Date]
                               ,[StartTime]
                               ,[EndTime]
                               ,[ShiftCode]
                               ,[FaliyatCode]
                               ,[OnvaneShoghliCode]
                               ,[GozareshCode]
                               ,[ZoneCode]
                               ,[Status])
                         VALUES
                               (ISNULL((select max(code)+1 from AUTTariff),1)
                               ,null
                               ,null
                               ,null
                               ,null
                               ,null
                               ,null
                               ,'" + date.ToShortDateString() + @" 00:00:00'
                               ,'00:00:00'
                               ,'23:59:59'
                               ," + cmbShift.SelectedValue + @"
                               ,null
                               ,null
                               ,null
                               ," + cmbZone.SelectedValue + @"
                               ,0)");
            if (Db.Query_Execute() >= 0)
                return true;
            else
                return false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtNumOfEmptyTarrif.Text == "" || txtNumOfEmptyTarrif.Text == null)
                txtNumOfEmptyTarrif.Text = "0";

            for (int i = 0; i < Convert.ToInt32(txtNumOfEmptyTarrif.Text); i++)
            {
                Save(((WebControllers.MainControls.Date.JDateControl)txtDate).GetDate(), Convert.ToInt32(cmbShift.SelectedValue), Convert.ToInt32(cmbZone.SelectedValue));
            }

            WebClassLibrary.JWebManager.RunClientScript("alert('با موفقیت ثبت شد');", "OKDialog");
            WebClassLibrary.JWebManager.CloseAndRefresh();
        }
    }
}