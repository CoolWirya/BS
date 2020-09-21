using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JBusEventUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            _SetForm();
        }


        public void _SetForm()
        {
            if (Code > 0)
            {
                BusManagment.BusEvent.JBusEvent Event = new BusManagment.BusEvent.JBusEvent();
                Event.GetData(Code);
                txtTitle.Text = Event.Name;
                cmbBusActive.SelectedValue = Event.BusActive.ToString();
                cmbDriverActive.SelectedValue = Event.DriverActive.ToString();
            }
        }

        public bool Save()
        {
            BusManagment.BusEvent.JBusEvent Event = new BusManagment.BusEvent.JBusEvent();
            Event.Code = Code;
            Event.Name = txtTitle.Text;
            Event.BusActive = Convert.ToInt32(cmbBusActive.SelectedValue);
            Event.DriverActive = Convert.ToInt32(cmbDriverActive.SelectedValue);

            BusManagment.Query.JQueryAutoAuto QueryAuto = new BusManagment.Query.JQueryAutoAuto();

            int RetCode = 0;

            if (Code > 0)
            {
                RetCode = Code;
                QueryAuto.Name = "Update Event";
                QueryAuto.QueryText = @"update events set 'name' = '" + txtTitle.Text + @"' where ""code"" = " + RetCode.ToString();
                QueryAuto.DataBaseName = "Local_Bus_Sqlite";
                QueryAuto.Insert();
                return Event.Update();
            }
            else
            {
                RetCode = Event.Insert();
                QueryAuto.Name = "Insert Event";
                QueryAuto.QueryText = @"insert into events('code','name') values(" + RetCode.ToString() + @",'" + txtTitle.Text + @"')";
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
            BusManagment.BusEvent.JBusEvent Event = new BusManagment.BusEvent.JBusEvent();
            Event.Code = Code;
            if (Event.Delete())
            {
                QueryAuto.Name = "Delete Event";
                QueryAuto.QueryText = @"delete from events where ""code"" = " + Code;
                QueryAuto.DataBaseName = "Local_Bus_Sqlite";
                QueryAuto.Insert();
                WebClassLibrary.JWebManager.RunClientScript("alert('واقعه با موفقیت حذف شد');", "ConfirmDialog");
            }

        }
    }
}