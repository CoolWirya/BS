using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAVL.Forms
{
    public partial class GoogleMapDirection : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "نقشه آفلاین";
           
            

        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (!Page.IsPostBack)
            {

                ((WebControllers.MainControls.Date.JDateControl)clrFromDate).Date = DateTime.Now.AddDays(-1);
                ((WebControllers.MainControls.Date.JDateControl)clrToDate).Date = DateTime.Now;
              //  txtFromHour.Text = DateTime.Now.AddHours(-1).Hour.ToString();
             //   txtFromMin.Text = DateTime.Now.AddHours(-1).Minute.ToString();
           //     txtToHour.Text = DateTime.Now.Hour.ToString();
           //     txtToMin.Text = DateTime.Now.Minute.ToString();

                ddlSpeed.Items.Add(new ListItem("آنی", "0"));
                ddlSpeed.Items.Add(new ListItem("خیلی زیاد", "100"));
                ddlSpeed.Items.Add(new ListItem(" زیاد", "300"));
                ddlSpeed.Items.Add(new ListItem("متوسط", "800"));
                ddlSpeed.Items.Add(new ListItem("کم", "1700"));
                ddlSpeed.Items.Add(new ListItem("خیلی کم", "3500"));
                ddlSpeed.SelectedIndex = 2;

               // MKB.TimePicker.TimeSelector.AmPmSpec pmam = MKB.TimePicker.TimeSelector.AmPmSpec.AM;
            //    pmam = (DateTime.Now.ToString("tt").ToUpper().Equals("PM")) ? MKB.TimePicker.TimeSelector.AmPmSpec.PM : MKB.TimePicker.TimeSelector.AmPmSpec.AM;
                TimeStart.Hour = DateTime.Now.AddHours(-1).Hour;//.SetTime(DateTime.Now.AddHours(-1).Hour, DateTime.Now.Minute, pmam);
                timeEnd.Hour = DateTime.Now.Hour; //.SetTime(DateTime.Now.Hour, DateTime.Now.Minute,  pmam);
                timeEnd.Minute= TimeStart.Minute = DateTime.Now.Minute;
            }
        }
        private void SetDirections(int lineCode)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                return;
            if (string.IsNullOrEmpty(((WebAVL.Controls.Search.JSearchDevice)searchDevice).IMEI))
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفا یک دستگاه را انتخاب نمایید.');", "ConfirmDialog");
                return;
            }
            Googlemap.Offline = true;
            Googlemap.Startdate = (((WebControllers.MainControls.Date.JDateControl)clrFromDate).Date.ToShortDateString() + " " + string.Format("{0}:{1}:{2} {3}", TimeStart.Hour, TimeStart.Minute, TimeStart.Second, TimeStart.AmPm));// txtFromHour.Text + ":" + txtFromMin.Text);
            Googlemap.EndDate = (((WebControllers.MainControls.Date.JDateControl)clrToDate).Date.ToShortDateString() + " " + string.Format("{0}:{1}:{2} {3}", timeEnd.Hour, timeEnd.Minute, timeEnd.Second, timeEnd.AmPm));// txtToHour.Text + ":" + txtToMin.Text);
           //Googlemap.DeviceCode = new AVL.RegisterDevice.JRegisterDevice(((WebAVL.Controls.Search.JSearchDevice)searchDevice).IMEI).Code;// dsDevices.Device.Code;// int.Parse(cmbObjectNumber.SelectedValue);
              Googlemap.DeviceCodes = ((WebAVL.Controls.Search.JSearchDevice)searchDevice).Codes;
            Googlemap.LinesColors = ((WebAVL.Controls.Search.JSearchDevice)searchDevice).Colors;
            Googlemap.Speed = int.Parse(ddlSpeed.SelectedValue);
            
            WebClassLibrary.JWebManager.RunClientScript("FuncOpenControlPanel();", "ConfirmDialog");
        }

        protected void ddlSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}