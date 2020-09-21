using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsManagement
{
    public partial class JBusEventDetailesUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            //sssss
            if (!IsPostBack)
                LoadBusEvent();
            int.TryParse(Request["Code"], out Code);
            _SetForm();
        }

        public void LoadBusEvent()
        {
            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable("SELECT [Code],[Name] FROM [dbo].[AUTBusEvent] order by [Code]");
            cmbBusEvent.DataSource = dt;
            cmbBusEvent.DataTextField = "Name";
            cmbBusEvent.DataValueField = "Code";
            cmbBusEvent.DataBind();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                BusManagment.BusEvent.JBusEventDetailes Event = new BusManagment.BusEvent.JBusEventDetailes();
                Event.GetData(Code);
                txtTitle.Text = Event.Name;
                cmbBusEvent.SelectedValue = Event.BusEventCode.ToString();
            }
        }

        public bool Save()
        {
            BusManagment.BusEvent.JBusEventDetailes Event = new BusManagment.BusEvent.JBusEventDetailes();
            Event.Code = Code;
            Event.Name = txtTitle.Text;
            Event.BusEventCode = Convert.ToInt32(cmbBusEvent.SelectedValue);

            BusManagment.Query.JQueryAutoAuto QueryAuto = new BusManagment.Query.JQueryAutoAuto();

            int RetCode = 0;

            if (Code > 0)
            {
                RetCode = Code;
                QueryAuto.Name = "Update Event Detailes";
                QueryAuto.QueryText = @"update eventdetails set 'name' = '" + txtTitle.Text + @"','eventcode' = " + cmbBusEvent.SelectedValue + @" where ""code"" = " + RetCode.ToString();
                QueryAuto.DataBaseName = "Local_Bus_Sqlite";
                QueryAuto.Insert();
                return Event.Update();
            }
            else
            {
                RetCode = Event.Insert();
                QueryAuto.Name = "Insert Event Detailes";
                QueryAuto.QueryText = @"insert into eventdetails('code','name','eventcode') values(" + RetCode.ToString() + @",'" + txtTitle.Text + @"'," + cmbBusEvent.SelectedValue + @")";
                QueryAuto.DataBaseName = "Local_Bus_Sqlite";
                QueryAuto.Insert();
                if (RetCode > 0)
                    return true;
                else
                    return false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.RunClientScript("alert('ثبت با موفقیت انجام شد');", "ConfirmDialog");

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BusManagment.Query.JQueryAutoAuto QueryAuto = new BusManagment.Query.JQueryAutoAuto();
            BusManagment.BusEvent.JBusEventDetailes Event = new BusManagment.BusEvent.JBusEventDetailes();
            Event.Code = Code;
            if (Code > 10000)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('امکان حذف این واقع وجود ندارد');", "ConfirmDialog");
                return;
            }
            if (Event.Delete())
            {
                QueryAuto.Name = "Delete Event Detailes";
                QueryAuto.QueryText = @"delete from buseventdetailes where ""code"" = " + Code;
                QueryAuto.DataBaseName = "Local_Bus_Sqlite";
                QueryAuto.Insert();
                WebClassLibrary.JWebManager.RunClientScript("alert('جزئیات واقعه با موفقیت حذف شد');", "ConfirmDialog");
            }
        }
    }
}