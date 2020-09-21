using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAVL.Forms
{
    public partial class SpeedReport : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
            }
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)dcDate).SetDate(DateTime.Now);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            WebAVL.Controls.Search.JSearchDevice sd = ((WebAVL.Controls.Search.JSearchDevice)searchDevice);
            string imei = sd.IMEI;
            if (String.IsNullOrEmpty(imei))
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفا یک دستگاه را انتخاب نمایید.');", "ConfirmDialog");
                return;
            }
            AVL.RegisterDevice.JRegisterDevice device = new AVL.RegisterDevice.JRegisterDevice(imei);
            if (device == null || device.Code < 1)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفا یک دستگاه را انتخاب نمایید.');", "ConfirmDialog");
                return;
            }
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            string query = string.Format(@"select 
Max( Code) Code,Speed,
Min(DeviceSendDateTime) StartDate,
	            max(DeviceSendDateTime) EndDate,
	            DATEDIFF(minute,min(DeviceSendDateTime),Max(DeviceSendDateTime)) Minute 
			  from AVLCoordinate
where  DeviceCode={0} and DeviceSendDateTime between '{1}' and '{1} 23:59:59' AND Speed>0
group by Speed,DeviceCode
having(DATEDIFF(minute,min(DeviceSendDateTime),Max(DeviceSendDateTime)))>0",device.Code,
                ((WebControllers.MainControls.Date.JDateControl)dcDate).GetDate().ToString("yyyy-MM-dd"));
            RadGridReport.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            RadGridReport.PageSize = 50;
            RadGridReport.HiddenColumns = "Code";
            RadGridReport.Title = "SpeedReport";
            RadGridReport.Buttons = "excel,print,record_print";
            RadGridReport.SQL = query;
            RadGridReport.ClassName = "WebAVL.Forms.SpeedReport";
            RadGridReport.ObjectCode = 0;

            RadGridReport.Actions = new List<WebClassLibrary.JActionsInfo>();
            RadGridReport.Actions.Add(new WebClassLibrary.JActionsInfo("GridItemDblClick", WebClassLibrary.JDomains.JActionEvents.GridItemDblClick, "WebAVL.JWebAVL" + "._ShowMarkerOnMap", null, null));

            //if (WebClassLibrary.SessionManager.Current.Session["WebClassLibrary.JWebDataBase.GetPagerData." + "WebAVL.Forms.JStopReport.0"] != null)
            //{
            //    try
            //    {
            //        (WebClassLibrary.SessionManager.Current.Session["WebClassLibrary.JWebDataBase.GetPagerData." + "WebAVL.Forms.JStopReport.0"] as ClassLibrary.JDataBase).Dispose();
            //    }
            //    catch
            //    {
            //    }
            //}
            //WebClassLibrary.SessionManager.Current.Session.Add("WebClassLibrary.JWebDataBase.GetPagerData." + "WebAVL.Forms.JStopReport.0" + ".DB", DB);

            RadGridReport.Bind();
        }
    }
}