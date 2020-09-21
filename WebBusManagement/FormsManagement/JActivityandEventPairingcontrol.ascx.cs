using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ClassLibrary;


namespace WebBusManagement.FormsManagement
{
    public partial class JActivityandEventPairingControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadBusEvent();
            LoadtxtActivity();

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
        public void LoadtxtActivity()
        {
            DataTable DttxtActivity = new DataTable();
            DttxtActivity = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code,Name from subdefine where bcode = 9101054");
            cmbActivity.DataSource = DttxtActivity;
            cmbActivity.DataTextField = "Name";
            cmbActivity.DataValueField = "Code";
            cmbActivity.DataBind();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                BusManagment.BusEvent.JEventActivity EventActivity = new BusManagment.BusEvent.JEventActivity();
                EventActivity.GetData(Code);
                cmbBusEvent.SelectedValue = EventActivity.Event.ToString();
                cmbActivity.SelectedValue = EventActivity.activity.ToString();
            }
        }
        private bool Find(string eventcode)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = "select event from AUTBusEventActivity where " + eventcode;
                Db.setQuery(Query);
                Db.Query_DataReader();
                if (Db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, Db.DataReader);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                Db.Dispose();
            }
        }
        public bool Save()
        {
            BusManagment.BusEvent.JEventActivity EventActivity = new BusManagment.BusEvent.JEventActivity();
            EventActivity.Code = Code;
            EventActivity.Event = Convert.ToInt32(cmbBusEvent.SelectedValue);
            EventActivity.activity = Convert.ToInt32(cmbActivity.SelectedValue);

            BusManagment.Query.JQueryAutoAuto QueryAuto = new BusManagment.Query.JQueryAutoAuto();

            int RetCode = 0;


            if (Code > 0)
            {
                RetCode = Code;
                QueryAuto.Name = "Update AUTBusEventActivity ";
                QueryAuto.QueryText = @"update AUTBusEventActivity set 'Priority'=0 and 'Event' = " + cmbBusEvent.SelectedValue + "and 'activity'=" + cmbActivity.SelectedValue + @" where ""Code"" = " + RetCode.ToString();
                QueryAuto.DataBaseName = "Local_Bus_Sqlite";
                QueryAuto.Insert();
                return EventActivity.Update();

            }
            else
            {
                if ((Find("Event=" + EventActivity.Event)))
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('این واقعه قبلا ثبت شده و تکراری است');", "ConfirmDialog");
                    return false;
                }
                else
                {
                    RetCode = EventActivity.Insert();
                    QueryAuto.Name = "Insert AUTBusEventActivity ";
                    QueryAuto.QueryText = @"insert into AUTBusEventActivity('Code','Event','activity','Priority') values(" + RetCode.ToString() + @"," + cmbBusEvent.SelectedValue + @"," + cmbActivity.SelectedValue + @")";
                    QueryAuto.DataBaseName = "Local_Bus_Sqlite";
                    QueryAuto.Insert();


                    if (RetCode > 0)
                        return true;
                    else
                        return false;
                }
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
            BusManagment.BusEvent.JEventActivity EventActivity = new BusManagment.BusEvent.JEventActivity();
            EventActivity.Code = Code;
            if (Code > 10000)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('امکان حذف این واقعه وجود ندارد');", "ConfirmDialog");
                return;
            }
            if (EventActivity.Delete())
            {
                QueryAuto.Name = "Delete AUTBusEventActivity ";
                QueryAuto.QueryText = @"delete from AUTBusEventActivity where ""Code"" = " + Code;
                QueryAuto.DataBaseName = "Local_Bus_Sqlite";
                QueryAuto.Insert();
                WebClassLibrary.JWebManager.RunClientScript("alert('جزئیات واقعه با موفقیت حذف شد');", "ConfirmDialog");
            }
        }
    }
}